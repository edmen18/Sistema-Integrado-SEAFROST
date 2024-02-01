namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data;

    public partial class DETALLE_LIQUIDACION
    {
        [Key]
        public int CODIGO { get; set; }

        [StringLength(20)]
        public string FACTURA { get; set; }

        public decimal MONTO { get; set; }

        [StringLength(10)]
        public string LIQ_NUMERO { get; set; }
        [StringLength(20)]
        public string ANT_CODIGO { get; set; }


        public static List<vista_detalleliquidacion> ListarDL(DETALLE_LIQUIDACION CODATA)
        {
            var alumnos = new List<vista_detalleliquidacion>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.DETALLE_LIQUIDACION
                               join l in ctx.tabla_anticipo on a.ANT_CODIGO equals l.ANT_CODIGO
                               where a.LIQ_NUMERO == CODATA.LIQ_NUMERO
                               select new
                               {
                                   factura = a.FACTURA,
                                   monto = a.MONTO,
                                   liquidacion = a.LIQ_NUMERO,
                                   codigp = a.CODIGO,
                                   anticipo=a.ANT_CODIGO,
                                   MONTO_A=l.OC_ANTICIPO,
                                   estado=l.ESTADO,
                               }
                              ).ToList()
                          .Select(c => new vista_detalleliquidacion()
                          {
                              LIQ_NUMERO = c.liquidacion,
                              FACTURA = c.factura,
                              MONTO = c.monto,
                              CODIGO = c.codigp,
                              ANT_CODIGO=c.anticipo,
                              MONTO_ANTICIPO=Convert.ToDecimal(c.MONTO_A),
                              estado=c.estado,
                              
                          }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        public static void EliminaItems(DETALLE_LIQUIDACION CCAB)
        {

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.Entry(new DETALLE_LIQUIDACION { CODIGO = CCAB.CODIGO }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
        public static Boolean insertaItem(DETALLE_LIQUIDACION tabla)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(tabla).State = EntityState.Added;
                    ctx.SaveChanges();
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
                band = false;
            }
            return band;
        }
    }
}
