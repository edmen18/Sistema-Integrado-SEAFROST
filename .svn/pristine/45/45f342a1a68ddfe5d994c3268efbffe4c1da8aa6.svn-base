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
using ENTITY;
using System.Configuration;

public partial class listadoOC : System.Web.UI.Page
{
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos)
    {
        return AL0003ARTI.ListarArticulos(productos);
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        CT0003ANEX ADATA = new CT0003ANEX()
        {
            AVANEXO="P",
            ADESANE= productos
        };

        return CT0003ANEX.listarAnexoT(ADATA);
    }
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {

            ddlPeriodo.Items.Clear();
            ddlPeriodo.DataTextField = "descripcion";
            ddlPeriodo.DataValueField = "cod";
            ddlPeriodo.DataSource = tabla_periodo.ListarPeriodo();
            ddlPeriodo.DataBind();
            ddlPeriodo.Items.Insert(0, new ListItem("[PERIODO]", "-1"));
            
            ddlmes.Items.Clear();
            ddlmes.DataTextField = "descripcion";
            ddlmes.DataValueField = "cod";
            ddlmes.DataSource = tabla_mes.ListaMes();
            ddlmes.DataBind();
            ddlmes.Items.Insert(0, new ListItem("[MES]", "-1"));

            ddlUsuario.Items.Clear();
            ddlUsuario.DataTextField = "tu_nomusu";
            ddlUsuario.DataValueField = "tu_alias";
            ddlUsuario.DataSource = UT0030.ListarUsuarios();
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "75";
            TABL.TG_CDESCRI = string.Empty;

            ddlestado.Items.Clear();
            ddlestado.DataTextField = "TG_CDESCRI";
            ddlestado.DataValueField = "TG_CCLAVE";
            ddlestado.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlestado.DataBind();
            ddlestado.Items.Insert(0, new ListItem("[ESTADO]", "-1"));


        }
    }





    protected void btnBuscar_Click(object sender, EventArgs e)
    {
      


        if ((ddlPeriodo.SelectedValue == "-1") || (ddlmes.SelectedValue == "-1"))
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Año y Mes"), false);
            return;
        }

        VISTA_REQUERIMIENTOS REQ = new VISTA_REQUERIMIENTOS()
        {
              ANIO= Convert.ToInt32( ddlPeriodo.SelectedItem.Text),
              MES=Convert.ToInt32 ( ddlmes.SelectedValue),
              RC_CUSUCRE=ddlUsuario.SelectedValue,
              RC_CESTADO=ddlestado.SelectedValue,
              USUARIO= hfproducto.Value

        };

       
        gvRequerimientos.DataSource = AL0003REQC.ListarRequerimientos(REQ);
        gvRequerimientos.DataBind();

        hfproducto.Value = null;
        txtproducto.Text = string.Empty;

    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevaOC.aspx");
    }


    protected void ib_editar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvRequerimientos.Rows[row.RowIndex].Cells[0].Text;
        string estado = gvRequerimientos.Rows[row.RowIndex].Cells[3].Text;
        string usuario = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSUCRE"].ToString().Trim();
        string usuariosession = Session["codusu"].ToString().Trim();
        if (estado == "EMITIDO")
        {
            if (usuariosession.Equals( usuario))
                Response.Redirect("nuevaOC.aspx?numero=" + item);
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("USUARIOS DIFERENTES"), false);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("DEBE ESTAR EMITIDO PARA MODIFICARSE"), false);

    }

    protected void ib_eliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvRequerimientos.Rows[row.RowIndex].Cells[0].Text;
        string estado = gvRequerimientos.Rows[row.RowIndex].Cells[3].Text;
        AL0003REQC REC = new AL0003REQC()
        {
            RC_CNROREQ = item
        };
        AL0003REQD REQ = new AL0003REQD()
        {
            RD_CNROREQ = item
        };

        VISTA_REQUERIMIENTOS VISTA = new VISTA_REQUERIMIENTOS()
        {
            ANIO = Convert.ToInt32(ddlPeriodo.SelectedItem.Text),
            MES = Convert.ToInt32(ddlmes.SelectedValue),
            RC_CUSUCRE = ddlUsuario.SelectedValue,
            RC_CESTADO = ddlestado.SelectedValue
        };
        string usuario = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSUCRE"].ToString().Trim();
        string usuariosession = Session["codusu"].ToString().Trim();

        if (estado == "EMITIDO")
        {

            if (usuariosession.Equals( usuario))
            {
                AL0003REQC.EliminarCabeceraRequerimiento(REC);
                AL0003REQD.EliminarDetalleRequerimientoTotal(REQ);

                gvRequerimientos.DataSource = AL0003REQC.ListarRequerimientos(VISTA);
                gvRequerimientos.DataBind();
            }
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("USUARIOS DIFERENTES"), false);

        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("DEBE ESTAR EMITIDO PARA ELIMINARSE"), false);

    }



    protected void ibVisualizar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvRequerimientos.Rows[row.RowIndex].Cells[0].Text;
        string estado = gvRequerimientos.Rows[row.RowIndex].Cells[3].Text;
        string usuario = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSUCRE"].ToString().Trim();
        string usuariosession = Session["codusu"].ToString().Trim();
        //if (estado == "EMITIDO")
        //{
            //if (usuariosession.Equals(usuario))
                Response.Redirect("verOC.aspx?numero=" + item);
        //    else
        //        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("USUARIOS DIFERENTES"), false);
        //}
        //else
        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("DEBE ESTAR EMITIDO PARA MODIFICARSE"), false);

    }

    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {

    }

    protected void ibImprimir_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;
        string item = gvRequerimientos.Rows[row.RowIndex].Cells[0].Text;
        string estado = gvRequerimientos.Rows[row.RowIndex].Cells[3].Text;
        string usuario = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSUCRE"].ToString().Trim();
        string usuariosession = Session["codusu"].ToString().Trim();
    }
    public void FunExportToExcel(GridView GrdView)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page pagina = new Page();
        HtmlForm form = new HtmlForm();

        GrdView.EnableViewState = false;

        pagina.EnableEventValidation = false;
        pagina.DesignerInitialize();
        pagina.Controls.Add(form);
        form.Controls.Add(GrdView);
        pagina.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }
    protected void btnExel_Click(object sender, EventArgs e)
    {
        if ((ddlPeriodo.SelectedValue == "-1") || (ddlmes.SelectedValue == "-1"))
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Año y Mes"), false);
            return;
        }

        VISTA_REQUERIMIENTOS REQ = new VISTA_REQUERIMIENTOS()
        {
            ANIO = Convert.ToInt32(ddlPeriodo.SelectedItem.Text),
            MES = Convert.ToInt32(ddlmes.SelectedValue),
            RC_CUSUCRE = ddlUsuario.SelectedValue,
            RC_CESTADO = ddlestado.SelectedValue
        };


        gvreporte.DataSource = AL0003REQC.ListarRequerimientos(REQ);
        gvreporte.DataBind();


        FunExportToExcel(gvreporte);
    }
}
