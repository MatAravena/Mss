using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Negocio;

namespace Mss_Proyecto
{
    public partial class Principal : Form
    {
        MssBD.Privilegios _privilegiosSesion = new MssBD.Privilegios();
        MssBD.Usuarios _usuarioSesion = new MssBD.Usuarios();
        Privilegios _privilegios = new Privilegios();

        private static Empleados emp = null;
        private static BusquedaEmpleados bus = null;
        private static EstructuraSueldos est = null;
        private static CentroDeCostos centro = null;
        private static Finiquitos _fini = null;
        private static Anexos _anexo = null;
        private static Contrato _contr = null;
        private static Visar_Contratos _visCont = null;
        private static Visar_Anexos _VisAne = null;
        private static Visar_Finiquitos _visFini = null;
        private static Logs _logs = null;
        private static Usuario _usu = null;

        public Principal(MssBD.Usuarios Usuario_)
        {
            _privilegiosSesion = _privilegios.ConsultaPrivilegiosDeUsuarios(Usuario_);
            if (_privilegiosSesion == null)
            {
                MessageBox.Show(String.Concat("Problemas para consultar los privilegios del Usuario ", Usuario_.Usuario_Nombre.ToString()), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Dispose();
            }
            _usuarioSesion = Usuario_;
            InitializeComponent();
            DibujaMenu(_privilegiosSesion);
        }

        private void DibujaMenu(MssBD.Privilegios _privilegios)
        {
            switch (_usuarioSesion.Privilegio_Id)
            {
                case 1:
                case 2:
                    break;
                default:
                    logToolStripMenuItem.Visible = false;
                    break;
            }
        }

        private void Principal_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void historialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (bus == null || !bus.Created)
                {
                    bus = new BusquedaEmpleados(_usuarioSesion);
                    bus.MdiParent = this;
                    bus.Show();
                }
                else
                {
                    bus.Activate();
                    bus.BringToFront();
                    if (bus.MinimizeBox)
                    {
                        bus.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void datosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (emp == null || !emp.Created)
                {
                    emp = new Empleados(_usuarioSesion);
                    emp.MdiParent = this;
                    emp.Show();
                }
                else
                {
                    emp.Activate();
                    emp.BringToFront();
                    if (emp.MinimizeBox)
                    {
                        emp.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void contratoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_contr == null || !_contr.Created)
                {
                    _contr = new Contrato(_usuarioSesion);
                    _contr.MdiParent = this;
                    _contr.Show();
                }
                else
                {
                    _contr.Activate();
                    _contr.BringToFront();
                    if (_contr.MinimizeBox)
                    {
                        _contr.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_logs == null || !_logs.Created)
                {
                    _logs = new Logs(_usuarioSesion);
                    _logs.MdiParent = this;
                    _logs.Show();
                }
                else
                {
                    _logs.Activate();
                    _logs.BringToFront();
                    if (_logs.MinimizeBox)
                    {
                        _logs.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void Principal_Load(object sender, EventArgs e)
        {
        }

        private void usuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_usu == null || !_usu.Created)
                {
                    _usu = new Usuario(_usuarioSesion);
                    _usu.MdiParent = this;
                    _usu.Show();
                }
                else
                {
                    _usu.Activate();
                    _usu.BringToFront();
                    if (_usu.MinimizeBox)
                    {
                        _usu.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        public static Boolean _MensajeControlado(String mensaje, Exception ex)
        {
            try
            {
                Cursor.Current = Cursors.Default;
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                mensa.Show();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private void vigenciaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void estructuraDeSueldosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;

                if (est == null || !est.Created)
                {
                    est = new EstructuraSueldos(_usuarioSesion);
                    est.MdiParent = this;
                    est.Show();
                }
                else
                {
                    est.Activate();
                    est.BringToFront();
                    if (est.MinimizeBox)
                    {
                        est.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void centroDeCostosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_contr == null || !_contr.Created)
                {
                    _contr = new Contrato(_usuarioSesion);
                    _contr.MdiParent = this;
                    _contr.Show();
                }
                else
                {
                    _contr.Activate();
                    _contr.BringToFront();
                    if (_contr.MinimizeBox)
                    {
                        _contr.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void generaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_anexo == null || !_anexo.Created)
                {
                    _anexo = new Anexos(_usuarioSesion);
                    _anexo.MdiParent = this;
                    _anexo.Show();
                }
                else
                {
                    _anexo.Activate();
                    _anexo.BringToFront();
                    if (_anexo.MinimizeBox)
                    {
                        _anexo.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void visadoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_VisAne == null || !_VisAne.Created)
                {
                    _VisAne = new Visar_Anexos(_usuarioSesion);
                    _VisAne.MdiParent = this;
                    _VisAne.Show();
                }
                else
                {
                    _VisAne.Activate();
                    _VisAne.BringToFront();
                    if (_VisAne.MinimizeBox)
                    {
                        _VisAne.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void generaciónToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_fini == null || !_fini.Created)
                {
                    _fini = new Finiquitos(_usuarioSesion);
                    _fini.MdiParent = this;
                    _fini.Show();
                }
                else
                {
                    _fini.Activate();
                    _fini.BringToFront();
                    if (_fini.MinimizeBox)
                    {
                        _fini.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void visadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_visFini == null || !_visFini.Created)
                {
                    _visFini = new Visar_Finiquitos(_usuarioSesion);
                    _visFini.MdiParent = this;
                    _visFini.Show();
                }
                else
                {
                    _visFini.Activate();
                    _visFini.BringToFront();
                    if (_visFini.MinimizeBox)
                    {
                        _visFini.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void visadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (_visCont == null || !_visCont.Created)
                {
                    _visCont = new Visar_Contratos(_usuarioSesion);
                    _visCont.MdiParent = this;
                    _visCont.Show();
                }
                else
                {
                    _visCont.Activate();
                    _visCont.BringToFront();
                    if (_visCont.MinimizeBox)
                    {
                        _visCont.MinimizeBox = true;
                    }
                }
            }
            catch (Exception ex)
            {
                _MensajeControlado(ex.Message, ex);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void respaldadosToolStripMenuItem3_Click(object sender, EventArgs e)
        {

        }

    }
}
