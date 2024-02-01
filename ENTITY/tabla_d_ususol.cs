namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_d_ususol
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(5)]
        public string SU_USUA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string SU_SOLIC { get; set; }

        public static void Insertarsolusua(tabla_d_ususol ADDMC)
        {
            try
            {
                using (ANEXO_RSFACAR ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
                //using (var ctxM = new RSFACAR())
                //{
                //    ctxM.Entry(ADDMC).State = EntityState.Modified;
                //    ctxM.SaveChanges();
                //}
                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //    {
                //        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                //    }
                //}
            }
        }


        public static void EliminaDetalleus(tabla_d_ususol DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_d_ususol.RemoveRange(ctx.tabla_d_ususol.Where(x => x.SU_USUA == DDET.SU_USUA.Trim()));
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }



        public static List<tabla_d_ususol> ListaDetalleus(tabla_d_ususol DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    return (from c in ctx.tabla_d_ususol where c.SU_USUA == DDET.SU_USUA select c).ToList();
                }
            }
            catch
            {
                throw;
            }
        }


        public static List<tabla_d_ususol> Validausuasoli(tabla_d_ususol DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    return (from c in ctx.tabla_d_ususol where c.SU_USUA == DDET.SU_USUA && c.SU_SOLIC == DDET.SU_SOLIC select c).ToList();
                }
            }
            catch
            {
                throw;
            }
        }



    }
}
