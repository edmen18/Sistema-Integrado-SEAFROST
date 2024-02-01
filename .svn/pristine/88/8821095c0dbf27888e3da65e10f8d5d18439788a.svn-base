using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using CapaNegocio;

public partial class MANTENIMIENTO_AprobacionTrabajos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            lblusuario.Text = Convert.ToString(Session["codusu"]);

            ddltipo.Items.Clear();
            ddltipo.DataTextField = "TIPO";
            ddltipo.DataValueField = "COD";
            ddltipo.DataSource = tabla_trabajo_tipo.ListaTipo();
            ddltipo.DataBind();
            ddltipo.Items.Insert(0, new ListItem("[NINGUNO]", "-1"));

           


            // area
            tabla_area area = new tabla_area();
            area.AE_DESC = string.Empty;
            ddlarea.Items.Clear();
            ddlarea.DataTextField = "SA_DESC";
            ddlarea.DataValueField = "SA_ID";
            ddlarea.DataSource = tabla_subareas.Listarsubareas();
            ddlarea.DataBind();
            ddlarea.Items.Insert(0, new ListItem("[AREAS]", "-1"));
            ddlare.Items.Clear();
            ddlare.DataTextField = "SA_DESC";
            ddlare.DataValueField = "SA_ID";
            ddlare.DataSource = tabla_subareas.ListarsubareasED();
            ddlare.DataBind();


            // PLANTA
            tabla_planta PLANTA = new tabla_planta();
            PLANTA.PL_DESCRIPCION = string.Empty;
            ddlplanta.Items.Clear();
            ddlplanta.DataTextField = "PL_DESCRIPCION";
            ddlplanta.DataValueField = "PL_CODIGO";
            ddlplanta.DataSource = tabla_planta.ListarPLANTA();
            ddlplanta.DataBind();
            ddlplanta.Items.Insert(0, new ListItem("[PLANTAS]", "-1"));
            ddlplant.Items.Clear();
            ddlplant.DataTextField = "PL_DESCRIPCION";
            ddlplant.DataValueField = "PL_CODIGO";
            ddlplant.DataSource = tabla_planta.ListarPLANTA();
            ddlplant.DataBind();


            // EQUIPO
            tabla_equipo equipo = new tabla_equipo();
            equipo.EQ_DESCRIPCION = string.Empty;
            ddlequipo.Items.Clear();
            ddlequipo.DataTextField = "EQ_DESCRIPCION";
            ddlequipo.DataValueField = "EQ_CODIGO";
            ddlequipo.DataSource = tabla_equipo.ListarEquipos();
            ddlequipo.DataBind();
            ddlequipo.Items.Insert(0, new ListItem("[EQUIPOS]", "-1"));
            ddlequip.Items.Clear();
            ddlequip.DataTextField = "EQ_DESCRIPCION";
            ddlequip.DataValueField = "EQ_CODIGO";
            ddlequip.DataSource = tabla_equipo.ListarEquipos();
            ddlequip.DataBind();

            AL0003TABL TAB = new AL0003TABL();
            TAB.TG_CCOD = "03";
            TAB.TG_CDESCRI = string.Empty;
            ddlmoneda.Items.Clear();
            ddlmoneda.DataTextField = "TG_CDESCRI";
            ddlmoneda.DataValueField = "TG_CCLAVE";
            ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TAB);
            ddlmoneda.DataBind();


            VERGRILLA();
            VERDETALLE();
            inicio();
            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }
    }
    public void VERGRILLA()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("TR_CODIGO");
        dtGetDatae.Columns.Add("FECH");
        dtGetDatae.Columns.Add("AE_DESC");
        dtGetDatae.Columns.Add("EQ_DESCRIPCION");
        dtGetDatae.Columns.Add("PL_DESCRIPCION");
        dtGetDatae.Columns.Add("CONTRATISTA");
        dtGetDatae.Columns.Add("CENTRO_COSTO");
        dtGetDatae.Columns.Add("DESCRIPCION");
        dtGetDatae.Columns.Add("CONTROL_ACTIVOS");
        dtGetDatae.Columns.Add("ESTADO");
        dtGetDatae.Columns.Add("USU1");
        dtGetDatae.Columns.Add("USU2");
        dtGetDatae.Columns.Add("USU3");
        dtGetDatae.Columns.Add("TIPO");
        dtGetDatae.Rows.Add();
        gvordencompra.DataSource = dtGetDatae;
        gvordencompra.DataBind();
    }
    public void VERDETALLE()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CODIGO");
        dtGetDatae.Columns.Add("DOCUMENTO");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("MONEDA");
        dtGetDatae.Columns.Add("MONTO");
        dtGetDatae.Rows.Add();
        //GridView1.DataSource = dtGetDatae;
        //GridView1.DataBind();
    }
    
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETALLE_TRABAJOCURSO> ListarDetalleFACCAR(tabla_trabajo VC)
    {
        return tabla_detalle.DETALLE(VC);

    }
    protected void btnbuscar_Click(object sender, EventArgs e)
    {
        //if ((Convert.ToString(txtfecha1.Text).Equals("")) || (Convert.ToString(txtfecha2.Text).Equals("")))
        //{
        //    ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Debe Ingresar un Rango de fechas"), false);
        //}
        //else
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
            var.ESTADO = ddlestado.Text;
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
            gvordencompra.DataSource = tabla_trabajo.ListarTrabajos(var);
            gvordencompra.DataBind();

            if (gvordencompra.Rows.Count > 0)
            {
                gvordencompra.UseAccessibleHeader = true;
                gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
            }
        }

       
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void aprobaroc(tabla_trabajo COAPRUEBA)
    {
        tabla_trabajo.AprobarSol(COAPRUEBA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TRABAJO> traerdatos(tabla_trabajo VC)
    {
        return tabla_trabajo.ConsultaUno(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETTRABAJO> ListarDetalle(VISTA_DETTRABAJO VC)
    {
        return tabla_detalle.ListarDL(VC);

    }
    public void inicio()
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
        //var.FECHA = Convert.ToDateTime(txtfecha1.Text);
        //var.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
        gvordencompra.DataSource = tabla_trabajo.ListarTrabajosPendientesApro(var);
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
}