using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using System.Web.SessionState;
using System.Web.Script.Services;
using ClosedXML.Excel;
using CapaNegocio;

public partial class MantenimientoBitacora : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtfinicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtffin.Text = DateTime.Now.ToString("dd/MM/yyyy");
           
        }
    }


    protected void btbusca_Click(object sender, EventArgs e)
    {

        var fechaini = Convert.ToDateTime(txtfinicio.Text);
        var fechafin = Convert.ToDateTime(txtffin.Text);
      

        gvsolicitudes.DataSource = tabla_transporte_cabViaje.MantenimientoBitacora(fechaini, fechafin);// tabla_transporte_cabViaje.ListaTransporteCabecera();
        gvsolicitudes.DataBind();
    }

    protected void imgeditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvsolicitudes.Rows[row.RowIndex].Cells[0].Text;

        Response.Redirect("Bitacora.aspx?numero=" + item);
    }

    protected void imgeditar_Click1(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvsolicitudes.Rows[row.RowIndex].Cells[0].Text;

        Response.Redirect("Bitacora.aspx?numero=" + item);
    }
}