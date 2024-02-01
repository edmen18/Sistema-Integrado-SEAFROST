using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;//agrega
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
//using CapaNegocio;
using ENTITY;
using System.Configuration;
public partial class Maestro : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            ListaEmbarcacion();

            LISTAR();
        }
        lblusuario.Text = Convert.ToString(Session["codusu"]);
    }

    public void ListaEmbarcacion()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("AF_COD");
        dtGetDatae.Columns.Add("AF_CCLAVE");
        dtGetDatae.Columns.Add("AF_TDESCRI1");
        dtGetDatae.Columns.Add("AF_TDESCRI2");
        dtGetDatae.Columns.Add("AF_TDESCRI3");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> LISTARDATOSPARAM(tabla_parametros com)
    {
        return tabla_parametros.ListarEmbarcacionParametros(com);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> LISTARDETALLE(tabla_parametros com)
    {
        return tabla_parametros.ListarDetalles(com);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> LISTARDATOS()
    {
        return tabla_parametros.ListarEmbarcacionestodos();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> LISTARDATOSAUTOCOMPLETE(string com)
    {
        return tabla_parametros.ListarEmbarcacionAut(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_parametros DETA)
    {
        tabla_parametros.actualizaBahia(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertar(tabla_parametros DETA)
    {
        tabla_parametros.insertaBahia(DETA);
        LISTARDATOS();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertardet(tabla_parametros DETA)
    {
        tabla_parametros.insertaBahia(DETA);
        LISTARDETALLE(DETA);
    }
    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static int generar (tabla_parametros DETA)
    //{
    //  return tabla_parametros.generarClave(DETA);
    //}
    public void LISTAR()
    {
        gvordencompra.DataSource = tabla_parametros.ListarEmbarcacionestodos();
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void btbuscar_Click(object sender, EventArgs e)
    {
        tabla_parametros var = new tabla_parametros();
        var.AF_COD = this.txtidbahia.Text.Split('-').First();
        var.AF_CCLAVE= this.txtidbahia.Text.Split('-').Last();
        gvordencompra.DataSource = tabla_parametros.ListarEmbarcacionParametros(var);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        this.txtbahia.Text = "";
        this.txtidbahia.Text = "";

    }

}

