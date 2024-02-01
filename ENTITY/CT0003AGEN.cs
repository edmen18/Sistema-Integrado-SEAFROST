namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    public partial class CT0003AGEN
    {
        [Key]
        [StringLength(4)]
        public string AG_CCODAGE { get; set; }

        [Required]
        [StringLength(80)]
        public string AG_CNOMAGE { get; set; }

        [Required]
        [StringLength(80)]
        public string AG_CDIRAGE { get; set; }

        [Required]
        [StringLength(20)]
        public string AG_CCONAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string AG_CTELAGE { get; set; }

        [Required]
        [StringLength(50)]
        public string AG_CCORAGE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AG_NULTOPE { get; set; }

        public DateTime? AG_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string AG_CUSUCRE { get; set; }

        public DateTime? AG_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string AG_CUSUMOD { get; set; }

        public static List<CT0003AGEN> ListarAgencia()
        {
            var agencia = new List<CT0003AGEN>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    agencia = ctx.CT0003AGEN.ToList();
                    /*agencia = (from x in ctx.CT0003AGEN
                               select new
                               {
                                   AG_COD = x.AG_CCODAGE,
                                   AG_NOMBRE = (x.AG_CCODAGE + " " + x.AG_CNOMAGE)
                               }).ToList().Select(y => new CT0003AGEN()
                               {
                                   AG_CCODAGE = y.AG_COD,
                                   AG_CNOMAGE = y.AG_NOMBRE
                               }

                                ).ToList();*/


                }
            }
            catch (Exception)
            {

                throw;
            }

            return agencia;
        }
        
        public static string GeneraNroSolicitud()
        {          
            var codigoe = "";          
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    codigoe =Convert.ToString(ctx.CT0003AGEN.Select(X => X.AG_NULTOPE).FirstOrDefault());                  
               }
            }
            catch (Exception)
            {
                throw;
            }
            return codigoe;
        }

        public static void ActualizaProg(CT0003AGEN COM)
        {
            var orden = new CT0003AGEN { AG_CCODAGE = COM.AG_CCODAGE };

            using (var ctx = new RSCONCAR())
            {
                ctx.CT0003AGEN.Attach(orden);
                orden.AG_NULTOPE = COM.AG_NULTOPE;             
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
          
            }
        }

    }
}
