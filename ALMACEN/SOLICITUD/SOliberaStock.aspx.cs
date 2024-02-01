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
            ListaMovi();
       

            ddlfilt.DataTextField = "A1_CDESCRI";
            ddlfilt.DataValueField ="A1_CALMA";
            ddlfilt.DataSource =AL0003ALMA.ListarAlmacen();
            ddlfilt.DataBind();
        }
    }

    public void ListaMovi() 
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SS_CCODIGO");
        dtGetDatae.Columns.Add("SS_ALMACEN");
        dtGetDatae.Columns.Add("SS_SOLICITAN");
        dtGetDatae.Columns.Add("SS_LOTES");
        dtGetDatae.Columns.Add("SS_CANTID");
        dtGetDatae.Columns.Add("SS_DESPROD");
        dtGetDatae.Rows.Add();
        gvsolicitudes.DataSource = dtGetDatae;
        gvsolicitudes.DataBind();
    }





   
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void enviofinalemail(string idusuario,string idprod)
    {
        List<string> fiche = new List<string>();
        AL0003ARTI mostrarprod = new AL0003ARTI();
        mostrarprod  = AL0003ARTI.obtenerArticuloPorID(idprod);
        string informa = "<html><body> <table style='font-size:12px;background-color:White;border-color:#CCCCCC;width:800px;font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif' border='1' cellpadding='1' cellspacing='1'><tr><td colspan='2' align='center' bgcolor='#7ACAFF'> <b>" + "SERVICIO" + "</b></td></tr><tr><td colspan='2' align='center' bgcolor='#FFCC99'>" + mostrarprod.AR_CDESCRI + "</td></tr><tr><td>" + " PROVEEDOR: " + "</td><td>" + CT0003ANEX.obtenProveedor(mostrarprod.AR_CCODPRO.Trim()).ADESANE+ "</td></tr><tr><td>" + " TARIFA: " + "</td><td>" + Convert.ToDecimal(string.Format("{0:00.0000}", mostrarprod.AR_NPRECOM)) + "</td></tr><tr><td>" 
                + " AREA: " + "</td><td>" + tabla_subareas.Listarsubareas().Where(a=>a.SA_ID.ToString()== mostrarprod.AR_CPARARA).First().SA_DESC + "</td></tr><tr><td>" + " MONEDA: " + "</td><td>" + mostrarprod.AR_CMONCOM.Trim() + "</td></tr><tr><td>" + " TIPO:" + "</td><td>" + mostrarprod.AR_CTIPDES + "</td></tr><tr><td>" + " USUARIO: " + "</td><td>" + UT0030.Mostrarunusuario(mostrarprod.AR_CUSUCRE) + "</td></tr></table></body></html>";

        var enviousuaxarea = UT0030.ListarUsuariosxF(); 
        foreach (var d in enviousuaxarea)
        {
            if (d.TU_CORREO.Trim() != "" || d.TU_CORREO != null)
            {
                Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "APROBACION FINAL DE SERVICIO", d.TU_CORREO, "", "programador1@seafrost.com.pe", fiche);
            }
        }
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<vista_stockxs> stockxalmacen(vista_stockxs ADATA)
    {
        return tabla_stockxsoli.ListaStockxAlmacen(ADATA); 
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void InsertastockS(tabla_stockxsoli ADATA)
    {
        tabla_stockxsoli.InsActStockxSolic(ADATA);
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Nvalidaususol(tabla_d_ususol ADATA)
    {
        return tabla_d_ususol.Validausuasoli(ADATA).Count();
    }

    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void actualizaStocknuevo(tabla_stockxsoli ADATA)
    {
        tabla_stockxsoli.ActualizaStockS(ADATA);
    }






}