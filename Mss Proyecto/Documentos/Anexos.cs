using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mss_Proyecto
{
    public partial class Anexos : Form
    {
        MssBD.Usuarios _usuarioSesion;
        Negocio.CentroCostos _Centros = new Negocio.CentroCostos();
        Negocio.Personal _Empleado = new Negocio.Personal();
        MssBD.CON_Empleados_Rut_Centro_Result _ConsultaEmp = null;
        Negocio.Documentos.Anexos _Anexos;
        Negocio.Documentos.Documento _Documento;
        Negocio.Documentos.Contratos _Contrato;

        public Anexos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
            InitializeComponent();
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

        private void btnAnexo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                String mensaje = string.Empty;
                Boolean Visacion = false;

                if (!Valida())
                { return; }

                _Anexos = new Negocio.Documentos.Anexos(_usuarioSesion);
                _Documento = new Negocio.Documentos.Documento();

                _ConsultaEmp.FechaIngreso = txtFechaInicio.Value;
                _ConsultaEmp.FechaVencimiento = txtFechaVencimiento.Value;
                _Anexos._FechaAnexo = txtFechaAnexo.Value;
                _Anexos._TipoContrato = cboTipoContrato.Text;

                _Anexos._per = _ConsultaEmp;
                _Anexos._RutaInicioProyecto = System.Windows.Forms.Application.StartupPath;

                Int32 _ContratoId = 0;
                if (!_Documento.RetornaContratoId(_ConsultaEmp, ref mensaje, ref _ContratoId))
                {
                    if (mensaje == string.Empty)
                    {
                        MessageBox.Show(String.Concat("Ha ocurrido un problema al consultar contrato Previo."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (_usuarioSesion.Privilegio_Id < 2)
                {
                    Visacion = false;
                }

                //Registra Anexo
                Int32 _Doc_Id = 0;
                _Documento = new Negocio.Documentos.Documento();
                if (!_Documento.RegistrarDocumento(2, _usuarioSesion, _ConsultaEmp, Visacion, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref  mensaje, ref _Doc_Id))
                {
                    if (mensaje == string.Empty)
                    {
                        MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Anexo."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                else
                {

                    if (!Visacion)
                    {
                        Folder.ShowDialog();
                        if (Folder.SelectedPath.ToString() != string.Empty)
                        {
                            _Anexos._RutaFinal = String.Concat(Folder.SelectedPath.ToString(), "\\");

                            if (!_Anexos.GeneraAnexo(ref mensaje))
                            {
                                if (mensaje == string.Empty)
                                {
                                    MessageBox.Show(String.Concat("Ha ocurrido un problema al generar Anexo."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                        }
                    }

                    if (_Documento.RegistrarAnexo(2, _usuarioSesion, _ConsultaEmp, Visacion, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref mensaje, _ContratoId))
                    {
                        MessageBox.Show(String.Concat("Anexo se ha registrado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Anexo."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
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
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool Valida()
        {
            if (_ConsultaEmp == null)
            {
                MessageBox.Show(String.Concat("Debe seleccionar a algún empleado."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (txtFechaInicio.Value.Date > txtFechaVencimiento.Value.Date)
            {
                MessageBox.Show(String.Concat("Fecha de inicio de Anexo no puede ser mayor a la fecha de vencimiento de éste."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (txtFechaInicio.Value.Date == txtFechaVencimiento.Value.Date)
            {
                MessageBox.Show(String.Concat("Fecha de inicio de Anexo no puede ser igual a la fecha de vencimiento de éste."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
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

            _Contrato = new Negocio.Documentos.Contratos(_usuarioSesion);

            // Valida si existe Contrato de persona
            if (!_Contrato.ValidaContrato(_ConsultaEmp.Rut))
            {
                MessageBox.Show(String.Concat(PrimeraMayuscula(_ConsultaEmp.Nombres.ToLower()), " ", PrimeraMayuscula(_ConsultaEmp.ApellidoPaterno.ToLower()), " no posee contrato. Debe estar contratado anteriormente."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            _Documento = new Negocio.Documentos.Documento();
            // Valida si ya tiene contrato Indefinido
            //if (_Documento.RetornaContratoId(_ConsultaEmp))
            //{
            //    MessageBox.Show(String.Concat(PrimeraMayuscula(_ConsultaEmp.Nombres.ToLower()), " ", PrimeraMayuscula(_ConsultaEmp.ApellidoPaterno.ToLower()), " ya posee contrato Indefinido, no se puede realizar un Anexo de Contrato."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    return false;
            //}

            if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea generar Anexo a '", PrimeraMayuscula(txtNombres.Text), " ", PrimeraMayuscula(txtApellidoPaterno.Text), "'"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }

            return true;
        }

        private void Anexos_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            //Pinta Centros de Costo
            List<MssBD.CentrosDeCostos> listaCentros = new List<MssBD.CentrosDeCostos>();
            listaCentros = _Centros.BuscaCentroCostos(_usuarioSesion, false);

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
            }
            else
            {
                MessageBox.Show(String.Concat("No se han podido cargar los Centros de Costo"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            txtFechaAnexo.Value = DateTime.Now;
        }

        private void gridEmpleados_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmpleados.Rows.Count < 1)
                {
                    return;
                }
                Cursor.Current = Cursors.WaitCursor;

                var selectedUser = (MssBD.CON_Empleados_Rut_Centro_Result)this.gridEmpleados.CurrentRow.DataBoundItem;
                _ConsultaEmp = selectedUser;

                txtRutDato.Text = selectedUser.Rut.ToString();

                if (txtRutDato.Text != string.Empty)
                    txtRutDato.Text = string.Format("{0:#,##0}", double.Parse(txtRutDato.Text));
                else
                    txtRutDato.Text = "0";

                txtDvDato.Text = selectedUser.Dv;
                txtApellidoPaterno.Text = selectedUser.ApellidoPaterno;
                txtApellidoMaterno.Text = selectedUser.ApellidoMaterno;
                txtNombres.Text = selectedUser.Nombres;
                txtDireccion.Text = selectedUser.Direccion;

                txtFechaInicio.Value = selectedUser.FechaIngreso.Value;
                txtFechaVencimiento.Value = selectedUser.FechaVencimiento.Value;
                cboTipoContrato.Text = selectedUser.TipoContrato;

                if (selectedUser.FechaNacimiento != null)
                {
                    txtFechaNacimiento.Value = (DateTime)selectedUser.FechaNacimiento;
                }
                else
                {
                    txtFechaNacimiento.Value = DateTime.Parse("19000101");
                }

                txtTeleFijo.Text = selectedUser.TelFijo;
                txtTeleCel.Text = selectedUser.TelCelular;
                try
                {
                    cboEstadoCivil.SelectedItem = selectedUser.EstadoCivil;
                }
                catch (Exception)
                {
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Anexos_Load(sender, e);
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
