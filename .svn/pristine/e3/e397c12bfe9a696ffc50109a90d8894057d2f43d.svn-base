using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Drawing;
using CapaNegocio;

public partial class ReporteRequerimientos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            //ListaDetalle();
            ListaDetalleCompra();
            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "31";
            TABL.TG_CDESCRI = string.Empty;

            //ddlestad.Items.Clear();
            //ddlestad.DataTextField = "TG_CDESCRI";
            //ddlestad.DataValueField = "TG_CCLAVE";
            //ddlestad.DataSource = AL0003TABL.ListarTabla(TABL);
            //ddlestad.DataBind();
            //ddlestad.Items.Insert(0, new ListItem("[ESTADO]", "-1"));


            TABL.TG_CCOD = "63";
            TABL.TG_CDESCRI = string.Empty;

            //ddltipo.Items.Clear();
            //ddltipo.DataTextField = "TG_CDESCRI";
            //ddltipo.DataValueField = "TG_CCLAVE";
            //ddltipo.DataSource = AL0003TABL.ListarTabla(TABL);
            //ddltipo.DataBind();
            //ddltipo.Items.Insert(0, new ListItem("[ESTADO]", "-1"));


            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlmone.Items.Clear();
            ddlmone.DataTextField = "TG_CDESCRI";
            ddlmone.DataValueField = "TG_CCLAVE";
            ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlmone.DataBind();
            ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));


            TABL.TG_CCOD = "63";
            TABL.TG_CDESCRI = string.Empty;

            ddltipoc.Items.Clear();
            ddltipoc.DataTextField = "TG_CDESCRI";
            ddltipoc.DataValueField = "TG_CCLAVE";
            ddltipoc.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddltipoc.DataBind();
            ddltipoc.Items.Insert(0, new ListItem("[TIPO]", ""));

            TABL.TG_CCOD = "04";
            TABL.TG_CDESCRI = string.Empty;

            ddldocre.Items.Clear();
            ddldocre.DataTextField = "TG_CDESCRI";
            ddldocre.DataValueField = "TG_CCLAVE";
            ddldocre.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddldocre.DataBind();
            ddldocre.Items.Insert(0, new ListItem("[REFERENCIA]", ""));

            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            // Add parts to the list.
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "1", TG_CCOD = "TODOS" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "2", TG_CCOD = "APROBADOS" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "3", TG_CCOD = "CON ORDEN DE COMPRA" });

            ddlestado.DataTextField = "TG_CCOD";
            ddlestado.DataValueField = "TG_CCLAVE";
            ddlestado.DataSource = listamoneda.ToList();
            ddlestado.DataBind();

            //ddlsuboc.Items.Clear();
            //ddlsuboc.DataTextField = "Descripcion";
            //ddlsuboc.DataValueField = "IDTipo";
            //ddlsuboc.DataSource = tabla_subtipoOC.ListarSTipoOC();
            //ddlsuboc.DataBind();
            //ddlsuboc.Items.Insert(0, new ListItem("[SUBTIPO]", "-1"));
        }
    }


    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CNUMORD");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_CRAZSOC");
        dtGetDatae.Columns.Add("OC_CCODMON");
        dtGetDatae.Columns.Add("OC_NIMPMN");
        dtGetDatae.Columns.Add("OC_CSITORD");
        dtGetDatae.Columns.Add("OC_CTIPORD");
        dtGetDatae.Columns.Add("OC_CCOTIZA");
        
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();

    }

    public void ListaDetalleCompra()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CITEM");
        dtGetDatae.Columns.Add("OC_CCODIGO");
        dtGetDatae.Columns.Add("OC_CCODREF");
        dtGetDatae.Columns.Add("OC_CUNIDAD");
        dtGetDatae.Columns.Add("OC_NCANORD");
        dtGetDatae.Columns.Add("OC_NPREUN2");
        dtGetDatae.Columns.Add("OC_NDSCPAD");
        dtGetDatae.Columns.Add("OC_NDSCPIT");
        dtGetDatae.Columns.Add("OC_NIGVPOR");
        dtGetDatae.Columns.Add("OC_NISCPOR");
        dtGetDatae.Columns.Add("OC_NPREUNI");
        dtGetDatae.Columns.Add("OC_NDESCTO");
        dtGetDatae.Columns.Add("OC_NIGV");
        dtGetDatae.Columns.Add("OC_NCANTEN");
        dtGetDatae.Columns.Add("OC_NCANSAL");
        dtGetDatae.Columns.Add("OC_DFECENT");
        dtGetDatae.Columns.Add("OC_COMENTA");
        dtGetDatae.Columns.Add("OC_NISC");
        dtGetDatae.Columns.Add("SUBTOTAL");

        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
        
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcera> ListarCabOC(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraoc(VC);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string cod,string productos)
    {
        return CT0003ANEX.listarAnexo(cod,productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void anularoc(CO0003MOVC COANULA)
    {
        CO0003MOVC.AnulaOC(COANULA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD LDE)
    {
        return CO0003MOVD.verListaOrden(LDE);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaDetalleOC(CO0003MOVD ELIM)
    {
        CO0003MOVD.EliminaItemsDetalleOC(ELIM);
    }
    

    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover","this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        DateTime fecha1 = Convert.ToDateTime( txtfecha1.Text);
        DateTime fecha2 = Convert.ToDateTime(txtfecha2.Text);
        int band = ddlestado.SelectedValue == "1" ? 1 : ddlestado.SelectedValue == "2" ? 2 : 3;
     // gvordencompra.DataSource = AL0003REQC.reporteRequerimeintoPorFechas(fecha1, fecha2, band);
        //gvordencompra.DataBind();
        Cls_ConsultasCN var_consultas = new Cls_ConsultasCN("RSFACAR");
        gvordencompra.DataSource = var_consultas.PR_REPORTESEMAFOROREQUERIMIENTO(band,fecha1, fecha2);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    //protected void ibexel_Click(object sender, ImageClickEventArgs e)
    //{
    //    FunExportToExcel(gvordencompra);
    //}
    public void FunExportToExcel(GridView GrdView)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page pagina = new Page();
        HtmlForm form = new HtmlForm();

        GrdView.EnableViewState = false;

        pagina.EnableEventValidation = false;
        pagina.DesignerInitialize();
        pagina.Controls.Add(form);
        form.Controls.Add(GrdView);
        pagina.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }


    protected void gvordencompra_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //    e.Row.Cells[2].BackColor = Color.Red;

            var dias = e.Row.Cells[2].Text == string.Empty ? "0" : e.Row.Cells[2].Text;

            if (Convert.ToInt32(dias) <= 5)
            {
                e.Row.Cells[2].BackColor = Color.LightGreen;
            }

            if (Convert.ToInt32(dias) > 5 && Convert.ToInt32(dias) <= 10)
            {
                e.Row.Cells[2].BackColor = Color.Yellow;
            }

            if (Convert.ToInt32(dias) > 10 && Convert.ToInt32(dias) <= 15)
            {
                e.Row.Cells[2].BackColor = Color.Orange;
            }
            if (Convert.ToInt32(dias) > 14)
            {
                e.Row.Cells[2].BackColor = Color.Red;
            }


        }
    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
        FunExportToExcel(gvordencompra);
    }
}