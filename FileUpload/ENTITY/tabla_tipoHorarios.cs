namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabla_tipoHorarios
    {
        [Key]
        [StringLength(2)]
        public string cod { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }
    }
}
