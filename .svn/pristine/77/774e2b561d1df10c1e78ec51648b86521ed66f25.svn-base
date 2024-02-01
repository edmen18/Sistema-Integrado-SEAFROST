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
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlmone.Items.Clear();
            ddlmone.DataTextField = "TG_CDESCRI";
            ddlmone.DataValueField = "TG_CCLAVE";
            ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlmone.DataBind();
            ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));


            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            //txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            //txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
        }
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
            else if (ddlmone.SelectedValue == "-1") 
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado la Moneda');</script>"); ddlmone.Focus();
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
                var moneda = ddlmone.SelectedValue;
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../COSTEO/ReporteKardexVal.aspx?f1="+Fenv+"&f2="+Fen2+"&p1="+prd1+"&p2="+ prd2+"&mo="+moneda+"' ,'_blank');</script>");

            //string finicio = "", ffina = "", diax = "";
            //finicio = "01/" + Fenv.Substring(5, 2) + "/" + Fenv.Substring(0, 4);
            //diax = DateTime.DaysInMonth(Convert.ToInt32(Fen2.Substring(0, 4)), Convert.ToInt32(Fen2.Substring(5, 2))).ToString("D2");
            //ffina = diax + "/" + Fen2.Substring(5, 2) + "/" + Fen2.Substring(0, 4);


            //DateTime fin = Convert.ToDateTime(finicio);
            //DateTime ffn = Convert.ToDateTime(ffina);

            //Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");

            

            //gvkardex.DataSource = consulta.funKardexVal(finicio, ffina, prd1, prd2, moneda);
            //gvkardex.DataBind();

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
}