using ENTITY;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class menu : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        ////HiddenField SourceTextBox =
        ////            (HiddenField)PreviousPage.FindControl("hfTipoUsuario");
        ////if (SourceTextBox != null)
        ////{
        ////    MessageBox.Show(SourceTextBox.Value);

        ////}

        if (!this.IsPostBack)
        {
            if (Request.QueryString["var"]=="NO")

            Response.Write("<script>alert('No tiene acceso')</script>");

            //if (PreviousPage != null)
            //{
            //    HiddenField SourceTextBox =
            //        (HiddenField)PreviousPage.FindControl("hfTipoUsuario");
            //    if (SourceTextBox != null)
            //    {
            //        MessageBox.Show(SourceTextBox.Value);
                    
            //    }
            //}
          
            // DropDownList1.DataTextField 
            //    DropDownList1.DataValueField
 
           
        }
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_menuusuarios> Getmenulista(string codig,string menunom)
    {
        return tabla_menuusuarios.VerUsuario(codig, menunom);
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static tabla_menuusuarios Getvalidaurl(string codig, string nomurl)
    //{
    //    return tabla_menuusuarios.ValidaUrls(codig, nomurl);
    //}
    

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<cabmenu> Getmenumain(string codig)
    {
        return tabla_menuusuarios.VerUsuariomain(codig);
    }


    //NUEVO
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string existeTC(CTCAMB DATC)
    {
        return CTCAMB.existeTC(DATC);
    }

    //BLOQUEO
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static ALCIAS bloqueo()
    {
        return ALCIAS.Verciasdato();
    }

}