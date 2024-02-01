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

public partial class ALMACEN_REPORTES_ESVArticuloSC : System.Web.UI.Page
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
            string articulo1 = Convert.ToString(Request.QueryString["articulo1"]);
            string articulo2 = Convert.ToString(Request.QueryString["articulo2"]);
            string indicador = Convert.ToString(Request.QueryString["ind"]);
            
           

            vista_esvarticulo TABL = new vista_esvarticulo();
            List<AL0003ARTI> detalle = new List<AL0003ARTI>();
            detalle = AL0003ARTI.ListarArticulosParaStockValorizado(articulo1, articulo2);
            TABL.AR_CCODIGO = "NINGUNO";
            foreach (AL0003ARTI B in detalle)
            {
                TABL.AR_CCODIGO = TABL.AR_CCODIGO + "," + B.AR_CCODIGO;
            }
            TABL.C6_DFECDOC = Convert.ToDateTime(fechini);
            TABL.C6_FECHA2 = Convert.ToDateTime(fechfin);
            TABL.A1_CALMA = almacen;
            TABL.C6_CCODMON = moneda;
            TABL.CADENA = (Request["cadena"]);
            TABL.MOVIMIENTO= (Request["movimiento"]);
            // ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript(TABL.CADENA.Replace("'\'", " ")), false);


            ReportDocument report = new ReportDocument();
            report.Load(Server.MapPath("Cr_ESV_ARTICULOSC.rpt"));
            if (indicador=="N")
            {
                report.SetDataSource(AL0003ALMA.RptESVARTALM(TABL));
            }
          
            CrystalReportViewer1.ReportSource = report;
        }
        catch
        {
            throw;
        }
    }
}