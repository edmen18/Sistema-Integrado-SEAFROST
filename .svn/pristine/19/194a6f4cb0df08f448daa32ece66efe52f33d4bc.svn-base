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
    public partial class CT0003NUME16
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CTSUBDIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string CTANO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string CTMES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CTNUMER { get; set; }

        public DateTime? CTFECCRE { get; set; }

        public DateTime? CTFECACT { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static string obtenerNumeracion(CT0003NUME16 DATA)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    cuenta = Convert.ToInt32(
                                (from n in ctx.CT0003NUME16
                                 where n.CTSUBDIA == DATA.CTSUBDIA &&
                                    n.CTANO == DATA.CTANO &&
                                    n.CTMES == DATA.CTMES
                                 select new { n.CTNUMER }).FirstOrDefault().CTNUMER);
                    //ctx.CT0003NUME16.Where(x => DATA.CTANOx.CTSUBDIA == DATA.CTSUBDIA && x.CTANO == DATA.CTANO && x.CTMES == DATA.CTMES).Select(y => y.CTNUMER).ToList());
                }
            }
            catch (Exception)
            {
                cuenta = 0;
            }
            cuenta = cuenta + 1;
            codID = cuenta.ToString("D4");
            codID = DATA.CTMES + "" + codID;
            return codID;
        }

        /// <summary>
        /// Actualiza numeracion de documento en sispag
        /// </summary>
        /// <param name="datos">CT0003NUME16</param>
        /// <returns></returns>
        public static Boolean Numeracion(CT0003NUME16 datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new CT0003NUME16 { CTSUBDIA = datos.CTSUBDIA, CTANO = datos.CTANO, CTMES = datos.CTMES };

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.CT0003NUME16.Attach(data);
                    data.CTNUMER = datos.CTNUMER;
                    //data.CTFECACT = datos.CTFECACT;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                ////NO EXISTE 
                datos.CTFECCRE = DateTime.Now;
                datos.CTFECACT = DateTime.Now;
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
                }

            }
            return band;
        }
    }
}
