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
    public partial class AL0003FACC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string LC_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string LC_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string LC_CNUMDOC { get; set; }

        public DateTime? LC_DFECCOM { get; set; }

        public DateTime? LC_DFECDOC { get; set; }

        public DateTime? LC_DFECVEN { get; set; }

        [Required]
        [StringLength(1)]
        public string LC_CDH { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CVENDE { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CNROCAJ { get; set; }

        [Required]
        [StringLength(1)]
        public string LC_CVANEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string LC_CCODPRV { get; set; }

        [Required]
        [StringLength(50)]
        public string LC_CNOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string LC_CDIRECC { get; set; }

        [Required]
        [StringLength(18)]
        public string LC_CRUC { get; set; }

        [Required]
        [StringLength(15)]
        public string LC_CCHENUM { get; set; }

        [Required]
        [StringLength(4)]
        public string LC_CSUBDIA { get; set; }

        [Required]
        [StringLength(6)]
        public string LC_CCOMPRO { get; set; }

        [Required]
        [StringLength(4)]
        public string LC_CALMA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPORT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPRET { get; set; }

        [Required]
        [StringLength(30)]
        public string LC_CFORVEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NSALDO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NTIPCAM { get; set; }

        [Required]
        [StringLength(1)]
        public string LC_CTIPO { get; set; }

        public DateTime? LC_DFECCAM { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CCODMON { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CESTADO { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CRFTD { get; set; }

        [Required]
        [StringLength(4)]
        public string LC_CRFNUMSER { get; set; }

        [Required]
        [StringLength(20)]
        public string LC_CRFNUMDOC { get; set; }

        [Required]
        [StringLength(11)]
        public string LC_CNROPED { get; set; }

        [Required]
        [StringLength(80)]
        public string LC_CGLOSA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NDESCTO { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CTF { get; set; }

        [Required]
        [StringLength(11)]
        public string LC_CNUMORD { get; set; }

        [Required]
        [StringLength(800)]
        public string LC_TOBSERV { get; set; }

        [Required]
        [StringLength(12)]
        public string LC_CCALIDA { get; set; }

        [Required]
        [StringLength(12)]
        public string LC_CORIGEN { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CUSUCRE { get; set; }

        public DateTime? LC_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CUSUMOD { get; set; }

        public DateTime? LC_DFECMOD { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CTIPOPE { get; set; }

        public static string correlativoCP(AL0003FACC datos)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSFACAR())
                {

                    cuenta = ctx.AL0003FACC.Where(x => x.LC_DFECCOM.Value.Year == datos.LC_DFECCOM.Value.Year && x.LC_DFECCOM.Value.Month == datos.LC_DFECCOM.Value.Month).Select(y=>y.LC_CCOMPRO).Count();

                }
            }
            catch (Exception)
            {

                throw;
            }

            cuenta = cuenta + 1;
            codID = (datos.LC_DFECCOM.Value.Month).ToString("D2")+""+cuenta.ToString("D4");
            return codID;
        }
        public static Boolean insertaCabecera(AL0003FACC datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSFACAR())
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
