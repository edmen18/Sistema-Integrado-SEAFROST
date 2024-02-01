using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;
using ClosedXML.Excel;
using CapaNegocio;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
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
        string almacen2 = Convert.ToString(Request.QueryString["al2"]); 
        string foragrupa = Convert.ToString(Request.QueryString["ag"]);

        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
            }
        }
      





        var treporte = (moneda == "1"?"MONEDA NACIONAL": moneda=="2" ? "MONEDA DOLARES":"CANTIDAD"  );//tabla_parametrosbusq.UnParam_af(Convert.ToInt32(moneda), "C").PM_DESC;
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


        TABLCONSUCTA detalle = new TABLCONSUCTA();
        AL0003MOVG detallesalidas = new AL0003MOVG();


        var reporte = "Centroconsumo.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        //micabecera(worksheet,1,idND);
        //List<AL0003MOVG> codir = new List<AL0003MOVG>();
        List<TABLCONSUCTA> codir = new List<TABLCONSUCTA>();
        //List<AL0003MOVG> ListadoG = new List<AL0003MOVG>();
        //codir = AL0003ARTI.ListarArticulosParaKardex(prd1, prd2);
        //foreach (var cg in codir) {

        //AL0003MOVG.DetalleMovgdistinc(arraycolumna[0],arraycolumna[ncolumnas - 1], prd1, prd2,almacen,foragrupa);
        string finicio = "", ffina = "", diax = "";
        finicio = "01/" + arraycolumna[0].Substring(5, 2) + "/" + arraycolumna[0].Substring(0, 4);
        diax = DateTime.DaysInMonth(Convert.ToInt32(arraycolumna[ncolumnas - 1].Substring(0, 4)), Convert.ToInt32(arraycolumna[ncolumnas - 1].Substring(5, 2))).ToString("D2");
        ffina = diax + "/" + arraycolumna[ncolumnas - 1].Substring(5, 2) + "/" + arraycolumna[ncolumnas - 1].Substring(0, 4);

        DateTime fin = Convert.ToDateTime(finicio);
        DateTime ffn = Convert.ToDateTime(ffina);

        Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
        DataTable dataTableName = consulta.funConsumoVal(foragrupa, almacen, finicio, ffina, prd1, prd2, localIP, almacen2);

        List<RConsumo> listName = dataTableName.AsEnumerable().Select(m => new RConsumo()
        {
            C6_CCENCOS = m.Field<string>("C6_CCENCOS"),
            C6_CCODIGO = m.Field<string>("C6_CCODIGO"),
            C6_CALMA = m.Field<string>("C6_CALMA"),
            C6_CCUENTA = m.Field<string>("C6_CCUENTA"),
            C6_ANIO = m.Field<string>("C6_ANIO"),
            RUB = m.Field<string>("RUB"),
            CTADEST = m.Field<string>("CTADEST"),
            CTACONS = m.Field<string>("CTACONS"),
            C6_NCANTID = m.Field<decimal>("C6_NCANTID"),
            C6_NUSIMPO = m.Field<decimal>("C6_NUSIMPO"),
            C6_NMNIMPO = m.Field<decimal>("C6_NMNIMPO"),
            AR_CDESCRI = m.Field<string>("AR_CDESCRI"),
            AR_CUNIDAD = m.Field<string>("AR_CUNIDAD"),
            TG_CDESCRI = m.Field<string>("TG_CDESCRI"),
            PDESCRI = m.Field<string>("PDESCRI"),
            DESCRUB = m.Field<string>("DESCRUB"),
        }).ToList();


        //using (var ctx = new RSFACAR())
        //{
            //codir = (from c in listName
            //         group c by new
            //       {
            //           c.C6_CCENCOS,
            //           c.C6_CCUENTA,
            //           c.C6_CCODIGO,
            //           c.C6_CALMA
            //       } into a
            //       select new
            //       {
            //           d01 = a.Key.C6_CCENCOS,
            //           d02 = a.Key.C6_CCUENTA,
            //           d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
            //           d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
            //           d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO),
            //           d06 = a.Key.C6_CCODIGO,
            //           d07 = a.Key.C6_CALMA,
            //       }

            //       ).ToList().Select(q => new TABLCONSUCTA()
            //       {
            //           C6_CCENCOS = q.d01,
            //           C6_CCUENTA = q.d02,
            //           C6_CCODIGO = q.d06,
            //           C6_CALMA = q.d07,
            //           C6_NMNIMPO = q.d04,
            //           C6_NUSIMPO = q.d05,
            //           C6_NCANTID = q.d03

            //       }
            //    ).ToList();
        //}


        //codir = TABLCONSUCTA.LstAsientoGroup();


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
        foreach (var t in listName)
        {
            
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue(t.C6_CCODIGO.Trim());

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(t.AR_CDESCRI);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(t.AR_CUNIDAD);

            worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 4).SetValue(t.C6_CCENCOS);

            worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 5).SetValue( t.TG_CDESCRI);

            worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 6).SetValue(t.PDESCRI);

            int contcolum = 6,sumaxcol=0;
            
            decimal sumaporfila = 0;
            foreach (var c in arraycolumna) 
            {
                //detalle = (AL0003MOVG.DetalleMovgSuma(c,c, t.C6_CCODIGO, "PE",almacen,t.C6_CCENCOS));
                TABLCONSUCTA ipar = new TABLCONSUCTA();
                ipar.C6_CCUENTA = t.C6_CCUENTA;
                ipar.C6_CALMA = t.C6_CALMA;
                ipar.C6_CCODIGO = t.C6_CCODIGO;
                ipar.C6_CCENCOS = t.C6_CCENCOS;
                ipar.C6_ANIO = c;
                detalle = TABLCONSUCTA.LstAsientoConsuCond(ipar, listName).Count() == 0 ? null : TABLCONSUCTA.LstAsientoConsuCond(ipar, listName).First(); //AL0003MOVG.DetalleMovgdistinc(c, c, t.C6_CCODIGO.Trim(), t.C6_CCODIGO.Trim(), t.C6_CALMA, "4");
                //detallesalidas = (AL0003MOVG.DetalleMovgSuma(c, c, t.C6_CCODIGO, "PS",almacen,t.C6_CCENCOS));
                decimal saldocus = 0,saldocmn=0,saldocantidad=0;
                saldocus =detalle==null ? 0:Convert.ToDecimal( detalle.C6_NUSIMPO); //(detallesalidas == null ? 0 : detallesalidas.C6_NUSIMPO) - (detalle == null ? 0 : detalle.C6_NUSIMPO) ;
                saldocmn = detalle == null ? 0 : Convert.ToDecimal(detalle.C6_NMNIMPO); //t.C6_NMNIMPO;//(detallesalidas == null ? 0 : detallesalidas.C6_NMNIMPO) - (detalle == null ? 0 : detalle.C6_NMNIMPO);
                saldocantidad = detalle == null ? 0 : Convert.ToDecimal(detalle.C6_NCANTID);//detalle.First().C6_NCANTID;t.C6_NCANTID;  //(detallesalidas == null ? 0 : detallesalidas.C6_NCANTID) - (detalle == null ? 0 : detalle.C6_NCANTID);
                
                if (moneda == "1")
                {
                    saldoantMNUS = saldocmn;
                } else if(moneda == "2"){
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
            //string dato = "",dato3 = "";
            //decimal dato2 = 0;
            //dato =  (AL0003MOVD.ListaProdUltimo(indato) == null ? "" : AL0003MOVD.ListaProdUltimo(indato).First().C6_CCODMON);
            //dato2 = (AL0003MOVD.ListaProdUltimo(indato) == null ? 0 : AL0003MOVD.ListaProdUltimo(indato).First().C6_NPREUN1);
            //dato3 = (AL0003MOVD.ListaProdUltimo(indato) == null ? "" : String.Format("{0:dd/MM/yyyy}", AL0003MOVD.ListaProdUltimo(indato).First().C6_DFECDOC));

            worksheet.Cell(cont, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, contcolum + 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, contcolum + 2).SetValue(t.DESCRUB);

            //worksheet.Cell(cont, contcolum + 3).Style.Font.FontName = "Draft 17cpi";
            //worksheet.Cell(cont, contcolum + 3).Style.Font.FontSize = 8;
            //worksheet.Cell(cont, contcolum + 3).SetValue(dato2);

            //worksheet.Cell(cont, contcolum + 4).Style.Font.FontName = "Draft 17cpi";
            //worksheet.Cell(cont, contcolum + 4).Style.Font.FontSize = 8;
            //worksheet.Cell(cont, contcolum + 4).SetValue(dato3);



            cont++;
            

        }

        int contfinalcolu =6,contarraycol=0; 
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
        worksheet.Range("D" + fila.ToString()).SetValue("CENTRO COSTO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("CENTRO COSTO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        //worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        //worksheet.Range("E" + fila.ToString()).SetValue("CTA")
        //    .Style.Font.SetBold(true)
        //    .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("CTA")
            .Style.Font.SetBold(true) 
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        int contcolum = 6;
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

        //worksheet.Cell(fila, contcolum + 2).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila, contcolum + 2).Style.Font.FontSize = 8;
        //worksheet.Cell(fila, contcolum + 2).SetValue("MON.")
        //    .Style.Font.SetBold(true)
        //    .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        //worksheet.Cell(fila, contcolum + 3).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila, contcolum + 3).Style.Font.FontSize = 8;
        //worksheet.Cell(fila, contcolum + 3).SetValue("PRECIO UNI")
        //    .Style.Font.SetBold(true)
        //    .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        //worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).Style.Font.FontSize = 8;
        //worksheet.Range(worksheet.Cell(6, contcolum + 2).Address + ":" + worksheet.Cell(6, contcolum + 4).Address ).SetValue("----ULTIMA COMPRA----") 
        // .Merge()
        // .Style.Font.SetBold(true)
        // .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        // .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192) ;


        //worksheet.Cell(fila, contcolum + 4).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila, contcolum + 4).Style.Font.FontSize = 8;
        //worksheet.Cell(fila, contcolum + 4).SetValue("FECHA")
        //.Style.Font.SetBold(true)
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        //.Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
        
    }
}