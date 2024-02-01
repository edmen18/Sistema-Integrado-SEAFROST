using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
    public class vista_detalle_programacion
    {
        public string AGENCIA { get; set; }
        public string AGENCIA2 { get; set; }
        public string numope { get; set; }
        public string CONCEPTO { get; set; }
        public string tipopago { get; set; }
        public string moneda { get; set; }
        public decimal? TIPOCAMBIO { get; set; }
        public decimal? IMPORTE { get; set; }
        public DateTime? fecah { get; set; }
        public string TIPODETRACCION { get; set; }
        public string TASADETRACCION { get; set; }
        public string coddepartamento { get; set; }
        public string DEPARTAMENTO { get; set; }
        public string CODBANCO { get; set; }
        public string BANCO { get; set; }

        public string BANCOCUENTA { get; set; }
        public string ESTADO { get; set; }

        public string USUCRE { get; set; }
        public string USUAPRO { get; set; }
        public string USUMOD { get; set; }

        public DateTime? FECRE { get; set; }
        public DateTime? FEAPRO { get; set; }
        public DateTime? FEMOD { get; set; }
        public string operacion { get; set; }
        public DateTime? foperacion { get; set; }
    }
}
