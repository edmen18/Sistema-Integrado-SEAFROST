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

    public class vista_AL0003ARTI
    {
        public string AR_CCODIGO { get; set; }
        public string AR_CDESCRI { get; set; }

        public decimal? AR_NPRECI1 { get; set; }
        public decimal? AR_NPRECI2 { get; set; }
        public decimal? AR_NPRECI3 { get; set; }
        public string AR_CTIPDES { get; set; }
    }
    public partial class AL0003ARTI
    {
        [Key]
        [StringLength(25)]
        public string AR_CCODIGO { get; set; }


        [StringLength(60)]
        public string AR_CDESCRI { get; set; }

        [StringLength(60)]
        public string AR_CDESCR2 { get; set; }

        [StringLength(25)]
        public string AR_CCODIG2 { get; set; }


        [StringLength(3)]
        public string AR_CUNIDAD { get; set; }


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


        [StringLength(2)]
        public string AR_CMONVTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NISCPOR { get; set; }


        [StringLength(1)]
        public string AR_CTIPO { get; set; }


        [StringLength(1)]
        public string AR_CCONTRO { get; set; }


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


        [StringLength(8)]
        public string AR_CGRUPO { get; set; }


        [StringLength(8)]
        public string AR_CFAMILI { get; set; }


        [StringLength(8)]
        public string AR_CMODELO { get; set; }


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


        [StringLength(2)]
        public string AR_CMONCOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECOS { get; set; }

        public DateTime? AR_DFECCOS { get; set; }


        [StringLength(2)]
        public string AR_CMONCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPRECOM { get; set; }

        public DateTime? AR_DFECCOM { get; set; }


        [StringLength(18)]
        public string AR_CCODPRO { get; set; }


        [StringLength(2)]
        public string AR_CMONFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPREFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE2 { get; set; }


        [StringLength(3)]
        public string AR_CCLAART { get; set; }


        [StringLength(15)]
        public string AR_CPARARA { get; set; }


        [StringLength(50)]
        public string AR_CINFTEC { get; set; }


        [StringLength(50)]
        public string AR_CCATALO { get; set; }


        [StringLength(2)]
        public string AR_CCATEGO { get; set; }


        [StringLength(2)]
        public string AR_CTIPOI { get; set; }


        [StringLength(800)]
        public string AR_TOBSERV { get; set; }


        [StringLength(3)]
        public string AR_CUNIREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NFACREF { get; set; }


        [StringLength(1)]
        public string AR_CFUNIRE { get; set; }


        [StringLength(1)]
        public string AR_CFSTOCK { get; set; }


        [StringLength(1)]
        public string AR_CFDECI { get; set; }


        [StringLength(1)]
        public string AR_CFPRELI { get; set; }


        [StringLength(1)]
        public string AR_CFRESTA { get; set; }


        [StringLength(1)]
        public string AR_CFSERIE { get; set; }


        [StringLength(1)]
        public string AR_CFLOTE { get; set; }


        [StringLength(1)]
        public string AR_CFROTAB { get; set; }


        [StringLength(5)]
        public string AR_CUSUCRE { get; set; }


        [StringLength(5)]
        public string AR_CUSUMOD { get; set; }


        [StringLength(1)]
        public string AR_CESTADO { get; set; }

        public DateTime? AR_DFECCRE { get; set; }

        public DateTime? AR_DFECMOD { get; set; }


        [StringLength(25)]
        public string AR_CCODANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NDETRA { get; set; }


        [StringLength(6)]
        public string AR_CMEDIDA { get; set; }


        [StringLength(9)]
        public string AR_CANNO { get; set; }


        [StringLength(15)]
        public string AR_CGROSOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIMAGEN { get; set; }


        [StringLength(6)]
        public string AR_CFECABC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NLONSER { get; set; }


        [StringLength(1)]
        public string AR_CFCELU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NLONCEL { get; set; }


        [StringLength(12)]
        public string AR_CMEDNEU { get; set; }


        [StringLength(12)]
        public string AR_CINDCAR { get; set; }


        [StringLength(12)]
        public string AR_CDISENO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPERC1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NPERC2 { get; set; }


        [StringLength(8)]
        public string AR_CMARCA { get; set; }


        [StringLength(4)]
        public string AR_CANOFAB { get; set; }


        [StringLength(8)]
        public string AR_CLUGORI { get; set; }


        [StringLength(1)]
        public string AR_CFVEHI { get; set; }


        [StringLength(1)]
        public string AR_CAYUVEN { get; set; }


        [StringLength(20)]
        public string AR_CCOLOR { get; set; }


        [StringLength(20)]
        public string AR_CTALLA { get; set; }


        [StringLength(4)]
        public string AR_CTIPEXI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NMARVTA { get; set; }


        [StringLength(10)]
        public string AR_CHORSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NIGVCPR { get; set; }


        [StringLength(12)]
        public string AR_CCUENTR { get; set; }


        [StringLength(1)]
        public string AR_CFLGRCN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AR_NTASRCN { get; set; }


        [StringLength(18)]
        public string AR_CFORSER { get; set; }


        [StringLength(8)]
        public string AR_CCODAG1 { get; set; }


        [StringLength(8)]
        public string AR_CCODAG2 { get; set; }


        [StringLength(8)]
        public string AR_CCODAG3 { get; set; }


        [StringLength(8)]
        public string AR_CCODAG4 { get; set; }


        [StringLength(8)]
        public string AR_CCODAG5 { get; set; }


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

        public static List<AL0003ARTI> ListarArticulosParaKardex(string cod1, string cod2)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<AL0003ARTI>("select * from  AL0003ARTI  where AR_CLINEA!='R' and AR_CCODIGO between @cod1 and @cod2 order by rtrim(ltrim(AR_CCODIGO))",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2)).ToList();
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

        //public static List<AL0003ARTI> ListarArticulosPorHistorial(string texto)
        //{
        //    var alumnos = new List<AL0003ARTI>();

        //    try
        //    {
        //        using (var ctx = new RSFACAR())
        //        {
        //            alumnos = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CESTADO == "V")
        //                             .Select(c=> new
        //                             {
        //                                 AR_CCODIGO = c.AR_CCODIGO,
        //                                 AR_CDESCRI = c.AR_CDESCRI//,

        //                                 //OC_NPREUN2 =
        //                                 //  (
        //                                 //     ctx.CO0003MOVC.Join(ctx.CO0003MOVD, x => x.OC_CNUMORD, cm => cm.OC_CNUMORD, (x, cm) => new { CO0003MOVC = x, CO0003MOVD = cm }).Where(cm => cm.CO0003MOVD.OC_CCODIGO.Trim() == c.AR_CCODIGO.Trim()).OrderByDescending(x => x.CO0003MOVC.OC_DFECDOC).Take(1).FirstOrDefault().CO0003MOVD.OC_NPREUN2
        //                                 //  )

        //                                   //,
        //                                 //OC_NTIPCAM =
        //                                 //  (
        //                                 //     ctx.CO0003MOVC.Join(ctx.CO0003MOVD, x => x.OC_CNUMORD, cm => cm.OC_CNUMORD, (x, cm) => new { CO0003MOVC = x, CO0003MOVD = cm }).Where(cm => cm.CO0003MOVD.OC_CCODIGO.Trim() == c.AR_CCODIGO.Trim()).OrderByDescending(x => x.CO0003MOVC.OC_DFECDOC).Take(1).FirstOrDefault().CO0003MOVC.OC_NTIPCAM
        //                                 //  ),
        //                                 //OC_NIMPMN =
        //                                 //  (
        //                                 //     ctx.CO0003MOVC.Join(ctx.CO0003MOVD, x => x.OC_CNUMORD, cm => cm.OC_CNUMORD, (x, cm) => new { CO0003MOVC = x, CO0003MOVD = cm }).Where(cm => cm.CO0003MOVD.OC_CCODIGO.Trim() == c.AR_CCODIGO.Trim()).OrderByDescending(x => x.CO0003MOVC.OC_DFECDOC).Take(1).FirstOrDefault().CO0003MOVC.OC_NIMPMN
        //                                 //  )
        //                             } ).ToList().Select(c => new AL0003ARTI()
        //        {
        //            AR_CCODIGO = c.AR_CCODIGO,
        //            AR_CDESCRI = c.AR_CDESCRI,

        //            AR_CTIPDES = CO0003MOVC.UltimolPrecioPorProducto(c.AR_CCODIGO.Trim()).OC_CCODMON,
        //            AR_NPRECI2 = CO0003MOVC.UltimolPrecioPorProducto(c.AR_CCODIGO.Trim()).OC_NTIPCAM,
        //            AR_NPRECI3 = CO0003MOVC.UltimolPrecioPorProducto(c.AR_CCODIGO.Trim()).OC_NIMPMN

        //                                 //AR_NPRECI3 = c.OC_NIMPMN



        //                             }).ToList();

        //            return alumnos;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }


        //}

        public static List<AL0003ARTI> ListarArticulosforma2(string texto, string tipop, string subtip, string tipolinea)
        {
            var articu = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    articu = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CESTADO == "V" &&
                    //((tipop =="S" && subtip == "1") ? x.AR_CLINEA=="R": x.AR_CLINEA != "" ) 
                     (tipolinea == "R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R")
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


        public static List<AL0003ARTI> ListarArticulosIDxOC(string texto, string tipolin)
        {
            var alumnos = new List<AL0003ARTI>();
            //vista_produautocom
            try
            {
                using (var ctx = new RSFACAR())
                {   //AR_CESTADO->A: ANULUADO B:BLOQUEADO S:SALDADO V:VIGENTE
                    alumnos = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CCODIGO) > 0
                    && x.AR_CESTADO == "V" 
                    && (tipolin == "R" ? x.AR_CLINEA == "R" : x.AR_CLINEA != "R")
                    && (tipolin == "R" ? x.AR_CCONTRO.Trim() == "A" : x.AR_CCONTRO != "D")
                    ).ToList();

                    //alumnos = (from x in ctx.AL0003ARTI join r in ctx.AL0003STOC on x.AR_CCODIGO equals r.SK_CCODIGO where SqlFunctions.PatIndex(texto, x.AR_CCODIGO) > 0 
                    //           && x.AR_CESTADO == "V" 
                    //           && (tipolin == "R" ? x.AR_CLINEA == "R" : x.AR_CLINEA != "R") 
                    //           && r.SK_NSKDIS > 0 
                    //           select x).ToList();

                    //alumnos = (from  x in ctx.AL0003ARTI where SqlFunctions.PatIndex(texto, x.AR_CCODIGO) > 0 && x.AR_CESTADO == "V" && (tipolin == "R" ? x.AR_CLINEA == "R" : x.AR_CLINEA != "R")
                    //           select new {
                    //               data1=x.AR_CDESCRI,
                    //               data2 = x.AR_CCODIGO,
                    //               data3 = x.AR_CUNIDAD,
                    //               data4 = x.AR_NIGVCPR,
                    //               data5 = x.AR_CTIPDES,
                    //               data6 = x.AR_NPRECOM,
                    //               data7 = x.AR_CCONTRO
                    //           }
                    //           ).ToList().Select(v=> new Cls_articulos() {
                    //               AR_CDESCRI = v.data1,
                    //               AR_CCODIGO = v.data2,
                    //               AR_CUNIDAD = v.data3,
                    //               AR_NIGVCPR = v.data4,
                    //               AR_CTIPDES = v.data5,
                    //               AR_NPRECOM = v.data6,
                    //               AR_CCONTRO = v.data7 
                    //           }).ToList();
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

            if (articulo.Count() == 0)
            {
                using (var ctx = new RSFACAR())
                {
                    articulo = (from c in ctx.AL0003ARTI
                                where
                                  (SqlFunctions.PatIndex(TEXTO, c.AR_CDESCRI) > 0 && c.AR_CESTADO == "V") 
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
                return articulo;
            }
            else
            {
                return articulo;
            }


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
        public static List<vista_movart> MovArticulos(vista_movart DATA)
        {
            var alumnos = new List<vista_movart>();
            try
            {

                using (var ctx = new RSFACAR())
                {

                    alumnos = (from A in ctx.AL0003ARTI
                               join M in ctx.AL0003MOVD on new { AR_CCODIGO = A.AR_CCODIGO } equals new { AR_CCODIGO = M.C6_CCODIGO }
                               where
                                 A.AR_CCODIGO == DATA.AR_CCODIGO &&
                                 M.C6_CALMA == DATA.C6_CALMA && M.C6_CSITUA.Trim() != "A"
                               orderby
                                 M.C6_DFECDOC
                               select new
                               {
                                   data1 = A.AR_CCODIGO,
                                   data2 = M.C6_CALMA,
                                   data3 = A.AR_CDESCRI,
                                   data4 = A.AR_CUNIDAD,
                                   data5 = M.C6_DFECDOC,
                                   data6 = M.C6_CTD,
                                   data7 = M.C6_CNUMDOC,
                                   data8 = M.C6_CCODMOV,
                                   data11 = M.C6_CCODMON,
                                   data12 = M.C6_NMNPRUN,
                                   data14 = M.C6_CNUMDOC,
                                   data9 = M.C6_NCANTID,
                                   data16 = A.AR_CFSERIE,
                                   data17 = A.AR_CFLOTE,


                                   data10 = ((from b in ctx.AL0003ASER
                                              where b.C6_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && b.C6_CALMA == M.C6_CALMA
                                               && b.C6_CNUMDOC == M.C6_CNUMDOC && M.C6_CITEM == b.C6_CITEM
                                               && b.C6_NCANTID == M.C6_NCANTID
                                              select new { b.C6_CSERIE }).FirstOrDefault().C6_CSERIE),

                                   //TDR = ((from b in ctx.AL0003MOVG
                                   //        where b.C6_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && b.C6_CALMA == M.C6_CALMA
                                   //         && b.C6_CNUMDOC == M.C6_CNUMDOC && b.C6_DFECDOC == M.C6_DFECDOC
                                   //        select new { b.C6_CRFTDOC }).FirstOrDefault().C6_CRFTDOC),

                                   //proveedor = ((from b in ctx.AL0003MOVG
                                   //              where b.C6_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && b.C6_CALMA == M.C6_CALMA
                                   //               && b.C6_CNUMDOC == M.C6_CNUMDOC && b.C6_DFECDOC == M.C6_DFECDOC
                                   //              select new { b.C6_CCODPRO }).FirstOrDefault().C6_CCODPRO),

                                   //REFERENCIA = ((from b in ctx.AL0003MOVG
                                   //               where b.C6_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && b.C6_CALMA == M.C6_CALMA
                                   //                && b.C6_CNUMDOC == M.C6_CNUMDOC && b.C6_DFECDOC == M.C6_DFECDOC
                                   //               select new { b.C6_CRFNDOC }).FirstOrDefault().C6_CRFNDOC),

                                   //SERIE = ((from b in ctx.AL0003MOVG
                                   //          where b.C6_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && b.C6_CALMA == M.C6_CALMA
                                   //           && b.C6_CNUMDOC == M.C6_CNUMDOC && b.C6_DFECDOC == M.C6_DFECDOC
                                   //          select new { b.C6_CSERIE }).FirstOrDefault().C6_CSERIE),

                                   TDR = ((from ARTI in ctx.AL0003ARTI
                                           join D in ctx.AL0003MOVD on new { C6_CCODIGO = ARTI.AR_CCODIGO } equals new { C6_CCODIGO = D.C6_CCODIGO }
                                           join C in ctx.AL0003MOVC on new { C5_CNUMDOC = D.C6_CNUMDOC } equals new { C5_CNUMDOC = C.C5_CNUMDOC }
                                           where ARTI.AR_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && D.C6_CALMA == M.C6_CALMA
                                            && M.C6_CNUMDOC == C.C5_CNUMDOC && M.C6_DFECDOC == C.C5_DFECDOC
                                           select new { C.C5_CRFTDOC }).FirstOrDefault().C5_CRFTDOC),

                                   proveedor = ((from ARTI in ctx.AL0003ARTI
                                                 join D in ctx.AL0003MOVD on new { C6_CCODIGO = ARTI.AR_CCODIGO } equals new { C6_CCODIGO = D.C6_CCODIGO }
                                                 join C in ctx.AL0003MOVC on new { C5_CNUMDOC = D.C6_CNUMDOC } equals new { C5_CNUMDOC = C.C5_CNUMDOC }
                                                 where ARTI.AR_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && D.C6_CALMA == M.C6_CALMA
                                                  && M.C6_CNUMDOC == C.C5_CNUMDOC && M.C6_DFECDOC == C.C5_DFECDOC
                                                 select new { C.C5_CCODPRO }).FirstOrDefault().C5_CCODPRO),

                                   REFERENCIA = ((from ARTI in ctx.AL0003ARTI
                                                  join D in ctx.AL0003MOVD on new { C6_CCODIGO = ARTI.AR_CCODIGO } equals new { C6_CCODIGO = D.C6_CCODIGO }
                                                  join C in ctx.AL0003MOVC on new { C5_CNUMDOC = D.C6_CNUMDOC } equals new { C5_CNUMDOC = C.C5_CNUMDOC }
                                                  where ARTI.AR_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && D.C6_CALMA == M.C6_CALMA
                                                  && M.C6_CNUMDOC == C.C5_CNUMDOC && M.C6_DFECDOC == C.C5_DFECDOC
                                                  select new { C.C5_CRFNDOC }).FirstOrDefault().C5_CRFNDOC),

                                   SERIE = ((from ARTI in ctx.AL0003ARTI
                                             join D in ctx.AL0003MOVD on new { C6_CCODIGO = ARTI.AR_CCODIGO } equals new { C6_CCODIGO = D.C6_CCODIGO }
                                             join C in ctx.AL0003MOVC on new { C5_CNUMDOC = D.C6_CNUMDOC } equals new { C5_CNUMDOC = C.C5_CNUMDOC }
                                             where ARTI.AR_CCODIGO.Trim() == A.AR_CCODIGO.Trim() && D.C6_CALMA == M.C6_CALMA
                                             && M.C6_CNUMDOC == C.C5_CNUMDOC && M.C6_DFECDOC == C.C5_DFECDOC
                                             select new { D.C6_CSERIE }).FirstOrDefault().C6_CSERIE),

                                   data13 = ((from b in ctx.AL0003TABL
                                              where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == M.C6_CCENCOS
                                              select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                                   data15 = ((from b in ctx.AL0003TABL
                                              where b.TG_CCOD.Trim() == "12" && b.TG_CCLAVE.Trim() == M.C6_CSOLI
                                              select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),


                               }).ToList()
                           .Select(c => new vista_movart()
                           {
                               AR_CCODIGO = c.data1,
                               C6_CALMA = c.data2,
                               AR_CDESCRI = c.data3,
                               AR_CUNIDAD = c.data4,
                               C6_DFECDOC = Convert.ToDateTime(c.data5),
                               C6_CTD = c.data6,
                               C6_CNUMDOC = c.data7,
                               C6_CCODMOV = c.data8,
                               CANTENT = Convert.ToDecimal(c.data9),
                               CANSAL = Convert.ToDecimal(c.data9),
                               C6_CCODMON = c.data11,
                               C6_NMNPRUN = Convert.ToDecimal(c.data12),
                               CCOSTO = c.data13,
                               SOLICITANTE = c.data15,
                               TDR = c.TDR,
                               REFERENCIA = c.REFERENCIA,
                               SERIE = c.SERIE,
                               PROVEEDOR = CT0003ANEX.obtenProveedorED(c.proveedor).ADESANE,
                               LOTE = c.data10,
                               AR_CFSERIE = c.data16,
                               AR_CFLOTE = c.data17,
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<vista_movart> MovArticulosent(vista_movart DATA)
        {
            var alumnos = new List<vista_movart>();
            try
            {

                using (var ctx = new RSFACAR())
                {

                    alumnos = (from A in ctx.AL0003ARTI
                               join M in ctx.AL0003MOVD on new { AR_CCODIGO = A.AR_CCODIGO } equals new { AR_CCODIGO = M.C6_CCODIGO }
                               where
                                 A.AR_CCODIGO == DATA.AR_CCODIGO &&
                                 M.C6_CALMA == DATA.C6_CALMA
                               orderby
                                 M.C6_DFECDOC
                               select new
                               {
                                   serie = A.AR_CFSERIE,
                                   unidad = A.AR_CUNIDAD,
                                   entradas = (from M in (from M in ctx.AL0003MOVD
                                                          where M.C6_CCODIGO == DATA.AR_CCODIGO && M.C6_CALMA == DATA.C6_CALMA
                                                          && M.C6_CTD == "PE"
                                                          select new
                                                          {
                                                              M.C6_NCANTID,
                                                              Dummy = "x"
                                                          })
                                               group M by new { M.Dummy } into g
                                               select new
                                               {
                                                   Column1 = (decimal?)g.Sum(p => p.C6_NCANTID)
                                               }).FirstOrDefault().Column1,

                                   salidas = (from M in (from M in ctx.AL0003MOVD
                                                         where M.C6_CCODIGO == DATA.AR_CCODIGO && M.C6_CALMA == DATA.C6_CALMA
                                                         && M.C6_CTD == "PS"
                                                         select new
                                                         {
                                                             M.C6_NCANTID,
                                                             Dummy = "x"
                                                         })
                                              group M by new { M.Dummy } into g
                                              select new
                                              {
                                                  Column1 = (decimal?)g.Sum(p => p.C6_NCANTID)
                                              }).FirstOrDefault().Column1,


                               }).ToList()
                           .Select(c => new vista_movart()
                           {
                               entradas = Convert.ToDecimal(c.entradas),
                               salidas = Convert.ToDecimal(c.salidas),
                               AR_CUNIDAD = c.unidad,
                               SERIE = c.serie,

                           }).ToList();
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
                    rvalor = ctx.AL0003ARTI.Where(x => x.AR_CLINEA.Trim() == linea).OrderByDescending(ob => ob.AR_CCODIGO).FirstOrDefault().AR_CCODIGO;
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
        public static List<AL0003ARTI> ListarArticulosxestado(string estado, string area)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos = (from x in ctx.AL0003ARTI

                               where
                               (estado == "T" ? (x.AR_CCONTRO != estado && x.AR_CCONTRO != "") : x.AR_CCONTRO == estado)
                               && x.AR_CESTADO == "V" && x.AR_CLINEA.Trim() == "R"
                               && (area.Trim() == "" ? x.AR_CPARARA.Trim() != "" : x.AR_CPARARA.Trim() == area.Trim())
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
                                   AR_CDESCRI = c.AR_CDESCRI.ToUpper(),
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
                ACDAt.AR_CFORSER = AINF.AR_CFORSER;
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

                               where (estado == "T" ? x.AR_CCONTRO != estado : x.AR_CCONTRO == estado) && x.AR_CESTADO == "V" && x.AR_CLINEA.Trim() == "R"
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

        public static List<AL0003ARTI> ListarServicios(string texto, string tipop, string subtip, string idsuario, string codprov, string tipolinea)
        {
            var articu = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    var narea = tabla_d_areausua.Listarsubareasxusua(idsuario, 1);
                    int contt = 0;
                    string[] filtroxareausua = new string[narea.Count()];
                    foreach (var c in narea)
                    {
                        filtroxareausua[contt] = c.SA_ID.ToString();
                        contt++;
                    }
                    List<AL0003ARTI> Listaprodxprov = new List<AL0003ARTI>();

                    Listaprodxprov = ctx.AL0003ARTI.Where(x => x.AR_CCODPRO.Trim() == codprov.Trim() && x.AR_CESTADO == "V" &&
                   (subtip == "2" ? (x.AR_CLINEA.Trim() == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA.Trim() != "R") : (x.AR_CLINEA.Trim() == "R"  //&& x.AR_CCONTRO == "A"
                   && filtroxareausua.Contains(x.AR_CPARARA.Trim())))).ToList(); //&& x.AR_CCONTRO == "A"

                    if (Listaprodxprov.Count() > 0 && subtip != "2")
                    {
                        articu = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CCODPRO.Trim() == codprov.Trim() && x.AR_CESTADO == "V" &&
                        (tipolinea == "R" ? x.AR_CCONTRO == "A" : x.AR_CESTADO == "V") &&
                        (subtip == "2" ?
                        (x.AR_CLINEA.Trim() == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA.Trim() != "R") :
                        (x.AR_CLINEA.Trim() == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim()))
                        )).ToList(); //&& x.AR_CCONTRO == "A"
                    } else {
                        articu = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0 && x.AR_CESTADO == "V" &&
                        (tipolinea == "R" ? x.AR_CCONTRO == "A" : x.AR_CESTADO == "V")  && 
                        //&& (tipolinea=="R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R") && 
                        //(subtip == "2" ? (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim())) || (x.AR_CLINEA != "R") : (x.AR_CLINEA == "R" && filtroxareausua.Contains(x.AR_CPARARA.Trim()))) //&& x.AR_CCONTRO == "A"
                         ((subtip == "2" || subtip == "5" || subtip == "7" || subtip == "4") ? (tipolinea == "R" ? (x.AR_CLINEA.Trim() == tipolinea && (x.AR_CPARARA.Trim() == "5" || x.AR_CPARARA.Trim() == "13" || x.AR_CPARARA.Trim() == "8" || x.AR_CPARARA.Trim() == "9")) : x.AR_CLINEA.Trim() != "R") :
                         ((tipolinea == "R" ? x.AR_CLINEA.Trim() == tipolinea : x.AR_CLINEA.Trim() != "R") && filtroxareausua.Contains(x.AR_CPARARA.Trim()) && x.AR_CPARARA.Trim() != "5" && x.AR_CCODPRO == "")
                         )
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
        public static List<AL0003ARTI> ListarServparaVBF(string estado, string area)
        {
            var alumnos = new List<AL0003ARTI>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    using (var ctxa = new ANEXO_RSFACAR())
                    {
                        alumnos = (from x in ctx.AL0003ARTI

                                   where (estado == "T" ? (x.AR_CCONTRO != estado && x.AR_CCONTRO != "") : x.AR_CCONTRO == estado) && x.AR_CESTADO == "V" && x.AR_CLINEA.Trim() == "R"
                                   //&& ((tabla_subareas.Nvalidaareas(x.AR_CPARARA.Trim()).SA_NAPROB) - 1) == 1 && tabla_d_usuaprod.AprobacionxProducto("R050870002000").Count() 
                                   && (area.Trim() == "" ? x.AR_CPARARA.Trim() != "" : x.AR_CPARARA.Trim() == area.Trim())
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
                                       AR_CDESCRI = c.AR_CDESCRI.ToUpper(),
                                       AR_CUNIDAD = c.AR_CUNIDAD,
                                       AR_NPRECOM = Convert.ToDecimal(string.Format("{0:00.0000}", c.AR_NPRECOM)),
                                       AR_CMONCOM = c.AR_CMONCOM,
                                       AR_CPARARA = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? "" : tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_DESC,
                                       AR_CCONTRO = c.AR_CCONTRO == "S" ? "SIN APROB" : "APROB",
                                       AR_CUSUCRE = c.AR_CUSUCRE,
                                       AR_CCODPRO = (CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()) == null ? "" : CT0003ANEX.obtenProveedor(c.AR_CCODPRO.Trim()).ADESANE),
                                       AR_NMARGE2 = tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()) == null ? 0 : Convert.ToDecimal(tabla_subareas.Nvalidaareas(c.AR_CPARARA.ToString()).SA_NAPROB) - tabla_d_usuaprod.AprobacionxProducto(c.AR_CCODIGO, 1).Count()
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
