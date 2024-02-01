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

public partial class ContabilizaDOC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            hdUSUARIO.Value = Session["codusu"].ToString();

            //lblFechaE.Text = (Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());//VALIDAR

            CP0003TAGE TAGE = new CP0003TAGE();
            TAGE.TG_INDICE = "90";

            ddlDEP.Items.Clear();
            ddlDEP.DataTextField = "TG_DESCRI";
            ddlDEP.DataValueField = "TG_CODIGO";
            ddlDEP.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlDEP.DataBind();
            ddlDEP.Items.Insert(0, new ListItem("[TODOS]", "XX"));

            /*CP0003CART DATA = new CP0003CART();
            DATA.CP_CSITUAC = "R";//REGISTRADA
            DATA.CP_CAREA = "";
            DATA.CP_CTDOCRE = "";
            DATA.CP_CCENCOR = (txtCCID.Text == "" ? "" : txtCCID.Text);//CONGELADO
            gvDOC.DataSource = CP0003CART.listar(DATA);
            gvDOC.DataBind();*/

            //TIPO ACREEDOR
            TAGE.TG_INDICE = "10";

            ddlACR.Items.Clear();
            ddlACR.DataTextField = "TG_DESCRI";
            ddlACR.DataValueField = "TG_CODIGO";
            ddlACR.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlACR.DataBind();
            ddlACR.SelectedValue = "P";

            //TIPO DOCUMENTO REFERENCIA
            TAGE.TG_INDICE = "25";

            ddlDRE.Items.Clear();
            ddlDRE.DataTextField = "TG_DESCRI";
            ddlDRE.DataValueField = "TG_CODIGO";
            ddlDRE.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlDRE.DataBind();
            ddlDRE.SelectedValue = "OC";
            ddlDRE.Attributes.Add("disabled", "disabled");

            //DOCUMENTO 
            TAGE.TG_INDICE = "13";

            ddlTDOC.Items.Clear();
            ddlTDOC.DataTextField = "TG_DESCRI";
            ddlTDOC.DataValueField = "TG_CODIGO";
            ddlTDOC.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlTDOC.DataBind();
            ddlTDOC.SelectedValue = "FT";

            //MONEDA
            TAGE.TG_INDICE = "16";

            ddlMON.Items.Clear();
            ddlMON.DataTextField = "TG_DESCRI";
            ddlMON.DataValueField = "TG_CODIGO";
            ddlMON.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlMON.DataBind();
            ddlMON.Items.Insert(0, new ListItem("[MONEDA]", "XX"));

            //DEPARTAMENTO
            TAGE.TG_INDICE = "90";

            ddlDEPA.Items.Clear();
            ddlDEPA.DataTextField = "TG_DESCRI";
            ddlDEPA.DataValueField = "TG_CODIGO";
            ddlDEPA.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlDEPA.DataBind();

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTCON.Items.Clear();
            ddlTCON.DataTextField = "TG_CDESCRI";
            ddlTCON.DataValueField = "TG_CCLAVE";
            ddlTCON.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlTCON.DataBind();
            ddlTCON.Items.Insert(0, new ListItem("[Conversion]", "-1"));

            ListaPEOC();
            ListaFinal();
        }
    }

    public void grid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("CP_CVANEXO");
        dtGetData.Columns.Add("CP_CCODIGO");
        dtGetData.Columns.Add("NOMTIT");
        dtGetData.Columns.Add("CP_CTIPDOC");
        dtGetData.Columns.Add("CP_CNUMDOC");
        dtGetData.Columns.Add("CP_CCODMON");
        dtGetData.Columns.Add("CP_CTDOCRE");
        dtGetData.Columns.Add("IMPORTE");
        dtGetData.Columns.Add("CP_CNDOCRE");
        dtGetData.Columns.Add("CP_DFDOCRE");
        dtGetData.Columns.Add("CENCOR");
        dtGetData.Columns.Add("NOMARE");
        dtGetData.Columns.Add("CP_CSITUAC");
        dtGetData.Columns.Add("");
        dtGetData.Rows.Add();
        gvDOC.DataSource = dtGetData;
        gvDOC.DataBind();
    }

    public void ListaPEOC()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C6_CITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");        
        dtGetData.Columns.Add("UM");
        dtGetData.Columns.Add("C6_NCANTID");
        dtGetData.Columns.Add("C6_NPREUN1");
        dtGetData.Columns.Add("IMPORTE");
        dtGetData.Columns.Add("MON");
        dtGetData.Rows.Add();
        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }
    public void ListaFinal()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("DSECUE");
        dtGetData.Columns.Add("DCUENTA");
        dtGetData.Columns.Add("DDETALLE");
        dtGetData.Columns.Add("DCODANE");
        dtGetData.Columns.Add("DCENCOS");
        dtGetData.Columns.Add("DDH");
        dtGetData.Columns.Add("DIMPORT");
        dtGetData.Columns.Add("DTIPDOC");
        dtGetData.Columns.Add("DNUMDOC");
        dtGetData.Columns.Add("DFECDOC2");
        dtGetData.Columns.Add("DFECVEN2");
        //dtGetData.Columns.Add("DAREA");        
        dtGetData.Rows.Add();
        gvDCOM.DataSource = dtGetData;
        gvDCOM.DataBind();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vistas_finanzas> listar(CP0003CART DATA)
    {
        return CP0003CART.listar(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> listarTG(CT0003TAGE DATA)
    {
        return CT0003TAGE.ListarTG(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CO0003MOVC mioc(CO0003MOVC DATA)
    {
        return CO0003MOVC.VerCabeceraID(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD DATA)
    {
        return CO0003MOVD.verListaOrden(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> ListarTGL(CT0003TAGE DATA)
    {
        return CT0003TAGE.ListarTGL(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> ListarTGLA(CT0003TAGE DATA, string[] PAR)
    {
        return CT0003TAGE.ListarTGLA(DATA, PAR);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> listaPOC(AL0003MOVC DATA)
    {
        //LISTA PE-OC
        return AL0003MOVC.listaCabeceraIX(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<FT0003CTAE> cuenta_asiento(string[] CUENTA)
    {
        return FT0003CTAE.cuenta_asiento(CUENTA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> getDPES(AL0003MOVC DATA, string[] ND)
    {
        return AL0003MOVC.listaCabeceraDX(DATA, ND);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> getDPES1(AL0003MOVC DATA, string[] ND)
    {   //LISTA PE-OC
        return AL0003MOVC.listaCabeceraDX1(DATA, ND);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> listaCCE(AL0003MOVC DATA, string[] ND)
    {
        return AL0003MOVC.listaCCE(DATA, ND);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static AL0003ARTI listaAID(string CADENA)
    {
        //LISTA ARTICULO CUENTA SERVICIO
        return AL0003ARTI.ListarArticulosID(CADENA).FirstOrDefault();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static tabla_parametros ListarParametroID(tabla_parametros DATA)
    {
        return tabla_parametros.ListarParametroID3(DATA);
        //return tabla_parametros.ListarParametroID(COD,KEY);
    }
    protected void txtCCDE_TextChanged(object sender, EventArgs e)
    {
        CP0003CART DATA = new CP0003CART();
        DATA.CP_CSITUAC = "R";//REGISTRADA
        DATA.CP_CAREA = "";
        DATA.CP_CTDOCRE = "";

        if (txtCCID.Text == "XX")
        {
            DATA.CP_CCENCOR = "";
            txtCCDE.Text = "TODOS";
        }
        else
        {
            DATA.CP_CCENCOR = txtCCID.Text;
        }
        //DATA.CP_CCENCOR = txtCCID.Text;

        if (CP0003CART.listar(DATA).Count > 0)
        {
            gvDOC.DataSource = CP0003CART.listar(DATA);
            gvDOC.DataBind();
        }
        else
        {
            grid();
        }


    }

    protected void ddlDEP_SelectedIndexChanged(object sender, EventArgs e)
    {
        CP0003CART DATA = new CP0003CART();
        DATA.CP_CSITUAC = "R";//REGISTRADA
        DATA.CP_CAREA = (ddlDEP.SelectedValue == "XX" ? "" : ddlDEP.SelectedValue);
        DATA.CP_CTDOCRE = "";
        //DATA.CP_CCENCOR = txtCCID.Text;
        if (txtCCID.Text == "XX")
        {
            DATA.CP_CCENCOR = "";
            txtCCDE.Text = "TODOS";
        }
        else
        {
            DATA.CP_CCENCOR = txtCCID.Text;
        }

        if (CP0003CART.listar(DATA).Count > 0)
        {
            gvDOC.DataSource = CP0003CART.listar(DATA);
            gvDOC.DataBind();
        }
        else
        {
            grid();
        }
    }

    protected void txtCCID_TextChanged(object sender, EventArgs e)
    {
        txtCCID.Text= txtCCID.Text.ToUpper();
        CT0003TAGE GDATA = new CT0003TAGE();
        GDATA.TCOD = "05";
        GDATA.TCLAVE = txtCCID.Text;

        txtCCDE.Text = Convert.ToString(CT0003TAGE.ListarTG(GDATA).Select(c => c.TDESCRI).FirstOrDefault());

        CP0003CART DATA = new CP0003CART();
        DATA.CP_CSITUAC = "R";//REGISTRADA
        DATA.CP_CAREA = (ddlDEP.SelectedValue == "XX" ? "" : ddlDEP.SelectedValue);
        DATA.CP_CTDOCRE = "";

        if (txtCCID.Text == "XX")
        {
            DATA.CP_CCENCOR = "";
            txtCCDE.Text = "TODOS";
        }
        else
        {
            DATA.CP_CCENCOR = txtCCID.Text;
        }

        if (CP0003CART.listar(DATA).Count > 0)
        {
            gvDOC.DataSource = CP0003CART.listar(DATA);
            gvDOC.DataBind();
        }
        else
        {
            grid();
        }

    }

}

