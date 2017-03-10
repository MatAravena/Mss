using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Previsiones : CommonBC
    {
        public List<MssBD.Afp> BuscaAfps()
        {
            try
            {
                List<MssBD.Afp> listAfp = new List<MssBD.Afp>();
                listAfp = (from p in Modelo_BDMSS.Afp
                           orderby p.Afp_Nombre ascending
                           select p).ToList();
                if (listAfp.Count() > 0)
                {
                    return listAfp;
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public List<MssBD.Isapres> BuscaAIsapre()
        {
            try
            {
                List<MssBD.Isapres> listIsapre = new List<MssBD.Isapres>();
                listIsapre = (from p in Modelo_BDMSS.Isapres
                              orderby p.Isapre_Nombre ascending
                              select p).ToList();
                if (listIsapre.Count() > 0)
                {
                    return listIsapre;
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
