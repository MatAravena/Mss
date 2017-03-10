using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;
namespace Negocio
{
    public class EstructuraSueldos : CommonBC
    {
        public List<MssBD.EstructuraSueldos> BuscaEstructuras(MssBD.Usuarios _usu)
        {
            try
            {
                List<MssBD.EstructuraSueldos> listEstructuras = new List<MssBD.EstructuraSueldos>();

                if (_usu.Privilegio_Id == 1 | _usu.Privilegio_Id == 2)
                {
                    listEstructuras = (from p in Modelo_BDMSS.EstructuraSueldos
                                       orderby p.Descripcion
                                       select p).ToList();
                }
                else
                {
                    listEstructuras = (from p in Modelo_BDMSS.EstructuraSueldos
                                       orderby p.Descripcion
                                       select p).ToList();
                }

                if (listEstructuras.Count() > 0)
                {
                    //foreach (var item in listEstructuras)
                    //{
                    //    item.Descripcion = string.Concat(item.Estructura_Codigo, " - ", item.Descripcion);
                    //}

                    return listEstructuras;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public Boolean EliminaEstructura(MssBD.Usuarios _usu, MssBD.EstructuraSueldos _estr)
        {
            try
            {
                Modelo_BDMSS.EstructuraSueldos.Remove(_estr);
                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha eliminado Estructura de Sueldo ", _estr.Estructura_Codigo));

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public Boolean GuardarEstructura(MssBD.Usuarios _usu, MssBD.EstructuraSueldos _estr)
        {
            try
            {
                Modelo_BDMSS.EstructuraSueldos.Add(_estr);
                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha guardado Estructura de Sueldo ", _estr.Estructura_Codigo));

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public Boolean ModificaEstructura(MssBD.Usuarios _usu, MssBD.EstructuraSueldos _estr)
        {
            try
            {
                var _act = (from p in Modelo_BDMSS.EstructuraSueldos
                            where p.Estructura_Codigo == _estr.Estructura_Codigo
                            select p).First();

                _act.Descripcion = _estr.Descripcion;
                _act.SueldoBase = _estr.SueldoBase;
                _act.Gratificacion = _estr.Gratificacion;
                _act.BonoAsistencia = _estr.BonoAsistencia;
                _act.BonoProduccion = _estr.BonoProduccion;
                _act.Colacion = _estr.Colacion;
                _act.Movilizacion = _estr.Movilizacion;
                _act.BonoTurno = _estr.BonoTurno;

                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha modificado Estructura de Sueldo ", _estr.Estructura_Codigo));

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public Boolean VerificaCódigo(MssBD.EstructuraSueldos _centro)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.EstructuraSueldos
                            where p.Estructura_Codigo == _centro.Estructura_Codigo
                            select p;

                if (lista.Count() > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public int EncuentraUltimoCodigo()
        {
            try
            {
                Int32 lista = (Int32)(from p in Modelo_BDMSS.EstructuraSueldos
                                      select p).OrderByDescending(x => x.Estructura_Codigo).First().Estructura_Codigo + 1;

                if (lista > 0)
                {
                    return lista;
                }

                return 0;
            }
            catch (Exception)
            {
                return 0;
                throw;
            }
        }
    }
}
