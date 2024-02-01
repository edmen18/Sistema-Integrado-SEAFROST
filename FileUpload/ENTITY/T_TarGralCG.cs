namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_TarGralCG 
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string codp { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string codpr { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string codt { get; set; }

        [StringLength(10)]
        public string und { get; set; }

        [Column(TypeName = "money")]
        public decimal? tar { get; set; }

        public double? kilohora { get; set; }

        public double? salario { get; set; }

        public int? idprod { get; set; }

        public int? idprest { get; set; }

        [StringLength(20)]
        public string codsofcom { get; set; }
    }
}
