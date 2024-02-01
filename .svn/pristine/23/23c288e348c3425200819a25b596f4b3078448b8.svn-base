using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Web;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
public partial class ORDENCOMPRA_REPORTES_RptAnticipoProv : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        {

            try
            {
                string idoc = Convert.ToString(Request.QueryString["ID"]);
                tabla_anticipo TABL = new tabla_anticipo();

                TABL.OC_CCODPRO = idoc.Trim();

                ReportDocument report = new ReportDocument();
                report.Load(Server.MapPath("Cr_AnticiposProv.rpt"));
                report.SetDataSource(tabla_anticipo.SAreportes(TABL));
                CrystalReportViewer1.ReportSource = report;
            }
            catch
            {
                throw;
            }
        }

    }

    //protected void Button1_Click(object sender, EventArgs e)
    //{
    //    // Declarar variables y obtener las opciones de exportación.
    //    CrystalDecisions.ReportAppServer.ReportDefModel.ExportOptions exportOpts = new ExportOptions();
    //    ExcelFormatOptions excelFormatOpts = new ExcelFormatOptions();
    //    DiskFileDestinationOptions diskOpts = new DiskFileDestinationOptions();
    //    exportOpts = Report.ExportOptions;

    //    // Establecer las opciones de formato de Excel.
    //    excelFormatOpts.ExcelUseConstantColumnWidth = true;
    //    exportOpts.ExportFormatType = ExportFormatType.Excel;
    //    exportOpts.FormatOptions = excelFormatOpts;

    //    // Establecer las opciones de archivo de disco y de exportación.
    //    exportOpts.ExportDestinationType = ExportDestinationType.DiskFile;
    //    diskOpts.DiskFileName = fileName;
    //    exportOpts.DestinationOptions = diskOpts;

    //    Report.Export();
    //}
}