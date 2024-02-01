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

public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) { 

        hffactual.Value = DateTime.Now.ToString("dd/MM/yyyy");
        txtfecha1.Text = DateTime.Now.ToString("dd/MM/yyyy");
        hfusu.Value = Session["codusu"].ToString();
        txtmesant.Text = AL0003LOGC.ObtenerRegistro().LC_CPERIODO.Substring(4, 2) + "-"+AL0003LOGC.ObtenerRegistro().LC_CPERIODO.Substring(0,4);

        }

    }



    [System.Web.Services.WebMethod]
    [ScriptMethod()]
    public static CTCAMB extraetcambio(CTCAMB TCAM)
    {
        return CTCAMB.obetenertcambio(TCAM);
    }






  

    protected void btacepta_Click(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            btacepta.Enabled = false;
        }
        
        txthinicio.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
        
        List<AL0003MOVD> Da = new List<AL0003MOVD>();
        List<AL0003MOVD> Dr = new List<AL0003MOVD>();
        Da = AL0003MOVD.Detalleagrupaentradasa(txtfecha1.Text);
        // Dr = AL0003MOVD.Detalleagruparesumen(txtfecha1.Text);
        AL0003MOVD.Detalleagruparesumen(txtfecha1.Text);
        

        var Fenv = txtfecha1.Text;
        
        List<AL0003SKNU> L_3SKNU = new List<AL0003SKNU>();
        //for (var i = 0; i < Da.Count; i++) {
        //    L_3SKNU.Add(new AL0003SKNU() {
        //    SA_CALMA = Da[i].C6_CALMA,
        //    SA_CMESPRO = Da[i].C6_CORDEN,
        //    SA_NCANACT = Da[i].C6_NNUMENV,
        //    SA_NCANANT = Da[i].C6_NCANFAC,
        //    SA_NCANENT = Da[i].C6_NCANTID,
        //    SA_NCANSAL = Da[i].C6_NCANTEN,
        //    SA_CCODIGO = Da[i].C6_CCODIGO
        //    });
        //}
        //AL0003SKNU.InsertarSKNU(L_3SKNU);

        //btacepta.Enabled = true;
        txthfin.Text = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");

        if (rbltipop.SelectedValue == "D")
        {
            Response.Write("<script LANGUAGE='JavaScript' >window.open('../COSTEO/Reporte.aspx?Fc="+Fenv +"','_blank');</script>");
        }

        
        //for (var j = 0; j < Dr.Count; j++)
        //    {
        //       AL0003RESU L_3RESU = new AL0003RESU()
        //        //L_3RESU.Add(new AL0003RESU()
        //        {
        //            VL_CLOCALI = "",//
        //            VL_CCODIGO = Dr[j].C6_CCODIGO,//
        //            VL_CMESPRO = Dr[j].C6_CORDEN,//
        //            VL_NUSPRUN = Dr[j].C6_NUSIMPO,//
        //            VL_NMNPRUN = Dr[j].C6_NMNIMPO,//
        //            VL_NUSPRAN = Dr[j].C6_NPREUN1,//
        //            VL_NMNPRAN = Dr[j].C6_NPRECIO,//
        //            VL_DULTMOV = null,
        //            VL_NCANENT = Dr[j].C6_NCANTID,//
        //            VL_NCANSAL = Dr[j].C6_NCANTEN,//
        //            VL_NANTCAN = Dr[j].C6_NCANFAC,//
        //            VL_NACTCAN = Dr[j].C6_NNUMENV,//
        //            VL_NMNANVL = Dr[j].C6_NIMPMN,//
        //            VL_NUSANVL = Dr[j].C6_NIMPUS,//
        //            VL_NMNACVL = Dr[j].C6_NIMPO1,//
        //            VL_NUSACVL = Dr[j].C6_NIMPO2,//
        //            VL_NUSENT = Dr[j].C6_NIMPO3,//
        //            VL_NMNENT = Dr[j].C6_NIMPO4,//
        //            VL_NUSSAL = Dr[j].C6_NISC,//
        //            VL_NMNSAL = Dr[j].C6_NIMPO5,//
        //            VL_CCUENTA = Dr[j].C6_CDESCRI,//
        //            VL_CGRUPO = Dr[j].C6_CNDSCF,//
        //            VL_CFAMILI = Dr[j].C6_CNDSCL,//
        //            VL_CMODELO = Dr[j].C6_CNDSCA,//
        //            VL_CLINEA = Dr[j].C6_CNDSCB,//
        //            VL_CMARCA = Dr[j].C6_CNFLAT,//
        //            VL_CLUGORI = Dr[j].C6_CCOMPRO,//
        //            VL_CANOFAB = Dr[j].C6_CCENCOS,//
        //            VL_CCUENTR = Dr[j].C6_CNROTAB//

        //        };
        //    AL0003RESU.ActualizaRESU(L_3RESU);
        //    }





    }
}