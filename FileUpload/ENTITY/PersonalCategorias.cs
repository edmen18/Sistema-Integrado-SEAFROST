namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PersonalCategorias
    {
        [Key]
        [StringLength(2)]
        public string idCategoria { get; set; }

        [StringLength(2)]
        public string Categoria { get; set; }

        [StringLength(100)]
        public string Detalle { get; set; }

        [StringLength(20)]
        public string DescripCorta { get; set; }

        public bool? CTS { get; set; }

        public int? Vacaciones { get; set; }

        public bool? Gratificaciones { get; set; }

        [StringLength(1)]
        public string Modulo { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        public DateTime? FechaMod { get; set; }

        public bool? activo { get; set; }
    }
}
