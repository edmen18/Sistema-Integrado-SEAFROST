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

public partial class LiquidacionCompra : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            //var fechaA = DateTime.Now;
            //USUARIO
            lblUSER.Text = Session["codusu"].ToString();
            hdUSUARIO.Value = Session["codusu"].ToString();
            txtFEC.Text = (Session["FechaE"] == null ? "" : Session["FechaE"].ToString()); ;


            //AGENCIA
            ddlAGE.Items.Clear();
            ddlAGE.DataTextField = "AG_CNOMAGE";
            ddlAGE.DataValueField = "AG_CCODAGE";
            ddlAGE.DataSource = CT0003AGEN.ListarAgencia();
            ddlAGE.DataBind();
            //ddlAGE.Items.Insert(0, new ListItem("[Moneda]", "-1"));

            //ALMACEN
            //AL0003ALMA TAAL = new AL0003ALMA();
            //TAAL.A1_CALMA = "0012";

            ddlALM.Items.Clear();
            ddlALM.DataTextField = "A1_CDESCRI";
            ddlALM.DataValueField = "A1_CALMA";
            ddlALM.DataSource = AL0003ALMA.ListarAlmacen();
            ddlALM.DataBind();
            ddlALM.Text = (Session["aID"] == null ? "" : Session["aID"].ToString());
            //MONEDA
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlMON.Items.Clear();
            ddlMON.DataTextField = "TG_CDESCRI";
            ddlMON.DataValueField = "TG_CCLAVE";
            ddlMON.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlMON.DataBind();
            ddlMON.Items.Insert(0, new ListItem("[Moneda]", "-1"));

            //TABL.TG_CCOD = "16";
            //TABL.TG_CDESCRI = string.Empty;

            ddlTIA.Items.Clear();
            ddlTIA.DataTextField = "TG_CDESCRI";
            ddlTIA.DataValueField = "TG_CCLAVE";
            ddlTIA.DataSource = AL0003TABL.ListarTablaID("16", "P");
            ddlTIA.DataBind();

            FT0003TCAJ TACJ = new FT0003TCAJ();
            TACJ.TC_CCOD = "20";
            TACJ.TC_CCLAVE = Session["codusu"].ToString();

            lblNCAJ.Text = Convert.ToString(FT0003TCAJ.ListarTablaID(TACJ).Select(c => c.TC_CDESCRI).FirstOrDefault());

            CT0003TAGE TABG = new CT0003TAGE();
            TABG.TCOD = "02";
            TABG.TCLAVE = "15";

            ddlSDIA.Items.Clear();
            ddlSDIA.DataTextField = "TDESCRI";
            ddlSDIA.DataValueField = "TCLAVE";
            ddlSDIA.DataSource = CT0003TAGE.ListarTG(TABG);
            ddlSDIA.DataBind();

            FT0003NUME FDATA = new FT0003NUME();
            FDATA.TN_CCODIGO = "LQ";
            FDATA.TN_CNUMSER = "0001";

            ddlSER.Items.Clear();
            ddlSER.DataTextField = "TN_CNUMSER";
            ddlSER.DataValueField = "TN_CNUMSER";
            ddlSER.DataSource = FT0003NUME.ListarNumeracion(FDATA);
            ddlSER.DataBind();

            gridDetalle();
        }
    }

    public void gridDetalle()
    {

        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("CODIGO");
        dtGetData.Columns.Add("DESCRIPCION");
        dtGetData.Columns.Add("UM");
        dtGetData.Columns.Add("CANTIDAD");
        dtGetData.Columns.Add("PRECIO");
        dtGetData.Columns.Add("VALORVENTA");
        //dtGetData.Columns.Add("A_ACCIONES");
        dtGetData.Rows.Add();
        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> getPEPF(AL0003MOVC PDATA)
    {
        return AL0003MOVC.listaCabeceraI(PDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(AL0003FACC DATA)
    {
        return AL0003FACC.correlativoCP(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarCLQ(AL0003FACC LCDATA)
    {
        AL0003FACC.insertaCabecera(LCDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarDLQ(AL0003FACD LDDATA)
    {
        AL0003FACD.insertaDetalle(LDDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaVCAB(AL0003MOVC LCDATA)
    {
        //ACTUALIZA CABECERA PRINCIPAL
        AL0003MOVC.valorizaCabecera(LCDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaVDET(AL0003MOVD LDDATA)
    {   //ACTUALIZA DETALLE PRINCIPAL
        AL0003MOVD.valorizaDetalle(LDDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static String correlativoID(FT0003NUME NDATA)
    {
        return FT0003NUME.obtenerNumeracion(NDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarPLQ(CP0003PAGO LPDATA)
    {
        //INSERTA LIQUIDACION REGISTRO PAGO
        CP0003PAGO.insertaCabecera(LPDATA);
    }

}

