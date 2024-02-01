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
    public partial class AL0003SERI
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string SR_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string SR_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(18)]
        public string SR_CSERIE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SR_NSKDIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SR_NSKCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal SR_NPREUNI { get; set; }

        public DateTime? SR_DFECMOV { get; set; }

        public DateTime? SR_DFECVEN { get; set; }



        public static List<AL0003SERI> ListarLOTES(string AL, string COD, string SER)
        {
            var sql = new List<AL0003SERI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    sql = ctx.AL0003SERI.Where(x => x.SR_CALMA == AL && x.SR_CCODIGO == COD.Trim() && x.SR_CSERIE.Contains(SER))
                           .ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql;
        }

        public static List<AL0003SERI> ListarLOTES(AL0003SERI lt)
        {
            var sql = new List<AL0003SERI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    sql = ctx.AL0003SERI.Where(x => x.SR_CALMA == lt.SR_CALMA.Trim() && x.SR_CCODIGO == lt.SR_CCODIGO.Trim())
                           .ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql;
        }

        /// <summary>
        /// Lista SERIE/LOTE que tengan stock disponibles
        /// Opciones: x codigo, x almacen 
        /// CREADO:06/04/2016
        /// ACTUALIZACION:15/06/2016
        /// USER: Sergio
        /// Se modifico signo != a >
        /// </summary>
        /// <param name="SDATA">LSERIE</param>
        /// <returns></returns>
        public static List<AL0003SERI> ListarSL(AL0003SERI SDATA)
        {
            var LSERIE = new List<AL0003SERI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    LSERIE = ctx.AL0003SERI.Where(x => x.SR_CCODIGO == SDATA.SR_CCODIGO && x.SR_CALMA == SDATA.SR_CALMA && x.SR_NSKDIS > 0).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return LSERIE;
        }
        //NUEVO WILLIAM
        public static Boolean insertaSerie(AL0003SERI datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
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

        public static Boolean actualizaSSerie(AL0003SERI datos, string op)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            //var NALM = new AL0003ALMA();
            var data = new AL0003SERI { SR_CALMA = datos.SR_CALMA, SR_CCODIGO = datos.SR_CCODIGO.Trim(), SR_CSERIE = datos.SR_CSERIE };
            var NSTOCK = new AL0003SERI();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    NSTOCK = ctx.AL0003SERI.Where(x => x.SR_CALMA == datos.SR_CALMA && x.SR_CCODIGO == datos.SR_CCODIGO.Trim() && x.SR_CSERIE == datos.SR_CSERIE).FirstOrDefault();
                    //if (NSTOCK == null)
                    //{
                    //ingresaStock(datos);
                    //}
                    //else
                    //{
                    ctx.AL0003SERI.Attach(data);
                    if (op == "1")
                    {
                        data.SR_NSKDIS = Convert.ToDecimal(NSTOCK == null ? 0 : NSTOCK.SR_NSKDIS) + datos.SR_NSKDIS;

                    }
                    else
                    {
                        data.SR_NSKDIS = Convert.ToDecimal(NSTOCK.SR_NSKDIS) - datos.SR_NSKDIS;
                    }
                    data.SR_DFECVEN = NSTOCK.SR_DFECVEN;
                    data.SR_DFECMOV = fechaA;
                    ctx.Entry(data).State = EntityState.Modified;
                    //ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();
                    //}
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

        public static Boolean InsUpdSerie(AL0003SERI datos, string op)
        {
            Boolean band = true;
            var fechaA = DateTime.Now; //var NALM = new AL0003ALMA();
            var data = new AL0003SERI { SR_CALMA = datos.SR_CALMA, SR_CCODIGO = datos.SR_CCODIGO.Trim(), SR_CSERIE = datos.SR_CSERIE };
            var NSTOCK = new AL0003SERI();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    NSTOCK = ctx.AL0003SERI.Where(x => x.SR_CALMA == datos.SR_CALMA && x.SR_CCODIGO == datos.SR_CCODIGO.Trim() && x.SR_CSERIE == datos.SR_CSERIE).FirstOrDefault();
                    if (NSTOCK == null)
                    {
                        ctx.Entry(datos).State = EntityState.Added;
                        ctx.SaveChanges();
                        //ingresaStock(datos);
                    }
                    else
                    {
                        ctx.AL0003SERI.Attach(data);
                        if (op == "1")
                        {
                            data.SR_NSKDIS = Convert.ToDecimal(NSTOCK == null ? 0 : NSTOCK.SR_NSKDIS) + datos.SR_NSKDIS;
                        }
                        else
                        {
                            data.SR_NSKDIS = Convert.ToDecimal(NSTOCK.SR_NSKDIS) - datos.SR_NSKDIS;
                        }
                        data.SR_DFECVEN = NSTOCK.SR_DFECVEN;
                        data.SR_DFECMOV = fechaA;
                        ctx.Entry(data).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
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


        //nuevo Sergio
        public static List<AL0003SERI> ListarSLxPROD(AL0003SERI SDATA)
        {
            var LSERIE = new List<AL0003SERI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    LSERIE = ctx.AL0003SERI.Where(x => x.SR_CCODIGO == SDATA.SR_CCODIGO && x.SR_CSERIE==SDATA.SR_CSERIE && x.SR_CALMA == SDATA.SR_CALMA && x.SR_NSKDIS >= 0).ToList();
                }
            }
            catch (Exception)
            {

                LSERIE = null;
            }

            return LSERIE;
        } 

    }

}
