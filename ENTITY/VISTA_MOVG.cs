namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class VISTA_MOVG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string C6_CCENCOS { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        public string C6_CCUENTA { get; set; }

        public decimal C6_NCANTID { get; set; }
        public decimal C6_NUSIMPO { get; set; }
        public decimal C6_NMNIMPO { get; set; }

    }
}
