using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using System.Collections;
using System.IO;

public partial class CancelaDR : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            txtNCU.Focus();
            CT0003TAGE DATA = new CT0003TAGE();
            DATA.TCOD = "26";
            ddlArea.Items.Clear();
            ddlArea.DataTextField = "TDESCRI";
            ddlArea.DataValueField = "TCLAVE";
            ddlArea.DataSource = CT0003TAGE.ListarTG(DATA);
            ddlArea.DataBind();
            ddlArea.SelectedValue = "050";

            vista_prog_pagos DATA1 = new vista_prog_pagos();
            DATA1.CP_CPROGRA = "CPTELES01";
            DATA1.TCOD = "S1";
            ddlTIPA.Items.Clear();
            ddlTIPA.DataTextField = "TDESCRI";
            ddlTIPA.DataValueField = "TCLAVE";
            ddlTIPA.DataSource = CP0003PAGP.listaPXP(DATA1);//CT0003TAGE.ListarTG(DATA1);
            ddlTIPA.DataBind();
            ddlTIPA.Items.Insert(0, new ListItem("[SELECCIONAR]", "XX"));
            ddlTIPA.SelectedValue = "001";

            vista_prog_sub DATA2 = new vista_prog_sub();
            DATA2.CP_CPROGRA = "CPTELS01";
            DATA2.TCOD = "02";
            ddlSUB.Items.Clear();
            ddlSUB.DataTextField = "TDESCRI";
            ddlSUB.DataValueField = "TCLAVE";
            ddlSUB.DataSource = CP0003SUBP.listaSXP(DATA2);
            ddlSUB.DataBind();
            ddlSUB.Items.Insert(0, new ListItem("[SELECCIONAR]", "XX"));
            ddlSUB.SelectedValue = "22";

            CP0003CART DATAP = new CP0003CART();
            /*DATAP.CP = "C";
            DATAP.CP_CVANEXO = "P";
            DATAP.CP_CTIPDOC = "FT";
            DATAP.CP_CSUBDIA="1";
            DATAP.CP_DFECCRE = Convert.ToDateTime(Hoy.Year + "/" + Hoy.Month + "/01");
            DATAP.CP_DFECMOD = Hoy;*/
            var MICOUNT = CP0003CART.listar_pagos_pendientes(DATAP).Count;
            //gvRESUMEN.Columns[2].Visible = false;
            if (MICOUNT == 0)
            {
                inicia_personas();
            }
            else
            {
                gvpersonas.DataSource = CP0003CART.listar_pagos_pendientes(DATAP);
                gvpersonas.DataBind();
            }
            txtreg.Text = MICOUNT.ToString();

            grid2();
            ListaFinal();
        }
    }


    public void inicia_personas()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CVANEXO");
        dtGetDatae.Columns.Add("CP_CCODIGO");
        dtGetDatae.Columns.Add("NOMTIT");
        dtGetDatae.Columns.Add("CP_CTIPO");
        dtGetDatae.Columns.Add("CP_CDESCRI");
        dtGetDatae.Columns.Add("IMPORTE");
        dtGetDatae.Columns.Add("");
        dtGetDatae.Columns.Add("");
        dtGetDatae.Rows.Add();
        gvpersonas.DataSource = dtGetDatae;
        gvpersonas.DataBind();
    }
    public void grid()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("CP_CTDOCRE");
        dtGetData.Columns.Add("CP_CNDOCRE");
        dtGetData.Columns.Add("CP_CVANEXO");
        dtGetData.Columns.Add("CP_CCODIGO");
        dtGetData.Columns.Add("NOMTIT");
        dtGetData.Columns.Add("CP_CTIPDOC");
        dtGetData.Columns.Add("CP_CNUMDOC");
        dtGetData.Columns.Add("CP_CCODMON");
        dtGetData.Columns.Add("IMPORTE");
        dtGetData.Columns.Add("CP_DFDOCRE");
        dtGetData.Columns.Add("CENCOR");
        dtGetData.Columns.Add("NOMARE");
        dtGetData.Columns.Add("CP_CUSER");
        dtGetData.Columns.Add("CP_CSITUAC");
        dtGetData.Columns.Add("");
        dtGetData.Rows.Add();
        //gvDOC.DataSource = dtGetData;
        //gvDOC.DataBind();
    }
    public void grid2()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CP_CTIPDOC");
        dtGetDatae.Columns.Add("CP_CNUMDOC");
        dtGetDatae.Columns.Add("CP_DFECDOC");
        dtGetDatae.Columns.Add("CP_DFECVEN");
        dtGetDatae.Columns.Add("CP_CCODMON");
        dtGetDatae.Columns.Add("CP_NIMPOMN");
        dtGetDatae.Columns.Add("CP_NSALDMN");
        dtGetDatae.Columns.Add("");
        dtGetDatae.Columns.Add("CP_CRETE");
        dtGetDatae.Columns.Add("CP_NPORRE");
        dtGetDatae.Columns.Add("PORDET");
        dtGetDatae.Columns.Add("CP_CCUENTA");
        dtGetDatae.Columns.Add("CP_CCOMPRO");
        dtGetDatae.Columns.Add("CP_NTIPCAM");
        dtGetDatae.Columns.Add("");
        dtGetDatae.Rows.Add();
        gvDCTOS.DataSource = dtGetDatae;
        gvDCTOS.DataBind();
        //gvDCTOS.Columns[12].Visible = false;
    }
    public void ListaFinal()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("DSECUE");
        dtGetData.Columns.Add("DCUENTA");
        dtGetData.Columns.Add("DDETALLE");
        dtGetData.Columns.Add("DCODANE");
        dtGetData.Columns.Add("DCENCOS");
        dtGetData.Columns.Add("DDH");
        dtGetData.Columns.Add("DIMPORT");
        dtGetData.Columns.Add("DTIPDOC");
        dtGetData.Columns.Add("DNUMDOC");
        dtGetData.Columns.Add("DFECDOC2");
        dtGetData.Columns.Add("DFECVEN2");
        //dtGetData.Columns.Add("DMONCON");        
        dtGetData.Rows.Add();
        gvDCOM.DataSource = dtGetData;
        gvDCOM.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    protected void gvpersonas_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> BancosxCta(CP0003CUBA DATA)
    {
        return CP0003CUBA.ListarBancosxCta(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> BancosxCtaD(CP0003CUBA DATA)
    {
        return CP0003CUBA.ListarBancosxCtaD(DATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CTCAMB tipoCambio(CTCAMB CODATA)
    {
        return CTCAMB.obetenertcambio(CODATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aNumeracion(CT0003NUME16 CDATA)
    {
        //INSERTA-ACTUALIZA LIQUIDACION REGISTRO PAGO-SISPAG
        CT0003NUME16.Numeracion(CDATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static String correlativoPG(CP0003PAGO DATA)
    {
        return CP0003PAGO.correlativoPG1(DATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarACAB(CT0003COMC16 ACDATA)
    {
        CT0003COMC16.insertaCabecera(ACDATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarADET(CT0003COMD16 ADDATA)
    {
        CT0003COMD16.insertaDetalle(ADDATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaBAL(CT0003BALH16 BDATA)
    {
        CT0003BALH16.actualizar(BDATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean guardarPLQ(CP0003PAGO DATA)
    {
        //INSERTA REGISTRO PAGO
        return CP0003PAGO.insertaCabecera(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vistas_finanzas> pagos_proveedor(vistas_finanzas DATA)
    {
        return CP0003CART.pagos_proveedor(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizarSaldo(CP0003CART DATA)
    {
        CP0003CART.actualizarsaldoENEJECUCION(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean registrar_vari(CP0003VARI DATA)
    {
        return CP0003VARI.insertar(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003PLEM> ListaPlanC(CT0003PLEM PDATA)
    {
        return CT0003PLEM.ListaPlanID(PDATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static tabla_parametros ListarParametroID(tabla_parametros DATA)
    {
        return tabla_parametros.ListarParametroID3(DATA);
        //return tabla_parametros.ListarParametroID(COD,KEY);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros DATA)
    {
        return tabla_parametros.ListarParametro(DATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003COMD16> c_detalle(CT0003COMD16 DATA)
    {
        return CT0003COMD16.listadetalle_le(DATA);
    }
    /*[System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void banco(vista_pago DATA){
        var datos = new vista_pago();
        var MICAD = txtACR0.Text.Split('-');
        datos.PG_CVANEXO = MICAD[0];
        datos.PG_CCODIGO = MICAD[1];
        exportar(datos);
    }*/
}



