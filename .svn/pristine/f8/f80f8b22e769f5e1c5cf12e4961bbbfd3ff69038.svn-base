using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetallepopup();
        ListaDetalleCompra();
     
        lblusuario.Text = Convert.ToString( Session["codusu"]);

        txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = "31";
        TABL.TG_CDESCRI = string.Empty;

        ddlestad.Items.Clear();
        ddlestad.DataTextField = "TG_CDESCRI";
        ddlestad.DataValueField = "TG_CCLAVE";
        ddlestad.DataSource = AL0003TABL.ListarTabla(TABL);
        ddlestad.DataBind();
        ddlestad.Items.Insert(0, new ListItem("[ESTADO]", "-1"));


        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipo.Items.Clear();
        ddltipo.DataTextField = "TG_CDESCRI";
        ddltipo.DataValueField = "TG_CCLAVE";
        ddltipo.DataSource = AL0003TABL.ListarTabla(TABL);
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("[ESTADO]", "-1"));


        //  ListaDetalle();
        //  //hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
        //  //hfusu.Value = Session["codusu"].ToString();

        ////  AL0003TABL TABL = new AL0003TABL();
        // // TABL.TG_CCOD = "03";
        //  //TABL.TG_CDESCRI = string.Empty;


        //  ddlmone.Items.Clear();
        //  ddlmone.DataTextField = "TG_CDESCRI";
        //  ddlmone.DataValueField = "TG_CCLAVE";
        //  ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
        //  ddlmone.DataBind();
        //  ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

        // // TABL.TG_CCOD = "27";
        // // TABL.TG_CDESCRI = string.Empty;

        //  ddlpais.Items.Clear();
        //  ddlpais.DataTextField = "TG_CDESCRI";
        //  ddlpais.DataValueField = "TG_CCLAVE";
        //  ddlpais.DataSource = AL0003TABL.ListarTablaS(TABL);
        //  ddlpais.DataBind();
        //  ddlpais.Items.Insert(0, new ListItem("[PAIS]", "-1"));


        //  //TABL.TG_CCOD = "63";
        //  //TABL.TG_CDESCRI = string.Empty;

        //  ddltipo.Items.Clear();
        //  ddltipo.DataTextField = "TG_CDESCRI";
        //  ddltipo.DataValueField = "TG_CCLAVE";
        //  ddltipo.DataSource = AL0003TABL.ListarTablaS(TABL);
        //  ddltipo.DataBind();
        //  ddltipo.Items.Insert(0, new ListItem("[TIPO]", ""));

        //  //TABL.TG_CCOD = "04";
        //  //TABL.TG_CDESCRI = string.Empty;

        //  ddldocre.Items.Clear();
        //  ddldocre.DataTextField = "TG_CDESCRI";
        //  ddldocre.DataValueField = "TG_CCLAVE";
        //  ddldocre.DataSource = AL0003TABL.ListarTablaS(TABL);
        //  ddldocre.DataBind();
        //  ddldocre.Items.Insert(0, new ListItem("[REFERENCIA]", ""));

        //  AL0003ALMA ALM = new AL0003ALMA();
        //  //TABL.TG_CCOD = "03";
        //  //TABL.TG_CDESCRI = string.Empty;

        //  ddlalma.Items.Clear();
        //  ddlalma.DataTextField = "A1_CDESCRI";
        //  ddlalma.DataValueField = "A1_CALMA";
        //  ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
        //  ddlalma.DataBind();
        //  ddlalma.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));


        //  CP0003TAGE CTABL = new CP0003TAGE();
        //  //CTABL.TG_INDICE = "51";
        //  //CTABL.TG_DESCRI = string.Empty;

        //  ddlfpago.Items.Clear();
        //  ddlfpago.DataTextField = "TG_DESCRI";
        //  ddlfpago.DataValueField = "TG_CODIGO";
        //  ddlfpago.DataSource = CP0003TAGE.C_ListarTablaG(CTABL);
        //  ddlfpago.DataBind();
        //  ddlfpago.Items.Insert(0, new ListItem("[FORMA PAGO]", "-1"));


        //  txtlugarf.Text = ALCIAS.Vercias();

        ACCESO();
            }


    public void ListaDetalleCompra()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CITEM");
        dtGetDatae.Columns.Add("OC_CCODIGO");
        dtGetDatae.Columns.Add("OC_CCODREF");
        dtGetDatae.Columns.Add("OC_CUNIDAD");
        dtGetDatae.Columns.Add("OC_NCANORD");
        dtGetDatae.Columns.Add("OC_NPREUN2");
        dtGetDatae.Columns.Add("OC_NDSCPAD");
        dtGetDatae.Columns.Add("OC_NDSCPIT");
        dtGetDatae.Columns.Add("OC_NIGVPOR");
        dtGetDatae.Columns.Add("OC_NISCPOR");
        dtGetDatae.Columns.Add("OC_NPREUNI");
        dtGetDatae.Columns.Add("OC_NDESCTO");
        dtGetDatae.Columns.Add("OC_NIGV");
        dtGetDatae.Columns.Add("OC_NCANTEN");
        dtGetDatae.Columns.Add("OC_NCANSAL");
        dtGetDatae.Columns.Add("OC_DFECENT");
        dtGetDatae.Columns.Add("OC_COMENTA");
        dtGetDatae.Columns.Add("OC_NISC");
        dtGetDatae.Columns.Add("SUBTOTAL");

        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }


    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_CCODMON");
        dtGetDatae.Columns.Add("OC_NIMPMN");
        dtGetDatae.Columns.Add("OC_CSITORD");
        dtGetDatae.Columns.Add("OC_CTIPORD");
        dtGetDatae.Columns.Add("OC_CCOTIZA");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public void ListaDetallepopup()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_CCODMON");
        dtGetDatae.Columns.Add("OC_NIMPMN");
        dtGetDatae.Columns.Add("OC_CSITORD");
        dtGetDatae.Columns.Add("OC_CTIPORD");
        dtGetDatae.Columns.Add("OC_CCOTIZA");
        dtGetDatae.Columns.Add("OC_CODPRO");
        dtGetDatae.Columns.Add("OC_CDIRPRO");
        dtGetDatae.Columns.Add("OC_CCOPAIS");
        dtGetDatae.Columns.Add("OC_CFORPA1");
        dtGetDatae.Columns.Add("OC_CTIPENV");
        dtGetDatae.Columns.Add("OC_CLUGENT");
        dtGetDatae.Columns.Add("OC_CLUGFAC");
        dtGetDatae.Columns.Add("OC_CDISTOC");
        dtGetDatae.Columns.Add("OC_CPROVOC");
        dtGetDatae.Columns.Add("OC_NTIPCAM");
        dtGetDatae.Columns.Add("OC_CODSOL");
        dtGetDatae.Columns.Add("OC_CSOLICIT");
        dtGetDatae.Columns.Add("OC_CREMITE");
        dtGetDatae.Columns.Add("OC_CPERATE");
        dtGetDatae.Columns.Add("OC_CUSEA01");
        dtGetDatae.Columns.Add("OC_CUSEA02");
        dtGetDatae.Columns.Add("OC_CUSEA03");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcerapopup> ListarCabOCpopup(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraocpopup(VC);

    }

    public static List<vista_cocabcera> ListarCabOC(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraoc(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aprobaroc(CO0003MOVC COAPRUEBA)
    {
       CO0003MOVC.AprobarOC(COAPRUEBA);
     }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> Getcentrocosto(string dato)
    {
        return AL0003TABL.ListarCcosto(dato);
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD LDE)
    {
        return CO0003MOVD.verListaOrden(LDE);
    }

    public static CO0003MOVC Getcabecerae(CO0003MOVC INFO)
    {
        return CO0003MOVC.VerCabeceraID(INFO);
    }

    public void ACCESO()
    {
        int contador = UT0030.CuentaAccesoADoc(lblusuario.Text);
        
        if (contador > 0)
        {

            lblacceso.Text =Convert.ToString( contador);
         }
        else
        {
            lblacceso.Text = "0";
        }

    }

   
    }



