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

        var reporte = "ReportOC.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ANTICIPO\\REPORTES\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);

        List<vista_cocabcerapopup> codir = new List<vista_cocabcerapopup>();
        CO0003MOVC VC = new CO0003MOVC();

        string tusu = UT0030.Mostrarinfousuario(Session["codusu"].ToString()).TU_LOCEMI;

        
        if (Session["TiCon"].ToString() == "1") {  
            VC.OC_CREMITE = Session["codusu"].ToString();
            VC.OC_CSITORD = Session["ddlestad"].ToString();//"1"; //VARIA
            VC.OC_CCODPRO = Session["txtidpro"].ToString();//""; //VARIA
            VC.OC_CTIPORD = Session["ddltipo"].ToString();// "-1"; //VARIA
            VC.OC_CCODSOL = Session["txtcodsol"].ToString() ; //""; //VARIA
            VC.OC_DFECDOC = Convert.ToDateTime(Session["txtfecha1"].ToString());//Convert.ToDateTime("01/01/2016");
            VC.OC_DFECENT = Convert.ToDateTime(Session["txtfecha2"].ToString()) ;//DateTime.Now; //VARIA
        }
        else
        {
            VC.OC_CREMITE = Session["codusu"].ToString();
            VC.OC_CSITORD = "1"; //VARIA
            VC.OC_CCODPRO = ""; //VARIA
            VC.OC_CTIPORD = "-1"; //VARIA
            VC.OC_CCODSOL = ""; //VARIA
            VC.OC_DFECDOC = Convert.ToDateTime("01/01/2014");
            VC.OC_DFECENT = DateTime.Now; //VARIA
        }

        if (tusu.Trim() == "F") {
        codir = CO0003MOVC.ListarcabeceraocpopupCondosusuarios(VC);
        }
        else
        {
            codir = CO0003MOVC.Listarcabeceraocpopup(VC);
        }
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
        worksheet.Range("B2:H2").SetValue("REPORTE ORDENES")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //worksheet.Range("B3:H3").Style.Font.FontName = "Draft 17cpi"; 
        //worksheet.Range("B3:H3").Style.Font.FontSize = 8; 
        //worksheet.Range("B3:H3").SetValue("A") 
        //.Merge() 
        //.Style.Font.SetBold(true) 
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center); 

        //worksheet.Range("B4:H4").Style.Font.FontName = "Draft 17cpi";
        //worksheet.Range("B4:H4").Style.Font.FontSize = 8;
        //worksheet.Range("B4:H4").SetValue("B")
        //.Merge()
        //.Style.Font.SetBold(true)
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //DETALLE
        decimal[] sumaxcolumna = new decimal[ncolumnas];
        //decimal sumaxcolfil = 0;
        int cont = 6;
        midetalle(worksheet, 5);

        foreach (var t in codir)
        {
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue(t.OC_CNUMORD.Trim());

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(t.OC_DFECDOC);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(t.OC_CRAZSOC);

            worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 4).SetValue(t.OC_CCODMON);

            worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 5).Style.NumberFormat.Format = "#,##0.00";
            worksheet.Cell(cont, 5).SetValue(t.OC_CCODMON == "MN" ?  t.OC_NIMPMN : t.OC_NIMPUS );//verificar

            worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 6).SetValue(t.OC_CTIPORD);

            worksheet.Cell(cont, 7).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 7).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 7).SetValue(t.OC_CSITORD);

            worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 8).SetValue(t.OC_CFORPA1);

            worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 9).SetValue(t.OC_CUSEA01);

            worksheet.Cell(cont, 10).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 10).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 10).SetValue(t.OC_CUSEA02); //subarea 

            worksheet.Cell(cont, 11).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 11).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 11).SetValue(t.OC_CUSEA03); //subarea 

            worksheet.Cell(cont, 12).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 12).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 12).SetValue(t.OC_CSOLICIT == null ? "" : t.OC_CSOLICIT); //subarea t.OC_CSOLICI

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
        worksheet.Range("A" + fila.ToString()).SetValue("N° ORDEN")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("FECHA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("PROVEEDOR")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("MONEDA")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("IMPORTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("ESTADO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("G" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString()).SetValue("TIPO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("H" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString()).SetValue("PAGO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("I" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + fila.ToString()).SetValue("USUARIO1")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("J" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + fila.ToString()).SetValue("USUARIO2")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("K" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("K" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("K" + fila.ToString()).SetValue("USUARIO3")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("L" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("L" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("L" + fila.ToString()).SetValue("SOLICITANTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);





        
    }
}