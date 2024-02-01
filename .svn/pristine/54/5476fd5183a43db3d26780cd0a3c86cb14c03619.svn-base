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
    public partial class CP0003CUBA
    {
        [Key]
        [StringLength(18)]
        public string CT_CNUMCTA { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMBAN { get; set; }

        [Required]
        [StringLength(20)]
        public string CT_CDESCTA { get; set; }

        [Required]
        [StringLength(10)]
        public string CT_CDESCOR { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CTIPCTA { get; set; }

        [Required]
        [StringLength(2)]
        public string CT_CCODMON { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFCHEQE { get; set; }

        [Required]
        [StringLength(12)]
        public string CT_CCUENTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ01 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ02 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ03 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NSALANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCARGOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NABONOS { get; set; }

        public DateTime? CT_DFECSAL { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP01 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP02 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP03 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CESTADO { get; set; }

        public DateTime? CT_DFECMOD { get; set; }

        public DateTime? CT_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string CT_CUSERSS { get; set; }

        [Required]
        [StringLength(8)]
        public string CT_CENTFIN { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR1 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR2 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR3 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR4 { get; set; }

        [Required]
        [StringLength(3)]
        public string CT_CCODMOD { get; set; }


        public static CP0003CUBA ListarDatosBancoID(string ban)
        {
            var banco = new CP0003CUBA();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    banco = ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA == ban).First();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return banco;
        }

        public static List<CP0003CUBA> ListarTablaS(CP0003CUBA TABL)
        {
            var alumnos = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA != "")
                               select new
                               {
                                   CT_CNUMCTA = c.CT_CNUMCTA,
                                   CT_CDESCTA = c.CT_CDESCTA
                                }

                        ).ToList().Select(c => new CP0003CUBA()
                        {
                            CT_CNUMCTA = c.CT_CNUMCTA.Trim(),
                            CT_CDESCTA = c.CT_CDESCTA.Trim()

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
    }
}
