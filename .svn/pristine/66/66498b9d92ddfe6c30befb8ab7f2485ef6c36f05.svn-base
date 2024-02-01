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

public partial class FINANZAS_TESORERIA_PAGOS_ProgramacionPagos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
           
            rbdia.Checked = true;
            rbmes.Checked = false;
            txtvencimiento1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtvencimiento2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechaprog.Text = DateTime.Now.ToString("dd/MM/yyyy");
            inicio();
            VERGRILLA();
            VERGRILLA2();
            VERGRILLA3();
            vergrilla();
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;
            ddlmoneda.Items.Clear();
            ddlmoneda.DataTextField = "TG_CDESCRI";
            ddlmoneda.DataValueField = "TG_CCLAVE";
            ddlmoneda.DataSource = AL0003TABL.Listarmonedasoles(TABL);
            ddlmoneda.DataBind();
           // ddlmoneda.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

            CT0003AGEN area = new CT0003AGEN();
            ddlagencia.Items.Clear();
            ddlagencia.DataTextField = "AG_CNOMAGE";
            ddlagencia.DataValueField = "AG_CCODAGE";
            ddlagencia.DataSource = CT0003AGEN.ListarAgencia();
            ddlagencia.DataBind();
            ddlagencia.Items.Insert(0, new ListItem("[AGENCIAS]", "-1"));

            ddlagencia0.Items.Clear();
            ddlagencia0.DataTextField = "AG_CNOMAGE";
            ddlagencia0.DataValueField = "AG_CCODAGE";
            ddlagencia0.DataSource = CT0003AGEN.ListarAgencia();
            ddlagencia0.DataBind();
           // ddlagencia0.Items.Insert(0, new ListItem("[AGENCIAS]", "-1"));

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

            ddltipopago0.Items.Clear();
            ddltipopago0.DataTextField = "TG_DESCRI";
            ddltipopago0.DataValueField = "TG_CODIGO";
            ddltipopago0.DataSource = CP0003TABL.ListarTablaS(TIPOPAGO);
            ddltipopago0.DataBind();
          
            CP0003TABL DEPARTAMENTO = new CP0003TABL();
            DEPARTAMENTO.TG_INDICE = "90";
            ddldepartamento.Items.Clear();
            ddldepartamento.DataTextField = "TG_DESCRI";
            ddldepartamento.DataValueField = "TG_CODIGO";
            ddldepartamento.DataSource = CP0003TABL.ListarTabla(DEPARTAMENTO);
            ddldepartamento.DataBind();
            ddldepartamento.Items.Insert(0, new ListItem("[DEPARTAMENTO]", "-1"));

            ddldepartamento0.Items.Clear();
            ddldepartamento0.DataTextField = "TG_DESCRI";
            ddldepartamento0.DataValueField = "TG_CODIGO";
            ddldepartamento0.DataSource = CP0003TABL.ListarTabla(DEPARTAMENTO);
            ddldepartamento0.DataBind();
            ddldepartamento0.Items.Insert(0, new ListItem("[DEPARTAMENTO]", "-1"));

            CP0003COPR CONCEPTO = new CP0003COPR();
            ddlconcepto.Items.Clear();
            ddlconcepto.DataTextField = "CG_CCONCEP";
            ddlconcepto.DataValueField = "CG_CCODCON";
            ddlconcepto.DataSource = CP0003COPR.ListarTodos();
            ddlconcepto.DataBind();
            ddlconcepto0.Items.Clear();
            ddlconcepto0.DataTextField = "CG_CCONCEP";
            ddlconcepto0.DataValueField = "CG_CCODCON";
            ddlconcepto0.DataSource = CP0003COPR.ListarTodos();
            ddlconcepto0.DataBind();
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtmes.Text = Convert.ToString(DateTime.Now.Month);
            txtannio.Text = Convert.ToString(DateTime.Now.Year);

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
        GridView4.DataSource = dtGetDatae;
        GridView4.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003TAGE> LISTARdetracciones(string productos)
    {
        return CT0003TAGE.LISTARdetracciones(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> ListarBancosProg(string productos)
    {
        return CP0003CUBA.ListarBancosProg(productos);
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ELIMINACABECERA(CP0003PRGC alumno)
    {
        CP0003PRGC.EliminaItems(alumno);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ELIMINADETALLE(CP0003PRGD ADATA)
    {
        CP0003PRGD.EliminaItems(ADATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaLog2(CP0003LOG2 ADATA)
    {
        CP0003LOG2.insertar(ADATA);
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("Ane");
        dtGetDatae.Columns.Add("Codigo");
        dtGetDatae.Columns.Add("Acreedor");
        dtGetDatae.Columns.Add("Vencido");
        dtGetDatae.Columns.Add("PorVencer");
        dtGetDatae.Columns.Add("Stotal");
        dtGetDatae.Columns.Add("ProgTotal");
       
        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }

    public void VERGRILLA2()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CTIPDOC");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_DFECDOC");
        dtGetDatae.Columns.Add("CP_DFECVEN");
        dtGetDatae.Columns.Add("PorVencer");
        dtGetDatae.Columns.Add("DIAS");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("CP_CRETE");
        dtGetDatae.Columns.Add("CP_CTASDET");
        dtGetDatae.Rows.Add();
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }

    public void VERGRILLA3()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CTIPDOC");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_DFECDOC");
        dtGetDatae.Columns.Add("CP_DFECVEN");
        dtGetDatae.Columns.Add("PorVencer");
        dtGetDatae.Columns.Add("DIAS");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("CP_CRETE");
        dtGetDatae.Columns.Add("CP_CTASDET");
        dtGetDatae.Columns.Add("ACREEDOR");
        dtGetDatae.Rows.Add();
        GridView3.DataSource = dtGetDatae;
        GridView3.DataBind();
    }

    public void inicio()
    {
        gvordencompra.DataSource = CP0003PRGC.LISTARTTODOS();
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

    protected void btnfiltro_Click(object sender, EventArgs e)
    {
        CP0003PRGC PROGRAMACION = new CP0003PRGC();
        PROGRAMACION.GC_CCODAGE = ddlagencia.Text;
        PROGRAMACION.GC_CCODBAN = ddlbanco.Text;
        PROGRAMACION.GC_CTIPPAG = ddltipopago.Text;
        PROGRAMACION.GC_CCODDEP = ddldepartamento.Text;
        PROGRAMACION.GC_CCODCON = ddlconcepto.Text;
        PROGRAMACION.GC_CESTADO = "P";
        VERGRILLAPRINCIPAL();

        if (rbdia.Checked)
        {
            if (this.txtfecha.Text=="")
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
            else {
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR()
    {
        return CT0003AGEN.GeneraNroSolicitud();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CTCAMB> obetenertcambiocvEdgar(CTCAMB COM)
    {
        return CTCAMB.obetenertcambiocvEdgar(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_totales_programacion> LISTARTOTALES(string VC)
    {
        return CP0003CART.LISTARTOTALES(VC).OrderBy(x=>x.Codigo).ToList();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(CP0003PRGC DETA)
    {
        CP0003PRGC.insertar(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDetalle(CP0003PRGD DETA)
    {
        CP0003PRGD.insertar(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> filtrodetalle(CP0003CART VC)
    {
        return CP0003CART.SELECTDETALLES(VC);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003PRGD> LISTARTTODOS(string dato)
    {
        return CP0003PRGD.LISTARTTODOS(dato);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_programacion> LISTARUNO(string CODATA)
    {
        return CP0003PRGC.LISTARUNO(CODATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaProg(CT0003AGEN DETA)
    {
        CT0003AGEN.ActualizaProg(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }
}