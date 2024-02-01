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

public partial class FINANZAS_TESORERIA_RENDICIONES_ComprobantesCompras : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            txtfechaemision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechavmto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaini.Text = "01/" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : "" + DateTime.Now.Month) + "/" + DateTime.Now.Year;
            txtfechafin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            vergrid();
            INICIO();
            detalle2();

            tabla_parametros are = new tabla_parametros();
            are.AF_COD = "CS";
            ddldocumento.Items.Clear();
            ddldocumento.DataTextField = "TDESCRI";
            ddldocumento.DataValueField = "TCLAVE";
            ddldocumento.DataSource = tabla_parametros.ComprobantesRendicion(are);
            ddldocumento.DataBind();
         
            are.AF_COD = "AC";
            ddloarea.Items.Clear();
            ddloarea.DataTextField = "TG_CDESCRI";
            ddloarea.DataValueField = "TG_CCLAVE";
            ddloarea.DataSource = tabla_parametros.areasrendicion(are);
            ddloarea.DataBind();
            ddloarea.Items.Insert(0, new ListItem("[SELECCIONAR]", ""));

            CT0003TAGE tage = new CT0003TAGE();
            tage.TCOD = "S1";
            ddlmedpag.Items.Clear();
            ddlmedpag.DataTextField = "TDESCRI";
            ddlmedpag.DataValueField = "TCLAVE";
            ddlmedpag.DataSource = CT0003TAGE.LISTARVARIOSED(tage);
            ddlmedpag.DataBind();
            ddlmedpag.Items.Insert(0, new ListItem("", ""));

            //are.TCOD = "53";
            //are.TCLAVE = "CTA";
            //ddlcodigocompra.Items.Clear();
            //ddlcodigocompra.DataTextField = "TDESCRI";
            //ddlcodigocompra.DataValueField = "TCLAVE";
            //ddlcodigocompra.DataSource = CT0003TAGE.listarSubCta(are);
            //ddlcodigocompra.DataBind();

            //are.TCOD = "53";
            //are.TCLAVE = "SUB";
            //ddlsubdiario.Items.Clear();
            //ddlsubdiario.DataTextField = "TDESCRI";
            //ddlsubdiario.DataValueField = "TCLAVE";
            //ddlsubdiario.DataSource = CT0003TAGE.listarSubCta(are);
            //ddlsubdiario.DataBind();

            //ddlareaa.Items.Clear();
            //ddlareaa.DataTextField = "TDESCRI";
            //ddlareaa.DataValueField = "TCLAVE";
            //ddlareaa.DataSource = CT0003TAGE.LISTARAREASED();
            //ddlareaa.DataBind();
            //ddlareaa.Items.Add("");

            //CT0003TABL ane = new CT0003TABL();
            //ane.TCOD = "17";
            //ddltipodeconversion.Items.Clear();
            //ddltipodeconversion.DataTextField = "TDESCRI";
            //ddltipodeconversion.DataValueField = "TCLAVE";
            //ddltipodeconversion.DataSource = CT0003TABL.ListarTabla(ane);
            //ddltipodeconversion.DataBind();

        }
        

    }
    public void vergrid()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ORDEN_NUMERO");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("SOLICITANTE");
        dtGetDatae.Columns.Add("COD_SOLICITANTE");
        dtGetDatae.Columns.Add("MOTIVO");
        dtGetDatae.Columns.Add("MONEDA");
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ConsultaUnaCuenta(string descri)
    {
       return CT0003PLEM.ConsultaUnaCuenta(descri);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> cuentasrendicion(tabla_parametros DATA)
    {
        return tabla_parametros.cuentasrendicion(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> anexor(CT0003ANEX DTA)
    {
        return CT0003ANEX.anexor(DTA);
    }
    public void INICIO()
    {
        tabla_oer a = new tabla_oer();
        a.ORDEN_NUMERO = txtnumerob.Text;
        a.COD_SOLICITANTE = txtcodsolicitanteb.Text;
        a.COD_BANCO = txtcodbancob.Text;
        a.FECHA = Convert.ToDateTime(txtfechaini.Text);
        a.FECHA_CREACION = Convert.ToDateTime(txtfechafin.Text);
        a.ESTADO = "A";
        GridView1.DataSource = tabla_oer.ListarOER(a);
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
        a.ORDEN_NUMERO = txtnumerob.Text;
        a.COD_SOLICITANTE = txtcodsolicitanteb.Text;
        a.COD_BANCO = txtcodbancob.Text;
        a.FECHA = Convert.ToDateTime(txtfechaini.Text);
        a.FECHA_CREACION = Convert.ToDateTime(txtfechafin.Text);
        a.ESTADO = "A";
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
    public static List<vista_oer_> ListarOER(tabla_oer CODATA)
    {
        return tabla_oer.ListarOER(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedoresid(string productos)
    {
        return CT0003ANEX.ListarProveedoresid(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean insertaoer(tabla_detalle_oer datos)
    {
        return tabla_detalle_oer.INSERTAR(datos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean actualiza(tabla_detalle_oer datos)
    {
        return tabla_detalle_oer.actualizaSolicitud(datos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_detalle_oer> ListarTodos(tabla_detalle_oer com)
    {
        return tabla_detalle_oer.ListarTodos(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_detalle_oer> ListarUnItem(tabla_detalle_oer com)
    {
        return tabla_detalle_oer.ListarUnItem(com);
    }
    public void detalle2()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("RUC");
        dtGetDatae.Columns.Add("PROVEEDOR");
        dtGetDatae.Columns.Add("TIPO_DOCUMENTO");
        dtGetDatae.Columns.Add("NUMERO_DOCUMENTO");
        dtGetDatae.Columns.Add("FECHA_EMISION");
        dtGetDatae.Columns.Add("MONTO_IGV");
        dtGetDatae.Columns.Add("IGV");
        dtGetDatae.Columns.Add("PARCIAL");
        dtGetDatae.Columns.Add("TOTAL");
        dtGetDatae.Columns.Add("MOTIVO");
        dtGetDatae.Rows.Add();
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Elimina(tabla_detalle_oer CCAB)
    {
        tabla_detalle_oer.Elimina(CCAB);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizarEstado(tabla_oer COM)
    {
        tabla_oer.ActualizarEstado(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOSCENCOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> LISTARVARIOSED(CT0003TAGE TABG)
    {
        return CT0003TAGE.LISTARVARIOSED(TABG);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string ObtenerSubdiario(tabla_parametros PDATA)
    {
        return tabla_parametros.ObtenerSubdiario(PDATA);
    }

    }