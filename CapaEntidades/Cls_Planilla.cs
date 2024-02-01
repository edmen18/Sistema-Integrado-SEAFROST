using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
   public class Cls_Planilla
    {

       public int numplanilla { get; set; }
       public string codp { get; set; }
       public string codpr { get; set; }
       public string codt { get; set; }
       public DateTime fecha { get; set; }
       public string hora { get; set; }
       public string responsable { get; set; }
       public string confirmacion { get; set; }
       public string turno { get; set; }
       public Boolean  bloque { get; set; }
       public DateTime FecProduc { get; set; }
       public string Sala { get; set; }
       public string codturno { get; set; }
       public string codsala { get; set; }
       public Boolean pendiente { get; set; }
       public int numplanilla1 { get; set; }
       public string ip { get; set; }

       public DateTime fecha1 { get; set; }
       public DateTime fecha2 { get; set; }

       public double kilos { get; set; }
       public int tipo2 { get; set; }

       public List<Cls_DetPlanilla> detalle { get; set; }

       public string sfecha { get; set; }
       public string sFecProduc { get; set; }

       public string periodo { get; set; }
       public string semanag { get; set; }
       public string tipopla { get; set; }
       public string idpla   { get; set; }

       public int idprod { get; set; }
       public int idprest { get; set; }

       public string grupotrabajo { get; set; }



    }
}
