using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;
using ClosedXML.Excel;
using System.IO;
using System.Drawing;

public partial class FINANZAS_TESORERIA_RENDICIONES_SolicitudRendicion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaini.Text = "01/"+ (DateTime.Now.Month < 10? "0" + DateTime.Now.Month : ""+ DateTime.Now.Month) + "/" + DateTime.Now.Year;
            txtfechafin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            vergrid();
            INICIO();

            tabla_tipo_entrega are = new tabla_tipo_entrega();
            ddltipoentrega.Items.Clear();
            ddltipoentrega.DataTextField = "DESCRIPCION";
            ddltipoentrega.DataValueField = "CODIGO_TIPO";
            ddltipoentrega.DataSource = tabla_tipo_entrega.listar();
            ddltipoentrega.DataBind();
        
        }

    }
    public void vergrid()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ORDEN_NUMERO");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("SOLICITANTE");
        dtGetDatae.Columns.Add("MOTIVO");
        dtGetDatae.Columns.Add("MONTO");
        dtGetDatae.Columns.Add("ESTADO");
        dtGetDatae.Columns.Add("TIPO");
        dtGetDatae.Columns.Add("CODIGO_CAJA");
        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }
    public void INICIO()
    {
        tabla_oer a = new tabla_oer();
        a.FECHA = Convert.ToDateTime(txtfechaini.Text);
        a.FECHA_CREACION = Convert.ToDateTime(txtfechafin.Text);
        a.CODIGO_CAJA = 2;
        GridView1.DataSource = tabla_oer.ListarOERInicio(a);
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void btnver_Click(object sender, EventArgs e)
    {
        tabla_oer a = new tabla_oer();
        a.ORDEN_NUMERO=txtnumerob.Text;
        a.COD_SOLICITANTE = txtcodsolicitanteb.Text;
        a.COD_BANCO = txtcodbancob.Text;
        a.FECHA = Convert.ToDateTime(txtfechaini.Text);
        a.FECHA_CREACION = Convert.ToDateTime(txtfechafin.Text);
        a.ESTADO = ddlestado.Text;
        a.CODIGO_CAJA = 2;
        GridView1.DataSource = tabla_oer.ListarOER(a);
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> ListarBancosProg(string productos)
    {
        return CP0003CUBA.ListarBancosProg(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> ListarProveedoresporid(string cod, string texto, string i)
    {
        return CT0003ANEX.ListarProveedoresporid(cod, texto, i);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListarCtaE1(string descri, string moneda)
    {
        return CT0003PLEM.ListarCtaE11(descri, moneda);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(int codigo)
    {
        return tabla_oer.GeneraNroSolicitud(codigo);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean insertaoer(tabla_oer datos)
    {
       return tabla_oer.insertaCabecera(datos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_oer_> ListarOER(tabla_oer CODATA)
    {
        return tabla_oer.ListarOER(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean modificaoer(tabla_oer datos)
    {
        return tabla_oer.actualizaSolicitud(datos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_oer_> ListarUnDato(tabla_oer com)
    {
        return tabla_oer.ListarUnDato(com);

    }

   
}