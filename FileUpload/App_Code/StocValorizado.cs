using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descripción breve de ESVARTICULOS
/// </summary>
/// 

namespace ENTITY
{
public class StocValorizado {

        public string AR_CGRUPO { get; set; }
        public string AR_CFAMILI { get; set; }
        public string AR_CLINEA { get; set; }
        public string AR_CMARCA { get; set; }
        public string AR_CMODELO { get; set; }
        public string AR_CCUENTA { get; set; }
        public string SA_CMESPRO { get; set; }
        public string SA_CALMA { get; set; }
        public string AR_CCODIGO { get; set; }
        public string AR_CDESCRI { get; set; }
        public string AR_CUNIDAD { get; set; }
        public decimal SA_NCANACT { get; set; }
        public decimal PRECIOSOLES { get; set; }
        public decimal PRECIODOLARES { get; set; }
        public string AR_CMONVTA { get; set; }
        // descripciones adicionales
        public string marca { get; set; }
        public string modelo { get; set; }
        public string linea { get; set; }
        public string grupo { get; set; }
        public string familia { get; set; }
        public string cuenta { get; set; }
        public string almacen { get; set; }
    }
}
