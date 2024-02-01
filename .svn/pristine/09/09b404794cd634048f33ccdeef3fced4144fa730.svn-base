using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CapaNegocio;
using CapaEntidades;

public partial class cambiarpass : System.Web.UI.Page
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
    protected void Button1_Click(object sender, EventArgs e)
    {
        Cls_ConsultasCN var_consulta = new Cls_ConsultasCN("seaplanillas");
        Cls_MantenimientosCN var_mantenimiento = new Cls_MantenimientosCN("seaplanillas");
        Cls_Usuarios usuario = new Cls_Usuarios();
        usuario = var_consulta.funObtenerUsuarios(Session["codusu"].ToString());

        Boolean band = false;

        if (usuario != null)
        {
            if (TextBox1.Text != usuario.password)
            {

                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Clave actual incorrecta"), false);
               
               
            }
            else
            {

                if (TextBox2.Text != TextBox3.Text)
                {


                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Claves nuevas no conciden"), false);
               

                }
                else
                {
                   band= var_mantenimiento.actualizaUsuarios(Session["codusu"].ToString(), TextBox2.Text);

                    if (band)
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Se cambio la clave con éxito"), false);
                    else
                        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("No se grabó"), false);
                   
                    
                }
            }
        }

 
    }
}