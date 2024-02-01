using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
    public class Cls_especies_materiaprima
    {

        public int id { get; set; }
        public string codpro { get; set; }
        public string descripvulgar { get; set; }
        public string descripespecie { get; set; }
        public int idempresa { get; set; }
        public Boolean  concurrencia { get; set; }
        public string imagen { get; set; }
        public string ejercicio { get; set; }
        public string calidad { get; set; }
    }
}
