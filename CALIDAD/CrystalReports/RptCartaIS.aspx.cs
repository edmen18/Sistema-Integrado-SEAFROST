using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CALIDAD_CrystalReports_RptCartaIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            DateTime fecha = Convert.ToDateTime(Request.QueryString["fecha"]);
            T_CALIDAD_CARTA_IS TABL = new T_CALIDAD_CARTA_IS();

            TABL.NUM_CARTA = idoc.Trim();
            TABL.FECHA = fecha;

            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_Carta01.rpt"));
            report.SetDataSource(T_CALIDAD_CARTA_IS.getdatos(TABL));
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }

    }
}