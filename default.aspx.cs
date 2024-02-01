using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaEntidades;
using CapaNegocio;
using ENTITY;
public partial class _default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string AUX = Convert.ToString(Request.RawUrl);
        string[] strArr = null;
        //string isuser = Convert.ToString(isuser);
        if (AUX != "/default.aspx") {
            string cad = "";
            cad = AUX.Replace("  ", "=");
            char[] splitchar = { '=' };
            strArr = cad.Split(splitchar);
            strArr = strArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
            if (strArr.Length >1) { 
            Session["codusu"] = strArr[3];
            }
            

        }

        if (!this.IsPostBack)
        {
            
            if (Session["codusu"] == null || Session.IsNewSession == false ) { 
                Session["codusu"] = String.Empty;
            }
            else
            {
               Response.Redirect(Request.RawUrl);
            }

            int x = Convert.ToInt32(Request.QueryString["x"]);
            if (x == 1)
            {
                lblMensaje.Visible = true;
                lblMensaje.Text = "VERSION DE PRUEBA HA EXPIRADO";
            }
        }
            
    }
  
    protected void btLogin_Click(object sender, EventArgs e)
    {
       string clave = Cls_Utilidades.devuelveClave(TextPass.Text);

        int cuenta= UT0030.CuentaUsuariosClave(txtUser.Text, clave);
        
        if (cuenta >0)
        {
            Session["codusu"] = txtUser.Text;
            Response.Redirect("~/menu.aspx");
        }
        else
        {
            lblMensaje.Visible = true;
            lblMensaje.Text = "Usuario o Contraseña Incorrecta";
        }
    }
    
}
