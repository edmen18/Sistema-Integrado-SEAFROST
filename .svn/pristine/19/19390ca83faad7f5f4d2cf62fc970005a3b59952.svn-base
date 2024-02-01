using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using System.Web.SessionState;
using System.Web.Script.Services;
using ClosedXML.Excel;
using CapaNegocio;
using CapaEntidades;

public partial class Bitacora : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {
            hfusu.Value = Session["codusu"].ToString();

            ddlcodigo.DataSource = Personal.listaCodigos().Select(x => x.codigo.Substring(0, 1)).Distinct();
            ddlcodigo.DataBind();

               gvdetallel();

            ddltipos.Items.Clear();
            ddltipos.DataTextField = "placa";
            ddltipos.DataValueField = "cod";
            ddltipos.DataSource = tabla_transporte_vehiculo.ListaVehiculo();
            ddltipos.DataBind();
            ddltipos.Items.Insert(0, new ListItem("[VEHICULO]", "-1"));

            ddlprocedencia.Items.Clear();
            ddlprocedencia.DataTextField = "procedencia";
            ddlprocedencia.DataValueField = "cod";
            ddlprocedencia.DataSource = tabla_transporte_procedencia.ListaProcedencia();
            ddlprocedencia.DataBind();
            ddlprocedencia.Items.Insert(0, new ListItem("[PROCEDENCIA]", "-1"));

            ddlchofer.Items.Clear();
            ddlchofer.DataTextField = "detalle";
            ddlchofer.DataValueField = "CodPer";
            ddlchofer.DataSource = PersonalEmpresa.ListaPersonaPorCosto("00045");
            ddlchofer.DataBind();
            ddlchofer.Items.Insert(0, new ListItem("[CHOFERES]", "-1"));

            ddlvigilante.Items.Clear();
            ddlvigilante.DataTextField = "detalle";
            ddlvigilante.DataValueField = "CodPer";
            ddlvigilante.DataSource = PersonalEmpresa.ListaPersonaPorCosto("00047");
            ddlvigilante.DataBind();
            ddlvigilante.Items.Insert(0, new ListItem("[VIGILANTES]", "-1"));

            ddlturno.Items.Clear();
            ddlturno.DataTextField = "turno";
            ddlturno.DataValueField = "cod";
            ddlturno.DataSource = tabla_transporte_turno.ListaTurno();
            ddlturno.DataBind();
            ddlturno.Items.Insert(0, new ListItem("[TURNO]", "-1"));

            //ddlcodigo.Items.Insert(0, new ListItem("A", "A"));
            //ddlcodigo.Items.Insert(1, new ListItem("C", "C"));
            //ddlcodigo.Items.Insert(1, new ListItem("S", "S"));
            //ddlcodigo.Items.Insert(1, new ListItem("X", "X"));

            ddlparadero.Items.Clear();
            ddlparadero.DataTextField = "paradero";
            ddlparadero.DataValueField = "cod";
            ddlparadero.DataSource = tabla_transporte_paradero.ListaParadero();
            ddlparadero.DataBind();
            ddlparadero.Items.Insert(0, new ListItem("[PARADERO]", "-1"));
        }
    }
    public void gvdetallel()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SA_ID");
        dtGetDatae.Columns.Add("SA_DESC");
        dtGetDatae.Columns.Add("PARADERO");
        dtGetDatae.Rows.Add();
        gvdetalle.DataSource = dtGetDatae;
        gvdetalle.DataBind();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static Personal obtenTrabajador(string codigo)
    {
        return Personal.obtenTrabajador(codigo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static PersonalEmpresa obtenTrabajadordetalle(string codigo)
    {
        return Personal.obtenTrabajadorDetalle(codigo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaBitacoraCab(tabla_transporte_cabViaje cabViaje)
    {
       tabla_transporte_cabViaje.InsertaBitacoraCab(cabViaje);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaBitacoraDet(tabla_transporte_detViaje DET)
    {
        tabla_transporte_detViaje.InsertaBitacoraDet(DET);
    }



    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void eliminaBitacoraDet(string numero)
    {
        tabla_transporte_detViaje.eliminaBitacoraDet(numero);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string obtenNumeroBitacora()
    {
        return tabla_transporte_cabViaje.obtenNumeroBitacora();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string ListarCostos(string costo)
    {
        return Ccosto.ListarCostos(costo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string ListarLabores(string costo)
    {
        return PersonalLabores.ListarLabores(costo);
    }

   





}