using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;//agrega
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
//using CapaNegocio;
using ENTITY;
using System.Configuration;
public partial class Embarcaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            ListaEmbarcacion();
           
            LISTAR();
        }
        lblusuario.Text = Convert.ToString(Session["codusu"]);
    }

    public void ListaEmbarcacion()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("E_MATRIC");
        dtGetDatae.Columns.Add("E_NOMBRE");
        dtGetDatae.Columns.Add("E_RESOLU");
        dtGetDatae.Columns.Add("E_PERPES");
        dtGetDatae.Columns.Add("E_PERZAR");
        dtGetDatae.Columns.Add("E_ESPCHD");
        dtGetDatae.Columns.Add("E_CABOM3");
        dtGetDatae.Columns.Add("E_CABOTM");
        dtGetDatae.Columns.Add("E_ESTADO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    public static List<tabla_embarcaciones> LISTARDATOSPARAM(tabla_embarcaciones com)
    {
        return tabla_embarcaciones.ListarEmbarcacionParametros(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_embarcaciones> LISTARDATOSAUTOCOMPLETE(string com)
    {
        return tabla_embarcaciones.ListarEmbarcacionAut(com);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_embarcaciones> LISTARDATOS()
    {
        return tabla_embarcaciones.ListarEmbarcacionestodos();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_embarcaciones DETA)
    {
        tabla_embarcaciones.actualizaBahia(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertar(tabla_embarcaciones DETA)
    {
        tabla_embarcaciones.insertaBahia(DETA);
        LISTARDATOS();
    }
    public void LISTAR()
    {
        gvordencompra.DataSource = tabla_embarcaciones.ListarEmbarcacionestodos();
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }

    }

    protected void btbuscar_Click(object sender, EventArgs e)
    {
        tabla_embarcaciones var = new tabla_embarcaciones();
        var.E_MATRIC = this.txtidbahia.Text;
        gvordencompra.DataSource = tabla_embarcaciones.ListarEmbarcacionParametros(var);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
        this.txtbahia.Text = "";
        this.txtidbahia.Text = "";

    }

    protected void btexcel_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        int cont2 = 7;
        tabla_embarcaciones embarcaciones = new tabla_embarcaciones();

        List<tabla_embarcaciones> vista = new List<tabla_embarcaciones>();
        //.Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("Reporte de Embarcaciones Registradas").Style.Font.SetBold(true);
        worksheet.Range("C4:F4").Row(1).Merge();
        worksheet.Range("F1").SetValue(DateTime.Now).Style.Font.SetBold(true);
        worksheet.Range("F1:H1").Row(1).Merge();

        worksheet.Range("A6").SetValue("MATRICULA").Style.Font.SetBold(true);
        worksheet.Range("A6").SetValue("MATRICULA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("B6").SetValue("NOMBRE").Style.Font.SetBold(true);
        worksheet.Range("B6").SetValue("NOMBRE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("C6").SetValue("RESOLUCIÓN Nº").Style.Font.SetBold(true);
        worksheet.Range("C6").SetValue("RESOLUCIÓN Nº").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("D6").SetValue("PERMISO PESCA").Style.Font.SetBold(true);
        worksheet.Range("D6").SetValue("PERMISO PESCA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("E6").SetValue("PERMISO ZARPE").Style.Font.SetBold(true);
        worksheet.Range("E6").SetValue("PERMISO ZARPE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("F6").SetValue("CAP. BODEGA M3").Style.Font.SetBold(true);
        worksheet.Range("F6").SetValue("CAP. BODEGA M3").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("G6").SetValue("CAP. BODEGA TM").Style.Font.SetBold(true);
        worksheet.Range("G6").SetValue("CAP. BODEGA TM").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("H6").SetValue("ESTPECIE").Style.Font.SetBold(true);
        worksheet.Range("H6").SetValue("ESTPECIE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        vista = tabla_embarcaciones.ListarEmbarcacionestodos();
            
            foreach (tabla_embarcaciones b in vista)
            {                
                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.E_MATRIC + "");
                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.E_NOMBRE + "");
                    worksheet.Cell("C" + cont2.ToString()).Value = b.E_RESOLU;
                    worksheet.Cell("D" + cont2.ToString()).Value = b.E_PERPES;
                    worksheet.Cell("E" + cont2.ToString()).Value = b.E_PERZAR;
                    worksheet.Cell("F" + cont2.ToString()).Value = b.E_CABOM3;
                    worksheet.Cell("G" + cont2.ToString()).Value = b.E_CABOTM;
                    worksheet.Cell("H" + cont2.ToString()).Value = b.E_ESPCHD;
                    cont2++;    
            }
        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"Embarcaciones.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }   
}

