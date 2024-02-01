using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ENTITY
{
   
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vista_listaHorarios
    {
        [Key]
        public int ID { get; set; }
        public  string DESCRIP_COSTO { get; set; }
        public string TIPO_HORARIO { get; set; }
        public int? HORA_INICIO { get; set; }
        public int? MINUTOS_INICIO { get; set; }
        public int? HORA_FIN { get; set; }
        public int? MINUTOS_FIN { get; set; }
        public string COD_COSTO { get; set; }
        public string COD_TIPOHORARIO { get; set; }

        public int? HORA_FIJA { get; set; }
        public int? MINUTOS_FIJA { get; set; }

        public string COD_TURNO { get; set; }

        public string TURNO { get; set; }
    }
}
