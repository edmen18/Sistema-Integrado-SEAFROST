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
    public partial class tabla_d_ordfac
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string OF_CITEM { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(20)]
        public string OF_ORDEN { get; set; }

        [StringLength(20)]
        [Key]
        [Column(Order = 2)]
        public string OF_FACTU { get; set; }

        public DateTime? OF_FECHAF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OF_MONTO { get; set; }

        public DateTime? OF_ASIGN { get; set; }
        public decimal? OF_PESO { get; set; }
        public string OF_CODMON { get; set; }

        public class vista_dordfac
        {
            public string OF_CITEM { get; set; }
            public string OF_ORDEN { get; set; }
            public string OF_FACTU { get; set; }
            public string OF_FECHAF { get; set; }
            public decimal? OF_MONTO { get; set; } 
            public string OF_ASIGN { get; set; } 
            public decimal? OF_PESO { get; set; } 
            public string OF_CODMON { get; set; } 
        }
        /// <summary>
        /// Consulta detalle de orden servicio - factura gasto de venta
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vista_dordfac> getList(vista_dordfac DATA)
        {
            var list = new List<vista_dordfac>();
            try
            {
                using (var ctx=new ANEXO_RSFACAR())
                {
                    list = (from c in ctx.tabla_d_ordfac.Where(x => x.OF_CITEM == DATA.OF_CITEM && x.OF_ORDEN == DATA.OF_ORDEN
                            )
                            select new
                            {
                                OF_FACTU = c.OF_FACTU,
                                OF_FECHAF = c.OF_FECHAF,
                                OF_PESO = c.OF_PESO,
                                OF_ASIGN = c.OF_ASIGN
                            }).ToList().Select(c => new vista_dordfac()
                            {
                                OF_FACTU = c.OF_FACTU,
                                OF_FECHAF = String.Format("{0:dd/MM/yyyy}", c.OF_FECHAF),
                                OF_PESO = c.OF_PESO,
                                OF_ASIGN = String.Format("{0:dd/MM/yyyy}", c.OF_ASIGN)
                            }).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
                //band = false;
            }

            return list;
        }



        public static void AsignaOSFAC(tabla_d_ordfac PDATA)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                try
                {
                    ctx.Entry(PDATA).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                catch
                {
                    ctx.Entry(PDATA).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public static List<SubreporteOSFACTEX> ListaxOrden(string nOC)
        {
            List<SubreporteOSFACTEX> inf = new List<SubreporteOSFACTEX>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                try
                {
                    inf = (from c in ctx.tabla_d_ordfac where c.OF_ORDEN.Trim() == nOC.Trim()
                           group c by new  {
                        c.OF_FACTU
                    } into d 
                           select new {
                               a1=d.Key.OF_FACTU,
                               //a2=c.OF_ORDEN
                           }
                           ).ToList().Select(f=> new SubreporteOSFACTEX()
                           {
                               //IDORDEN=f.a2,
                               NFACTURA=f.a1
                           }
                        ).Distinct().ToList();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                    //band = false;
                }
                return inf;
            }
        }



    }
}
