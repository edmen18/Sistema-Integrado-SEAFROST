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
using System.Drawing;

public partial class FINANZAS_TESORERIA_CHEQUES_EliminarCheque : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblusuario.Text = Convert.ToString(Session["codusu"]);
            VERGRILLA();
            vergrilladet();

            //inicio();
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003COMD16> ConsultaunDetalle(CT0003COMD16 COM)
    {
        return CT0003COMD16.ConsultaunDetalle(COM);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GeneraSecuencia(CT0003CTL416 COM)
    {
        return CT0003CTL416.GeneraSecuencia(COM);
    }
    /// <summary>
    /// EHMM
    /// </summary>CABECERA DEL COMPROBANTE
    /// <param name="CODATA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CT0003COMC16 CABECERA(CT0003COMC16 CODATA)
    {
        return CT0003COMC16.CABECERA(CODATA);
    }


    public void vergrilladet()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("DSECUE");
        dtGetDatae.Columns.Add("DCUENTA");
        dtGetDatae.Columns.Add("DVANEXO");
        dtGetDatae.Columns.Add("DDH");
        dtGetDatae.Columns.Add("DCENCOS");
        dtGetDatae.Columns.Add("DIMPORT");
        dtGetDatae.Columns.Add("DTIPDOC");
        dtGetDatae.Columns.Add("DNUMDOC");
        dtGetDatae.Rows.Add();
        gvdetalle.DataSource = dtGetDatae;
        gvdetalle.DataBind();
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CSUBDIA");
        dtGetDatae.Columns.Add("CCOMPRO");
        dtGetDatae.Columns.Add("CDATE");
        dtGetDatae.Columns.Add("CCODMON");
        dtGetDatae.Columns.Add("CTOTAL");
        dtGetDatae.Columns.Add("CGLOSA");
        dtGetDatae.Columns.Add("CSITUA");
        dtGetDatae.Columns.Add("CEXTOR");
        dtGetDatae.Columns.Add("CTIPCOM");
        dtGetDatae.Columns.Add("CMEMO");        
        dtGetDatae.Rows.Add();
        gvcomprobantes.DataSource = dtGetDatae;
        gvcomprobantes.DataBind();
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }
    public void inicio()
    {
        CT0003COMC16 TABL = new CT0003COMC16();
        TABL.CSUBDIA = "23";
        gvcomprobantes.DataSource = CT0003COMC16.DETALLE(TABL).OrderBy(x => x.CCOMPRO);
        gvcomprobantes.DataBind();

        if (gvcomprobantes.Rows.Count > 0)
        {
            gvcomprobantes.UseAccessibleHeader = true;
            gvcomprobantes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean insertaCabeceraCONTROL16(CT0003CTL416 CONTROL416)
    {
        return CT0003CTL416.insertaCabecera(CONTROL416);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean insertaCabeceraLOG1(CP0003LOG1 LOG1)
    {
        return CP0003LOG1.insertaCabecera(LOG1);
    }
    /// <summary> EDGAR MENDOZA MENDIVES
    /// ACTUALIZAR EL SALDO AL MONTO ANTERIOR EN LA TABLA CARTERA DE PAGO
    /// </summary>CREADO EL 22/08/2016 A LAS 09:10 AM.
    /// <param name="DETA"></param>
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizarSaldo(CP0003CART DETA)
    {
        CP0003CART.ActualizarSaldo(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// UNA VEZ ESTRAIDOS LOS DATOS DE LA TABLA DETALLE COMPROBANTE, SE ACTUALIZAN LOS MONTOS EN LA TABLA BALH16.
    /// </summary>CREADO EL 22/08/2016 A LAS 09:59 AM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean ActualizarBalh(CT0003BALH16 DETA)
    {
        return CT0003BALH16.actualizaredgar(DETA);
    }

    /////////////////////////////////////////////////******* ELIMINACIONES **************************************///////////////////

    /// <summary>EDGAR MENDOZA MENDIVES
    /// ELIMINAR CABECERA DEL COMPROBANTE
    /// </summary>CREADO EL 22/08/2016 A LAS 01:07 PM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaComc16(CT0003COMC16 DETA)
    {
        CT0003COMC16.Elimina(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// ELIMINAR PAGO
    /// </summary>CREADO EL 22/08/2016 A LAS 01:07 PM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaPago(CP0003PAGO DETA)
    {
        CP0003PAGO.Elimina(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// ELIMINAR CHEQUE
    /// </summary>CREADO EL 22/08/2016 A LAS 01:08 PM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaCheque(CP0003CHEQ DETA)
    {
        CP0003CHEQ.Elimina(DETA);
    }
    /// <summary>EDGAR MENDOZA MENDIVES
    /// ELIMINAR DETALLE COMPROBANTE
    /// </summary>CREADO EL 22/08/2016 A LAS 01:08 PM.
    /// <param name="DETA"></param>
    /// <returns></returns>

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void EliminaComd16(CT0003COMD16 DETA)
    {
        CT0003COMD16.Elimina(DETA);
    }

    protected void btnver_Click(object sender, EventArgs e)
    {
        CT0003COMC16 TABL = new CT0003COMC16();
        TABL.CSUBDIA = "23";
        TABL.CCOMPRO = txtcomprobanteb.Text;
        TABL.CGLOSA = txtchequeb.Text;
        gvcomprobantes.DataSource = CT0003COMC16.DETALLE(TABL).OrderBy(x => x.CCOMPRO);
        gvcomprobantes.DataBind();

        if (gvcomprobantes.Rows.Count > 0)
        {
            gvcomprobantes.UseAccessibleHeader = true;
            gvcomprobantes.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}