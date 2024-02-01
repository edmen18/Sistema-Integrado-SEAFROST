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

public partial class FINANZAS_TESORERIA_RENDICIONES_Sub11 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    { 
    if (!Page.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            txtfechaini.Text = "01/" + (DateTime.Now.Month< 10 ? "0" + DateTime.Now.Month : "" + DateTime.Now.Month) + "/" + DateTime.Now.Year;
            txtfechafin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaactual.Text = DateTime.Now.ToString("dd/MM/yyyy");
            vergrid();
            INICIO();
            detalle2();
            asiento();
        }
    }
    public void vergrid()
{
    DataTable dtGetDatae = new DataTable();
    dtGetDatae.Columns.Add("ORDEN_NUMERO");
    dtGetDatae.Columns.Add("FECHA");
    dtGetDatae.Columns.Add("SOLICITANTE");
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
    a.ESTADO = "L";
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
    a.ESTADO = "L";
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
    dtGetDatae.Columns.Add("ESTADO");
    dtGetDatae.Rows.Add();
    GridView2.DataSource = dtGetDatae;
    GridView2.DataBind();
}

    public void asiento()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SUBDIARIO");
        dtGetDatae.Columns.Add("CUENTA");
        dtGetDatae.Columns.Add("CENTRODECOSTO");
        dtGetDatae.Columns.Add("DDHH");
        dtGetDatae.Columns.Add("SOLES");
        dtGetDatae.Columns.Add("DOLARES");
        dtGetDatae.Columns.Add("TIP.DOC");
        dtGetDatae.Columns.Add("NUM.DOC");
        dtGetDatae.Rows.Add();
        gvasiento.DataSource = dtGetDatae;
        gvasiento.DataBind();
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA).OrderBy(X=>X.AF_CCLAVE).ToList();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListaPlanIDE(string PDATA)
    {
        return CT0003PLEM.ListaPlanIDE(PDATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CTCAMB> obetenertcambiocvEdgar(CTCAMB COM)
    {
        return CTCAMB.obetenertcambiocvEdgar(COM);
    }

    /// <summary>
    /// INSERTAR EN EL DETALLE DE COMPROBANTE.
    /// </summary>
    /// <param name="DETA"></param>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertDetComprobante(CT0003COMD16 DETA)
    {
        CT0003COMD16.insertaDetalle(DETA);
    }
    /// <summary>
    /// ACTUALIZA NUMERACION.
    /// </summary>
    /// <param name="DETA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean Numeracion(CT0003NUME16 DETA)
    {
        return CT0003NUME16.Numeracion(DETA);
    }
    /// <summary>
    /// INSERTA BALH16.
    /// </summary>
    /// <param name="DETA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ActualizarBalh(CT0003BALH16 DETA)
    {
        return CT0003BALH16.actualizar(DETA);
    }
    /// <summary>
    /// INSERTA CABECERA COMPROBANTE.
    /// </summary>
    /// <param name="DETA"></param>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertCabComprobante(CT0003COMC16 DETA)
    {
        CT0003COMC16.insertaCabecera(DETA);
    }

    /// <summary>EDGAR MENDOZA MENDIVES
    /// PARA GENERAR EL NUMERO DE COMPROBANTE DE LA TABLA NUMERACION.
    /// </summary> CREADO EL 06/08/2016 A LAS 12:07 P.M.
    /// <param name="DATA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void CambiarEstado(tabla_detalle_oer COM)
    {
        tabla_detalle_oer.CambiarEstado(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ACTUALIZACOST(CT0003COST16 DETA)
    {
        return CT0003COST16.actualizar(DETA);
    }

}