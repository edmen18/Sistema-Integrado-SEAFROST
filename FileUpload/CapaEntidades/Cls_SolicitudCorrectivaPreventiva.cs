using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CapaEntidades
{
   public class Cls_SolicitudCorrectivaPreventiva
    {

 public   int id { get; set; }
 public string numero { get; set; }
 public string tipo { get; set; }
 public string origen { get; set; }
 public string descripcion { get; set; }
 public string otro_origen { get; set; }
 public DateTime fecha { get; set; }
 public string estado { get; set; }
 public string serie { get; set; }
 public string areadirigida { get; set; }
    }
}
