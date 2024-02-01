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
        //string Fc = Convert.ToString(Request.QueryString["ES"]);
        string estado = Convert.ToString(Request.QueryString["ES"]);

        estado = estado.Trim();
        
        List<VISTA_PEDIDOS1612> detalle = new List<VISTA_PEDIDOS1612>();

        var reporte = "ReporteG.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\COMERCIAL\\REPORTES\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);

        //micabecera(worksheet,1,idND);
        //detalle = AL0003MOVD.DetalleNovalorizado(Fc).ToList();
        detalle = VISTA_PEDIDOS1612.F_ListarPedido(estado);

        //CABECERA 1:
        worksheet.Range("A1:J1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A1:J1").Style.Font.FontSize = 8;
        worksheet.Range("A1:J1").SetValue("LISTA DE PEDIDOS:"+ (estado=="P" ? "PENDIENTES" :"APROBADOS"))
        .Merge()
        .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Font.SetBold(true)
        ;

        //DETALLE
        int cont = 4,contf=1;
        midetalle(worksheet, 3);
        foreach (VISTA_PEDIDOS1612 p in detalle)
        {

            worksheet.Range("A" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + cont.ToString()).SetValue(contf);

            worksheet.Range("B" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("B" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("B" + cont.ToString()).SetValue(p.F5_CNUMPED);

            worksheet.Range("C" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("C" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("C" + cont.ToString()).SetValue(p.F5_DFECDOC);
                
            worksheet.Range("D" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("D" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("D" + cont.ToString()).SetValue(p.F5_CNOMBRE.ToUpper());

            worksheet.Range("E" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("E" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("E" + cont.ToString()).SetValue(p.FV_CDESCRI);

            worksheet.Range("F" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("F" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("F" + cont.ToString()).SetValue(p.F5_CCODMON);

            worksheet.Range("G" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("G" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("G" + cont.ToString()).SetValue(p.F5_NIMPORT)
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right) 
            .NumberFormat.Format = "###,##0.00";

            worksheet.Range("H" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("H" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("H" + cont.ToString()).SetValue(p.TG_CDESCRI)
            ;

            worksheet.Range("I" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("I" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("I" + cont.ToString()).SetValue(p.XEMBARC)
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                .NumberFormat.Format = "###,##0.00";

            worksheet.Range("J" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("J" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("J" + cont.ToString()).SetValue(p.F5_CALMA == "0002"?"CONGELADO": p.F5_CALMA == "0003"?"CONSERVA":"HARINA")
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

            cont++;
            contf++;
        }
        
        worksheet.Columns().AdjustToContents();
        
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
        worksheet.Range("A" + fila.ToString()).SetValue("N°")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("N° PEDIDO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("FECHA DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("CLIENTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("FORMA VTA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("MONEDA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("G" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString()).SetValue("IMPORTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("H" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString()).SetValue("ESTADO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("I" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + fila.ToString()).SetValue("ATENCION")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("J" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + fila.ToString()).SetValue("AREA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

    }
}