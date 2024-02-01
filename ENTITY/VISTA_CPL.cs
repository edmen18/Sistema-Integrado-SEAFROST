using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
   public class VISTA_CPL
    {
        // cabecera
        public string C5_CALMA { get; set; }
        public string C5_CTD { get; set; }
        public string C5_CNUMDOC { get; set; }
        public DateTime C5_DFECDOC { get; set; }
        public string C5_CCODPRO { get; set; }
        public string C5_CNOMPRO { get; set; }

        //detalle
        public string C6_CALMA { get; set; }
        public string C6_CCODIGO { get; set; }
        public string C6_CDESCRI { get; set; }
        public decimal C6_NCANTID { get; set; }
        public decimal C6_NCANTEN { get; set; }
        public string C6_CVANEXO { get; set; }

        //adicional a detalle
        public string unidad { get; set; }
        
    }
}
