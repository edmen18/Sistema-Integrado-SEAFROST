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

public partial class FINANZAS_TESORERIA_CHEQUES_EmisionCheques : System.Web.UI.Page
{
  
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblusuario.Text = Convert.ToString(Session["codusu"]);
            VERGRILLA();
            VERGRILLA2();
            VERGRILLA3();
            vergrilla1();
            vergrilladet();
            inicio();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CT0003TAGE are = new CT0003TAGE();
            ddlarea.Items.Clear();
            ddlarea.DataTextField = "TDESCRI";
            ddlarea.DataValueField = "TCLAVE";
            ddlarea.DataSource = CT0003TAGE.LISTARAREASED();
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("[area]", "-1"));

            ddlsubdiario.Items.Clear();
            ddlsubdiario.DataTextField = "TDESCRI";
            ddlsubdiario.DataValueField = "TCLAVE";
            ddlsubdiario.DataSource = CT0003TAGE.LISTARSUBDIARIOED("23");
            ddlsubdiario.DataBind();
          
            ddlmediopago.Items.Clear();
            ddlmediopago.DataTextField = "TDESCRI";
            ddlmediopago.DataValueField = "TCLAVE";
            ddlmediopago.DataSource = CT0003TAGE.LISTARMEDIOPAGOED("001","007");
            ddlmediopago.DataBind();
            lblcuentapago.Text = CT0003PLEM.ListarCtaE("FACTURAS EMITIDAS POR PAGAR M.N. TERCEROS").Select(x => x.PCUENTA).FirstOrDefault();
            lblcuentapagodol.Text = CT0003PLEM.ListarCtaE("FACTURAS EMITIDAS POR PAGAR M.E. TERCEROS").Select(x => x.PCUENTA).FirstOrDefault();
            lblcuentaretencion.Text = CT0003PLEM.ListarCtaE("IGV - REGIMEN DE RETENCIONES POR PAGAR").Select(x => x.PCUENTA).FirstOrDefault();
        }
        }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListaPlanID(string PDATA)
    {
        return CT0003PLEM.ListaPlanIDE(PDATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CUBA ListarDatosBancoID(string ban)
    {
        return CP0003CUBA.ListarDatosBancoID(ban);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> filtrodetalle(CP0003CART VC)
    {
        return CP0003CART.SELECTDETALLESCHEQUES(VC).OrderBy(x=>x.CP_CNUMDOC).ToList();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> ListarBancosProg(string productos)
    {
        return CP0003CUBA.ListarBancosProg(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CTCAMB> obetenertcambiocvEdgar(CTCAMB COM)
    {
        return CTCAMB.obetenertcambiocvEdgar(COM);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003MAES listarMaestroxunID(CP0003MAES ADATA)
    {
        return CP0003MAES.listarMaestroxunID(ADATA);
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    public void vergrilladet()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CUENTA");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("SUMASOLESDEBE");
        dtGetDatae.Columns.Add("SUMASOLESHABER");
        dtGetDatae.Columns.Add("SUMADOLARESDEBE");
        dtGetDatae.Columns.Add("SUMADOLARESHABER");
        dtGetDatae.Columns.Add("TIPODOPC");
        dtGetDatae.Rows.Add();
        GridView5.DataSource = dtGetDatae;
        GridView5.DataBind();
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("Ane");
        dtGetDatae.Columns.Add("Codigo");
        dtGetDatae.Columns.Add("Acreedor");
        dtGetDatae.Columns.Add("Tipo");
        dtGetDatae.Columns.Add("Direccion");
        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }
    public void vergrilla1()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CUENTA");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("SUMASOLESDEBE");
        dtGetDatae.Columns.Add("SUMASOLESHABER");
        dtGetDatae.Columns.Add("SUMADOLARESDEBE");
        dtGetDatae.Columns.Add("SUMADOLARESHABER");
        dtGetDatae.Columns.Add("TIPODOPC");
        dtGetDatae.Rows.Add();
        GridView4.DataSource = dtGetDatae;
        GridView4.DataBind();
    }
    public void VERGRILLA2()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CTIPDOC");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_DFECDOC");
        dtGetDatae.Columns.Add("CP_DFECVEN");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NIMPOMN");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("");
        dtGetDatae.Columns.Add("CP_CRETE");
        dtGetDatae.Columns.Add("CP_NPORRE");
        dtGetDatae.Rows.Add();
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }
    public void VERGRILLA3()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("SEC");
        dtGetDatae.Columns.Add("CUENTA");
        dtGetDatae.Columns.Add("ANEXO");
        dtGetDatae.Columns.Add("COS");
        dtGetDatae.Columns.Add("F");
        dtGetDatae.Columns.Add("IMPORTE");
        dtGetDatae.Columns.Add("TP");
        dtGetDatae.Columns.Add("DOCMTO");
        dtGetDatae.Columns.Add("FEC DOC");
        dtGetDatae.Columns.Add("FEC VEN");
        dtGetDatae.Columns.Add("AREA");
        dtGetDatae.Rows.Add();
        GridView3.DataSource = dtGetDatae;
        GridView3.DataBind();
       }
    public void inicio()
    {
        GridView1.DataSource = CP0003CART.LISTARTOTALESCHEQUES().OrderBy(x=>x.Acreedor);
        GridView1.DataBind();

        if (GridView1.Rows.Count > 0)
        {
            GridView1.UseAccessibleHeader = true;
            GridView1.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// EXTRAER LOS DATOS DE LA TABLA DETALLE DE COMPROBANTE PARA INSERTARLOS EN LA TABLA BALH16
    /// </summary>>CREADO EL 06/08/2016 A LAS 11:30 AM.
    /// <param name="CODATA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_PREVIA_INSERCION_BALH> LISTARPARABALH(CT0003COMD16 CODATA)
    {
        return CT0003COMD16.DETALLE(CODATA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// UNA VEZ ESTRAIDOS LOS DATOS DE LA TABLA DETALLE COMPROBANTE, SE ACTUALIZAN LOS MONTOS EN LA TABLA BALH16.
    /// </summary>CREADO EL 06/08/2016 A LAS 11:30 AM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ActualizarBalh(CT0003BALH16 DETA)
    {
        return CT0003BALH16.actualizar(DETA);
    }
    /// <summary> EDGAR MENDOZA MENDIVES
    /// ACTUALIZAR EL SALDO A CERO EN LA TABLA CARTERA DE PAGO
    /// </summary>CREADO EL 06/08/2016 A LAS 11:34 AM.
    /// <param name="DETA"></param>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizarsaldoENEJECUCION(CP0003CART DETA)
    {
        CP0003CART.actualizarsaldoENEJECUCION(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// PARA GENERAR EL CORRELATIVO EN LA TABLA PAGO
    /// </summary>CREADO EL 06/08/2016 A LAS 11:36 AM.
    /// <param name="ADATA"></param>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string CORRELATIVO(CP0003PAGO ADATA)
    {
        return CP0003PAGO.correlativoPG(ADATA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// PARA INSERTAR EN LA TABLA DETALLE DE COMPROBANTE
    /// </summary>CREADO EL 06/08/2016 A LAS 11:36 AM.
    /// <param name="DETA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertDetComprobante(CT0003COMD16 DETA)
    {
        CT0003COMD16.insertaDetalleEdgar(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// PARA INSERTAR EN LA TABLA CABECERA DE COMPROBANTE
    /// </summary>CREADO EL 06/08/2016 A LAS 11:36 AM.
    /// <param name="DETA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertCabComprobante(CT0003COMC16 DETA)
    {
        CT0003COMC16.insertaCabecera(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// PARA INSERTAR EN LA TABLA PAGO.
    /// </summary>CREADO EL 06/08/2016 A LAS 11:39 AM.
    /// <param name="DETA"></param>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaPago(CP0003PAGO DETA)
    {
        CP0003PAGO.insertaCabecera(DETA);
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
    /// <summary> EDGAR MENDOZA MENDIVES
    /// PARA EXTRAER LOS DATOS DEL PROVEEDOR PRINCIPALMENTE EL NOMBRE PARA LA GLOSA DE LA TABLA PAGO
    /// </summary>CREADO EL 08/08/2016 A LAS 9:58 AM.
    /// <param name="CODATA"></param>
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> datoscompletardetcomprobante(CP0003EJED CODATA)
    {
        return CP0003MAES.ListarMaestroDescr(CODATA);
    }
    /// <summary>
    /// EDGAR MENDOZA MENDIVES
    /// </summary>EXTRAER LOS DATOS DE LAS CUENTAS DE LA TABLA PARAMETROS
    /// <param name="PDATA"></param> CREADO EL 09/08/2016 A LAS 01:15 P.M.
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }
    /// <summary>
    /// EDGAR MENDOZA MENDIVES
    /// </summary>INSERTAR EN LA TABLA CHEQUE
    /// <param name="DETA"></param> CREADO EL 09/08/2016 A LAS 05:11 P.M.
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaCheques(CP0003CHEQ DETA)
    {
        CP0003CHEQ.insertaCabecera(DETA);
    }
    /// <summary>
    /// EDGAR MENDOZA MENDIVES
    /// </summary>ACTUALIZAR EL NUMERO DE COMPROBANTE EN LA TABLA NUMERACION 16
    /// <param name="DETA"></param>CREADO EL 09/08/2016 A LAS 06:27 P.M.
    /// <returns></returns>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean Numeracion(CT0003NUME16 DETA)
    {
        return CT0003NUME16.Numeracion(DETA);
    }
    /// <summary>
    /// EDGAR MENDOZA MENDIVES
    /// </summary> ACTUALIZACIÓN DEL CAMPO NUMERO DE CHEQUERA (1 ,2 O 3) SEGUN LA SELECCION
    /// <param name="DETA"></param>CREADO EL 18/08/2016 A LAS 12:25 P.M.
    /// 
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaCheque(CP0003CUBA DETA)
    {
        CP0003CUBA.Actualizacheque(DETA);
    }

}