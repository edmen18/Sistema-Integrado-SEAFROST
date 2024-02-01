using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;//agrega
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
//using CapaNegocio;
using ENTITY;
using System.Configuration;

public partial class ConsultaReimpresion : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            txtalcanceDia.Text = auxFecha;
            txtalcanceDia.Text = (Session["Fechae"]!=null?Session["FechaE"].ToString():auxFecha);
            //txtNumeroDoc.Text = AL0003MOVC.codMaximo("0012", "PE").ToString();
            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"] != null ? Session["aID"].ToString():"0012");//"0001"

            ddlMalmacen.Items.Clear();
            ddlMalmacen.DataTextField = "A1_CDESCRI";
            ddlMalmacen.DataValueField = "A1_CALMA";
            ddlMalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlMalmacen.DataBind();

            ddlTipodocumento.Items.Clear();
            ddlTipodocumento.Items.Insert(0, new ListItem("[Todos]", "-1"));
            ddlTipodocumento.Items.Insert(1, new ListItem("PE", "PE"));
            ddlTipodocumento.Items.Insert(2, new ListItem("PS", "PS"));
            ddlTipodocumento.Items.Insert(2, new ListItem("GS", "GS"));

            visualizarGrid();
            visualizarGridDetalle();
        }
    }
    
    public void visualizarGrid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C5_CTD");
        dtGetData.Columns.Add("C5_CNUMDOC");
        dtGetData.Columns.Add("C5_CCODMOV");
        dtGetData.Columns.Add("C5_DFECDOC");
        dtGetData.Columns.Add("C5_CCODPRO");
        dtGetData.Columns.Add("C5_CCODCLI");
        dtGetData.Columns.Add("C5_CNOMCLI");
        dtGetData.Columns.Add("C5_CRFTDOC");
        dtGetData.Columns.Add("C5_CRFNDOC");
        dtGetData.Columns.Add("C5_CRFTDO2");
        dtGetData.Columns.Add("C5_CRFNDO2");
        dtGetData.Columns.Add("C5_CGLOSA1");
        dtGetData.Rows.Add();
        gvCRD.DataSource = dtGetData;
        gvCRD.DataBind();
    }

    public void visualizarGridDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("C6_CITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("");//UNID
        dtGetData.Columns.Add("C6_CSERIE");
        dtGetData.Columns.Add("C6_NCANTID");
        dtGetData.Columns.Add("C6_NPREUN1");
        dtGetData.Columns.Add("C6_NDESCTO");
        dtGetData.Columns.Add("C6_NPRECIO");
        dtGetData.Columns.Add("C6_MINPMN");        
        dtGetData.Rows.Add();
        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }
    /* propiedad  OnRowCreated="griddata_RowCreated"
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }*/

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]    
    public static List<AL0003MOVC> listaDocumentos(AL0003MOVC DATOS)
    {
        return AL0003MOVC.listaDocumentos(DATOS);//, FEC2, TD, MOV, CCLI, NCLI, PRO);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003MOVD> detalleCabecera(string AL,string TD,string ND)
    {
        return AL0003MOVD.detalleCabecera(AL, TD, ND);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string ListarEID(string ID)
    {   //MATRICULA-EMBARCACION
        return tabla_embarcaciones.ListarEID(ID);
    }

    protected void btnExportar_Click(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            /*AL0003MOVC TABL = new AL0003MOVC();
            lblPrueba.Text = "si";
            //TABL.C5_CALMA = idAL;
            //TABL.C5_CTD = idTD;
            //TABL.C5_CNUMDOC = idND;

            //AL0003MOVC.listaFinal(TABL);

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");

            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"Demo.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();*/
        }
            
    }
}

