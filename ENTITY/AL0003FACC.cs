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
    using System.Data.SqlClient;
    using System.Data.Entity.SqlServer;
    using CapaNegocio;
   
    public partial class AL0003FACC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string LC_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string LC_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(20)]
        public string LC_CNUMDOC { get; set; }

        public DateTime? LC_DFECCOM { get; set; }

        public DateTime? LC_DFECDOC { get; set; }

        public DateTime? LC_DFECVEN { get; set; }


        [StringLength(1)]
        public string LC_CDH { get; set; }


        [StringLength(5)]
        public string LC_CVENDE { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CNROCAJ { get; set; }

        [Required]
        [StringLength(1)]
        public string LC_CVANEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string LC_CCODPRV { get; set; }

        [Required]
        [StringLength(50)]
        public string LC_CNOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string LC_CDIRECC { get; set; }

        [Required]
        [StringLength(18)]
        public string LC_CRUC { get; set; }


        [StringLength(15)]
        public string LC_CCHENUM { get; set; }

        [Required]
        [StringLength(4)]
        public string LC_CSUBDIA { get; set; }

        [Required]
        [StringLength(6)]
        public string LC_CCOMPRO { get; set; }

        [Required]
        [StringLength(4)]
        public string LC_CALMA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPORT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPRET { get; set; }

        [Required]
        [StringLength(30)]
        public string LC_CFORVEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NSALDO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NIMPIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NTIPCAM { get; set; }

        [Required]
        [StringLength(1)]
        public string LC_CTIPO { get; set; }

        public DateTime? LC_DFECCAM { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CCODMON { get; set; }

        [Required]
        [StringLength(2)]
        public string LC_CESTADO { get; set; }


        [StringLength(2)]
        public string LC_CRFTD { get; set; }


        [StringLength(4)]
        public string LC_CRFNUMSER { get; set; }


        [StringLength(20)]
        public string LC_CRFNUMDOC { get; set; }


        [StringLength(11)]
        public string LC_CNROPED { get; set; }

        [Required]
        [StringLength(80)]
        public string LC_CGLOSA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal LC_NDESCTO { get; set; }


        [StringLength(2)]
        public string LC_CTF { get; set; }


        [StringLength(11)]
        public string LC_CNUMORD { get; set; }


        [StringLength(800)]
        public string LC_TOBSERV { get; set; }


        [StringLength(12)]
        public string LC_CCALIDA { get; set; }


        [StringLength(12)]
        public string LC_CORIGEN { get; set; }

        [Required]
        [StringLength(5)]
        public string LC_CUSUCRE { get; set; }

        public DateTime? LC_DFECCRE { get; set; }


        [StringLength(5)]
        public string LC_CUSUMOD { get; set; }

        public DateTime? LC_DFECMOD { get; set; }


        [StringLength(2)]
        public string LC_CTIPOPE { get; set; }

        /// <summary>
        /// Lista un registro 
        /// Filtros: LC_CTD:TIPO DOCUMENTO,LC_CNUMDOC:NUMERO DOCUMENTO,CCODPRV:CODIGO PROVEEDOR
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<AL0003FACC> listar(AL0003FACC DATA)
        {
            List<AL0003FACC> listND = new List<AL0003FACC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = ctx.AL0003FACC.Where(x => x.LC_CTD == DATA.LC_CTD &&
                                             (DATA.LC_CNUMDOC != null ? x.LC_CNUMDOC == DATA.LC_CNUMDOC : x.LC_CNUMDOC != DATA.LC_CNUMDOC) &&
                                             x.LC_CCODPRV == DATA.LC_CCODPRV).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }

        public static List<AL0003FACC> autocompleteLiq(string texto)
        {
            var Liquidacion = new List<AL0003FACC>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    Liquidacion = ctx.AL0003FACC.Where(x => x.LC_CNUMDOC.Contains(texto))
                                     .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return Liquidacion;
        }
        /// <summary>
        /// Lista Documentos
        /// Filtros:AGENCIA,TIPO DOCUMENTO,NUMERO DOCUMENTO,PROVEEDOR,FECHA DOCUMENTO
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<AL0003FACC> listarLQ(AL0003FACC DATA)
        {
            List<AL0003FACC> listND = new List<AL0003FACC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = (from list in ctx.AL0003FACC
                              where (list.LC_CCODAGE == DATA.LC_CCODAGE &&
                                             list.LC_CTD == DATA.LC_CTD &&
                                             (DATA.LC_CNUMDOC != "" ? list.LC_CNUMDOC == DATA.LC_CNUMDOC : list.LC_CNUMDOC != DATA.LC_CNUMDOC) &&
                                             (DATA.LC_CCODPRV != "" ? list.LC_CCODPRV == DATA.LC_CCODPRV : list.LC_CCODPRV != DATA.LC_CCODPRV) &&
                                             (DATA.LC_DFECDOC != null ? list.LC_DFECDOC == DATA.LC_DFECDOC : list.LC_DFECDOC != DATA.LC_DFECDOC)
                                             )
                                             select new
                                             {
                                                 var0 = list.LC_CCODAGE,
                                                 var1 = list.LC_CTD,
                                                 var2 = list.LC_CNUMDOC,
                                                 var3 = list.LC_DFECDOC,
                                                 var4 = list.LC_DFECVEN,
                                                 var5 = list.LC_CCODPRV,
                                                 var6 = list.LC_CNOMBRE,
                                                 var7 = list.LC_CFORVEN,
                                                 var8 = list.LC_CCODMON,
                                                 var9 = list.LC_NIMPORT,
                                                 var10=list.LC_CESTADO,
                                                 var11=list.LC_CUSUCRE

                                             }).ToList().Select(c => new AL0003FACC
                                             {
                                                 LC_CCODAGE=c.var0,
                                                 LC_CTD= c.var1,
                                                 LC_CNUMDOC=c.var2,
                                                 LC_CVENDE= String.Format("{0:dd/MM/yyyy}", c.var3),//LC_DFECDOC
                                                 LC_CRFTD = String.Format("{0:dd/MM/yyyy}", c.var4),//LC_DFECVEN
                                                 LC_CCODPRV =c.var5,
                                                 LC_CNOMBRE=c.var6,
                                                 LC_CFORVEN=c.var7,
                                                 LC_CCODMON=c.var8,
                                                 LC_NIMPORT=c.var9,
                                                 LC_CESTADO=c.var10,
                                                 LC_CUSUCRE=c.var11                                                 
                                             }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }

        public static List<VISTA_REPLIQCOMPRAS> RepLiquidacion(VISTA_REPLIQCOMPRAS DATA)
      {
            string[] proveedor = DATA.LC_CCODPRV.Split(',');
           
                             
            List<VISTA_REPLIQCOMPRAS> listND = new List<VISTA_REPLIQCOMPRAS>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = (from list in ctx.AL0003FACC
                              join det in ctx.AL0003FACD
                              on new { LC_CNUMDOC = list.LC_CNUMDOC } equals new { LC_CNUMDOC = det.LD_CNUMDOC }
                              where (list.LC_CCODAGE == DATA.LC_CCODAGE &&
                                             list.LC_CCODMON == DATA.LC_CCODMON &&

                                             (DATA.LC_CCODPRV != "" ? proveedor.Contains(list.LC_CCODPRV.Trim()) : list.LC_CCODPRV != DATA.LC_CCODPRV) &&
                                             (list.LC_DFECDOC>= DATA.LC_DFECDOC && list.LC_DFECDOC<=DATA.LC_DFECMOD)                                                                                                 // (DATA.LC_DFECDOC != null ? list.LC_DFECDOC == DATA.LC_DFECDOC : list.LC_DFECDOC != DATA.LC_DFECDOC)
                                             )
                              select new
                              {
                                  var0 = list.LC_CCODAGE,
                                  var1 = list.LC_CCODMON,
                                  var2 = list.LC_CNUMDOC,
                                  var3 = list.LC_DFECDOC,
                                  var5 = list.LC_CCODPRV,
                                  var6 = list.LC_CNOMBRE,

                                  var7 = det.LD_CCODIGO,
                                  var8 = det.LD_CDESCRI,
                                  var9 = det.LD_CUNIDAD,
                                  var10 = det.LD_NCANTID,
                                  var11 = det.LD_NPRECIO,
                                 
                              }).ToList().Select(c => new VISTA_REPLIQCOMPRAS
                              {
                                  LC_CCODAGE = c.var0,
                                  LC_CCODMON = c.var1,
                                  LC_CNUMDOC = c.var2,
                                  LC_DFECDOC = Convert.ToDateTime(c.var3),
                                  LC_CCODPRV = c.var5,
                                  LC_CNOMBRE = c.var6,

                                  LD_CCODIGO = c.var7,
                                  LD_CDESCRI = c.var8,
                                  LD_CUNIDAD = c.var9,
                                  LD_NCANTID = c.var10,
                                  LD_NPRECIO = c.var11,

                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }
        public static List<VISTA_REPLIQCOMPRAS> RepLiquidacionART(VISTA_REPLIQCOMPRAS DATA)
        {
             string[] articulos = DATA.LD_CCODIGO.Split(',');

            List<VISTA_REPLIQCOMPRAS> listND = new List<VISTA_REPLIQCOMPRAS>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = (from list in ctx.AL0003FACC
                              join det in ctx.AL0003FACD
                              on new { LC_CNUMDOC = list.LC_CNUMDOC } equals new { LC_CNUMDOC = det.LD_CNUMDOC }
                              where (list.LC_CCODAGE == DATA.LC_CCODAGE &&
                                             list.LC_CCODMON == DATA.LC_CCODMON &&
                                             (DATA.LD_CCODIGO != "" ? articulos.Contains(det.LD_CCODIGO.Trim()) : det.LD_CCODIGO != det.LD_CCODIGO) &&
                                              (list.LC_DFECDOC >= DATA.LC_DFECDOC && list.LC_DFECDOC <= DATA.LC_DFECMOD)                                                                                                 // (DATA.LC_DFECDOC != null ? list.LC_DFECDOC == DATA.LC_DFECDOC : list.LC_DFECDOC != DATA.LC_DFECDOC)
                                             )
                              select new
                              {
                                  var0 = list.LC_CCODAGE,
                                  var1 = list.LC_CCODMON,
                                  var2 = list.LC_CNUMDOC,
                                  var3 = list.LC_DFECDOC,
                                  var5 = list.LC_CCODPRV,
                                  var6 = list.LC_CNOMBRE,

                                  var7 = det.LD_CCODIGO,
                                  var8 = det.LD_CDESCRI,
                                  var9 = det.LD_CUNIDAD,
                                  var10 = det.LD_NCANTID,
                                  var11 = det.LD_NPRECIO,

                              }).ToList().Select(c => new VISTA_REPLIQCOMPRAS
                              {
                                  LC_CCODAGE = c.var0,
                                  LC_CCODMON = c.var1,
                                  LC_CNUMDOC = c.var2,
                                  LC_DFECDOC = Convert.ToDateTime(c.var3),
                                  LC_CCODPRV = c.var5,
                                  LC_CNOMBRE = c.var6,

                                  LD_CCODIGO = c.var7,
                                  LD_CDESCRI = c.var8,
                                  LD_CUNIDAD = c.var9,
                                  LD_NCANTID = c.var10,
                                  LD_NPRECIO = c.var11,

                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }


        public static List<VISTA_REPLIQCOMPRAS> RepLiquidacionLIQ(VISTA_REPLIQCOMPRAS DATA)
        {
            string[] LIQUIDACION = DATA.LC_CNUMDOC.Split(',');

            List<VISTA_REPLIQCOMPRAS> listND = new List<VISTA_REPLIQCOMPRAS>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = (from list in ctx.AL0003FACC
                              join det in ctx.AL0003FACD
                              on new { LC_CNUMDOC = list.LC_CNUMDOC } equals new { LC_CNUMDOC = det.LD_CNUMDOC }
                              where (list.LC_CCODAGE == DATA.LC_CCODAGE &&
                                             list.LC_CCODMON == DATA.LC_CCODMON &&
                                             (DATA.LC_CNUMDOC != "" ? LIQUIDACION.Contains(list.LC_CNUMDOC.Trim()) : list.LC_CNUMDOC != list.LC_CNUMDOC) &&
                                              (list.LC_DFECDOC >= DATA.LC_DFECDOC && list.LC_DFECDOC <= DATA.LC_DFECMOD)                                                                                                 // (DATA.LC_DFECDOC != null ? list.LC_DFECDOC == DATA.LC_DFECDOC : list.LC_DFECDOC != DATA.LC_DFECDOC)
                                             )
                              select new
                              {
                                  var0 = list.LC_CCODAGE,
                                  var1 = list.LC_CCODMON,
                                  var2 = list.LC_CNUMDOC,
                                  var3 = list.LC_DFECDOC,
                                  var5 = list.LC_CCODPRV,
                                  var6 = list.LC_CNOMBRE,

                                  var7 = det.LD_CCODIGO,
                                  var8 = det.LD_CDESCRI,
                                  var9 = det.LD_CUNIDAD,
                                  var10 = det.LD_NCANTID,
                                  var11 = det.LD_NPRECIO,

                              }).ToList().Select(c => new VISTA_REPLIQCOMPRAS
                              {
                                  LC_CCODAGE = c.var0,
                                  LC_CCODMON = c.var1,
                                  LC_CNUMDOC = c.var2,
                                  LC_DFECDOC = Convert.ToDateTime(c.var3),
                                  LC_CCODPRV = c.var5,
                                  LC_CNOMBRE = c.var6,

                                  LD_CCODIGO = c.var7,
                                  LD_CDESCRI = c.var8,
                                  LD_CUNIDAD = c.var9,
                                  LD_NCANTID = c.var10,
                                  LD_NPRECIO = c.var11,

                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }

        public static List<VISTA_CCODPRV> ListarProveedoresED(string cod1, string cod2, DateTime fec1, DateTime fec2, string agencia, string moneda)
        {
            var alumnos = new List<VISTA_CCODPRV>();
           

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<VISTA_CCODPRV>("select distinct LC_CCODPRV,LC_CNOMBRE from  al0003facc  where (LC_CCODPRV>= @cod1 and LC_CCODPRV<= @cod2) and (LC_DFECCOM>= @fec1 and LC_DFECCOM<= @fec2) and LC_CCODAGE=@agencia AND LC_CCODMON=@moneda  ",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2),
                           new SqlParameter("fec1", fec1), new SqlParameter("fec2", fec2)
                           , new SqlParameter("agencia", agencia)
                            , new SqlParameter("moneda", moneda))
                           .ToList();
                      }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_LC_CNUMDOC> ListarLiquidacionesED(string cod1, string cod2, DateTime fec1, DateTime fec2, string agencia, string moneda)
        {
            var alumnos = new List<VISTA_LC_CNUMDOC>();


            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<VISTA_LC_CNUMDOC>("select distinct LC_CNUMDOC from  AL0003FACC  where (LC_CNUMDOC>= @cod1 and LC_CNUMDOC<= @cod2) and (LC_DFECCOM>= @fec1 and LC_DFECCOM<= @fec2) and LC_CCODAGE=@agencia AND LC_CCODMON=@moneda  ",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2),
                           new SqlParameter("fec1", fec1), new SqlParameter("fec2", fec2)
                           , new SqlParameter("agencia", agencia)
                            , new SqlParameter("moneda", moneda))
                           .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_CCODPRV> lISTARaRTICULOSED(string cod1, string cod2,  string agencia)
        {
            var alumnos = new List<VISTA_CCODPRV>();


            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<VISTA_CCODPRV>("select distinct LD_CCODIGO AS LC_CCODPRV, LD_CDESCRI AS LC_CNOMBRE from  AL0003FACD  where (LD_CCODIGO>= @cod1 and LD_CCODIGO<= @cod2) AND LD_CCODAGE=@agencia ",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2),
                           new SqlParameter("agencia", agencia)
                           )
                           .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }



        public static string correlativoCP(AL0003FACC datos)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSFACAR())
                {

                    cuenta = ctx.AL0003FACC.Where(x => x.LC_DFECCOM.Value.Year == datos.LC_DFECCOM.Value.Year && x.LC_DFECCOM.Value.Month == datos.LC_DFECCOM.Value.Month).Select(y => y.LC_CCOMPRO).Count();

                }
            }
            catch (Exception)
            {

                throw;
            }

            cuenta = cuenta + 1;
            codID = (datos.LC_DFECCOM.Value.Month).ToString("D2") + "" + cuenta.ToString("D4");
            return codID;
        }
        public static Boolean insertaCabecera(AL0003FACC datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
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

        // PARA LIBRO LIQUIDACIONES
        public static List<AL0003FACC> LibroLiquidacion(AL0003FACC DATA)
        {
            int mess = Convert.ToInt16(DATA.LC_CNUMDOC);
            int annio = Convert.ToInt16(DATA.LC_CTD);
            List<AL0003FACC> listND = new List<AL0003FACC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = (from list in ctx.AL0003FACC
                              where (        (DATA.LC_CCODAGE != "" ? list.LC_CCODAGE == DATA.LC_CCODAGE : list.LC_CCODAGE != DATA.LC_CCODAGE) &&
                                             (DATA.LC_CCODMON != "" ? list.LC_CCODMON == DATA.LC_CCODMON : list.LC_CCODMON != DATA.LC_CCODMON) &&
                                             (list.LC_DFECDOC.Value.Year ==annio  && list.LC_DFECDOC.Value.Month == mess)
                                             )
                              select new
                              {
                                  var0 = list.LC_CCODAGE,
                                  var1 = list.LC_CTD,
                                  var2 = list.LC_CNUMDOC,
                                  var3 = list.LC_DFECDOC,
                                  var4 = list.LC_CNOMBRE,
                                  var5 = list.LC_CCODPRV,
                                  var6 = list.LC_NIMPORT,
                                  var7 = list.LC_NIMPIGV,
                                  var8 = list.LC_NIMPRET,
                                  var9 = list.LC_NSALDO,
                                  var10 = list.LC_CCOMPRO,
                                  var11 = list.LC_CESTADO

                              }).ToList().Select(c => new AL0003FACC
                              {
                                    LC_CCODAGE= c.var0,
                                    LC_CTD= c.var1,
                                    LC_CNUMDOC= c.var2,
                                    LC_DFECDOC= c.var3,
                                    LC_CNOMBRE= c.var4,
                                    LC_CCODPRV= c.var5,
                                    LC_NIMPORT= c.var6,
                                    LC_NIMPIGV= c.var7,
                                    LC_NIMPRET= c.var8,
                                    LC_NSALDO= c.var9,
                                    LC_CCOMPRO= c.var10,
                                    LC_CESTADO= c.var11

                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }

    }
}
