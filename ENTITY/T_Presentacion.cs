namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Presentacion
    {
        [Key]
        [StringLength(5)]
        public string codpr { get; set; }

        [StringLength(50)]
        public string despr { get; set; }

        [StringLength(5)]
        public string idgrupo { get; set; }
    }
}
