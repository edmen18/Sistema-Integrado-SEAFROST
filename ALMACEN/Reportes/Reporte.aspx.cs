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
        string idAL = Convert.ToString(Request.QueryString["AL"]);
        string idTD = Convert.ToString(Request.QueryString["TD"]);
        string idND = Convert.ToString(Request.QueryString["ND"]);

        idAL = idAL.Trim();
        idTD = idTD.Trim();
        idND = idND.Trim();

        AL0003MOVC TABL = new AL0003MOVC();
        TABL.C5_CALMA = idAL;
        TABL.C5_CTD = idTD;
        TABL.C5_CNUMDOC = idND;


        int cont2 = 15;
        //worksheet.PageSetup.PaperSize = XLPaperSize.A2Paper;
        Principal cabecera = new Principal();
        List<Principal> detalle = new List<Principal>();

        var reporte = (idTD == "PE" ? "Formato1.xlsx" : "Formato2.xlsx");
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\Reportes\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        micabecera(worksheet, 1, idND, idTD);
        cabecera = AL0003MOVC.listaFinal(TABL).FirstOrDefault();
        detalle = AL0003MOVC.listaFinal(TABL);

        //CABECERA 1:
        worksheet.Range("A4:D4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A4:D4").Style.Font.FontSize = 8;
        worksheet.Range("A4:D4").SetValue("ALMACEN")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Column("E").Width = 0.83;
        worksheet.Range("E4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E4").Style.Font.FontSize = 8;
        worksheet.Range("E4").SetValue(":")
            .Style.Font.SetBold(true);


        worksheet.Range("S4:U4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S4:U4").Style.Font.FontSize = 8;
        worksheet.Range("S4:U4").SetValue("FECHA DOC.:")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("A5:D5").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A5:D5").Style.Font.FontSize = 8;
        worksheet.Range("A5:D5").SetValue("BAHIA")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("E5").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E5").Style.Font.FontSize = 8;
        worksheet.Range("E5").SetValue(":")
            .Style.Font.SetBold(true);

        worksheet.Range("A6:D6").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A6:D6").Style.Font.FontSize = 8;
        worksheet.Range("A6:D6").SetValue("PROVEEDOR")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("E6").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E6").Style.Font.FontSize = 8;
        worksheet.Range("E6").SetValue(":")
            .Style.Font.SetBold(true);

        worksheet.Range("A7:D7").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A7:D7").Style.Font.FontSize = 8;
        worksheet.Range("A7:D7").SetValue("NRO RUC")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("E7").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E7").Style.Font.FontSize = 8;
        worksheet.Range("E7").SetValue(":")
            .Style.Font.SetBold(true);

        worksheet.Range("A8:D8").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A8:D8").Style.Font.FontSize = 8;
        worksheet.Range("A8:D8").SetValue("EMBARCACION")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("E8").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E8").Style.Font.FontSize = 8;
        worksheet.Range("E8").SetValue(":")
            .Style.Font.SetBold(true);

        //(cabecera.C5_CGLOSA4.Trim() == "" ? cabecera.C5_CGLOSA4:"")
        worksheet.Range("S8:T8").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S8:T8").Style.Font.FontSize = 8;
        worksheet.Range("S8:T8").SetValue((cabecera.C5_CGLOSA4.Trim() != "" ? "DER:" : ""))
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("A9:D9").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A9:D9").Style.Font.FontSize = 8;
        worksheet.Range("A9:D9").SetValue("TRANSPORTE")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("E9").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E9").Style.Font.FontSize = 8;
        worksheet.Range("E9").SetValue(":")
            .Style.Font.SetBold(true);

        worksheet.Range("S9:T9").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S9:T9").Style.Font.FontSize = 8;
        worksheet.Range("S9:T9").SetValue("N°T.PESAJE:")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("A10:E10").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A10:E10").Style.Font.FontSize = 8;
        worksheet.Range("A10:E10").SetValue("CHOFER/TRANSPORTE :")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("S10:T10").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S10:T10").Style.Font.FontSize = 8;
        worksheet.Range("S10:T10").SetValue("ORIGEN:")
            .Merge()
            .Style.Font.SetBold(true);

        //cabecera = AL0003MOVC.listaFinal(TABL).FirstOrDefault();
        //detalle = AL0003MOVC.listaFinal(TABL);
        //CABECERA
        worksheet.Range("F4:P4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F4:P4").Style.Font.FontSize = 8;
        worksheet.Range("F4:P4").SetValue(cabecera.C5_CALMA + " " + cabecera.NOMAL)
            .Merge();

        worksheet.Range("V4:X4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("V4:X4").Style.Font.FontSize = 8;
        worksheet.Range("V4:X4").SetValue(cabecera.C5_DFECDOC)
            .Merge();

        worksheet.Range("F5:R5").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F5:R5").Style.Font.FontSize = 8;
        worksheet.Range("F5:R5").SetValue(cabecera.C5_CORDEN)
            .Merge();

        worksheet.Range("F6:R6").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F6:R6").Style.Font.FontSize = 8;
        worksheet.Range("F6:R6").SetValue(cabecera.C5_CNOMPRO)
            .Merge();

        worksheet.Range("F7:R7").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F7:R7").Style.Font.FontSize = 8;
        worksheet.Range("F7:R7").SetValue(cabecera.C5_CCODPRO)
            .Merge();

        worksheet.Range("F8:R8").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F8:R8").Style.Font.FontSize = 8;
        worksheet.Range("F8:R8").SetValue(cabecera.C5_CGLOSA1)
            .Merge();

        worksheet.Range("U8:W8").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("U8:W8").Style.Font.FontSize = 8;
        worksheet.Range("U8:W8").SetValue((cabecera.C5_CGLOSA4.Trim() != "" ? cabecera.C5_CGLOSA4:"")) //cabecera.C5_CNUMORD : cabecera.C5_CGLOSA4))
            .Merge();

        worksheet.Range("F9:R9").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F9:R9").Style.Font.FontSize = 8;
        worksheet.Range("F9:R9").SetValue(cabecera.C5_CGLOSA2)
            .Merge();

        worksheet.Range("U9:W9").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("U9:W9").Style.Font.FontSize = 8;
        worksheet.Range("U9:W9").SetValue(cabecera.C5_CCODFER)
            .Merge();

        worksheet.Range("F10:R10").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F10:R10").Style.Font.FontSize = 8;
        worksheet.Range("F10:R10").SetValue(cabecera.C5_CGLOSA3)
            .Merge();

        worksheet.Range("U10:X10").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("U10:X10").Style.Font.FontSize = 8;
        worksheet.Range("U10:X10").SetValue(cabecera.C5_CRFNDO2)
            .Merge();

        //DETALLE
        int cont = 13;
        decimal SUBTOTAL = 0;
        midetalle(worksheet, 12);
        foreach (Principal p in detalle)
        {

            worksheet.Range("A" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + cont.ToString()).SetValue(p.C6_CITEM)
                .Merge();

            worksheet.Range("C" + cont.ToString() + ":L" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("C" + cont.ToString() + ":L" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("C" + cont.ToString() + ":L" + cont.ToString()).SetValue(p.C6_CDESCRI)
                .Merge();

            worksheet.Range("S" + cont.ToString() + ":T" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("S" + cont.ToString() + ":T" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("S" + cont.ToString() + ":T" + cont.ToString()).SetValue(p.AR_CUNIDAD)
                .Merge();

            worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).SetValue(p.C6_NCANTID)
                 .Merge()
                 .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                 .NumberFormat.Format = "#,##0.00";

            SUBTOTAL = SUBTOTAL + Convert.ToDecimal(p.C6_NCANTID);
            cont2++;
            cont++;
            if (cont == 21)
            {
                micabecera(worksheet, 25, idND, idTD);
                midetalle(worksheet, 28);
                cont = 29;
            }


        }

        int co = cont + 4;//inicia
        int fir = co - 1;

        worksheet.Columns().Width = 3.45;
        worksheet.Rows().Height = 14.00;
        //worksheet.Rows().AdjustToContents();

        worksheet.Range("A" + (cont - 1).ToString() + ":Y" + (cont - 1).ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Thin;

        worksheet.Range("S" + cont.ToString() + ":U" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S" + cont.ToString() + ":U" + cont.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("S" + cont.ToString() + ":U" + cont.ToString()).SetValue("SUBTOTAL")
            .Merge()
            .Style.Font.SetBold(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

        worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("V" + cont.ToString() + ":X" + cont.ToString()).SetValue(SUBTOTAL)
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
            .NumberFormat.Format = "#,##0.00";

        //FIRMAS 1
        worksheet.Range("C" + fir.ToString() + ":F" + fir.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fir.ToString() + ":F" + fir.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fir.ToString() + ":F" + fir.ToString()).SetValue(cabecera.C5_CUSUCRE)
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Range("C" + co.ToString() + ":F" + co.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + co.ToString() + ":F" + co.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + co.ToString() + ":F" + co.ToString()).SetValue("RECEPCION")
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //.Style.Font.SetBold(true);

        //FIRMAS 2
        worksheet.Range("J" + fir.ToString() + ":O" + fir.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + fir.ToString() + ":O" + fir.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + fir.ToString() + ":O" + fir.ToString()).SetValue(cabecera.C5_CCODAUT)
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Range("J" + co.ToString() + ":O" + co.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + co.ToString() + ":O" + co.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + co.ToString() + ":O" + co.ToString()).SetValue("GERENTE DE PLANTA")
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //.Style.Font.SetBold(true);

        worksheet.Range("R" + co.ToString() + ":U" + co.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("R" + co.ToString() + ":U" + co.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("R" + co.ToString() + ":U" + co.ToString()).SetValue("VB°")
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //.Style.Font.SetBold(true);

        // Adding print areas
        //worksheet.PageSetup.PrintAreas.Add("A1:X" + co.ToString());

        //PROTEGE
        var pass = worksheet.Protect("SEA2016");
        pass.SelectLockedCells = false;
        pass.SelectUnlockedCells = false;

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

    public void micabecera(IXLWorksheet worksheet, int fila, string idND, string idTD)
    {
        //1:
        //worksheet.Range("A"+fila.ToString()+":E"+fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        //worksheet.Range("A" + fila.ToString() + ":E" + fila.ToString()).Style.Font.FontSize = 8;
        //worksheet.Range("A" + fila.ToString() + ":E" + fila.ToString()).SetValue("SEAFROST SAC")
        //    .Merge()
        //    .Style.Font.SetBold(true)
        //    .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        //2:
        var nfila = fila + 1;
        int npagina = 1;
        npagina = (nfila == 1 ? 0 : 1);
        worksheet.Range("I" + nfila.ToString() + ":L" + nfila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + nfila.ToString() + ":L" + nfila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + nfila.ToString() + ":L" + nfila.ToString()).SetValue((idTD == "PE" ? "NOTA DE INGRESO N°" : "NOTA DE SALIDA N°"))
            .Merge()
            .Style.Font.SetBold(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //2:
        worksheet.Range("M" + nfila.ToString() + ":P" + nfila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("M" + nfila.ToString() + ":P" + nfila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("M" + nfila.ToString() + ":P" + nfila.ToString()).SetValue(idND)
            .Merge()
            .Style.Font.SetBold(true);

        //3:
        /*worksheet.Range("T" + nfila.ToString() + ":U" + nfila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("T" + nfila.ToString() + ":U" + nfila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("T" + nfila.ToString() + ":U" + nfila.ToString()).SetValue("Pagina")
            .Merge()
            .Style.Font.SetBold(true);

        //4
        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).SetValue(fila+" de "+(fila==1?1:npagina))
            .Merge()
            .Style.Font.SetBold(true);*/
    }

    public void midetalle(IXLWorksheet worksheet, int fila)
    {
        worksheet.Range("A" + fila.ToString() + ":Y" + fila.ToString()).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
        //fila12
        worksheet.Range("A" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("A" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("A" + fila.ToString()).SetValue("ITEM")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("C" + fila.ToString() + ":L" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString() + ":L" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString() + ":L" + fila.ToString()).SetValue("DESCRIPCION")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("S" + fila.ToString() + ":T" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("S" + fila.ToString() + ":T" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("S" + fila.ToString() + ":T" + fila.ToString()).SetValue("UNIDAD")
            .Merge()
            .Style.Font.SetBold(true);

        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("V" + fila.ToString() + ":X" + fila.ToString()).SetValue("CANTIDAD")
            .Merge()
            .Style.Font.SetBold(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
    }
}