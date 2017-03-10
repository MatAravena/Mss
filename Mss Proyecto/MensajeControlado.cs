using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mss_Proyecto
{
    public partial class MensajeControlado : Form
    {
        public MensajeControlado(String Solucion, String exepcion, Exception ex)
        {
            InitializeComponent();
            switch (ex.GetType().ToString())
            {
                case "System.Runtime.InteropServices.COMException":
                    txtError.Text = exepcion;

                    if (String.Equals(exepcion.ToString(), "No se puede encontrar el archivo."))
                    {
                        Solucion = "Para solucionar éste problema debe acceder vía RED al computador MSS1-PC. Al acceder a éste computador con sus credenciales de sesión de Window a la red permitirá poder crear los documentos.";
                    }
                    txtSolucion.Text = Solucion;
                    break;
                case "System.Data.Entity.Validation.DbEntityValidationException":
                    //foreach (var validationErrors in ex.EntityValidationErrors)
                    //{
                    //    foreach (var validationError in validationErrors.ValidationErrors)
                    //    {
                    //        Trace.TraceInformation("Property: {0} Error: {1}",
                    //                                validationError.PropertyName,
                    //                                validationError.ErrorMessage);
                    //    }
                    //}
                    txtError.Text = exepcion;
                    txtSolucion.Text = Solucion;
                    break;
                default:
                    txtError.Text = "Error no encontrado. Favor comunicarse con Administrador de aplicación. " + exepcion;
                    txtSolucion.Text = "Dar a conocer posible motivo de error para solucionarlo a la brevedad.";
                    break;
            }

            //catch (DbEntityValidationException dbEx)
            //{
            //    foreach (var validationErrors in dbEx.EntityValidationErrors)
            //    {
            //        foreach (var validationError in validationErrors.ValidationErrors)
            //        {
            //            Trace.TraceInformation("Property: {0} Error: {1}",
            //                                    validationError.PropertyName,
            //                                    validationError.ErrorMessage);
            //        }
            //    }
            //    throw;
            //}
        }

        private void btn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
