using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ORDENCOMPRA_REPORTES_RptAnticipoNum : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {

            try
            {
                string idoc = Convert.ToString(Request.QueryString["ID"]);
                tabla_anticipo TABL = new tabla_anticipo();

                TABL.OC_CNUMORD = idoc.Trim();

                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_AnticiposOrden.rpt"));
                report.SetDataSource(tabla_anticipo.SAreportes(TABL));
                CrystalReportViewer1.ReportSource = report;
            }
            catch
            {
                throw;
            }
        }
    }
}