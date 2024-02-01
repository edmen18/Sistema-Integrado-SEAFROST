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

public partial class ValorizacionMM : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            //txtalcanceDia.Text = auxFecha;
            //txtNumeroDoc.Text = AL0003MOVC.codMaximo("0012", "PE").ToString();
            string miu = Session["codusu"].ToString();
            hdUSUARIO.Value = Session["codusu"].ToString();
            txtalcanceDia.Text = (Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());
            codAL.Value = (Session["aID"] == null ? "0012" : Session["aID"].ToString());//"0001"
            ddlMalmacen.Items.Clear();
            ddlMalmacen.DataTextField = "A1_CDESCRI";
            ddlMalmacen.DataValueField = "A1_CALMA";
            ddlMalmacen.DataSource = (miu == "SIST" ? AL0003ALMA.ListarAlmacen() : AL0003ALMA.ListarAlmacenIDS());
            //AL0003ALMA.ListarAlmacen();//ACTUALIZACION MM-AL0003ALMA.ListarAlmacen();
            ddlMalmacen.DataBind();
            ddlMalmacen.SelectedValue = (Session["aID"] != null ? Session["aID"].ToString() : "0001");

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlMN.Items.Clear();
            ddlMN.DataTextField = "TG_CDESCRI";
            ddlMN.DataValueField = "TG_CCLAVE";
            ddlMN.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlMN.DataBind();
            ddlMN.Items.Insert(0, new ListItem("[Moneda]", "-1"));

            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTICO.Items.Clear();
            ddlTICO.DataTextField = "TG_CDESCRI";
            ddlTICO.DataValueField = "TG_CCLAVE";
            ddlTICO.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlTICO.DataBind();
            ddlTICO.Items.Insert(0, new ListItem("[Conversion]", "-1"));

            visualizarGrid();
            visualizarGridDetalle();
            visualizarDetalle2();
        }
    }

    public void visualizarGrid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C5_CTD");
        dtGetData.Columns.Add("C5_CNUMDOC");
        dtGetData.Columns.Add("C5_CNUMORD");
        dtGetData.Columns.Add("C5_CCODMON");
        dtGetData.Columns.Add("C5_CCODMOV");
        dtGetData.Columns.Add("C5_DFECDOC");
        dtGetData.Columns.Add("C5_CSITUA");
        dtGetData.Columns.Add("C5_CGLOSA1");//C5_CUSUCRE
        dtGetData.Columns.Add("C5_CUSUCRE");
        dtGetData.Columns.Add("C5_CCODAUT");
        dtGetData.Columns.Add("Accion");
        dtGetData.Rows.Add();
        gvVMM.DataSource = dtGetData;
        gvVMM.DataBind();
    }
    public void visualizarGridDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C6_CITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("C6_CSERIE");//UNID
        dtGetData.Columns.Add("AR_CUNIDAD");
        dtGetData.Columns.Add("C6_NCANTID");
        //dtGetData.Columns.Add("C6_NIGV");
        //dtGetData.Columns.Add("C6_TIGV");
        dtGetData.Columns.Add("C6_NPREUN1");
        //dtGetData.Columns.Add("C6_NDESCTO1");
        //dtGetData.Columns.Add("C6_NDESCTO2");
        //dtGetData.Columns.Add("C6_NDESCTO3");
        //dtGetData.Columns.Add("C6_NDESCTO4");
        dtGetData.Columns.Add("C6_NVALTOT");
        dtGetData.Rows.Add();
        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }

    public void visualizarDetalle2()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C6_CITEM");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("AR_CUNIDAD");
        dtGetData.Columns.Add("C6_NCANTID");
        dtGetData.Rows.Add();
        gvDetalleA.DataSource = dtGetData;
        gvDetalleA.DataBind();
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<SCabecera> listaFinal(AL0003MOVC CDATA)
    {
        return AL0003MOVC.listaCabecera(CDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003MOVD> detalle(AL0003MOVD DATA) { 
          return AL0003MOVD.detalleC(DATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean aprobar(AL0003MOVC DATA)
    {
        return AL0003MOVC.aprobarpe(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void valorizaCabecera(AL0003MOVC VDATA)
    {
        AL0003MOVC.valorizaCabecera(VDATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void valorizaDetalle(AL0003MOVD VDETA)
    {
        AL0003MOVD.valorizaDetalle(VDETA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CO0003MOVC Getcabecerae(CO0003MOVC INFO)
    {
        return CO0003MOVC.VerCabeceraID(INFO);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static string ListarParametroID(string COD, string KEY)
    public static tabla_parametros ListarParametroID(string COD, string KEY)
    {
        return tabla_parametros.ListarParametroID2(COD, KEY);
        //return tabla_parametros.ListarParametroID(COD,KEY);
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void enviofinalemail(string[] DATA, string[] DATA_A)
    {
        var MICADENA = "";//DATA_A[5]OC DATA_A[6]ND
        List<string> fiche = new List<string>();
        string informa = "<html><body>";
        informa += "<div style='border:1px solid #ccc;padding:5px;font-family: Verdana, Helvetica, sans-serif'>";
        informa += "<p style='background-color:#006699;color:white;margin:0;padding:5px;'>Se ha generado una modificación en el parte de entrada " + DATA_A[6] + "</p>";
        informa += "<table cellspacing=0 cellpadding=3 rules=all style=border-color:#CCCCCC;border-width:1px;border-style:None;border-collapse:collapse;>";
        informa += "<tr ><td align='left' style='background - color:#006699;font-weight:bold;'>O/C:</td><td>" + DATA_A[5] +"</td></tr>";
        informa += "<tr ><td align='left' style='background - color:#006699;font-weight:bold;'>Proveedor Original:</td><td>" + DATA_A[0]+" "+DATA_A[1] + "</td></tr>";
        informa += "<tr ><td align='left' style='background - color:#006699;font-weight:bold;'>Proveedor Actualizado:</td><td>" + DATA_A[2]+" "+DATA_A[3] + "</td></tr>";
        informa += "<tr ><td style='background - color:#006699;font-weight:bold;'>Usuario/Creación:</td><td>-</td></tr>";
        informa += "<tr ><td style='background - color:#006699;font-weight:bold;'>Usuario/Modificación:</td><td>" + DATA_A[4] + "</td></tr>";
        informa += "</table></div>";
        informa += "</body></html>";

        List<UT0030> euxa = new List<UT0030>();
        euxa =  UT0030.cuentas(DATA);
        foreach (var d in euxa)
        {
            MICADENA += d.TU_CORREO;//+ ";";//HttpUtility.HtmlEncode(
            Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "Actualizacion de Orden Compra", MICADENA, "", "programador2@seafrost.com.pe", fiche);
        }
        
        //Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "Actualizacion de Orden Compra", "programador2@seafrost.com.pe", "", "programador1@seafrost.com.pe", fiche);
    }

}

