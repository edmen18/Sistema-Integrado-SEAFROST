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
        ListMovimientos();
        //AL0003TABL TABL = new AL0003TABL();
        //TABL.TG_CCOD = "03";
        //TABL.TG_CDESCRI = string.Empty;
        //ddlmoneda.Items.Clear();
        //ddlmoneda.DataTextField = "TG_CDESCRI";
        //ddlmoneda.DataValueField = "TG_CCLAVE";
        //ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TABL);
        //ddlmoneda.DataBind();
        //ddlmoneda.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

    }
    public void ListMovimientos()

    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("TM_CTIPMOV");
        dtGetDatae.Columns.Add("TM_CCODMOV");
        dtGetDatae.Columns.Add("TM_CDESCRI");
        dtGetDatae.Rows.Add();
        gvmovimientos.DataSource = dtGetDatae;
        gvmovimientos.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<FT0003LINE> GETLINEAS(string CLAVE)
    {
        return AL0003TABL.ListarLineas(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> getrangoccosto(string cod1, string cod2)
    {
        return AL0003TABL.ListarCentrosCosto(cod1, cod2);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> getrangovarios(string cod1, string cod2, string c3)
    {
        return AL0003TABL.ListarvALORESParaStockValorizado(cod1, cod2, c3);
    }
}