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

        string fimpresion = "";// DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        string fec02res = string.Empty;
        fec02res = Fen2.Replace("/", "");
        var mesxt = fec02res.Substring(4, 2);
        int f = 0;
        f = (Convert.ToInt32(mesxt) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt) - 1);
        fec02res = fec02res.Substring(0, 4) + f.ToString("D2");


        string fec01res = string.Empty;
        fec01res = Fenv.Replace("/", "");
        var mesxt1 = fec01res.Substring(4, 2);
        int f1 = 0;
        f1 = (Convert.ToInt32(mesxt1) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt1) - 1);
        fec01res = ((Convert.ToInt32(mesxt1)) == 1 ? Convert.ToString(Convert.ToUInt64(fec01res.Substring(0, 4)) - 1) : fec01res.Substring(0, 4)) + f1.ToString("D2");

        //List<VISTA_KARDEVAL> detalle = new List<VISTA_KARDEVAL>();


        var reporte = "KardexVal.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\

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


        worksheet.Cell(1, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(1, 4).Style.Font.FontSize = 8;
        worksheet.Cell(1, 4).SetValue("REGISTRO DE INVENTARIO PERMANENTE VALORIZADO - DETALLLE DEL INVENTARIO VALORIZADO")
        //.Merge()
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

        //worksheet.Range("F3:H3").Style.Font.FontName = "Draft 17cpi";
        //worksheet.Range("F3:H3").Style.Font.FontSize = 8;
        //worksheet.Range("F3:H3").SetValue("MONEDA:" + (moneda == "MN" ? "MONEDA NACIONAL" : "DOLARES"))
        //.Merge()
        //.Style.Font.SetBold(true);

        //DETALLE
        int cont = 10;

        string finicio = "", ffina = "", diax = "";
        finicio = "01/" + Fenv.Substring(5, 2) + "/" + Fenv.Substring(0, 4);
        diax = DateTime.DaysInMonth(Convert.ToInt32(Fen2.Substring(0, 4)), Convert.ToInt32(Fen2.Substring(5, 2))).ToString("D2");
        ffina = diax + "/" + Fen2.Substring(5, 2) + "/" + Fen2.Substring(0, 4);


        DateTime fin = Convert.ToDateTime(finicio);
        DateTime ffn = Convert.ToDateTime(ffina);

        Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
        DataTable dataTableName = consulta.funKardexVal(finicio, ffina, prd1, prd2, moneda);

        List<RKardex> detalle = dataTableName.AsEnumerable().Select(m => new RKardex()
        {
            C6_CCODIGO = m.Field<string>("C6_CCODIGO"),
            C6_DFECDOC = m.Field<string>("C6_DFECDOC"),
            C6_CTD = m.Field<string>("C6_CTD"),
            C6_CCODMOV = m.Field<string>("C6_CCODMOV"),
            C6_CALMA = m.Field<string>("C6_CALMA"),
            C6_CNUMDOC = m.Field<string>("C6_CNUMDOC"),
            C6_CRFNDOC = m.Field<string>("C6_CRFNDOC"),
            C6_CCODPRO = m.Field<string>("C6_CCODPRO"),
            MONEDA = m.Field<decimal>("MONEDA"),
            C6_NCANTIN = m.Field<decimal>("C6_NCANTIN"),
            MONTOING = m.Field<decimal>("MONTOING"),
            C6_NCANTSA = m.Field<decimal>("C6_NCANTSA"),
            MONTOSAL = m.Field<decimal>("MONTOSAL"),
            C6_CGLOSA = m.Field<string>("C6_CGLOSA"),
            VL_NACTCAN = m.Field<decimal>("VL_NACTCAN"),
            VL_NACVL = m.Field<decimal>("VL_NACVL"),
            INDICA = m.Field<string>("INDICA"),
            MONEDAING = m.Field<decimal>("MONEDAING"),
            MONEDASAL = m.Field<decimal>("MONEDASAL"),
            //DESCRUB = m.Field<string>("DESCRUB"),
        }).ToList();

        string Mletra = AL0003MOVG.Mesletras(Convert.ToInt32(Fenv.Substring(5, 2)));
        Mletra += "-" + Fenv.Substring(0, 4);
        //detalle = (AL0003MOVG.DetalleMovg(Fenv, Fen2, t.AR_CCODIGO));

        int cuentadet = 0, nregistro = 0;
        decimal totaingreso = 0, totasalida = 0, totalimnus = 0, totalsmnus = 0;
        int totalregist = detalle.Count;
        int limite = 90, contadorlim = 8;
        CabeceraHoja(worksheet, cont, Mletra);
        foreach (var p in detalle)
        {
            nregistro++;
            if (p.INDICA == "0")
            {
                //midetalle(worksheet, cont + 1, Mletra, p.C6_CCODIGO, p.C6_CTD, p.C6_CCODMOV, p.C6_CALMA, cuentadet, totaingreso, totalimnus, totasalida, totalsmnus);
                //cont += +13;
                //contadorlim += +13;
                if (cuentadet == 1)
                {
                    worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
                    worksheet.Cell(cont, 1).SetValue("TOTAL DE MOVIMIENTO");

                    worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
                    worksheet.Cell(cont, 6).SetValue(totaingreso);

                    worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
                    worksheet.Cell(cont, 8).SetValue(totalimnus);

                    worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
                    worksheet.Cell(cont, 9).SetValue(totasalida);

                    worksheet.Cell(cont, 11).Style.Font.FontName = "Draft 17cpi";
                    worksheet.Cell(cont, 11).Style.Font.FontSize = 8;
                    worksheet.Cell(cont, 11).SetValue(totalsmnus);

                    totaingreso = 0; totalimnus = 0; totasalida = 0; totalsmnus = 0;
                    cont++;
                    contadorlim++;
                }
                else
                {
                    contadorlim++;
                }


            }

            if (contadorlim >= limite)
            {
                CabeceraHoja(worksheet, cont + 8, Mletra);
                cont += +8;
                contadorlim = 8;
            }
            else
            {
                contadorlim++;
            }
            // worksheet.Range("A" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue( p.C6_DFECDOC);

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(p.C6_CTD);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(p.C6_CALMA);

            worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 4).SetValue(p.C6_CNUMDOC);

            worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 5).SetValue(p.C6_CCODMOV);

            totaingreso += p.C6_NCANTIN;
            worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 6).SetValue(p.C6_NCANTIN);

            worksheet.Cell(cont, 7).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 7).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 7).SetValue(p.MONEDAING);

            worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 8).SetValue(p.MONTOING);
            totalimnus += p.MONTOING;


            totasalida += p.C6_NCANTSA;
            worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 9).SetValue(p.C6_NCANTSA);

            worksheet.Cell(cont, 10).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 10).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 10).SetValue(p.MONEDASAL);

            worksheet.Cell(cont, 11).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 11).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 11).SetValue(p.MONTOSAL);
            totalsmnus += p.MONTOSAL;

            worksheet.Cell(cont, 12).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 12).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 12).SetValue(p.VL_NACTCAN);

            worksheet.Cell(cont, 13).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 13).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 13).SetValue(p.MONEDA);

            worksheet.Cell(cont, 14).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 14).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 14).SetValue(p.VL_NACVL);

            cont++;

            cuentadet = 1;
            //}

            if (totalregist == nregistro)
            {
                worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 1).SetValue("TOTAL DE MOVIMIENTO");

                worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 6).SetValue(totaingreso);

                worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 8).SetValue(totalimnus);

                worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 9).SetValue(totasalida);

                worksheet.Cell(cont, 11).Style.Font.FontName = "Draft 17cpi";
                worksheet.Cell(cont, 11).Style.Font.FontSize = 8;
                worksheet.Cell(cont, 11).SetValue(totalsmnus);
            }

        }


        //}
        worksheet.Columns(5, 14).AdjustToContents();
        worksheet.PageSetup.AdjustTo(55);
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


    public void midetalle(IXLWorksheet worksheet, int fila, string mesletra, string codp, string descp, string cunid, string tip10, int cuentadet, decimal totaingreso, decimal totalimnus, decimal totasalida, decimal totalsmnus)
    {   //fila3

        // worksheet.Range("A" + (fila - 1).ToString() + ":O" + (fila + 1).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        worksheet.Cell(fila + 1, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 1, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 1, 1).SetValue("PERIODO:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 1, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 1, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 1, 4).SetValue(mesletra)
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 2, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 2, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 2, 1).SetValue("RUC:")
        .Style.Font.SetBold(true);
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 2, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 2, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 2, 4).SetValue("20356922311")
        .Style.Font.SetBold(true);

        worksheet.Cell(fila + 3, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 3, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 3, 1).SetValue("RAZON SOCIAL:")
        .Style.Font.SetBold(true);
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 3, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 3, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 3, 4).SetValue("SEAFROST SAC")
        .Style.Font.SetBold(true);

        //worksheet.Cell(fila + 4, 1).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila + 4, 1).Style.Font.FontSize = 8;
        //worksheet.Cell(fila + 4, 1).SetValue("ESTABLECIMIENTO")
        //.Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 4, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 4, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 4, 1).SetValue("CODIGO EXISTENCIA:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 4, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 4, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 4, 4).SetValue(codp)
        .Style.Font.SetBold(true);

        worksheet.Cell(fila + 5, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 5, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 5, 1).SetValue("TIPO:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 5, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 5, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 5, 4).SetValue(tip10)
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


        worksheet.Cell(fila + 6, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 6, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 6, 1).SetValue("DESCRIPCION:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 6, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 6, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 6, 4).SetValue(descp)
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


        worksheet.Cell(fila + 7, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 7, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 7, 1).SetValue("CODIGO DE UNIDAD:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 7, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 7, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 7, 4).SetValue(cunid)
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


        worksheet.Cell(fila + 8, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 8, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 8, 1).SetValue("METODO VALUACION:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila + 8, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 8, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 8, 4).SetValue("PROMEDIO PONDERADO")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);


        worksheet.Cell(fila + 11, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 1).SetValue("FECHA")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192)
        ;

        worksheet.Cell(fila + 11, 2).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 2).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 2).SetValue("TIPO")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila + 11, 3).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 3).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 3).SetValue("SERIE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
        //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Cell(fila + 11, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 4).SetValue("NRO DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila + 11, 5).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 5).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 5).SetValue("TM")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        //worksheet.Cell(fila + 1, 6).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila + 1, 6).Style.Font.FontSize = 8;
        //worksheet.Cell(fila + 1, 6).SetValue("DOC REF.") 
        //    .Style.Font.SetBold(true)
        //    .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        //worksheet.Cell(fila + 1, 7).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Cell(fila + 1, 7).Style.Font.FontSize = 8;
        //worksheet.Cell(fila + 1, 7).SetValue("PROVEEDOR / CLIENTE")
        //    .Style.Font.SetBold(true)
        //    .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);



        worksheet.Cell(fila + 10, 7).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 10, 7).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 10, 7).SetValue("ENTRADAS")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila + 11, 6).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 6).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 6).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila + 11, 7).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 7).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 7).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila + 11, 8).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 8).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 8).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila + 10, 10).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 10, 10).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 10, 10).SetValue("SALIDA")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila + 11, 9).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 9).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 9).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila + 11, 10).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 10).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 10).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila + 11, 11).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 11).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 11).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila + 10, 13).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 10, 13).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 10, 13).SetValue("SALDO FINAL")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
       .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila + 11, 12).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 12).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 12).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila + 11, 13).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 13).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 13).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila + 11, 14).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila + 11, 14).Style.Font.FontSize = 8;
        worksheet.Cell(fila + 11, 14).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);


        if (cuentadet == 1)
        {
            worksheet.Cell(fila - 1, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, 1).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, 1).SetValue("TOTAL DE MOVIMIENTO");

            worksheet.Cell(fila - 1, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, 6).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, 6).SetValue(totaingreso);

            worksheet.Cell(fila - 1, 8).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, 8).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, 8).SetValue(totalimnus);

            worksheet.Cell(fila - 1, 9).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, 9).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, 9).SetValue(totasalida);

            worksheet.Cell(fila - 1, 11).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(fila - 1, 11).Style.Font.FontSize = 8;
            worksheet.Cell(fila - 1, 11).SetValue(totalsmnus);

        }
    }

    public void CabeceraHoja(IXLWorksheet worksheet, int fila, string mesletra)
    {

        worksheet.Cell(fila - 7, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 7, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 7, 1).SetValue("PERIODO:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila - 7, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 7, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 7, 4).SetValue(mesletra)
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila - 6, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 6, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 6, 1).SetValue("RUC:")
        .Style.Font.SetBold(true);
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila - 6, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 6, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 6, 4).SetValue("20356922311")
        .Style.Font.SetBold(true);

        worksheet.Cell(fila - 5, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 5, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 5, 1).SetValue("RAZON SOCIAL:")
        .Style.Font.SetBold(true);
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila - 5, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 5, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 5, 4).SetValue("SEAFROST SAC")
        .Style.Font.SetBold(true);


        worksheet.Cell(fila - 4, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 4, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 4, 1).SetValue("METODO VALUACION:")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell(fila - 4, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 4, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 4, 4).SetValue("PROMEDIO PONDERADO")
        .Style.Font.SetBold(true)
        ;//.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);





        worksheet.Cell(fila - 1, 1).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 1).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 1).SetValue("FECHA")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192)
        ;

        worksheet.Cell(fila - 1, 2).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 2).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 2).SetValue("TIPO")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 1, 3).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 3).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 3).SetValue("SERIE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
        //  .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Cell(fila - 1, 4).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 4).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 4).SetValue("NRO DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 1, 5).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 5).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 5).SetValue("TM")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 2, 7).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 2, 7).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 2, 7).SetValue("ENTRADAS")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila - 1, 6).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 6).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 6).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila - 1, 7).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 7).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 7).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila - 1, 8).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 8).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 8).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 255);

        worksheet.Cell(fila - 2, 10).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 2, 10).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 2, 10).SetValue("SALIDA")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila - 1, 9).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 9).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 9).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila - 1, 10).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 10).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 10).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila - 1, 11).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 11).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 11).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(255, 255, 192);

        worksheet.Cell(fila - 2, 13).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 2, 13).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 2, 13).SetValue("SALDO FINAL")
        .Style.Font.SetBold(true)
        .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
       .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 1, 12).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 12).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 12).SetValue("CANTIDAD")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 1, 13).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 13).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 13).SetValue("CU")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Cell(fila - 1, 14).Style.Font.FontName = "Draft 17cpi";
        worksheet.Cell(fila - 1, 14).Style.Font.FontSize = 8;
        worksheet.Cell(fila - 1, 14).SetValue("COSTO TOTAL")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
    }


}