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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
            lblFechaDocD.Text = (Session["FechaE"] == null ? hffactual.Value : Session["FechaE"].ToString());//DETALLE
            codAL.Value = (Session["aID"] == null ? "0001" : Session["aID"].ToString());
            ListaMovi();
            iniciaSL();
            ListaDetalle();
            Listadetallev();
            ListaDetalle02();
            ddlfilt.DataTextField = "SA_DESC";
            ddlfilt.DataValueField ="SA_ID";
            ddlfilt.DataSource = tabla_subareas.Listarsubareas();
            ddlfilt.DataBind();
            ddlfilt.Items.Insert(0, new ListItem("[Seleccione Area]", ""));

            ddltipos.Items.Insert(0, new ListItem("SOLICITUD", "SO"));
            ddltipos.Items.Insert(1, new ListItem("DEVOLUCION", "DE"));

            ddlalma.Items.Clear();
            ddlalma.DataTextField = "A1_CDESCRI";
            ddlalma.DataValueField = "A1_CALMA";
            ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma.DataBind();
            ddlalma.Items.Insert(0, new ListItem("[Almacen Ref]", ""));

            AL0003TABL ifo = new AL0003TABL();
            ifo.TG_CCOD = "75";
            ddlestad.Items.Clear();
            ddlestad.DataTextField = "TG_CDESCRI";
            ddlestad.DataValueField = "TG_CCLAVE";
            ddlestad.DataSource = AL0003TABL.ListarTablaS(ifo);
            ddlestad.DataBind();
            ddlestad.Items.Insert(0, new ListItem("[Seleccione Estado]", ""));
            

            var lar = new List<AL0003ARTI>();
            int sivalida = UT0030.ListarUsuariosxF().Where(r => r.TU_ALIAS == hfusu.Value).ToList().Count();


        }
    }

    public void ListaMovi() 
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SM_ID");
        dtGetDatae.Columns.Add("SM_IDSOLI");
        dtGetDatae.Columns.Add("SM_GLOSA");
        dtGetDatae.Columns.Add("SM_AREA");
        dtGetDatae.Columns.Add("SM_ESTADO");
        dtGetDatae.Columns.Add("SM_USUA");
        dtGetDatae.Rows.Add();
        gvsolicitudes.DataSource = dtGetDatae;
        gvsolicitudes.DataBind();
    }

    public void ListaDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("ITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("AR_CUNIDAD");
        dtGetData.Columns.Add("C6_CCENCOS");
        dtGetData.Columns.Add("C6_CSERIE");
        dtGetData.Columns.Add("C6_CFECDOC");
        dtGetData.Columns.Add("C6_CNCANTIDAD");
        //dtGetData.Columns.Add("A_EDITA");
        dtGetData.Rows.Add();
        gvDetalleEntrada.DataSource = dtGetData;
        gvDetalleEntrada.DataBind();
    }

    public void ListaDetalle02()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("ITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("AR_CUNIDAD");
        dtGetData.Columns.Add("C6_CCENCOS");
        dtGetData.Columns.Add("C6_CSERIE");
        dtGetData.Columns.Add("C6_CFECDOC");
        dtGetData.Columns.Add("C6_CNCANTIDAD");
        ////dtGetData.Columns.Add("A_EDITA");
        ////dtGetData.Columns.Add("A_ELIMINA");
        dtGetData.Rows.Add("","","","","","","","");
        gvlotexvale.DataSource = dtGetData;
        gvlotexvale.DataBind();
    }

    public void iniciaSL()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("SR_CSERIE");
        dtGetData.Columns.Add("SR_NKDIS");
        dtGetData.Columns.Add("SR_DFECVEN");
        dtGetData.Rows.Add();
        gvSerie.DataSource = dtGetData;
        gvSerie.DataBind();
    }
    public void Listadetallev()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("VSO_ITM");
        dtGetDatae.Columns.Add("VSO_UND");
        dtGetDatae.Columns.Add("VSO_DESPROD");
        dtGetDatae.Columns.Add("VSO_CANTID");
        dtGetDatae.Rows.Add();
        gvdetvale.DataSource = dtGetDatae;
        gvdetvale.DataBind();
    }

    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<UT0030> listarusuarios(string nombre)
    {
        return UT0030.ListarautocUsuarios(nombre);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<tabla_d_usuaprod> listarusuariosaproba(string idproducto)
    {
        return tabla_d_usuaprod.AprobacionxProductodetall(idproducto, 1); 
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<vista_d_soli> ListaDetalleVale(int nrvale,string SM_TIPOS)
    {
        return tabla_d_solicitud.ListaDetalleVale(nrvale, SM_TIPOS);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static vista_solicitudalmacen Vercabvale(tabla_solicitud INF)
    {
        return tabla_solicitud.MostrarCabsoli(INF);
    }

    [System.Web.Services.WebMethod] 
    [ScriptMethod()]
    public static tabla_solicitud ObtenerinfSoli(int codnumdoc,string tiposo)
    {
        return tabla_solicitud.ObtenerinfounaSol(codnumdoc,tiposo);
    }
    

   [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Validausuarioniv(string usua,int numnivel)
    {
        return tabla_d_nivelusua.Validausuanivel(usua, numnivel);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void guardarCabecera(AL0003MOVC DATA)
    {
        AL0003MOVC.insertaCabeceraEntrada(DATA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Validausuariocuenta(string usua)
    {
        return tabla_d_nivelusua.Validausuacuenta(usua);
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Extraenaprob(tabla_d_usuaprod parm)
    {
        return tabla_d_usuaprod.NumAprob(parm);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string Subareasnaprob(string codprod)
    {
        return AL0003ARTI.Obtenernaprobaxarea(codprod).Trim();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Subareanusua(string codusua,string codarea,int tipopro)
    {
        return tabla_d_areausua.Listarsubareacceso(codusua, codarea, tipopro);
    }
    

    [System.Web.Services.WebMethod] 
    [ScriptMethod()] 
    public static int Extraenaprobtotal(tabla_d_usuaprod parm) 
    {
        return tabla_d_usuaprod.NumAprobTotal(parm); 
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string Extraeunacuenta(string ncuenta)
    {
        return FT0003CTAE.RegistrounCta(ncuenta);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void ActualizaEstado(tabla_solicitud INF)
    {
        tabla_solicitud.ActualizaARestado(INF); 
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Actualizacuenta(AL0003ARTI INF)
    {
        AL0003ARTI.ActualizaARcuenta(INF);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Insertadetallprodusua(tabla_d_usuaprod INF)
    {
        tabla_d_usuaprod.Actualizardetup(INF);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void eliminausuaprod(tabla_d_usuaprod INF)
    {
        tabla_d_usuaprod.DesapruebaTarifa(INF);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<tabla_d_solicitud> GetListaVale(int numvale,string DS_TIPOS)
    {
        return tabla_d_solicitud.ListarDetalleSolid(numvale, DS_TIPOS);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static AL0003ARTI GEtProductoInf(string idprod)
    {
        return AL0003ARTI.obtenerArticuloPorID(idprod);
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string correlativoID(string AL, string TDOC)
    {
        return AL0003MOVC.codMaximo(AL, TDOC);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static Boolean registraAlmacenSerie(AL0003ASER ASDATA)
    {
        return AL0003ASER.insertaAS(ASDATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static void ActualizaStockxSolicitan(tabla_stockxsoli ADATA,string OP)
    {
        tabla_stockxsoli.ActulizarStockxSolic(ADATA,OP);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]

    public static void ActualizaestadoSolic(tabla_solicitud ADATA)
    {
        tabla_solicitud.ActualizaDatoVale(ADATA);
    }


   

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003SERI> ListarSL(AL0003SERI SDATA)
    {
        return AL0003SERI.ListarSL(SDATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaSSerie(AL0003SERI SDATA, string OP)
    {
        //STOCK SERIE
        AL0003SERI.InsUpdSerie(SDATA, OP);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static tabla_solicitud ObtenerinfSolic(int idsol,string tiposo)
    {
        return tabla_solicitud.ObtenerinfounaSol(idsol, tiposo);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarDetalleCabecera(AL0003MOVD DATA)
    {
        AL0003MOVD.insertaDetalleCabecera(DATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaStock(AL0003STOC DATAI, string OP)
    {
        AL0003STOC.actualizaStock(DATAI, OP);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static int Existevale(int dato,string TDOCX)
    {
        return tabla_solicitud.ListarSolicitud(dato, TDOCX).Count();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> getMovimientos(string datos, string tipo)
    {
        return AL0003TABM.ListarMovimientos(datos, tipo);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static AL0003TABM getMovimientosID(string datos, string tipo)
    {
        return AL0003TABM.ListarMovimientosID(datos, tipo).FirstOrDefault();
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static int ValidaStocxSoli(string almacen, string idprod, string solict, string lote)
    {
        return tabla_stockxsoli.ValidaStockxsoli(almacen, idprod, solict, lote).Where(a=>a.SS_CANTID>0).Count();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static tabla_stockxsoli CantidadStocxSoli(string almacen, string idprod, string solict, string lote)
    {
        return tabla_stockxsoli.ValidaStockxsoli(almacen, idprod, solict, lote).FirstOrDefault();
    }

    //[System.Web.Services.WebMethod]
    //[ScriptMethod()]
    //public static void enviofinalemail(string idusuario,string idprod)
    //{
    //    List<string> fiche = new List<string>();
    //    AL0003ARTI mostrarprod = new AL0003ARTI();
    //    mostrarprod  = AL0003ARTI.obtenerArticuloPorID(idprod);
    //    string informa = "<html><body> <table style='font-size:12px;background-color:White;border-color:#CCCCCC;width:800px;font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif' border='1' cellpadding='1' cellspacing='1'><tr><td colspan='2' align='center' bgcolor='#7ACAFF'> <b>" + "SERVICIO" + "</b></td></tr><tr><td colspan='2' align='center' bgcolor='#FFCC99'>" + mostrarprod.AR_CDESCRI + "</td></tr><tr><td>" + " PROVEEDOR: " + "</td><td>" + CT0003ANEX.obtenProveedor(mostrarprod.AR_CCODPRO.Trim()).ADESANE+ "</td></tr><tr><td>" + " TARIFA: " + "</td><td>" + Convert.ToDecimal(string.Format("{0:00.0000}", mostrarprod.AR_NPRECOM)) + "</td></tr><tr><td>" 
    //            + " AREA: " + "</td><td>" + tabla_subareas.Listarsubareas().Where(a=>a.SA_ID.ToString()== mostrarprod.AR_CPARARA).First().SA_DESC + "</td></tr><tr><td>" + " MONEDA: " + "</td><td>" + mostrarprod.AR_CMONCOM.Trim() + "</td></tr><tr><td>" + " TIPO:" + "</td><td>" + mostrarprod.AR_CTIPDES + "</td></tr><tr><td>" + " USUARIO: " + "</td><td>" + UT0030.Mostrarunusuario(mostrarprod.AR_CUSUCRE) + "</td></tr></table></body></html>";

    //    var enviousuaxarea = UT0030.ListarUsuariosxF(); 
    //    foreach (var d in enviousuaxarea)
    //    {
    //        if (d.TU_CORREO.Trim() != "" || d.TU_CORREO != null)
    //        {
    //            Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "APROBACION FINAL DE SERVICIO", d.TU_CORREO, "", "programador1@seafrost.com.pe", fiche);
    //        }
    //    }
    //}

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<vista_solicitudCAB> ListarVales(tabla_solicitud ADATA)
    {
        return tabla_solicitud.ListarSolicitudes(ADATA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<vista_solicitudCAB> ListarValesFesp(tabla_solicitud ADATA)
    {
        return tabla_solicitud.ListarSolicitudesPRM(ADATA);
    }
    

    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }






}