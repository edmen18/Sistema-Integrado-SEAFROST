namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CP0003MAEC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string CP_CVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string CP_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string CP_CUBIC { get; set; }

        [Required]
        [StringLength(80)]
        public string CP_CNOMBRE { get; set; }

        [Required]
        [StringLength(80)]
        public string CP_CDIRECC { get; set; }

        [Required]
        [StringLength(25)]
        public string CP_CTELEFO { get; set; }

        [Required]
        [StringLength(30)]
        public string CP_CNUMFAX { get; set; }

        [Required]
        [StringLength(40)]
        public string CP_CCARGO { get; set; }

        [Required]
        [StringLength(30)]
        public string CP_CEMAIL { get; set; }

        public DateTime? CP_DFECNAC { get; set; }

        [Required]
        [StringLength(5)]
        public string CP_CUSUCRE { get; set; }

        public DateTime? CP_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string CP_CUSUMOD { get; set; }

        public DateTime? CP_DFECMOD { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CDEPCON { get; set; }

        [Required]
        [StringLength(50)]
        public string CP_CHORARI { get; set; }

        [Required]
        [StringLength(10)]
        public string CP_CCODPOS { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CPAIS { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CDEPART { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CPROVIN { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CDISDES { get; set; }

        [Required]
        [StringLength(1)]
        public string CP_CESTADO { get; set; }

        [Required]
        [StringLength(1)]
        public string CP_CBENIF { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CTIPDOC { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CNUMDOC { get; set; }
    }
}
