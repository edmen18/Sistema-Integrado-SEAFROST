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

public partial class FINANZAS_TESORERIA_CHEQUES_ImprimirCheques : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblusuario.Text = Convert.ToString(Session["codusu"]);
            VERGRILLA();
                    }
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

    }