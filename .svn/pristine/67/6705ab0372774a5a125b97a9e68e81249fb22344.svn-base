namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_ProductoCG
    {
        [Key]
        [StringLength(3)]
        public string codp { get; set; }

        [StringLength(50)]
        public string desp { get; set; }

        [StringLength(50)]
        public string sw { get; set; }

        [StringLength(2)]
        public string idespecie { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
    }
}
