namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    public partial class tabla_configuracion_correo
    {
        public int id { get; set; }

        [StringLength(50)]
        public string servidor_salida { get; set; }

        [StringLength(50)]
        public string usuario { get; set; }

        [StringLength(50)]
        public string pass { get; set; }

        public int? puerto { get; set; }


        public static Boolean Guardar(tabla_configuracion_correo alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {

                    if (alumno.id > 0)
                    {
                        ctx.Entry(alumno).State = EntityState.Modified;
                    }
                    else
                    {

                        ctx.Entry(alumno).State = EntityState.Added;
                    }
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
            }
            return band;
        }

        public static tabla_configuracion_correo ListaConfiguracionCorreo()
        {
            tabla_configuracion_correo userx = new tabla_configuracion_correo();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = ctx.tabla_configuracion_correo.FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }

    }
}
