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

public partial class RegistroEntrada : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            lblEntrada.Text = "E";
            lbltipoRegistro.Text = "E";
            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"] == null ? "0001" : Session["aID"].ToString());
            lblFechaE.Text = (Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());//VALIDAR
            lblFechaDocD.Text = (Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());//DETALLE
            lblAlmacen.Text = (Session["daID"] == null ? "ALMACEN DE INSUMOS" : Session["daID"].ToString());
            btnagregarItem.Enabled = false;

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlMoneda.Items.Clear();
            ddlMoneda.DataTextField = "TG_CDESCRI";
            ddlMoneda.DataValueField = "TG_CCLAVE";
            ddlMoneda.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlMoneda.DataBind();
            ddlMoneda.Items.Insert(0, new ListItem("[Moneda]", "-1"));

            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTipoConversion.Items.Clear();
            ddlTipoConversion.DataTextField = "TG_CDESCRI";
            ddlTipoConversion.DataValueField = "TG_CCLAVE";
            ddlTipoConversion.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlTipoConversion.DataBind();
            ddlTipoConversion.Items.Insert(0, new ListItem("[Conversion]", "-1"));

            ddlAlmacenRef.Items.Clear();
            ddlAlmacenRef.DataTextField = "A1_CDESCRI";
            ddlAlmacenRef.DataValueField = "A1_CALMA";
            ddlAlmacenRef.DataSource = AL0003ALMA.ListarAlmacen();
            ddlAlmacenRef.DataBind();
            ddlAlmacenRef.Items.Insert(0, new ListItem("[Almacen Ref]", "-1"));

            tabla_parametros PDATA = new tabla_parametros();
            PDATA.AF_COD = "DE";
            ddlDepa.Items.Clear();
            ddlDepa.DataTextField = "AF_TDESCRI1";
            ddlDepa.DataValueField = "AF_CCLAVE";
            ddlDepa.DataSource = tabla_parametros.ListarParametro(PDATA);
            ddlDepa.DataBind();
            ddlDepa.Items.Insert(0, new ListItem("-", "-1"));

            PDATA.AF_COD = "01";
            ddlOrigen.Items.Clear();
            ddlOrigen.DataTextField = "AF_TDESCRI1";
            ddlOrigen.DataValueField = "AF_TDESCRI1";
            ddlOrigen.DataSource = tabla_parametros.ListarParametro(PDATA);
            ddlOrigen.DataBind();

            ListaDetalle();
            iniciaSL();
        }
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
        dtGetData.Columns.Add("A_EDITA");
        dtGetData.Columns.Add("A_ELIMINA");
        dtGetData.Rows.Add();
        gvDetalleEntrada.DataSource = dtGetData;
        gvDetalleEntrada.DataBind();
    }
    public void iniciaSL()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("SR_CSERIE");
        dtGetData.Columns.Add("SR_NKDIS");
        dtGetData.Columns.Add("SR_DFECVEN");
        dtGetData.Columns.Add("ACCION");
        dtGetData.Rows.Add();
        gvSerie.DataSource = dtGetData;
        gvSerie.DataBind();
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> getMovimientosID(string datos, string tipo)
    {
        return AL0003TABM.ListarMovimientosID(datos, tipo);
    }


    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> getMovimientos(string datos, string tipo)
    {
        return AL0003TABM.ListarMovimientos(datos, tipo);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<AL0003TABL> Gettablaycodigo(string dato, string codigo)
    public static string Gettablaycodigo(string dato, string codigo)
    {
        return AL0003TABL.Registrouno(dato, codigo);
        //return AL0003TABL.ListartablaxID(dato, codigo);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> Gettablaydetalle(string dato, string codigo)
    {
        return AL0003TABL.ListartablaxDetalle(dato, codigo);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<FT0003CLIE> getClienteID(string dato)
    {
        return FT0003CLIE.ListarClienteID(dato);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static List<CT0003ANEX> getCliente(string COD, string CAD)
    {
        //CODIGO
        return CT0003ANEX.listarAnexoID(COD, CAD);
        //return CT0003ANEX.listarAnexo(COD,CAD);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static List<CT0003ANEX> getClienteT(CT0003ANEX ADATA)
    { 
        //DESCRIPCION
        return CT0003ANEX.listarAnexoT(ADATA);
        //return CT0003ANEX.listarAnexoID(COD,CAD);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> getClienteT1(CP0003MAES ADATA)
    {
        //NUEVA ACTUALIZACION
        return CP0003MAES.listarMaestro(ADATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getProducto(string dato,string TR,string AL)
    {
        return AL0003ARTI.ListarArtSto(dato, TR, AL);
        //return AL0003ARTI.ListarArticulos(dato,TR,AL);

    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getProductoAS(string dato, string TR, string AL)
    {
        return AL0003ARTI.ListarArtStoID(dato, TR, AL);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getProductoID(string dato)
    {
        return AL0003ARTI.ListarArticulosID(dato);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003STOC> getSTOCKCOD(string AL, string COD,string TR)
    {
        return AL0003STOC.ListarStockID(AL, COD,TR);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003SERI> getLOTES(string AL, string COD, string SER)
    {
        return AL0003SERI.ListarLOTES(AL, COD, SER);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoID(string AL, string TDOC)
    {
        return AL0003MOVC.codMaximo(AL, TDOC);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarCabecera(AL0003MOVC DATA)
    {
        AL0003MOVC.insertaCabeceraEntrada(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarDetalleCabecera(AL0003MOVD DATA)
    {
        AL0003MOVD.insertaDetalleCabecera(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaStock(AL0003STOC DATAI, string OP)
    {
        AL0003STOC.actualizaStock(DATAI, OP);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaSSerie(AL0003SERI SDATA, string OP)
    {
        //STOCK SERIE
        AL0003SERI.actualizaSSerie(SDATA,OP);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static AL0003TABM obtenerCampo(string CM, string TM)
    {
        return AL0003TABM.obtenerCDisponible(CM, TM);
    }
    //NUEVO 21/03/16
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_bahias> getBAHIA(tabla_bahias BDATA)
    {
        return tabla_bahias.ListarBahia(BDATA);
    }
    //NUEVO 26/03/2016
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_embarcaciones> getEMBID(tabla_embarcaciones EDATA)
    {
        return tabla_embarcaciones.ListarEmbarcacionid(EDATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_embarcaciones> getEMB(tabla_embarcaciones EDATA)
    {
        return tabla_embarcaciones.ListarEmbarcacion(EDATA);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getBAR(tabla_parametros EDATA)
    {
        //BARCOS CONSERVAS
        return tabla_parametros.ListarParametroX(EDATA);
    }

    //21/03/2016
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003SERI> ListarSL(AL0003SERI SDATA)
    {
        return AL0003SERI.ListarSL(SDATA);
    }
}

