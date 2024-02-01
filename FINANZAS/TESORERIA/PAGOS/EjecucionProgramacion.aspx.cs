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
public partial class FINANZAS_TESORERIA_PAGOS_EjecucionProgramacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtfechatransaccion.Text = DateTime.Now.ToString("dd/MM/yyyy");
            rbdia.Checked = true;
            rbmes.Checked = false;
            inicio();
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            vergrilla();
            vergrilla1();

            CT0003AGEN area = new CT0003AGEN();
            ddlagencia.Items.Clear();
            ddlagencia.DataTextField = "AG_CNOMAGE";
            ddlagencia.DataValueField = "AG_CCODAGE";
            ddlagencia.DataSource = CT0003AGEN.ListarAgencia();
            ddlagencia.DataBind();
            ddlagencia.Items.Insert(0, new ListItem("[AGENCIAS]", "-1"));


            CP0003CUBA BAN = new CP0003CUBA();
            ddlbanco.Items.Clear();
            ddlbanco.DataTextField = "CT_CDESCTA";
            ddlbanco.DataValueField = "CT_CNUMCTA";
            ddlbanco.DataSource = CP0003CUBA.ListarBancos();
            ddlbanco.DataBind();
            ddlbanco.Items.Insert(0, new ListItem("[BANCOS]", "-1"));



            CP0003TABL TIPOPAGO = new CP0003TABL();
            TIPOPAGO.TG_INDICE = "60";
            ddltipopago.Items.Clear();
            ddltipopago.DataTextField = "TG_DESCRI";
            ddltipopago.DataValueField = "TG_CODIGO";
            ddltipopago.DataSource = CP0003TABL.ListarTablaS(TIPOPAGO);
            ddltipopago.DataBind();
            ddltipopago.Items.Insert(0, new ListItem("[TIPOPAGO]", "-1"));



            CP0003TABL DEPARTAMENTO = new CP0003TABL();
            DEPARTAMENTO.TG_INDICE = "90";
            ddldepartamento.Items.Clear();
            ddldepartamento.DataTextField = "TG_DESCRI";
            ddldepartamento.DataValueField = "TG_CODIGO";
            ddldepartamento.DataSource = CP0003TABL.ListarTabla(DEPARTAMENTO);
            ddldepartamento.DataBind();
            ddldepartamento.Items.Insert(0, new ListItem("[DEPARTAMENTO]", "-1"));


            CP0003COPR CONCEPTO = new CP0003COPR();
            ddlconcepto.Items.Clear();
            ddlconcepto.DataTextField = "CG_CCONCEP";
            ddlconcepto.DataValueField = "CG_CCODCON";
            ddlconcepto.DataSource = CP0003COPR.ListarTodos();
            ddlconcepto.DataBind();
            ddlconcepto.Items.Insert(0, new ListItem("[CONCEPTO]", "-1"));

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
            ddlsubdiario.DataSource = CT0003TAGE.LISTARSUBDIARIOED("22");
            ddlsubdiario.DataBind();
            //ddlsubdiario.Items.Insert(0, new ListItem("[SUBDIARIO]", "-1"));

            ddlmediopago.Items.Clear();
            ddlmediopago.DataTextField = "TDESCRI";
            ddlmediopago.DataValueField = "TCLAVE";
            ddlmediopago.DataSource = CT0003TAGE.LISTARMEDIOPAGOED("001","004");
            ddlmediopago.DataBind();
           // ddlmediopago.Items.Insert(0, new ListItem("[MEDIO PAGO]", "-1"));

            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtmes.Text = Convert.ToString(DateTime.Now.Month);
            txtannio.Text = Convert.ToString(DateTime.Now.Year);
            ListaDetalle();
        }
    }
    public void VERGRILLAPRINCIPAL()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("GC_CCODAGE");
        dtGetDatae.Columns.Add("GC_CNUMOPE");
        dtGetDatae.Columns.Add("GC_CUSUCRE");
        dtGetDatae.Columns.Add("GC_CCODCON");
        dtGetDatae.Columns.Add("GC_CTIPPAG");
        dtGetDatae.Columns.Add("GC_CCODBAN");
        dtGetDatae.Columns.Add("GC_CCODMON");
        dtGetDatae.Columns.Add("GC_NMONPRO");
        dtGetDatae.Columns.Add("GC_CESTADO");

        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    protected void btnfiltro_Click(object sender, EventArgs e)
    {
        CP0003PRGC PROGRAMACION = new CP0003PRGC();
        PROGRAMACION.GC_CCODAGE = ddlagencia.Text;
        PROGRAMACION.GC_CCODBAN = ddlbanco.Text;
        PROGRAMACION.GC_CTIPPAG = ddltipopago.Text;
        PROGRAMACION.GC_CCODDEP = ddldepartamento.Text;
        PROGRAMACION.GC_CCODCON = ddlconcepto.Text;
        PROGRAMACION.GC_CESTADO = "A";
        VERGRILLAPRINCIPAL();

        if (rbdia.Checked)
        {
            if (this.txtfecha.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar una fecha válida"), false);
            }
            else
            {
                PROGRAMACION.GC_DFECPRO = Convert.ToDateTime(this.txtfecha.Text);
                if (gvordencompra.Rows.Count > 0)
                {
                    gvordencompra.UseAccessibleHeader = true;
                    gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSFILTROP(PROGRAMACION);
                    gvordencompra.DataBind();
                }
            }

        }
        if (rbmes.Checked)
        {
            if ((this.txtannio.Text == "") && (this.txtmes.Text == ""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar un mes y un año válidos"), false);
            }
            else
            {
                PROGRAMACION.GC_NMONPRO = Convert.ToDecimal(this.txtannio.Text);
                PROGRAMACION.GC_NTIPCAM = Convert.ToDecimal(this.txtmes.Text);
                if (gvordencompra.Rows.Count > 0)
                {
                    gvordencompra.UseAccessibleHeader = true;
                    gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSFILTROP(PROGRAMACION);
                    gvordencompra.DataBind();
                }
            }
        }
        if (!rbmes.Checked && !rbdia.Checked)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe seleccionar una opcion de la parte superior referente a la fecha"), false);
        }
    }
    public void vergrilla()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("GD_CVANEXO");
        dtGetDatae.Columns.Add("GD_CCODIGO");
        dtGetDatae.Columns.Add("GD_CNDREF");
        dtGetDatae.Columns.Add("GD_CTIPDOC");
        dtGetDatae.Columns.Add("GD_CNUMDOC");
        dtGetDatae.Columns.Add("GD_DFECDOC");
        dtGetDatae.Columns.Add("GD_DFECVEN");
        dtGetDatae.Columns.Add("GD_CMONCAR");
        dtGetDatae.Columns.Add("GD_NORPROG");
        dtGetDatae.Columns.Add("GD_NORRETE");
        dtGetDatae.Columns.Add("GD_CRETE");
        dtGetDatae.Columns.Add("GD_NMNPROG");
        dtGetDatae.Columns.Add("GD_CTASDET");

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
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }
    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CUENTA");
        dtGetDatae.Columns.Add("DDH");
        dtGetDatae.Columns.Add("DIMPORT");
        dtGetDatae.Columns.Add("GLOSA");
        dtGetDatae.Columns.Add("DUSIMPORT");
        dtGetDatae.Columns.Add("DMNIMPOR");
        dtGetDatae.Rows.Add();
        GridView3.DataSource = dtGetDatae;
        GridView3.DataBind();
    }

    public void inicio()
    {
        CP0003PRGC PROGRAMACION = new CP0003PRGC();

        PROGRAMACION.GC_CESTADO = "A";

        gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSP(PROGRAMACION);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
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
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);
      
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CTCAMB> obetenertcambiocvEdgar(CTCAMB COM)
    {
        return CTCAMB.obetenertcambiocvEdgar(COM);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string INCONSISTENCIACUENTADET(CP0003MAES ADATA)
    {
        return CP0003MAES.INCONSISTENCIACUENTADET(ADATA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003PRGD> LISTARTTODOS(string dato)
    {
        return CP0003PRGD.LISTARTTODOS(dato);
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<CP0003CART> filtrodetalle(string dato)
    //{
    //    return CP0003CART.SELECTDETALLES(dato);
    //}
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_programacion> LISTARUNO(string CODATA)
    {
        return CP0003PRGC.LISTARUNO(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_CP0003PRGC> EXTRAERPARAINSERTARCAB(string CODATA)
    {
        return CP0003PRGC.EXTRAERPARAINSERTAR(CODATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_CP0003PRGD> EXTRAERPARAINSERTARDET(string CODATA)
    {
        return CP0003PRGD.EXTRAERPARAINSERTAR(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> datoscompletarejed(CP0003EJED CODATA)
    {
        return CP0003CART.consultadatosparaejecucion(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR()
    {
        return CT0003COMC16.GeneraNroSolicitud();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(CP0003EJEC DETA)
    {
        CP0003EJEC.insertar(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaPago(CP0003PAGO DETA)
    {
        CP0003PAGO.insertaCabecera(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDetalle(CP0003EJED DETA)
    {
        CP0003EJED.insertar(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERARLOTE()
    {
        return CP0003EJEC.GenerarNumLote();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string CORRELATIVO(CP0003PAGO ADATA)
    {
        return CP0003PAGO.correlativoPG(ADATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertDetComprobante(CT0003COMD16 DETA)
    {
        CT0003COMD16.insertaDetalleEdgar(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertCabComprobante(CT0003COMC16 DETA)
    {
        CT0003COMC16.insertaCabecera(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003MAES> datoscompletardetcomprobante(CP0003EJED CODATA)
    {
        return CP0003MAES.ListarMaestroDescr(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean Numeracion(CT0003NUME16 DETA)
    {
     return  CT0003NUME16.Numeracion(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizarsaldoENEJECUCION(CP0003CART DETA)
    {
        CP0003CART.actualizarsaldoENEJECUCION(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaItemsC(CP0003PRGC DETA)
    {
        CP0003PRGC.EliminaItems(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaItemsD(CP0003PRGD DETA)
    {
        CP0003PRGD.EliminaItems(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_PREVIA_INSERCION_BALH> LISTARPARABALH(CT0003COMD16 CODATA)
    {
        return CT0003COMD16.DETALLE(CODATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ActualizarBalh(CT0003BALH16 DETA)
    {
        return CT0003BALH16.actualizar(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }
}


