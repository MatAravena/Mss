using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Documentos
{
    public class Remuneracion : CommonBC
    {
        public DateTime FechaInicio { get; set; }
        public DateTime FechaTermino { get; set; }
        public Double Monto { get; set; }

        public Remuneracion()
        { }

        public List<MssBD.Remuneraciones> BuscaRemuneraciones(MssBD.Usuarios _usu, Int32 _FiniquitoId)
        {
            try
            {
                var _ListRemus = (from p in Modelo_BDMSS.Remuneraciones
                                  where p.Finiquito_Id == _FiniquitoId
                                  orderby p.FechaInicio ascending
                                  select p).ToList();

                if (_ListRemus.Count() > 0)
                {
                    return _ListRemus;
                }

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
