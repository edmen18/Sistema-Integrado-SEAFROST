namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class CP0003TABL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TG_INDICE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string TG_CODIGO { get; set; }

        [Required]
        [StringLength(60)]
        public string TG_DESCRI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal TG_NUMERO { get; set; }

        [Required]
        [StringLength(6)]
        public string TG_FECCRE { get; set; }

        [Required]
        [StringLength(6)]
        public string TG_FECACT { get; set; }

        [Required]
        [StringLength(5)]
        public string TG_USUARI { get; set; }

        public static List<CP0003TABL> ListarTablaS(CP0003TABL TABL)
        {
            var alumnos = new List<CP0003TABL>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003TABL.Where(x => x.TG_INDICE == TABL.TG_INDICE && x.TG_CODIGO.Trim()=="B")
                               select new
                               {
                                   TG_CODIGO = c.TG_CODIGO,
                                   TG_DESCRI = c.TG_DESCRI
                               }

                        ).ToList().Select(c => new CP0003TABL()
                        {
                            TG_CODIGO = c.TG_CODIGO.Trim(),
                            TG_DESCRI = c.TG_CODIGO.Trim() + "-" +  c.TG_DESCRI.Trim()

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

        public static List<CP0003TABL> ListarTabla(CP0003TABL TABL)
        {
            var alumnos = new List<CP0003TABL>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003TABL.Where(x => x.TG_INDICE == TABL.TG_INDICE )
                               select new
                               {
                                   TG_CODIGO = c.TG_CODIGO,
                                   TG_DESCRI = c.TG_DESCRI
                               }

                        ).ToList().Select(c => new CP0003TABL()
                        {
                            TG_CODIGO = c.TG_CODIGO.Trim(),
                            TG_DESCRI = c.TG_CODIGO.Trim() + "-" + c.TG_DESCRI.Trim()

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
