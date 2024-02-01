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

public partial class ALMACEN_REPORTES_stocvalorizado_SVEXCELDETALLADO : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {


       
        string articulo1 = Convert.ToString(Request.QueryString["articulo1"]);
        string articulo2 = Convert.ToString(Request.QueryString["articulo2"]);
        string periodo = Convert.ToString(Request.QueryString["PERIODO"]);
        string moneda = Convert.ToString(Request.QueryString["MONEDA"]);
        string codigo = Convert.ToString(Request.QueryString["CODIGO"]);
        string indicador = Request.QueryString["indicador"];
        string mes = Request.QueryString["MES"];
        string annio = Request.QueryString["ANNIO"];
        string mesletras = "";
        if (mes == "1")
        {
            mesletras = "ENERO";
        }
        if (mes == "2")
        {
            mesletras = "FEBRERO";
        }
        if (mes == "3")
        {
            mesletras = "MARZO";
        }
        if (mes == "4")
        {
            mesletras = "ABRIL";
        }
        if (mes == "5")
        {
            mesletras = "MAYO";
        }
        if (mes == "6")
        {
            mesletras = "JUNIO";
        }
        if (mes == "7")
        {
            mesletras = "JULIO";
        }
        if (mes == "8")
        {
            mesletras = "AGOSTO";
        }
        if (mes == "9")
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
        vista_stockvalorizado TABL = new vista_stockvalorizado();
        decimal SUMTOTAL = 0;
        decimal SUMART = 0;
        decimal SUMTOTALG = 0;
        decimal SUMARTG = 0;

        // CUANDO ES POR ARTICULO
        if (indicador == "PA")
        {
            List<AL0003ARTI> LISTART = new List<AL0003ARTI>();
            LISTART = AL0003ARTI.ListarArticulosParaStockValorizado(articulo1, articulo2);
            TABL.TG_CCLAVE = "NINGUNO";
            foreach (AL0003ARTI B in LISTART)
            {
                TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.AR_CCODIGO;
            }

           
            TABL.SA_CMESPRO = periodo;
            TABL.AR_CMONVTA = moneda;

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            int cont = 9;
            int cont3 = 9;
            int cont4 = 9;
            int contgrupo = 7;
            int contcab = 0;
            int contdetalle = 9;

            AL0003ALMA almac = new AL0003ALMA();
            List<vista_stockvalorizado> detalle = new List<vista_stockvalorizado>();
            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("B4").SetValue("STOCKS POR ALMACEN A COSTO PROMEDIO/ALMACEN AL MES " + mesletras + "DEL" + annio).Style.Font.SetBold(true);
            worksheet.Range("B5").SetValue("ORDEN: POR ATICULO").Style.Font.SetBold(true);

            if (TABL.AR_CMONVTA.Trim() == "MN")
            {
                worksheet.Range("B7").SetValue("MONEDA NACIONAL S/.").Style.Font.SetBold(true);
            }
            else
            {
                worksheet.Range("B7").SetValue("DOLARES US$.").Style.Font.SetBold(true);
            }

            worksheet.Range("C4:J4").Row(1).Merge();

            detalle = AL0003ALMA.RptSVPORALMACENPORCADAUNO(TABL,codigo);

            cont = 9;
            contcab = contgrupo + 1;
                 worksheet.Range("C" + contgrupo.ToString() + ":J" + contgrupo.ToString()).Row(1).Merge();

            worksheet.Cell("A" + contcab.ToString()).SetValue("ARTICULO").Style.Font.SetBold(true);
            worksheet.Cell("B" + contcab.ToString()).SetValue("DESCRIPCION").Style.Font.SetBold(true);
            worksheet.Cell("C" + contcab.ToString()).SetValue("UNIDAD").Style.Font.SetBold(true);
            worksheet.Cell("D" + contcab.ToString()).SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("E" + contcab.ToString()).SetValue("PRECIO UNITARIO").Style.Font.SetBold(true);
            worksheet.Cell("F" + contcab.ToString()).SetValue("TOTAL").Style.Font.SetBold(true);
            foreach (AL0003ARTI a in LISTART)
            {

                foreach (vista_stockvalorizado b in detalle)
                {
                    if (a.AR_CCODIGO == b.AR_CCODIGO)
                    {
                        worksheet.Cell("A" + contdetalle.ToString()).Value = ("'" + b.AR_CCODIGO + "");
                        worksheet.Cell("B" + contdetalle.ToString()).Value = ("'" + b.AR_CDESCRI + "");
                        worksheet.Cell("C" + contdetalle.ToString()).Value = b.AR_CUNIDAD;
                        worksheet.Cell("D" + contdetalle.ToString()).Value = b.SA_NCANACT;

                        if (b.AR_CMONVTA.Trim() == "MN")
                        {
                            worksheet.Cell("E" + contdetalle.ToString()).Value = b.PRECIOSOLES;
                            worksheet.Cell("F" + contdetalle.ToString()).Value = (b.PRECIOSOLES * b.SA_NCANACT);
                            SUMTOTAL = SUMTOTAL + (b.PRECIOSOLES * b.SA_NCANACT);

                        }
                        else
                        {
                            worksheet.Cell("E" + contdetalle.ToString()).Value = b.PRECIODOLARES;
                            worksheet.Cell("F" + contdetalle.ToString()).Value = (b.PRECIODOLARES * b.SA_NCANACT);
                        }

                        cont++;
                        contdetalle++;
                        contgrupo++;
                    }

                }

            }
            worksheet.Cell("F" + (contdetalle + 1).ToString()).Value = SUMTOTAL;
            worksheet.Cell("E" + (contdetalle + 1).ToString()).Value = "Total s/.";

            if (cont3 == 9)
            {
                cont4 = cont3;
                cont3 = 0;
            }
            else
            {
                cont4 = contdetalle - cont + 9;
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

        // CUANDO ES POR OTRAS OPCIONES QUE NO SEA ARTICULO


        if (indicador != "PA")
        {
            List<AL0003TABL> LISTART = new List<AL0003TABL>();
            List<vista_stockvalorizado> articulos = new List<vista_stockvalorizado>();
            LISTART = AL0003TABL.ListarvALORESParaStockValorizado(articulo1, articulo2, codigo);
            TABL.TG_CCLAVE = "NINGUNO";
            foreach (AL0003TABL B in LISTART)
            {
                TABL.TG_CCLAVE = TABL.TG_CCLAVE + "," + B.TG_CCLAVE;
            }

            TABL.SA_CMESPRO = periodo;
            TABL.AR_CMONVTA = moneda;

            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            int contgrupo = 8;
            int contcab = 7;
            int contdetalle = 10;
            int contarticulo = 9;
            int bandera = 0;
            int bandera1 = 0;
            string anterior = "";
            int rept = 0;
                       
            AL0003ALMA almac = new AL0003ALMA();
            List<vista_stockvalorizado> detalle = new List<vista_stockvalorizado>();
            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("B4").SetValue("STOCKS POR ALMACEN A COSTO PROMEDIO/ALMACEN AL MES " + mesletras + "DEL" + annio).Style.Font.SetBold(true);
            //worksheet.Range("C" + contgrupo.ToString() + ":J" + contgrupo.ToString()).Row(1).Merge();

            if (TABL.AR_CMONVTA.Trim() == "MN")
            {
                worksheet.Range("B5").SetValue("MONEDA NACIONAL S/.").Style.Font.SetBold(true);
            }
            else
            {
                worksheet.Range("B5").SetValue("DOLARES US$.").Style.Font.SetBold(true);
            }

            worksheet.Range("C4:J4").Row(1).Merge();

            detalle = AL0003ALMA.RptSVDETALLADO1X1(TABL, codigo);
            worksheet.Cell("A" + contcab.ToString()).SetValue("CODIGO").Style.Font.SetBold(true);
            worksheet.Cell("B" + contcab.ToString()).SetValue("ALMACEN").Style.Font.SetBold(true);
            worksheet.Cell("C" + contcab.ToString()).SetValue("UNIDAD").Style.Font.SetBold(true);
            worksheet.Cell("D" + contcab.ToString()).SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("E" + contcab.ToString()).SetValue("PRECIO UNITARIO").Style.Font.SetBold(true);
            worksheet.Cell("F" + contcab.ToString()).SetValue("TOTAL").Style.Font.SetBold(true);
            foreach (AL0003TABL a in LISTART)
            {
                if (indicador == "TF")
                {
                    
                    foreach (vista_stockvalorizado b in detalle)
                    {
                        if (a.TG_CCLAVE.Trim() == b.AR_CFAMILI.Trim())
                        {   
                            if (anterior.Trim() != b.AR_CFAMILI.Trim())
                            {
                                worksheet.Cell("B" + (contgrupo).ToString()).Value = ("'" + a.TG_CDESCRI + "");
                                worksheet.Cell("A" + (contgrupo).ToString()).Value = ("FAMILIA:  " + "'" + a.TG_CCLAVE + "");
                                rept = 1;
                            }
                            
                            foreach (vista_stockvalorizado c in detalle)
                            {
                                if (c.AR_CCODIGO.Trim() == b.AR_CCODIGO.Trim())
                                {
                                worksheet.Cell("A" + contarticulo.ToString()).Value = ("ARTICULO: "+"'" + b.AR_CCODIGO + "");
                                worksheet.Cell("B" + contarticulo.ToString()).Value = ("'" + b.AR_CDESCRI + "");

                                worksheet.Cell("A" + contdetalle.ToString()).Value = ("'" + b.SA_CALMA + "");
                                worksheet.Cell("B" + contdetalle.ToString()).Value = ("'" + b.almacen + "");
                                worksheet.Cell("C" + contdetalle.ToString()).Value = b.AR_CUNIDAD;
                                worksheet.Cell("D" + contdetalle.ToString()).Value = b.SA_NCANACT;

                                if (b.AR_CMONVTA.Trim() == "MN")
                                {
                                    worksheet.Cell("E" + contdetalle.ToString()).Value = b.PRECIOSOLES;
                                    worksheet.Cell("F" + contdetalle.ToString()).Value = (b.PRECIOSOLES * b.SA_NCANACT);
                                    SUMTOTAL = SUMTOTAL + (b.PRECIOSOLES * b.SA_NCANACT);
                                    SUMART = SUMART + b.SA_NCANACT;
                                    SUMTOTALG = SUMTOTALG + (b.PRECIOSOLES * b.SA_NCANACT);
                                    SUMARTG = SUMARTG + b.SA_NCANACT;
                                }
                                else
                                {
                                    worksheet.Cell("E" + contdetalle.ToString()).Value = b.PRECIODOLARES;
                                    worksheet.Cell("F" + contdetalle.ToString()).Value = (b.PRECIODOLARES * b.SA_NCANACT);
                                    SUMTOTAL = SUMTOTAL + (b.PRECIODOLARES * b.SA_NCANACT);
                                    SUMART = SUMART + b.SA_NCANACT;
                                    SUMTOTALG = SUMTOTALG + (b.PRECIODOLARES * b.SA_NCANACT);
                                    SUMARTG = SUMARTG + b.SA_NCANACT;
                                }
                                    bandera1 = bandera1 + 1;
                                    if (rept == 1)
                                    {
                                        contdetalle++;
                                    }
                                 }


                                if (bandera1 > 0)
                                {
                                    if (rept == 1)
                                    {
                                        contdetalle++;
                                    }
                                    bandera1 = 0;
                                  }

                            }
                           
                            bandera = bandera + 1;

                            }
                        if (bandera > 0)
                        {
                            if (rept==1)
                            {
                                worksheet.Cell("B" + (contdetalle).ToString()).Value = "Total";
                                worksheet.Cell("D" + (contdetalle).ToString()).Value = SUMARTG;
                                worksheet.Cell("F" + (contdetalle).ToString()).Value = SUMTOTALG;
                                SUMARTG = 0;
                                SUMTOTALG = 0;

                                contgrupo = contdetalle + 1;
                                contarticulo = contgrupo + 1;
                                contdetalle = contarticulo + 1;
                            }
                            else {
                                contarticulo = contdetalle + 1;
                                contdetalle = contarticulo + 1;
                                 }
                            rept = 0;
                            bandera = 0;
                          }
                        rept = 0;
                        anterior = b.AR_CFAMILI.Trim();
                                               
                    }
                   
                }
               // inicio de los ifs


                // fin de los ifs


            }
            worksheet.Cell("B" + (contdetalle + 1).ToString()).Value = "Total General";
            worksheet.Cell("D" + (contdetalle + 1).ToString()).Value = SUMART;
            worksheet.Cell("F" + (contdetalle + 1).ToString()).Value = SUMTOTAL;
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"Stock_Valorizado.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();
        }


    }
}