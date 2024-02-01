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
    public partial class CT0003COMC16
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CSUBDIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string CCOMPRO { get; set; }

        [Required]
        [StringLength(6)]
        public string CFECCOM { get; set; }

        [Required]
        [StringLength(2)]
        public string CCODMON { get; set; }

        [Required]
        [StringLength(1)]
        public string CSITUA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CTIPCAM { get; set; }

        [Required]
        [StringLength(40)]
        public string CGLOSA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CTOTAL { get; set; }

        [Required]
        [StringLength(1)]
        public string CTIPO { get; set; }

        [Required]
        [StringLength(1)]
        public string CFLAG { get; set; }

        public DateTime? CDATE { get; set; }

        [Required]
        [StringLength(6)]
        public string CHORA { get; set; }

        [Required]
        [StringLength(5)]
        public string CUSER { get; set; }


        [StringLength(6)]
        public string CFECCAM { get; set; }

       
        [StringLength(2)]
        public string CORIG { get; set; }

        [StringLength(1)]
        public string CFORM { get; set; }

        
        [StringLength(2)]
        public string CTIPCOM { get; set; }


        [StringLength(1)]
        public string CEXTOR { get; set; }

        public DateTime? CFECCOM2 { get; set; }

        public DateTime? CFECCAM2 { get; set; }


        [StringLength(800)]
        public string CMEMO { get; set; }


        [StringLength(4)]
        public string CSERCER { get; set; }


        [StringLength(10)]
        public string CNUMCER { get; set; }

        /// <summary>
        /// Inserta registro de cabecera comprobante
        /// Creado:14/04/2016
        /// Actualizacion:--/--/----
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static Boolean insertaCabecera(CT0003COMC16 datos)
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
        public static string GeneraNroSolicitud()
        {
            var codigot = "";
            var valor = 0;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    codigot = ctx.CT0003COMC16.OrderByDescending(X => X.CDATE).Select(X => X.CCOMPRO).FirstOrDefault();
                    if (codigot == null)
                    { codigot = "000000"; }
                    else
                    {
                        valor = Convert.ToInt32(codigot) + 1;
                    }
                    codigot = Convert.ToString(valor);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigot;
        }

        public static List<CT0003COMC16> DETALLE(CT0003COMC16 CODATA)
        {
            var alumnos = new List<CT0003COMC16>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ((from a in ctx.CT0003COMC16
                                join b in ctx.CT0003COMD16
                                 on a.CCOMPRO equals b.DCOMPRO
                                where
                               (CODATA.CCOMPRO.Trim() != "" ? a.CCOMPRO.Trim() == CODATA.CCOMPRO.Trim() : a.CCOMPRO.Trim() != CODATA.CCOMPRO.Trim())
                               && a.CSUBDIA.Trim() == CODATA.CSUBDIA
                               && b.DAREA.Trim() != ""
                               && b.DTIPDOC == "CH"
                               && (CODATA.CGLOSA.Trim() != "" ? b.DNUMDOC.Trim() == CODATA.CGLOSA.Trim() : b.DNUMDOC.Trim() != CODATA.CGLOSA.Trim())
                                select new
                                {
                                    data1 = a.CSUBDIA,
                                    data2 = a.CCOMPRO,
                                    data3 = a.CDATE,
                                    data4 = a.CCODMON,
                                    data5 = a.CTOTAL,
                                    data6 = a.CGLOSA,
                                    data7 = a.CSITUA,
                                    data8 = a.CEXTOR,
                                    data9 = a.CTIPCOM,
                                    data10 = b.DNUMDOC,
                                }).ToList()

                          .Select(c => new CT0003COMC16()
                          {
                              CSUBDIA = c.data1,
                              CCOMPRO = c.data2,
                              CDATE = c.data3,
                              CCODMON = c.data4,
                              CTOTAL = c.data5,
                              CGLOSA = c.data6,
                              CSITUA = c.data7,
                              CEXTOR = c.data8,
                              CTIPCOM = c.data9,
                              CMEMO = c.data10,

                          }).Take(1).ToList());

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<vista_comprobante> consultaMiComprobante(vista_comprobante COM)
        {
            var Listarep = new List<vista_comprobante>();
            using (var ctx = new RSCONCAR())
            {
                Listarep = (from c in ctx.CT0003COMC16
                            join d in ctx.CT0003COMD16
                                on new { c.CSUBDIA, c.CCOMPRO }
                            equals new { CSUBDIA = d.DSUBDIA.Trim(), CCOMPRO = d.DCOMPRO.Trim() }
                            where
                                c.CSUBDIA.Trim() == COM.DSUBDIA.Trim() && c.CCOMPRO.Trim() == COM.DCOMPRO.Trim() && d.DFECCOM.Trim() == COM.DFECCOM.Trim()
                            orderby d.DSECUE ascending
                            select new
                            {
                                data10 = c.CGLOSA,
                                data101 = c.CFLAG,
                                data102 = c.CTIPO,
                                data103 = c.CTIPCAM,
                                data104 = c.CUSER,
                                data20 = d.DCUENTA,
                                data14 = d.DCODANE,
                                data140 = d.DCODMON,
                                data141 = (d.DTIPDOC == "WI" ? (ctx.CP0003CUBA.Where(ki => ki.CT_CNUMCTA.Trim() == d.DCODANE.Trim()).Select(b => b.CT_CDESCTA).FirstOrDefault()) : (ctx.CP0003MAES.Where(y => y.AC_CCODIGO.Trim() == d.DCODANE.Trim() && y.AC_CESTADO == "V").Select(m => m.AC_CNOMBRE).FirstOrDefault())),
                                data15 = d.DTIPDOC,
                                data16 = d.DAREA,
                                data17 = d.DXGLOSA,
                                data18 = d.DIMPORT,
                                data19 = d.DDH,
                                data21 = d.DNUMDOC,
                                data22 = d.DSECUE,
                                data23 = d.DVANEXO,
                                data24 = d.DCENCOS,
                                data25 = d.DMNIMPOR,
                                data26 = d.DUSIMPOR,
                                data27 = d.DFECCOM2,
                                data28 = d.DFECDOC2,
                                data29 = d.DFECVEN2,
                                data30 = d.DCODARC,
                                data31 = d.DMEDPAG,
                                data32 = d.DSUBDIA,
                                data33 = d.DCOMPRO
                            }).ToList().
                 Select(c => new vista_comprobante()
                 {
                     CGLOSA = c.data10,
                     CFLAG = c.data101,
                     CTIPO = c.data102,
                     CTIPCAM = c.data103,
                     CUSER = c.data104,
                     DSUBDIA = c.data32,
                     DCOMPRO = c.data33,
                     DSDESCRI = (ctx.CT0003TAGE.Where(x => x.TCOD == "02" && x.TCLAVE.Trim() == c.data32.Trim())).Select(m => m.TDESCRI).FirstOrDefault(),
                     DCUENTA = c.data20,
                     DCODANE = c.data14,
                     AC_CNOMBRE = c.data141,
                     DCODMON = c.data140,
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
                     DFECCOM2 = (c.data27 == null ? "  /  /  " : String.Format("{0:dd/MM/yy}", c.data27)),
                     DFECDOC2 = (c.data28 == null ? "  /  /  " : String.Format("{0:dd/MM/yy}", c.data28)),
                     DFECVEN2 = (c.data29 == null ? "  /  /  " : String.Format("{0:dd/MM/yy}", c.data29)),
                     DMEDPAG = c.data31,

                 }).ToList();

            }
            return Listarep;
        }
        /// <summary>
        /// EDGAR MENDOZA MENDIVES
        /// </summary> CABECERA DEL COMPROBANTE UTILIZADO EN LA ELIMINACION DE CHEQUES
        /// <param name="CODATA"></param> CREADO EL 20/08/2016 A LAS 11:06 HRS.
        /// <returns></returns>
        public static CT0003COMC16 CABECERA(CT0003COMC16 CODATA)
        {
            var cabecera = new CT0003COMC16();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    cabecera = ctx.CT0003COMC16.Where(x => x.CCOMPRO == CODATA.CCOMPRO && x.CSUBDIA == CODATA.CSUBDIA).First();
                }
            }
            catch (Exception)
            {

                throw;
            }
            return cabecera;
        }
        public static void Elimina(CT0003COMC16 CCAB)
        {

            using (var ctx = new RSCONCAR())
            {
                ctx.Entry(new CT0003COMC16 { CSUBDIA = CCAB.CSUBDIA, CCOMPRO = CCAB.CCOMPRO }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public static void ActualizarSituacion(CT0003COMC16 COM)
        {
            var comprobante = new CT0003COMC16 { CSUBDIA = COM.CSUBDIA, CCOMPRO = COM.CCOMPRO };

            using (var ctx = new RSCONCAR())
            {
                ctx.CT0003COMC16.Attach(comprobante);
                comprobante.CSITUA = COM.CSITUA;
                comprobante.CTOTAL = COM.CTOTAL;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }


        }

    }
}
