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

public partial class FINANZAS_TESORERIA_PAGOS_ConsultaDetraccionesPorPagar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            VERGRILLAPRINCIPAL();
            inicio();
        }
    }
    public void inicio()
    {
        CP0003CART PROGRAMACION = new CP0003CART();
        tabla_parametros parametros = new tabla_parametros();
        parametros.AF_COD = "AD";
        PROGRAMACION.CP_CCUENTA = tabla_parametros.ListarParametro(parametros).Select(X=>X.AF_CCLAVE).FirstOrDefault();

       gvordencompra.DataSource = CP0003CART.ConsultaDetraccionesPorPagar(PROGRAMACION);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }


    public void VERGRILLAPRINCIPAL()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CCODIGO");
        dtGetDatae.Columns.Add("CP_CDESCRI");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NSALDUS");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("CP_CTASDET");
        dtGetDatae.Columns.Add("CP_CNDOCCO");
        dtGetDatae.Columns.Add("CP_CTIPO");

        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> ConsultaDetracciones(CP0003CART adata)
    {
        return CP0003CART.ConsultaDetracciones(adata);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> ConsultaReferencia(CP0003CART adata)
    {
        return CP0003CART.ConsultaReferencia(adata);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> LISTARdetracciones(string productos)
    {
        return CT0003TAGE.LISTARdetracciones(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    protected void btnfiltro_Click(object sender, EventArgs e)
    {
      
        CP0003CART PROGRAMACION = new CP0003CART();
        PROGRAMACION.CP_CCODIGO = txtruc.Text;
        
        gvordencompra.DataSource = CP0003CART.ConsultaDetraccionesPorPagarF(PROGRAMACION);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
         }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }
}