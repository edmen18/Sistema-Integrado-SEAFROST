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

public partial class MANTENIMIENTO_AprobarSolicitud : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
       
         if (!this.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            ACCESO();
            // area
            tabla_area area = new tabla_area();
            area.AE_DESC = string.Empty;
            ddlarea.Items.Clear();
            ddlarea.DataTextField = "SA_DESC";
            ddlarea.DataValueField = "SA_ID";
            ddlarea.DataSource = tabla_subareas.Listarsubareas();
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("[AREAS]", "-1"));

            //ddlare.Items.Clear();
            //ddlare.DataTextField = "SA_DESC";
            //ddlare.DataValueField = "SA_ID";
            //ddlare.DataSource = tabla_subareas.Listarsubareas();
            //ddlare.DataBind();

            // PLANTA
            tabla_planta PLANTA = new tabla_planta();
            PLANTA.PL_DESCRIPCION = string.Empty;
            ddlplanta.Items.Clear();
            ddlplanta.DataTextField = "PL_DESCRIPCION";
            ddlplanta.DataValueField = "PL_CODIGO";
            ddlplanta.DataSource = tabla_planta.ListarPLANTA();
            ddlplanta.DataBind();
            ddlplanta.Items.Insert(0, new ListItem("[PLANTAS]", "-1"));

            //ddlplant.Items.Clear();
            //ddlplant.DataTextField = "PL_DESCRIPCION";
            //ddlplant.DataValueField = "PL_CODIGO";
            //ddlplant.DataSource = tabla_planta.ListarPLANTA();
            //ddlplant.DataBind();


            // EQUIPO
            tabla_equipo equipo = new tabla_equipo();
            equipo.EQ_DESCRIPCION = string.Empty;
            ddlequipo.Items.Clear();
            ddlequipo.DataTextField = "EQ_DESCRIPCION";
            ddlequipo.DataValueField = "EQ_CODIGO";
            ddlequipo.DataSource = tabla_equipo.ListarEquipos();
            ddlequipo.DataBind();
            ddlequipo.Items.Insert(0, new ListItem("[EQUIPOS]", "-1"));

            //ddlequip.Items.Clear();
            //ddlequip.DataTextField = "EQ_DESCRIPCION";
            //ddlequip.DataValueField = "EQ_CODIGO";
            //ddlequip.DataSource = tabla_equipo.ListarEquipos();
            //ddlequip.DataBind();

            // MONEDA

            //AL0003TABL TAB = new AL0003TABL();
            //TAB.TG_CCOD = "03";
            //TAB.TG_CDESCRI = string.Empty;
            //ddlmoneda.Items.Clear();
            //ddlmoneda.DataTextField = "TG_CDESCRI";
            //ddlmoneda.DataValueField = "TG_CCLAVE";
            //ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TAB);
            //ddlmoneda.DataBind();
            VERGRILLA();
            inicio();

            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");

        }
    }

    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("COD_SOLICITUD");
        dtGetDatae.Columns.Add("FECHA_SOL");
        dtGetDatae.Columns.Add("TR_CODIGO");
        dtGetDatae.Columns.Add("DESCRIPCION");
        dtGetDatae.Columns.Add("PMO_ANTERIOR");
        dtGetDatae.Columns.Add("PM_ANTERIOR");
        dtGetDatae.Columns.Add("PE_ANTERIOR");
        dtGetDatae.Columns.Add("PRES_ANTERIOR");
        dtGetDatae.Columns.Add("PMO_NUEVO");
        dtGetDatae.Columns.Add("PM_NUEVO");
        dtGetDatae.Columns.Add("PE_NUEVO");
        dtGetDatae.Columns.Add("PRES_NUEVO");
        dtGetDatae.Columns.Add("ESTADO");
        dtGetDatae.Columns.Add("USU_APRO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
   protected void btnbuscar_Click(object sender, EventArgs e)
    {
        VISTA_TRABAJO var = new VISTA_TRABAJO();
        var.AE_COD = Convert.ToInt32(ddlarea.Text);
        var.PL_CODIGO = ddlplanta.Text;
        var.EQ_CODIGO = ddlequipo.Text;
        if (this.txtcodcencosto0.Text == "")
        {
            var.COD_CENCOS = "-1";
        }
        else
        {
            var.COD_CENCOS = this.txtcodcencosto0.Text;
        }
        if (txtfecha1.Text == "")
        {
            var.FECHA = Convert.ToDateTime("01/05/2016");
        }
        else
        {
            var.FECHA = Convert.ToDateTime(txtfecha1.Text);
        }
        if (txtfecha2.Text == "")
        {
            var.FECHAFIN = DateTime.Today;
        }
        else
        {
            var.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
        }

        var.ESTADO = ddlestado.Text;
        gvordencompra.DataSource = tabla_modpresupuesto.listarparametros(var);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
    protected void griddata_RowCreated(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            e.Row.Attributes.Add("onmouseover", "this.originalstyle=this.style.backgroundColor;this.style.backgroundColor='#c5c5ce'");
            e.Row.Attributes.Add("onmouseout", "this.style.backgroundColor=this.originalstyle;");
        }
    }

    protected void btreporte_Click(object sender, EventArgs e)
    {
       

    }

    public void inicio()
    {
        gvordencompra.DataSource = tabla_modpresupuesto.ListaTodos();
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TRABAJO> traerdatos(tabla_trabajo VC)
    {
        return tabla_trabajo.ConsultaUno(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_trabajo DETA)
    {
        tabla_trabajo.ActPresupuesto(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_SOLICITUD_EXTENSION> traerdatossolicitud(tabla_modpresupuesto VC)
    {
        return tabla_modpresupuesto.ConsultaUno(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETALLE_TRABAJOCURSO> SUMATORIA(tabla_trabajo VC)
    {
        return tabla_trabajo.SUMDETALLE(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void cambiarestado(tabla_modpresupuesto COAPRUEBA)
    {
       tabla_modpresupuesto.Cambiarestado(COAPRUEBA);

    }
    public void ACCESO()
    {
        int contador = tabla_permiso_presupuesto.CuentaAccesoADoc(lblusuario.Text);

        if (contador > 0)
        {

            lblacceso.Text = Convert.ToString(contador);
        }
        else
        {
            lblacceso.Text = "0";
        }

    }
}