namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class FT0003CTAE
    {
        [Key]
        [StringLength(12)]
        public string TC_CEXISTE { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVENTAS { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CDEVOLU { get; set; }

        [Required]
        [StringLength(18)]
        public string TC_CANEXO { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CFLETES { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CDSCTOS { get; set; }

        public DateTime? TC_DFECCRE { get; set; }

        public DateTime? TC_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string TC_CUSUCRE { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CPROMO { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOSVEN { get; set; }

        [Required]
        [StringLength(40)]
        public string TC_CDESCRI { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOMPRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCONSUM { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVENTAD { get; set; }

        [Required]
        [StringLength(6)]
        public string TC_CCENCOS { get; set; }

        [Required]
        [StringLength(10)]
        public string TC_CEXPORT { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCOMTRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CVARTRA { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CGASCOM { get; set; }

        [Required]
        [StringLength(12)]
        public string TC_CCTAPEP { get; set; }

        public static List<FT0003CTAE> ListarCtaE(string texto)
        {
            var info = new List<FT0003CTAE>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.FT0003CTAE.Where(w=>w.TC_CDESCRI.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static string RegistrounCta( string codig)
        {
            var info = "";
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.FT0003CTAE.Where(x => x.TC_CEXISTE.Trim() == codig.Trim()).Select(aw => aw.TC_CDESCRI).First().ToString();
                }
            }
            catch (Exception)
            {
                info = "";
            }
            return info;
        }


    }
}
