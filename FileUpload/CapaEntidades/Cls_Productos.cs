using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
  public class Cls_Productos
    {
        public int idcodpro { get; set; }
        public string codpro { get; set; }
        public string tipoprod { get; set; }
        public string descrip { get; set; }
        public string unidad { get; set; }
        public double rend { get; set; }
        public Boolean  subproducto { get; set; }
        public Boolean bloqueado { get; set; }

   

    }
}
