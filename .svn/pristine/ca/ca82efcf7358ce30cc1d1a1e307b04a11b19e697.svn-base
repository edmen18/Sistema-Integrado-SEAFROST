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

    public partial class T_CALIDAD_TIPO_ANALISIS
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TA_CODIGO { get; set; }

        [StringLength(500)]
        public string TA_DESCRIPCION { get; set; }

        public int TA_ESTADO { get; set; }



        public static List<T_CALIDAD_TIPO_ANALISIS> LISTARAUTOCOMPLETE(string texto)
        {
            var alumnos = new List<T_CALIDAD_TIPO_ANALISIS>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.T_CALIDAD_TIPO_ANALISIS.Where(x => x.TA_DESCRIPCION.Contains(texto) && x.TA_ESTADO == 1)
                                     .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TIPOANALISIS> ListarTA()
        {
            var alumnos = new List<VISTA_TIPOANALISIS>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_TIPO_ANALISIS where  a.TA_ESTADO == 1

                               select new
                               {
                                   codigo = a.TA_CODIGO,
                                   DESCRIPCION = a.TA_DESCRIPCION,
                                   
                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              TA_CODIGO = c.codigo,
                              TA_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                } 
            }
            catch (Exception)
            { 
                throw;
            }
            return alumnos;
        }

        public static List<VISTA_TIPOANALISIS> ListarTAPARAMETRO(T_CALIDAD_TIPO_ANALISIS DATO)
        {
            var alumnos = new List<VISTA_TIPOANALISIS>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_TIPO_ANALISIS.Where(X=> X.TA_CODIGO == DATO.TA_CODIGO && X.TA_ESTADO == 1)

                               select new
                               {
                                   codigo = a.TA_CODIGO,
                                   DESCRIPCION = a.TA_DESCRIPCION,

                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              TA_CODIGO = c.codigo,
                              TA_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static Boolean insertaSolicitud(T_CALIDAD_TIPO_ANALISIS alumno)
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

        public static Boolean actualizaSolicitud(T_CALIDAD_TIPO_ANALISIS alumno)
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

        public static string GeneraNroSolicitud(string solicitud)

        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.T_CALIDAD_TIPO_ANALISIS.Where(x => x.TA_DESCRIPCION != solicitud).Count() + 1;
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;

        }

    }
}
