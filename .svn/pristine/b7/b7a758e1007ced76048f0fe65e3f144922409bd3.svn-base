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
      ddlestad.Items.Insert(0, new ListItem("[ESTADO]", "-1"));
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_cocabcerapopup> ListarCabOCpopup(CO0003MOVC VC)
    {
        return CO0003MOVC.Listarcabeceraocpopup(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> ListarTabla(AL0003TABL TABL)
    {
        return AL0003TABL.ListartablaxDetalle(TABL.TG_CDESCRI,"12");
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

                if (rbsolicitante.Checked)
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


                   // detplanilla.OC_CCODSOL = txtcodsolicitante.Text;
                    detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                    detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                    detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                    proveedor = tabla_anticipo.solicitantes();


                    cont = 9;
                    foreach (vista_solicitud a in proveedor)
                    {
                        SUMDOLARES = 0;
                        SUMSOLES = 0;
                        contcab = contprov + 1;
                        worksheet.Range("C" + contprov.ToString()).SetValue("Codigo: " + a.OC_CCODSOL + " Solicitante: " + a.OC_CSOLICT).Style.Font.SetBold(true);
                        //worksheet.Range("C5:J5").Row(1).Merge();
                        worksheet.Range("C" + contprov.ToString() + ":J" + contprov.ToString()).Row(1).Merge();

                        worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Font.SetBold(true);
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("E" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("F" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("G" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("H" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("I" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("J" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("K" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("L" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("M" + contcab.ToString()).SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("N" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);

                        worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("E" + contcab.ToString()).SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("F" + contcab.ToString()).SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("G" + contcab.ToString()).SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("H" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("I" + contcab.ToString()).SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("J" + contcab.ToString()).SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("K" + contcab.ToString()).SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("L" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("M" + contcab.ToString()).SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("N" + contcab.ToString()).SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        foreach (vista_solicitud b in detalle1)
                        {
                            if (a.OC_CCODSOL == b.OC_CCODSOL)
                            {
                                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                                worksheet.Cell("D" + cont2.ToString()).Value = b.OC_CRAZSOC;
                                worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                                worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                                worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                                worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                                worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;

                                if (b.ESTADO == "P")
                                {
                                    worksheet.Cell("M" + cont2.ToString()).Value = "PENDIENTE";
                                }
                                else
                                {
                                    worksheet.Cell("M" + cont2.ToString()).Value = "LIQUIDADO";
                                }


                                if (b.APROB == "A")
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "APROBADO";
                                }
                                else
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "EMITIDO";
                                }

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
                            worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                            worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                            worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                            worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 30; //BANCO
                    worksheet.Column(6).Width = 6; //MONEDA
                    worksheet.Column(7).Width = 8; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 15; // est. aprobado
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
                            worksheet.Cell("D" + contcab.ToString()).SetValue("SOLICITANTE").Style.Font.SetBold(true);
                            worksheet.Cell("E" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                            worksheet.Cell("F" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                            worksheet.Cell("G" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                            worksheet.Cell("H" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                            worksheet.Cell("I" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                            worksheet.Cell("J" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                            worksheet.Cell("K" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                            worksheet.Cell("L" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                            worksheet.Cell("M" + contcab.ToString()).SetValue("SITUACIÓN").Style.Font.SetBold(true);
                            worksheet.Cell("N" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);

                        worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("D" + contcab.ToString()).SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("E" + contcab.ToString()).SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("F" + contcab.ToString()).SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("G" + contcab.ToString()).SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("H" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("I" + contcab.ToString()).SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("J" + contcab.ToString()).SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("K" + contcab.ToString()).SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("L" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("M" + contcab.ToString()).SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("N" + contcab.ToString()).SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                        foreach (vista_solicitud b in detalle1)
                            {
                                if (a.OC_CCODPRO == b.OC_CCODPRO)
                                {
                                    worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                    worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                    worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                                    worksheet.Cell("D" + cont2.ToString()).Value = b.OC_CSOLICT;
                                    worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                                    worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                                    worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                    worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                    worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                    worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                                    worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                                    worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                    
                                if (b.ESTADO=="P")
                                {
                                    worksheet.Cell("M" + cont2.ToString()).Value = "PENDIENTE";
                                }
                                else
                                {
                                    worksheet.Cell("M" + cont2.ToString()).Value = "LIQUIDADO";
                                }


                                if (b.APROB=="A")
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value ="APROBADO";
                                }
                                else
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "EMITIDO";
                                }
                                   
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
                                worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                                worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                                worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                                worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 30; //BANCO
                    worksheet.Column(6).Width = 6; //MONEDA
                    worksheet.Column(7).Width = 8; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 15; // est. aprobado
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
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("E" + contcab.ToString()).SetValue("SOLICITANTE").Style.Font.SetBold(true);
                        worksheet.Cell("F" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("G" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("H" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("I" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("J" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("K" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("L" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("M" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("N" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);
                        worksheet.Cell("O" + contcab.ToString()).SetValue("ESTADO APROB.").Style.Font.SetBold(true);

                        worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("E" + contcab.ToString()).SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("F" + contcab.ToString()).SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("G" + contcab.ToString()).SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("H" + contcab.ToString()).SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("I" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("J" + contcab.ToString()).SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("K" + contcab.ToString()).SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("L" + contcab.ToString()).SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("M" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("N" + contcab.ToString()).SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("O" + contcab.ToString()).SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                       

                        foreach (vista_solicitud b in detalle1)
                            {
                                if (a.ESTADO == b.ESTADO)
                            {
                                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;

                                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                                worksheet.Cell("E" + cont2.ToString()).Value = b.OC_CSOLICT;

                                worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                                worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                                worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                                worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                                worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                if (b.ESTADO == "P")
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                                }
                                else
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                                }

                                if (b.APROB == "A")
                                {
                                    worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                                }
                                else
                                {
                                    worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                                }

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
                            worksheet.Cell("M" + cont2.ToString()).Value = SUMSOLES;
                            worksheet.Cell("L" + cont2.ToString()).Value = "Total s/.";
                            worksheet.Cell("K" + cont2.ToString()).Value = SUMDOLARES;
                            worksheet.Cell("J" + cont2.ToString()).Value = "Total ME.";
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
                        
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(5).Width = 40; //SOLICITANTE
                    worksheet.Column(6).Width = 30; //BANCO
                    worksheet.Column(7).Width = 6; //MONEDA
                    worksheet.Column(8).Width = 8; //("%").
                    worksheet.Column(9).Width = 10; //TOTAL ORDEN
                    worksheet.Column(10).Width = 10; //ANTICIPO
                    worksheet.Column(11).Width = 10; // detraccion
                    worksheet.Column(12).Width = 10; //retencion
                    worksheet.Column(13).Width = 10; //total a pagar
                    worksheet.Column(14).Width = 10; //estado
                    worksheet.Column(15).Width = 15; // est. aprobado

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
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Font.SetBold(true);
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("E" + contcab.ToString()).SetValue("SOLICITANTE").Style.Font.SetBold(true);
                        worksheet.Cell("F" + contcab.ToString()).SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("G" + contcab.ToString()).SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("H" + contcab.ToString()).SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("I" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("J" + contcab.ToString()).SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("K" + contcab.ToString()).SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("L" + contcab.ToString()).SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("M" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("N" + contcab.ToString()).SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("O" + contcab.ToString()).SetValue("ESTADO").Style.Font.SetBold(true);

                        
                        worksheet.Cell("A" + contcab.ToString()).SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("B" + contcab.ToString()).SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("C" + contcab.ToString()).SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("D" + contcab.ToString()).SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("E" + contcab.ToString()).SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("F" + contcab.ToString()).SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("G" + contcab.ToString()).SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("H" + contcab.ToString()).SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("I" + contcab.ToString()).SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("J" + contcab.ToString()).SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("K" + contcab.ToString()).SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("L" + contcab.ToString()).SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("M" + contcab.ToString()).SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("N" + contcab.ToString()).SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                        worksheet.Cell("O" + contcab.ToString()).SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                       

                        foreach (vista_solicitud b in detalle1)
                            {
                                if (a.OC_CNUMORD == b.OC_CNUMORD)
                            {
                                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                                worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                                worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                                worksheet.Cell("E" + cont2.ToString()).Value = b.OC_CSOLICT;
                                worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                                worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                                worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                                worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                                worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                                worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                                worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                                worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                                if (b.ESTADO == "P")
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                                }
                                else
                                {
                                    worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                                }


                                if (b.APROB == "A")
                                {
                                    worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                                }
                                else
                                {
                                    worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                                }

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
                            worksheet.Cell("M" + cont2.ToString()).Value = SUMSOLES;
                            worksheet.Cell("L" + cont2.ToString()).Value = "Total s/.";
                            worksheet.Cell("K" + cont2.ToString()).Value = SUMDOLARES;
                            worksheet.Cell("J" + cont2.ToString()).Value = "Total ME.";
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
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(5).Width = 40; //SOLICITANTE
                    worksheet.Column(6).Width = 30; //BANCO
                    worksheet.Column(7).Width = 6; //MONEDA
                    worksheet.Column(8).Width = 8; //("%").
                    worksheet.Column(9).Width = 10; //TOTAL ORDEN
                    worksheet.Column(10).Width = 10; //ANTICIPO
                    worksheet.Column(11).Width = 10; // detraccion
                    worksheet.Column(12).Width = 10; //retencion
                    worksheet.Column(13).Width = 10; //total a pagar
                    worksheet.Column(14).Width = 15; // est. aprobado
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
                        worksheet.Cell("D7").SetValue("PROVEEDOR").Style.Font.SetBold(true);
                        worksheet.Cell("E7").SetValue("SOLICITANTE").Style.Font.SetBold(true);
                        worksheet.Cell("F7").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("G7").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("H7").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("I7").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("J7").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("K7").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("L7").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("M7").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("N7").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("O7").SetValue("ESTADO").Style.Font.SetBold(true);
                 
                    worksheet.Cell("A7").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B7").SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C7").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D7").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E7").SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F7").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G7").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H7").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I7").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J7").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K7").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L7").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M7").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N7").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("O7").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                   detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                            worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                            worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                            worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;

                        worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                        worksheet.Cell("E" + cont2.ToString()).Value = b.OC_CSOLICT;

                        worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                        }

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
                        worksheet.Cell("M" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("L" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("K" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("J" + cont2.ToString()).Value = "Total ME.";
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
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(5).Width = 40; //SOLICITANTE
                    worksheet.Column(6).Width = 30; //BANCO
                    worksheet.Column(7).Width = 6; //MONEDA
                    worksheet.Column(8).Width = 8; //("%").
                    worksheet.Column(9).Width = 10; //TOTAL ORDEN
                    worksheet.Column(10).Width = 10; //ANTICIPO
                    worksheet.Column(11).Width = 10; // detraccion
                    worksheet.Column(12).Width = 10; //retencion
                    worksheet.Column(13).Width = 10; //total a pagar
                    worksheet.Column(14).Width = 10; //estado
                    worksheet.Column(15).Width = 15; // est. aprobado

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
                    //

                    worksheet.Cell("A7").SetValue("SOLICITUD").Style.Font.SetBold(true);
                    worksheet.Cell("B7").SetValue("ORDEN N°").Style.Font.SetBold(true);
                    worksheet.Cell("C7").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                    worksheet.Cell("D7").SetValue("PROVEEDOR").Style.Font.SetBold(true);
                    worksheet.Cell("E7").SetValue("SOLICITANTE").Style.Font.SetBold(true);
                    worksheet.Cell("F7").SetValue("BANCO").Style.Font.SetBold(true);
                    worksheet.Cell("G7").SetValue("MONEDA").Style.Font.SetBold(true);
                    worksheet.Cell("H7").SetValue("%").Style.Font.SetBold(true);
                    worksheet.Cell("I7").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                    worksheet.Cell("J7").SetValue("ANTICIPO").Style.Font.SetBold(true);
                    worksheet.Cell("K7").SetValue("DETRACCION").Style.Font.SetBold(true);
                    worksheet.Cell("L7").SetValue("RETENCION").Style.Font.SetBold(true);
                    worksheet.Cell("M7").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                    worksheet.Cell("N7").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                    worksheet.Cell("O7").SetValue("ESTADO").Style.Font.SetBold(true);

                    worksheet.Cell("A7").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B7").SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C7").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D7").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E7").SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F7").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G7").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H7").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I7").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J7").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K7").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L7").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M7").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N7").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("O7").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                        detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                        detalle1 = tabla_anticipo.SAreportesFechas(detplanilla);
                        cont = 7;
                        foreach (vista_solicitud b in detalle1)
                        {
                        worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                        worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                        worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;

                        worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CRAZSOC + "");
                        worksheet.Cell("E" + cont2.ToString()).Value = b.OC_CSOLICT;

                        worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                        worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                        worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                        worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                        worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                        worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                        worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                        worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;
                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                        }

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

                    worksheet.Cell("M" + cont2.ToString()).Value = SUMSOLES;
                    worksheet.Cell("L" + cont2.ToString()).Value = "Total s/.";
                    worksheet.Cell("K" + cont2.ToString()).Value = SUMDOLARES;
                    worksheet.Cell("J" + cont2.ToString()).Value = "Total ME.";
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

                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                    worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(5).Width = 40; //SOLICITANTE
                    worksheet.Column(6).Width = 30; //BANCO
                    worksheet.Column(7).Width = 6; //MONEDA
                    worksheet.Column(8).Width = 8; //("%").
                    worksheet.Column(9).Width = 10; //TOTAL ORDEN
                    worksheet.Column(10).Width = 10; //ANTICIPO
                    worksheet.Column(11).Width = 10; // detraccion
                    worksheet.Column(12).Width = 10; //retencion
                    worksheet.Column(13).Width = 10; //total a pagar
                    worksheet.Column(14).Width = 10; //estado
                    worksheet.Column(15).Width = 15; // est. aprobado

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

                if (rbsolicitante.Checked)
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
                    worksheet.Range("C5").SetValue(" Solicitante: " + txtsolicitante.Text).Style.Font.SetBold(true);
                    worksheet.Range("C5:J5").Row(1).Merge();
                    worksheet.Range("C6").SetValue("DEL: " + txtfecha1.Text + " AL: " + txtfecha2.Text).Style.Font.SetBold(true);
                    worksheet.Range("C6:J6").Row(1).Merge();

                    worksheet.Cell("A8").SetValue("SOLICITUD").Style.Font.SetBold(true);
                    worksheet.Cell("B8").SetValue("ORDEN N°").Style.Font.SetBold(true);
                    worksheet.Cell("C8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                    worksheet.Cell("D8").SetValue("PROVEEDOR").Style.Font.SetBold(true);
                    worksheet.Cell("E8").SetValue("BANCO").Style.Font.SetBold(true);
                    worksheet.Cell("F8").SetValue("MONEDA").Style.Font.SetBold(true);
                    worksheet.Cell("G8").SetValue("%").Style.Font.SetBold(true);
                    worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                    worksheet.Cell("I8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                    worksheet.Cell("J8").SetValue("DETRACCION").Style.Font.SetBold(true);
                    worksheet.Cell("K8").SetValue("RETENCION").Style.Font.SetBold(true);
                    worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                    worksheet.Cell("M8").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                    worksheet.Cell("N8").SetValue("ESTADO").Style.Font.SetBold(true);

                    //Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("A8").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B8").SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C8").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D8").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E8").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F8").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G8").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I8").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J8").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K8").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M8").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N8").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;



                    detplanilla.OC_CCODSOL = txtcodsolicitante.Text;
                    detplanilla.OC_FECEMI = Convert.ToDateTime(txtfecha1.Text);
                    detplanilla.OC_FECPRO = Convert.ToDateTime(txtfecha2.Text);
                    detalle1 = tabla_anticipo.SAreportes(detplanilla);
                    cont = 7;
                    foreach (vista_solicitud b in detalle1)
                    {
                        worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.ANT_CODIGO + "");
                        worksheet.Cell("B" + cont2.ToString()).Value = ("'" + b.OC_CNUMORD + "");
                        worksheet.Cell("C" + cont2.ToString()).Value = b.OC_FECEMI;
                        worksheet.Cell("D" + cont2.ToString()).Value = b.OC_CRAZSOC;

                        worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                        worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                        worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                        worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                        worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                        worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                        worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                        worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;

                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("M" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("M" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "EMITIDO";
                        }
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
                    worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                    worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                    worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                    worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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

                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                                                    // worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 30; //BANCO
                    worksheet.Column(6).Width = 6; //MONEDA
                    worksheet.Column(7).Width = 8; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 15; // est. aprobado
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
                        worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Font.SetBold(true);
                        worksheet.Cell("E8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("M8").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("N8").SetValue("ESTADO").Style.Font.SetBold(true);

                    //Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    worksheet.Cell("A8").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B8").SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C8").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E8").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F8").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G8").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H8").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I8").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J8").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K8").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L8").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M8").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N8").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                    

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
                        worksheet.Cell("D" + cont2.ToString()).Value = b.OC_CSOLICT;

                        worksheet.Cell("E" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;

                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("M" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("M" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "EMITIDO";
                        }
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
                        worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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

                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 10; //FECHA_EMISION
                                                    // worksheet.Column(4).Width = 50; //PROVEEDOR
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 30; //BANCO
                    worksheet.Column(6).Width = 6; //MONEDA
                    worksheet.Column(7).Width = 8; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 15; // est. aprobado
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
                        worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Font.SetBold(true);
                        worksheet.Cell("E8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("M8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("N8").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("O8").SetValue("ESTADO.").Style.Font.SetBold(true);

                   
                    worksheet.Cell("A8").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B8").SetValue("RUC").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C8").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E8").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F8").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G8").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H8").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I8").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J8").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K8").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L8").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M8").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N8").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("O8").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

           

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
                            worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CSOLICT + "");
                            worksheet.Cell("E" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;

                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                        }
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
                        worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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
                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 50; //PROVEEDOR
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 10; //BANCO
                    worksheet.Column(6).Width = 30; //MONEDA
                    worksheet.Column(7).Width = 10; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 10; // est. aprobado
                    worksheet.Column(15).Width = 15; // est. aprobado
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
                    worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Font.SetBold(true);
                    worksheet.Cell("E8").SetValue("FECHA_EMISION").Style.Font.SetBold(true);
                        worksheet.Cell("F8").SetValue("BANCO").Style.Font.SetBold(true);
                        worksheet.Cell("G8").SetValue("MONEDA").Style.Font.SetBold(true);
                        worksheet.Cell("H8").SetValue("%").Style.Font.SetBold(true);
                        worksheet.Cell("I8").SetValue("TOTAL ORDEN").Style.Font.SetBold(true);
                        worksheet.Cell("J8").SetValue("ANTICIPO").Style.Font.SetBold(true);
                        worksheet.Cell("K8").SetValue("DETRACCION").Style.Font.SetBold(true);
                        worksheet.Cell("L8").SetValue("RETENCION").Style.Font.SetBold(true);
                        worksheet.Cell("M8").SetValue("TOTAL A PAGAR").Style.Font.SetBold(true);
                        worksheet.Cell("N8").SetValue("SITUACIÓN").Style.Font.SetBold(true);
                        worksheet.Cell("O8").SetValue("ESTADO").Style.Font.SetBold(true);

                    worksheet.Cell("A8").SetValue("SOLICITUD").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("B8").SetValue("ORDEN N°").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("C8").SetValue("PROVEEDOR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("D8").SetValue("SOLICITANTE").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("E8").SetValue("FECHA_EMISION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("F8").SetValue("BANCO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("G8").SetValue("MONEDA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("H8").SetValue("%").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("I8").SetValue("TOTAL ORDEN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("J8").SetValue("ANTICIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("K8").SetValue("DETRACCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("L8").SetValue("RETENCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("M8").SetValue("TOTAL A PAGAR").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("N8").SetValue("SITUACIÓN").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                    worksheet.Cell("O8").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

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
                        worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.OC_CSOLICT + "");
                        worksheet.Cell("E" + cont2.ToString()).Value = b.OC_FECEMI;
                            worksheet.Cell("F" + cont2.ToString()).Value = b.BANCO;
                            worksheet.Cell("G" + cont2.ToString()).Value = b.MONEDA;
                            worksheet.Cell("H" + cont2.ToString()).Value = b.OC_PERCENTAJE;
                            worksheet.Cell("I" + cont2.ToString()).Value = b.OC_MONTO_PEDIDO;
                            worksheet.Cell("J" + cont2.ToString()).Value = b.OC_ANTICIPO;
                            worksheet.Cell("K" + cont2.ToString()).Value = b.DETRACCION;
                            worksheet.Cell("L" + cont2.ToString()).Value = b.RETENCION;
                            worksheet.Cell("M" + cont2.ToString()).Value = b.OC_TOTAL_PAGAR;


                        if (b.ESTADO == "P")
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "PENDIENTE";
                        }
                        else
                        {
                            worksheet.Cell("N" + cont2.ToString()).Value = "LIQUIDADO";
                        }

                        if (b.APROB == "A")
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "APROBADO";
                        }
                        else
                        {
                            worksheet.Cell("O" + cont2.ToString()).Value = "EMITIDO";
                        }

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
                        worksheet.Cell("L" + cont2.ToString()).Value = SUMSOLES;
                        worksheet.Cell("K" + cont2.ToString()).Value = "Total s/.";
                        worksheet.Cell("J" + cont2.ToString()).Value = SUMDOLARES;
                        worksheet.Cell("I" + cont2.ToString()).Value = "Total ME.";
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

                    worksheet.Column(1).Width = 10; // SOLICITUD
                    worksheet.Column(2).Width = 15; //ORDEN
                    worksheet.Column(3).Width = 50; //PROVEEDOR
                    worksheet.Column(4).Width = 40; //SOLICITANTE
                    worksheet.Column(5).Width = 10; //BANCO
                    worksheet.Column(6).Width = 30; //MONEDA
                    worksheet.Column(7).Width = 10; //("%").
                    worksheet.Column(8).Width = 10; //TOTAL ORDEN
                    worksheet.Column(9).Width = 10; //ANTICIPO
                    worksheet.Column(10).Width = 10; // detraccion
                    worksheet.Column(11).Width = 10; //retencion
                    worksheet.Column(12).Width = 10; //total a pagar
                    worksheet.Column(13).Width = 10; //estado
                    worksheet.Column(14).Width = 10; // est. aprobado
                    worksheet.Column(15).Width = 15; // est. aprobado

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




