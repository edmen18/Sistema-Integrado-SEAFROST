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
    using System.Linq;
    public partial class AL0003SKNU
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string SA_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string SA_CCODIGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SA_NCANANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SA_NCANENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SA_NCANSAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SA_NCANACT { get; set; }

        [StringLength(6)]
        public string SA_CMESPRO { get; set; }


        public static void InsertarSKNU(List<AL0003SKNU> ADDMC)
        {

            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                    ctx.AL0003SKNU.AddRange(ADDMC);
                    ctx.SaveChanges();
                }
            }
            catch (DbEntityValidationException dbEx) { 
foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                }
            }
            //using (var ctxM = new RSFACAR())
            //{
            //    ctxM.Entry(ADDMC).State = EntityState.Modified;
            //    ctxM.SaveChanges();
            //}

            }
        }


    }
}
