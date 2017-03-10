using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using Negocio;

namespace Mss_Proyecto
{
    public partial class Inicio : Form
    {
        private Negocio.Usuario _UsuNeg = new Negocio.Usuario();
        public Inicio()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == string.Empty && txtPassword.Text == string.Empty)
                {
                    MessageBox.Show("Usuario Inválido.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                Cursor.Current = Cursors.WaitCursor;
                MssBD.Usuarios _usu = new MssBD.Usuarios();
                _usu.Usuario_Nombre = txtUsuario.Text;
                _usu.Usuario_Password = txtPassword.Text;
                Boolean nuevo = false;

                if (!_UsuNeg.ConsultaUsuarioIngreso(out _usu, _usu.Usuario_Nombre, _usu.Usuario_Password, ref nuevo))
                {
                    MessageBox.Show("Usuario Inválido.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Focus();
                    Cursor.Current = Cursors.Default;
                    return;
                }

                if (nuevo)
                {
                    Cursor.Current = Cursors.Default;
                    Usuario usu = new Usuario(_usu, true);
                    usu._personal = usu._personal;
                    usu.nuevo = true;
                    usu.ShowDialog();

                    usu.Hide();
                }

                this.Hide();
                Principal per = new Principal(_usu );
                per.IsMdiContainer = true;
                per.ShowDialog();

                Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                MensajeControlado mensa = new MensajeControlado("", ex.Message, ex);
                //mensa.MdiParent = this;
                mensa.Show();
                return;
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1_Click(sender, e);
            }
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            lblMensaje.Text = string.Empty;
        }

        private void Inicio_Load(object sender, EventArgs e)
        {
            txtUsuario.Focus();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtUsuario_Validating(object sender, CancelEventArgs e)
        {
            if (txtUsuario.Text.Length < 3)
            {
                Console.Write("Mal");
            }
        }
    }
}
