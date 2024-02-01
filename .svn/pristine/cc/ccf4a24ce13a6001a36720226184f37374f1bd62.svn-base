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
            Txtfinicial.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtffinal.Text = DateTime.Now.ToString("dd/MM/yyyy");

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
        }
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
    public static List<AL0003TABM> ListarMovimientos(AL0003TABM VC)

    {
        return AL0003TABM.ListarMovimientos(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> ListarMovimientosTodos(AL0003TABM VC)

    {
        return AL0003TABM.ListarMovimientosTodos(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> GetArticulos(string productos)
    {
        return AL0003ARTI.ListarArticulo(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getrangoarticulos(string cod1, string cod2)
    {
        return AL0003ARTI.ListarArticulosParaStockValorizado(cod1, cod2);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ALMA> getrangoalmacen(string cod1, string cod2)
    {
        return AL0003ALMA.ListarAlmacenParaStockValorizado(cod1, cod2);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> getrangoproveedor(string cod1, string cod2)
    {
        return CT0003ANEX.ListarProveedorParaStockValorizado(cod1, cod2);
    }
}