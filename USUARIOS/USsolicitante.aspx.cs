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
        if (!this.IsPostBack)
        {

            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();

            AL0003TABL prmas = new AL0003TABL();
            prmas.TG_CCOD ="12";
            gvgerencia.DataSource = AL0003TABL.ListarTablaS(prmas);
            gvgerencia.DataBind();

        }
    }


    //public void ListaNivel()
    //{
    //    DataTable dtGetDatae = new DataTable();
    //    dtGetDatae.Columns.Add("NA_ID");
    //    dtGetDatae.Columns.Add("NA_NIVEL");
    //    dtGetDatae.Rows.Add();
    //    gvnivel.DataSource = dtGetDatae;
    //    gvnivel.DataBind();
    //}

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<UT0030> listarusuarios(string nombre)
    {
        return UT0030.ListarautocUsuarios(nombre);
    }


    protected void btacepta_Click(object sender, EventArgs e)
    {
        tabla_d_ususol eli = new tabla_d_ususol();
        eli.SU_USUA = txtidusua.Text;
        tabla_d_ususol.EliminaDetalleus(eli);
        
        int cont = 0;
        foreach (GridViewRow row in gvgerencia.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionn") as CheckBox;

            if (check.Checked)
            {
                tabla_d_ususol ireg = new tabla_d_ususol();
                ireg.SU_SOLIC = (row.Cells[0].Text);
                ireg.SU_USUA = txtidusua.Text;
                tabla_d_ususol.Insertarsolusua(ireg);
                cont++;
            }
        }
        if (cont > 0)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Registros Grabados')</script>");
        }


    }


    protected void txtidusua_TextChanged(object sender, EventArgs e)
    {
        if (UT0030.Mostrarunusuario(txtidusua.Text) == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('El usuario no existe')</script>");
            txtidusua.Focus();
            txtidusua.Text = "";
            txtusua.Text = "";
        }
        else {
            txtusua.Text = UT0030.Mostrarunusuario(txtidusua.Text);
            tabla_d_ususol parm = new tabla_d_ususol();
            parm.SU_USUA = txtidusua.Text;
            List<tabla_d_ususol> ldata = new List<tabla_d_ususol>();
            ldata = tabla_d_ususol.ListaDetalleus(parm);

            foreach (GridViewRow row in gvgerencia.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccionn") as CheckBox;
                var id = row.Cells[0].Text;
                if (ldata.Count() == 0) {
                    check.Checked = false;
                } else { 
                foreach (var ak in ldata)
                {
                    if (ak.SU_SOLIC == (id))
                    {
                        check.Checked = true;
                        break;
                    }
                    else { 
                        check.Checked = false;
                    }
                    }
                }
            }
            


        }
    }




    protected void btbuscar_Click(object sender, EventArgs e)
    {

        tabla_d_ususol parm = new tabla_d_ususol();
        parm.SU_USUA = txtidusua.Text;
        List<tabla_d_ususol> ldata = new List<tabla_d_ususol>();
        ldata = tabla_d_ususol.ListaDetalleus(parm);

        foreach (GridViewRow row in gvgerencia.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionn") as CheckBox;
            var id = row.Cells[0].Text;
            if (ldata.Count() == 0)
            {
                check.Checked = false;
            }
            else {
                foreach (var ak in ldata)
                {
                    if (ak.SU_SOLIC == (id))
                    {
                        check.Checked = true;
                        break;
                    }
                    else {
                        check.Checked = false;
                    }
                }
            }
        }

    }









}