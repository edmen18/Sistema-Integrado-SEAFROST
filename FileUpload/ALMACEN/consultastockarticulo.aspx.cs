using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
using ENTITY;
using System.Configuration;

public partial class consultastockarticulo : System.Web.UI.Page
{
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos)
    {
        return AL0003ARTI.ListarArticulos(productos);
    }
      
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {

            ddlalmacen.Items.Clear();
            ddlalmacen.DataTextField = "A1_CDESCRI";
            ddlalmacen.DataValueField = "A1_CALMA";
            ddlalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalmacen.DataBind();
            ddlalmacen.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));

            ListaDetalle();



            hfproducto.Value = null;


            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            // Add parts to the list.
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "1", TG_CCOD = "ARTICULOS CON O SIN STOCK" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "2", TG_CCOD = "ARTICULOS CON STOCK" });

            ddlmes.Items.Clear();
            ddlmes.DataTextField = "TG_CCOD";
            ddlmes.DataValueField = "TG_CCLAVE";
            ddlmes.DataSource = listamoneda;
            ddlmes.DataBind();
            //ddlmes.Items.Insert(0, new ListItem("[MES]", "-1"));
        }
    }
    public void ListaDetalle()
    {
        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("SR_CCODIGO");
        dtGetDatae1.Columns.Add("SR_CSERIE");
        dtGetDatae1.Columns.Add("SR_NSKDIS");
        dtGetDatae1.Columns.Add("SR_DFECVEN");
        dtGetDatae1.Rows.Add();
        gvdetallereq.DataSource = dtGetDatae1;
        gvdetallereq.DataBind();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003SERI> consultaStockSerie(AL0003SERI REQ)
    {
        return AL0003SERI.ListarLOTES(REQ);
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static Boolean actualizaStockMinimo(AL0003ARTI ARTI)
    {
        return AL0003ARTI.actualizaStockMinimo(ARTI);
    }


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
      


        if ((ddlalmacen.SelectedValue == "-1") )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Año y Mes"), false);
            return;
        }


        AL0003STOC toc = new AL0003STOC()
        {
            SK_CALMA = ddlalmacen.SelectedValue,
            SK_CCODIGO= hfproducto.Value ,
            SK_CTIPREP=ddlmes.SelectedValue
        };

        gvRequerimientos.DataSource = AL0003STOC.retornaListaConsultaStock(toc);
        gvRequerimientos.DataBind();

        hfproducto.Value = null;
        txtproducto.Text = string.Empty;
        txtarticulo.Text = string.Empty;

    }

  


   


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


    protected void txtarticulo_TextChanged(object sender, EventArgs e)
    {
        AL0003ARTI arti = new AL0003ARTI();
        arti =AL0003ARTI.obtenerArticuloPorID(txtarticulo.Text.Trim());
        if (arti != null)
        {
            txtproducto.Text = arti.AR_CDESCRI.Trim();
        //    txtarticulo.Text = arti.AR_CCODIGO.Trim();
            hfproducto.Value = arti.AR_CCODIGO.Trim();
        }
        else
        {
            txtproducto.Text = string.Empty;
            txtarticulo.Text = string.Empty;
            hfproducto.Value = null;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("El articulo no existe"), false);
            return;
        }
    }
}
