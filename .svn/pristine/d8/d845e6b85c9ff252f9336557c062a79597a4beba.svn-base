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
    using System.Data.Entity.SqlServer;

    public partial class tabla_avances
    {
        [StringLength(10)]
        public string TR_CODIGO { get; set; }

        public decimal? ACUMULADO { get; set; }

        public decimal? NIVEL_AVANCE { get; set; }

        public DateTime? FECHA { get; set; }

        [Key]
        public int COD_AVANCE { get; set; }

        public static string maximo(tabla_avances CODATA)
        {
            var alumnos = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos =Convert.ToString(ctx.tabla_avances.Where(a => a.TR_CODIGO == CODATA.TR_CODIGO).OrderByDescending(a => a.ACUMULADO).Select(a => a.ACUMULADO).FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return alumnos;
        }

        public static List<tabla_avances> Impresion(tabla_avances CODATA)
        {
            var alumnos = new List<tabla_avances>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_avances
                                where (a.TR_CODIGO == CODATA.TR_CODIGO)
                                orderby a.ACUMULADO descending
                               select new
                               {
                                  ACUMULADO=a.ACUMULADO,
                                  FECHA=a.FECHA,
                                  NIVEL=a.NIVEL_AVANCE, 

                               }).ToList()
                           .Select(c => new tabla_avances()
                           {
                               ACUMULADO = c.ACUMULADO,
                               FECHA = c.FECHA,
                               NIVEL_AVANCE = c.NIVEL,

                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static Boolean inserta(tabla_avances alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Added;
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

        public static Boolean actualiza(tabla_avances alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Modified;
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
