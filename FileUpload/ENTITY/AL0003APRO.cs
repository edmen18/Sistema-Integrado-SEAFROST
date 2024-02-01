namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;

    public partial class AL0003APRO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(25)]
        public string PM_CCODMAT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string PM_CCODPRO { get; set; }

        public DateTime? PM_DFECDOC { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string PM_CTIPMON { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "numeric")]
        public decimal PM_NVALOR { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(30)]
        public string PM_CCOTIZA { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(20)]
        public string PM_CORDCOM { get; set; }

        public DateTime? PM_DFECCRE { get; set; }

        public DateTime? PM_DFECMOD { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(5)]
        public string PM_CHORA { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(5)]
        public string PM_CUSER { get; set; }


        public static void InsertaOCcopia(AL0003APRO datad)
        {
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(datad).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
                //using (var ctxM = new RSFACAR())
                //{
                //    ctxM.Entry(datad).State = EntityState.Modified;
                //    ctxM.SaveChanges();
                //}
            }
        }

    }
}
