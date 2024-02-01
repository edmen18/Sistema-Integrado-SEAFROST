namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    public partial class tabla_plan_ord
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string BK_NORD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(50)]
        public string BK_CODIG { get; set; }

        [Required]
        [StringLength(6)]
        public string BK_PLANI { get; set; }

        [StringLength(800)]
        public string BK_DESC { get; set; }

        public decimal? BK_CANT { get; set; }

        public decimal? BK_TARIF { get; set; }

        public decimal? BK_TOTA { get; set; }

        [StringLength(50)]
        public string BK_CODPLAN { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(10)]
        public string BK_CITEM { get; set; }

        public int? BK_AREA { get; set; }

        [StringLength(50)]
        public string BK_GUIA { get; set; }



        public static void Insertarplanillaorden(tabla_plan_ord ADDMC)
        {
            try
            {
                using (ANEXO_RSFACAR ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctxM = new ANEXO_RSFACAR())
                {
                    ctxM.Entry(ADDMC).State = EntityState.Modified;
                    ctxM.SaveChanges();
                }

            }
        }

        public static void EliminaItemsplanilla(tabla_plan_ord CCAB)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(new tabla_plan_ord { BK_NORD = CCAB.BK_NORD, BK_CITEM = CCAB.BK_CITEM, BK_CODIG = CCAB.BK_CODIG }).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                //throw;
            }
        }
    }
}
