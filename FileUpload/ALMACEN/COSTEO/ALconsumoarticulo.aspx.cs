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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack) {
            tabla_parametrosbusq TABL = new tabla_parametrosbusq();
            ListaMovi();
            TABL.PM_CAT = "C";
            ddlconsu.Items.Clear();
            ddlconsu.DataTextField = "PM_DESC"; 
            ddlconsu.DataValueField = "PM_ID"; 
            ddlconsu.DataSource = tabla_parametrosbusq.ListaParam_af(TABL);
            ddlconsu.DataBind();

            TABL.PM_CAT = "G";
            ddlagrup.Items.Clear();
            ddlagrup.DataTextField = "PM_DESC";
            ddlagrup.DataValueField = "PM_ID";
            ddlagrup.DataSource = tabla_parametrosbusq.ListaParam_af(TABL);
            ddlagrup.DataBind();

            ddlalma.Items.Clear();
            ddlalma.DataTextField = "A1_CDESCRI";
            ddlalma.DataValueField = "A1_CALMA";
            ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma.DataBind();
            ddlalma.Items.Insert(0, new ListItem("[TODOS]", "-1"));


            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
        }
    }

    public void ListaMovi()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("PL_fecha");
        dtGetDatae.Columns.Add("PL_codigo");
        dtGetDatae.Rows.Add();
        gvmovi.DataSource = dtGetDatae;
        gvmovi.DataBind();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }


    protected void btacepta_Click(object sender, EventArgs e)
    {
            if (txtidprod1.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado el Producto 1')</script>"); txtidprod1.Focus();
            }
            else if (txtidprod2.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado el Producto 2');</script>"); txtidprod2.Focus();
            }
            else if (txtfecha1.Text == "") 
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado la fecha 1');</script>"); txtfecha1.Focus();
            }
            else if (txtfecha2.Text == "")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado la fecha 2');</script>"); txtfecha2.Focus();
            }
            else {

                var Fenv = txtfecha1.Text;
                var Fen2 = txtfecha2.Text;
                var prd1 = txtidprod1.Text;
                var prd2 = txtidprod2.Text;
                var almacen = ddlalma.SelectedValue;
            var consu = ddlconsu.SelectedValue;
            //if (Convert.ToInt32(consu) == 1) { consu = "MN"; } else if  (Convert.ToInt32(consu) == 2){ consu = "US";}
             Response.Write("<script LANGUAGE='JavaScript' >window.open('../COSTEO/ReporteConsumoCentro.aspx?f1="+Fenv+"&f2="+Fen2+"&p1="+prd1+"&p2="+prd2+"&al="+almacen+"&cs="+consu+"','_blank');</script>");


            btacepta.Enabled = true;
        }
    }

    protected void txtidprod1_TextChanged(object sender, EventArgs e)
    {
        //if (!IsPostBack) {
        if (AL0003ARTI.obtenerArticuloPorID(txtidprod1.Text) == null)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Producto');</script>"); txtidprod1.Focus();
        }
        else { 
        txtprod.Text= AL0003ARTI.obtenerArticuloPorID(txtidprod1.Text).AR_CDESCRI;
        }
        //}
    }

    protected void txtidprod2_TextChanged(object sender, EventArgs e)
    {
        if (AL0003ARTI.obtenerArticuloPorID(txtidprod2.Text) == null)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Producto');</script>"); txtidprod2.Focus();
        }
        else {
            txtprod2.Text = AL0003ARTI.obtenerArticuloPorID(txtidprod2.Text).AR_CDESCRI;
        }
    }

    protected void rbmovi_SelectedIndexChanged(object sender, EventArgs e)
    {

        Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Producto');</script>");
    }
}