namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class vista_personalGeneral
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long item { get; set; }

        [StringLength(15)]
        public string codper { get; set; }

        [StringLength(80)]
        public string detalle { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(9)]
        public string sexo { get; set; }

        [StringLength(70)]
        public string Ccosto { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string AsignacionFamiliar { get; set; }

        [StringLength(50)]
        public string correo { get; set; }

        [StringLength(20)]
        public string fechaingreso { get; set; }

        [StringLength(20)]
        public string fechanacimiento { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string Activo { get; set; }
    }
}
