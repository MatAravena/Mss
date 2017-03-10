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
    public class Finiquitos : CommonBC
    {
        public MssBD.CON_Empleados_Rut_Centro_Result _per { get; set; }
                     
        MssBD.Usuarios _usuarioSesion;
        public String _RutaFinal { get; set; }
        public String _RutaInicioProyecto { get; set; }
        public String _Articulo { get; set; }
        public String _NumeroArticulo { get; set; }
        public String _Motivo { get; set; }
        public double _Total { get; set; }
        public double _Vacaciones { get; set; }

        Object oMissing = System.Reflection.Missing.Value;
        Object objFileFormat = Microsoft.Office.Interop.Word.WdSaveFormat.wdFormatPDF;
        Object objFalse = false;

        public Finiquitos(MssBD.Usuarios _usu)
        {
            _usuarioSesion = _usu;
        }
        public Finiquitos()
        {
        }

        public Boolean GeneraFiniquito(ref String Mensaje, IDictionary<int, Negocio.Documentos.Remuneracion> _listRemu)
        {

            Application wordApp = new Application();
            Document wordDoc = new Document();

            try
            {
                Object oMissing = System.Reflection.Missing.Value;
                //System.Windows.forms.application.startuppath

                var Assembly2 = System.Reflection.Assembly.GetExecutingAssembly();

                Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Finiquito_Template.dotx");

                wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

                // Creacion bookmark / Tabla Finiquitos
                Table tblRemuneraciones = getTableByBookmarkName(wordDoc, "Remuneraciones");
                int i = 0;
                for (i = 1; i <= _listRemu.Count(); i++)
                {
                    Remuneracion remu = new Remuneracion();
                    remu = (Remuneracion)_listRemu.ElementAt(i - 1).Value;

                    tblRemuneraciones.Cell(i, 1).Range.Text = String.Concat("Remuneraciones del ", remu.FechaInicio.ToShortDateString(), " al ", remu.FechaTermino.ToShortDateString());
                    tblRemuneraciones.Cell(i, 2).Range.Text = String.Concat("$", FormatNumero(remu.Monto.ToString()), ".-");
                    tblRemuneraciones.Rows.Add();
                }

                tblRemuneraciones.Cell(i + 1, 1).Range.Text = "Vacaciones Proporcionales:";
                tblRemuneraciones.Cell(i + 1, 2).Range.Text = String.Concat("$", _Vacaciones.ToString(), ".-");

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
                            case "FechaActual":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(DateTime.Now.ToLongDateString());
                                break;
                            case "Nombre":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(String.Concat(_per.Nombres, " ", _per.ApellidoPaterno, " ", _per.ApellidoMaterno)));
                                break;
                            case "Rut":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(String.Concat(FormatNumero(_per.Rut.ToString()), "-", _per.Dv));
                                break;
                            case "FechaInicio":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.FechaIngreso.Value.ToLongDateString());
                                break;
                            case "FechaHasta":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_per.FechaVencimiento.Value.ToLongDateString());
                                break;
                            case "Articulo":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_Articulo);
                                break;
                            case "NumeroArticulo":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_NumeroArticulo);
                                break;
                            case "Motivo":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(_Motivo);
                                break;
                            case "TotalNumerico":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(String.Concat("$", FormatNumero(_Total.ToString())));
                                break;
                            case "TotalLetras":
                                myMergeField.Select();
                                wordApp.Selection.TypeText(PrimeraMayuscula(enletras(_Total.ToString())));
                                break;

                            default:
                                break;
                        }
                    }
                }

                if (File.Exists(String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf")))
                {
                    Mensaje = String.Concat("Finiquito a crear '", _RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(),
                                            "_", _per.Rut, "-", _per.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                    return false;
                }

                //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".doc"));
                Object objSaveAsFile = String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".pdf");
                wordDoc.SaveAs2(objSaveAsFile, ref objFileFormat, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing, ref oMissing, ref oMissing, ref oMissing,
                                ref oMissing, ref oMissing);

                //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Contrato_", DateTime.Now.ToShortDateString(), "_", _per.Rut, "-", _per.Dv, ".doc"));
                _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha generado Finiquito de ", _per.Rut, "-", _per.Dv));

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

        private Table findTable(Document doc, string searchText)
        {
            try
            {
                if (doc.Tables.Count > 0)
                {
                    int iCount = 1;


                    Microsoft.Office.Interop.Word.Table tbl;
                    do
                    {
                        tbl = (Microsoft.Office.Interop.Word.Table)doc.Tables[iCount];
                        //Select first cell and check it's value
                        string header = tbl.Cell(1, 1).Range.Text;
                        if (header.Contains(searchText))
                        {
                            return tbl;
                        }
                        iCount++;
                        Marshal.ReleaseComObject(tbl);
                    } while (iCount < doc.Tables.Count + 1);
                }
                return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private Table getTableByBookmarkName(Document doc, string bookmarkName)
        {
            try
            {
                Table tbl = doc.Bookmarks[bookmarkName].Range.Tables[1];
                if (tbl != null)
                    return tbl;
                else
                    return null;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void asd()
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            object fileName = @"C:\Template\StudentLetter.doc";
            object confirmConversions = Type.Missing;
            object readOnly = Type.Missing;
            object addToRecentFiles = Type.Missing;
            object passwordDoc = Type.Missing;
            object passwordTemplate = Type.Missing;
            object revert = Type.Missing;
            object writepwdoc = Type.Missing;
            object writepwTemplate = Type.Missing;
            object format = Type.Missing;
            object encoding = Type.Missing;
            object visible = Type.Missing;
            object openRepair = Type.Missing;
            object docDirection = Type.Missing;
            object notEncoding = Type.Missing;
            object xmlTransform = Type.Missing;

            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Open(ref fileName, ref confirmConversions, ref readOnly, ref addToRecentFiles, ref passwordDoc, ref passwordTemplate, ref revert, ref writepwdoc, ref writepwTemplate, ref format, ref encoding, ref visible, ref openRepair, ref docDirection, ref notEncoding, ref xmlTransform);

        }
        private void ReplaceBookmarkText(Microsoft.Office.Interop.Word.Document doc, string bookmarkName, string text)
        {
            if (doc.Bookmarks.Exists(bookmarkName))
            {

                Object name = bookmarkName;

                Microsoft.Office.Interop.Word.Range range =

                doc.Bookmarks.get_Item(ref name).Range;

                range.Text = text;

                object newRange = range;

                doc.Bookmarks.Add(bookmarkName, ref newRange);
            }

        }

        public List<MssBD.VW_DOC_Finiquitos> BuscaFiniquitos_Visar(MssBD.Usuarios _usu, DateTime FechaDesde, DateTime FechaHasta)
        {
            try
            {
                FechaDesde = FechaDesde.AddDays(-1);
                FechaHasta = FechaHasta.AddDays(1);

                var _vw = (from p in Modelo_BDMSS.VW_DOC_Finiquitos
                           where p.Fecha >= FechaDesde && p.Fecha <= FechaHasta && p.PorVisar == true
                           select p).ToList();

                if (_vw.Count() > 0)
                {
                    _log.IngresaLog(_usu, String.Concat(_usu.Usuario_Nombre, " ha consultado Finiquitos a Visar "));
                    return _vw;
                }
                return null;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool GenereFiniquitosMasivos(ref String Mensaje, List<MssBD.VW_DOC_Finiquitos> _ListFiniquitos, String _RutaFinal)
        {
            Application wordApp = new Application();
            Document wordDoc = new Document(); ;
            try
            {
                foreach (var item in _ListFiniquitos)
                {
                    Object oMissing = System.Reflection.Missing.Value;

                    //Object oTemplatePath = String.Concat(_RutaInicioProyecto.Replace("\\Mss Proyecto\\bin\\Debug", String.Empty), "\\Negocio\\WordTemplate\\Finiquito_Template.dotx");
                    //Object oTemplatePath = "C:/Users/Matias Aravena/Pegas/MSS/Mss Aplicativo/Negocio/WordTemplate/Finiquito_Template.dotx";
                    Object oTemplatePath = String.Concat(RutaArchivosMss, "\\Finiquito_Template.dotx");

                    wordApp = new Application();
                    wordDoc = new Document();

                    wordDoc = wordApp.Documents.Add(ref oTemplatePath, ref oMissing, ref oMissing, ref oMissing);

                    // Creacion bookmark / Tabla Finiquitos
                    Table tblRemuneraciones = getTableByBookmarkName(wordDoc, "Remuneraciones");

                    List<MssBD.Remuneraciones> _remuList = new List<MssBD.Remuneraciones>();
                    _remuList = Modelo_BDMSS.Remuneraciones.Where(fini => fini.Finiquito_Id == item.Finiquito_Id).ToList()
                                                           .OrderBy(fini => fini.Finiquito_Id).ToList();
                    Int32 orden = 1;
                    foreach (var _remu in _remuList)
                    {
                        tblRemuneraciones.Cell(orden, 1).Range.Text = String.Concat("Remuneraciones del ", _remu.FechaInicio.Value.ToShortDateString(), " al ", _remu.FechaTermino.Value.ToShortDateString());
                        tblRemuneraciones.Cell(orden, 2).Range.Text = String.Concat("$", _remu.monto.ToString());
                        tblRemuneraciones.Rows.Add();
                        orden = orden + 1;
                    }
                    tblRemuneraciones.Cell(orden, 1).Range.Text = "Vacaciones Proporcionales:";
                    tblRemuneraciones.Cell(orden, 2).Range.Text = String.Concat("$", item.Vacaciones.ToString(), ".-");

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
                                case "FechaActual":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(DateTime.Now.ToLongDateString());
                                    break;
                                case "Nombre":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(String.Concat(item.Nombres, " ", item.ApellidoPaterno, " ", item.ApellidoMaterno)));
                                    break;
                                case "Rut":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(String.Concat(item.Rut, "-", item.Dv));
                                    break;
                                case "FechaInicio":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.FechaIngreso.Value.ToLongDateString());
                                    break;
                                case "FechaHasta":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.FechaVencimiento.Value.ToLongDateString());
                                    break;
                                case "Articulo":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Articulo);
                                    break;
                                case "NumeroArticulo":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Articulo_Numero.ToString());
                                    break;
                                case "Motivo":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.Comentario.ToString());
                                    break;
                                case "TotalNumerico":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(item.MontoTotal.ToString());
                                    break;
                                case "TotalLetras":
                                    myMergeField.Select();
                                    wordApp.Selection.TypeText(PrimeraMayuscula(enletras(item.MontoTotal.ToString())));
                                    break;
                                default:
                                    break;
                            }
                        }
                    }

                    if (File.Exists(String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf")))
                    {
                        Mensaje = String.Concat("Finiquito a crear '", _RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(),
                                                "_", item.Rut, "-", item.Dv, ".pdf", "' ya existe en la carpeta destino, favor revisar");
                        return false;
                    }

                    //wordDoc.SaveAs2(String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".doc"));

                    Object objSaveAsFile = String.Concat(_RutaFinal, "Finiquito_", DateTime.Now.ToShortDateString(), "_", item.Rut, "-", item.Dv, ".pdf");
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

                    _log.IngresaLog(_usuarioSesion, String.Concat(_usuarioSesion.Usuario_Nombre, " ha autorizado Visar Finiquito de ", item.Rut.ToString(), "-", item.Dv));

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
    }
}
