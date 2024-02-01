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

public partial class RegistroEntradaOC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha=DateTime.Now.ToString("dd/MM/yyyy");
            //txtNumeroDoc.Text = AL0003MOVC.codMaximo("0012", "PE").ToString();
            lblEntrada.Text = "E";
            lbltipoRegistro.Text = "E";
            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"]==null?"0001":Session["aID"].ToString());
            lblFechaE.Text = (Session["FechaE"]==null?auxFecha:Session["FechaE"].ToString());//VALIDAR
            //lblFechaDocD.Text = lblFechaE.Text;//(Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());//DETALLE
            lblAlmacen.Text = (Session["daID"]==null?"ALMACEN DE INSUMOS":Session["daID"].ToString());
            
            AL0003TABL TABL = new AL0003TABL();
            //TABL.TG_CCOD = "03";
            //TABL.TG_CDESCRI = string.Empty;

            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTipoConversion.Items.Clear();
            ddlTipoConversion.DataTextField = "TG_CDESCRI";
            ddlTipoConversion.DataValueField = "TG_CCLAVE";
            ddlTipoConversion.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlTipoConversion.DataBind();
            ddlTipoConversion.Items.Insert(0, new ListItem("[Conversion]", "-1"));

            ListaDetalle();
            ListaDIngresoCantidad();

        }
    }
    public void ListaDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("OC_ITEM");
        dtGetData.Columns.Add("OC_CCODIGO");
        dtGetData.Columns.Add("OC_CDESREF");
        dtGetData.Columns.Add("OC_CUNIDAD");
        dtGetData.Columns.Add("OC_NCANORD");
        dtGetData.Columns.Add("OC_NCANTEN");
        dtGetData.Columns.Add("OC_NCANSAL");
        dtGetData.Rows.Add();
        gvDREOC.DataSource = dtGetData;
        gvDREOC.DataBind();
    }

    public void ListaDIngresoCantidad()
    {
        //DEBE REGISTRARSE EN AL0003SERI
        DataTable dtGetDataIC = new DataTable();
        dtGetDataIC.Columns.Add("OC_ITEM");
        dtGetDataIC.Columns.Add("OC_NCANTEN");
        dtGetDataIC.Columns.Add("SR_DFECVEN");
        dtGetDataIC.Rows.Add();
        gvDIC.DataSource = dtGetDataIC;
        gvDIC.DataBind();
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcera> getOC(CO0003MOVC OCDATA)
    {
        return CO0003MOVC.ListarOCAP(OCDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CTCAMB getTC(CTCAMB CODATA)
    {
        return CTCAMB.obetenertcambio(CODATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> verLOD(CO0003MOVD DOCDATA)
    {
        return CO0003MOVD.verListaOrden(DOCDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean actualizaNumeracion(AL0003ALMA AXAL)
    {
        return AL0003ALMA.actualizaNumeracion(AXAL);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean registraSerie(AL0003SERI SDATA)
    {
        return AL0003SERI.insertaSerie(SDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean registraAlmacenSerie(AL0003ASER ASDATA)
    {
        return AL0003ASER.insertaAS(ASDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaCabecera(CO0003MOVC ACDATA)
    {
        CO0003MOVC.EstadoOC(ACDATA);
        //CO0003MOVC.AnulaOC(ACDATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaDetalle(CO0003MOVD DCAB)
    {
        CO0003MOVD.actualizaDetalle(DCAB);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static AL0003SERI verificaSL(string AL, string COD, string SER)
    {
        return AL0003SERI.ListarLOTES(AL,COD,SER).FirstOrDefault();
    }
}

