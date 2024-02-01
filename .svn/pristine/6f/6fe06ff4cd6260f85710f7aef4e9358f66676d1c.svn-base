namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data;
    public partial class CP0003SUBP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CP_CPROGRA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string CP_CSUBDIA { get; set; }

        [Required]
        [StringLength(5)]
        public string CP_CUSUCRE { get; set; }

        public DateTime? CP_DFECCRE { get; set; }

        /// <summary>
        /// Lista programas por subdiarios
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vista_prog_sub> listaSXP(vista_prog_sub DATA)
        {
            List<vista_prog_sub> lista = new List<vista_prog_sub>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from pp in ctx.CP0003SUBP
                             join tg in ctx.CT0003TAGE
                                 on new { pp.CP_CSUBDIA }
                             equals new { CP_CSUBDIA = tg.TCLAVE }
                             where
                                (pp.CP_CPROGRA == DATA.CP_CPROGRA &&
                                //pp.CP_CUSUCRE == DATA.CP_CUSUCRE &&
                                tg.TCOD == DATA.TCOD
                                )
                             select new
                             {
                                 var1 = tg.TCOD,
                                 var2 = tg.TCLAVE,
                                 var3 = tg.TDESCRI
                             }).ToList().Select(x => new vista_prog_sub
                             {
                                 TCOD = x.var1,
                                 TCLAVE = x.var2.Trim(),
                                 TDESCRI = x.var2+ " "+ x.var3
                             }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
    }
}
