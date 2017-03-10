using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DocVisados : CommonBC
    {
        
        public MssBD.VW_Documentos_Visar Consulta_DocumentosVisados(MssBD.Usuarios _usu, Boolean _vigencia, DateTime fechaDesde, DateTime fechaHasta)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.VW_Documentos_Visar
                            where (p.Fecha.Value >= fechaDesde.Date && p.Fecha.Value <= fechaHasta)
                            select p;
                if (lista.Count() == 1)
                {
                    foreach (var item in lista)
                    {
                        return item;
                    }
                }

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha consultado Documentos por Autorizar."));


                return null;
            }
            catch (Exception ex)
            {
                return null;
                //_mensaje = ex.Message;
            }
        }

        public Boolean Guardar_DocumentosVisados(MssBD.Usuarios _usu, MssBD.VW_Documentos_Visar listadoDocuments)
        {
            try
            {

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, "ha consultado Documentos por Autorizar."));


                return true;
            }
            catch (Exception ex)
            {
                return false;
                //_mensaje = ex.Message;
            }
        }
    }
}
