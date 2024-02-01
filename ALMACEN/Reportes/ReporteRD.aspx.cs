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

public partial class ALMACEN_Reportes_ReporteRD : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idCTD = Convert.ToString(Request.QueryString["CTD"]);
        string idNUM = Convert.ToString(Request.QueryString["NUM"]);
        string idCOP = Convert.ToString(Request.QueryString["COP"]);

        idCTD = idCTD.Trim();
        idNUM = idNUM.Trim();
        idCOP = idCOP.Trim();

        AL0003FACC DATA = new AL0003FACC();
        DATA.LC_CTD = idCTD;
        DATA.LC_CNUMDOC = idNUM;
        DATA.LC_CCODPRV = idCOP;

        AL0003FACD DATA1 = new AL0003FACD();
        DATA1.LD_CTD = idCTD;
        DATA1.LD_CNUMDOC = idNUM;


        int cont2 = 15;
        //worksheet.PageSetup.PaperSize = XLPaperSize.A2Paper;
        AL0003FACC cabecera = new AL0003FACC();
        List<AL0003FACD> detalle = new List<AL0003FACD>();

        var reporte = "Formato3.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\Reportes\\" + reporte;//SERVIDOR AGREGAR \\

        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);


        micabecera(worksheet, 0, idNUM);
        cabecera = AL0003FACC.listar(DATA).FirstOrDefault();
        detalle = AL0003FACD.listar(DATA1);

        //CABECERA 1:
        //NUMERO DOCUMENTO
        worksheet.Range("D2:F2").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D2:F2").Style.Font.FontSize = 8;
        worksheet.Range("D2:F2").SetValue(cabecera.LC_CNOMBRE)
            .Merge()
            .Style.Font.SetBold(true);

        //DIRECCION
        worksheet.Range("D3:F3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D3:F3").Style.Font.FontSize = 8;
        worksheet.Range("D3:F3").SetValue(cabecera.LC_CDIRECC)
            .Merge()
            .Style.Font.SetBold(true);

        //FECHA DOCUMENTO
        worksheet.Range("H3:I3").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H3:I3").Style.Font.FontSize = 8;
        worksheet.Range("H3:I3").SetValue(String.Format("{0: dd 'de' MMMM 'del' yyyy}", cabecera.LC_DFECDOC))
            .Merge()
            .Style.Font.SetBold(true);

        //GLOSA
        worksheet.Range("E4:F4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E4:F4").Style.Font.FontSize = 8;
        worksheet.Range("E4:F4").SetValue(cabecera.LC_CGLOSA)
            .Merge()
            .Style.Font.SetBold(true);
        //.Alignment.SetVertical(XLAlignmentVerticalValues.Top)
        //.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        //DOCUMENTO DE IDENTIDAD
        worksheet.Range("H4").Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H4").Style.Font.FontSize = 8;
        worksheet.Range("H4").SetValue(cabecera.LC_CCODPRV.Trim())
            .Merge()
            .Style.Font.SetBold(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);

        //DETALLE
        int cont = 6;
        decimal SUBTOTAL = 0;
        decimal RETENCION = 0;
        //midetalle(worksheet, 12);
        foreach (AL0003FACD p in detalle)
        {

            //CANTIDAD RECEPCION
            worksheet.Range("A" + cont.ToString() + ":C" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("A" + cont.ToString() + ":C" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("A" + cont.ToString() + ":C" + cont.ToString()).SetValue(p.LD_NCANTID)
                .Merge()
                .Style.NumberFormat.Format = "#,##0.00";

            //CODIGO
            worksheet.Range("D" + cont.ToString() + ":E" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("D" + cont.ToString() + ":E" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("D" + cont.ToString() + ":E" + cont.ToString()).SetValue(p.LD_CCODIGO.Trim())
                .Merge()
                .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

            //DESCRIPCION
            worksheet.Range("F" + cont.ToString() + ":G" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("F" + cont.ToString() + ":G" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("F" + cont.ToString() + ":G" + cont.ToString()).SetValue(p.LD_CDESCRI)
                .Merge();

            //PRECIO
            worksheet.Range("H" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("H" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("H" + cont.ToString()).SetValue(p.LD_NPRECIO)
                 .Merge()
                 .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center)
                 .NumberFormat.Format = "#,##0.00";

            //
            worksheet.Range("I" + cont.ToString()).Style.Font.FontName = "Draft 17cpi";
            worksheet.Range("I" + cont.ToString()).Style.Font.FontSize = 8;
            worksheet.Range("I" + cont.ToString()).SetValue(p.LD_NIMPMN)
                 .Merge()
                 .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
                 .NumberFormat.Format = "#,##0.00";

            SUBTOTAL = SUBTOTAL + Convert.ToDecimal(p.LD_NIMPMN);
            RETENCION = RETENCION + Convert.ToDecimal(p.LD_NIMPRMN);
            cont++;
        }
        int co0 = 13;//cont + 7;
        int co = 15;//cont + 9;
        int co1 = co + 1;
        int co2 = co1 + 2;

        //DESCRIPCION CANTIDAD LETRAS
        worksheet.Range("D" + co0.ToString() + ":G" + co0.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + co0.ToString() + ":G" + co0.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + co0.ToString() + ":G" + co0.ToString()).SetValue(CapaNegocio.Cls_Utilidades.NumeroLetras((SUBTOTAL - RETENCION), cabecera.LC_CCODMON))
            .Merge();

        worksheet.Range("H" + co.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + co.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + co.ToString()).SetValue((cabecera.LC_CCODMON == "MN" ? "S/.   " : "US"))
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        //SUBTOTAL
        worksheet.Range("I" + co.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + co.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + co.ToString()).SetValue(SUBTOTAL)
             .Merge()
             .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
             .NumberFormat.Format = "#,##0.00";

        //DESCRIPCION RETENCION
        worksheet.Range("H" + co1.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + co1.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + co1.ToString()).SetValue((cabecera.LC_CCODMON == "MN" ? "RETENCION 1.5 S/.   " : "US"))
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("I" + co1.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + co1.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + co1.ToString()).SetValue(RETENCION)
             .Merge()
             .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
             .NumberFormat.Format = "#,##0.00";

        worksheet.Range("H" + co2.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + co2.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + co2.ToString()).SetValue((cabecera.LC_CCODMON == "MN" ? "S/.   " : "US"))
            .Merge()
            .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);

        worksheet.Range("I" + co2.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + co2.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + co2.ToString()).SetValue(SUBTOTAL - RETENCION)
             .Merge()
             .Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right)
             .NumberFormat.Format = "#,##0.00";


        //PROTEGE
        var pass = worksheet.Protect("SEA2016");
        pass.SelectLockedCells = false;
        pass.SelectUnlockedCells = false;

        var filename = "LQ" + DATA.LC_CNUMDOC.Trim() + ".xlsx";

        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=" + filename + "");
        //Response.AddHeader("content-disposition", "attachment;filename=\"Demo.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();
    }

    public void micabecera(IXLWorksheet worksheet, int fila, string idND)
    {

        var nfila = fila + 1;
        int npagina = 1;
        npagina = (nfila == 1 ? 0 : 1);
        worksheet.Range("H" + nfila.ToString() + ":I" + nfila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + nfila.ToString() + ":I" + nfila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + nfila.ToString() + ":I" + nfila.ToString()).SetValue(idND)
            .Merge()
            .Style.Font.SetBold(true)
            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
    }


}