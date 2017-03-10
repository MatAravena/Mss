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
    public partial class Gigantografia : Form
    {
        public Gigantografia(Image _Imagen, String _Nombre, String _apellido)
        {
            InitializeComponent();
            txtImagen.Image = _Imagen;
            this.Text = String.Concat(_Nombre, " ", _apellido);
        }

        private void Gigantografia_Load(object sender, EventArgs e)
        {

        }
    }
}
