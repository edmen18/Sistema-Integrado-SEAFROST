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
        string moneda = Convert.ToString(Request.QueryString["cs"]);
        string almacen = Convert.ToString(Request.QueryString["al"]);

        var treporte = tabla_parametrosbusq.UnParam_af(Convert.ToInt32(moneda), "C").PM_DESC;
        string fimpresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        string fec02res = string.Empty, fec01res = string.Empty;
        fec02res = Fen2.Replace("/", "");
        fec01res = Fenv.Replace("/", "");
        int ncolumnas = 0;
        decimal saldoantMNUS =0;
        ncolumnas = Convert.ToInt32(fec02res) - Convert.ToInt32(Fenv.Replace("/", "")) + 1;

        string[] arraycolumna=new string[ncolumnas];
        for (var k = 0; k < ncolumnas ; k++)
        {
            arraycolumna[k] = (Convert.ToInt32(fec01res) + k).ToString().Substring(0,4)+"/" + (Convert.ToInt32(fec01res) + k).ToString().Substring(4, 2);
        }

        var mesxt = fec02res.Substring(4, 2);
        int f = 0;
        f = (Convert.ToInt32(mesxt) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt) - 1);
        fec02res = fec02res.Substring(0, 4) + f.ToString("D2");


        AL0003MOVG detalle = new AL0003MOVG();
        AL0003MOVG detallesalidas = new AL0003MOVG();


        var reporte = "Centroconsumo.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        //micabecera(worksheet,1,idND);
        List<AL0003MOVG> codir = new List<AL0003MOVG>();
        //List<AL0003MOVG> ListadoG = new List<AL0003MOVG>();
        //codir = AL0003ARTI.ListarArticulosParaKardex(prd1, prd2);
        //foreach (var cg in codir) {
        codir = AL0003MOVG.DetalleMovgdistinc(arraycolumna[0],arraycolumna[ncolumnas - 1], prd1, prd2,almacen);
        //}
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
        worksheet.Range("B2:H2").SetValue("REPORTE DE CONSUMO ("+ treporte + ") DEL :" + Fenv + " AL: " + Fen2)
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Range("B3:H3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B3:H3").Style.Font.FontSize = 8;
        worksheet.Range("B3:H3").SetValue("ARTICULO DEL :" + prd1+" AL "+ prd2)
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        string almac = "";
        AL0003ALMA codalmacc = new AL0003ALMA();
        codalmacc.A1_CALMA =almacen; 
        almac = (almacen == "-1" ? "TODOS": AL0003ALMA.ListadirAlmacen(codalmacc).A1_CDESCRI);
        worksheet.Range("B4:H4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B4:H4").Style.Font.FontSize = 8;
        worksheet.Range("B4:H4").SetValue("ALMACEN "+ almac)
        .Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //DETALLE
        decimal[] sumaxcolumna = new decimal[ncolumnas];
        decimal sumaxcolfil = 0;
        int cont = 8;
        midetalle(worksheet, 7,arraycolumna);
        foreach (var t in codir)
        {
            
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue(t.C6_CCODIGO.Trim());

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(AL0003ARTI.obtenerArticuloPorID(t.C6_CCODIGO).AR_CDESCRI);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(AL0003ARTI.obtenerArticuloPorID(t.C6_CCODIGO).AR_CUNIDAD);

            int contcolum = 3,sumaxcol=0;
            
            decimal sumaporfila = 0;
            foreach (var c in arraycolumna) 
            {
                detalle = (AL0003MOVG.DetalleMovgSuma(c,c, t.C6_CCODIGO, "PE",almacen));
                detallesalidas = (AL0003MOVG.DetalleMovgSuma(c, c, t.C6_CCODIGO, "PS",almacen));
                decimal saldocus = 0,saldocmn=0,saldocantidad=0;
                saldocus = (detallesalidas == null ? 0 : detallesalidas.C6_NUSIMPO) - (detalle == null ? 0 : detalle.C6_NUSIMPO) ;
                saldocmn = (detallesalidas == null ? 0 : detallesalidas.C6_NMNIMPO) - (detalle == null ? 0 : detalle.C6_NMNIMPO);
                saldocantidad = (detallesalidas == null ? 0 : detallesalidas.C6_NCANTID) - (detalle == null ? 0 : detalle.C6_NCANTID);


                if (moneda == "1")
                {
                    saldoantMNUS = saldocmn;
                }
                else if(moneda == "2")
                {
                    saldoantMNUS = saldocus;
                }
                else
                {
                    saldoantMNUS = saldocantidad;
                }


                //saldoantMNUS
                sumaxcolumna[sumaxcol] = saldoantMNUS + sumaxcolumna[sumaxcol]; 
                sumaporfila = sumaporfila + saldoantMNUS; 
                

                worksheet.Cell(cont, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, contcolum + 1).Style.Font.FontSize = 8;
                worksheet.Cell(cont, contcolum + 1).SetValue(saldoantMNUS);
                contcolum++;
                sumaxcol++;
            }

            //var ss = sumaxcolumna;
            sumaxcolfil = sumaxcolfil + sumaporfila;
            worksheet.Cell(cont, contcolum+1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, contcolum+1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, contcolum+1).SetValue(sumaporfila); 

            AL0003MOVD indato = new AL0003MOVD();
            indato.C6_CCODIGO = t.C6_CCODIGO;
            string dato = "",dato3 = "";
            decimal dato2 = 0;
            dato = (AL0003MOVD.ListaProdUltimo(indato) == null ? "" : AL0003MOVD.ListaProdUltimo(indato).C6_CCODMON);
            dato2 = (AL0003MOVD.ListaProdUltimo(indato) == null ? 0 : AL0003MOVD.ListaProdUltimo(indato).C6_NPREUN1);
            dato3 = (AL0003MOVD.ListaProdUltimo(indato) == null ? "" : String.Format("{0:dd/MM/yyyy}", AL0003MOVD.ListaProdUltimo(indato).C6_DFECDOC));
            
            worksheet.Cell(cont, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, contcolum + 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, contcolum + 2).SetValue(dato);

            worksheet.Cell(cont, contcolum + 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, contcolum + 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, contcolum + 3).SetValue(dato2);

            worksheet.Cell(cont, contcolum + 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, contcolum + 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, contcolum + 4).SetValue(dato3);



            cont++;
            

        }

        int contfinalcolu =3,contarraycol=0; 
        foreach (var k in arraycolumna) { 
            worksheet.Cell(cont + 1, contfinalcolu + 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont + 1, contfinalcolu + 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont + 1, contfinalcolu + 1).SetValue(sumaxcolumna[contarraycol]);
            contfinalcolu++;
            contarraycol++;
        }

        worksheet.Cell(cont + 1, contfinalcolu + 1 ).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(cont + 1, contfinalcolu + 1 ).Style.Font.FontSize = 8;
        worksheet.Cell(cont + 1, contfinalcolu + 1 ).SetValue(sumaxcolfil);

        worksheet.Columns().AdjustToContents();
        //
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

   

    public void midetalle(IXLWorksheet worksheet, int fila,string[] arraycolumna)
    {   //fila3

     

        worksheet.Range("A" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("A" + fila.ToString()).SetValue("CODIGO")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("ARTICULO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("UND")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
          //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("MES")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        int contcolum = 3;
        foreach (var c in arraycolumna)
        {
            
            
            worksheet.Cell(fila, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila, contcolum + 1).Style.Font.FontSize = 8;
            worksheet.Cell(fila, contcolum + 1).SetValue(AL0003MOVG.Mesletras( Convert.ToInt32( c.Substring(5,2))))
                .Style.Font.SetBold(true)
                .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

            worksheet.Cell(fila - 1, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, contcolum + 1).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, contcolum + 1).SetValue(c.Substring(0,4))
                .Style.Font.SetBold(true)
                .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
            contcolum++;
        }

        worksheet.Cell(fila, contcolum + 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila, contcolum + 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila, contcolum + 1).SetValue("TOTAL")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila, contcolum + 2).Style.Font.FontSize = 8;
        worksheet.Cell(fila, contcolum + 2).SetValue("MON.")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila, contcolum + 3).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila, contcolum + 3).Style.Font.FontSize = 8;
        worksheet.Cell(fila, contcolum + 3).SetValue("PRECIO UNI")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).Style.Font.FontSize = 8;
        worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).SetValue("----ULTIMA COMPRA----") 
         .Merge()
         .Style.Font.SetBold(true)
         .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
         .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192) ;


        worksheet.Cell(fila, contcolum + 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila, contcolum + 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila, contcolum + 4).SetValue("FECHA")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
        
    }
}