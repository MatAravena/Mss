using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mss_Proyecto
{
    public partial class Finiquitos : Form
    {
        MssBD.Usuarios _usuarioSesion;
        Negocio.CentroCostos _Centros = new Negocio.CentroCostos();
        Negocio.Personal _Empleado = new Negocio.Personal();
        Negocio.Documentos.Finiquitos _finiquito;
        Negocio.Documentos.Documento _Documento;
        MssBD.CON_Empleados_Rut_Centro_Result _ConsultaEmp = null;

        DateTimePicker dtpInicio;
        DateTimePicker dtpTermino;

        public Finiquitos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
            InitializeComponent();
        }

        private void Finiquitos_Load(object sender, EventArgs e)
        {
            PintaPantalla();

            dtpInicio = new DateTimePicker();
            dtpInicio.Format = DateTimePickerFormat.Short;
            dtpInicio.Visible = false;
            dtpInicio.Width = 100;

            dtpTermino = new DateTimePicker();
            dtpTermino.Format = DateTimePickerFormat.Short;
            dtpTermino.Visible = false;
            dtpTermino.Width = 100;

            gridRemuneraciones.Controls.Add(dtpInicio);
            gridRemuneraciones.Controls.Add(dtpTermino);

            dtpInicio.ValueChanged += this.dtpInicio_ValueChanged;
            dtpTermino.ValueChanged += this.dtpTermino_ValueChanged;

            gridRemuneraciones.CellBeginEdit += this.gridRemuneraciones_CellBeginEdit;
            gridRemuneraciones.CellEndEdit += this.gridRemuneraciones_CellEndEdit;

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

        private void BuscaEmpleado()
        {
            try
            {
                List<MssBD.CON_Empleados_Rut_Centro_Result> _listEmpleados = new List<MssBD.CON_Empleados_Rut_Centro_Result>();
                MssBD.CentrosDeCostos _centro = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

                Int32 _rut;
                Int32 _dv;
                if (!Int32.TryParse(txtRut.Text.Replace(".", "").Replace(",", ""), out _rut))
                { _rut = 0; }

                if (!Int32.TryParse(txtDv.Text, out _dv))
                { _dv = 0; }


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

        private void cboCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaEmpleado();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (!ValidaDatos())
                {
                    return;
                }

                String mensaje = string.Empty;

                _finiquito = new Negocio.Documentos.Finiquitos(_usuarioSesion);

                _ConsultaEmp.FechaIngreso = txtFechaInicio.Value;
                _ConsultaEmp.FechaVencimiento = txtFechaVencimiento.Value;

                _finiquito._RutaFinal = String.Concat(Folder.SelectedPath.ToString(), "\\");
                _finiquito._per = _ConsultaEmp;
                _finiquito._Articulo = cboArticulo.Text;
                _finiquito._Motivo = txtMotivo.Text.Trim();
                _finiquito._NumeroArticulo = txtNumeroArt.Text.Trim();

                Double vacaciones, totalremu = 0;
                if (!Double.TryParse(txtVacaciones.Text.Replace("$", "").Replace(",", "").Replace(".", ""), out vacaciones))
                {
                    vacaciones = 0;
                }
                if (!Double.TryParse(txtTotalRemuneraciones.Text.Replace("$", "").Replace(",", "").Replace(".", ""), out totalremu))
                {
                    totalremu = 0;
                }

                _finiquito._Vacaciones = vacaciones;
                _finiquito._Total = totalremu;

                _finiquito._RutaInicioProyecto = System.Windows.Forms.Application.StartupPath;

                IDictionary<int, Negocio.Documentos.Remuneracion> _listRemu = new Dictionary<int, Negocio.Documentos.Remuneracion>();

                foreach (DataGridViewRow item in gridRemuneraciones.Rows)
                {
                    if (gridRemuneraciones["FechaInicio", item.Index].Value != null &&
                            gridRemuneraciones["FechaVencimiento", item.Index].Value != null &&
                                gridRemuneraciones["Monto", item.Index].Value != null)
                    {
                        Negocio.Documentos.Remuneracion _remu = new Negocio.Documentos.Remuneracion();

                        DateTime aaa;
                        double _monto;

                        if (double.TryParse(gridRemuneraciones["Monto", item.Index].Value.ToString(), out  _monto))
                        {
                            if (_monto == 0)
                            { continue; }
                            _remu.Monto = _monto;
                        }
                        else
                        { continue; }

                        if (DateTime.TryParse(gridRemuneraciones["FechaInicio", item.Index].Value.ToString(), out  aaa))
                        { _remu.FechaInicio = aaa; }
                        else
                        { _remu.FechaInicio = DateTime.Now; }

                        if (DateTime.TryParse(gridRemuneraciones["FechaVencimiento", item.Index].Value.ToString(), out  aaa))
                        { _remu.FechaTermino = aaa; }
                        else
                        { _remu.FechaInicio = DateTime.Now; }

                        _listRemu.Add(item.Index, _remu);
                    }
                }

                if (_usuarioSesion.Privilegio_Id < 2)
                {
                    Folder.ShowDialog();
                    if (Folder.SelectedPath.ToString() != string.Empty)
                    {
                        _finiquito._RutaFinal = String.Concat(Folder.SelectedPath.ToString(), "\\");
                        if (!_finiquito.GeneraFiniquito(ref mensaje, _listRemu))
                        {
                            if (mensaje == string.Empty)
                            {
                                MessageBox.Show(String.Concat("Ha ocurrido un problema al generar finiquito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            MessageBox.Show(String.Concat("Finiquito se ha generado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    //Registra Finiquito
                    Int32 _Doc_Id = 0;
                    _Documento = new Negocio.Documentos.Documento();
                    if (!_Documento.RegistrarDocumento(3, _usuarioSesion, _ConsultaEmp, true, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref  mensaje, ref _Doc_Id))
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Finiquito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        if (_Documento.RegistrarFiniquito(3, _usuarioSesion, _ConsultaEmp, true, String.Concat(Folder.SelectedPath.ToString(), "\\"), ref mensaje, _Doc_Id, _finiquito, _listRemu))
                        {
                            MessageBox.Show(String.Concat("Finiquito se ha registrado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            if (mensaje == string.Empty)
                            {
                                MessageBox.Show(String.Concat("Ha ocurrido un problema al registrar visado de Finiquito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
            }
            catch (System.Runtime.InteropServices.COMException ex)
            {
                MensajeControlado mensa = new MensajeControlado(String.Concat("Éste error se produce por que Window no ha podido reproducir el documento.", Environment.NewLine,
                            "Para poder solucionar este problema debe cerrar documentos Offices en su computador o evitar la sobre carga de procesos en su computador que pueda ocacionar que su computador no tengo la suficiente memoria para crear el nuevo documento."), ex.Message, ex);
                //mensa.MdiParent = this;
                mensa.Show();
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

        private Boolean ValidaDatos()
        {
            if (_ConsultaEmp == null)
            {
                MessageBox.Show(String.Concat("Debe seleccionar a algún empleado."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (txtMotivo.Text == string.Empty)
            {
                MessageBox.Show(String.Concat("Debe ingresar un motivo de finiquito."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (txtNumeroArt.Text == string.Empty)
            {
                MessageBox.Show(String.Concat("Debe ingresar número de artículo."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }
            if (cboArticulo.Text == string.Empty)
            {

                MessageBox.Show(String.Concat("Debe seleccionar Artículo."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                return false;
            }

            if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea generar finiquito a '", txtNombres.Text, " ", txtApellidoPaterno.Text, "'"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
            {
                return false;
            }
            return true;
        }

        private void gridEmpleados_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridEmpleados.Rows.Count < 1)
                {
                    return;
                }

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

                if (selectedUser.FechaNacimiento != null)
                    txtFechaNacimiento.Value = (DateTime)selectedUser.FechaNacimiento;
                else
                    txtFechaNacimiento.Value = DateTime.Parse("19000101");

                txtTeleFijo.Text = selectedUser.TelFijo;
                txtTeleCel.Text = selectedUser.TelCelular;

                if (txtRutDato.Text != string.Empty)
                    txtRutDato.Text = string.Format("{0:#,##0}", double.Parse(txtRutDato.Text));
                else
                    txtRutDato.Text = "0";

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void gridRemuneraciones_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            try
            {
                if (gridRemuneraciones.Focused && gridRemuneraciones.CurrentCell.ColumnIndex == 0)
                {
                    dtpInicio.Location = gridRemuneraciones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtpInicio.Visible = true;
                    if (gridRemuneraciones.CurrentCell.Value != DBNull.Value && gridRemuneraciones.CurrentCell.Value != null)
                    {
                        dtpInicio.Value = (DateTime)gridRemuneraciones.CurrentCell.Value;
                    }
                    else
                    {
                        dtpInicio.Value = DateTime.Today;
                    }
                }
                else
                {
                    dtpInicio.Visible = false;
                }

                if (gridRemuneraciones.Focused && gridRemuneraciones.CurrentCell.ColumnIndex == 1)
                {
                    dtpTermino.Location = gridRemuneraciones.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false).Location;
                    dtpTermino.Visible = true;
                    if (gridRemuneraciones.CurrentCell.Value != DBNull.Value && gridRemuneraciones.CurrentCell.Value != null)
                    {
                        dtpTermino.Value = (DateTime)gridRemuneraciones.CurrentCell.Value;
                    }
                    else
                    {
                        dtpTermino.Value = DateTime.Today;
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        private void gridRemuneraciones_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (gridRemuneraciones.Focused && gridRemuneraciones.CurrentCell.ColumnIndex == 0)
                {
                    gridRemuneraciones.CurrentCell.Value = dtpInicio.Value.Date;
                }

                if (gridRemuneraciones.Focused && gridRemuneraciones.CurrentCell.ColumnIndex == 1)
                {
                    gridRemuneraciones.CurrentCell.Value = dtpTermino.Value.Date;
                }

                if (gridRemuneraciones.Focused && gridRemuneraciones.CurrentCell.ColumnIndex == 2)
                {
                    CalculaMonto();
                }
            }
            catch (Exception)
            {
            }
        }

        private void CalculaMonto()
        {
            try
            {

                double _monto = 0, total = 0, vacaciones = 0;
                foreach (DataGridViewRow item in gridRemuneraciones.Rows)
                {
                    if (gridRemuneraciones["Monto", item.Index].Value != null && double.TryParse(gridRemuneraciones["Monto", item.Index].Value.ToString(), out  _monto))
                    { total = total + _monto; }
                }
                if (!double.TryParse(txtVacaciones.Text.Replace("$", ""), out  vacaciones))
                {
                    vacaciones = 0;
                }

                txtTotalRemuneraciones.Text = (vacaciones + total).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void dtpInicio_ValueChanged(object sender, EventArgs e)
        {
            gridRemuneraciones.CurrentCell.Value = dtpInicio.Value.Date;
        }
        private void dtpTermino_ValueChanged(object sender, EventArgs e)
        {
            gridRemuneraciones.CurrentCell.Value = dtpTermino.Value.Date;
        }

        private void txtVacaciones_TextChanged(object sender, EventArgs e)
        {
            CalculaMonto();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            Finiquitos_Load(sender, e);
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
    }
}
