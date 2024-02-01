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
        txtfecha1.Text = "01/01/2016";
        txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //txtfechaproceso.Text = DateTime.Now.ToString("dd/MM/yyyy");
        ListaLiquidaciones();
        ListaDetalle();
    }
    public void ListaLiquidaciones()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("LIQ_NUMERO");
        dtGetDatae.Columns.Add("ANT_CODIGO");
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("RUC");
        dtGetDatae.Columns.Add("PROVEEDOR");
        dtGetDatae.Columns.Add("FECHA_EMISION");
        dtGetDatae.Columns.Add("FECHA_REG");
        dtGetDatae.Columns.Add("MONEDA");
        dtGetDatae.Columns.Add("MONTOTOTAL");
        dtGetDatae.Columns.Add("PORCENTAJE");
        dtGetDatae.Columns.Add("ANTICIPO");
        dtGetDatae.Columns.Add("PAGADO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("FACTURA");
        dtGetDatae.Columns.Add("MONTO");
        dtGetDatae.Columns.Add("ANTICIPO");
        dtGetDatae.Columns.Add("MONTO_A");
        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }

    //ListarLiquidaciones
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_liquidacion> ListarLiquidaciones(tabla_anticipo VC)

    {
        return TABLA_LIQUIDACION_ANTICIPO.ListarSA(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVC> getordenes(string productos)
    {
        return CO0003MOVC.Listarordenautocomplete(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalleliquidacion> ListarDetalle(DETALLE_LIQUIDACION VC)
     {
        return DETALLE_LIQUIDACION.ListarDL(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string traerorden(string solicitud)
    {
        return tabla_anticipo.traerordencompra(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(TABLA_LIQUIDACION_ANTICIPO DETA)
    {
        TABLA_LIQUIDACION_ANTICIPO.insertaLiquidacion(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaLiquidacion(TABLA_LIQUIDACION_ANTICIPO DETA)
    {
        TABLA_LIQUIDACION_ANTICIPO.actualizaLiquidacion(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud)
    {
        return TABLA_LIQUIDACION_ANTICIPO.GeneraNroLiquidacion(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static tabla_anticipo DatosSolicitud(string dato)
    {
        return TABLA_LIQUIDACION_ANTICIPO.ListarDatosAnticipoID(dato);
        
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<CO0003MOVC> getordenes(string productos)
    //{
    //    return CO0003MOVC.Listarordenautocomplete(productos);
    //}

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_anticipo> AnticipoOrden(string dato, string ant)
    {
        return TABLA_LIQUIDACION_ANTICIPO.ListarDatosAnticipoPorOreden(dato,ant);

    }
    //ListarDatosAnticipoPorOreden


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void deleteDet(DETALLE_LIQUIDACION DETA)
    {
        DETALLE_LIQUIDACION.EliminaItems(DETA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDetalle(DETALLE_LIQUIDACION DETAIL)
    {
        DETALLE_LIQUIDACION.insertaItem(DETAIL);
    }

    // para actualizar el estado a liquidado en la tabla solicitud de anticipo
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaSolicitud(tabla_anticipo solicitud)
    {
        tabla_anticipo.ActualizarEstado(solicitud);
    }

    
}




