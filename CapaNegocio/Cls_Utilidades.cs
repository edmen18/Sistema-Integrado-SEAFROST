using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Configuration;
using System.Web;
using System.Net.Mail;
using System.Data;
using System.IO;
namespace CapaNegocio
{
    public class Cls_Utilidades
    {
        public static string ExportarExcelDataTable(DataTable dt, string nombreexel)
        {
            HttpServerUtility server = HttpContext.Current.Server;
            string RutaExcel = server.MapPath("~") + "\\Bin\\" + nombreexel;

            const string FIELDSEPARATOR = "\t";
            const string ROWSEPARATOR = "\n";
            StringBuilder output = new StringBuilder();
            // Escribir encabezados    
            foreach (DataColumn dc in dt.Columns)
            {
                output.Append(dc.ColumnName);
                output.Append(FIELDSEPARATOR);
            }
            output.Append(ROWSEPARATOR);
            foreach (DataRow item in dt.Rows)
            {
                foreach (object value in item.ItemArray)
                {
                    output.Append(value.ToString().Replace('\n', ' ').Replace('\r', ' ').Replace('.', ','));
                    output.Append(FIELDSEPARATOR);
                }
                // Escribir una línea de registro        
                output.Append(ROWSEPARATOR);
            }
            // Valor de retorno    
            // output.ToString();
            StreamWriter sw = new StreamWriter(RutaExcel);
            sw.Write(output.ToString());
            sw.Close();
            return RutaExcel;
        }
        public static string mensajescript(string mensaje)
        {

            string script5 = @"<script type='text/javascript'> alert('" + mensaje + "');</script>";
            return script5;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="cantidad"></param>
        /// <returns></returns>
        public static string miFuncionRS(string str, int cantidad)
        {
            string cadenaO = "";
            str = str.Replace(",", "");
            var cadenaN = str.Split(' ');
            var MILEN = cadenaN.Length;
            for (int i = 0; i < MILEN; i++)
            {
                if (MILEN - 1 == i || MILEN - 2 == i)
                {
                    cadenaO += (MILEN - 1 == i ? cadenaN[i].PadRight(cantidad, ' ') : cadenaN[i] + " ");
                }
                else {
                    cadenaO += cadenaN[i].PadRight(cantidad, ' ');
                }
            }
            return cadenaO;
        }
        public static string miCadenaLimite(string str,int cantidad)
        {
            string cadenaNueva = str;
            cadenaNueva = cadenaNueva.Substring(0,(str.Length>30?cantidad:str.Length));
            return cadenaNueva;
        }

        public static string replicate(string str, int times)
        {
            string repli = string.Empty;
            for (int i = 1; i <= times; i++)
            {
                repli += str;

            }
            return repli;
        }
        public static string llenaConceros(string texto, int num)
        {
            texto = replicate("0", (num - texto.Length)) + texto;
            return texto;
        }

        public static string devuelveClave(string texto)
        {

            string ingreso = texto;
            string cadena = string.Empty;
            int longcadena = ingreso.Length;

            for (int i = 0; i < longcadena; i++)
            {
                String letra = ingreso.Substring(i, 1);
                int aas = Convert.ToChar(letra);
                int sumalon = aas + longcadena;
                char retorno = Convert.ToChar(sumalon);
                cadena = cadena + Convert.ToString(retorno);
            }
            return cadena;

        }
        public static string retornaLetra(int x)
        {
            string letra = string.Empty;

            if (x == 1)
                letra = "A";
            if (x == 2)
                letra = "B";
            if (x == 3)
                letra = "C";
            if (x == 4)
                letra = "D";
            if (x == 5)
                letra = "E";
            if (x == 6)
                letra = "F";
            if (x == 7)
                letra = "G";
            if (x == 8)
                letra = "H";
            if (x == 9)
                letra = "I";
            if (x == 10)
                letra = "J";
            if (x == 11)
                letra = "K";
            if (x == 12)
                letra = "L";
            if (x == 13)
                letra = "M";
            if (x == 14)
                letra = "N";
            if (x == 15)
                letra = "O";
            if (x == 16)
                letra = "P";
            if (x == 17)
                letra = "Q";
            if (x == 18)
                letra = "R";
            if (x == 19)
                letra = "S";
            if (x == 20)
                letra = "T";
            if (x == 21)
                letra = "U";
            if (x == 22)
                letra = "V";
            if (x == 23)
                letra = "W";
            if (x == 24)
                letra = "X";
            if (x == 25)
                letra = "Y";
            if (x == 26)
                letra = "Z";
            if (x == 27)
                letra = "AA";
            if (x == 28)
                letra = "AB";
            if (x == 29)
                letra = "AC";
            if (x == 30)
                letra = "AD";
            if (x == 31)
                letra = "AE";
            if (x == 32)
                letra = "AF";
            if (x == 33)
                letra = "AG";
            if (x == 34)
                letra = "AH";
            if (x == 35)
                letra = "AI";
            if (x == 36)
                letra = "AJ";
            if (x == 37)
                letra = "AK";
            if (x == 38)
                letra = "AL";
            if (x == 39)
                letra = "AM";
            if (x == 40)
                letra = "AN";
            if (x == 41)
                letra = "AO";
            if (x == 42)
                letra = "AP";
            if (x == 43)
                letra = "AQ";
            if (x == 44)
                letra = "AR";
            if (x == 45)
                letra = "AS";
            if (x == 46)
                letra = "AT";
            if (x == 47)
                letra = "AU";
            if (x == 48)
                letra = "AV";
            if (x == 49)
                letra = "AW";
            if (x == 50)
                letra = "AX";
            if (x == 51)
                letra = "AY";
            if (x == 52)
                letra = "AZ";


            return letra;

        }


        public static string Right(string param, int length)
        {

            int value = param.Length - length;

            string result = param.Substring(value, length);

            return result;

        }

        public static void enviarMail(string direccion, string smtp, string pass, string cuerpo, string asunto, string para, string copia, string copiacco, List<string> fichero)
        {
            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(direccion);
            msg.To.Add(para);
            if (copia.Length > 0)
            {
                msg.CC.Add(copia);
            }
            if (copiacco.Length > 0)
            {
                msg.Bcc.Add(copiacco);
            }
            msg.Subject = asunto;
            msg.Body = cuerpo;
            msg.IsBodyHtml = true;

            foreach (string l in fichero)
            {
                msg.Attachments.Add(new System.Net.Mail.Attachment(l));

            }

            SmtpClient mail = new SmtpClient(smtp);
            mail.Port = 587;
            mail.Credentials = new System.Net.NetworkCredential(direccion, pass);
            mail.Send(msg);

            msg.Dispose();
            mail.Dispose();
        }



        public static Stream ImprimirCrystalReport(string reporte, string cnSVR, string cnDB, string cnUID, string cnPWD, string[] parametros, string nombre)
        {
            HttpServerUtility server = HttpContext.Current.Server;
            string rr = server.MapPath("~") + "\\Bin\\" + reporte;
            ReportDocument crReport = new ReportDocument();
            ConnectionInfo crConnInfo = new ConnectionInfo();
            TableLogOnInfo crLogOnInfo = new TableLogOnInfo();
            crConnInfo.DatabaseName = cnDB;
            crConnInfo.ServerName = cnSVR;
            crConnInfo.UserID = cnUID;
            crConnInfo.Password = cnPWD;
            crReport.Load(rr);
            crReport.DataSourceConnections[0].SetConnection(crConnInfo.ServerName, crConnInfo.DatabaseName, false);
            crReport.RecordSelectionFormula = nombre;
            Tables crTables;
            crTables = crReport.Database.Tables;
            foreach (Table crTable in crTables)
            {
                crConnInfo.DatabaseName = cnDB;
                crConnInfo.ServerName = cnSVR;
                crConnInfo.UserID = cnUID;
                crConnInfo.Password = cnPWD;
                crLogOnInfo = crTable.LogOnInfo;
                crLogOnInfo.ConnectionInfo = crConnInfo;
                crTable.ApplyLogOnInfo(crLogOnInfo);
            }

            for (int i = 0; i <= parametros.Length - 1; i++)
                crReport.SetParameterValue(i, parametros[i]);

            System.IO.MemoryStream rptStream = new System.IO.MemoryStream();
            rptStream = (System.IO.MemoryStream)(crReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            crReport.Close();
            crReport.Dispose();
            return rptStream;// crReport;
        }


        public static MemoryStream ImprimirCrystalReportOC(string reporte, string cnSVR, string cnDB, string cnUID, string cnPWD, string[] parametros, string nombre)
        {
            HttpServerUtility server = HttpContext.Current.Server;
            string rr = server.MapPath("~") + "\\ORDENCOMPRA/REPORTES\\" + reporte;
            ReportDocument crReport = new ReportDocument();
            //ConnectionInfo crConnInfo = new ConnectionInfo();
            //TableLogOnInfo crLogOnInfo = new TableLogOnInfo();
            //crConnInfo.DatabaseName = cnDB;
            //crConnInfo.ServerName = cnSVR;
            //crConnInfo.UserID = cnUID;
            //crConnInfo.Password = cnPWD;
            crReport.Load(rr);
            //crReport.DataSourceConnections[0].SetConnection(crConnInfo.ServerName, crConnInfo.DatabaseName, false);
            //crReport.RecordSelectionFormula = nombre;
            //Tables crTables;
            //crTables = crReport.Database.Tables;
            //foreach (Table crTable in crTables)
            //{
            //    crConnInfo.DatabaseName = cnDB;
            //    crConnInfo.ServerName = cnSVR;
            //    crConnInfo.UserID = cnUID;
            //    crConnInfo.Password = cnPWD;
            //    crLogOnInfo = crTable.LogOnInfo;
            //    crLogOnInfo.ConnectionInfo = crConnInfo;
            //    crTable.ApplyLogOnInfo(crLogOnInfo);
            //}

            //for (int i = 0; i <= parametros.Length - 1; i++)
            //    crReport.SetParameterValue(i, parametros[i]);

            System.IO.MemoryStream rptStream = new System.IO.MemoryStream();
            rptStream = (System.IO.MemoryStream)(crReport.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat));
            crReport.Close();
            crReport.Dispose();
            return rptStream;// crReport;
        }

        public static void LogError(Exception ex)
        {
            List<string> fichero = new List<string>();
            string message = string.Format("Time: {0}", DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            message += string.Format("Message: {0}", ex.Message);
            message += Environment.NewLine;
            message += string.Format("StackTrace: {0}", ex.StackTrace);
            message += Environment.NewLine;
            message += string.Format("Source: {0}", ex.Source);
            message += Environment.NewLine;
            message += string.Format("TargetSite: {0}", ex.TargetSite.ToString());
            message += Environment.NewLine;
            message += "-----------------------------------------------------------";
            message += Environment.NewLine;
            string path = HttpContext.Current.Server.MapPath("~/ErrorLog.txt");
            using (StreamWriter writer = new StreamWriter(path, true))
            {
                //Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", "", "ERROR DE INGRESO", "programador2@seafrost.com.pe", "", "", fichero);
                Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2016frost", message, "ERROR DE INGRESO", "programador2@seafrost.com.pe", "", "", fichero);
                writer.WriteLine(message);
                writer.Close();
            }
        }

        public static string mimoneda(string mn)
        {
            switch (mn)
            {
                case "MN": return "SOLES";
                case "US": return "DOLARES";
            }
            return "";
        }
        public static string Decimales(string num)
        {
            string numero = num;
            string[] valores = numero.Split('.');
            string vDecimal = valores[1];
            return vDecimal + "/100";
        }

        public static string Unidades(int num)
        {
            switch (num)
            {
                case 1: return "UN";
                case 2: return "DOS";
                case 3: return "TRES";
                case 4: return "CUATRO";
                case 5: return "CINCO";
                case 6: return "SEIS";
                case 7: return "SIETE";
                case 8: return "OCHO";
                case 9: return "NUEVE";
            }

            return "";
        }

        public static string Decenas(decimal num)
        {
            int decena = Convert.ToInt32(Math.Floor(num / 10));
            int unidad = Convert.ToInt32(num - (decena * 10));

            switch (decena)
            {
                case 1:
                    switch (unidad)
                    {
                        case 0: return "DIEZ";
                        case 1: return "ONCE";
                        case 2: return "DOCE";
                        case 3: return "TRECE";
                        case 4: return "CATORCE";
                        case 5: return "QUINCE";
                        default: return "DIECI" + Unidades(unidad);
                    }
                case 2:
                    switch (unidad)
                    {
                        case 0: return "VEINTE";
                        default: return "VEINTI" + Unidades(unidad);
                    }
                case 3: return DecenasY("TREINTA", unidad);
                case 4: return DecenasY("CUARENTA", unidad);
                case 5: return DecenasY("CINCUENTA", unidad);
                case 6: return DecenasY("SESENTA", unidad);
                case 7: return DecenasY("SETENTA", unidad);
                case 8: return DecenasY("OCHENTA", unidad);
                case 9: return DecenasY("NOVENTA", unidad);
                case 0: return Unidades(unidad);
            }
            return "";
        }

        public static string DecenasY(string strSin, int numUnidades)
        {
            if (numUnidades > 1)
            {
                return strSin + " Y " + Unidades(numUnidades);
            }
            else if (numUnidades == 1)
            {
                return strSin + " Y UNO";
            }
            return strSin;
        }

        public static string Centenas(decimal num)
        {
            int centenas = Convert.ToInt32(Math.Floor(num / 100));
            int decenas = Convert.ToInt32(num - (centenas * 100));

            switch (centenas)
            {
                case 1:
                    if (decenas > 0)
                    {
                        return "CIENTO " + Decenas(decenas);
                    }
                    else {
                        return "CIEN";
                    }
                case 2: return "DOSCIENTOS " + Decenas(decenas);
                case 3: return "TRESCIENTOS " + Decenas(decenas);
                case 4: return "CUATROCIENTOS " + Decenas(decenas);
                case 5: return "QUINIENTOS " + Decenas(decenas);
                case 6: return "SEISCIENTOS " + Decenas(decenas);
                case 7: return "SETECIENTOS " + Decenas(decenas);
                case 8: return "OCHOCIENTOS " + Decenas(decenas);
                case 9: return "NOVECIENTOS " + Decenas(decenas);
            }

            return Decenas(decenas);
        }

        public static string Seccion(decimal num, int divisor, string strSingular, string strPlural)
        {
            int cientos = Convert.ToInt32(Math.Floor(num / divisor));
            int resto = Convert.ToInt32(num - (cientos * divisor));

            string letras = "";

            if (cientos > 0)
                if (cientos > 1)
                    letras = Centenas(cientos) + " " + strPlural;
                else
                    letras = strSingular;

            if (resto > 0)
                letras += "";

            return letras;
        }

        public static string Miles(decimal num)
        {
            int divisor = 1000;
            int cientos = Convert.ToInt32(Math.Floor(num / divisor));
            int resto = Convert.ToInt32(num - (cientos * divisor));

            string strMiles = Seccion(num, divisor, "UN MIL", "MIL");
            string strCentenas = Centenas(resto);

            if (strMiles == "")
                return strCentenas;

            return strMiles + " " + strCentenas;
        }

        public static string Millones(decimal num)
        {
            int divisor = 1000000;
            int cientos = Convert.ToInt32(Math.Floor(num / divisor));
            int resto = Convert.ToInt32(num - (cientos * divisor));

            string strMillones = Seccion(num, divisor, "UN MILLON", "MILLONES");
            string strMiles = Miles(resto);

            if (strMillones == "")
                return strMiles;

            return strMillones + " " + strMiles;
        }

        public static string NumeroLetras(decimal num, string mon)
        {
            var OBJ = new
            {
                numero = num,
                enteros = Math.Floor(num),
                centavos = (((Math.Round(num * 100)) - (Math.Floor(num) * 100))),
            };

            return "SON: " + Millones(OBJ.enteros) + " " + Decimales(num.ToString()) + " " + mimoneda(mon);
        }
    }
}
