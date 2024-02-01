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
    public static List<vista_cocabcerapopup> ListarCabOCpopupFechas(CO0003MOVC VC)
    {
        return CO0003MOVC.ListarcabeceraocpopupFechas(VC);


    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aprobardet(CO0003MOVD DETAPRUEBA)
    {
        CO0003MOVD.AprobarDET(DETAPRUEBA);
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



