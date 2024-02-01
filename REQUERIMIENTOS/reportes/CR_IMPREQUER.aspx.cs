using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class REQUERIMIENTOS_reportes_CR_IMPREQUER : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            AL0003REQC TABL = new AL0003REQC();

            TABL.RC_CNROREQ = idoc.Trim();

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_ImRequerimiento.rpt"));
            report.SetDataSource(AL0003REQC.ImpresionReq(TABL));
            
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