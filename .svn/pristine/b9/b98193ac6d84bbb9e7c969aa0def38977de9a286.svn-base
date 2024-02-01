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
        //string isuser = Convert.ToString(Request.QueryString["US"]);
        
        //
        //if (isuser != "" && isuser != null)
        //{
        //    Session["codusu"] = isuser;
        //}
        //if (!IsPostBack) { 

            string idoc = Convert.ToString(Request.QueryString["ID"]);
            

            //string depr = Convert.ToString(Request.QueryString["DEPRO"]);
            string numagen = Convert.ToString(Request.QueryString["IDAG"]);

            idoc = idoc.Trim();
            //idpr = idpr.Trim();
            CO0003MOVC TABL = new CO0003MOVC();

            CO0003MOVC FDS = new CO0003MOVC();
            FDS.OC_CNUMORD = idoc;
            var idpr = CO0003MOVC.VerCabeceraID(FDS).OC_CCODPRO;
            var depr = CO0003MOVC.VerCabeceraID(FDS).OC_CRAZSOC;
            depr = depr.Replace(",", ""); 
            //var numagen = CO0003MOVC.VerCabeceraID(FDS).OC_CCODTAL;

            TABL.OC_CNUMORD = idoc;
            TABL.OC_CCODPRO = idpr;
            TABL.OC_CCODTAL = numagen;

            //ExportOptions exportOpts = new ExportOptions();
            // PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            // exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            // exportOpts.ExportFormatOptions = pdfOpts;

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Informe.rpt"));
            report.SetDataSource(CO0003MOVC.OCreporte(TABL));
            //report.ExportToHttpResponse(exportOpts, Response, false, idoc + " " + idpr);
            //report.ExportToHttpResponse(ExportFormatType.PortableDocFormat, Response, true, idoc + " " + depr);
            //CrystalReportViewer1.ReportSource = report;


            System.IO.Stream oStream = null;
            byte[] byteArray = null;
            oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.AddHeader("Content-Disposition", "filename=" + idoc + "_" + depr + ".pdf");
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.Flush();
            Response.Close();
            report.Close();
            report.Dispose();
            
        }

        
        
    //}


}