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

    public partial class vista_permisos
    {
        public int ID { get; set; }

        [StringLength(30)]
        public string DNI { get; set; }

        [StringLength(100)]
        public string NOMBRETRABAJADOR { get; set; }

        [StringLength(30)]
        public string FECHAINICIO { get; set; }
        

        [StringLength(100)]
        public string MOTIVO { get; set; }
        public int? HORAINICIO { get; set; }
        public int? MINUTOINICIO { get; set; }

        public int? HORAFIN { get; set; }
        public int? MINUTOFIN { get; set; }

        [StringLength(30)]
        public string DNIAUTORIZA { get; set; }

        [StringLength(100)]
        public string NOMBREAUTORIZA { get; set; }

       








    }
}
