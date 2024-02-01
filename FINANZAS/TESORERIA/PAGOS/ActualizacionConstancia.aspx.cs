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


public partial class FINANZAS_TESORERIA_PAGOS_ActualizacionConstancia : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           VERGRILLAPRINCIPAL();
            txtfechapago.Text= DateTime.Now.ToString("dd/MM/yyyy");
        }
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
    public static List<vista_detalle_programacion> LISTARUNO(string CODATA)
    {
        return CP0003EJEC.LISTARUNOCONST(CODATA);
    }

    public void VERGRILLAPRINCIPAL()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("GD_CVANEXO");
        dtGetDatae.Columns.Add("GD_CCODIGO");
        dtGetDatae.Columns.Add("ACREEDOR");
        dtGetDatae.Columns.Add("GD_CTIPDOC");
        dtGetDatae.Columns.Add("GD_CNUMDOC");
        dtGetDatae.Columns.Add("GD_CSUBDIA");
        dtGetDatae.Columns.Add("GD_CCOMPRO");
        dtGetDatae.Columns.Add("CONSTANCIA");
        dtGetDatae.Columns.Add("GD_NMNPROG");
        dtGetDatae.Columns.Add("GD_CTASDET");

        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string autocomplete()
    {
        return CP0003EJEC.autocomplete();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003EJED> LISTARTTODOS(string dato)
    {
        return CP0003EJED.LISTARTTODOSCONST(dato);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003MAES NOMBRE(CP0003MAES dato)
    {
        return CP0003MAES.listarMaestroxunID(dato);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void UpdateConstanciaEjec(CP0003EJEC DETA)
    {
        CP0003EJEC.ActualizaConstancia(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void UpdateConstanciaEjed(CP0003EJED DETA)
    {
        CP0003EJED.ActualizaConstancia(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CART obtenerDOC(CP0003CART DETA)
    {
        return CP0003CART.obtenerDOC(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaConstancia(CT0003COMD16 COM)
    {
        CT0003COMD16.ActualizaConstancia(COM);
    }

}