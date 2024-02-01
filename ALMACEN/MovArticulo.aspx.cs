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

public partial class Default2 : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            ListMovimientos();
         
            //llenar el combo moneda
            AL0003ALMA TABL = new AL0003ALMA();
            ddlalmacen.Items.Clear();
            ddlalmacen.DataTextField = "A1_CDESCRI";
            ddlalmacen.DataValueField = "A1_CALMA";
            ddlalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalmacen.DataBind();
            ddlalmacen.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));
        }
    }

    public void ListMovimientos()

    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("C6_DFECDOC");
        dtGetDatae.Columns.Add("C6_CTD");
        dtGetDatae.Columns.Add("C6_CNUMDOC");
        dtGetDatae.Columns.Add("C6_CCODMOV");
        dtGetDatae.Columns.Add("TDR");
        dtGetDatae.Columns.Add("PROVEEDOR");
        dtGetDatae.Columns.Add("REFERENCIA");
        dtGetDatae.Columns.Add("SERIE");
        dtGetDatae.Columns.Add("CANSAL");
        dtGetDatae.Columns.Add("CANTENT");
        dtGetDatae.Columns.Add("C6_CCODMON");
        dtGetDatae.Columns.Add("C6_NMNPRUN");
        dtGetDatae.Columns.Add("TOTAL");
        dtGetDatae.Columns.Add("CCOSTO");
        dtGetDatae.Columns.Add("SOLICITANTE");
        dtGetDatae.Columns.Add("LOTE");
        dtGetDatae.Rows.Add();
        gvmovimientos.DataSource = dtGetDatae;
        gvmovimientos.DataBind();
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003TABM> ListarMovimientos(AL0003TABM VC)

    //{
    //    return AL0003TABM.ListarMovimientos(VC);

    //}
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003TABM> ListarMovimientosTodos(AL0003TABM VC)

    //{
    //    return AL0003TABM.ListarMovimientosTodos(VC);

    //}
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<CT0003ANEX> GetProveedores(string productos)
    //{
    //    return CT0003ANEX.ListarProveedores(productos);
    //}

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> GetArticulos(string productos)
    {
        return AL0003ARTI.ListarArticulo(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_movart> Movimientos(vista_movart LDE)
    {
        return AL0003ARTI.MovArticulos(LDE);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_movart> gettotales(vista_movart LDE)
    {
        return AL0003ARTI.MovArticulosent(LDE);
    }
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003ALMA> GetAlmacen(string productos)
    //{
    //    return AL0003ALMA.ListarAlmacenAc(productos);
    //}
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003ARTI> getrangoarticulos(string cod1, string cod2)
    //{
    //    return AL0003ARTI.ListarArticulosParaStockValorizado(cod1, cod2);
    //}
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003ALMA> getrangoalmacen(string cod1, string cod2)
    //{
    //    return AL0003ALMA.ListarAlmacenParaStockValorizado(cod1, cod2);
    //}
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<CT0003ANEX> getrangoproveedor(string cod1, string cod2)
    //{
    //    return CT0003ANEX.ListarProveedorParaStockValorizado(cod1, cod2);
    //}
}