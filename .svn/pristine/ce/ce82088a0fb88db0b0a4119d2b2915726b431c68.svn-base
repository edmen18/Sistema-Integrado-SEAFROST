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
        if (!this.IsPostBack)
        {
            //// centro de costo
            //AL0003TABL TABL = new AL0003TABL();
            //TABL.TG_CCOD = "10";
            //TABL.TG_CDESCRI = string.Empty;
            //ddlccosto.Items.Clear();
            //ddlccosto.DataTextField = "TG_CDESCRI";
            //ddlccosto.DataValueField = "TG_CCLAVE";
            //ddlccosto.DataSource = AL0003TABL.ListarTablaS(TABL);
            //ddlccosto.DataBind();
            //ddlccosto.Items.Insert(0, new ListItem("[CENCOSTO]", "-1"));


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
            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }




    protected void btnbuscar_Click(object sender, EventArgs e)
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
      //  worksheet.Range("C4").SetValue("INFORME DE TRABAJOS DE MANTENIMIENTO PROGRAMADOS A LA FECHA " + this.txtfecha2.Text).Style.Font.SetBold(true);
        worksheet.Range("C4:F4").Row(1).Merge();
        worksheet.Range("F1").SetValue(DateTime.Now).Style.Font.SetBold(true);
        worksheet.Range("F1:G1").Row(1).Merge();

        worksheet.Range("A6").SetValue("TAREA").Style.Font.SetBold(true);
        worksheet.Range("A6").SetValue("TAREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("B6").SetValue("FECHA").Style.Font.SetBold(true);
        worksheet.Range("B6").SetValue("FECHA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("C6").SetValue("AREA").Style.Font.SetBold(true);
        worksheet.Range("C6").SetValue("AREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("D6").SetValue("EQUIPO").Style.Font.SetBold(true);
        worksheet.Range("D6").SetValue("EQUIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("E6").SetValue("DESCRIPCIÓN").Style.Font.SetBold(true);
        worksheet.Range("E6").SetValue("DESCRIPCIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("F6").SetValue("PLANTA").Style.Font.SetBold(true);
        worksheet.Range("F6").SetValue("PLANTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("G6").SetValue("CONTRATISTA").Style.Font.SetBold(true);
        worksheet.Range("G6").SetValue("CONTRATISTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("H6").SetValue("REQ").Style.Font.SetBold(true);
        worksheet.Range("H6").SetValue("REQ").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("I6").SetValue("ORDENES").Style.Font.SetBold(true);
        worksheet.Range("I6").SetValue("ORDENES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("J6").SetValue("CENTRO COSTO").Style.Font.SetBold(true);
        worksheet.Range("J6").SetValue("CENTRO COSTO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("K6").SetValue("CONTROL ACTIVOS").Style.Font.SetBold(true);
        worksheet.Range("K6").SetValue("CONTROL ACTIVOS").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("L6").SetValue("ACUMULADO").Style.Font.SetBold(true);
        worksheet.Range("L6").SetValue("ACUMULADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("M6").SetValue("OBSERVACIONES").Style.Font.SetBold(true);
        worksheet.Range("M6").SetValue("OBSERVACIONES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        vista = tabla_trabajo.ReporteAvances(trabajo);

        var detalleRQ = "";
        var detalleOC = "";

        foreach (VISTA_TRABAJO b in vista)
        {
            if (ddlsituacion.Text=="T")
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.FECHA + "");
            worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
            worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
            worksheet.Cell("E" + cont2.ToString()).Value = b.DESCRIPCION;
            worksheet.Cell("F" + cont2.ToString()).Value = b.PL_DESCRIPCION;
            worksheet.Cell("G" + cont2.ToString()).Value = b.CONTRATISTA;
            worksheet.Cell("J" + cont2.ToString()).Value = b.CENTRO_COSTO;
            worksheet.Cell("K" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
            worksheet.Cell("L" + cont2.ToString()).Value = b.acumulado + "%";
            //establecemos rangos 
            if (b.acumulado >= 0 && b.acumulado <= 10)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
            }
            if (b.acumulado >= 11 && b.acumulado <= 20)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LemonChiffon;
            }
            if (b.acumulado >= 21 && b.acumulado <= 30)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Khaki;
            }
            if (b.acumulado >= 31 && b.acumulado <= 40)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Yellow;
            }
            if (b.acumulado >= 41 && b.acumulado <= 50)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Gold;
            }
            if (b.acumulado >= 51 && b.acumulado <= 60)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.GreenYellow;
            }
            if (b.acumulado >= 61 && b.acumulado <= 70)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.YellowGreen;
            }
            if (b.acumulado >= 71 && b.acumulado <= 80)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.ForestGreen;
            }
            if (b.acumulado >= 81 && b.acumulado <= 90)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Green;
            }
            if (b.acumulado >= 91 && b.acumulado <= 100)
            {
                worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.DarkGreen;
            }

            worksheet.Cell("M" + cont2.ToString()).Value = b.OBSERVACIONES;
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

                        worksheet.Cell("H" + cont2.ToString()).Value = detalleRQ;
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

                        worksheet.Cell("I" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }

            if ((ddlsituacion.Text == "P") && (b.acumulado<100) )
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS PENDIENTES DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.FECHA + "");
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
                worksheet.Cell("E" + cont2.ToString()).Value = b.DESCRIPCION;
                worksheet.Cell("F" + cont2.ToString()).Value = b.PL_DESCRIPCION;
                worksheet.Cell("G" + cont2.ToString()).Value = b.CONTRATISTA;
                worksheet.Cell("J" + cont2.ToString()).Value = b.CENTRO_COSTO;
                worksheet.Cell("K" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
                worksheet.Cell("L" + cont2.ToString()).Value = b.acumulado + "%";
                //establecemos rangos 
                if (b.acumulado >= 0 && b.acumulado <= 10)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
                }
                if (b.acumulado >= 11 && b.acumulado <= 20)
                {
                    worksheet.Range("" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LemonChiffon;
                }
                if (b.acumulado >= 21 && b.acumulado <= 30)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Khaki;
                }
                if (b.acumulado >= 31 && b.acumulado <= 40)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Yellow;
                }
                if (b.acumulado >= 41 && b.acumulado <= 50)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Gold;
                }
                if (b.acumulado >= 51 && b.acumulado <= 60)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                }
                if (b.acumulado >= 61 && b.acumulado <= 70)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.YellowGreen;
                }
                if (b.acumulado >= 71 && b.acumulado <= 80)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.ForestGreen;
                }
                if (b.acumulado >= 81 && b.acumulado <= 90)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Green;
                }
                if (b.acumulado >= 91 && b.acumulado <= 100)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.DarkGreen;
                }

                worksheet.Cell("M" + cont2.ToString()).Value = b.OBSERVACIONES;
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

                        worksheet.Cell("H" + cont2.ToString()).Value = detalleRQ;
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

                        worksheet.Cell("I" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }

            if ((ddlsituacion.Text == "C") && (b.acumulado==100))
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS CULMINADOS DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.FECHA + "");
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
                worksheet.Cell("E" + cont2.ToString()).Value = b.DESCRIPCION;
                worksheet.Cell("F" + cont2.ToString()).Value = b.PL_DESCRIPCION;
                worksheet.Cell("G" + cont2.ToString()).Value = b.CONTRATISTA;
                worksheet.Cell("J" + cont2.ToString()).Value = b.CENTRO_COSTO;
                worksheet.Cell("K" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
                worksheet.Cell("L" + cont2.ToString()).Value = b.acumulado + "%";
                //establecemos rangos 
                if (b.acumulado >= 0 && b.acumulado <= 10)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LightGoldenrodYellow;
                }
                if (b.acumulado >= 11 && b.acumulado <= 20)
                {
                    worksheet.Range("" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.LemonChiffon;
                }
                if (b.acumulado >= 21 && b.acumulado <= 30)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Khaki;
                }
                if (b.acumulado >= 31 && b.acumulado <= 40)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Yellow;
                }
                if (b.acumulado >= 41 && b.acumulado <= 50)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Gold;
                }
                if (b.acumulado >= 51 && b.acumulado <= 60)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.GreenYellow;
                }
                if (b.acumulado >= 61 && b.acumulado <= 70)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.YellowGreen;
                }
                if (b.acumulado >= 71 && b.acumulado <= 80)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.ForestGreen;
                }
                if (b.acumulado >= 81 && b.acumulado <= 90)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.Green;
                }
                if (b.acumulado >= 91 && b.acumulado <= 100)
                {
                    worksheet.Range("L" + cont2.ToString()).Style.Fill.BackgroundColor = XLColor.DarkGreen;
                }

                worksheet.Cell("M" + cont2.ToString()).Value = b.OBSERVACIONES;
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

                        worksheet.Cell("H" + cont2.ToString()).Value = detalleRQ;
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

                        worksheet.Cell("I" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }
            worksheet.Column(1).Width = 10;
            worksheet.Column(2).Width = 10;
            worksheet.Column(3).Width = 30;
            worksheet.Column(4).Width = 50;
            worksheet.Column(5).Width = 40;
            worksheet.Column(6).Width = 30;
            worksheet.Column(7).Width = 40;
            worksheet.Column(8).Width = 60;
            worksheet.Column(9).Width = 25;
            worksheet.Column(10).Width = 40;
            worksheet.Column(11).Width = 20;
            worksheet.Column(12).Width = 15;
            worksheet.Column(13).Width = 30;
            //////////////// 
        }
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