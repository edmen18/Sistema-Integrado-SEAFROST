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
using ClosedXML.Excel;
using CapaNegocio;
using System.Net;
using System.Text;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Globalization;
using System.Drawing;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!this.IsPostBack)
        {
            AddGVconsumo();
            tabla_parametrosbusq TABL = new tabla_parametrosbusq();
            TABL.PM_CAT = "C";
            ddlconsu.Items.Clear();
            ddlconsu.DataTextField = "PM_DESC";
            ddlconsu.DataValueField = "PM_ID";
            ddlconsu.DataSource = tabla_parametrosbusq.ListaParam_af(TABL);
            ddlconsu.DataBind();

            TABL.PM_CAT = "G";
            ddlagrup.Items.Clear();
            ddlagrup.DataTextField = "PM_DESC";
            ddlagrup.DataValueField = "PM_ID";
            ddlagrup.DataSource = tabla_parametrosbusq.ListaParam_af(TABL);
            ddlagrup.DataBind();

            ddlalma.Items.Clear();
            ddlalma.DataTextField = "A1_CDESCRI";
            ddlalma.DataValueField = "A1_CALMA";
            ddlalma.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma.DataBind();
            ddlalma.Items.Insert(0, new ListItem("[TODOS]", "-1"));

            ddlalma2.Items.Clear();
            ddlalma2.DataTextField = "A1_CDESCRI";
            ddlalma2.DataValueField = "A1_CALMA";
            ddlalma2.DataSource = AL0003ALMA.ListarAlmacen();
            ddlalma2.DataBind();
            ddlalma2.Items.Insert(0, new ListItem("[TODOS]", "-1"));





            hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
            hfusu.Value = Session["codusu"].ToString();
        }
    }

    public void AddGVconsumo()
    {
        DataTable gvcon = new DataTable();
        gvcon.Columns.Add("RUB");
        gvcon.Columns.Add("C6_CCODIGO");
        gvcon.Columns.Add("CTAV");
        gvcon.Columns.Add("C6_NUSIMPO");
        gvcon.Columns.Add("C6_CCUENTA");
        gvcon.Columns.Add("C6_NMNIMPO");
        gvcon.Columns.Add("IP_PC");
        gvcon.Rows.Add();
        gvconsumo.DataSource = gvcon;
        gvconsumo.DataBind();

    }



    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }

    //[System.Web.Services.WebMethod]
    //[ScriptMethod()]
    //public static void Add_COMD16(CT0003COMD16 TCAM)
    //{
    //    CT0003COMD16.insertaDetalle(TCAM);
    //}


    protected void btacepta_Click(object sender, EventArgs e)
    {
        if (txtidprod1.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado el Producto 1')</script>"); txtidprod1.Focus();
        }
        else if (txtidprod2.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha seleccionado el Producto 2');</script>"); txtidprod2.Focus();
        }
        else if (txtfecha1.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado la fecha 1');</script>"); txtfecha1.Focus();
        }
        else if (txtfecha2.Text == "")
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('No ha ingresado la fecha 2');</script>"); txtfecha2.Focus();
        }
        else
        {



            var Fenv = txtfecha1.Text;
            var Fen2 = txtfecha2.Text;
            var prd1 = txtidprod1.Text;
            var prd2 = txtidprod2.Text;
            var almacen = ddlalma.SelectedValue;
            var almacen2 = ddlalma2.SelectedValue;
            var agrup = ddlagrup.SelectedValue;
            var consu = ddlconsu.SelectedValue;
            //if (Convert.ToInt32(consu) == 1) { consu = "MN"; } else if  (Convert.ToInt32(consu) == 2){ consu = "US";}
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../COSTEO/ReporteConsumoCentro.aspx?f1=" + Fenv + "&f2=" + Fen2 + "&p1=" + prd1 + "&p2=" + prd2 + "&al=" + almacen + "&al2=" + almacen2 + "&cs=" + consu + "&ag=" + agrup + "','_blank');</script>");

            btgenera.Enabled = true;


        }
    }

    protected void txtidprod1_TextChanged(object sender, EventArgs e)
    {

        if (ddlagrup.SelectedValue == "4")
        {
            if (AL0003ARTI.obtenerArticuloPorID(txtidprod1.Text) == null)
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Producto');</script>"); txtidprod1.Focus();
            }
            else
            {
                txtprod.Text = AL0003ARTI.obtenerArticuloPorID(txtidprod1.Text).AR_CDESCRI;
            }
        }
        else
        {
            if (AL0003TABL.Registrouno(txtidprod1.Text, "10") == "")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No existe el Centro Costo');</script>"); txtidprod1.Focus();
            }
            else
            {
                txtprod.Text = AL0003TABL.Registrouno(txtidprod1.Text, "10");
            }
        }
    }

    protected void txtidprod2_TextChanged(object sender, EventArgs e)
    {

        if (ddlagrup.SelectedValue == "4")
        {
            if (AL0003ARTI.obtenerArticuloPorID(txtidprod2.Text) == null)
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No existe Producto');</script>"); txtidprod2.Focus();
            }
            else
            {
                txtprod2.Text = AL0003ARTI.obtenerArticuloPorID(txtidprod2.Text).AR_CDESCRI;
            }
        }
        else
        {
            if (AL0003TABL.Registrouno(txtidprod2.Text, "10") == "")
            {
                Response.Write("<script LANGUAGE='JavaScript'>alert('No existe el Centro Costo');</script>"); txtidprod2.Focus();
            }
            else
            {
                txtprod2.Text = AL0003TABL.Registrouno(txtidprod2.Text, "10");
            }
        }
    }





    protected void btgenera_Click(object sender, EventArgs e)
    {
        //gvconsumo.DataSource = TABLCONSUCTA.LstAsientoConsu(); 
        //gvconsumo.DataBind();
        IPHostEntry host;
        string localIP = "";
        host = Dns.GetHostEntry(Dns.GetHostName());
        foreach (IPAddress ip in host.AddressList)
        {
            if (ip.AddressFamily.ToString() == "InterNetwork")
            {
                localIP = ip.ToString();
            }
        }
        string almac = ddlalma.SelectedValue;

        gvconsumo.DataSource = TABLCONSUCTA.LstAsientoConsu(localIP, almac).OrderBy(a => a.DESCRUB);
        gvconsumo.DataBind();
    }



    protected void ddlalma_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlalma.SelectedValue == "0016")
        {
            ddlalma2.SelectedValue = "0017";
        }
        else
        {
            ddlalma2.SelectedValue = ddlalma.SelectedValue;
        }

    }


    public void FunExportToExcel(GridView GrdView)
    {
        StringBuilder sb = new StringBuilder();
        StringWriter sw = new StringWriter(sb);
        HtmlTextWriter htw = new HtmlTextWriter(sw);

        Page pagina = new Page();
        HtmlForm form = new HtmlForm();

        GrdView.EnableViewState = false;

        pagina.EnableEventValidation = false;
        pagina.DesignerInitialize();
        pagina.Controls.Add(form);
        form.Controls.Add(GrdView);
        pagina.RenderControl(htw);

        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/vnd.ms-excel";
        Response.AddHeader("Content-Disposition", "attachment;filename=data.xls");
        Response.Charset = "UTF-8";

        Response.ContentEncoding = Encoding.Default;
        Response.Write(sb.ToString());
        Response.End();
    }

    protected void btexcel_Click(object sender, EventArgs e)
    {
        FunExportToExcel(gvconsumo);
    }



    protected void btgrabar_Click(object sender, EventArgs e)
    {
        CT0003COMD16 INF = new CT0003COMD16();
        CT0003COMC16 INFCAB = new CT0003COMC16();
        CT0003NUME16 NUMC = new CT0003NUME16();
        CT0003BALH16 DBH = new CT0003BALH16();
        decimal sumadebe = 0;
        int cont = 0, contvacios = 0;
        DateTime fecha = DateTime.Parse(txtfcomp.Text);
        string hora = DateTime.Now.ToString("hh:mm", CultureInfo.InvariantCulture);
        string mesletra = AL0003MOVG.Mesletras(fecha.Month);
        string anio = fecha.Year.ToString().Substring(2, 2);
        string aniocompl = fecha.Year.ToString();
        string mescompl = fecha.Month.ToString("D2");
        string fcompro = anio + fecha.Month.ToString("D2") + fecha.Day.ToString("D2");

        foreach (GridViewRow row in gvconsumo.Rows)
        {
            if (row.Cells[4].Text == "&nbsp;") contvacios++ ;
            if (row.Cells[4].Text == "&nbsp;")  row.Cells[4].BackColor = Color.GreenYellow;
            if (row.Cells[5].Text == "D") sumadebe += Convert.ToDecimal(row.Cells[2].Text);
        }

        NUMC.CTSUBDIA = "32";
        NUMC.CTANO = anio;
        NUMC.CTMES = fecha.Month.ToString("D2");
        string numdoc = CT0003NUME16.obtenerNumeracion(NUMC);
        decimal ina= Convert.ToDecimal(numdoc.Substring(2, 4));
        NUMC.CTNUMER =Convert.ToDecimal(numdoc.Substring(2,4));
        CT0003NUME16.Numeracion(NUMC);
        txtncomprob.Text = numdoc.Trim();

        if (contvacios > 0)
        {
            Response.Write("<script LANGUAGE='JavaScript'>alert('Hay Registros sin cuenta');</script>"); 
        }
        else{

            INFCAB.CSUBDIA = "32";
            INFCAB.CCOMPRO = numdoc;//comprobante
            INFCAB.CFECCOM = fcompro;
            INFCAB.CCODMON = "MN";
            INFCAB.CSITUA = "F";
            INFCAB.CTIPCAM = 0;
            INFCAB.CGLOSA = "CONSUMO " + ddlalma.SelectedValue + " " + mesletra;
            INFCAB.CTOTAL = sumadebe;
            INFCAB.CTIPO = "M";//?
            INFCAB.CFLAG = "N";//?
            INFCAB.CDATE = DateTime.Now;
            INFCAB.CHORA = hora;
            INFCAB.CUSER = hfusu.Value;
            INFCAB.CFECCAM = "";
            INFCAB.CORIG = "";
            INFCAB.CFORM = "";
            INFCAB.CTIPCOM = "";
            INFCAB.CEXTOR = "";
            INFCAB.CFECCOM2 = fecha;
            //INFCAB.CFECCAM2 =;
            INFCAB.CMEMO = "";
            INFCAB.CSERCER = "";
            INFCAB.CNUMCER = "";
            CT0003COMC16.insertaCabecera(INFCAB);

            foreach (GridViewRow row in gvconsumo.Rows)
            {
                cont++;
                string dcosto = CT0003PLEM.InfCtaOBJ(row.Cells[4].Text).PVCENCOS == "N" ? "" : tabla_parametros.ListarParametroDescr1("FC", row.Cells[4].Text);
                string dsumin = CT0003PLEM.InfCtaOBJ(row.Cells[4].Text).PVCENCOS == "N" ? "" : tabla_parametros.ListarParametroID3("FC", row.Cells[4].Text).AF_TDESCRI3;
                string vanex = CT0003PLEM.InfCtaOBJ(row.Cells[4].Text).PVANEXO == "P" ? "P" : "";
                string codref = CT0003PLEM.InfCtaOBJ(row.Cells[4].Text).PVDOCREF == "N" ? "" : tabla_parametros.ListarParametroDescr1("FC", row.Cells[4].Text);
                INF.DSUBDIA = "32";
                INF.DCOMPRO = numdoc;//numero de comprobante
                INF.DSECUE = cont.ToString("D3");//
                INF.DFECCOM = fcompro;
                INF.DCUENTA = row.Cells[4].Text;
                INF.DCODANE = vanex == "P" ? "VARIOS" : "";
                INF.DCENCOS = dcosto;
                INF.DCODMON = "MN";//?
                INF.DDH = row.Cells[5].Text;
                INF.DIMPORT = Convert.ToDecimal(row.Cells[2].Text);
                INF.DTIPDOC = codref;
                INF.DNUMDOC = mesletra + " " + anio;
                INF.DFECDOC = fcompro;
                INF.DFECVEN = "";
                INF.DAREA = "";
                INF.DFLAG = "N";
                INF.DDATE = DateTime.Now;
                INF.DXGLOSA = row.Cells[1].Text;
                INF.DUSIMPOR = Convert.ToDecimal(row.Cells[3].Text);
                INF.DMNIMPOR = Convert.ToDecimal(row.Cells[2].Text);
                INF.DCODARC = row.Cells[6].Text != "" ? "AT" : "";
                INF.DFECCOM2 = fecha;
                INF.DFECDOC2 = fecha;
                INF.DFECVEN2 = null;
                INF.DCODANE2 = dsumin;
                INF.DVANEXO = vanex;
                INF.DVANEXO2 = dcosto != "" ? "X" : "";
                INF.DTIPCAM = 0;
                INF.DCANTID = 0;
                INF.DCTAORI = row.Cells[6].Text;
                INF.DCCODMON = "";
                INF.DCIMPORT = 0;
                INF.DCNUMDOC = "";
                INF.DCESTADO = "";
                INF.DCCONFEC2 = null;
                INF.DCCONNRO = "";
                INF.DCCONPRO = null;
                INF.DCNUMEST = "";
                INF.DCITEM = "";
                INF.DCIMPORTB = 0;
                INF.DCANO = "";
                INF.DTIPDOR = "";
                INF.DNUMDOR = "";
                INF.DFECDO2 = null;
                INF.DTIPTAS = "";
                INF.DIMPTAS = 0;
                INF.DIMPBMN = 0;
                INF.DIMPBUS = 0;
                INF.DMONCOM = "";
                INF.DCOLCOM = "";
                INF.DBASCOM = 0;
                INF.DINACOM = 0;
                INF.DIGVCOM = 0;
                INF.DTPCONV = "";
                INF.DFLGCOM = "";
                INF.DANECOM = "";
                INF.DTIPACO = "";
                INF.DMEDPAG = "";
                INF.DTIPDO2 = "";
                INF.DNUMDO2 = "";
                INF.DRETE = "";
                INF.DPORRE = 0;
                CT0003COMD16.insertaDetalle(INF);

                DBH.BCUENTA = row.Cells[4].Text.Trim();
                DBH.BMNSALA = 0;
                DBH.BMNDEBE = row.Cells[5].Text == "D" ? Convert.ToDecimal(row.Cells[2].Text) : 0;
                DBH.BMNHABER = row.Cells[5].Text == "H" ? Convert.ToDecimal(row.Cells[2].Text) : 0;
                DBH.BMNSALN = 0;
                DBH.BUSSALA = 0;
                DBH.BUSDEBE = row.Cells[5].Text == "D" ? Convert.ToDecimal(row.Cells[3].Text) : 0;
                DBH.BUSHABER = row.Cells[5].Text == "H" ? Convert.ToDecimal(row.Cells[3].Text) : 0;
                DBH.BUSSALN = 0;
                DBH.BMNSALI = 0;
                DBH.BUSSALI = 0;
                DBH.BFECPRO = "";
                DBH.BFORBAL = "1";
                DBH.BFORGYP = "";
                DBH.BFORRE1 = "";
                DBH.BCTAAJU = "";
                DBH.BFECPRO2 = aniocompl + "" + mescompl;

                CT0003BALH16.actualizar(DBH);
            }

            Response.Write("<script LANGUAGE='JavaScript'>alert('Registro grabado');</script>");

        }
    }








    protected void btelimin_Click(object sender, ImageClickEventArgs e)
    {
        //gvconsumo.Rows.Remove(1);// (gvconsumo.CurrentRow);// .RemoveAt(gvconsumo.CurrentRow.Index);
    }
}