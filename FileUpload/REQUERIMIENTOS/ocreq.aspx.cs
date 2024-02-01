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

public partial class ocreq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            hfip.Value = Request.ServerVariables["REMOTE_ADDR"].ToString();
            List<tabla_busquedaRequerimiento> tb = new List<tabla_busquedaRequerimiento>();
            tb= tabla_busquedaRequerimiento.obtenerBusquedaReq(hfip.Value);
            foreach (var xx in tb)
            {
                tabla_busquedaRequerimiento.EliminarBusquedaRequerimiento(xx.id);
            }

            //tabla_busquedaRequerimiento.EliminarBusquedaRequerimiento(hfip.Value);


            txtlbltcambio.Attributes.Add("onkeydown", "soloNumeros();");

            txtFecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtffinal.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            ListaDetalle();

            AL0003TABL TABL = new AL0003TABL()
            {
                TG_CCOD = "12"
            };
            ddlsolicitante.DataTextField = "TG_CDESCRI";
            ddlsolicitante.DataValueField = "TG_CCLAVE";
            ddlsolicitante.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlsolicitante.DataBind();
            ddlsolicitante.Items.Insert(0, new ListItem("[SOLICITANTE]", "-1"));

            ddlalma.Items.Clear();
            ddlalma.DataTextField = "A1_CDESCRI";
            ddlalma.DataValueField = "A1_CALMA";
            ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma.DataBind();
            ddlalma.Items.Insert(0, new ListItem("ALMACEN DE INSUMOS", "0001"));


            txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
            CTCAMB CT = new CTCAMB()
            {
                XFECCAM2 = Convert.ToDateTime(txtFechaRegistro.Text)
            };

            CT = CTCAMB.obetenertcambio(CT);//.XMEIMP2.ToString();
            if (CT !=null)
            txtlbltcambio.Text = CTCAMB.obetenertcambio(CT).XMEIMP2.ToString();
            else
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Actualice el tipo de cambio"), false);


            ListaDetalle();

        }
    }

    protected void btnGrabar_Click(object sender, EventArgs e)
    {

        if (txtnroreq.Text != string.Empty)
        {
            for (int s =0; s<= gvDetalle.Rows.Count -1;s++ )
            {
                if (gvDetalle.Rows[s].Cells[1].Text == txtnroreq.Text)
                {
                    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Requerimiento repetido"), false);
                    return;
                }
            }


            AL0003REQC rec1 = new AL0003REQC()
            {
                RC_CNROREQ = txtnroreq.Text
            };



            tabla_busquedaRequerimiento busq = new tabla_busquedaRequerimiento();
            List<vista_requerimientoParaOC> vista = new List<vista_requerimientoParaOC>();
            vista = AL0003REQC.ListarRequerimientosParaOCPorNumero(rec1);
            foreach (var vist in vista)
            {
                busq.RC_CCODSOLI = vist.RC_CCODSOLI;
                busq.RD_CCENCOS = vist.RD_CCENCOS;
                busq.RC_CNROREQ = vist.RC_CNROREQ;
                busq.IP = hfip.Value;
                busq.RD_CCODIGO = vist.RD_CCODIGO;
                busq.RD_CDESCRI = vist.RD_CDESCRI;
                busq.RC_DFECREQ = vist.RC_DFECREQ;
                busq.RD_NQPEDI = vist.RD_NQPEDI;
                busq.CCOSTO = vist.CCOSTO;
                busq.TG_CDESCRI = vist.TG_CDESCRI;
                tabla_busquedaRequerimiento.insertaBusqueda(busq);

            }
            gvDetalle.DataSource = tabla_busquedaRequerimiento.obtenerBusquedaReq(hfip.Value);
            gvDetalle.DataBind();
        }
        else
        {

            AL0003REQC rec = new AL0003REQC()
            {
                RC_DFECA01 = Convert.ToDateTime(txtFecha.Text),
                RC_DFECA02 = Convert.ToDateTime(txtffinal.Text),
                RC_CCODSOLI = ddlsolicitante.SelectedValue.Trim()
            };
            gvDetalle.DataSource = AL0003REQC.ListarRequerimientosParaOC(rec);
            gvDetalle.DataBind();
        }
    }
    public void ListaDetalle()
    {
        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("OC_CCODPRO");
        dtGetDatae1.Columns.Add("OC_CRAZSOC");
        dtGetDatae1.Columns.Add("OC_DFECDOC");
        dtGetDatae1.Columns.Add("OC_CCODMON");
        dtGetDatae1.Columns.Add("OC_NPREUN2");
        dtGetDatae1.Columns.Add("OC_CNUMORD");
        dtGetDatae1.Rows.Add();
        gvdetallereq.DataSource = dtGetDatae1;
        gvdetallereq.DataBind();
    }

    protected void btnOC_Click(object sender, EventArgs e)
    {
        for (int r = 0; r <= GridView1.Columns.Count - 1; r++)
        {
            GridView1.Columns[r].Visible = true;
        }

        AL0003TABL tabla = new AL0003TABL()
        {
            TG_CCOD = "63"
        };

        var tab = AL0003TABL.ListarTablaMod(tabla).OrderBy(iv=> iv.TG_CDESCRI.Length );
        int contador = 0;
        for (int i = 0; i <= gvDetalle.Rows.Count - 1; i++)
        {
            if ((gvDetalle.Rows[i].FindControl("CheckBox1") as CheckBox).Checked)
            {
                               contador++;
            }
        }

        string[] arr = new string [contador];
        string[] arr1 = new string[contador];
        int cont_arr = 0;
       

        for (int i =0; i<=gvDetalle.Rows.Count-1 ;i++ )
        {
            if ((gvDetalle.Rows[i].FindControl("CheckBox1") as CheckBox).Checked)
            {
                arr[cont_arr] = gvDetalle.Rows[i].Cells[1].Text;
                arr1[cont_arr] = gvDetalle.DataKeys[i].Values["RD_CCODIGO"].ToString().Trim();
                cont_arr++;
            }
        }

        int cont_item = 1;

        List<vista_requerimientoParaOC> lista0 = new List<vista_requerimientoParaOC>();
        vista_requerimientoParaOC lista1;
        for (int i = 0; i <= gvDetalle.Rows.Count - 1; i++)
        {
            if ((gvDetalle.Rows[i].FindControl("CheckBox1") as CheckBox).Checked)
            {
                lista1 = new vista_requerimientoParaOC();
                lista1.RC_CNROREQ = gvDetalle.Rows[i].Cells[1].Text;
                lista1.TG_CDESCRI = HttpUtility.HtmlDecode(gvDetalle.Rows[i].Cells[3].Text);
                lista1.RD_CCODIGO=  gvDetalle.DataKeys[i].Values["RD_CCODIGO"].ToString().Trim(); //RD_CCODIGO
                lista1.RD_CDESCRI = HttpUtility.HtmlDecode(gvDetalle.Rows[i].Cells[4].Text);
                lista1.RD_NQPEDI = Convert.ToDecimal ( gvDetalle.Rows[i].Cells[5].Text);
                lista1.CCOSTO = gvDetalle.Rows[i].Cells[6].Text;
                lista1.RD_CCENCOS = gvDetalle.DataKeys[i].Values["RD_CCENCOS"].ToString().Trim();
                lista1.RC_CCODSOLI = gvDetalle.DataKeys[i].Values["RC_CCODSOLI"].ToString().Trim();
                lista0.Add(lista1);
                cont_item++;
            }
        }

        var yyy = lista0;

        List <vista_requerimientoParaOCProductos1> lista = new List<vista_requerimientoParaOCProductos1>();
        lista= AL0003REQC.listarqcontraoc(arr,arr1);

        GridView1.DataSource = lista0;
        GridView1.DataBind();

        
        var prov = (from a in lista 
                    orderby
                     a.OC_CRAZSOC
                    select new
                    {
                        a.OC_CRAZSOC,a.OC_CCODPRO
                       
                    }).Distinct();

     
        int x = 5;
            foreach (var a in prov)
            {
                GridView1.HeaderRow.Cells[x].Text = a.OC_CRAZSOC;

            for (int y = 0; y <= GridView1.Rows.Count - 1; y++)
            {
                (GridView1.Rows[y].FindControl("hfruc" + x.ToString()) as HiddenField).Value = a.OC_CCODPRO;
                (GridView1.Rows[y].FindControl("txtprecio" + x.ToString()) as TextBox).Attributes.Add("onkeydown", "soloNumeros();");
                (GridView1.Rows[y].FindControl("txtcantidad" ) as TextBox).Attributes.Add("onkeydown", "soloNumeros();");

            }

            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataTextField = "TG_CDESCRI";
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataValueField = "TG_CCLAVE";
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataSource = tab;
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataBind();

            x++;
            }
        int w = 5 + prov.Count();
        for (int r = w; r<= GridView1.Columns.Count - 1; r++)
        {
            GridView1.Columns[r].Visible = false;
        }
        x = 5;
        hfcolumnas.Value = w.ToString();

        List<AL0003TABL> listamoneda = new List<AL0003TABL>();

        // Add parts to the list.
        listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
        listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });


        foreach (var b in prov)
        {
            for (int y = 0; y <= GridView1.Rows.Count - 1; y++)
            {
                var abc = (GridView1.Rows[y].FindControl("hfruc" + x.ToString()) as HiddenField).Value.Trim();
                var def = GridView1.DataKeys[y].Values["RD_CCODIGO"].ToString().Trim();

                var listaPrecio = (from c in lista
                                   where
                                     c.OC_CCODPRO.Trim() == abc
                                     && c.OC_CCODIGO.Trim() == def
                                   select new
                                   {
                                       c.OC_NPREUN2,c.OC_CCODMON
                                   }).FirstOrDefault();
                var ghi = listaPrecio==null ? string.Empty : Math.Round(listaPrecio.OC_NPREUN2,2).ToString() ;
                var jkl = listaPrecio == null ? string.Empty : listaPrecio.OC_CCODMON.ToString().Trim();

               
                var devuelvemoneda = jkl == "US" ? listamoneda.OrderByDescending(mon => mon.TG_CCLAVE).ToList() : listamoneda;

                (GridView1.Rows[y].FindControl("txtprecio" + x.ToString()) as TextBox).Text = ghi;

                (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataTextField = "TG_CDESCRI";
                (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataValueField = "TG_CCLAVE";

                (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataTextField = "TG_CCLAVE";
                (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataValueField = "TG_CCOD";
        
                (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataSource = devuelvemoneda;
                (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataBind();
            }
            x++;
        }
        
    }
    protected void btnFinalizar_Click(object sender, EventArgs e)
    {
        if (GridView1.Columns[5].Visible !=true)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Seleccione un proveedor"), false);
            return;
        }


        if (ddlalma.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Elija un almacén"), false);
            return;
        }

        if (txtlbltcambio.Text == string.Empty )
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("El tipo de cambio debe ser mayor que cero"), false);
            return;
        }
        

        string provd = string.Empty;
        

        List<vista_OcCabDet> lista = new List<vista_OcCabDet>();
        int cuenta = 0;
        for (int r = 5; r <= GridView1.Columns.Count - 1; r++)
        {
            if (GridView1.Columns[r].Visible)
                cuenta++;
        }
        int inicio = 5;
        for (int y = 0; y <= GridView1.Rows.Count - 1; y++)
        {
            vista_OcCabDet fila;
            string precio = string.Empty;


            for (int s = inicio; s <= cuenta + inicio - 1; s++)
            {
                provd = CT0003ANEX.obtenProveedor((GridView1.Rows[y].FindControl("hfruc" + s.ToString()) as HiddenField).Value.Trim()).AREFANE.Trim();
                fila = new vista_OcCabDet();
                fila.OC_CCODPRO = (GridView1.Rows[y].FindControl("hfruc" + s.ToString()) as HiddenField).Value;
                fila.OC_CDIRPRO = provd;
                precio = (((GridView1.Rows[y].FindControl("txtprecio" + s.ToString()) as TextBox).Text == string.Empty) ? "0" : ((GridView1.Rows[y].FindControl("txtprecio" + s.ToString()) as TextBox).Text));
                fila.OC_NPREUN2 =  Convert.ToDecimal(precio);
                fila.OC_CCODMON = (GridView1.Rows[y].FindControl("ddlmoneda" + s.ToString()) as DropDownList ).SelectedItem.Text;
                fila.OC_CRAZSOC = HttpUtility.HtmlDecode(GridView1.HeaderRow.Cells[s].Text);
                fila.OC_CTIPORD = (GridView1.FooterRow.FindControl("ddltipooc" + s.ToString()) as DropDownList).SelectedValue.Trim();
                fila.OC_CIGVPOR = (GridView1.FooterRow.FindControl("cbigv" + s.ToString()) as CheckBox).Checked == true ? "S" : "N";
                fila.OC_CNUMREQ = GridView1.Rows[y].Cells[0].Text;
                fila.OC_CCODIGO = GridView1.DataKeys[y].Values["RD_CCODIGO"].ToString().Trim();
                fila.OC_CCENCOS = GridView1.DataKeys[y].Values["RD_CCENCOS"].ToString().Trim();
                fila.OC_CSOLICI = GridView1.DataKeys[y].Values["RC_CCODSOLI"].ToString().Trim();
                fila.OC_CDESREF = HttpUtility.HtmlDecode(GridView1.Rows[y].Cells[3].Text);
                fila.OC_NCANSAL = Convert.ToDecimal((GridView1.Rows[y].FindControl("txtcantidad") as TextBox).Text);
                fila.OC_NTIPCAM = Convert.ToDecimal(txtlbltcambio.Text);
                fila.OC_DFECDOC = Convert.ToDateTime(txtFechaRegistro.Text);
                fila.OC_CALMDES = ddlalma.SelectedValue.Trim();
                fila.sel = ((GridView1.Rows[y].FindControl("cbsel" + s.ToString()) as CheckBox).Checked);
                lista.Add(fila);
            }

        }
        var prov = (from a in lista where a.OC_NPREUN2>0  && a.sel==true
                    orderby
                     a.OC_CRAZSOC
                    select new
                    {
                        a.OC_CRAZSOC,
                        a.OC_CCODPRO,
                        a.OC_CCODMON,
                        a.OC_NTIPCAM,
                        a.OC_CTIPORD,
                        a.OC_CALMDES
                    }).Distinct();
        string todasoc = " ";
        CO0003MOVC CABC = new CO0003MOVC();
        int cont = 1;
        foreach (var muestra in prov)
        {
            CABC.OC_CNUMORD = CO0003MOVC.CuentaDetalleMov().Trim();
            CABC.OC_CCODPRO = muestra.OC_CCODPRO.Trim();
            CABC.OC_CRAZSOC = muestra.OC_CRAZSOC.Trim();
            CABC.OC_CDIRPRO = CT0003ANEX.obtenProveedor(muestra.OC_CCODPRO).AREFANE.Trim();
            CABC.OC_CCODMON =  muestra.OC_CCODMON.Trim();
            CABC.OC_NTIPCAM = muestra.OC_NTIPCAM;
            CABC.OC_CCOTIZA = string.Empty;
            CABC.OC_CFORPA1 = string.Empty;
            CABC.OC_CFORPA2 = string.Empty;
            CABC.OC_CFORPA3 = string.Empty;
            CABC.OC_DFECENT = DateTime.Now;
            CABC.OC_NPORDES = 0;
            CABC.OC_CCARDES = string.Empty;
            CABC.OC_NIMPUS = 0;
            CABC.OC_NIMPMN = 0;
            CABC.OC_CSOLICT = string.Empty;//; muestra.OC_CSOLICI;
            CABC.OC_CTIPENV = string.Empty;
            CABC.OC_CLUGENT = string.Empty;// $("#MainContent_txtlentre").val().trim();
            CABC.OC_CLUGFAC = string.Empty;//$("#MainContent_txtlugarf").val().trim();
            CABC.OC_CDETENT = string.Empty;
            CABC.OC_CSITORD = "1";
            CABC.OC_DFECACT = DateTime.Now;
            CABC.OC_CHORA = DateTime.Now.Hour.ToString();
            CABC.OC_CUSUARI = Session["codusu"].ToString();
            CABC.OC_DFECDOC = Convert.ToDateTime(txtFechaRegistro.Text);
            CABC.OC_CTIPORD = muestra.OC_CTIPORD;
            CABC.OC_CRESPER1 = string.Empty;
            CABC.OC_CRESPER2 = string.Empty;
            CABC.OC_CRESPER3 = string.Empty;
            CABC.OC_CRESCARG1 = string.Empty;
            CABC.OC_CRESCARG2 = string.Empty;
            CABC.OC_CRESCARG3 = string.Empty;
            CABC.OC_CCOPAIS = string.Empty;
            CABC.OC_CUSEA01 = string.Empty;
            CABC.OC_CUSEA02 = string.Empty;
            CABC.OC_CUSEA03 = string.Empty;
            CABC.OC_CREMITE = string.Empty;
            CABC.OC_CPERATE = string.Empty;
            CABC.OC_CCONTA1 = string.Empty;
            CABC.OC_CCONTA2 = string.Empty;
            CABC.OC_CCONTA3 = string.Empty;
            CABC.OC_CNUMFAC = string.Empty;
            CABC.OC_CUNIORD = string.Empty;
            CABC.OC_CCONVTA = string.Empty;
            CABC.OC_CCONEMB = string.Empty;
            CABC.OC_CCONDIC = string.Empty;
            CABC.OC_CTIPENT = string.Empty;
            CABC.OC_CDIAENT = string.Empty;
            CABC.OC_NFLEINT = 0;
            CABC.OC_NDOCCHA = 0;
            CABC.OC_NFLETE = 0;
            CABC.OC_NSEGURO = 0;
            CABC.OC_NIMPFAC = 0;
            CABC.OC_NIMPFOB = 0;
            CABC.OC_NIMPCF = 0;
            CABC.OC_NIMPCIF = 0;
            CABC.OC_CNUMREF = string.Empty;
            CABC.OC_CTIPDSP = string.Empty;
            CABC.OC_CTIPDOC = "RQ";
            CABC.OC_CALMDES = muestra.OC_CALMDES;
            CABC.OC_CDISTOC = string.Empty;//$("#MainContent_txtdist").val().trim();
            CABC.OC_CPROVOC = string.Empty;//$("#MainContent_txtprov").val().trim();
          
            CABC.OC_CDOCPAG = string.Empty;
            CABC.OC_CESTPAG = string.Empty;
            CABC.OC_CMONPAG = string.Empty;
            CABC.OC_NIMPPAG = 0;
            CABC.OC_CGLOPAG = string.Empty;
       
            CABC.OC_CCODAGE = string.Empty;
            CABC.OC_CCODTAL = string.Empty;
            CABC.OC_CORDTRA = string.Empty;
           

            decimal OC_NPREUN2 = 0;
            decimal OC_NTOTMN = 0;

            decimal TOTAL_OC_NTOTMN = 0;
            decimal TOTAL_OC_NTOTUS = 0;

            var detalle = (lista.Where(x => x.OC_CCODPRO.Trim().Equals(CABC.OC_CCODPRO.Trim()) && x.OC_NPREUN2 > 0 && x.sel ==true ) ).ToList();
            CO0003MOVD DETA = new CO0003MOVD();
            foreach (var det in detalle)
            {
                CABC.OC_CCOSTOC = det.OC_CCENCOS;// string.Empty;//  muestra.OC_CCENCOS;
                CABC.OC_CCODSOL = det.OC_CSOLICI; //  muestra.OC_CSOLICI;
                CABC.OC_CCOTIZA= det.OC_CNUMREQ.Trim();

                OC_NPREUN2 = det.OC_CIGVPOR == "S" ? det.OC_NPREUN2 / Convert.ToDecimal(1.18) : det.OC_NPREUN2;
                OC_NTOTMN = OC_NPREUN2 * det.OC_NCANSAL * Convert.ToDecimal(1.18);//det.OC_CIGVPOR == "S" ? det.OC_NPREUN2 * det.OC_NCANSAL* Convert.ToDecimal(1.18) : det.OC_NPREUN2 * det.OC_NCANSAL;
                DETA.OC_CNUMORD = CABC.OC_CNUMORD.Trim();
                DETA.OC_CCODPRO = CABC.OC_CCODPRO.Trim();
                DETA.OC_CITEM = cont.ToString("D4");
                DETA.OC_CCODIGO = det.OC_CCODIGO.Trim();
                DETA.OC_CCODREF = string.Empty;
                DETA.OC_CDESREF = det.OC_CDESREF.Trim();
                DETA.OC_CUNIPRO = string.Empty;
                DETA.OC_CDEUNPR = string.Empty;
                DETA.OC_CUNIDAD = AL0003ARTI.obtenerArticuloPorID(det.OC_CCODIGO.Trim()).AR_CUNIDAD;
                DETA.OC_NCANORD = det.OC_NCANSAL;
                DETA.OC_NPREUNI = det.OC_NPREUN2;
                DETA.OC_NPREUN2 = OC_NPREUN2;
                DETA.OC_NDSCPFI = 0;
                DETA.OC_NDESCFI = 0;
                DETA.OC_NDSCPIT = 0;
                DETA.OC_NDESCIT = 0;
                DETA.OC_NDSCPAD = 0;//
                DETA.OC_NDESCAD = 0;
                DETA.OC_NDSCPOR = 0;
                DETA.OC_NDESCTO = 0;
                DETA.OC_NIGV = det.OC_NCANSAL * OC_NPREUN2 * Convert.ToDecimal(0.18);//det.OC_CIGVPOR == "S" ? det.OC_NCANSAL * OC_NPREUN2 * Convert.ToDecimal(0.18) : 0;
                DETA.OC_NIGVPOR = 18;// det.OC_CIGVPOR =="S" ? 18:0; 
                DETA.OC_NISC = 0;
                DETA.OC_NISCPOR = 0;
                DETA.OC_NCANTEN = 0;
                DETA.OC_NCANSAL = det.OC_NCANSAL;
                DETA.OC_NTOTUS = OC_NTOTMN/det.OC_NTIPCAM;
                DETA.OC_NTOTMN = OC_NTOTMN;
                DETA.OC_COMENTA = string.Empty;
                DETA.OC_CESTADO = "1";
                DETA.OC_FUNICOM = string.Empty;
                DETA.OC_NCANREF = 0;
                DETA.OC_CSERIE = string.Empty;
                DETA.OC_NANCHO = 0;
                DETA.OC_NCORTE = 0;
                DETA.OC_DFECDOC = det.OC_DFECDOC;
                DETA.OC_CTIPORD = det.OC_CTIPORD.Trim();
                DETA.OC_CCENCOS = det.OC_CCENCOS;
                DETA.OC_CNUMREQ = det.OC_CNUMREQ.Trim();
                DETA.OC_CSOLICI = det.OC_CSOLICI;
                DETA.OC_CITEREQ = string.Empty;
                DETA.OC_CREFCOD = string.Empty;
                DETA.OC_CPEDINT = string.Empty;
                DETA.OC_CITEINT = string.Empty;
                DETA.OC_CREFCOM = string.Empty;
                DETA.OC_CNOMFAB = string.Empty;
                DETA.OC_NCANEMB = 0;
                DETA.OC_DFECENT = DateTime.Now;
                DETA.OC_CITMPOR = string.Empty;
                DETA.OC_CDSCPOR = string.Empty;
                DETA.OC_CIGVPOR = string.Empty;
                DETA.OC_CISCPOR = string.Empty;
                DETA.OC_NTOTMO = 0;
                DETA.OC_NUNXENV = 0;
                DETA.OC_NNUMENV = 0;
                DETA.OC_NCANFAC = 0;
                CO0003MOVD.insertdetalleOC(DETA);

                var listaReq = AL0003REQD.obtenerRequerimientoPorNumeroYCodigo(det.OC_CNUMREQ.Trim(), det.OC_CCODIGO.Trim());
                AL0003REQD variable = new AL0003REQD();
                foreach (var listareq1 in listaReq)
                {
                    variable.RD_CITEM = listareq1.RD_CITEM;
                    variable.RD_CNROREQ = listareq1.RD_CNROREQ;
                    variable.RD_CSITUA = "3";
                    variable.RD_NQATEN = listareq1.RD_NQPEDI;
                    AL0003REQD.apruebaRequerimientoAtendido(variable);
                    AL0003REQC.apruebaRequerimientoAtendido(listareq1.RD_CNROREQ, "3");
                }

                cont++;
                TOTAL_OC_NTOTMN = TOTAL_OC_NTOTMN+DETA.OC_NTOTMN;
                TOTAL_OC_NTOTUS = TOTAL_OC_NTOTUS+ DETA.OC_NTOTUS;
            }
            CABC.OC_NIMPUS = TOTAL_OC_NTOTUS;
            CABC.OC_NIMPMN = TOTAL_OC_NTOTMN;
            CO0003MOVC.InsertarCabecera(CABC);
            FT0003NUME ft = new FT0003NUME()
            {
                TN_CCODIGO="OC",
                TN_CNUMSER = "0001",
                TN_NNUMERO =Convert.ToInt32 (  CABC.OC_CNUMORD.Substring (4,7) )
            };

            FT0003NUME.actualizaNumeraciónOC(ft);
            todasoc = todasoc + CABC.OC_CNUMORD.Trim() + ",";
        }
        todasoc = todasoc.Substring(0, todasoc.Length - 1);
        ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("OC generadas: " + todasoc), false);
        GridView1.DataSource = null;
        GridView1.DataBind(); 
        btnGrabar_Click(e, null);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_historialPrecios> ListarHistorialPrecios(AL0003REQD REQ)
    {
        return CO0003MOVC.ListarHistorialPreciosPorProducto(REQ);
    }




    protected void btnaddprov_Click(object sender, EventArgs e)
    {
        AL0003TABL tabla = new AL0003TABL()
        {
            TG_CCOD = "63"
        };

        var tab = AL0003TABL.ListarTablaMod(tabla).OrderBy(iv => iv.TG_CDESCRI.Length);

        CT0003ANEX ANEX = new CT0003ANEX();
        ANEX= CT0003ANEX.obtenProveedor(hfproveedor.Value.Trim());
        if (hfproveedor.Value.Trim() == string.Empty)
            ANEX = null;


        if (ANEX ==null)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Proveedor no existe"), false);
            txtProveedor.Text = string.Empty;
            hfproveedor.Value = null;
            return;
        }

        for (int q = 0; q <= GridView1.Columns.Count - 1; q++)
        {

            if (GridView1.HeaderRow.Cells[q].Text.Trim() == txtProveedor.Text.Trim())
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Proveedor repetido"), false);
                txtProveedor.Text = string.Empty;
                hfproveedor.Value = null;
                return;
            }

        }
        int x = Convert.ToInt32(hfcolumnas.Value);
        GridView1.Columns[x].Visible = true;
        GridView1.HeaderRow.Cells[x].Text = txtProveedor.Text;


        List<AL0003TABL> listamoneda = new List<AL0003TABL>();

        // Add parts to the list.
        listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "MN", TG_CCOD = "MN" });
        listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "US", TG_CCOD = "US" });

        for (int y = 0; y <= GridView1.Rows.Count - 1; y++)
        {
                 (GridView1.Rows[y].FindControl("txtprecio" + x.ToString()) as TextBox).Attributes.Add("onkeydown", "soloNumeros();");
            (GridView1.Rows[y].FindControl("hfruc" + x.ToString()) as HiddenField).Value = hfproveedor.Value;
            (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataTextField = "TG_CCLAVE";
            (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataValueField = "TG_CCOD";

            (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataSource = listamoneda;
            (GridView1.Rows[y].FindControl("ddlmoneda" + x.ToString()) as DropDownList).DataBind();

            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataTextField = "TG_CDESCRI";
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataValueField = "TG_CCLAVE";
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataSource = tab;
            (GridView1.FooterRow.FindControl("ddltipooc" + x.ToString()) as DropDownList).DataBind();
        }
      
        hfcolumnas.Value =(x + 1).ToString();
        txtProveedor.Text = string.Empty;
        hfproveedor.Value = null;
    }



    protected void txtFechaRegistro_TextChanged(object sender, EventArgs e)
    {
        //txtFechaRegistro.Text = DateTime.Now.ToString("dd/MM/yyyy");
        CTCAMB CT = new CTCAMB()
        {
            XFECCAM2 = Convert.ToDateTime(txtFechaRegistro.Text)
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
}


