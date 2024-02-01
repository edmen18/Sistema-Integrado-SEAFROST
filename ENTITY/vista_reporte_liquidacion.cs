using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class vista_reporte_liquidacion
    {
        //cabecera de liquidacion
        public string LIQ_NUMERO { get; set; }
        // public string ANT_CODIGO { get; set; }
        public DateTime FECHA_REG { get; set; }
        public string ESTADO { get; set; }
        public DateTime FECHA_EMISION { get; set; }

        //detalle de liquidacion

        public int CODIGO { get; set; }
        public string FACTURA { get; set; }
        public decimal MONTO { get; set; }
        // public string LIQ_NUMERO { get; set; }

        //anticipo asignado

        public string ANT_CODIGO { get; set; }

        public string OC_CNUMORD { get; set; }

        public string OC_CCODPRO { get; set; }

        public string OC_CRAZSOC { get; set; }
        public DateTime OC_FECEMI { get; set; }
        public DateTime OC_FECPRO { get; set; }
        public string OC_CODMON { get; set; }
        public decimal OC_MONTO_PEDIDO { get; set; }
        public decimal OC_PERCENTAJE { get; set; }
        public decimal OC_ANTICIPO { get; set; }
        public decimal OC_TOTAL_PAGAR { get; set; }
        public string MOTIVO { get; set; }
        public string OC_CTAPROVEEDOR { get; set; }
        public string OC_BANCO { get; set; }
        public string BANCO { get; set; }
        public string APROBADO { get; set; }
        public string MONEDA { get; set; }
        public decimal DET_PORCENTAJE { get; set; }
        public decimal DETRACCION { get; set; }
        public decimal RET_PORCENTAJE { get; set; }
        public decimal RETENCION { get; set; }
        public int PLAZO_DIAS { get; set; }
        // public string ESTADO { get; set; }


    }


}
