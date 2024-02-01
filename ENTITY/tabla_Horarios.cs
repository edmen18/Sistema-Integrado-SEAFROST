namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabla_Horarios
    {
        [Key]
        public int cod { get; set; }

        [StringLength(2)]
        public string descripcion { get; set; }

        public int? hora_ing { get; set; }

        public int? minutos_ing { get; set; }

        public int? hora_sal { get; set; }

        public int? minutos_sal { get; set; }

        public int? rango_minutos { get; set; }

        [StringLength(5)]
        public string codcosto { get; set; }

      public int? hora_fija { get; set; }

      public int?  minuto_fija { get; set; }
        [StringLength(3)]
    public string codturno { get; set; }


    }
}
