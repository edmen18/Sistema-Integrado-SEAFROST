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
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)

    {
        //txtfechainicio.Text = DateTime.Now.ToString("dd/MM/yyyy");
        //txtfechafin.Text = DateTime.Now.ToString("dd/MM/yyyy");
       

        if (!this.IsPostBack)
        {
            //this.txtfecha.Text = Convert.ToString(DateTime.Now.Date);
            txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
            txtfecha2.Text = DateTime.Now.ToString("dd/MM/yyyy");
            lblusuario.Text = Convert.ToString(Session["codusu"]);
            ACCESO();

            ddltipo.Items.Clear();
            ddltipo.DataTextField = "TIPO";
            ddltipo.DataValueField = "COD";
            ddltipo.DataSource = tabla_trabajo_tipo.ListaTipo();
            ddltipo.DataBind();
            //ddltipo.Items.Insert(0, new ListItem("[TIPO]", "-1"));
            
            // area
            tabla_area area = new tabla_area();
            area.AE_DESC = string.Empty;
            ddlarea.Items.Clear();
            ddlarea.DataTextField = "SA_DESC";
            ddlarea.DataValueField = "SA_ID";
            ddlarea.DataSource = tabla_subareas.ListarsubareasED();
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

            // MONEDA

            AL0003TABL TAB = new AL0003TABL();
            TAB.TG_CCOD = "03";
            TAB.TG_CDESCRI = string.Empty;
            ddlmoneda.Items.Clear();
            ddlmoneda.DataTextField = "TG_CDESCRI";
            ddlmoneda.DataValueField = "TG_CCLAVE";
            ddlmoneda.DataSource = AL0003TABL.ListarTablaS(TAB);
            ddlmoneda.DataBind();

            //// tipo documento
            //tabla_tipo_doc TA = new tabla_tipo_doc();
            //TA.TD_DESCRIPCION = string.Empty;
            //ddltipodoc.Items.Clear();
            //ddltipodoc.DataTextField = "TD_DESCRIPCION";
            //ddltipodoc.DataValueField = "COD_TIPO";
            //ddltipodoc.DataSource = tabla_tipo_doc.ListarTipoDoc();
            //ddltipodoc.DataBind();

            VERGRILLA();
            VERDETALLE();
            VERDETALLE1();
            VERDETALLEDOC();
            VERDETALLESOL();
            INICIO();


        }

    }
    public void ACCESO()
    {
        int contador = tabla_permiso_presupuesto.CuentaAccesovalidar(lblusuario.Text);

        if (contador > 0)
        {

            lblacceso.Text = Convert.ToString(contador);
        }
        else
        {
            lblacceso.Text = "0";
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
        dtGetDatae.Columns.Add("acumulado");
        dtGetDatae.Columns.Add("PRESUPUESTO");
        dtGetDatae.Columns.Add("PRES_MANOBRA");
        dtGetDatae.Columns.Add("PRES_MATERIAL");
        dtGetDatae.Columns.Add("PRES_EQUIPOS");
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
        GridView1.DataSource = dtGetDatae;
        GridView1.DataBind();
    }

    public void VERDETALLE1()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("CODIGO");
        dtGetDatae.Columns.Add("DOCUMENTO");
        dtGetDatae.Columns.Add("FECHA");
        dtGetDatae.Columns.Add("MONTOMN");
        dtGetDatae.Columns.Add("MONTOUS");
        dtGetDatae.Rows.Add();
        GridView2.DataSource = dtGetDatae;
        GridView2.DataBind();
    }

    public void VERDETALLEDOC()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ITEM");
        dtGetDatae.Columns.Add("DESCRIPCION");
        dtGetDatae.Columns.Add("UNIDAD");
        dtGetDatae.Columns.Add("CANTIDAD");
        dtGetDatae.Columns.Add("PRECIODOLARES");
        dtGetDatae.Columns.Add("PRECIOSOLES");

        dtGetDatae.Columns.Add("IGV");
        dtGetDatae.Columns.Add("TOTALD");
        dtGetDatae.Columns.Add("TOTALS");
        dtGetDatae.Rows.Add();
        GridView3.DataSource = dtGetDatae;
        GridView3.DataBind();
    }

    public void VERDETALLESOL()
    {
        DataTable dtGetDatae = new DataTable();
        dtGetDatae.Columns.Add("ITEM");
        dtGetDatae.Columns.Add("DESCRIPCION");
        dtGetDatae.Columns.Add("UNIDAD");
        dtGetDatae.Columns.Add("CANTIDAD");
        dtGetDatae.Columns.Add("PRECIOSOLES");      
        dtGetDatae.Columns.Add("TOTALD");
        dtGetDatae.Columns.Add("TOTALS");
        dtGetDatae.Rows.Add();
        GridView4.DataSource = dtGetDatae;
        GridView4.DataBind();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string maximo(tabla_avances data)
    {
        return tabla_avances.maximo(data);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string tc(CTCAMB data)
    {
        return CTCAMB.obetenertcambioEdgar(data);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> GETVARIOS(string CLAVE, string INDICADOR)
    {
        return AL0003TABL.ListarvARIOS(CLAVE, INDICADOR);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CO0003MOVC> getordenes(CO0003MOVC productos)
    {
        return CO0003MOVC.Listarordenautocompletetc(productos);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string getporcentaje()
    {
        return tabla_porcentaje.actual();
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003REQC> getreque(AL0003REQC reques)
    {
        return AL0003REQC.ListarReqautocomplete(reques);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string productos)
    {
        CT0003ANEX ADATA = new CT0003ANEX()
        {
            AVANEXO = "P",
            ADESANE = productos,
            ARUC = productos,
        };

        return CT0003ANEX.listarAnexoT(ADATA);
       
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void deleteDet(tabla_detalle DETA)
    {
        tabla_detalle.EliminaItems(DETA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETTRABAJO> ListarDetalle(VISTA_DETTRABAJO VC)
    {
        return tabla_detalle.ListarDL(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETALLE_TRABAJOCURSO> ListarDetalleFACCAR(tabla_trabajo VC)
    {
        return tabla_detalle.DETALLE(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_DETALLE_TRABAJOCURSO> ListarDetalleAcum(tabla_trabajo VC)
    {
        return tabla_solicitud.DETALLE2(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_oc_req> LISTARDETORDEN(CO0003MOVD VC)
    {
        return CO0003MOVD.detalleorden(VC);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_oc_req> LISTARDETSOLICITUD(tabla_d_solicitud VC)
    {
        return tabla_d_solicitud.detallesolicitud(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<vista_detalle_oc_req> LISTARDETREQUER(AL0003REQD VC)
    {
        return AL0003REQD.detallereque(VC);

    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDet(tabla_trabajo DETA)
    {
        tabla_trabajo.inserta(DETA);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void valida(tabla_trabajo DETA)
    {
        tabla_trabajo.ActValidacion(DETA);
    }




    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaAnticipo(tabla_trabajo DETA)
    {
        tabla_trabajo.actualiza(DETA);
    }

   
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string GENERAR()
    {
        return tabla_trabajo.GenerarCodigo();
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaDetalle(tabla_detalle DETAIL)
    {
        tabla_detalle.insertaItem(DETAIL);
    }

    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<VISTA_TRABAJO> traerdatos(tabla_trabajo VC)
    {
        return tabla_trabajo.ConsultaUno(VC);

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




        gvordencompra.DataSource = tabla_trabajo.LISTADODETRABAJOS(var);
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
        var workbook = new XLWorkbook();
        var worksheet = workbook.Worksheets.Add("Hoja 1");
        int cont2 = 7;
        VISTA_TRABAJO trabajo = new VISTA_TRABAJO();
        trabajo.AE_COD = Convert.ToInt32(ddlarea.Text);
        trabajo.PL_CODIGO = ddlplanta.Text;
        trabajo.EQ_CODIGO = ddlequipo.Text;
        if (this.txtcodcencosto0.Text == "")
        {
            trabajo.COD_CENCOS = "-1";
        }
        else
        {
            trabajo.COD_CENCOS = this.txtcodcencosto0.Text;
        }
        if (txtfecha1.Text == "")
        {
            trabajo.FECHA = Convert.ToDateTime("01/05/2016");
        }
        else
        {
            trabajo.FECHA = Convert.ToDateTime(txtfecha1.Text);
        }
        if (txtfecha2.Text == "")
        {
            trabajo.FECHAFIN = DateTime.Today;
        }
        else
        {
            trabajo.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
        }
        trabajo.ESTADO = ddlestado.Text;

        tabla_trabajo trabajodet = new tabla_trabajo();

        List<VISTA_TRABAJO> vista = new List<VISTA_TRABAJO>();
        List<VISTA_DETALLE_TRABAJOCURSO> vistadet = new List<VISTA_DETALLE_TRABAJOCURSO>();

        worksheet.Range("A1").SetValue("SEAFROST SAC").Style.Font.SetBold(true);
        worksheet.Range("A2").SetValue("Carretera Paita-Sullana").Style.Font.SetBold(true);
        worksheet.Range("A2:J2").Row(1).Merge();
        worksheet.Range("A3").SetValue("Mz D Lote 1 Zona Industrial").Style.Font.SetBold(true);
        worksheet.Range("A3:J3").Row(1).Merge();
        worksheet.Range("C4:F4").Row(1).Merge();
        worksheet.Range("F1").SetValue(DateTime.Now).Style.Font.SetBold(true);
        worksheet.Range("F1:G1").Row(1).Merge();

        worksheet.Range("A6").SetValue("TAREA").Style.Font.SetBold(true);
        worksheet.Range("A6").SetValue("TAREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
       //worksheet.Range("A6").SetValue("TAREA")

        worksheet.Range("B6").SetValue("FECHA").Style.Font.SetBold(true);
        worksheet.Range("B6").SetValue("FECHA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("C6").SetValue("AREA").Style.Font.SetBold(true);
        worksheet.Range("C6").SetValue("AREA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("D6").SetValue("EQUIPO").Style.Font.SetBold(true);
        worksheet.Range("D6").SetValue("EQUIPO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("E6").SetValue("PLANTA").Style.Font.SetBold(true);
        worksheet.Range("E6").SetValue("PLANTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("F6").SetValue("CONTRATISTA").Style.Font.SetBold(true);
        worksheet.Range("F6").SetValue("CONTRATISTA").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("G6").SetValue("CENTRO COSTO").Style.Font.SetBold(true);
        worksheet.Range("G6").SetValue("CENTRO COSTO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("H6").SetValue("DESCRIPCION").Style.Font.SetBold(true);
        worksheet.Range("H6").SetValue("DESCRIPCION").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("I6").SetValue("CONTROL ACTIVOS").Style.Font.SetBold(true);
        worksheet.Range("I6").SetValue("CONTROL ACTIVOS").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("J6").SetValue("OBSERVACIONES").Style.Font.SetBold(true);
        worksheet.Range("J6").SetValue("OBSERVACIONES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("K6").SetValue("ESTADO").Style.Font.SetBold(true);
        worksheet.Range("K6").SetValue("ESTADO").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("L6").SetValue("REQ").Style.Font.SetBold(true);
        worksheet.Range("L6").SetValue("REQ").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        worksheet.Range("M6").SetValue("ORDENES").Style.Font.SetBold(true);
        worksheet.Range("M6").SetValue("ORDENES").Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
        vista = tabla_trabajo.ListarTrabajos(trabajo);

        var detalleRQ = "";
        var detalleOC = "";

        foreach (VISTA_TRABAJO b in vista)
        {
            if (ddlestado.Text == "T")
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
                worksheet.Cell("B" + cont2.ToString()).Value = b.FECHA;
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
                worksheet.Cell("E" + cont2.ToString()).Value = b.PL_DESCRIPCION;
                worksheet.Cell("F" + cont2.ToString()).Value = b.CONTRATISTA;
                worksheet.Cell("G" + cont2.ToString()).Value = b.CENTRO_COSTO;
                worksheet.Cell("H" + cont2.ToString()).Value = b.DESCRIPCION;
                worksheet.Cell("I" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
                worksheet.Cell("J" + cont2.ToString()).Value = b.OBSERVACIONES;
                if (b.ESTADO.Trim() == "APROBADO")
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = "APROBADO";
                }
                if (b.ESTADO.Trim() == "EMITIDO")
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = "EMITIDO";
                }
                trabajodet.TR_CODIGO = b.TR_CODIGO;
                vistadet = tabla_detalle.DETALLE(trabajodet);
                foreach (VISTA_DETALLE_TRABAJOCURSO c in vistadet)
                {
                    if (c.DOCUMENTO == "REQUERIMIENTO")
                    {
                        if (detalleRQ == "")
                        {
                            detalleRQ = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleRQ = detalleRQ + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("L" + cont2.ToString()).Value = detalleRQ;
                    }
                    if (c.DOCUMENTO == "ORDEN SERVICIO")
                    {
                        if (detalleOC == "")
                        {
                            detalleOC = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleOC = detalleOC + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("M" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }

            if ((ddlestado.Text == "E") && (b.ESTADO == "EMITIDO"))
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS EMITIDOS DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
                worksheet.Cell("B" + cont2.ToString()).Value = b.FECHA;
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
                worksheet.Cell("E" + cont2.ToString()).Value = b.PL_DESCRIPCION;
                worksheet.Cell("F" + cont2.ToString()).Value = b.CONTRATISTA;
                worksheet.Cell("G" + cont2.ToString()).Value = b.CENTRO_COSTO;
                worksheet.Cell("H" + cont2.ToString()).Value = b.DESCRIPCION;
                worksheet.Cell("I" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
                worksheet.Cell("J" + cont2.ToString()).Value = b.OBSERVACIONES;

                if (b.ESTADO.Trim() == "EMITIDO")
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = "EMITIDO";
                }
                trabajodet.TR_CODIGO = b.TR_CODIGO;
                vistadet = tabla_detalle.DETALLE(trabajodet);
                foreach (VISTA_DETALLE_TRABAJOCURSO c in vistadet)
                {
                    if (c.DOCUMENTO == "REQUERIMIENTO")
                    {
                        if (detalleRQ == "")
                        {
                            detalleRQ = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleRQ = detalleRQ + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("L" + cont2.ToString()).Value = detalleRQ;
                    }
                    if (c.DOCUMENTO == "ORDEN SERVICIO")
                    {
                        if (detalleOC == "")
                        {
                            detalleOC = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleOC = detalleOC + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("M" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }
            if ((ddlestado.Text == "A") && (b.ESTADO == "APROBADO"))
            {
                worksheet.Range("C4").SetValue("INFORME DE TRABAJOS APROBADOS DE MANTENIMIENTO DEL " + this.txtfecha1.Text + " AL " + this.txtfecha2.Text).Style.Font.SetBold(true);
                worksheet.Cell("A" + cont2.ToString()).Value = ("'" + b.TR_CODIGO + "");
                worksheet.Cell("B" + cont2.ToString()).Value = b.FECHA;
                worksheet.Cell("C" + cont2.ToString()).Value = ("'" + b.AE_DESC + "");
                worksheet.Cell("D" + cont2.ToString()).Value = ("'" + b.EQ_DESCRIPCION + "");
                worksheet.Cell("E" + cont2.ToString()).Value = b.PL_DESCRIPCION;
                worksheet.Cell("F" + cont2.ToString()).Value = b.CONTRATISTA;
                worksheet.Cell("G" + cont2.ToString()).Value = b.CENTRO_COSTO;
                worksheet.Cell("H" + cont2.ToString()).Value = b.DESCRIPCION;
                worksheet.Cell("I" + cont2.ToString()).Value = b.CONTROL_ACTIVOS;
                worksheet.Cell("J" + cont2.ToString()).Value = b.OBSERVACIONES;
                if (b.ESTADO.Trim() == "APROBADO")
                {
                    worksheet.Cell("K" + cont2.ToString()).Value = "APROBADO";
                }
                trabajodet.TR_CODIGO = b.TR_CODIGO;
                vistadet = tabla_detalle.DETALLE(trabajodet);
                foreach (VISTA_DETALLE_TRABAJOCURSO c in vistadet)
                {
                    if (c.DOCUMENTO == "REQUERIMIENTO")
                    {
                        if (detalleRQ == "")
                        {
                            detalleRQ = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleRQ = detalleRQ + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("L" + cont2.ToString()).Value = detalleRQ;
                    }
                    if (c.DOCUMENTO == "ORDEN SERVICIO")
                    {
                        if (detalleOC == "")
                        {
                            detalleOC = ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }
                        else
                        {
                            detalleOC = detalleOC + " , " + ("'" + Convert.ToInt32(c.CODIGO.Trim()) + "");
                        }

                        worksheet.Cell("M" + cont2.ToString()).Value = detalleOC;
                    }
                }
                cont2++;
                detalleRQ = "";
                detalleOC = "";
            }
        }
        worksheet.Column(1).Width = 10;
        worksheet.Column(2).Width = 10;
        worksheet.Column(3).Width = 30;
        worksheet.Column(4).Width = 60;
        worksheet.Column(5).Width = 20;
        worksheet.Column(6).Width = 30;
        worksheet.Column(7).Width = 40;
        worksheet.Column(8).Width = 60;
        worksheet.Column(9).Width = 25;
        worksheet.Column(10).Width = 30;
        worksheet.Column(11).Width = 10;

        Response.Clear();
        Response.ContentType =
             "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        Response.AddHeader("content-disposition", "attachment;filename=\"ReporteAvances.xlsx\"");

        using (var memoryStream = new MemoryStream())
        {
            workbook.SaveAs(memoryStream);
            memoryStream.WriteTo(Response.OutputStream);
        }
        Response.End();

    }

    protected void gvordencompra_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //    e.Row.Cells[2].BackColor = Color.Red;

            var dias = e.Row.Cells[12].Text == "&nbsp;" ? "0" : e.Row.Cells[12].Text;
            var acum = e.Row.Cells[14].Text == "&nbsp;" ? "0" : e.Row.Cells[14].Text;

            if (Convert.ToDecimal(dias) <= 90)
            {
                e.Row.Cells[12].BackColor = Color.GreenYellow;
            }

            if (Convert.ToDecimal(dias) > 90 && Convert.ToDecimal(dias) <= 110)
            {
                e.Row.Cells[12].BackColor = Color.Yellow;
            }

            if (Convert.ToDecimal(dias) > 110)
            {
                e.Row.Cells[12].BackColor = Color.Red;
            }
            // para acumulado
            if (Convert.ToDecimal(acum) <= 90)
            {
                e.Row.Cells[14].BackColor = Color.GreenYellow;
            }

            if (Convert.ToDecimal(acum) > 90 && Convert.ToDecimal(acum) <= 110)
            {
                e.Row.Cells[14].BackColor = Color.Yellow;
            }

            if (Convert.ToDecimal(acum) > 110)
            {
                e.Row.Cells[14].BackColor = Color.Red;
            }

        }
    }

    public void INICIO()
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
       
            var.FECHA = Convert.ToDateTime("01/05/2016");
        
        if (txtfecha2.Text == "")
        {
            var.FECHAFIN = DateTime.Today;
        }
        else
        {
            var.FECHAFIN = Convert.ToDateTime(txtfecha2.Text);
        }

        var.ESTADO = ddlestado.Text;




        gvordencompra.DataSource = tabla_trabajo.ListaInicio(var);
        gvordencompra.DataBind();

        if (gvordencompra.Rows.Count > 0)
        {
            gvordencompra.UseAccessibleHeader = true;
            gvordencompra.HeaderRow.TableSection = TableRowSection.TableHeader;
        }
    }
}
