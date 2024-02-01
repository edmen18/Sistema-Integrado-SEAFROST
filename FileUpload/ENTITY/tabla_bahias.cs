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
    public partial class tabla_bahias
    {
        [StringLength(10)]
        public string ID { get; set; }

        [Required]
        [StringLength(50)]
        public string B_NOMBRES { get; set; }

        [StringLength(50)]
        public string B_APELLIDOS { get; set; }

        [StringLength(10)]
        public string B_TEL_CONTACTO { get; set; }

        [StringLength(10)]
        public string B_CEL_CONTACTO { get; set; }

        [StringLength(100)]
        public string B_GLOSA1 { get; set; }

        [StringLength(100)]
        public string B_GLOSA2 { get; set; }

        [StringLength(2)]
        public string B_ESTADO { get; set; }

        [Column(TypeName = "date")]
        public DateTime? B_FECHA_C { get; set; }

        [StringLength(10)]
        public string B_USUCRE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? B_FECHA_M { get; set; }

        [StringLength(10)]
        public string B_USUMOD { get; set; }

        public static List<tabla_bahias> ListarBahia(tabla_bahias BDATA)
        {
            var data = new List<tabla_bahias>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    //x.AR_CCODIGO.Contains(texto) SqlFunctions.PatIndex(BDATA.B_NOMBRES, x.B_NOMBRES) > 0
                    //data = ctx.tabla_bahias.Where(x => x.B_NOMBRES.Contains(BDATA.B_NOMBRES) && x.B_ESTADO == "A").ToList();
                    data = ctx.tabla_bahias.Where(x => SqlFunctions.PatIndex(BDATA.B_NOMBRES, x.B_NOMBRES) > 0 || SqlFunctions.PatIndex(BDATA.B_NOMBRES,x.B_APELLIDOS)>0 && x.B_ESTADO == "A").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return data;
        }

        public static Boolean insertaBahia(tabla_bahias datos)
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

        public static Boolean actualizaBahia(tabla_bahias datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new tabla_bahias { ID = datos.ID };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_bahias.Attach(data);
                    data.B_NOMBRES = datos.B_NOMBRES;
                    data.B_APELLIDOS = datos.B_APELLIDOS;
                    data.B_TEL_CONTACTO = datos.B_TEL_CONTACTO;
                    data.B_CEL_CONTACTO = datos.B_CEL_CONTACTO;
                    data.B_FECHA_M = fechaA;
                    data.B_USUMOD = datos.B_USUMOD;

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
