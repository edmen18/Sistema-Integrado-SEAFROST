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

    public partial class CT0003ANEX
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string AVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string ACODANE { get; set; }

        [Required]
        [StringLength(40)]
        public string ADESANE { get; set; }

        [Required]
        [StringLength(50)]
        public string AREFANE { get; set; }

        [Required]
        [StringLength(18)]
        public string ARUC { get; set; }

        [Required]
        [StringLength(2)]
        public string ACODMON { get; set; }

        [Required]
        [StringLength(1)]
        public string AESTADO { get; set; }

        public DateTime? ADATE { get; set; }

        [Required]
        [StringLength(6)]
        public string AHORA { get; set; }

        [Required]
        [StringLength(20)]
        public string APATERNO { get; set; }

        [Required]
        [StringLength(20)]
        public string AMATERNO { get; set; }

        [Required]
        [StringLength(20)]
        public string ANOMBRE { get; set; }

        [Required]
        [StringLength(8)]
        public string AFORMSUS { get; set; }

        [Required]
        [StringLength(30)]
        public string ATELEFO { get; set; }

        [Required]
        [StringLength(1)]
        public string ATIPTRA { get; set; }

        [Required]
        [StringLength(30)]
        public string APROVIN { get; set; }

        [Required]
        [StringLength(30)]
        public string ADEPART { get; set; }

        [Required]
        [StringLength(30)]
        public string APAIS { get; set; }

        [Required]
        [StringLength(10)]
        public string AZONPOS { get; set; }

        [Required]
        [StringLength(40)]
        public string ANOMREP { get; set; }

        [Required]
        [StringLength(20)]
        public string ACARREP { get; set; }

        [Required]
        [StringLength(80)]
        public string AEMAIL { get; set; }

        [Required]
        [StringLength(80)]
        public string AHOST { get; set; }

        [Required]
        [StringLength(5000)]
        public string AMEMO { get; set; }

        [Required]
        [StringLength(2)]
        public string ADOCIDE { get; set; }

        [Required]
        [StringLength(15)]
        public string ANUMIDE { get; set; }

        [Required]
        [StringLength(1)]
        public string ATIPPRO { get; set; }

        [Required]
        [StringLength(8)]
        public string ATASDET { get; set; }

        [Required]
        [StringLength(8)]
        public string ATASPER { get; set; }

        public DateTime? AFEPINI { get; set; }

        public DateTime? AFEPFIN { get; set; }

        [Required]
        [StringLength(1)]
        public string ASTTPRO { get; set; }

        [Required]
        [StringLength(30)]
        public string AOBSPRO { get; set; }

        [Required]
        [StringLength(8)]
        public string AENTFIN { get; set; }

        public DateTime? AFNACI { get; set; }

        [Required]
        [StringLength(6)]
        public string ASEXO { get; set; }

        [Required]
        [StringLength(6)]
        public string ANACIO { get; set; }

        [Required]
        [StringLength(2)]
        public string AESSAL { get; set; }

        [Required]
        [StringLength(2)]
        public string ADOMIC { get; set; }

        [Required]
        [StringLength(2)]
        public string ATIPVIA { get; set; }

        [Required]
        [StringLength(20)]
        public string ANVVIA { get; set; }

        [Required]
        [StringLength(4)]
        public string ANUMER { get; set; }

        [Required]
        [StringLength(4)]
        public string AINTER { get; set; }

        [Required]
        [StringLength(2)]
        public string ATZONA { get; set; }

        [Required]
        [StringLength(20)]
        public string ANZONA { get; set; }

        [Required]
        [StringLength(40)]
        public string AREFER { get; set; }

        [Required]
        [StringLength(6)]
        public string AUBIGU { get; set; }

        [Required]
        [StringLength(2)]
        public string ASITUA { get; set; }

        [Required]
        [StringLength(2)]
        public string ATICONV { get; set; }

        [Required]
        [StringLength(1)]
        public string AVRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal APORRE { get; set; }

        [Required]
        [StringLength(18)]
        public string ACODAFP { get; set; }

        [Required]
        [StringLength(2)]
        public string ATIPCOMAFP { get; set; }

        [Required]
        [StringLength(20)]
        public string ACUSPP { get; set; }

        public static List<CT0003ANEX> ListarProveedores(string texto)
        {
            var alumnos = new List<CT0003ANEX>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ctx.CT0003ANEX.Where(x => x.ADESANE.Contains(texto))
                                     .ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static CT0003ANEX obtenProveedor(string texto)
        {
            var alumnos = new CT0003ANEX();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ctx.CT0003ANEX.Where(x => x.ACODANE == texto).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        //NUEVO
        public static List<CT0003ANEX> listarAnexo(string cod, string texto)
        {
            var lista = new List<CT0003ANEX>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    //lista = ctx.CT0003ANEX.Where(x=>x.AVANEXO==cod && x.ADESANE.Contains(texto)).ToList();
                    lista = ctx.CT0003ANEX.Where(x => x.AVANEXO == cod && x.ADESANE.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }


        
        
        //codigo william

        public static List<CT0003ANEX> listarAnexoT(CT0003ANEX ADATA)
        {
            var lista = new List<CT0003ANEX>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    //lista = ctx.CT0003ANEX.Where(x=>x.AVANEXO==cod && x.ADESANE.Contains(texto)).ToList();
                    //lista = ctx.CT0003ANEX.Where(x => x.AVANEXO == ADATA.AVANEXO && SqlFunctions.PatIndex(texto, x.ADESANE) > 0).ToList();
                    lista = ctx.CT0003ANEX.Where(x => x.AVANEXO == ADATA.AVANEXO
                            && (ADATA.ATIPTRA != null ? x.ATIPTRA == ADATA.ATIPTRA : x.ATIPTRA != ADATA.ATIPTRA)
                            && SqlFunctions.PatIndex(ADATA.ADESANE, x.ADESANE) > 0
                            && x.AESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<CT0003ANEX> listarAnexoID(string cod, string texto)
        {
            var lista = new List<CT0003ANEX>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    //lista = ctx.CT0003ANEX.Where(x=>x.AVANEXO==cod && x.ADESANE.Contains(texto)).ToList();
                    //alumnos = ctx.AL0003ARTI.Where(x => SqlFunctions.PatIndex(texto, x.AR_CDESCRI) > 0).ToList();
                    lista = ctx.CT0003ANEX.Where(x => x.AVANEXO == cod && SqlFunctions.PatIndex(texto, x.ACODANE) > 0).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        //CODIGO EDGAR
        public static List<CT0003ANEX> ListarProveedorParaStockValorizado(string cod1, string cod2)
        {
            var alumnos = new List<CT0003ANEX>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ctx.Database.SqlQuery<CT0003ANEX>("select * from  CT0003ANEX  where ACODANE between @cod1 and @cod2 order by rtrim(ltrim(ACODANE))",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static CT0003ANEX obtenProveedorED(string texto)
        {
            var alumnos = new CT0003ANEX();


            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = ctx.CT0003ANEX.Where(x => x.ACODANE.Trim() == texto.Trim()).FirstOrDefault();

                    if (alumnos == null)
                    {

                        CT0003ANEX alumnos1 = new CT0003ANEX()
                        {
                            ADESANE = "proveedor no registrado",
                            ACODANE = "no registra",
                            ARUC = "no registra"

                        };
                        alumnos = alumnos1;
                    }
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
