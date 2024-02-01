﻿using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class FINANZAS_TESORERIA_PAGOSBT_Reportes_IComprobante : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            string SUB = Convert.ToString(Request.QueryString["SUB"]);
            string COMP = Convert.ToString(Request.QueryString["COMP"]);
            string FCOMP = Convert.ToString(Request.QueryString["FCOMP"]);
            string CANT = Convert.ToString(Request.QueryString["CANT"]);

            vista_comprobante DATA = new vista_comprobante();
            DATA.DSUBDIA = SUB;
            DATA.DCOMPRO = COMP;
            DATA.DFECCOM = FCOMP;

            ReportDocument report = new ReportDocument();
            ExportOptions exportOpts = new ExportOptions();
            PdfRtfWordFormatOptions pdfOpts = ExportOptions.CreatePdfFormatOptions();
            exportOpts.ExportFormatType = ExportFormatType.PortableDocFormat;
            exportOpts.ExportFormatOptions = pdfOpts;

            report.Load(Server.MapPath("IComprobante.rpt"));
            List<vista_comprobante> prueba1 = new List<vista_comprobante>();
            var milista = CT0003COMC16.consultaMiComprobante(DATA);
            var count = 0;var count2 = 0;
            foreach (var lista in milista)
            {
                count2++;
                vista_comprobante prueba2 = new vista_comprobante();
                prueba2.idCount = count;
                prueba2.CGLOSA = lista.CGLOSA;
                prueba2.CFLAG = lista.CFLAG;
                prueba2.CTIPO = lista.CTIPO;
                prueba2.CTIPCAM = lista.CTIPCAM;
                prueba2.CUSER = lista.CUSER;
                prueba2.DSUBDIA = lista.DSUBDIA;
                prueba2.DCOMPRO = lista.DCOMPRO;
                prueba2.DSDESCRI = lista.DSDESCRI;
                prueba2.DCUENTA = lista.DCUENTA;
                prueba2.DCODANE = lista.DCODANE;
                prueba2.AC_CNOMBRE = lista.AC_CNOMBRE;
                prueba2.DCODMON = lista.DCODMON;
                prueba2.DTIPDOC = lista.DTIPDOC;
                prueba2.DNUMDOC = lista.DNUMDOC;
                prueba2.DAREA = lista.DAREA;
                prueba2.DXGLOSA = lista.DXGLOSA;
                prueba2.DIMPORT = lista.DIMPORT;
                prueba2.DDH = lista.DDH;
                prueba2.DSECUE = lista.DSECUE;
                prueba2.DVANEXO = lista.DVANEXO;
                prueba2.DCENCOS = lista.DCENCOS;
                prueba2.DMNIMPOR = lista.DMNIMPOR;
                prueba2.DUSIMPOR = lista.DUSIMPOR;
                prueba2.DFECCOM2 = lista.DFECCOM2;
                prueba2.DFECDOC2 = lista.DFECDOC2;
                prueba2.DFECVEN2 = lista.DFECVEN2;
                prueba2.DMEDPAG = lista.DMEDPAG;
                prueba2.DMEDPAG = lista.DMEDPAG;
                if (count2==Convert.ToInt32(CANT))
                {
                    count++;
                    count2 = 0;
                }
                prueba1.Add(prueba2);
            }
            report.SetDataSource(prueba1);
            
            System.IO.Stream oStream = null;
            byte[] byteArray = null;
            oStream = report.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
            byteArray = new byte[oStream.Length];
            oStream.Read(byteArray, 0, Convert.ToInt32(oStream.Length - 1));
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "application/pdf";
            Response.BinaryWrite(byteArray);
            Response.Flush();
            Response.Close();
            report.Close();
            report.Dispose();
        }
        catch
        {
            throw;
        }
    }
}

