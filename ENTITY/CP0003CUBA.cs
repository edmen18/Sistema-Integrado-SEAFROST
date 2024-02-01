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
    public partial class CP0003CUBA
    {
        [Key]
        [StringLength(18)]
        public string CT_CNUMCTA { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMBAN { get; set; }

        [Required]
        [StringLength(20)]
        public string CT_CDESCTA { get; set; }

        [Required]
        [StringLength(10)]
        public string CT_CDESCOR { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CTIPCTA { get; set; }

        [Required]
        [StringLength(2)]
        public string CT_CCODMON { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFCHEQE { get; set; }

        [Required]
        [StringLength(12)]
        public string CT_CCUENTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ01 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ02 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCHEQ03 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NSALANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NCARGOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CT_NABONOS { get; set; }

        public DateTime? CT_DFECSAL { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP01 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP02 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CFREP03 { get; set; }

        [Required]
        [StringLength(1)]
        public string CT_CESTADO { get; set; }

        public DateTime? CT_DFECMOD { get; set; }

        public DateTime? CT_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string CT_CUSERSS { get; set; }

        [Required]
        [StringLength(8)]
        public string CT_CENTFIN { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR1 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR2 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR3 { get; set; }

        [Required]
        [StringLength(30)]
        public string CT_CNOMFR4 { get; set; }

        [Required]
        [StringLength(3)]
        public string CT_CCODMOD { get; set; }

        /// <summary>
        /// Busqueda por banco codigo
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<CP0003CUBA> ListarBancosxCta(CP0003CUBA DATA)
        {
            var lista = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {

                    lista = ctx.CP0003CUBA.Where(x => SqlFunctions.PatIndex(DATA.CT_CDESCTA, x.CT_CNUMCTA) > 0 && x.CT_CESTADO == "V")
                                     .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }
        /// <summary>
        /// Busqueda por Bancos x Descripcion
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<CP0003CUBA> ListarBancosxCtaD(CP0003CUBA DATA)
        {
            var lista = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {

                    lista = ctx.CP0003CUBA.Where(x => SqlFunctions.PatIndex(DATA.CT_CDESCTA, x.CT_CDESCTA) > 0 && x.CT_CESTADO == "V")
                                     .ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return lista;
        }

        public static CP0003CUBA ListarDatosBancoID(string ban)
        {
            var banco = new CP0003CUBA();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    banco = ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA == ban).First();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return banco;
        }

        public static List<CP0003CUBA> ListarTablaS(CP0003CUBA TABL)
        {
            var alumnos = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA != "" && x.CT_CFREP02=="1")
                               select new
                               {
                                   CT_CNUMCTA = c.CT_CNUMCTA,
                                   CT_CDESCTA = c.CT_CDESCTA
                                }

                        ).ToList().Select(c => new CP0003CUBA()
                        {
                            CT_CNUMCTA = c.CT_CNUMCTA.Trim(),
                            CT_CDESCTA = c.CT_CDESCTA.Trim()

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

        public static List<CP0003CUBA> ListarBancos()
        {
            var alumnos = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA != "")
                               select new
                               {
                                   CT_CNUMCTA = c.CT_CNUMCTA,
                                   CT_CDESCTA = c.CT_CDESCTA
                               }

                        ).ToList().Select(c => new CP0003CUBA()
                        {
                            CT_CNUMCTA = c.CT_CNUMCTA.Trim(),
                            CT_CDESCTA = c.CT_CNUMCTA.Trim() + "-" + c.CT_CDESCTA.Trim()

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

        public static List<CP0003CUBA> ListarBancosProg(string clave)
        {
            var alumnos = new List<CP0003CUBA>();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from c in ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA.Contains(clave) || x.CT_CDESCTA.Contains(clave))
                               select new
                               {
                                   CT_CNUMCTA = c.CT_CNUMCTA,
                                   CT_CDESCTA = c.CT_CDESCTA,
                                   CT_CCODMON = c.CT_CCODMON,
                                   CT_CCUENTA= c.CT_CCUENTA,
                               }

                        ).ToList().Select(c => new CP0003CUBA()
                        {
                            CT_CNUMCTA = c.CT_CNUMCTA.Trim(),
                            CT_CDESCTA = c.CT_CDESCTA.Trim(),
                            CT_CCODMON = c.CT_CCODMON.Trim(),
                            CT_CCUENTA = c.CT_CCUENTA.Trim(),

                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }
        /// <summary>
        /// EDGAR MENDOZA MENDIVES
        /// </summary> ACTUALIZACIÓN DEL CAMPO NUMERO DE CHEQUERA (1 ,2 O 3) SEGUN LA SELECCION
        /// <param name="COM"></param>CREADO EL 18/08/2016 A LAS 12:23 P.M.
        public static void Actualizacheque(CP0003CUBA COM)
        {
            var banco = new CP0003CUBA { CT_CNUMCTA = COM.CT_CNUMCTA };

            using (var ctx = new RSCONCAR())
            {
                ctx.CP0003CUBA.Attach(banco);
                if (COM.CT_CTIPCTA=="1")
                {
                    banco.CT_NCHEQ01 = COM.CT_NCHEQ01;
                }
                if (COM.CT_CTIPCTA == "2")
                {
                    banco.CT_NCHEQ02 = COM.CT_NCHEQ01;
                }
                if (COM.CT_CTIPCTA == "3")
                {
                    banco.CT_NCHEQ03 = COM.CT_NCHEQ01;
                }
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }
        /// <summary>
        /// Lista Bancos cadena sin guion
        /// </summary>
        /// <param name="ban"></param>
        /// <returns></returns>
        public static string ListarDatosBancoIDC(string ban)
        {
            var banco = "";//new CP0003CUBA();
            string codID;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    banco = ctx.CP0003CUBA.Where(x => x.CT_CNUMCTA.Trim() == ban.Trim() && x.CT_CESTADO=="V").First().CT_CNOMBAN;
                }
            }
            catch (Exception)
            {
                throw;
            }
            codID = banco.Replace("-","");
            return codID;
        }

    }
}
