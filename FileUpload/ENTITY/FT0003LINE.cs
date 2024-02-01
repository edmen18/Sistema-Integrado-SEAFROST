namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class FT0003LINE
    {
        [Key]
        [StringLength(4)]
        public string LI_CCODLIN { get; set; }

        [Required]
        [StringLength(30)]
        public string LI_CDESLIN { get; set; }

        [Required]
        [StringLength(30)]
        public string LI_COBSER1 { get; set; }

        [Required]
        [StringLength(30)]
        public string LI_COBSER2 { get; set; }

        [Required]
        [StringLength(5)]
        public string LI_CUSUCRE { get; set; }

        public DateTime? LI_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string LI_CUSUMOD { get; set; }

        public DateTime? LI_DFECMOD { get; set; }
    }
}
