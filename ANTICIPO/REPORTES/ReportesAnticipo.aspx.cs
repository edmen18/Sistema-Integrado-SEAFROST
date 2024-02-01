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



public partial class ORDENCOMPRA_REPORTES_ReportesAnticipo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            tabla_anticipo TABL = new tabla_anticipo();

            TABL.ANT_CODIGO = idoc.Trim();

            //ReportDocument report = new ReportDocument();
            //report.Load(Server.MapPath("Cr_ReporteAnticipo.rpt"));
            //report.SetDataSource(tabla_anticipo.SAreporte(TABL));
            //report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, idoc);


            ReportDocument report = new ReportDocument();
            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.ExportFormatOptions = pdfOpts;

            report.Load(Server.MapPath("Cr_ReporteAnticipo.rpt"));
            report.SetDataSource(tabla_anticipo.SAreporte(TABL));

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