using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ALMACEN_REPORTES_ESVProveedorSC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        try
        {
            //string idoc = Convert.ToString(Request.QueryString["ID"]);
            string fechini = Convert.ToString(Request.QueryString["FecIni"]);
            string fechfin = Convert.ToString(Request.QueryString["FecFin"]);
            string almacen = Convert.ToString(Request.QueryString["almacen"]);
            string moneda = Convert.ToString(Request.QueryString["moneda"]);
            string proveedor1 = Convert.ToString(Request.QueryString["proveedor1"]);
            string proveedor2 = Convert.ToString(Request.QueryString["proveedor2"]);
            string indicador = Convert.ToString(Request.QueryString["ind"]);
           
           vista_esvarticulo TABL = new vista_esvarticulo();
            List<CT0003ANEX> detalle = new List<CT0003ANEX>();
            detalle = CT0003ANEX.ListarProveedorParaStockValorizado(proveedor1,proveedor2);
           TABL.ACODANE = "NINGUNO";
            foreach (CT0003ANEX B in detalle)
            {
                TABL.ACODANE = TABL.ACODANE + "," + B.ACODANE;
            }
            
            TABL.C6_DFECDOC = Convert.ToDateTime(fechini);
            TABL.C6_FECHA2 = Convert.ToDateTime(fechfin);
            TABL.A1_CALMA = almacen;
            TABL.C6_CCODMON = moneda;
           
            TABL.CADENA = (Request["cadena"]);
            TABL.MOVIMIENTO = (Request["movimiento"]);
            // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript(TABL.CADENA.Replace("'\'", " ")), false);
            
            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_ESV_PROVEEDORSC.rpt"));
            if (indicador == "N")
            {
                report.SetDataSource(AL0003ALMA.RptESVPROALM(TABL));
            }
           
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }
    }
}