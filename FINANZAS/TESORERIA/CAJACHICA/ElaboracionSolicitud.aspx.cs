﻿using System;
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

public partial class FINANZAS_TESORERIA_CAJA_CHICA_ElaboracionSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaini.Text = "01/" + (DateTime.Now.Month < 10 ? "0" + DateTime.Now.Month : "" + DateTime.Now.Month) + "/" + DateTime.Now.Year;
            txtfechafin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaemision.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechavmto.Text = DateTime.Now.ToString("dd/MM/yyyy");
            vergrid();
            detalle2();
            INICIO();
            validarusuario();

            tabla_cajas are = new tabla_cajas();
            are.USUARIO = lblusuario.Text;
            are.TIPO = 1;
            ddltipoentrega.Items.Clear();
            ddltipoentrega.DataTextField = "USUARIO";
            ddltipoentrega.DataValueField = "CODIGO_CAJA";
            ddltipoentrega.DataSource = tabla_cajas.listarCajas(are);
            ddltipoentrega.DataBind();
            ddltipoentrega.Items.Insert(0, new ListItem("SELECCIONE", ""));

            tabla_parametros pare = new tabla_parametros();
            pare.AF_COD = "CS";
            ddldocumento.Items.Clear();
            ddldocumento.DataTextField = "TDESCRI";
            ddldocumento.DataValueField = "TCLAVE";
            ddldocumento.DataSource = tabla_parametros.ComprobantesRendicion(pare);
            ddldocumento.DataBind();

            pare.AF_COD = "AC";
            ddloarea.Items.Clear();
            ddloarea.DataTextField = "TG_CDESCRI";
            ddloarea.DataValueField = "TG_CCLAVE";
            ddloarea.DataSource = tabla_parametros.areasrendicion(pare);
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

        }

    }
    public void validarusuario()
    {
        tabla_parametros a = new tabla_parametros();
        //a.AF_COD = "UC";
        //a.AF_TDESCRI1 = lblusuario.Text;
        lbltipo.Text = tabla_parametros.ListarParametroDescr1("UC",lblusuario.Text);
      
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
    public static List<tabla_cajas> listarCajas(tabla_cajas PDATA)
    {
        return tabla_cajas.listarCajas(PDATA);
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> LISTARVARIOSED(CT0003TAGE TABG)
    {
        return CT0003TAGE.LISTARVARIOSED(TABG);
    }
    public void INICIO()
    {
        tabla_oer a = new tabla_oer();
        a.ORDEN_NUMERO = txtnumerob.Text;
        a.COD_SOLICITANTE = txtcodsolicitanteb.Text;
        a.COD_BANCO = txtcodbancob.Text;
        a.FECHA = Convert.ToDateTime(txtfechaini.Text);
        a.FECHA_CREACION = Convert.ToDateTime(txtfechafin.Text);
        a.CODIGO_CAJA = 1;
        a.ESTADO = ddlestado.Text;
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
        a.CODIGO_CAJA = 1;
        a.ESTADO = ddlestado.Text;
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> anexor(CT0003ANEX DTA)
    {
        return CT0003ANEX.anexor(DTA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean insertaoerD(tabla_detalle_oer datos)
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
    public static List<AL0003TABL> GETVARIOSCENCOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string ObtenerSubdiario(tabla_parametros PDATA)
    {
        return tabla_parametros.ObtenerSubdiario(PDATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_detalle_oer> ListarTodos(tabla_detalle_oer com)
    {
        return tabla_detalle_oer.ListarTodos(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Elimina(tabla_detalle_oer CCAB)
    {
        tabla_detalle_oer.Elimina(CCAB);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_detalle_oer> ListarUnItem(tabla_detalle_oer com)
    {
        return tabla_detalle_oer.ListarUnItem(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizarEstado(tabla_oer COM)
    {
        tabla_oer.ActualizarEstado(COM);
    }

}