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
    public partial class tabla_embarcaciones
    {
        [Key]
        [StringLength(20)]
        public string E_MATRIC { get; set; }

        [Required]
        [StringLength(50)]
        public string E_NOMBRE { get; set; }

        [Required]
        [StringLength(150)]
        public string E_RESOLU { get; set; }

        [Required]
        [StringLength(10)]
        public string E_PERPES { get; set; }

        [Required]
        [StringLength(10)]
        public string E_PERZAR { get; set; }

        [StringLength(60)]
        public string E_ESPCHD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? E_CABOM3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? E_CABOTM { get; set; }

        [Required]
        [StringLength(5)]
        public string E_USUCRE { get; set; }

        public DateTime E_FECCRE { get; set; }

        [StringLength(5)]
        public string E_USUMOD { get; set; }

        public DateTime? E_FECMOD { get; set; }

        [Required]
        [StringLength(2)]
        public string E_ESTADO { get; set; }

        public static string ListarEID(string ID)
        {
            string codID;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //ACTUALIZACIÓN PARA CONCHA SOLO MATRICULA EN DEMAS ESPECIES
                    codID = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC == ID
                                    && x.E_PERPES == "VIGENTE"
                                    && x.E_PERZAR == "VIGENTE"
                                    ).Select(y => y.E_NOMBRE + " " + (y.E_ESPCHD == "CONCHA"?"": y.E_MATRIC)).FirstOrDefault().ToString();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return codID;
        }
        public static List<tabla_embarcaciones> ListarEmbarcacionid(tabla_embarcaciones EDATA)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC.Contains(EDATA.E_MATRIC) 
                                        && x.E_PERPES == "VIGENTE" 
                                        && x.E_PERZAR == "VIGENTE"
                                        && x.E_ESTADO == "AL"
                                        ).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EDATA"></param>
        /// <returns></returns>
        public static List<tabla_embarcaciones> ListarEmbarcacion(tabla_embarcaciones EDATA)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_PERPES == "VIGENTE" && x.E_PERZAR == "VIGENTE" 
                    && x.E_ESTADO == "AL" &&
                    SqlFunctions.PatIndex(EDATA.E_NOMBRE, x.E_NOMBRE) > 0 || SqlFunctions.PatIndex(EDATA.E_NOMBRE, x.E_MATRIC) > 0)
                    .ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }

        // codigo edgar
        public static List<tabla_embarcaciones> ListarEmbarcacionestodos()
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_embarcaciones.OrderByDescending(X => X.E_FECCRE).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        public static List<tabla_embarcaciones> ListarEmbarcacionParametros(tabla_embarcaciones data)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC.Trim() == data.E_MATRIC.Trim()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }
        public static List<tabla_embarcaciones> ListarEmbarcacionAut(string texto)
        {
            List<tabla_embarcaciones> listaE = new List<tabla_embarcaciones>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_embarcaciones.Where(x => x.E_MATRIC.Contains(texto) || x.E_NOMBRE.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }

        public static Boolean insertaBahia(tabla_embarcaciones datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
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

        public static Boolean actualizaBahia(tabla_embarcaciones datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new tabla_embarcaciones { E_MATRIC = datos.E_MATRIC };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_embarcaciones.Attach(data);
                    data.E_MATRIC = datos.E_MATRIC;
                    data.E_NOMBRE = datos.E_NOMBRE;
                    data.E_RESOLU = datos.E_RESOLU;
                    data.E_CABOM3 = datos.E_CABOM3;
                    data.E_CABOTM = datos.E_CABOTM;
                    data.E_ESPCHD = datos.E_ESPCHD;
                    data.E_FECMOD = fechaA;
                    data.E_PERPES = datos.E_PERPES;
                    data.E_PERZAR = datos.E_PERZAR;
                    data.E_USUMOD = datos.E_USUMOD;
                    data.E_ESTADO = datos.E_ESTADO;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
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
