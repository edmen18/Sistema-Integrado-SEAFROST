namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.SqlServer;
    using System.Linq;

    public partial class CT0003TABL
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

        public static List<CT0003TABL> ListarTabla(CT0003TABL TABL)
        {
            var alumnos = new List<CT0003TABL>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ctx.CT0003TABL.Where(x => x.TCOD == TABL.TCOD).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
        public static List<CT0003TABL>ListarTablaD(CT0003TABL TABL)
        {
            var tablag = new List<CT0003TABL>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TABL.Where(x => x.TCOD == TABL.TCOD)
                              orderby x.TCLAVE
                              select new
                              {
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList().Select(x => new CT0003TABL
                              {
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TCLAVE + "-"+x.TDESCRI,

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
