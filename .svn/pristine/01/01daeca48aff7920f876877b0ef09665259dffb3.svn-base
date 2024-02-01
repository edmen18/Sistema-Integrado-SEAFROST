namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;

    public partial class tabla_detalle_oer
    {
        [Key]
        public int CODIGO_DETALLE { get; set; }

        [StringLength(10)]
        public string ORDEN_NUMERO { get; set; }

        public int? CODIGO_CAJA { get; set; }

        [StringLength(50)]
        public string CODIGO_PROVEEDOR { get; set; }

        [StringLength(50)]
        public string PROVEEDOR { get; set; }

        [StringLength(50)]
        public string RUC { get; set; }

        [StringLength(50)]
        public string TIPO_DOCUMENTO { get; set; }

        [StringLength(50)]
        public string NUM_DOCUMENTO { get; set; }

        public DateTime? FECHA_EMISION { get; set; }

        public DateTime? FECHA_VENCIMIENTO { get; set; }

        public decimal? MONTO_IGV { get; set; }

        public decimal? IGV { get; set; }

        public decimal? PARCIAL { get; set; }

        public decimal? TOTAL { get; set; }

        public string GLOSA_COMPROBANTE { get; set; }

        public string GLOSA_MOVIMIENTO { get; set; }

        [StringLength(12)]
        public string CUENTA { get; set; }

        [StringLength(50)]
        public string AREA { get; set; }

        [StringLength(50)]
        public string ANEXO_REFERENCIA { get; set; }

        public DateTime? FECHA_VEN { get; set; }

        [StringLength(50)]
        public string CENCOS { get; set; }

        [StringLength(50)]
        public string ANEXO_REF2 { get; set; }

        [StringLength(50)]
        public string MEDIOPAG { get; set; }
        public string TIPO_REF2 { get; set; }
        public string SUBDIARIO { get; set; }
        public DateTime? FECHA_REF2 { get; set; }
        public string MOTIVO { get; set; }
        public string ESTADO { get; set; }
        public string DVANEXO { get; set; }
        public string ANEXO { get; set; }
        public static Boolean INSERTAR(tabla_detalle_oer datos)
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
        public static List<tabla_detalle_oer> ListarTodos(tabla_detalle_oer com)
        {
            var retorno = new List<tabla_detalle_oer>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_detalle_oer.Where(X => X.ORDEN_NUMERO.Trim() == com.ORDEN_NUMERO.Trim() && X.CODIGO_CAJA == com.CODIGO_CAJA).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }
        public static List<tabla_detalle_oer> ListarUnItem(tabla_detalle_oer com)
        {
            var retorno = new List<tabla_detalle_oer>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_detalle_oer.Where(X => X.CODIGO_DETALLE == com.CODIGO_DETALLE).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static void Elimina(tabla_detalle_oer CCAB)
        {
            var ctx = new ANEXO_RSFACAR();
            var sql = "Delete tabla_detalle_oer  where CODIGO_DETALLE = @CODIGO_DETALLE ";

            ctx.Database.ExecuteSqlCommand(sql,
              new SqlParameter("CODIGO_DETALLE", CCAB.CODIGO_DETALLE));
        }
        public static Boolean actualizaSolicitud(tabla_detalle_oer alumno)
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

        public static void CambiarEstado(tabla_detalle_oer COM)
        {
            var orden = new tabla_detalle_oer { CODIGO_DETALLE = COM.CODIGO_DETALLE };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_detalle_oer.Attach(orden);
                orden.ESTADO = COM.ESTADO;           
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();               
            }
        }

    }
}
