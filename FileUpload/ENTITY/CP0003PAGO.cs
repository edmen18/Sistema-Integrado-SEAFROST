namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    public partial class CP0003PAGO
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string PG_CVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string PG_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string PG_CTIPDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string PG_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(14)]
        public string PG_CORDKEY { get; set; }

        [Required]
        [StringLength(1)]
        public string PG_CDEBHAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PG_NIMPOMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal PG_NIMPOUS { get; set; }

        [Required]
        [StringLength(6)]
        public string PG_CFECCOM { get; set; }

        [Required]
        [StringLength(4)]
        public string PG_CSUBDIA { get; set; }

        [Required]
        [StringLength(6)]
        public string PG_CNUMCOM { get; set; }

        [Required]
        [StringLength(40)]
        public string PG_CGLOSA { get; set; }

        [Required]
        [StringLength(12)]
        public string PG_CCOGAST { get; set; }

        [Required]
        [StringLength(2)]
        public string PG_CORIGEN { get; set; }

        [Required]
        [StringLength(5)]
        public string PG_CUSUARI { get; set; }

        [Required]
        [StringLength(2)]
        public string PG_CCODMON { get; set; }

        public DateTime? PG_DFECCOM { get; set; }

        public static Boolean insertaCabecera(CP0003PAGO datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }


            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                band = false;
            }
            return band;
        }
    }
}
