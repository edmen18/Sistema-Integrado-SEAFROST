using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft;
using System.Web.Services;
using ENTITY;

public partial class ACCESOS_servicios_servicios : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    [WebMethod]
    public static string GetEmployeeIDs()
    {
        return Newtonsoft.Json.JsonConvert.SerializeObject(tabla_menuusuarios.todosLasOpcionesPorUsuario("SIST"));
    
    }
}