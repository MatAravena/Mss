using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Documentos
{
    public class Documento : CommonBC
    {

        public Documento()
        {

        }

        public int DocumentoID { get; set; }
        public Boolean Vigencia { get; set; }
        public String TipoDocumento { get; set; }

        public Boolean RegistrarDocumento(Int32 DocumentoTipo_Id
                                        , MssBD.Usuarios _usu
                                        , MssBD.CON_Empleados_Rut_Centro_Result _per
                                        , bool PorVisar
                                        , string RutaFinal
                                        , ref String Mensaje
                                        , ref Int32 Doc_Id)
        {
            try
            {

                MssBD.Documentos _doc = new MssBD.Documentos();
                _doc.DocumentoTipo_Id = DocumentoTipo_Id;
                _doc.Fecha = DateTime.Now;
                _doc.Personal_Id = _per.Rut;
                _doc.PorVisar = true;
                _doc.RutaFinal = RutaFinal;
                _doc.Usuario_Id = _usu.Usuario_Id;

                Modelo_BDMSS.Documentos.Add(_doc);
                Modelo_BDMSS.SaveChanges();

                switch (DocumentoTipo_Id)
                {
                    case 1:
                        Mensaje = "Se ha registrado Contrato. Dar a conocer a Administrador para su visado.";
                        break;
                    case 2:
                        Mensaje = "Se ha registrado Anexo. Dar a conocer a Administrador para su visado.";
                        break;
                    case 3:
                        Mensaje = "Se ha registrado Finiquito. Dar a conocer a Administrador para su visado.";
                        break;
                    default:
                        break;
                }

                try
                {
                    Doc_Id = Modelo_BDMSS.Documentos.Where(doc => doc.Documento_Id == doc.Documento_Id)
                                            .Max(doc => doc.Documento_Id);
                }
                catch (Exception ex)
                {
                    throw ex;
                }

                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean RegistrarContrato(Int32 DocumentoTipo_Id
                                       , MssBD.Usuarios _usu
                                       , MssBD.CON_Empleados_Rut_Centro_Result _per
                                       , bool PorVisar
                                       , string RutaFinal
                                       , ref String Mensaje
                                       , Int32 Doc_Id)
        {
            try
            {

                MssBD.Contratos _con = new MssBD.Contratos();
                _con.Afp_Id = _per.Afp_Id;
                _con.CentroCosto_Id = _per.CentroCosto_Id;
                _con.Documento_Id = Doc_Id;
                _con.EstructuraSueldo_Id = _per.EstructuraSueldo_Id;
                _con.FechaDesde = _per.FechaIngreso.Value;
                _con.FechaHasta = _per.FechaVencimiento.Value;
                _con.Isapre_Id = _per.Isapre_Id;
                _con.TipoContrato = _per.TipoContrato;

                Modelo_BDMSS.Contratos.Add(_con);
                Modelo_BDMSS.SaveChanges();

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha registrado Contratos de ", _per.Rut, "-", _per.Dv));

                switch (DocumentoTipo_Id)
                {
                    case 1:
                        Mensaje = "Se ha registrado Contrato. Dar a conocer a Administrador para su visado.";
                        break;
                    case 2:
                        Mensaje = "Se ha registrado Anexo. Dar a conocer a Administrador para su visado.";
                        break;
                    case 3:
                        Mensaje = "Se ha registrado Finiquito. Dar a conocer a Administrador para su visado.";
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                throw; ;
            }
        }

        public Boolean RegistrarAnexo(Int32 DocumentoTipo_Id
                                       , MssBD.Usuarios _usu
                                       , MssBD.CON_Empleados_Rut_Centro_Result _per
                                       , bool PorVisar
                                       , string RutaFinal
                                       , ref String Mensaje
                                       , Int32 Contrato_Id)
           {
            try
            {
                MssBD.Anexos _ane = new MssBD.Anexos();
                
                _ane.Contrato_Id = Contrato_Id;
                _ane.FechaDesde = _per.FechaIngreso.Value;
                _ane.FechaHasta = _per.FechaVencimiento.Value;
                _ane.RutaFinal = RutaFinal;

                Modelo_BDMSS.Anexos.Add(_ane);
                Modelo_BDMSS.SaveChanges();

                switch (DocumentoTipo_Id)
                {
                    case 1:
                        Mensaje = "Se ha registrado Contrato. Dar a conocer a Administrador para su visado.";
                        break;
                    case 2:
                        Mensaje = "Se ha registrado Anexo. Dar a conocer a Administrador para su visado.";
                        break;
                    case 3:
                        Mensaje = "Se ha registrado Finiquito. Dar a conocer a Administrador para su visado.";
                        break;
                    default:
                        break;
                }

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha registrado Anexo de ", _per.Rut, "-", _per.Dv));

                return true;
            }
            catch (Exception)
            {
                throw; ;
            }
        }

        public Boolean RegistrarFiniquito(Int32 DocumentoTipo_Id
                                       , MssBD.Usuarios _usu
                                       , MssBD.CON_Empleados_Rut_Centro_Result _per
                                       , bool PorVisar
                                       , string RutaFinal
                                       , ref String Mensaje
                                       , Int32 Doc_Id
                                       , Finiquitos _Finiquito
                                       , IDictionary<int, Negocio.Documentos.Remuneracion> _listRemu)
        {
            try
            {
                Int32 _Finiquito_Id = 0;
                MssBD.Finiquito _fin = new MssBD.Finiquito();
                _fin.Documento_Id = Doc_Id;
                _fin.Articulo = _Finiquito._Articulo;
                _fin.Articulo_Numero = Int32.Parse(_Finiquito._NumeroArticulo);
                _fin.Comentario = _Finiquito._Motivo;
                _fin.Documento_Id = Doc_Id;
                _fin.Vacaciones = _Finiquito._Vacaciones;
                _fin.MontoTotal = _Finiquito._Total;
                _fin.RutaFinal = RutaFinal;

                Modelo_BDMSS.Finiquito.Add(_fin);
                Modelo_BDMSS.SaveChanges();

                _Finiquito_Id = Modelo_BDMSS.Finiquito.Where(fin => fin.Finiquito_Id == fin.Finiquito_Id)
                                        .Max(fin => fin.Finiquito_Id);

                foreach (var item in _listRemu)
                {
                    Remuneracion remu = new Remuneracion();
                    remu = (Remuneracion)item.Value;

                    MssBD.Remuneraciones _remu = new MssBD.Remuneraciones();
                    _remu.FechaInicio = remu.FechaInicio;
                    _remu.FechaTermino = remu.FechaTermino;
                    _remu.Finiquito_Id = _Finiquito_Id;
                    _remu.monto = remu.Monto;

                    Modelo_BDMSS.Remuneraciones.Add(_remu);
                    Modelo_BDMSS.SaveChanges();
                }

                _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha registrado Finiquito de ", _per.Rut, "-", _per.Dv));

                switch (DocumentoTipo_Id)
                {
                    case 1:
                        Mensaje = "Se ha registrado Contrato. Dar a conocer a Administrador para su visado.";
                        break;
                    case 2:
                        Mensaje = "Se ha registrado Anexo. Dar a conocer a Administrador para su visado.";
                        break;
                    case 3:
                        Mensaje = "Se ha registrado Finiquito. Dar a conocer a Administrador para su visado.";
                        break;
                    default:
                        break;
                }

                return true;
            }
            catch (Exception)
            {
                throw; ;
            }
        }

        public Boolean RetornaContratoId(MssBD.CON_Empleados_Rut_Centro_Result _per
                                       , ref String Mensaje
                                       , ref int ContratoId)
        {

            try
            {
                //String _TipoContrato = (from con in Modelo_BDMSS.Contratos
                //                        join doc in Modelo_BDMSS.Documentos on con.Documento_Id equals doc.Documento_Id
                //                        join per in Modelo_BDMSS.Personal on doc.Personal_Id equals per.Rut
                //                        where per.Rut == _per.Rut
                //                        select con.TipoContrato).First();
                //if (_TipoContrato.Equals("INDEFINIDO"))
                //{
                //    Mensaje = String.Concat(_per.Nombres, " ya posee contrato Indefinido, no se puede realizar un Anexo de Contrato.");
                //    return false;
                //}

                int _contratoId = (from con in Modelo_BDMSS.Contratos
                                   join doc in Modelo_BDMSS.Documentos on con.Documento_Id equals doc.Documento_Id
                                   join per in Modelo_BDMSS.Personal on doc.Personal_Id equals per.Rut
                                   where per.Rut == _per.Rut
                                   select con.Contrato_Id).First();

                if (_contratoId > 0)
                {
                    ContratoId = _contratoId;
                    return true;
                }
                else
                {
                    Mensaje = String.Concat("No se ha encontrado un Contrato anteriormente registrado para Id de Contrato", _per.Nombres);
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Boolean RetornaContratoId(MssBD.CON_Empleados_Rut_Centro_Result _per)
        {

            try
            {
                String _TipoContrato = (from con in Modelo_BDMSS.Contratos
                                        join doc in Modelo_BDMSS.Documentos on con.Documento_Id equals doc.Documento_Id
                                        join per in Modelo_BDMSS.Personal on doc.Personal_Id equals per.Rut
                                        where per.Rut == _per.Rut
                                        select con.TipoContrato).First();
                if (_TipoContrato.Equals("INDEFINIDO"))
                {
                    return false;
                }
                return true;

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
