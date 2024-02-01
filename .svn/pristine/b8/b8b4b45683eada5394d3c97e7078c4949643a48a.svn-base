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
using CapaEntidades;
using System.Web.Services;

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {


            txtfini.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtffin.Text = DateTime.Now.ToString("dd/MM/yyyy");
            gridpedidos();
            gridguias();
            gridFACTURAs();
            gridBOLETAs();
        }
    }

    public void gridpedidos()
    {
        DataTable gridg = new DataTable();
        gridg.Columns.Add("D01");
        gridg.Columns.Add("D02");
        gridg.Columns.Add("D03");
        gridg.Columns.Add("D04");
        gridg.Columns.Add("D05");
        gridg.Columns.Add("D06");
        gridg.Columns.Add("D07");
        gridg.Columns.Add("D08");
        gridg.Columns.Add("D09");
        gridg.Columns.Add("D10");
        gridg.Rows.Add();
        gridpeda.DataSource = gridg;
        gridpeda.DataBind();
    }

    public void gridguias()
    {
        DataTable gridg = new DataTable();
        gridg.Columns.Add("D01");
        gridg.Columns.Add("D02");
        gridg.Columns.Add("D03");
        gridg.Columns.Add("D04");
        gridg.Columns.Add("D05");
        gridg.Columns.Add("D06");
        gridg.Rows.Add();
        gvguias.DataSource = gridg;
        gvguias.DataBind();
    }

    public void gridFACTURAs()
    {
        DataTable gridg = new DataTable();
        gridg.Columns.Add("D01");
        gridg.Columns.Add("D02");
        gridg.Columns.Add("D03");
        gridg.Columns.Add("D04");
        gridg.Columns.Add("D05");
        gridg.Columns.Add("D06");
        gridg.Columns.Add("D07");
        gridg.Rows.Add();
        gvfactura.DataSource = gridg;
        gvfactura.DataBind();
    }

    public void gridBOLETAs()
    {
        DataTable gridg = new DataTable();
        gridg.Columns.Add("D01");
        gridg.Columns.Add("D02");
        gridg.Columns.Add("D03");
        gridg.Columns.Add("D04");
        gridg.Columns.Add("D05");
        gridg.Columns.Add("D06");
        gridg.Columns.Add("D07");
        gridg.Rows.Add();
        gvboleta.DataSource = gridg;
        gvboleta.DataBind();
    }


    [WebMethod]
    [ScriptMethod]
    public static List<VISTA_PEDIDOS1612> FlistaPedidos(string EST)
    {
        
        return VISTA_PEDIDOS1612.F_ListarPedido(EST);
    }

    [WebMethod]
    [ScriptMethod]
    public static List<VISTA_GUIASC> FlistaGuias(string f1, string f2, string EST)
    {
      
        return VISTA_GUIASC.LGuiasxEstado(f1, f2, EST);
    }

    [WebMethod]
    [ScriptMethod]
    public static List<FT0003ACUC> FlistaFacturas(string f1, string f2, string EST,string TDOC)
    {
      
        return FT0003ACUC.ListaFacturasEs(f1, f2, EST, TDOC);
    }


    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover",
            "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout",
            "this.style.backgroundColor=this.originalstyle;");
        }
    }

    protected void btbusqueda_Click(object sender, EventArgs e)
    {
        //Cls_Pedido fas = new Cls_Pedido();
        int trs, tpp, g_lgf, g_lgsf, f_lfp, f_lfsp, f_lbp, f_lbsp;
        string a = string.Empty; string b = string.Empty;
        a = txtfini.Text;
        b = txtffin.Text;

        //Pedidos
        trs = VISTA_PEDIDOS.cpedidosa("A");
        tpp = VISTA_PEDIDOS.cpedidosa("P");

        DataTable gridp = new DataTable();
        gridp.Columns.Add("F5_CNUMPED");
        gridp.Columns.Add("aprobados");
        gridp.Columns.Add("Pendientes");
        gridp.Rows.Add("", trs, tpp);
        gridpedido.DataSource = gridp;
        gridpedido.DataBind();

        //Guia Remision
        g_lgf = VISTA_GUIASC.LGuiasfacturada(a, b,"F");
        g_lgsf = VISTA_GUIASC.LGuiasfacturada(a, b,"V");

        DataTable gridg = new DataTable();
        gridg.Columns.Add("F5_CNUMPED");
        gridg.Columns.Add("aprobados");
        gridg.Columns.Add("Pendientes");

        gridg.Rows.Add("", g_lgf, g_lgsf);

        gridguia.DataSource = gridg;
        gridguia.DataBind();


        //Facturas
        f_lfp = FT0003ACUC.ListaFacturasEs(a, b, "1","FT").Count;
        f_lfsp = FT0003ACUC.ListaFacturasEs(a, b, "0", "FT").Count;

        DataTable gridf = new DataTable();
        gridf.Columns.Add("F5_CNUMPED");
        gridf.Columns.Add("aprobados");
        gridf.Columns.Add("Pendientes");

        gridf.Rows.Add("", f_lfp, f_lfsp);

        gridfacturas.DataSource = gridf;
        gridfacturas.DataBind();


        //Boletas
        f_lbp = FT0003ACUC.ListaFacturasEs(a, b, "1", "BV").Count;
        f_lbsp = FT0003ACUC.ListaFacturasEs(a, b, "0", "BV").Count;

        DataTable gridb = new DataTable();
        gridb.Columns.Add("F5_CNUMPED");
        gridb.Columns.Add("aprobados");
        gridb.Columns.Add("Pendientes");

        gridb.Rows.Add("", f_lbp, f_lbsp);

        gridboletas.DataSource = gridb;
        gridboletas.DataBind();

    }

    protected void bttimprimir_Click(object sender, EventArgs e)
    {
        string x = string.Empty;
        string y = string.Empty;
        string p = string.Empty;
        string ndec = string.Empty;
        ndec = "2";
        x = inidpedido.Value;
        y = "ES";
        p = "1";
        //Cls_Pedido web = new Cls_Pedido();
        string server = string.Empty;
        string pass = string.Empty;
        string dbname = string.Empty;
        string dbusu = string.Empty;
        string creport = string.Empty;
        string creportn = string.Empty;
        string creportnc = string.Empty;

        server = "192.168.10.5";
        pass = "SEA2013frost";
        dbname = "RSFACCAR";
        dbusu = "sa";
        creport = "REPORTE_PEDIDO.rpt";
        creportnc = "REPORTE_PEDIDO_NCONG.rpt";
        creportn = "REPORTE_PEDIDO_NAC.rpt";
        string[] parametros = { x, y, p, ndec };

        //Cls_Pedido pedt = new Cls_Pedido();
        VISTA_DCABECERA pedit = new VISTA_DCABECERA()
        {
            F5_CNUMPED = inidpedido.Value
        };
        var tipopedidov = "";
        //tipopedidov = pedt.Vertipopedido(pedit).ToString();


        //Cls_Pedido pedtalma = new Cls_Pedido();
        VISTA_DCABECERA peditalma = new VISTA_DCABECERA()
        {
            F5_CNUMPED = inidpedido.Value
        };
        var tipopedidovalma = "";
        tipopedidovalma = VISTA_DCABECERA.Vertipoalmacen(peditalma).ToString();

        if (tipopedidov == "E" && (tipopedidovalma == "0002" || tipopedidovalma == "0012"))
        {

            System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creport, server, dbname, dbusu, pass, parametros, "Reporte");
            Session["rutacrystal"] = rutalocal;
        }
        else if (tipopedidov == "E" && tipopedidovalma == "0003")
        {
            System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creportn, server, dbname, dbusu, pass, parametros, "Reporte");
            Session["rutacrystal"] = rutalocal;
        }
        else
        {
            if (tipopedidov == "N" && tipopedidovalma == "0003")
            {
                System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creportn, server, dbname, dbusu, pass, parametros, "Reporte");
                Session["rutacrystal"] = rutalocal;
            }
            else
            {
                if (tipopedidov == "N" && (tipopedidovalma == "0002" || tipopedidovalma == "0012"))
                {
                    System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creportn, server, dbname, dbusu, pass, parametros, "Reporte");
                    Session["rutacrystal"] = rutalocal;
                }
            }
        }


        string strUrl = string.Empty;
        strUrl = "WebForm2.aspx";

        Response.Redirect(strUrl);
        //}
    }


    protected void btimprimir_Click(object sender, EventArgs e)
    {


        string x = string.Empty;


        x = txtnguia.Value;


        string server = string.Empty;
        string pass = string.Empty;
        string dbname = string.Empty;
        string dbusu = string.Empty;
        string creport = string.Empty;
        string creport04 = string.Empty;
        string creport02 = string.Empty;
        server = "192.168.10.5";
        pass = "SEA2013frost";
        dbname = "RSFACCAR";
        dbusu = "sa";
        creport = "REPORTE_GUIA.rpt";
        creport04 = "REPORTE_GUIAS0004.rpt";
        creport02 = "REPORTE_GUIAS0002.rpt";
        //server = ".";
        string[] parametros = { x };

        if (txtnguia.Value == "")
        {

        }
        else
        {
            if (hfserie.Value == "0004")
            {

                System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creport04, server, dbname, dbusu, pass, parametros, "Reporte");
                Session["rutacrystal"] = rutalocal;
            }
            else
            {
                if (hfserie.Value == "0001")
                {
                    System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creport, server, dbname, dbusu, pass, parametros, "Reporte");
                    Session["rutacrystal"] = rutalocal;
                }
                else
                {
                    System.IO.Stream rutalocal = Cls_Utilidades.ImprimirCrystalReport(creport02, server, dbname, dbusu, pass, parametros, "Reporte");
                    Session["rutacrystal"] = rutalocal;
                }

            }
            string strUrl = string.Empty;
            strUrl = "WebForm2.aspx";

            Response.Redirect(strUrl);
        }



    }



    protected void btexc_Click(object sender, EventArgs e)
    {
        var F1 = txtfini.Text;
        var F2 = txtffin.Text;
        var estadoP = hfestadoP.Value;
        var estadoG = hfestadoG.Value;
        var estadoF = hfestadoF.Value;
        var estadoB = hfestadoB.Value;
        if (estadoP != "")
        {
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../REPORTES/Reporte.aspx?ES=" + estadoP + "' ,'_blank');</script>");
        }else if (estadoG != "")
        {
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../REPORTES/ReporteGR.aspx?ES=" + estadoG + "&f1=" + F1 + "&f2=" + F2 + "' ,'_blank');</script>");
        }
        else if(estadoF!="") 
        {
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../REPORTES/ReporteFT.aspx?ES=" + estadoF + "&f1=" + F1 + "&f2=" + F2 +"&TD="+"FT"+ "' ,'_blank');</script>");
        }
        else
        {
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../REPORTES/ReporteFT.aspx?ES=" + estadoF + "&f1=" + F1 + "&f2=" + F2 + "&TD=" + "BV" + "' ,'_blank');</script>");
        }

    }
}