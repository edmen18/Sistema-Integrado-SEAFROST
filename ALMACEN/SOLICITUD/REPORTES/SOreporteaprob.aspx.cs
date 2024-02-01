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

public partial class ORDENCOMPRA_REPORTES_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string idoc = Convert.ToString(Request.QueryString["ID"]);
        string Tdoc = Convert.ToString(Request.QueryString["TD"]);
        idoc = idoc.Trim();

        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        exportOpts.ExportFormatOptions = pdfOpts;
        tabla_solicitud TABL = new tabla_solicitud();
            TABL.SM_ID = Convert.ToInt32(idoc);
            TABL.SM_TIPOS = (Tdoc);
        ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("RSolicitud.rpt"));
            report.SetDataSource(tabla_solicitud.ListarSolicit(TABL));
        //report.ExportToHttpResponse(exportOpts, Response, false, idoc );
        //CrystalReportViewer1.ReportSource = report;
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

    
}