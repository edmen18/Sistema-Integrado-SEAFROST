namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data;
    using System.Linq;
    public partial class CO0003MOVI
    {
        [Key]
        [StringLength(20)]
        public string OC_CNUMORD { get; set; }
        
        [StringLength(18)]
        public string OC_CCODPRO { get; set; }
        
        [StringLength(80)]
        public string OC_CSTNOMC { get; set; }
        
        [StringLength(4)]
        public string OC_CSTPAIS { get; set; }
        
        [StringLength(80)]
        public string OC_CSTDIRC { get; set; }
        
        [StringLength(20)]
        public string OC_CSTTELC { get; set; }
        
        [StringLength(20)]
        public string OC_CSTFAXC { get; set; }
        
        [StringLength(50)]
        public string OC_CSTPERA { get; set; }
        
        [StringLength(80)]
        public string OC_CCTNOMC { get; set; }
        
        [StringLength(4)]
        public string OC_CCTPAIS { get; set; }
        
        [StringLength(80)]
        public string OC_CCTDIRC { get; set; }
        
        [StringLength(20)]
        public string OC_CCTTELC { get; set; }
        
        [StringLength(20)]
        public string OC_CCTFAXC { get; set; }
        
        [StringLength(50)]
        public string OC_CCTPERA { get; set; }


        public static void insertmoviimp(CO0003MOVI datad)
        {
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(datad).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctxM = new RSFACAR())
                {
                    ctxM.Entry(datad).State = EntityState.Modified;
                    ctxM.SaveChanges();
                }
            }
        }


        public static CO0003MOVI VerMoviimpo(CO0003MOVI CALMA)
        {
            CO0003MOVI listaA = new CO0003MOVI();
            try
            {
                using (var ctx0 = new RSFACAR())
                {
                    listaA = (from p in ctx0.CO0003MOVI where p.OC_CNUMORD== CALMA.OC_CNUMORD select p).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }

    }
}
