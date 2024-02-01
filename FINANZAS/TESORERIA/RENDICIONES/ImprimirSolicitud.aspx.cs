using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class FINANZAS_TESORERIA_RENDICIONES_ImprimirSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string NUMERO = Convert.ToString(Request.QueryString["NUMERO"]);
            string TIPO = Convert.ToString(Request.QueryString["TIPO"]);
            string ESTADO = Convert.ToString(Request.QueryString["ESTADO"]);
            tabla_oer TABL = new tabla_oer();

            TABL.ORDEN_NUMERO = NUMERO.Trim();
            TABL.CODIGO_CAJA = Convert.ToInt32(TIPO);
            TABL.ESTADO = ESTADO;

            ReportDocument report = new ReportDocument();
            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.ExportFormatOptions = pdfOpts;
            if (ESTADO == "L" )
            {
                if (TIPO == "2")
                {
                    report.Load(Server.MapPath("CR_SOLICITUDDETALLE.rpt"));
                }
                if (TIPO == "1")
                {
                    report.Load(Server.MapPath("CR_SOLICITUDDETALLECC.rpt"));
                }

                report.SetDataSource(tabla_oer.Imprimir2(TABL));
            }
            else
            {
                if (TIPO == "2")
                {
                    report.Load(Server.MapPath("CR_SOLICITUD.rpt"));
                }
                if (TIPO == "1")
                {
                    report.Load(Server.MapPath("CR_SOLICITUDCAJA.rpt"));
                }
                report.SetDataSource(tabla_oer.Imprimir(TABL));
            }
            System.IO.Stream oStream = null;
            byte[] byteArray = null;
            oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.Flush();
            Response.Close();
            report.Close();
            report.Dispose();
        }
        catch
        {
            throw;
        }
    }
}
