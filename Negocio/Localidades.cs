using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;

namespace Negocio
{
    public class Localidades : CommonBC
    {
        public List<MssBD.Paises> BuscaPais()
        {
            try
            {
                List<MssBD.Paises> listPaises = new List<MssBD.Paises>();

                listPaises = (from p in Modelo_BDMSS.Paises
                              orderby p.Pais_Nombre
                              select p).ToList();

                if (listPaises.Count() > 0)
                {
                    return listPaises;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MssBD.Regiones> BuscaRegion(int _pais)
        {
            try
            {
                List<MssBD.Regiones> listRegiones = new List<MssBD.Regiones>();
                listRegiones = (from p in Modelo_BDMSS.Regiones
                                where p.Pais_Codigo == _pais
                                orderby p.region_id
                                select p).ToList();

                if (listRegiones.Count() > 0)
                {
                    return listRegiones;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MssBD.Provincias> BuscaProvincia(int _region)
        {
            try
            {
                List<MssBD.Provincias> listProvincias = new List<MssBD.Provincias>();
                listProvincias = (from p in Modelo_BDMSS.Provincias
                                  where p.region_id == _region
                                  orderby p.provincia_nombre
                                  select p).ToList();

                if (listProvincias.Count() > 0)
                {
                    return listProvincias;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MssBD.Comunas> BuscaComunas(int _provincia)
        {
            try
            {
                List<MssBD.Comunas> listComunas = new List<MssBD.Comunas>();
                listComunas = (from p in Modelo_BDMSS.Comunas
                               where p.provincia_id == _provincia
                               orderby p.comuna_nombre
                               select p).ToList();

                if (listComunas.Count() > 0)
                {
                    return listComunas;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
