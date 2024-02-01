using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;



public partial class ORDENCOMPRA_REPORTES_ReportesAnticipo : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            tabla_anticipo TABL = new tabla_anticipo();

            TABL.ANT_CODIGO = idoc.Trim();

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_ReporteAnticipo.rpt"));
            report.SetDataSource(tabla_anticipo.SAreporte(TABL));
            CrystalReportViewer1.ReportSource = report;
            }
        catch
        {
            throw;
        }
    }
}