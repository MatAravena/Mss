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
    public partial class CentroDeCostos : Form
    {
        Negocio.CentroCostos _centro = new Negocio.CentroCostos();
        Negocio.EstructuraSueldos _estruc = new Negocio.EstructuraSueldos();
        List<MssBD.CentrosDeCostos> _centrosActuales = new List<MssBD.CentrosDeCostos>();
        Boolean nuevo;
        MssBD.Usuarios _usuarioSesion;

        public CentroDeCostos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
            InitializeComponent();
        }

        private void chkSi_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSi.Checked)
            {
                cboEstructura.Enabled = true;
                chkNo.Checked = false;
            }
            else
            {
                //chkNo.Checked = true;
                cboEstructura.Enabled = false;
            }
        }

        private void chkNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkNo.Checked)
            {
                cboEstructura.Enabled = false;
                chkSi.Checked = false;
            }
        }

        private void CentroDeCostos_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            Limpiame();

            _centrosActuales = _centro.BuscaCentroCostos(_usuarioSesion, true);
            //Pinta Cbo Centro Principal
            cboCentroCostos.DataSource = _centrosActuales;
            cboCentroCostos.DisplayMember = "CentroNombre";
            cboCentroCostos.ValueMember = "CentroId";

            //Pinta cbo Estructuras
            cboEstructura.DataSource = _estruc.BuscaEstructuras(_usuarioSesion);
            cboEstructura.DisplayMember = "Descripcion";
            cboEstructura.ValueMember = "EstructuraSueldo_Id";
        }

        private void cboCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            MssBD.CentrosDeCostos _centro = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

            txtCentroEdit.Text = _centro.Centro_Codigo.ToString();
            txtDescripcion.Text = _centro.CentroNombre.ToString();
            chkVigencia.Checked = (Boolean)_centro.Vigencia;
            txtDireccion.Text = _centro.Direccion;

            if (null != _centro.EstructuraSueldo_Id && _centro.EstructuraSueldo_Id > 0)
            {
                chkSi.Checked = true;
                cboEstructura.SelectedValue = _centro.EstructuraSueldo_Id;
            }
            else
            {
                cboEstructura.SelectedIndex = -1;
                chkNo.Checked = true;
            }
        }

        private void Limpiame()
        {
            nuevo = false;
            lblSugerencia.Visible = false;
            chkNo.Checked = true;
            cboCentroCostos.Enabled = true;
            txtCentroEdit.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            txtCentroEdit.Enabled = true;
            Limpiame();
            gprCentroPrincipal.Enabled = true;
            LimpiarPantalla();
            PintaPantalla();

            btnNuevo.Enabled = true;
            btnEliminar.Enabled = true;
            btnGuardar.Enabled = true;
            BtnLimpiar.Enabled = true;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MssBD.CentrosDeCostos _centroGuardar = new MssBD.CentrosDeCostos();
                Int32 CentroCodigo = 0;
                Int32.TryParse(txtCentroEdit.Text, out CentroCodigo);

                if (!ValidaDatos(_centroGuardar))
                {
                    return;
                }

                if (_centro.VerificaCódigo(CentroCodigo))
                {
                    if (DialogResult.Cancel == MessageBox.Show(String.Concat("¿Realmente desea modificar centro de costo?"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Question))
                    {
                        return;
                    }

                    if (_centro.ModificaCentro(_usuarioSesion, _centroGuardar))
                    {
                        MessageBox.Show(String.Concat("Centro de costo '", _centroGuardar.CentroNombre, "' se ha guardado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    if (_centro.GuardarCentro(_usuarioSesion, _centroGuardar))
                    {
                        MessageBox.Show(String.Concat("Nuevo centro de costo '", _centroGuardar.CentroNombre, "' se ha guardado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                BtnLimpiar_Click(sender, e);
                // if(_centro.GuardarCentro(  Mss_Proyecto.CentroDeCostos egg))
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

        private bool ValidaDatos(MssBD.CentrosDeCostos _centroGuardar)
        {
            try
            {
                if (txtCentroEdit.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar Codigo del nuevo Centro de costo", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    _centroGuardar.Centro_Codigo = Int32.Parse(txtCentroEdit.Text);
                }

                if (nuevo)
                {
                    if (_centro.VerificaCódigo(_centroGuardar))
                    {
                        MessageBox.Show(String.Concat("Éste código ", _centroGuardar.Centro_Codigo.ToString(), " de Centro de Costo ya existe"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return false;
                    }
                }

                if (txtDescripcion.Text == string.Empty)
                {
                    MessageBox.Show("Falta ingresar descripción del nuevo Centro de costo", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                else
                {
                    _centroGuardar.CentroNombre = txtDescripcion.Text;
                }

                _centroGuardar.Vigencia = chkVigencia.Checked;
                _centroGuardar.Direccion = txtDireccion.Text;

                if (chkSi.Checked)
                {
                    MssBD.EstructuraSueldos est = (MssBD.EstructuraSueldos)cboEstructura.SelectedItem;
                    _centroGuardar.EstructuraSueldo_Id = est.Estructura_Codigo;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                nuevo = true;
                btnNuevo.Enabled = false;
                btnEliminar.Enabled = false;

                Limpiame();
                lblSugerencia.Visible = true;
                gprCentroPrincipal.Enabled = false;

                txtCentroEdit.Text = _centro.EncuentraUltimoCodigo().ToString();
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

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MssBD.CentrosDeCostos _cent = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

                if (DialogResult.Cancel == MessageBox.Show(String.Concat("Realmente desea eliminar el centro '", _cent.CentroNombre, "'"), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation))
                {
                    return;
                }

                if (_centro.EliminaCentroCosto(_usuarioSesion, _cent))
                {
                    MessageBox.Show("Se ha eliminado Centro de Costos con éxito", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    BtnLimpiar_Click(sender, e);
                }
                else
                {
                    MessageBox.Show("No se ha podido eliminado Centro de Costos.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void txtDescripcion_Leave(object sender, EventArgs e)
        {
            txtDescripcion.Text = txtDescripcion.Text.ToUpper();
        }
    }
}
