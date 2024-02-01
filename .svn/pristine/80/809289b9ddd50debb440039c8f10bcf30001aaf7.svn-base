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
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static AL0003ARTI  UltimolPrecioPorProducto(AL0003REQD REQ)
    {

        var xxx = CO0003MOVC.UltimolPrecioPorProducto(REQ);
        var det = new AL0003ARTI()
        {
            AR_CTIPDES = xxx.OC_CCODMON,
            AR_NPRECI2 = xxx.OC_NTIPCAM,
            AR_NPRECI3 = xxx.OC_NIMPMN
        };
       
        return det;
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003TABL> GetCentroCosto(string productos)
    {
        return AL0003TABL.Listartablaxcodigo(productos, "10");
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003TABL> GetSolicitante(string productos)
    {
        return AL0003TABL.Listartablaxcodigo(productos, "12");
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos)
    {
        return AL0003ARTI.ListarArticulos(productos.Trim ());
    }

    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {

            List<AL0003TABL> listamoneda = new List<AL0003TABL>();
                // Add parts to the list.
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";

            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();


            txtlbltcambio.Attributes.Add("onkeydown", "soloNumeros();");
            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
          
            txtCantidaad.Attributes.Add("onkeydown", "soloNumeros();");
            txtdias.Attributes.Add("onkeydown", "soloNumeros();");
            string numero = Request.QueryString["numero"];
            string descrip = string.Empty;

            AL0003REQC rec = new AL0003REQC()
            {
                RC_CNROREQ = numero
            };
            rec = AL0003REQC.obtenerRequerimientoPorNumero(rec);

            txtsolicitante.Text = rec==null? string.Empty : rec.RC_CCODSOLI ;
            txtccosto.Text = rec == null ? string.Empty : rec.RC_CCENCOS;

            txtsolicitante_TextChanged(null, null);
            txtccosto_TextChanged(null, null);
           

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

          

            List<tabla_trabajo> tc, tc1 = new List<tabla_trabajo>();
            tabla_trabajo tc2;
            ddltrabajoencurso.DataTextField = "DESCRIPCION";
            ddltrabajoencurso.DataValueField = "TR_CODIGO";
            tc = tabla_trabajo.ListarTrabajosAprobados();
            foreach (var x in tc)
            {
                tc2 = new tabla_trabajo();
                tc2.TR_CODIGO = x.TR_CODIGO;
                tc2.DESCRIPCION = x.TR_CODIGO + " " + x.DESCRIPCION;
                tc1.Add(tc2);
            }
            if (numero == null)
            {
                ddltrabajoencurso.DataSource = tc1;
                ddltrabajoencurso.DataBind();
            }
            else
            {
                var aa = ddlArea.SelectedValue.Trim();
                if (aa == "03")
                {
                    var xx = rec.RC_CNUMOT;
                    var zz = tc1.Where(x => x.TR_CODIGO.Trim() == xx.Trim()).Union(tc1.Where(x => x.TR_CODIGO.Trim() != xx.Trim()));
                    ddltrabajoencurso.DataSource = zz;
                    ddltrabajoencurso.DataBind();
                    pntrabajocurso.Visible = true;

                    ddltrabajoencurso_SelectedIndexChanged(null, null);
                }
                else
                    pntrabajocurso.Visible = false;
            }
            ////////jimmy





            TABL.TG_CCOD = "12";
            if (numero != null)
                TABL.TG_CCLAVE = rec.RC_CCODSOLI;

           

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
                //ddlsolicitante.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));
                ddltipo.Items.Insert(0, new ListItem("[TIPO]", "-1"));
                //ddlccosto.Items.Insert(0, new ListItem("[CCOSTO]", "-1"));
                ddluso.Items.Insert(0, new ListItem("[USO]", "-1"));
                ddlPrioridad.Items.Insert(0, new ListItem("[PRIORIDAD]", "-1"));
                //ddlcostodet.Items.Insert(0, new ListItem("[CCOSTO]", "-1"));
                //ddlsolicitantedet.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));
                ddltrabajoencurso.Items.Insert(0, new ListItem("[TRABAJO EN CURSO]", "-1"));

            }
            else
            {
                txttrabajoencurso.Enabled = false;
                ddltrabajoencurso.Enabled = false;

                if (rec.RC_CESTADO !="1")
                    Response.Redirect("listadoOC.aspx");

                txtdias.Text = rec.RC_CAGEOT;

                txtnroreq.Enabled = false;
                DateTime fech = Convert.ToDateTime(rec.RC_DFECREQ);
                txtFecha.Text =  fech.ToString("dd/MM/yyyy");
                txtFecha_TextChanged(null, null);
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
                    RD_CNROREQ = txtnroreq.Text,

                };
                if (ddlArea.SelectedValue.Trim() == "03")
                {
                    red.RD_CCODCOM = txtmonedatc.Text;
                }
                    rec = AL0003REQC.obtenerRequerimientoPorNumero(rec);
                gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(red);
                gvDetalle.DataBind();
            }

            CTCAMB CT = new CTCAMB()
            {
                XFECCAM2 = Convert.ToDateTime(txtFecha.Text)
            };

            CT = CTCAMB.obetenertcambio(CT);//.XMEIMP2.ToString();
            if (CT != null)
                txtlbltcambio.Text = CTCAMB.obetenertcambio(CT).XMEIMP2.ToString();
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Actualice el tipo de cambio"), false);


        }
    }
    public void valida()
    {
        //if (ddlsolicitante.SelectedValue == "-1")
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
        //    return;
        //}
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        //if (ddlccosto.SelectedValue == "-1")
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
        //    return;
        //}
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

        if (ddlArea.SelectedValue.Trim() == "03")
        {
            if (ddltrabajoencurso.SelectedValue.Trim() == "-1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Trabajo en curso"), false);
                return;
            }
        }

        if (txtlbltcambio.Text == string.Empty || txtlbltcambio.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Tipo de cambio inválido"), false);
            return;
        }


        if (txtdias.Text  == string.Empty || txtdias.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Número de días, debe ser mayor a cero"), false);
            return;
        }

        if (txtsolicitante.Text  == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        if (txtccosto.Text  == string.Empty  )
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
            RC_CCODSOLI = txtsolicitante.Text.Trim(),
            RC_CCODAREA = ddltipo.SelectedValue.Trim(),
            RC_CCENCOS = txtccosto.Text.Trim() ,
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
            RC_CNUMOT = ddltrabajoencurso.SelectedValue.Trim(),
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

        if (hfprecio.Value != string.Empty && hfprecio.Value != "0")
        {
            txtprecio.Text = hfprecio.Value;
            txtprecio.Enabled = false;
            ddlmoneda.Enabled = false;
       
            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            if (hfmoneda.Value == "MN")
            {
                // Add parts to the list.
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            }
            else
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });

            }

            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";

            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();
        }
        if (hfproducto.Value == null|| hfproducto.Value == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Producto no existe"), false);
            return;
        }
              if (txtlbltcambio.Text == string.Empty || txtlbltcambio.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Tipo de cambio inválido"), false);
            return;
        }

        if (txtCantidaad.Text == string.Empty || txtCantidaad.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Cantidad, debe ser mayor a cero"), false);
            return;
        }
        var  sumagrid= Convert.ToDecimal (0)  ;

        if (gvDetalle.Rows.Count > 0)
        {
            for (int i = 0; i <= gvDetalle.Rows.Count-1; i++)
            {
                var grid = gvDetalle.Rows[i].Cells[9].Text;
                sumagrid = sumagrid + Convert.ToDecimal(gvDetalle.Rows[i].Cells[9].Text);
            }
        }
        if (txtcostodet.Text  == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Seleccione Centro de Costo"), false);
            return;
        }
        if (txtsolicitante0.Text  == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Seleccione Solicitante"), false);
            return;
        }

        if (ddlArea.SelectedValue.Trim() == "03")
        {
            if (Convert.ToDecimal(txtprecio.Text) <=0)
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Ingrese precio referencial"), false);
                return;
            }
        }

        var a = ddlmoneda.SelectedValue;//  hfmoneda.Value==string.Empty ? txtmonedatc.Text  : hfmoneda.Value;
        var b = (hftcambio.Value==string.Empty || hftcambio.Value=="0") ? Convert.ToDecimal ( txtlbltcambio.Text) :  Convert.ToDecimal ( hftcambio.Value);
        var c = Convert.ToDecimal(txtprecio.Text);

        string item = AL0003REQD.CuentaDetalleReq(txtnroreq.Text).ToString();
        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = Cls_Utilidades.llenaConceros(item, 4),
            RD_CCODIGO = hfproducto.Value,
            RD_CDESCRI = ((txtproducto.Text.Length > 50) ? txtproducto.Text.Substring(0, 49) : txtproducto.Text),
            RD_CUNID = AL0003ARTI.obtenerArticuloPorID(hfproducto.Value).AR_CUNIDAD,
            RD_NQPEDI = Convert.ToInt32(txtCantidaad.Text),
            RD_CCENCOS = txtcostodet.Text.Trim(),
            RD_COBS = ((txtObserva.Text.Length > 40) ? txtObserva.Text.Substring(0, 39) : txtObserva.Text),
            RD_NQATEN = 0,
            RD_CSITUA = "1",
            RD_NQINGALM = 0,
            RD_NQDESPA = 0,
            RD_NCANAPR = Convert.ToInt32(txtCantidaad.Text),
            RD_NPRUNMN = 0,
            RD_NPRUNUS = 0,
            RD_NPRU2MN = a == "MN" ? c : c * b,
            RD_NPRU2US = a == "US" ? c : b == 0 ? 0 : (c / b),
            RD_NIGV = 0,
            RD_NIGVPOR = 0,
            RD_NTOTMN = Convert.ToInt32(txtCantidaad.Text) * (a == "MN" ? c : c * b),
            RD_NTOTUS = Convert.ToInt32(txtCantidaad.Text) * (a == "US" ? c : b == 0 ? 0 : (c / b)),
            RD_NDSCPOR = 0,
            RD_NDESCTO = 0,
            RD_CUSRAPR = string.Empty,
            RD_DFUSAPR = null,
            RD_NCANALM = 0,
            RD_CTR = ".",
            RD_DFECASG = null,
            RD_CCODCOM = a,
            RD_CFLGASG = ".",
            RD_CUSRCOM = txtsolicitante0.Text.Trim()
        };

        var band =Convert.ToDecimal ( 0);
        band =  (txtmonedatc.Text == "MN" ? rec.RD_NTOTMN : rec.RD_NTOTUS); //Convert.ToInt32(txtCantidaad.Text) * (a == "MN" ? c : c * b);

        if (ddlArea.SelectedValue.Trim() == "03")
        {
            if (band > Convert.ToDecimal(txtsaldo.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("No se debe exeder el saldo"), false);
                return;
            }
        }
        AL0003REQD.insertaRequerimiento(rec);
  
        var   lista = AL0003REQD.obtenerRequerimientoPorNumero(txtnroreq.Text);
        var suma_soles = Convert.ToDecimal ( 0);
        var suma_dolares = Convert.ToDecimal(0) ;
        foreach (var x in lista )
        {
            suma_soles = suma_soles+ x.RD_NTOTMN;
            suma_dolares = suma_dolares + x.RD_NTOTUS;
        }
        AL0003REQC.actualizaValoresRequerimineto(txtnroreq.Text,txtmonedatc.Text  , suma_soles, suma_dolares,Convert.ToDecimal ( txtlbltcambio.Text ));

        AL0003REQD rec1 = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CCODCOM = txtmonedatc.Text==string.Empty ? "MN" : txtmonedatc.Text
        };


        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec1);
        gvDetalle.DataBind();

        hfproducto.Value = null;
        txtproducto.Text = string.Empty;
        txtCantidaad.Text = string.Empty;
        hfprecio.Value = null;
        hftotal.Value = null;

        ////////////////////////////////////////////////////
        tabla_trabajo CODATA = new tabla_trabajo()
        { TR_CODIGO = ddltrabajoencurso.SelectedValue.Trim() };
        var tc3 = tabla_detalle.DETALLE(CODATA);
        var acumulado = (decimal?)(0);
        foreach (var t in tc3)
        {
            acumulado = acumulado + (txtmonedatc.Text.Trim()=="MN"? t.MONTOMN:t.MONTOUS) ;
        }
        txtacumulado.Text = acumulado.ToString();

     
        if (ddlArea.SelectedValue.Trim() == "03")
            txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtacumulado.Text)).ToString();
        ////////////////////////////////////////////////////
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
        var lista = AL0003REQD.obtenerRequerimientoPorNumero(txtnroreq.Text);
        var suma_soles = Convert.ToDecimal(0);
        var suma_dolares = Convert.ToDecimal(0);
        foreach (var x in lista)
        {
            suma_soles = suma_soles + x.RD_NTOTMN;
            suma_dolares = suma_dolares + x.RD_NTOTUS;
        }
        AL0003REQC.actualizaValoresRequerimineto(txtnroreq.Text, txtmonedatc.Text, suma_soles, suma_dolares, Convert.ToDecimal(txtlbltcambio.Text));

        ////////////////////////////////////////////////////
        tabla_trabajo CODATA = new tabla_trabajo()
        { TR_CODIGO = ddltrabajoencurso.SelectedValue.Trim() };
        var tc3 = tabla_detalle.DETALLE(CODATA);
        var acumulado = (decimal?)(0);
        foreach (var t in tc3)
        {
            acumulado = acumulado + (txtmonedatc.Text.Trim() == "MN" ? t.MONTOMN : t.MONTOUS);
        }
        txtacumulado.Text = acumulado.ToString();


        if (ddlArea.SelectedValue.Trim() == "03")
            txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtacumulado.Text)).ToString();
        ////////////////////////////////////////////////////

        AL0003REQD rec1 = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CCODCOM = txtmonedatc.Text == string.Empty ? "MN" : txtmonedatc.Text
        };


        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec1);
        gvDetalle.DataBind();

        //gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec);
        //gvDetalle.DataBind();

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
        txtsolicitante0.Text = codsolicita;
        txtcostodet.Text = codcosto;
        txtsolicitante0_TextChanged(null, null);
        txtcostodet_TextChanged(null, null);

       
        hftotal.Value = gvDetalle.Rows[row.RowIndex].Cells[9].Text;

        string moneda = gvDetalle.DataKeys[row.RowIndex].Values["RD_CCODCOM"].ToString().Trim();
        string preciomn = gvDetalle.DataKeys[row.RowIndex].Values["RD_NPRU2MN"].ToString().Trim();
        string precious = gvDetalle.DataKeys[row.RowIndex].Values["RD_NPRU2US"].ToString().Trim();

        hfpreciomn.Value = preciomn;
        hfprecious.Value = precious;

        txtprecio.Text = moneda == "MN" ? preciomn : precious;
        hfprecio.Value = txtprecio.Text;
        hfmoneda.Value = moneda;

        List<AL0003TABL> listamoneda = new List<AL0003TABL>();

        if (moneda == "MN")
        {
            // Add parts to the list.
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
        }
        else
        {
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });

        }
        ddlmoneda.DataTextField = "TG_CCLAVE";
        ddlmoneda.DataValueField = "TG_CCOD";
        ddlmoneda.DataSource = listamoneda;
        ddlmoneda.DataBind();
    }

    protected void btnModificar_Click(object sender, EventArgs e)
    {
        if (hfprecio.Value != string.Empty && hfprecio.Value != "0")
        {
            txtprecio.Text = hfprecio.Value;
            txtprecio.Enabled = false;
            ddlmoneda.Enabled = false;
            List<AL0003TABL> listamoneda = new List<AL0003TABL>();
            if (hfmoneda.Value == "MN")
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            }
            else
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
            }
            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";
            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();
        }

        string item = hfitem.Value;
        AL0003REQD rec = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CITEM = item,
            RD_CCODIGO = hfproducto.Value,
            RD_CDESCRI = ((txtproducto.Text.Length > 50) ? txtproducto.Text.Substring(0, 49) : txtproducto.Text),
            RD_CUNID = AL0003ARTI.obtenerArticuloPorID(hfproducto.Value).AR_CUNIDAD,
            RD_NQPEDI = Convert.ToInt32(txtCantidaad.Text),
            RD_CCENCOS = txtcostodet.Text.Trim(),
            RD_COBS = ((txtObserva.Text.Length > 40) ? txtObserva.Text.Substring(0, 39) : txtObserva.Text),
            RD_NQATEN = 0,
            RD_CSITUA = "1",
            RD_NQINGALM = 0,
            RD_NQDESPA = 0,
            RD_NCANAPR = Convert.ToInt32(txtCantidaad.Text),
            RD_NPRUNMN = 0,
            RD_NPRUNUS = 0,
            RD_NPRU2MN = Convert.ToDecimal (hfpreciomn.Value )  ,
            RD_NPRU2US = Convert.ToDecimal(hfprecious.Value),
            RD_NIGV = 0,
            RD_NIGVPOR = 0,
            RD_NTOTMN = Convert.ToInt32(txtCantidaad.Text) * Convert.ToDecimal(hfpreciomn.Value),
            RD_NTOTUS = Convert.ToInt32(txtCantidaad.Text) * Convert.ToDecimal(hfprecious.Value),
            RD_NDSCPOR = 0,
            RD_NDESCTO = 0,
            RD_CUSRAPR = string.Empty,
            RD_DFUSAPR =null,
            RD_NCANALM = 0,
            RD_CTR = ".",
            RD_DFECASG = DateTime.Now,
            RD_CCODCOM = hfmoneda.Value,
            RD_CFLGASG = ".",
            RD_CUSRCOM = txtsolicitante0.Text.Trim()
        };
        var band = Convert.ToDecimal(0);
        band = (txtmonedatc.Text == "MN" ? rec.RD_NTOTMN : rec.RD_NTOTUS); //Convert.ToInt32(txtCantidaad.Text) * (a == "MN" ? c : c * b);

        if (ddlArea.SelectedValue.Trim() == "03")
        {
            if (band > Convert.ToDecimal(txtsaldo.Text))
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("No se debe exeder el saldo"), false);
                return;
            }
        }

        AL0003REQD.modificarRequerimiento(rec);
        var lista = AL0003REQD.obtenerRequerimientoPorNumero(txtnroreq.Text);
        var suma_soles = Convert.ToDecimal(0);
        var suma_dolares = Convert.ToDecimal(0);
        foreach (var x in lista)
        {
            suma_soles = suma_soles + x.RD_NTOTMN;
            suma_dolares = suma_dolares + x.RD_NTOTUS;
        }
        AL0003REQC.actualizaValoresRequerimineto(txtnroreq.Text, txtmonedatc.Text, suma_soles, suma_dolares, Convert.ToDecimal(txtlbltcambio.Text));

        ////////////////////////////////////////////////////
        tabla_trabajo CODATA = new tabla_trabajo()
        { TR_CODIGO = ddltrabajoencurso.SelectedValue.Trim() };
        var tc3 = tabla_detalle.DETALLE(CODATA);
        var acumulado = (decimal?)(0);
        foreach (var t in tc3)
        {
            acumulado = acumulado + (txtmonedatc.Text.Trim() == "MN" ? t.MONTOMN : t.MONTOUS);
        }
        txtacumulado.Text = acumulado.ToString();
        if (ddlArea.SelectedValue.Trim() == "03")
            txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtacumulado.Text)).ToString();
        ////////////////////////////////////////////////////

        AL0003REQD rec1 = new AL0003REQD()
        {
            RD_CNROREQ = txtnroreq.Text,
            RD_CCODCOM = txtmonedatc.Text == string.Empty ? "MN" : txtmonedatc.Text
        };

        gvDetalle.DataSource = AL0003REQD.ListarRequerimientosPorCodigo(rec1);
        gvDetalle.DataBind();
    }

    protected void gvDetalle_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        Cls_RecursosWeb web = new Cls_RecursosWeb();

        if (e.Row.RowType == DataControlRowType.Footer)
        {
            e.Row.Cells[3].Text = "TOTAL=";
            e.Row.Cells[4].Text = Math.Round(web.totalizaGridview(gvDetalle, 4), 4).ToString();

            e.Row.Cells[8].Text = "TOTAL=";
            e.Row.Cells[9].Text = Math.Round(web.totalizaGridview(gvDetalle, 9), 4).ToString();

        }
    }

    protected void btnModificarcab_Click(object sender, EventArgs e)
    {

        if (ddlArea.SelectedValue.Trim() == "03")
        {
            if (ddltrabajoencurso.SelectedValue.Trim() == "-1")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Trabajo en curso"), false);
                return;
            }
        }

        if (txtlbltcambio.Text == string.Empty || txtlbltcambio.Text == "0")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Tipo de cambio inválido"), false);
            return;
        }


        if (txtsolicitante.Text == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }

        if (txtccosto.Text == string.Empty)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
            return;
        }

        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
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
            RC_CCODSOLI = txtsolicitante.Text.Trim(),  
            RC_CCODAREA = ddltipo.SelectedValue.Trim(),
            RC_CCENCOS = txtccosto.Text.Trim(),
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
            RC_CNUMOT = ddltrabajoencurso.SelectedValue.Trim(),
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


        if (AL0003TABL.Registroxcodigo(txtccosto.Text, "10") != null)
        {
            txtccostosensitivo.Text = AL0003TABL.Registroxcodigo(txtccosto.Text, "10").TG_CDESCRI;
        }


        else
        {
            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Centro de Costo no existe"), false);
            txtccosto.Text = string.Empty;
            txtccostosensitivo.Text = string.Empty;
        }//txtccosto.Text = string.Empty;
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
        if (hfprecio.Value != string.Empty && hfprecio.Value != "0")
        {
            txtprecio.Text = hfprecio.Value;
            txtprecio.Enabled = false;
            ddlmoneda.Enabled = false;
      
            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            if (hfmoneda.Value == "MN")
            {
                // Add parts to the list.
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            }
            else
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });

            }

            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";

            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();
        }

        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "10",
            TG_CCLAVE = txtcostodet.Text
        };


        if (AL0003TABL.Registroxcodigo(txtcostodet.Text, "10") != null)
        {
            txtccostosensitivo0.Text = AL0003TABL.Registroxcodigo(txtcostodet.Text, "10").TG_CDESCRI;
        }
        // buscaTabla("10", txtccosto.Text, ddlccosto);

        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Centro de Costo no existe"), false);

    }

    protected void txtcodprod_TextChanged(object sender, EventArgs e)
    {
        if (AL0003ARTI.obtenerArticuloPorID(txtcodprod.Text) != null)
        {
            hfproducto.Value = txtcodprod.Text;
            txtproducto.Text = AL0003ARTI.obtenerArticuloPorID(txtcodprod.Text).AR_CDESCRI;

            var REQ = new AL0003REQD()
            {
                RD_CCODIGO = txtcodprod.Text 
            };

            var xxx = CO0003MOVC.UltimolPrecioPorProducto(REQ);
            var a = xxx.OC_CCODMON;
            var b = xxx.OC_NTIPCAM;
            var c = xxx.OC_NIMPMN;

            hfmoneda.Value = a;
            hftcambio.Value = b.ToString();
            hfprecio.Value = c.ToString ();

        

            hfpreciomn.Value = a =="MN" ? c.ToString(): (c*b).ToString () ;
            hfprecious.Value = a == "US" ? c.ToString() : b==0? "0" :  (c * b).ToString();

            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            if (hfmoneda.Value == "MN")
            {
                // Add parts to the list.
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            }
            else
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });

            }

            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";

            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();

            if (hfprecio.Value != string.Empty && hfprecio.Value !="0" )
            {
                txtprecio.Text = hfprecio.Value;
                txtprecio.Enabled = false;
                ddlmoneda.Enabled = false;
            }
            else
            {
              
                txtprecio.Enabled = true ;
                ddlmoneda.Enabled = true;

            }

        }
        else
        {
            hfproducto.Value = null;
            txtproducto.Text = string.Empty;
        }
    }

    protected void txttrabajoencurso_TextChanged(object sender, EventArgs e)
    {
        var yy = Convert.ToInt32(txttrabajoencurso.Text);
        string xx = "TR" + yy.ToString("D8");

        ddltrabajoencurso.DataTextField = "DESCRIPCION";
        ddltrabajoencurso.DataValueField = "TR_CODIGO";

        List<tabla_trabajo> tc, tc1 = new List<tabla_trabajo>();
        tabla_trabajo tc2;

        tc = tabla_trabajo.ListarTrabajosAprobados();
        foreach (var x in tc)
        {
            tc2 = new tabla_trabajo();
            tc2.TR_CODIGO = x.TR_CODIGO;
            tc2.DESCRIPCION = x.TR_CODIGO + " " + x.DESCRIPCION;
            tc2.PRESUPUESTO = x.PRESUPUESTO;
            tc1.Add(tc2);
        }

        var zz=   tc1.Where(x => x.TR_CODIGO.Trim() == xx.Trim()).Union(tc1.Where(x => x.TR_CODIGO.Trim() != xx.Trim()));
        var cc = tc1.Where(x => x.TR_CODIGO.Trim() == xx.Trim()).FirstOrDefault();
        txtpresupuesto.Text= cc.PRESUPUESTO.ToString();
        ddltrabajoencurso.DataSource = zz;
        ddltrabajoencurso.DataBind();


        tc = tabla_trabajo.ListarTrabajosAprobados();
        foreach (var x in tc)
        {
            tc2 = new tabla_trabajo();
            tc2.TR_CODIGO = x.TR_CODIGO;
            tc2.DESCRIPCION = x.TR_CODIGO + " " + x.DESCRIPCION;
            tc2.PRESUPUESTO = x.PRESUPUESTO;
            tc1.Add(tc2);
        }

      
        txttolerancia.Text = tabla_porcentaje.actual();
        var dd = (Convert.ToDecimal(txttolerancia.Text) / 100) + 1;
        txttotal.Text = (Convert.ToDecimal(txtpresupuesto.Text) * dd).ToString();

        tabla_trabajo CODATA = new tabla_trabajo()
        { TR_CODIGO = ddltrabajoencurso.SelectedValue.Trim() };
        var tc3 = tabla_detalle.DETALLE(CODATA);
        var acumulado = (Decimal?)(0);

        foreach (var t in tc3)
        {
            acumulado = acumulado + t.MONTO;
        }
        txtacumulado.Text = acumulado.ToString();

        txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtacumulado.Text)).ToString();


    }

    protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
    {
        var xx = ddlArea.SelectedValue.Trim();
        if (xx == "03")
            pntrabajocurso.Visible = true;
        else
            pntrabajocurso.Visible = false;
    }

    protected void txtsolicitante_TextChanged(object sender, EventArgs e)
    {
        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "12",
            TG_CCLAVE = txtsolicitante.Text
        };


        if (AL0003TABL.Registroxcodigo(txtsolicitante.Text, "12") != null)
        {
            txtsolicitantesensitivo.Text = AL0003TABL.Registroxcodigo(txtsolicitante.Text, "12").TG_CDESCRI;
        }
         else
        {
            //ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Solicitante no existe"), false);

            txtsolicitante.Text = string.Empty;
            txtsolicitantesensitivo.Text = string.Empty;
        }

    }

    protected void ddltrabajoencurso_SelectedIndexChanged(object sender, EventArgs e)
    {
        List<tabla_trabajo> tc, tc1  = new List<tabla_trabajo>();
        tabla_trabajo tc2;

        tc = tabla_trabajo.ListarTrabajosAprobados();
        foreach (var x in tc)
        {
            tc2 = new tabla_trabajo();
            tc2.TR_CODIGO = x.TR_CODIGO;
            tc2.DESCRIPCION = x.TR_CODIGO + " " + x.DESCRIPCION;
            tc2.PRESUPUESTO = x.PRESUPUESTO;
            tc2.COD_MON = x.COD_MON;
            tc1.Add(tc2);
        }

        var zz = tc1.Where(x => x.TR_CODIGO.Trim() == ddltrabajoencurso.SelectedValue.Trim()).Union(tc1.Where(x => x.TR_CODIGO.Trim() != ddltrabajoencurso.SelectedValue.Trim()));
        var cc = tc1.Where(x => x.TR_CODIGO.Trim() == ddltrabajoencurso.SelectedValue.Trim()).FirstOrDefault();
        txtpresupuesto.Text = cc.PRESUPUESTO.ToString();
        txttolerancia.Text = tabla_porcentaje.actual();
        txtmonedatc.Text = cc.COD_MON;
        var dd= (Convert.ToDecimal(txttolerancia.Text) / 100) +1;
        txttotal.Text = (Convert.ToDecimal(txtpresupuesto.Text) * dd).ToString();

        tabla_trabajo CODATA = new tabla_trabajo()
        { TR_CODIGO = ddltrabajoencurso.SelectedValue.Trim() };
        var   tc3 = tabla_detalle.DETALLE(CODATA);
        var acumulado = (Decimal?)(0);

        foreach (var t in tc3)
        {
            acumulado = acumulado + t.MONTO;
        }
        txtacumulado.Text = acumulado.ToString();

        txtsaldo.Text = (Convert.ToDecimal(txttotal.Text) - Convert.ToDecimal(txtacumulado.Text)).ToString();
    }

    protected void txtsolicitante0_TextChanged(object sender, EventArgs e)
    {

        if (hfprecio.Value != string.Empty && hfprecio.Value != "0")
        {
            txtprecio.Text = hfprecio.Value;
            txtprecio.Enabled = false;
            ddlmoneda.Enabled = false;
      
            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            if (hfmoneda.Value == "MN")
            {
                // Add parts to the list.
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
            }else
            {
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });
                listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
             
            }

            ddlmoneda.DataTextField = "TG_CCLAVE";
            ddlmoneda.DataValueField = "TG_CCOD";

            ddlmoneda.DataSource = listamoneda;
            ddlmoneda.DataBind();
        }

        AL0003TABL TABL = new AL0003TABL()
        {
            TG_CCOD = "12",
            TG_CCLAVE = txtsolicitante0.Text
        };


        if (AL0003TABL.Registroxcodigo(txtsolicitante0.Text, "12") != null)
        {
            txtsolicitantesensitivo0.Text = AL0003TABL.Registroxcodigo(txtsolicitante0.Text, "12").TG_CDESCRI;
        }
        // buscaTabla("10", txtccosto.Text, ddlccosto);

        else
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Solicitante no existe"), false);

    }

    protected void txtFecha_TextChanged(object sender, EventArgs e)
    {
        CTCAMB CT = new CTCAMB()
        {
            XFECCAM2 = Convert.ToDateTime(txtFecha.Text)
        };

        CT = CTCAMB.obetenertcambio(CT);//.XMEIMP2.ToString();

        if (CT != null)
            txtlbltcambio.Text = CTCAMB.obetenertcambio(CT).XMEIMP2.ToString();
        else
        {
            txtlbltcambio.Text = string.Empty;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Actualice el tipo de cambio"), false);
        }
    }

    protected void btnimprimir_Click(object sender, EventArgs e)
    {
        string idnumor = txtnroreq.Text;
        Response.Redirect("../REQUERIMIENTOS/reportes/CR_IMPREQUER.aspx?ID=" + idnumor);
    }
}

