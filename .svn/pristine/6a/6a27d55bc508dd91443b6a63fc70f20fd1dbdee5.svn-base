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
    public partial class CT0003BALH16
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string BCUENTA { get; set; }


        [Column(Order = 1, TypeName = "numeric")]
        public decimal BMNSALA { get; set; }


        [Column(Order = 2, TypeName = "numeric")]
        public decimal BMNDEBE { get; set; }


        [Column(Order = 3, TypeName = "numeric")]
        public decimal BMNHABER { get; set; }


        [Column(Order = 4, TypeName = "numeric")]
        public decimal BMNSALN { get; set; }


        [Column(Order = 5, TypeName = "numeric")]
        public decimal BUSSALA { get; set; }


        [Column(Order = 6, TypeName = "numeric")]
        public decimal BUSDEBE { get; set; }


        [Column(Order = 7, TypeName = "numeric")]
        public decimal BUSHABER { get; set; }


        [Column(Order = 8, TypeName = "numeric")]
        public decimal BUSSALN { get; set; }


        [Column(Order = 9, TypeName = "numeric")]
        public decimal BMNSALI { get; set; }


        [Column(Order = 10, TypeName = "numeric")]
        public decimal BUSSALI { get; set; }


        [Column(Order = 11)]
        [StringLength(4)]
        public string BFECPRO { get; set; }


        [Column(Order = 12)]
        [StringLength(4)]
        public string BFORBAL { get; set; }


        [Column(Order = 13)]
        [StringLength(4)]
        public string BFORGYP { get; set; }


        [Column(Order = 14)]
        [StringLength(4)]
        public string BFORRE1 { get; set; }


        [Column(Order = 15)]
        [StringLength(1)]
        public string BCTAAJU { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(6)]
        public string BFECPRO2 { get; set; }

        public static Boolean inserta(CT0003BALH16 DATA)
        {
            Boolean band = true;
            DATA.BFORBAL = "";
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

        public static Boolean actualizar(CT0003BALH16 DATOS)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var NBAL = new CT0003BALH16 { BCUENTA = DATOS.BCUENTA, BFECPRO2 = DATOS.BFECPRO2 };
            var ABAL = new CT0003BALH16();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ABAL = ctx.CT0003BALH16.Where(x => x.BCUENTA == DATOS.BCUENTA && x.BFECPRO2 == DATOS.BFECPRO2).FirstOrDefault();
                    if (ABAL == null)
                    {
                        inserta(DATOS);
                    }
                    else
                    {
                        ctx.CT0003BALH16.Attach(NBAL);
                        if (DATOS.BFORBAL == "1") {
                            NBAL.BMNDEBE = Convert.ToDecimal(ABAL.BMNDEBE) + DATOS.BMNDEBE;
                            NBAL.BMNHABER = Convert.ToDecimal(ABAL.BMNHABER) + DATOS.BMNHABER;
                            NBAL.BUSDEBE = Convert.ToDecimal(ABAL.BUSDEBE) + DATOS.BUSDEBE;
                            NBAL.BUSHABER = Convert.ToDecimal(ABAL.BUSHABER) + DATOS.BUSHABER;
                            NBAL.BFORBAL = "";
                        } else {
                            NBAL.BMNDEBE = Convert.ToDecimal(ABAL.BMNDEBE) - DATOS.BMNDEBE;
                            NBAL.BMNHABER = Convert.ToDecimal(ABAL.BMNHABER) - DATOS.BMNHABER;
                            NBAL.BUSDEBE = Convert.ToDecimal(ABAL.BUSDEBE) - DATOS.BUSDEBE;
                            NBAL.BUSHABER = Convert.ToDecimal(ABAL.BUSHABER) - DATOS.BUSHABER;
                            NBAL.BFORBAL = "";
                        }
                       // ctx.Entry(NBAL).State = EntityState.Modified;
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

        /// <summary>
        /// UTILIZADA PARA DISMINUIR EL SALDO EN LA TABLA BALH16
        /// </summary> // NO UTILICE LA ANTERIOR XQ HAY VECES EN QUE HAY QUE ACTUALIZAR A CERO.
        /// <param name="DATOS"></param>
        /// <returns></returns>

        public static Boolean actualizaredgar(CT0003BALH16 DATOS)
          {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var NBAL = new CT0003BALH16 { BCUENTA = DATOS.BCUENTA, BFECPRO2 = DATOS.BFECPRO2 };
            var ABAL = new CT0003BALH16();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ABAL = ctx.CT0003BALH16.Where(x => x.BCUENTA == DATOS.BCUENTA && x.BFECPRO2 == DATOS.BFECPRO2).FirstOrDefault();
                    {
                        ctx.CT0003BALH16.Attach(ABAL);
                       {
                            ABAL.BMNDEBE = Convert.ToDecimal(ABAL.BMNDEBE) - DATOS.BMNDEBE;
                            ABAL.BMNHABER = Convert.ToDecimal(ABAL.BMNHABER) - DATOS.BMNHABER;
                            ABAL.BUSDEBE = Convert.ToDecimal(ABAL.BUSDEBE) - DATOS.BUSDEBE;
                            ABAL.BUSHABER = Convert.ToDecimal(ABAL.BUSHABER) - DATOS.BUSHABER;
                            ABAL.BFORBAL = "";
                        }
                         ctx.Entry(ABAL).State = EntityState.Modified;
                        //ctx.Configuration.ValidateOnSaveEnabled = false;
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
