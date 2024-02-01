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


public partial class FINANZAS_TESORERIA_CHEQUES_FinEliminacion : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            lblusuario.Text = Convert.ToString(Session["codusu"]);
            txtfechadiferido.Text = DateTime.Now.ToString("dd/MM/yyyy");
            rbautomatico.Checked = true;
            this.txtcheque.Enabled = false;


            ddlsubdiario.Items.Clear();
            ddlsubdiario.DataTextField = "TDESCRI";
            ddlsubdiario.DataValueField = "TCLAVE";
            ddlsubdiario.DataSource = CT0003TAGE.LISTARSUBDIARIOED("23");
            ddlsubdiario.DataBind();

                   }

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CUBA> ListarBancosProg(string productos)
    {
        return CP0003CUBA.ListarBancosProg(productos);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static CP0003CUBA ListarDatosBancoID(string ban)
    {
        return CP0003CUBA.ListarDatosBancoID(ban);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static List<CP0003CHEQ> ConsultaunDetalle(CP0003CHEQ COM)
    {
        return CP0003CHEQ.ConsultaCheque(COM);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static string correlativoCP(CT0003NUME16 DATA)
    {
        return CT0003NUME16.obtenerNumeracion(DATA);

    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertaCheques(CP0003CHEQ DETA)
    {
        CP0003CHEQ.insertaCabecera(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static Boolean Numeracion(CT0003NUME16 DETA)
    {
        return CT0003NUME16.Numeracion(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void ActualizaCheque(CP0003CUBA DETA)
    {
        CP0003CUBA.Actualizacheque(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertDetComprobante(CT0003COMD16 DETA)
    {
        CT0003COMD16.insertaDetalleEdgar(DETA);
    }
    [System.Web.Services.WebMethod]
    [System.Web.Script.Services.ScriptMethod()]
    public static void InsertCabComprobante(CT0003COMC16 DETA)
    {
        CT0003COMC16.insertaCabecera(DETA);
    }

    }