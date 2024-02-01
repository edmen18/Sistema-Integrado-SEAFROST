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

public partial class ReimpresionDocumentos : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha = DateTime.Now.ToString("dd/MM/yyyy");
            txtFEC.Text = (Session["Fechae"]!=null?Session["FechaE"].ToString():auxFecha);
            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"] != null ? Session["aID"].ToString():"0012");//"0001"

            //TIPO ANEXO
            CP0003TAGE TAGE = new CP0003TAGE();
            TAGE.TG_INDICE = "10";
            TAGE.TG_CODIGO = "P";

            ddlTA.Items.Clear();
            ddlTA.DataTextField = "TG_DESCRI";
            ddlTA.DataValueField = "TG_CODIGO";
            ddlTA.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlTA.DataBind();

            txtTDO.Text = "LQ";
            ddlAGE.Items.Clear();
            ddlAGE.DataTextField = "AG_CNOMAGE";
            ddlAGE.DataValueField = "AG_CCODAGE";
            ddlAGE.DataSource = CT0003AGEN.ListarAgencia();
            ddlAGE.DataBind();

            ddlTA.Items.Clear();
            ddlTA.DataTextField = "TG_DESCRI";
            ddlTA.DataValueField = "TG_CODIGO";
            ddlTA.DataSource = CP0003TAGE.ListarTG(TAGE);
            ddlTA.DataBind();

            AL0003FACC DATA = new AL0003FACC();
            DATA.LC_CCODAGE = "0001";
            DATA.LC_CTD = "LQ";
            DATA.LC_CNUMDOC = "";
            DATA.LC_CCODPRV = "";
            DATA.LC_DFECDOC =Convert.ToDateTime(txtFEC.Text);

            if (AL0003FACC.listarLQ(DATA).Count>0)
            {
                gvRD.DataSource = AL0003FACC.listarLQ(DATA);
                gvRD.DataBind();
            }
            else
            {
                visualizarGrid();
            }
            

            //visualizarGrid();
            visualizarGridDetalle();

        }
    }
    
    public void visualizarGrid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("LC_CCODAGE");
        dtGetData.Columns.Add("LC_CTD");
        dtGetData.Columns.Add("LC_CNUMDOC");
        dtGetData.Columns.Add("LC_CVENDE");//LC_DFECDOC
        dtGetData.Columns.Add("LC_CRFTD");//LC_DFECVEN
        dtGetData.Columns.Add("LC_CCODPRV");
        dtGetData.Columns.Add("LC_CNOMBRE");
        dtGetData.Columns.Add("LC_CFORVEN");
        dtGetData.Columns.Add("LC_CCODMON");
        dtGetData.Columns.Add("LC_NIMPORT");
        dtGetData.Columns.Add("LC_CESTADO");
        dtGetData.Columns.Add("LC_CUSUCRE");
        dtGetData.Columns.Add("");
        dtGetData.Rows.Add();
        gvRD.DataSource = dtGetData;
        gvRD.DataBind();
    }

    public void visualizarGridDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("LD_CCODIGO");
        dtGetData.Columns.Add("LD_CDESCRI");
        dtGetData.Columns.Add("LD_DCANTID");
        dtGetData.Columns.Add("LD_CUNIDAD");
        dtGetData.Columns.Add("LD_NPRECIO");
        dtGetData.Columns.Add("LD_NIMPMN");
        dtGetData.Columns.Add("LD_NIGVMN");
        dtGetData.Columns.Add("LD_NIMPMN1");      
        dtGetData.Rows.Add();
        gvDetalle.DataSource = dtGetData;
        gvDetalle.DataBind();
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003FACD> listarD(AL0003FACD DATA)
    {
        return AL0003FACD.listar(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003FACC> listar(AL0003FACC DATA)
    {
        return AL0003FACC.listar(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static AL0003ALMA mialmacen(AL0003ALMA CALMA)
    {
        return AL0003ALMA.ListadirAlmacen(CALMA);
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


    protected void txtFEC_TextChanged(object sender, EventArgs e)
    {
        AL0003FACC DATA = new AL0003FACC();
        DATA.LC_CCODAGE = "0001";
        DATA.LC_CTD = "LQ";
        DATA.LC_CNUMDOC = "";
        DATA.LC_CCODPRV = "";
        DATA.LC_DFECDOC = Convert.ToDateTime(txtFEC.Text);

        if (AL0003FACC.listarLQ(DATA).Count > 0)
        {
            gvRD.DataSource = AL0003FACC.listarLQ(DATA);
            gvRD.DataBind();
        }
        else
        {
            visualizarGrid();
        }
    }

    protected void txtPRO_TextChanged(object sender, EventArgs e)
    {
        AL0003FACC DATA = new AL0003FACC();
        DATA.LC_CCODAGE = "0001";
        DATA.LC_CTD = "LQ";
        DATA.LC_CNUMDOC = "";
        DATA.LC_CCODPRV = txtPRO.Text;
        //DATA.LC_DFECDOC = ""; 

        if (AL0003FACC.listarLQ(DATA).Count > 0)
        {
            gvRD.DataSource = AL0003FACC.listarLQ(DATA);
            gvRD.DataBind();
        }
        else
        {
            visualizarGrid();
        }
    }
}

