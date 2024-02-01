using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ORDENCOMPRA_REPORTES_RptAnticiposFecha : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string fechini = Convert.ToString(Request.QueryString["FecIni"]);
            string fechfin = Convert.ToString(Request.QueryString["FecFin"]);
            tabla_anticipo TABL = new tabla_anticipo();

            TABL.OC_FECEMI = Convert.ToDateTime(fechini);
            TABL.OC_FECPRO= Convert.ToDateTime(fechfin);

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_AnticiposFecha.rpt"));
            report.SetDataSource(tabla_anticipo.SAreportes(TABL));
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }
    }
}