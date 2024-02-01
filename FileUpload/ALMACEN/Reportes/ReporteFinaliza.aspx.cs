using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
/* using System.Data.DataSetExtensions;*/

public partial class ALMACEN_Reportes_ReporteFinaliza : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idAL = Convert.ToString(Request.QueryString["AL"]);
        string idTD = Convert.ToString(Request.QueryString["TD"]);
        string idND = Convert.ToString(Request.QueryString["ND"]);

        idAL = idAL.Trim();
        idTD = idTD.Trim();
        idND = idND.Trim();

        AL0003MOVC TABL = new AL0003MOVC();

        TABL.C5_CALMA = idAL;
        TABL.C5_CTD = idTD;
        TABL.C5_CNUMDOC = idND;

        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        exportOpts.ExportFormatOptions = pdfOpts;
        
        ReportDocument report = new ReportDocument();
        report.Load(Server.MapPath("crReporteFinal.rpt"));
        report.SetDataSource(AL0003MOVC.listaFinal(TABL));
        report.ExportToHttpResponse(exportOpts, Response, false, idAL + " " + idTD +" "+idND);
        CrystalReportViewer1.ReportSource = report;
        
    }
}