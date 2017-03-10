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
    public partial class BusquedaEmpleados : Form
    {
        Negocio.Localidades _localidades = new Negocio.Localidades();
        Negocio.Usuario _Usu = new Negocio.Usuario();
        MssBD.Usuarios _usuSesion;
        Negocio.Personal _Empleado = new Negocio.Personal();
        Negocio.CentroCostos _Centro = new Negocio.CentroCostos();

        public BusquedaEmpleados(MssBD.Usuarios _usu)
        {
            _usuSesion = _usu;
            InitializeComponent();
        }

        private void Busqueda_Load(object sender, EventArgs e)
        {
            PintaPantalla();
        }

        private void PintaPantalla()
        {
            try
            {

                //Pintar paises
                List<MssBD.Paises> listPaises = new List<MssBD.Paises>();
                listPaises = _localidades.BuscaPais();

                if (listPaises != null)
                {
                    cboPais.DataSource = listPaises;
                    cboPais.DisplayMember = "Pais_Nombre";
                    cboPais.ValueMember = "Pais_Codigo";
                    cboPais.SelectedIndex = 0;
                }

                //Pinta Centros de Costo
                List<MssBD.CentrosDeCostos> listaCentros = new List<MssBD.CentrosDeCostos>();
                listaCentros = _Centro.BuscaCentroCostos(_usuSesion, false);

                if (listaCentros != null)
                {
                    cboCentroCostos.DataSource = listaCentros;
                    cboCentroCostos.DisplayMember = "CentroNombre";
                    cboCentroCostos.ValueMember = "CentroId";
                    cboCentroCostos.SelectedItem = -1;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboRegiones_SelectedValueChanged(object sender, EventArgs e)
        {
            //Pintar Provincias
            MssBD.Regiones reg = (MssBD.Regiones)cboRegiones.SelectedItem;

            if (reg != null)
            {
                List<MssBD.Provincias> listaPro = new List<MssBD.Provincias>();
                listaPro = _localidades.BuscaProvincia(reg.region_id);

                if (listaPro != null)
                {
                    cboProvincias.DataSource = listaPro;
                    cboProvincias.DisplayMember = "provincia_nombre";
                    cboProvincias.ValueMember = "provincia_id";
                    cboProvincias.SelectedItem = -1;
                }
            }
        }

        private void cboProvincias_SelectedValueChanged(object sender, EventArgs e)
        {
            //Pintar Comunas
            MssBD.Provincias pro = (MssBD.Provincias)cboProvincias.SelectedItem;

            if (pro != null)
            {
                List<MssBD.Comunas> listaCom = new List<MssBD.Comunas>();
                listaCom = _localidades.BuscaComunas(pro.provincia_id);
                if (listaCom != null)
                {
                    cboComunas.DataSource = listaCom;
                    cboComunas.DisplayMember = "comuna_nombre";
                    cboComunas.ValueMember = "comuna_nombre";
                    cboComunas.SelectedItem = 0;
                }
            }
        }

        private void cboPais_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Pintar Regiones
            MssBD.Paises _pais = (MssBD.Paises)cboRegiones.SelectedItem;

            if (_pais != null)
            {
                List<MssBD.Regiones> listaReg = new List<MssBD.Regiones>();
                listaReg = _localidades.BuscaRegion(_pais.Pais_Codigo);

                if (listaReg != null)
                {
                    cboRegiones.DataSource = listaReg;
                    cboRegiones.DisplayMember = "region_nombre";
                    cboRegiones.ValueMember = "region_id";
                    cboRegiones.SelectedItem = 0;
                }
            }
        }

        private void cboPais_SelectedValueChanged(object sender, EventArgs e)
        {
            //Pintar Regiones
            if (IsNumeric(cboPais.SelectedValue.ToString()))
            {
                List<MssBD.Regiones> listaReg = new List<MssBD.Regiones>();
                listaReg = _localidades.BuscaRegion(int.Parse(cboPais.SelectedValue.ToString()));

                if (listaReg != null)
                {
                    cboRegiones.DataSource = listaReg;
                    cboRegiones.DisplayMember = "region_nombre";
                    cboRegiones.ValueMember = "";
                    cboRegiones.SelectedItem = 0;
                }
            }
        }

        public bool IsNumeric(string input)
        {
            int test;
            return int.TryParse(input, out test);
        }

        private void txtRut_TextChanged(object sender, EventArgs e)
        {
            if (txtRut.Text != string.Empty)
            {
                txtDv.Text = retornaDv(txtRut.Text.Replace(",", "").Replace(".", ""));
                BuscaEmpleado();
            }
            else
            {
                txtDv.Text = string.Empty;
            }
        }

        private String retornaDv(String _Rut)
        {
            int suma = 0;
            for (int x = _Rut.Length - 1; x >= 0; x--)
                suma += int.Parse(char.IsDigit(_Rut[x]) ? _Rut[x].ToString() : "0") * (((_Rut.Length - (x + 1)) % 6) + 2);
            int numericDigito = (11 - suma % 11);
            string digito = numericDigito == 11 ? "0" : numericDigito == 10 ? "K" : numericDigito.ToString();
            return digito;
        }

        private void BuscaEmpleado()
        {
            try
            {
                List<MssBD.CON_Empleados_Rut_Centro_Result> _listEmpleados = new List<MssBD.CON_Empleados_Rut_Centro_Result>();
                MssBD.CentrosDeCostos _centro = (MssBD.CentrosDeCostos)cboCentroCostos.SelectedItem;

                Int32 _rut;
                Int32 _dv;
                if (!Int32.TryParse(txtRut.Text.Replace(".", "").Replace(",", ""), out _rut))
                {
                    _rut = 0;
                }
                if (!Int32.TryParse(txtDv.Text, out _dv))
                {
                    _dv = 0;
                }

                _listEmpleados = _Empleado.ConsultaPersonal_RutApellidosCentroCostos(_usuSesion, _rut, txtApellidos.Text, _centro.CentroId);
                gridEmpleados.DataSource = _listEmpleados;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void txtApellidos_TextChanged(object sender, EventArgs e)
        {
            if (txtApellidos.Text != string.Empty)
            {
                BuscaEmpleado();
            }
        }

        private void cboCentroCostos_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuscaEmpleado();
        }

        private void cboPais_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            try
            {
                List<MssBD.Regiones> listRegiones = new List<MssBD.Regiones>();
                MssBD.Paises _pais = (MssBD.Paises)cboPais.SelectedItem;

                listRegiones = _localidades.BuscaRegion(Int32.Parse(_pais.Pais_Codigo.ToString()));

                if (listRegiones != null)
                {
                    cboRegiones.DataSource = listRegiones;
                    cboRegiones.DisplayMember = "region_nombre";
                    cboRegiones.ValueMember = "region_id";
                    cboRegiones.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show(String.Concat("No se han podido cargar las Regiones"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void cboRegiones_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MssBD.Provincias> listProvincias = new List<MssBD.Provincias>();
            MssBD.Regiones _region = (MssBD.Regiones)cboRegiones.SelectedItem;
            listProvincias = _localidades.BuscaProvincia(Int32.Parse(_region.region_id.ToString()));

            if (listProvincias != null)
            {
                cboProvincias.DataSource = listProvincias;
                cboProvincias.DisplayMember = "provincia_nombre";
                cboProvincias.ValueMember = "provincia_id";
                cboProvincias.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(String.Concat("No se han podido cargar las Provincias"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboProvincias_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MssBD.Comunas> listComunas = new List<MssBD.Comunas>();
            MssBD.Provincias _provi = (MssBD.Provincias)cboProvincias.SelectedItem;
            listComunas = _localidades.BuscaComunas(Int32.Parse(_provi.provincia_id.ToString()));

            if (listComunas != null)
            {
                cboComunas.DataSource = listComunas;
                cboComunas.DisplayMember = "comuna_nombre";
                cboComunas.ValueMember = "comuna_id";
                cboComunas.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show(String.Concat("No se han podido cargar las Comunas"), "Mss", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
