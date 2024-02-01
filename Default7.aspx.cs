using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Default7 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        System.IO.MemoryStream rutalocal = (System.IO.MemoryStream)Session["rutacrystal"];
        Response.Clear();
        Response.Buffer = true;
        Response.ContentType = "application/pdf";
        Response.AddHeader("Content-Disposition", "attachment;filename=ASISTENCIA.pdf");
        Response.Charset = "UTF-8";
        Response.BinaryWrite(rutalocal.ToArray());
        Response.End();
    }
}