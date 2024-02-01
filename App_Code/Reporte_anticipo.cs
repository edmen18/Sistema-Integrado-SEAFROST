using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Descripción breve de Reporte_Anticipo
/// </summary>


namespace ENTITY
{

    public class Reporte_Anticipo
    {
        public string ANT_CODIGO { get; set; }

        public string OC_CNUMORD { get; set; }

        public string OC_CCODPRO { get; set; }

        public string OC_CRAZSOC { get; set; }
        public string OC_FECEMI { get; set; }

        public string OC_FECPRO { get; set; }

        public string OC_CODMON { get; set; }

        public decimal OC_MONTO_PEDIDO { get; set; }

        public decimal OC_PERCENTAJE { get; set; }

        public decimal OC_ANTICIPO { get; set; }

        public decimal OC_TOTAL_PAGAR { get; set; }

        public decimal TOTAL_ANTICIPO { get; set; }

        public decimal DETRACCION { get; set; }

        public decimal RETENCION { get; set; }

        public string MOTIVO { get; set; }

        public string OC_CTAPROVEEDOR { get; set; }

        public string OC_BANCO { get; set; }
        public string BANCO { get; set; }
        public string MONEDA { get; set; }

        public string APROBADO { get; set; }
        public string APROB { get; set; }
        public int PLAZO_DIAS { get; set; }
        public string USER1 { get; set; }
        public string USER2 { get; set; }
        public string USER3 { get; set; }
        public string USER4 { get; set; }
        public string OC_CSOLICT { get; set; }
    }
}
