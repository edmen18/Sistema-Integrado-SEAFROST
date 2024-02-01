namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    public partial class CT0003TAGE
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TCOD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string TCLAVE { get; set; }

        [Required]
        [StringLength(60)]
        public string TDESCRI { get; set; }

        public DateTime? TDATE { get; set; }

        [Required]
        [StringLength(6)]
        public string THORA { get; set; }
        
        /// <summary>
        /// Lista tabla generales - CONCAR
        /// Actualizacion:29.04.2016
        /// Ultimo : 09.09.16 ->PAGOS
        /// </summary>
        /// <param name="TABG"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> ListarTG(CT0003TAGE TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD && 
                              (TABG.TCLAVE!=null?x.TCLAVE==TABG.TCLAVE: x.TCLAVE != TABG.TCLAVE) &&
                              x.TCLAVE!="00000")
                              select new
                              {
                                  //TG_INDICE = x.TG_INDICE,
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI=x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {

                                  TCOD = x.TCOD.Trim(),
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = "["+x.TCLAVE.Trim()+"]"+x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }
        /// <summary>
        /// Parametros Generales x descripcion
        /// </summary>
        /// <param name="TABG"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> ListarTGxD(CT0003TAGE TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD &&
                              (TABG.TCLAVE != null ? x.TCLAVE == TABG.TCLAVE : x.TCLAVE != TABG.TCLAVE) &&
                              (SqlFunctions.PatIndex(TABG.TDESCRI, x.TDESCRI) > 0) &&
                              x.TCLAVE != "00000")
                              select new
                              {
                                  //TG_INDICE = x.TG_INDICE,
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {

                                  TCOD = x.TCOD.Trim(),
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        /// <summary>
        /// Busqueda tabla general x filtro de clave
        /// Uso:ContabilizaDOC
        /// </summary>
        /// <param name="TABG"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> ListarTGL(CT0003TAGE TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD &&
                              (TABG.TDESCRI!=null?x.TDESCRI.StartsWith(TABG.TDESCRI):x.TDESCRI!=null) &&
                              (TABG.TCLAVE!=null?x.TCLAVE.StartsWith(TABG.TCLAVE):x.TCLAVE!= null))
                              select new
                              {
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {

                                  TCOD = x.TCOD.Trim(),
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        /// <summary>
        /// Listar Parametros Varios
        /// Uso:Contabilizacion de documentos O/C
        /// </summary>
        /// <param name="TABG"></param>
        /// <param name="PAR"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> ListarTGLA(CT0003TAGE TABG, string[] PAR)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {   //&&   (PAR).Contains(x.TCLAVE)
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD &&
                              PAR.Contains(x.TCLAVE)
                              )
                              select new
                              {
                                  //TG_INDICE = x.TG_INDICE,
                                  TCOD = x.TCOD,
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {

                                  TCOD = x.TCOD.Trim(),
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

//CODIGO EDGAR
        public static List<CT0003TAGE> LISTARVARIOSED(CT0003TAGE TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == TABG.TCOD &&
                              (TABG.TCLAVE != null ? x.TCLAVE == TABG.TCLAVE : x.TCLAVE != TABG.TCLAVE) &&
                              x.TCLAVE != "00000")
                              select new
                              {                                 
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TCLAVE +"-" + x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }
        public static List<CT0003TAGE> LISTARdetracciones(string TABG)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD == "28" && 
                              x.TCLAVE.Contains(TABG )
                             )
                              select new
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI,
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        public static List<CT0003TAGE> LISTARAREASED()
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD.Trim() == "26")
                              select new
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TCLAVE + "-" + x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TCLAVE.Trim()+"-"+ x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        public static List<CT0003TAGE> LISTARMEDIOPAGOED(string clave1, string clave2)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD.Trim() == "S1"
                              &&(x.TCLAVE.Trim() == clave1.Trim() || x.TCLAVE.Trim() == clave2.Trim())

                              )
                              select new
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TCLAVE + "-" + x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="clave1"></param>
        /// <param name="clave2"></param>
        /// <returns></returns>
        public static List<CT0003TAGE> listage_unico(string clave1, string clave2)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD.Trim() == clave1
                              && x.TCLAVE.Trim() == clave2.Trim())
                              select new
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }
        public static List<CT0003TAGE> LISTARSUBDIARIOED(string subdiario)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD.Trim() == "02"
                              && x.TCLAVE.Trim() == subdiario.Trim() 

                              )
                              select new
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TCLAVE + "-" + x.TDESCRI
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE.Trim(),
                                  TDESCRI = x.TDESCRI.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }


        //mostrar un item por codigo y clave
        public static CT0003TAGE VerUnTAGE(CT0003TAGE TABG)
        {
            var tablag = new CT0003TAGE();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE
                              where x.TCOD.Trim() == TABG.TCOD.Trim() &&
                              x.TCLAVE.Trim() == TABG.TCLAVE.Trim() select x).First();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }

        public static List<CT0003TAGE> listarSubCta(CT0003TAGE COM)
        {
            var tablag = new List<CT0003TAGE>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tablag = (from x in ctx.CT0003TAGE.Where(x => x.TCOD.Trim() == COM.TCOD.Trim()
                              && x.TCLAVE.Trim().Contains(COM.TCLAVE.Trim())
                              )    select new
                              {   TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI,
                                 // AUX= (x.TDESCRI.Substring(0,22)).Substring(22,8).Substring(0,12),
                              }).ToList().Select(x => new CT0003TAGE
                              {
                                  TCLAVE = x.TCLAVE,
                                  TDESCRI = x.TDESCRI
                              }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tablag;
        }
   }
}
