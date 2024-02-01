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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
         

     //   txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
   //     txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

    
        ddlestad.Items.Insert(0, new ListItem("[ESTADO]", "-1"));

            }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcerapopup> ListarCabOCpopup(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraocpopup(VC);

    }

    public static List<vista_cocabcera> ListarCabOC(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraoc(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        return CT0003ANEX.ListarProveedores(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aprobaroc(CO0003MOVC COAPRUEBA)
    {
       CO0003MOVC.AprobarOC(COAPRUEBA);
     }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> Getcentrocosto(string dato)
    {
        return AL0003TABL.ListarCcosto(dato);
    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVD> GetListaDetalle(CO0003MOVD LDE)
    {
        return CO0003MOVD.verListaOrden(LDE);
    }

    public static CO0003MOVC Getcabecerae(CO0003MOVC INFO)
    {
        return CO0003MOVC.VerCabeceraID(INFO);
    }





   // protected void Button1_Click(object sender, EventArgs e)
   


    protected void Button1_Click1(object sender, EventArgs e)
    {
       


            if (txtfecha1.Text != "" && txtfecha2.Text != "")
            {
                decimal SUMSOLES = 0;
                decimal SUMDOLARES = 0;
                if (chktodos.Checked)
                {

                    if (rbproveedor.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;

                        int cont3 = 9;
                        int cont4 = 9;


                        int contprov = 7;
                        int contcab = 0;
                        int cont2 = 9;
                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        List<vista_solicitud> proveedor = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Proveedor").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();


                        worksheet.Range("C5").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();


                        detplanilla.OC_CCODPRO = txtidpro.Text;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        proveedor = tabla_anticipo.proveedores();


                        cont = 9;
                        foreach (vista_solicitud a in proveedor)
                        {
                            SUMDOLARES = 0;
                            SUMSOLES = 0;
                            contcab = contprov + 1;
                            worksheet.Range("C" + contprov.ToString()).SetValue("RUC: " + a.OC_CCODPRO + " Proveedor: " + a.OC_CRAZSOC).Style.Font.SetBold(true);
                            //worksheet.Range("C5:J5").Row(1).Merge();
                            worksheet.Range("C" + contprov.ToString() + ":J" + contprov.ToString()).Row(1).Merge();

                            worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Font.SetBold(true);
                            worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Font.SetBold(true);
                            worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                            worksheet.Cell("D" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                            worksheet.Cell("E" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                            worksheet.Cell("F" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                            worksheet.Cell("G" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                            worksheet.Cell("H" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                            worksheet.Cell("I" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                            worksheet.Cell("J" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                            worksheet.Cell("K" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                            worksheet.Cell("L" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);


                            foreach (vista_solicitud b in detalle1)
                            {
                                if (a.OC_CCODPRO == b.OC_CCODPRO)
                                {
                                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                    worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                                    worksheet.Cell("D" + cont2.ToString()).Value = b.BANCO;
                                    worksheet.Cell("E" + cont2.ToString()).Value = b.MONEDA;
                                    worksheet.Cell("F" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                    worksheet.Cell("G" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                    worksheet.Cell("H" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                    worksheet.Cell("I" + cont2.ToString()).Value = b.DETRACCION;
                                    worksheet.Cell("J" + cont2.ToString()).Value = b.RETENCION;
                                    worksheet.Cell("k" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                    worksheet.Cell("L" + cont2.ToString()).Value = b.ESTADO;
                                    if (b.OC_CODMON.Trim() == "MN")
                                    {
                                        SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    else
                                    {
                                        SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    cont++;
                                    cont2++;
                                    contprov++;
                                }
                                worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                                worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                                worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                                worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
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



                    if (rbestado.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;

                        int cont3 = 9;
                        int cont4 = 9;


                        int contprov = 7;
                        int contcab = 0;
                        int cont2 = 9;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        List<vista_solicitud> estado = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Estado").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();


                        worksheet.Range("C5").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();


                        detplanilla.OC_CCODPRO = txtidpro.Text;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        estado = tabla_anticipo.estados();


                        cont = 9;
                        foreach (vista_solicitud a in estado)
                        {
                            SUMDOLARES = 0;
                            SUMSOLES = 0;
                            contcab = contprov + 1;
                            worksheet.Range("C" + contprov.ToString()).SetValue("Estado: " + a.ESTADO + "      (L) Liquidados, (P) Pendientes").Style.Font.SetBold(true);
                            //worksheet.Range("C5:J5").Row(1).Merge();
                            worksheet.Range("C" + contprov.ToString() + ":J" + contprov.ToString()).Row(1).Merge();

                            worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Font.SetBold(true);
                            worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Font.SetBold(true);
                            worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                            worksheet.Cell("D" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                            worksheet.Cell("E" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                            worksheet.Cell("F" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                            worksheet.Cell("G" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                            worksheet.Cell("H" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                            worksheet.Cell("I" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                            worksheet.Cell("J" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                            worksheet.Cell("K" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                            // worksheet.Cell("L" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);


                            foreach (vista_solicitud b in detalle1)
                            {
                                if (a.ESTADO == b.ESTADO)
                                {
                                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                    worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                                    worksheet.Cell("D" + cont2.ToString()).Value = b.BANCO;
                                    worksheet.Cell("E" + cont2.ToString()).Value = b.MONEDA;
                                    worksheet.Cell("F" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                    worksheet.Cell("G" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                    worksheet.Cell("H" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                    worksheet.Cell("I" + cont2.ToString()).Value = b.DETRACCION;
                                    worksheet.Cell("J" + cont2.ToString()).Value = b.RETENCION;
                                    worksheet.Cell("k" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                    if (b.OC_CODMON.Trim() == "MN")
                                    {
                                        SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    else
                                    {
                                        SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    cont++;
                                    cont2++;
                                    contprov++;
                                }
                                worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                                worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                                worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                                worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
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


                    if (rbnumero.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;

                        int cont3 = 9;
                        int cont4 = 9;


                        int contprov = 7;
                        int contcab = 0;
                        int cont2 = 9;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        List<vista_solicitud> orden = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Número de Órden").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();


                        worksheet.Range("C5").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();


                        detplanilla.OC_CCODPRO = txtidpro.Text;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        orden = tabla_anticipo.ordenes();


                        cont = 9;
                        foreach (vista_solicitud a in orden)
                        {
                            SUMDOLARES = 0;
                            SUMSOLES = 0;
                            contcab = contprov + 1;
                            worksheet.Range("C" + contprov.ToString()).SetValue("Orden N° : " + a.OC_CNUMORD).Style.Font.SetBold(true);
                            //worksheet.Range("C5:J5").Row(1).Merge();
                            worksheet.Range("C" + contprov.ToString() + ":J" + contprov.ToString()).Row(1).Merge();

                            worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Font.SetBold(true);
                            // worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Font.SetBold(true);
                            worksheet.Cell("B" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                            worksheet.Cell("C" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                            worksheet.Cell("D" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                            worksheet.Cell("E" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                            worksheet.Cell("F" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                            worksheet.Cell("G" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                            worksheet.Cell("H" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                            worksheet.Cell("I" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                            worksheet.Cell("J" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                            worksheet.Cell("K" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);


                            foreach (vista_solicitud b in detalle1)
                            {
                                if (a.OC_CNUMORD == b.OC_CNUMORD)
                                {
                                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                    /// worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                    worksheet.Cell("B" + cont2.ToString()).Value = b.OC_FECEMI;
                                    worksheet.Cell("C" + cont2.ToString()).Value = b.BANCO;
                                    worksheet.Cell("D" + cont2.ToString()).Value = b.MONEDA;
                                    worksheet.Cell("E" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                    worksheet.Cell("F" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                    worksheet.Cell("G" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                    worksheet.Cell("H" + cont2.ToString()).Value = b.DETRACCION;
                                    worksheet.Cell("I" + cont2.ToString()).Value = b.RETENCION;
                                    worksheet.Cell("J" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                    worksheet.Cell("K" + cont2.ToString()).Value = b.ESTADO;
                                    if (b.OC_CODMON.Trim() == "MN")
                                    {
                                        SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    else
                                    {
                                        SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                                    }
                                    cont++;
                                    cont2++;
                                    contprov++;
                                }
                                worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                                worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                                worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                                worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
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
                    if (rbfechas.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 8;
                        int cont2 = 8;
                        int cont3 = 8;
                        int cont4 = 8;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Fecha").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();
                        worksheet.Range("C5").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Cell("A7").SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B7").SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C7").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("D7").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("E7").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("F7").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("G7").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("H7").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("I7").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("J7").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("K7").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("L7").SetValue("ESTADO").Style.Font.SetBold(true);


                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("D" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("E" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("k" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.ESTADO;
                            if (b.OC_CODMON.Trim() == "MN")
                            {
                                SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            else
                            {
                                SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }

                            cont++;
                            cont2++;

                        }
                        worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
                        SUMDOLARES = 0;
                        SUMSOLES = 0;

                        if (cont3 == 8)
                        {
                            cont4 = cont3;
                            cont3 = 0;
                        }
                        else
                        {
                            cont4 = cont2 - cont + 8;
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
                /////////////************** reporte uno por uno *********////////////////////////

                else {
                    if (rbfechas.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 8;
                        int cont2 = 8;
                        int cont3 = 8;
                        int cont4 = 8;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Fecha").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();
                        worksheet.Range("C5").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Cell("A7").SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B7").SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C7").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("D7").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("E7").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("F7").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("G7").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("H7").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("I7").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("J7").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("K7").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("L7").SetValue("ESTADO").Style.Font.SetBold(true);


                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("D" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("E" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("k" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.ESTADO;
                            if (b.OC_CODMON.Trim() == "MN")
                            {
                                SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            else
                            {
                                SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }

                            cont++;
                            cont2++;

                        }
                        worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
                        SUMDOLARES = 0;
                        SUMSOLES = 0;

                        if (cont3 == 8)
                        {
                            cont4 = cont3;
                            cont3 = 0;
                        }
                        else
                        {
                            cont4 = cont2 - cont + 8;
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

                    if (rbproveedor.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;
                        int cont2 = 9;
                        int cont3 = 9;
                        int cont4 = 9;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Proveedor").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();
                        worksheet.Range("C5").SetValue("RUC: " + txtidpro.Text + " Proveedor: " + txtprove.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Range("C6").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C6:J6").Row(1).Merge();
                        worksheet.Cell("A8").SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B8").SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("D8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("E8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("ESTADO").Style.Font.SetBold(true);

                        detplanilla.OC_CCODPRO = txtidpro.Text;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportes(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("D" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("E" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("k" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.ESTADO;
                            if (b.OC_CODMON.Trim() == "MN")
                            {
                                SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            else
                            {
                                SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            cont++;
                            cont2++;

                        }
                        worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
                        SUMDOLARES = 0;
                        SUMSOLES = 0;

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

                    if (rbnumero.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;
                        int cont2 = 9;
                        int cont3 = 9;
                        int cont4 = 9;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Número de Orden").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();
                        worksheet.Range("C5").SetValue("Numero Orden: : " + txtnumero.Text).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Range("C6").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C6:J6").Row(1).Merge();
                        worksheet.Cell("A8").SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B8").SetValue("RUC").Style.Font.SetBold(true);
                        worksheet.Cell("C8").SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("D8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("E8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("M8").SetValue("ESTADO").Style.Font.SetBold(true);

                        detplanilla.OC_CNUMORD = txtnumero.Text;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportes(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CCODPRO + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                            worksheet.Cell("D" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                            worksheet.Cell("M" + cont2.ToString()).Value = b.ESTADO;
                            if (b.OC_CODMON.Trim() == "MN")
                            {
                                SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            else
                            {
                                SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            cont++;
                            cont2++;

                        }
                        worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
                        SUMDOLARES = 0;
                        SUMSOLES = 0;

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

                    if (rbestado.Checked)
                    {
                        var workbook = new XLWorkbook();
                        var worksheet = workbook.Worksheets.Add("Hoja 1");

                        int cont = 9;
                        int cont2 = 9;
                        int cont3 = 9;
                        int cont4 = 9;

                        tabla_anticipo var_consulta = new tabla_anticipo();
                        tabla_anticipo det = new tabla_anticipo();
                        List<vista_solicitud> detalle = new List<vista_solicitud>();
                        List<vista_solicitud> detalle1 = new List<vista_solicitud>();
                        tabla_anticipo detplanilla = new tabla_anticipo();

                        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
                        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
                        worksheet.Range("A2:J2").Row(1).Merge();
                        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
                        worksheet.Range("A3:J3").Row(1).Merge();
                        worksheet.Range("C4").SetValue("Reporte de Anticipos de Ordenes de Compra y/o Servicio por Estado").Style.Font.SetBold(true);
                        worksheet.Range("C4:J4").Row(1).Merge();
                        worksheet.Range("C5").SetValue("Estado: : " + ddlestad.SelectedItem.Text + " Cod.Estado: " + ddlestad.SelectedValue).Style.Font.SetBold(true);
                        worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Range("C6").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                        worksheet.Range("C6:J6").Row(1).Merge();
                        worksheet.Cell("A8").SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B8").SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C8").SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("D8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("E8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("M8").SetValue("ESTADO").Style.Font.SetBold(true);

                        detplanilla.ESTADO = ddlestad.SelectedValue;
                        detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportes(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                            worksheet.Cell("D" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                            worksheet.Cell("M" + cont2.ToString()).Value = b.ESTADO;
                            if (b.OC_CODMON.Trim() == "MN")
                            {
                                SUMSOLES = SUMSOLES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            else
                            {
                                SUMDOLARES = SUMDOLARES + Convert.ToDecimal(b.OC_TOTAL_PAGAR);
                            }
                            cont++;
                            cont2++;

                        }
                        worksheet.Cell("k" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("I" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("H" + cont2.ToString()).Value = "Total ME.";
                        SUMDOLARES = 0;
                        SUMSOLES = 0;

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



                ///fin validacion fechas
            }


            else
            {
                ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar un Rango de fechas"), false);
            }
        }


   }




