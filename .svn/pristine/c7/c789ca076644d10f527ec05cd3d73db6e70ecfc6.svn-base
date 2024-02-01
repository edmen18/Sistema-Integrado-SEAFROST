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

public partial class FINANZAS_TESORERIA_CHEQUES_ImprimeCheque : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string NUMERO = Convert.ToString(Request.QueryString["CHEQUE"]);
            string SUBDIARIO = Convert.ToString(Request.QueryString["SUBDIARIO"]);
            string COMPROBANTE = Convert.ToString(Request.QueryString["COMPROBANTE"]);
            CP0003CHEQ TABL = new CP0003CHEQ();

            TABL.CH_CNUMCHE = NUMERO.Trim();
            TABL.CH_CSUBDIA = SUBDIARIO.Trim();
            TABL.CH_CNUMCOM = COMPROBANTE.Trim();

            ReportDocument report = new ReportDocument();
            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.ExportFormatOptions = pdfOpts;

            report.Load(Server.MapPath("CHEQUE.rpt"));
            report.SetDataSource(CP0003CHEQ.IMPRESIONCHEQUE(TABL));

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

