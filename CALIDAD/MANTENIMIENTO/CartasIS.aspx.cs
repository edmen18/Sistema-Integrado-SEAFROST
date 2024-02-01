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
        txtfinspeccion.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtfechaemision.Text = DateTime.Now.ToString("dd/MM/yyyy");

        ListaDetallepopup();
        lblusuario.Text = Convert.ToString(Session["codusu"]);
               
    }
    
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_CARTASIS> ListarSolicitudes(T_CALIDAD_CARTA_IS VC)
    {
        return T_CALIDAD_CARTA_IS.LISTARTTODOS(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_CARTASIS> traerdatos(VISTA_CARTASIS VC)
    {
        return T_CALIDAD_CARTA_IS.getdatos(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(T_CALIDAD_CARTA_IS DETA)
    {
        T_CALIDAD_CARTA_IS.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(T_CALIDAD_CARTA_IS DETA)
    {
        T_CALIDAD_CARTA_IS.actualizaSolicitud(DETA);
    }

    public void ListaDetallepopup()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("NUM_CARTA");
        dtGetDatae.Columns.Add("ORDEN_TRABAJO");
        dtGetDatae.Columns.Add("PARA");
        dtGetDatae.Columns.Add("DE");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("TIPO_ANALISIS");
        dtGetDatae.Columns.Add("TIPO_CERTIFICADO");
        dtGetDatae.Columns.Add("HABILITACION");
        dtGetDatae.Columns.Add("PRODUCTO");
        dtGetDatae.Columns.Add("ESPECIFICACION_INTERNA");
        dtGetDatae.Columns.Add("DESTINO");
        dtGetDatae.Columns.Add("LUGAR");
        dtGetDatae.Columns.Add("FECHA_INSPECCION");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_DESTINO> GETDESTINO(string CLAVE)
    {
        return T_CALIDAD_DESTINO.LISTARAUTOCOMPLETE(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_ENVASE> GETENVASE(string CLAVE)
    {
        return T_CALIDAD_ENVASE.LISTARAUTOCOMPLETE(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_PRODUCTO> GETPRODUCTO(string CLAVE)
    {
        return T_CALIDAD_PRODUCTO.LISTARAUTOCOMPLETE(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_TIPO_ANALISIS> GETTA(string CLAVE)
    {
        return T_CALIDAD_TIPO_ANALISIS.LISTARAUTOCOMPLETE(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_TIPO_CERTIFICADO> GETTC(string CLAVE)
    {
        return T_CALIDAD_TIPO_CERTIFICADO.LISTARAUTOCOMPLETE(CLAVE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud)
    {
        return T_CALIDAD_CARTA_IS.GeneraNroSolicitud(solicitud);
    }
}
