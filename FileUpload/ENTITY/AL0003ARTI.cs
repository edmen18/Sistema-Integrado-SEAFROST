namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.SqlServer;
    using System.Data.SqlClient;
    using System.Data.Entity.Validation;
    using System.Diagnostics;

    public partial class AL0003ARTI
    {
        [Key]
        [StringLength(25)]
        public string AR_CCODIGO { get; set; }

        [Required]
        [StringLength(60)]
        public string AR_CDESCRI { get; set; }

        [StringLength(60)]
        public string AR_CDESCR2 { get; set; }

        [StringLength(25)]
        public string AR_CCODIG2 { get; set; }

        [Required]
        [StringLength(3)]
        public string AR_CUNIDAD { get; set; }

        [Required]
        [StringLength(12)]
        public string AR_CCUENTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECI6 { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CMONVTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NISCPOR { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CTIPO { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CCONTRO { get; set; }

        [Required]
        [StringLength(3)]
        public string AR_CTIPDES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NDESCT2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPDIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPCOM { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CGRUPO { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CFAMILI { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CMODELO { get; set; }

        [Required]
        [StringLength(4)]
        public string AR_CLINEA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPESO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NVOLUME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NAREA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NFACTOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NANCHO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NLARGO { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CMONCOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECOS { get; set; }

        public DateTime? AR_DFECCOS { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CMONCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECOM { get; set; }

        public DateTime? AR_DFECCOM { get; set; }

        [Required]
        [StringLength(18)]
        public string AR_CCODPRO { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CMONFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPREFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE2 { get; set; }

        [Required]
        [StringLength(3)]
        public string AR_CCLAART { get; set; }

        [Required]
        [StringLength(15)]
        public string AR_CPARARA { get; set; }

        [Required]
        [StringLength(50)]
        public string AR_CINFTEC { get; set; }

        [Required]
        [StringLength(50)]
        public string AR_CCATALO { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CCATEGO { get; set; }

        [Required]
        [StringLength(2)]
        public string AR_CTIPOI { get; set; }

        [Required]
        [StringLength(800)]
        public string AR_TOBSERV { get; set; }

        [Required]
        [StringLength(3)]
        public string AR_CUNIREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NFACREF { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFUNIRE { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFSTOCK { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFDECI { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFPRELI { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFRESTA { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFSERIE { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFLOTE { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFROTAB { get; set; }

        [Required]
        [StringLength(5)]
        public string AR_CUSUCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string AR_CUSUMOD { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CESTADO { get; set; }

        public DateTime? AR_DFECCRE { get; set; }

        public DateTime? AR_DFECMOD { get; set; }

        [Required]
        [StringLength(25)]
        public string AR_CCODANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NDETRA { get; set; }

        [Required]
        [StringLength(6)]
        public string AR_CMEDIDA { get; set; }

        [Required]
        [StringLength(9)]
        public string AR_CANNO { get; set; }

        [Required]
        [StringLength(15)]
        public string AR_CGROSOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIMAGEN { get; set; }

        [Required]
        [StringLength(6)]
        public string AR_CFECABC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NLONSER { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFCELU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NLONCEL { get; set; }

        [Required]
        [StringLength(12)]
        public string AR_CMEDNEU { get; set; }

        [Required]
        [StringLength(12)]
        public string AR_CINDCAR { get; set; }

        [Required]
        [StringLength(12)]
        public string AR_CDISENO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPERC1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPERC2 { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CMARCA { get; set; }

        [Required]
        [StringLength(4)]
        public string AR_CANOFAB { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CLUGORI { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFVEHI { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CAYUVEN { get; set; }

        [Required]
        [StringLength(20)]
        public string AR_CCOLOR { get; set; }

        [Required]
        [StringLength(20)]
        public string AR_CTALLA { get; set; }

        [Required]
        [StringLength(4)]
        public string AR_CTIPEXI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NMARVTA { get; set; }

        [Required]
        [StringLength(10)]
        public string AR_CHORSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIGVCPR { get; set; }

        [Required]
        [StringLength(12)]
        public string AR_CCUENTR { get; set; }

        [Required]
        [StringLength(1)]
        public string AR_CFLGRCN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NTASRCN { get; set; }

        [Required]
        [StringLength(18)]
        public string AR_CFORSER { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CCODAG1 { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CCODAG2 { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CCODAG3 { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CCODAG4 { get; set; }

        [Required]
        [StringLength(8)]
        public string AR_CCODAG5 { get; set; }

        [Required]
        [StringLength(10)]
        public string AR_PERTOPE { get; set; }

        public static Boolean actualizaStockMinimo(AL0003ARTI ARTI)
        {
            Boolean band = true;
            var cliente = new AL0003ARTI { AR_CCODIGO = ARTI.AR_CCODIGO.Trim() };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003ARTI.Attach(cliente);
                    cliente.AR_NMARGE1 = ARTI.AR_NMARGE1;
                    cliente.AR_NMARGE2 = ARTI.AR_NMARGE2;
                    cliente.AR_CCATALO = ARTI.AR_CCATALO;
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

        public static List<AL0003ARTI> ListarArticulosParaKardex(string cod1 , string cod2 )
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<AL0003ARTI>("select * from  AL0003ARTI  where AR_CCODIGO between @cod1 and @cod2 order by rtrim(ltrim(AR_CCODIGO))",
                           new SqlParameter("cod1", cod1),new SqlParameter("cod2", cod2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<AL0003ARTI> ListarArticulos(string texto)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CESTADO == "V")
                                     .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<AL0003ARTI> ListarArticulosforma2(string texto,string tipop,string subtip,string tipolinea)
        {
            var articu = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    articu = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0  && x.AR_CESTADO=="V" &&
                    //((tipop =="S" && subtip == "1") ? x.AR_CLINEA=="R": x.AR_CLINEA != "" ) 
                     (tipolinea =="R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R")
                    ).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return articu;
        }
        
        public static AL0003ARTI obtenerArticuloPorID(string art)
        {
            var alumnos = new AL0003ARTI();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003ARTI.Where(x => x.AR_CCODIGO == art).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        //nuevo william
        //nuevo william
        public static List<AL0003ARTI> ListarArticulosID(string texto)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {   //AR_CESTADO->A: ANULUADO B:BLOQUEADO S:SALDADO V:VIGENTE
                    alumnos = ctx.AL0003ARTI.Where(x => x.AR_CCODIGO.Contains(texto) && x.AR_CESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        //NUEVO WILLIAM
        /// <summary>
        /// Listar articulos con stock filtro
        /// fitlros: 
        /// ACTUALIZACION 12/04/2016
        /// </summary>
        /// <param name="TEXTO"></param>
        /// <param name="TR"></param>
        /// <param name="AL"></param>
        /// <returns></returns>
        public static List<AL0003ARTI> ListarArtSto(string TEXTO, string TR, string AL)
        {
            var articulo = new List<AL0003ARTI>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    articulo = (from c in ctx.AL0003ARTI
                                join d in ctx.AL0003STOC
                                      on new { c.AR_CCODIGO }
                                  equals new { AR_CCODIGO = d.SK_CCODIGO }
                                where
                                  (SqlFunctions.PatIndex(TEXTO, c.AR_CDESCRI) > 0 && c.AR_CESTADO == "V") &&
                                  (TR == "E" ? d.SK_NSKDIS >= 0 : d.SK_NSKDIS != 0) && (d.SK_CALMA == AL)
                                select new
                                {
                                    AR_CCODIGO = c.AR_CCODIGO,
                                    AR_CDESCRI = c.AR_CDESCRI,
                                    AR_CUNIDAD = c.AR_CUNIDAD,
                                    AR_CCUENTA = c.AR_CCUENTA,
                                    AR_CGRUPO = c.AR_CGRUPO,
                                    AR_CFAMILI = c.AR_CFAMILI,
                                    AR_CMODELO = c.AR_CMODELO,
                                    AR_CLINEA = c.AR_CLINEA,
                                    AR_NPESO = c.AR_NPESO,
                                    AR_CFLOTE = c.AR_CFLOTE
                                }).ToList().Select(c => new AL0003ARTI()
                                {
                                    AR_CCODIGO = c.AR_CCODIGO,
                                    AR_CDESCRI = c.AR_CDESCRI,
                                    AR_CUNIDAD = c.AR_CUNIDAD,
                                    AR_CCUENTA = c.AR_CCUENTA,
                                    AR_CGRUPO = c.AR_CGRUPO,
                                    AR_CFAMILI = c.AR_CFAMILI,
                                    AR_CMODELO = c.AR_CMODELO,
                                    AR_CLINEA = c.AR_CLINEA,
                                    AR_NPESO = c.AR_NPESO,
                                    AR_CFLOTE = c.AR_CFLOTE
                                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return articulo;
        }
        /// <summary>
        /// Listar articulos con stock/sin stock
        /// filtros: x codigo
        /// </summary>
        /// <param name="TEXTO"></param>
        /// <param name="TR"></param>
        /// <param name="AL"></param>
        /// <returns></returns>
        public static List<AL0003ARTI> ListarArtStoID(string TEXTO, string TR, string AL)
        {
            var articulo = new List<AL0003ARTI>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    articulo = (from c in ctx.AL0003ARTI
                                join d in ctx.AL0003STOC
                                      on new { c.AR_CCODIGO }
                                  equals new { AR_CCODIGO = d.SK_CCODIGO }
                                where
                                  (SqlFunctions.PatIndex(TEXTO, c.AR_CCODIGO) > 0 && c.AR_CESTADO == "V") &&
                                  (TR == "E" ? d.SK_NSKDIS >= 0 : d.SK_NSKDIS != 0) && (d.SK_CALMA == AL)
                                select new
                                {
                                    AR_CCODIGO = c.AR_CCODIGO,
                                    AR_CDESCRI = c.AR_CDESCRI,
                                    AR_CUNIDAD = c.AR_CUNIDAD,
                                    AR_CCUENTA = c.AR_CCUENTA,
                                    AR_CGRUPO = c.AR_CGRUPO,
                                    AR_CFAMILI = c.AR_CFAMILI,
                                    AR_CMODELO = c.AR_CMODELO,
                                    AR_CLINEA = c.AR_CLINEA,
                                    AR_NPESO = c.AR_NPESO,
                                    AR_CFLOTE = c.AR_CFLOTE
                                }).ToList().Select(c => new AL0003ARTI()
                                {
                                    AR_CCODIGO = c.AR_CCODIGO,
                                    AR_CDESCRI = c.AR_CDESCRI,
                                    AR_CUNIDAD = c.AR_CUNIDAD,
                                    AR_CCUENTA = c.AR_CCUENTA,
                                    AR_CGRUPO = c.AR_CGRUPO,
                                    AR_CFAMILI = c.AR_CFAMILI,
                                    AR_CMODELO = c.AR_CMODELO,
                                    AR_CLINEA = c.AR_CLINEA,
                                    AR_NPESO = c.AR_NPESO,
                                    AR_CFLOTE = c.AR_CFLOTE
                                }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return articulo;
        }

        //CODIGO EDGAR
        public static List<AL0003ARTI> ListarArticulo(string texto)

        {
            var ARTICULOS = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    ARTICULOS = (from c in ctx.AL0003ARTI
                                 where c.AR_CDESCRI.Contains(texto)
                                 select new
                                 {
                                     AR_CCODIGO = c.AR_CCODIGO,
                                     AR_CDESCRI = c.AR_CDESCRI,
                                 }

                        ).ToList().Select(c => new AL0003ARTI()
                        {
                            AR_CCODIGO = c.AR_CCODIGO.Trim(),
                            AR_CDESCRI = c.AR_CCODIGO.Trim() + "-" + c.AR_CDESCRI.Trim(),
                        }).ToList(); ;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ARTICULOS;
        }

        public static List<AL0003ARTI> ListarArticulosParaStockValorizado(string cod1, string cod2)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos = ctx.Database.SqlQuery<AL0003ARTI>("select * from  AL0003ARTI  where AR_CCODIGO between @cod1 and @cod2 order by rtrim(ltrim(AR_CCODIGO))",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        //sergio nuevo 15/04/2016
        public static string ultimocodigoxtipo(string linea)
        {

            string rvalor = "", codgen = "";
            long codgenera = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    rvalor = ctx.AL0003ARTI.Where(x => x.AR_CLINEA == linea).OrderByDescending(ob => ob.AR_CCODIGO).FirstOrDefault().AR_CCODIGO;
                }
            }
            catch (Exception)
            {

                rvalor = "";
            }

            codgen = rvalor.Replace("R", "").Trim();
            codgenera = Convert.ToInt64(codgen) + 1;
            codgen = "R" + codgenera.ToString("D12");
            return codgen;
        }

        //nuevo sergio 19042016

        public static void Insertararticulo(AL0003ARTI ADDM)
        {
            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                    using (RSFACAR ctx2 = new RSFACAR())
                    {
                        ctx.Entry(ADDM).State = EntityState.Added;
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
            }
        }

        public static void Actualizararticulo(AL0003ARTI ADDM)
        {
            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                    using (RSFACAR ctx2 = new RSFACAR())
                    {

                        ctx.Entry(ADDM).State = EntityState.Modified;
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
            }

        }


        //nuevo sergio 20/04/2016
        public static List<AL0003ARTI> ListarArticulosxestado(string estado)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos = (from x in ctx.AL0003ARTI

                               where (estado == "T" ? (x.AR_CCONTRO != estado && x.AR_CCONTRO != "") : x.AR_CCONTRO == estado) && x.AR_CESTADO == "V" && x.AR_CLINEA == "R"
                               select new
                               {
                                   AR_CCODIGO = x.AR_CCODIGO,
                                   AR_CDESCRI = x.AR_CDESCRI,
                                   AR_CUNIDAD = x.AR_CUNIDAD,
                                   AR_NPRECOM = x.AR_NPRECOM,
                                   AR_CMONCOM = x.AR_CMONCOM,
                                   AR_CPARARA = x.AR_CPARARA,
                                   AR_CCONTRO = x.AR_CCONTRO,
                                   AR_CUSUCRE = x.AR_CUSUCRE,
                                   AR_CCODPRO = x.AR_CCODPRO
                               }).ToList().Select(c => new AL0003ARTI()
                               {
                                   AR_CCODIGO = c.AR_CCODIGO,
                                   AR_CDESCRI = c.AR_CDESCRI,
                                   AR_CUNIDAD = c.AR_CUNIDAD,
                                   AR_NPRECOM = Convert.ToDecimal(string.Format("{0:00.0000}", c.AR_NPRECOM)),
                                   AR_CMONCOM = c.AR_CMONCOM,
                                   AR_CPARARA = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? "" : tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_DESC,
                                   AR_CCONTRO = c.AR_CCONTRO == "S" ? "SIN APROB" : "APROB",
                                   AR_CUSUCRE = c.AR_CUSUCRE,
                                   AR_CCODPRO = (CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()) == null ? "" : CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()).ADESANE)

                               }
                        ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static void ActualizaARestado(AL0003ARTI AINF)
        {
            using (RSFACAR ctx = new RSFACAR())
            {
                var ACDAt = (from c in ctx.AL0003ARTI where c.AR_CCODIGO.Trim() == AINF.AR_CCODIGO.Trim() select c).FirstOrDefault();
                ctx.Entry(ACDAt).State = EntityState.Modified;
                ACDAt.AR_CCONTRO = AINF.AR_CCONTRO;
                try
                {
                    ctx.SaveChanges();
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
                }
            }
        }


        public static void ActualizaARcuenta(AL0003ARTI AINF)
        {
            using (RSFACAR ctx = new RSFACAR())
            {
                var ACDAt = (from c in ctx.AL0003ARTI where c.AR_CCODIGO.Trim() == AINF.AR_CCODIGO.Trim() select c).FirstOrDefault();
                ctx.Entry(ACDAt).State = EntityState.Modified;
                ACDAt.AR_CCUENTA = AINF.AR_CCUENTA;
                ACDAt.AR_CINFTEC = AINF.AR_CINFTEC;
                try
                {
                    ctx.SaveChanges();
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
                }
            }
        }

        public static string Obtenernaprobaxarea(string codarticulo)
        {
            var datar1 = "";
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //datar1 = ctx.AL0003ARTI.Where(x => x.AR_CCODIGO == codarticulo).Select(aa => tabla_subareas.Nvalidaareas(aa.AR_CPARARA).SA_NAPROB.ToString()).ToString();
                    var aax = (from c in ctx.AL0003ARTI.Where(x => x.AR_CCODIGO == codarticulo)
                               select new
                               {
                                   AR_CPARARA = c.AR_CPARARA
                               }

                         ).ToList().Select(c => new AL0003ARTI()
                         {
                             AR_CPARARA = tabla_subareas.Nvalidaareas(c.AR_CPARARA).SA_NAPROB.ToString()

                         }).FirstOrDefault();
                    datar1 = aax.AR_CPARARA;

                }
            }
            catch
            {
                datar1 = "";
            }
            return datar1;
        }

        //nuevo sergio 22042016

        public static List<AL0003ARTI> Tarifario(string estado)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos = (from x in ctx.AL0003ARTI

                               where (estado == "T" ? x.AR_CCONTRO != estado : x.AR_CCONTRO == estado) && x.AR_CESTADO == "V" && x.AR_CLINEA == "R"
                               select new
                               {
                                   AR_CCODIGO = x.AR_CCODIGO,
                                   AR_CDESCRI = x.AR_CDESCRI,
                                   AR_CUNIDAD = x.AR_CUNIDAD,
                                   AR_NPRECOM = x.AR_NPRECOM,
                                   AR_CMONCOM = x.AR_CMONCOM,
                                   AR_CPARARA = x.AR_CPARARA,
                                   AR_CCONTRO = x.AR_CCONTRO,
                                   AR_CTIPDES = x.AR_CTIPDES,
                                   AR_CINFTEC = x.AR_CINFTEC,
                                   AR_CUSUCRE = x.AR_CUSUCRE,
                                   AR_CCUENTA = x.AR_CCUENTA,
                                   AR_CCODPRO = x.AR_CCODPRO
                               }).ToList().Select(c => new AL0003ARTI()
                               {
                                   AR_CCODIGO = c.AR_CCODIGO,
                                   AR_CDESCRI = c.AR_CDESCRI,
                                   AR_CUNIDAD = c.AR_CUNIDAD,
                                   AR_NPRECOM = c.AR_NPRECOM,
                                   AR_CMONCOM = c.AR_CMONCOM,
                                   AR_CPARARA = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? "" : tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_DESC,
                                   AR_CCONTRO = c.AR_CCONTRO,//estado 
                                   AR_CTIPDES = c.AR_CTIPDES, //tipo tarifa fija o variable 
                                   AR_CINFTEC = UT0030.Mostrarunusuario(c.AR_CINFTEC), //usuario que asigno cuenta  
                                   AR_CUSUCRE = UT0030.Mostrarunusuario(c.AR_CUSUCRE),
                                   AR_CCUENTA = c.AR_CCUENTA,
                                   AR_CCODPRO = (CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()) == null ? "" : CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()).ADESANE)
                               }
                        ).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        //nuevo 22042016

        public static List<AL0003ARTI> ListarServicios(string texto, string tipop, string subtip, string idsuario, string codprov,string tipolinea)
        {
            var articu = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    var narea = tabla_d_areausua.Listarsubareasxusua(idsuario);
                    int contt = 0;
                    string[] filtroxareausua = new string[narea.Count()];
                    foreach (var c in narea)
                    {
                        filtroxareausua[contt] = c.SA_ID.ToString();
                        contt++;
                    }
                    List<AL0003ARTI> Listaprodxprov = new List<AL0003ARTI>();

                    Listaprodxprov = ctx.AL0003ARTI.Where(x => x.AR_CCODPRO.Trim() == codprov.Trim() && x.AR_CESTADO == "V" &&
                   (subtip == "2" ? (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA != "R") : (x.AR_CLINEA == "R"  //&& x.AR_CCONTRO == "A"
                   && filtroxareausua.Contains(x.AR_CPARARA.Trim())))).ToList(); //&& x.AR_CCONTRO == "A"

                    if (Listaprodxprov.Count() > 0 && subtip != "2")
                    {
                        articu = ctx.AL0003ARTI.Where(x => x.AR_CCODPRO == codprov && x.AR_CESTADO == "V" &&
                        (subtip == "2" ? (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA != "R") : (x.AR_CLINEA == "R" //&& x.AR_CCONTRO == "A"
                        && filtroxareausua.Contains(x.AR_CPARARA.Trim())))).ToList(); //&& x.AR_CCONTRO == "A"
                    }
                    else {
                        articu = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CESTADO == "V" &&
                        //&& (tipolinea=="R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R") && 
                        //(subtip == "2" ? (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA != "R") : (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim()))) //&& x.AR_CCONTRO == "A"
                         (subtip == "2" ? (tipolinea == "R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R") : ((tipolinea == "R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R") && filtroxareausua.Contains(x.AR_CPARARA.Trim())) )
                        //&& x.AR_CCONTRO == "A"
                        ).ToList();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return articu;
        }

        public static List<AL0003ARTI> Listanrepeticiones(string descr, string idprovee, decimal tarifa)
        {
            List<AL0003ARTI> lisresp = new List<AL0003ARTI>();
            using (var ctx = new RSFACAR())
            {
                lisresp = (from c in ctx.AL0003ARTI
                           where c.AR_CCODPRO.Trim() == idprovee.Trim()
  && c.AR_CDESCRI.ToUpper().Replace(" ", "").Replace(".", "").Replace(",", "") == descr.ToUpper().Replace(" ", "").Replace(".", "").Replace(",", "")
  && c.AR_NPRECOM == tarifa
                           select c).ToList();
            }
            return lisresp;
        }

        //nuevo sergio 27/04/2016
        public static List<AL0003ARTI> ListarServparaVBF(string estado)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    using (var ctxa = new ANEXO_RSFACAR())
                    {
                        alumnos = (from x in ctx.AL0003ARTI

                                   where (estado == "T" ? (x.AR_CCONTRO != estado && x.AR_CCONTRO != "") : x.AR_CCONTRO == estado) && x.AR_CESTADO == "V" && x.AR_CLINEA == "R"
                                   //&& ((tabla_subareas.Nvalidaareas(x.AR_CPARARA.Trim()).SA_NAPROB) - 1) == 1 && tabla_d_usuaprod.AprobacionxProducto("R050870002000").Count() 
                                   select new
                                   {
                                       AR_CCODIGO = x.AR_CCODIGO,
                                       AR_CDESCRI = x.AR_CDESCRI,
                                       AR_CUNIDAD = x.AR_CUNIDAD,
                                       AR_NPRECOM = x.AR_NPRECOM,
                                       AR_CMONCOM = x.AR_CMONCOM,
                                       AR_CPARARA = x.AR_CPARARA,
                                       AR_CCONTRO = x.AR_CCONTRO,
                                       AR_CUSUCRE = x.AR_CUSUCRE,
                                       AR_CCODPRO = x.AR_CCODPRO,
                                       AR_NMARGE2 = x.AR_CPARARA
                                   }).ToList().Select(c => new AL0003ARTI()
                                   {
                                       AR_CCODIGO = c.AR_CCODIGO,
                                       AR_CDESCRI = c.AR_CDESCRI,
                                       AR_CUNIDAD = c.AR_CUNIDAD,
                                       AR_NPRECOM = Convert.ToDecimal(string.Format("{0:00.0000}", c.AR_NPRECOM)),
                                       AR_CMONCOM = c.AR_CMONCOM,
                                       AR_CPARARA = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? "" : tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_DESC,
                                       AR_CCONTRO = c.AR_CCONTRO == "S" ? "SIN APROB" : "APROB",
                                       AR_CUSUCRE = c.AR_CUSUCRE,
                                       AR_CCODPRO = (CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()) == null ? "" : CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()).ADESANE),
                                       AR_NMARGE2 = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? 0 : Convert.ToDecimal(tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_NAPROB) - tabla_d_usuaprod.AprobacionxProducto(c.AR_CCODIGO).Count()
                                   }
                            ).ToList();
                    }
                }
            }
            catch
            {

                throw;
            }

            return alumnos;
        }




    }
}
