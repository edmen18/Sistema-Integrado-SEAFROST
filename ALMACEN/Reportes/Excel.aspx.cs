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

public partial class ALMACEN_REPORTES_Excel : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        string fechini = Convert.ToString(Request.QueryString["FecIni"]);
        string fechfin = Convert.ToString(Request.QueryString["FecFin"]);
        string almac = Convert.ToString(Request.QueryString["almacen"]);
        string moneda = Convert.ToString(Request.QueryString["moneda"]);
        string articulo1 = Convert.ToString(Request.QueryString["articulo1"]);
        string articulo2 = Convert.ToString(Request.QueryString["articulo2"]);
        string indicador = Convert.ToString(Request.QueryString["ind"]);
        decimal SUMTOTAL = 0;
       

        vista_esvarticulo TABL = new vista_esvarticulo();
        List<AL0003ARTI> LISTART = new List<AL0003ARTI>();
        LISTART = AL0003ARTI.ListarArticulosParaStockValorizado(articulo1, articulo2);
        TABL.AR_CCODIGO = "NINGUNO";
        foreach (AL0003ARTI B in LISTART)
        {
            TABL.AR_CCODIGO = TABL.AR_CCODIGO + "," + B.AR_CCODIGO;
        }

        TABL.C6_DFECDOC = Convert.ToDateTime(fechini);
        TABL.C6_FECHA2 = Convert.ToDateTime(fechfin);
        TABL.A1_CALMA = almac;
        TABL.C6_CCODMON = moneda;
        TABL.CADENA = (Request["cadena"]);
        TABL.MOVIMIENTO = (Request["movimiento"]);

        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        int cont = 9;
        int cont3 = 9;
        int cont4 = 9;
        int contprov = 7;
        int contcab = 0;
        int cont2 = 9;

        AL0003ALMA almacen = new AL0003ALMA();
        List<vista_esvarticulo> detalle = new List<vista_esvarticulo>();
        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("PARTES DE ENTRADA/SALIDA VALORIZADOS").Style.Font.SetBold(true);
        worksheet.Range("B5").SetValue("ORDEN: POR ATICULO").Style.Font.SetBold(true);
        worksheet.Range("D5").SetValue("DEL: " + TABL.C6_DFECDOC + " AL: " + TABL.C6_FECHA2).Style.Font.SetBold(true);
        worksheet.Range("D5:J5").Row(1).Merge();
        if (TABL.C6_CCODMON.Trim()=="MN")
        {
            worksheet.Range("E6").SetValue("MONEDA NACIONAL S/.").Style.Font.SetBold(true);
        }
       else
        {
            worksheet.Range("E6").SetValue("DOLARES US$.").Style.Font.SetBold(true);
        }

        worksheet.Range("C4:J4").Row(1).Merge();
        if (indicador == "N")
        {
            detalle = AL0003ALMA.RptESVARTALM(TABL);
        }
             
        cont = 9;
        foreach (AL0003ARTI a in LISTART)
        {

            SUMTOTAL = 0;
             contcab = contprov + 1;

            worksheet.Range("C" + contprov.ToString()).SetValue("CODIGO: " + a.AR_CCODIGO + " ARTICULO: " + a.AR_CDESCRI).Style.Font.SetBold(true);
            worksheet.Range("C" + contprov.ToString() + ":J" + contprov.ToString()).Row(1).Merge();
            worksheet.Cell("A" + contcab.ToString()).SetValue("ALMACEN").Style.Font.SetBold(true);
            worksheet.Cell("B" + contcab.ToString()).SetValue("TIP.MOV").Style.Font.SetBold(true);
            worksheet.Cell("C" + contcab.ToString()).SetValue("MOVIMIENTO").Style.Font.SetBold(true);
            worksheet.Cell("D" + contcab.ToString()).SetValue("PARTE").Style.Font.SetBold(true);
            worksheet.Cell("E" + contcab.ToString()).SetValue("FECHA").Style.Font.SetBold(true);
            worksheet.Cell("F" + contcab.ToString()).SetValue("FT").Style.Font.SetBold(true);
            worksheet.Cell("G" + contcab.ToString()).SetValue("REFERENCIA").Style.Font.SetBold(true);
            worksheet.Cell("H" + contcab.ToString()).SetValue("PROVEEDOR").Style.Font.SetBold(true);
            worksheet.Cell("I" + contcab.ToString()).SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("J" + contcab.ToString()).SetValue("PRECIO").Style.Font.SetBold(true);
            worksheet.Cell("K" + contcab.ToString()).SetValue("VALOR TOTAL").Style.Font.SetBold(true);
            worksheet.Cell("L" + contcab.ToString()).SetValue("CTA. GASTO").Style.Font.SetBold(true);
            worksheet.Cell("M" + contcab.ToString()).SetValue("CENTRO COSTO").Style.Font.SetBold(true);
            worksheet.Cell("M" + contcab.ToString()).SetValue("SOLICITANTE").Style.Font.SetBold(true);
            worksheet.Cell("O" + contcab.ToString()).SetValue("ORDEN TRABAJO").Style.Font.SetBold(true);

            foreach (vista_esvarticulo b in detalle)
            {
                if (a.AR_CCODIGO == b.AR_CCODIGO)
                {
                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.A1_CALMA + "");
                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.C6_CTIPMOV + "");
                    worksheet.Cell("C" + cont2.ToString()).Value = b.C6_CCODMOV;
                    worksheet.Cell("D" + cont2.ToString()).Value = ("'" +  b.C6_CNUMDOC +"'");
                    worksheet.Cell("E" + cont2.ToString()).Value = ("'" + b.C6_DFECDOC + "");
                    worksheet.Cell("F" + cont2.ToString()).Value = b.C6_CRFTDOC;
                    worksheet.Cell("G" + cont2.ToString()).Value = b.C6_CRFNDOC;
                    worksheet.Cell("H" + cont2.ToString()).Value = b.ADESANE;
                    worksheet.Cell("I" + cont2.ToString()).Value = b.C6_NCANTID;
                    if(b.C6_CCODMON.Trim()== "MN")
                    {
                        worksheet.Cell("J" + cont2.ToString()).Value = b.C6_NMNPRUN;
                        worksheet.Cell("k" + cont2.ToString()).Value = b.C6_NMNIMPO;
                    }
                    else
                    {
                        worksheet.Cell("J" + cont2.ToString()).Value = b.C6_NUSPRUN;
                        worksheet.Cell("k" + cont2.ToString()).Value = b.C6_NUSIMPO;
                    }
                   
                    worksheet.Cell("L" + cont2.ToString()).Value = b.C6_CCUENTA;
                    worksheet.Cell("M" + cont2.ToString()).Value = b.CCOSTO;
                    worksheet.Cell("N" + cont2.ToString()).Value = b.solicitante;
                    worksheet.Cell("O" + cont2.ToString()).Value = b.C6_CORDEN;

                    if (b.C6_CCODMON.Trim() == "MN")
                    {
                        SUMTOTAL = SUMTOTAL + Convert.ToDecimal(b.C6_NMNIMPO);
                    }
                    else
                    {
                        SUMTOTAL = SUMTOTAL + Convert.ToDecimal(b.C6_NUSIMPO);
                    }
                    cont++;
                    cont2++;
                    contprov++;
                    worksheet.Cell("k" + cont2.ToString()).Value = SUMTOTAL;
                    worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                }
               
               
            }
            contprov = contprov + 3;
            cont2 = cont2 + 3;
        }

        if (cont3 == 9)
        {
            cont4 = cont3;
            cont3 = 0;
        }
        else
        {
            cont4 = cont2 - cont + 9;
        }

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