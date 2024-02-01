using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
public partial class ListadoCDOC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetallepopup();
        ListaDetalleCompra();
        ListaDetallepopupcopia();
        historial();

        lblusuario.Text = Convert.ToString(Session["codusu"]);

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
        ddlestad.Items.Insert(0, new ListItem("[TODOS]", "-1"));


        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipo.Items.Clear();
        ddltipo.DataTextField = "TG_CDESCRI";
        ddltipo.DataValueField = "TG_CCLAVE";
        ddltipo.DataSource = AL0003TABL.ListarTabla(TABL);
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("[TODOS]", "-1"));

        ACCESO();
        FILTROAPROB();

        /**/
        DateTime Hoy = DateTime.Today;
        CP0003CART DATA = new CP0003CART();
        DATA.CP_CVANEXO = "P";
        DATA.CP_CSITUAC = "C";//REGISTRADA:R
        DATA.CP_CTIPDOC = "FT";
        DATA.CP_CAREA = "";
        DATA.CP_CTDOCRE = "";//CP_CTDOCRE
        DATA.CP_CCENCOR = "";// (txtCCID.Text == "" ? "" : txtCCID.Text);//CONGELADO
        DATA.CP_DFECDOC = Convert.ToDateTime(Hoy.Year + "/" + Hoy.Month + "/01");//Convert.ToDateTime(txtOCF1.Text);
        DATA.CP_DFECUBI = Hoy;//Convert.ToDateTime(txtOCF2.Text);
        gvDOC.DataSource = CP0003CART.listar(DATA);
        gvDOC.DataBind();
        gvDOC.Columns[2].Visible = false;

        if (CP0003CART.listar(DATA).Count == 0)
        {
            grid();
        }

        CP0003CART DATAR = new CP0003CART();
        DATAR.CP_CSITUAC = "C";
        DATAR.CP_CVANEXO = "P";
        //DATAR.CP_CTIPDOC = "FT";
        DATAR.CP_CSUBDIA = "1";
        DATAR.CP_DFECCRE = Convert.ToDateTime(Hoy.Year + "/" + Hoy.Month + "/01");
        DATAR.CP_DFECMOD = Hoy;
        gvRESUMEN.DataSource = CP0003CART.mi_resumen(DATAR);
        gvRESUMEN.DataBind();
        //gvRESUMEN.Columns[2].Visible = false;
        if (CP0003CART.mi_resumen(DATAR).Count == 0)
        {
            grid2();
        }
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
        dtGetDatae.Columns.Add("OC_CFORPA1");
        dtGetDatae.Columns.Add("OC_CUSEA01");
        dtGetDatae.Columns.Add("OC_CUSEA02");
        dtGetDatae.Columns.Add("OC_CUSEA03");
        dtGetDatae.Columns.Add("OC_CSOLICIT");
        dtGetDatae.Columns.Add("AC_CCTAMNT");
        dtGetDatae.Columns.Add("AC_CCTAUST");
        dtGetDatae.Columns.Add("AC_CCTAMN7");
        dtGetDatae.Columns.Add("AC_CCTAUS7");
        dtGetDatae.Columns.Add("AC_CCTAMNK");
        dtGetDatae.Columns.Add("AC_CCTAUSK");
        dtGetDatae.Columns.Add("AC_CCTADET");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public void ListaDetallepopupcopia()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_CCODMON");
        dtGetDatae.Columns.Add("OC_NIMPMN");
        dtGetDatae.Columns.Add("OC_CSITORD");
        dtGetDatae.Columns.Add("OC_CTIPORD");
        dtGetDatae.Columns.Add("OC_CFORPA1");
        dtGetDatae.Columns.Add("OC_CUSEA01");
        dtGetDatae.Columns.Add("OC_CUSEA02");
        dtGetDatae.Columns.Add("OC_CUSEA03");
        dtGetDatae.Columns.Add("OC_CSOLICIT");
        dtGetDatae.Columns.Add("AC_CCTAMNT");
        dtGetDatae.Columns.Add("AC_CCTAMN7");
        dtGetDatae.Columns.Add("AC_CCTAMNK");
        dtGetDatae.Columns.Add("AC_CCTADET");
        dtGetDatae.Rows.Add();
        gvcopia.DataSource = dtGetDatae;
        gvcopia.DataBind();
    }

    public void historial()
    {
        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("OC_CCODPRO");
        dtGetDatae1.Columns.Add("OC_CRAZSOC");
        dtGetDatae1.Columns.Add("OC_DFECDOC");
        dtGetDatae1.Columns.Add("OC_CCODMON");
        dtGetDatae1.Columns.Add("OC_NPREUN2");
        dtGetDatae1.Columns.Add("OC_CNUMORD");
        dtGetDatae1.Rows.Add();
        gvdetallereq.DataSource = dtGetDatae1;
        gvdetallereq.DataBind();
    }

    public void grid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("CP_CTDOCRE");
        dtGetData.Columns.Add("CP_CNDOCRE");
        dtGetData.Columns.Add("CP_CVANEXO");
        dtGetData.Columns.Add("CP_CCODIGO");
        dtGetData.Columns.Add("NOMTIT");
        dtGetData.Columns.Add("CP_CTIPDOC");
        dtGetData.Columns.Add("CP_CNUMDOC");
        dtGetData.Columns.Add("CP_CCODMON");
        dtGetData.Columns.Add("IMPORTE");
        dtGetData.Columns.Add("CP_DFECCRE1");
        //dtGetData.Columns.Add("CP_DFDOCRE");
        dtGetData.Columns.Add("CENCOR");
        dtGetData.Columns.Add("NOMARE");
        dtGetData.Columns.Add("CP_CUSER");
        dtGetData.Columns.Add("CP_CSITUAC");
        dtGetData.Columns.Add("");
        dtGetData.Rows.Add();
        gvDOC.DataSource = dtGetData;
        gvDOC.DataBind();
    }

    public void grid2()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("CP_CUSER");
        dtGetData.Columns.Add("CP_CAREA");
        dtGetData.Columns.Add("CP_CSUBDIA");
        dtGetData.Columns.Add("CP_NIMP2MN");
        dtGetData.Rows.Add();
        gvRESUMEN.DataSource = dtGetData;
        gvRESUMEN.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcerapopup> ListarCabOCpopup(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraocpopup(VC);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcerapopup> ListarcabeceraocpopupCondosusuarios(CO0003MOVC VC)
    {
        return CO0003MOVC.ListarcabeceraocpopupCondosusuarios(VC);
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
    public static tabla_d_control micontrol(tabla_d_control DATA)
    {
        return tabla_d_control.VerCabeceraID(DATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertadetallprodusua(tabla_d_usuaprod INF)
    {
        tabla_d_usuaprod.Actualizardetup(INF);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static int Extraenaprob(tabla_d_usuaprod parm)
    {
        return tabla_d_usuaprod.NumAprob(parm);
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

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_historialPrecios> ListarHistorialPrecios(AL0003REQD REQ)
    {
        return CO0003MOVC.ListarHistorialPreciosPorProducto(REQ);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vistas_finanzas> contabilizados(CP0003CART DATA)
    {
        return CP0003CART.listar(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> mi_resumen(CP0003CART DATA) {
        return CP0003CART.mi_resumen(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> obtiene_bc(CP0003MAES DATA) {
        return CP0003MAES.obtiene_banco_cuenta(DATA);
    }
    public void ACCESO()
    {
        int contador = UT0030.CuentaAccesoADoc(lblusuario.Text);

        if (contador > 0)
        {

            lblacceso.Text = Convert.ToString(contador);
        }
        else
        {
            lblacceso.Text = "0";
        }

    }

    public void FILTROAPROB()
    {
        string PERMISO = UT0030.Mostrarinfousuario(lblusuario.Text).TU_LOCEMI;

        if (PERMISO != "F")
        {

            lblpermiso.Text = Convert.ToString(PERMISO);
        }
        else
        {
            lblpermiso.Text = "";
        }

    }

    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }

    protected void btnOC_Click(object sender, EventArgs e)
    {
        /*
        CP0003CART DATA = new CP0003CART();
        DATA.CP_CVANEXO = "P";
        DATA.CP_CSITUAC = "C";//REGISTRADA:R
        DATA.CP_CAREA = "";
        DATA.CP_CTDOCRE = "OC";//CP_CTDOCRE
        DATA.CP_CCENCOR = "";
        DATA.CP_DFECDOC = Convert.ToDateTime(txtOCF1.Text);
        DATA.CP_DFECUBI = Convert.ToDateTime(txtOCF2.Text);
        /*
        if (txtCCID.Text == "XX")
        {
            DATA.CP_CCENCOR = "";
            txtCCDE.Text = "TODOS";
        }
        else
        {
            DATA.CP_CCENCOR = txtCCID.Text;
        }*/
        /*
        if (CP0003CART.listar(DATA).Count > 0)
        {
            gvDOC.DataSource = CP0003CART.listar(DATA);
            gvDOC.DataBind();
        }
        else
        {
            grid();
        }*/
    }
}



