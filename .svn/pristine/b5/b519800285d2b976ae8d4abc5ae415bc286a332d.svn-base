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
    public partial class AL0003RESU
    {
        
        [Column(Order = 0)]
        [StringLength(4)]
        public string VL_CLOCALI { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string VL_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string VL_CMESPRO { get; set; }

        
        [Column(Order = 3, TypeName = "numeric")]
        public decimal VL_NUSPRUN { get; set; }

        
        [Column(Order = 4, TypeName = "numeric")]
        public decimal VL_NMNPRUN { get; set; }

        
        [Column(Order = 5, TypeName = "numeric")]
        public decimal VL_NUSPRAN { get; set; }

        
        [Column(Order = 6, TypeName = "numeric")]
        public decimal VL_NMNPRAN { get; set; }

        public DateTime? VL_DULTMOV { get; set; }

        
        [Column(Order = 7, TypeName = "numeric")]
        public decimal VL_NCANENT { get; set; }

        
        [Column(Order = 8, TypeName = "numeric")]
        public decimal VL_NCANSAL { get; set; }

        
        [Column(Order = 9, TypeName = "numeric")]
        public decimal VL_NANTCAN { get; set; }

        
        [Column(Order = 10, TypeName = "numeric")]
        public decimal VL_NACTCAN { get; set; }

        
        [Column(Order = 11, TypeName = "numeric")]
        public decimal VL_NMNANVL { get; set; }

        
        [Column(Order = 12, TypeName = "numeric")]
        public decimal VL_NUSANVL { get; set; }

        
        [Column(Order = 13, TypeName = "numeric")]
        public decimal VL_NMNACVL { get; set; }

        
        [Column(Order = 14, TypeName = "numeric")]
        public decimal VL_NUSACVL { get; set; }

        
        [Column(Order = 15, TypeName = "numeric")]
        public decimal VL_NUSENT { get; set; }

        
        [Column(Order = 16, TypeName = "numeric")]
        public decimal VL_NMNENT { get; set; }

        
        [Column(Order = 17, TypeName = "numeric")]
        public decimal VL_NUSSAL { get; set; }

        
        [Column(Order = 18, TypeName = "numeric")]
        public decimal VL_NMNSAL { get; set; }

        
        [Column(Order = 19)]
        [StringLength(12)]
        public string VL_CCUENTA { get; set; }

        
        [Column(Order = 20)]
        [StringLength(12)]
        public string VL_CGRUPO { get; set; }

        
        [Column(Order = 21)]
        [StringLength(12)]
        public string VL_CFAMILI { get; set; }

        
        [Column(Order = 22)]
        [StringLength(12)]
        public string VL_CMODELO { get; set; }

        [StringLength(12)]
        public string VL_CLINEA { get; set; }

        
        [Column(Order = 23)]
        [StringLength(12)]
        public string VL_CMARCA { get; set; }

        
        [Column(Order = 24)]
        [StringLength(12)]
        public string VL_CLUGORI { get; set; }

        
        [Column(Order = 25)]
        [StringLength(12)]
        public string VL_CANOFAB { get; set; }

        
        [Column(Order = 26)]
        [StringLength(12)]
        public string VL_CCUENTR { get; set; }


        public static void InsertarRESU(List<AL0003RESU> ADDMC)
        {

            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                    ctx.AL0003RESU.AddRange(ADDMC);
                    ctx.SaveChanges();
                    //ctx.Entry(ADDMC).State = EntityState.Modified;
                    //ctx.SaveChanges();
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

            }
        }

        public static void ActualizaRESU(AL0003RESU ADDMC)
        {

            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                   ctx.Entry(ADDMC).State = EntityState.Modified;
                    try {
                        ctx.SaveChanges();
                    }
                    catch
                    {
                        ctx.Entry(ADDMC).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
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

            }
        }


        public static decimal  ObtenerSaldoAnterior(string codigo,string periodo)
        {
           decimal dato = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    dato = ((from r in ctx.AL0003RESU where r.VL_CCODIGO.Trim() == codigo.Trim() && r.VL_CMESPRO == periodo //select r).FirstOrDefault();
                             select new { r.VL_NACTCAN }).FirstOrDefault().VL_NACTCAN); 
                }
            }
            catch 
            {
                dato = 0;
            }
            return dato;
        }
        public static decimal ObtenerSaldoAnteriorMN(string codigo, string periodo)
        {
            decimal dato = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    dato = ((from r in ctx.AL0003RESU
                             where r.VL_CCODIGO.Trim() == codigo.Trim() && r.VL_CMESPRO == periodo //select r).FirstOrDefault();
                             select new { r.VL_NMNACVL}).FirstOrDefault().VL_NMNACVL) ;
                }
            }
            catch
            {
                dato = 0;
            }
            return dato;
        }

        public static decimal ObtenerSaldoAnteriorUS(string codigo, string periodo)
        {
            decimal dato = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    dato = ((from r in ctx.AL0003RESU
                             where r.VL_CCODIGO.Trim() == codigo.Trim() && r.VL_CMESPRO == periodo //select r).FirstOrDefault();
                             select new { r.VL_NUSACVL }).FirstOrDefault().VL_NUSACVL);
                }
            }
            catch
            {
                dato = 0;
            }
            return dato;
        }



        public static AL0003RESU ObtenerStockVal(string codigo, string periodo)
        {
            AL0003RESU dato = new AL0003RESU();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    dato = ((from r in ctx.AL0003RESU
                             where r.VL_CCODIGO.Trim() == codigo.Trim() && r.VL_CMESPRO == periodo.Replace("/","") //select r).FirstOrDefault();
                             select r).FirstOrDefault());
                }
            }
            catch
            {
                dato = null;
            }
            return dato;
        }



    }
}
