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
    public class Anexos : CommonBC
    {
        public MssBD.CON_Empleados_Rut_Centro_Result _per { get; set; }
        MssBD.Usuarios _usuarioSesion;
        public String _RutaFinal { get; set; }
        public String _RutaInicioProyecto { get; set; }
        public String _TipoContrato { get; set; }
        public DateTime _FechaAnexo { get; set; }

        Object oMissing = System.Reflection.Missing.Value;
        Object objFileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
        Object objFalse = false;

        public Anexos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
        }

        public Anexos()
        {
        }

        public Boolean GeneraAnexo(ref String Mensaje)
        {
            Application wordApp = new Application();
            Document wordDoc = new Document();

            try
            {
                Object oMissing = System.Reflection.Missing.Value;
                Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Anexo_Template.dotx");

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
                            case "FechaInicio":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.FechaIngreso.Value.ToLongDateString());
                                break;
                            case "Nombre":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(String.Concat(_per.Nombres, " ", _per.ApellidoPaterno, " ", _per.ApellidoMaterno)));
                                break;
                            case "Rut":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(String.Concat(FormatNumero(_per.Rut.ToString()), "-", _per.Dv));
                                break;
                            case "EstadoCivil":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.EstadoCivil);
                                break;
                            case "FechaNacimiento":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.FechaNacimiento.Value.ToLongDateString());
                                break;
                            case "Direccion":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.Direccion);
                                break;
                            case "Comuna":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.comuna_nombre);
                                break;
                            case "Telefono":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.TelFijo);
                                break;
                            case "FechaAnexo":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_FechaAnexo.ToLongDateString());
                                break;
                            case "FechaVencimiento":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.FechaVencimiento.Value.ToLongDateString());
                                break;
                            default:
                                break;
                        }
                    }
                }

                if (File.Exists(String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf")))
                {
                    Mensaje = String.Concat("Anexo a crear '", _RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(),
                                            "_", _per.Rut, "-", _per.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                    return false;
                }

                //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".doc"));
                Object objSaveAsFile = String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf");
                wordDoc.SaveAs2(objSaveAsFile, ref objFileFormat, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing);

                //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".doc"));
                _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha generado Anexo de ", _per.Rut, "-", _per.Dv));

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
                    wordApp = (Microsoft.Office.Interop.Word.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Word.Application");
                    wordApp = null;
                }
                catch (Exception)
                {
                }
            }
        }


        public List<MssBD.VW_DOC_Anexos> BuscaAnexos_Visar(MssBD.Usuarios _usu, DateTime FechaDesde, DateTime fechaHasta)
        {
            try
            {
                FechaDesde = FechaDesde.AddDays(-1);
                fechaHasta = fechaHasta.AddDays(1);

                var _vw = (from p in Modelo_BDMSS.VW_DOC_Anexos
                           where p.Fecha >= FechaDesde && p.Fecha <= fechaHasta && p.PorVisar == true
                           select p).ToList();

                if (_vw.Count() > 0)
                {
                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha consultado Anexos a Visar "));
                    return _vw;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool GenereAnexosMasivos(ref String Mensaje, List<MssBD.VW_DOC_Anexos> _ListAnexos, String _RutaFinal)
        {
            Application wordApp = new Application(); ;
            Document wordDoc = new Document(); ;
            try
            {
                foreach (var item in _ListAnexos)
                {
                    Object oMissing = System.Reflection.Missing.Value;
                    Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Anexo_Template.dotx");

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
                                case "FechaInicio":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.FechaDesde.Value.ToLongDateString());
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
                                case "Direccion":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Direccion);
                                    break;
                                case "Comuna":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.comuna_nombre);
                                    break;
                                case "Telefono":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.TelFijo);
                                    break;
                                case "FechaAnexo":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(_FechaAnexo.ToLongDateString());
                                    break;
                                case "FechaVencimiento":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(_per.FechaVencimiento.Value.ToLongDateString());
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (File.Exists(String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf")))
                    {
                        Mensaje = String.Concat("Anexo a crear '", _RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(),
                                                "_", item.Rut, "-", item.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                        return false;
                    }

                    //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".doc"));

                    Object objSaveAsFile = String.Concat(_RutaFinal, "Anexo_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf");
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

                    _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha autorizado Visar Anexo de ", item.Rut.ToString(), "-", item.Dv));

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
            catch (Exception)
            {

                throw;
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

    }
}