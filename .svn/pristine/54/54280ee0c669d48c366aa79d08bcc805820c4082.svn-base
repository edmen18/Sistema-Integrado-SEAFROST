using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;
using ClosedXML.Excel;
using System.IO;
using System.Drawing;

public partial class FINANZAS_TESORERIA_PAGOS_PagoDetraIndividual : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       

        if (!this.IsPostBack)
        {
            VERGRILLA();
            VERGRILLA1();
            inicio();
            CT0003TAGE area = new CT0003TAGE();
            area.TCOD="28";
            ddldetraccion.Items.Clear();
            ddldetraccion.DataTextField = "TDESCRI";
            ddldetraccion.DataValueField = "TCLAVE";
            ddldetraccion.DataSource = CT0003TAGE.LISTARVARIOSED(area);
            ddldetraccion.DataBind();
            ddldetraccion.Items.Insert(0, new ListItem("[DETRACCIONES]", "-1"));

        }
    }
    public void inicio()
    {
        gvordencompra.DataSource = CP0003CART.DetraccionIndividual();
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> listarautocomplete(CP0003MAES VC)
    {
        return CP0003MAES.listarMaestroxDescripcion(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003PAGO> PAGOS(CP0003CART VC)
    {
        return CP0003CART.ConsultaPagos(VC);

    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> ConsultaReferencia(CP0003CART adata)
    {
        return CP0003CART.ConsultaReferencia(adata);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART>ConsultaDetracciones(CP0003CART adata)
    {
        return CP0003CART.ConsultaDetracciones(adata);
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CCODIGO");
        dtGetDatae.Columns.Add("CP_CSITUAC");
        dtGetDatae.Columns.Add("CP_CCODIRF");
        dtGetDatae.Columns.Add("CP_CDESCRI");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("CP_CTASDET");
        dtGetDatae.Columns.Add("CP_DFECVEN");
        dtGetDatae.Columns.Add("CP_CTIPDOC");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_CAREA");
       
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    public void VERGRILLA1()
    {

        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("PG_DFECCOM");
        dtGetDatae.Columns.Add("PG_CCODMON");
        dtGetDatae.Columns.Add("PG_CDEBHAB");
        dtGetDatae.Columns.Add("PG_NIMPOMN");
        dtGetDatae.Columns.Add("PG_NIMPOUS");
        dtGetDatae.Columns.Add("PG_CSUBDIA");
        dtGetDatae.Columns.Add("PG_CNUMCOM");
        dtGetDatae.Columns.Add("PG_CGLOSA");

        dtGetDatae.Rows.Add();
        gvordencompra0.DataSource = dtGetDatae;
        gvordencompra0.DataBind();
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }


    protected void btnfiltro_Click(object sender, EventArgs e)
    {
        CP0003CART cart = new CP0003CART();
        cart.CP_CCODIGO = this.txtcodigo.Text;
        cart.CP_CTASDET = this.ddldetraccion.Text;
        
        gvordencompra.DataSource = CP0003CART.DetraccionIndividualfiltro(cart);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}