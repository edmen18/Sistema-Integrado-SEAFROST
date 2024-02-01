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
    public partial class CT0003COST16
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string CT_CUENTA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string CT_CENCOS { get; set; }

        
        [Column(Order = 2, TypeName = "numeric")]
        public decimal CT_USDEBE { get; set; }

        
        [Column(Order = 3, TypeName = "numeric")]
        public decimal CT_USHABER { get; set; }

        
        [Column(Order = 4, TypeName = "numeric")]
        public decimal CT_MNDEBE { get; set; }

        
        [Column(Order = 5, TypeName = "numeric")]
        public decimal CT_MNHABER { get; set; }

        [Column(Order = 6)]
        [StringLength(4)]
        public string CT_FORCOS { get; set; }

        [Column(Order = 7)]
        [StringLength(4)]
        public string CT_FECPRO { get; set; }

        [Column(Order = 8)]
        [StringLength(6)]
        public string CT_FECPRO2 { get; set; }

        public static Boolean inserta(CT0003COST16 DATA)
        {
            DATA.CT_FORCOS = "";
            Boolean band = true;
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

        public static Boolean actualizar(CT0003COST16 DATOS)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var NCOST = new CT0003COST16 { CT_CUENTA = DATOS.CT_CUENTA, CT_CENCOS = DATOS.CT_CENCOS };
            var ACOST = new CT0003COST16();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ACOST = ctx.CT0003COST16.Where(x => x.CT_CUENTA == DATOS.CT_CUENTA && x.CT_CENCOS == DATOS.CT_CENCOS && x.CT_FECPRO2==DATOS.CT_FECPRO2).FirstOrDefault();
                    if (ACOST == null)
                    {
                        inserta(DATOS);
                    }
                    else
                    {
                        ctx.CT0003COST16.Attach(NCOST);
                        if (DATOS.CT_FORCOS == "1")
                        {
                            NCOST.CT_MNDEBE = Convert.ToDecimal(ACOST.CT_MNDEBE) + DATOS.CT_MNDEBE;
                            NCOST.CT_MNHABER = Convert.ToDecimal(ACOST.CT_MNHABER) + DATOS.CT_MNHABER;
                            NCOST.CT_USDEBE = Convert.ToDecimal(ACOST.CT_USDEBE) + DATOS.CT_USDEBE;
                            NCOST.CT_USHABER = Convert.ToDecimal(ACOST.CT_USHABER) + DATOS.CT_USHABER;
                            NCOST.CT_FORCOS = "";
                        }
                        else
                        {
                            NCOST.CT_MNDEBE = Convert.ToDecimal(ACOST.CT_MNDEBE) - DATOS.CT_MNDEBE;
                            NCOST.CT_MNHABER = Convert.ToDecimal(ACOST.CT_MNHABER) - DATOS.CT_MNHABER;
                            NCOST.CT_USDEBE = Convert.ToDecimal(ACOST.CT_USDEBE) - DATOS.CT_USDEBE;
                            NCOST.CT_USHABER = Convert.ToDecimal(ACOST.CT_USHABER) - DATOS.CT_USHABER;
                            NCOST.CT_FORCOS = "";
                        }
                        //ctx.Entry(DATOS).State = EntityState.Modified;
                        ctx.Configuration.ValidateOnSaveEnabled = false;
                        ctx.SaveChanges();
                    }
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
