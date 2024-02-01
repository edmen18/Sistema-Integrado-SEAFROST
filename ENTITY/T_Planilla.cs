namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Planilla
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int NumPlanilla { get; set; }

        [StringLength(5)]
        public string codp { get; set; }

        [StringLength(5)]
        public string codpr { get; set; }

        [StringLength(5)]
        public string codt { get; set; }

        public DateTime? fecha { get; set; }

        [StringLength(20)]
        public string hora { get; set; }

        [StringLength(50)]
        public string responsable { get; set; }

        [StringLength(20)]
        public string confirmacion { get; set; }

        [StringLength(20)]
        public string turno { get; set; }

        public bool? bloque { get; set; }

        public DateTime? FecProduc { get; set; }

        [StringLength(20)]
        public string Sala { get; set; }

        [StringLength(3)]
        public string codturno { get; set; }

        [StringLength(3)]
        public string codsala { get; set; }

        public bool? pendiente { get; set; }

        public bool? sie { get; set; }

        [StringLength(50)]
        public string guia { get; set; }
    }
}
