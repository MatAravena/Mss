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
    public partial class EstructuraSueldos : Form
    {
        Negocio.EstructuraSueldos _estru = new Negocio.EstructuraSueldos();
        MssBD.Usuarios _usuarioSesion;

        public EstructuraSueldos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
            InitializeComponent();
        }

        private void EstructuraSueldos_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            //Pinta Cbo Centro Principal
            cboEstructuras.DataSource = _estru.BuscaEstructuras(_usuarioSesion);
            cboEstructuras.DisplayMember = "Descripcion";
            cboEstructuras.ValueMember = "Estructura_Codigo";
        }

        private void cboEstructuras_SelectedIndexChanged(object sender, EventArgs e)
        {
            MssBD.EstructuraSueldos _estructura = (MssBD.EstructuraSueldos)cboEstructuras.SelectedItem;

            if (_estructura != null)
            {
                txtEstructuraCodigo.Text = _estructura.Estructura_Codigo.ToString();
                txtDescipcion.Text = _estructura.Descripcion;
                txtSueldoBase.Text = _estructura.SueldoBase.ToString();
                txtGratificacion.Text = _estructura.Gratificacion.ToString();
                txtBonoAsistencia.Text = _estructura.BonoAsistencia.ToString();
                txtBonoProduccion.Text = _estructura.BonoProduccion.ToString();
                txtColacion.Text = _estructura.Colacion.ToString();
                txtMovilizacion.Text = _estructura.Movilizacion.ToString();
            }
            FormatCampos();
        }

        private void btnNuevo_Click_1(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                txtEstructuraCodigo.Text = _estru.EncuentraUltimoCodigo().ToString();
                BtnLimpiar_Click(sender, e);
                btnEliminar.Enabled = false;
                btnNuevo.Enabled = false;
                grp.Enabled = false;
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                MssBD.EstructuraSueldos _estruct = (MssBD.EstructuraSueldos)cboEstructuras.SelectedItem;
                if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea eliminar Estructura de Sueldo ", _estruct.Estructura_Codigo, " ", _estruct.Descripcion),
                    "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;

                if (!_estru.EliminaEstructura(_usuarioSesion, _estruct))
                {
                    MessageBox.Show("Se ha eliminado Estructura de Sueldos con éxito", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLimpiar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminado Estructura de Sueldos.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MssBD.EstructuraSueldos _struct = new MssBD.EstructuraSueldos();

                if (ValidaPantala(ref _struct))
                {
                    if (_estru.VerificaCódigo(_struct))
                    {
                        if (_estru.ModificaEstructura(_usuarioSesion, _struct))
                        {
                            MessageBox.Show(String.Concat("Estructura de Sueldo '", _struct.Descripcion, "' se ha guardado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnLimpiar_Click(sender, e);
                            PintaPantalla();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido guardadar Estructura de Sueldos.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                    else
                    {
                        if (_estru.GuardarEstructura(_usuarioSesion, _struct))
                        {
                            MessageBox.Show("Estructura de Sueldo se ha guardado con éxito.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            BtnLimpiar_Click(sender, e);
                            PintaPantalla();
                        }
                        else
                        {
                            MessageBox.Show("No se ha podido guardadar Estructura de Sueldos.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
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

        private bool ValidaPantala(ref MssBD.EstructuraSueldos _struct)
        {
            try
            {
                if (txtEstructuraCodigo.Text == string.Empty)
                {
                    MessageBox.Show("Falta código de Estructuras.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }
                if (txtDescipcion.Text == string.Empty)
                {
                    MessageBox.Show("Falta descripción de Estructuras.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return false;
                }

                Double _monto = 0;
                Int32 _montoInt = 0;

                if (Int32.TryParse(txtEstructuraCodigo.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _montoInt))
                    _struct.Estructura_Codigo = _montoInt;
                else
                    _struct.Estructura_Codigo = 0;

                _struct.Descripcion = txtDescipcion.Text;

                if (Double.TryParse(txtSueldoBase.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.SueldoBase = _monto;
                else
                    _struct.SueldoBase = 0;

                if (Double.TryParse(txtGratificacion.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.Gratificacion = _monto;
                else
                    _struct.Gratificacion = 0;

                if (Double.TryParse(txtBonoAsistencia.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.BonoAsistencia = _monto;
                else
                    _struct.BonoAsistencia = 0;

                if (Double.TryParse(txtBonoProduccion.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.BonoProduccion = _monto;
                else
                    _struct.BonoProduccion = 0;

                if (Double.TryParse(txtColacion.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.Colacion = _monto;
                else
                    _struct.Colacion = 0;

                if (Double.TryParse(txtMovilizacion.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.Movilizacion = _monto;
                else
                    _struct.Movilizacion = 0;

                if (Double.TryParse(txtTurno.Text.Replace(".", string.Empty).Replace(",", string.Empty).Replace(" ", string.Empty), out _monto))
                    _struct.BonoTurno = _monto;
                else
                    _struct.BonoTurno = 0;

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            btnEliminar.Enabled = true;
            btnNuevo.Enabled = true;
            grp.Enabled = true;
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

        private void txtEstructuraCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
            try
            {
                //long intToFormat;
                //intToFormat = long.Parse(txtEstructuraCodigo.Text);
                //txtEstructuraCodigo.Text = string.Empty;
                //this.txtEstructuraCodigo.Text = intToFormat.ToString("###,###", CultureInfo.CurrentCulture);
            }
            catch (FormatException)
            {
            }

            //txtEstructuraCodigo.Text = String.Format(CultureInfo.InvariantCulture, "{0:###.###.###}", txtEstructuraCodigo.Text.ToString("0,0", elGR));
        }

        private void FormatCampos()
        {
            if (txtSueldoBase.Text != string.Empty)
                txtSueldoBase.Text = string.Format("{0:#,##0}", double.Parse(txtSueldoBase.Text));
            else
                txtSueldoBase.Text = "0";


            if (txtGratificacion.Text != string.Empty)
                txtGratificacion.Text = string.Format("{0:#,##0}", double.Parse(txtGratificacion.Text));
            else
                txtGratificacion.Text = "0";

            if (txtBonoAsistencia.Text != string.Empty)
                txtBonoAsistencia.Text = string.Format("{0:#,##0}", double.Parse(txtBonoAsistencia.Text));
            else
                txtBonoAsistencia.Text = "0";

            if (txtTurno.Text != string.Empty)
                txtTurno.Text = string.Format("{0:#,##0}", double.Parse(txtTurno.Text));
            else
                txtTurno.Text = "0";

            if (txtBonoProduccion.Text != string.Empty)
                txtBonoProduccion.Text = string.Format("{0:#,##0}", double.Parse(txtBonoProduccion.Text));
            else
                txtBonoProduccion.Text = "0";

            if (txtColacion.Text != string.Empty)
                txtColacion.Text = string.Format("{0:#,##0}", double.Parse(txtColacion.Text));
            else
                txtColacion.Text = "0";

            if (txtMovilizacion.Text != string.Empty)
                txtMovilizacion.Text = string.Format("{0:#,##0}", double.Parse(txtMovilizacion.Text));
            else
                txtMovilizacion.Text = "0";
        }

    }
}
