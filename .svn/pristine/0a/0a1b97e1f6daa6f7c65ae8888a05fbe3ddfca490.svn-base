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
using CapaEntidades;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {

            gvdetallel();
            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
            //txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");

            AL0003ALMA ALM = new AL0003ALMA();

            ddlalma.Items.Clear();
            ddlalma.DataTextField = "A1_CDESCRI";
            ddlalma.DataValueField = "A1_CALMA";
            ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma.DataBind();
            ddlalma.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));
            ddlalma.SelectedValue = "0001";


            ddlsarea.Items.Clear();
            ddlsarea.DataTextField = "SA_DESC";
            ddlsarea.DataValueField = "SA_ID";
            ddlsarea.DataSource = tabla_d_areausua.Listarsubareasxusua(hfusu.Value,1);
            ddlsarea.DataBind();
            ddlsarea.Items.Insert(0, new ListItem("[AREA]", ""));

            ddltipos.Items.Insert(0, new ListItem("SOLICITUD", "SO"));
            ddltipos.Items.Insert(1, new ListItem("DEVOLUCION", "DE"));

            //tabla_parametros PDATA = new tabla_parametros();
            //PDATA.AF_COD = "SL";
            //ddldest.Items.Clear();
            //ddldest.DataTextField = "AF_TDESCRI1";
            //ddldest.DataValueField = "AF_TDESCRI2";
            //ddldest.DataSource = tabla_parametros.ListarParametro(PDATA);
            //ddldest.DataBind();
            //ddldest.Items.Insert(0, new ListItem("", ""));

            //ddltipot.Items.Insert(0, new ListItem("FIJA", "F"));
            //ddltipot.Items.Insert(1, new ListItem("VARIABLE", "V"));


        }
    }


    public void gvdetallel()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SA_ITEM"); 
        dtGetDatae.Columns.Add("SA_ID");
        dtGetDatae.Columns.Add("SA_DESC");
        dtGetDatae.Columns.Add("SA_NAPROB");
        dtGetDatae.Columns.Add("SA_PRECIO");
        dtGetDatae.Columns.Add("SA_SUBTOT");
        dtGetDatae.Rows.Add();
        gvdetalle.DataSource = dtGetDatae;
        gvdetalle.DataBind();
    }
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<AL0003TABL> Gettablaycodigo(string dato, string codigo)
    {
        return AL0003TABL.Listartablaxcodigo(dato, codigo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertSolicitudC(tabla_solicitud tabla_solicitud)
    {
        tabla_solicitud.InsertaSolicitudC(tabla_solicitud); 
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CO0003MOVC MostrarPrecioUlt(AL0003REQD ADATA)
    {
        return CO0003MOVC.UltimolPrecioPorProducto(ADATA);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static tabla_solicitud MostraCabSol(int ndoc,string tipod)
    {
        return tabla_solicitud.ListarSolicitud(ndoc, tipod).FirstOrDefault();
    }

    


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertSolicitudD(tabla_d_solicitud TDET)  
    {
        tabla_d_solicitud.InsertaSolicitudD(TDET);
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void ElimSolicitudD(tabla_d_solicitud TDET)
    {
        tabla_d_solicitud.eliminaSolicitudD(TDET);
    }


    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string GetcodigoGenerar(string TDOC)
    {
        return tabla_solicitud.ultimocodigoSolic(TDOC).ToString();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static AL0003TABL Getdescycodigo(string dato, string codigo)
    {
        return AL0003TABL.Registroxcodigo(dato, codigo);
    }


    //[ScriptMethod()]
    //[System.Web.Services.WebMethod]
    //public static List<AL0003ARTI> GetProductos(string productos, string tipop, string subtip, string idusuario, string idprovee,string tipolinea)
    //{
    //        return AL0003ARTI.ListarServicios(productos, tipop, subtip, idusuario, idprovee, tipolinea);
    //}

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<Cls_articulos> getProducto(string dato,string COalm)
    {
        Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
        return consulta.funObtenerArticulos(dato, COalm,"1");

    }
    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> getProductoAS(string dato)
    {
        return AL0003ARTI.ListarArticulosIDxOC(dato,"N");
    }


    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<tabla_d_solicitud> Listardetvale(int codig,string DS_TIPOS)
    {
        return tabla_d_solicitud.ListarDetalleSolid(codig,DS_TIPOS);
    }


    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static AL0003ARTI Mostrarunarti(string SDATA)
    {
        return AL0003ARTI.obtenerArticuloPorID(SDATA);
    }
    

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static AL0003SERI ListarSL(AL0003SERI SDATA)
    {
        return AL0003SERI.ListarSLxPROD(SDATA).FirstOrDefault();
    }


    //[ScriptMethod()]
    //[System.Web.Services.WebMethod]
    //public static List<Cls_articulos> getProducto(string dato)
    //{
    //    Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
    //    return consulta.funObtenerArticulos(dato);
    //}

    [System.Web.Services.WebMethod]
    [ScriptMethod()] 
    public static List<AL0003TABL> listatabl(string texto,string codigo)
    {
        return AL0003TABL.Listartablaxcodigo(texto, codigo);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<tabla_parametros> Listarcombo(tabla_parametros PDATA)
    {
        return tabla_parametros.Listaxalmac(PDATA);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static decimal Stockxsolicitante(tabla_stockxsoli valores)
    {
        return tabla_stockxsoli.Stockxsolicitante(valores);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static decimal StockxGeneral(tabla_stockxsoli valores)
    {
        return tabla_stockxsoli.StockxGeneral(valores);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static decimal Stockxsol(tabla_stockxsoli valores)
    {
        return tabla_stockxsoli.Stockxsol(valores);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static decimal StockGenerall(tabla_stockxsoli valores)
    {
        return tabla_stockxsoli.StockxGeneral(valores);
    }

    //[System.Web.Services.WebMethod]
    //[ScriptMethod()]
    //public static decimal? Solicitudesaprob(tabla_d_solicitud valores)
    //{
    //    return  tabla_d_solicitud.CantidadsolicitadaAp(valores).Sum(a=>a.DS_CANTID);
    //}


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string extraedescuenta(string ncuenta)
    {
        return FT0003CTAE.RegistrounCta(ncuenta);
    }


    //[System.Web.Services.WebMethod]
    //[ScriptMethod()]
    //public static string ExtraeStock(string ncuenta)
    //{
    //    return AL0003STOC.ListarStockID(ncuenta);
    //}





  
}