using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;//agrega
using System.IO;
using System.Data;
using CapaEntidades;
using CapaNegocio;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Web.UI.HtmlControls;
using System.Text;
using ClosedXML.Excel;
//using CapaNegocio;
using ENTITY;
using System.Configuration;

public partial class RegistroSalida : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs args)
    {
        if (!this.IsPostBack)
        {
            string auxFecha=DateTime.Now.ToString("dd/MM/yyyy");
            //txtNumeroDoc.Text = AL0003MOVC.codMaximo("0012", "PE").ToString();
            lblSalida.Text = "S";
            lbltipoRegistro.Text = "S";
            hdUSUARIO.Value = Session["codusu"].ToString();
            codAL.Value = (Session["aID"]==null?"0001":Session["aID"].ToString());
            lblFechaE.Text = (Session["FechaE"]==null?auxFecha:Session["FechaE"].ToString());//VALIDAR
            lblFechaDocD.Text= (Session["FechaE"] == null ? auxFecha : Session["FechaE"].ToString());//DETALLE
            lblAlmacen.Text = (Session["daID"]==null?"ALMACEN DE INSUMOS":Session["daID"].ToString());
            btnagregarItem.Enabled = false;
            
            AL0003TABL TABL = new AL0003TABL();
            TABL.TG_CCOD = "03";
            TABL.TG_CDESCRI = string.Empty;

            ddlMoneda.Items.Clear();
            ddlMoneda.DataTextField = "TG_CDESCRI";
            ddlMoneda.DataValueField = "TG_CCLAVE";
            ddlMoneda.DataSource = AL0003TABL.ListarTablaS(TABL);
            ddlMoneda.DataBind();
            ddlMoneda.Items.Insert(0, new ListItem("[Moneda]", "-1"));

            TABL.TG_CCOD = "37";
            TABL.TG_CDESCRI = string.Empty;
            ddlTipoConversion.Items.Clear();
            ddlTipoConversion.DataTextField = "TG_CDESCRI";
            ddlTipoConversion.DataValueField = "TG_CCLAVE";
            ddlTipoConversion.DataSource = AL0003TABL.ListarTabla(TABL);
            ddlTipoConversion.DataBind();
            ddlTipoConversion.Items.Insert(0, new ListItem("[Conversion]", "-1"));

            tabla_parametros PDATA = new tabla_parametros();
            PDATA.AF_COD = "00";
            ddlDepa.Items.Clear();
            ddlDepa.DataTextField = "AF_TDESCRI1";
            ddlDepa.DataValueField = "AF_CCLAVE";
            ddlDepa.DataSource = tabla_parametros.ListarParametro(PDATA);
            ddlDepa.DataBind();
            ddlDepa.Items.Insert(0, new ListItem("-", "-1"));

            PDATA.AF_COD = "01";
            ddlOrigen.Items.Clear();
            ddlOrigen.DataTextField = "AF_TDESCRI1";
            ddlOrigen.DataValueField = "AF_TDESCRI1";
            ddlOrigen.DataSource = tabla_parametros.ListarParametro(PDATA);
            ddlOrigen.DataBind();

            ddlAlmacenRef.Items.Clear();
            ddlAlmacenRef.DataTextField = "A1_CDESCRI";
            ddlAlmacenRef.DataValueField = "A1_CALMA";
            ddlAlmacenRef.DataSource = AL0003ALMA.ListarAlmacen();
            ddlAlmacenRef.DataBind();
            ddlAlmacenRef.Items.Insert(0, new ListItem("[Almacen Ref]", "-1"));

            ListaDetalle();
            iniciaSL();
        }
    }
    public void ListaDetalle()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("ITEM");
        dtGetData.Columns.Add("C6_CCODIGO");
        dtGetData.Columns.Add("C6_CDESCRI");
        dtGetData.Columns.Add("AR_CUNIDAD");
        dtGetData.Columns.Add("C6_CCENCOS");
        dtGetData.Columns.Add("C6_CSERIE");
        dtGetData.Columns.Add("C6_CFECDOC");
        dtGetData.Columns.Add("C6_CNCANTIDAD");
        dtGetData.Columns.Add("A_EDITA");
        dtGetData.Columns.Add("A_ELIMINA");
        dtGetData.Rows.Add();
        gvDetalleEntrada.DataSource = dtGetData;
        gvDetalleEntrada.DataBind();
    }

    public void iniciaSL()
    {
        DataTable dtGetData = new DataTable();
        dtGetData.Columns.Add("SR_CSERIE");
        dtGetData.Columns.Add("SR_NKDIS");
        dtGetData.Columns.Add("SR_DFECVEN");
        dtGetData.Columns.Add("ACCION");
        dtGetData.Rows.Add();
        gvSerie.DataSource = dtGetData;
        gvSerie.DataBind();
    }
    
    protected void btnEditar_Click(object sender, ImageClickEventArgs e)
    {
        /*ImageButton img = (ImageButton)sender;
        GridViewRow row = (GridViewRow)img.NamingContainer;

        hfitem.Value = gvDetalle.Rows[row.RowIndex].Cells[0].Text;
        hfproducto.Value = gvDetalle.Rows[row.RowIndex].Cells[1].Text;
        txtproducto.Text = HttpUtility.HtmlDecode(gvDetalle.Rows[row.RowIndex].Cells[2].Text);
        txtCantidaad.Text = gvDetalle.Rows[row.RowIndex].Cells[4].Text;
        txtObserva.Text = HttpUtility.HtmlDecode( gvDetalle.Rows[row.RowIndex].Cells[5].Text);

       */
    }

    protected void btnModificarcab_Click(object sender, EventArgs e)
    {
        /*if (ddlsolicitante.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Solicitante"), false);
            return;
        }
        if (ddltipo.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Tipo"), false);
            return;
        }
        if (ddlccosto.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Centro de Costo"), false);
            return;
        }
        if (ddluso.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Uso"), false);
            return;
        }
        if (ddlPrioridad.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Prioridad"), false);
            return;
        }
        if (ddlArea.SelectedValue == "-1")
        {
            ScriptManager.RegisterStartupScript(this, typeof(System.Web.UI.Page), "Alerta", Cls_Utilidades.mensajescript("Serleccione Area"), false);
            return;
        }
        AL0003REQC rec = new AL0003REQC()
        {
            RC_CNROREQ = txtnroreq.Text,
            RC_DFECREQ = Convert.ToDateTime(txtFecha.Text),
            RC_CCODSOLI = ddlsolicitante.SelectedValue.Trim(),
            RC_CCODAREA = ddltipo.SelectedValue.Trim(),
            RC_CCENCOS = ddlccosto.SelectedValue.Trim(),
            RC_CPRVSUG = hfproveedor.Value.Trim(),
            RC_CESTADO = "1",
            RC_CUSEA01 = string.Empty,
            RC_CUSEA02 = string.Empty,
            RC_CUSEA03 = string.Empty,
            RC_DFECA01 = null,
            RC_DFECA02 = null,
            RC_DFECA03 = null,
            RC_CUNIREQ = string.Empty,
            RC_CCODMON = "MN",
            RC_NIMPMN = 0,
            RC_NIMPUS = 0,
            RC_NTIPCAM = 0,
            RC_CAGEOT = string.Empty,
            RC_CNUMOT = string.Empty,
            RC_CORIREQ = ddluso.SelectedValue.Trim(),
            RC_CTIPREQ = ddlPrioridad.SelectedValue.Trim(),
            RC_CUSUCRE = Session["codusu"].ToString(),
            RC_DFECCRE = DateTime.Now,
            RC_CNUMORD = string.Empty,
            RC_CGLOSA1 = txtObserv1.Text,
            RC_CGLOSA2 = txtObserv2.Text,
            RC_CTIPAPR = string.Empty,
            RC_CAREARQ = ddlArea.SelectedValue.Trim(),
            RC_CNUMCOT = ((txtcotiz.Text.Length > 20) ? txtcotiz.Text.Substring(0, 19) : txtcotiz.Text)
        };
        AL0003REQC.modifcaRequerimiento(rec);*/
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //btnAceptar.Enabled = false;
        AL0003REQD rec = new AL0003REQD()
        {
            //ddlFechaA.SelectedValue,
            //ddlFechaP.SelectedValue
        };
        //AL0003REQD.insertaAU(rec);ALMACEN A UTILIZAR
        //mbox('hola');
        //Response.Write("<script LANGUAGE='JavaScript' >alert('" + dpFecha.Text + "')</script>");

    }
    
    protected void txtCodigoMov_TextChanged(object sender, EventArgs e)
    {
        /*if (!this.IsPostBack)
        //{
            string mov = codM.Value;
            lblCodigoM.Text = mov;
            switch (mov)
            {
                case "AI":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtOrdenCompra.Enabled = false;
                    txtOrdenCompraD.Enabled = false;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = false;
                    ddlAlmacenRef.Enabled = false;
                    txtCliente.Enabled = false;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "AJ":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtOrdenCompra.Enabled = true;
                    txtOrdenCompraD.Enabled = true;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = false;
                    ddlAlmacenRef.Enabled = false;
                    txtCliente.Enabled = false;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "CO":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtOrdenCompra.Enabled = true;
                    txtOrdenCompraD.Enabled = true;
                    txtOrdenTrabajo.Enabled = true;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = false;
                    ddlAlmacenRef.Enabled = false;
                    txtCliente.Enabled = false;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "CQ":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtOrdenCompra.Enabled = true;
                    txtOrdenCompraD.Enabled = true;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = true;
                    txtCentroCosto.Enabled = true;
                    ddlAlmacenRef.Enabled = false;
                    txtCliente.Enabled = true;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "CS":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtTipoDocumentoRef1.Enabled = false;
                    txtTipoDocumentoRef2.Enabled = false;
                    txtNroDocumento1.Enabled = false;
                    txtNroDocumento2.Enabled = false;
                    txtOrdenCompra.Enabled = false;
                    txtOrdenCompraD.Enabled = false;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = false;
                    ddlAlmacenRef.Enabled = true;
                    txtCliente.Enabled = true;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "CX":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = true;
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtTipoDocumentoRef1.Enabled = false;
                    txtTipoDocumentoRef2.Enabled = false;
                    txtNroDocumento1.Enabled = false;
                    txtNroDocumento2.Enabled = false;
                    txtOrdenCompra.Enabled = false;
                    txtOrdenCompraD.Enabled = false;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = true;
                    ddlAlmacenRef.Enabled = false;
                    txtCliente.Enabled = false;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
                case "DE":
                    ddlMoneda.Enabled = false;
                    ddlTipoConversion.Enabled = false;
                    ddlTipoCambio.Enabled = false;
                    txtProveedor.Enabled = false;
                    txtOrdenCompra.Enabled = false;
                    txtOrdenCompraD.Enabled = false;
                    txtOrdenTrabajo.Enabled = false;
                    txtSolicitante.Enabled = false;
                    txtCentroCosto.Enabled = true;
                    txtCliente.Enabled = true;
                    ddlAnexo.Enabled = false;
                    txtAnexoDetalle.Enabled = false;
                    break;
            case "EP":
                ddlMoneda.Enabled = false;
                ddlTipoConversion.Enabled = false;
                ddlTipoCambio.Enabled = false;
                txtProveedor.Enabled = false;
                txtOrdenCompra.Enabled = false;
                txtOrdenCompraD.Enabled = false;
                txtOrdenTrabajo.Enabled = false;
                txtSolicitante.Enabled = false;
                txtCentroCosto.Enabled = true;
                txtCliente.Enabled = true;
                ddlAlmacenRef.Enabled = false;
                ddlAnexo.Enabled = false;
                txtAnexoDetalle.Enabled = false;
                txtTipoDocumentoRef1.Focus();
                break;
            //}
            //Response.Write("<script LANGUAGE='JavaScript' >alert('" + mov + "')</script>");
            
        }*/

        
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABM> getMovimientos(string datos,string tipo)
    {
        return AL0003TABM.ListarMovimientos(datos,tipo);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> Gettablaycodigo(string dato, string codigo)
    {
        return AL0003TABL.Listartablaxcodigo(dato, codigo);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003TABL> Gettablaydetalle(string dato, string codigo)
    {
        return AL0003TABL.ListartablaxDetalle(dato, codigo);
    }
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<FT0003CLIE> getClienteID(string dato)
    {
        return FT0003CLIE.ListarClienteID(dato);
    }
    
    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static List<CT0003ANEX> getCliente(string COD,string CAD)
    {
        return CT0003ANEX.listarAnexo(COD,CAD);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    //public static List<FT0003CLIE> getCliente(string dato)
    public static List<CT0003ANEX> getClienteT(CT0003ANEX ADATA)
    {
        return CT0003ANEX.listarAnexoT(ADATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getProducto(string dato)
    {
        return AL0003ARTI.ListarArticulos(dato);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003ARTI> getProductoID(string dato)
    {
        return AL0003ARTI.ListarArticulosID(dato);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<AL0003STOC> getSTOCKCOD(string AL,string COD,string TR) {
        return AL0003STOC.ListarStockID(AL, COD,TR);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoID(string AL,string TDOC)
    {
        return AL0003MOVC.codMaximo(AL, TDOC);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarCabecera(AL0003MOVC DATA)
    {
        AL0003MOVC.insertaCabeceraEntrada(DATA);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void guardarDetalleCabecera(AL0003MOVD DATA)
    {
        AL0003MOVD.insertaDetalleCabecera(DATA);
    }

 }

