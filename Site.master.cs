using CapaNegocio;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SiteMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        DateTime fecha1 = Convert.ToDateTime("12/11/2015");
        DateTime fecha2 = DateTime.Now;
        double dias = (fecha2 - fecha1).TotalDays;

        //if (dias >= 30)
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("VERSION DE PRUEBA HA EXPIRADO"), false);
        //    Response.Redirect("default.aspx?x=1");
        //}
        //site master 



        if (!this.IsPostBack)
        {
            hfusu.Value = Session["codusu"].ToString().ToUpper();
            var az = hfusu.Value;
            string path = HttpContext.Current.Request.Url.AbsolutePath;
            string host = HttpContext.Current.Request.Url.Host;

            int ccc = tabla_menuusuarios.ValidaUrls(az, path, host);

            if (host == "localhost")
            {

                if (ccc == 0 && path != "/menu.aspx")
                {
                    Response.Redirect(Request.UrlReferrer.ToString());
                    //Response.Redirect(ResolveUrl("~/menu.aspx"));
                }

            }
            else
            {

                if (ccc == 0 && path != "/SEALOGISTICA/menu.aspx")

                {
                   // Response.Redirect(Request.UrlReferrer.ToString());
                    Response.Redirect(ResolveUrl("/SEALOGISTICA/menu.aspx"));

                }
            }



        }


    }




}
