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
    public partial class Usuario : Form
    {

        public MssBD.Personal _personal { get; set; }
        MssBD.Usuarios _usuarioSesion;
        public Boolean nuevo { get; set; }

        public Usuario(MssBD.Usuarios _usuSesion)
        {
            _usuarioSesion = _usuSesion;

            InitializeComponent();
            PintaPantalla(nuevo);
        }

        public Usuario(MssBD.Usuarios _usuSesion, Boolean NuevaContraseña)
        {
            _usuarioSesion = _usuSesion;
            if (NuevaContraseña)
            {
                this.ControlBox = false;
            }

            InitializeComponent();
            PintaPantalla(nuevo);
        }

        private void PintaPantalla(Boolean nuevo)
        {
            if (!nuevo)
            {
                txtUsuario.Enabled = false;
                txtUsuario.Text = _usuarioSesion.Usuario_Nombre;
                Negocio.Personal _per = new Personal();

                this._personal = _per.BuscaPersonalPorIdUsuario(_usuarioSesion.Usuario_Id);
            }
        }

        private void Usuario_Load(object sender, EventArgs e)
        {

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (txtPassword.Text != txtPassword2.Text)
                {
                    MessageBox.Show("Contraseñas no son iguales, favor corregir", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                _usuarioSesion.Usuario_Password = txtPassword.Text;

                Negocio.Usuario _negUsu = new Negocio.Usuario();
                _negUsu.CambioContraseña(_usuarioSesion);

                MessageBox.Show("Se ha guardado contraseña con éxito.", "Mss", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                if (nuevo)
                {
                    this.Hide();
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
    }
}
