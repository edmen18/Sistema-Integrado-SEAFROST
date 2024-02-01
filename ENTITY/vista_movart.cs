using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ENTITY

{
   public class vista_movart
    {
      public string  AR_CCODIGO { get; set; }
      public string C6_CALMA { get; set; }
        public string AR_CDESCRI { get; set; }
        public string AR_CUNIDAD { get; set; }
        public DateTime C6_DFECDOC { get; set; }
        public string C6_CTD { get; set; }
        public string C6_CNUMDOC { get; set; }
        public string C6_CCODMOV { get; set; }
        public decimal CANTENT { get; set; }
        public decimal CANSAL { get; set; }
        public string C6_CCODMON { get; set; }
        public decimal C6_NMNPRUN { get; set; }
        public string CCOSTO { get; set; }
        public string SOLICITANTE { get; set; }
        public string PROVEEDOR { get; set; }
        public string TDR { get; set; }
        public string REFERENCIA { get; set; }
        public string SERIE { get; set; }
        public string LOTE { get; set; }
        public decimal entradas { get; set; }
        public decimal salidas { get; set; }
        public decimal total { get; set; }
        public string AR_CFSERIE { get; set; }
        public string AR_CFLOTE { get; set; }
        
    }
}
