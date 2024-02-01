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
        if (!this.IsPostBack)
        {
            Session["codusu"] = String.Empty;

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
