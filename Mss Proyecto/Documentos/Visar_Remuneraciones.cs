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
    public partial class Visar_Remuneraciones : Form
    {
        MssBD.Usuarios _usuarioSesion;
        Negocio.Personal _Empleado = new Negocio.Personal();
        Negocio.Documentos.Remuneracion _NegRemu;
        MssBD.VW_DOC_Finiquitos _Finiquito = null;

        public Visar_Remuneraciones(MssBD.Usuarios _usu, MssBD.VW_DOC_Finiquitos _Finiquitos)
        {
            _Finiquito = new MssBD.VW_DOC_Finiquitos();
            _Finiquito = _Finiquitos;
            _usuarioSesion = _usu;
            InitializeComponent();
        }

        private void Finiquitos_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            //Pinta Centros de Costo
            CargaDatos();
            BuscaRemuneraciones();
        }

        private void CargaDatos()
        {
            try
            {
                MssBD.Personal selectedUser = new MssBD.Personal();
                selectedUser = _Empleado.BuscaPersonalPorRut((Int32)_Finiquito.Rut);

                txtRutDato.Text = selectedUser.Rut.ToString();

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

                cboArticulo.Text  = _Finiquito.Articulo;
                txtNumeroArt.Text = _Finiquito.Articulo_Numero.ToString();
                txtMotivo.Text = _Finiquito.Comentario;
                txtVacaciones.Text = _Finiquito.Vacaciones.ToString();
                txtTotalRemuneraciones.Text = _Finiquito.MontoTotal.ToString();

                if (txtRutDato.Text != string.Empty)
                    txtRutDato.Text = string.Format("{0:#,##0}", double.Parse(txtRutDato.Text));
                else
                    txtRutDato.Text = "0";

                if (txtVacaciones.Text != string.Empty)
                    txtVacaciones.Text = string.Format("{0:#,##0}", double.Parse(txtVacaciones.Text));
                else
                    txtVacaciones.Text = "0";

                if (txtTotalRemuneraciones.Text != string.Empty)
                    txtTotalRemuneraciones.Text = string.Format("{0:#,##0}", double.Parse(txtTotalRemuneraciones.Text));
                else
                    txtTotalRemuneraciones.Text = "0";

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void BuscaRemuneraciones()
        {
            try
            {
                List<MssBD.Remuneraciones> _listRemus = new List<MssBD.Remuneraciones>();
                _NegRemu = new Negocio.Documentos.Remuneracion();
                _listRemus = _NegRemu.BuscaRemuneraciones(_usuarioSesion, (Int32)_Finiquito.Finiquito_Id);

                gridRemuneraciones.DataSource = _listRemus;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
