
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
  public  class vista_impresion_requerimiento
    {
       public string RC_CNROREQ { get; set; } 
       public string RC_DFECREQ { get; set; }
       public string RC_CCODSOLI { get; set; }
       public string RC_CCODAREA { get; set; }
       public string RC_CCENCOS { get; set; }
       public string RC_CPRVSUG { get; set; }
       public string RC_CAGEOT { get; set; }
       public string RC_CORIREQ { get; set; }
       public string RC_CTIPREQ { get; set; }
       public string RC_CGLOSA1 { get; set; }
       public string RC_CGLOSA2 { get; set; }
       public string RC_CAREARQ { get; set; }
       public string RC_CNUMCOT { get; set; }
       public string RD_CITEM { get; set; }
       public string RD_CCODIGO { get; set; }
       public string RD_CDESCRI { get; set; }
       public string RD_CUNID { get; set; }
       public decimal RD_NQPEDI { get; set; }
       public string RD_COBS { get; set; }
       public string RD_CCENCOS { get; set; }
       public string RD_CUSRCOM { get; set; }

        // agregados
        public string TRABAJO { get; set; }
        public string MONEDA { get; set; }
        public decimal TIPO_CAMBIO { get; set; }
        public decimal PRESUPUESTO { get; set; }
        public decimal MONTODETALLESOLES { get; set; }
        public decimal MONTODETALLEDOLARES { get; set; }
        public string USU1 { get; set; }
        public string USU2 { get; set; }
        public string USU3 { get; set; }
    }
}
