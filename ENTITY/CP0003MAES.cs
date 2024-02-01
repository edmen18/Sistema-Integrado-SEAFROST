namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.SqlServer;
    using System.Linq;
    public partial class CP0003MAES
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string AC_CVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string AC_CCODIGO { get; set; }

        [Required]
        [StringLength(50)]
        public string AC_CNOMBRE { get; set; }

        [Required]
        [StringLength(50)]
        public string AC_CDIRECC { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CLOCALI { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CPAISAC { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CTELEF1 { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CTELEF2 { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CTELEF3 { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CFAXACR { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPOAC { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CGIROAC { get; set; }

        [Required]
        [StringLength(40)]
        public string AC_CREPRES { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCARREP { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CTELREP { get; set; }

        public DateTime? AC_DFECCRE { get; set; }

        public DateTime? AC_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CUSER { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CESTADO { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CABREVI { get; set; }

        [Required]
        [StringLength(18)]
        public string AC_CRUC { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CTIPPAG { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMN { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUS { get; set; }

        [Required]
        [StringLength(8)]
        public string AC_CCODPOS { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CFORPAG { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CCODSUP { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMNC { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUSC { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPCTA { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CSUCURS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_CMAXPAG { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUS7 { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMN7 { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPDOI { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CNUMDOI { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CTIPPRO { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUST { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMNT { get; set; }

        [Required]
        [StringLength(20)]
        public string AV_CPATER { get; set; }

        [Required]
        [StringLength(20)]
        public string AV_CMATERN { get; set; }

        [Required]
        [StringLength(20)]
        public string AV_CNOMBRE { get; set; }

        [Required]
        [StringLength(8)]
        public string AV_CFORMSU { get; set; }

        [Required]
        [StringLength(1)]
        public string AV_CTIPTRA { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMNB { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUSB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NMESNOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NMESURG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NDIANOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NDIAURG { get; set; }

        [Required]
        [StringLength(1)]
        public string AV_CTIPRO2 { get; set; }

        [Required]
        [StringLength(2)]
        public string AV_CDOCIDE { get; set; }

        [Required]
        [StringLength(15)]
        public string AV_CNUMIDE { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CFORPA1 { get; set; }

        [Required]
        [StringLength(8)]
        public string AC_CTASDET { get; set; }

        [Required]
        [StringLength(8)]
        public string AC_CTASPER { get; set; }

        [Required]
        [StringLength(50)]
        public string AC_CEMAIL { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTADET { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAMNK { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAUSK { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CTIPPRK { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPABK { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CCODOFK { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CTIPPA2 { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CNUMTRA { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CCODBC2 { get; set; }

        [Required]
        [StringLength(35)]
        public string AC_CNUMCT2 { get; set; }

        [Required]
        [StringLength(35)]
        public string AC_CNUMUS2 { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPCT2 { get; set; }

        public DateTime? AC_DFNACI { get; set; }

        [Required]
        [StringLength(6)]
        public string AC_CSEXO { get; set; }

        [Required]
        [StringLength(6)]
        public string AC_CNACIO { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CESSAL { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CDOMIC { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPVIA { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CNVVIA { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CNUMER { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CINTER { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTZONA { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CNZONA { get; set; }

        [Required]
        [StringLength(40)]
        public string AC_CREFER { get; set; }

        [Required]
        [StringLength(6)]
        public string AC_CUBIGU { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CSITUA { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTICONV { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CFLUPRO { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CVALRUT { get; set; }

        [Required]
        [StringLength(225)]
        public string AC_COBSERV { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CFORPG7 { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_CTIPCT7 { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CCODCI7 { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CCTAITB { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CTIPOPG { get; set; }

        [Required]
        [StringLength(8)]
        public string AC_CGRUACR { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CSISTEL { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAITI { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CFORPAB { get; set; }

        [Required]
        [StringLength(3)]
        public string AC_CCODBAB { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CCTCCIB { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CTIPDIB { get; set; }

        [Required]
        [StringLength(15)]
        public string AC_CNUMDIB { get; set; }

        [Required]
        [StringLength(100)]
        public string AC_CCTDERF { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CFORPAF { get; set; }

        [Required]
        [StringLength(5)]
        public string AC_CTIPCTF { get; set; }

        [Required]
        [StringLength(40)]
        public string AC_CNUMCSF { get; set; }

        [Required]
        [StringLength(40)]
        public string AC_CNUMCDF { get; set; }

        [Required]
        [StringLength(18)]
        public string AC_CDOCREF { get; set; }

        [Required]
        [StringLength(1)]
        public string AC_CRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal AC_NPORRE { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAIMN { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CCTAIUS { get; set; }

        [Required]
        [StringLength(4)]
        public string AC_CCOPAIS { get; set; }

        [Required]
        [StringLength(18)]
        public string AC_CODAFP { get; set; }

        [Required]
        [StringLength(2)]
        public string AC_TIPCOMAFP { get; set; }

        [Required]
        [StringLength(20)]
        public string AC_CUSPP { get; set; }

        [Required]
        [StringLength(10)]
        public string AC_CCODCI7US { get; set; }

        [Required]
        [StringLength(30)]
        public string AC_CCTAITBUS { get; set; }

        //codigo william
        /// <summary>
        /// Lista acreedor en Maestro - LQ/FT
        /// Filtro: x nombre,
        /// </summary>
        /// <param name="ADATA"></param>
        /// <returns></returns>
        public static List<CP0003MAES> listarMaestro(CP0003MAES ADATA)
        {   //string cod, string texto
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => x.AC_CVANEXO == ADATA.AC_CVANEXO
                            && (ADATA.AV_CDOCIDE != null ? x.AV_CDOCIDE == ADATA.AV_CDOCIDE : x.AV_CDOCIDE != ADATA.AV_CDOCIDE)
                            && (ADATA.AC_CTIPOAC != "" ? x.AC_CTIPOAC == ADATA.AC_CTIPOAC : x.AC_CTIPOAC != ADATA.AC_CTIPOAC)
                            && SqlFunctions.PatIndex(ADATA.AC_CNOMBRE, x.AC_CNOMBRE) > 0
                            && x.AC_CESTADO == "V").ToList();
                    //MODIFICACION 27.05.16
                    //&& (ADATA.AC_CTIPOAC != null ? x.AC_CTIPOAC == ADATA.AC_CTIPOAC : x.AC_CTIPOAC != ADATA.AC_CTIPOAC)
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        /// <summary>
        /// Lista acreedor Maestro
        /// Filtro: x codigo
        /// Actualizacion:--.--.----
        /// </summary>
        /// <param name="ADATA"></param>
        /// <returns></returns>
        public static List<CP0003MAES> listarMaestroID(CP0003MAES ADATA)
        {
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => x.AC_CVANEXO == ADATA.AC_CVANEXO
                            && (ADATA.AV_CDOCIDE != null ? x.AV_CDOCIDE == ADATA.AV_CDOCIDE : x.AV_CDOCIDE != ADATA.AV_CDOCIDE)
                            && (ADATA.AC_CTIPOAC != null ? x.AC_CTIPOAC == ADATA.AC_CTIPOAC : x.AC_CTIPOAC != ADATA.AC_CTIPOAC)
                            && SqlFunctions.PatIndex(ADATA.AC_CCODIGO, x.AC_CCODIGO) > 0
                            && x.AC_CESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static CP0003MAES listarMaestroxunID(CP0003MAES ADATA)
        {
            var lista = new CP0003MAES();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => x.AC_CVANEXO.Trim() == ADATA.AC_CVANEXO.Trim()
                            && ADATA.AC_CCODIGO.Trim() == x.AC_CCODIGO.Trim()
                            && x.AC_CESTADO == "V").FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<CP0003MAES> listarMaestroxDescripcion(CP0003MAES ADATA)
        {
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => x.AC_CVANEXO.Trim() == ADATA.AC_CVANEXO.Trim()
                            && (x.AC_CCODIGO.Trim().Contains(ADATA.AC_CCODIGO) ||
                            x.AC_CNOMBRE.Trim().Contains(ADATA.AC_CNOMBRE))
                            && x.AC_CESTADO == "V").ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        // CODIGO EDGAR
        // ENCONTRAR INCONSISTENCIA CON LA CUENTA DE DETRACCION
        public static string INCONSISTENCIACUENTADET(CP0003MAES ADATA)
        {
            var lista = "";
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => x.AC_CVANEXO.Trim() == ADATA.AC_CVANEXO.Trim()
                            && (x.AC_CCODIGO.Trim() == ADATA.AC_CCODIGO.Trim())).Select(X => X.AC_CCTADET).FirstOrDefault();
                    if (lista == null)
                    {
                        lista = "xx";
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<CP0003MAES> ListarMaestroDescr(CP0003EJED ADATA)
        {
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.Where(x => (x.AC_CCODIGO.Trim() == (ADATA.GD_CCODIGO).Trim())
                            && x.AC_CESTADO == "V" && x.AC_CVANEXO.Trim() == ADATA.GD_CVANEXO.Trim()).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static List<CP0003MAES> ListarTodo()
        {
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = ctx.CP0003MAES.OrderBy(X => X.AC_CNOMBRE).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        /// <summary>
        /// Original consulta proveedores que se buscan en cancelacion de documentos
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<CP0003MAES> ListarTodoPT(CP0003MAES DATA)
        {
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from a in ctx.CP0003MAES.Where(x => (DATA.AC_CVANEXO != null ? x.AC_CVANEXO.Trim() == DATA.AC_CVANEXO.Trim() : x.AC_CVANEXO != DATA.AC_CVANEXO.Trim()) &&
                                  (DATA.AC_CCODIGO != null ? x.AC_CCODIGO.Trim() == DATA.AC_CCODIGO.Trim() : x.AC_CCODIGO.Trim() != DATA.AC_CCODIGO.Trim()))
                             select new
                             {
                                 var001 = a.AC_CVANEXO,
                                 var010 = a.AC_CCODIGO,
                                 var002 = a.AC_CNOMBRE,
                                 var021 = a.AC_CTIPOAC,
                                 var003 = a.AC_CDIRECC,
                             }).ToList().Select(c => new CP0003MAES()
                             {
                                 AC_CVANEXO = c.var001,
                                 AC_CCODIGO = c.var010,
                                 AC_CNOMBRE = c.var002,
                                 AC_CTIPOAC = c.var021,
                                 AC_CDIRECC = c.var003,
                             }).ToList();//.FirstOrDefault();
                }
            }
            catch (Exception)
            {

            }
            return lista;
        }

        // FIN CODIGO EDGAR
        //OBTENER CUENTA BANCO - BANCO
        public static List<CP0003MAES> obtiene_banco_cuenta(CP0003MAES DATA)
        {
            //var lista = "";
            var lista = new List<CP0003MAES>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from a in ctx.CP0003MAES.Where(x => x.AC_CVANEXO.Trim() == DATA.AC_CVANEXO.Trim() &&
                                x.AC_CCODIGO.Trim() == DATA.AC_CCODIGO.Trim())
                             select new
                             {
                                 var001 = a.AC_CCTAMNT,
                                 var010 = a.AC_CCTAUST,
                                 var002 = a.AC_CCTAMN7,
                                 var021 = a.AC_CCTAUS7,
                                 var003 = a.AC_CCTAMNK,
                                 var031 = a.AC_CCTAUSK,
                                 var03 = a.AC_CCTADET
                             }).ToList().Select(c => new CP0003MAES()
                             {
                                 AC_CCTAMNT = c.var001,
                                 AC_CCTAUST = c.var010,
                                 AC_CCTAMN7 = c.var002,
                                 AC_CCTAUS7 = c.var021,
                                 AC_CCTAMNK = c.var003,
                                 AC_CCTAUSK = c.var031,
                                 AC_CCTADET = c.var03
                             }).ToList();//.FirstOrDefault();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }
        public static List<vista_pago> obtiene_banco_cuenta2(CP0003MAES DATA, string MONEDA)
        {
            //var lista = "";
            var lista = new List<vista_pago>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    lista = (from a in ctx.CP0003MAES.Where(x => x.AC_CVANEXO.Trim() == DATA.AC_CVANEXO.Trim() &&
                                x.AC_CCODIGO.Trim() == DATA.AC_CCODIGO.Trim())
                             select new
                             {
                                 var100 = a.AC_CCTAMN,/*SCOTIBANK:TELEWIESE*/
                                 var110 = a.AC_CCTAUS,/*SCOTIBANK:TELEWIESE*/
                                 var001 = a.AC_CCTAMNT,/*BCP*/
                                 var010 = a.AC_CCTAUST,/*BCP*/
                                 var002 = a.AC_CCTAMN7,/*BBVA*/
                                 var021 = a.AC_CCTAUS7,/*BBVA*/
                                 var003 = a.AC_CCTAMNK,/*INTERBANK*/
                                 var031 = a.AC_CCTAUSK,/*INTERBANK*/
                                 var03 = a.AC_CCTADET
                             }).ToList().Select(c => new vista_pago()
                             {
                                 CT_CTCARGO = (DATA.AC_CABREVI.Trim() == "CREDITO" ? (MONEDA == "MN" ? c.var001 : c.var010) :
                                                (DATA.AC_CABREVI.Trim() == "BBVA" || DATA.AC_CABREVI.Trim() == "CONTINENTA" ? (MONEDA == "MN" ? c.var002 : c.var021) :
                                                   (DATA.AC_CABREVI.Trim() == "INTERBANK" ? (MONEDA == "MN" ? c.var003 : c.var031) :
                                                    (DATA.AC_CABREVI.Trim() == "SCOTIABANK" ? (MONEDA == "MN" ? c.var100 : c.var110) : ""))))
                             }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

    }
}
