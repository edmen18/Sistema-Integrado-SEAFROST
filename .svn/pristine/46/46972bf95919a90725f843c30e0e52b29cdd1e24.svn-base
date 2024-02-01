namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_transporte_detViaje
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string numero { get; set; }
        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string codpasajero { get; set; }

        [StringLength(3)]
        public string codparadero { get; set; }

        [StringLength(10)]
        public string codigo { get; set; }
        [StringLength(50)]
        public string detalle_pasajero { get; set; }

        [StringLength(10)]
        public string codcco { get; set; }

        [StringLength(100)]
        public string detalle_ccosto { get; set; }
        [StringLength(10)]
        public string codLabor { get; set; }

        [StringLength(100)]
        public string detalle_labor { get; set; }

        public static void InsertaBitacoraDet(tabla_transporte_detViaje ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                ctx.Entry(ADDMC).State = EntityState.Added;
                ctx.SaveChanges();
            }
        }

        public static void eliminaBitacoraDet(string numero)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {

                ctx.tabla_transporte_detViaje.RemoveRange(ctx.tabla_transporte_detViaje.Where(d => d.numero==numero ));
                ctx.SaveChanges();
            }
        }


    }
}
