using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Word;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Negocio.Documentos
{
    public class Contratos : CommonBC
    {
        public MssBD.CON_Empleados_Rut_Centro_Result _per { get; set; }
        MssBD.Usuarios _usuarioSesion;
        public String _RutaFinal { get; set; }
        public String _RutaInicioProyecto { get; set; }
        public String _DireccionInstalacion { get; set; }
        public String _SegundoParrafo { get; set; }
        public Double _Anticipo { get; set; }

        Documento _doc = new Documento();

        EstructuraSueldos _est = new EstructuraSueldos();
        Personal _NegPer = new Personal();
        Bancos _Bancos = new Bancos();
        MssBD.EstructuraSueldos _estBD = new MssBD.EstructuraSueldos();
        MssBD.Personal _personal = new MssBD.Personal();

        Object oMissing = System.Reflection.Missing.Value;
        Object objFileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
        Object objFalse = false;

        public Contratos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
        }

        public Contratos()
        {
        }

        public Boolean GeneraContrato(ref String Mensaje)
        {

            Application wordApp = new Application();
            Document wordDoc = new Document();

            try
            {
                Object oMissing = System.Reflection.Missing.Value;

                _personal = _NegPer.BuscaPersonalPorRut(_per.Rut);

                _personal.FechaIngreso = _per.FechaIngreso;
                _personal.FechaVencimiento = _per.FechaVencimiento;

                _personal.Afp_Id = _per.Afp_Id;
                _personal.Isapre_Id = _per.Isapre_Id;
                _personal.EstructuraSueldo_Id = _per.EstructuraSueldo_Id;
                _personal.CentroCosto_Id = _per.CentroCosto_Id;
                _personal.TipoContrato = _per.TipoContrato;

                Boolean _bol = false;

                _NegPer.GuardaPersonal(_usuarioSesion, _personal, ref _bol);

                //Assembly thisAssembly;
                //thisAssembly = Assembly.GetExecutingAssembly();
                //Stream someStream;
                //someStream = thisAssembly.GetManifestResourceStream("Negocio.WordTemplate.Contrato_Template.dotx");

                //Assembly _assembly = Assembly.GetExecutingAssembly();

                //// Object oTemplatePath = _assembly.GetManifestResourceStream("WordTemplate\\Contrato_Template.dotx");
                //Object oTemplatePath = _assembly.GetManifestResourceStream("Negocio.WordTemplate.Contrato_Template.dotx");
                //Object oTemplatePath2 = _assembly.GetManifestResourceStream("WordTemplate\\Contrato_Template.dotx");

                Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Contrato_Template.dotx");
                wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

                foreach (Field myMergeField in wordDoc.Fields)
                {
                    Range rngFieldCode = myMergeField.Code;
                    String fieldText = rngFieldCode.Text;

                    if (fieldText.StartsWith(" MERGEFIELD"))
                    {
                        Int32 endMerge = fieldText.IndexOf("\\");
                        Int32 fieldNameLength = fieldText.Length - endMerge;
                        String fieldName = fieldText.Substring(11, endMerge - 11);

                        switch (fieldName.Trim())
                        {
                            case "FechaContrato":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(DateTime.Now.ToLongDateString());
                                break;
                            case "Nombre":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(String.Concat(_personal.Nombres, " ", _personal.ApellidoPaterno, " ", _personal.ApellidoMaterno)));
                                break;
                            case "Rut":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(String.Concat(FormatNumero(_personal.Rut.ToString()), "-", _personal.Dv));
                                break;
                            case "EstadoCivil":
                                myMergeField.Select();
                                if (String.Equals(_personal.EstadoCivil, String.Empty))
                                {
                                    wordApp.Selection.TypeText(" ");
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(_personal.EstadoCivil);
                                }
                                break;
                            case "FechaNacimiento":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_personal.FechaNacimiento.Value.ToLongDateString());
                                break;
                            case "Dirección":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_personal.Direccion);
                                break;
                            case "Comuna":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Comunas.comuna_nombre == null)
                                    {
                                        Mensaje = "Personal no tiene Comuna asociada. Favor ingresarla y volver a intentar.";
                                        return false;
                                    }
                                    wordApp.Selection.TypeText(_personal.Comunas.comuna_nombre);
                                }
                                catch (Exception)
                                {
                                    Mensaje = "Personal no tiene Comuna asociada. Favor ingresarla y volver a intentar.";
                                    return false;
                                }

                                break;
                            case "Telefono":
                                myMergeField.Select();
                                if (_personal.TelCelular != string.Empty && _personal.TelFijo != string.Empty)
                                {
                                    wordApp.Selection.TypeText(String.Concat("Teléfono ", _personal.TelFijo, " y Teléfono Celular ", _personal.TelCelular));
                                }
                                else
                                {
                                    if (_personal.TelCelular != string.Empty)
                                    {
                                        wordApp.Selection.TypeText(String.Concat("Teléfono Celular ", _personal.TelCelular));
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(String.Concat("Teléfono ", _personal.TelFijo));
                                    }
                                }
                                break;
                            case "SueldoBaseNumero":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(FormatNumero(_personal.EstructuraSueldos.SueldoBase.ToString()));
                                break;
                            case "SueldoBaseLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_personal.EstructuraSueldos.SueldoBase.ToString())));
                                break;
                            case "GratificacionNumero":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(FormatNumero(_personal.EstructuraSueldos.Gratificacion.ToString()));
                                break;
                            case "GratificacionLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_personal.EstructuraSueldos.Gratificacion.ToString())));
                                break;
                            case "AsistenciaNumero":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(FormatNumero(_personal.EstructuraSueldos.BonoAsistencia.ToString()));
                                break;
                            case "AsistenciaLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_personal.EstructuraSueldos.BonoAsistencia.ToString())));
                                break;
                            case "ColacionNumero":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(FormatNumero(_personal.EstructuraSueldos.Colacion.ToString()));
                                break;
                            case "ColacionLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_personal.EstructuraSueldos.Colacion.ToString())));
                                break;
                            case "MovilizacionNumero":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(FormatNumero(_personal.EstructuraSueldos.Movilizacion.ToString()));
                                break;
                            case "MovilizacionLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_personal.EstructuraSueldos.Movilizacion.ToString())));
                                break;

                            case "ProduccionNumero":
                                myMergeField.Select();
                                if (_personal.EstructuraSueldos.BonoProduccion != 0)
                                {
                                    wordApp.Selection.TypeText(String.Concat(", bono de producción de $", FormatNumero(_personal.EstructuraSueldos.BonoProduccion.ToString())));
                                }
                                break;
                            case "ProduccionLetras":
                                myMergeField.Select();

                                if (_personal.EstructuraSueldos.BonoProduccion != 0)
                                {
                                    wordApp.Selection.TypeText(String.Concat("(", PrimeraMayuscula(enletras(_personal.EstructuraSueldos.BonoProduccion.ToString())), "chilenos)"));
                                }
                                break;

                            case "BonoTurno":
                                myMergeField.Select();
                                if (_personal.EstructuraSueldos.BonoTurno != 0)
                                {
                                    wordApp.Selection.TypeText(String.Concat("y un bono cargo mientras ejerza la labor de encargado de turno de $", FormatNumero(_personal.EstructuraSueldos.BonoTurno.ToString())));
                                }
                                break;
                            case "FechaVencimiento":
                                myMergeField.Select();
                                if (_personal.TipoContrato.Equals("INDEFINIDO"))
                                {
                                    wordApp.Selection.TypeText("Indefinida");
                                }
                                else
                                {
                                    wordApp.Selection.TypeText(String.Concat("hasta el ", _personal.FechaVencimiento.Value.ToLongDateString()));
                                }
                                break;

                            case "FechaInicio":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_personal.FechaIngreso.Value.ToLongDateString());
                                break;
                            case "AFP":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Afp.Afp_Nombre == null)
                                    {
                                        Mensaje = "Personal no tiene Afp asociada. Favor ingresarla y volver a intentar.";
                                        return false;
                                    }
                                    wordApp.Selection.TypeText(_personal.Afp.Afp_Nombre);
                                }
                                catch (Exception)
                                {
                                    Mensaje = "Personal no tiene Afp asociada. Favor ingresarla y volver a intentar.";
                                    return false;
                                }

                                break;
                            case "Isapre":
                                myMergeField.Select();

                                try
                                {
                                    if (_personal.Isapres.Isapre_Nombre == null)
                                    {
                                        Mensaje = "Personal no tiene Isapre asociada. Favor ingresarla y volver a intentar.";
                                        return false;
                                    }
                                    wordApp.Selection.TypeText(_personal.Isapres.Isapre_Nombre);
                                }
                                catch (Exception)
                                {
                                    Mensaje = "Personal no tiene Isapre asociada. Favor ingresarla y volver a intentar.";
                                    return false;
                                }
                                break;

                            case "Desempeño":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Usuarios == null)
                                    {
                                        wordApp.Selection.TypeText("Guardia de Seguridad");
                                    }
                                    else
                                    {
                                        if (_personal.Usuarios.Privilegio_Id == 5)
                                        {
                                            wordApp.Selection.TypeText("Guardia de Seguridad");
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(_personal.Cargo);
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "SegundoParrafo":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Usuarios == null)
                                    {
                                        wordApp.Selection.TypeText("Guardia de Seguridad, será el encargado de asistir en la organización y realización de tareas de seguridad del área, patrullar o supervisar las instalaciones para evitar el robo, la violencia, o infracciones contra la empresa contratante, autorizar la entrada y salida de los empleados, visitantes y otras personas con el fin de protegerse contra el Robo y/o Hurto. El guardia de Seguridad es responsable de mantener instalaciones seguras, debe ser capaz de escribir informes sobre las actividades diarias y las irregularidades, tales como daños en los equipos o la propiedad, robos, Hurtos, la presencia de personas no autorizadas o los acontecimientos inusuales, o cualquier otro acontecimiento que revista los caracteres de delito. Un guardia de seguridad debe llamar a la Carabineros o a la Policía, bomberos y/o Ambulancias en casos de emergencia. Cuando un guardia de seguridad se enfrenta a personas no autorizadas que se niegan a abandonar la zona custodiada, deben llamar a la policía para efectuar el procedimiento.");
                                    }
                                    else
                                    {
                                        if (_personal.Usuarios.Privilegio_Id == 5)
                                        {
                                            wordApp.Selection.TypeText("Guardia de Seguridad, será el encargado de asistir en la organización y realización de tareas de seguridad del área, patrullar o supervisar las instalaciones para evitar el robo, la violencia, o infracciones contra la empresa contratante, autorizar la entrada y salida de los empleados, visitantes y otras personas con el fin de protegerse contra el Robo y/o Hurto. El guardia de Seguridad es responsable de mantener instalaciones seguras, debe ser capaz de escribir informes sobre las actividades diarias y las irregularidades, tales como daños en los equipos o la propiedad, robos, Hurtos, la presencia de personas no autorizadas o los acontecimientos inusuales, o cualquier otro acontecimiento que revista los caracteres de delito. Un guardia de seguridad debe llamar a la Carabineros o a la Policía, bomberos y/o Ambulancias en casos de emergencia. Cuando un guardia de seguridad se enfrenta a personas no autorizadas que se niegan a abandonar la zona custodiada, deben llamar a la policía para efectuar el procedimiento.");
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(String.Concat(_personal.Cargo, ", ", _SegundoParrafo));
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "DireccionInstalacion":
                                myMergeField.Select();
                                try
                                {
                                    wordApp.Selection.TypeText(_DireccionInstalacion);
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "AfectoBonoAsistencia":
                                myMergeField.Select();
                                try
                                {
                                    //if (_personal.Usuarios.Privilegio_Id == 5)
                                    if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                    {
                                        wordApp.Selection.TypeText("En el evento que el trabajador tenga un día de inasistencia o un atraso injustificado, se le descontará el 100% del bono de Asistencia y Responsabilidad.  Lo anterior sin perjuicio de lo estipulado en el Art. 160, nro. 3 y 4, del Código del Trabajo. El trabajador no tendrá otros beneficios que los que se hagan contar por escrito en el presente contrato.");
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "Anticipo":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                    {
                                        wordApp.Selection.TypeText(FormatNumero("60000"));
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(FormatNumero(_Anticipo.ToString()));
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "AnticipoLetras":
                                myMergeField.Select();
                                try
                                {
                                    if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                    {
                                        wordApp.Selection.TypeText(String.Concat("(", PrimeraMayuscula(enletras(FormatNumero("60000"))), " pesos chilenos)"));
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(String.Concat("(", PrimeraMayuscula(enletras(FormatNumero(_Anticipo.ToString()))), " pesos chilenos)"));
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;

                            case "DepositoBanco":
                                myMergeField.Select();
                                try
                                {
                                    //vista Nº 18162030, del Banco Estado.
                                    if (_personal.Id_Banco == 19 && _personal.TipoCuenta.ToString().Equals("Cuenta Vista"))
                                    {
                                        wordApp.Selection.TypeText(String.Concat("Cuenta Rut", " Nº", _personal.NumeroCuenta, ", del", _Bancos.BuscaNombreBanco((int)_personal.Id_Banco)));
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(String.Concat(_personal.TipoCuenta, " Nº", _personal.NumeroCuenta, ", del", _Bancos.BuscaNombreBanco((int)_personal.Id_Banco)));
                                    }
                                }
                                catch (Exception)
                                {
                                    throw;
                                }
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (File.Exists(String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf")))
                {
                    Mensaje = String.Concat("Contrato a crear '", _RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(),
                                            "_", _per.Rut, "-", _per.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                    return false;
                }

                Object objSaveAsFile = String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf");
                wordDoc.SaveAs2(objSaveAsFile, ref objFileFormat, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing);

                //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".doc"));
                _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha generado Contratos de ", _per.Rut, "-", _per.Dv));

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    if (wordDoc != null)
                    {
                        wordDoc.Close(ref objFalse, ref oMissing, ref oMissing);
                    }
                    if (wordApp != null)
                    {
                        wordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
                    }

                    Marshal.ReleaseComObject(wordDoc);
                    Marshal.ReleaseComObject(wordApp);
                    Marshal.ReleaseThreadCache();
                    wordApp = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    wordApp = null;
                }
                catch (Exception)
                {
                }
            }
        }

        public List<MssBD.VW_DOC_Contratos> BuscaContratos_Visar(MssBD.Usuarios _usu, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                FechaDesde = FechaDesde.AddDays(-1);
                FechaHasta = FechaHasta.AddDays(1);

                var _vw = (from p in Modelo_BDMSS.VW_DOC_Contratos
                           where p.Fecha >= FechaDesde && p.Fecha <= FechaHasta && p.PorVisar == true
                           select p).ToList();

                //var _vw2 = (from p in Modelo_BDMSS.VW_DOC_Contratos
                //            where p.PorVisar == true
                //            select p).ToList();

                if (_vw.Count() > 0)
                {
                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha consultado Contratos a Visar "));
                    return _vw;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GenereContratosMasivos(ref String Mensaje, List<MssBD.VW_DOC_Contratos> _ListContratos, String _RutaFinal)
        {

            Application wordApp = new Application();
            Document wordDoc = new Document(); ;
            try
            {

                foreach (var item in _ListContratos)
                {
                    //Assembly thisAssembly;
                    //thisAssembly = Assembly.GetExecutingAssembly();
                    //Stream someStream;
                    //someStream = thisAssembly.GetManifestResourceStream("Negocio.WordTemplate.Contrato_Template.dotx");
                    //Assembly _assembly = Assembly.GetExecutingAssembly();

                    // Object oTemplatePath = _assembly.GetManifestResourceStream("WordTemplate\\Contrato_Template.dotx");
                    //Object oTemplatePath = _assembly.GetManifestResourceStream("Negocio.WordTemplate.Contrato_Template.dotx");
                    //Object oTemplatePath2 = _assembly.GetManifestResourceStream("WordTemplate\\Contrato_Template.dotx");

                    Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Contrato_Template.dotx");

                    wordApp = new Application();
                    wordDoc = new Document();

                    wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

                    foreach (Field myMergeField in wordDoc.Fields)
                    {
                        Range rngFieldCode = myMergeField.Code;
                        String fieldText = rngFieldCode.Text;

                        if (fieldText.StartsWith(" MERGEFIELD"))
                        {
                            Int32 endMerge = fieldText.IndexOf("\\");
                            Int32 fieldNameLength = fieldText.Length - endMerge;
                            String fieldName = fieldText.Substring(11, endMerge - 11);

                            switch (fieldName.Trim())
                            {
                                case "FechaContrato":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(DateTime.Now.ToLongDateString());
                                    break;
                                case "Nombre":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(String.Concat(item.Nombres, " ", item.ApellidoPaterno, " ", item.ApellidoMaterno)));
                                    break;
                                case "Rut":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(String.Concat(FormatNumero(item.Rut.ToString()), "-", item.Dv));
                                    break;
                                case "EstadoCivil":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.EstadoCivil);
                                    break;
                                case "FechaNacimiento":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.FechaNacimiento.Value.ToLongDateString());
                                    break;
                                case "Dirección":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Direccion);
                                    break;
                                case "Comuna":
                                    myMergeField.Select();
                                    try
                                    {
                                        if (item.comuna_nombre == null)
                                        {
                                            Mensaje = "Personal no tiene Comuna asociada. Favor ingresarla y volver a intentar.";
                                            return false;
                                        }
                                        wordApp.Selection.TypeText(item.comuna_nombre);
                                    }
                                    catch (Exception)
                                    {
                                        Mensaje = "Personal no tiene Comuna asociada. Favor ingresarla y volver a intentar.";
                                        return false;
                                    }
                                    break;

                                case "Telefono":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.TelFijo);

                                    if (item.TelCelular != string.Empty && item.TelFijo != string.Empty)
                                    {
                                        wordApp.Selection.TypeText(String.Concat("Teléfono ", item.TelFijo, " y Teléfono Celular ", item.TelCelular));
                                    }
                                    else
                                    {
                                        if (item.TelCelular != string.Empty)
                                        {
                                            wordApp.Selection.TypeText(String.Concat("Teléfono Celular ", item.TelCelular));
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(String.Concat("Teléfono ", item.TelFijo));
                                        }
                                    }
                                    break;

                                case "SueldoBaseNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.SueldoBase.ToString()));
                                    break;
                                case "SueldoBaseLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.SueldoBase.ToString())));
                                    break;
                                case "GratificacionNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.Gratificacion.ToString()));
                                    break;
                                case "GratificacionLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.Gratificacion.ToString())));
                                    break;
                                case "AsistenciaNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.BonoAsistencia.ToString()));
                                    break;
                                case "AsistenciaLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.BonoAsistencia.ToString())));
                                    break;
                                case "ProduccionNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.BonoProduccion.ToString()));
                                    break;
                                case "ProduccionLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.BonoProduccion.ToString())));
                                    break;
                                case "ColacionNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.Colacion.ToString()));
                                    break;
                                case "ColacionLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.Colacion.ToString())));
                                    break;
                                case "MovilizacionNumero":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(FormatNumero(item.Movilizacion.ToString()));
                                    break;
                                case "MovilizacionLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.Movilizacion.ToString())));
                                    break;
                                case "BonoTurno":
                                    myMergeField.Select();
                                    if (item.BonoTurno <= 0)
                                    {
                                        wordApp.Selection.TypeText(FormatNumero("0"));
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(FormatNumero(item.BonoTurno.ToString()));
                                    }
                                    break;

                                case "FechaVencimiento":
                                    myMergeField.Select();
                                    if (item.TipoContrato.Equals("INDEFINIDO"))
                                    {
                                        wordApp.Selection.TypeText("Indefinida");
                                    }
                                    else
                                    {
                                        wordApp.Selection.TypeText(String.Concat("hasta el ", item.FechaVencimiento.Value.ToLongDateString()));
                                    }
                                    break;

                                case "FechaInicio":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.FechaHasta.Value.ToLongDateString());
                                    break;
                                case "AFP":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Afp_Nombre);
                                    break;
                                case "Isapre":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Isapre_Nombre);
                                    break;

                                case "Desempeño":
                                    myMergeField.Select();
                                    try
                                    {
                                        if (item.Cargo.Contains("guardia") || item.Cargo.Contains("Guardia") || item.Cargo.Contains("GUARDIA"))
                                        {
                                            wordApp.Selection.TypeText("Guardia de Seguridad.");
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(_personal.Cargo);
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "SegundoParrafo":
                                    myMergeField.Select();
                                    try
                                    {
                                        if (item.Cargo.Contains("guardia") || item.Cargo.Contains("Guardia") || item.Cargo.Contains("GUARDIA"))
                                        {
                                            wordApp.Selection.TypeText("Guardia de Seguridad, será el encargado de asistir en la organización y realización de tareas de seguridad del área, patrullar o supervisar las instalaciones para evitar el robo, la violencia, o infracciones contra la empresa contratante, autorizar la entrada y salida de los empleados, visitantes y otras personas con el fin de protegerse contra el Robo y/o Hurto. El guardia de Seguridad es responsable de mantener instalaciones seguras, debe ser capaz de escribir informes sobre las actividades diarias y las irregularidades, tales como daños en los equipos o la propiedad, robos, Hurtos, la presencia de personas no autorizadas o los acontecimientos inusuales, o cualquier otro acontecimiento que revista los caracteres de delito. Un guardia de seguridad debe llamar a la Carabineros o a la Policía, bomberos y/o Ambulancias en casos de emergencia. Cuando un guardia de seguridad se enfrenta a personas no autorizadas que se niegan a abandonar la zona custodiada, deben llamar a la policía para efectuar el procedimiento.");
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(String.Concat(item.Cargo, ", ", _SegundoParrafo));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "DireccionInstalacion":
                                    myMergeField.Select();
                                    try
                                    {
                                        wordApp.Selection.TypeText(_DireccionInstalacion);
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "AfectoBonoAsistencia":
                                    myMergeField.Select();
                                    try
                                    {
                                        //if (_personal.Usuarios.Privilegio_Id == 5)
                                        if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                        {
                                            wordApp.Selection.TypeText("En el evento que el trabajador tenga un día de inasistencia o un atraso injustificado, se le descontará el 100% del bono de Asistencia y Responsabilidad.  Lo anterior sin perjuicio de lo estipulado en el Art. 160, nro. 3 y 4, del Código del Trabajo. El trabajador no tendrá otros beneficios que los que se hagan contar por escrito en el presente contrato.");
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "Anticipo":
                                    myMergeField.Select();
                                    try
                                    {
                                        if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                        {
                                            wordApp.Selection.TypeText(FormatNumero("60000"));
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(FormatNumero(_Anticipo.ToString()));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "AnticipoLetras":
                                    myMergeField.Select();
                                    try
                                    {
                                        if (_personal.Cargo.Contains("guardia") || _personal.Cargo.Contains("Guardia") || _personal.Cargo.Contains("GUARDIA"))
                                        {
                                            wordApp.Selection.TypeText(FormatNumero(String.Concat("(", PrimeraMayuscula(enletras("60000")), " pesos chilenos)")));
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(FormatNumero(String.Concat("(", PrimeraMayuscula(enletras(_Anticipo.ToString())), " pesos chilenos)")));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                case "DepositoBanco":
                                    myMergeField.Select();
                                    try
                                    {
                                        //vista Nº 18162030, del Banco Estado.
                                        if (_personal.Id_Banco == 19 && _personal.TipoCuenta.ToString().Equals("Cuenta Vista"))
                                        {
                                            wordApp.Selection.TypeText(String.Concat("Cuenta Rut", " Nº", _personal.NumeroCuenta, ", del", _Bancos.BuscaNombreBanco((int)_personal.Id_Banco)));
                                        }
                                        else
                                        {
                                            wordApp.Selection.TypeText(String.Concat(_personal.TipoCuenta, " Nº", _personal.NumeroCuenta, ", del", _Bancos.BuscaNombreBanco((int)_personal.Id_Banco)));
                                        }
                                    }
                                    catch (Exception)
                                    {
                                        throw;
                                    }
                                    break;

                                default:
                                    break;
                            }
                        }
                    }

                    if (File.Exists(String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf")))
                    {
                        Mensaje = String.Concat("Contrato a crear '", _RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(),
                                                "_", item.Rut, "-", item.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                        return false;
                    }

                    Object objSaveAsFile = String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf");
                    Object objFileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
                    wordDoc.SaveAs2(objSaveAsFile, ref objFileFormat, ref oMissing, ref oMissing,
                                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                    ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                    ref oMissing, ref oMissing);

                    MssBD.Documentos _doc = new MssBD.Documentos();
                    _doc = (from p in Modelo_BDMSS.Documentos
                            where p.Documento_Id == item.Documento_Id
                            select p).First();
                    _doc.PorVisar = false;

                    Modelo_BDMSS.SaveChanges();

                    _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha autorizado Visar Contratos de ", item.Rut.ToString(), "-", item.Dv));

                    if (wordDoc != null)
                    {
                        wordDoc.Close(ref objFalse, ref oMissing, ref oMissing);
                    }
                    if (wordApp != null)
                    {
                        wordApp.Quit(ref oMissing, ref oMissing, ref oMissing);
                    }

                }

                return true;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                try
                {
                    Marshal.ReleaseComObject(wordDoc);
                    Marshal.ReleaseComObject(wordApp);
                    wordApp = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    wordApp = null;
                }
                catch (Exception)
                {
                }
            }
        }

        public Boolean ValidaContrato(Int32 Rut)
        {
            try
            {
                var _contr = (from cont in Modelo_BDMSS.Contratos
                              join docum in Modelo_BDMSS.Documentos on cont.Documento_Id equals docum.Documento_Id
                              join per in Modelo_BDMSS.Personal on docum.Personal_Id equals per.Rut
                              where per.Rut == Rut
                              select cont).FirstOrDefault();

                if (_contr != null)
                {
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
