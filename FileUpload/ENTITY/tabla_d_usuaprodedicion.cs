namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_d_usuaprodedicion
    {
        [Key]
        public int DA_ID { get; set; }

        [Required]
        [StringLength(5)]
        public string DA_IDUSUA { get; set; }

        [Required]
        [StringLength(50)]
        public string DA_CODIGO { get; set; }

        public DateTime? DA_FECHA { get; set; }

        [StringLength(15)]
        public string DA_HORA { get; set; }

        public decimal? DA_PRECIO { get; set; }

        public static void insertarhistoriamod(tabla_d_usuaprodedicion ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.Entry(ADDMC).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }
    }
}
