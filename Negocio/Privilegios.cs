using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class Privilegios : CommonBC
    {
        public MssBD.Privilegios ConsultaPrivilegiosDeUsuarios(MssBD.Usuarios _usu)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.Privilegios
                            where p.Privilegio_Id == _usu.Privilegio_Id
                            select p;
                if (lista.Count() == 1)
                {
                    foreach (var item in lista)
                    {
                        return item;
                    }
                }

                return null;
            }
            catch (Exception ex)
            {
                return null;
                //_mensaje = ex.Message;
            }
        }

        public List<MssBD.Privilegios> ConsultaPrivilegiosListado(MssBD.Usuarios _usu)
        {
            try
            {
                List<MssBD.Privilegios> lista = new List<MssBD.Privilegios>();

                switch (_usu.Privilegio_Id)
                {
                    case 1:
                        lista = (from p in Modelo_BDMSS.Privilegios
                                 select p).ToList();
                        break;
                    case 2:
                        lista = (from p in Modelo_BDMSS.Privilegios
                                 where p.Privilegio_Id != 1
                                 select p).ToList();
                        break;
                    case 3:
                        lista = (from p in Modelo_BDMSS.Privilegios
                                 where p.Privilegio_Id != 1 && p.Privilegio_Id != 2
                                 select p).ToList();
                        break;
                    default:
                        lista = (from p in Modelo_BDMSS.Privilegios
                                 where p.Privilegio_Id == 5
                                 select p).ToList();
                        break;
                }

                if (lista.Count() > 0)
                    return lista;

                return null;
            }
            catch (Exception ex)
            {
                return null;
                //_mensaje = ex.Message;
            }
        }
    }
}
