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

        public decimal ? saldo { get; set; }

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
        public decimal RC_NIMPMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal RC_NIMPUS { get; set; }

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
        public static List<vista_reporteRequerimeintoPorFechas>  reporteRequerimeintoPorFechas(DateTime fecha1, DateTime fecha2,int band)
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


        public static Boolean apruebaRequerimientoAtendido(string RC_CNROREQ,string RC_CESTADO)
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

            if (alumno.RC_CUSEA01 == string.Empty && alumno.RC_CUSEA02 == string.Empty && alumno.RC_CUSEA03 == string.Empty)
            {
                user1 = alumno.RC_CUSUCRE;
                fecha1 = DateTime.Now.ToString("dd/MM/yyyy");
            }
            if (alumno.RC_CUSEA01 != string.Empty && alumno.RC_CUSEA02 == string.Empty && alumno.RC_CUSEA03 == string.Empty)
            {
                user1 = alumno.RC_CUSEA01;
                user2 = alumno.RC_CUSUCRE;
                fecha2 = DateTime.Now.ToString("dd/MM/yyyy");
            }
            if (alumno.RC_CUSEA01 != string.Empty && alumno.RC_CUSEA02 != string.Empty && alumno.RC_CUSEA03 == string.Empty)
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



        public static List<vista_requerimientoParaOCProductos1> listarqcontraoc(string [] req, string[] req1)
        {
            var alumnos1 = new List<vista_requerimientoParaOCProductos>();
            var alumnos2 = new List<vista_requerimientoParaOCProductosCab>();
            var alumnos3 = new List<vista_requerimientoParaOCProductos1>();
            using (var ctx = new RSFACAR())
            {
                alumnos1 = (from a in ctx.CO0003MOVC
                           join b in ctx.CO0003MOVD on a.OC_CNUMORD equals b.OC_CNUMORD
                          
                                where
                                (req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2>0
                            orderby
                             b.OC_CCODIGO,
                             a.OC_CRAZSOC
                           select new
                           {
                            a=   a.OC_DFECDOC,
                            b=   a.OC_CCODPRO,
                            c=   a.OC_CRAZSOC,
                            d=   b.OC_CCODIGO,
                            e=   b.OC_NPREUN2,
                            f=   a.OC_CCODMON

                           }
                                              ).ToList()
                                                 .Select(c => new vista_requerimientoParaOCProductos()
                                                 {
                                                     OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.a),
                                                     OC_CCODPRO =c.b,
                                                     OC_CRAZSOC = c.c,
                                                     OC_CCODIGO = c.d,
                                                     OC_NPREUN2=Convert.ToDouble (c.e),
                                                     pk= String.Format("{0:yyyyMMdd}", c.a)+ (c.b.Trim())+(c.d.Trim()),
                                                     OC_CCODMON= c.f

                                                 }).ToList();
                alumnos2 = (
                    from a in ctx.CO0003MOVC
                    join b in ctx.CO0003MOVD on a.OC_CNUMORD equals b.OC_CNUMORD
                    where  (req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2 > 0
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
                        b=g.Key.OC_CCODPRO,
                        c=g.Key.OC_CCODIGO
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
                                c =  x.OC_DFECDOC,
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
                           OC_CRAZSOC=c.e ,
                           ARTICULO=c.f,
                           OC_CCODMON=c.g

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
                           c.RC_CNROREQ.Trim()== rec.RC_CNROREQ.Trim()
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
                                              join b in ctx.AL0003REQD on c.RC_CNROREQ equals  b.RD_CNROREQ 
                                              where c.RC_CESTADO =="7" && (c.RC_DFECREQ >= rec.RC_DFECA01  && c.RC_DFECREQ <=rec.RC_DFECA02)
                                             && ((rec.RC_CCODSOLI == "-1") ? b.RD_CUSRCOM != rec.RC_CCODSOLI : b.RD_CUSRCOM == rec.RC_CCODSOLI)
                                             && b.RD_CSITUA=="7"
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
                                                  f= b.RD_CDESCRI,
                                                  g= b.RD_NQPEDI,
                                                  h  = ((from x in ctx.AL0003TABL
                                                            where
                                                              x.TG_CCOD == "10" && x.TG_CCLAVE ==b.RD_CCENCOS
                                                            select new
                                                            {
                                                                x.TG_CDESCRI

                                                            }).FirstOrDefault().TG_CDESCRI),
                                                   i=b.RD_CCENCOS
                            }).ToList()
                                                .Select(c => new vista_requerimientoParaOC()
                                                {
                                                    RC_CNROREQ =c.a.Trim(),
                                                    RC_DFECREQ=String.Format("{0:dd/MM/yyyy}", c.b), 
                                                    RC_CCODSOLI =c.c.Trim(),
                                                    TG_CDESCRI =c.d.Trim(),
                                                    RD_CCODIGO=c.e.Trim(),
                                                    RD_CDESCRI=c.f.Trim(),
                                                    RD_NQPEDI=c.g,
                                                    CCOSTO=c.h.Trim(),
                                                    RD_CCENCOS=c.i.Trim()


                                                }).ToList();
            }

            return alumnos;
        }


        public static List<VISTA_REQUERIMIENTOS> ListarRequerimientos(VISTA_REQUERIMIENTOS REQ)
        {
            var alumnos = new List<VISTA_REQUERIMIENTOS>();
            using (var ctx = new RSFACAR())
            {
                var query = ctx.AL0003REQD.Join(ctx.VISTA_REQUERIMIENTOS,c => c.RD_CNROREQ,cm => cm.RC_CNROREQ,  (c, cm) => new { AL0003REQD = c, VISTA_REQUERIMIENTOS = cm }).Where(c=>c.AL0003REQD.RD_CCODIGO== REQ.USUARIO && c.VISTA_REQUERIMIENTOS.ANIO==REQ.ANIO && c.VISTA_REQUERIMIENTOS.MES==REQ.MES)
                            .Select(x => x.VISTA_REQUERIMIENTOS.RC_CNROREQ).ToArray();

               // if (REQ.USUARIO != null)
                //{

                    if (query.Length>0 )
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => query.Contains(x.RC_CNROREQ)).ToList();
                  //  return alumnos;
                //}

                if (REQ.RC_CUSUCRE == "-1" && REQ.RC_CESTADO == "-1" && query.Length==0)
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES ).ToList();


                if (REQ.RC_CUSUCRE!="-1" && REQ.RC_CESTADO == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CUSUCRE ==REQ.RC_CUSUCRE).ToList();

             if (REQ.RC_CESTADO != "-1" && REQ.RC_CUSUCRE == "-1")
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CESTADO == REQ.RC_CESTADO).ToList();

             if ((REQ.RC_CUSUCRE != "-1") && (REQ.RC_CESTADO != "-1"))
                    alumnos = ctx.VISTA_REQUERIMIENTOS.Where(x => x.ANIO == REQ.ANIO && x.MES == REQ.MES && x.RC_CUSUCRE == REQ.RC_CUSUCRE && x.RC_CESTADO == REQ.RC_CESTADO).ToList();

                
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
            DateTime fecha =Convert.ToDateTime ("01/01/1900");
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

    }
}
