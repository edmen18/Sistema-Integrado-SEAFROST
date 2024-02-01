using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using ClosedXML.Excel;
using System.IO;
using CapaNegocio;


public partial class FINANZAS_Reportes_ComprasPendientesLiq : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            AL0003ALMA TABL = new AL0003ALMA();
            ddlalmacen.Items.Clear();
            ddlalmacen.DataTextField = "A1_CDESCRI";
            ddlalmacen.DataValueField = "A1_CALMA";
            ddlalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalmacen.DataBind();
        }
       
        
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    protected void btnexcel_Click(object sender, EventArgs e)
    {
         if (this.rbdetallado.Checked==true)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            int contcab = 8;
            int cont2 = 9;
            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("C4").SetValue("Reporte Detallado de Ordenes de Compra Pendientes de Liquidación").Style.Font.SetBold(true);
            worksheet.Range("C4:J4").Row(1).Merge();
            worksheet.Range("C5").SetValue("DEL: " + Txtfinicial.Text + " AL: " + txtffinal.Text).Style.Font.SetBold(true);
            worksheet.Range("C5:J5").Row(1).Merge();

            worksheet.Cell("B7").SetValue("ALMACEN").Style.Font.SetBold(true);
            worksheet.Cell("B7").SetValue("ALMACEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("C7").SetValue("CÓDIGO").Style.Font.SetBold(true);
            worksheet.Cell("C7").SetValue("CÓDIGO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("D7").SetValue("ARTÍCULO").Style.Font.SetBold(true);
            worksheet.Cell("D7").SetValue("ARTÍCULO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("E7").SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("E7").SetValue("CANTIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("F7").SetValue("CANT.ENTREG.").Style.Font.SetBold(true);
            worksheet.Cell("F7").SetValue("CANT.ENTREG.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("G7").SetValue("CANT.X LIQU.").Style.Font.SetBold(true);
            worksheet.Cell("G7").SetValue("CANT.X LIQU.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("H7").SetValue("UNID").Style.Font.SetBold(true);
            worksheet.Cell("H7").SetValue("UNID").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("I7").SetValue("OBSERVACION").Style.Font.SetBold(true);
            worksheet.Cell("I7").SetValue("OBSERVACION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            AL0003MOVC CABECERA = new AL0003MOVC();
            List<VISTA_AL0003MOVC> TABLA = new List<VISTA_AL0003MOVC>();
            List<VISTA_CPL> detalle = new List<VISTA_CPL>();


            List<AL0003MOVC> proveedor = new List<AL0003MOVC>();
            proveedor = AL0003MOVC.ListarProveedoresED(txtcodigo.Text, txtcodigofin.Text, Convert.ToDateTime(Txtfinicial.Text), Convert.ToDateTime(txtffinal.Text), ddlalmacen.Text);
            foreach (AL0003MOVC B in proveedor)
            {
                CABECERA.C5_CCODPRO = CABECERA.C5_CCODPRO + "," + B.C5_CCODPRO.Trim();
            }


            CABECERA.C5_CALMA = ddlalmacen.Text;
            CABECERA.C5_DFECDOC = Convert.ToDateTime(Txtfinicial.Text);
            CABECERA.C5_DFECMOD = Convert.ToDateTime(txtffinal.Text);

            detalle = AL0003MOVC.ComprasPLdetallado(CABECERA);
            TABLA = AL0003MOVC.ComprasPLResumido(CABECERA);

            foreach (VISTA_AL0003MOVC C in TABLA)
            {
                worksheet.Cell("A" + contcab.ToString()).SetValue("'" + C.C5_CALMA + "" +" "+ "'" + C.C5_CTD + "-" + "'" + C.C5_CNUMDOC + " "+ C.C5_CCODPRO + "-" + C.C5_CNOMPRO + "        " + C.C5_DFECDOC).Style.Font.SetBold(true); ;
                worksheet.Range("A"+ contcab+":"+"I"+contcab).Row(1).Merge();

                foreach (VISTA_CPL b in detalle)
                {
                    if (C.C5_CNUMDOC == b.C5_CNUMDOC)
                    {                      
                        worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.C6_CALMA + "");
                        worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.C6_CCODIGO + "");
                        worksheet.Cell("D" + cont2.ToString()).Value = b.C6_CDESCRI;
                        worksheet.Cell("E" + cont2.ToString()).Value = Convert.ToDecimal(b.C6_NCANTID);
                        worksheet.Cell("F" + cont2.ToString()).Value = Convert.ToDecimal(b.C6_NCANTEN);
                        worksheet.Cell("G" + cont2.ToString()).Value =Convert.ToDecimal(b.C6_NCANTID - b.C6_NCANTEN);
                        worksheet.Cell("H" + cont2.ToString()).Value = b.unidad;
                        worksheet.Cell("I" + cont2.ToString()).Value = b.C6_CVANEXO;

                        worksheet.Cell("E" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("F" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                     
                        cont2++;
                    }
                }
                    
               
                contcab = cont2 + 1;
                cont2 = contcab + 1;
              }

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"CPLDETALLADO.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();

        }
         if (this.rbresumido.Checked == true)
        {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
           int cont2 = 8;
            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("C4").SetValue("Reporte Resumido de Ordenes de Compra Pendientes de Liquidación").Style.Font.SetBold(true);
            worksheet.Range("C4:J4").Row(1).Merge();
            worksheet.Range("C5").SetValue("DEL: " + Txtfinicial.Text + " AL: " + txtffinal.Text).Style.Font.SetBold(true);
            worksheet.Range("C5:J5").Row(1).Merge();

            worksheet.Cell("A7").SetValue("ALMACEN").Style.Font.SetBold(true);
            worksheet.Cell("A7").SetValue("ALMACEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("B7").SetValue("TD").Style.Font.SetBold(true);
            worksheet.Cell("B7").SetValue("TD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("C7").SetValue("NUMERO").Style.Font.SetBold(true);
            worksheet.Cell("C7").SetValue("NUMERO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("D7").SetValue("CODIGO").Style.Font.SetBold(true);
            worksheet.Cell("D7").SetValue("CODIGO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("E7").SetValue("PROVEEDOR").Style.Font.SetBold(true);
            worksheet.Cell("E7").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("F7").SetValue("FECHA").Style.Font.SetBold(true);
            worksheet.Cell("F7").SetValue("FECHA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            
            AL0003MOVC CABECERA = new AL0003MOVC();
            List<VISTA_AL0003MOVC> TABLA = new List<VISTA_AL0003MOVC>();
          
            List<AL0003MOVC> proveedores = new List<AL0003MOVC>();
            proveedores = AL0003MOVC.ListarProveedoresED(txtcodigo.Text, txtcodigofin.Text, Convert.ToDateTime(Txtfinicial.Text), Convert.ToDateTime(txtffinal.Text), ddlalmacen.Text);
            foreach (AL0003MOVC B in proveedores)
            {
                CABECERA.C5_CCODPRO = CABECERA.C5_CCODPRO + "," + B.C5_CCODPRO.Trim();
            }


            CABECERA.C5_CALMA = ddlalmacen.Text;
            CABECERA.C5_DFECDOC = Convert.ToDateTime(Txtfinicial.Text);
            CABECERA.C5_DFECMOD = Convert.ToDateTime(txtffinal.Text);

              TABLA = AL0003MOVC.ComprasPLResumido(CABECERA);

            foreach (VISTA_AL0003MOVC C in TABLA)
            {
                worksheet.Cell("A" + cont2.ToString()).SetValue("'" + C.C5_CALMA);
                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + C.C5_CTD);
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + C.C5_CNUMDOC);
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + C.C5_CCODPRO);
                worksheet.Cell("E" + cont2.ToString()).Value =("'" + C.C5_CNOMPRO);
                worksheet.Cell("F" + cont2.ToString()).Value = ("'" + C.C5_DFECDOC);
                cont2 = cont2 + 1;
            }

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"CPLDETALLADO.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();

        }
    }
}