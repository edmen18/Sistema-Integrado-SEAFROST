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
    using System.Data.SqlClient;
    using System.Linq;
    public partial class CT0003COMD16
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string DSUBDIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string DCOMPRO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string DSECUE { get; set; }


        [Column(Order = 3)]
        [StringLength(6)]
        public string DFECCOM { get; set; }


        [Column(Order = 4)]
        [StringLength(12)]
        public string DCUENTA { get; set; }

        [Column(Order = 5)]
        [StringLength(18)]
        public string DCODANE { get; set; }


        [Column(Order = 6)]
        [StringLength(6)]
        public string DCENCOS { get; set; }


        [Column(Order = 7)]
        [StringLength(2)]
        public string DCODMON { get; set; }


        [Column(Order = 8)]
        [StringLength(1)]
        public string DDH { get; set; }


        [Column(Order = 9, TypeName = "numeric")]
        public decimal DIMPORT { get; set; }


        [Column(Order = 10)]
        [StringLength(2)]
        public string DTIPDOC { get; set; }


        [Column(Order = 11)]
        [StringLength(20)]
        public string DNUMDOC { get; set; }


        [Column(Order = 12)]
        [StringLength(6)]
        public string DFECDOC { get; set; }


        [Column(Order = 13)]
        [StringLength(6)]
        public string DFECVEN { get; set; }


        [Column(Order = 14)]
        [StringLength(3)]
        public string DAREA { get; set; }


        [Column(Order = 15)]
        [StringLength(1)]
        public string DFLAG { get; set; }

        public DateTime? DDATE { get; set; }


        [Column(Order = 16)]
        [StringLength(30)]
        public string DXGLOSA { get; set; }


        [Column(Order = 17, TypeName = "numeric")]
        public decimal DUSIMPOR { get; set; }


        [Column(Order = 18, TypeName = "numeric")]
        public decimal DMNIMPOR { get; set; }


        [Column(Order = 19)]
        [StringLength(2)]
        public string DCODARC { get; set; }

        public DateTime? DFECCOM2 { get; set; }

        public DateTime? DFECDOC2 { get; set; }

        public DateTime? DFECVEN2 { get; set; }


        [Column(Order = 20)]
        [StringLength(18)]
        public string DCODANE2 { get; set; }


        [Column(Order = 21)]
        [StringLength(1)]
        public string DVANEXO { get; set; }


        [Column(Order = 22)]
        [StringLength(1)]
        public string DVANEXO2 { get; set; }


        [Column(Order = 23, TypeName = "numeric")]
        public decimal DTIPCAM { get; set; }


        [Column(Order = 24, TypeName = "numeric")]
        public decimal DCANTID { get; set; }


        [Column(Order = 25)]
        [StringLength(12)]
        public string DCTAORI { get; set; }


        [Column(Order = 26)]
        [StringLength(2)]
        public string DCCODMON { get; set; }


        [Column(Order = 27, TypeName = "numeric")]
        public decimal DCIMPORT { get; set; }


        [Column(Order = 28)]
        [StringLength(20)]
        public string DCNUMDOC { get; set; }


        [Column(Order = 29)]
        [StringLength(1)]
        public string DCESTADO { get; set; }

        public DateTime? DCCONFEC2 { get; set; }


        [Column(Order = 30)]
        [StringLength(6)]
        public string DCCONNRO { get; set; }

        public DateTime? DCCONPRO { get; set; }


        [Column(Order = 31)]
        [StringLength(6)]
        public string DCNUMEST { get; set; }


        [Column(Order = 32)]
        [StringLength(4)]
        public string DCITEM { get; set; }


        [Column(Order = 33, TypeName = "numeric")]
        public decimal DCIMPORTB { get; set; }


        [Column(Order = 34)]
        [StringLength(4)]
        public string DCANO { get; set; }


        [Column(Order = 35)]
        [StringLength(2)]
        public string DTIPDOR { get; set; }


        [Column(Order = 36)]
        [StringLength(20)]
        public string DNUMDOR { get; set; }

        public DateTime? DFECDO2 { get; set; }


        [Column(Order = 37)]
        [StringLength(8)]
        public string DTIPTAS { get; set; }


        [Column(Order = 38, TypeName = "numeric")]
        public decimal DIMPTAS { get; set; }


        [Column(Order = 39, TypeName = "numeric")]
        public decimal DIMPBMN { get; set; }


        [Column(Order = 40, TypeName = "numeric")]
        public decimal DIMPBUS { get; set; }


        [Column(Order = 41)]
        [StringLength(2)]
        public string DMONCOM { get; set; }


        [Column(Order = 42)]
        [StringLength(10)]
        public string DCOLCOM { get; set; }


        [Column(Order = 43, TypeName = "numeric")]
        public decimal DBASCOM { get; set; }


        [Column(Order = 44, TypeName = "numeric")]
        public decimal DINACOM { get; set; }


        [Column(Order = 45, TypeName = "numeric")]
        public decimal DIGVCOM { get; set; }


        [Column(Order = 46)]
        [StringLength(1)]
        public string DTPCONV { get; set; }


        [Column(Order = 47)]
        [StringLength(1)]
        public string DFLGCOM { get; set; }


        [Column(Order = 48)]
        [StringLength(18)]
        public string DANECOM { get; set; }


        [Column(Order = 49)]
        [StringLength(1)]
        public string DTIPACO { get; set; }


        [Column(Order = 50)]
        [StringLength(8)]
        public string DMEDPAG { get; set; }


        [Column(Order = 51)]
        [StringLength(2)]
        public string DTIPDO2 { get; set; }


        [Column(Order = 52)]
        [StringLength(20)]
        public string DNUMDO2 { get; set; }


        [Column(Order = 53)]
        [StringLength(1)]
        public string DRETE { get; set; }


        [Column(Order = 54, TypeName = "numeric")]
        public decimal DPORRE { get; set; }

        public static Boolean insertaDetalle(CT0003COMD16 datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSCONCAR())
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
        /// <summary>
        /// Lista detalle del comprobante relacionado a letras de la cartera
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<CT0003COMD16> listadetalle_le(CT0003COMD16 DATA)
        {
            var lista = new List<CT0003COMD16>();
            using (var ctx = new RSCONCAR())
            {
                lista = (from ta in ctx.CT0003COMD16
                         where
                           ta.DSUBDIA.Trim() == DATA.DSUBDIA.Trim() && ta.DCOMPRO.Trim() == DATA.DCOMPRO.Trim()
                           && (DATA.DCODANE != null ? ta.DCODANE.Trim() == DATA.DCODANE.Trim() : ta.DCODANE.Trim() != DATA.DCODANE)
                           && (DATA.DDH != null ? ta.DDH == DATA.DDH : ta.DDH != DATA.DDH)//(ta.DDH != null ? ta.DDH == DATA.DDH : ta.DDH != DATA.DDH)
                           && (DATA.DTIPDOC != null ? ta.DTIPDOC == DATA.DTIPDOC : ta.DTIPDOC != DATA.DTIPDOC)//(ta.DTIPDOC != null ? ta.DTIPDOC == DATA.DTIPDOC : ta.DTIPDOC != DATA.DTIPDOC)
                         orderby ta.DSECUE
                         select new
                         {
                             data13 = ta.DFECCOM,
                             data20 = ta.DCUENTA,
                             data14 = ta.DCODANE,
                             data15 = ta.DTIPDOC,
                             data16 = ta.DAREA,
                             data17 = ta.DXGLOSA,
                             data18 = ta.DIMPORT,
                             data19 = ta.DDH,
                             data21 = ta.DNUMDOC,
                             data22 = ta.DSECUE,
                             data23 = ta.DVANEXO,
                             data24 = ta.DCENCOS,
                             data31 = ta.DCODMON,
                             data25 = ta.DMNIMPOR,
                             data26 = ta.DUSIMPOR,
                             data27 = ta.DFECDOC2,
                             data28 = ta.DFECVEN2,
                             data29 = ta.DCODARC,
                             data32 = ta.DCANTID,
                             data30 = ta.DMEDPAG
                         }).ToList().
                             Select(c => new CT0003COMD16()
                             {
                                 DFECCOM = c.data13,
                                 DCUENTA = c.data20,
                                 DCODANE = c.data14,
                                 DTIPDOC = c.data15,
                                 DNUMDOC = c.data21,
                                 DAREA = c.data16,
                                 DXGLOSA = c.data17,
                                 DIMPORT = c.data18,
                                 DDH = c.data19,
                                 DSECUE = c.data22,
                                 DVANEXO = c.data23,
                                 DCENCOS = c.data24,
                                 DCODMON = c.data31,
                                 DMNIMPOR = c.data25,
                                 DUSIMPOR = c.data26,
                                 DANECOM = ctx.CP0003PAGO.Where(x => x.PG_CVANEXO == c.data23 && x.PG_CCODIGO == c.data14 && x.PG_CTIPDOC == c.data15 && x.PG_CNUMDOC == c.data21).Select(x => x.PG_CORDKEY).FirstOrDefault(),
                                 DFECDOC2 = c.data27,
                                 DFECVEN2 = c.data28,
                                 DCODARC = c.data29,
                                 DMEDPAG = c.data30,
                                 DCANTID = c.data32
                             }).ToList();

            }
            return lista;
        }
        /*
        public static Boolean insertaDetalleEdgar(CT0003COMD16 datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSCONCAR())
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
        }*/

        /// <summary>
        /// EXTRAER LOS DATOS DE LA TABALA DETALLE COMPROBANTE PARA INSERCION EN BALH16
        /// </summary>
        /// <param name="CODATA"></param>
        /// <returns></returns>
        public static List<VISTA_PREVIA_INSERCION_BALH> DETALLE(CT0003COMD16 CODATA)
        {
            var alumnos = new List<VISTA_PREVIA_INSERCION_BALH>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ((from a in ctx.CT0003COMD16
                                where a.DCOMPRO.Trim() == CODATA.DCOMPRO.Trim() && a.DSUBDIA.Trim() == CODATA.DSUBDIA.Trim() //&& a.RC_CESTADO=="7"
                                group new { a } by new
                                {
                                    a.DCUENTA,
                                    a.DFECCOM,
                                    a.DMNIMPOR,
                                    a.DUSIMPOR,
                                    a.DTIPDOC,

                                } into g
                                orderby
                                  g.Key.DCUENTA
                                select new
                                {
                                    data1 = g.Key.DCUENTA,
                                    data2 = g.Key.DFECCOM,
                                    SUMASOLESD = g.Where(s => s.a.DDH.Trim() == "D").Sum(s => ((decimal?)s.a.DMNIMPOR)),
                                    SUMADOLARESD = g.Where(s => s.a.DDH.Trim() == "D").Sum(s => ((decimal?)s.a.DUSIMPOR)),
                                    SUMASOLESH = g.Where(s => s.a.DDH.Trim() == "H").Sum(s => ((decimal?)s.a.DMNIMPOR)),
                                    SUMADOLARESH = g.Where(s => s.a.DDH.Trim() == "H").Sum(s => ((decimal?)s.a.DUSIMPOR)),
                                    TIPODOC = g.Key.DTIPDOC,

                                }).ToList()

                          .Select(c => new VISTA_PREVIA_INSERCION_BALH()
                          {
                              CUENTA = (c.data1 == null ? "SIN CUENTA" : c.data1),
                              FECHA = (Convert.ToString(c.data2) == null ? "SIN FECHA" : Convert.ToString(c.data2)),
                              SUMASOLESDEBE = ((decimal?)c.SUMASOLESD),
                              SUMASOLESHABER = ((decimal?)c.SUMASOLESH),
                              SUMADOLARESDEBE = ((decimal?)c.SUMADOLARESD),
                              SUMADOLARESHABER = ((decimal?)c.SUMADOLARESH),
                              TIPODOPC = c.TIPODOC,
                          }).ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static void ActualizaConstancia(CT0003COMD16 COM)
        {
            var orden = new CT0003COMD16 { DSUBDIA = COM.DSUBDIA, DCOMPRO = COM.DCOMPRO, DSECUE = COM.DSECUE, DCODANE = COM.DCODANE };

            using (var ctx = new RSCONCAR())
            {
                ctx.CT0003COMD16.Attach(orden);
                orden.DNUMDOR = COM.DNUMDOR;
                orden.DFECDO2 = COM.DFECDO2;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

            }
        }

        public static void Elimina(CT0003COMD16 CCAB)
        {

            using (var ctx = new RSCONCAR())
            {
                ctx.Entry(new CT0003COMD16 { DSUBDIA = CCAB.DSUBDIA, DCOMPRO = CCAB.DCOMPRO, DSECUE = CCAB.DSECUE }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
        public static List<CT0003COMD16> ConsultaunDetalle(CT0003COMD16 COM)
        {
            var Listarep = new List<CT0003COMD16>();
            using (var ctx = new RSCONCAR())
            {
                Listarep = (from la in ctx.CT0003COMD16
                            where
                              la.DSUBDIA.Trim() == COM.DSUBDIA.Trim() && la.DCOMPRO.Trim() == COM.DCOMPRO.Trim()
                            select new
                            {
                                data20 = la.DCUENTA,
                                data14 = la.DCODANE,
                                data15 = la.DTIPDOC,
                                data16 = la.DAREA,
                                data17 = la.DXGLOSA,
                                data18 = la.DIMPORT,
                                data19 = la.DDH,
                                data21 = la.DNUMDOC,
                                data22 = la.DSECUE,
                                data23 = la.DVANEXO,
                                data24 = la.DCENCOS,
                                data25 = la.DMNIMPOR,
                                data26 = la.DUSIMPOR,
                                data27 = la.DFECDOC2,
                                data28 = la.DFECVEN2,
                                data29 = la.DCODARC,
                                data30 = la.DMEDPAG,
                                data31 = la.DSUBDIA

                            }).ToList().
                 Select(c => new CT0003COMD16()
                 {

                     DCUENTA = c.data20,
                     DCODANE = c.data14,
                     DTIPDOC = c.data15,
                     DNUMDOC = c.data21,
                     DAREA = c.data16,
                     DXGLOSA = c.data17,
                     DIMPORT = c.data18,
                     DDH = c.data19,
                     DSECUE = c.data22,
                     DVANEXO = c.data23,
                     DCENCOS = c.data24,
                     DMNIMPOR = c.data25,
                     DUSIMPOR = c.data26,
                     DANECOM = ctx.CP0003PAGO.Where(x => x.PG_CVANEXO == c.data23 && x.PG_CCODIGO == c.data14 && x.PG_CTIPDOC == c.data15 && x.PG_CNUMDOC == c.data21 && x.PG_CSUBDIA == c.data31).Select(x => x.PG_CORDKEY).FirstOrDefault(),
                     DFECDOC2 = c.data27,
                     DFECVEN2 = c.data28,
                     DCODARC = c.data29,
                     DMEDPAG = c.data30,

                 }).ToList();

            }
            return Listarep;
        }

    }
}
