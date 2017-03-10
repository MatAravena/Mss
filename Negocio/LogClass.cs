using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Validation;
using System.Diagnostics;

namespace Negocio
{
    public class LogClass : CommonBC
    {
        public LogClass()
        {
        }

        public bool IngresaLog(MssBD.Usuarios _usu, String _Accion)
        {
            try
            {
                MssBD.Log _log = new MssBD.Log();
                _log.Accion = _Accion;
                _log.Usuario_Id = _usu.Usuario_Id;
                _log.fecha = DateTime.Now;

                Modelo_BDMSS_Logs.Log.Add(_log);
                Modelo_BDMSS_Logs.SaveChanges();

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
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public bool IngresaLogSinUser(MssBD.Usuarios _usu, String _Accion)
        {
            try
            {
                MssBD.Log _log = new MssBD.Log();
                _log.Accion = _Accion;
                _log.fecha = DateTime.Now;

                Modelo_BDMSS_Logs.Log.Add(_log);
                Modelo_BDMSS_Logs.SaveChanges();

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
            catch (Exception)
            {
                return false;
                throw;
            }
        }

        public List<MssBD.VW_Logs> BuscaLog(MssBD.Usuarios _usu, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                FechaDesde = FechaDesde.AddDays(-1);
                FechaHasta = FechaHasta.AddDays(1);

                var _lstLog = (from log in Modelo_BDMSS.VW_Logs
                               where log.fecha >= FechaDesde && log.fecha <= FechaHasta
                               select log).ToList();

                //from t1 in db.Table1
                //join t2 in db.Table2 on t1.field equals t2.field
                //select new { t1.field2, t2.field3}

                if (_lstLog != null)
                {
                    return _lstLog;
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
