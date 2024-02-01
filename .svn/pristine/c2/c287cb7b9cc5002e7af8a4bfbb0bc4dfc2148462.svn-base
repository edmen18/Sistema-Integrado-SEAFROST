namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    public partial class ALCIAS
    {
        [Key]
        [StringLength(4)]
        public string AC_CCIA { get; set; }

        [Required]
        [StringLength(50)]
        public string AC_CNOMCIA { get; set; }

        [Required]
        [StringLength(60)]
        public string AC_CDIRCIA { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CCODAGE { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CALMA { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CNOMLOC { get; set; }

        [Required]
        [StringLength(18)]
        public string AC_CRUC { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CMN { get; set; }

        public DateTime? AC_DFECPR1 { get; set; }

        public DateTime? AC_DFECPRO { get; set; }

        public DateTime? AC_DULTFEC { get; set; }

        public DateTime? AC_DFECCIE { get; set; }

        public DateTime? AC_DFECCAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NTIPCAM { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CRUTVEN { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CRUTPLA { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CRUTCON { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CUSUCRE { get; set; }

        public DateTime? AC_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CUSUMOD { get; set; }

        public DateTime? AC_DFECMOD { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CFILE { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CCIACON { get; set; }

        public DateTime? AC_DULTTRA { get; set; }

        public DateTime? AC_DCIECOB { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CPROVIN { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CPAIS { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CCODARE { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CTELEF1 { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CTELEF2 { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CFAX { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CEMAIL { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CCONTAC { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERS { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSTF { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSOC { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSMO { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSLO { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CPCGE { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSLQ { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CVERSEX { get; set; }

        public static Boolean acierre(ALCIAS DATOS)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new ALCIAS { AC_CCIA = DATOS.AC_CCIA };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.ALCIAS.Attach(data);
                    data.AC_CALMA = (DATOS.AC_CALMA != null ? DATOS.AC_CALMA : data.AC_CALMA);
                    data.AC_DFECPRO = (DATOS.AC_DFECPRO != null ? DATOS.AC_DFECPRO : data.AC_DFECPRO);
                    data.AC_DFECPR1 = (DATOS.AC_DFECPR1 != null ? Convert.ToDateTime(DATOS.AC_DFECPR1) : data.AC_DFECPR1);
                    ctx.Configuration.ValidateOnSaveEnabled = false;
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

        public static string  Vercias()
        {

            string vcia ="";
            try
            {
                using (var ctx = new RSFACAR())
                {
                ALCIAS vciaA =  ctx.ALCIAS.Where(c => c.AC_CCIA == "0003").First();
                vcia = vciaA.AC_CDIRCIA.ToString();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return vcia;
        }

        //nuevo sergio 22032016 ALCIAS
        public static ALCIAS Verciasdato()
        {

            var vcia = new ALCIAS();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    vcia = ctx.ALCIAS.Where(c => c.AC_CCIA == "0003").First();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return vcia;
        }


    }
}
