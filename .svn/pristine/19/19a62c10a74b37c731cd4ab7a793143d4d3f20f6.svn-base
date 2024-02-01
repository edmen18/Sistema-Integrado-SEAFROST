using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;
using ClosedXML.Excel;
using System.Data;
using CapaNegocio;
/* using System.Data.DataSetExtensions;*/

public partial class ALMACEN_Reportes_Reporte : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string Fenv = Convert.ToString(Request.QueryString["f1"]);
        //string Fen2 = Convert.ToString(Request.QueryString["f2"]);
        string prd1 = Convert.ToString(Request.QueryString["p1"]);
        string prd2 = Convert.ToString(Request.QueryString["p2"]);
        string moneda = Convert.ToString(Request.QueryString["mo"]);
        string alma = Convert.ToString(Request.QueryString["al"]);

        string fimpresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        string fec02res = string.Empty;
        //fec02res = Fen2.Replace("/", "");
        //var mesxt = fec02res.Substring(4,2);
        //int f = 0;
        //f = (Convert.ToInt32(mesxt) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt) - 1);
        //fec02res = fec02res.Substring(0, 4) + f.ToString("D2");


        string fec01res = string.Empty;
        fec01res = Fenv.Replace("/", "");
        var mesxt1 = fec01res.Substring(4, 2);
        int f1 = 0;
        f1 = (Convert.ToInt32(mesxt1) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt1) - 1);
        fec01res = ((Convert.ToInt32(mesxt1) )==1 ?Convert.ToString( Convert.ToUInt64(fec01res.Substring(0, 4)) - 1 ) : fec01res.Substring(0, 4) ) + f1.ToString("D2");

        List<AL0003SKNU> detalle = new List<AL0003SKNU>();


        var reporte = "StockVal.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        //micabecera(worksheet,1,idND);
        //List<AL0003ARTI> codir = new List<AL0003ARTI>();
        //AL0003RESU stock = new AL0003RESU();
        //codir = AL0003ARTI.ListarArticulosParaKardex(prd1, prd2);
        Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
        DataTable dataTableName = consulta.funStockVal(alma, Fenv.Replace("/",""),  prd1, prd2);
        List<RStockVal> listName = dataTableName.AsEnumerable().Select(m => new RStockVal()
        {
            SA_CCODIGO = m.Field<string>("SA_CCODIGO"),
            AR_CDESCRI = m.Field<string>("AR_CDESCRI"),
            SA_CALMA = m.Field<string>("SA_CALMA"),
            A1_CDESCRI = m.Field<string>("A1_CDESCRI"),
            AR_CUNIDAD = m.Field<string>("AR_CUNIDAD"),
            SA_NCANACT = m.Field<decimal>("SA_NCANACT"),
            VL_NMNPRUN = m.Field<decimal>("VL_NMNPRUN"),
            VL_NUSPRUN = m.Field<decimal>("VL_NUSPRUN"),
            MONTOUS = m.Field<decimal>("MONTOUS"),
            MONTOMN = m.Field<decimal>("MONTOMN")
        }).ToList();

        //CABECERA 1:
        worksheet.Range("A1:B1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A1:B1").Style.Font.FontSize = 8;
        worksheet.Range("A1:B1").SetValue("SEAFROST SAC:")
        .Merge()
        .Style.Font.SetBold(true);

    
        worksheet.Range("H1:H1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H1:H1").Style.Font.FontSize = 8;
        worksheet.Range("H1:H1").SetValue(fimpresion)
        .Merge()
        .Style.Font.SetBold(true)
        ;

        worksheet.Range("A2:H2").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A2:H2").Style.Font.FontSize = 8;
        worksheet.Range("A2:H2").SetValue("STOCK POR ARTICULO - DEL :"+ Fenv )
        .Merge()
        .Style.Font.SetBold(true);

        worksheet.Range("A3:H3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A3:H3").Style.Font.FontSize = 8;
        worksheet.Range("A3:H3").SetValue("MONEDA:"+ (moneda =="MN"?"MONEDA NACIONAL":"DOLARES"))
        .Merge()
        .Style.Font.SetBold(true);



        //DETALLE
        int cont = 7;
        midetalle(worksheet, 5);
        //foreach (var t in codir)
        //{

        //    detalle = AL0003SKNU.ListarStockVal(alma, t.AR_CCODIGO,Fenv);
        //    //detalle = AL0003STOC.ListarStockVal(alma, t.AR_CCODIGO);

            foreach (var p in listName)
            {
                //stock = (AL0003RESU.ObtenerStockVal(t.AR_CCODIGO, Fenv));

                worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 1).SetValue(p.SA_CCODIGO);

                worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 2).SetValue(p.AR_CDESCRI);

                worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 3).SetValue(p.SA_CALMA);

                worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 4).SetValue(p.A1_CDESCRI);

                worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 5).SetValue(p.AR_CUNIDAD);

                worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 6).SetValue(p.SA_NCANACT);

                worksheet.Cell(cont, 7).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 7).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 7).SetValue(moneda == "MN" ? p.VL_NMNPRUN : p.VL_NUSPRUN)
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                .NumberFormat.Format = "###,##0.00";

                worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 8).SetValue(moneda == "MN" ? p.MONTOMN : p.MONTOUS)
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                .NumberFormat.Format = "###,##0.00";


                cont++;
            }

        //}
        worksheet.Columns().AdjustToContents();
        
        // Adding print areas
        //worksheet.PageSetup.PrintAreas.Add("A1:X" + co.ToString());

        //PROTEGE
        //var pass = worksheet.Protect("SEA2016");
        //pass.SelectLockedCells = false;
        //pass.SelectUnlockedCells = false;

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

        worksheet.Range("A" + (fila - 1).ToString() + ":H" + (fila + 1).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).SetValue("CODIGO")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192,255,192)
        ;

        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).SetValue("DESCRIPCION")
        .Merge()
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).SetValue("ALMACEN")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("D" + fila.ToString() + ":D" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString() + ":D" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString() + ":D" + (fila + 1).ToString()).SetValue("ALMACEN")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("E" + fila.ToString() + ":E" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString() + ":E" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString() + ":E" + (fila + 1).ToString()).SetValue("UNIDAD")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).SetValue("CANTIDAD")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).SetValue("PRECIO")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).SetValue("TOTAL")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
                

    }
}