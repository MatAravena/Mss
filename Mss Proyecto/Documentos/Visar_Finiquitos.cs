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
    public partial class Visar_Finiquitos : Form
    {

        Negocio.Documentos.Finiquitos _Doc = new Negocio.Documentos.Finiquitos();
        MssBD.Usuarios _usuarioSesion;

        public Visar_Finiquitos(MssBD.Usuarios _usuarioS)
        {
            _usuarioSesion = _usuarioS;
            InitializeComponent();
        }

        private void DocVisados_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            if (_usuarioSesion.Privilegio_Id > 2)
            {
                btnGuardar.Enabled = false;
                porVisarDataGridViewCheckBoxColumn.ReadOnly = true;
            }

            BuscaDocumentosVisados();
        }

        private void BuscaDocumentosVisados()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                MssBD.VW_DOC_Finiquitos _vw = new MssBD.VW_DOC_Finiquitos();
                gridContratos.DataSource = _Doc.BuscaFiniquitos_Visar(_usuarioSesion, txtDesde.Value, txtHasta.Value);
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

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            txtDesde.Value = DateTime.Now;
            txtHasta.Value = DateTime.Now;
            BuscaDocumentosVisados();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            BuscaDocumentosVisados();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                List<MssBD.VW_DOC_Finiquitos> _ListGrilla = new List<MssBD.VW_DOC_Finiquitos>();
                List<MssBD.VW_DOC_Finiquitos> _ListGuardar = new List<MssBD.VW_DOC_Finiquitos>();

                this.gridContratos.Refresh();

                _ListGrilla = (List<MssBD.VW_DOC_Finiquitos>)this.gridContratos.DataSource;
                if (this.gridContratos.DataSource == null || _ListGrilla.Count() < 1)
                {
                    return;
                }

                foreach (DataGridViewRow item in this.gridContratos.Rows)
                {
                    if ((Boolean)item.Cells["porVisarDataGridViewCheckBoxColumn"].Value)
                    {
                        _ListGuardar.Add((MssBD.VW_DOC_Finiquitos)item.DataBoundItem);
                    }
                }

                if (_ListGuardar.Count == 0)
                {
                    MessageBox.Show(String.Concat("Debe seleccionar algún Finiquito a autorizar."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                String mensaje = string.Empty;
                Folder.ShowDialog();
                if (Folder.SelectedPath.ToString() != string.Empty)
                {
                    Negocio.Documentos.Finiquitos _Contrato = new Negocio.Documentos.Finiquitos(_usuarioSesion);

                    _Contrato._RutaInicioProyecto = System.Windows.Forms.Application.StartupPath;

                    if (!_Contrato.GenereFiniquitosMasivos(ref mensaje, _ListGuardar, String.Concat(Folder.SelectedPath.ToString(), "\\")))
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al generar Finiquitos."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Finiquitos se han generado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    BuscaDocumentosVisados();
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

        private void gridContratos_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (gridContratos.Rows.Count < 1)
                {
                    return;
                }

                var selectedUser = (MssBD.VW_DOC_Finiquitos)this.gridContratos.CurrentRow.DataBoundItem;

                Visar_Remuneraciones _remu = new Visar_Remuneraciones(_usuarioSesion, selectedUser);
                _remu.MdiParent = this.MdiParent;
                _remu.Show();
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

        private void gridContratos_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (gridContratos.IsCurrentCellDirty)
            {
                gridContratos.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void gridContratos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (gridContratos.Columns[e.ColumnIndex].Name == "porVisarDataGridViewCheckBoxColumn")
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)gridContratos.Rows[e.RowIndex].Cells["porVisarDataGridViewCheckBoxColumn"];
                gridContratos.Rows[e.RowIndex].Cells["porVisarDataGridViewCheckBoxColumn"].Value = checkCell.Value;

                gridContratos.Invalidate();
            }
        }
    }
}
