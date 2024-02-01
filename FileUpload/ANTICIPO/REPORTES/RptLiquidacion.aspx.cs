using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ORDENCOMPRA_REPORTES_RptLiquidacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            TABLA_LIQUIDACION_ANTICIPO TABL = new TABLA_LIQUIDACION_ANTICIPO();

            TABL.LIQ_NUMERO = idoc.Trim();

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_Liquidacion.rpt"));
            report.SetDataSource(TABLA_LIQUIDACION_ANTICIPO.LiqImpresion(TABL));
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }
    }
}