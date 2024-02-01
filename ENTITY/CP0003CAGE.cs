namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class CP0003CAGE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CE_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string CE_CTIPACR { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string CE_CCODMON { get; set; }

        [Required]
        [StringLength(12)]
        public string CE_CCTACOM { get; set; }

        [Required]
        [StringLength(12)]
        public string CE_CCTALET { get; set; }

        [Required]
        [StringLength(12)]
        public string CE_CCTAANT { get; set; }

        [Required]
        [StringLength(1)]
        public string CE_CVANEXO { get; set; }

        [Required]
        [StringLength(5)]
        public string CE_CUSUCRE { get; set; }

        public DateTime? CE_DFECCRE { get; set; }

        [Required]
        [StringLength(12)]
        public string CE_CCTALIQ { get; set; }
        /// <summary>
        /// Lista configuracion cuenta de compra
        /// Opciones: x moneda
        /// </summary>
        /// <returns>Lista</returns>
        public static List<V_CUENTA_COMPRA> ListarCC(V_CUENTA_COMPRA DATA)
        {
            List<V_CUENTA_COMPRA> tablag = new List<V_CUENTA_COMPRA>();
            /*CONFIGURACION DE LQ: CUENTAS DE COMPRA-I1*/
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CP0003CAGE
                              where
                              (DATA.CE_CCODMON!=null?x.CE_CCODMON==DATA.CE_CCODMON:x.CE_CCODMON!=DATA.CE_CCODMON) &&
                              (DATA.CE_CTIPACR!=null?x.CE_CTIPACR==DATA.CE_CTIPACR:x.CE_CTIPACR!=DATA.CE_CTIPACR)
                              select new
                              {
                                  CE_CCODAGE = x.CE_CCODAGE,
                                  CE_CTIPACR = x.CE_CTIPACR,
                                  CE_CCODMON = x.CE_CCODMON,
                                  CE_CCTACOM = x.CE_CCTACOM,
                                  CE_CCTALET=x.CE_CCTALET,
                                  CE_CCTAANT=x.CE_CCTAANT,
                                  CE_CVANEXO=x.CE_CVANEXO,
                                  CE_CUSUCRE=x.CE_CUSUCRE,
                                  CE_DFECCRE=x.CE_DFECCRE,
                                  CE_CCTALIQ=x.CE_CCTALIQ
                              }).ToList().Select(x => new V_CUENTA_COMPRA
                              {
                                  CE_CCODAGE = x.CE_CCODAGE.Trim(),
                                  CE_CTIPACR = x.CE_CTIPACR.Trim(),
                                  DESACR = ((from T1 in ctx.CP0003TAGE
                                                           where T1.TG_CODIGO == x.CE_CTIPACR
                                                           select new { T1.TG_DESCRI }).FirstOrDefault().TG_DESCRI),
                                  CE_CCODMON = x.CE_CCODMON,
                                  CE_CCTACOM = x.CE_CCTACOM,
                                  CE_CCTALET = x.CE_CCTALET,
                                  CE_CCTAANT = x.CE_CCTAANT,
                                  CE_CVANEXO = x.CE_CVANEXO,
                                  CE_CUSUCRE= x.CE_CUSUCRE,
                                  CE_DFECCRE= String.Format("{0:dd/MM/yyyy}", x.CE_DFECCRE),
                                  CE_CCTALIQ = x.CE_CCTALIQ
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
