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
//using CapaNegocio;
using ENTITY;
using System.Configuration;

public partial class SAlmacen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            String MID = ALCIAS.Verciasdato().AC_CALMA.ToString();
            ddlAlmacenA.Items.Clear();
            ddlAlmacenA.DataTextField = "A1_CDESCRI";
            ddlAlmacenA.DataValueField = "A1_CALMA";
            ddlAlmacenA.DataSource = AL0003ALMA.ListarAlmacen();
            ddlAlmacenA.DataBind();
            ddlAlmacenA.SelectedValue = (Session["aID"]!=null? Session["aID"].ToString():"0001");

            ddlAlmacenP.Items.Clear();
            ddlAlmacenP.DataTextField = "A1_CDESCRI";
            ddlAlmacenP.DataValueField = "A1_CALMA";
            ddlAlmacenP.DataSource = AL0003ALMA.ListarAlmacen();
            ddlAlmacenP.DataBind();
            ddlAlmacenP.SelectedValue = MID;

            dpFecha.Text = Convert.ToDateTime(ALCIAS.Verciasdato().AC_DFECPRO.ToString()).ToString("dd/MM/yyyy");//DateTime.Now.ToString("dd/MM/yyyy");

        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //SiteMaster master = (SiteMaster)Page.Master;
        String ID = ALCIAS.Verciasdato().AC_CCIA.ToString();
        String FB = ALCIAS.Verciasdato().AC_DFECPR1.ToString();
        if (Convert.ToDateTime(FB) >= Convert.ToDateTime(dpFecha.Text))
        {
            Response.Write("<script LANGUAGE='JavaScript' >alert('La fecha elegida se encuentra bloqueada')</script>");
            dpFecha.Text = Convert.ToDateTime(ALCIAS.Verciasdato().AC_DFECPRO.ToString()).ToString("dd/MM/yyyy");//DateTime.Now.ToString("dd/MM/yyyy");
        }
        else
        {
            btnAceptar.Enabled = false;
            ddlAlmacenA.Enabled = false;
            ddlAlmacenP.Enabled = false;
            dpFecha.Enabled = false;

            Session["aID"] = ddlAlmacenA.SelectedValue;
            Session["daID"] = ddlAlmacenA.SelectedItem;
            Session["pID"] = ddlAlmacenP.SelectedValue;
            Session["dpID"] = ddlAlmacenP.SelectedItem;
            Session["FechaE"] = dpFecha.Text;
            ddlAlmacenA.SelectedValue = Session["aID"].ToString();
            Response.Write("<script LANGUAGE='JavaScript' >alert('Se han guardado sus cambios " + ddlAlmacenA.SelectedValue + "')</script>");
            var DATA = new ALCIAS();
            DATA.AC_CCIA = ID;
            DATA.AC_CALMA = ddlAlmacenP.SelectedValue;
            DATA.AC_DFECPRO = Convert.ToDateTime(dpFecha.Text);
            ALCIAS.acierre(DATA);

        }

        
        
        //Response.Write("<script LANGUAGE='JavaScript' >alert('" + dpFecha.Text + "')</script>");

    }
}

