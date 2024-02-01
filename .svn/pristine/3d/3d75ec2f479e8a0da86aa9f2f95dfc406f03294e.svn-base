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
using System.Web.Script.Services;

public partial class apruebaRequerimiento : System.Web.UI.Page
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
        return CT0003ANEX.ListarProveedores(productos);
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static AL0003REQC datosCabecera(AL0003REQC REQ)
    {
        return AL0003REQC.obtenerRequerimientoPorNumero(REQ);
    }
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            ListaDetalle();
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

            //ddlUsuario.Items.Clear();
            //ddlUsuario.DataTextField = "tu_nomusu";
            //ddlUsuario.DataValueField = "tu_alias";
            //ddlUsuario.DataSource = UT0030.ListarUsuarios();
            //ddlUsuario.DataBind();
            //ddlUsuario.Items.Insert(0, new ListItem("[USUARIO]", "-1"));

            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "75";
            TABL.TG_CDESCRI = string.Empty;

            ddlestado.Items.Clear();
            ddlestado.DataTextField = "TG_CDESCRI";
            ddlestado.DataValueField = "TG_CCLAVE";
            ddlestado.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlestado.DataBind();
            ddlestado.Items.Insert(0, new ListItem("[ESTADO]", "-1"));

           
            hfusuario.Text = Session["codusu"].ToString().Trim();
            ddlmes.SelectedIndex = Convert.ToInt16(DateTime.Today.Month);
            ddlPeriodo.SelectedIndex = tabla_periodo.ListarPeriodo().Count();



            TABL.TG_CCOD = "12";
            TABL.TG_CDESCRI = string.Empty;

            ddlUsuario.Items.Clear();
            ddlUsuario.DataTextField = "TG_CDESCRI";
            ddlUsuario.DataValueField = "TG_CCLAVE";
            ddlUsuario.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlUsuario.DataBind();
            ddlUsuario.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));


        }
        lblusuario.Text = Convert.ToString(Session["codusu"]);
        FILTROAPROB();
    }
    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("RC_CNROREQ");
        dtGetDatae.Columns.Add("RC_DFECREQ");
        dtGetDatae.Columns.Add("PROVEEDOR");
        dtGetDatae.Columns.Add("ESTADO");
        dtGetDatae.Columns.Add("APROBAC");
        dtGetDatae.Columns.Add("RC_DFECA03");
        dtGetDatae.Columns.Add("RC_CNUMORD");
        dtGetDatae.Columns.Add("USUARIO");
        dtGetDatae.Columns.Add("COSTO");
        dtGetDatae.Columns.Add("PRIORIDAD");
        dtGetDatae.Columns.Add("USO");
        dtGetDatae.Columns.Add("RC_DFECA01");
        dtGetDatae.Columns.Add("RC_DFECA02");

        dtGetDatae.Columns.Add("RC_CUSEA01");
        dtGetDatae.Columns.Add("RC_CUSEA02");
        dtGetDatae.Columns.Add("RC_CUSEA03");

        dtGetDatae.Rows.Add();
        gvRequerimientos.DataSource = dtGetDatae;
        gvRequerimientos.DataBind();

        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("RD_CITEM");
        dtGetDatae1.Columns.Add("RD_CCODIGO");
        dtGetDatae1.Columns.Add("RD_CDESCRI");
        dtGetDatae1.Columns.Add("RD_CUNID");
        dtGetDatae1.Columns.Add("RD_NQPEDI");
        dtGetDatae1.Columns.Add("RD_COBS");
        dtGetDatae1.Rows.Add();
        gvdetalle.DataSource = dtGetDatae1;
        gvdetalle.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> ListarReq(VISTA_REQUERIMIENTOS REQ)
    {
        return AL0003REQC.ListarRequerimientos(REQ);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> ListarReqIni(VISTA_REQUERIMIENTOS REQ)
    {
        return AL0003REQC.ListarRequerimientosInicio(REQ).OrderByDescending(x=> Convert.ToDateTime(x.RC_DFECREQ)).ToList();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> ListarReqIniC(VISTA_REQUERIMIENTOS REQ)
    {
        return AL0003REQC.ListarRequerimientosInicio2(REQ).OrderByDescending(x => Convert.ToDateTime(x.RC_DFECREQ)).ToList();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool desaprobarCab(AL0003REQC REQ)
    {
        return AL0003REQC.desapruebaRequerimientoCab(REQ);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool desaprobarDet(AL0003REQD REQ)
    {
        List<VISTA_AL0003REQD> LISTA = AL0003REQD.ListarRequerimientosPorCodigo(REQ);

        foreach (VISTA_AL0003REQD item in LISTA)
        {
            REQ.RD_CITEM = item.RD_CITEM;
            AL0003REQD.desapruebaRequerimiento(REQ);
        };
        return true;
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool aprobarCab(AL0003REQC REQ)
    {
        return AL0003REQC.apruebaRequerimiento(REQ);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static bool aprobarDet(AL0003REQD REQ)
    {
       List<VISTA_AL0003REQD> LISTA = AL0003REQD.ListarRequerimientosPorCodigo(REQ);

        foreach (VISTA_AL0003REQD item in LISTA)
        {
            REQ.RD_CITEM = item.RD_CITEM;
            AL0003REQD.apruebaRequerimiento(REQ);
        };
        return true;
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_AL0003REQD> ListarReqDetalle(AL0003REQD REQ)
    {
        return AL0003REQD.ListarRequerimientosPorCodigo(REQ);
    }

    protected void btnNuevo_Click(object sender, EventArgs e)
    {
        Response.Redirect("nuevaOC.aspx");
    }

    protected void ib_editar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;

        string numero = gvRequerimientos.Rows[1].Cells[0].Text;
        string fecha = gvRequerimientos.Rows[row.RowIndex].Cells[1].Text;
        string CCODSOLI = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CCODSOLI"].ToString().Trim();
        string CODAREA = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CCODAREA"].ToString().Trim();
        string CCENCOS = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CCENCOS"].ToString().Trim();
        string RUC = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CPRVSUG"].ToString().Trim();
        string USEA01 = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSEA01"].ToString().Trim();
        string USEA02 = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSEA02"].ToString().Trim();
        string USEA03 = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSEA03"].ToString().Trim();
        string estado = gvRequerimientos.Rows[row.RowIndex].Cells[3].Text;
        string usuario = gvRequerimientos.DataKeys[row.RowIndex].Values["RC_CUSUCRE"].ToString().Trim();
        string usuariosession = Session["codusu"].ToString().Trim();

        string fechaX = "01/01/2000";

        string user1 = string.Empty; string user2 = string.Empty; string user3 = string.Empty;
        string fecha1 = fechaX; string fecha2= fechaX; string fecha3= fechaX;

        if (USEA01 == string.Empty && USEA02 == string.Empty && USEA03 == string.Empty)
        {
            user1 = usuariosession;
            fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
        }
        if (USEA01 != string.Empty && USEA02 == string.Empty && USEA03 == string.Empty)
        {
            user1 = USEA01;
            user2 = usuariosession;
            fecha2 = DateTime.Now.ToString("dd/MM/yyyy");
        }
        if (USEA01 != string.Empty && USEA02 != string.Empty && USEA03 == string.Empty)
        {
            user1 = USEA01;
            user2 = USEA02;
            user3 = usuariosession;
            fecha3 = DateTime.Now.ToString("dd/MM/yyyy");
        }

        AL0003REQC rec = new AL0003REQC()
        {
            RC_CNROREQ = numero,
            RC_CESTADO = ((user1 != string.Empty && user2 != string.Empty && user3 != string.Empty) ? "7" : "1"),
            RC_CUSEA01 = user1,
            RC_CUSEA02 = user2,
            RC_CUSEA03 = user3,
            RC_DFECA01 = Convert.ToDateTime( fecha1),
            RC_DFECA02 = Convert.ToDateTime(fecha2),
            RC_DFECA03 = Convert.ToDateTime(fecha3),
            RC_CTIPAPR= ((user1 != string.Empty && user2 != string.Empty && user3 != string.Empty) ? "T" : string.Empty)

        };
        AL0003REQC.apruebaRequerimiento(rec);

        AL0003REQD REEQ = new AL0003REQD()
        {
            RD_CNROREQ= numero,
            RD_CSITUA = "7"
        };

        List<VISTA_AL0003REQD> LISTA = AL0003REQD.ListarRequerimientosPorCodigo(REEQ);

        foreach (VISTA_AL0003REQD item in LISTA )
        {
            REEQ.RD_CITEM = item.RD_CITEM;
            AL0003REQD.apruebaRequerimiento(REEQ);
        };


       

        VISTA_REQUERIMIENTOS REQ = new VISTA_REQUERIMIENTOS()
        {
            ANIO = Convert.ToInt32(ddlPeriodo.SelectedItem.Text),
            MES = Convert.ToInt32(ddlmes.SelectedValue),
            RC_CUSUCRE = ddlUsuario.SelectedValue,
            RC_CESTADO = ddlestado.SelectedValue,
            USUARIO = hfproducto.Value

        };
        
        gvRequerimientos.DataSource = AL0003REQC.ListarRequerimientos(REQ);
        gvRequerimientos.DataBind();

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
   
    public void FILTROAPROB()
    {
        string PERMISO = UT0030.Mostrarinfousuario(lblusuario.Text).TU_LOCEMI;

        if (PERMISO != "F")
        {

            lblpermiso.Text = Convert.ToString(PERMISO);
        }
        else
        {
            lblpermiso.Text = "";
        }

    }

}
