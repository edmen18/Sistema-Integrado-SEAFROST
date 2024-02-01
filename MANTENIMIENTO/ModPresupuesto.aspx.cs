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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        lblusuario.Text = Convert.ToString(Session["codusu"]);
        ACCESO();
        if (!this.IsPostBack)
        {
            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

            // area
            tabla_area area = new tabla_area();
            area.AE_DESC = string.Empty;
            ddlarea.Items.Clear();
            ddlarea.DataTextField = "SA_DESC";
            ddlarea.DataValueField = "SA_ID";
            ddlarea.DataSource = tabla_subareas.Listarsubareas();
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("[AREAS]", "-1"));


            // PLANTA
            tabla_planta PLANTA = new tabla_planta();
            PLANTA.PL_DESCRIPCION = string.Empty;
            ddlplanta.Items.Clear();
            ddlplanta.DataTextField = "PL_DESCRIPCION";
            ddlplanta.DataValueField = "PL_CODIGO";
            ddlplanta.DataSource = tabla_planta.ListarPLANTA();
            ddlplanta.DataBind();
            ddlplanta.Items.Insert(0, new ListItem("[PLANTAS]", "-1"));



            // EQUIPO
            tabla_equipo equipo = new tabla_equipo();
            equipo.EQ_DESCRIPCION = string.Empty;
            ddlequipo.Items.Clear();
            ddlequipo.DataTextField = "EQ_DESCRIPCION";
            ddlequipo.DataValueField = "EQ_CODIGO";
            ddlequipo.DataSource = tabla_equipo.ListarEquipos();
            ddlequipo.DataBind();
            ddlequipo.Items.Insert(0, new ListItem("[EQUIPOS]", "-1"));
            VERGRILLA();
        }

    }
    public void ACCESO()
    {
        int contador = tabla_permiso_presupuesto.CuentaAccesoADoc(lblusuario.Text);

        if (contador > 0)
        {

            lblacceso.Text = Convert.ToString(contador);
        }
        else
        {
            lblacceso.Text = "0";
        }

    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("TR_CODIGO");
        dtGetDatae.Columns.Add("FECH");
        dtGetDatae.Columns.Add("AE_DESC");
        dtGetDatae.Columns.Add("EQ_DESCRIPCION");
        dtGetDatae.Columns.Add("PL_DESCRIPCION");
        dtGetDatae.Columns.Add("CONTRATISTA");
        dtGetDatae.Columns.Add("CENTRO_COSTO");
        dtGetDatae.Columns.Add("DESCRIPCION");
        dtGetDatae.Columns.Add("CONTROL_ACTIVOS");
        dtGetDatae.Columns.Add("ACUMULADO");
        dtGetDatae.Columns.Add("ADICIONAL");
        dtGetDatae.Columns.Add("TOTAL");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR()
    {
        return tabla_modpresupuesto.GenerarCodigo();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string contaremitidas(string dato)
    {
        return tabla_modpresupuesto.EMITIDAS(dato);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_trabajo DETA)
    {
        tabla_trabajo.ActPresupuesto(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarModificacion(tabla_modpresupuesto DETA)
    {
        tabla_modpresupuesto.inserta(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TRABAJO> traerdatos(tabla_trabajo VC)
    {
        return tabla_trabajo.ConsultaUno(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETALLE_TRABAJOCURSO> SUMATORIA(tabla_trabajo VC)
    {
        return tabla_trabajo.SUMDETALLE(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_avances> ListarDetalle(tabla_avances VC)
    {
        return tabla_avances.Impresion(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TRABAJO> Listarcabecera(VISTA_TRABAJO VC)
    {
        return tabla_trabajo.ListarTrabajosAvances1(VC);
    }

    //protected void btnbuscar_Click(object sender, EventArgs e)
    //{
    //    //if ((Convert.ToString(txtfecha1.Text).Equals("")) || (Convert.ToString(txtfecha2.Text).Equals("")))
    //    //{
    //    //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar un Rango de fechas"), false);
    //    //}
    //    //else
    //    {
    //        VISTA_TRABAJO var = new VISTA_TRABAJO();
    //        var.AE_COD = Convert.ToInt32(ddlarea.Text);
    //        var.PL_CODIGO = ddlplanta.Text;
    //        var.EQ_CODIGO = ddlequipo.Text;
    //        if (this.txtcodcencosto0.Text == "")
    //        {
    //            var.COD_CENCOS = "-1";
    //        }
    //        else
    //        {
    //            var.COD_CENCOS = this.txtcodcencosto0.Text;
    //        }
    //        if (txtfecha1.Text == "")
    //        {
    //            var.FECHA = Convert.ToDateTime("01/05/2016");
    //        }
    //        else
    //        {
    //            var.FECHA = Convert.ToDateTime(txtfecha1.Text);
    //        }
    //        if (txtfecha2.Text == "")
    //        {
    //            var.FECHAFIN = DateTime.Today;
    //        }
    //        else
    //        {
    //            var.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
    //        }
    //        gvordencompra.DataSource = tabla_trabajo.ListarTrabajosAvances(var);
    //        gvordencompra.DataBind();

    //        if (gvordencompra.Rows.Count > 0)
    //        {
    //            gvordencompra.UseAccessibleHeader = true;
    //            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
    //        }
    //    }
    //}
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(tabla_avances DETA)
    {
        tabla_avances.inserta(DETA);
    }

    //[System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod()]
    //public static void ActualizaAnticipo(tabla_avances DETA)
    //{
    //    tabla_avances.actualiza(DETA);
    //}

    protected void btnexcel_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        int cont2 = 7;
        VISTA_TRABAJO trabajo = new VISTA_TRABAJO();
        trabajo.AE_COD = Convert.ToInt32(ddlarea.Text);
        trabajo.PL_CODIGO = ddlplanta.Text;
        trabajo.EQ_CODIGO = ddlequipo.Text;
        if (this.txtcodcencosto0.Text == "")
        {
            trabajo.COD_CENCOS = "-1";
        }
        else
        {
            trabajo.COD_CENCOS = this.txtcodcencosto0.Text;
        }
        if (txtfecha1.Text == "")
        {
            trabajo.FECHA = Convert.ToDateTime("01/05/2016");
        }
        else
        {
            trabajo.FECHA = Convert.ToDateTime(txtfecha1.Text);
        }
        if (txtfecha2.Text == "")
        {
            trabajo.FECHAFIN = DateTime.Today;
        }
        else
        {
            trabajo.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
        }
        tabla_trabajo trabajodet = new tabla_trabajo();
        List<VISTA_TRABAJO> vista = new List<VISTA_TRABAJO>();
        List<VISTA_DETALLE_TRABAJOCURSO> vistadet = new List<VISTA_DETALLE_TRABAJOCURSO>();


        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("INFORME DE TRABAJOS DE MANTENIMIENTO PROGRAMADOS A LA FECHA " + this.txtfecha2.Text).Style.Font.SetBold(true);
        worksheet.Range("C4:F4").Row(1).Merge();
        worksheet.Range("F1").SetValue(DateTime.Now).Style.Font.SetBold(true);
        worksheet.Range("F1:G1").Row(1).Merge();

        worksheet.Range("A6").SetValue("TAREA").Style.Font.SetBold(true);
        worksheet.Range("A6").SetValue("TAREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("B6").SetValue("AREA").Style.Font.SetBold(true);
        worksheet.Range("B6").SetValue("AREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("C6").SetValue("EQUIPO").Style.Font.SetBold(true);
        worksheet.Range("C6").SetValue("EQUIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("D6").SetValue("DESCRIPCIÓN").Style.Font.SetBold(true);
        worksheet.Range("D6").SetValue("DESCRIPCIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("E6").SetValue("PLANTA").Style.Font.SetBold(true);
        worksheet.Range("E6").SetValue("PLANTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("F6").SetValue("CONTRATISTA").Style.Font.SetBold(true);
        worksheet.Range("F6").SetValue("CONTRATISTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("G6").SetValue("REQ").Style.Font.SetBold(true);
        worksheet.Range("G6").SetValue("REQ").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("H6").SetValue("ORDENES").Style.Font.SetBold(true);
        worksheet.Range("H6").SetValue("ORDENES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        worksheet.Range("I6").SetValue("CENTRO COSTO").Style.Font.SetBold(true);
        worksheet.Range("I6").SetValue("CENTRO COSTO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("J6").SetValue("CONTROL ACTIVOS").Style.Font.SetBold(true);
        worksheet.Range("J6").SetValue("CONTROL ACTIVOS").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("K6").SetValue("ACUMULADO").Style.Font.SetBold(true);
        worksheet.Range("K6").SetValue("ACUMULADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("L6").SetValue("OBSERVACIONES").Style.Font.SetBold(true);
        worksheet.Range("L6").SetValue("OBSERVACIONES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        vista = tabla_trabajo.ReporteAvances(trabajo);

        var detalleRQ = "";
        var detalleOC = "";

        foreach (VISTA_TRABAJO b in vista)
        {
            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
            worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
            worksheet.Cell("D" + cont2.ToString()).Value = b.DESCRIPCION;
            worksheet.Cell("E" + cont2.ToString()).Value = b.PL_DESCRIPCION;
            worksheet.Cell("F" + cont2.ToString()).Value = b.CONTRATISTA;
            worksheet.Cell("I" + cont2.ToString()).Value = b.CENTRO_COSTO;
            worksheet.Cell("J" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
            worksheet.Cell("K" + cont2.ToString()).Value = b.acumulado + "%";
            //establecemos rangos 
            if (b.acumulado >= 0 && b.acumulado <= 10)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
            }
            if (b.acumulado >= 11 && b.acumulado <= 20)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LemonChiffon;
            }
            if (b.acumulado >= 21 && b.acumulado <= 30)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Khaki;
            }
            if (b.acumulado >= 31 && b.acumulado <= 40)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Yellow;
            }
            if (b.acumulado >= 41 && b.acumulado <= 50)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Gold;
            }
            if (b.acumulado >= 51 && b.acumulado <= 60)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.GreenYellow;
            }
            if (b.acumulado >= 61 && b.acumulado <= 70)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.YellowGreen;
            }
            if (b.acumulado >= 71 && b.acumulado <= 80)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.ForestGreen;
            }
            if (b.acumulado >= 81 && b.acumulado <= 90)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Green;
            }
            if (b.acumulado >= 91 && b.acumulado <= 100)
            {
                worksheet.Range("K" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.DarkGreen;
            }

            worksheet.Cell("L" + cont2.ToString()).Value = b.OBSERVACIONES;
            trabajodet.TR_CODIGO = b.TR_CODIGO;
            vistadet = tabla_detalle.DETALLE(trabajodet);
            foreach (VISTA_DETALLE_TRABAJOCURSO c in vistadet)
            {
                if (c.DOCUMENTO == "REQUERIMIENTO")
                {
                    if (detalleRQ == "")
                    {
                        detalleRQ = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                    }
                    else
                    {
                        detalleRQ = detalleRQ + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                    }

                    worksheet.Cell("G" + cont2.ToString()).Value = detalleRQ;
                }
                if (c.DOCUMENTO == "ORDEN SERVICIO")
                {
                    if (detalleOC == "")
                    {
                        detalleOC = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                    }
                    else
                    {
                        detalleOC = detalleOC + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                    }

                    worksheet.Cell("H" + cont2.ToString()).Value = detalleOC;
                }
            }
            cont2++;
            detalleRQ = "";
            detalleOC = "";
        }

        worksheet.Column(1).Width = 10;
        worksheet.Column(2).Width = 30;
        worksheet.Column(3).Width = 50;
        worksheet.Column(4).Width = 50;
        worksheet.Column(5).Width = 30;
        worksheet.Column(6).Width = 30;
        worksheet.Column(7).Width = 40;
        worksheet.Column(8).Width = 60;
        worksheet.Column(9).Width = 25;
        worksheet.Column(10).Width = 20;
        worksheet.Column(11).Width = 15;
        worksheet.Column(12).Width = 20;
      
        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"ReporteAvances.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }

   
    
}
