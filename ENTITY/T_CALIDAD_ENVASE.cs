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

    public partial class T_CALIDAD_ENVASE
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string ENV_CODIGO { get; set; }

        [StringLength(500)]
        public string ENV_DESCRIPCION { get; set; }
        public int ENV_ESTADO { get; set; }
        public static List<T_CALIDAD_ENVASE> LISTARAUTOCOMPLETE(string texto)
        {
            var alumnos = new List<T_CALIDAD_ENVASE>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.T_CALIDAD_ENVASE.Where(x => x.ENV_DESCRIPCION.Contains(texto) && x.ENV_ESTADO==1)
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
                    alumnos = (from a in ctx.T_CALIDAD_ENVASE where a.ENV_ESTADO == 1

                               select new
                               {
                                   codigo = a.ENV_CODIGO,
                                   DESCRIPCION = a.ENV_DESCRIPCION,

                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              ENV_CODIGO = c.codigo,
                              ENV_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static List<VISTA_TIPOANALISIS> ListarTAPARAMETRO(T_CALIDAD_ENVASE DATO)
        {
            var alumnos = new List<VISTA_TIPOANALISIS>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_ENVASE.Where(X => X.ENV_CODIGO == DATO.ENV_CODIGO && X.ENV_ESTADO == 1)

                               select new
                               {
                                   codigo = a.ENV_CODIGO,
                                   DESCRIPCION = a.ENV_DESCRIPCION,

                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              ENV_CODIGO = c.codigo,
                              ENV_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static Boolean insertaSolicitud(T_CALIDAD_ENVASE alumno)
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

        public static Boolean actualizaSolicitud(T_CALIDAD_ENVASE alumno)
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
                    codigo = ctx.T_CALIDAD_ENVASE.Where(x => x.ENV_DESCRIPCION != solicitud).Count() + 1;
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
