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

public partial class nuevaOC : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            txtCantidaad.Attributes.Add("onkeydown", "soloNumeros();");
            txtdias.Attributes.Add("onkeydown", "soloNumeros();");
            string numero = Request.QueryString["numero"];
            string descrip = string.Empty;

            AL0003REQC rec = new AL0003REQC()
            {
                RC_CNROREQ = numero
            };
            rec = AL0003REQC.obtenerRequerimientoPorNumero(rec);


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

            ddlsolicitantedet.DataTextField = "TG_CDESCRI";
            ddlsolicitantedet.DataValueField = "TG_CCLAVE";
            if (numero == null)
            {
                ddlsolicitante.DataSource = AL0003TABL.ListarTabla(TABL);
                ddlsolicitantedet.DataSource = AL0003TABL.ListarTabla(TABL);
            }
            else
            {
                ddlsolicitante.DataSource = AL0003TABL.ListarTablaMod(TABL);
                ddlsolicitantedet.DataSource = AL0003TABL.ListarTabla(TABL);
            }
           ddlsolicitante.DataBind();
           ddlsolicitantedet.DataBind();


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

            ddlcostodet.DataTextField = "TG_CDESCRI";
            ddlcostodet.DataValueField = "TG_CCLAVE";

         

            if (numero == null)
            {
                ddlccosto.DataSource = AL0003TABL.ListarTabla(TABL);
                ddlcostodet.DataSource = AL0003TABL.ListarTabla(TABL);
            }
            else
            {
                ddlccosto.DataSource = AL0003TABL.ListarTablaMod(TABL);
                ddlcostodet.DataSource = AL0003TABL.ListarTabla(TABL);
            }
            ddlccosto.DataBind();
            ddlcostodet.DataBind();

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
                ddlcostodet.Items.Insert(0, new ListItem("[CCOSTO]", "-1"));
                ddlsolicitantedet.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));

            }
            else
            {
                if (rec.RC_CESTADO !="1")
                    Response.Redirect("listadoOC.aspx");

                txtdias.Text = rec.RC_CAGEOT;

                txtnroreq.Enabled = false;
                DateTime fech = Convert.ToDateTime(rec.RC_DFECREQ);
                txtFecha.Text =  fech.ToString("dd/MM/yyyy");
                btnGrabar.Visible = false;
                btnModificarcab.Visible = true;
                pnCabecera.Enabled = true;
                pnDetalle.Enabled = true;
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
        if (txtdias.Text  == string.Empty || txtdias.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Número de días, debe ser mayor a cero"), false);
            return;
        }

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
        AL0003REQC recx = new AL0003REQC()
        {
            RC_CNROREQ = txtnroreq.Text
        };
     if ( AL0003REQC.obtenerRequerimientoPorNumero(recx)!=null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Número ocupado,vuelva a generar"), false);
            Response.Redirect("listadoOC.aspx");
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
            RC_CAGEOT = txtdias.Text,
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
            RC_CNUMCOT = ((txtcotiz.Text.Length > 20) ? txtcotiz.Text.Substring(0, 19) : txtcotiz.Text)
            
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
        
        if (hfproducto.Value == null|| hfproducto.Value == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Producto no existe"), false);
            return;
        }

        if (txtCantidaad.Text == string.Empty || txtCantidaad.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Cantidad, debe ser mayor a cero"), false);
            return;
        }

        if (ddlcostodet.SelectedValue=="-1" )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Seleccione Centro de Costo"), false);
            return;
        }
        if (ddlsolicitantedet.SelectedValue=="-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Seleccione Solicitante"), false);
            return;
        }

        string item = AL0003REQD.CuentaDetalleReq(txtnroreq.Text).ToString();
        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = Cls_Utilidades.llenaConceros(item, 4),
            RD_CCODIGO = hfproducto.Value,
            RD_CDESCRI = ((txtproducto.Text.Length > 50) ? txtproducto.Text.Substring(0, 49) : txtproducto.Text),
            RD_CUNID = AL0003ARTI.obtenerArticuloPorID(hfproducto.Value).AR_CUNIDAD,
            RD_NQPEDI = Convert.ToInt32(txtCantidaad.Text),
            RD_CCENCOS = ddlcostodet.SelectedValue.Trim(),
            RD_COBS = ((txtObserva.Text.Length > 40) ? txtObserva.Text.Substring(0, 39) : txtObserva.Text),
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
            RD_DFUSAPR = null,
            RD_NCANALM = 0,
            RD_CTR = ".",
            RD_DFECASG = null,
            RD_CCODCOM = ".",
            RD_CFLGASG = ".",
            RD_CUSRCOM = ddlsolicitantedet.SelectedValue.Trim()
        };
        AL0003REQD.insertaRequerimiento(rec);

        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec);
        gvDetalle.DataBind();
        hfproducto.Value = null;
        txtproducto.Text = string.Empty;
        txtCantidaad.Text = string.Empty;
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
        string codsolicita = gvDetalle.DataKeys[row.RowIndex].Values["RD_CUSRCOM"].ToString().Trim(); 
        string codcosto = gvDetalle.DataKeys[row.RowIndex].Values["RD_CCENCOS"].ToString().Trim(); 


        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "10",
            TG_CCLAVE = codcosto
        };

        if (AL0003TABL.cuentaTablaMod(TABL) > 0)
        {
            buscaTabla("10", codcosto, ddlcostodet);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Centro de Costo no existe"), false);


        AL0003TABL TABL1 = new AL0003TABL()
        {
            TG_CCOD = "12",
            TG_CCLAVE = codsolicita
        };

        if (AL0003TABL.cuentaTablaMod(TABL1) > 0)
        {
            buscaTabla("12", codsolicita, ddlsolicitantedet);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Solicitante no existe"), false);


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
            RD_CCENCOS = ddlcostodet.SelectedValue.Trim(),
            RD_COBS = ((txtObserva.Text.Length > 40) ? txtObserva.Text.Substring(0, 39) : txtObserva.Text),
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
            RD_CUSRCOM = ddlsolicitantedet.SelectedValue.Trim()
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
            RC_CAGEOT = txtdias.Text,
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
            RC_CNUMCOT = ((txtcotiz.Text.Length > 20) ? txtcotiz.Text.Substring(0, 19) : txtcotiz.Text)
        };
        AL0003REQC.modifcaRequerimiento(rec);
    }

    protected void txtccosto_TextChanged(object sender, EventArgs e)
    {
        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "10",
            TG_CCLAVE = txtccosto.Text
        };

        if (AL0003TABL.cuentaTablaMod(TABL) >0)
        {
            buscaTabla("10",txtccosto.Text, ddlccosto);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Centro de Costo no existe"), false);
        txtccosto.Text = string.Empty;
    }

    public void   buscaTabla(string TG_CCOD,string variable,DropDownList ddl)
    {
        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = TG_CCOD;
        TABL.TG_CCLAVE = variable;
        ddl.DataTextField = "TG_CDESCRI";
        ddl.DataValueField = "TG_CCLAVE";
        ddl.DataSource = AL0003TABL.ListarTablaMod(TABL);
        ddl.DataBind();
    }

    protected void txtcostodet_TextChanged(object sender, EventArgs e)
    {
        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "10",
            TG_CCLAVE = txtcostodet.Text
        };

        if (AL0003TABL.cuentaTablaMod(TABL) > 0)
        {
            buscaTabla("10",txtcostodet.Text, ddlcostodet);
        }
        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Centro de Costo no existe"), false);
        txtcostodet.Text = string.Empty;
    }
}

