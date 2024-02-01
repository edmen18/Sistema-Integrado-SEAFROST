﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;


public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ListaDetallepopup();

    }

    public void ListaDetallepopup()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("TA_CODIGO");
        dtGetDatae.Columns.Add("TA_DESCRIPCION");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }



    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOS()

    {
        return T_CALIDAD_TIPO_ANALISIS.ListarTA();

    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOSPARAM(T_CALIDAD_TIPO_ANALISIS DATO)

    {
        return T_CALIDAD_TIPO_ANALISIS.ListarTAPARAMETRO(DATO);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(T_CALIDAD_TIPO_ANALISIS DETA)
    {
        T_CALIDAD_TIPO_ANALISIS.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(T_CALIDAD_TIPO_ANALISIS DETA)
    {
        T_CALIDAD_TIPO_ANALISIS.actualizaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud)
    {
        return T_CALIDAD_TIPO_ANALISIS.GeneraNroSolicitud(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_TIPO_ANALISIS> GETDATOS(string productos)
    {
        return T_CALIDAD_TIPO_ANALISIS.LISTARAUTOCOMPLETE(productos);
    }

}