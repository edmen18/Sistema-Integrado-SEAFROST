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

    public partial class T_CALIDAD_TIPO_CERTIFICADO
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string TC_CODIGO { get; set; }

        [StringLength(500)]
        public string TC_DESCRIPCION { get; set; }

        public int TC_ESTADO { get; set; }
        public static List<T_CALIDAD_TIPO_CERTIFICADO> LISTARAUTOCOMPLETE(string texto)
        {
            var alumnos = new List<T_CALIDAD_TIPO_CERTIFICADO>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.T_CALIDAD_TIPO_CERTIFICADO.Where(x => x.TC_DESCRIPCION.Contains(texto) && x.TC_ESTADO==1 )
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
                    alumnos = (from a in ctx.T_CALIDAD_TIPO_CERTIFICADO where a.TC_ESTADO == 1

                               select new
                               {
                                   codigo = a.TC_CODIGO,
                                   DESCRIPCION = a.TC_DESCRIPCION,

                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              TC_CODIGO = c.codigo,
                              TC_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static List<VISTA_TIPOANALISIS> ListarTAPARAMETRO(T_CALIDAD_TIPO_CERTIFICADO DATO)
        {
            var alumnos = new List<VISTA_TIPOANALISIS>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_TIPO_CERTIFICADO.Where(X => X.TC_CODIGO == DATO.TC_CODIGO && X.TC_ESTADO == 1)

                               select new
                               {
                                   codigo = a.TC_CODIGO,
                                   DESCRIPCION = a.TC_DESCRIPCION,

                               }).ToList()
                          .Select(c => new VISTA_TIPOANALISIS()
                          {

                              TC_CODIGO = c.codigo,
                              TC_DESCRIPCION = c.DESCRIPCION,
                          }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static Boolean insertaSolicitud(T_CALIDAD_TIPO_CERTIFICADO alumno)
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

        public static Boolean actualizaSolicitud(T_CALIDAD_TIPO_CERTIFICADO alumno)
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
                    codigo = ctx.T_CALIDAD_TIPO_CERTIFICADO.Where(x => x.TC_DESCRIPCION != solicitud).Count() + 1;
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
