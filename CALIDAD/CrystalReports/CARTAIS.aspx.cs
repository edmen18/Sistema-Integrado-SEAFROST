using CapaNegocio;
using ClosedXML.Excel;
using ENTITY;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

public partial class CALIDAD_CrystalReports_CARTAIS : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

       
        string idoc = Convert.ToString(Request.QueryString["ID"]);
        string fecha = Convert.ToString(Request.QueryString["fecha"]);
        VISTA_CARTASIS TABL = new VISTA_CARTASIS();

        TABL.NUM_CARTA = idoc.Trim();
        TABL.FECHA = Convert.ToDateTime(fecha.Trim());

        List<VISTA_CARTASIS> detalle = new List<VISTA_CARTASIS>();
        detalle = T_CALIDAD_CARTA_IS.getdatos(TABL);
        var reporte = ("CARTA001.xlsx");
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "CALIDAD\\CrystalReports\\" + reporte;//SERVIDOR AGREGAR \\
        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        foreach (VISTA_CARTASIS b in detalle)
        {
            worksheet.Range("A7").SetValue("CARTA Nº " + b.NUM_CARTA + b.complemento + " / ASEG. DE LA CALIDAD / SEAFROST SAC.").Style.Font.SetBold(true);
            worksheet.Range("D8").SetValue(b.RAZONSOCIAL).Style.Font.SetBold(true);
            worksheet.Range("D9").SetValue(b.DE).Style.Font.SetBold(true);
            worksheet.Range("H5").SetValue(b.ORDEN_TRABAJO).Style.Font.SetBold(true);
            worksheet.Range("D10").SetValue(b.FECHA_E).Style.Font.SetBold(true);
            worksheet.Range("D13").SetValue(b.TA_DESCRIPCION).Style.Font.SetBold(true);
            worksheet.Range("D14").SetValue(b.TC_DESCRIPCION).Style.Font.SetBold(true);
            worksheet.Range("D15").SetValue(b.PRODUCTOR + "/" + b.HABILITACION).Style.Font.SetBold(true);
            worksheet.Range("D16").SetValue(b.PR_DESCRIPCION).Style.Font.SetBold(true);
            worksheet.Range("D17").SetValue(b.ENV_DESCRIPCION).Style.Font.SetBold(true);
            worksheet.Range("D18").SetValue(b.LOTES).Style.Font.SetBold(true);
            worksheet.Range("D18").SetValue(b.LOTES).Style.Alignment.Horizontal=XLAlignmentHorizontalValues.Justify;
            worksheet.Range("D19").SetValue(b.ESPECIFICACION_INTERNA).Style.Font.SetBold(true);
            worksheet.Range("D20").SetValue(b.DST_DESCRIPCION).Style.Font.SetBold(true);
            worksheet.Range("D21").SetValue(b.LUGAR).Style.Font.SetBold(true);
            worksheet.Range("D22").SetValue(b.FECHA_I).Style.Font.SetBold(true);
            worksheet.Range("D23").SetValue(b.CC).Style.Font.SetBold(true);
         
        }
        var pass = worksheet.Protect("Log2016");
        pass.SelectLockedCells = false;
        pass.SelectUnlockedCells = false;
        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"Demo.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();

    }
}