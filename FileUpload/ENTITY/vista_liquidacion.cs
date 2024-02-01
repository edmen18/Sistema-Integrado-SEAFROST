using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
   public  class vista_liquidacion
    {
        public string LIQ_NUMERO { get; set; }
        public string ANT_CODIGO { get; set; }
        public string OC_CNUMORD { get; set; }
        public string FECHA_REG { get; set; }
        public string ESTADO { get; set; }
        public string FECHA_EMISION { get; set; }
        public string SOLICITUD { get; set; }
        public string PROVEEDOR { get; set; }
        public string RUC { get; set; }
        public decimal MONTOTOTAL { get; set; }
        public decimal PORCENTAJE { get; set; }
        public decimal PAGADO { get; set; }
        public decimal ANTICIPO { get; set; }
        public string MONEDA { get; set; }
            }
}
