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
    public partial class Visar_Anexos : Form
    {

        Negocio.Documentos.Anexos _Doc = new Negocio.Documentos.Anexos();
        MssBD.Usuarios _usuarioSesion;

        public Visar_Anexos(MssBD.Usuarios _usuarioS)
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
                MssBD.VW_DOC_Anexos _vw = new MssBD.VW_DOC_Anexos();
                gridContratos.DataSource = _Doc.BuscaAnexos_Visar(_usuarioSesion, txtDesde.Value, txtHasta.Value);
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
                List<MssBD.VW_DOC_Anexos> _ListGrilla = new List<MssBD.VW_DOC_Anexos>();
                List<MssBD.VW_DOC_Anexos> _ListGuardar = new List<MssBD.VW_DOC_Anexos>();

                this.gridContratos.Refresh();

                _ListGrilla = (List<MssBD.VW_DOC_Anexos>)this.gridContratos.DataSource;
                if (this.gridContratos.DataSource == null || _ListGrilla.Count() < 1)
                {
                    return;
                }

                foreach (DataGridViewRow item in this.gridContratos.Rows)
                {
                    if ((Boolean)item.Cells["porVisarDataGridViewCheckBoxColumn"].Value)
                    {
                        _ListGuardar.Add((MssBD.VW_DOC_Anexos)item.DataBoundItem);
                    }
                }

                if (_ListGuardar.Count == 0)
                {
                    MessageBox.Show(String.Concat("Debe seleccionar algún Anexos a autorizar."), "Mss", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    return;
                }

                String mensaje = string.Empty;
                Folder.ShowDialog();
                if (Folder.SelectedPath.ToString() != string.Empty)
                {
                    Negocio.Documentos.Anexos _Contrato = new Negocio.Documentos.Anexos(_usuarioSesion);

                    _Contrato._RutaInicioProyecto = System.Windows.Forms.Application.StartupPath;

                      if (!_Contrato.GenereAnexosMasivos(ref mensaje, _ListGuardar, String.Concat(Folder.SelectedPath.ToString(), "\\")))
                    {
                        if (mensaje == string.Empty)
                        {
                            MessageBox.Show(String.Concat("Ha ocurrido un problema al generar Anexos."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show(String.Concat(mensaje), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show(String.Concat("Anexos se han generado con éxito."), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
