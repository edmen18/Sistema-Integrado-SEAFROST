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

public partial class RetrasoRequerimiento : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetalle();
       
     }
    //protected void HyperLink1_Click(object sender, EventArgs e)

    //{
    //    if (!this.IsPostBack)
    //    {
    //        ClientScript.RegisterStartupScript(GetType(), "Funcion", "porcinco1();", true);
    //    }

    //}

    public void ListaDetalle()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("RC_CNROREQ");
        dtGetDatae.Columns.Add("RC_DFECREQ");
        dtGetDatae.Columns.Add("PROVEEDOR");
        dtGetDatae.Columns.Add("ESTADO");
        dtGetDatae.Columns.Add("APROBAC");
        dtGetDatae.Columns.Add("RC_DFECA03");
        dtGetDatae.Columns.Add("RC_CNUMORD");
        dtGetDatae.Columns.Add("USUARIO");
        dtGetDatae.Columns.Add("RC_CCENCOS");
        dtGetDatae.Columns.Add("PRIORIDAD");
        dtGetDatae.Columns.Add("USO");
        dtGetDatae.Columns.Add("RC_DFECA01");
        dtGetDatae.Columns.Add("RC_DFECA02");

        dtGetDatae.Columns.Add("RC_CUSEA01");
        dtGetDatae.Columns.Add("RC_CUSEA02");
        dtGetDatae.Columns.Add("RC_CUSEA03");

        dtGetDatae.Rows.Add();
        gvRequerimientos.DataSource = dtGetDatae;
        gvRequerimientos.DataBind();

        DataTable dtGetDatae1 = new DataTable();
        dtGetDatae1.Columns.Add("RD_CITEM");
        dtGetDatae1.Columns.Add("RD_CCODIGO");
        dtGetDatae1.Columns.Add("RD_CDESCRI");
        dtGetDatae1.Columns.Add("RD_CUNID");
        dtGetDatae1.Columns.Add("RD_NQPEDI");
        dtGetDatae1.Columns.Add("RD_COBS");
        dtGetDatae1.Rows.Add();
        gvdetalle.DataSource = dtGetDatae1;
        gvdetalle.DataBind();

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> ListarReqIni()
    {
        return AL0003REQC.RPTRETRASOS5();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQRETRASO> RETRASOS()
    {
        return AL0003REQC.RPTRETRASOS();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> RETRASOS59()
    {
        return AL0003REQC.RPTRETRASOS59();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> RETRASOS1015()
    {
        return AL0003REQC.RPTRETRASOS1015();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> RETRASOSMAS15()
    {
        return AL0003REQC.RPTRETRASOSMAS15();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_REQUERIMIENTOS> RETRASOSTODOS()
    {
        return AL0003REQC.RPTRETRASOSTODOS();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_AL0003REQD> ListarReqDetalle(AL0003REQD REQ)
    {
        return AL0003REQD.ListarRequerimientosPorCodigo(REQ);
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
            var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add("Hoja 1");
            List<VISTA_REQRETRASO> vista = new List<VISTA_REQRETRASO>();
            AL0003REQC tabla = new AL0003REQC();

            worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
            worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
            worksheet.Range("A2:J2").Row(1).Merge();
            worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
            worksheet.Range("A3:J3").Row(1).Merge();
            worksheet.Range("C4").SetValue("Reporte de Requerimientos Pendientes de Atención").Style.Font.SetBold(true);
            worksheet.Range("C4:J4").Row(1).Merge();

        worksheet.Cell("A5").SetValue("DÍAS TRANSCURRIDOS").Style.Font.SetBold(true);
        worksheet.Cell("A6").SetValue("NÙMERO DE REQUERIMIENTOS").Style.Font.SetBold(true);
        worksheet.Cell("A7").SetValue("PORCENTAJE").Style.Font.SetBold(true);

        worksheet.Cell("B5").SetValue("MENOR A 5 DÍAS").Style.Font.SetBold(true);
        worksheet.Cell("C5").SetValue("DE 5 A 9 DÍAS").Style.Font.SetBold(true);
        worksheet.Cell("D5").SetValue("DE 10 A 15 DÍAS").Style.Font.SetBold(true);
        worksheet.Cell("E5").SetValue("MAYOR DE 15 DÍAS").Style.Font.SetBold(true);
        worksheet.Cell("F5").SetValue("TOTAL").Style.Font.SetBold(true);


        vista = AL0003REQC.RPTRETRASOS();
                         
                foreach (VISTA_REQRETRASO b in vista)
                {
                        worksheet.Cell("B6").Value = b.CINCO;
                        worksheet.Cell("C6").Value =b.CINCONUEVE;
                        worksheet.Cell("D6").Value = b.DIEZQUINCE;
                        worksheet.Cell("E6").Value = b.QUINCEMAS;
                        worksheet.Cell("F6").Value = b.TOTALREQ;

                        worksheet.Cell("B7").Value = ((Convert.ToDecimal(b.CINCO) * 100) / Convert.ToDecimal(b.TOTALREQ));
               
                        worksheet.Cell("C7").Value = ((Convert.ToDecimal(b.CINCONUEVE) * 100) / Convert.ToDecimal(b.TOTALREQ)) ;
                        worksheet.Cell("D7").Value = ((Convert.ToDecimal(b.DIEZQUINCE) * 100) / Convert.ToDecimal(b.TOTALREQ));
                        worksheet.Cell("E7").Value = ((Convert.ToDecimal(b.QUINCEMAS) * 100) / Convert.ToDecimal(b.TOTALREQ));
                        worksheet.Cell("F7").Value = ((Convert.ToDecimal(b.TOTALREQ) * 100) / Convert.ToDecimal(b.TOTALREQ));

                        worksheet.Cell("B7").Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("C7").Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("D7").Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("E7").Style.NumberFormat.SetFormat("#,##0.#0");
                        worksheet.Cell("F7").Style.NumberFormat.SetFormat("#,##0.#0");

        }                      
            Response.Clear();
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            Response.AddHeader("content-disposition", "attachment;filename=\"RequerimientosPendientes.xlsx\"");

            using (var memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
            }
            Response.End();
        
    }
}