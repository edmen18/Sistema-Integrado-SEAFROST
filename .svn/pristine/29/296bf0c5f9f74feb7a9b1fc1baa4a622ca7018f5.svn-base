using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

using System.Web.UI.HtmlControls;
using System.IO;


namespace CapaNegocio
{
    public class Cls_RecursosWeb : System.Web.UI.Page
    {

       public void FunExportToExcel(GridView GrdView)
        {
            StringBuilder sb = new StringBuilder();
            StringWriter sw = new StringWriter();
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


          public double totalizaGridview( GridView gv, int celda ) 
    {
        double suma  = 0;

        for (int i = 0; i <= gv.Rows.Count - 1; i++)
        {
            suma += Convert.ToDouble ( gv.Rows[i].Cells[celda].Text);
        }
        return suma;
       
    }


        public void llenaGridView(string varSesion, string[] columnas, GridView gv, object[,] datos)
        {

            //Session[varSesion] = null;


            DataTable dtDatos;
            if (Session[varSesion] == null)
            {
                dtDatos = new DataTable();
                for (int i = 0; i <= columnas.Length-1; i++)
                    dtDatos.Columns.Add(new DataColumn(columnas[i]));
            }
            else
            {
                dtDatos = (DataTable)(Session[varSesion]);
            }


           

                DataRow drNewFila;

                drNewFila = dtDatos.NewRow();
                drNewFila.BeginEdit();
                for (int i = 0; i <= columnas.Length - 1; i++)
                {
                    drNewFila[columnas[i]] = datos[i, 0];
                }
                drNewFila.EndEdit();
                dtDatos.Rows.Add(drNewFila);

          
            gv.DataSource = dtDatos;
            gv.DataBind();
            Session[varSesion] = dtDatos;



        }

          public void eliminaGridView(string varSesion , int  fila , GridView gv)
          {
          DataTable dt = new DataTable();
          dt = (DataTable)(Session[varSesion]);
          dt.Rows[fila].Delete();
          gv.DataSource = dt.DefaultView;
          gv.DataBind();

           
          }
    }
}
