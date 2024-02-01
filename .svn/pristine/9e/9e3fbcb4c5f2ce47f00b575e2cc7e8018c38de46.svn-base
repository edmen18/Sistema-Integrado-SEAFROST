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
    using System.Data.SqlClient;
    using System.Data.Entity.SqlServer;
    using System.Data.Entity.Core.Objects;
    public class vista_reporteRequerimeintoPorFechas
    {
        public string NUMERO { get; set; }
        public string FECHA_HOY { get; set; }
        public int DIAS { get; set; }
        public string FECHA_APROB { get; set; }
        public string NUMERO_ORDEN { get; set; }
        public string CENTRO_COSTO { get; set; }
        public string SOLICITANTE { get; set; }
        public string CODIGO { get; set; }
        public string ARTICULO { get; set; }
        public string UNIDAD { get; set; }
        public decimal? CANTIDAD { get; set; }
        public string OBSERVACION { get; set; }
        // public string PROVEEDOR { get; set; }

        public string RC_CGLOSA1 { get; set; }
        public string RC_CGLOSA2 { get; set; }

        public string ESTADO { get; set; }

        public decimal? saldo { get; set; }

        public string proveedores { get; set; }




    }


    public class vista_requerimientoParaOC
    {
        public string RC_CNROREQ { get; set; }
        public string RC_DFECREQ { get; set; }
        public string RC_CCODSOLI { get; set; }
        public string TG_CDESCRI { get; set; }
        public string RD_CCODIGO { get; set; }
        public string RD_CDESCRI { get; set; }
        public decimal? RD_NQPEDI { get; set; }

        public string RD_CCENCOS { get; set; }
        public string CCOSTO { get; set; }

        public int CONTADOR { get; set; }


    }
    public class vista_requerimientoParaOCProductos
    {
        public string OC_DFECDOC { get; set; }
        public string OC_CCODPRO { get; set; }
        public string OC_CCODIGO { get; set; }

        public string OC_CRAZSOC { get; set; }
        public double OC_NPREUN2 { get; set; }
        public string pk { get; set; }

        public string OC_CCODMON { get; set; }
    }
    public class vista_requerimientoParaOCProductos1
    {
        public string OC_DFECDOC { get; set; }
        public string OC_CCODPRO { get; set; }
        public string OC_CCODIGO { get; set; }
        public double OC_NPREUN2 { get; set; }
        public string OC_CRAZSOC { get; set; }

        public string ARTICULO { get; set; }
        public string OC_CCODMON { get; set; }
    }
    public class vista_requerimientoParaOCProductosCab
    {
        public string OC_DFECDOC { get; set; }
        public string OC_CCODPRO { get; set; }
        public string OC_CCODIGO { get; set; }

    }
    public partial class AL0003REQC
    {
        [Key]
        [StringLength(7)]
        public string RC_CNROREQ { get; set; }

        public DateTime? RC_DFECREQ { get; set; }

        [StringLength(4)]
        public string RC_CCODSOLI { get; set; }

        [StringLength(5)]
        public string RC_CCODAREA { get; set; }

        [StringLength(6)]
        public string RC_CCENCOS { get; set; }

        [StringLength(18)]
        public string RC_CPRVSUG { get; set; }

        [StringLength(1)]
        public string RC_CESTADO { get; set; }

        [StringLength(5)]
        public string RC_CUSEA01 { get; set; }

        [StringLength(5)]
        public string RC_CUSEA02 { get; set; }

        [StringLength(5)]
        public string RC_CUSEA03 { get; set; }

        public DateTime? RC_DFECA01 { get; set; }

        public DateTime? RC_DFECA02 { get; set; }

        public DateTime? RC_DFECA03 { get; set; }


        [StringLength(1)]
        public string RC_CUNIREQ { get; set; }


        [StringLength(2)]
        public string RC_CCODMON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RC_NIMPMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? RC_NIMPUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RC_NTIPCAM { get; set; }


        [StringLength(4)]
        public string RC_CAGEOT { get; set; }


        [StringLength(11)]
        public string RC_CNUMOT { get; set; }


        [StringLength(2)]
        public string RC_CORIREQ { get; set; }


        [StringLength(2)]
        public string RC_CTIPREQ { get; set; }

        [Required]
        [StringLength(5)]
        public string RC_CUSUCRE { get; set; }

        public DateTime? RC_DFECCRE { get; set; }

        [StringLength(20)]
        public string RC_CNUMORD { get; set; }


        [StringLength(225)]
        public string RC_CGLOSA1 { get; set; }


        [StringLength(225)]
        public string RC_CGLOSA2 { get; set; }


        [StringLength(1)]
        public string RC_CTIPAPR { get; set; }


        [StringLength(3)]
        public string RC_CAREARQ { get; set; }


        [StringLength(20)]
        public string RC_CNUMCOT { get; set; }


        //public static List<vista_reporteRequerimeintoPorFechas> reporteRequerimeintoPorFechasPorParte(DateTime fecha1, DateTime fecha2)
        //{

        //   var reporte = AL0003REQC.reporteRequerimeintoPorFechas(fecha1, fecha2);

        //    using (var ctx = new RSFACAR())
        //    {
        //        var data =
        //               ( 
        //               from A in reporte 
        //               select new
        //               {
        //                    e = "'" +
        //                        ((

        //                         from c in ctx.AL0003MOVC
        //                         join d in ctx.AL0003MOVD
        //                               on new { c.C5_CALMA, c.C5_CTD, c.C5_CNUMDOC }
        //                           equals new { C5_CALMA = d.C6_CALMA, C5_CTD = d.C6_CTD, C5_CNUMDOC = d.C6_CNUMDOC }





        //                         from AL0003MOVC  in ctx.CO0003MOVD
        //                          where
        //                         CO0003MOVD.OC_CNUMREQ.Trim() == A.RC_CNROREQ.Trim() &&
        //                         CO0003MOVD.OC_CCODIGO.Trim() == B.RD_CCODIGO.Trim()
        //                          select new
        //                          {
        //                              CO0003MOVD.OC_CNUMORD
        //                          }).FirstOrDefault().OC_CNUMORD)


        //    return reporte;

        //}
        public static List<vista_reporteRequerimeintoPorFechas> reporteRequerimeintoPorFechas(DateTime fecha1, DateTime fecha2, int band)
        {
            using (var ctx = new RSFACAR())
            {

                return ctx.Database.SqlQuery<vista_reporteRequerimeintoPorFechas>("EXEC PR_REPORTESEMAFOROREQUERIMIENTO").ToList();
                //var data =
                //       (
                //       from A in ctx.AL0003REQC//VISTA_REQUERIMIENTOS
                //       join B in ctx.AL0003REQD on new { RC_CNROREQ = A.RC_CNROREQ } equals new { RC_CNROREQ = B.RD_CNROREQ }
                //       join C in ctx.AL0003ARTI on new { AR_CCODIGO = B.RD_CCODIGO } equals new { AR_CCODIGO = C.AR_CCODIGO }
                //       where
                //      (A.RC_DFECREQ >= fecha1 && A.RC_DFECREQ <= fecha2) && (band == 1 ? (A.RC_CESTADO == "3" || A.RC_CESTADO == "7") : band == 2 ? A.RC_CESTADO == "7": A.RC_CESTADO == "3")
                //       select new
                //       {

                //           a = "'" + A.RC_CNROREQ,
                //           b = DateTime.Now,
                //           c = A.RC_DFECA03,// DateTime.Now.Subtract(Convert.ToDateTime(A.RC_DFECA03)).Days,
                //           d = A.RC_DFECA03,
                //           e = "'" +
                //                ((from CO0003MOVD in ctx.CO0003MOVD
                //                  where
                //                 CO0003MOVD.OC_CNUMREQ.Trim() == A.RC_CNROREQ.Trim() &&
                //                 CO0003MOVD.OC_CCODIGO.Trim() == B.RD_CCODIGO.Trim()
                //                  select new
                //                  {
                //                      CO0003MOVD.OC_CNUMORD
                //                  }).FirstOrDefault().OC_CNUMORD),
                //        //   f = A.PROVEEDOR,

                //           g =
                //                   (B.RD_CCENCOS + " " +
                //                ((from a in ctx.AL0003TABL
                //                  where
                //                    a.TG_CCLAVE == B.RD_CCENCOS &&
                //                    a.TG_CCOD == "10"
                //                  select new
                //                  {
                //                      a.TG_CDESCRI
                //                  }).FirstOrDefault().TG_CDESCRI)),

                //           h =
                //                ((from a in ctx.AL0003TABL
                //                  where
                //                   a.TG_CCLAVE == B.RD_CUSRCOM &&
                //                a.TG_CCOD == "12"
                //                  select new
                //                  {
                //                      a.TG_CDESCRI
                //                  }).FirstOrDefault().TG_CDESCRI),

                //           i = C.AR_CCODIGO,
                //           j = C.AR_CDESCRI,
                //           k = C.AR_CUNIDAD,
                //           l = B.RD_NCANAPR,
                //           m = B.RD_COBS,
                //           n = A.RC_CGLOSA1,
                //           o = A.RC_CGLOSA2,

                //           p = (
                //            from D in ctx.AL0003TABL where D.TG_CCOD == "31" && D.TG_CCLAVE ==
                //        (
                //          (
                //               from C in ctx.CO0003MOVD where C.OC_CNUMORD ==
                //               ((from CO0003MOVD in ctx.CO0003MOVD
                //                 where
                //                CO0003MOVD.OC_CNUMREQ.Trim() == A.RC_CNROREQ.Trim() &&
                //                CO0003MOVD.OC_CCODIGO.Trim() == B.RD_CCODIGO.Trim()
                //                 select new
                //                 {
                //                     CO0003MOVD.OC_CNUMORD
                //                 }).FirstOrDefault().OC_CNUMORD)

                //               select new
                //               {
                //                   C.OC_CESTADO
                //               }).FirstOrDefault().OC_CESTADO
                //         )

                //            select new
                //            {
                //                D.TG_CDESCRI
                //            }).FirstOrDefault().TG_CDESCRI,

                //           q =
                //             (
                //                  from C in ctx.CO0003MOVD
                //                  where C.OC_CNUMORD ==
                //                   ((from CO0003MOVD in ctx.CO0003MOVD
                //                     where
                //                    CO0003MOVD.OC_CNUMREQ.Trim() == A.RC_CNROREQ.Trim() &&
                //                    CO0003MOVD.OC_CCODIGO.Trim() == B.RD_CCODIGO.Trim()
                //                     select new
                //                     {
                //                         CO0003MOVD.OC_CNUMORD
                //                     }).FirstOrDefault().OC_CNUMORD)

                //                  select new
                //                  {
                //                      Column1 = (((System.Decimal?)C.OC_NCANORD ?? (System.Decimal?)0) - ((System.Decimal?)C.OC_NCANSAL ?? (System.Decimal?)0)),

                //                  }).FirstOrDefault().Column1//,

                //          // r = CO0003MOVC.RetornaProveedores(  C.AR_CCODIGO)

                //       }
                //       ).ToList()
                //       .Select(c => new vista_reporteRequerimeintoPorFechas()
                //       {
                //           NUMERO = c.a,
                //           FECHA_HOY = String.Format("{0:dd/MM/yyyy}", c.b),
                //           DIAS  = DateTime.Now.Subtract(Convert.ToDateTime(c.c)).Days,//DateTime.Now.Subtract(Convert.ToDateTime(c.c)).Days,
                //           FECHA_APROB= String.Format("{0:dd/MM/yyyy}", c.d),
                //           NUMERO_ORDEN = c.e,
                //         //  PROVEEDOR = c.f,
                //           CENTRO_COSTO =c.g,
                //           SOLICITANTE =c.h,
                //           CODIGO=c.i,
                //           ARTICULO=c.j,
                //           UNIDAD=c.k,
                //           CANTIDAD=c.l,
                //           OBSERVACION=c.m,
                //           RC_CGLOSA1=c.n,
                //           RC_CGLOSA2=c.o,
                //           ESTADO=c.p ,
                //           saldo=c.q,
                //           proveedores= ""//CO0003MOVC.RetornaProveedores(c.i)
                //       }).ToList();

                //return data;    

            }
        }


        public static Boolean actualizaValoresRequerimineto(string RC_CNROREQ, string moneda, decimal soles, decimal dolares, decimal tcambio)
        {
            Boolean band = true;
            var cliente = new AL0003REQC { RC_CNROREQ = RC_CNROREQ };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQC.Attach(cliente);
                    cliente.RC_CCODMON = moneda;
                    cliente.RC_NIMPMN = soles;
                    cliente.RC_NIMPUS = dolares;
                    cliente.RC_NTIPCAM = tcambio;
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


        public static Boolean apruebaRequerimientoAtendido(string RC_CNROREQ, string RC_CESTADO)
        {
            Boolean band = true;
            var cliente = new AL0003REQC { RC_CNROREQ = RC_CNROREQ };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQC.Attach(cliente);
                    cliente.RC_CESTADO = RC_CESTADO;
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

        public static Boolean EliminarCabeceraRequerimiento(AL0003REQC req)
        {

            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(new AL0003REQC { RC_CNROREQ = req.RC_CNROREQ }).State = EntityState.Deleted;
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

        public static Boolean insertaRequerimiento(AL0003REQC alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
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
        public static Boolean modifcaRequerimiento(AL0003REQC alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSFACAR())
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
        public static Boolean apruebaRequerimiento(AL0003REQC alumno)
        {
            string fechaX = "01/01/2000";

            string user1 = string.Empty; string user2 = string.Empty; string user3 = string.Empty;
            string fecha1 = fechaX; string fecha2 = fechaX; string fecha3 = fechaX;

            if (alumno.RC_CUSEA01.Trim() == string.Empty && alumno.RC_CUSEA02.Trim() == string.Empty && alumno.RC_CUSEA03.Trim() == string.Empty)
            {
                user1 = alumno.RC_CUSUCRE;
                fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
            }
            if (alumno.RC_CUSEA01.Trim() != string.Empty && alumno.RC_CUSEA02.Trim() == string.Empty && alumno.RC_CUSEA03.Trim() == string.Empty)
            {
                user1 = alumno.RC_CUSEA01;
                user2 = alumno.RC_CUSUCRE;
                fecha2 = DateTime.Now.ToString("dd/MM/yyyy");
            }
            if (alumno.RC_CUSEA01.Trim() != string.Empty && alumno.RC_CUSEA02.Trim() != string.Empty && alumno.RC_CUSEA03.Trim() == string.Empty)
            {
                user1 = alumno.RC_CUSEA01;
                user2 = alumno.RC_CUSEA02;
                user3 = alumno.RC_CUSUCRE;
                fecha3 = DateTime.Now.ToString("dd/MM/yyyy");
            }

            AL0003REQC rec = new AL0003REQC()
            {
                RC_CNROREQ = alumno.RC_CNROREQ,
                RC_CESTADO = ((user1 != string.Empty && user2 != string.Empty && user3 != string.Empty) ? "7" : "1"),
                RC_CUSEA01 = user1,
                RC_CUSEA02 = user2,
                RC_CUSEA03 = user3,
                RC_DFECA01 = Convert.ToDateTime(fecha1),
                RC_DFECA02 = Convert.ToDateTime(fecha2),
                RC_DFECA03 = Convert.ToDateTime(fecha3),
                RC_CTIPAPR = ((user1 != string.Empty && user2 != string.Empty && user3 != string.Empty) ? "T" : string.Empty)

            };
            ////////////////////////////////////////
            string fechay = "01/01/2000";
            Boolean band = true;
            var cliente = new AL0003REQC { RC_CNROREQ = alumno.RC_CNROREQ };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQC.Attach(cliente);
                    cliente.RC_CESTADO = rec.RC_CESTADO;
                    cliente.RC_CUSEA01 = rec.RC_CUSEA01;
                    cliente.RC_CUSEA02 = rec.RC_CUSEA02;
                    cliente.RC_CUSEA03 = rec.RC_CUSEA03;
                    cliente.RC_CTIPAPR = rec.RC_CTIPAPR;

                    if (Convert.ToDateTime(fechay) != rec.RC_DFECA01)
                    {
                        cliente.RC_DFECA01 = rec.RC_DFECA01;
                    }
                    if (Convert.ToDateTime(fechay) != rec.RC_DFECA02)
                    {
                        cliente.RC_DFECA02 = rec.RC_DFECA02;
                    }
                    if (Convert.ToDateTime(fechay) != rec.RC_DFECA03)
                    {
                        cliente.RC_DFECA03 = rec.RC_DFECA03;
                    }

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



        public static List<vista_requerimientoParaOCProductos1> listarqcontraoc(string[] req, string[] req1)
        {
            var alumnos1 = new List<vista_requerimientoParaOCProductos>();
            var alumnos2 = new List<vista_requerimientoParaOCProductosCab>();
            var alumnos3 = new List<vista_requerimientoParaOCProductos1>();
            using (var ctx = new RSFACAR())
            {
                alumnos1 = (from a in ctx.CO0003MOVC
                            join b in ctx.CO0003MOVD on a.OC_CNUMORD equals b.OC_CNUMORD

                            where
                            (req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2 > 0
                            orderby
                             b.OC_CCODIGO,
                             a.OC_CRAZSOC
                            select new
                            {
                                a = a.OC_DFECDOC,
                                b = a.OC_CCODPRO,
                                c = a.OC_CRAZSOC,
                                d = b.OC_CCODIGO,
                                e = b.OC_NPREUN2,
                                f = a.OC_CCODMON

                            }
                                              ).ToList()
                                                 .Select(c => new vista_requerimientoParaOCProductos()
                                                 {
                                                     OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.a),
                                                     OC_CCODPRO = c.b,
                                                     OC_CRAZSOC = c.c,
                                                     OC_CCODIGO = c.d,
                                                     OC_NPREUN2 = Convert.ToDouble(c.e),
                                                     pk = String.Format("{0:yyyyMMdd}", c.a) + (c.b.Trim().ToUpper()) + (c.d.Trim().ToUpper()),
                                                     OC_CCODMON = c.f

                                                 }).ToList();
                alumnos2 = (
                    from a in ctx.CO0003MOVC
                    join b in ctx.CO0003MOVD on a.OC_CNUMORD equals b.OC_CNUMORD
                    where (req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2 > 0
                    group new { a, b } by new
                    {
                        a.OC_CCODPRO,
                        b.OC_CCODIGO
                    } into g
                    orderby
                      g.Key.OC_CCODIGO,
                      g.Key.OC_CCODPRO
                    select new
                    {
                        a = (DateTime?)g.Max(p => p.a.OC_DFECDOC),
                        b = g.Key.OC_CCODPRO,
                        c = g.Key.OC_CCODIGO
                    }
                    ).ToList()
                    .Select(c => new vista_requerimientoParaOCProductosCab()
                    {
                        OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.a),
                        OC_CCODPRO = c.b,
                        OC_CCODIGO = c.c

                    }).ToList();

                alumnos3 = (from x in alumnos2
                            select new

                            {
                                a = x.OC_CCODIGO,
                                b = x.OC_CCODPRO,
                                c = x.OC_DFECDOC,
                                d = (

                                (from b in alumnos1
                                 where
                                   b.pk == x.OC_DFECDOC.Substring(6, 4) + x.OC_DFECDOC.Substring(3, 2) + x.OC_DFECDOC.Substring(0, 2) + x.OC_CCODPRO.Trim() + x.OC_CCODIGO.Trim()
                                 select new
                                 {
                                     b.OC_NPREUN2

                                 }).FirstOrDefault().OC_NPREUN2

                                      )
                                      ,

                                e = ((from b in alumnos1
                                      where
                                        b.pk == x.OC_DFECDOC.Substring(6, 4) + x.OC_DFECDOC.Substring(3, 2) + x.OC_DFECDOC.Substring(0, 2) + x.OC_CCODPRO.Trim() + x.OC_CCODIGO.Trim()
                                      select new
                                      {
                                          b.OC_CRAZSOC

                                      }).FirstOrDefault().OC_CRAZSOC),
                                f = ((from b in ctx.AL0003ARTI
                                      where
                                        b.AR_CCODIGO == x.OC_CCODIGO
                                      select new
                                      {
                                          b.AR_CDESCRI

                                      }).FirstOrDefault().AR_CDESCRI),

                                g = ((from b in alumnos1
                                      where
                                        b.pk == x.OC_DFECDOC.Substring(6, 4) + x.OC_DFECDOC.Substring(3, 2) + x.OC_DFECDOC.Substring(0, 2) + x.OC_CCODPRO.Trim() + x.OC_CCODIGO.Trim()
                                      select new
                                      {
                                          b.OC_CCODMON

                                      }).FirstOrDefault().OC_CCODMON)
                            }).ToList()
                       .Select(c => new vista_requerimientoParaOCProductos1()
                       {
                           OC_CCODIGO = c.a,
                           OC_CCODPRO = c.b,
                           OC_DFECDOC = c.c,
                           OC_NPREUN2 = c.d,
                           OC_CRAZSOC = c.e,
                           ARTICULO = c.f,
                           OC_CCODMON = c.g

                       }).ToList();



            }

            return alumnos3;
        }

        public static List<vista_requerimientoParaOC> ListarRequerimientosParaOCPorNumero(AL0003REQC rec)
        {
            var alumnos = new List<vista_requerimientoParaOC>();
            using (var ctx = new RSFACAR())
            {
                alumnos = (from c in ctx.AL0003REQC
                           join b in ctx.AL0003REQD on c.RC_CNROREQ equals b.RD_CNROREQ
                           where c.RC_CESTADO == "7"
                           &&
                           c.RC_CNROREQ.Trim() == rec.RC_CNROREQ.Trim()
                           orderby c.RC_CNROREQ
                           select new
                           {
                               a = c.RC_CNROREQ,
                               b = c.RC_DFECREQ,
                               c = b.RD_CUSRCOM,
                               d = ((from x in ctx.AL0003TABL
                                     where
                                       x.TG_CCOD == "12" && x.TG_CCLAVE == b.RD_CUSRCOM
                                     select new
                                     {
                                         x.TG_CDESCRI

                                     }).FirstOrDefault().TG_CDESCRI),
                               e = b.RD_CCODIGO,
                               f = b.RD_CDESCRI,
                               g = b.RD_NQPEDI,
                               h = ((from x in ctx.AL0003TABL
                                     where
                                       x.TG_CCOD == "10" && x.TG_CCLAVE == b.RD_CCENCOS
                                     select new
                                     {
                                         x.TG_CDESCRI

                                     }).FirstOrDefault().TG_CDESCRI),
                               i = b.RD_CCENCOS
                           }).ToList()
                                               .Select(c => new vista_requerimientoParaOC()
                                               {
                                                   RC_CNROREQ = c.a.Trim(),
                                                   RC_DFECREQ = String.Format("{0:dd/MM/yyyy}", c.b),
                                                   RC_CCODSOLI = c.c.Trim(),
                                                   TG_CDESCRI = c.d.Trim(),
                                                   RD_CCODIGO = c.e.Trim(),
                                                   RD_CDESCRI = c.f.Trim(),
                                                   RD_NQPEDI = c.g,
                                                   CCOSTO = c.h.Trim(),
                                                   RD_CCENCOS = c.i.Trim()


                                               }).ToList();
            }

            return alumnos;
        }

        public static List<vista_requerimientoParaOC> ListarRequerimientosParaOC(AL0003REQC rec)
        {
            var alumnos = new List<vista_requerimientoParaOC>();
            using (var ctx = new RSFACAR())
            {
                alumnos = (from c in ctx.AL0003REQC
                           join b in ctx.AL0003REQD on c.RC_CNROREQ equals b.RD_CNROREQ
                           where (c.RC_CESTADO == "3" || c.RC_CESTADO == "7") && (c.RC_DFECREQ >= rec.RC_DFECA01 && c.RC_DFECREQ <= rec.RC_DFECA02)
                          && ((rec.RC_CCODSOLI == "-1") ? b.RD_CUSRCOM != rec.RC_CCODSOLI : b.RD_CUSRCOM == rec.RC_CCODSOLI)
                          && b.RD_CSITUA == "7"
                           orderby c.RC_CNROREQ
                           select new
                           {
                               a = c.RC_CNROREQ,
                               b = c.RC_DFECREQ,
                               c = b.RD_CUSRCOM,
                               d = ((from x in ctx.AL0003TABL
                                     where
                                       x.TG_CCOD == "12" && x.TG_CCLAVE == b.RD_CUSRCOM
                                     select new
                                     {
                                         x.TG_CDESCRI

                                     }).FirstOrDefault().TG_CDESCRI),
                               e = b.RD_CCODIGO,
                               f = b.RD_CDESCRI,
                               g = b.RD_NQPEDI,
                               h = ((from x in ctx.AL0003TABL
                                     where
                                       x.TG_CCOD == "10" && x.TG_CCLAVE == b.RD_CCENCOS
                                     select new
                                     {
                                         x.TG_CDESCRI

                                     }).FirstOrDefault().TG_CDESCRI),
                               i = b.RD_CCENCOS
                           }).ToList()
                                               .Select(c => new vista_requerimientoParaOC()
                                               {
                                                   RC_CNROREQ = c.a.Trim(),
                                                   RC_DFECREQ = String.Format("{0:dd/MM/yyyy}", c.b),
                                                   RC_CCODSOLI = c.c.Trim(),
                                                   TG_CDESCRI = c.d.Trim(),
                                                   RD_CCODIGO = c.e.Trim(),
                                                   RD_CDESCRI = c.f.Trim(),
                                                   RD_NQPEDI = c.g,
                                                   CCOSTO = c.h.Trim(),
                                                   RD_CCENCOS = c.i.Trim()


                                               }).ToList();
            }

            return alumnos;
        }


        public static List<VISTA_REQUERIMIENTOS> ListarRequerimientos(VISTA_REQUERIMIENTOS REQ)
        {
            var alumnos = new List<VISTA_REQUERIMIENTOS>();
            using (var ctx = new RSFACAR())
            {
                var query = ctx.AL0003REQD.Join(ctx.VISTA_REQUERIMIENTOS, c => c.RD_CNROREQ, cm => cm.RC_CNROREQ, (c, cm) => new { AL0003REQD = c, VISTA_REQUERIMIENTOS = cm }).Where(c => c.AL0003REQD.RD_CCODIGO == REQ.USUARIO && c.VISTA_REQUERIMIENTOS.ANIO == REQ.ANIO && c.VISTA_REQUERIMIENTOS.MES == REQ.MES)
                            .Select(x => x.VISTA_REQUERIMIENTOS.RC_CNROREQ).ToArray();

                // if (REQ.USUARIO != null)
                //{

                if (query.Length > 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => query.Contains(x.RC_CNROREQ)).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();
                //  return alumnos;
                //}

                if (REQ.RC_CUSUCRE == "-1" && REQ.RC_CESTADO == "-1" && query.Length == 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


                if (REQ.RC_CUSUCRE != "-1" && REQ.RC_CESTADO == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CUSUCRE == REQ.RC_CUSUCRE).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if (REQ.RC_CESTADO != "-1" && REQ.RC_CUSUCRE == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CESTADO == REQ.RC_CESTADO).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if ((REQ.RC_CUSUCRE != "-1") && (REQ.RC_CESTADO != "-1"))
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CUSUCRE == REQ.RC_CUSUCRE && x.RC_CESTADO == REQ.RC_CESTADO).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


            }

            return alumnos;
        }

        public static List<VISTA_REQUERIMIENTOS> ListarRequerimientosInicio(VISTA_REQUERIMIENTOS REQ)
        {
            var alumnos = new List<VISTA_REQUERIMIENTOS>();
            using (var ctx = new RSFACAR())
            {
                var query = ctx.AL0003REQD.Join(ctx.VISTA_REQUERIMIENTOS, c => c.RD_CNROREQ, cm => cm.RC_CNROREQ, (c, cm) => new { AL0003REQD = c, VISTA_REQUERIMIENTOS = cm }).Where(c => c.VISTA_REQUERIMIENTOS.ANIO == REQ.ANIO && c.VISTA_REQUERIMIENTOS.RC_CESTADO == REQ.RC_CESTADO)
                            .Select(x => x.VISTA_REQUERIMIENTOS.RC_CNROREQ).ToArray();

                // if (REQ.USUARIO != null)
                //{

                if (query.Length > 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => query.Contains(x.RC_CNROREQ)).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();
                //  return alumnos;
                //}

                if (REQ.RC_CUSUCRE == "-1" && REQ.RC_CESTADO == "-1" && query.Length == 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


                if (REQ.RC_CUSUCRE != "-1" && REQ.RC_CESTADO == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CUSUCRE == REQ.RC_CUSUCRE).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if (REQ.RC_CESTADO != "-1" && REQ.RC_CUSUCRE == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CESTADO == REQ.RC_CESTADO).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if ((REQ.RC_CUSUCRE != "-1") && (REQ.RC_CESTADO != "-1"))
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CUSUCRE == REQ.RC_CUSUCRE && x.RC_CESTADO == REQ.RC_CESTADO).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


            }

            return alumnos;
        }

        public static List<VISTA_REQUERIMIENTOS> ListarRequerimientosInicio2(VISTA_REQUERIMIENTOS REQ)
        {
            var alumnos = new List<VISTA_REQUERIMIENTOS>();
            using (var ctx = new RSFACAR())
            {
                var query = ctx.AL0003REQD.Join(ctx.VISTA_REQUERIMIENTOS, c => c.RD_CNROREQ, cm => cm.RC_CNROREQ, (c, cm) => new { AL0003REQD = c, VISTA_REQUERIMIENTOS = cm }).Where(c => c.VISTA_REQUERIMIENTOS.ANIO == REQ.ANIO && c.VISTA_REQUERIMIENTOS.RC_CESTADO == REQ.RC_CESTADO && c.VISTA_REQUERIMIENTOS.RC_CUSEA01 != "     " && c.VISTA_REQUERIMIENTOS.RC_CUSEA02 != "     " && c.VISTA_REQUERIMIENTOS.RC_CUSEA03 == "     ")
                            .Select(x => x.VISTA_REQUERIMIENTOS.RC_CNROREQ).ToArray();

                // if (REQ.USUARIO != null)
                //{

                if (query.Length > 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => query.Contains(x.RC_CNROREQ)).OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();
                //  return alumnos;
                //}

                if (REQ.RC_CUSUCRE == "-1" && REQ.RC_CESTADO == "-1" && query.Length == 0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && REQ.RC_CUSEA01 != "     " && REQ.RC_CUSEA02 != "     " && REQ.RC_CUSEA03 == "     ").OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


                if (REQ.RC_CUSUCRE != "-1" && REQ.RC_CESTADO == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CUSUCRE == REQ.RC_CUSUCRE && x.RC_CUSEA01 != "     " && x.RC_CUSEA02 != "     " && x.RC_CUSEA03 == "     ").OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if (REQ.RC_CESTADO != "-1" && REQ.RC_CUSUCRE == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CESTADO == REQ.RC_CESTADO && x.RC_CUSEA01 != "     " && x.RC_CUSEA02 != "     " && x.RC_CUSEA03 == "     ").OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();

                if ((REQ.RC_CUSUCRE != "-1") && (REQ.RC_CESTADO != "-1"))
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.RC_CUSUCRE == REQ.RC_CUSUCRE && x.RC_CUSEA01 != "     " && x.RC_CUSEA02 != "     " && x.RC_CUSEA03 == "     ").OrderByDescending(x => x.RC_DFECREQ).OrderByDescending(x => x.RC_CNROREQ).ToList();


            }

            return alumnos;
        }
        public static AL0003REQC obtenerRequerimientoPorNumero(AL0003REQC rec)
        {
            var alumnos = new AL0003REQC();
            using (var ctx = new RSFACAR())
            {
                alumnos = ctx.AL0003REQC.Where(x => x.RC_CNROREQ == rec.RC_CNROREQ).FirstOrDefault();
            }

            return alumnos;
        }

        public static Boolean desapruebaRequerimientoCab(AL0003REQC alumno)
        {
            DateTime fecha = Convert.ToDateTime("01/01/1900");
            Boolean band = true;
            var cliente = new AL0003REQC { RC_CNROREQ = alumno.RC_CNROREQ };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003REQC.Attach(cliente);
                    cliente.RC_CESTADO = alumno.RC_CESTADO;
                    cliente.RC_CUSEA01 = alumno.RC_CUSEA01;
                    cliente.RC_CUSEA02 = alumno.RC_CUSEA02;
                    cliente.RC_CUSEA03 = alumno.RC_CUSEA03;
                    cliente.RC_CTIPAPR = alumno.RC_CTIPAPR;
                    cliente.RC_DFECA01 = fecha;
                    cliente.RC_DFECA02 = fecha;
                    cliente.RC_DFECA03 = fecha;
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

        //CODIGO EDGAR PARA EL REPORTE DE DIAS DE RETRASO DE REQUERIMIENTOS
        public static List<AL0003REQC> ListarReqautocomplete(AL0003REQC datos)
        {
            var codID = new List<AL0003REQC>();

            using (var ctx = new RSFACAR())
            {
                codID = (from REQUE in ctx.AL0003REQC ///join orden in ctx.CO0003MOVC on REQUE.RC_CNUMORD equals orden.OC_CNUMORD
                         where (REQUE.RC_CESTADO == "7") && (REQUE.RC_CNROREQ.Contains(datos.RC_CNROREQ)) && (REQUE.RC_CCODMON.Trim() == datos.RC_CCODMON)
                         // && (orden.OC_CCODPRO==datos.RC_CGLOSA1)                           
                         select new
                         {
                             a = REQUE.RC_CNROREQ,
                             b = REQUE.RC_CCODMON,
                             j = REQUE.RC_NIMPMN,
                             k = REQUE.RC_NIMPUS,

                         }).ToList().
                   Select(c => new AL0003REQC()
                   {
                       RC_CNROREQ = c.a,
                       RC_NIMPMN = (c.b.Trim() == "MN" ? c.j : c.k),
                   }).ToList();
            }
            return codID;
        }
        public static List<VISTA_REQRETRASO> RPTRETRASOS()

        {
            var Listarep = new List<VISTA_REQRETRASO>();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where
(REQUE.RC_CESTADO == "7") &&
REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {

                                cinco = ((from AL0003REQC in
                                            (from AL0003REQC in ctx.AL0003REQC
                                             where
                                            AL0003REQC.RC_CESTADO == "7" &&
                                            (AL0003REQC.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -5)) &&
                                             AL0003REQC.RC_DFECA03 != null &&
                                             AL0003REQC.RC_CNUMORD == ""
                                             select new
                                             {
                                                 Dummy = "x"
                                             })
                                          group AL0003REQC by new { AL0003REQC.Dummy } into g
                                          select new
                                          {
                                              Column1 = g.Count()
                                          }).FirstOrDefault().Column1),



                                cinconueve = ((from AL0003REQC in
                                     (from AL0003REQC in ctx.AL0003REQC
                                      where
                                     AL0003REQC.RC_CESTADO == "7" &&
                                    ((AL0003REQC.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -5))
                                    && (AL0003REQC.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -10)) &&
                                   AL0003REQC.RC_DFECA03 != null &&
                                             AL0003REQC.RC_CNUMORD == ""
                                    )
                                      select new
                                      {
                                          Dummy = "x"
                                      })
                                               group AL0003REQC by new { AL0003REQC.Dummy } into g
                                               select new
                                               {
                                                   Column1 = g.Count()
                                               }).FirstOrDefault().Column1),

                                diezquince =
                                ((from AL0003REQC in
                                   (from AL0003REQC in ctx.AL0003REQC
                                    where
                                   AL0003REQC.RC_CESTADO == "7" &&
                                    ((AL0003REQC.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -10))
                                    && (AL0003REQC.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -16))) &&
                                    AL0003REQC.RC_DFECA03 != null &&
                                             AL0003REQC.RC_CNUMORD == ""
                                    select new
                                    {
                                        Dummy = "x"
                                    })
                                  group AL0003REQC by new { AL0003REQC.Dummy } into g
                                  select new
                                  {
                                      Column1 = g.Count()
                                  }).FirstOrDefault().Column1),

                                masquince =
                                ((from AL0003REQC in
                 (from AL0003REQC in ctx.AL0003REQC
                  where
                 AL0003REQC.RC_CESTADO == "7" &&
               (AL0003REQC.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -16))
               &&
                 AL0003REQC.RC_DFECA03 != null && AL0003REQC.RC_CNUMORD == ""

                  select new
                  {
                      Dummy = "x"
                  })
                                  group AL0003REQC by new { AL0003REQC.Dummy } into g
                                  select new
                                  {
                                      Column1 = g.Count()
                                  }).FirstOrDefault().Column1),

                                total =
                                ((from AL0003REQC in
                 (from AL0003REQC in ctx.AL0003REQC
                  where
                 AL0003REQC.RC_CESTADO == "7" &&
                 AL0003REQC.RC_DFECA03 != null &&
                                             AL0003REQC.RC_CNUMORD == ""

                  select new
                  {
                      Dummy = "x"
                  })
                                  group AL0003REQC by new { AL0003REQC.Dummy } into g
                                  select new
                                  {
                                      Column1 = g.Count()
                                  }).FirstOrDefault().Column1),


                            }).Distinct().ToList().
                 Select(c => new VISTA_REQRETRASO()

                 {

                     CINCO = Convert.ToInt32(c.cinco),
                     CINCONUEVE = Convert.ToInt32(c.cinconueve),
                     DIEZQUINCE = Convert.ToInt32(c.diezquince),
                     QUINCEMAS = Convert.ToInt16(c.masquince),
                     TOTALREQ = Convert.ToInt16(c.total),

                 }).ToList();

            }
            return Listarep;
        }


        public static List<VISTA_REQUERIMIENTOS> RPTRETRASOS5()

        {
            var Listarep = new List<VISTA_REQUERIMIENTOS>();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where (REQUE.RC_CESTADO == "7")
                            && (REQUE.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -5)) &&
                            REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {
                                a = REQUE.RC_CNROREQ,
                                b = REQUE.RC_DFECREQ,
                                c = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                d = REQUE.RC_CESTADO,
                                e = REQUE.RC_CTIPAPR,
                                f = REQUE.RC_CNUMORD,
                                g = REQUE.RC_CCODSOLI,
                                h = REQUE.RC_CUSEA01,
                                i = REQUE.RC_CUSEA02,
                                j = REQUE.RC_CUSEA03,
                                k = REQUE.RC_DFECA03,
                                l = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                            }).ToList().
                 Select(c => new VISTA_REQUERIMIENTOS()

                 {
                     RC_CNROREQ = c.a,
                     RC_DFECREQ = Convert.ToString(c.b),
                     RC_CESTADO = c.d,
                     RC_CNUMORD = c.f,
                     RC_CCODSOLI = c.c,
                     RC_CUSEA01 = c.h,
                     RC_CUSEA02 = c.i,
                     RC_CUSEA03 = c.j,
                     RC_DFECA03 = Convert.ToString(c.k),
                     RC_CCENCOS = c.l,


                 }).ToList();

            }
            return Listarep;
        }


        public static List<VISTA_REQUERIMIENTOS> RPTRETRASOS59()

        {
            var Listarep = new List<VISTA_REQUERIMIENTOS>();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where (REQUE.RC_CESTADO == "7")
                            && (REQUE.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -5))
                            && (REQUE.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -10)) &&
                                   REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {
                                a = REQUE.RC_CNROREQ,
                                b = REQUE.RC_DFECREQ,
                                c = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                d = REQUE.RC_CESTADO,
                                e = REQUE.RC_CTIPAPR,
                                f = REQUE.RC_CNUMORD,
                                g = REQUE.RC_CCODSOLI,
                                h = REQUE.RC_CUSEA01,
                                i = REQUE.RC_CUSEA02,
                                j = REQUE.RC_CUSEA03,
                                k = REQUE.RC_DFECA03,
                                l = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                            }).ToList().
                 Select(c => new VISTA_REQUERIMIENTOS()

                 {
                     RC_CNROREQ = c.a,
                     RC_DFECREQ = Convert.ToString(c.b),
                     RC_CESTADO = c.d,
                     RC_CNUMORD = c.f,
                     RC_CCODSOLI = c.c,
                     RC_CUSEA01 = c.h,
                     RC_CUSEA02 = c.i,
                     RC_CUSEA03 = c.j,
                     RC_DFECA03 = Convert.ToString(c.k),
                     RC_CCENCOS = c.l,


                 }).ToList();

            }
            return Listarep;
        }

        public static List<VISTA_REQUERIMIENTOS> RPTRETRASOS1015()

        {
            var Listarep = new List<VISTA_REQUERIMIENTOS>();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where (REQUE.RC_CESTADO == "7")
                            && (REQUE.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -10))
                            && (REQUE.RC_DFECA03 >= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -16)) &&
                                   REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {
                                a = REQUE.RC_CNROREQ,
                                b = REQUE.RC_DFECREQ,
                                c = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                d = REQUE.RC_CESTADO,
                                e = REQUE.RC_CTIPAPR,
                                f = REQUE.RC_CNUMORD,
                                g = REQUE.RC_CCODSOLI,
                                h = REQUE.RC_CUSEA01,
                                i = REQUE.RC_CUSEA02,
                                j = REQUE.RC_CUSEA03,
                                k = REQUE.RC_DFECA03,
                                l = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                            }).ToList().
                 Select(c => new VISTA_REQUERIMIENTOS()

                 {
                     RC_CNROREQ = c.a,
                     RC_DFECREQ = Convert.ToString(c.b),
                     RC_CESTADO = c.d,
                     RC_CNUMORD = c.f,
                     RC_CCODSOLI = c.c,
                     RC_CUSEA01 = c.h,
                     RC_CUSEA02 = c.i,
                     RC_CUSEA03 = c.j,
                     RC_DFECA03 = Convert.ToString(c.k),
                     RC_CCENCOS = c.l,


                 }).ToList();

            }
            return Listarep;
        }


        public static List<VISTA_REQUERIMIENTOS> RPTRETRASOSMAS15()

        {
            var Listarep = new List<VISTA_REQUERIMIENTOS>();
            var cty = new RSCONCAR();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where (REQUE.RC_CESTADO == "7")
                           &&
                           (REQUE.RC_DFECA03 <= System.Data.Entity.DbFunctions.AddDays(DateTime.Now, -16)) &&
                                   REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {
                                a = REQUE.RC_CNROREQ,
                                b = REQUE.RC_DFECREQ,
                                c = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                d = REQUE.RC_CESTADO,
                                e = REQUE.RC_CTIPAPR,
                                f = REQUE.RC_CNUMORD,
                                g = REQUE.RC_CCODSOLI,
                                h = REQUE.RC_CUSEA01,
                                i = REQUE.RC_CUSEA02,
                                j = REQUE.RC_CUSEA03,
                                k = REQUE.RC_DFECA03,
                                l = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                            }).ToList().
                 Select(c => new VISTA_REQUERIMIENTOS()

                 {
                     RC_CNROREQ = c.a,
                     RC_DFECREQ = Convert.ToString(c.b),
                     RC_CESTADO = c.d,
                     RC_CNUMORD = c.f,
                     RC_CCODSOLI = c.c,
                     RC_CUSEA01 = c.h,
                     RC_CUSEA02 = c.i,
                     RC_CUSEA03 = c.j,
                     RC_DFECA03 = Convert.ToString(c.k),
                     RC_CCENCOS = c.l,


                 }).ToList();

            }
            return Listarep;
        }


        public static List<VISTA_REQUERIMIENTOS> RPTRETRASOSTODOS()

        {
            var Listarep = new List<VISTA_REQUERIMIENTOS>();

            using (var ctx = new RSFACAR())
            {

                Listarep = (from REQUE in ctx.AL0003REQC
                            where (REQUE.RC_CESTADO == "7") &&
                            REQUE.RC_DFECA03 != null && REQUE.RC_CNUMORD == ""
                            select new
                            {
                                a = REQUE.RC_CNROREQ,
                                b = REQUE.RC_DFECREQ,
                                c = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                d = REQUE.RC_CESTADO,
                                e = REQUE.RC_CTIPAPR,
                                f = REQUE.RC_CNUMORD,
                                g = REQUE.RC_CCODSOLI,
                                h = REQUE.RC_CUSEA01,
                                i = REQUE.RC_CUSEA02,
                                j = REQUE.RC_CUSEA03,
                                k = REQUE.RC_DFECA03,
                                l = ((from b in ctx.AL0003TABL
                                      where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                      select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                            }).ToList().
                 Select(c => new VISTA_REQUERIMIENTOS()

                 {
                     RC_CNROREQ = c.a,
                     RC_DFECREQ = Convert.ToString(c.b),
                     RC_CESTADO = c.d,
                     RC_CNUMORD = c.f,
                     RC_CCODSOLI = c.c,
                     RC_CUSEA01 = c.h,
                     RC_CUSEA02 = c.i,
                     RC_CUSEA03 = c.j,
                     RC_DFECA03 = Convert.ToString(c.k),
                     RC_CCENCOS = c.l,


                 }).ToList();

            }
            return Listarep;
        }

        public static List<vista_impresion_requerimiento> ImpresionReq(AL0003REQC tab)

        {
            var Listarep = new List<vista_impresion_requerimiento>();

            using (var ctx = new RSFACAR())
            {
                Listarep = (from REQUE in ctx.AL0003REQC
                            join REQD in ctx.AL0003REQD on new
                            { RC_CNROREQ = REQUE.RC_CNROREQ } equals new { RC_CNROREQ = REQD.RD_CNROREQ }
                            where REQUE.RC_CNROREQ == tab.RC_CNROREQ
                            select new
                            {
                                numero = REQUE.RC_CNROREQ,
                                fecha = REQUE.RC_DFECREQ,
                                solicitante = ((from b in ctx.AL0003TABL
                                                where b.TG_CCLAVE.Trim() == REQUE.RC_CCODSOLI && b.TG_CCOD == "12"
                                                select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                                centrocosto = ((from b in ctx.AL0003TABL
                                                where b.TG_CCLAVE.Trim() == REQUE.RC_CCENCOS && b.TG_CCOD == "10"
                                                select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                proveedor = REQUE.RC_CPRVSUG,
                                obs1 = REQUE.RC_CGLOSA1,
                                obs2 = REQUE.RC_CGLOSA2,
                                cotizacion = REQUE.RC_CNUMCOT,
                                dias = REQUE.RC_CAGEOT,

                                area = ((from b in ctx.AL0003TABL
                                         where
                                           b.TG_CCOD == "74" && b.TG_CCLAVE == REQUE.RC_CCODAREA
                                         select new
                                         {
                                             b.TG_CDESCRI
                                         }).FirstOrDefault().TG_CDESCRI),
                                tipoarea = ((from b in ctx.AL0003TABL
                                             where
                                               b.TG_CCOD == "R3" && b.TG_CCLAVE == REQUE.RC_CAREARQ
                                             select new
                                             {
                                                 b.TG_CDESCRI
                                             }).FirstOrDefault().TG_CDESCRI),

                                USO = ((from b in ctx.AL0003TABL
                                        where
                                          b.TG_CCOD == "R1" && b.TG_CCLAVE == REQUE.RC_CORIREQ
                                        select new
                                        {
                                            b.TG_CDESCRI
                                        }).FirstOrDefault().TG_CDESCRI),
                                PRIORIDAD = ((from b in ctx.AL0003TABL
                                              where
                                                b.TG_CCOD == "R2" && b.TG_CCLAVE == REQUE.RC_CTIPREQ
                                              select new
                                              {
                                                  b.TG_CDESCRI
                                              }).FirstOrDefault().TG_CDESCRI),



                                // PARA DETALLE 
                                RD_CITEM = REQD.RD_CITEM,
                                RD_CCODIGO = REQD.RD_CCODIGO,
                                RD_CDESCRI = REQD.RD_CDESCRI,
                                RD_CUNID = REQD.RD_CUNID,
                                RD_NQPEDI = REQD.RD_NQPEDI,
                                RD_COBS = REQD.RD_COBS,
                                COSTO = REQD.RD_CCENCOS,
                                DESCRIPCOSTO = ((from b in ctx.AL0003TABL
                                                 where
                                                   b.TG_CCOD == "10" && b.TG_CCLAVE == REQD.RD_CCENCOS
                                                 select new
                                                 {
                                                     b.TG_CDESCRI
                                                 }).FirstOrDefault().TG_CDESCRI),
                                SOLICITANTE = ((from b in ctx.AL0003TABL
                                                where
                                                  b.TG_CCOD == "12" && b.TG_CCLAVE == REQD.RD_CUSRCOM
                                                select new
                                                {
                                                    b.TG_CDESCRI
                                                }).FirstOrDefault().TG_CDESCRI),
                                codsolicitante = REQD.RD_CUSRCOM,

                                //AGREGADOS TRABAJO CURSO CABECERA
                                trabajo = REQUE.RC_CNUMOT,
                                moneda = REQUE.RC_CCODMON,
                                //AGREGADOS TRABAJO CURSO DETALLE
                                soles = REQD.RD_NPRU2MN,
                                dolares = REQD.RD_NPRU2US,
                                USU1 = ((from b in ctx.UT0030
                                         where b.TU_ALIAS.Trim() == REQUE.RC_CUSEA01
                                         select new { b.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),
                                USU2 = ((from b in ctx.UT0030
                                         where b.TU_ALIAS.Trim() == REQUE.RC_CUSEA02
                                         select new { b.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),
                                USU3 = ((from b in ctx.UT0030
                                         where b.TU_ALIAS.Trim() == REQUE.RC_CUSEA03
                                         select new { b.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),

                            }).ToList().
                  Select(c => new vista_impresion_requerimiento()
                  {
                      RC_CNROREQ = c.numero == null ? string.Empty : c.numero,
                      RC_DFECREQ = String.Format("{0:dd/MM/yyyy}", c.fecha) == null ? "01/01/1990" : String.Format("{0:dd/MM/yyyy}", c.fecha),
                      RC_CCODSOLI = c.SOLICITANTE == null ? string.Empty : c.SOLICITANTE,
                      RC_CCENCOS = c.centrocosto == null ? string.Empty : c.centrocosto,
                      RC_CPRVSUG = CT0003ANEX.obtenProveedor(c.proveedor.Trim()).ADESANE.ToString() == null ? string.Empty : CT0003ANEX.obtenProveedor(c.proveedor.Trim()).ADESANE.ToString(),
                      RC_CGLOSA1 = c.obs1 == null ? string.Empty : c.obs1,
                      RC_CGLOSA2 = c.obs2 == null ? string.Empty : c.obs2,
                      RC_CNUMCOT = c.cotizacion == null ? string.Empty : c.cotizacion,
                      RC_CAGEOT = c.dias == null ? string.Empty : c.dias,
                      RC_CCODAREA = c.area == null ? string.Empty : c.area,
                      RC_CAREARQ = c.tipoarea == null ? string.Empty : c.tipoarea,
                      RC_CORIREQ = c.USO == null ? string.Empty : c.USO,
                      RC_CTIPREQ = c.PRIORIDAD == null ? string.Empty : c.PRIORIDAD,
                      // DETALLE
                      RD_CITEM = c.RD_CITEM == null ? string.Empty : c.RD_CITEM,
                      RD_CCODIGO = c.RD_CCODIGO == null ? string.Empty : c.RD_CCODIGO,
                      RD_CDESCRI = c.RD_CDESCRI == null ? string.Empty : c.RD_CDESCRI,
                      RD_CUNID = c.RD_CUNID == null ? string.Empty : c.RD_CUNID,
                      RD_NQPEDI = Convert.ToDecimal(c.RD_NQPEDI),
                      RD_COBS = c.RD_COBS == null ? string.Empty : c.RD_COBS,
                      RD_CCENCOS = c.DESCRIPCOSTO == null ? string.Empty : c.DESCRIPCOSTO,
                      RD_CUSRCOM = c.SOLICITANTE == null ? string.Empty : c.SOLICITANTE,
                      TRABAJO = AL0003REQC.obtentrabajo(c.trabajo).TR_CODIGO,
                      MONEDA = (AL0003REQC.obtentrabajo(c.trabajo).COD_MON == "SIN TRABAJO" ? c.moneda.Trim() == "" ? "MN" : c.moneda : AL0003REQC.obtentrabajo(c.trabajo).COD_MON),
                      TIPO_CAMBIO = Convert.ToDecimal(AL0003REQC.obtentrabajo(c.trabajo).TIPO_CAMBIO),
                      PRESUPUESTO = Convert.ToDecimal(AL0003REQC.obtentrabajo(c.trabajo).PRESUPUESTO),
                      MONTODETALLESOLES = c.soles,
                      MONTODETALLEDOLARES = c.dolares,
                      USU1 = c.USU1,
                      USU2 = c.USU2,
                      USU3 = c.USU3

                  }).ToList();

            }
            return Listarep;
        }

        public static tabla_trabajo obtentrabajo(string texto)
        {
            var alumnos = new tabla_trabajo();


            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = ctx.tabla_trabajo.Where(x => x.TR_CODIGO.Trim() == texto.Trim()).FirstOrDefault();

                    if (alumnos == null)
                    {

                        tabla_trabajo alumnos1 = new tabla_trabajo()
                        {
                            TR_CODIGO = "SIN TRABAJO",
                            COD_MON = "SIN TRABAJO",
                            TIPO_CAMBIO = 0,
                            PRESUPUESTO = 0,

                        };
                        alumnos = alumnos1;
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;

        }


    }
}
