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

public partial class ALMACEN_REPORTES_stocvalorizado_SVDETALLADO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //
        try
        {

            string articulo1 = Convert.ToString(Request.QueryString["articulo1"]);
            string articulo2 = Convert.ToString(Request.QueryString["articulo2"]);
            string periodo = Convert.ToString(Request.QueryString["PERIODO"]);
            string moneda = Convert.ToString(Request.QueryString["MONEDA"]);
            string indicador = Request.QueryString["indicador"];
            string codigo = Convert.ToString(Request.QueryString["CODIGO"]);
            vista_stockvalorizado TABL = new vista_stockvalorizado();

            //REPORTES UNO POR ITEM       
            if (indicador == "TAD")
            {
                List<AL0003ARTI> detalle = new List<AL0003ARTI>();
                detalle = AL0003ARTI.ListarArticulosParaStockValorizado(articulo1, articulo2);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003ARTI B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.AR_CCODIGO;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetArticulo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL,"A"));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TGD")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetGrupo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TFD")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetFamilia.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TMAD")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetMarca.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }

            if (indicador == "TMOD")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetModelo.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
            if (indicador == "TCD")
            {
                List<AL0003TABL> detalle = new List<AL0003TABL>();
                detalle = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
                TABL.TG_CCLAVE = "NINGUNO";
                foreach (AL0003TABL B in detalle)
                {
                    TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
                }
                TABL.SA_CMESPRO = periodo;
                TABL.AR_CMONVTA = moneda;
                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_DetCuenta.rpt"));
                report.SetDataSource(AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo));
                CrystalReportViewer1.ReportSource = report;
            }
           
        }
        catch
        {
            throw;
        }
    }
}