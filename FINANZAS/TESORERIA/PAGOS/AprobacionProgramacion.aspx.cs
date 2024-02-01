using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;
using ClosedXML.Excel;
using System.IO;
using System.Drawing;

public partial class FINANZAS_TESORERIA_PAGOS_AprobacionProgramacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtfecha.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtmes.Text = Convert.ToString(DateTime.Now.Month);
            txtannio.Text = Convert.ToString(DateTime.Now.Year);
            rbdia.Checked = true;
            rbmes.Checked = false;
            inicio();
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            vergrilla();

            CT0003AGEN area = new CT0003AGEN();
            ddlagencia.Items.Clear();
            ddlagencia.DataTextField = "AG_CNOMAGE";
            ddlagencia.DataValueField = "AG_CCODAGE";
            ddlagencia.DataSource = CT0003AGEN.ListarAgencia();
            ddlagencia.DataBind();
            ddlagencia.Items.Insert(0, new ListItem("[AGENCIAS]", "-1"));


            CP0003CUBA BAN = new CP0003CUBA();
            ddlbanco.Items.Clear();
            ddlbanco.DataTextField = "CT_CDESCTA";
            ddlbanco.DataValueField = "CT_CNUMCTA";
            ddlbanco.DataSource = CP0003CUBA.ListarBancos();
            ddlbanco.DataBind();
            ddlbanco.Items.Insert(0, new ListItem("[BANCOS]", "-1"));



            CP0003TABL TIPOPAGO = new CP0003TABL();
            TIPOPAGO.TG_INDICE = "60";
            ddltipopago.Items.Clear();
            ddltipopago.DataTextField = "TG_DESCRI";
            ddltipopago.DataValueField = "TG_CODIGO";
            ddltipopago.DataSource = CP0003TABL.ListarTablaS(TIPOPAGO);
            ddltipopago.DataBind();
            ddltipopago.Items.Insert(0, new ListItem("[TIPOPAGO]", "-1"));



            CP0003TABL DEPARTAMENTO = new CP0003TABL();
            DEPARTAMENTO.TG_INDICE = "90";
            ddldepartamento.Items.Clear();
            ddldepartamento.DataTextField = "TG_DESCRI";
            ddldepartamento.DataValueField = "TG_CODIGO";
            ddldepartamento.DataSource = CP0003TABL.ListarTabla(DEPARTAMENTO);
            ddldepartamento.DataBind();
            ddldepartamento.Items.Insert(0, new ListItem("[DEPARTAMENTO]", "-1"));



            CP0003COPR CONCEPTO = new CP0003COPR();
            ddlconcepto.Items.Clear();
            ddlconcepto.DataTextField = "CG_CCONCEP";
            ddlconcepto.DataValueField = "CG_CCODCON";
            ddlconcepto.DataSource = CP0003COPR.ListarTodos();
            ddlconcepto.DataBind();
            ddlconcepto.Items.Insert(0, new ListItem("[CONCEPTO]", "-1"));



        }
    }

    public void vergrilla()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("GD_CVANEXO");
        dtGetDatae.Columns.Add("GD_CCODIGO");
        dtGetDatae.Columns.Add("GD_CNDREF");
        dtGetDatae.Columns.Add("GD_CTIPDOC");
        dtGetDatae.Columns.Add("GD_CNUMDOC");
        dtGetDatae.Columns.Add("GD_DFECDOC");
        dtGetDatae.Columns.Add("GD_DFECVEN");
        dtGetDatae.Columns.Add("GD_CMONCAR");
        dtGetDatae.Columns.Add("GD_NORPROG");
        dtGetDatae.Columns.Add("GD_NORRETE");
        dtGetDatae.Columns.Add("GD_CRETE");
        dtGetDatae.Columns.Add("GD_NMNPROG");
        dtGetDatae.Columns.Add("GD_CTASDET");

        dtGetDatae.Rows.Add();
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }

    public void inicio()
    {
        CP0003PRGC PROGRAMACION = new CP0003PRGC();

        PROGRAMACION.GC_CESTADO = "P";

        gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSP(PROGRAMACION);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    public void VERGRILLAPRINCIPAL()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("GC_CCODAGE");
        dtGetDatae.Columns.Add("GC_CNUMOPE");
        dtGetDatae.Columns.Add("GC_CUSUCRE");
        dtGetDatae.Columns.Add("GC_CCODCON");
        dtGetDatae.Columns.Add("GC_CTIPPAG");
        dtGetDatae.Columns.Add("GC_CCODBAN");
        dtGetDatae.Columns.Add("GC_CCODMON");
        dtGetDatae.Columns.Add("GC_NMONPRO");
        dtGetDatae.Columns.Add("GC_CESTADO");

        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    protected void btnfiltro_Click(object sender, EventArgs e)
    {
        CP0003PRGC PROGRAMACION = new CP0003PRGC();
        PROGRAMACION.GC_CCODAGE = ddlagencia.Text;
        PROGRAMACION.GC_CCODBAN = ddlbanco.Text;
        PROGRAMACION.GC_CTIPPAG = ddltipopago.Text;
        PROGRAMACION.GC_CCODDEP = ddldepartamento.Text;
        PROGRAMACION.GC_CCODCON = ddlconcepto.Text;
        PROGRAMACION.GC_CESTADO = "P";
        VERGRILLAPRINCIPAL();

        if (rbdia.Checked)
        {
            if (this.txtfecha.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar una fecha válida"), false);
            }
            else
            {
                PROGRAMACION.GC_DFECPRO = Convert.ToDateTime(this.txtfecha.Text);
                if (gvordencompra.Rows.Count > 0)
                {
                    gvordencompra.UseAccessibleHeader = true;
                    gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSFILTROP(PROGRAMACION);
                    gvordencompra.DataBind();
                }
            }

        }
        if (rbmes.Checked)
        {
            if ((this.txtannio.Text == "") && (this.txtmes.Text == ""))
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar un mes y un año válidos"), false);
            }
            else
            {
                PROGRAMACION.GC_NMONPRO = Convert.ToDecimal(this.txtannio.Text);
                PROGRAMACION.GC_NTIPCAM = Convert.ToDecimal(this.txtmes.Text);
                if (gvordencompra.Rows.Count > 0)
                {
                    gvordencompra.UseAccessibleHeader = true;
                    gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
                    gvordencompra.DataSource = CP0003PRGC.LISTARTTODOSFILTROP(PROGRAMACION);
                    gvordencompra.DataBind();
                }
            }
        }
        if (!rbmes.Checked && !rbdia.Checked)
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe seleccionar una opcion de la parte superior referente a la fecha"), false);
        }
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static List<CTCAMB> obetenertcambiocvEdgar()
    //{
    //    return CTCAMB.obetenertcambiocvEdgar();
    //}

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003PRGD> LISTARTTODOS(string dato)
    {
        return CP0003PRGD.LISTARTTODOS(dato);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CART> filtrodetalle(CP0003CART CODATA)
    {
        return CP0003CART.SELECTDETALLES(CODATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_programacion> LISTARUNO(string CODATA)
    {
        return CP0003PRGC.LISTARUNO(CODATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void actualizaEstado(CP0003PRGC alumno)
    {
        CP0003PRGC.actualizaEstado(alumno);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string INCONSISTENCIACUENTADET(CP0003MAES ADATA)
    {
        return CP0003MAES.INCONSISTENCIACUENTADET(ADATA);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ELIMINACABECERA(CP0003PRGC alumno)
    {
        CP0003PRGC.EliminaItems(alumno);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ELIMINADETALLE(CP0003PRGD ADATA)
    {
        CP0003PRGD.EliminaItems(ADATA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaLog2(CP0003LOG2 ADATA)
    {
        CP0003LOG2.insertar(ADATA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_parametros> getPARAM(tabla_parametros PDATA)
    {
        return tabla_parametros.ListarParametro(PDATA);
    }

    protected void btnlistar_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");

        CP0003PRGC consultacab = new CP0003PRGC();
        CP0003PRGD consultadet = new CP0003PRGD();
        List<vista_detalle_programacion> CABECERA = new List<vista_detalle_programacion>();
        List<CP0003PRGD> DETALLE = new List<CP0003PRGD>();
        int cont = 17;
        int CONTDOC = 0;
        decimal sumsol = 0;
        decimal sumdol = 0;


        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("Programación de Pagos " + this.txtprogramacion.Text).Style.Font.SetBold(true);
        worksheet.Range("C4:J4").Row(1).Merge();

        CABECERA = CP0003PRGC.LISTARUNO1(txtprogramacion.Text);
        DETALLE = CP0003PRGD.LISTARTTODOS1(txtprogramacion.Text);

        foreach (vista_detalle_programacion a in CABECERA)
        {
            worksheet.Cell("D" + 5).Value = ("'" + a.AGENCIA + "-" + a.AGENCIA2 + "");

            worksheet.Cell("A" + 6).SetValue("Fecha Programacion").Style.Font.SetBold(true);
            worksheet.Cell("A" + 7).SetValue("Concepto").Style.Font.SetBold(true);
            worksheet.Cell("A" + 8).SetValue("Tipo Pago").Style.Font.SetBold(true);
            worksheet.Cell("A" + 9).SetValue("Banco").Style.Font.SetBold(true);
            worksheet.Cell("A" + 10).SetValue("Importe").Style.Font.SetBold(true);
            worksheet.Cell("A" + 11).SetValue("Estado").Style.Font.SetBold(true);
            worksheet.Cell("A" + 12).SetValue("Moneda").Style.Font.SetBold(true);
            worksheet.Cell("A" + 13).SetValue("Tipo Cambio").Style.Font.SetBold(true);
            worksheet.Cell("A" + 14).SetValue("Tipo Detracción").Style.Font.SetBold(true);
            worksheet.Cell("A" + 15).SetValue("Lote").Style.Font.SetBold(true);

            worksheet.Cell("B" + 6).Value = ("'" + a.fecah + "").Substring(0, 11);
            worksheet.Cell("B" + 7).Value = ("'" + a.CONCEPTO + "");
            worksheet.Cell("B" + 8).Value = a.tipopago;
            worksheet.Cell("B" + 9).Value = a.BANCO;
            worksheet.Cell("B" + 10).Value = ("'" + a.IMPORTE + "");
            worksheet.Cell("B" + 11).Value = a.ESTADO;
            worksheet.Cell("B" + 12).Value = a.moneda;
            worksheet.Cell("B" + 13).Value = ("'" + a.TIPOCAMBIO + "");
            worksheet.Cell("B" + 14).Value = a.TIPODETRACCION;
            worksheet.Cell("B" + 15).Value = ("'" + a.BANCOCUENTA + "");


            worksheet.Cell("F" + 6).SetValue("Departamento").Style.Font.SetBold(true);
            worksheet.Cell("F" + 7).SetValue("Elaborado Por").Style.Font.SetBold(true);
            worksheet.Cell("F" + 8).SetValue("Modificado Por").Style.Font.SetBold(true);
            worksheet.Cell("F" + 9).SetValue("Aprobado Por").Style.Font.SetBold(true);
            worksheet.Cell("F" + 10).SetValue("Fecha Creación").Style.Font.SetBold(true);
            worksheet.Cell("F" + 11).SetValue("Fecha Modificación").Style.Font.SetBold(true);
            worksheet.Cell("F" + 12).SetValue("Fecha Aprobación").Style.Font.SetBold(true);
            worksheet.Cell("F" + 13).SetValue("Vence A").Style.Font.SetBold(true);
            //worksheet.Cell("F" + 14).SetValue("Número de Operación").Style.Font.SetBold(true);
            //worksheet.Cell("F" + 15).SetValue("Fecha Depósito Det.").Style.Font.SetBold(true);

            worksheet.Cell("H" + 6).Value = ("'" + a.DEPARTAMENTO + "");
            worksheet.Cell("H" + 7).Value = ("'" + a.USUCRE + "");
            worksheet.Cell("H" + 8).Value = a.USUMOD;
            worksheet.Cell("H" + 9).Value = a.USUAPRO;
            worksheet.Cell("H" + 10).Value = ("'" + a.FECRE + "").Substring(0, 11);
            worksheet.Cell("H" + 11).Value = ("'" + a.FEMOD + "").Substring(0, 11);
            if (a.FEAPRO != null)
            {
                worksheet.Cell("H" + 12).Value = ("'" + a.FEAPRO + "").Substring(0, 11);
            }
            else
            {
                worksheet.Cell("H" + 12).Value = ("");
            }

            TimeSpan TS = Convert.ToDateTime(DateTime.Today) - Convert.ToDateTime(a.fecah);
            worksheet.Cell("H" + 13).Value = TS.Days + " dias";
            worksheet.Cell("H" + 14).Value = ("'" + a.operacion + "");
            // worksheet.Cell("H" + 15).Value = ("'" + a.foperacion + "");
        }
        // para el filtrado del detalle

        foreach (CP0003PRGD b in DETALLE)
        {
            cont = cont + 1;

            worksheet.Cell("A" + 17).SetValue("Proveedor").Style.Font.SetBold(true);
            worksheet.Cell("B" + 17).SetValue("Nombre").Style.Font.SetBold(true);
            worksheet.Cell("C" + 17).SetValue("TD").Style.Font.SetBold(true);
            worksheet.Cell("D" + 17).SetValue("Número").Style.Font.SetBold(true);
            worksheet.Cell("E" + 17).SetValue("Emisión").Style.Font.SetBold(true);
            worksheet.Cell("F" + 17).SetValue("Vmto").Style.Font.SetBold(true);
            worksheet.Cell("G" + 17).SetValue("Moneda").Style.Font.SetBold(true);
            worksheet.Cell("H" + 17).SetValue("Programado MN").Style.Font.SetBold(true);
            worksheet.Cell("I" + 17).SetValue("Programado US").Style.Font.SetBold(true);
            worksheet.Cell("J" + 17).SetValue("Com. Provisión").Style.Font.SetBold(true);
            worksheet.Cell("K" + 17).SetValue("Tasa Detracción").Style.Font.SetBold(true);
            // worksheet.Cell("L" + 17).SetValue("Número Constancia").Style.Font.SetBold(true);
            worksheet.Cell("L" + 17).SetValue("Orden C/S").Style.Font.SetBold(true);

            worksheet.Cell("A" + cont.ToString()).Value = ("" + b.GD_CVANEXO + "" + "-" + "" + b.GD_CCODIGO + "");
            worksheet.Cell("B" + cont.ToString()).Value = ("'" + b.GD_CNDREF + "");
            worksheet.Cell("C" + cont.ToString()).Value = b.GD_CTIPDOC;
            worksheet.Cell("D" + cont.ToString()).Value = b.GD_CNUMDOC;
            worksheet.Cell("E" + cont.ToString()).Value = b.GD_DFECDOC;
            worksheet.Cell("F" + cont.ToString()).Value = b.GD_DFECVEN;
            worksheet.Cell("G" + cont.ToString()).Value = b.GD_CMONCAR;
            worksheet.Cell("H" + cont.ToString()).Value = b.GD_NMNPROG;
            worksheet.Cell("I" + cont.ToString()).Value = "";
            worksheet.Cell("J" + cont.ToString()).Value = b.GD_CSUBCOM + "-" + b.GD_CNUMCOM;
            worksheet.Cell("K" + cont.ToString()).Value = b.GD_CTASDET;
            // worksheet.Cell("L" + cont.ToString()).Value = b.GD_CNOCONS;
            worksheet.Cell("L" + cont.ToString()).Value = ("'" + b.GD_CCODAGE + "");
            CONTDOC = CONTDOC + 1;
            sumsol = sumsol + b.GD_NMNPROG;
        }
        worksheet.Cell("B" + (cont + 1).ToString()).Value = ("Total de Documentos (" + (CONTDOC) + ")");
        worksheet.Cell("F" + (cont + 1).ToString()).Value = ("Total General");
        worksheet.Cell("H" + (cont + 1).ToString()).Value = (sumsol);
        worksheet.Cell("I" + (cont + 1).ToString()).Value = (sumdol);

        worksheet.Column(1).Width = 20; // SOLICITUD
        worksheet.Column(2).Width = 40; //ORDEN
        worksheet.Column(3).Width = 5;
        worksheet.Column(4).Width = 10;
        worksheet.Column(5).Width = 10;
        worksheet.Column(6).Width = 10;
        worksheet.Column(8).Width = 15;
        worksheet.Column(9).Width = 15;
        worksheet.Column(10).Width = 15;
        worksheet.Column(11).Width = 35;
        worksheet.Column(12).Width = 20;

        //worksheet.Column(6).Width = 40; //MONEDA

        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"detalle_programacion.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();

    }
    protected void btninconsistencias1_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");

        CP0003PRGC consultacab = new CP0003PRGC();
        CP0003PRGD consultadet = new CP0003PRGD();
        List<vista_detalle_programacion> CABECERA = new List<vista_detalle_programacion>();
        List<CP0003PRGD> DETALLE = new List<CP0003PRGD>();
        int cont = 9;
        int CONTDOC = 0;
        decimal sumsol = 0;

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("C2").SetValue("REPORTE DE INCONSISTENCIAS").Style.Font.SetBold(true);
        worksheet.Range("H1").SetValue(DateTime.Today).Style.Font.SetBold(true);
        worksheet.Range("C2:J2").Row(1).Merge();

        CABECERA = CP0003PRGC.LISTARUNO1(txtprogramacion.Text);
        DETALLE = CP0003PRGD.LISTARTTODOS1(txtprogramacion.Text);

        foreach (vista_detalle_programacion a in CABECERA)
        {
            worksheet.Cell("A" + 3).SetValue("Agencia").Style.Font.SetBold(true);
            worksheet.Cell("A" + 4).SetValue("Programación").Style.Font.SetBold(true);
            worksheet.Cell("A" + 5).SetValue("Concepto").Style.Font.SetBold(true);
            worksheet.Cell("A" + 6).SetValue("Banco").Style.Font.SetBold(true);
            worksheet.Cell("A" + 7).SetValue("Departamento").Style.Font.SetBold(true);
            worksheet.Cell("A" + 8).SetValue("Tipo Detracción").Style.Font.SetBold(true);

            worksheet.Cell("B" + 3).Value = ("'" + a.AGENCIA + "");
            worksheet.Cell("B" + 4).Value = ("'" + txtprogramacion.Text + "");
            worksheet.Cell("B" + 5).Value = a.CONCEPTO;
            worksheet.Cell("B" + 6).Value = a.BANCO;
            worksheet.Cell("B" + 7).Value = ("'" + a.DEPARTAMENTO + "");
            worksheet.Cell("B" + 8).Value = a.TIPODETRACCION;


            worksheet.Cell("F" + 3).SetValue("Fecha").Style.Font.SetBold(true);
            worksheet.Cell("F" + 4).SetValue("Tipo Pago").Style.Font.SetBold(true);
            worksheet.Cell("F" + 5).SetValue("Importe").Style.Font.SetBold(true);
            worksheet.Cell("F" + 6).SetValue("Moneda").Style.Font.SetBold(true);
            worksheet.Cell("F" + 7).SetValue("Lote").Style.Font.SetBold(true);


            worksheet.Cell("H" + 3).Value = ("'" + a.FECRE + "").Substring(0, 11);
            worksheet.Cell("H" + 4).Value = ("'" + a.CONCEPTO + "");
            worksheet.Cell("H" + 5).Value = ("'" + a.IMPORTE + "");
            worksheet.Cell("H" + 6).Value = a.moneda;
            worksheet.Cell("H" + 7).Value = ("");

            // para el filtrado del detalle

            foreach (CP0003PRGD b in DETALLE)
            {
                cont = cont + 1;

                worksheet.Cell("A" + 9).SetValue("Proveedor").Style.Font.SetBold(true);
                worksheet.Cell("B" + 9).SetValue("Nombre").Style.Font.SetBold(true);
                worksheet.Cell("C" + 9).SetValue("TD").Style.Font.SetBold(true);
                worksheet.Cell("D" + 9).SetValue("Número").Style.Font.SetBold(true);
                worksheet.Cell("E" + 9).SetValue("Vmto").Style.Font.SetBold(true);
                worksheet.Cell("F" + 9).SetValue("Moneda").Style.Font.SetBold(true);
                worksheet.Cell("G" + 9).SetValue("Programado MN").Style.Font.SetBold(true);
                worksheet.Cell("H" + 9).SetValue("Rechazado X").Style.Font.SetBold(true);

                worksheet.Cell("A" + cont.ToString()).Value = ("" + b.GD_CVANEXO + "" + "-" + "" + b.GD_CCODIGO + "");
                worksheet.Cell("B" + cont.ToString()).Value = ("'" + b.GD_CNDREF + "");
                worksheet.Cell("C" + cont.ToString()).Value = b.GD_CTIPDOC;
                worksheet.Cell("D" + cont.ToString()).Value = b.GD_CNUMDOC;
                worksheet.Cell("E" + cont.ToString()).Value = b.GD_DFECVEN;
                worksheet.Cell("F" + cont.ToString()).Value = b.GD_CMONCAR;
                worksheet.Cell("G" + cont.ToString()).Value =("'"+ b.GD_NMNPROG + "");
                CP0003MAES ADATA = new CP0003MAES();
                ADATA.AC_CVANEXO = b.GD_CVANEXO;
                ADATA.AC_CCODIGO = b.GD_CCODIGO;

                if (CP0003MAES.INCONSISTENCIACUENTADET(ADATA).Count() <= 0)
                {
                    worksheet.Cell("H" + cont.ToString()).Value = "El Proveedor no tiene cuenta de detraccion";
                }

                CONTDOC = CONTDOC + 1;
                sumsol = sumsol + b.GD_NMNPROG;
            }


            worksheet.Column(1).Width = 20; // SOLICITUD
            worksheet.Column(2).Width = 40; //ORDEN
            worksheet.Column(3).Width = 5;
            worksheet.Column(4).Width = 10;
            worksheet.Column(5).Width = 10;
            worksheet.Column(6).Width = 10;
            worksheet.Column(8).Width = 15;
            worksheet.Column(9).Width = 15;
            worksheet.Column(10).Width = 15;
            worksheet.Column(11).Width = 35;
            worksheet.Column(12).Width = 20;

            //worksheet.Column(6).Width = 40; //MONEDA

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"Inconsistencias.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();

        }
    }
}
