namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data;
    using System.Data.Entity.SqlServer;

    public partial class CP0003PAGP
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string CP_CPROGRA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string CP_CMEDPAG { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CMODULO { get; set; }

        [Required]
        [StringLength(5)]
        public string CP_CUSUCRE { get; set; }

        public DateTime? CP_DFECCRE { get; set; }

        /// <summary>
        /// Tipo pago x programa
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vista_prog_pagos> listaPXP(vista_prog_pagos DATA)
        {
            List<vista_prog_pagos> lista = new List<vista_prog_pagos>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from pp in ctx.CP0003PAGP
                             join tg in ctx.CT0003TAGE
                                 on new { pp.CP_CMEDPAG }
                             equals new { CP_CMEDPAG = tg.TCLAVE }
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
                             }).ToList().Select(x => new vista_prog_pagos
                             {
                                 TCOD = x.var1,
                                 TCLAVE = x.var2.Trim(),
                                 TDESCRI = x.var2+" "+x.var3 
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
