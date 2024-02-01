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

    public partial class tabla_porcentaje
    {
        [Key]
        public int PORC_CODIGO { get; set; }

        public decimal? PORC_MONTO { get; set; }

        [StringLength(1)]
        public string PORC_ESTADO { get; set; }

        public DateTime? PORC_FECHA { get; set; }

        [StringLength(5)]
        public string PORC_USU { get; set; }

        public static string actual()
        {
            var dato = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato =Convert.ToString(ctx.tabla_porcentaje.Where(X => X.PORC_ESTADO=="A").Select(X=>X.PORC_MONTO).ToList().FirstOrDefault());
                }
            }
            catch (Exception)
            {
                throw;
            }

            return dato;
        }


        public static List<tabla_porcentaje> ListarPorcentajes()
        {
            List<tabla_porcentaje> listaE = new List<tabla_porcentaje>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaE = ctx.tabla_porcentaje.OrderByDescending(X => X.PORC_FECHA).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaE;
        }

        public static Boolean insertar(tabla_porcentaje datos)
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

        public static Boolean Actualizar(tabla_porcentaje datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new tabla_porcentaje { PORC_CODIGO = datos.PORC_CODIGO };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_porcentaje.Attach(data);
                    data.PORC_ESTADO = datos.PORC_ESTADO;
                    data.PORC_FECHA = datos.PORC_FECHA;
                    data.PORC_MONTO = datos.PORC_MONTO;
                    data.PORC_USU = datos.PORC_USU;
                  
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
