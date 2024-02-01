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
using System.Drawing;
using System.Globalization;

public partial class ALMACEN_REPORTES_consumo_ExcelConsumoES : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string anio = Convert.ToString(Request.QueryString["anio"]);
        string mes = Convert.ToString(Request.QueryString["mes"]);
        string cadena = Convert.ToString(Request.QueryString["cadena"]);
        string movimiento = Convert.ToString(Request.QueryString["movimiento"]);
        string centrocosto1 = Convert.ToString(Request.QueryString["centrocosto1"]);
        string centrocosto2 = Convert.ToString(Request.QueryString["centrocosto2"]);
        string varios1 = Convert.ToString(Request.QueryString["varios1"]);
        string varios2 = Convert.ToString(Request.QueryString["varios2"]);
        string indicador = Convert.ToString(Request.QueryString["indicador"]);
        int contprov = 7;
        int contcab = 0;
        int cont2 = 9;
        decimal SUMCANT = 0;
        decimal SUMDOL = 0;
        decimal SUMMN = 0;
        decimal SUMCANTD = 0;
        decimal SUMDOLD = 0;
        decimal SUMMND = 0;
        string mesletras = "";
        if (mes == "01")
        {
            mesletras = "ENERO";
        }
        if (mes == "02")
        {
            mesletras = "FEBRERO";
        }
        if (mes == "03")
        {
            mesletras = "MARZO";
        }
        if (mes == "04")
        {
            mesletras = "ABRIL";
        }
        if (mes == "05")
        {
            mesletras = "MAYO";
        }
        if (mes == "06")
        {
            mesletras = "JUNIO";
        }
        if (mes == "07")
        {
            mesletras = "JULIO";
        }
        if (mes == "08")
        {
            mesletras = "AGOSTO";
        }
        if (mes == "09")
        {
            mesletras = "SETIEMBRE";
        }
        if (mes == "10")
        {
            mesletras = "OCTUBRE";
        }
        if (mes == "11")
        {
            mesletras = "NOVIEMBRE";
        }
        if (mes == "12")
        {
            mesletras = "DICIEMBRE";
        }
        if (indicador!="PL") { 
        List<AL0003TABL> CENTROCOSTO = new List<AL0003TABL>();
        List<AL0003TABL> VARIOS = new List<AL0003TABL>();
        CENTROCOSTO = AL0003TABL.ListarvALORESParaStockValorizado(centrocosto1, centrocosto2, "10");
        VARIOS = AL0003TABL.ListarvALORESParaStockValorizado(varios1, varios2, indicador);
        vista_consumoccosto TABL = new vista_consumoccosto();

        TABL.annio = anio;
        TABL.mes = mes;
        TABL.CADENA = cadena;
        TABL.MOVIMIENTO = movimiento;
        TABL.CADENACCOSTO = "NINGUNO";
        foreach (AL0003TABL B in CENTROCOSTO)
        {
            TABL.CADENACCOSTO = TABL.CADENACCOSTO + "," + B.TG_CCLAVE;
        }
        TABL.TG_CCLAVE = "NINGUNO";
        foreach (AL0003TABL B in VARIOS)
        {
            TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
        }
        AL0003ALMA almacen = new AL0003ALMA();
        List<vista_consumoccosto> detalle = new List<vista_consumoccosto>();

        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("E4").SetValue("RESUMEN POR CENTRO DE COSTO DEL MES " + " " + mesletras + " DEL AÑO " + anio).Style.Font.SetBold(true);
        worksheet.Range("E5").SetValue("DEL GRUPO " + varios1 + " HASTA EL GRUPO " + varios2).Style.Font.SetBold(true);
        detalle = AL0003ALMA.rptconsumoes(TABL, indicador);

        contcab = contprov + 1;
        worksheet.Cell("A" + contcab.ToString()).SetValue("C. COSTO").Style.Font.SetBold(true);
        worksheet.Cell("B" + contcab.ToString()).SetValue("DESCRIPCION").Style.Font.SetBold(true);
        worksheet.Cell("E" + contcab.ToString()).SetValue("ARTICULO").Style.Font.SetBold(true);
        worksheet.Cell("F" + contcab.ToString()).SetValue("DESCRIPCION").Style.Font.SetBold(true);
        worksheet.Cell("G" + contcab.ToString()).SetValue("CANT. CONSUMO").Style.Font.SetBold(true);
        worksheet.Cell("H" + contcab.ToString()).SetValue("DEVOLUCION").Style.Font.SetBold(true);
        worksheet.Cell("I" + contcab.ToString()).SetValue("NETO").Style.Font.SetBold(true);
        worksheet.Cell("J" + contcab.ToString()).SetValue("CONSUMO US").Style.Font.SetBold(true);
        worksheet.Cell("K" + contcab.ToString()).SetValue("DEVOLUC. US").Style.Font.SetBold(true);
        worksheet.Cell("L" + contcab.ToString()).SetValue("NETO US").Style.Font.SetBold(true);
        worksheet.Cell("M" + contcab.ToString()).SetValue("CONSUMO MN").Style.Font.SetBold(true);
        worksheet.Cell("N" + contcab.ToString()).SetValue("DEVOLUC. MN").Style.Font.SetBold(true);
        worksheet.Cell("O" + contcab.ToString()).SetValue("NETO MN").Style.Font.SetBold(true);

        //worksheet.Range("A8:O8").Style.Border.BottomBorder.Equals(XLLineStyle.Single);
        foreach (vista_consumoccosto b in detalle)
        {
            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.C6_CCENCOS + "");
            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.centrocosto + "");

            if (indicador == "38")
            {
                worksheet.Cell("C" + contcab.ToString()).SetValue("COD. FAMILIA").Style.Font.SetBold(true);
                worksheet.Cell("D" + contcab.ToString()).SetValue("FAMILIA").Style.Font.SetBold(true);
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AR_CFAMILI + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.familia + "");
                worksheet.Range("E5").SetValue("DE LA FAMILIA " + varios1 + " HASTA LA FAMILIA " + varios2).Style.Font.SetBold(true);
            }
            if (indicador == "06")
            {
                worksheet.Cell("C" + contcab.ToString()).SetValue("COD. GRUPO").Style.Font.SetBold(true);
                worksheet.Cell("D" + contcab.ToString()).SetValue("GRUPO").Style.Font.SetBold(true);
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AR_CGRUPO + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.grupo + "");
                worksheet.Range("E5").SetValue("DEL GRUPO " + varios1 + " HASTA EL GRUPO " + varios2).Style.Font.SetBold(true);
            }
            if (indicador == "07")
            {
                worksheet.Cell("C" + contcab.ToString()).SetValue("COD.CUENTA").Style.Font.SetBold(true);
                worksheet.Cell("D" + contcab.ToString()).SetValue("CUENTA").Style.Font.SetBold(true);
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AR_CCUENTA + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.cuenta + "");
                worksheet.Range("E5").SetValue("DE LA CUENTA " + varios1 + " HASTA LA CUENTA " + varios2).Style.Font.SetBold(true);
            }
            if (indicador == "39")
            {
                worksheet.Cell("C" + contcab.ToString()).SetValue("COD.MODELO").Style.Font.SetBold(true);
                worksheet.Cell("D" + contcab.ToString()).SetValue("MODELO").Style.Font.SetBold(true);
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AR_CMODELO + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.modelo + "");
                worksheet.Range("E5").SetValue("DEL MODELO " + varios1 + " HASTA EL MODELO " + varios2).Style.Font.SetBold(true);
            }
            worksheet.Cell("E" + cont2.ToString()).Value = ("'" + b.AR_CCODIGO + "");
            worksheet.Cell("F" + cont2.ToString()).Value = b.AR_CDESCRI;

            if (b.cadcantidad == "")
            {
                worksheet.Cell("G" + cont2.ToString()).Value = ("0.00");
                b.cadcantidad = "0";

            }
            else
            {
                worksheet.Cell("G" + cont2.ToString()).Value = Convert.ToDecimal((b.cadcantidad)).ToString("N", CultureInfo.InvariantCulture); ;
            }

            if (b.caddevolucion == "")
            {
                worksheet.Cell("H" + cont2.ToString()).Value = ("0.00");
                b.caddevolucion = "0";
            }
            else
            {
                worksheet.Cell("H" + cont2.ToString()).Value = (b.caddevolucion);
            }

            worksheet.Cell("I" + cont2.ToString()).Value = (Convert.ToDecimal(b.cadcantidad) - Convert.ToDecimal(b.caddevolucion)).ToString("N", CultureInfo.InvariantCulture);

            if (b.caddolares == "")
            {
                worksheet.Cell("J" + cont2.ToString()).Value = ("0.00");
                b.caddolares = "0";
            }
            else
            {
                worksheet.Cell("J" + cont2.ToString()).Value = Convert.ToDecimal(b.caddolares).ToString("N", CultureInfo.InvariantCulture);
            }

            if (b.caddevoluciondol == "")
            {
                worksheet.Cell("K" + cont2.ToString()).Value = ("0.00");
                b.caddevoluciondol = "0";
            }
            else
            {
                worksheet.Cell("K" + cont2.ToString()).Value = b.caddevoluciondol;
            }

            worksheet.Cell("L" + cont2.ToString()).Value = (Convert.ToDecimal(b.caddolares) - Convert.ToDecimal(b.caddevoluciondol)).ToString("N", CultureInfo.InvariantCulture);


            if (b.cadsoles == "")
            {
                worksheet.Cell("M" + cont2.ToString()).Value = ("0.00");
                b.cadsoles = "0";
            }
            else
            {
                worksheet.Cell("M" + cont2.ToString()).Value = Convert.ToDecimal(b.cadsoles).ToString("N", CultureInfo.InvariantCulture);
            }

            if (b.caddevolucionsol == "")
            {
                worksheet.Cell("N" + cont2.ToString()).Value = ("0.00");
                b.caddevolucionsol = "0";
            }
            else
            {
                worksheet.Cell("N" + cont2.ToString()).Value = Convert.ToDecimal((b.caddevolucionsol)).ToString("N", CultureInfo.InvariantCulture);
            }

            worksheet.Cell("o" + cont2.ToString()).Value = Convert.ToDecimal(b.cadsoles) - Convert.ToDecimal(b.caddevolucionsol);
            SUMCANT = SUMCANT + Convert.ToDecimal(b.cadcantidad);
            SUMDOL = SUMDOL + Convert.ToDecimal(b.caddolares);
            SUMMN = SUMMN + Convert.ToDecimal(b.cadsoles);
            SUMCANTD = SUMCANTD + Convert.ToDecimal(b.caddevolucion);
            SUMDOLD = SUMDOLD + Convert.ToDecimal(b.caddevoluciondol);
            SUMMND = SUMMND + Convert.ToDecimal(b.caddevolucionsol);
            cont2++;
            contprov++;
        }
        worksheet.Cell("F" + (cont2 + 1).ToString()).Value = "TOTAL";
        //dblValue.ToString("N", CultureInfo.InvariantCulture)
        worksheet.Cell("G" + (cont2 + 1).ToString()).Value = SUMCANT.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("H" + (cont2 + 1).ToString()).Value = SUMCANTD.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("I" + (cont2 + 1).ToString()).Value = (SUMCANT - SUMCANTD).ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("J" + (cont2 + 1).ToString()).Value = SUMDOL.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("K" + (cont2 + 1).ToString()).Value = SUMDOLD.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("L" + (cont2 + 1).ToString()).Value = (SUMDOL - SUMDOLD).ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("M" + (cont2 + 1).ToString()).Value = SUMMN.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("N" + (cont2 + 1).ToString()).Value = SUMMND.ToString("N", CultureInfo.InvariantCulture);
        worksheet.Cell("O" + (cont2 + 1).ToString()).Value = (SUMMN - SUMMND).ToString("N", CultureInfo.InvariantCulture);

        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"consumo.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }
        if (indicador == "PL")
        {
            List<AL0003TABL> CENTROCOSTO = new List<AL0003TABL>();
            List<FT0003LINE> VARIOS = new List<FT0003LINE>();
            CENTROCOSTO = AL0003TABL.ListarvALORESParaStockValorizado(centrocosto1, centrocosto2, "10");
            VARIOS = AL0003TABL.ListarvALORESParaLinea(varios1, varios2);
            vista_consumoccosto TABL = new vista_consumoccosto();

            TABL.annio = anio;
            TABL.mes = mes;
            TABL.CADENA = cadena;
            TABL.MOVIMIENTO = movimiento;
            TABL.CADENACCOSTO = "NINGUNO";
            foreach (AL0003TABL B in CENTROCOSTO)
            {
                TABL.CADENACCOSTO = TABL.CADENACCOSTO + "," + B.TG_CCLAVE;
            }
            TABL.TG_CCLAVE = "NINGUNO";
            foreach (FT0003LINE B in VARIOS)
            {
                TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.LI_CCODLIN;
            }
            AL0003ALMA almacen = new AL0003ALMA();
            List<vista_consumoccosto> detalle = new List<vista_consumoccosto>();

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("E4").SetValue("RESUMEN POR CENTRO DE COSTO DEL MES " + " " + mesletras + " DEL AÑO " + anio).Style.Font.SetBold(true);
            worksheet.Range("E5").SetValue("DEL GRUPO " + varios1 + " HASTA EL GRUPO " + varios2).Style.Font.SetBold(true);
            detalle = AL0003ALMA.rptconsumoes(TABL, indicador);

            contcab = contprov + 1;
            worksheet.Cell("A" + contcab.ToString()).SetValue("C. COSTO").Style.Font.SetBold(true);
            worksheet.Cell("B" + contcab.ToString()).SetValue("DESCRIPCION").Style.Font.SetBold(true);
            worksheet.Cell("E" + contcab.ToString()).SetValue("ARTICULO").Style.Font.SetBold(true);
            worksheet.Cell("F" + contcab.ToString()).SetValue("DESCRIPCION").Style.Font.SetBold(true);
            worksheet.Cell("G" + contcab.ToString()).SetValue("CANT. CONSUMO").Style.Font.SetBold(true);
            worksheet.Cell("H" + contcab.ToString()).SetValue("DEVOLUCION").Style.Font.SetBold(true);
            worksheet.Cell("I" + contcab.ToString()).SetValue("NETO").Style.Font.SetBold(true);
            worksheet.Cell("J" + contcab.ToString()).SetValue("CONSUMO US").Style.Font.SetBold(true);
            worksheet.Cell("K" + contcab.ToString()).SetValue("DEVOLUC. US").Style.Font.SetBold(true);
            worksheet.Cell("L" + contcab.ToString()).SetValue("NETO US").Style.Font.SetBold(true);
            worksheet.Cell("M" + contcab.ToString()).SetValue("CONSUMO MN").Style.Font.SetBold(true);
            worksheet.Cell("N" + contcab.ToString()).SetValue("DEVOLUC. MN").Style.Font.SetBold(true);
            worksheet.Cell("O" + contcab.ToString()).SetValue("NETO MN").Style.Font.SetBold(true);

            //worksheet.Range("A8:O8").Style.Border.BottomBorder.Equals(XLLineStyle.Single);
            foreach (vista_consumoccosto b in detalle)
            {
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.C6_CCENCOS + "");
                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.centrocosto + "");

                    worksheet.Cell("C" + contcab.ToString()).SetValue("COD.LINEA").Style.Font.SetBold(true);
                    worksheet.Cell("D" + contcab.ToString()).SetValue("LINEA").Style.Font.SetBold(true);
                    worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AR_CLINEA + "");
                    worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.linea + "");
                    worksheet.Range("E5").SetValue("DEL MODELO " + varios1 + " HASTA EL MODELO " + varios2).Style.Font.SetBold(true);
               
                worksheet.Cell("E" + cont2.ToString()).Value = ("'" + b.AR_CCODIGO + "");
                worksheet.Cell("F" + cont2.ToString()).Value = b.AR_CDESCRI;

                if (b.cadcantidad == "")
                {
                    worksheet.Cell("G" + cont2.ToString()).Value = ("0.00");
                    b.cadcantidad = "0";

                }
                else
                {
                    worksheet.Cell("G" + cont2.ToString()).Value = Convert.ToDecimal((b.cadcantidad)).ToString("N", CultureInfo.InvariantCulture); ;
                }

                if (b.caddevolucion == "")
                {
                    worksheet.Cell("H" + cont2.ToString()).Value = ("0.00");
                    b.caddevolucion = "0";
                }
                else
                {
                    worksheet.Cell("H" + cont2.ToString()).Value = (b.caddevolucion);
                }

                worksheet.Cell("I" + cont2.ToString()).Value = (Convert.ToDecimal(b.cadcantidad) - Convert.ToDecimal(b.caddevolucion)).ToString("N", CultureInfo.InvariantCulture);

                if (b.caddolares == "")
                {
                    worksheet.Cell("J" + cont2.ToString()).Value = ("0.00");
                    b.caddolares = "0";
                }
                else
                {
                    worksheet.Cell("J" + cont2.ToString()).Value = Convert.ToDecimal(b.caddolares).ToString("N", CultureInfo.InvariantCulture);
                }

                if (b.caddevoluciondol == "")
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = ("0.00");
                    b.caddevoluciondol = "0";
                }
                else
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = b.caddevoluciondol;
                }

                worksheet.Cell("L" + cont2.ToString()).Value = (Convert.ToDecimal(b.caddolares) - Convert.ToDecimal(b.caddevoluciondol)).ToString("N", CultureInfo.InvariantCulture);


                if (b.cadsoles == "")
                {
                    worksheet.Cell("M" + cont2.ToString()).Value = ("0.00");
                    b.cadsoles = "0";
                }
                else
                {
                    worksheet.Cell("M" + cont2.ToString()).Value = Convert.ToDecimal(b.cadsoles).ToString("N", CultureInfo.InvariantCulture);
                }

                if (b.caddevolucionsol == "")
                {
                    worksheet.Cell("N" + cont2.ToString()).Value = ("0.00");
                    b.caddevolucionsol = "0";
                }
                else
                {
                    worksheet.Cell("N" + cont2.ToString()).Value = Convert.ToDecimal((b.caddevolucionsol)).ToString("N", CultureInfo.InvariantCulture);
                }

                worksheet.Cell("o" + cont2.ToString()).Value = Convert.ToDecimal(b.cadsoles) - Convert.ToDecimal(b.caddevolucionsol);
                SUMCANT = SUMCANT + Convert.ToDecimal(b.cadcantidad);
                SUMDOL = SUMDOL + Convert.ToDecimal(b.caddolares);
                SUMMN = SUMMN + Convert.ToDecimal(b.cadsoles);
                SUMCANTD = SUMCANTD + Convert.ToDecimal(b.caddevolucion);
                SUMDOLD = SUMDOLD + Convert.ToDecimal(b.caddevoluciondol);
                SUMMND = SUMMND + Convert.ToDecimal(b.caddevolucionsol);
                cont2++;
                contprov++;
            }
            worksheet.Cell("F" + (cont2 + 1).ToString()).Value = "TOTAL";
            //dblValue.ToString("N", CultureInfo.InvariantCulture)
            worksheet.Cell("G" + (cont2 + 1).ToString()).Value = SUMCANT.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("H" + (cont2 + 1).ToString()).Value = SUMCANTD.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("I" + (cont2 + 1).ToString()).Value = (SUMCANT - SUMCANTD).ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("J" + (cont2 + 1).ToString()).Value = SUMDOL.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("K" + (cont2 + 1).ToString()).Value = SUMDOLD.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("L" + (cont2 + 1).ToString()).Value = (SUMDOL - SUMDOLD).ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("M" + (cont2 + 1).ToString()).Value = SUMMN.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("N" + (cont2 + 1).ToString()).Value = SUMMND.ToString("N", CultureInfo.InvariantCulture);
            worksheet.Cell("O" + (cont2 + 1).ToString()).Value = (SUMMN - SUMMND).ToString("N", CultureInfo.InvariantCulture);

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"consumo.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();
        }

    }
}