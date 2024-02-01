namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data;
    
    public partial class CP0003LOG2
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string L2_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string L2_CNUMOPE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string L2_CTIPTRA { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(80)]
        public string L2_CDESCRI { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(8)]
        public string L2_CORIGEN { get; set; }

        public DateTime? L2_DFECCRE { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(5)]
        public string L2_CUSUCRE { get; set; }

        public static Boolean insertar(CP0003LOG2 DATA)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(DATA).State = EntityState.Added;
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
