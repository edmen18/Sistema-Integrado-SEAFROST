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
public partial class FINANZAS_TESORERIA_CHEQUES_CONCAR_ComprobantesCheques : System.Web.UI.Page
{
   protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblusuario.Text = Convert.ToString(Session["codusu"]);
            VERGRILLA();
            if (!Page.IsPostBack)
            {
                txtchequeinicial.Text = "00000000";
                txtchequefinal.Text = "99999999";
                lblusuario.Text = Convert.ToString(Session["codusu"]);
                VERGRILLA();
                VERGRILLADETALLE();


                txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                CT0003TAGE are = new CT0003TAGE();
                ddlarea.Items.Clear();
                ddlarea.DataTextField = "TDESCRI";
                ddlarea.DataValueField = "TCLAVE";
                ddlarea.DataSource = CT0003TAGE.LISTARAREASED();
                ddlarea.DataBind();
                ddlareadet.Items.Clear();
                ddlareadet.DataTextField = "TDESCRI";
                ddlareadet.DataValueField = "TCLAVE";
                ddlareadet.DataSource = CT0003TAGE.LISTARAREASED();
                ddlareadet.DataBind();
                ddlareadet.Items.Insert(0, new ListItem("  ", " "));

                CT0003TABL ane = new CT0003TABL();
                ane.TCOD = "06";
                ddltipodoc.Items.Clear();
                ddltipodoc.DataTextField = "TDESCRI";
                ddltipodoc.DataValueField = "TCLAVE";
                ddltipodoc.DataSource = CT0003TABL.ListarTablaD(ane);
                ddltipodoc.DataBind();
                ddltipodoc.Items.Insert(0, new ListItem("  ", " "));

                ane.TCOD = "07";
                ddltipoanexo.Items.Clear();
                ddltipoanexo.DataTextField = "TDESCRI";
                ddltipoanexo.DataValueField = "TCLAVE";
                ddltipoanexo.DataSource = CT0003TABL.ListarTablaD(ane);
                ddltipoanexo.DataBind();
                               
                ane.TCOD = "17";
                ddltipoconvers.Items.Clear();
                ddltipoconvers.DataTextField = "TDESCRI";
                ddltipoconvers.DataValueField = "TCLAVE";
                ddltipoconvers.DataSource = CT0003TABL.ListarTabla(ane);
                ddltipoconvers.DataBind();

                ddlsubdiario.Items.Clear();
                ddlsubdiario.DataTextField = "TDESCRI";
                ddlsubdiario.DataValueField = "TCLAVE";
                ddlsubdiario.DataSource = CT0003TAGE.LISTARSUBDIARIOED("23");
                ddlsubdiario.DataBind();

                ddlmediopago.Items.Clear();
                ddlmediopago.DataTextField = "TDESCRI";
                ddlmediopago.DataValueField = "TCLAVE";
                ddlmediopago.DataSource = CT0003TAGE.LISTARMEDIOPAGOED("001", "007");
                ddlmediopago.DataBind();

                ddltipopago.Items.Clear();
                ddltipopago.DataTextField = "TDESCRI";
                ddltipopago.DataValueField = "TCLAVE";
                ddltipopago.DataSource = CT0003TAGE.LISTARMEDIOPAGOED("001", "007");
                ddltipopago.DataBind();
                ddltipopago.Items.Insert(0, new ListItem("  ", " "));


                lblcuentapago.Text = CT0003PLEM.ListarCtaE("FACTURAS EMITIDAS POR PAGAR M.N. TERCEROS").Select(x => x.PCUENTA).FirstOrDefault();
                lblcuentapagodol.Text = CT0003PLEM.ListarCtaE("FACTURAS EMITIDAS POR PAGAR M.E. TERCEROS").Select(x => x.PCUENTA).FirstOrDefault();
                lblcuentaretencion.Text = CT0003PLEM.ListarCtaE("IGV - REGIMEN DE RETENCIONES POR PAGAR").Select(x => x.PCUENTA).FirstOrDefault();
            }
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Elimina(CT0003COMD16 COM)
    {
        CT0003COMD16.Elimina(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CUBA ListarDatosBancoID(string ban)
    {
        return CP0003CUBA.ListarDatosBancoID(ban);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CHEQ> ConsultaCheque(CP0003CHEQ COM)
    {
        return CP0003CHEQ.ConsultaCheque(COM);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003COMD16> ConsultaunDetalle(CT0003COMD16 COM)
    {
      return  CT0003COMD16.ConsultaunDetalle(COM).OrderBy(X=>X.DSECUE).ToList();
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CSUBDIA");
        dtGetDatae.Columns.Add("CCOMPRO");
        dtGetDatae.Columns.Add("CDATE");
        dtGetDatae.Columns.Add("CCODMON");
        dtGetDatae.Columns.Add("CTOTAL");
        dtGetDatae.Columns.Add("CGLOSA");
        dtGetDatae.Columns.Add("CSITUA");
        dtGetDatae.Columns.Add("CEXTOR");
        dtGetDatae.Columns.Add("CTIPCOM");
        dtGetDatae.Columns.Add("CMEMO");
        dtGetDatae.Rows.Add();
        gvcomprobantes.DataSource = dtGetDatae;
        gvcomprobantes.DataBind();
    }

    public void VERGRILLADETALLE()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CSUBDIA");
        dtGetDatae.Columns.Add("CCOMPRO");
        dtGetDatae.Columns.Add("CMEMO");
        dtGetDatae.Columns.Add("CDATE");
        dtGetDatae.Columns.Add("CCODMON");
        dtGetDatae.Columns.Add("CTOTAL");
        dtGetDatae.Columns.Add("CGLOSA");
        dtGetDatae.Columns.Add("DOCMTO");
        dtGetDatae.Columns.Add("FEC DOC");
        dtGetDatae.Columns.Add("FEC VEN");
        dtGetDatae.Columns.Add("AREA");
        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CTCAMB> obetenertcambiocvEdgar(CTCAMB COM)
    {
        return CTCAMB.obetenertcambiocvEdgar(COM);
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
    public static List<CT0003ANEX> ListarProveedoresporid(string cod, string texto, string i)
    {
        return CT0003ANEX.ListarProveedoresporid(cod,texto,i);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> ListarBancosProg(string productos)
    {
        return CP0003CUBA.ListarBancosProg(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CHEQ> ConsultaChequeParametros(CP0003CHEQ COM)
    {
        return CP0003CHEQ.ConsultaChequeParametros(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CHEQ> DETALLE(CP0003CHEQ CODATA)
    {
        return CP0003CHEQ.CONSULTATODOS(CODATA);
    }
    /// INICIO DEL PROCESO DEL PRIMER GUARDADO
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
    public static void InsertaCheques(CP0003CHEQ DETA)
    {
        CP0003CHEQ.insertaCabecera(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean Numeracion(CT0003NUME16 DETA)
    {
        return CT0003NUME16.Numeracion(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaCheque(CP0003CUBA DETA)
    {
        CP0003CUBA.Actualizacheque(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizarSituacion(CT0003COMC16 COM)
    {
        CT0003COMC16.ActualizarSituacion(COM);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CT0003COMC16 CABECERA(CT0003COMC16 COM)
    {
        return CT0003COMC16.CABECERA(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListarCtaE1(string descri, string anexo, string moneda)
    {
        return CT0003PLEM.ListarCtaE1(descri, anexo, moneda);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ActualizarBalh(CT0003BALH16 DETA)
    {
        return CT0003BALH16.actualizar(DETA);
    }
}

