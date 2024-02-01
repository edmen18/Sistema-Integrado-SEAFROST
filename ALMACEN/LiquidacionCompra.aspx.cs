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
            CP0003TAGE IPV = new CP0003TAGE();
            IPV.TG_INDICE = "C6";

            //CP0003TAGE.C_ListarTablaG(IPV);
            //var fechaA = DateTime.Now;
            //USUARIO
            lblUSER.Text = Session["codusu"].ToString();
            hdUSUARIO.Value = Session["codusu"].ToString();
            string miu = Session["codusu"].ToString();
            txtFEC.Text = (Session["FechaE"] == null ? "" : Session["FechaE"].ToString());

            //AGENCIA
            ddlAGE.Items.Clear();
            ddlAGE.DataTextField = "AG_CNOMAGE";
            ddlAGE.DataValueField = "AG_CCODAGE";
            ddlAGE.DataSource = CT0003AGEN.ListarAgencia();
            ddlAGE.DataBind();

            //ALMACEN
            ddlALM.Items.Clear();
            ddlALM.DataTextField = "A1_CDESCRI";
            ddlALM.DataValueField = "A1_CALMA";
            ddlALM.DataSource = (miu == "SIST" ? AL0003ALMA.ListarAlmacen() : AL0003ALMA.ListarAlmacenIDS()); //AL0003ALMA.ListarAlmacen();
            ddlALM.DataBind();
            ddlALM.SelectedValue = "A002";
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

            //TIPO ANEXO
            CP0003TAGE TAGE = new CP0003TAGE();
            IPV.TG_CODIGO = "QTIPANE";
            TAGE.TG_INDICE = "10";
            TAGE.TG_CODIGO = CP0003TAGE.ListarTGID(IPV).TG_DESCRI.ToString().Substring(0, 1);//"P";

            ddlTIA.Items.Clear();
            ddlTIA.DataTextField = "TG_DESCRI";
            ddlTIA.DataValueField = "TG_CODIGO";
            ddlTIA.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlTIA.DataBind();

            FT0003TCAJ TACJ = new FT0003TCAJ();
            TACJ.TC_CCOD = "20";
            TACJ.TC_CCLAVE = Session["codusu"].ToString();

            lblNCAJ.Text = Convert.ToString(FT0003TCAJ.ListarTablaID(TACJ).Select(c => c.TC_CDESCRI).FirstOrDefault());

            /*CT0003TAGE TABG = new CT0003TAGE();
            TABG.TCOD = "02";
            TABG.TCLAVE = "15";//SUBDIARIO

            ddlSDIA.Items.Clear();
            ddlSDIA.DataTextField = "TDESCRI";
            ddlSDIA.DataValueField = "TCLAVE";
            ddlSDIA.DataSource = CT0003TAGE.ListarTG(TABG);
            ddlSDIA.DataBind();*/

            FT0003NUME FDATA = new FT0003NUME();
            FDATA.TN_CCODIGO = "LQ";
            FDATA.TN_CNUMSER = "0001";

            ddlSER.Items.Clear();
            ddlSER.DataTextField = "TN_CNUMSER";
            ddlSER.DataValueField = "TN_CNUMSER";
            ddlSER.DataSource = FT0003NUME.ListarNumeracion(FDATA);
            ddlSER.DataBind();

            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTICO.Items.Clear();
            ddlTICO.DataTextField = "TG_CDESCRI";
            ddlTICO.DataValueField = "TG_CCLAVE";
            ddlTICO.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlTICO.DataBind();
            ddlTICO.Items.Insert(0, new ListItem("[Conversion]", "-1"));

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

        dtGetData.Rows.Add("", "", "",String.Format("{0:0.00}",0), String.Format("{0:0.00}", 0),String.Format("{0:0.00}",0));//Add();

        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }
    
    public void parametrosvarios()
    {
        //CP0003TAGE.C_ListarTablaG(TABP);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CART obtenerDOC(CP0003CART DATA)
    {
        //VERIFICA DOCUMENTO EXISTE-N/EXISTE
        return CP0003CART.obtenerDOC(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> getPEPF(AL0003MOVC PDATA)
    {
        return AL0003MOVC.listaCabeceraI(PDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> getDPES(AL0003MOVC DATA,string[] ND)
    {
        return AL0003MOVC.listaCabeceraD(DATA,ND);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003TAGE> configuracion(CP0003TAGE TABP)
    {
        return CP0003TAGE.C_ListarTablaG(TABP);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListaPlanC(CT0003PLEM PDATA)
    {
        return CT0003PLEM.ListaPlanID(PDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<V_CUENTA_COMPRA> ListaCC(V_CUENTA_COMPRA DATA)
    {
        return CP0003CAGE.ListarCC(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> listaMaestro(CP0003MAES DATA)
    {
        return CP0003MAES.listarMaestro(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> listaMaestroID(CP0003MAES DATA)
    {
        return CP0003MAES.listarMaestroID(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> listarAnexo(CT0003ANEX DATA)
    {
        return CT0003ANEX.listarAnexoT(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> listaTAGE(CT0003TAGE TABG)
    {
        return CT0003TAGE.ListarTG(TABG);
        //CT0003TAGE TABG = new CT0003TAGE();
        //TABG.TCOD = "02";
        //TABG.TCLAVE = "15";//SUBDIARIO

        //ddlSDIA.Items.Clear();
        //ddlSDIA.DataTextField = "TDESCRI";
        //ddlSDIA.DataValueField = "TCLAVE";
        //ddlSDIA.DataSource = CT0003TAGE.ListarTG(TABG);
        //ddlSDIA.DataBind();
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);
        //public static string correlativoCP(AL0003FACC DATA)
        //return AL0003FACC.correlativoCP(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static String correlativoID(FT0003NUME NDATA)
    {
        return FT0003NUME.obtenerNumeracion(NDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static String correlativoPG(CP0003PAGO DATA)
    {
        return CP0003PAGO.correlativoPG(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aNumeracion(CT0003NUME16 CDATA)
    {
        //INSERTA-ACTUALIZA LIQUIDACION REGISTRO PAGO-SISPAG
        CT0003NUME16.Numeracion(CDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<FT0003NUME> ListarNumeracion(FT0003NUME FDATA)
    {   //Lista numeracion serie LQ
        return FT0003NUME.ListarNumeracion(FDATA);
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
    public static void actualizaVCAB(AL0003MOVC VDATA)
    {
        //ACTUALIZA CABECERA PRINCIPAL
        AL0003MOVC.valorizaCabeceraG(VDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaVDET(AL0003MOVD VDETA, string[] ND)
    {   //ACTUALIZA DETALLE PRINCIPAL
        AL0003MOVD.valorizaDetalleG(VDETA, ND);
        //AL0003MOVD.valorizaDetalle(LDDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarPLQ(CP0003PAGO PLQDATA)
    {
        //INSERTA LIQUIDACION REGISTRO PAGO
        CP0003PAGO.insertaCabecera(PLQDATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarCART(CP0003CART CDATA)
    {
        CP0003CART.insertar(CDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarACAB(CT0003COMC16 ACDATA)
    {
        CT0003COMC16.insertaCabecera(ACDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarADET(CT0003COMD16 ADDATA)
    {
        CT0003COMD16.insertaDetalle(ADDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Actualizanum(FT0003NUME datos)
    {
        FT0003NUME.actualizaNumer(datos);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaBAL(CT0003BALH16 BDATA)
    {
        CT0003BALH16.actualizar(BDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CT0003CTL316 listarBC(CT0003CTL316 DATA)
    {
        return CT0003CTL316.listar(DATA);
    }
}

