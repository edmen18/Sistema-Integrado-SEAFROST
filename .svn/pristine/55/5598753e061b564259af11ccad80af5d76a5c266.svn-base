namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class CP0003COPR
    {
        [Key]
        [StringLength(8)]
        public string CG_CCODCON { get; set; }

        [Required]
        [StringLength(50)]
        public string CG_CCONCEP { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CFLGMAS { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CESTADO { get; set; }

        public DateTime? CG_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string CG_CUSUCRE { get; set; }

        public DateTime? CG_DFECACT { get; set; }

        [Required]
        [StringLength(5)]
        public string CG_CUSUMOD { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CTIPPAG { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CTIPFLA { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CTIPANE { get; set; }

        [Required]
        [StringLength(18)]
        public string CG_CANEINI { get; set; }

        [Required]
        [StringLength(18)]
        public string CG_CANEFIN { get; set; }

        [Required]
        [StringLength(2)]
        public string CG_CCODMON { get; set; }

        [Required]
        [StringLength(1)]
        public string CG_CACRBAN { get; set; }

        public static List<CP0003COPR> ListarTodos()
        {
            var alumnos = new List<CP0003COPR>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003COPR where c.CG_CCODCON.Trim()=="DRM"
                               select new
                               {
                                   cg_ccodcon = c.CG_CCODCON,
                                   gg_cconcep = c.CG_CCONCEP
                               }

                        ).ToList().Select(c => new CP0003COPR()
                        {
                            CG_CCODCON = c.cg_ccodcon.Trim(),
                            CG_CCONCEP = c.gg_cconcep.Trim()

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
