using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
using ENTITY;
using System.Configuration;

public partial class kardexAlmacen : System.Web.UI.Page
{
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003ARTI> GetProductos(string productos)
    {
        return AL0003ARTI.ListarArticulos(productos);
    }
    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    //public static List<CT0003ANEX> GetProveedores(string productos)
    //{
    //    return CT0003ANEX.listarAnexoT("P",productos);
    //}

    protected void txtcodprod1_TextChanged(object sender, EventArgs e)
    {
        AL0003ARTI arti = new AL0003ARTI();
        arti = AL0003ARTI.obtenerArticuloPorID(txtcodprod1.Text.Trim());
        if (arti != null)
        {
            txtproducto.Text = arti.AR_CDESCRI.Trim();
            //    txtarticulo.Text = arti.AR_CCODIGO.Trim();
            hfproducto.Value = arti.AR_CCODIGO.Trim();
        }
        else
        {
            txtproducto.Text = string.Empty;
            txtcodprod1.Text = string.Empty;
            hfproducto.Value = null;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("El articulo no existe"), false);
            return;
        }
    }

    protected void txtcodprod2_TextChanged(object sender, EventArgs e)
    {
        AL0003ARTI arti = new AL0003ARTI();
        arti = AL0003ARTI.obtenerArticuloPorID(txtcodprod2.Text.Trim());
        if (arti != null)
        {
            txtproducto1.Text = arti.AR_CDESCRI.Trim();
            //    txtarticulo.Text = arti.AR_CCODIGO.Trim();
            hfproducto1.Value = arti.AR_CCODIGO.Trim();
        }
        else
        {
            txtproducto1.Text = string.Empty;
            txtcodprod2.Text = string.Empty;
            hfproducto1.Value = null;
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("El articulo no existe"), false);
            return;
        }
    }
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {

            ddlalmacen.Items.Clear();
            ddlalmacen.DataTextField = "A1_CDESCRI";
            ddlalmacen.DataValueField = "A1_CALMA";
            ddlalmacen.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalmacen.DataBind();
            ddlalmacen.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));

            ListaDetalle();

            txtfechini.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfechfin.Text = DateTime.Now.ToString("dd/MM/yyyy");

            hfproducto.Value = null;


            List<AL0003TABL> listamoneda = new List<AL0003TABL>();

            // Add parts to the list.
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "1", TG_CCOD = "Detallado" });
            listamoneda.Add(new AL0003TABL() { TG_CCLAVE = "2", TG_CCOD = "Resumen" });

            ddltipo.Items.Clear();
            ddltipo.DataTextField = "TG_CCOD";
            ddltipo.DataValueField = "TG_CCLAVE";
            ddltipo.DataSource = listamoneda;
            ddltipo.DataBind();
          //  ddltipo.Items.Insert(0, new ListItem("[MES]", "-1"));
        }
    }
    public void ListaDetalle()
    {
        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("SR_CCODIGO");
        dtGetDatae1.Columns.Add("SR_CSERIE");
        dtGetDatae1.Columns.Add("SR_NSKDIS");
        dtGetDatae1.Columns.Add("SR_DFECVEN");
        dtGetDatae1.Rows.Add();
        gvdetallereq.DataSource = dtGetDatae1;
        gvdetallereq.DataBind();
    }

    [System.Web.Script.Services.ScriptMethod()]
    [System.Web.Services.WebMethod]
    public static List<AL0003SERI> consultaStockSerie(AL0003SERI REQ)
    {
        return AL0003SERI.ListarLOTES(REQ);
    }

    public void GenerakardexAlmacen(string cod1,string cod2,string fecha1, string fecha2,string alma, string alam_descrip ,string tipo)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");

        // var ff =  AL0003ARTI.ListarArticulosParaKardex("E010010018000", "E010010018000");
        var ff = AL0003ARTI.ListarArticulosParaKardex(cod1.Trim() , cod2.Trim());
        DateTime f1 = Convert.ToDateTime(fecha1);
        DateTime f2 = Convert.ToDateTime(fecha2);

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("KARDEX GENERAL ALMACEN " + alma + " " + alam_descrip).Style.Font.SetBold(true);
        worksheet.Range("C5").SetValue("DESDE " + fecha1 + " al " + fecha2).Style.Font.SetBold(true);
        worksheet.Range("C4:J4").Row(1).Merge();
        worksheet.Range("C5:J5").Row(1).Merge();

        worksheet.Cell("A7").SetValue("CODIGO").Style.Font.SetBold(true);
        worksheet.Cell("B7").SetValue("ARTICULO").Style.Font.SetBold(true);
        worksheet.Cell("C7").SetValue("DO").Style.Font.SetBold(true);
        worksheet.Cell("D7").SetValue("MO").Style.Font.SetBold(true);
        worksheet.Cell("E7").SetValue("MOVIMIENTO").Style.Font.SetBold(true);
        worksheet.Cell("F7").SetValue("ALMA").Style.Font.SetBold(true);
        worksheet.Cell("G7").SetValue("ALMA.REF.").Style.Font.SetBold(true);
        worksheet.Cell("H7").SetValue("NºDOCUM.").Style.Font.SetBold(true);
        worksheet.Cell("I7").SetValue("FECHA").Style.Font.SetBold(true);
        worksheet.Cell("J7").SetValue("DR").Style.Font.SetBold(true);
        worksheet.Cell("K7").SetValue("NºDOCREF").Style.Font.SetBold(true);
        worksheet.Cell("L7").SetValue("E.SERIE").Style.Font.SetBold(true);

        worksheet.Cell("M7").SetValue("ANTERIOR").Style.Font.SetBold(true);
        worksheet.Cell("N7").SetValue("ENTRADAS").Style.Font.SetBold(true);
        worksheet.Cell("O7").SetValue("SALIDAS").Style.Font.SetBold(true);
        worksheet.Cell("P7").SetValue("FINAL").Style.Font.SetBold(true);


        //worksheet.Rows().AdjustToContents();
        worksheet.Columns("A").Width = 15;
        worksheet.Columns("B").Width = 50;
        worksheet.Columns("E").Width = 25;
        worksheet.Columns("H").Width = 12;
        worksheet.Columns("I").Width = 11;
        worksheet.Columns("L").Width = 14;

        int cont = 8;
        int contt = 8;

        var letra = string.Empty;

        foreach (var dd in ff)
        {
            AL0003ASER ser = new AL0003ASER()
            {
                C6_CCODIGO = dd.AR_CCODIGO.Trim(),
                C6_DFECCRE = f1,
                C6_DFECDOC = f2,
                C6_CALMA = alma
            };
            //worksheet.Cell("A" + cont1.ToString()).Value = "'" + dd.AR_CDESCRI;

            List<vista_AL0003ASER> vist = null;

            if (ddltipo.SelectedValue == "1")
            {
             var arti=   AL0003ARTI.obtenerArticuloPorID(dd.AR_CCODIGO.Trim());
               if (arti.AR_CFSERIE.Trim() =="S" || arti.AR_CFLOTE.Trim() == "S")
                     vist = AL0003ASER.ListarKardex(ser);
               else
                    vist = AL0003ASER.ListarKardexSinLote(ser);
            }
            else
                vist = AL0003ASER.ListarKardexResumido(ser);


            if (vist.Count > 0)
            {
                if (cont != 8)
                {
                    cont++;
                    contt = cont;
                }
            }
            //if (cont != 8)
            //    cont++;

         

            foreach (var b in vist)
            {
                if (b.C6_CTD == "PE")
                    letra = "S";
                if (b.C6_CTD == "PS")
                    letra = "T";

               //if ("E010010024000"== b.C6_CCODIGO.Trim())
               // {
               //     var xxx = 1;
               // }

                worksheet.Cell("A" + cont.ToString()).Value = "'" + b.C6_CCODIGO;
                worksheet.Cell("B" + cont.ToString()).Value = "'" + b.ARTICULO;
                worksheet.Cell("C" + cont.ToString()).Value = "'" + b.C6_CTD;
                worksheet.Cell("D" + cont.ToString()).Value = "'" + b.C5_CCODMOV;
                worksheet.Cell("E" + cont.ToString()).Value = "'" + b.DESCRIPMOV;

                worksheet.Cell("F" + cont.ToString()).Value = "'" + b.C6_CALMA;
                worksheet.Cell("G" + cont.ToString()).Value = "'" + b.C5_CRFALMA;
                worksheet.Cell("H" + cont.ToString()).Value = "'" + b.C6_CNUMDOC;
                //                worksheet.Cell("I" + cont.ToString()).Value = "'" + b.C6_DFECDOC;
                worksheet.Cell("I" + cont.ToString()).SetValue(b.C6_DFECDOC).Style.DateFormat.SetFormat("dd/mm/yyyy");
                worksheet.Cell("J" + cont.ToString()).Value = "'" + b.C5_CRFTDOC;
                worksheet.Cell("K" + cont.ToString()).Value = "'" + b.C5_CRFNDOC;
                worksheet.Cell("L" + cont.ToString()).Value = "'" + b.C6_CSERIE;
                worksheet.Cell("R" + cont.ToString()).Value = cont == contt ? b.SALDO : 0;

                //  if (ddltipo.SelectedValue == "1")
                worksheet.Cell(letra + cont.ToString()).Value = b.C6_CTD == "PE" ? b.C6_NCANTID : (b.C6_CTD == "PS" ? -1 * b.C6_NCANTID : b.C6_NCANTID);
                //   else
                //     worksheet.Cell(letra + cont.ToString()).Value =b.C6_NCANTID;

                worksheet.Cell("U" + cont.ToString())
               .SetFormulaA1("=SUM(R" + cont.ToString() + ":" + "T" + cont.ToString() + ")");
                worksheet.Cell("V" + cont.ToString()).Value = cont == contt ? worksheet.Cell("U" + cont.ToString()).Value : Convert.ToDecimal(worksheet.Cell("U" + cont.ToString()).Value) + Convert.ToDecimal(worksheet.Cell("V" + (cont - 1).ToString()).Value);
                worksheet.Cell("M" + cont.ToString()).Value = worksheet.Cell("R" + cont.ToString()).Value;
                worksheet.Cell("N" + cont.ToString()).Value = worksheet.Cell("S" + cont.ToString()).Value;
                worksheet.Cell("O" + cont.ToString()).Value = Convert.ToDecimal(worksheet.Cell("T" + cont.ToString()).Value.ToString() == String.Empty ? "0" : worksheet.Cell("T" + cont.ToString()).Value) * -1;
                worksheet.Cell("P" + cont.ToString()).Value = worksheet.Cell("V" + cont.ToString()).Value;



                worksheet.Cell("M" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("N" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("O" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("P" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

                cont++;
            }
            worksheet.Cell("M" + cont.ToString())
           .SetFormulaA1("=SUM(M" + contt.ToString() + ":" + "M" + (cont - 1).ToString() + ")");

            worksheet.Cell("N" + cont.ToString())
         .SetFormulaA1("=SUM(N" + contt.ToString() + ":" + "N" + (cont - 1).ToString() + ")");

            worksheet.Cell("O" + cont.ToString())
         .SetFormulaA1("=SUM(O" + contt.ToString() + ":" + "O" + (cont - 1).ToString() + ")");

            worksheet.Cell("P" + cont.ToString()).Value = Convert.ToDecimal(worksheet.Cell("M" + cont.ToString()).Value) + Convert.ToDecimal(worksheet.Cell("N" + cont.ToString()).Value) - Convert.ToDecimal(worksheet.Cell("O" + cont.ToString()).Value);
            worksheet.Cell("L" + cont.ToString()).Value = "TOTALES: ";

            worksheet.Cell("M" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("N" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("O" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("P" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
        };

        worksheet.Columns("R", "V").Hide();

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

    public void GenerakardexAlmacenResumido(string cod1, string cod2, string fecha1, string fecha2, string alma, string alam_descrip, string tipo)
    {
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");

        // var ff =  AL0003ARTI.ListarArticulosParaKardex("E010010018000", "E010010018000");
        var ff = AL0003ARTI.ListarArticulosParaKardex(cod1.Trim(), cod2.Trim());
        DateTime f1 = Convert.ToDateTime(fecha1);
        DateTime f2 = Convert.ToDateTime(fecha2);

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4").SetValue("KARDEX GENERAL ALMACEN " + alma + " " + alam_descrip).Style.Font.SetBold(true);
        worksheet.Range("C5").SetValue("DESDE " + fecha1 + " al " + fecha2).Style.Font.SetBold(true);
        worksheet.Range("C4:J4").Row(1).Merge();
        worksheet.Range("C5:J5").Row(1).Merge();

        worksheet.Cell("A7").SetValue("CODIGO").Style.Font.SetBold(true);
        worksheet.Cell("B7").SetValue("ARTICULO").Style.Font.SetBold(true);
        worksheet.Cell("C7").SetValue("ANTERIOR").Style.Font.SetBold(true);
        worksheet.Cell("D7").SetValue("ENTRADAS").Style.Font.SetBold(true);
        worksheet.Cell("E7").SetValue("SALIDAS").Style.Font.SetBold(true);
        worksheet.Cell("F7").SetValue("FINAL").Style.Font.SetBold(true);
        //worksheet.Cell("G7").SetValue("ALMA.REF.").Style.Font.SetBold(true);
        //worksheet.Cell("H7").SetValue("NºDOCUM.").Style.Font.SetBold(true);
        //worksheet.Cell("I7").SetValue("FECHA").Style.Font.SetBold(true);
        //worksheet.Cell("J7").SetValue("DR").Style.Font.SetBold(true);
        //worksheet.Cell("K7").SetValue("NºDOCREF").Style.Font.SetBold(true);
        //worksheet.Cell("L7").SetValue("E.SERIE").Style.Font.SetBold(true);

        //worksheet.Cell("M7").SetValue("ANTERIOR").Style.Font.SetBold(true);
        //worksheet.Cell("N7").SetValue("ENTRADAS").Style.Font.SetBold(true);
        //worksheet.Cell("O7").SetValue("SALIDAS").Style.Font.SetBold(true);
        //worksheet.Cell("P7").SetValue("FINAL").Style.Font.SetBold(true);


        //worksheet.Rows().AdjustToContents();
        worksheet.Columns("A").Width = 15;
        worksheet.Columns("B").Width = 50;
        worksheet.Columns("E").Width = 15;
        worksheet.Columns("H").Width = 12;
        worksheet.Columns("I").Width = 11;
        worksheet.Columns("L").Width = 14;

        int cont = 8;
        int contt = 8;

        var letra = string.Empty;

        foreach (var dd in ff)
        {
            AL0003ASER ser = new AL0003ASER()
            {
                C6_CCODIGO = dd.AR_CCODIGO.Trim(),
                C6_DFECCRE = f1,
                C6_DFECDOC = f2,
                C6_CALMA = alma
            };
            //worksheet.Cell("A" + cont1.ToString()).Value = "'" + dd.AR_CDESCRI;

            List<vista_AL0003ASER> vist = null;

            if (ddltipo.SelectedValue == "1")
                vist = AL0003ASER.ListarKardex(ser);
            else
            {
                var arti = AL0003ARTI.obtenerArticuloPorID(dd.AR_CCODIGO.Trim());
                if (arti.AR_CFSERIE.Trim() == "S" || arti.AR_CFLOTE.Trim() == "S")
                    vist = AL0003ASER.ListarKardexResumido(ser);
                else
                    vist = AL0003ASER.ListarKardexResumidoSinLote(ser);

              //  vist = AL0003ASER.ListarKardexResumido(ser);
            }


            //if (vist.Count > 0)
            //{
            //    if (cont != 8)
            //        cont++;
            //}
            if (vist.Count > 0)
            {
                if (cont != 8)
                {
                    
     ///               cont++;
                    contt = cont;
                }
            }

            //contt = cont;

            foreach (var b in vist)
            {
                if (b.C6_CTD == "PE")
                    letra = "S";
                if (b.C6_CTD == "PS")
                    letra = "T";



                worksheet.Cell("A" + cont.ToString()).Value = "'" + b.C6_CCODIGO;
                worksheet.Cell("B" + cont.ToString()).Value = "'" + b.ARTICULO;
                worksheet.Cell("C" + cont.ToString()).Value =  b.SALDO;
                worksheet.Cell("D" + cont.ToString()).Value =  b.entrada;
                worksheet.Cell("E" + cont.ToString()).Value = b.salida;
                worksheet.Cell("F" + cont.ToString()).Value = b.final;

                // worksheet.Cell("F" + cont.ToString()).Value = "'" + b.C6_CALMA;
                //  worksheet.Cell("G" + cont.ToString()).Value = "'" + b.C5_CRFALMA;
                //worksheet.Cell("H" + cont.ToString()).Value = "'" + b.C6_CNUMDOC;
                //                worksheet.Cell("I" + cont.ToString()).Value = "'" + b.C6_DFECDOC;
                //         worksheet.Cell("I" + cont.ToString()).SetValue(b.C6_DFECDOC).Style.DateFormat.SetFormat("dd/mm/yyyy");
                //     worksheet.Cell("J" + cont.ToString()).Value = "'" + b.C5_CRFTDOC;
                //        worksheet.Cell("K" + cont.ToString()).Value = "'" + b.C5_CRFNDOC;
                //      worksheet.Cell("L" + cont.ToString()).Value = "'" + b.C6_CSERIE;
                //    worksheet.Cell("R" + cont.ToString()).Value = cont == contt ? b.SALDO : 0;

                //  if (ddltipo.SelectedValue == "1")
                //        worksheet.Cell(letra + cont.ToString()).Value = b.C6_CTD == "PE" ? b.C6_NCANTID : (b.C6_CTD == "PS" ? -1 * b.C6_NCANTID : b.C6_NCANTID);
                //   else
                //     worksheet.Cell(letra + cont.ToString()).Value =b.C6_NCANTID;

                // worksheet.Cell("U" + cont.ToString())
                //.SetFormulaA1("=SUM(R" + cont.ToString() + ":" + "T" + cont.ToString() + ")");
                // worksheet.Cell("V" + cont.ToString()).Value = cont == contt ? worksheet.Cell("U" + cont.ToString()).Value : Convert.ToDecimal(worksheet.Cell("U" + cont.ToString()).Value) + Convert.ToDecimal(worksheet.Cell("V" + (cont - 1).ToString()).Value);

                // worksheet.Cell("C" + cont.ToString()).Value = worksheet.Cell("R" + cont.ToString()).Value;

                // worksheet.Cell("D" + cont.ToString()).Value = worksheet.Cell("S" + cont.ToString()).Value;
                // worksheet.Cell("E" + cont.ToString()).Value = Convert.ToDecimal(worksheet.Cell("T" + cont.ToString()).Value.ToString() == String.Empty ? "0" : worksheet.Cell("T" + cont.ToString()).Value) * -1;
                // worksheet.Cell("F" + cont.ToString()).Value = worksheet.Cell("V" + cont.ToString()).Value;



                worksheet.Cell("C" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("D" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("E" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
                worksheet.Cell("F" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");

                cont++;
            }
            worksheet.Cell("C" + cont.ToString())
           .SetFormulaA1("=SUM(C" + "8".ToString() + ":" + "C" + (cont - 1).ToString() + ")");

            worksheet.Cell("D" + cont.ToString())
         .SetFormulaA1("=SUM(D" + "8".ToString() + ":" + "D" + (cont - 1).ToString() + ")");

            worksheet.Cell("E" + cont.ToString())
         .SetFormulaA1("=SUM(E" + "8".ToString() + ":" + "E" + (cont - 1).ToString() + ")");

             worksheet.Cell("F" + cont.ToString()).Value = Convert.ToDecimal(worksheet.Cell("C" + cont.ToString()).Value) + Convert.ToDecimal(worksheet.Cell("D" + cont.ToString()).Value) - Convert.ToDecimal(worksheet.Cell("E" + cont.ToString()).Value);
             worksheet.Cell("B" + cont.ToString()).Value = "TOTAL ARTICULOS : ( " + (cont -8).ToString() +")";

            worksheet.Cell("C" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("D" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("E" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
            worksheet.Cell("F" + cont.ToString()).Style.NumberFormat.SetFormat("#,##0.#0");
        };

        worksheet.Columns("R", "V").Hide();

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


    protected void btnBuscar_Click(object sender, EventArgs e)
    {
        if ((ddlalmacen.SelectedValue == "-1"))
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Almacén"), false);
            return;
        }

        if ((txtcodprod1.Text == string.Empty))
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Escriba Artículo Inicial"), false);
            return;
        }
        if ((txtcodprod2.Text == string.Empty ))
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Escriba Artículo Final"), false);
            return;
        }

        if (ddltipo.SelectedValue=="1")
        GenerakardexAlmacen(txtcodprod1.Text, txtcodprod2.Text, txtfechini.Text, txtfechfin.Text, ddlalmacen.SelectedValue, ddlalmacen.SelectedItem.Text, "1");

        if (ddltipo.SelectedValue == "2")
            GenerakardexAlmacenResumido(txtcodprod1.Text, txtcodprod2.Text, txtfechini.Text, txtfechfin.Text, ddlalmacen.SelectedValue, ddlalmacen.SelectedItem.Text, "2");
       
    }







    public void FunExportToExcel(GridView GrdView)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page pagina = new Page();
        HtmlForm form = new HtmlForm();

        GrdView.EnableViewState = false;

        pagina.EnableEventValidation = false;
        pagina.DesignerInitialize();
        pagina.Controls.Add(form);
        form.Controls.Add(GrdView);
        pagina.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }

}
