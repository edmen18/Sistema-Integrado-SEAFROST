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
        string estado = Convert.ToString(Request.QueryString["et"]);
        string fimpresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        int ncolumnas = 0;

        var reporte = "Tarifario.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "ARTICULO\\REPORTES\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);

        List<AL0003ARTI> codir = new List<AL0003ARTI>();

        codir = AL0003ARTI.Tarifario(estado);

        //CABECERA 1:
        worksheet.Range("A1:B1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A1:B1").Style.Font.FontSize = 8;
        worksheet.Range("A1:B1").SetValue("SEAFROST SAC")
        .Merge()
        .Style.Font.SetBold(true);


        worksheet.Range("H1:I1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H1:I1").Style.Font.FontSize = 8;
        worksheet.Range("H1:I1").SetValue(fimpresion)
        .Merge()
        .Style.Font.SetBold(true)
        ;

        worksheet.Range("B2:H2").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B2:H2").Style.Font.FontSize = 8;
        worksheet.Range("B2:H2").SetValue("REPORTE TARIFARIO")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Range("B3:H3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B3:H3").Style.Font.FontSize = 8;
        worksheet.Range("B3:H3").SetValue("SERVICIOS")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Range("B4:H4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B4:H4").Style.Font.FontSize = 8;
        worksheet.Range("B4:H4").SetValue(estado == "S"?"DESAPROBADOS": estado=="T"?"TODOS":"APROBADOS")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //DETALLE
        decimal[] sumaxcolumna = new decimal[ncolumnas];
        //decimal sumaxcolfil = 0;
        int cont = 8;
        midetalle(worksheet, 7);

        foreach (var t in codir)
        {
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue(t.AR_CCODIGO.Trim());

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(t.AR_CDESCRI);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(t.AR_CCODPRO);

            worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 4).SetValue(t.AR_CUNIDAD);

            worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 5).SetValue(t.AR_NPRECOM);

            worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 6).SetValue(t.AR_CMONCOM);

            worksheet.Cell(cont, 7).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 7).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 7).SetValue(t.AR_CCUENTA);

            worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 8).SetValue(t.AR_CINFTEC);

            worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 9).SetValue(t.AR_CPARARA); //subarea 


            int contcolum = 9;//,sumaxcol=0;
            List<tabla_d_usuaprod> detalle = new List<tabla_d_usuaprod>();
            detalle = tabla_d_usuaprod.AprobacionxProducto(t.AR_CCODIGO.Trim());
            //decimal sumaporfila = 0;
            foreach (var c in detalle) 
            {


                worksheet.Cell(cont, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, contcolum + 1).Style.Font.FontSize = 8;
                worksheet.Cell(cont, contcolum + 1).SetValue(UT0030.Mostrarunusuario(c.DA_IDUSUA));

                worksheet.Cell(cont, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, contcolum + 2).Style.Font.FontSize = 8;
                worksheet.Cell(cont, contcolum + 2).SetValue( string.Format("{0:dd/MM/yyyy}" ,c.DA_FECHA) + " " +c.DA_HORA);
                contcolum = contcolum + 2;
                //sumaxcol++;String.Format("{0:dd/MM/yyyy}", c.var5) 
            }


            cont++;
            

        }

        worksheet.Columns().AdjustToContents();

        Response.Clear();
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"Reporte.xlsx\"");


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
        worksheet.Range("A" + fila.ToString()).SetValue("CODIGO")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("SERVICIO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("PROVEEDOR")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("UND")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("PRECIO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("MONEDA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("G" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString()).SetValue("CUENTA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("H" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString()).SetValue("USUARIO ASIG CUENTA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("I" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + fila.ToString()).SetValue("AREA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);




        int contcolum = 9;
        var validas = tabla_subareas.Nvalidaareas("1").SA_NAPROB;
        for (var c=0;c< validas;c++)
        {
            
            
            worksheet.Cell(fila, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila, contcolum + 1).Style.Font.FontSize = 8;
            worksheet.Cell(fila, contcolum + 1).SetValue("USUARIO APROBACION")
                .Style.Font.SetBold(true)
                .Fill.BackgroundColor = XLColor.FromArgb(251, 230, 171);

            worksheet.Cell(fila, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila, contcolum + 2).Style.Font.FontSize = 8;
            worksheet.Cell(fila, contcolum + 2).SetValue("FECHA HORA")
                .Style.Font.SetBold(true)
                .Fill.BackgroundColor = XLColor.FromArgb(251, 230, 171);

            contcolum= contcolum + 2;
        }

        
    }
}