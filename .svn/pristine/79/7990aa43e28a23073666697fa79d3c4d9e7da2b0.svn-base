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
public partial class FINANZAS_Reportes_RepLiquidacionCompras : System.Web.UI.Page
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
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> GetArticulos(string productos)
    {
        return AL0003ARTI.ListarArticulo(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003FACC> GetLiquidaciones(string productos)
    {
        return AL0003FACC.autocompleteLiq(productos);
    }

    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if (this.rbproveedor.Checked==true)
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
            worksheet.Range("C4").SetValue("Reporte de Liquidación de Ordenes").Style.Font.SetBold(true);
            worksheet.Range("C4:J4").Row(1).Merge();
            worksheet.Range("C5").SetValue("DEL: " + txtfinicial.Text + " AL: " + txtffinal.Text).Style.Font.SetBold(true);
            worksheet.Range("C5:J5").Row(1).Merge();

            worksheet.Cell("B7").SetValue("NRO.LIQUID.").Style.Font.SetBold(true);
            worksheet.Cell("B7").SetValue("NRO.LIQUID.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("C7").SetValue("T.OPERACION").Style.Font.SetBold(true);
            worksheet.Cell("C7").SetValue("T.OPERACION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("D7").SetValue("FECHA").Style.Font.SetBold(true);
            worksheet.Cell("D7").SetValue("FECHA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("E7").SetValue("CODIGO").Style.Font.SetBold(true);
            worksheet.Cell("E7").SetValue("CODIGO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("F7").SetValue("ARTICULO").Style.Font.SetBold(true);
            worksheet.Cell("F7").SetValue("ARTICULO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("G7").SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("G7").SetValue("CANTIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("H7").SetValue("UNIDAD").Style.Font.SetBold(true);
            worksheet.Cell("H7").SetValue("UNIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("I7").SetValue("PRECIO").Style.Font.SetBold(true);
            worksheet.Cell("I7").SetValue("PRECIO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("J7").SetValue("V. VENTA").Style.Font.SetBold(true);
            worksheet.Cell("J7").SetValue("V. VENTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            VISTA_REPLIQCOMPRAS CABECERA = new VISTA_REPLIQCOMPRAS();
           List<VISTA_REPLIQCOMPRAS> detalle = new List<VISTA_REPLIQCOMPRAS>();
            
            List<VISTA_CCODPRV> proveedor = new List<VISTA_CCODPRV>();
            proveedor = AL0003FACC.ListarProveedoresED(txtcodigo.Text, txtcodigofin.Text,Convert.ToDateTime(txtfinicial.Text),Convert.ToDateTime(txtffinal.Text),ddlagencia.Text,ddlmoneda.Text);
            CABECERA.LC_CCODPRV = "";
            foreach (VISTA_CCODPRV B in proveedor)
            {
                CABECERA.LC_CCODPRV = CABECERA.LC_CCODPRV + "," + B.LC_CCODPRV.Trim();
            }
            
            CABECERA.LC_CCODAGE = ddlagencia.Text;
            CABECERA.LC_CCODMON = ddlmoneda.Text;
            CABECERA.LC_DFECDOC = Convert.ToDateTime(txtfinicial.Text);
            CABECERA.LC_DFECMOD = Convert.ToDateTime(txtffinal.Text);

            detalle = AL0003FACC.RepLiquidacion(CABECERA);
           
            foreach (VISTA_CCODPRV C in proveedor)
            {
                worksheet.Cell("A" + contcab.ToString()).Value = ("'" +C.LC_CCODPRV + ""+ C.LC_CNOMBRE);
                worksheet.Range("A" + contcab + ":" + "G" + contcab).Row(1).Merge();

                foreach (VISTA_REPLIQCOMPRAS b in detalle)
                {
                    if (C.LC_CCODPRV == b.LC_CCODPRV)
                    {
                        worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.LC_CNUMDOC + "");
                        worksheet.Cell("C" + cont2.ToString()).Value = ("XXXX   - ");
                        worksheet.Cell("D" + cont2.ToString()).Value = b.LC_DFECDOC;
                        worksheet.Cell("E" + cont2.ToString()).Value = ("'"+b.LD_CCODIGO);
                        worksheet.Cell("F" + cont2.ToString()).Value = b.LD_CDESCRI;
                        worksheet.Cell("G" + cont2.ToString()).Value = Convert.ToDecimal(b.LD_NCANTID);
                        worksheet.Cell("H" + cont2.ToString()).Value = b.LD_CUNIDAD;
                        worksheet.Cell("I" + cont2.ToString()).Value = b.LD_NPRECIO;
                        worksheet.Cell("J" + cont2.ToString()).Value = b.LD_NPRECIO * b.LD_NCANTID;

                        worksheet.Cell("I" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("J" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

                        cont2++;
                    }
                }


                contcab = cont2 + 1;
                cont2 = contcab + 1;
            }

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"CPLDETALLADOPROV.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();

        }

        if (this.rbarticulo.Checked == true)
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
            worksheet.Range("C4").SetValue("Reporte de Liquidación de Ordenes").Style.Font.SetBold(true);
            worksheet.Range("C4:J4").Row(1).Merge();
            worksheet.Range("C5").SetValue("DEL: " + txtfinicial.Text + " AL: " + txtffinal.Text).Style.Font.SetBold(true);
            worksheet.Range("C5:J5").Row(1).Merge();

            worksheet.Cell("B7").SetValue("NRO.LIQUID.").Style.Font.SetBold(true);
            worksheet.Cell("B7").SetValue("NRO.LIQUID.").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("C7").SetValue("T.OPERACION").Style.Font.SetBold(true);
            worksheet.Cell("C7").SetValue("T.OPERACION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("D7").SetValue("FECHA").Style.Font.SetBold(true);
            worksheet.Cell("D7").SetValue("FECHA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("E7").SetValue("CODIGO").Style.Font.SetBold(true);
            worksheet.Cell("E7").SetValue("CODIGO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("F7").SetValue("PROVEEDOR").Style.Font.SetBold(true);
            worksheet.Cell("F7").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("G7").SetValue("CANTIDAD").Style.Font.SetBold(true);
            worksheet.Cell("G7").SetValue("CANTIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("H7").SetValue("UNIDAD").Style.Font.SetBold(true);
            worksheet.Cell("H7").SetValue("UNIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("I7").SetValue("PRECIO").Style.Font.SetBold(true);
            worksheet.Cell("I7").SetValue("PRECIO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
            worksheet.Cell("J7").SetValue("V. VENTA").Style.Font.SetBold(true);
            worksheet.Cell("J7").SetValue("V. VENTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

            VISTA_REPLIQCOMPRAS CABECERA = new VISTA_REPLIQCOMPRAS();
            List<VISTA_REPLIQCOMPRAS> detalle = new List<VISTA_REPLIQCOMPRAS>();

            List<VISTA_CCODPRV> ARTICULO = new List<VISTA_CCODPRV>();
            ARTICULO = AL0003FACC.lISTARaRTICULOSED(txtcodigo.Text, txtcodigofin.Text, ddlagencia.Text);
            CABECERA.LD_CCODIGO = "";
            foreach (VISTA_CCODPRV B in ARTICULO)
            {
                CABECERA.LD_CCODIGO = CABECERA.LD_CCODIGO + "," + B.LC_CCODPRV.Trim();
            }

            CABECERA.LC_CCODAGE = ddlagencia.Text;
            CABECERA.LC_CCODMON = ddlmoneda.Text;
            CABECERA.LC_DFECDOC = Convert.ToDateTime(txtfinicial.Text);
            CABECERA.LC_DFECMOD = Convert.ToDateTime(txtffinal.Text);

            detalle = AL0003FACC.RepLiquidacionART(CABECERA);

            foreach (VISTA_CCODPRV C in ARTICULO)
            {
                worksheet.Cell("A" + contcab.ToString()).Value = ("'" + C.LC_CCODPRV + "" + C.LC_CNOMBRE);
                worksheet.Range("A" + contcab + ":" + "G" + contcab).Row(1).Merge();

                foreach (VISTA_REPLIQCOMPRAS b in detalle)
                {
                    if (C.LC_CCODPRV == b.LD_CCODIGO)
                    {
                        worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.LC_CNUMDOC + "");
                        worksheet.Cell("C" + cont2.ToString()).Value = ("XXXX   - ");
                        worksheet.Cell("D" + cont2.ToString()).Value = b.LC_DFECDOC;
                        worksheet.Cell("E" + cont2.ToString()).Value = ("'" + b.LC_CCODPRV);
                        worksheet.Cell("F" + cont2.ToString()).Value = b.LC_CNOMBRE;
                        worksheet.Cell("G" + cont2.ToString()).Value = Convert.ToDecimal(b.LD_NCANTID);
                        worksheet.Cell("H" + cont2.ToString()).Value = b.LD_CUNIDAD;
                        worksheet.Cell("I" + cont2.ToString()).Value = b.LD_NPRECIO;
                        worksheet.Cell("J" + cont2.ToString()).Value = b.LD_NPRECIO * b.LD_NCANTID;

                        worksheet.Cell("I" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("J" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

                        cont2++;
                    }
                }


                contcab = cont2 + 1;
                cont2 = contcab + 1;
            }

            Response.Clear();
            Response.ContentType =
                 "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"CPLDETALLADOART.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();
        }


        if (this.rbliquidacion.Checked == true)
        {
               var workbook = new XLWorkbook();
                var worksheet = workbook.Worksheets.Add("Hoja 1");
                int contcab = 8;
                int cont2 = 9;
                decimal suma = 0;
                worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                worksheet.Range("A2:J2").Row(1).Merge();
                worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                worksheet.Range("A3:J3").Row(1).Merge();
                worksheet.Range("C4").SetValue("Reporte de Liquidación de Ordenes").Style.Font.SetBold(true);
                worksheet.Range("C4:J4").Row(1).Merge();
                worksheet.Range("C5").SetValue("DEL: " + txtfinicial.Text + " AL: " + txtffinal.Text).Style.Font.SetBold(true);
                worksheet.Range("C5:J5").Row(1).Merge();
                worksheet.Range("C6").SetValue(this.ddlmoneda.SelectedItem).Style.Font.SetBold(true);


            worksheet.Cell("B7").SetValue("CODIGO").Style.Font.SetBold(true);
                worksheet.Cell("B7").SetValue("CODIGO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell("C7").SetValue("ARTICULO").Style.Font.SetBold(true);
                worksheet.Cell("C7").SetValue("ARTICULO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell("D7").SetValue("CANTIDAD").Style.Font.SetBold(true);
                worksheet.Cell("D7").SetValue("CANTIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell("E7").SetValue("UNIDAD").Style.Font.SetBold(true);
                worksheet.Cell("E7").SetValue("UNIDAD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell("F7").SetValue("PRECIO").Style.Font.SetBold(true);
                worksheet.Cell("F7").SetValue("PRECIO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                worksheet.Cell("G7").SetValue("V. VENTA").Style.Font.SetBold(true);
                worksheet.Cell("G7").SetValue("V. VENTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                VISTA_REPLIQCOMPRAS CABECERA = new VISTA_REPLIQCOMPRAS();
                List<VISTA_REPLIQCOMPRAS> detalle = new List<VISTA_REPLIQCOMPRAS>();

                List<VISTA_LC_CNUMDOC> proveedor = new List<VISTA_LC_CNUMDOC>();
                proveedor = AL0003FACC.ListarLiquidacionesED(txtcodigo.Text, txtcodigofin.Text, Convert.ToDateTime(txtfinicial.Text), Convert.ToDateTime(txtffinal.Text), ddlagencia.Text, ddlmoneda.Text);
                CABECERA.LC_CNUMDOC = "";
                foreach (VISTA_LC_CNUMDOC B in proveedor)
                {
                    CABECERA.LC_CNUMDOC = CABECERA.LC_CNUMDOC + "," + B.LC_CNUMDOC.Trim();
                }

                CABECERA.LC_CCODAGE = ddlagencia.Text;
                CABECERA.LC_CCODMON = ddlmoneda.Text;
                CABECERA.LC_DFECDOC = Convert.ToDateTime(txtfinicial.Text);
                CABECERA.LC_DFECMOD = Convert.ToDateTime(txtffinal.Text);

                detalle = AL0003FACC.RepLiquidacionLIQ(CABECERA);

                foreach (VISTA_LC_CNUMDOC C in proveedor)
                {
                   foreach (VISTA_REPLIQCOMPRAS b in detalle)
                    {
                    worksheet.Cell("A" + contcab.ToString()).Value = ("'" + C.LC_CNUMDOC + " "+b.LC_DFECDOC +" "+ b.LC_CCODPRV + " "+ b.LC_CNOMBRE);
                    worksheet.Range("A" + contcab + ":" + "G" + contcab).Row(1).Merge();

                    if (C.LC_CNUMDOC == b.LC_CNUMDOC)
                        {
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.LD_CCODIGO + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.LD_CDESCRI + "");
                            worksheet.Cell("D" + cont2.ToString()).Value = b.LD_NCANTID;
                            worksheet.Cell("E" + cont2.ToString()).Value = ("'" + b.LD_CUNIDAD);
                            worksheet.Cell("F" + cont2.ToString()).Value = b.LD_NPRECIO;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.LD_NPRECIO * b.LD_NCANTID;

                            worksheet.Cell("F" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                            worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                            worksheet.Cell("D" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

                            cont2++;
                        suma = suma + (b.LD_NPRECIO * b.LD_NCANTID);
                        }
                    }
               worksheet.Range("F" + cont2.ToString()).SetValue("TOTAL").Style.Font.SetBold(true);
               worksheet.Range("G" + cont2.ToString()).SetValue(suma).Style.Font.SetBold(true);
               worksheet.Cell("G" + cont2.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                suma = 0;
                    contcab = cont2 + 1;
                    cont2 = contcab + 1;
                }

                Response.Clear();
                Response.ContentType =
                     "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;filename=\"RLCxLC.xlsx\"");

                using (var memoryStream = new MemoryStream())
                {
                    workbook.SaveAs(memoryStream);
                    memoryStream.WriteTo(Response.OutputStream);
                }
                Response.End();
            }

    }
}