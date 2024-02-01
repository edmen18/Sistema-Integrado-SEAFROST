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

    public partial class vista_usuario
    {
        [Key]
        public int ID { get; set; }
        public string DNI { get; set; }
        public string NOMBRE { get; set; }
        public string CODUSUARIO { get; set; }
        public string CLAVE { get; set; }
       
    }
}
