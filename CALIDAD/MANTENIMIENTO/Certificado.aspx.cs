using System;
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
        dtGetDatae.Columns.Add("TC_CODIGO");
        dtGetDatae.Columns.Add("TC_DESCRIPCION");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }



    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOS()

    {
        return T_CALIDAD_TIPO_CERTIFICADO.ListarTA();

    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOSPARAM(T_CALIDAD_TIPO_CERTIFICADO DATO)

    {
        return T_CALIDAD_TIPO_CERTIFICADO.ListarTAPARAMETRO(DATO);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(T_CALIDAD_TIPO_CERTIFICADO DETA)
    {
        T_CALIDAD_TIPO_CERTIFICADO.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(T_CALIDAD_TIPO_CERTIFICADO DETA)
    {
        T_CALIDAD_TIPO_CERTIFICADO.actualizaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud)
    {
        return T_CALIDAD_TIPO_CERTIFICADO.GeneraNroSolicitud(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_TIPO_CERTIFICADO> GETDATOS(string productos)
    {
        return T_CALIDAD_TIPO_CERTIFICADO.LISTARAUTOCOMPLETE(productos);
    }

}