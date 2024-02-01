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

public partial class verOC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            txtCantidaad.Attributes.Add("onkeydown", "soloNumeros();");
            string numero = Request.QueryString["numero"];
            string descrip = string.Empty;

            AL0003REQC rec = new AL0003REQC()
            {
                RC_CNROREQ = numero
            };
            rec = AL0003REQC.obtenerRequerimientoPorNumero(rec);

            lblcodcosto.Text = rec.RC_CCENCOS;
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "R3";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CAREARQ;


            ddlArea.DataTextField = "TG_CDESCRI";
            ddlArea.DataValueField = "TG_CCLAVE";
            if (numero == null)
                ddlArea.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddlArea.DataSource = AL0003TABL.ListarTablaMod(TABL);
            ddlArea.DataBind();


            TABL.TG_CCOD = "12";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CCODSOLI;

            ddlsolicitante.DataTextField = "TG_CDESCRI";
            ddlsolicitante.DataValueField = "TG_CCLAVE";
            if (numero == null)
                ddlsolicitante.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddlsolicitante.DataSource = AL0003TABL.ListarTablaMod(TABL);
           ddlsolicitante.DataBind();


            TABL.TG_CCOD = "74";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CCODAREA;

            ddltipo.DataTextField = "TG_CDESCRI";
            ddltipo.DataValueField = "TG_CCLAVE";
           if (numero == null)
                ddltipo.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddltipo.DataSource = AL0003TABL.ListarTablaMod(TABL);
            ddltipo.DataBind();


            TABL.TG_CCOD = "10";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CCENCOS;

            ddlccosto.DataTextField = "TG_CDESCRI";
            ddlccosto.DataValueField = "TG_CCLAVE";
            if (numero == null)
                ddlccosto.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddlccosto.DataSource = AL0003TABL.ListarTablaMod(TABL);
            ddlccosto.DataBind();

            TABL.TG_CCOD = "R1";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CORIREQ;
            
            ddluso.DataTextField = "TG_CDESCRI";
            ddluso.DataValueField = "TG_CCLAVE";
            if (numero == null)
                ddluso.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddluso.DataSource = AL0003TABL.ListarTablaMod(TABL);
            ddluso.DataBind();


            TABL.TG_CCOD = "R2";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CTIPREQ;

            ddlPrioridad.DataTextField = "TG_CDESCRI";
            ddlPrioridad.DataValueField = "TG_CCLAVE";
            if (numero == null)
                ddlPrioridad.DataSource = AL0003TABL.ListarTabla(TABL);
            else
                ddlPrioridad.DataSource = AL0003TABL.ListarTablaMod(TABL);
            ddlPrioridad.DataBind();

            if (numero == null)
            {
                txtnroreq.Text = Cls_Utilidades.llenaConceros((FT0003NUME.ListarRequerimientos().TN_NNUMERO + 1).ToString(), 7);
                txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
                ddlArea.Items.Insert(0, new ListItem("[AREA]", "-1"));
                ddlsolicitante.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));
                ddltipo.Items.Insert(0, new ListItem("[TIPO]", "-1"));
                ddlccosto.Items.Insert(0, new ListItem("[CCOSTO]", "-1"));
                ddluso.Items.Insert(0, new ListItem("[USO]", "-1"));
                ddlPrioridad.Items.Insert(0, new ListItem("[PRIORIDAD]", "-1"));

            }
            else
            {
                //if (rec.RC_CESTADO !="1")
                //    Response.Redirect("listadoOC.aspx");
                txtdias.Text = rec.RC_CAGEOT;
                txtnroreq.Enabled = false;
                DateTime fech = Convert.ToDateTime(rec.RC_DFECREQ);
                txtFecha.Text =  fech.ToString("dd/MM/yyyy");
                btnGrabar.Visible = false;
                btnModificarcab.Visible = false;
                //pnCabecera.Enabled = true;
                //pnDetalle.Enabled = true;
                txtnroreq.Text = numero;

                hfproveedor.Value = rec.RC_CPRVSUG.Trim();
                txtProveedor.Text= CT0003ANEX.obtenProveedor(rec.RC_CPRVSUG.Trim()).ADESANE.ToString();

                txtObserv1.Text = rec.RC_CGLOSA1;
                txtObserv2.Text = rec.RC_CGLOSA2;
                txtcotiz.Text = rec.RC_CNUMCOT;

                AL0003REQD red = new AL0003REQD()
                {
                    RD_CNROREQ = txtnroreq.Text
                };
                rec = AL0003REQC.obtenerRequerimientoPorNumero(rec);
                gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(red);
                gvDetalle.DataBind();
            }
        }
    }
    public void valida()
    {
        if (ddlsolicitante.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        if (ddlccosto.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
            return;
        }
        if (ddluso.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Uso"), false);
            return;
        }
        if (ddlPrioridad.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Prioridad"), false);
            return;
        }
        if (ddlArea.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Area"), false);
            return;
        }
    }
    protected void btnGrabar_Click(object sender, EventArgs e)
    {

        if (ddlsolicitante.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        if (ddlccosto.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
            return;
        }
        if (ddluso.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Uso"), false);
            return;
        }
        if (ddlPrioridad.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Prioridad"), false);
            return;
        }
        if (ddlArea.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Area"), false);
            return;
        }
        AL0003REQC rec = new AL0003REQC()
        {
            RC_CNROREQ = txtnroreq.Text,
            RC_DFECREQ = Convert.ToDateTime(txtFecha.Text),
            RC_CCODSOLI = ddlsolicitante.SelectedValue.Trim(),
            RC_CCODAREA = ddltipo.SelectedValue.Trim(),
            RC_CCENCOS = ddlccosto.SelectedValue.Trim(),
            RC_CPRVSUG = hfproveedor.Value.Trim(),
            RC_CESTADO = "1",
            RC_CUSEA01 = string.Empty,
            RC_CUSEA02 = string.Empty,
            RC_CUSEA03 = string.Empty,
            RC_DFECA01 = null,
            RC_DFECA02 = null,
            RC_DFECA03 = null,
            RC_CUNIREQ = string.Empty,
            RC_CCODMON = "MN",
            RC_NIMPMN = 0,
            RC_NIMPUS = 0,
            RC_NTIPCAM = 0,
            RC_CAGEOT = string.Empty,
            RC_CNUMOT = string.Empty,
            RC_CORIREQ = ddluso.SelectedValue.Trim(),
            RC_CTIPREQ = ddlPrioridad.SelectedValue.Trim(),
            RC_CUSUCRE = Session["codusu"].ToString(),
            RC_DFECCRE = DateTime.Now,
            RC_CNUMORD = string.Empty,
            RC_CGLOSA1 = txtObserv1.Text,
            RC_CGLOSA2 = txtObserv2.Text,
            RC_CTIPAPR = string.Empty,
            RC_CAREARQ = ddlArea.SelectedValue.Trim(),
            RC_CNUMCOT = txtcotiz.Text 
        };
        AL0003REQC.insertaRequerimiento(rec);

        FT0003NUME ft = new FT0003NUME()
        {
            TN_CCODIGO = "RQ",
            TN_CNUMSER = "001",
            TN_NNUMINI = 1,
            TN_NNUMFIN = 9999999,
            TN_CDESCRI = "REQUISICION",
            TN_NNUMERO = Convert.ToInt32(txtnroreq.Text),
            TN_CUSUCRE = Session["codusu"].ToString(),
            TN_DFECCRE = DateTime.Now,
            TN_CUSUMOD = Session["codusu"].ToString(),
            TN_DFECMOD = DateTime.Now,
            TN_CFORMAT = ".",
            TN_CCODAGE = "0001",
            TN_CESTACI = ".",
            TN_CPUERTO = ".",
            TN_CNUMAUT = ".",
            TN_CRUTFW = ".",
            TN_CRUTFW2 = ".",
            TN_CPRINTE = ".",
            TN_CTIPLET = ".",
            TN_NTAMLET =0,
            TN_CMODIMP = ".",
            TN_CTIPIMP = ".",
            TN_CTIPMAQ = ".",
            TN_NMARIZQ =0,
            TN_NMARSUP=0

        };
        FT0003NUME.actualizaNumeracion(ft);

        pnCabecera.Enabled = false;
        pnDetalle.Enabled = true; 
    }
   
protected void btnAgregar_Click(object sender, EventArgs e)
    {
        string item = AL0003REQD.CuentaDetalleReq(txtnroreq.Text).ToString();
        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = Cls_Utilidades.llenaConceros(item,4),
            RD_CCODIGO = hfproducto.Value,
            RD_CDESCRI =  ((txtproducto.Text.Length > 50) ? txtproducto.Text.Substring(0, 49) : txtproducto.Text) ,
            RD_CUNID = AL0003ARTI.obtenerArticuloPorID(hfproducto.Value).AR_CUNIDAD,
            RD_NQPEDI= Convert.ToInt32 ( txtCantidaad.Text),
            RD_CCENCOS= ddlccosto.SelectedValue.Trim(),
            RD_COBS= txtObserva.Text ,
            RD_NQATEN=0,
            RD_CSITUA ="1",
            RD_NQINGALM=0,
            RD_NQDESPA=0,
            RD_NCANAPR= Convert.ToInt32(txtCantidaad.Text),
            RD_NPRUNMN = 0,
            RD_NPRUNUS = 0,
            RD_NPRU2MN = 0,
            RD_NPRU2US = 0,
            RD_NIGV = 0,
            RD_NIGVPOR = 0,
            RD_NTOTMN = 0,
            RD_NTOTUS = 0,
            RD_NDSCPOR = 0,
            RD_NDESCTO=0,
            RD_CUSRAPR=string.Empty,
            RD_DFUSAPR=null ,
            RD_NCANALM=0,
            RD_CTR=".",
            RD_DFECASG=null ,
            RD_CCODCOM = ".",
            RD_CFLGASG = ".",
            RD_CUSRCOM = ".",
        };
        AL0003REQD.insertaRequerimiento(rec);

        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec);
        gvDetalle.DataBind();
    }

    protected void ibEliminar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;

        string item = gvDetalle.Rows[row.RowIndex].Cells[0].Text;

        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = item
        };
        AL0003REQD.EliminarDetalleRequerimiento(rec);
        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec);
        gvDetalle.DataBind();

    }

    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;

        hfitem.Value = gvDetalle.Rows[row.RowIndex].Cells[0].Text;
        hfproducto.Value = gvDetalle.Rows[row.RowIndex].Cells[1].Text;
        txtproducto.Text = HttpUtility.HtmlDecode(gvDetalle.Rows[row.RowIndex].Cells[2].Text);
        txtCantidaad.Text = gvDetalle.Rows[row.RowIndex].Cells[4].Text;
        txtObserva.Text = HttpUtility.HtmlDecode( gvDetalle.Rows[row.RowIndex].Cells[5].Text);

      
    }



    protected void btnModificar_Click(object sender, EventArgs e)
    {
        string item = hfitem.Value;
        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = item,
            RD_CCODIGO = hfproducto.Value,
            RD_CDESCRI = ((txtproducto.Text.Length > 50) ? txtproducto.Text.Substring(0, 49) : txtproducto.Text),
            RD_CUNID = AL0003ARTI.obtenerArticuloPorID(hfproducto.Value).AR_CUNIDAD,
            RD_NQPEDI = Convert.ToInt32(txtCantidaad.Text),
            RD_CCENCOS = ddlccosto.SelectedValue.Trim(),
            RD_COBS = txtObserva.Text,
            RD_NQATEN = 0,
            RD_CSITUA = "1",
            RD_NQINGALM = 0,
            RD_NQDESPA = 0,
            RD_NCANAPR = Convert.ToInt32(txtCantidaad.Text),
            RD_NPRUNMN = 0,
            RD_NPRUNUS = 0,
            RD_NPRU2MN = 0,
            RD_NPRU2US = 0,
            RD_NIGV = 0,
            RD_NIGVPOR = 0,
            RD_NTOTMN = 0,
            RD_NTOTUS = 0,
            RD_NDSCPOR = 0,
            RD_NDESCTO = 0,
            RD_CUSRAPR = string.Empty,
            RD_DFUSAPR =null,
            RD_NCANALM = 0,
            RD_CTR = ".",
            RD_DFECASG = DateTime.Now,
            RD_CCODCOM = ".",
            RD_CFLGASG = ".",
            RD_CUSRCOM = ".",
        };
        AL0003REQD.modificarRequerimiento(rec);

        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec);
        gvDetalle.DataBind();
    }

    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Cls_RecursosWeb web = new Cls_RecursosWeb();

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "Total=";
            e.Row.Cells[4].Text = Math.Round(web.totalizaGridview(gvDetalle, 4), 4).ToString();

        }
    }

    protected void btnModificarcab_Click(object sender, EventArgs e)
    {
        if (ddlsolicitante.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        if (ddlccosto.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
            return;
        }
        if (ddluso.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Uso"), false);
            return;
        }
        if (ddlPrioridad.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Prioridad"), false);
            return;
        }
        if (ddlArea.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Area"), false);
            return;
        }
        AL0003REQC rec = new AL0003REQC()
        {
            RC_CNROREQ = txtnroreq.Text,
            RC_DFECREQ = Convert.ToDateTime(txtFecha.Text),
            RC_CCODSOLI = ddlsolicitante.SelectedValue.Trim(),
            RC_CCODAREA = ddltipo.SelectedValue.Trim(),
            RC_CCENCOS = ddlccosto.SelectedValue.Trim(),
            RC_CPRVSUG = hfproveedor.Value.Trim(),
            RC_CESTADO = "1",
            RC_CUSEA01 = string.Empty,
            RC_CUSEA02 = string.Empty,
            RC_CUSEA03 = string.Empty,
            RC_DFECA01 = null,
            RC_DFECA02 = null,
            RC_DFECA03 = null,
            RC_CUNIREQ = string.Empty,
            RC_CCODMON = "MN",
            RC_NIMPMN = 0,
            RC_NIMPUS = 0,
            RC_NTIPCAM = 0,
            RC_CAGEOT = string.Empty,
            RC_CNUMOT = string.Empty,
            RC_CORIREQ = ddluso.SelectedValue.Trim(),
            RC_CTIPREQ = ddlPrioridad.SelectedValue.Trim(),
            RC_CUSUCRE = Session["codusu"].ToString(),
            RC_DFECCRE = DateTime.Now,
            RC_CNUMORD = string.Empty,
            RC_CGLOSA1 = txtObserv1.Text,
            RC_CGLOSA2 = txtObserv2.Text,
            RC_CTIPAPR = string.Empty,
            RC_CAREARQ = ddlArea.SelectedValue.Trim(),
            RC_CNUMCOT = txtcotiz.Text
        };
        AL0003REQC.modifcaRequerimiento(rec);
    }
}

