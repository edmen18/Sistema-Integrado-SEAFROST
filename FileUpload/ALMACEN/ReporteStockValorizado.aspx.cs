using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;
public partial class Default2 : System.Web.UI.Page
{ 
    protected void Page_Load(object sender, EventArgs e)
    {
        //llenar el combo moneda
        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;
        ddlmoneda.Items.Clear();
        ddlmoneda.DataTextField = "TG_CDESCRI";
        ddlmoneda.DataValueField = "TG_CCLAVE";
        ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlmoneda.DataBind();
        ddlmoneda.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

        //LLENAR ALMACEN
        AL0003ALMA TAB = new AL0003ALMA();
        ddlalmacen.Items.Clear();
        ddlalmacen.DataTextField = "A1_CDESCRI";
        ddlalmacen.DataValueField = "A1_CALMA";
        ddlalmacen.DataSource = AL0003ALMA.ListarALMACENES(TAB);
        ddlalmacen.DataBind();
        ddlalmacen.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> gatarticulos(string productos)
    {
        return AL0003ARTI.ListarArticulo(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE,string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE,INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getrangoarticulos(string cod1, string cod2)
    {
        return AL0003ARTI.ListarArticulosParaStockValorizado(cod1, cod2);
    }

   
}