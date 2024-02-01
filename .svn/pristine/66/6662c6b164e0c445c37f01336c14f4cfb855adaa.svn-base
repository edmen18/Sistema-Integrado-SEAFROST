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
using System.Web.Services;//agrega
using System.Configuration;

public partial class CAlmacen : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            //dpFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            dpFecha.Text= Convert.ToDateTime(ALCIAS.Verciasdato().AC_DFECPR1.ToString()).ToString("dd/MM/yyyy");
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        String ID = ALCIAS.Verciasdato().AC_CCIA.ToString();
        btnAceptar.Enabled = false;
        dpFecha.Enabled = false;
        //AL0003REQD rec = new AL0003REQD()
        //{
            //ddlFechaA.SelectedValue,
            //ddlFechaP.SelectedValue
        //};
        //AL0003REQD.insertaAU(rec);ALMACEN A UTILIZAR
        //Session["aID"] = ddlAlmacenA.SelectedValue;
        //Session["daID"] = ddlAlmacenA.SelectedItem;
        //Session["pID"] = ddlAlmacenP.SelectedValue;
        //Session["dpID"] = ddlAlmacenP.SelectedItem;
        //Session["FechaE"] = dpFecha.Text;
        ALCIAS DATA = new ALCIAS();
        DATA.AC_CCIA = ID;
        DATA.AC_DFECPR1 = Convert.ToDateTime(dpFecha.Text);
        ALCIAS.acierre(DATA);

        Response.Write("<script LANGUAGE='JavaScript' >alert('Cierre de Almacen efectuado al:"+dpFecha.Text+"')</script>");

    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static ALCIAS getALCIAS()
    {
        return ALCIAS.Verciasdato();
    }

}

