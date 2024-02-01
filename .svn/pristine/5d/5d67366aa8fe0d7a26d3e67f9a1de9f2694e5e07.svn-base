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
        string moneda = Convert.ToString(Request.QueryString["cs"]);
        string almacen = Convert.ToString(Request.QueryString["al"]);
        string foragrupa = Convert.ToString(Request.QueryString["ag"]);
        string tp = Convert.ToString(Request.QueryString["tp"]);

        var treporte = "";//tabla_parametrosbusq.UnParam_af(Convert.ToInt32(moneda), "C").PM_DESC;
        string fimpresion = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        string fec02res = string.Empty, fec01res = string.Empty;
        fec02res = Fen2.Replace("/", "");
        fec01res = Fenv.Replace("/", "");
        int ncolumnas = 0;
        
        ncolumnas = Convert.ToInt32(fec02res) - Convert.ToInt32(Fenv.Replace("/", "")) + 1;

        //string[] arraycolumna=new string[ncolumnas];
        //for (var k = 0; k < ncolumnas ; k++)
        //{
        //    arraycolumna[k] = (Convert.ToInt32(fec01res) + k).ToString().Substring(0,4)+"/" + (Convert.ToInt32(fec01res) + k).ToString().Substring(4, 2);
        //}

        var mesxt = fec02res.Substring(4, 2);
        int f = 0;
        f = (Convert.ToInt32(mesxt) - 1) == 0 ? 12 : (Convert.ToInt32(mesxt) - 1);
        fec02res = fec02res.Substring(0, 4) + f.ToString("D2");
        REntrasSalidas detalle = new REntrasSalidas();//AL0003MOVG detallesalidas = new AL0003MOVG();
        
        var reporte = "Centroconsumo.xlsx";
        HttpServerUtility server = HttpContext.Current.Server;
        string rr = server.MapPath("~") + "\\ALMACEN\\COSTEO\\" + reporte;//SERVIDOR AGREGAR \\
        var workbook = new XLWorkbook(rr);
        var worksheet = workbook.Worksheet(1);
        Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");

        var mList = (List<ListTipoIS>)Session["LTipo"];

      
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
        worksheet.Range("B2:H2").SetValue("REPORTE DE INGRESOS Y SALIDAS ("+ treporte + ") DEL :" + Fenv + " AL: " + Fen2)
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
        int cont = 8;

        midetalle(worksheet, 7);

        foreach (var tipodoc in mList) { 
        DataTable dataTableName = consulta.funEntradasSalida(foragrupa, almacen, Fenv, Fen2, prd1, prd2, tipodoc.TIPOIS, tp);
        List<REntrasSalidas> listName = dataTableName.AsEnumerable().Select(m => new REntrasSalidas()
        {
            C6_CNUMDOC = m.Field<string>("C6_CNUMDOC"),
            C6_CCODMOV = m.Field<string>("C6_CCODMOV"),
            C6_DFECDOC = m.Field<DateTime>("C6_DFECDOC"),//m.Field<double>("Balance"),String.Format("{0:dd/MM/yyyy}", p.C6_DFECDOC)
            C6_CRFTDOC = m.Field<string>("C6_CRFTDOC"),
            C6_CRFNDOC = m.Field<string>("C6_CRFNDOC"),
            C6_CCODPRO = m.Field<string>("C6_CCODPRO"),
            DESPRO = m.Field<string>("DESPRO"),
            C6_CALMA = m.Field<string>("C6_CALMA"),
            C6_CCODIGO = m.Field<string>("C6_CCODIGO"),
            AR_CDESRI = m.Field<string>("AR_CDESRI"),
            C6_NCANTID = m.Field<decimal>("C6_NCANTID"),
            C6_NMNPRUN = m.Field<decimal>("C6_NMNPRUN"),
            C6_NUSPRUN = m.Field<decimal>("C6_NUSPRUN"),
            C6_NMNIMPO = m.Field<decimal>("C6_NMNIMPO"),
            C6_NUSIMPO = m.Field<decimal>("C6_NUSIMPO"),
            C6_CCENCOS = m.Field<string>("C6_CCENCOS"),
            TG_CDESCCO = m.Field<string>("TG_CDESCCO"),
            C6_CSOLI = m.Field<string>("C6_CSOLI"),
            TG_CDESSOL = m.Field<string>("TG_CDESSOL"),
            C6_CCODMON = m.Field<string>("C6_CCODMON"),
            C6_CTIPMOV = m.Field<string>("C6_CTIPMOV"),
        }).ToList();
        foreach (var t in listName)
        {
            worksheet.Cell(cont, 1).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 1).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 1).SetValue(t.C6_CNUMDOC.Trim());

            worksheet.Cell(cont, 2).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 2).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 2).SetValue(t.C6_CCODMOV);

            worksheet.Cell(cont, 3).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 3).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 3).SetValue(String.Format("{0:dd/MM/yyyy}", t.C6_DFECDOC));

            worksheet.Cell(cont, 4).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 4).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 4).SetValue(t.C6_CRFTDOC);

            worksheet.Cell(cont, 5).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 5).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 5).SetValue(t.C6_CRFNDOC);

            worksheet.Cell(cont, 6).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 6).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 6).SetValue(t.C6_CCODPRO);

            worksheet.Cell(cont, 7).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 7).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 7).SetValue(t.DESPRO);

            worksheet.Cell(cont, 8).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 8).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 8).SetValue(t.C6_CALMA);

            worksheet.Cell(cont, 9).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 9).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 9).SetValue(t.C6_CCODIGO);

            worksheet.Cell(cont, 10).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 10).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 10).SetValue(t.AR_CDESRI);

            worksheet.Cell(cont, 11).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 11).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 11).SetValue(t.C6_NCANTID);

            worksheet.Cell(cont, 12).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 12).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 12).SetValue(moneda =="MN" ? t.C6_NMNPRUN : t.C6_NUSPRUN);

            worksheet.Cell(cont, 13).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 13).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 13).SetValue(moneda == "MN" ? t.C6_NMNIMPO : t.C6_NUSIMPO);

            worksheet.Cell(cont, 14).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 14).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 14).SetValue(t.C6_CCENCOS);

            worksheet.Cell(cont, 15).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 15).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 15).SetValue(t.C6_CSOLI);

            worksheet.Cell(cont, 16).Style.Font.FontName = "Draft 17cpi";
            worksheet.Cell(cont, 16).Style.Font.FontSize = 8;
            worksheet.Cell(cont, 16).SetValue(t.TG_CDESSOL);

            cont++;
        }

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
        worksheet.Range("A" + fila.ToString()).SetValue("NUM DOC")
        .Style.Font.SetBold(true)
        .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("B" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("B" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("B" + fila.ToString()).SetValue("COD MOV")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("C" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("C" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("C" + fila.ToString()).SetValue("FECHA DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("D" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("D" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("D" + fila.ToString()).SetValue("TIPO DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("E" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("E" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("E" + fila.ToString()).SetValue("NUM DOC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("F" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("F" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("F" + fila.ToString()).SetValue("COD PRO")
            .Style.Font.SetBold(true) 
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("G" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("G" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("G" + fila.ToString()).SetValue("DESCRIPCION")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);


        worksheet.Range("H" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("H" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("H" + fila.ToString()).SetValue("COD ALMACEN")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("I" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("I" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("I" + fila.ToString()).SetValue("COD PRODUCTO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("J" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("J" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("J" + fila.ToString()).SetValue("DESCRIPCION")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("K" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("K" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("K" + fila.ToString()).SetValue("CANTIDAD")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("L" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("L" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("L" + fila.ToString()).SetValue("PRECIO UNIT")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("M" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("M" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("M" + fila.ToString()).SetValue("IMPORTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("N" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("N" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("N" + fila.ToString()).SetValue("COD CCOSTO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("O" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("O" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("O" + fila.ToString()).SetValue("DESC CCOSTO")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("P" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("P" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("P" + fila.ToString()).SetValue("COD SOLICITANTE")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);

        worksheet.Range("Q" + fila.ToString()).Style.Font.FontName = "Draft 17cpi";
        worksheet.Range("Q" + fila.ToString()).Style.Font.FontSize = 8;
        worksheet.Range("Q" + fila.ToString()).SetValue("DESCRI SOLIC")
            .Style.Font.SetBold(true)
            .Fill.BackgroundColor = XLColor.FromArgb(192, 255, 192);
    }
}