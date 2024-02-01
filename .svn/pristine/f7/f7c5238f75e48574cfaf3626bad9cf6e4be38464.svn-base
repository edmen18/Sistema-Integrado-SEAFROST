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
        string Fenv = Convert.ToString(Request.QueryString["f1"]);
        string Fen2 = Convert.ToString(Request.QueryString["f2"]);
        string prd1 = Convert.ToString(Request.QueryString["p1"]);
        string prd2 = Convert.ToString(Request.QueryString["p2"]);
        string moneda = Convert.ToString(Request.QueryString["mo"]);

        string fimpresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        string fec02res = string.Empty;
        fec02res = Fen2.Replace("/", "");
        var mesxt = fec02res.Substring(4,2);
        int f = 0;
        f = (Convert.ToInt32(mesxt) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt) - 1);
        fec02res = fec02res.Substring(0, 4) + f.ToString("D2");
        List<AL0003MOVG> detalle = new List<AL0003MOVG>();


        var reporte = "KardexVal.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        //micabecera(worksheet,1,idND);
        List<AL0003ARTI> codir = new List<AL0003ARTI>();
        List<AL0003MOVG> ListadoG = new List<AL0003MOVG>();
        codir = AL0003ARTI.ListarArticulosParaKardex(prd1, prd2);

      
        
        //CABECERA 1:
        worksheet.Range("A1:B1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A1:B1").Style.Font.FontSize = 8;
        worksheet.Range("A1:B1").SetValue("SEAFROST SAC:")
        .Merge()
        .Style.Font.SetBold(true);

    
        worksheet.Range("K1:L1").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("K1:L1").Style.Font.FontSize = 8;
        worksheet.Range("K1:L1").SetValue(fimpresion)
        .Merge()
        .Style.Font.SetBold(true)
        ;

        worksheet.Range("D2:I2").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D2:I2").Style.Font.FontSize = 8;
        worksheet.Range("D2:I2").SetValue("MOVIMIENTO DE EXISTENCIAS POR ARTICULO - DEL :"+ Fenv +" AL: "+ Fen2)
        .Merge()
        .Style.Font.SetBold(true);

        worksheet.Range("F3:H3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F3:H3").Style.Font.FontSize = 8;
        worksheet.Range("F3:H3").SetValue("MONEDA:"+ (moneda =="MN"?"MONEDA NACIONAL":"DOLARES"))
        .Merge()
        .Style.Font.SetBold(true);



        //DETALLE
        int cont = 9;
        midetalle(worksheet, 5);
        foreach (var t in codir)
        {

            detalle = (AL0003MOVG.DetalleMovg(Fenv, Fen2, t.AR_CCODIGO));
            
            worksheet.Range("A" + (cont - 2).ToString()+ ":B" + (cont - 2).ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + (cont - 2).ToString()+ ":B" + (cont - 2).ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + (cont - 2).ToString()+ ":B" + (cont - 2).ToString()).SetValue(t.AR_CCODIGO.Trim())
                .Merge()
            .Style.Font.SetBold(true);

            worksheet.Range("C" + (cont - 2).ToString()+ ":G" +(cont - 2).ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("C" + (cont - 2).ToString()+ ":G" + (cont - 2).ToString()).Style.Font.FontSize = 8;
            worksheet.Range("C" + (cont - 2).ToString()+ ":G" + (cont - 2).ToString()).SetValue(t.AR_CDESCRI)
            .Merge()
            .Style.Font.SetBold(true);


            worksheet.Range("A" + (cont - 1).ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + (cont - 1).ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + (cont - 1).ToString()).SetValue("Saldo Inicial:");

            worksheet.Range("M" + (cont - 1).ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("M" + (cont - 1).ToString()).Style.Font.FontSize = 8;
            decimal saldoant = (AL0003RESU.ObtenerSaldoAnterior(t.AR_CCODIGO.Trim(), fec02res) );
            worksheet.Range("M" + (cont - 1).ToString()).SetValue(saldoant);

            
            decimal saldoantMNUS = 0;
            if (moneda == "MN")
            {
                saldoantMNUS = (AL0003RESU.ObtenerSaldoAnteriorMN(t.AR_CCODIGO.Trim(), fec02res));
            }
            else
            {
                saldoantMNUS = (AL0003RESU.ObtenerSaldoAnteriorUS(t.AR_CCODIGO.Trim(), fec02res));
            }
            
            worksheet.Range("N" + (cont - 1).ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("N" + (cont - 1).ToString()).Style.Font.FontSize = 8;
            worksheet.Range("N" + (cont - 1).ToString()).SetValue(saldoantMNUS);

            int cuentadet = 0;
            decimal totaingreso = 0, totasalida = 0,totalimnus=0,totalsmnus=0;
            foreach (AL0003MOVG p in detalle)
        {
            
            worksheet.Range("A" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + cont.ToString()).SetValue(p.C6_DFECDOC);

            worksheet.Range("B" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("B" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("B" + cont.ToString()).SetValue(p.C6_CTD);

            worksheet.Range("C" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("C" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("C" + cont.ToString()).SetValue(p.C6_CCODMOV);
                
            worksheet.Range("D" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("D" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("D" + cont.ToString()).SetValue(p.C6_CALMA);

            worksheet.Range("E" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("E" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("E" + cont.ToString()).SetValue(p.C6_CNUMDOC);

            worksheet.Range("F" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("F" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("F" + cont.ToString()).SetValue(p.C6_CRFNDOC);

            worksheet.Range("G" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("G" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("G" + cont.ToString()).SetValue(p.C6_CCODPRO);

            if (moneda=="MN") { 
            worksheet.Range("H" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("H" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("H" + cont.ToString()).SetValue(p.C6_NMNPRUN);
            }
            else
            {
                worksheet.Range("H" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("H" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("H" + cont.ToString()).SetValue(p.C6_NUSPRUN);
            //.Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
            //.NumberFormat.Format = "###,##0.00"; 
            }

            if (p.C6_CTD == "PE")
            {
                totaingreso = totaingreso + p.C6_NCANTID;
                worksheet.Range("I" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("I" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("I" + cont.ToString()).SetValue(p.C6_NCANTID);
                    saldoant = p.C6_NCANTID + saldoant;
                if (moneda == "MN")
                {
                    worksheet.Range("J" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Range("J" + cont.ToString()).Style.Font.FontSize = 8;
                    worksheet.Range("J" + cont.ToString()).SetValue(p.C6_NMNIMPO);
                        saldoantMNUS = saldoantMNUS  + p.C6_NMNIMPO;
                        totalimnus = totalimnus + p.C6_NMNIMPO;
                }
                else
                {
                    worksheet.Range("J" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Range("J" + cont.ToString()).Style.Font.FontSize = 8;
                    worksheet.Range("J" + cont.ToString()).SetValue(p.C6_NUSIMPO);
                        saldoantMNUS = saldoantMNUS + p.C6_NUSIMPO;
                        totalimnus = totalimnus + p.C6_NUSIMPO;
                    }
            }


            if (p.C6_CTD == "PS")
            {
                    totasalida = totasalida + p.C6_NCANTID;
                    saldoant = (saldoant - p.C6_NCANTID) ;
                worksheet.Range("K" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("K" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("K" + cont.ToString()).SetValue(p.C6_NCANTID);
                if (moneda == "MN")
                {
                    worksheet.Range("L" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Range("L" + cont.ToString()).Style.Font.FontSize = 8;
                    worksheet.Range("L" + cont.ToString()).SetValue(p.C6_NMNIMPO);
                        saldoantMNUS = saldoantMNUS - p.C6_NMNIMPO ;
                        totalsmnus = totalsmnus + p.C6_NMNIMPO;
                    }
                else
                {
                    worksheet.Range("L" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Range("L" + cont.ToString()).Style.Font.FontSize = 8;
                    worksheet.Range("L" + cont.ToString()).SetValue(p.C6_NUSIMPO);
                    saldoantMNUS = saldoantMNUS - p.C6_NUSIMPO ;
                        totalsmnus = totalsmnus + p.C6_NUSIMPO;
                    }
            }

            worksheet.Range("M" + cont.ToString()).Style.Font.FontName = "Draft 17cpi"; 
            worksheet.Range("M" + cont.ToString()).Style.Font.FontSize = 8; 
            worksheet.Range("M" + cont.ToString()).SetValue(saldoant);

            worksheet.Range("N" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("N" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("N" + cont.ToString()).SetValue(saldoantMNUS);

            worksheet.Range("O" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("O" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("O" + cont.ToString()).SetValue(p.C6_CGLOSA);

            cont++;
            cuentadet++;
            }
            if (cuentadet > 1)
            {

                worksheet.Range("A" + cont.ToString()+ ":E" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("A" + cont.ToString() + ":E" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("A" + cont.ToString() + ":E" + cont.ToString()).SetValue("TOTAL DE MOVIMIENTO")
                    .Merge();

                worksheet.Range("I" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("I" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("I" + cont.ToString()).SetValue(totaingreso);

                worksheet.Range("J" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("J" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("J" + cont.ToString()).SetValue(totalimnus);

                worksheet.Range("K" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("K" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("K" + cont.ToString()).SetValue(totasalida);

                worksheet.Range("L" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
                worksheet.Range("L" + cont.ToString()).Style.Font.FontSize = 8;
                worksheet.Range("L" + cont.ToString()).SetValue(totalsmnus);
                cont = cont + 3;
            }
            else
            {
                cont = cont + 2;
            }
            

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

        worksheet.Range("A" + (fila - 1).ToString() + ":O" + (fila + 1).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("A" + fila.ToString() + ":A"+(fila + 1).ToString()).SetValue("FECHA")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192,255,192)
        ;

        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString() + ":B" + (fila + 1).ToString()).SetValue("TIPO DOC")
        .Merge()
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString() + ":C" + (fila + 1).ToString()).SetValue("TIPO MOV.")
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
        worksheet.Range("E" + fila.ToString() + ":E" + (fila + 1).ToString()).SetValue("NRO DOC")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString() + ":F" + (fila + 1).ToString()).SetValue("DOC REF.")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString() + ":G" + (fila + 1).ToString()).SetValue("PROVEEDOR / CLIENTE")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString() + ":H" + (fila + 1).ToString()).SetValue("PRECIO UNITARIO")
        .Merge()
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("I" + fila.ToString()+":J"+ fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + fila.ToString()+ ":J" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + fila.ToString() + ":J" + fila.ToString()).SetValue("ENTRADA")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Range("I" + (fila + 1).ToString() ).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + (fila + 1).ToString()).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Range("J" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + (fila + 1).ToString()).SetValue("PT DOC.")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Range("K" + fila.ToString() + ":L" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("K" + fila.ToString() + ":L" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("K" + fila.ToString() + ":L" + fila.ToString()).SetValue("SALIDA")
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Range("K" + (fila + 1).ToString() ).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("K" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("K" + (fila + 1).ToString()).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Range("L" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("L" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("L" + (fila + 1).ToString()).SetValue("PT DOC.")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Range("M" + fila.ToString() + ":N" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("M" + fila.ToString() + ":N" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("M" + fila.ToString() + ":N" + fila.ToString()).SetValue("SALDO")
        .Merge() 
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
       .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("M" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("M" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("M" + (fila + 1).ToString()).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("N" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("N" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("N" + (fila + 1).ToString()).SetValue("IMPORTE")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192); 

        worksheet.Range("O" + fila.ToString() + ":O" + (fila + 1).ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("O" + fila.ToString() + ":O" + (fila + 1).ToString()).Style.Font.FontSize = 8;
        worksheet.Range("O" + fila.ToString() + ":O" + (fila + 1).ToString()).SetValue("GLOSA")
            .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        

    }
}