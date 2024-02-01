﻿using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CALIDAD_CrystalReports_RepCartasIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string idoc = Convert.ToString(Request.QueryString["ID"]);
            string fecha = Convert.ToString(Request.QueryString["fecha"]);
            VISTA_CARTASIS TABL = new VISTA_CARTASIS();

            TABL.NUM_CARTA = idoc.Trim();
            TABL.FECHA = Convert.ToDateTime(fecha.Trim());

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