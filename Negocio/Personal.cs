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
    public class Personal : CommonBC
    {
        public Boolean ExistePersonal(MssBD.Personal _perso)
        {
            try
            {
                var pers2 = (from p in Modelo_BDMSS.Personal
                             where p.Rut == _perso.Rut
                             select p);
                if (pers2.Count() > 0)
                {

                    //_perso.Usuarios = new MssBD.Usuarios();

                    //_perso.Usuarios = (from usu in Modelo_BDMSS.Usuarios
                    //                   where usu.Usuario_Nombre == String.Concat(_perso.Rut.ToString(), "-", _perso.Dv)
                    //                   select usu).First();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public MssBD.Personal BuscaPersonalPorRut(Int32 _rut)
        {
            try
            {
                var pers2 = (from p in Modelo_BDMSS.Personal
                             where p.Rut == _rut
                             select p).First();

                try
                {
                    var usu = (from per in Modelo_BDMSS.Personal
                               join usua in Modelo_BDMSS.Usuarios on per.Usuario_Id equals usua.Usuario_Id
                               where per.Rut == _rut
                               select usua).First();

                    if (usu != null)
                    {
                        pers2.Usuarios = new Usuarios();
                        pers2.Usuarios = usu;
                    }
                }
                catch (Exception)
                {
                }

                return pers2;
            }
            catch
            {
                return null;
            }
        }

        public MssBD.Personal BuscaPersonalPorIdUsuario(Int32 _Id)
        {
            try
            {
                var pers2 = (from p in Modelo_BDMSS.Personal
                             where p.Usuario_Id == _Id
                             select p).First();
                return pers2;
            }
            catch
            {
                return null;
            }
        }

        public List<MssBD.CON_Empleados_Rut_Centro_Result> ConsultaPersonal_RutApellidosCentroCostos(MssBD.Usuarios _usuSesion, Int32? _Rut, String _Apellido, Int32? _CentroCosto)
        {
            if (_Apellido == String.Empty)
                _Apellido = null;

            if (_CentroCosto == 0)
                _CentroCosto = null;

            List<MssBD.CON_Empleados_Rut_Centro_Result> _listEmpleados = new List<MssBD.CON_Empleados_Rut_Centro_Result>();

            switch (_usuSesion.Privilegio_Id)
            {
                case 1:
                    _listEmpleados = (from p in Modelo_BDMSS.CON_Empleados_Rut_Centro(_Rut.ToString(), _CentroCosto.ToString(), _Apellido, _Apellido)
                                      select p).ToList();
                    break;
                case 2:
                    _listEmpleados = (from p in Modelo_BDMSS.CON_Empleados_Rut_Centro(_Rut.ToString(), _CentroCosto.ToString(), _Apellido, _Apellido)
                                      where p.CentroCosto_Id != 26
                                      select p).ToList();
                    break;
                default:
                    _listEmpleados = (from p in Modelo_BDMSS.CON_Empleados_Rut_Centro(_Rut.ToString(), _CentroCosto.ToString(), _Apellido, _Apellido)
                                      where p.Vigencia == true && p.CentroCosto_Id != 26
                                      select p).ToList();
                    break;
            }

            if (_listEmpleados != null)
            {
                return _listEmpleados;
            }

            return null;
        }

        public bool EliminaPersonal(MssBD.Usuarios _usu, MssBD.Personal _persEliminar)
        {
            try
            {
                var _Empleado = (from p in Modelo_BDMSS.Personal
                                 where p.Rut == _persEliminar.Rut
                                 select p).First();
                _Empleado.Vigencia = false;

                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha eliminado Empleado ", _persEliminar.Rut, "-", _persEliminar.Dv, " ", _persEliminar.Nombres, " ", _persEliminar.ApellidoPaterno));

                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool GuardaPersonal(MssBD.Usuarios _usu, MssBD.Personal _persGuarda, ref bool Nuevo)
        {
            try
            {
                if (!ExistePersonal(_persGuarda))
                {
                    if (_persGuarda.Usuarios.Privilegio_Id <= 4)
                    {
                        _persGuarda.Usuarios.Usuario_Nombre = String.Concat(_persGuarda.Rut, "-", _persGuarda.Dv);
                        _persGuarda.Usuarios.Privilegio_Id = _persGuarda.Usuarios.Privilegio_Id;
                        _persGuarda.Usuarios.Usuario_Password = String.Empty;

                        Modelo_BDMSS.Usuarios.Add((MssBD.Usuarios)_persGuarda.Usuarios);
                        Modelo_BDMSS.SaveChanges();

                        var _us = (from u in Modelo_BDMSS.Usuarios
                                   where u.Usuario_Nombre == _persGuarda.Usuarios.Usuario_Nombre && u.Usuario_Password == string.Empty
                                   select u).First();

                        _persGuarda.Usuario_Id = _us.Usuario_Id;
                    }

                    Modelo_BDMSS.Personal.Add(_persGuarda);
                    Modelo_BDMSS.SaveChanges();

                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha ingresado nuevo Empleado ", _persGuarda.Rut, "-", _persGuarda.Dv, " ", _persGuarda.Nombres, " ", _persGuarda.ApellidoPaterno));

                    Nuevo = true;
                    return true;
                }
                else
                {
                    MssBD.Personal _perAct = new MssBD.Personal();
                    _perAct = (from p in Modelo_BDMSS.Personal
                               where p.Rut == _persGuarda.Rut
                               select p).First();

                    _perAct.ApellidoPaterno = _persGuarda.ApellidoPaterno;
                    _perAct.ApellidoMaterno = _persGuarda.ApellidoMaterno;
                    _perAct.Nombres = _persGuarda.Nombres;

                    _perAct.Direccion = _persGuarda.Direccion;
                    _perAct.Pais_Codigo = _persGuarda.Pais_Codigo;
                    _perAct.Region_Codigo = _persGuarda.Region_Codigo;
                    _perAct.Provincia_Codigo = _persGuarda.Provincia_Codigo;
                    _perAct.Comuna_Codigo = _persGuarda.Comuna_Codigo;
                    _perAct.FechaNacimiento = _persGuarda.FechaNacimiento;
                    _perAct.TelFijo = _persGuarda.TelFijo;
                    _perAct.TelCelular = _persGuarda.TelCelular;
                    _perAct.NombreContacto = _persGuarda.NombreContacto;
                    _perAct.Parentesco = _persGuarda.Parentesco;

                    _perAct.TelContactoFijo = _persGuarda.TelContactoFijo;
                    _perAct.TelContactoCelular = _persGuarda.TelContactoCelular;
                    _perAct.TipoContrato = _persGuarda.TipoContrato;
                    _perAct.FechaIngreso = _persGuarda.FechaIngreso;
                    _perAct.CursoOS10 = _persGuarda.CursoOS10;
                    _perAct.Credencial = _persGuarda.Credencial;
                    _perAct.FechaVencimiento = _persGuarda.FechaVencimiento;
                    _perAct.Calzado = _persGuarda.Calzado;
                    _perAct.Pantalon = _persGuarda.Pantalon;
                    _perAct.Polera = _persGuarda.Polera;
                    _perAct.Camisa = _persGuarda.Camisa;
                    _perAct.Polar = _persGuarda.Polar;
                    _perAct.Casaca = _persGuarda.Casaca;
                    _perAct.Corbata = _persGuarda.Corbata;
                    _perAct.Gorro = _persGuarda.Gorro;
                    _perAct.Cazadora = _persGuarda.Cazadora;
                    _perAct.Imagen = _persGuarda.Imagen;
                    _perAct.CentroCosto_Id = _persGuarda.CentroCosto_Id;
                    _perAct.Usuario_Id = _persGuarda.Usuario_Id;
                    _perAct.Estado = _persGuarda.Estado;
                    _perAct.EstructuraSueldo_Id = _persGuarda.EstructuraSueldo_Id;

                    _perAct.EstadoCivil = _persGuarda.EstadoCivil;
                    _perAct.Isapre_Id = _persGuarda.Isapre_Id;
                    _perAct.Afp_Id = _persGuarda.Afp_Id;

                    _perAct.Id_Banco = _persGuarda.Id_Banco;
                    _perAct.NumeroCuenta = _persGuarda.NumeroCuenta;
                    _perAct.TipoCuenta = _persGuarda.TipoCuenta;
                    _perAct.Cargo = _persGuarda.Cargo;

                    Modelo_BDMSS.SaveChanges();

                    if (_persGuarda.Usuarios != null)
                    {
                        if (_persGuarda.Usuarios.Privilegio_Id < 5)
                        {
                            _perAct.Usuarios = new MssBD.Usuarios();

                            _perAct.Usuarios = (from usu in Modelo_BDMSS.Usuarios
                                                where usu.Usuario_Nombre == String.Concat(_persGuarda.Rut.ToString(), "-", _persGuarda.Dv)
                                                select usu).First();
                            _perAct.Usuarios.Privilegio_Id = _persGuarda.Usuarios.Privilegio_Id;
                        }
                    }
                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha modificado Empleado ", _persGuarda.Rut, "-", _persGuarda.Dv, " ", _persGuarda.Nombres, " ", _persGuarda.ApellidoPaterno));

                    Nuevo = false;
                    return true;
                }
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
                throw ex;
            }
        }
    }
}
