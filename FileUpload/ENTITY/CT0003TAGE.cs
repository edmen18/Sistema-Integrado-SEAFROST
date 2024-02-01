namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class CT0003TAGE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TCOD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string TCLAVE { get; set; }

        [Required]
        [StringLength(60)]
        public string TDESCRI { get; set; }

        public DateTime? TDATE { get; set; }

        [Required]
        [StringLength(6)]
        public string THORA { get; set; }
        /*NUEVO WILLIAM*/
        public static List<CT0003TAGE> ListarTG(CT0003TAGE TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD && x.TCLAVE==TABG.TCLAVE)
                              select new
                              {
                                  //TG_INDICE = x.TG_INDICE,
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI=x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {

                                  TCOD = x.TCOD.Trim(),
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }
    }
}
