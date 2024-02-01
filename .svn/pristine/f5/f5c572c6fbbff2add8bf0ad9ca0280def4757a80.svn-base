using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ORDENCOMPRA_REPORTES_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        enviapdf();


    }

    public   void enviapdf ()
    {


        string idoc = Convert.ToString(Request.QueryString["ID"]);
        //string idpr = Convert.ToString(Request.QueryString["IDPROC"]);
        //string depr = Convert.ToString(Request.QueryString["DEPRO"]);
        string numagen = Convert.ToString(Request.QueryString["IDAG"]);

        string creportn = string.Empty;
        creportn = "OTInforme.rpt";

        idoc = idoc.Trim();
        //idpr = idpr.Trim();
        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        //exportOpts.ExportFormatOptions = pdfOpts; 
        OT_CO0003MOVC TABL = new OT_CO0003MOVC();

        CO0003MOVC FDS = new CO0003MOVC();
        FDS.OC_CNUMORD = idoc;
        var idpr = CO0003MOVC.VerCabeceraID(FDS).OC_CCODPRO;
        var depr = CO0003MOVC.VerCabeceraID(FDS).OC_CRAZSOC;
        depr = depr.Replace(",", "");
        TABL.OC_CNUMORD = idoc;
        TABL.OC_CCODPRO = idpr;
        TABL.OC_CCODTAL = numagen;

        ReportDocument report = new ReportDocument();
        report.Load(Server.MapPath("OTInforme.rpt"));
        report.SetDataSource(OT_CO0003MOVC.OCreporteOT(TABL));
        //report.ExportToHttpResponse(exportOpts, Response, false, idoc + " " + idpr);
        //report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, false, idoc + " " + depr);
        //Stream s = report.ExportToStream(ExportFormatType.PortableDocFormat);
        // CrystalReportViewer1.ReportSource = report;
        
     
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



        //System.IO.MemoryStream rutalocal = (System.IO.MemoryStream)s;
        //Response.Clear();
        //Response.Buffer = true;
        //Response.ContentType = "application/pdf";
        //Response.AddHeader("Content-Disposition", "attachment;filename=GUIA.pdf");
        //Response.Charset = "UTF-8";

        //Response.BinaryWrite(rutalocal.ToArray());
        //Response.End();


    }
}