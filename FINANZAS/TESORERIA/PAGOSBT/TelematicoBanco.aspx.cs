using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;
using ClosedXML.Excel;
/* using System.Data.DataSetExtensions;*/

public partial class TelematicoBanco : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string idAX = Convert.ToString(Request.QueryString["ANEXO"]);//CODIGO ANEXO
        string idCX = Convert.ToString(Request.QueryString["PRO"]);//CODIGO PROVEEDOR
        string idSD = Convert.ToString(Request.QueryString["SD"]);//SUBDIARIO
        string idCO = Convert.ToString(Request.QueryString["CO"]);//CORRELATIVO
        string idBA = Convert.ToString(Request.QueryString["BA"]);//NOMBRE BANCO
        string idCB = Convert.ToString(Request.QueryString["CB"]);//BANCO DESCRIPCION

        var datos = new vista_pago();
        datos.PG_CVANEXO = idAX;
        datos.PG_CCODIGO = idCX;
        datos.PG_CSUBDIA = idSD;
        datos.PG_CNUMCOM = idCO;
        datos.CT_CNUMCTA = idCB;
        datos.CT_BANCO = idBA;//descripcion

        var numlote = "";
        int total = 0;
        var ruc = ALCIAS.Verciasdato().AC_CRUC.Trim();
        //var RUTA = tabla_parametros.ListarParametroID("RU", "01");
        MemoryStream ms = new MemoryStream();
        TextWriter tw = new StreamWriter(ms);
        //C_:AC_CTIPPRO
        if(datos.CT_BANCO != "INTERBANK" && datos.CT_BANCO!= "SCOTIABANK")
        {
            vista_pago cabecera = new vista_pago();
            cabecera = CP0003PAGO.cabeceraTxt(datos).FirstOrDefault();
            micabecera(idBA, tw, cabecera);
        }
            
        List<vista_pago> dt = new List<vista_pago>();
        dt = CP0003PAGO.detalleTxt(datos);
        foreach (vista_pago row in dt)
        {
            midetalle(idBA, tw, row);
        }
        tw.Flush();
        byte[] bytes = ms.ToArray();
        ms.Close();

        Response.Clear();
        Response.ContentType = "application/force-download";
        Response.AddHeader("content-disposition", "attachment;    filename=" + "D" + ruc + "" + numlote + ".txt");
        Response.BinaryWrite(bytes);
        Response.End();
    }

    public void micabecera(string BANCO, TextWriter tw, vista_pago cabecera)
    {
        if (BANCO == "CREDITO")
        {
            tw.WriteLine(cabecera.BA_TIPREG + "" + cabecera.PG_CANTABO + "" + cabecera.PG_CFECCOM2 + "" + cabecera.AC_CTIPPRO + "" + cabecera.PG_CCODMON + "" + cabecera.PG_CTACORR + "" + cabecera.PG_NIMPORT + "" + cabecera.PG_DESCRIP + "N" + cabecera.CT_CTOTAL);//CABECERA BCP
        }
        else if (BANCO == "BBVA" || BANCO == "CONTINENTA")
        {
            tw.WriteLine(cabecera.BA_TIPREG + "" + cabecera.PG_CTACORR + "" + cabecera.PG_CCODMON + "" + cabecera.PG_NIMPORT + "" + cabecera.AC_CTIPPRO + " " + cabecera.PG_CFECCOM2 + "" + cabecera.PG_DESCRIP + "" + cabecera.PG_CANTABO + "" + cabecera.PG_FLAG);//CABECERA BCP
        }
        else if (BANCO == "INTERBANK")
        {

        }
    }
    public void midetalle(string BANCO, TextWriter tw, vista_pago row)
    {
        if (BANCO == "CREDITO")
        {
            tw.WriteLine((row.BA_TIPREG) + "" + row.AC_CTIPPRO + "" + row.CT_CTCARGO + "" + row.AU_MODPAG + "" + row.AV_CDOCIDE + "" + row.AC_CCODIGO + "" + row.AC_CODOPRO + "" + row.AC_CNOMBRE + "" + row.PG_REFEREN + "" + row.PG_REFEREN1 + "" + row.PG_CCODMON + "" + row.PG_NIMPORT + "" + row.AC_CVALRUT);
            tw.WriteLine((row.BA_TIPREG1) + "" + row.PG_CTIPDOC + "" + row.PG_NDOCPAG + "" + row.PG_NIMPORT);
        }
        else if (BANCO == "BBVA" || BANCO == "CONTINENTA")
        {
            tw.WriteLine((row.BA_TIPREG2) + "" + row.AV_CDOCIDE + "" + (row.AV_CDOCIDE.Trim() == "R" ? (row.AC_CCODIGO.Trim().Length == 11 ? row.AC_CCODIGO : "INVALIDO-RUC") : (row.AV_CDOCIDE == "L" ? (row.AC_CCODIGO.Length == 8 ? row.AC_CCODIGO : "INVALIDO-DNI") : "")) + row.AC_CTIPPRO + "" + row.CT_CTCARGO + "" + row.AC_CNOMBRE.Replace(",", "") + " " + row.PG_NIMPORT + "" + row.PG_CTIPDOC + "" + row.PG_REFEREN + "" + (row.PG_FLAG == "S" ? "N" : ""));
        } else if (BANCO=="INTERBANK") {
            tw.WriteLine((row.AV_CDOCIDE =="6"?"02":"")+ ""+row.AC_CCODIGO+""+ row.PG_CTIPDOC+""+row.PG_REFEREN+""+row.DFECVEN2+""+row.PG_CCODMON+""+row.PG_NIMPORT+""+ row.PG_NIMPORTR+""+row.AU_MODPAG + ""+row.AC_CTIPPRO+ ""+ row.PG_CCODMON+""+row.CT_CTCARGO+""+(row.AV_CTIPTRA.Trim()=="N"?"P":"J")+""+(row.AV_CDOCIDE=="6"?"02":"")+""+row.PG_REFEREN1 + ""+row.AC_CNOMBRE+"000000000000000");//NOMBRE VALIDACION(;)
        }else if (BANCO== "SCOTIABANK")
        {
            tw.WriteLine(row.AC_CCODIGO + "" + row.PG_REFEREN1 + "" + row.PG_REFEREN + ""+ row.DFECVEN2 +""+ row.PG_NIMPORT+""+ row.AC_CTIPPRO + "" + row.CT_CTCARGO);
            //tw.WriteLine(row.BA_TIPREG + "" + row.PG_REFEREN1 + "" + row.PG_REFEREN + "" + row.PG_REFEREN + "" + row.PG_NIMPORT + "" + row.AC_CTIPPRO + "" + row.CT_CTCARGO + ""+row.AC_CCODIGO + ""+row.AC_CNOMBRE);
            //tw.WriteLine(row.BA_TIPREG+""+row.PG_REFEREN1+ ""+row.PG_REFEREN+""+ row.DFECVEN2+""+row.PG_NIMPORT+""+row.AC_CTIPPRO+""+row.CT_CTCARGO+"");
        }
    }

    //public void 
}