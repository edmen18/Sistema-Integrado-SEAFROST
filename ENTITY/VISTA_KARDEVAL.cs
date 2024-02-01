namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VISTA_KARDEVAL
    {
        public DateTime? C6_DFECDOC { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string C6_CTD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(11)]
        public string C6_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string C6_CCODMOV { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(24)]
        public string C6_CRFNDOC { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(18)]
        public string C6_CCODPRO { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal C6_NMNPRUN { get; set; }

        [Key]
        [Column(Order = 8, TypeName = "numeric")]
        public decimal C6_NUSPRUN { get; set; }

        [Key]
        [Column(Order = 9, TypeName = "numeric")]
        public decimal C6_NCANTID { get; set; }

        [Key]
        [Column(Order = 10, TypeName = "numeric")]
        public decimal C6_NMNIMPO { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal C6_NUSIMPO { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(50)]
        public string C6_CGLOSA { get; set; }
    }
}
