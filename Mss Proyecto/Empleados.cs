using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Imaging;

namespace Mss_Proyecto
{
    public partial class Empleados : Form
    {
        Negocio.Localidades _localidades = new Negocio.Localidades();
        Negocio.Usuario _Usu = new Negocio.Usuario();
        Negocio.Personal _Empleado = new Negocio.Personal();
        Negocio.Privilegios _Privilegios = new Negocio.Privilegios();
        Negocio.CentroCostos _Centros = new Negocio.CentroCostos();
        Negocio.EstructuraSueldos _Estructuras = new Negocio.EstructuraSueldos();
        Negocio.Previsiones _Previsiones = new Negocio.Previsiones();
        Negocio.Bancos _Bancos = new Negocio.Bancos();

        MssBD.CON_Empleados_Rut_Centro_Result _PersonaSeleccionada = new MssBD.CON_Empleados_Rut_Centro_Result();

        MssBD.Usuarios _usuarioSesion;

        public Empleados(MssBD.Usuarios _usuarioS)
        {
            _usuarioSesion = _usuarioS;
            InitializeComponent();
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            if (txtRut.Text != string.Empty)
            {
                txtDv.Text = retornaDv(txtRut.Text.Replace(",", "").Replace(".", ""));
                BuscaEmpleado();
            }
            else
            {
                txtDv.Text = string.Empty;
            }
        }

        private String retornaDv(String _Rut)
        {
            int suma = 0;
            for (int x = _Rut.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(_Rut[x]) ? _Rut[x].ToString() : "0") * (((_Rut.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            return digito;
        }

        private void BuscaEmpleado()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                List<MssBD.CON_Empleados_Rut_Centro_Result> _listEmpleados = new List<MssBD.CON_Empleados_Rut_Centro_Result>();
                MssBD.CentrosDeCostos _centro = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

                Int32 _rut;
                Int32 _dv;
                if (!Int32.TryParse(txtRut.Text.Replace(".", "").Replace(",", ""), out _rut))
                {
                    _rut = 0;
                }
                else
                {
                    _rut = 0;
                }
                if (!Int32.TryParse(txtDv.Text, out _dv))
                {
                    _dv = 0;
                }
                else
                {
                    _dv = 0;
                }

                _listEmpleados = _Empleado.ConsultaPersonal_RutApellidosCentroCostos(_usuarioSesion, _rut, txtApellidos.Text, _centro.CentroId);
                gridEmpleados.DataSource = _listEmpleados;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Empleados_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            try
            {
                if (_usuarioSesion.Privilegio_Id > 2)
                {
                    btnEliminar.Enabled = false;
                }

                //Pintar paises
                List<MssBD.Paises> listPaises = new List<MssBD.Paises>();
                listPaises = _localidades.BuscaPais();

                if (listPaises != null)
                {
                    cboPais.DataSource = listPaises;
                    cboPais.DisplayMember = "Pais_Nombre";
                    cboPais.ValueMember = "Pais_Codigo";
                    cboPais.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar los Paises"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Pinta Centros de Costo
                List<MssBD.CentrosDeCostos> listaCentros = new List<MssBD.CentrosDeCostos>();
                List<MssBD.CentrosDeCostos> listaCentros2 = new List<MssBD.CentrosDeCostos>();
                listaCentros = _Centros.BuscaCentroCostos(_usuarioSesion, false);
                listaCentros2 = _Centros.BuscaCentroCostos(_usuarioSesion, false);

                if (listaCentros != null)
                {
                    cboCentroCostos.DataSource = listaCentros;
                    cboCentroCostos.DisplayMember = "CentroNombre";
                    cboCentroCostos.ValueMember = "CentroId";
                    cboCentroCostos.SelectedItem = -1;

                    cboCentroCostoInfo.DataSource = listaCentros2;
                    cboCentroCostoInfo.DisplayMember = "CentroNombre";
                    cboCentroCostoInfo.ValueMember = "CentroId";
                    cboCentroCostoInfo.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar los Centros de Costo"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Pinta Privilegios
                List<MssBD.Privilegios> listaPrivilegios = new List<MssBD.Privilegios>();
                listaPrivilegios = _Privilegios.ConsultaPrivilegiosListado(_usuarioSesion);

                if (listaPrivilegios != null)
                {
                    cboPrivilegios.DataSource = listaPrivilegios;
                    cboPrivilegios.DisplayMember = "Privilegio_Nombre";
                    cboPrivilegios.ValueMember = "Privilegio_Id";
                    cboPrivilegios.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar los privilegios"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                //Pinta Estructuras
                List<MssBD.EstructuraSueldos> listaEstructuras = new List<MssBD.EstructuraSueldos>();
                listaEstructuras = _Estructuras.BuscaEstructuras(_usuarioSesion);

                if (listaEstructuras != null)
                {
                    cboEstructuraSueldo.DataSource = listaEstructuras;
                    cboEstructuraSueldo.DisplayMember = "Descripcion";
                    cboEstructuraSueldo.ValueMember = "EstructuraSueldo_Id";
                    cboEstructuraSueldo.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar las Estructuras de Sueldo"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Estado Civil , Curso OS10, Tipo Contrato
                try
                { cboEstadoCivil.SelectedIndex = 1; }
                catch (Exception)
                { throw; }
                try
                { cboCursoOS10.SelectedIndex = 1; }
                catch (Exception)
                { throw; }
                try
                { cboTipoContrato.SelectedIndex = 1; }
                catch (Exception)
                { throw; }

                //Previsiones
                List<MssBD.Isapres> listaIsapres = new List<MssBD.Isapres>();
                listaIsapres = _Previsiones.BuscaAIsapre();

                if (listaIsapres != null)
                {
                    cboIsapre.DataSource = listaIsapres;
                    cboIsapre.DisplayMember = "Isapre_Nombre";
                    cboIsapre.ValueMember = "Isapre_Id";
                    cboIsapre.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar las Isapres."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                List<MssBD.Afp> listaAfps = new List<MssBD.Afp>();
                listaAfps = _Previsiones.BuscaAfps();

                if (listaAfps != null)
                {
                    cboAfp.DataSource = listaAfps;
                    cboAfp.ValueMember = "Afp_Id";
                    cboAfp.DisplayMember = "Afp_Nombre";
                    cboAfp.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar las Afps."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                List<MssBD.Bancos> listaBancos = new List<MssBD.Bancos>();
                listaBancos = _Bancos.BuscaPancos();

                if (listaBancos != null)
                {
                    cboBancos.DataSource = listaBancos;
                    cboBancos.ValueMember = "Id_Banco";
                    cboBancos.DisplayMember = "NombreBanco";
                    cboBancos.SelectedItem = -1;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar los Banco."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Empleados_Load(sender, e);
            LimpiarPantalla();
            _PersonaSeleccionada = null;
            Cursor.Current = Cursors.Default;
        }

        private void LimpiarPantalla()
        {
            foreach (var c in pnlDatosPersonal.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is Int32TextBox)
                {
                    ((Int32TextBox)c).Text = String.Empty;
                }
                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Text = String.Empty;
                }
                if (c is DateTimePicker)
                {
                    ((DateTimePicker)c).Value = DateTime.Now;
                }
            }

            foreach (var c in pnlDatosContactos.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is Int32TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is MaskedTextBox)
                {
                    ((MaskedTextBox)c).Text = String.Empty;
                }
            }

            foreach (var c in pnlCursoCredencial.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is Int32TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }

            foreach (var c in pnlRopaPersonal.Controls)
            {
                if (c is TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
                if (c is Int32TextBox)
                {
                    ((TextBox)c).Text = String.Empty;
                }
            }

            foreach (var c in pnlContrato.Controls)
            {
                if (c is DateTimePicker)
                {
                    ((DateTimePicker)c).Value = DateTime.Now;
                }
            }



            txtImagen.Image = null;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtRutDato.Text != string.Empty && txtDvDato.Text != string.Empty)
                {
                    MssBD.Personal _persEliminar = new MssBD.Personal();
                    _persEliminar.Rut = Int32.Parse(txtRutDato.Text.Replace(".", "").Replace(",", ""));
                    _persEliminar.Dv = txtDvDato.Text;

                    if (!_Empleado.ExistePersonal(_persEliminar))
                    {
                        MessageBox.Show(String.Concat("Empleado no existe en la Base de Datos."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea eliminar al Personal '", _persEliminar.Nombres, _persEliminar.ApellidoPaterno, _persEliminar.ApellidoMaterno, "'"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        return;
                    }

                    if (_Empleado.EliminaPersonal(_usuarioSesion, _persEliminar))
                    {
                        MessageBox.Show("Se ha eliminado Empleado con éxito", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        BtnLimpiar_Click(sender, e);
                        _PersonaSeleccionada = null;
                    }
                    else
                    {
                        MessageBox.Show("No se ha podido eliminado Empleado.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show(String.Concat("Debe seleccionar personal o ingresar Rut y Digito verificador en la sección 'Datos del Personal'."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _PersonaSeleccionada = null;
                    return;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void gridEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmpleados.Rows.Count < 1)
                {
                    return;
                }

                var selectedUser = (MssBD.CON_Empleados_Rut_Centro_Result)this.gridEmpleados.CurrentRow.DataBoundItem;
                _PersonaSeleccionada = selectedUser;

                txtRutDato.Text = selectedUser.Rut.ToString();

                txtDvDato.Text = selectedUser.Dv;

                if (txtRutDato.Text != string.Empty)
                    txtRutDato.Text = string.Format("{0:#,##0}", double.Parse(txtRutDato.Text));
                else
                    txtRutDato.Text = "0";

                txtApellidoPaterno.Text = selectedUser.ApellidoPaterno;
                txtApellidoMaterno.Text = selectedUser.ApellidoMaterno;
                txtNombres.Text = selectedUser.Nombres;
                txtDireccion.Text = selectedUser.Direccion;

                if (selectedUser.FechaNacimiento != null)
                { txtFechaNacimiento.Value = (DateTime)selectedUser.FechaNacimiento; }
                else
                { txtFechaNacimiento.Value = DateTime.Parse("19000101"); }

                if (selectedUser.FechaIngreso != null)
                { txtFechaContrato.Value = (DateTime)selectedUser.FechaIngreso; }
                else
                { txtFechaContrato.Value = DateTime.Parse("19000101"); }

                if (selectedUser.FechaVencimiento != null)
                { txtFechaVencimiento.Value = (DateTime)selectedUser.FechaVencimiento; }
                else
                { txtFechaVencimiento.Value = DateTime.Parse("19000101"); }

                txtTeleFijo.Text = selectedUser.TelFijo;
                txtTeleCel.Text = selectedUser.TelCelular.Replace("56", string.Empty);
                txtContactTeleFijo.Text = selectedUser.TelContactoFijo;
                txtContactTeleCelular.Text = selectedUser.TelContactoCelular;

                txtNombreContacto.Text = selectedUser.NombreContacto;
                txtParentesco.Text = selectedUser.Parentesco;

                //Datos Contratos
                cboTipoContrato.Text = selectedUser.TipoContrato;
                cboCursoOS10.Text = selectedUser.CursoOS10;
                txtCredencial.Text = selectedUser.Credencial;

                //Datos Ropa 
                txtCalzado.Text = selectedUser.Calzado.ToString();
                txtPantalon.Text = selectedUser.Pantalon;
                txtPolera.Text = selectedUser.Polera;
                txtCamisa.Text = selectedUser.Camisa;
                txtPolar.Text = selectedUser.Polar;
                txtCasaca.Text = selectedUser.Casaca;
                txtCorbata.Text = selectedUser.Corbata;
                txtGorro.Text = selectedUser.Gorro;
                txtCazadora.Text = selectedUser.Cazadora;

                //imagen 
                try
                {
                    MemoryStream _ms = new MemoryStream(selectedUser.Imagen);
                    txtImagen.Image = Image.FromStream(_ms);
                    _PersonaSeleccionada.Imagen = selectedUser.Imagen;

                    _ms.Dispose();
                    _ms = null;
                }
                catch (Exception)
                {
                    txtImagen.Image = null;
                }

                //Localidades
                try
                {
                    cboPais.SelectedValue = selectedUser.Pais_Codigo;
                    cboRegiones.SelectedValue = selectedUser.Region_Codigo;
                    cboProvincias.SelectedValue = selectedUser.Provincia_Codigo;
                    cboComunas.SelectedValue = selectedUser.Comuna_Codigo;
                }
                catch (Exception)
                { }

                //Privilegios Usuarios
                if (selectedUser.Privilegio_Id != null)
                    cboPrivilegios.SelectedValue = selectedUser.Privilegio_Id;
                else
                    cboPrivilegios.SelectedValue = 5;

                // Centro y Estructuras
                if (selectedUser.CentroCosto_Id != null)
                    cboCentroCostoInfo.SelectedValue = selectedUser.CentroCosto_Id;
                else
                    cboCentroCostoInfo.SelectedItem = -1;

                if (selectedUser.EstructuraSueldo_Id != null)
                    cboEstructuraSueldo.SelectedValue = selectedUser.EstructuraSueldo_Id;
                else
                    cboEstructuraSueldo.SelectedItem = -1;

                //Previsiones
                if (selectedUser.Afp_Id != null)
                    cboAfp.SelectedValue = selectedUser.Afp_Id;
                else
                    cboAfp.SelectedItem = -1;
                if (selectedUser.Isapre_Id != null)
                    cboIsapre.SelectedValue = selectedUser.Isapre_Id;
                else
                    cboIsapre.SelectedItem = -1;
                try
                {
                    cboEstadoCivil.SelectedItem = selectedUser.EstadoCivil;
                }
                catch (Exception)
                {
                }

                //Cuentas Corrientes
                txtNumeroCuenta.Text = selectedUser.NumeroCuenta;

                if (selectedUser.Id_Banco != null)
                    cboBancos.SelectedValue = selectedUser.Id_Banco;
                else
                    cboBancos.SelectedItem = -1;

                cboTipoCuenta.Text = selectedUser.TipoCuenta;
                txtCargo.Text = selectedUser.Cargo;

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (txtApellidos.Text != string.Empty)
            {
                BuscaEmpleado();
            }
        }

        private void cboCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaEmpleado();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtRutDato.Text != string.Empty && txtDvDato.Text != string.Empty)
                {
                    MssBD.Personal _emp = new MssBD.Personal();

                    if (ValidaDatos(_emp))
                    {
                        bool nuevo = false;

                        //if (!_Empleado.ExistePersonal(_emp))
                        //{
                        //    Usuario _us = new Usuario();
                        //    _us.nuevo = true;
                        //}

                        if (_Empleado.GuardaPersonal(_usuarioSesion, _emp, ref nuevo))
                        {
                            MessageBox.Show(String.Concat("Información de Personal se ha guardado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BuscaEmpleado();
                        }
                        else
                        {
                            MessageBox.Show(String.Concat("No se ha podido guardar la información del Personal."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show(String.Concat("Debe seleccionar personal o ingresar Rut y Digito verificador en la sección 'Datos del Personal'."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool ValidaDatos(MssBD.Personal _emp)
        {
            MssBD.Paises _pais;
            MssBD.Regiones _region;
            MssBD.Provincias _provincia;
            MssBD.Comunas _comuna;
            MssBD.Privilegios _usu;
            MssBD.CentrosDeCostos _cen;
            MssBD.EstructuraSueldos _est;
            MssBD.Afp _afp;
            MssBD.Bancos _banco;
            MssBD.Isapres _isa;
            try
            {
                _pais = (MssBD.Paises)cboPais.SelectedItem;
            }
            catch (Exception)
            { _pais = null; }
            try
            {
                _region = (MssBD.Regiones)cboRegiones.SelectedItem;
            }
            catch (Exception)
            { _region = null; }
            try
            {
                _provincia = (MssBD.Provincias)cboProvincias.SelectedItem;
            }
            catch (Exception)
            { _provincia = null; }
            try
            {
                _comuna = (MssBD.Comunas)cboComunas.SelectedItem;
            }
            catch (Exception)
            { _comuna = null; }
            try
            {
                _usu = (MssBD.Privilegios)cboPrivilegios.SelectedItem;
            }
            catch (Exception)
            { _usu = null; }

            //Centro // Estructura
            try
            {
                _cen = (MssBD.CentrosDeCostos)cboCentroCostoInfo.SelectedItem;
            }
            catch (Exception)
            { _cen = null; }

            try
            {
                _est = (MssBD.EstructuraSueldos)cboEstructuraSueldo.SelectedItem;
            }
            catch (Exception)
            { _est = null; }

            //Previsiones
            try
            {
                _afp = (MssBD.Afp)cboAfp.SelectedItem;
            }
            catch (Exception)
            { _afp = null; }
            try
            {
                _isa = (MssBD.Isapres)cboIsapre.SelectedItem;
            }
            catch (Exception)
            { _isa = null; }
            try
            {
                _banco = (MssBD.Bancos)cboBancos.SelectedItem;
            }
            catch (Exception)
            { _banco = null; }

            try
            {
                _emp.Rut = Int32.Parse(txtRutDato.Text.Replace(".", "").Replace(",", ""));
                _emp.Dv = txtDvDato.Text;
                _emp.ApellidoPaterno = txtApellidoPaterno.Text;
                _emp.ApellidoMaterno = txtApellidoMaterno.Text;
                _emp.Nombres = txtNombres.Text;
                _emp.Direccion = txtDireccion.Text;

                if (_pais != null)
                {
                    _emp.Pais_Codigo = _pais.Pais_Codigo;
                }
                else
                {
                    _emp.Pais_Codigo = null;
                }

                if (_region != null)
                {
                    _emp.Region_Codigo = _region.region_id;
                }
                else
                {
                    _emp.Region_Codigo = null;
                }

                if (_provincia != null)
                {
                    _emp.Provincia_Codigo = _provincia.provincia_id;
                }
                else
                {
                    _emp.Provincia_Codigo = null;
                }

                if (_comuna != null)
                {
                    _emp.Comuna_Codigo = _comuna.comuna_id;
                }
                else
                {
                    _emp.Comuna_Codigo = null;
                }

                _emp.FechaNacimiento = txtFechaNacimiento.Value;
                _emp.FechaIngreso = txtFechaContrato.Value;
                _emp.FechaVencimiento = txtFechaVencimiento.Value;

                _emp.TelFijo = txtTeleFijo.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+", "");
                _emp.TelCelular = txtTeleCel.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+56", "");
                _emp.TelContactoFijo = txtContactTeleFijo.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+", "");
                _emp.TelContactoCelular = txtContactTeleCelular.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+56", "");

                _emp.NombreContacto = txtNombreContacto.Text;
                _emp.Parentesco = txtParentesco.Text;

                //Datos Ropa
                _emp.TipoContrato = cboTipoContrato.Text;
                _emp.CursoOS10 = cboCursoOS10.Text;
                _emp.Credencial = txtCredencial.Text;

                //Datos Ropa
                Int16 _calzado;
                if (Int16.TryParse(txtCalzado.Text, out _calzado))
                {
                    _emp.Calzado = _calzado;
                }

                _emp.Pantalon = txtPantalon.Text;
                _emp.Polera = txtPolera.Text;
                _emp.Camisa = txtCamisa.Text;
                _emp.Polar = txtPolar.Text;
                _emp.Casaca = txtCasaca.Text;
                _emp.Corbata = txtCorbata.Text;
                _emp.Gorro = txtGorro.Text;
                _emp.Cazadora = txtCazadora.Text;

                //imagen
                try
                {
                    txtImagen.Refresh();
                    MemoryStream ms = new MemoryStream();

                    //using (var ms = new MemoryStream())
                    //{
                    txtImagen.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    //txtImagen.Image.Save(ms, txtImagen.Image.RawFormat);

                    _emp.Imagen = ms.ToArray();

                    ms.Dispose();
                    ms = null;
                    //}
                }
                catch (Exception)
                {
                    try
                    {
                        _emp.Imagen = _PersonaSeleccionada.Imagen;
                    }
                    catch (Exception)
                    {
                        _emp.Imagen = null;
                    }
                }

                // At this point the new bitmap has no MimeType
                // Need to output to memory stream
                //using (var m = new MemoryStream())
                //{
                //    txtImagen.Save(m, format);

                //    var img = Image.FromStream(m);

                //    //TEST
                //    img.Save("C:\\test.jpg");
                //    var bytes = PhotoEditor.ConvertImageToByteArray(img);
                //    return img;
                //}

                // Centro y Estructuras
                if (_cen != null)
                { _emp.CentroCosto_Id = _cen.CentroId; }
                else
                { _emp.CentroCosto_Id = null; }

                if (_est != null)
                { _emp.EstructuraSueldo_Id = _est.EstructuraSueldo_Id; }
                else
                { _emp.EstructuraSueldo_Id = null; }

                _emp.Estado = "";



                if (_usu != null)
                {
                    _emp.Usuarios = new MssBD.Usuarios();
                    _emp.Usuarios.Privilegio_Id = _usu.Privilegio_Id;
                }
                else
                {
                    _emp.Usuarios.Privilegio_Id = 5;
                }

                //Previsiones
                if (_afp != null)
                { _emp.Afp_Id = _afp.Afp_Id; }
                else
                { _emp.Afp_Id = null; }
                if (_isa != null)
                { _emp.Isapre_Id = _isa.Isapre_Id; }
                else
                { _emp.Isapre_Id = null; }

                try
                {
                    _emp.EstadoCivil = cboEstadoCivil.SelectedItem.ToString();
                }
                catch (Exception)
                {
                    _emp.EstadoCivil = null;
                }

                //
                _emp.Cargo = txtCargo.Text;

                if (_banco != null)
                { _emp.Id_Banco = _banco.Id_Banco; }
                else
                { _emp.Id_Banco = null; }

                _emp.NumeroCuenta = txtNumeroCuenta.Text;
                _emp.TipoCuenta = cboTipoCuenta.Text;


                //txtNumeroCuenta.Text = selectedUser.NumeroCuenta;
                //cboBancos.SelectedValue = selectedUser.Id_Banco;
                //cboTipoCuenta.SelectedText = selectedUser.TipoCuenta;
                //txtCargo.Text = selectedUser.Cargo;

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        private void txtRutDato_TextChanged(object sender, EventArgs e)
        {

            if (txtRutDato.Text != string.Empty)
            {
                txtDvDato.Text = retornaDv(txtRutDato.Text.Replace(",", "").Replace(".", ""));
            }
            else
            {
                txtDvDato.Text = string.Empty;
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                List<MssBD.Regiones> listRegiones = new List<MssBD.Regiones>();
                MssBD.Paises _pais = (MssBD.Paises)cboPais.SelectedItem;

                listRegiones = _localidades.BuscaRegion(Int32.Parse(_pais.Pais_Codigo.ToString()));

                if (listRegiones != null)
                {
                    cboRegiones.DataSource = listRegiones;
                    cboRegiones.DisplayMember = "region_nombre";
                    cboRegiones.ValueMember = "region_id";
                    cboRegiones.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar las Regiones"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void cboRegiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MssBD.Provincias> listProvincias = new List<MssBD.Provincias>();
            MssBD.Regiones _region = (MssBD.Regiones)cboRegiones.SelectedItem;
            listProvincias = _localidades.BuscaProvincia(Int32.Parse(_region.region_id.ToString()));

            if (listProvincias != null)
            {
                cboProvincias.DataSource = listProvincias;
                cboProvincias.DisplayMember = "provincia_nombre";
                cboProvincias.ValueMember = "provincia_id";
                cboProvincias.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(String.Concat("No se han podido cargar las Provincias"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<MssBD.Comunas> listComunas = new List<MssBD.Comunas>();
            MssBD.Provincias _provi = (MssBD.Provincias)cboProvincias.SelectedItem;
            listComunas = _localidades.BuscaComunas(Int32.Parse(_provi.provincia_id.ToString()));

            if (listComunas != null)
            {
                cboComunas.DataSource = listComunas;
                cboComunas.DisplayMember = "comuna_nombre";
                cboComunas.ValueMember = "comuna_id";
                cboComunas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(String.Concat("No se han podido cargar las Comunas"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtImagen_Click(object sender, EventArgs e)
        {
            if (txtImagen.Image != null)
            {
                Cursor.Current = Cursors.WaitCursor;
                Gigantografia _gin = new Gigantografia(txtImagen.Image, txtNombres.Text, txtApellidoPaterno.Text);
                _gin.MdiParent = this.MdiParent;
                _gin.Show();
                Cursor.Current = Cursors.Default;
            }
        }

        private void btnImagen_Click(object sender, EventArgs e)
        {
            try
            {
                // Se crea el OpenFileDialog
                _OpenFile = new OpenFileDialog();
                // Se muestra al usuario esperando una acción
                DialogResult result = _OpenFile.ShowDialog();

                // Si seleccionó un archivo (asumiendo que es una imagen lo que seleccionó)
                // la mostramos en el PictureBox de la inferfaz
                if (result == DialogResult.OK)
                {
                    txtImagen.Image = Image.FromFile(_OpenFile.FileName);
                    MemoryStream _ms = new MemoryStream();
                    txtImagen.Image.Save(_ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    _PersonaSeleccionada.Imagen = _ms.ToArray();
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return;
            }
        }

        private void btnImagenElimina_Click(object sender, EventArgs e)
        {
            try
            {
                txtImagen.Image = null;
                _PersonaSeleccionada.Imagen = null;
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return;
            }
        }

        private void cboPrivilegios_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int privi = 0;
                if (int.TryParse(cboPrivilegios.SelectedValue.ToString(), out privi))
                {
                    if (privi == 5)
                    {
                        txtCargo.Text = "Guardia";
                        return;
                    }
                }
            }
            catch (Exception ex)
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return;
            }
        }

        private void cboTipoContrato_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoContrato.Text == "INDEFINIDO")
            {
                txtFechaVencimiento.Enabled = false;
                txtFechaVencimiento.Value = DateTime.Now;
            }
            else
            {
                txtFechaVencimiento.Enabled = true;
            }
        }

    }
}

