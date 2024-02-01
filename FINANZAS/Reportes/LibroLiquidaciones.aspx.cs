using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;
using ClosedXML.Excel;
using System.IO;

public partial class FINANZAS_Reportes_LibroLiquidaciones : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;
            ddlmoneda.Items.Clear();
            ddlmoneda.DataTextField = "TG_CDESCRI";
            ddlmoneda.DataValueField = "TG_CCLAVE";
            ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlmoneda.DataBind();

            CT0003AGEN TABL1 = new CT0003AGEN();
            ddlagencia.Items.Clear();
            ddlagencia.DataTextField = "AG_CNOMAGE";
            ddlagencia.DataValueField = "AG_CCODAGE";
            ddlagencia.DataSource = CT0003AGEN.ListarAgencia();
            ddlagencia.DataBind();


        }
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        decimal importe = 0;
        decimal igv = 0;
        decimal retencion = 0;
        decimal saldo = 0;

      
        int cont2 = 9;
        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("LIBRO DE LIQUIDACIONES DE COMPRAS ").Style.Font.SetBold(true);
        worksheet.Range("C4:J4").Row(1).Merge();
        worksheet.Range("C4:J4").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
        worksheet.Range("C5").SetValue("PERIODO: " + txtannio.Text + " - " + ddlmes.SelectedItem).Style.Font.SetBold(true);
        worksheet.Range("C5:J5").Row(1).Merge();
        worksheet.Range("C5:J5").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

        worksheet.Cell("A7").SetValue("AGENCIA").Style.Font.SetBold(true);
        worksheet.Cell("A7").SetValue("AGENCIA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("B7").SetValue("TD").Style.Font.SetBold(true);
        worksheet.Cell("B7").SetValue("TD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("C7").SetValue("NUM.LIQUID").Style.Font.SetBold(true);
        worksheet.Cell("C7").SetValue("NUM.LIQUID").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("D7").SetValue("FECHA DOC").Style.Font.SetBold(true);
        worksheet.Cell("D7").SetValue("FECHA DOC").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("E7").SetValue("RAZON SOCIAL").Style.Font.SetBold(true);
        worksheet.Cell("E7").SetValue("RAZON SOCIAL").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("F7").SetValue("R.U.C.").Style.Font.SetBold(true);
        worksheet.Cell("F7").SetValue("R.U.C.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("G7").SetValue("BASE IMPONIBLE").Style.Font.SetBold(true);
        worksheet.Cell("G7").SetValue("BASE IMPONIBLE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("H7").SetValue("IGV").Style.Font.SetBold(true);
        worksheet.Cell("H7").SetValue("I.G.V.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("I7").SetValue("RETEN.IR.1.5%").Style.Font.SetBold(true);
        worksheet.Cell("I7").SetValue("RETEN.IR.1.5% ").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        worksheet.Cell("J7").SetValue("TOTAL").Style.Font.SetBold(true);
        worksheet.Cell("J7").SetValue("TOTAL").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("K7").SetValue("COMPROBANTE").Style.Font.SetBold(true);
        worksheet.Cell("K7").SetValue("COMPROBANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("L7").SetValue("ESTADO").Style.Font.SetBold(true);
        worksheet.Cell("L7").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Cell("M7").SetValue("TIPO OPER.").Style.Font.SetBold(true);
        worksheet.Cell("M7").SetValue("TIPO OPER.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

        AL0003FACC CABECERA = new AL0003FACC();
        //List<AL0003FACC> TABLA = new List<AL0003FACC>();
         List<AL0003FACC> detalle = new List<AL0003FACC>();


       


        CABECERA.LC_CCODAGE = ddlagencia.Text;
        CABECERA.LC_CCODMON = ddlmoneda.Text;
        CABECERA.LC_CNUMDOC = ddlmes.Text;
        CABECERA.LC_CTD = txtannio.Text;

        detalle = AL0003FACC.LibroLiquidacion(CABECERA);

        foreach (AL0003FACC b in detalle)
            {
                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.LC_CCODAGE + "");
                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.LC_CTD + "");
                    worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.LC_CNUMDOC + "");
                    worksheet.Cell("D" + cont2.ToString()).Value = b.LC_DFECDOC;
                    worksheet.Cell("E" + cont2.ToString()).Value = (b.LC_CNOMBRE);
                    worksheet.Cell("F" + cont2.ToString()).Value = b.LC_CCODPRV;
                   
                    worksheet.Cell("K" + cont2.ToString()).Value = ("'" + b.LC_CCOMPRO + "");
            if (b.LC_CESTADO.Trim()=="V")
            {
                worksheet.Cell("L" + cont2.ToString()).Value = ("VIGENTE");
                worksheet.Cell("G" + cont2.ToString()).Value = b.LC_NIMPORT;
                worksheet.Cell("H" + cont2.ToString()).Value = b.LC_NIMPIGV;
                worksheet.Cell("I" + cont2.ToString()).Value = b.LC_NIMPRET;
                worksheet.Cell("J" + cont2.ToString()).Value = b.LC_NSALDO;
            }
            else
            {
                worksheet.Cell("L" + cont2.ToString()).Value = ("ANULADO");
                worksheet.Cell("G" + cont2.ToString()).Value = "0.00";
                worksheet.Cell("H" + cont2.ToString()).Value = "0.00";
                worksheet.Cell("I" + cont2.ToString()).Value = "0.00";
                worksheet.Cell("J" + cont2.ToString()).Value = "0.00";
            }
                 
            worksheet.Cell("M" + cont2.ToString()).Value = ("XXXX - ");
            importe = importe + Convert.ToDecimal(b.LC_NIMPORT);
            igv = igv + b.LC_NIMPIGV;
            retencion = retencion + b.LC_NIMPRET;
            saldo = saldo + b.LC_NSALDO;


            worksheet.Cell("H" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("I" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("J" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

            cont2++;               
            }
        worksheet.Cell("F" + cont2.ToString()).Value = "TOTAL";
        worksheet.Cell("G" + cont2.ToString()).Value = importe;
        worksheet.Cell("H" + cont2.ToString()).Value = igv;
        worksheet.Cell("I" + cont2.ToString()).Value = retencion;
        worksheet.Cell("J" + cont2.ToString()).Value = saldo;
        worksheet.Cell("H" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
        worksheet.Cell("I" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
        worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
        worksheet.Cell("J" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

        worksheet.Column(1).Width = 10;
        worksheet.Column(2).Width = 5;
        worksheet.Column(3).Width = 15;
        worksheet.Column(4).Width = 10;
        worksheet.Column(5).Width = 40;
        worksheet.Column(6).Width = 10;
        worksheet.Column(7).Width = 10;
        worksheet.Column(8).Width = 10;
        worksheet.Column(9).Width = 10;
        worksheet.Column(10).Width = 10;
        worksheet.Column(11).Width = 10;
        worksheet.Column(12).Width = 10;
        worksheet.Column(13).Width = 10;

        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"LIBRO_LQ.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();

    }

    
  }