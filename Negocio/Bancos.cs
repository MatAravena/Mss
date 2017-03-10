using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;

namespace Negocio
{
    public class Bancos : CommonBC
    {
        public List<MssBD.Bancos> BuscaPancos()
        {
            try
            {
                var lista = (from p in Modelo_BDMSS.Bancos
                             orderby p.NombreBanco
                             select p).ToList();

                if (lista.Count() > 0)
                {
                    return lista;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public String BuscaNombreBanco(int idBanco)
        {
            try
            {
                var nombre = (from p in Modelo_BDMSS.Bancos
                              where p.Id_Banco == idBanco
                              select p.NombreBanco).First();
                return nombre;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
