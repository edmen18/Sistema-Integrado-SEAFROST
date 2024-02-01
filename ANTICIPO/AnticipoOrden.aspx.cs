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
        ListaDetallepopup();

        lblusuario.Text = Convert.ToString(Session["codusu"]);

        txtfechaemision.Text = DateTime.Now.ToString("dd/MM/yyyy");
        txtfechaproceso.Text = DateTime.Now.ToString("dd/MM/yyyy");
       
        
        //llenar el combo bancos
        CP0003CUBA TABL = new CP0003CUBA();
        TABL.CT_CDESCTA = string.Empty;


        ddlbanco.Items.Clear();
        ddlbanco.DataTextField = "CT_CDESCTA";
        ddlbanco.DataValueField = "CT_CNUMCTA";
        ddlbanco.DataSource = CP0003CUBA.ListarTablaS(TABL);
        ddlbanco.DataBind();
        ddlbanco.Items.Insert(0, new ListItem("[BANCO]", "-1"));

    }


    public void ListaDetallepopup()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ANT_CODIGO");
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_CCODPRO");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_FECEMI");
        dtGetDatae.Columns.Add("OC_FECPRO");
        dtGetDatae.Columns.Add("OC_CODMON");
        dtGetDatae.Columns.Add("OC_MONTO_PEDIDO");
        dtGetDatae.Columns.Add("OC_PERCENTAJE");
        dtGetDatae.Columns.Add("OC_ANTICIPO");
        dtGetDatae.Columns.Add("OC_TOTAL_PAGAR");
        dtGetDatae.Columns.Add("MOTIVO");
        dtGetDatae.Columns.Add("APROBADO");
        //dtGetDatae.Columns.Add("OC_BANCO");
        //dtGetDatae.Columns.Add("CT_CDESCTA");
        //dtGetDatae.Columns.Add("BANCO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_solicitud> ListarSolicitudes(tabla_anticipo VC)

    {
        return tabla_anticipo.ListarSA(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_solicitud> sumaranticipos(tabla_anticipo VC)
        
    {
        return tabla_anticipo.SumarAnticipos(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    } 
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVC> getordenes(string productos)
    {
        return CO0003MOVC.Listarordenautocomplete(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CO0003MOVC datosproveedor(string dato)
    {
        return CO0003MOVC.ListarDatosOrdenID(dato);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CUBA datosbanco(string datos)
    {
        return CP0003CUBA.ListarDatosBancoID(datos);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(tabla_anticipo DETA)
    {
        tabla_anticipo.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void insertalog(tabla_log_anticipo DETA)
    {
        tabla_log_anticipo.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_anticipo DETA)
    {
        tabla_anticipo.actualizaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud )
    {
     return  tabla_anticipo.GeneraNroSolicitud(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string detraccion(string orden)
    {
        return tabla_anticipo.traerDetraccion(orden);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_solicitud> CONSULTAUNO(tabla_anticipo VC)
    {
        return tabla_log_anticipo.CONSULTAUNO(VC);
    }

}
