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
    public partial class Logs : Form
    {
        private MssBD.Usuarios _UsuarioSesion;
        Negocio.LogClass _Logs;

        public Logs(MssBD.Usuarios _usu)
        {
            _UsuarioSesion = _usu;
            InitializeComponent();
        }

        private void Logs_Load(object sender, EventArgs e)
        {
        }

        private void BuscaLog()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _Logs = new Negocio.LogClass();
                gridLogs.DataSource = _Logs.BuscaLog(_UsuarioSesion, txtDesde.Value, txtHasta.Value);
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

        private void txtDesde_ValueChanged(object sender, EventArgs e)
        {
            BuscaLog();
        }

        private void txtHasta_ValueChanged(object sender, EventArgs e)
        {
            BuscaLog();
        }
    }
}
