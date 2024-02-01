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

    public partial class AL0003TABL
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TG_CCOD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(12)]
        public string TG_CCLAVE { get; set; }

        [Required]
        [StringLength(60)]
        public string TG_CDESCRI { get; set; }

        [Required]
        [StringLength(5)]
        public string TG_CUSUCRE { get; set; }

        public DateTime? TG_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string TG_CUSUMOD { get; set; }

        public DateTime? TG_DFECMOD { get; set; }

        public static List<AL0003TABL> ListarTabla(AL0003TABL TABL)
        {
            var alumnos = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003TABL.Where(x => x.TG_CCOD == TABL.TG_CCOD).OrderBy(x=> x.TG_CDESCRI).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<AL0003TABL> ListarTablaMod(AL0003TABL TABL)
        {
            var alumnos = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003TABL.Where(x => x.TG_CCOD == TABL.TG_CCOD && x.TG_CCLAVE == TABL.TG_CCLAVE).Concat(ctx.AL0003TABL.Where((x => x.TG_CCOD == TABL.TG_CCOD && x.TG_CCLAVE != TABL.TG_CCLAVE))).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static int cuentaTablaMod(AL0003TABL TABL)
        {
            var alumnos = 0;

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003TABL.Where(x => x.TG_CCOD == TABL.TG_CCOD && x.TG_CCLAVE == TABL.TG_CCLAVE).Count(); 
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        
        //nuevo codigo
        public static List<AL0003TABL> ListarCcosto(string texto)
        {
            var info = new List<AL0003TABL>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.AL0003TABL.Where(x => SqlFunctions.PatIndex(texto, x.TG_CDESCRI) > 0  && x.TG_CCOD=="10").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }
        
        public static List<AL0003TABL> Listartablaxcodigo(string texto, string codig)
        {
            var info = new List<AL0003TABL>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    // info = ctx.AL0003TABL.Where(x => x.TG_CDESCRI.Contains(texto) && x.TG_CCOD==codig).ToList();
                    info = ctx.AL0003TABL.Where(x => SqlFunctions.PatIndex(texto, x.TG_CDESCRI) > 0 && x.TG_CCOD == codig).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }
        public static AL0003TABL Registroxcodigo(string texto, string codig)
        {
            var info = new AL0003TABL();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.AL0003TABL.Where(x => x.TG_CCLAVE.Trim() == texto.Trim() && x.TG_CCOD.Trim() == codig.Trim()).First();
                }
            }
            catch (Exception)
            {
                info = null;
            }
            return info;
        }
        
        public static List<AL0003TABL> ListarTablaS(AL0003TABL TABL)
        {
            var alumnos = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = (from c in ctx.AL0003TABL.Where(x => x.TG_CCOD == TABL.TG_CCOD && x.TG_CCLAVE!= "EU")
                               select new
                               {
                                   TG_CCOD = c.TG_CCOD,
                                   TG_CCLAVE = c.TG_CCLAVE,
                                   TG_CDESCRI = c.TG_CDESCRI

                               }

                        ).ToList().Select(c => new AL0003TABL()
                        {
                            TG_CCOD = c.TG_CCOD.Trim(),
                            TG_CCLAVE = c.TG_CCLAVE.Trim(),
                            TG_CDESCRI = c.TG_CDESCRI.Trim()

                        }).ToList(); 
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
        //codigo nuevo willliam
        public static List<AL0003TABL> ListarTablaID(string id, string tipo)
        {
            var alumnos = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003TABL.Where(x => x.TG_CCOD == id && x.TG_CCLAVE == tipo).OrderBy(x => x.TG_CDESCRI).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<AL0003TABL> ListartablaxDetalle(string texto, string codig)
        {
            var info = new List<AL0003TABL>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.AL0003TABL.Where(x => x.TG_CDESCRI.Contains(texto) && x.TG_CCOD == codig.Trim()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static List<AL0003TABL> ListartablaxID(string texto, string codig)
        {
            var info = new List<AL0003TABL>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.AL0003TABL.Where(x => x.TG_CCLAVE.Contains(texto) && x.TG_CCOD == codig.Trim()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        //sergio 22032016  AL0003TABL

        public static string Registrouno(string texto, string codig)
        {
            var info = "";
            try
            {
                using (var ctx = new RSFACAR())
                {
                    info = ctx.AL0003TABL.Where(x => x.TG_CCLAVE.Trim() == texto.Trim() && x.TG_CCOD.Trim() == codig.Trim()).Select(aw => aw.TG_CDESCRI).First().ToString();
                }
            }
            catch (Exception)
            {
                info = "";
            }
            return info;
        }

        //CODIGO EDGAR

        public static List<AL0003TABL> ListarvARIOS(string texto, string INDICADOR)

        {
            var ARTICULOS = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    ARTICULOS = (from c in ctx.AL0003TABL
                                 where c.TG_CDESCRI.Contains(texto) && c.TG_CCOD == INDICADOR
                                 select new
                                 {
                                     TG_CCLAVE = c.TG_CCLAVE,
                                     TG_CDESCRI = c.TG_CDESCRI,
                                 }

                        ).ToList().Select(c => new AL0003TABL()
                        {
                            TG_CCLAVE = c.TG_CCLAVE.Trim(),
                            TG_CDESCRI = c.TG_CDESCRI.Trim(),
                            //c.TG_CCLAVE.Trim() + "   " + 
                        }).ToList(); ;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return ARTICULOS;
        }
        public static List<AL0003TABL> ListarvALORESParaStockValorizado(string cod1, string cod2, string COD3)
        {
            var alumnos = new List<AL0003TABL>();

            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos = ctx.Database.SqlQuery<AL0003TABL>("select * from  AL0003TABL  where TG_CCOD=@COD3 AND TG_CCLAVE between @cod1 and @cod2 order by rtrim(ltrim(TG_CCLAVE))",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2), new SqlParameter("COD3", COD3)).ToList();
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
