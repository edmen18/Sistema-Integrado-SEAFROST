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

public partial class ModificacionCabecera : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            //txtNumeroDoc.Text = AL0003MOVC.codMaximo("0012", "PE").ToString();

            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"] == null ? "0001" : Session["aID"].ToString());


            //AL0003TABM TABL = new AL0003TABM();
            ddlesM.Items.Clear();
            //ddlesM.DataTextField = "TM_CTIPMOV";
            //ddlesM.DataValueField = "TM_CTIPMOV";
            //ddlesM.DataSource = AL0003TABM.ListaTipo();
            //ddlesM.DataBind();
            ddlesM.Items.Insert(0, new ListItem("E - ENTRADA", "E"));
            ddlesM.Items.Insert(1, new ListItem("S - SALIDA", "S"));

            ddlTipoMov.Items.Clear();
            //ddlTipoMov.DataTextField = "TM_CTIPMOV";
            //ddlTipoMov.DataValueField = "TM_CTIPMOV";
            //ddlTipoMov.DataSource = AL0003TABM.ListaTipo();
            ddlTipoMov.Items.Insert(0, new ListItem("PE - Parte de Entrada", "PE"));
            //ddlTipoMov.DataBind();
            //LoadCombo("E");
            //ListaDetalle();

            ddlMalmacen.Items.Clear();
            ddlMalmacen.DataTextField = "A1_CDESCRI";
            ddlMalmacen.DataValueField = "A1_CALMA";
            ddlMalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlMalmacen.DataBind();



        }
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003MOVC> getNRODOCUMENTO(string ND, string ES, string TD, string AL)
    {
        return AL0003MOVC.listaNRODOCUMENTO(ND, ES, TD, AL);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> getLISTAMOVID(string datos, string tipo)
    {
        return AL0003TABM.ListarMovimientosID(datos, tipo);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> getLISTATD(string dato, string codigo)
    {
        return AL0003TABL.ListarTablaID(codigo, dato);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaCabecera(AL0003MOVC DATA)
    {
        AL0003MOVC.actualizaCabeceraEntrada(DATA);
    }

}

