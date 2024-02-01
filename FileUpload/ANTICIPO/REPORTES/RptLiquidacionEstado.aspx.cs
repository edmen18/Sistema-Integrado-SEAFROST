using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ORDENCOMPRA_REPORTES_RptLiquidacionEstado : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string est = Convert.ToString(Request.QueryString["ESTADO"]);
            tabla_anticipo TABL = new tabla_anticipo();

            TABL.ESTADO = est.Trim();

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_LiquidacionEstado.rpt"));
            report.SetDataSource(TABLA_LIQUIDACION_ANTICIPO.ReporteLa(TABL));
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }
    }
}