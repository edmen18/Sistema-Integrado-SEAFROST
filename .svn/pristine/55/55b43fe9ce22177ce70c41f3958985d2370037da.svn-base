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
public partial class Porcentaje : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            ListaEmbarcacion();

           LISTAR();
        }
        lblusuario.Text = Convert.ToString(Session["codusu"]);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_porcentaje DETA)
    {
        tabla_porcentaje.Actualizar(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertar(tabla_porcentaje DETA)
    {
        tabla_porcentaje.insertar(DETA);
    }
   public void ListaEmbarcacion()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("PORC_CODIGO");
        dtGetDatae.Columns.Add("PORC_MONTO");
        dtGetDatae.Columns.Add("PORC_ESTADO");
        dtGetDatae.Columns.Add("PORC_FECHA");
        dtGetDatae.Columns.Add("PORC_USU");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    public void LISTAR()
    {
        gvordencompra.DataSource = tabla_porcentaje.ListarPorcentajes();
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }
   
}