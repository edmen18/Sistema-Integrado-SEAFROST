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
    using System.Data.Entity.SqlServer;

    public partial class tabla_anticipo
    {
        [Key]
        [StringLength(10)]
        public string ANT_CODIGO { get; set; }

        [StringLength(20)]
        public string OC_CNUMORD { get; set; }

        [Required]
        [StringLength(18)]
        public string OC_CCODPRO { get; set; }

        [Required]
        [StringLength(80)]
        public string OC_CRAZSOC { get; set; }

        public DateTime? OC_FECEMI { get; set; }

        public DateTime? OC_FECPRO { get; set; }

        [StringLength(12)]
        public string OC_CODMON { get; set; }

        public decimal? OC_MONTO_PEDIDO { get; set; }

        public decimal? OC_PERCENTAJE { get; set; }

        public decimal? OC_ANTICIPO { get; set; }

        public decimal? OC_TOTAL_PAGAR { get; set; }

        [StringLength(500)]
        public string MOTIVO { get; set; }

        [StringLength(30)]
        public string OC_CTAPROVEEDOR { get; set; }

        [StringLength(18)]
        public string OC_BANCO { get; set; }

        [StringLength(500)]
        public string BANCO { get; set; }

        [StringLength(60)]
        public string MONEDA { get; set; }

        public decimal? DET_PORCENTAJE { get; set; }

        public decimal? DETRACCION { get; set; }

        public decimal? RET_PORCENTAJE { get; set; }

        public decimal? RETENCION { get; set; }

        public int? PLAZO_DIAS { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        [StringLength(1)]
        public string APROBADO { get; set; }

        [StringLength(5)]
        public string USER1 { get; set; }

        [StringLength(5)]
        public string USER2 { get; set; }

        [StringLength(5)]
        public string USER3 { get; set; }

        [StringLength(5)]
        public string USER4 { get; set; }

        [StringLength(50)]
        public string OC_CSOLICT { get; set; }
        
        [StringLength(12)]
        public string OC_CCODSOL { get; set; }

        public static List<vista_solicitud> ListarSA(tabla_anticipo CODATA)
        {
            var alumnos = new List<vista_solicitud>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_anticipo.Where(x =>

                               ( CODATA.OC_CCODPRO != string.Empty ? x.OC_CCODPRO == CODATA.OC_CCODPRO : x.OC_CCODPRO != string.Empty)
                               &&
                               (CODATA.ESTADO != "1" ? x.ESTADO == CODATA.ESTADO : x.ESTADO != CODATA.ESTADO)
                               &&
                               (CODATA.APROBADO != "1" ? x.APROBADO == CODATA.APROBADO : x.APROBADO != CODATA.APROBADO)
                                &&
                               (CODATA.OC_CCODSOL != string.Empty ? x.OC_CCODSOL == CODATA.OC_CCODSOL : x.OC_CCODSOL != string.Empty)

                                && ((x.OC_FECEMI >= CODATA.OC_FECEMI) && (x.OC_FECEMI <= CODATA.OC_FECPRO))
                              ).OrderByDescending(x=> new { x.OC_FECEMI, x.ANT_CODIGO })

                               select new
                               {
                                   codigo = a.ANT_CODIGO,
                                   numoc = a.OC_CNUMORD,
                                   ruc = a.OC_CCODPRO,
                                   razonoc = a.OC_CRAZSOC,
                                   fecemi = a.OC_FECEMI,
                                   fecpro = a.OC_FECPRO,
                                   codmon = a.OC_CODMON,
                                   montopedido = a.OC_MONTO_PEDIDO,
                                   porcentaje = a.OC_PERCENTAJE,
                                   anticipo = a.OC_ANTICIPO,
                                   totalpagar = a.OC_TOTAL_PAGAR,
                                   motivo = a.MOTIVO,
                                   ctaprovedor = a.OC_CTAPROVEEDOR,
                                   ctabanco = a.OC_BANCO,
                                   banco = a.BANCO,
                                   moneda = a.MONEDA,
                                   pdetra = a.DET_PORCENTAJE,
                                   detra = a.DETRACCION,
                                   pret = a.RET_PORCENTAJE,
                                   ret = a.RETENCION,
                                   dias = a.PLAZO_DIAS,
                                   estado = a.ESTADO,
                                   user1=a.USER1,
                                   user2=a.USER2,
                                   user3=a.USER3,
                                   user4=a.USER4,
                                   apro=a.APROBADO,
                                   codsol=a.OC_CCODSOL,
                                   solicitante=a.OC_CSOLICT,
                                
                                   


                               }).ToList()
                          .Select(c => new vista_solicitud()
                          {
                              ANT_CODIGO = c.codigo,
                              OC_CNUMORD = c.numoc,
                              OC_CCODPRO = c.ruc,
                              OC_CRAZSOC = c.razonoc,
                              OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.fecemi),
                              OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.fecpro),
                              OC_CODMON = c.codmon,
                              OC_MONTO_PEDIDO = Convert.ToDecimal(c.montopedido),
                              OC_PERCENTAJE = Convert.ToDecimal(c.porcentaje),
                              OC_ANTICIPO = Convert.ToDecimal(c.anticipo),
                              OC_TOTAL_PAGAR = Convert.ToDecimal(c.totalpagar),
                              OC_CTAPROVEEDOR = c.ctaprovedor,
                              MOTIVO = c.motivo,
                              OC_BANCO = c.ctabanco,
                              BANCO = c.banco,
                              MONEDA = c.moneda,
                              DET_PORCENTAJE =Convert.ToDecimal(c.pdetra),
                              DETRACCION = Convert.ToDecimal(c.detra),
                              RET_PORCENTAJE = Convert.ToDecimal(c.pret),
                              RETENCION = Convert.ToDecimal(c.ret),
                              PLAZO_DIAS = Convert.ToInt16(c.dias),
                              ESTADO = c.estado,
                              USER1=c.user1,
                              USER2=c.user2,
                              USER3=c.user3,
                              USER4=c.user4,
                              APROB=c.apro,
                              OC_CCODSOL=c.codsol,
                              OC_CSOLICT=c.solicitante,

                          }).ToList();

                }
                
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }



        public static Boolean insertaSolicitud(tabla_anticipo alumno)
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

        public static Boolean actualizaSolicitud(tabla_anticipo alumno)
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

        public static string GeneraNroSolicitud(string solicitud)
        {
            var codigo = "";
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo =ctx.tabla_anticipo.Select(x =>x.ANT_CODIGO ).Max();
                    codigo =Convert.ToString( Convert.ToInt32(codigo) + 1);
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
         }
        public static string traerordencompra(string solicitud)
        {
            var codigo = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.tabla_anticipo.Where(x => x.ANT_CODIGO == solicitud).Select(x=>x.OC_CNUMORD).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigo;
        }

        public static string traerDetraccion(string orden)
        {
            var codigo = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.tabla_anticipo.Where(x => x.OC_CNUMORD.Trim() == orden.Trim() && x.DET_PORCENTAJE > 0).Select(x => x.OC_CNUMORD).FirstOrDefault();
                    if (codigo==null)
                    {
                        codigo = "";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigo;
        }

        public static List<vista_solicitud> SumarAnticipos(tabla_anticipo CODATA)
        {
            var alumnos = new List<vista_solicitud>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from tabla_anticipo in ctx.tabla_anticipo
                               where tabla_anticipo.OC_CNUMORD == CODATA.OC_CNUMORD
                               group tabla_anticipo by new
                               {
                                   tabla_anticipo.OC_CNUMORD
                               } into g

                               select new
                               {
                                   Column1 = (decimal?)g.Sum(p => p.OC_ANTICIPO)

                               }).ToList()

                           .Select(c => new vista_solicitud()
                           {
                               TOTAL_ANTICIPO = Convert.ToDecimal(c.Column1),

                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<vista_solicitud> SAreporte(tabla_anticipo COM)
        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from a in ctx.tabla_anticipo
                            where a.ANT_CODIGO == COM.ANT_CODIGO
                            select new
                            {
                                data1 = a.OC_CNUMORD,
                                data2 = a.OC_CCODPRO,
                                data3 = a.OC_CRAZSOC,
                                data4 = a.OC_FECEMI,
                                data5 = a.OC_FECPRO,
                                data6 = a.OC_CODMON,
                                data7 = a.OC_MONTO_PEDIDO,
                                data8 = a.OC_PERCENTAJE,
                                data9 = a.OC_ANTICIPO,
                                data10 = a.OC_TOTAL_PAGAR,
                                data11 = a.MOTIVO,
                                data12 = a.OC_CTAPROVEEDOR,
                                data13 = a.OC_BANCO,
                                data14 = a.BANCO,
                                data15 = a.MONEDA,
                                data16 = a.ANT_CODIGO,
                                data17 = a.DET_PORCENTAJE,
                                data18 = a.DETRACCION,
                                data19 = a.RET_PORCENTAJE,
                                data20 = a.RETENCION,
                                data21 = a.PLAZO_DIAS,
                                data22=a.APROBADO,
                                data23=a.USER1,
                                data24=a.USER2,
                                data25=a.USER3,
                                data26=a.USER4,
                                data27=a.OC_CSOLICT,
                            }).ToList().
                  Select(c => new vista_solicitud()
                  {
                      OC_CNUMORD = c.data1,
                      OC_CCODPRO = c.data2,
                      OC_CRAZSOC = c.data3,
                      OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.data4),
                      OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.data5),
                      OC_CODMON = c.data6,
                      OC_MONTO_PEDIDO = Convert.ToDecimal(c.data7),
                      OC_PERCENTAJE = Convert.ToDecimal(c.data8),
                      OC_ANTICIPO = Convert.ToDecimal(c.data9),
                      OC_TOTAL_PAGAR = Convert.ToDecimal(c.data10),
                      MOTIVO = c.data11,
                      OC_CTAPROVEEDOR = c.data12,
                      OC_BANCO = c.data13,
                      BANCO = c.data14,
                      MONEDA = c.data15,
                      ANT_CODIGO = c.data16,
                      DET_PORCENTAJE = Convert.ToDecimal(c.data17),
                      DETRACCION = Convert.ToDecimal(c.data18),
                      RET_PORCENTAJE = Convert.ToDecimal(c.data19),
                      RETENCION = Convert.ToDecimal(c.data20),
                      PLAZO_DIAS = Convert.ToInt16(c.data21),
                      APROB=c.data22,
                      USER1=tabla_usuarios.ObtenUsuario(c.data23).TU_NOMUSU.ToUpper(),
                      USER2= tabla_usuarios.ObtenUsuario(c.data24).TU_NOMUSU.ToUpper(),
                      USER3 = tabla_usuarios.ObtenUsuario(c.data25).TU_NOMUSU.ToUpper(),
                      USER4 = tabla_usuarios.ObtenUsuario(c.data26).TU_NOMUSU.ToUpper(),
                      OC_CSOLICT =c.data27,
                  }).ToList();

            }
            return Listarep;
        }


        public static List<vista_solicitud> SAreportes(tabla_anticipo COM)
        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {

                Listarep = (from a in ctx.tabla_anticipo.Where(x =>
               ((x.OC_CCODPRO == COM.OC_CCODPRO) || (x.OC_CNUMORD == COM.OC_CNUMORD) || (x.ESTADO == COM.ESTADO)
               || (x.OC_CCODSOL == COM.OC_CCODSOL))
               && ((x.OC_FECEMI >= COM.OC_FECEMI) && (x.OC_FECEMI <= COM.OC_FECPRO))
                )
                            select new
                            {
                                data1 = a.OC_CNUMORD,
                                data2 = a.OC_CCODPRO,
                                data3 = a.OC_CRAZSOC,
                                data4 = a.OC_FECEMI,
                                data5 = a.OC_FECPRO,
                                data6 = a.OC_CODMON,
                                data7 = a.OC_MONTO_PEDIDO,
                                data8 = a.OC_PERCENTAJE,
                                data9 = a.OC_ANTICIPO,
                                data10 = a.OC_TOTAL_PAGAR,
                                data11 = a.MOTIVO,
                                data12 = a.OC_CTAPROVEEDOR,
                                data13 = a.OC_BANCO,
                                data14 = a.BANCO,
                                data15 = a.OC_CODMON,
                                data16 = a.ANT_CODIGO,
                                data17 = a.DET_PORCENTAJE,
                                data18 = a.DETRACCION,
                                data19 = a.RET_PORCENTAJE,
                                data20 = a.RETENCION,
                                data21 = a.PLAZO_DIAS,
                                data22 = a.ESTADO,
                                data23= a.APROBADO,
                                data24=a.OC_CSOLICT

                            }).ToList().
                 Select(c => new vista_solicitud()
                 {
                     OC_CNUMORD = c.data1,
                     OC_CCODPRO = c.data2,
                     OC_CRAZSOC = c.data3,
                     OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.data4),
                     OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.data5),
                     OC_CODMON = c.data6,
                     OC_MONTO_PEDIDO = Convert.ToDecimal(c.data7),
                     OC_PERCENTAJE = Convert.ToDecimal(c.data8),
                     OC_ANTICIPO = Convert.ToDecimal(c.data9),
                     OC_TOTAL_PAGAR = Convert.ToDecimal(c.data10),
                     MOTIVO = c.data11,
                     OC_CTAPROVEEDOR = c.data12,
                     OC_BANCO = c.data13,
                     BANCO = c.data14,
                     MONEDA = c.data15,
                     ANT_CODIGO = c.data16,
                     DET_PORCENTAJE = Convert.ToDecimal(c.data17),
                     DETRACCION = Convert.ToDecimal(c.data18),
                     RET_PORCENTAJE = Convert.ToDecimal(c.data19),
                     RETENCION = Convert.ToDecimal(c.data20),
                     PLAZO_DIAS = Convert.ToInt16(c.data21),
                     ESTADO = c.data22,
                     APROB=c.data23,
                     OC_CSOLICT=c.data24
                 }).ToList();

            }
            return Listarep;
        }

        public static List<vista_solicitud> SAreportesFechas(tabla_anticipo COM)

        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {

                Listarep = (from a in ctx.tabla_anticipo.Where(x => (x.OC_FECEMI >= COM.OC_FECEMI) && (x.OC_FECEMI <= COM.OC_FECPRO)
                )
                            select new
                            {
                                data1 = a.OC_CNUMORD,
                                data2 = a.OC_CCODPRO,
                                data3 = a.OC_CRAZSOC,
                                data4 = a.OC_FECEMI,
                                data5 = a.OC_FECPRO,
                                data6 = a.OC_CODMON,
                                data7 = a.OC_MONTO_PEDIDO,
                                data8 = a.OC_PERCENTAJE,
                                data9 = a.OC_ANTICIPO,
                                data10 = a.OC_TOTAL_PAGAR,
                                data11 = a.MOTIVO,
                                data12 = a.OC_CTAPROVEEDOR,
                                data13 = a.OC_BANCO,
                                data14 = a.BANCO,
                                data15 = a.OC_CODMON,
                                data16 = a.ANT_CODIGO,
                                data17 = a.DET_PORCENTAJE,
                                data18 = a.DETRACCION,
                                data19 = a.RET_PORCENTAJE,
                                data20 = a.RETENCION,
                                data21 = a.PLAZO_DIAS,
                                data22 = a.ESTADO,
                                data23= a.APROBADO,
                                data24= a.OC_CSOLICT,
                                data25= a.OC_CCODSOL,

                            }).ToList().
                 Select(c => new vista_solicitud()
                 {
                     OC_CNUMORD = c.data1,
                     OC_CCODPRO = c.data2,
                     OC_CRAZSOC = c.data3,
                     OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.data4),
                     OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.data5),
                     OC_CODMON = c.data6,
                     OC_MONTO_PEDIDO = Convert.ToDecimal(c.data7),
                     OC_PERCENTAJE = Convert.ToDecimal(c.data8),
                     OC_ANTICIPO = Convert.ToDecimal(c.data9),
                     OC_TOTAL_PAGAR = Convert.ToDecimal(c.data10),
                     MOTIVO = c.data11,
                     OC_CTAPROVEEDOR = c.data12,
                     OC_BANCO = c.data13,
                     BANCO = c.data14,
                     MONEDA = c.data15,
                     ANT_CODIGO = c.data16,
                     DET_PORCENTAJE = Convert.ToDecimal(c.data17),
                     DETRACCION = Convert.ToDecimal(c.data18),
                     RET_PORCENTAJE = Convert.ToDecimal(c.data19),
                     RETENCION = Convert.ToDecimal(c.data20),
                     PLAZO_DIAS = Convert.ToInt16(c.data21),
                     ESTADO = c.data22,
                     APROB=c.data23,
                     OC_CSOLICT=c.data24,
                     OC_CCODSOL=c.data25,
                 }).ToList();

            }
            return Listarep;
        }

        public static void ActualizarEstado(tabla_anticipo COM)
        {
            var solicitud = new tabla_anticipo { ANT_CODIGO = COM.ANT_CODIGO };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_anticipo.Attach(solicitud);
                solicitud.ESTADO = COM.ESTADO;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }


        }

        ///////obtener los proveedores
        public static List<vista_solicitud> proveedores()

        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from Tabla_anticipo in ctx.tabla_anticipo
                            select new
                            {
                                data1 = Tabla_anticipo.OC_CCODPRO,
                                data2 = Tabla_anticipo.OC_CRAZSOC,

                            }).Distinct().
                  Select(c => new vista_solicitud()
                  {
                      OC_CRAZSOC = c.data2,
                      OC_CCODPRO = c.data1,
                  }).ToList();
                
            }
            return Listarep;
        }
        // OBTENER LOS SOLICITANTES

        public static List<vista_solicitud> solicitantes()

        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from Tabla_anticipo in ctx.tabla_anticipo
                            select new
                            {
                                data1 = Tabla_anticipo.OC_CCODSOL,
                                data2 = Tabla_anticipo.OC_CSOLICT,

                            }).Distinct().
                  Select(c => new vista_solicitud()
                  {
                      OC_CSOLICT = c.data2,
                      OC_CCODSOL = c.data1,
                  }).ToList();

            }
            return Listarep;
        }

        public static List<vista_solicitud> estados()

        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from Tabla_anticipo in ctx.tabla_anticipo
                            select new
                            {
                                data1 = Tabla_anticipo.ESTADO,

                            }).Distinct().
                  Select(c => new vista_solicitud()
                  {
                      ESTADO = c.data1,
                  }).ToList();

            }
            return Listarep;
        }
        public static List<vista_solicitud> ordenes()

        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from Tabla_anticipo in ctx.tabla_anticipo
                            select new
                            {
                                data1 = Tabla_anticipo.OC_CNUMORD,

                            }).Distinct().
                  Select(c => new vista_solicitud()
                  {
                      OC_CNUMORD = c.data1,
                  }).ToList();

            }
            return Listarep;
        }

        public static void AprobarSol(tabla_anticipo COM)
        {
            var SOLICITUD = new tabla_anticipo { ANT_CODIGO = COM.ANT_CODIGO };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_anticipo.Attach(SOLICITUD);
                // orden.OC_CSITORD = COM.OC_CSITORD;
                SOLICITUD.USER1 = COM.USER1;
                SOLICITUD.USER2 = COM.USER2;
                SOLICITUD.USER3 = COM.USER3;
                SOLICITUD.USER4 = COM.USER4;

                if (COM.USER1 != "     " && COM.USER2 == "     " && COM.USER3 == "     " && COM.USER4 == "     ")
                {
                   // SOLICITUD.OC_DFECR01 = DateTime.Now.Date;
                }
                if (COM.USER1 != "     " && COM.USER2 != "     " && COM.USER3 == "     " && COM.USER4 == "     ")
                {
                   // SOLICITUD.OC_DFECR02 = DateTime.Now.Date;
                }
                if (COM.USER1 != "     " && COM.USER2 != "     " && COM.USER3 != "     " && COM.USER4 == "     ")
                {
                    // SOLICITUD.OC_DFECR02 = DateTime.Now.Date;
                }

                if (COM.USER1 != "     " && COM.USER2 != "     " && COM.USER3 != "     " && COM.USER4 != "     " && COM.APROBADO == "A")
                {
                    SOLICITUD.APROBADO = COM.APROBADO;
                  
                }

                if (COM.USER1 != "     " && COM.USER2 != "     " && COM.USER3 != "     " && COM.USER4 != "     "  && COM.APROBADO == "E")
                {
                    SOLICITUD.APROBADO = COM.APROBADO;
                    SOLICITUD.USER1 = "     ";
                    SOLICITUD.USER2 = "     ";
                    SOLICITUD.USER3 = "     ";
                    SOLICITUD.USER4 = "     ";
                }

                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static List<vista_solicitud>traerdatos(tabla_anticipo COM)
        {
            var Listarep = new List<vista_solicitud>();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Listarep = (from a in ctx.tabla_anticipo
                            where a.ANT_CODIGO == COM.ANT_CODIGO
                            select new
                            {
                                data1 = a.OC_CNUMORD,
                                data2 = a.OC_CCODPRO,
                                data3 = a.OC_CRAZSOC,
                                data4 = a.OC_FECEMI,
                                data5 = a.OC_FECPRO,
                                data6 = a.OC_CODMON,
                                data7 = a.OC_MONTO_PEDIDO,
                                data8 = a.OC_PERCENTAJE,
                                data9 = a.OC_ANTICIPO,
                                data10 = a.OC_TOTAL_PAGAR,
                                data11 = a.MOTIVO,
                                data12 = a.OC_CTAPROVEEDOR,
                                data13 = a.OC_BANCO,
                                data14 = a.BANCO,
                                data15 = a.MONEDA,
                                data16 = a.ANT_CODIGO,
                                data17 = a.DET_PORCENTAJE,
                                data18 = a.DETRACCION,
                                data19 = a.RET_PORCENTAJE,
                                data20 = a.RETENCION,
                                data21 = a.PLAZO_DIAS,
                                data22 = a.APROBADO,
                                data23 = a.USER1,
                                data24 = a.USER2,
                                data25 = a.USER3,
                                data26 = a.USER4,
                                data27 = a.OC_CSOLICT,
                            }).ToList().
                  Select(c => new vista_solicitud()
                  {
                      OC_CNUMORD = c.data1,
                      OC_CCODPRO = c.data2,
                      OC_CRAZSOC = c.data3,
                      OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.data4),
                      OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.data5),
                      OC_CODMON = c.data6,
                      OC_MONTO_PEDIDO = Convert.ToDecimal(c.data7),
                      OC_PERCENTAJE = Convert.ToDecimal(c.data8),
                      OC_ANTICIPO = Convert.ToDecimal(c.data9),
                      OC_TOTAL_PAGAR = Convert.ToDecimal(c.data10),
                      MOTIVO = c.data11,
                      OC_CTAPROVEEDOR = c.data12,
                      OC_BANCO = c.data13,
                      BANCO = c.data14,
                      MONEDA = c.data15,
                      ANT_CODIGO = c.data16,
                      DET_PORCENTAJE = Convert.ToDecimal(c.data17),
                      DETRACCION = Convert.ToDecimal(c.data18),
                      RET_PORCENTAJE = Convert.ToDecimal(c.data19),
                      RETENCION = Convert.ToDecimal(c.data20),
                      PLAZO_DIAS = Convert.ToInt16(c.data21),
                      APROB = c.data22,
                      USER1 = c.data23,
                      USER2 = c.data24,
                      USER3 = c.data25,
                      USER4 = c.data26,
                      OC_CSOLICT = c.data27,
                  }).ToList();

            }
            return Listarep;
        }

    }
}
