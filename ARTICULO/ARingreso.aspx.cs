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
        if (!this.IsPostBack) {
            //este para oe
            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
            
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            ddlmone.Items.Clear();
            ddlmone.DataTextField = "TG_CDESCRI";
            ddlmone.DataValueField = "TG_CCLAVE";
            ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlmone.DataBind();
            ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));
            ddlmone.SelectedValue = "MN";
            
            ddltipot.Items.Insert(0, new ListItem("FIJA", "F"));
            ddltipot.Items.Insert(1, new ListItem("VARIABLE", "V"));

            csigv.Items.Insert(0, new ListItem("CON IGV", "18"));
            csigv.Items.Insert(1, new ListItem("SIN IGV", "0"));

            

            ddlsarea.Items.Clear();
            ddlsarea.DataTextField = "SA_DESC";
            ddlsarea.DataValueField = "SA_ID";
            ddlsarea.DataSource = tabla_d_areausua.Listarsubareasxusua(hfusu.Value,1);
            ddlsarea.DataBind();
            ddlsarea.Items.Insert(0, new ListItem("[AREA]", ""));


            string idproducto = Convert.ToString(Request.QueryString["idp"]);
            if (idproducto == "" || idproducto ==null )
            {
            } else {
                ddltipot.Enabled = true;
                txtcuenta.Enabled = true;
                txtidcuenta.Enabled = true;
                txtprod2.Enabled = true;
                txttar.Enabled = true;
                ddlmone.Enabled = true;
                ddlsarea.Enabled = true;
                txtidprove.Enabled = true;
                txtprove.Enabled = true;
                txtCTASA.Enabled = true;

                txtprod2.Focus();
                btgrabar.Enabled = true;
                btnuevo.Enabled = false;
                AL0003ARTI verarticu = new AL0003ARTI();
                verarticu = AL0003ARTI.obtenerArticuloPorID(idproducto);
                CT0003TAGE TABG = new CT0003TAGE();
                TABG.TCOD = "28";
                TABG.TCLAVE = verarticu.AR_CFORSER;//TASA
                txtnuevocod.Text = idproducto;
                txtcuenta.Text = CT0003PLEM.RegistrounCta(verarticu.AR_CCUENTA.Trim());//FT0003CTAE.RegistrounCta(verarticu.AR_CCUENTA.Trim()) ;
                //CT0003TAGE AUX = new CT0003TAGE();
                string AUX;
                AUX = CT0003TAGE.ListarTG(TABG).First().TDESCRI.ToString();
                string[] strArr = null;
                if (AUX != null) {
                    string cad = "";
                    cad = AUX.Replace("  ", "-");
                    char[] splitchar = { '-' };
                    strArr = cad.Split(splitchar);
                    strArr=strArr.Where(x => !string.IsNullOrEmpty(x)).ToArray();
                }
                else
                {
                    strArr = null;
                }
                
                txtidcuenta.Text = verarticu.AR_CCUENTA.Trim();
                txtprod2.Text = verarticu.AR_CDESCRI;
                txttar.Text = verarticu.AR_NPRECOM.ToString("{00.0000}");
                txtCTASA.Text = verarticu.AR_CFORSER;
                txtDTASA.Text= (strArr != null ? strArr[0] : "");
                lblMTASA.Text=(strArr != null ? strArr[1] : "");
                lblPTASA.Text= (strArr != null ? strArr[2] : "");
                ddlmone.SelectedValue = verarticu.AR_CMONCOM.Trim();
                ddlsarea.SelectedValue = verarticu.AR_CPARARA;
                txtidprove.Text = verarticu.AR_CCODPRO;
                txtprove.Text = CT0003ANEX.obtenProveedor(verarticu.AR_CCODPRO.Trim()) ==null?"" : CT0003ANEX.obtenProveedor(verarticu.AR_CCODPRO.Trim()).ADESANE ;
            }


        }
    }



    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }

    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static string GetcodigoGenerar(string tipo)
    {
        return AL0003ARTI.ultimocodigoxtipo(tipo).ToString();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(CT0003ANEX ADATA)
    {
        return CT0003ANEX.listarAnexoT(ADATA);
    }


    [ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos, string tipop, string subtip, string idusuario, string idprovee,string tipolinea)
    {
        //if (tipop != "S")
        //{
        //    return AL0003ARTI.ListarArticulosforma2(productos, tipop, subtip,tipolinea);
        //}
        //else {
            return AL0003ARTI.ListarServicios(productos, tipop, subtip, idusuario, idprovee, tipolinea);
        //}
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<AL0003TABL> listatabl(string texto,string codigo)
    {
        return AL0003TABL.Listartablaxcodigo(texto, codigo);
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<CT0003PLEM> listactaexis(string texto)
    {
        return CT0003PLEM.ListarCtaE(texto);
    }


    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string extraedescuenta(string ncuenta)
    {
        return FT0003CTAE.RegistrounCta(ncuenta);
    }



    protected void txtidcuenta_TextChanged(object sender, EventArgs e)
    {
        if (CT0003PLEM.RegistrounCta(txtidcuenta.Text) == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Codigo');</script>");
            txtcuenta.Text = "";
            txtidcuenta.Text = "";
            txtidcuenta.Focus();
        }
        else {
            txtcuenta.Text = CT0003PLEM.RegistrounCta(txtidcuenta.Text);
            ddlsarea.Focus();
        }
    }

    //protected void txtidfami_TextChanged(object sender, EventArgs e)
    //{
    //    if (AL0003TABL.Registrouno(txtidfami.Text, "38") == "")
    //    {
    //        Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Codigo');</script>");
    //        txtfami.Text = "";
    //        txtidfami.Text = "";
    //        txtidfami.Focus();
    //    }
    //    else {
    //        txtfami.Text = AL0003TABL.Registrouno(txtidfami.Text, "38");
    //    }
    //}

    protected void btgrabar_Click(object sender, EventArgs e)
    {
        string idproducto = Convert.ToString(Request.QueryString["idp"]); 
        List<AL0003ARTI> Listanrep = new List<AL0003ARTI>();
        var copiacorreo = "programador1@seafrost.com.pe";
        //tabla_d_usuaprod parm = new tabla_d_usuaprod(); 
        //parm.DA_CODIGO = idproducto;
        //var naprob= tabla_d_usuaprod.NumAprobTotal(parm);


        Listanrep = AL0003ARTI.Listanrepeticiones(txtprod2.Text.Trim(),txtidprove.Text,Convert.ToDecimal(txttar.Text));

        int nrepetic = Listanrep.Count();

        if (txtprod2.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado el Servicio');</script>");
            txtprod2.Focus();
        }
        else if (txttar.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado la tarifa ');</script>");
            txttar.Focus();
        } else if (ddlsarea.SelectedValue == "") {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado el area');</script>");
            ddlsarea.Focus();
        } else if (txtidprove.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado el proveedor');</script>");
            txtidprove.Focus();
        }
        else {
            List<string> fiche = new List<string>();
            string informa = "<html><body> <table style='font-size:12px;background-color:White;border-color:#CCCCCC;width:800px;font-family: 'Helvetica Neue',Helvetica,Arial,sans-serif' border='1' cellpadding='1' cellspacing='1'><tr><td colspan='2' align='center' bgcolor='#7ACAFF'> <b>" + "SERVICIO" + "</b></td></tr><tr><td colspan='2' align='center' bgcolor='#FFCC99'>" + txtprod2.Text + "</td></tr><tr><td>" + " PROVEEDOR: "+ "</td><td>" + txtprove.Text + "</td></tr><tr><td>" + " TARIFA: " + "</td><td>" + Convert.ToDecimal( string.Format("{0:00.0000}", txttar.Text)) + "</td></tr><tr><td>"
                + " AREA: " + "</td><td>" + ddlsarea.SelectedItem.Text + "</td></tr><tr><td>" + " MONEDA: " + "</td><td>" + ddlmone.SelectedValue + "</td></tr><tr><td>" + " TIPO:" + "</td><td>" + ddltipot.SelectedItem.Text + "</td></tr><tr><td>" + " USUARIO: " + "</td><td>" + UT0030.Mostrarunusuario(hfusu.Value)+ "</td></tr></table></body></html>";

            if (idproducto == "" || idproducto == null){
            txtnuevocod.Text = AL0003ARTI.ultimocodigoxtipo("R").ToString();
            }

            tabla_servicios ACDA = new tabla_servicios();
            ACDA.AR_CCODIGO = txtnuevocod.Text;
            ACDA.AR_CDESCRI = txtprod2.Text;
            ACDA.AR_NPRECOM = Convert.ToDecimal(txttar.Text);
            ACDA.AR_CMONCOM = ddlmone.SelectedValue;
            ACDA.AR_CUSUCRE = hfusu.Value;
            ACDA.AR_DFECCRE = Convert.ToDateTime(hffactual.Value);
            ACDA.AR_CCUENTA = txtidcuenta.Text;
            ACDA.AR_CPARARA = ddlsarea.SelectedValue;
            ACDA.AR_CTIPDES = ddltipot.SelectedValue;
            ACDA.AR_CCONTRO = "S";//sin aprobar
            ACDA.AR_CCODPRO = txtidprove.Text;
            ACDA.AR_NIGVCPR = Convert.ToDecimal(csigv.SelectedValue);


            tabla_servicios.ActualizatmpAL(ACDA); 
            AL0003ARTI ts = new AL0003ARTI();
            tabla_servicios tmpa = new tabla_servicios();

            tmpa = tabla_servicios.ListarTarificaO(txtnuevocod.Text);

            ts.AR_CCODIGO = tmpa.AR_CCODIGO;
            ts.AR_CDESCRI = tmpa.AR_CDESCRI;
            ts.AR_CDESCR2 = tmpa.AR_CDESCR2;
            ts.AR_CCODIG2 = tmpa.AR_CCODIG2;
            ts.AR_CUNIDAD = tmpa.AR_CUNIDAD;
            ts.AR_CCUENTA = tmpa.AR_CCUENTA;
            ts.AR_NPRECI1 = Convert.ToDecimal(tmpa.AR_NPRECI1);
            ts.AR_NPRECI2 = Convert.ToDecimal(tmpa.AR_NPRECI2);
            ts.AR_NPRECI3 = Convert.ToDecimal(tmpa.AR_NPRECI3);
            ts.AR_NPRECI4 = Convert.ToDecimal(tmpa.AR_NPRECI4);
            ts.AR_NPRECI5 = Convert.ToDecimal(tmpa.AR_NPRECI5);
            ts.AR_NPRECI6 = Convert.ToDecimal(tmpa.AR_NPRECI6);
            ts.AR_CMONVTA = tmpa.AR_CMONVTA;
            ts.AR_NIGVPOR = Convert.ToDecimal(tmpa.AR_NIGVPOR);
            ts.AR_NISCPOR = Convert.ToDecimal(tmpa.AR_NISCPOR);
            ts.AR_CTIPO = tmpa.AR_CTIPO;
            ts.AR_CCONTRO = tmpa.AR_CCONTRO;
            ts.AR_CTIPDES = tmpa.AR_CTIPDES;
            ts.AR_NDESCTO = Convert.ToDecimal(tmpa.AR_NDESCTO);
            ts.AR_NDESCT2 = Convert.ToDecimal(tmpa.AR_NDESCT2);
            ts.AR_NPDIS = Convert.ToDecimal(tmpa.AR_NPDIS);
            ts.AR_NPCOM = Convert.ToDecimal(tmpa.AR_NPCOM);
            ts.AR_CGRUPO = tmpa.AR_CGRUPO;
            ts.AR_CFAMILI = tmpa.AR_CFAMILI;
            ts.AR_CMODELO = tmpa.AR_CMODELO;
            ts.AR_CLINEA = tmpa.AR_CLINEA;
            ts.AR_NPESO = Convert.ToDecimal(tmpa.AR_NPESO);
            ts.AR_NVOLUME = Convert.ToDecimal(tmpa.AR_NVOLUME);
            ts.AR_NAREA = Convert.ToDecimal(tmpa.AR_NAREA);
            ts.AR_NFACTOR = Convert.ToDecimal(tmpa.AR_NFACTOR);
            ts.AR_NANCHO = Convert.ToDecimal(tmpa.AR_NANCHO);
            ts.AR_NLARGO = Convert.ToDecimal(tmpa.AR_NLARGO);
            ts.AR_CMONCOS = tmpa.AR_CMONCOS;
            ts.AR_NPRECOS = Convert.ToDecimal(tmpa.AR_NPRECOS);
            ts.AR_DFECCOS = tmpa.AR_DFECCOS;
            ts.AR_CMONCOM = tmpa.AR_CMONCOM;
            ts.AR_NPRECOM = Convert.ToDecimal(tmpa.AR_NPRECOM);
            ts.AR_DFECCOM = tmpa.AR_DFECCOM;
            ts.AR_CCODPRO = tmpa.AR_CCODPRO;
            ts.AR_CMONFOB = tmpa.AR_CMONFOB;
            ts.AR_NPREFOB = Convert.ToDecimal(tmpa.AR_NPREFOB);
            ts.AR_NMARGE1 = Convert.ToDecimal(tmpa.AR_NMARGE1);
            ts.AR_NMARGE2 = Convert.ToDecimal(tmpa.AR_NMARGE2);
            ts.AR_CCLAART = tmpa.AR_CCLAART;
            ts.AR_CPARARA = ddlsarea.SelectedValue;
            ts.AR_CINFTEC = tmpa.AR_CINFTEC;
            ts.AR_CCATALO = tmpa.AR_CCATALO;
            ts.AR_CCATEGO = tmpa.AR_CCATEGO;
            ts.AR_CTIPOI = tmpa.AR_CTIPOI;
            ts.AR_TOBSERV = tmpa.AR_TOBSERV;
            ts.AR_CUNIREF = tmpa.AR_CUNIREF;
            ts.AR_NFACREF = Convert.ToDecimal(tmpa.AR_NFACREF);
            ts.AR_CFUNIRE = tmpa.AR_CFUNIRE;
            ts.AR_CFSTOCK = tmpa.AR_CFSTOCK;
            ts.AR_CFDECI = tmpa.AR_CFDECI;
            ts.AR_CFPRELI = tmpa.AR_CFPRELI;
            ts.AR_CFRESTA = tmpa.AR_CFRESTA;
            ts.AR_CFSERIE = tmpa.AR_CFSERIE;
            ts.AR_CFLOTE = tmpa.AR_CFLOTE;
            ts.AR_CFROTAB = tmpa.AR_CFROTAB;
            ts.AR_CUSUCRE = tmpa.AR_CUSUCRE;
            ts.AR_CUSUMOD = tmpa.AR_CUSUMOD;
            ts.AR_CESTADO = tmpa.AR_CESTADO;
            ts.AR_DFECCRE = tmpa.AR_DFECCRE;
            ts.AR_DFECMOD = tmpa.AR_DFECMOD;
            ts.AR_CCODANT = tmpa.AR_CCODANT;
            ts.AR_NDETRA = Convert.ToDecimal(tmpa.AR_NDETRA);
            ts.AR_CMEDIDA = tmpa.AR_CMEDIDA;
            ts.AR_CANNO = tmpa.AR_CANNO;
            ts.AR_CGROSOR = tmpa.AR_CGROSOR;
            ts.AR_NIMAGEN = Convert.ToDecimal(tmpa.AR_NIMAGEN);
            ts.AR_CFECABC = tmpa.AR_CFECABC;
            ts.AR_NLONSER = Convert.ToDecimal(tmpa.AR_NLONSER);
            ts.AR_CFCELU = tmpa.AR_CFCELU;
            ts.AR_NLONCEL = Convert.ToDecimal(tmpa.AR_NLONCEL);
            ts.AR_CMEDNEU = tmpa.AR_CMEDNEU;
            ts.AR_CINDCAR = tmpa.AR_CINDCAR;
            ts.AR_CDISENO = tmpa.AR_CDISENO;
            ts.AR_NPERC1 = Convert.ToDecimal(tmpa.AR_NPERC1);
            ts.AR_NPERC2 = Convert.ToDecimal(tmpa.AR_NPERC2);
            ts.AR_CMARCA = tmpa.AR_CMARCA;
            ts.AR_CANOFAB = tmpa.AR_CANOFAB;
            ts.AR_CLUGORI = tmpa.AR_CLUGORI;
            ts.AR_CFVEHI = tmpa.AR_CFVEHI;
            ts.AR_CAYUVEN = tmpa.AR_CAYUVEN;
            ts.AR_CCOLOR = tmpa.AR_CCOLOR;
            ts.AR_CTALLA = tmpa.AR_CTALLA;
            ts.AR_CTIPEXI = tmpa.AR_CTIPEXI;
            ts.AR_NMARVTA = Convert.ToDecimal(tmpa.AR_NMARVTA);
            ts.AR_CHORSER = tmpa.AR_CHORSER;
            ts.AR_NIGVCPR = Convert.ToDecimal(tmpa.AR_NIGVCPR);
            ts.AR_CCUENTR = tmpa.AR_CCUENTR;
            ts.AR_CFLGRCN = tmpa.AR_CFLGRCN;
            ts.AR_NTASRCN = Convert.ToDecimal(tmpa.AR_NTASRCN);
            ts.AR_CFORSER = tmpa.AR_CFORSER;
            ts.AR_CCODAG1 = tmpa.AR_CCODAG1;
            ts.AR_CCODAG2 = tmpa.AR_CCODAG2;
            ts.AR_CCODAG3 = tmpa.AR_CCODAG3;
            ts.AR_CCODAG4 = tmpa.AR_CCODAG4;
            ts.AR_CCODAG5 = tmpa.AR_CCODAG5;
            ts.AR_PERTOPE = tmpa.AR_PERTOPE;

            if (idproducto == "" || idproducto == null)
            {              
                if (nrepetic > 0) 
                {
                    Response.Write("<script LANGUAGE='JavaScript'>alert('Esta Tarifa con este proveedor ya fue creada');</script>");
                    btgrabar.Enabled = true;
                }
                else {
               
                    AL0003ARTI.Insertararticulo(ts);
                    Response.Write("<script LANGUAGE='JavaScript'>alert('Registro Grabado');</script>");
                    if (txtidcuenta.Text == "")
                    {

                        var enviousuaxarea = tabla_d_areausua.Listausuarioareaaprob(Convert.ToInt32(ddlsarea.SelectedValue), idproducto, 7);
                        foreach (var d in enviousuaxarea)
                        {
                            if (d.UA_CORREO != "" || d.UA_CORREO != null)
                            {
                                Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "CREACION DE TARIFA POR ASIGNAR CUENTA", d.UA_CORREO, "", copiacorreo, fiche);
                            }
                        }
                    }
                    else
                    {
                        var enviousuaxarea = tabla_d_areausua.Listausuarioareaaprob(Convert.ToInt32(ddlsarea.SelectedValue), idproducto,3);
                        foreach (var d in enviousuaxarea)
                        {
                            if (d.UA_CORREO.Trim() != "" || d.UA_CORREO != null)
                            {
                                Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "CREACION DE TARIFA POR APROBAR", d.UA_CORREO, "", copiacorreo, fiche);
                            }
                        }
                    }
                    btgrabar.Enabled = false; 
                } 
            }
            else {
                
                tabla_d_usuaprod parm = new tabla_d_usuaprod();
                parm.DA_CODIGO = idproducto;
                int numaprob = tabla_d_usuaprod.NumAprobTotal(parm);
                var numaprobxarea = tabla_subareas.Nvalidaareas(ddlsarea.SelectedValue).SA_NAPROB;
                //var naproxusuaF = tabla_d_usuaprod.NumAprobTotalxusuarioF(idproducto);


                var enviousuaxarea= tabla_d_areausua.Listausuarioareaaprob( Convert.ToInt32(ddlsarea.SelectedValue),idproducto,3);

                foreach (var d in enviousuaxarea) { 
                    if (d.UA_CORREO.Trim() != "" && d.UA_CORREO != null) { 
                    Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "MODIFICACION DE TARIFA POR APROBAR", d.UA_CORREO, "", copiacorreo, fiche);
                    }
                }
                /////////agregar a historial de modificaciones
                tabla_d_usuaprodedicion ireg = new tabla_d_usuaprodedicion();
                ireg.DA_CODIGO = txtnuevocod.Text;
                ireg.DA_FECHA = Convert.ToDateTime(hffactual.Value);
                ireg.DA_HORA = Convert.ToString( DateTime.Now.ToString("hh:mm") );
                ireg.DA_IDUSUA = hfusu.Value;
                ireg.DA_PRECIO =Convert.ToDecimal( txttar.Text);
                tabla_d_usuaprodedicion.insertarhistoriamod(ireg);
                ////////////////////////////////////
                AL0003ARTI.Actualizararticulo(ts);
                Response.Write("<script LANGUAGE='JavaScript'>alert('Registro Grabado');</script>");

                btgrabar.Enabled = false;
            }
            
        }
    }

    protected void btnuevo_Click(object sender, EventArgs e)
    {
        //txtnuevocod.Text = AL0003ARTI.ultimocodigoxtipo("R").ToString();
        txtnuevocod.Text = "";
        txtcuenta.Text = "";
        txtidcuenta.Text = "";
        txtprod2.Text = "";
        txttar.Text = "";
        txtidprove.Text = "";
        txtprove.Text = "";
        txtCTASA.Text = "";
        txtDTASA.Text = "";
        lblMTASA.Text = "";
        lblPTASA.Text = "";

        ddltipot.Enabled = true;
        txtcuenta.Enabled = true;
        txtidcuenta.Enabled = true;
        txtprod2.Enabled = true;
        txttar.Enabled = true;
        ddlmone.Enabled = true;
        ddlsarea.Enabled = true;
        txtprove.Enabled = true;
        txtidprove.Enabled = true;
        txtCTASA.Enabled = true;
        //txtDTASA.Enabled = true;

        txtprod2.Focus();
        btgrabar.Enabled = true;
    }






    //protected void txtprod2_TextChanged(object sender, EventArgs e)
    //{
       
    //    txtcuenta.Focus();

    //}

 

    protected void txttar_TextChanged(object sender, EventArgs e)
    {
        btgrabar.Focus();
    
    }

    


    //protected void txtidprove_TextChanged(object sender, EventArgs e)
    //{
    //    if (CT0003ANEX.obtenProveedor(txtidprove.Text) == null)
    //    {
    //        txtprove.Text = CT0003ANEX.obtenProveedor(txtidprove.Text).ADESANE;
    //    }
    //    else
    //    {

    //        Response.Write("<script LANGUAGE='JavaScript'>alert('Registro no existe');</script>");
    //    }
    //}



    protected void txtprove_TextChanged(object sender, EventArgs e)
    {
        ddlsarea.Focus();
    }

    //protected void txtcuenta_TextChanged(object sender, EventArgs e)
    //{
    //    txtprove.Focus(); 
    //} 

    protected void txtidprove_TextChanged(object sender, EventArgs e)
    {
        if (CT0003ANEX.obtenProveedor(txtidprove.Text) == null)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Registro no existe');</script>"); 
        }
        else
        {
            txtprove.Text = CT0003ANEX.obtenProveedor(txtidprove.Text).ADESANE;
        }
    }




}