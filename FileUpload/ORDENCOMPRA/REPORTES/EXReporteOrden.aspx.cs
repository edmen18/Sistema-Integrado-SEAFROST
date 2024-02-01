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
        CO0003MOVC TABL = new CO0003MOVC();

            TABL.OC_CNUMORD = idoc;
            TABL.OC_CCODPRO = idpr;

        ReportDocument report = new ReportDocument();
        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        exportOpts.ExportFormatOptions = pdfOpts;

        report.Load(Server.MapPath("EXInforme.rpt"));
        report.SetDataSource(CO0003MOVC.OCreporte(TABL));

        report.ExportToHttpResponse(exportOpts, Response, false, idoc + " " + idpr);
        CrystalReportViewer1.ReportSource = report;
        
        //ReportDocument crReportDocument = new ReportDocument();
        //ExportOptions crExportOptions = new ExportOptions();
        //DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
        //String Fname = "";

        //crReportDocument.Load(Server.MapPath("Informe.rpt"));
        //crReportDocument.SetDataSource(CO0003MOVC.OCreporte(TABL));
        //Fname = "D:\\TuArchivo.pdf" + ".pdf";
        //crDiskFileDestinationOptions.DiskFileName = Fname;
        //crExportOptions = crReportDocument.ExportOptions;

        //crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
        //crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
        //crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;

        //crReportDocument.Export();




    }

    
}