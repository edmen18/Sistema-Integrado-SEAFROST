namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class T_CodigoGral
    {
      
        [StringLength(3)]
        public string codp { get; set; }

      
        [StringLength(5)]
        public string codpr { get; set; }

        [StringLength(10)]
        public string codgral { get; set; }

        [StringLength(50)]
        public string descodgral { get; set; }

        [StringLength(50)]
        public string sw { get; set; }

        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idprod { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int idpres { get; set; }
    }
}
