namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PersonalConfiguracion")]
    public partial class PersonalConfiguracion
    {
        public decimal? Basico { get; set; }

        public decimal? HorasTrabajadas { get; set; }

        [StringLength(5)]
        public string HoraInicioDia { get; set; }

        [StringLength(5)]
        public string HoraFinalDia { get; set; }

        [StringLength(5)]
        public string HoraInicioNoche { get; set; }

        [StringLength(5)]
        public string HoraFinalNoche { get; set; }

        public decimal? Ing_AsignacionFamiliar { get; set; }

        public decimal? Desc_EsSaludVida { get; set; }

        public decimal? Desc_SNP { get; set; }

        public decimal? Aport_EsSalud { get; set; }

        public decimal? Aport_Senati { get; set; }

        [Column(TypeName = "money")]
        public decimal? TopeSeguroAFP { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        public DateTime? FechaMod { get; set; }

        [Column(TypeName = "money")]
        public decimal? uit { get; set; }

        public int? horatardanza { get; set; }

        public int? minutotardanza { get; set; }

        [Column(TypeName = "money")]
        public decimal? porcentajequincena { get; set; }

        [Column(TypeName = "money")]
        public decimal? porcentajemensual { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }
    }
}
