using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Negocio
{
    public class Usuario : CommonBC
    {
        public bool ConsultaUsuarioIngreso(out MssBD.Usuarios _usu, String Nombre, String Pass, ref Boolean nuevo)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.Usuarios
                            where p.Usuario_Nombre == Nombre
                            && p.Usuario_Password == Pass && p.Usuario_Password != string.Empty
                            select p;
                foreach (var item in lista)
                {
                    _usu = item;
                    nuevo = false;
                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha ingresado al sistema"));
                    return true;
                }

                var lista2 = from p in Modelo_BDMSS.Usuarios
                             where p.Usuario_Nombre == Nombre
                             && p.Usuario_Password == string.Empty
                             select p;
                foreach (var item in lista2)
                {
                    _usu = item;
                    nuevo = true;
                    return true;
                }

                if (!ExisteUsuario(Nombre))
                {
                    _usu = null;
                    _log.IngresaLogSinUser(null, String.Concat(Nombre, " ha intentado conectarse al sistema pero se ha equivocado de Usuario."));
                    return false;
                }

                nuevo = false;
                _usu = null;
                _log.IngresaLog(_usu, String.Concat(Nombre, "ha intentado conectarse al sistema pero se ha equivocado de Usuario y/o Contraseña."));
                return false;
            }
            catch (System.Data.Entity.Core.MetadataException ex)
            {
                throw ex;
            }
            catch (System.Data.Entity.Core.EntityException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                _usu = null;
                throw ex;
            }
        }

        public Boolean ExisteUsuario(String nombre)
        {
            try
            {
                var lista = from p in Modelo_BDMSS.Usuarios
                            where p.Usuario_Nombre == nombre
                            select p;
                foreach (var item in lista)
                {
                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool CambioContraseña(MssBD.Usuarios _usuCambio)
        {
            try
            {
                var _act = (from p in Modelo_BDMSS.Usuarios
                            where p.Usuario_Nombre == _usuCambio.Usuario_Nombre
                            select p).First();

                _act.Usuario_Password = _usuCambio.Usuario_Password;
                Modelo_BDMSS.SaveChanges();

                return true;
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}",
                                                validationError.PropertyName,
                                                validationError.ErrorMessage);
                    }
                }
                throw;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }

        public bool CambioContraseña(Int32 Rut, String Contraseña)
        {
            try
            {
                MssBD.Personal _per = new MssBD.Personal();
                Personal _NegPer = new Personal();
                _per = _NegPer.BuscaPersonalPorRut(Rut);

                var _act = (from p in Modelo_BDMSS.Usuarios
                            where p.Usuario_Id == _per.Usuario_Id
                            select p).First();

                _act.Usuario_Password = Contraseña;
                Modelo_BDMSS.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw ex;
            }
        }



    }
}
