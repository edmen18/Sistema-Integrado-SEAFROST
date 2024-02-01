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
public partial class ALMACEN_REPORTES_stocvalorizado_SVALMACEN : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            //string idoc = Convert.ToString(Request.QueryString["ID"]);
            string almacen = Convert.ToString(Request.QueryString["ALMACEN"]);
            string articulo1 = Convert.ToString(Request.QueryString["articulo1"]);
            string articulo2 = Convert.ToString(Request.QueryString["articulo2"]);
            string periodo = Convert.ToString(Request.QueryString["PERIODO"]);
            string moneda = Convert.ToString(Request.QueryString["MONEDA"]);
            string codigo = Convert.ToString(Request.QueryString["CODIGO"]);
            string indicador=Request.QueryString["indicador"];
            vista_stockvalorizado TABL = new vista_stockvalorizado();
                   
            //REPORTES UNO POR ITEM       
            if (indicador=="PA")
            {

                List<AL0003ARTI> detalle = new List<AL0003ARTI>();
                detalle = AL0003ARTI.ListarArticulosParaStockValorizado(articulo1, articulo2);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003ARTI B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.AR_CCODIGO;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Articulo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL,"A"));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TGF")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2,codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Grupo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL,codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TFF")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Familia.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TMAF")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Marca.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }

            if (indicador == "TMOF")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Modelo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TCF")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CALMA = Convert.ToString(almacen);
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_Cuenta.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
         }
        catch
        {
            throw;
        }
    }
}