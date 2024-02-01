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

    public partial class vista_vacaciones
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string DNI { get; set; }

        [StringLength(100)]
        public string NOMBRETRABAJADOR { get; set; }

        [StringLength(30)]
        public string FECHAINICIO { get; set; }

        [StringLength(30)]
        public string FECHAFIN { get; set; }
   
        [StringLength(100)]
        public string MOTIVO { get; set; }
       


    }
}
