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
            ListaMovi();
            ListaUsuarioPro();
            Listahistorico();

            ddlfilt.Items.Insert(0, new ListItem("Sin Aprobar", "S"));
            ddlfilt.Items.Insert(1, new ListItem("Aprobados", "A"));
            ddlfilt.Items.Insert(2, new ListItem("[TODOS]", "T")); 
            ddlfilt.SelectedValue = "S";
            //var lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);  

            //var lar = AL0003ARTI.ListarServparaVBF(ddlfilt.SelectedValue).Where(r=>r.AR_NMARGE2==1).ToList();
            //gvproductos.DataSource = lar;
            //gvproductos.DataBind();

            var lar = new List<AL0003ARTI>();
            //var lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
            int sivalida = UT0030.ListarUsuariosxF().Where(r => r.TU_ALIAS == hfusu.Value).ToList().Count();
            if (sivalida == 1)
            {
                if (ddlfilt.SelectedValue == "A")
                {
                    lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
                }
                else { 
                lar = AL0003ARTI.ListarServparaVBF(ddlfilt.SelectedValue).Where(r => r.AR_NMARGE2 == 1).ToList();
                }
            }
            else
            {
                lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
            }

            gvproductos.DataSource = lar;
            gvproductos.DataBind();






        }
    }

    public void ListaMovi() 
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("AR_CCODIGO");
        dtGetDatae.Columns.Add("AR_CDESCRI");
        dtGetDatae.Columns.Add("AR_CUNIDAD");
        dtGetDatae.Columns.Add("AR_NPRECOM");
        dtGetDatae.Columns.Add("AR_CMONCOM");
        dtGetDatae.Columns.Add("AR_CPARARA");
        dtGetDatae.Columns.Add("AR_CCONTRO");
        dtGetDatae.Columns.Add("AR_CUSUCRE");
        dtGetDatae.Columns.Add("AR_CCODPRO"); 
        dtGetDatae.Rows.Add();
        gvproductos.DataSource = dtGetDatae;
        gvproductos.DataBind();
    }

    public void ListaUsuarioPro()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("DA_IDUSUA");
        dtGetDatae.Columns.Add("DA_FECHA");
        dtGetDatae.Columns.Add("DA_HORA");

        dtGetDatae.Rows.Add();
        gvusuarios.DataSource = dtGetDatae;
        gvusuarios.DataBind();
    }

    public void Listahistorico()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("OC_CDESREF");
        dtGetDatae.Columns.Add("OC_DFECDOC");
        dtGetDatae.Columns.Add("OC_NTOTMN");
        dtGetDatae.Columns.Add("OC_NTOTUS");
        dtGetDatae.Rows.Add();
        gvhistorico.DataSource = dtGetDatae;
        gvhistorico.DataBind();
    }

    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<UT0030> listarusuarios(string nombre)
    {
        return UT0030.ListarautocUsuarios(nombre);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<tabla_d_usuaprod> listarusuariosaproba(string idproducto)
    {
        return tabla_d_usuaprod.AprobacionxProductodetall(idproducto);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<CO0003MOVD> HistoricoxProducto(CO0003MOVD CO0003MOVD)
    {
        return CO0003MOVD.ListaHistoricoxTar(CO0003MOVD);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static AL0003ARTI ObtenerArticuloun(string codarti)
    {
        return AL0003ARTI.obtenerArticuloPorID(codarti);
    }
    

   [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Validausuarioniv(string usua,int numnivel)
    {
        return tabla_d_nivelusua.Validausuanivel(usua, numnivel);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Validausuariocuenta(string usua)
    {
        return tabla_d_nivelusua.Validausuacuenta(usua);
    }
    
    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Extraenaprob(tabla_d_usuaprod parm)
    {
        return tabla_d_usuaprod.NumAprob(parm);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string Subareasnaprob(string codprod)
    {
        return AL0003ARTI.Obtenernaprobaxarea(codprod).Trim();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static int Subareanusua(string codusua,string codarea)
    {
        return tabla_d_areausua.Listarsubareacceso(codusua, codarea);
    }
    

    [System.Web.Services.WebMethod] 
    [ScriptMethod()] 
    public static int Extraenaprobtotal(tabla_d_usuaprod parm) 
    {
        return tabla_d_usuaprod.NumAprobTotal(parm); 
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static string Extraeunacuenta(string ncuenta)
    {
        return FT0003CTAE.RegistrounCta(ncuenta);
    }
    

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void ActualizaEstado(AL0003ARTI INF)
    {
        AL0003ARTI.ActualizaARestado(INF); 
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Actualizacuenta(AL0003ARTI INF)
    {
        AL0003ARTI.ActualizaARcuenta(INF);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void Insertadetallprodusua(tabla_d_usuaprod INF)
    {
        tabla_d_usuaprod.Actualizardetup(INF);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void eliminausuaprod(tabla_d_usuaprod INF)
    {
        tabla_d_usuaprod.DesapruebaTarifa(INF);
    }
    

    protected void ddlfilt_SelectedIndexChanged(object sender, EventArgs e)
    {
        var lar = new List<AL0003ARTI>();
        //var lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
        int sivalida= UT0030.ListarUsuariosxF().Where(r => r.TU_ALIAS == hfusu.Value).ToList().Count();
        if (sivalida == 1)
        {
            if (ddlfilt.SelectedValue == "A")
            {
                lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
            }
            else {
                lar = AL0003ARTI.ListarServparaVBF(ddlfilt.SelectedValue).Where(r => r.AR_NMARGE2 == 1).ToList();
            }
        }
        else
        {
            lar = AL0003ARTI.ListarArticulosxestado(ddlfilt.SelectedValue);
        }

        gvproductos.DataSource = lar;
        gvproductos.DataBind();
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static void enviofinalemail(string idusuario,string idprod)
    {
        List<string> fiche = new List<string>();
        AL0003ARTI mostrarprod = new AL0003ARTI();
        mostrarprod  = AL0003ARTI.obtenerArticuloPorID(idprod);
        string informa = "<html><body> <table border='1' style='font-size:14px'><tr><td colspan='2' align='center' bgcolor='#7ACAFF'> <b>" + "SERVICIO" + "</b></td></tr><tr><td colspan='2' align='center' bgcolor='#FFCC99'>" + mostrarprod.AR_CDESCRI + "</td></tr><tr><td>" + " PROVEEDOR: " + "</td><td>" + CT0003ANEX.obtenProveedor(mostrarprod.AR_CCODPRO.Trim()).ADESANE+ "</td></tr><tr><td>" + " TARIFA: " + "</td><td>" + Convert.ToDecimal(string.Format("{0:00.0000}", mostrarprod.AR_NPRECOM)) + "</td></tr><tr><td>" 
                + " AREA: " + "</td><td>" + tabla_subareas.Listarsubareas().Where(a=>a.SA_ID.ToString()== mostrarprod.AR_CPARARA).First().SA_DESC + "</td></tr><tr><td>" + " MONEDA: " + "</td><td>" + mostrarprod.AR_CMONCOM.Trim() + "</td></tr><tr><td>" + " TIPO:" + "</td><td>" + mostrarprod.AR_CTIPDES + "</td></tr><tr><td>" + " USUARIO: " + "</td><td>" + UT0030.Mostrarunusuario(mostrarprod.AR_CUSUCRE) + "</td></tr></table></body></html>";

        var enviousuaxarea = UT0030.ListarUsuariosxF(); 
        foreach (var d in enviousuaxarea)
        {
            if (d.TU_CORREO.Trim() != "" || d.TU_CORREO != null)
            {
                Cls_Utilidades.enviarMail("programador1@seafrost.com.pe", "mail.seafrost.com.pe", "SEA2015frost", informa, "APROBACION FINAL DE SERVICIO", d.TU_CORREO, "", "", fiche);
            }
        }
    }




}