using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MssBD;

namespace Negocio
{
    public class CommonBC
    {
        private static MssBD.MSS_BDEntities _ModeloEmpleados;
        private static MssBD.MSS_BDEntities _Modelo_Logs;

        public string RutaArchivosMss = "C:\\Users\\Matias Aravena\\Pegas\\MSS\\Mss Aplicativo\\Negocio\\WordTemplate";
        //public string RutaArchivosMss = "\\\\MSS1-PC\\Matias Aravena\\WordTemplate";

        public static MssBD.MSS_BDEntities Modelo_Logs
        {
            get { return CommonBC._Modelo_Logs; }
            set { CommonBC._Modelo_Logs = value; }
        }

        public static LogClass _log = new LogClass();

        public static MSS_BDEntities Modelo_BDMSS_Logs
        {
            get
            {
                if (Modelo_Logs == null)
                {
                    Modelo_Logs = new MSS_BDEntities();
                }
                return Modelo_Logs;
            }
        }

        public static MSS_BDEntities Modelo_BDMSS
        {
            get
            {
                if (_ModeloEmpleados == null)
                {
                    _ModeloEmpleados = new MSS_BDEntities();
                }
                return _ModeloEmpleados;
            }
        }

        public CommonBC()
        {
        }

        public enum UserStatus
        {
            Unverified,
            Active,
            Removed,
            Suspended,
            Banned
        }

        public string enletras(string num)
        {
            string res, dec = "";
            Int64 entero;
            int decimales;
            double nro;

            try
            {
                nro = Convert.ToDouble(num);
            }
            catch
            {
                return "";
            }

            entero = Convert.ToInt64(Math.Truncate(nro));
            decimales = Convert.ToInt32(Math.Round((nro - entero) * 100, 2));
            if (decimales > 0)
            {
                dec = " Con " + decimales.ToString() + "/100";
            }

            res = toText(Convert.ToDouble(entero)) + dec;
            return String.Concat(res, " Pesos ");
        }

        private string toText(double value)
        {
            string Num2Text = "";
            value = Math.Truncate(value);
            if (value == 0) Num2Text = "Cero";
            else if (value == 1) Num2Text = "uno";
            else if (value == 2) Num2Text = "dos";
            else if (value == 3) Num2Text = "tres";
            else if (value == 4) Num2Text = "cuatro";
            else if (value == 5) Num2Text = "cinco";
            else if (value == 6) Num2Text = "seis";
            else if (value == 7) Num2Text = "siete";
            else if (value == 8) Num2Text = "ocho";
            else if (value == 9) Num2Text = "nueve";
            else if (value == 10) Num2Text = "diez";
            else if (value == 11) Num2Text = "once";
            else if (value == 12) Num2Text = "doce";
            else if (value == 13) Num2Text = "trece";
            else if (value == 14) Num2Text = "catorce";
            else if (value == 15) Num2Text = "quince";
            else if (value < 20) Num2Text = "dieci" + toText(value - 10);
            else if (value == 20) Num2Text = "veinte";
            else if (value < 30) Num2Text = "veinti" + toText(value - 20);
            else if (value == 30) Num2Text = "treinta";
            else if (value == 40) Num2Text = "cuarenta";
            else if (value == 50) Num2Text = "cincuenta";
            else if (value == 60) Num2Text = "sesenta";
            else if (value == 70) Num2Text = "setenta";
            else if (value == 80) Num2Text = "ochenta";
            else if (value == 90) Num2Text = "noventa";
            else if (value < 100) Num2Text = toText(Math.Truncate(value / 10) * 10) + " Y " + toText(value % 10);
            else if (value == 100) Num2Text = "cien";
            else if (value < 200) Num2Text = "ciento " + toText(value - 100);
            else if ((value == 200) || (value == 300) || (value == 400) || (value == 600) || (value == 800)) Num2Text = toText(Math.Truncate(value / 100)) + "cientos";
            else if (value == 500) Num2Text = "quinientos";
            else if (value == 700) Num2Text = "setecientos";
            else if (value == 900) Num2Text = "novecientos";
            else if (value < 1000) Num2Text = toText(Math.Truncate(value / 100) * 100) + " " + toText(value % 100);
            else if (value == 1000) Num2Text = "mil";
            else if (value < 2000) Num2Text = "mil " + toText(value % 1000);
            else if (value < 1000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000)) + " mil";
                if ((value % 1000) > 0) Num2Text = Num2Text + " " + toText(value % 1000);
            }

            else if (value == 1000000) Num2Text = "Un millon";
            else if (value < 2000000) Num2Text = "Un millon " + toText(value % 1000000);
            else if (value < 1000000000000)
            {
                Num2Text = toText(Math.Truncate(value / 1000000)) + " millones ";
                if ((value - Math.Truncate(value / 1000000) * 1000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000) * 1000000);
            }

            else if (value == 1000000000000) Num2Text = "Un billon";
            else if (value < 2000000000000) Num2Text = "Un billon " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);

            else
            {
                Num2Text = toText(Math.Truncate(value / 1000000000000)) + " billones";
                if ((value - Math.Truncate(value / 1000000000000) * 1000000000000) > 0) Num2Text = Num2Text + " " + toText(value - Math.Truncate(value / 1000000000000) * 1000000000000);
            }
            return Num2Text;
        }

        public string PrimeraMayuscula(string value)
        {
            return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(value.ToLower());
        }

        public String FormatNumero(String Text)
        {
            if (Text != string.Empty)
                return string.Format("{0:#,##0}", double.Parse(Text));
            else
                return "0";
        }
    }
}
