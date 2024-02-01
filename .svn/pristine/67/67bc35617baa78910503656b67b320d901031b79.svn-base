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

public partial class Bahias : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            
        }
        ListaBahia();
        lblusuario.Text = Convert.ToString(Session["codusu"]);

    }
      public void ListaBahia()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ID");
        dtGetDatae.Columns.Add("B_NOMBRES");
        dtGetDatae.Columns.Add("B_APELLIDOS");
        dtGetDatae.Columns.Add("B_TEL_CONTACTO");
        dtGetDatae.Columns.Add("B_CEL_CONTACTO");
        dtGetDatae.Columns.Add("B_GLOSA1");
        dtGetDatae.Columns.Add("B_GLOSA2");
        dtGetDatae.Columns.Add("B_ESTADO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string obtieneBahia(string KEY)
    {
        return tabla_bahias.obtieneBahia(KEY);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_bahias> LISTARDATOSPARAM(tabla_bahias com)
    {
        return tabla_bahias.ListarBahiasparam(com);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_bahias> LISTARDATOSAUTOCOMPLETE(string com)
    {
        return tabla_bahias.ListarBahiasautocomplete(com);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<tabla_bahias> LISTARDATOS()
    {
        return tabla_bahias.ListarBahias();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_bahias DETA)
    {
        tabla_bahias.actualizaBahia(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void Insertar(tabla_bahias DETA)
    {
        tabla_bahias.insertaBahia(DETA);
    }
    protected void btexcel_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        int cont2 = 7;
        tabla_bahias BAHIA = new tabla_bahias();

        List<tabla_bahias> vista = new List<tabla_bahias>();
       

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("Reporte de Bahías Registrados").Style.Font.SetBold(true);
        worksheet.Range("C4:F4").Row(1).Merge();
        worksheet.Range("F1").SetValue(DateTime.Now).Style.Font.SetBold(true);
        worksheet.Range("F1:G1").Row(1).Merge();

        worksheet.Range("A6").SetValue("D.N.I.").Style.Font.SetBold(true);
        worksheet.Range("A6").SetValue("D.N.I.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("B6").SetValue("NOMBRES").Style.Font.SetBold(true);
        worksheet.Range("B6").SetValue("NOMBRES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("C6").SetValue("APELLIDOS").Style.Font.SetBold(true);
        worksheet.Range("C6").SetValue("APELLIDOS").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("D6").SetValue("GLOSA1").Style.Font.SetBold(true);
        worksheet.Range("D6").SetValue("GLOSA1").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("E6").SetValue("GLOSA2").Style.Font.SetBold(true);
        worksheet.Range("E6").SetValue("GLOSA2").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("F6").SetValue("TELEFONO").Style.Font.SetBold(true);
        worksheet.Range("F6").SetValue("TELEFONO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("G6").SetValue("CELULAR").Style.Font.SetBold(true);
        worksheet.Range("G6").SetValue("CELULAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("H6").SetValue("ESTADO").Style.Font.SetBold(true);
        worksheet.Range("H6").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        vista = tabla_bahias.ListarBahias();

        foreach (tabla_bahias b in vista)
        {
            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ID + "");
            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.B_NOMBRES + "");
            worksheet.Cell("C" + cont2.ToString()).Value = b.B_APELLIDOS;
            worksheet.Cell("D" + cont2.ToString()).Value = b.B_GLOSA1;
            worksheet.Cell("E" + cont2.ToString()).Value = b.B_GLOSA2;
            worksheet.Cell("F" + cont2.ToString()).Value = b.B_TEL_CONTACTO;
            worksheet.Cell("G" + cont2.ToString()).Value = b.B_CEL_CONTACTO;
            if (b.B_ESTADO.Trim()=="A")
            {
                worksheet.Cell("H" + cont2.ToString()).Value ="ACTIVO";
            }
            else
            {
                worksheet.Cell("H" + cont2.ToString()).Value = "INACTIVO";
            }
           
            cont2++;
        }
        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"BAHIAS.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
}

