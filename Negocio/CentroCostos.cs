using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;

namespace Negocio
{
    public class CentroCostos : CommonBC
    {
        private int CentroId { get; set; }
        private string CentroNombre { get; set; }
        private Nullable<int> Centro_Codigo { get; set; }
        private Nullable<int> EstructuraSueldo_Id { get; set; }
        private Nullable<bool> Vigencia { get; set; }

        public List<MssBD.CentrosDeCostos> BuscaCentroCostos(MssBD.Usuarios _usu, Boolean DeFormCentros)
        {
            try
            {
                List<MssBD.CentrosDeCostos> listCentros = new List<MssBD.CentrosDeCostos>();
                List<CentroCostos> _lst = new List<CentroCostos>();
                switch (_usu.Privilegio_Id)
                {
                    case 1:
                        if (DeFormCentros)
                        {

                            listCentros = (from p in Modelo_BDMSS.CentrosDeCostos
                                           orderby p.CentroNombre
                                           select p).ToList();
                        }
                        else
                        {
                            listCentros = (from p in Modelo_BDMSS.CentrosDeCostos
                                           where p.Vigencia == true
                                           orderby p.CentroNombre
                                           select p).ToList();
                        }
                        break;
                    case 2:
                        if (DeFormCentros)
                        {
                            listCentros = (from p in Modelo_BDMSS.CentrosDeCostos
                                           where p.CentroId != 26
                                           orderby p.CentroNombre
                                           select p).ToList();
                        }
                        else
                        {
                            listCentros = (from p in Modelo_BDMSS.CentrosDeCostos
                                           where p.Vigencia == true && p.CentroId != 26
                                           orderby p.CentroNombre
                                           select p).ToList();
                        }
                        break;
                    default:
                        listCentros = (from p in Modelo_BDMSS.CentrosDeCostos
                                       where p.Vigencia == true && p.CentroId != 26
                                       orderby p.CentroNombre
                                       select p).ToList();
                        break;
                }

                if (listCentros.Count() > 0)
                {
                    //foreach (var item in listCentros)
                    //{
                    //    item.CentroNombre = string.Concat(item.Centro_Codigo, " - ", item.CentroNombre);
                    //}

                    return listCentros;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean EliminaCentroCosto(MssBD.Usuarios _usu, MssBD.CentrosDeCostos _centro)
        {
            try
            {
                Modelo_BDMSS.CentrosDeCostos.Remove(_centro);
                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha eliminado el Centro de Costo ", _centro.CentroNombre));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean GuardarCentro(MssBD.Usuarios _usu, MssBD.CentrosDeCostos _centro)
        {
            try
            {
                Modelo_BDMSS.CentrosDeCostos.Add(_centro);
                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha guardado nuevo Centro de Costo ", _centro.CentroNombre));

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean ModificaCentro(MssBD.Usuarios _usu, MssBD.CentrosDeCostos _centro)
        {
            try
            {
                var _act = (from p in Modelo_BDMSS.CentrosDeCostos
                            where p.Centro_Codigo == _centro.Centro_Codigo
                            select p).First();
                //Modelo_BDMSS.Entry(_centro).State = Modelo_BDMSS.Modified;
                _act.CentroNombre = _centro.CentroNombre;
                _act.Vigencia = _centro.Vigencia;
                _act.EstructuraSueldo_Id = _centro.EstructuraSueldo_Id;

                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha modificado Centro de Costo ", _centro.CentroNombre));

                return true;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Boolean VerificaCódigo(MssBD.CentrosDeCostos _centro)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.CentrosDeCostos
                            where p.Centro_Codigo == _centro.Centro_Codigo
                            select p;

                if (lista.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Boolean VerificaCódigo(Int32 Codigo)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.CentrosDeCostos
                            where p.Centro_Codigo == Codigo
                            select p;

                if (lista.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int EncuentraUltimoCodigo()
        {
            try
            {
                var lista = from p in Modelo_BDMSS.CentrosDeCostos
                            orderby p.Centro_Codigo descending
                            select p;

                if (lista.Count() > 0)
                {
                    return (Int32)lista.OrderByDescending(x => x.Centro_Codigo).First().Centro_Codigo + 1; //.Centro_Codigo + 1;
                }

                return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
