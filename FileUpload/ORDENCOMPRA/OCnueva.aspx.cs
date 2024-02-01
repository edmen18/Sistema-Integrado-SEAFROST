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
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetalle();
        ListaDPlan();
        ListaDetallemtto();

        hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        hfusu.Value = Session["codusu"].ToString();

        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;

        txtobs.Attributes.Add("maxlength", txtobs.MaxLength.ToString());

        ddlmone.Items.Clear();
        ddlmone.DataTextField = "TG_CDESCRI";
        ddlmone.DataValueField = "TG_CCLAVE";
        ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlmone.DataBind();
        ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

        TABL.TG_CCOD = "27";
        TABL.TG_CDESCRI = string.Empty;

        ddlpais.Items.Clear();
        ddlpais.DataTextField = "TG_CDESCRI";
        ddlpais.DataValueField = "TG_CCLAVE";
        ddlpais.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlpais.DataBind();
        ddlpais.Items.Insert(0, new ListItem("[PAIS]", "-1"));
        ddlpais.SelectedValue = "PERU";

        ddlipais.Items.Clear();
        ddlipais.DataTextField = "TG_CDESCRI"; 
        ddlipais.DataValueField = "TG_CCLAVE";
        ddlipais.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlipais.DataBind();
        ddlipais.Items.Insert(0, new ListItem("[PAIS]", "-1"));

        ddlipais2.Items.Clear();
        ddlipais2.DataTextField = "TG_CDESCRI";
        ddlipais2.DataValueField = "TG_CCLAVE";
        ddlipais2.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlipais2.DataBind();
        ddlipais2.Items.Insert(0, new ListItem("[PAIS]", "-1"));


        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipo.Items.Clear();
        ddltipo.DataTextField = "TG_CDESCRI";
        ddltipo.DataValueField = "TG_CCLAVE";
        ddltipo.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("[TIPO]", ""));

        ddltdespa.Items.Clear();
        ddltdespa.DataTextField = "TD_DESC";
        ddltdespa.DataValueField = "TD_ID";
        ddltdespa.DataSource = tabla_tipo_despacho.ListarTipodespa();
        ddltdespa.DataBind();
        ddltdespa.Items.Insert(0, new ListItem("[DESPACHO]", ""));


        TABL.TG_CCOD = "04";
        TABL.TG_CDESCRI = string.Empty;

        ddldocre.Items.Clear();
        ddldocre.DataTextField = "TG_CDESCRI";
        ddldocre.DataValueField = "TG_CCLAVE";
        ddldocre.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddldocre.DataBind();
        ddldocre.Items.Insert(0, new ListItem("[REFERENCIA]", ""));

        AL0003ALMA ALM = new AL0003ALMA();
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;

        ddlalma.Items.Clear();
        ddlalma.DataTextField = "A1_CDESCRI";
        ddlalma.DataValueField = "A1_CALMA";
        ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
        ddlalma.DataBind();
        ddlalma.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));

        //tabla_subtipoOC subo = new tabla_subtipoOC();

        ddlsuboc.Items.Clear();
        ddlsuboc.DataTextField = "Descripcion";
        ddlsuboc.DataValueField = "IDTipo";
        ddlsuboc.DataSource = tabla_subtipoOC.ListarSTipoOC();
        ddlsuboc.DataBind();
        ddlsuboc.Items.Insert(0, new ListItem("[SUBTIPO]", "-1"));

        ddlparea.Items.Clear();
        ddlparea.DataTextField = "AE_DESC";
        ddlparea.DataValueField = "AE_COD";
        ddlparea.DataSource = tabla_area.Listararea();
        ddlparea.DataBind();
        ddlparea.Items.Insert(0, new ListItem("[AREA]", "-1"));

        
        //CP0003TAGE CTABL = new CP0003TAGE();
        //CTABL.TG_INDICE = "51";
        //CTABL.TG_DESCRI = string.Empty;

        //ddlfpago.Items.Clear();
        //ddlfpago.DataTextField = "TG_DESCRI";
        //ddlfpago.DataValueField = "TG_CODIGO";
        //ddlfpago.DataSource = CP0003TAGE.C_ListarTablaG(CTABL);
        //ddlfpago.DataBind();
        //ddlfpago.Items.Insert(0, new ListItem("[FORMA PAGO]", "-1"));


        txtlugarf.Text = ALCIAS.Vercias();
        

    }


    public void ListaDetalle()
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
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public void ListaDetallemtto()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CDESREF");
        dtGetDatae.Columns.Add("OC_CUNIDAD");
        dtGetDatae.Columns.Add("OC_NCANORD");
        dtGetDatae.Columns.Add("OC_NPREUNI");
        dtGetDatae.Columns.Add("OC_NPREUN2");
        dtGetDatae.Columns.Add("OC_NIGV");
        dtGetDatae.Columns.Add("OC_CCENCOS");
        dtGetDatae.Columns.Add("OC_CSOLICI");
        dtGetDatae.Columns.Add("OC_SUBTOTAL");
        dtGetDatae.Columns.Add("OC_TOTAL");
        dtGetDatae.Rows.Add();
        gvmantenimiento.DataSource = dtGetDatae;
        gvmantenimiento.DataBind();
    }
    

    public void ListaDPlan()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("PL_fecha");
        dtGetDatae.Columns.Add("PL_codigo");
        dtGetDatae.Columns.Add("PL_servis");
        dtGetDatae.Columns.Add("PL_planilla");
        dtGetDatae.Columns.Add("PL_especie");
        dtGetDatae.Columns.Add("PL_presentacion");
        dtGetDatae.Columns.Add("PL_tarea");
        dtGetDatae.Columns.Add("PL_cantidad");
        dtGetDatae.Columns.Add("PL_tarifa");
        dtGetDatae.Columns.Add("PL_total");
        dtGetDatae.Columns.Add("PL_turno"); 
        dtGetDatae.Rows.Add();
        gvplan.DataSource = dtGetDatae;
        gvplan.DataBind();
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<vista_cocabcera> ListarCabOC(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraoc(VC);
        
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(CT0003ANEX ADATA)
    {
        return CT0003ANEX.listarAnexoT(ADATA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<AL0003TABL> Getcentrocosto(string dato)
    {
        return AL0003TABL.ListarCcosto(dato);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<AL0003TABL> Gettablaycodigo(string dato,string codigo)
    {
        return AL0003TABL.Listartablaxcodigo(dato, codigo);
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static AL0003TABL Getdescycodigo(string dato, string codigo)
    {
        return AL0003TABL.Registroxcodigo(dato, codigo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CT0003ANEX Getdescproveedor(string textocod)
    {
        return CT0003ANEX.obtenProveedor(textocod);
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void anularoc(CO0003MOVC COANULA)
    {
        CO0003MOVC.AnulaOC(COANULA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static tabla_services Getservxcodigo(tabla_services tbserv,string area)
    {
        return tabla_services.Servicexcodigo(tbserv,area);
    }
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string insertarnumeracion()
    {
        return CO0003MOVC.CuentaDetalleMov();
    }


    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static AL0003ALMA extraeDirAlma(AL0003ALMA CDIR)
    {
        return AL0003ALMA.ListadirAlmacen(CDIR);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaCab(CO0003MOVC CABC)
    {
        CO0003MOVC.InsertarCabecera(CABC);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void eliminadetalleOT(OT_CO0003MOVD ELIM)
    {
        OT_CO0003MOVD.EliminaItemsDetalleOT(ELIM);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaCab_Anexo(OT_CO0003MOVC CABC)
    {
        OT_CO0003MOVC.InsertarCabeceraOT(CABC);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Insertaplanord(tabla_plan_ord DETA)
    {
        tabla_plan_ord.Insertarplanillaorden(DETA);
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaDet(CO0003MOVD DETA)
    {
        CO0003MOVD.insertdetalleOC(DETA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaDet_Anexo(OT_CO0003MOVD DETA)
    {
        OT_CO0003MOVD.insertdetalleOT(DETA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertaDetplanilla(CO0003MOVD DETA)
    {
        CO0003MOVD.insertdetalleOCplanilla(DETA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Eliminadetalle(CO0003MOVD ELIM)
    {
        CO0003MOVD.EliminaItems(ELIM);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Eliminadetalleplanilla(tabla_plan_ord ELIM)
    {
        tabla_plan_ord.EliminaItemsplanilla(ELIM);
    }
    
    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos,string tipop,string subtip,string idusuario,string idprovee,string tipolinea)
    {
        if ( tipop != "S" )
        {
            return AL0003ARTI.ListarArticulosforma2(productos, tipop, subtip,tipolinea);
        }else {
            return AL0003ARTI.ListarServicios(productos, tipop, subtip, idusuario,idprovee, tipolinea);
        }
    }

    //[ScriptMethod()]
    //[System.Web.Services.WebMethod]
    //public static List<AL0003ARTI> GetServicios(string productos, string tipop, string subtip,string idusuario)
    //{
    //    return AL0003ARTI.ListarServicios(productos, tipop, subtip,idusuario);
    //}



    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static CO0003MOVC Getcabecerae(CO0003MOVC INFO)
    {
        return CO0003MOVC.VerCabeceraID(INFO);
    }

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD LDE)
    {
        return CO0003MOVD.verListaOrden(LDE);
    }

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<CP0003TAGE> Getformapago(string cod,string texto)
    {
        return CP0003TAGE.C_ListarTablaGedita(cod,texto);
    }

    

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static void ModificaMontos(CO0003MOVC LDE)
    {
        CO0003MOVC.ModificaMonto(LDE);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertarOChistorial(AL0003APRO DETA)
    {
        AL0003APRO.InsertaOCcopia(DETA);
    }
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertarMOvi(CO0003MOVI DETA)
    {
        CO0003MOVI.insertmoviimp(DETA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CO0003MOVI Mostrarimportacion(CO0003MOVI DETA)
    {
       return  CO0003MOVI.VerMoviimpo(DETA);
    }

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<vista_planilla> GetlistaPlanilla(T_Planilla T_Planilla,string area)
    {
        return DetPlanillaCG.lista_planilla(T_Planilla,area);
    }

    [ScriptMethod]
    [System.Web.Services.WebMethod]
    public static List<tabla_services> GetServis(string texto,string area)
    {
        return tabla_services.ListarServis(texto,area);
    }

    [ScriptMethod]
    [System.Web.Services.WebMethod]
    public static List<OT_CO0003MOVD> ListarMovmtto(OT_CO0003MOVD LDE)
    {
        return OT_CO0003MOVD.verListaOrden_OT(LDE);
    }
    

    [ScriptMethod]
    [System.Web.Services.WebMethod]
    public static void Actualizanum(FT0003NUME datos)
    {
        FT0003NUME.actualizaNumer(datos);
    }

    
}