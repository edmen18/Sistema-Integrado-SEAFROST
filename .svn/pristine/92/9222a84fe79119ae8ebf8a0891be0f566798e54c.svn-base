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
        dtGetDatae.Columns.Add("PR_CODIGO");
        dtGetDatae.Columns.Add("PR_DESCRIPCION");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }



    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOS()

    {
        return T_CALIDAD_PRODUCTO.ListarTA();

    }


    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TIPOANALISIS> LISTARDATOSPARAM(T_CALIDAD_PRODUCTO DATO)

    {
        return T_CALIDAD_PRODUCTO.ListarTAPARAMETRO(DATO);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(T_CALIDAD_PRODUCTO DETA)
    {
        T_CALIDAD_PRODUCTO.insertaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(T_CALIDAD_PRODUCTO DETA)
    {
        T_CALIDAD_PRODUCTO.actualizaSolicitud(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR(string solicitud)
    {
        return T_CALIDAD_PRODUCTO.GeneraNroSolicitud(solicitud);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<T_CALIDAD_PRODUCTO> GETDATOS(string productos)
    {
        return T_CALIDAD_PRODUCTO.LISTARAUTOCOMPLETE(productos);
    }

}