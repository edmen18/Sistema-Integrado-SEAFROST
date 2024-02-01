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

        public static string devuelveClave (string texto)
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
            return  cadena;

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
            mail.Port = 547;
            mail.Credentials = new System.Net.NetworkCredential(direccion, pass);
            mail.Send(msg);

            msg.Dispose();
            mail.Dispose();
        }


    
        public static MemoryStream ImprimirCrystalReport(string reporte, string cnSVR, string cnDB, string cnUID, string cnPWD, string[] parametros, string nombre)
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


    }
}
