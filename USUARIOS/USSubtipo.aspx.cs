﻿using System;
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
            ListaMovi();
            ListaNivel();
            //TABL.PM_CAT = "C";
            //ddlconsu.Items.Clear();
            //ddlconsu.DataTextField = "PM_DESC";
            //ddlconsu.DataValueField = "PM_ID";
            //ddlconsu.DataSource = tabla_parametrosbusq.ListaParam_af(TABL);
            //ddlconsu.DataBind();
            gvareas.DataSource = tabla_subtipoOC.ListarSTipoOC();
            gvareas.DataBind();

            gvnivel.DataSource = tabla_niveledicion.Listarniveles();
            gvnivel.DataBind();

            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
        }
    }

    public void ListaMovi()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("IDTipo");
        dtGetDatae.Columns.Add("Descripcion");
        dtGetDatae.Columns.Add("ST_NAPROB"); 
        dtGetDatae.Rows.Add();
        gvareas.DataSource = dtGetDatae;
        gvareas.DataBind();
    }

    public void ListaNivel()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("NA_ID");
        dtGetDatae.Columns.Add("NA_NIVEL");
        dtGetDatae.Rows.Add();
        gvnivel.DataSource = dtGetDatae;
        gvnivel.DataBind();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<UT0030> listarusuarios(string nombre)
    {
        return UT0030.ListarautocUsuarios(nombre);
    }


    protected void btacepta_Click(object sender, EventArgs e)
    {
        tabla_d_areausua eli = new tabla_d_areausua();
        eli.UA_USUA = txtidusua.Text;
        eli.UA_TIPOPROCESO = 2;
        tabla_d_areausua.EliminaDetalleua(eli);
        
        int cont = 0;
        foreach (GridViewRow row in gvareas.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccion") as CheckBox;

            if (check.Checked)
            {
                tabla_d_areausua ireg = new tabla_d_areausua();
                ireg.UA_SUBAREA = Convert.ToInt32(row.Cells[0].Text);
                ireg.UA_USUA = txtidusua.Text;
                ireg.UA_CORREO = txtcorreo.Text;
                ireg.UA_TIPOPROCESO = 2 ;
                tabla_d_areausua.Insertarareausua(ireg); 
                cont++;
            }
        }
        if (cont > 0)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Registros Grabados')</script>");
        }


        int cont2 = 0;
        tabla_d_nivelusua eli2 = new tabla_d_nivelusua();
        eli2.NU_USUA = txtidusua.Text;
        tabla_d_nivelusua.EliminaDetallena(eli2);
        foreach (GridViewRow row in gvnivel.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccionn") as CheckBox;

            if (check.Checked)
            {
                tabla_d_nivelusua ireg = new tabla_d_nivelusua();
                ireg.NU_NIVEL = Convert.ToInt32(row.Cells[0].Text);
                ireg.NU_USUA = txtidusua.Text;
                tabla_d_nivelusua.Insertarnivelusua(ireg);
                cont2++;
            }
        }
        if (cont2 > 0 && cont==0)
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
            txtcorreo.Text = UT0030.Mostrarinfousuario(txtidusua.Text.Trim()).TU_CORREO;
          
            List<tabla_subtipoOC> ldata = new List<tabla_subtipoOC>();
            ldata = tabla_subtipoOC.Listarsubtipoxusua(txtidusua.Text,2);
            foreach (GridViewRow row in gvareas.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
                var id = row.Cells[0].Text;
                if (ldata.Count() == 0) {
                    check.Checked = false;
                } else { 
                foreach (var ak in ldata)
                {
                    if (ak.IDTipo == Convert.ToInt32(id))
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
            //mostrar nivel
            List<tabla_niveledicion> ldata2 = new List<tabla_niveledicion>();
            ldata2 = tabla_d_nivelusua.Listarnivelxusua(txtidusua.Text);
            foreach (GridViewRow row in gvnivel.Rows)
            {
                CheckBox check = row.FindControl("chkSeleccionn") as CheckBox;
                var id = row.Cells[0].Text;
                if (ldata2.Count() == 0)
                {
                    check.Checked = false;
                }
                else {
                    foreach (var ak in ldata2)
                    {
                        if (ak.NA_ID == Convert.ToInt32(id))
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

        List<tabla_subtipoOC> ldata = new List<tabla_subtipoOC>();
        ldata = tabla_subtipoOC.Listarsubtipoxusua(txtidusua.Text,2);

        foreach (GridViewRow row in gvareas.Rows)
        {
            CheckBox check = row.FindControl("chkSeleccion") as CheckBox;
            var id = row.Cells[0].Text;
            if (ldata.Count() == 0)
            {
                check.Checked = false;
            }
            else {
                foreach (var ak in ldata)
                {
                    if (ak.IDTipo == Convert.ToInt32(id))
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