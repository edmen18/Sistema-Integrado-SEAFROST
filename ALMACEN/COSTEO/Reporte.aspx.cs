using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;
using ClosedXML.Excel;
/* using System.Data.DataSetExtensions;*/

public partial class ALMACEN_Reportes_Reporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Fc = Convert.ToString(Request.QueryString["Fc"]);

        Fc = Fc.Trim();
        
        List<AL0003MOVD> detalle = new List<AL0003MOVD>();

        var reporte = "Prueba.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        //micabecera(worksheet,1,idND);
        detalle = AL0003MOVD.DetalleNovalorizado(Fc).ToList();
        
        //CABECERA 1:
        worksheet.Range("A1:B1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A1:B1").Style.Font.FontSize = 8;
        worksheet.Range("A1:B1").SetValue("DOCUMENTOS SIN VALORIZAR:")
        .Merge()
        .Style.Font.SetBold(true);

        //DETALLE
        int cont = 4;
        midetalle(worksheet, 3);
        foreach (AL0003MOVD p in detalle)
        {

            worksheet.Range("A" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + cont.ToString()).SetValue(p.C6_CALMA);

            worksheet.Range("B" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("B" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("B" + cont.ToString()).SetValue(p.C6_CTD);

            worksheet.Range("C" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("C" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("C" + cont.ToString()).SetValue(p.C6_CCODMOV);
                
            worksheet.Range("D" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("D" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("D" + cont.ToString()).SetValue(p.C6_CNUMDOC);

            worksheet.Range("E" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("E" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("E" + cont.ToString()).SetValue(p.C6_CITEM);

            worksheet.Range("F" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("F" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("F" + cont.ToString()).SetValue(p.C6_CCODIGO);

            worksheet.Range("G" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("G" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("G" + cont.ToString()).SetValue(p.C6_DFECDOC);

            worksheet.Range("H" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("H" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("H" + cont.ToString()).SetValue(p.C6_NCANTID)
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                .NumberFormat.Format = "###,##0.00"; 

            cont++;
            
        }
        
        worksheet.Rows().AdjustToContents();
        
        // Adding print areas
        //worksheet.PageSetup.PrintAreas.Add("A1:X" + co.ToString());

        //PROTEGE
        //var pass = worksheet.Protect("SEA2016");
        //pass.SelectLockedCells = false;
        //pass.SelectUnlockedCells = false;

        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"DocSinValorizar.xlsx\"");


        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }

   

    public void midetalle(IXLWorksheet worksheet, int fila)
    {   //fila3
        worksheet.Range("A" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("A" + fila.ToString()).SetValue("ALMACEN")
            .Style.Font.SetBold(true);

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("TIPO IS")
            .Style.Font.SetBold(true);

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("COD MOV")
            .Style.Font.SetBold(true);

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("NUMERO DOCUMENTO")
            .Style.Font.SetBold(true);
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("ITEM")
            .Style.Font.SetBold(true);

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("CODIGO PRODUCTO")
            .Style.Font.SetBold(true);

        worksheet.Range("G" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString()).SetValue("FECHA")
            .Style.Font.SetBold(true);

        worksheet.Range("H" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString()).SetValue("CANTIDAD")
            .Style.Font.SetBold(true);

    }
}