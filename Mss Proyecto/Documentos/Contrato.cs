using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Mss_Proyecto
{
    public partial class Contrato : Form
    {
        MssBD.Usuarios _usuarioSesion;
        Negocio.CentroCostos _Centros = new Negocio.CentroCostos();
        Negocio.Personal _Empleado = new Negocio.Personal();
        MssBD.CON_Empleados_Rut_Centro_Result _ConsultaEmp = null;
        Negocio.EstructuraSueldos _Estructuras = new Negocio.EstructuraSueldos();
        Negocio.Previsiones _Previsiones = new Negocio.Previsiones();
        Negocio.Documentos.Contratos _Contrato;
        Negocio.Documentos.Documento _Documento;
        Negocio.Bancos _Bancos = new Negocio.Bancos();

        public Contrato(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
            InitializeComponent();
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            if (txtRut.Text != string.Empty)
            {
                txtDv.Text = retornaDv(txtRut.Text.Replace(",", String.Empty).Replace(".", String.Empty));
                BuscaEmpleado();
            }
            else
            {
                txtDv.Text = string.Empty;
            }
        }

        private void BuscaEmpleado()
        {
            try
            {
                List<MssBD.CON_Empleados_Rut_Centro_Result> _listEmpleados = new List<MssBD.CON_Empleados_Rut_Centro_Result>();
                MssBD.CentrosDeCostos _centro = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

                Int32 _rut;
                Int32 _dv;
                if (!Int32.TryParse(txtRut.Text.Replace(".", "").Replace(",", ""), out _rut))
                {
                    _rut = 0;
                }
                if (!Int32.TryParse(txtDv.Text, out _dv))
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

        private void gridEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmpleados.Rows.Count < 1)
                {
                    return;
                }

                var selectedUser = (MssBD.CON_Empleados_Rut_Centro_Result)this.gridEmpleados.CurrentRow.DataBoundItem;
                _ConsultaEmp = selectedUser;

                txtRutDato.Text = selectedUser.Rut.ToString().Replace(",", String.Empty).Replace(".", String.Empty);

                txtDvDato.Text = selectedUser.Dv;

                if (txtRutDato.Text != string.Empty)
                    txtRutDato.Text = string.Format("{0:#,##0}", double.Parse(txtRutDato.Text));
                else
                    txtRutDato.Text = "0";

                txtApellidoPaterno.Text = selectedUser.ApellidoPaterno;
                txtApellidoMaterno.Text = selectedUser.ApellidoMaterno;
                txtNombres.Text = selectedUser.Nombres;
                txtDireccion.Text = selectedUser.Direccion;

                txtFechaContrato.Value = DateTime.Now;

                if (selectedUser.FechaNacimiento != null)
                { txtFechaNacimiento.Value = (DateTime)selectedUser.FechaNacimiento; }
                else
                { txtFechaNacimiento.Value = DateTime.Parse("19000101"); }

                if (selectedUser.FechaIngreso != null)
                { txtFechaInicio.Value = (DateTime)selectedUser.FechaIngreso; }
                else
                { txtFechaInicio.Value = DateTime.Parse("19000101"); }

                if (selectedUser.FechaVencimiento != null)
                { txtFechaVencimiento.Value = (DateTime)selectedUser.FechaVencimiento; }
                else
                { txtFechaVencimiento.Value = DateTime.Parse("19000101"); }

                txtTeleFijo.Text = selectedUser.TelFijo;
                txtTeleCel.Text = selectedUser.TelCelular;

                //Datos Contratos
                cboTipoContrato.Text = selectedUser.TipoContrato;
                cboCursoOS10.Text = selectedUser.CursoOS10;
                txtCredencial.Text = selectedUser.Credencial;

                // Centro y Estructuras
                if (selectedUser.CentroCosto_Id != null)
                    cboCentroCostoInfo.SelectedValue = selectedUser.CentroCosto_Id;
                else
                    cboCentroCostoInfo.SelectedItem = -1;

                if (selectedUser.EstructuraSueldo_Id != null)
                    cboEstructuraSueldo.SelectedValue = selectedUser.EstructuraSueldo_Id;
                else
                    cboEstructuraSueldo.SelectedItem = -1;

                try
                {
                    cboEstadoCivil.SelectedItem = selectedUser.EstadoCivil;
                }
                catch (Exception)
                {
                }

                //Previsiones
                if (selectedUser.Afp_Id != null)
                    cboAfp.SelectedValue = selectedUser.Afp_Id;
                else
                    cboAfp.SelectedItem = -1;
                if (selectedUser.Isapre_Id != null)
                    cboIsapre.SelectedValue = selectedUser.Isapre_Id;
                else
                    cboIsapre.SelectedItem = -1;

                //Cuentas Corrientes
                txtNumeroCuenta.Text = selectedUser.NumeroCuenta;

                if (selectedUser.Id_Banco != null)
                    cboBancos.SelectedValue = selectedUser.Id_Banco;
                else
                    cboBancos.SelectedItem = -1;

                cboTipoCuenta.Text = selectedUser.TipoCuenta;
                if (selectedUser.Privilegio_Id == 5)
                {
                    txtCargo.Text = "Guardia";
                    txtAnticipo.Text = "60000";
                }
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

        private void btnGenerarContrato_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MssBD.CentrosDeCostos _cen = new MssBD.CentrosDeCostos();
                MssBD.EstructuraSueldos _est = new MssBD.EstructuraSueldos();
                MssBD.Afp _Afp = new MssBD.Afp();
                MssBD.Isapres _Isapre = new MssBD.Isapres();

                String mensaje = string.Empty;
                Boolean Visacion = true;

                _Contrato = new Negocio.Documentos.Contratos(_usuarioSesion);

                // Valida si existe Contrato d persona
                if (_Contrato.ValidaContrato(_ConsultaEmp.Rut))
                { MessageBox.Show(String.Concat(PrimeraMayuscula(_ConsultaEmp.Nombres), " ", PrimeraMayuscula(_ConsultaEmp.ApellidoPaterno), " ya posee contrato. Si desea cambiar información del Contrato creado por favor generar Anexo para éste empleado.w2|9uv      uuu"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information); }

                if (!ValidaDatos(ref _est, ref _Afp, ref _Isapre, ref _cen))
                { return; }

                if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea generar Contrato a '", txtNombres.Text, " ", txtApellidoPaterno.Text, "' \n", "Con la Estructura de Sueldo '", _est.Descripcion, "'"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                { return; }

                _ConsultaEmp.FechaIngreso = txtFechaInicio.Value;
                _ConsultaEmp.FechaVencimiento = txtFechaVencimiento.Value;

                _ConsultaEmp.Afp_Id = _Afp.Afp_Id;
                _ConsultaEmp.Isapre_Id = _Isapre.Isapre_Id;
                _ConsultaEmp.EstructuraSueldo_Id = _est.EstructuraSueldo_Id;
                _ConsultaEmp.TipoContrato = cboTipoContrato.Text;
                _ConsultaEmp.CentroCosto_Id = _cen.CentroId;

                //Valores de Pantalla a Contrato
                Double _anticipo = 0;

                _Contrato._RutaFinal = String.Concat(Folder.SelectedPath.ToString(), "\\");
                _Contrato._SegundoParrafo = txtSegundoParrafo.Text;
                _Contrato._DireccionInstalacion = txtInstalacion.Text;

                if (Double.TryParse(txtAnticipo.Text, out _anticipo))
                { _Contrato._Anticipo = _anticipo; }

                _Contrato._per = _ConsultaEmp;
                _Contrato._RutaInicioProyecto = System.Windows.Forms.Application.StartupPath;

                //Registra Contrato, en caso que usuario no tenga permisos necesarios.
                Int32 _Doc_Id = 0;
                _Documento = new Negocio.Documentos.Documento();

                Folder.ShowDialog();
                if (Folder.SelectedPath.ToString() == string.Empty)
                {
                    return;
                }

                if (_usuarioSesion.Privilegio_Id < 2)
                {
                    Visacion = false;
                }

                if (!_Documento.RegistrarDocumento(1, _usuarioSesion, _ConsultaEmp, Visacion, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref  mensaje, ref _Doc_Id))
                {
                    if (mensaje == string.Empty)
                    {
                        MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    if (_Documento.RegistrarContrato(1, _usuarioSesion, _ConsultaEmp, Visacion, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref mensaje, _Doc_Id))
                    {
                        if (!Visacion)
                        {
                            MessageBox.Show(String.Concat("Contrato se ha registrado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }

                //En caso que usuario va a generar contrato por Permisos
                if (!Visacion)
                {
                    _Contrato._RutaFinal = String.Concat(Folder.SelectedPath.ToString(), "\\");
                    if (!_Contrato.GeneraContrato(ref mensaje))
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al generar el Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Contrato se ha generado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MensajeControlado mensa = new MensajeControlado(String.Concat("Éste error se produce por que Window no ha podido reproducir el documento.", Environment.NewLine,
                          "Para poder solucionar este problema debe cerrar documentos Offices en su computador o evitar la sobre carga de procesos en su computador que pueda ocacionar que su computador no tengo la suficiente memoria para crear el nuevo documento."), ex.Message, ex);
                mensa.Show();
                return;
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

        private bool ValidaDatos(ref MssBD.EstructuraSueldos _est, ref MssBD.Afp _Afp, ref MssBD.Isapres _Isapre, ref MssBD.CentrosDeCostos _Cen)
        {
            if (_ConsultaEmp == null)
            {
                MessageBox.Show(String.Concat("Debe seleccionar a algún empleado."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                _est = (MssBD.EstructuraSueldos)cboEstructuraSueldo.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show(String.Concat("Empledo no posee una estructura de sueldo asociada. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _est = null;
                return false;
            }

            try
            {
                _Afp = (MssBD.Afp)cboAfp.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show(String.Concat("Empledo no posee Afp asociada. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Afp = null;
                return false;
            }

            try
            {
                _Isapre = (MssBD.Isapres)cboIsapre.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show(String.Concat("Empledo no posee Isapre asociada. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Isapre = null;
                return false;
            }

            try
            {
                _Cen = (MssBD.CentrosDeCostos)cboCentroCostoInfo.SelectedItem;
            }
            catch (Exception)
            {
                MessageBox.Show(String.Concat("Empledo no posee Centro de Costo asociado. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                _Isapre = null;
                return false;
            }

            if (String.Equals(txtDireccion.Text, String.Empty))
            {
                MessageBox.Show(String.Concat("Empledo no posee dirección. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }

            if (String.Equals(cboEstadoCivil.Text, String.Empty))
            {
                MessageBox.Show(String.Concat("Empledo no posee estado Civil. No se podrá generar Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return false;
            }
            if (txtFechaInicio.Value.Date > txtFechaVencimiento.Value.Date)
            {
                MessageBox.Show(String.Concat("Fecha de inicio de Contrato no puede ser mayor a la fecha de vencimiento de éste."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtFechaInicio.Value.Date == txtFechaVencimiento.Value.Date && !cboTipoContrato.Text.Equals("INDEFINIDO"))
            {
                MessageBox.Show(String.Concat("Fecha de inicio de Contrato no puede ser igual a la fecha de vencimiento de éste."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (DateTime.Compare(txtFechaInicio.Value.Date, txtFechaVencimiento.Value.Date) > 365 && !cboTipoContrato.Text.Equals("INDEFINIDO"))
            {
                MessageBox.Show(String.Concat("Fecha de inicio de Contrato no puede ser igual a la fecha de vencimiento de éste."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtTeleFijo.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+", "") == string.Empty && txtTeleCel.Text.Replace("(", "").Replace(")", "").Replace("_", "").Replace("+56", "") == string.Empty)
            {
                MessageBox.Show(String.Concat("Empleado debe tener al menos un teléfono para generar el contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtCargo.Text == string.Empty)
            {
                MessageBox.Show(String.Concat("Empleado debe tener un cargo profesional para generar el contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtAnticipo.Text == string.Empty)
            {
                MessageBox.Show(String.Concat("Empleado debe tener Anticipo para generar el contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtInstalacion.Text == string.Empty)
            {
                MessageBox.Show(String.Concat("Empleado debe tener una Instalacíon asociada para generar el contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Contrato_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            try
            {

                //Pinta Centros de Costo
                List<MssBD.CentrosDeCostos> listaCentros = new List<MssBD.CentrosDeCostos>();
                listaCentros = _Centros.BuscaCentroCostos(_usuarioSesion, false);

                List<MssBD.CentrosDeCostos> listaCentros2 = new List<MssBD.CentrosDeCostos>();
                listaCentros2 = _Centros.BuscaCentroCostos(_usuarioSesion, false);

                if (listaCentros != null)
                {
                    if (_usuarioSesion.Privilegio_Id < 2)
                    {
                        listaCentros.RemoveAt(1);
                    }
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
                    cboAfp.DisplayMember = "Afp_Nombre";
                    cboAfp.ValueMember = "Afp_Id";
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

        private void cboCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaEmpleado();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Contrato_Load(sender, e);
            LimpiarPantalla();
            Cursor.Current = Cursors.Default;
        }

        private void LimpiarPantalla()
        {
            foreach (Control controlChotex in this.Controls)
            {
                if (controlChotex.HasChildren)
                {
                    foreach (Control c in controlChotex.Controls)
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
                }
            }
        }

        public string PrimeraMayuscula(string value)
        { return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower()); }
    }
}
