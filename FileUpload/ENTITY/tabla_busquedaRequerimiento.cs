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

    public partial class tabla_busquedaRequerimiento
    {
        public int id { get; set; }

        [StringLength(20)]
        public string RC_CNROREQ { get; set; }

        [StringLength(20)]
        public string RC_DFECREQ { get; set; }

        [StringLength(50)]
        public string TG_CDESCRI { get; set; }

        [StringLength(50)]
        public string RD_CDESCRI { get; set; }

        [Column(TypeName = "money")]
        public decimal? RD_NQPEDI { get; set; }

        [StringLength(50)]
        public string CCOSTO { get; set; }

        [StringLength(50)]
        public string RC_CCODSOLI { get; set; }

        [StringLength(50)]
        public string RD_CCODIGO { get; set; }

        [StringLength(50)]
        public string RD_CCENCOS { get; set; }

        [StringLength(50)]
        public string IP { get; set; }


        public static Boolean EliminarBusquedaRequerimiento(int  id)
        {

            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(new tabla_busquedaRequerimiento { id = id}).State = EntityState.Deleted;
                    ctx.SaveChanges();
                }
            }
            catch (Exception)
            {
                band = false;
                //throw;
            }
            return band;
        }


        public static List<tabla_busquedaRequerimiento> obtenerBusquedaReq(string ip)
        {
            var alumnos = new List<tabla_busquedaRequerimiento>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                alumnos = ctx.tabla_busquedaRequerimiento.Where(x => x.IP == ip).ToList();
            }

            return alumnos;
        }

        public static Boolean insertaBusqueda(tabla_busquedaRequerimiento alumno)
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
    }
}
