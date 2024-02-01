namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_Tarea
    {
        [Key]
        [StringLength(10)]
        public string codt { get; set; }

        [StringLength(100)]
        public string dest { get; set; }

        public bool? activo { get; set; }

        [StringLength(10)]
        public string codcon { get; set; }

        [StringLength(10)]
        public string codconhor { get; set; }
    }
}
