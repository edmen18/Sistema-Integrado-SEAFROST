using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
  public  class vista_detalle_oc_req
    {
        public string ITEM { get; set; }
        public string DESCRIPCION { get; set; }
        public string UNIDAD { get; set; }
        public decimal CANTIDAD { get; set; }
        public decimal PRECIODOLARES { get; set; }
        public decimal PRECIOSOLES { get; set; }
        public decimal IGV { get; set; }
        public decimal TOTALD { get; set; }
        public decimal TOTALS { get; set; }

    }
}
