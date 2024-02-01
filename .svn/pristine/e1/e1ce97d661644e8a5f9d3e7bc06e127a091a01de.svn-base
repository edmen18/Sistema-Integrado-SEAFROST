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
        string idpr = Convert.ToString(Request.QueryString["IDPROC"]);
        string depr = Convert.ToString(Request.QueryString["DEPRO"]);

        idoc = idoc.Trim();
        idpr = idpr.Trim();
        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        exportOpts.ExportFormatOptions = pdfOpts;
        OT_CO0003MOVC TABL = new OT_CO0003MOVC();

            TABL.OC_CNUMORD = idoc;
            TABL.OC_CCODPRO = idpr;

        ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("OTInforme.rpt"));
            report.SetDataSource(OT_CO0003MOVC.OCreporteOT(TABL));
        report.ExportToHttpResponse(exportOpts, Response, false, idoc + " " + depr);
        CrystalReportViewer1.ReportSource = report;

    }

    
}