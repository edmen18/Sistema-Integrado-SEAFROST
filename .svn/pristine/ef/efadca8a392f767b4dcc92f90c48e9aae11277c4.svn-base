namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class CT0003CTL316
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TMES { get; set; }

        public DateTime? TLFECHA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(15)]
        public string TLHORA { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(5)]
        public string TUSER { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string TTIPCONS { get; set; }

        /// <summary>
        /// Consulta fecha de cierre x 
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static CT0003CTL316 listar(CT0003CTL316 DATA)
        {
            CT0003CTL316 result = new CT0003CTL316();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    result = (from c in ctx.CT0003CTL316 where 
                              (DATA.TMES!=null?c.TMES == DATA.TMES: c.TMES != DATA.TMES) &&
                              (DATA.TTIPCONS!=null?c.TTIPCONS==DATA.TTIPCONS:c.TTIPCONS!=DATA.TTIPCONS) &&
                              (DATA.TUSER!=null?c.TUSER==DATA.TUSER:c.TUSER!=DATA.TUSER)
                              orderby c.TMES select c).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
