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

    public partial class TABLA_LIQUIDACION_ANTICIPO
    {
        [Key]
        [StringLength(10)]
        public string LIQ_NUMERO { get; set; }

       
        public DateTime FECHA_REG { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public DateTime FECHA_EMISION { get; set; }

        public static List<vista_reporte_liquidacion> LiqImpresion(TABLA_LIQUIDACION_ANTICIPO COM)

        {
            var Listarep = new List<vista_reporte_liquidacion>();
            using (var ctx = new ANEXO_RSFACAR())
            {

                Listarep = (from a in ctx.tabla_anticipo
                            join liq in ctx.DETALLE_LIQUIDACION on a.ANT_CODIGO equals liq.ANT_CODIGO
                            join la in ctx.TABLA_LIQUIDACION_ANTICIPO on liq.LIQ_NUMERO equals la.LIQ_NUMERO

                            where
                              la.LIQ_NUMERO == COM.LIQ_NUMERO
                            select new
                            {
                                data1 = la.LIQ_NUMERO,
                                data2 = a.OC_CRAZSOC,
                                data3 = a.OC_FECEMI,
                                data4 = la.FECHA_REG,
                                data5 = a.OC_MONTO_PEDIDO,
                                data6 = a.OC_PERCENTAJE,
                                data7 = a.OC_ANTICIPO,
                                data8 = liq.FACTURA,
                                data9 = liq.MONTO,
                                data10 = a.MOTIVO,
                                data11=a.OC_CODMON,
                                data12= a.APROBADO,
                                DATA13=a.ANT_CODIGO,
                                data14=a.OC_TOTAL_PAGAR,
                                data15=a.OC_CNUMORD,

                            }).Distinct().ToList().
                 Select(c => new vista_reporte_liquidacion()
                 {
                     LIQ_NUMERO = c.data1,
                     OC_CRAZSOC = c.data2,
                     FECHA_EMISION = Convert.ToDateTime(c.data3),
                     OC_FECEMI =Convert.ToDateTime(c.data3),
                     FECHA_REG =Convert.ToDateTime(c.data4),
                     OC_MONTO_PEDIDO = Convert.ToDecimal(c.data5),
                     OC_PERCENTAJE = Convert.ToDecimal(c.data6),
                     OC_ANTICIPO = Convert.ToDecimal(c.data7),
                     FACTURA = c.data8,
                     MONTO = c.data9,
                     MOTIVO = c.data10,
                     OC_CODMON=c.data11,
                     APROBADO=c.data12,
                     ANT_CODIGO=c.DATA13,
                     OC_TOTAL_PAGAR=Convert.ToDecimal(c.data14),
                     OC_CNUMORD=c.data15,

                     
                 }).ToList();

            }
            return Listarep;
        }

        public static List<vista_liquidacion> ListarSA(tabla_anticipo CODATA)
        {
            var alumnos = new List<vista_liquidacion>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_anticipo
                               join liq in ctx.DETALLE_LIQUIDACION on a.ANT_CODIGO equals liq.ANT_CODIGO
                               join l in ctx.TABLA_LIQUIDACION_ANTICIPO on liq.LIQ_NUMERO equals l.LIQ_NUMERO
                               where a.OC_CCODPRO == CODATA.OC_CCODPRO ||
                                    (l.FECHA_EMISION >= CODATA.OC_FECEMI && l.FECHA_EMISION <= CODATA.OC_FECPRO)
                               select new
                               {
                                   liq_numero = l.LIQ_NUMERO,
                                   numoc = a.OC_CNUMORD,
                                   freg = l.FECHA_REG,
                                   femision = l.FECHA_EMISION,
                                   estado = a.ESTADO,

                                   ant_codigo = ((from b in ctx.tabla_anticipo
                                                  where b.ANT_CODIGO == a.ANT_CODIGO
                                                  select new { b.ANT_CODIGO }).FirstOrDefault().ANT_CODIGO),



                                   ruc = ((from b in ctx.tabla_anticipo
                                           where b.ANT_CODIGO == a.ANT_CODIGO
                                           select new { b.OC_CCODPRO }).FirstOrDefault().OC_CCODPRO),
                                   proveedor = ((from b in ctx.tabla_anticipo
                                                 where b.ANT_CODIGO == a.ANT_CODIGO
                                                 select new { b.OC_CRAZSOC }).FirstOrDefault().OC_CRAZSOC),
                                   //  moneda=a.OC_CODMON,

                                   moneda = ((from b in ctx.tabla_anticipo
                                              where b.ANT_CODIGO == a.ANT_CODIGO
                                              select new { b.OC_CODMON }).FirstOrDefault().OC_CODMON),

                                   montototal = ((from b in ctx.tabla_anticipo
                                                  where b.ANT_CODIGO == a.ANT_CODIGO
                                                  select new { b.OC_MONTO_PEDIDO }).FirstOrDefault().OC_MONTO_PEDIDO),

                                   porcentaje = ((from b in ctx.tabla_anticipo
                                                  where b.ANT_CODIGO == a.ANT_CODIGO
                                                  select new { b.OC_PERCENTAJE }).FirstOrDefault().OC_PERCENTAJE),

                                   anticipo = ((from b in ctx.tabla_anticipo
                                                where b.ANT_CODIGO == a.ANT_CODIGO
                                                select new { b.OC_ANTICIPO }).FirstOrDefault().OC_ANTICIPO),

                                   totalpagado = ((from b in ctx.tabla_anticipo
                                                   where b.ANT_CODIGO == a.ANT_CODIGO
                                                   select new { b.OC_TOTAL_PAGAR }).FirstOrDefault().OC_TOTAL_PAGAR),
                               }

                              ).OrderByDescending(X=> new {X.femision,X.liq_numero }).Distinct().ToList()
                          .Select(c => new vista_liquidacion()
                          {
                              LIQ_NUMERO = c.liq_numero,
                              ANT_CODIGO = c.ant_codigo,
                              OC_CNUMORD = c.numoc,
                              FECHA_EMISION = String.Format("{0:dd/MM/yyyy}", c.femision),
                              FECHA_REG = String.Format("{0:dd/MM/yyyy}", c.freg),
                              SOLICITUD = c.ant_codigo,
                              RUC = c.ruc,
                              PROVEEDOR = c.proveedor,
                              MONEDA = c.moneda,
                              MONTOTOTAL = Convert.ToDecimal(c.montototal),
                              PORCENTAJE = Convert.ToDecimal(c.porcentaje),
                              ANTICIPO = Convert.ToDecimal(c.anticipo),
                              PAGADO = Convert.ToDecimal(c.totalpagado),
                              ESTADO = c.estado,

                          }).ToList();

                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        public static Boolean insertaLiquidacion(TABLA_LIQUIDACION_ANTICIPO alumno)
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

        public static Boolean actualizaLiquidacion(TABLA_LIQUIDACION_ANTICIPO alumno)
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

        public static string GeneraNroLiquidacion(string liquidacion)
            
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.TABLA_LIQUIDACION_ANTICIPO.Where(x => x.LIQ_NUMERO != liquidacion).Count() + 1;
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;

        }

        public static tabla_anticipo ListarDatosAnticipoID(string oc)

        {
            var userx = new tabla_anticipo();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    userx = ctx.tabla_anticipo.Where(x => x.ANT_CODIGO == oc && x.ESTADO=="P" && x.APROBADO=="A").First();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return userx;
        }

        //public static tabla_anticipo ListarDatosAnticipoPorOreden(string oc, string ant)

        //{
        //    var userx = new tabla_anticipo();
        //    try
        //    {
        //        using (var ctx = new ANEXO_RSFACAR())
        //        {
        //            userx = ctx.tabla_anticipo.Where(x => x.OC_CNUMORD == oc && x.ESTADO == "P" && x.APROBADO == "A" && x.ANT_CODIGO.Contains(ant)).First();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        // throw;
        //    }
        //    return userx;
        //}

        public static List<tabla_anticipo> ListarDatosAnticipoPorOreden(string oc, string ant)
        {
            var codID = new List<tabla_anticipo>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codID = ctx.tabla_anticipo.Where(x => x.OC_CNUMORD.Trim() == oc.Trim() && x.ESTADO == "P" && x.APROBADO == "A" && x.ANT_CODIGO.Contains(ant)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return codID;
        }


        public static List<vista_reporte_liquidacion> ReporteLa(tabla_anticipo COM)
                        
        {
            var Listarep = new List<vista_reporte_liquidacion>();

            using (var ctx = new ANEXO_RSFACAR())
            {

                Listarep = (from ta in ctx.tabla_anticipo
                            join liq in ctx.DETALLE_LIQUIDACION on ta.ANT_CODIGO equals liq.ANT_CODIGO
                            join la in ctx.TABLA_LIQUIDACION_ANTICIPO on liq.LIQ_NUMERO equals la.LIQ_NUMERO
                            where
                              ( ta.OC_CCODPRO == COM.OC_CCODPRO || ta.OC_CNUMORD == COM.OC_CNUMORD || ta.ESTADO == COM.ESTADO) 
                              &&
                              (ta.OC_FECEMI >= COM.OC_FECEMI && ta.OC_FECEMI <= COM.OC_FECPRO)
                            select new
                            {
                                data1 = liq.ANT_CODIGO,
                                data2 = la.LIQ_NUMERO,
                                data3 = ta.OC_CRAZSOC,
                                data4 = ta.OC_FECEMI,
                                data5 = la.FECHA_REG,
                                data6 = ta.OC_MONTO_PEDIDO,
                                data7 = ta.OC_PERCENTAJE,
                                data8 = ta.OC_ANTICIPO,
                                data9 = ta.OC_CODMON,
                                data10 = ta.MOTIVO,
                                data11 = ta.OC_CODMON,
                                data12= ta.OC_CCODPRO,
                                DATA13=ta.ESTADO,
                                data14=ta.OC_CNUMORD,
                                data15=ta.OC_TOTAL_PAGAR,
                                data16 = ta.RETENCION,
                                data17 = ta.DETRACCION,
                            }).Distinct().ToList().
                 Select(c => new vista_reporte_liquidacion()
                 {
                     ANT_CODIGO = c.data1,
                     LIQ_NUMERO = c.data2,
                     OC_CRAZSOC = c.data3,
                     OC_FECEMI = Convert.ToDateTime(c.data4),
                     FECHA_REG = Convert.ToDateTime(c.data5),
                     OC_MONTO_PEDIDO = Convert.ToDecimal(c.data6),
                     OC_PERCENTAJE = Convert.ToDecimal(c.data7),
                     OC_ANTICIPO = Convert.ToDecimal(c.data8),
                     MONEDA = c.data9,
                     MOTIVO = c.data10,
                     OC_CODMON = c.data11,
                     OC_CCODPRO=c.data12,
                     ESTADO=c.DATA13,
                     OC_CNUMORD=c.data14,
                     OC_TOTAL_PAGAR= Convert.ToDecimal(c.data15),
                     RETENCION = Convert.ToDecimal(c.data16),
                     DETRACCION = Convert.ToDecimal(c.data17),

                 }).ToList();

            }
            return Listarep;
        }



        public static List<vista_reporte_liquidacion> ReporteLaFechas(tabla_anticipo COM)
         {
            var Listarep = new List<vista_reporte_liquidacion>();

            using (var ctx = new ANEXO_RSFACAR())
            {

                Listarep = (from ta in ctx.tabla_anticipo
                            join liq in ctx.DETALLE_LIQUIDACION on ta.ANT_CODIGO equals liq.ANT_CODIGO
                            join la in ctx.TABLA_LIQUIDACION_ANTICIPO on liq.LIQ_NUMERO equals la.LIQ_NUMERO
                            where (ta.OC_FECEMI >= COM.OC_FECEMI && ta.OC_FECEMI <= COM.OC_FECPRO) 
                            select new
                            {
                                data1 = liq.ANT_CODIGO,
                                data2 = la.LIQ_NUMERO,
                                data3 = ta.OC_CRAZSOC,
                                data4 = ta.OC_FECEMI,
                                data5 = la.FECHA_REG,
                                data6 = ta.OC_MONTO_PEDIDO,
                                data7 = ta.OC_PERCENTAJE,
                                data8 = ta.OC_ANTICIPO,
                                data9 = ta.OC_CODMON,
                                data10 = ta.MOTIVO,
                                data11 = ta.OC_CODMON,
                                data12 = ta.OC_CCODPRO,
                                DATA13 = ta.ESTADO,
                                data14 = ta.OC_CNUMORD,
                                data15 = ta.OC_TOTAL_PAGAR,
                                data16=ta.RETENCION,
                                data17=ta.DETRACCION,

                            }).Distinct().ToList().
                 Select(c => new vista_reporte_liquidacion()
                 {
                     ANT_CODIGO = c.data1,
                     LIQ_NUMERO = c.data2,
                     OC_CRAZSOC = c.data3,
                     OC_FECEMI = Convert.ToDateTime(c.data4),
                     FECHA_REG = Convert.ToDateTime(c.data5),
                     OC_MONTO_PEDIDO = Convert.ToDecimal(c.data6),
                     OC_PERCENTAJE = Convert.ToDecimal(c.data7),
                     OC_ANTICIPO = Convert.ToDecimal(c.data8),
                     MONEDA = c.data9,
                     MOTIVO = c.data10,
                     OC_CODMON = c.data11,
                     OC_CCODPRO = c.data12,
                     ESTADO = c.DATA13,
                     OC_CNUMORD = c.data14,
                     OC_TOTAL_PAGAR = Convert.ToDecimal(c.data15),
                      RETENCION= Convert.ToDecimal(c.data16),
                      DETRACCION= Convert.ToDecimal(c.data17),
                                       }).ToList();

            }
            return Listarep;
        }
    }
}
