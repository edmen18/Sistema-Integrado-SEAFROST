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

public partial class MANTENIMIENTO_Reportes_TC_IMP_AVANCE : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            tabla_trabajo TABL = new tabla_trabajo();

            TABL.TR_CODIGO = idoc.Trim();

            ReportDocument report = new ReportDocument();
            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.ExportFormatOptions = pdfOpts;

            report.Load(Server.MapPath("Cr_Imtrabajo.rpt"));
            report.SetDataSource(tabla_trabajo.Impresion2(TABL));

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