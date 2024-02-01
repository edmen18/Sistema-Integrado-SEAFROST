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
  
    public class vista_AL0003ASER
    {
      
        public string C6_CLOCALI { get; set; }
        public string C6_CALMA { get; set; }
        public string C6_CTD { get; set; }
        public string C6_CNUMDOC { get; set; }
        public string C6_CITEM { get; set; }
        public string C6_CCODIGO { get; set; }
        public string C6_CSERIE { get; set; }
        public decimal C6_NCANTID { get; set; }
        public string C6_CUSUCRE { get; set; }
        public DateTime? C6_DFECCRE { get; set; }
        public DateTime? C6_DFECDOC { get; set; }
        public string C6_CITEREQ { get; set; }
        public string C6_CNUMCEL { get; set; }
        public decimal C6_NCANRPE { get; set; }
        public decimal? SALDO { get; set; }
        public string ARTICULO { get; set; }
        public string C5_CCODMOV { get; set; }

        public string C5_CRFTDOC { get; set; }
        public string C5_CRFNDOC { get; set; }

        public string C5_CRFALMA { get; set; }

        public string DESCRIPMOV { get; set; }

        public decimal entrada { get; set; }
        public decimal salida { get; set; }
        public decimal final { get; set; }


    }
    public partial class AL0003ASER
    {
        [Required]
        [StringLength(4)]
        public string C6_CLOCALI { get; set; }

        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string C6_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string C6_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string C6_CITEM { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(18)]
        public string C6_CSERIE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANTID { get; set; }

        [Required]
        [StringLength(5)]
        public string C6_CUSUCRE { get; set; }

        public DateTime? C6_DFECCRE { get; set; }

        public DateTime? C6_DFECDOC { get; set; }


        [StringLength(4)]
        public string C6_CITEREQ { get; set; }


        [StringLength(15)]
        public string C6_CNUMCEL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANRPE { get; set; }

        public static List<vista_AL0003ASER> ListarKardexResumidoSinLote(AL0003ASER kardex)
        {
            var sql = new List<vista_AL0003ASER>();
            var sql1 = new List<vista_AL0003ASER>();


            try
            {
                using (var ctx = new RSFACAR())
                {
                    var SAL = AL0003MOVD.devuelveKardexSaldoAnteriorFinal(kardex.C6_CCODIGO.Trim(), kardex.C6_CALMA.Trim(), Convert.ToDateTime(kardex.C6_DFECCRE));

                    sql = (from x in ctx.AL0003MOVC
                           join y in ctx.AL0003MOVD
                                 on new { x.C5_CALMA, x.C5_CNUMDOC, x.C5_CTD }
                             equals new { C5_CALMA = y.C6_CALMA, C5_CNUMDOC = y.C6_CNUMDOC, C5_CTD = y.C6_CTD }
                           join z in ctx.AL0003ARTI on new { AR_CCODIGO = y.C6_CCODIGO } equals new { AR_CCODIGO = z.AR_CCODIGO }
                           where
                             y.C6_CCODIGO.Trim() == kardex.C6_CCODIGO.Trim() && y.C6_CALMA.Trim() == kardex.C6_CALMA.Trim() &&
                             (
                             y.C6_DFECDOC >= kardex.C6_DFECCRE &&
                             y.C6_DFECDOC <= kardex.C6_DFECDOC
                             )
                           orderby
                             y.C6_DFECDOC
                           group new { x, y, z } by new
                           {
                               y.C6_CCODIGO,
                               z.AR_CDESCRI,
                               y.C6_CTD

                           } into g
                           select new
                           {
                               a = g.Key.C6_CCODIGO,
                               b = g.Key.AR_CDESCRI,
                               c = (decimal)g.Sum(p => p.y.C6_NCANTID),
                               d = g.Key.C6_CTD,
                               e = SAL

                           }).Select(c => new vista_AL0003ASER()
                           {
                               C6_CCODIGO = c.a,
                               ARTICULO = c.b,
                               C6_NCANTID = c.c,
                               C6_CTD = c.d,
                               SALDO = c.e

                           }

                    ).ToList();

                    decimal entrada = 0;
                    decimal salida = 0;
                    string codigo = string.Empty;
                    string articulo = string.Empty;
                    decimal? saldo = 0;
                    decimal final = 0;

                    if (sql.Count > 0)
                    {
                        foreach (var x in sql)
                        {
                            if (x.C6_CTD == "PE")
                                entrada = x.C6_NCANTID;
                            else
                                salida = x.C6_NCANTID;

                            codigo = x.C6_CCODIGO;
                            articulo = x.ARTICULO;
                            saldo = x.SALDO;
                            final = Convert.ToDecimal(saldo) + entrada - salida;
                        }
                        vista_AL0003ASER sql2 = new vista_AL0003ASER()
                        {
                            C6_CCODIGO = codigo,
                            ARTICULO = articulo,
                            entrada = entrada,
                            salida = salida,
                            SALDO = saldo,
                            final = final

                        };

                        sql1.Add(sql2);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql1;
        }

        public static List<vista_AL0003ASER> ListarKardexResumido(AL0003ASER kardex)
        {
            var sql = new List<vista_AL0003ASER>();
            var sql1 = new List<vista_AL0003ASER>();
           

            try
            {
                using (var ctx = new RSFACAR())
                {
                    var SAL = AL0003MOVD.devuelveKardexSaldoAnteriorFinal(kardex.C6_CCODIGO.Trim(), kardex.C6_CALMA.Trim(), Convert.ToDateTime(kardex.C6_DFECCRE));

                    sql = (from x in ctx.AL0003ASER
                           join y in ctx.AL0003MOVD
                                 on new { x.C6_CALMA, x.C6_CNUMDOC, x.C6_CTD, x.C6_CITEM }
                             equals new { C6_CALMA = y.C6_CALMA, C6_CNUMDOC = y.C6_CNUMDOC, C6_CTD = y.C6_CTD, C6_CITEM = y.C6_CITEM }
                           join z in ctx.AL0003ARTI on new { AR_CCODIGO = x.C6_CCODIGO } equals new { AR_CCODIGO = z.AR_CCODIGO }
                           where
                             x.C6_CCODIGO.Trim() == kardex.C6_CCODIGO.Trim() && y.C6_CALMA.Trim() == kardex.C6_CALMA.Trim() &&
                             (
                             y.C6_DFECDOC >= kardex.C6_DFECCRE &&
                             y.C6_DFECDOC <= kardex.C6_DFECDOC
                             )
                           orderby
                             y.C6_DFECDOC
                           group new { x, y,z } by new
                           {
                               x.C6_CCODIGO,
                               z.AR_CDESCRI,
                               y.C6_CTD 
                             
                           } into g
                           select new
                           {
                              a= g.Key.C6_CCODIGO,
                              b= g.Key.AR_CDESCRI,
                              c =  (decimal)g.Sum(p => p.x.C6_NCANTID),
                              d=g.Key.C6_CTD ,
                              e=SAL
                            
                           }).Select(c => new vista_AL0003ASER()
                           {
                               C6_CCODIGO = c.a,
                               ARTICULO = c.b,
                               C6_NCANTID = c.c,
                               C6_CTD =c.d,
                               SALDO=c.e 

                           }

                    ).ToList();

                    decimal entrada=0;
                    decimal salida = 0;
                    string codigo=string.Empty;
                    string articulo=string.Empty;
                    decimal? saldo=0;
                    decimal final = 0;

                    if (sql.Count >0)
                    {
                        foreach (var x in sql)
                        {
                            if (x.C6_CTD == "PE")
                                entrada = x.C6_NCANTID;
                            else
                                salida = x.C6_NCANTID;

                            codigo = x.C6_CCODIGO;
                            articulo = x.ARTICULO;
                            saldo = x.SALDO;
                            final = Convert.ToDecimal(saldo) + entrada - salida;
                        }
                        vista_AL0003ASER sql2 = new vista_AL0003ASER()
                        {
                            C6_CCODIGO = codigo,
                            ARTICULO = articulo,
                            entrada = entrada,
                            salida = salida,
                            SALDO = saldo,
                            final = final

                        };

                        sql1.Add(sql2);
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql1;
        }
        public static List<vista_AL0003ASER> ListarKardex(AL0003ASER kardex)
        {
            var sql = new List<vista_AL0003ASER>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    var SAL = AL0003MOVD.devuelveKardexSaldoAnteriorFinal(kardex.C6_CCODIGO.Trim(), kardex.C6_CALMA.Trim(), Convert.ToDateTime(kardex.C6_DFECCRE));

                    sql = (from x in ctx.AL0003ASER
                           join y in ctx.AL0003MOVD
                                 on new { x.C6_CALMA, x.C6_CNUMDOC, x.C6_CTD, x.C6_CITEM }
                             equals new { C6_CALMA = y.C6_CALMA, C6_CNUMDOC = y.C6_CNUMDOC, C6_CTD = y.C6_CTD , C6_CITEM  =y.C6_CITEM}
                           join z in ctx.AL0003ARTI on new { AR_CCODIGO = x.C6_CCODIGO } equals new { AR_CCODIGO = z.AR_CCODIGO }
                           where
                             x.C6_CCODIGO.Trim() == kardex.C6_CCODIGO.Trim() && y.C6_CALMA.Trim()==kardex.C6_CALMA.Trim() &&
                             (
                             y.C6_DFECDOC >= kardex.C6_DFECCRE &&
                             y.C6_DFECDOC <= kardex.C6_DFECDOC
                             )
                           orderby
                             y.C6_DFECDOC
                           select new
                           {
                               a = x.C6_CLOCALI,
                               b = x.C6_CALMA,
                               c = x.C6_CTD,
                               d = x.C6_CNUMDOC,
                               e = x.C6_CITEM,
                               f = x.C6_CCODIGO,
                               g = x.C6_CSERIE,
                               h = x.C6_NCANTID,
                               i = x.C6_CUSUCRE,
                               j = x.C6_DFECCRE,
                               k = y.C6_DFECDOC,
                               l = x.C6_CITEREQ,
                               m = x.C6_CNUMCEL,
                               n = x.C6_NCANRPE,
                               o=z.AR_CDESCRI,

                               //p =y.C5_CCODMOV,
                               //q=y.C5_CRFALMA,
                               //r=y.C5_CRFTDOC,
                               //s=y.C5_CRFNDOC,

                               p = ((from b in ctx.AL0003MOVC
                                     where
                                       b.C5_CALMA==y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                                     select new
                                     {
                                         b.C5_CCODMOV
                                     }).FirstOrDefault().C5_CCODMOV),

                               q = ((from b in ctx.AL0003MOVC
                                     where
                                       b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                                     select new
                                     {
                                         b.C5_CRFALMA
                                     }).FirstOrDefault().C5_CRFALMA),

                               r = ((from b in ctx.AL0003MOVC
                                     where
                                       b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                                     select new
                                     {
                                         b.C5_CRFTDOC
                                     }).FirstOrDefault().C5_CRFTDOC),

                               s = ((from b in ctx.AL0003MOVC
                                     where
                                       b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                                     select new
                                     {
                                         b.C5_CRFNDOC
                                     }).FirstOrDefault().C5_CRFNDOC),



                               t = ((from b in ctx.AL0003TABM
                                     where
                                       b.TM_CTIPMOV == (y.C6_CTD=="PE" ? "E" : "S") && b.TM_CCODMOV == y.C6_CCODMOV
                                     select new
                                     {
                                         b.TM_CDESCRI
                                     }).FirstOrDefault().TM_CDESCRI)
                               
                           }).Select(c => new vista_AL0003ASER()
                           {
                               C6_CLOCALI = c.a,
                               C6_CALMA = c.b,
                               C6_CTD = c.c,
                               C6_CNUMDOC = c.d,
                               C6_CITEM = c.e,
                               C6_CCODIGO = c.f,
                               C6_CSERIE = c.g,
                               C6_NCANTID = c.h,
                               C6_CUSUCRE = c.i,
                               C6_DFECCRE = c.j,
                               C6_DFECDOC = c.k,
                               C6_CITEREQ = c.l,
                               C6_CNUMCEL = c.m,
                               C6_NCANRPE = c.n,
                               SALDO =SAL,
                               ARTICULO=c.o,
                               C5_CCODMOV=c.p,
                               C5_CRFALMA = c.q ,
                               C5_CRFTDOC=c.r,
                               C5_CRFNDOC=c.s,
                               DESCRIPMOV=c.t
                           }


                    ).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql;
        }

        public static List<vista_AL0003ASER> ListarKardexSinLote(AL0003ASER kardex)
        {
            var sql = new List<vista_AL0003ASER>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    var SAL = AL0003MOVD.devuelveKardexSaldoAnteriorFinal(kardex.C6_CCODIGO.Trim(), kardex.C6_CALMA.Trim(), Convert.ToDateTime(kardex.C6_DFECCRE));

                    sql = (from x in ctx.AL0003MOVC
                           join y in ctx.AL0003MOVD
                                 on new { x.C5_CALMA, x.C5_CNUMDOC, x.C5_CTD }
                            equals new { C5_CALMA = y.C6_CALMA, C5_CNUMDOC = y.C6_CNUMDOC, C5_CTD = y.C6_CTD }
                           join z in ctx.AL0003ARTI on new { AR_CCODIGO = y.C6_CCODIGO } equals new { AR_CCODIGO = z.AR_CCODIGO }
                           where
                             y.C6_CCODIGO.Trim() == kardex.C6_CCODIGO.Trim() && y.C6_CALMA.Trim() == kardex.C6_CALMA.Trim() &&
                             (
                             y.C6_DFECDOC >= kardex.C6_DFECCRE &&
                             y.C6_DFECDOC <= kardex.C6_DFECDOC
                             )
                           orderby
                             y.C6_DFECDOC
                           select new
                           {
                               a = y.C6_CLOCALI,
                               b = y.C6_CALMA,
                               c = y.C6_CTD,
                               d = y.C6_CNUMDOC,
                               e = y.C6_CITEM,
                               f = y.C6_CCODIGO,
                               g = y.C6_CSERIE,
                               h = y.C6_NCANTID,
                               i = x.C5_CUSUCRE,
                               j = x.C5_DFECCRE,
                               k = y.C6_DFECDOC,
                               l = "",// x.C5_CITEREQ,
                               m = "",//x.C5_CNUMCEL,
                               n = 0,//x.C5_NCANRPE,
                               o = z.AR_CDESCRI,

                               //p =y.C5_CCODMOV,
                               //q=y.C5_CRFALMA,
                               //r=y.C5_CRFTDOC,
                               //s=y.C5_CRFNDOC,

                               p = x.C5_CCODMOV ,
                               //((from b in ctx.AL0003MOVC
                               //      where
                               //        b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                               //      select new
                               //      {
                               //          b.C5_CCODMOV
                               //      }).FirstOrDefault().C5_CCODMOV),

                               q = x.C5_CRFALMA,
                               //((from b in ctx.AL0003MOVC
                               //      where
                               //        b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                               //      select new
                               //      {
                               //          b.C5_CRFALMA
                               //      }).FirstOrDefault().C5_CRFALMA),

                               r = x.C5_CRFTDOC,
                               //((from b in ctx.AL0003MOVC
                               //      where
                               //        b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                               //      select new
                               //      {
                               //          b.C5_CRFTDOC
                               //      }).FirstOrDefault().C5_CRFTDOC),

                               s = x.C5_CRFNDOC,

                               //((from b in ctx.AL0003MOVC
                               //      where
                               //        b.C5_CALMA == y.C6_CALMA && b.C5_CNUMDOC == y.C6_CNUMDOC && b.C5_CTD == y.C6_CTD
                               //      select new
                               //      {
                               //          b.C5_CRFNDOC
                               //      }).FirstOrDefault().C5_CRFNDOC),



                               t = ((from b in ctx.AL0003TABM
                                     where
                                       b.TM_CTIPMOV == (y.C6_CTD == "PE" ? "E" : "S") && b.TM_CCODMOV == y.C6_CCODMOV
                                     select new
                                     {
                                         b.TM_CDESCRI
                                     }).FirstOrDefault().TM_CDESCRI)

                           }).Select(c => new vista_AL0003ASER()
                           {
                               C6_CLOCALI = c.a,
                               C6_CALMA = c.b,
                               C6_CTD = c.c,
                               C6_CNUMDOC = c.d,
                               C6_CITEM = c.e,
                               C6_CCODIGO = c.f,
                               C6_CSERIE = c.g,
                               C6_NCANTID = c.h,
                               C6_CUSUCRE = c.i,
                               C6_DFECCRE = c.j,
                               C6_DFECDOC = c.k,
                               C6_CITEREQ = c.l,
                               C6_CNUMCEL = c.m,
                               C6_NCANRPE = c.n,
                               SALDO = SAL,
                               ARTICULO = c.o,
                               C5_CCODMOV = c.p,
                               C5_CRFALMA = c.q,
                               C5_CRFTDOC = c.r,
                               C5_CRFNDOC = c.s,
                               DESCRIPMOV = c.t
                           }


                    ).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return sql;
        }




        public static Boolean insertaAS(AL0003ASER datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            datos.C6_DFECCRE = fechaA;
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




    }
}
