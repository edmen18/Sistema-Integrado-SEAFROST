using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ENTITY;
using System.Web.SessionState;
using System.Web.Script.Services;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        hfusu.Value = Session["codusu"].ToString();

        AL0003TABL TABL = new AL0003TABL();
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;

        txtobs.Attributes.Add("maxlength", txtobs.MaxLength.ToString());

        ddlmone.Items.Clear();
        ddlmone.DataTextField = "TG_CDESCRI";
        ddlmone.DataValueField = "TG_CCLAVE";
        ddlmone.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlmone.DataBind();
        ddlmone.Items.Insert(0, new ListItem("[MONEDA]", "-1"));

        TABL.TG_CCOD = "27";
        TABL.TG_CDESCRI = string.Empty;

        ddlpais.Items.Clear();
        ddlpais.DataTextField = "TG_CDESCRI";
        ddlpais.DataValueField = "TG_CCLAVE";
        ddlpais.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddlpais.DataBind();
        ddlpais.Items.Insert(0, new ListItem("[PAIS]", "-1"));
        ddlpais.SelectedValue = "PERU";
        
        TABL.TG_CCOD = "63";
        TABL.TG_CDESCRI = string.Empty;

        ddltipo.Items.Clear();
        ddltipo.DataTextField = "TG_CDESCRI";
        ddltipo.DataValueField = "TG_CCLAVE";
        ddltipo.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddltipo.DataBind();
        ddltipo.Items.Insert(0, new ListItem("[TIPO]", ""));

        ddltdespa.Items.Clear();
        ddltdespa.DataTextField = "TD_DESC";
        ddltdespa.DataValueField = "TD_ID";
        ddltdespa.DataSource = tabla_tipo_despacho.ListarTipodespa();
        ddltdespa.DataBind();
        ddltdespa.Items.Insert(0, new ListItem("[DESPACHO]", ""));


        TABL.TG_CCOD = "04";
        TABL.TG_CDESCRI = string.Empty;

        ddldocre.Items.Clear();
        ddldocre.DataTextField = "TG_CDESCRI";
        ddldocre.DataValueField = "TG_CCLAVE";
        ddldocre.DataSource = AL0003TABL.ListarTablaS(TABL);
        ddldocre.DataBind();
        ddldocre.Items.Insert(0, new ListItem("[REFERENCIA]", ""));

        AL0003ALMA ALM = new AL0003ALMA();
        TABL.TG_CCOD = "03";
        TABL.TG_CDESCRI = string.Empty;

        ddlalma.Items.Clear();
        ddlalma.DataTextField = "A1_CDESCRI";
        ddlalma.DataValueField = "A1_CALMA";
        ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
        ddlalma.DataBind();
        ddlalma.Items.Insert(0, new ListItem("[ALMACEN]", "-1"));

        //tabla_subtipoOC subo = new tabla_subtipoOC();

        ddlsuboc.Items.Clear();
        ddlsuboc.DataTextField = "Descripcion";
        ddlsuboc.DataValueField = "IDTipo";
        ddlsuboc.DataSource = tabla_subtipoOC.ListarSTipoOC();
        ddlsuboc.DataBind();
        ddlsuboc.Items.Insert(0, new ListItem("[SUBTIPO]", "-1"));
        
        txtlugarf.Text = ALCIAS.Vercias();
        
    }



    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }

    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static List<CT0003ANEX> GetProveedores(string codig, string productos)
    {
        return CT0003ANEX.listarAnexoT(codig, productos);
    }



}