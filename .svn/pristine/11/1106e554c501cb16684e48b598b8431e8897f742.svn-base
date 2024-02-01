using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetalle();
        ListaDetalleCompra();
        txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy"); 

        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = "31";
        TABL.TG_CDESCRI = string.Empty;

        ddlestad.Items.Clear();
        ddlestad.DataTextField = "TG_CDESCRI";
        ddlestad.DataValueField = "TG_CCLAVE";
        ddlestad.DataSource = AL0003TABL.ListarTabla(TABL);
        ddlestad.DataBind();
        ddlestad.Items.Insert(0, new ListItem("[ESTADO]", "-1"));

        
        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipo.Items.Clear();
        ddltipo.DataTextField = "TG_CDESCRI";
        ddltipo.DataValueField = "TG_CCLAVE";
        ddltipo.DataSource = AL0003TABL.ListarTabla(TABL);
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("[ESTADO]", "-1"));

        
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;

        ddlmone.Items.Clear();
        ddlmone.DataTextField = "TG_CDESCRI";
        ddlmone.DataValueField = "TG_CCLAVE";
        ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlmone.DataBind();
        ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));


        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipoc.Items.Clear();
        ddltipoc.DataTextField = "TG_CDESCRI";
        ddltipoc.DataValueField = "TG_CCLAVE";
        ddltipoc.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddltipoc.DataBind();
        ddltipoc.Items.Insert(0, new ListItem("[TIPO]", ""));

        TABL.TG_CCOD = "04";
        TABL.TG_CDESCRI = string.Empty;

        ddldocre.Items.Clear();
        ddldocre.DataTextField = "TG_CDESCRI";
        ddldocre.DataValueField = "TG_CCLAVE";
        ddldocre.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddldocre.DataBind();
        ddldocre.Items.Insert(0, new ListItem("[REFERENCIA]", ""));

        ddlsuboc.Items.Clear();
        ddlsuboc.DataTextField = "Descripcion";
        ddlsuboc.DataValueField = "IDTipo";
        ddlsuboc.DataSource = tabla_subtipoOC.ListarSTipoOC();
        ddlsuboc.DataBind();
        ddlsuboc.Items.Insert(0, new ListItem("[SUBTIPO]", "-1"));
    }


    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_CCODMON");
        dtGetDatae.Columns.Add("OC_NIMPMN");
        dtGetDatae.Columns.Add("OC_CSITORD");
        dtGetDatae.Columns.Add("OC_CTIPORD");
        dtGetDatae.Columns.Add("OC_CCOTIZA");
        
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public void ListaDetalleCompra()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CITEM");
        dtGetDatae.Columns.Add("OC_CCODIGO");
        dtGetDatae.Columns.Add("OC_CCODREF");
        dtGetDatae.Columns.Add("OC_CUNIDAD");
        dtGetDatae.Columns.Add("OC_NCANORD");
        dtGetDatae.Columns.Add("OC_NPREUN2");
        dtGetDatae.Columns.Add("OC_NDSCPAD");
        dtGetDatae.Columns.Add("OC_NDSCPIT");
        dtGetDatae.Columns.Add("OC_NIGVPOR");
        dtGetDatae.Columns.Add("OC_NISCPOR");
        dtGetDatae.Columns.Add("OC_NPREUNI");
        dtGetDatae.Columns.Add("OC_NDESCTO");
        dtGetDatae.Columns.Add("OC_NIGV");
        dtGetDatae.Columns.Add("OC_NCANTEN");
        dtGetDatae.Columns.Add("OC_NCANSAL");
        dtGetDatae.Columns.Add("OC_DFECENT");
        dtGetDatae.Columns.Add("OC_COMENTA");
        dtGetDatae.Columns.Add("OC_NISC");
        dtGetDatae.Columns.Add("SUBTOTAL");

        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcera> ListarCabOC(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraoc(VC);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string cod,string productos)
    {
        return CT0003ANEX.listarAnexo(cod,productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void anularoc(CO0003MOVC COANULA)
    {
        CO0003MOVC.AnulaOC(COANULA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD LDE)
    {
        return CO0003MOVD.verListaOrden(LDE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaDetalleOC(CO0003MOVD ELIM)
    {
        CO0003MOVD.EliminaItemsDetalleOC(ELIM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static int  validanaprobOC(string ADATA)
    {
        return CO0003MOVC.Naprobacionesorden(ADATA);
    }
    

    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover","this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }

}