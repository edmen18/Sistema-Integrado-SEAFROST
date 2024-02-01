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
        //string idpr = Convert.ToString(Request.QueryString["IDPROC"]);
        //string depr = Convert.ToString(Request.QueryString["DEPRO"]);
        string numagen = Convert.ToString(Request.QueryString["IDAG"]);  
        idoc = idoc.Trim();
        CO0003MOVC TABL = new CO0003MOVC();
        CO0003MOVC FDS = new CO0003MOVC();
        FDS.OC_CNUMORD = idoc;
        var idpr = CO0003MOVC.VerCabeceraID(FDS).OC_CCODPRO;
        var depr = CO0003MOVC.VerCabeceraID(FDS).OC_CRAZSOC;
        var contnpedanex = tabla_ordenped.ListaPedos(idoc)[0].IDPEDIDO == null ?0:1;
        depr = depr.Replace(",", "");
        TABL.OC_CNUMORD = idoc;
        TABL.OC_CCODPRO = idpr;
        TABL.OC_CCODTAL = numagen;
        TABL.OC_CDIAENT = Convert.ToString(contnpedanex);

        ReportDocument report = new ReportDocument();
        
        ExportOptions exportOpts = new ExportOptions();
        PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
        exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
        exportOpts.ExportFormatOptions = pdfOpts;

        report.Load(Server.MapPath("EXInforme.rpt"));
        report.SetDataSource(CO0003MOVC.OCreporte(TABL));

        ReportDocument subreport = report.Subreports[0];
        subreport.SetDataSource(tabla_ordenped.ListaPedos(idoc));

        ReportDocument subreportfac = report.Subreports[1];
        subreportfac.SetDataSource(tabla_d_ordfac.ListaxOrden(idoc));


        System.IO.Stream oStream = null;
        byte[] byteArray = null;
        oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
        

        byteArray = new byte[oStream.Length];
        oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
        Response.ClearContent();
        Response.ClearHeaders();
        //Response.Clear();
        //Response.Buffer = true;
        Response.AddHeader("Content-Disposition", "filename=" + idoc + "_" + depr + ".pdf");
        //Response.AddHeader("Content-Disposition", "attachment;filename=GUIA.pdf");
        Response.ContentType = "application/pdf";
        Response.BinaryWrite(byteArray);
        Response.Flush();
        Response.Close();
        report.Close();
        report.Dispose();






    }

    
}