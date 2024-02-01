namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    public partial class CP0003CART
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(1)]
        public string CP_CVANEXO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(18)]
        public string CP_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string CP_CTIPDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(20)]
        public string CP_CNUMDOC { get; set; }

        [Required]
        [StringLength(6)]
        public string CP_CFECDOC { get; set; }


        [StringLength(6)]
        public string CP_CFECVEN { get; set; }

        [Required]
        [StringLength(6)]
        public string CP_CFECREC { get; set; }

        [Required]
        [StringLength(1)]
        public string CP_CSITUAC { get; set; }

        [Required]
        [StringLength(6)]
        public string CP_CFECCOM { get; set; }

        [Required]
        [StringLength(4)]
        public string CP_CSUBDIA { get; set; }

        [Required]
        [StringLength(6)]
        public string CP_CCOMPRO { get; set; }

        [Required]
        [StringLength(1)]
        public string CP_CDEBHAB { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CCODMON { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CP_NTIPCAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIMPOMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIMPOUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CP_NSALDMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? CP_NSALDUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIGVMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIGVUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIMP2MN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIMP2US { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NIMPAJU { get; set; }

        [Required]
        [StringLength(12)]
        public string CP_CCUENTA { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CAREA { get; set; }

        [Required]
        [StringLength(6)]
        public string CP_CFECUBI { get; set; }

        [Required]
        [StringLength(2)]
        public string CP_CTDOCRE { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CNDOCRE { get; set; }


        [StringLength(6)]
        public string CP_CFDOCRE { get; set; }


        [StringLength(2)]
        public string CP_CTDOCCO { get; set; }


        [StringLength(10)]
        public string CP_CNDOCCO { get; set; }


        [StringLength(6)]
        public string CP_CFDOCCO { get; set; }


        [StringLength(6)]
        public string CP_CFECPRO { get; set; }


        [StringLength(1)]
        public string CP_CFORMPG { get; set; }


        [StringLength(12)]
        public string CP_CCOGAST { get; set; }

        [Required]
        [StringLength(20)]
        public string CP_CDESCRI { get; set; }

        public DateTime? CP_DFECCRE { get; set; }

        public DateTime? CP_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string CP_CUSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NINAFEC { get; set; }


        [StringLength(2)]
        public string CP_CTIPSUN { get; set; }

        public DateTime? CP_DFECDOC { get; set; }

        public DateTime? CP_DFECVEN { get; set; }

        public DateTime? CP_DFECREC { get; set; }

        public DateTime? CP_DFECCOM { get; set; }

        public DateTime? CP_DFDOCRE { get; set; }

        public DateTime? CP_DFDOCCO { get; set; }

        public DateTime? CP_DFECPRO { get; set; }

        public DateTime? CP_DFECUBI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_CIMAGEN { get; set; }

        [StringLength(1)]
        public string CP_CVANERF { get; set; }

        [StringLength(18)]
        public string CP_CCODIRF { get; set; }


        [StringLength(20)]
        public string CP_CNUMORD { get; set; }


        [StringLength(1)]
        public string CP_CTIPO { get; set; }


        [StringLength(6)]
        public string CP_CFECCAM { get; set; }

        public DateTime? CP_DFECCAM { get; set; }


        [StringLength(8)]
        public string CP_CTASDET { get; set; }


        [StringLength(4)]
        public string CP_CSECDET { get; set; }


        [StringLength(6)]
        public string CP_CCENCOR { get; set; }


        [StringLength(1)]
        public string CP_CRETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal CP_NPORRE { get; set; }

        public class vista_cart
        {
            public string CP_CVANEXO { get; set; }
            public string CP_CCODIGO { get; set; }
            public string AC_CNOMBRE { get; set; }
            public String NOMCEN { get; set; }

        }


        /// <summary>
        /// Buscar documento registrado en cartera de pagos
        /// Creado:10.05.2016
        /// </summary>
        /// <param name="texto"></param>
        /// <returns></returns>
        public static CP0003CART obtenerDOC(CP0003CART DATA)
        {
            var result = new CP0003CART();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    result = ctx.CP0003CART.Where(x => x.CP_CVANEXO == DATA.CP_CVANEXO
                                                        && x.CP_CCODIGO == DATA.CP_CCODIGO
                                                        && x.CP_CTIPDOC == DATA.CP_CTIPDOC
                                                        && x.CP_CNUMDOC == DATA.CP_CNUMDOC).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return result;
        }

        /// <summary>
        /// Inserta un registro de cartera de pagos pendientes - sispag
        /// Creado:14/04/2016
        /// Modificacion:--/--/---
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static Boolean insertar(CP0003CART DATA)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(DATA).State = EntityState.Added;
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
        /// 
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<vistas_finanzas> listar(CP0003CART DATA)
        {
            DateTime Hoy = DateTime.Today;
            List<vistas_finanzas> list = new List<vistas_finanzas>();
            var lista1 = new List<tabla_parametros>();
            string[] mv1 = new string[0];
            try
            {
                using (var ctx1 = new ANEXO_RSFACAR())
                {
                    var DATASO = new tabla_parametros();
                    DATASO.AF_COD = "SO";
                    lista1 = tabla_parametros.ListarParametro(DATASO);
                    var count = 0;
                    mv1 = new string[lista1.Count];
                    foreach (var mv in lista1)
                    {
                        mv1[count] = mv.AF_TDESCRI1;
                        count++;
                    }
                }

                using (var ctx = new RSCONCAR())
                {
                    list = (from c in ctx.CP0003CART
                            join M in ctx.CP0003MAES //on new { CP_CVANEXO = M.AC_CVANEXO } equals new { C6_CCODIGO = MOVG.C6_CCODIGO }
                             on new { c.CP_CVANEXO, c.CP_CCODIGO }
                               equals new { CP_CVANEXO = M.AC_CVANEXO, CP_CCODIGO = M.AC_CCODIGO }
                               /*join T in ctx.CT0003TAGE
                                on new { c.CP_CCENCOR }
                                   equals new { CP_CCENCOR = T.TCLAVE.Trim() }*/
                               /*join D in ctx.CP0003TAGE
                                    on new { c.CP_CAREA }
                                    equals new { CP_CAREA = D.TG_CODIGO.Trim() }*/
                            where (
                                (DATA.CP_CSITUAC != "" ? c.CP_CSITUAC == DATA.CP_CSITUAC : c.CP_CSITUAC != DATA.CP_CSITUAC) &&
                                (DATA.CP_CVANEXO != null ? c.CP_CVANEXO == DATA.CP_CVANEXO : c.CP_CVANEXO != DATA.CP_CVANEXO) &&
                                (DATA.CP_CTIPDOC != null ? c.CP_CTIPDOC == DATA.CP_CTIPDOC : c.CP_CTIPDOC != DATA.CP_CTIPDOC) &&
                                //(DATA.CP_CAREA != null ? c.CP_CAREA == DATA.CP_CAREA : c.CP_CAREA != DATA.CP_CAREA) &&
                                //(DATA.CP_CTDOCRE != "" ? c.CP_CTDOCRE == DATA.CP_CTDOCRE : c.CP_CTDOCRE != DATA.CP_CTDOCRE) &&
                                (DATA.CP_CSUBDIA != "" ? c.CP_CSUBDIA.Trim() == DATA.CP_CSUBDIA : mv1.Contains(c.CP_CSUBDIA)) &&
                                //(DATA.CP_CCENCOR != "" ? c.CP_CCENCOR.Trim() == DATA.CP_CCENCOR : c.CP_CCENCOR.Trim() != DATA.CP_CCENCOR) &&
                                (c.CP_DFECCRE >= DATA.CP_DFECDOC && c.CP_DFECCRE <= DATA.CP_DFECUBI)
                            //(c.CP_DFECDOC.Value.Year == Hoy.Year && c.CP_DFECDOC.Value.Month == 7) &&
                            //c.CP_DFDOCRE != null &&
                            //T.TCOD.Trim() == "05" &&
                            //D.TG_INDICE == "90"
                            )
                            //orderby c.CP_CSITUAC, c.CP_CVANEXO, c.CP_CCODIGO, c.CP_CTIPDOC, c.CP_CNUMDOC
                            orderby c.CP_CNDOCRE descending
                            select new
                            {
                                CP_CVANEXO = c.CP_CVANEXO,
                                CP_CCODIGO = c.CP_CCODIGO,
                                NOMTIT = M.AC_CNOMBRE,
                                CP_CTIPDOC = c.CP_CTIPDOC,
                                CP_CNUMDOC = c.CP_CNUMDOC,
                                CP_CCODMON = c.CP_CCODMON,
                                IMPORTE = (c.CP_CCODMON == "US" ? c.CP_NIMPOUS : c.CP_NIMPOMN),
                                CP_CTDOCRE = c.CP_CTDOCRE,
                                CP_CSITUAC = c.CP_CSITUAC,
                                CP_CNDOCRE = c.CP_CNDOCRE,
                                //CP_DFDOCRE = c.CP_DFDOCRE,
                                CP_DFECCRE = c.CP_DFECCRE,
                                CP_CCENCOR = c.CP_CCENCOR.Trim(),
                                CENCOR = ctx.CT0003TAGE.Where(x => x.TCOD == "05" && x.TCLAVE == c.CP_CCENCOR.Trim()).Select(x => x.TDESCRI).FirstOrDefault(),//T.TDESCRI,
                                NOMARE = "",//D.TG_DESCRI,
                                CP_CUSER = c.CP_CUSER
                            }).ToList().Select(a => new vistas_finanzas()
                            {
                                CP_CVANEXO = a.CP_CVANEXO,
                                CP_CCODIGO = a.CP_CCODIGO.Trim(),
                                NOMTIT = a.NOMTIT.Trim(),
                                CP_CTIPDOC = a.CP_CTIPDOC,
                                CP_CNUMDOC = a.CP_CNUMDOC.Trim(),
                                CP_CCODMON = a.CP_CCODMON,
                                IMPORTE = a.IMPORTE,
                                CP_CTDOCRE = a.CP_CTDOCRE,
                                CP_CSITUAC = a.CP_CSITUAC,
                                CP_CNDOCRE = a.CP_CNDOCRE.Trim(),
                                CP_DFECCRE1 = String.Format("{0:dd/MM/yyyy}", a.CP_DFECCRE),
                                CP_CCENCOR = a.CP_CCENCOR.Trim(),
                                CENCOR = a.CENCOR,
                                NOMARE = a.NOMARE,
                                CP_CUSER = a.CP_CUSER
                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return list;
        }
        // CODIGO EDGAR
        // INTERFAZ PAGGO DETRACCION INDIVIDUAL

        public static List<CP0003CART> DetraccionIndividual()
        {
            DateTime fecha = DateTime.Today;
            var cty = new RSFACAR();
            List<CP0003CART> list = new List<CP0003CART>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where a.CP_CCUENTA == "421205" && a.CP_DFECVEN < fecha && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != ""
                            orderby a.CP_CCODIGO

                            select new
                            {
                                comprobante = a.CP_CCOMPRO,
                                ruc = a.CP_CCODIGO,
                                moneda = a.CP_CCODMON,
                                saldomn = a.CP_NSALDMN,
                                saldodol = a.CP_NSALDUS,
                                tipo = a.CP_CTASDET,
                                vence = a.CP_DFECVEN,
                                factura1 = a.CP_CTIPDOC,
                                factura2 = a.CP_CNUMDOC,
                                monedacab = ((from b in ctx.CP0003CART
                                              where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                             a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                             && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                              select new { b.CP_CCODMON }).FirstOrDefault().CP_CCODMON),

                                montosol = (decimal?)((from b in ctx.CP0003CART
                                                       where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                                         a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                                       && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                                       select new { b.CP_NSALDMN }).FirstOrDefault().CP_NSALDMN),
                                montodol = (decimal?)((from b in ctx.CP0003CART
                                                       where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                                      a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                             && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                                       select new { b.CP_NSALDUS }).FirstOrDefault().CP_NSALDUS),
                                SUBDIARIO = a.CP_CSUBDIA,

                                ORDEN = ((from b in ctx.CP0003CART
                                          where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                         a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim() && b.CP_CTDOCRE.Trim() == "OC"
                                          select new { b.CP_CNDOCRE }).FirstOrDefault().CP_CNDOCRE),


                            }).ToList().Select(c => new CP0003CART()
                            {
                                CP_CCOMPRO = c.comprobante,
                                CP_CDESCRI = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == c.ruc.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                CP_CCODIGO = c.ruc,
                                CP_CCODMON = c.moneda,
                                CP_NSALDMN = c.saldomn,
                                CP_NSALDUS = c.saldodol,
                                CP_CTASDET = c.tipo,
                                CP_DFECVEN = c.vence,
                                CP_CTIPDOC = c.factura2,
                                CP_CNUMDOC = (c.monedacab == "MN" ? Convert.ToString(c.montosol) : Convert.ToString(c.montodol)),
                                CP_CAREA = (c.vence < fecha ? "VENCIDO" : ""),
                                CP_CSITUAC = (c.ORDEN != null ?
                                cty.AL0003MOVC.Where(x => x.C5_CRFNDOC.Trim() == c.factura2.Trim() && x.C5_CCODPRO.Trim() == c.ruc.Trim() && c.factura1 == "FT").Select(X => X.C5_CNUMDOC).FirstOrDefault() :
                                ""),
                                CP_CCODIRF = c.ORDEN,
                            }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public static List<CP0003CART> DetraccionIndividualfiltro(CP0003CART ADATA)
        {
            DateTime fecha = DateTime.Today;

            List<CP0003CART> list = new List<CP0003CART>();
            try
            {
                var cty = new RSFACAR();

                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where a.CP_CCUENTA == "421205 " && a.CP_DFECVEN < fecha && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != ""
                            && (ADATA.CP_CCODIGO.Trim() != "" ? a.CP_CCODIGO.Trim() == ADATA.CP_CCODIGO.Trim() : a.CP_CCODIGO.Trim() != ADATA.CP_CCODIGO.Trim())
                            && (ADATA.CP_CTASDET.Trim() != "-1" ? a.CP_CTASDET.Trim() == ADATA.CP_CTASDET.Trim() : a.CP_CTASDET.Trim() != ADATA.CP_CTASDET.Trim())
                            orderby a.CP_CCODIGO
                            //ADATA.CP_CCODIGO != null ||
                            //ADATA.CP_CTASDET != null ||
                            select new
                            {
                                comprobante = a.CP_CCOMPRO,
                                ruc = a.CP_CCODIGO,
                                moneda = a.CP_CCODMON,
                                saldomn = a.CP_NSALDMN,
                                saldodol = a.CP_NSALDUS,
                                tipo = a.CP_CTASDET,
                                vence = a.CP_DFECVEN,
                                factura1 = a.CP_CTIPDOC,
                                factura2 = a.CP_CNUMDOC,
                                monedacab = ((from b in ctx.CP0003CART
                                              where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                             a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                             && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                              select new { b.CP_CCODMON }).FirstOrDefault().CP_CCODMON),

                                montosol = (decimal?)((from b in ctx.CP0003CART
                                                       where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                                         a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                                       && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                                       select new { b.CP_NSALDMN }).FirstOrDefault().CP_NSALDMN),
                                montodol = (decimal?)((from b in ctx.CP0003CART
                                                       where b.CP_CCUENTA != "421205" && a.CP_DFECVEN < fecha &&
                                                      a.CP_CNUMDOC.Trim() == b.CP_CNUMDOC.Trim() + "-D" && a.CP_CCODIGO.Trim() == b.CP_CCODIGO.Trim()
                                             && a.CP_CTIPDOC.Trim() == b.CP_CTIPDOC.Trim() && a.CP_CVANEXO.Trim() == b.CP_CVANEXO.Trim()
                                                       select new { b.CP_NSALDUS }).FirstOrDefault().CP_NSALDUS),
                                SUBDIARIO = a.CP_CSUBDIA,
                                ORDEN = a.CP_CNDOCRE,




                            }).ToList().Select(c => new CP0003CART()
                            {
                                CP_CCOMPRO = c.comprobante,
                                CP_CCODIGO = c.ruc,
                                CP_CDESCRI = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == c.ruc.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                CP_CCODMON = c.moneda,
                                CP_NSALDMN = c.saldomn,
                                CP_NSALDUS = c.saldodol,
                                CP_CTASDET = c.tipo,
                                CP_DFECVEN = c.vence,
                                CP_CTIPDOC = c.factura1 + "" + c.factura2,
                                CP_CNUMDOC = (c.monedacab == "MN" ? Convert.ToString(c.montosol) : Convert.ToString(c.montodol)),
                                CP_CAREA = (c.vence > fecha ? "" : "VENCIDO"),
                                CP_CSITUAC = (c.SUBDIARIO.Trim() == "11" ? cty.AL0003MOVC.Where(x => x.C5_CRFNDOC.Trim() == c.factura2.Trim() && x.C5_CRFTDOC.Trim() == "FT").Select(X => X.C5_CNUMDOC).FirstOrDefault() : ""),
                                CP_CCODIRF = (c.SUBDIARIO.Trim() == "11" ? cty.AL0003MOVC.Where(x => x.C5_CRFNDOC.Trim() == c.factura2.Trim() && x.C5_CRFTDOC.Trim() == "FT").Select(X => X.C5_CNUMDOC).FirstOrDefault() : c.ORDEN.Trim()),
                            }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public static List<CP0003CART> ConsultaReferencia(CP0003CART adata)
        {
            DateTime fecha = DateTime.Today;
            int LONG = adata.CP_CNUMDOC.Trim().Length;
            string VAR = adata.CP_CNUMDOC.Trim().Substring(0, (LONG - 2));
            string FIN = VAR.Substring(0, VAR.Length);


            List<CP0003CART> list = new List<CP0003CART>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    list = ctx.CP0003CART.Where(a => a.CP_CCUENTA != "421205 " && a.CP_CCODIGO.Trim() == adata.CP_CCODIGO.Trim()
                    //&& a.CP_DFECVEN < fecha  && a.CP_CTDOCRE != "" && a.CP_NSALDMN > 0
                    && a.CP_CNUMDOC.Trim() == FIN).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }
        public static List<CP0003CART> ConsultaDetracciones(CP0003CART adata)
        {
            DateTime fecha = DateTime.Today;
            int LONG = adata.CP_CNUMDOC.Trim().Length;
            string FIN = adata.CP_CNUMDOC.Trim().Substring(0, LONG);

            List<CP0003CART> list = new List<CP0003CART>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where (a.CP_CCUENTA == "421205 " && a.CP_DFECVEN < fecha && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != ""
                             && a.CP_CNUMDOC.Trim() == FIN)
                            select new
                            {
                                CP_NSALDMN = a.CP_NSALDMN,
                                CP_CTASDET = a.CP_CTASDET,
                                detraccion = ctx.CT0003TAGE.Where(x => x.TCOD == "28" && x.TCLAVE == a.CP_CTASDET).Select(x => x.TDESCRI).FirstOrDefault(),
                                PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == adata.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                            }

                        ).ToList().Select(c => new CP0003CART()
                        {
                            CP_NSALDMN = c.CP_NSALDMN,
                            CP_CTASDET = c.CP_CTASDET,
                            CP_CAREA = c.detraccion.Trim(),
                            CP_CCODIGO = c.PROVEEDOR,
                        }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public static List<CP0003CART> consultadatosparaejecucion(CP0003EJED adata)
        {

            List<CP0003CART> list = new List<CP0003CART>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where (a.CP_CCUENTA == "421205 " && a.CP_CNUMDOC.Trim() == adata.GD_CNUMDOC.Trim()
                            && a.CP_CTIPDOC.Trim() == adata.GD_CTIPDOC.Trim() && a.CP_CCODIGO.Trim() == adata.GD_CCODIGO.Trim()
                            && a.CP_CVANEXO.Trim() == adata.GD_CVANEXO.Trim()
                            )
                            select new
                            {
                                GD_CSUBCOM = a.CP_CSUBDIA,
                                GD_CNUMCOM = a.CP_CCOMPRO,
                                GD_CSECCOM = a.CP_CSECDET,
                                GD_CTDREF = a.CP_CTIPDOC,
                                GD_CNDREF = a.CP_CNDOCRE,
                                GD_NTCORI = a.CP_NTIPCAM,
                            }

                        ).ToList().Select(c => new CP0003CART()
                        {
                            CP_CSUBDIA = c.GD_CSUBCOM,
                            CP_CCOMPRO = c.GD_CNUMCOM,
                            CP_CSECDET = c.GD_CSECCOM,
                            CP_CTIPDOC = c.GD_CTDREF,
                            CP_CNDOCRE = c.GD_CNDREF,
                            CP_NTIPCAM = c.GD_NTCORI,
                        }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public static List<CP0003PAGO> ConsultaPagos(CP0003CART adata)
        {
            DateTime fecha = DateTime.Today;
            //int LONG = adata.CP_CNUMDOC.Trim().Length;
            //string VAR = adata.CP_CNUMDOC.Trim().Substring(0, (LONG - 2));
            //string FIN = VAR.Substring(2, (VAR.Length - 2));


            List<CP0003PAGO> list = new List<CP0003PAGO>();
            try
            {
                if (adata.CP_CNUMDOC.Trim() != "")
                {
                    using (var ctx = new RSCONCAR())
                    {
                        list = ctx.CP0003PAGO.Where(a => a.PG_CNUMDOC.Trim() == adata.CP_CNUMDOC.Trim() && a.PG_CCODIGO.Trim() == adata.CP_CCODIGO.Trim()).ToList();
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        // INTERFAZ PARA CREAR UNA PROGRAMACION NUEVA  GRILLA TOTALES para detracciones.
        public static List<vista_totales_programacion> LISTARTOTALES(string VC) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_totales_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    string[] arreglo = ctx.CP0003PRGD.Select(X => X.GD_CNUMDOC.Trim()).ToArray();

                    alumnos = (from a in ctx.CP0003CART
                               where (a.CP_CCUENTA.Trim() == VC.Trim() && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != "" && a.CP_DFECVEN < fecha
                               && !(arreglo.Contains(a.CP_CNUMDOC.Trim()))
                    )
                               group new { a } by new
                               {
                                   a.CP_CCODIGO,
                                   a.CP_CVANEXO,

                               } into g

                               select new
                               {
                                   ANE = g.Key.CP_CVANEXO,
                                   CODIGO = g.Key.CP_CCODIGO,
                                   PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),

                                   VENCIDO = g.Where(s => s.a.CP_CCUENTA == VC.Trim() && s.a.CP_NSALDMN > 0 && s.a.CP_CTDOCRE != "" && s.a.CP_DFECVEN <= fecha &&
                                   !(arreglo.Contains(s.a.CP_CNUMDOC))).Sum(s => (decimal?)s.a.CP_NSALDMN),

                                   PORVENCER = g.Where(s => s.a.CP_CCUENTA == VC.Trim() && s.a.CP_NSALDMN > 0 && s.a.CP_CTDOCRE != "" && s.a.CP_DFECVEN > fecha &&
                                   !(arreglo.Contains(s.a.CP_CNUMDOC))).Sum(s => (decimal?)s.a.CP_NSALDMN) + 0,

                               }).ToList()
                           .Select(c => new vista_totales_programacion()
                           {
                               Ane = c.ANE,
                               Codigo = c.CODIGO,
                               Acreedor = c.PROVEEDOR,
                               Vencido = c.VENCIDO,
                               PorVencer = c.PORVENCER,
                               STotal = c.VENCIDO + c.PORVENCER,


                           }).OrderBy(x => x.Codigo).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<CP0003CART> SELECTDETALLES(CP0003CART CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003CART>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    string[] arreglo = ctx.CP0003PRGD.Select(X => X.GD_CNUMDOC.Trim()).ToArray();
                    alumnos = (from x in ctx.CP0003CART.Where(a => a.CP_CCODIGO == CODATA.CP_CCODIGO && a.CP_CCUENTA == CODATA.CP_CCUENTA
                               && a.CP_CVANEXO == CODATA.CP_CVANEXO && a.CP_DFECVEN < fecha
                                        && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != "" && !(arreglo.Contains(a.CP_CNUMDOC.Trim())))
                               select new
                               {
                                   CP_CTIPDOC = x.CP_CTIPDOC,
                                   CP_CNUMDOC = x.CP_CNUMDOC,
                                   CP_DFECDOC = x.CP_DFECDOC,
                                   CP_DFECVEN = x.CP_DFECVEN,
                                   CP_CCODMON = x.CP_CCODMON,
                                   CP_NSALDMN = x.CP_NSALDMN,
                                   CP_CRETE = x.CP_CRETE,
                                   CP_CTASDET = x.CP_CTASDET,
                               }).ToList()
                           .Select(c => new CP0003CART()
                           {
                               CP_CTIPDOC = c.CP_CTIPDOC,
                               CP_CNUMDOC = c.CP_CNUMDOC,
                               CP_DFECDOC = c.CP_DFECDOC,
                               CP_DFECVEN = c.CP_DFECVEN,
                               CP_CCODMON = c.CP_CCODMON,
                               CP_NSALDMN = c.CP_NSALDMN,
                               CP_CRETE = c.CP_CRETE,
                               CP_CTASDET = c.CP_CTASDET
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<CP0003CART> SELECTDETALLESPARAMODPROG(CP0003CART CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003CART>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from x in ctx.CP0003CART.Where(a => a.CP_CCODIGO == CODATA.CP_CCODIGO && a.CP_CCUENTA == CODATA.CP_CCUENTA
                               && a.CP_CVANEXO == CODATA.CP_CVANEXO && a.CP_DFECVEN < fecha
                                        && a.CP_NSALDMN > 0 && a.CP_CTDOCRE != "")
                               select new
                               {
                                   CP_CTIPDOC = x.CP_CTIPDOC,
                                   CP_CNUMDOC = x.CP_CNUMDOC,
                                   CP_DFECDOC = x.CP_DFECDOC,
                                   CP_DFECVEN = x.CP_DFECVEN,
                                   CP_CCODMON = x.CP_CCODMON,
                                   CP_NSALDMN = x.CP_NSALDMN,
                                   CP_CRETE = x.CP_CRETE,
                                   CP_CTASDET = x.CP_CTASDET,
                               }).ToList()
                           .Select(c => new CP0003CART()
                           {
                               CP_CTIPDOC = c.CP_CTIPDOC,
                               CP_CNUMDOC = c.CP_CNUMDOC,
                               CP_DFECDOC = c.CP_DFECDOC,
                               CP_DFECVEN = c.CP_DFECVEN,
                               CP_CCODMON = c.CP_CCODMON,
                               CP_NSALDMN = c.CP_NSALDMN,
                               CP_CRETE = c.CP_CRETE,
                               CP_CTASDET = c.CP_CTASDET
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }
        /// <summary>
        /// PARA FILTAR EL DETALLE DE LOS PGOS PENDIENTES DE UN PROVEEDOR
        /// </summary>
        /// <param name="CODATA"></param>
        /// <returns></returns>
        public static List<CP0003CART> SELECTDETALLESCHEQUES(CP0003CART CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003CART>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    string[] arreglo = ctx.CP0003PRGD.Select(X => X.GD_CNUMDOC.Trim()).ToArray();
                    alumnos = (from x in ctx.CP0003CART.Where(a => a.CP_CCODIGO.Trim() == CODATA.CP_CCODIGO.Trim() && a.CP_NSALDMN > 0
                               && a.CP_CVANEXO.Trim() == CODATA.CP_CVANEXO.Trim()
                              && !(arreglo.Contains(a.CP_CNUMDOC.Trim())))
                               select new
                               {
                                   CP_CTIPDOC = x.CP_CTIPDOC,
                                   CP_CNUMDOC = x.CP_CNUMDOC,
                                   CP_DFECDOC = x.CP_DFECDOC,
                                   CP_DFECVEN = x.CP_DFECVEN,
                                   CP_CCODMON = x.CP_CCODMON,
                                   CP_NIMPOMN = x.CP_NIMPOMN,
                                   CP_NIMPOUS = x.CP_NIMPOUS,
                                   CP_NSALDMN = x.CP_NSALDMN,
                                   CP_NSALDUS = x.CP_NSALDUS,
                                   CP_CRETE = x.CP_CRETE,
                                   CP_NPORRE = x.CP_NPORRE,
                                   CP_NTIPCAM = x.CP_NTIPCAM,

                               }).ToList()
                           .Select(c => new CP0003CART()
                           {
                               CP_CTIPDOC = c.CP_CTIPDOC,
                               CP_CNUMDOC = c.CP_CNUMDOC,
                               CP_DFECDOC = c.CP_DFECDOC,
                               CP_DFECVEN = c.CP_DFECVEN,
                               CP_CCODMON = c.CP_CCODMON,
                               CP_NIMPOMN = c.CP_NIMPOMN,
                               CP_NIMPOUS = c.CP_NIMPOUS,
                               CP_NSALDMN = c.CP_NSALDMN,
                               CP_NSALDUS = c.CP_NSALDUS,
                               CP_CRETE = c.CP_CRETE,
                               CP_NPORRE = c.CP_NPORRE,
                               CP_NTIPCAM = c.CP_NTIPCAM,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }
        /// <summary>
        /// aCTUALIZAR EL MONTO DEL SALDO A CERO UNA VEZ EJECUTADA LA PROGRAMACION.
        /// </summary>
        /// <param name="COM"></param>
        public static void actualizarsaldoENEJECUCION(CP0003CART COM)
        {
            var orden = new CP0003CART
            {
                CP_CVANEXO = COM.CP_CVANEXO,
                CP_CCODIGO = COM.CP_CCODIGO,
                CP_CTIPDOC = COM.CP_CTIPDOC,
                CP_CNUMDOC = COM.CP_CNUMDOC
            };

            using (var ctx = new RSCONCAR())
            {
                ctx.CP0003CART.Attach(orden);
                orden.CP_NSALDMN = 0;
                orden.CP_NSALDUS = 0;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static List<CP0003CART> mi_resumen(CP0003CART DATA)
        {
            //DateTime fecha = DateTime.Today;
            var lista = new List<CP0003CART>();
            var lista1 = new List<tabla_parametros>();
            string[] mv1 = new string[0];
            try
            {
                using (var ctx1 = new ANEXO_RSFACAR())
                {
                    var DATASO = new tabla_parametros();
                    DATASO.AF_COD = "SO";
                    lista1 = tabla_parametros.ListarParametro(DATASO);
                    var count = 0;
                    mv1 = new string[lista1.Count];
                    foreach (var mv in lista1)
                    {
                        mv1[count] = mv.AF_TDESCRI1;
                        count++;
                    }
                }

                using (var ctx = new RSCONCAR())
                {


                    lista = (from x in ctx.CP0003CART.Where(a => a.CP_CVANEXO == DATA.CP_CVANEXO &&
                               (DATA.CP_CTIPDOC != null ?
                                a.CP_CTIPDOC == DATA.CP_CTIPDOC : a.CP_CTIPDOC != DATA.CP_CTIPDOC) &&
                                a.CP_CSITUAC == DATA.CP_CSITUAC &&
                                (DATA.CP_CSUBDIA != null ?
                                    //(DATA.CP_CSUBDIA == "1" ? (new string[] { "11", "13", "17", "18", "31", "40" }).Contains(a.CP_CSUBDIA) :
                                    (DATA.CP_CSUBDIA == "1" ? mv1.Contains(a.CP_CSUBDIA) :
                                        a.CP_CSUBDIA == DATA.CP_CSUBDIA) : a.CP_CSUBDIA != DATA.CP_CSUBDIA) &&
                                (a.CP_DFECCRE >= DATA.CP_DFECCRE && a.CP_DFECCRE <= DATA.CP_DFECMOD)
                              //&& (new string[] { "11, "13" }).Contains(a.CP_CSUBDIA)//
                              )
                             group new { x } by new
                             {
                                 x.CP_CUSER,
                                 x.CP_CSUBDIA,
                             } into g
                             select new
                             {
                                 CP_CUSER = g.Key.CP_CUSER,
                                 CP_CSUBDIA = g.Key.CP_CSUBDIA,
                                 CP_CAREA = (g.Key.CP_CSUBDIA == "11" ? "COMPRAS" : (g.Key.CP_CSUBDIA == "13" ? "SERVICIOS" : "OTROS")),
                                 CP_NIMP2MN = g.Count()
                             }).ToList().Select(c => new CP0003CART()
                             {
                                 CP_CUSER = c.CP_CUSER,
                                 CP_CSUBDIA = c.CP_CSUBDIA,
                                 CP_CAREA = c.CP_CAREA,
                                 CP_NIMP2MN = c.CP_NIMP2MN
                             }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return lista;
        }

        public static List<CP0003CART> ConsultaDetraccionesPorPagar(CP0003CART adata)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            List<CP0003CART> list = new List<CP0003CART>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where (a.CP_NSALDMN > 0 && a.CP_NSALDUS > 0
                            && a.CP_CTIPDOC == "FT" && a.CP_DFECVEN < DateTime.Today
                            && a.CP_CCODMON == "MN" && a.CP_CCUENTA.Trim() == adata.CP_CCUENTA.Trim()
                            && a.CP_CTASDET.Trim() != ""
                // && ((proveedor!=null || proveedor !="")? a.CP_CCODIGO.Trim() == proveedor.Trim() : a.CP_CCODIGO.Trim() != proveedor.Trim() )
                // && ((tasdet == null || tasdet == "" || tasdet.Trim() == "99999") ? a.CP_CTASDET != tasdet : a.CP_CTASDET == tasdet )
                )
                            select new
                            {
                                CP_CCODIGO = a.CP_CCODIGO,
                                PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == a.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                CP_CTIPDOC = a.CP_CTIPDOC,
                                CP_CNUMDOC = a.CP_CNUMDOC,
                                CP_CCODMON = a.CP_CCODMON,
                                SALDO = ctx.CP0003CART.Where(x => x.CP_CNUMDOC.Trim() == a.CP_CNUMDOC.Trim().Substring(0, a.CP_CNUMDOC.Trim().Length - 2)).Select(x => x.CP_NSALDMN).FirstOrDefault(),
                                CP_NSALDMN = a.CP_NSALDMN,
                                CP_CTASDET = a.CP_CTASDET,
                                CP_DFECVEN = a.CP_DFECVEN,
                            }
                        ).ToList().Select(c => new CP0003CART()
                        {
                            CP_CCODIGO = c.CP_CCODIGO,
                            CP_CDESCRI = c.PROVEEDOR,
                            CP_CNUMDOC = c.CP_CTIPDOC + "-" + c.CP_CNUMDOC,
                            CP_CCODMON = c.CP_CCODMON,
                            CP_NSALDUS = c.SALDO,
                            CP_NSALDMN = c.CP_NSALDMN,
                            CP_CTASDET = c.CP_CTASDET,
                            CP_CNDOCCO = String.Format("{0:dd/MM/yyyy}", c.CP_DFECVEN),
                            CP_CTIPO = "VENCIDO",
                        }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        public static List<CP0003CART> ConsultaDetraccionesPorPagarF(CP0003CART ADATA)
        {
            CultureInfo culture = new CultureInfo("pt-BR");
            List<CP0003CART> list = new List<CP0003CART>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    list = (from a in ctx.CP0003CART
                            where (a.CP_NSALDMN > 0 && a.CP_NSALDUS > 0
                            && a.CP_CTIPDOC == "FT" && a.CP_DFECVEN < DateTime.Today
                            && a.CP_CCODMON == "MN" && a.CP_CCUENTA == "421205" && a.CP_CTASDET.Trim() != ""
                            && ((ADATA.CP_CCODIGO != null || ADATA.CP_CCODIGO != "") ? a.CP_CCODIGO.Trim() == ADATA.CP_CCODIGO.Trim() : a.CP_CCODIGO.Trim() != ADATA.CP_CCODIGO.Trim())
                            )
                            select new
                            {
                                CP_CCODIGO = a.CP_CCODIGO,
                                PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == a.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                CP_CTIPDOC = a.CP_CTIPDOC,
                                CP_CNUMDOC = a.CP_CNUMDOC,
                                CP_CCODMON = a.CP_CCODMON,
                                SALDO = ctx.CP0003CART.Where(x => x.CP_CNUMDOC.Trim() == a.CP_CNUMDOC.Trim().Substring(0, a.CP_CNUMDOC.Trim().Length - 2)).Select(x => x.CP_NSALDMN).FirstOrDefault(),
                                CP_NSALDMN = a.CP_NSALDMN,
                                CP_CTASDET = a.CP_CTASDET,
                                CP_DFECVEN = a.CP_DFECVEN,
                            }
                        ).ToList().Select(c => new CP0003CART()
                        {
                            CP_CCODIGO = c.CP_CCODIGO,
                            CP_CDESCRI = c.PROVEEDOR,
                            CP_CNUMDOC = c.CP_CTIPDOC + "-" + c.CP_CNUMDOC,
                            CP_CCODMON = c.CP_CCODMON,
                            CP_NSALDUS = c.SALDO,
                            CP_NSALDMN = c.CP_NSALDMN,
                            CP_CTASDET = c.CP_CTASDET,
                            CP_CNDOCCO = String.Format("{0:dd/MM/yyyy}", c.CP_DFECVEN),
                            CP_CTIPO = "VENCIDO",
                        }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return list;
        }

        //para la interfaz cheques
        //pantalla inicial de proveedores para cheques
        public static List<vista_totales_programacion> LISTARTOTALESCHEQUES() //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_totales_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    //string[] arreglo = ctx.CP0003PRGD.Select(X => X.GD_CNUMDOC.Trim()).ToArray();

                    alumnos = (from a in ctx.CP0003CART
                               where (a.CP_NSALDMN > 0
                    )
                               group new { a } by new
                               {
                                   a.CP_CCODIGO,
                                   a.CP_CVANEXO,

                               } into g

                               select new
                               {
                                   ANE = g.Key.CP_CVANEXO,
                                   CODIGO = g.Key.CP_CCODIGO,
                                   PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                   TIPO = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CTIPOAC).FirstOrDefault(),
                                   DIRECCION = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CDIRECC).FirstOrDefault(),

                               }).ToList()
                           .Select(c => new vista_totales_programacion()
                           {
                               Ane = c.ANE,
                               Codigo = c.CODIGO,
                               Acreedor = c.PROVEEDOR,
                               Direccion = c.DIRECCION,
                               Tipo = c.TIPO,
                           }).OrderBy(x => x.Acreedor).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }
        public static List<vistas_finanzas> listar_pagos_pendientes(CP0003CART DATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vistas_finanzas>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003CART
                               where (a.CP_CSITUAC == "C" && (a.CP_CCODMON == "MN" ? a.CP_NSALDMN > 0 : a.CP_NSALDUS > 0)
                    )
                               group new { a } by new
                               {
                                   a.CP_CCODIGO,
                                   a.CP_CVANEXO
                               } into g
                               select new
                               {
                                   ANE = g.Key.CP_CVANEXO,
                                   CODIGO = g.Key.CP_CCODIGO,
                                   PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                   TIPO = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CTIPOAC).FirstOrDefault(),
                                   DIRECCION = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CDIRECC).FirstOrDefault(),
                                   TOTALES = g.Count()
                               }).ToList()
                           .Select(c => new vistas_finanzas()
                           {
                               CP_CVANEXO = c.ANE,
                               CP_CCODIGO = c.CODIGO,
                               NOMTIT = c.PROVEEDOR,
                               CP_CDESCRI = c.DIRECCION,
                               CP_CTIPO = c.TIPO,
                               IMPORTE = c.TOTALES
                           }).OrderByDescending(x => x.IMPORTE).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<vistas_finanzas> listar_pagos_pendientesd(CP0003CART DATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vistas_finanzas>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003CART
                               where (a.CP_NSALDMN > 0 && a.CP_CCODIGO == DATA.CP_CCODIGO
                    )
                               group new { a } by new
                               {
                                   a.CP_CCODIGO,
                                   a.CP_CVANEXO,

                               } into g

                               select new
                               {
                                   ANE = g.Key.CP_CVANEXO,
                                   CODIGO = g.Key.CP_CCODIGO,
                                   PROVEEDOR = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CNOMBRE).FirstOrDefault(),
                                   TIPO = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CTIPOAC).FirstOrDefault(),
                                   DIRECCION = ctx.CP0003MAES.Where(x => x.AC_CCODIGO.Trim() == g.Key.CP_CCODIGO.Trim()).Select(x => x.AC_CDIRECC).FirstOrDefault(),
                                   TOTALES = g.Count()
                               }).ToList()
                           .Select(c => new vistas_finanzas()
                           {
                               CP_CVANEXO = c.ANE,
                               CP_CCODIGO = c.CODIGO,
                               NOMTIT = c.PROVEEDOR,
                               CP_CDESCRI = c.DIRECCION,
                               CP_CTIPO = c.TIPO,
                               IMPORTE = c.TOTALES
                           }).OrderByDescending(x => x.IMPORTE).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        /// <summary>
        /// Pagos del proveedor pendientes
        /// </summary>
        /// <param name="CODATA"></param>
        /// <returns></returns>
        public static List<vistas_finanzas> pagos_proveedor(vistas_finanzas CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var lista = new List<vistas_finanzas>();
            try
            {

                using (var ctx = new RSCONCAR())
                {
                    lista = (from x in ctx.CP0003CART.Where(a => a.CP_CCODIGO == CODATA.CP_CCODIGO
                               //&& (CODATA.CP_CCUENTA != null ? a.CP_CCUENTA == CODATA.CP_CCUENTA : a.CP_CCUENTA != null)
                               && a.CP_CVANEXO == CODATA.CP_CVANEXO && a.CP_CSITUAC == "C"//a.CP_DFECVEN < fecha
                               && (a.CP_CCODMON == "MN" ? a.CP_NSALDMN > 0 : a.CP_NSALDUS > 0)) //&& a.CP_CTDOCRE != "")
                             orderby x.CP_CTIPDOC, x.CP_CNUMDOC
                             select new
                             {
                                 CP_CTIPDOC = x.CP_CTIPDOC,
                                 CP_CNUMDOC = x.CP_CNUMDOC,
                                 CP_DFECDOC = x.CP_DFECDOC,
                                 CP_DFECVEN = x.CP_DFECVEN,
                                 CP_CDEBHAB = x.CP_CDEBHAB,
                                 CP_CCODMON = x.CP_CCODMON,
                                 CP_NTIPCAM = x.CP_NTIPCAM,
                                 CP_NIMPOMN = x.CP_NIMPOMN,
                                 CP_NIMPOUS = x.CP_NIMPOUS,
                                 CP_NSALDMN = x.CP_NSALDMN,
                                 CP_NSALDUS = x.CP_NSALDUS,
                                 CP_CRETE = x.CP_CRETE,
                                 CP_NPORRE = x.CP_NPORRE,
                                 CP_CCUENTA = x.CP_CCUENTA,
                                 CP_CTASDET = x.CP_CTASDET,
                                 CP_CSUBDIA = x.CP_CSUBDIA,
                                 CP_CCOMPRO = x.CP_CCOMPRO
                             }).ToList()
                           .Select(c => new vistas_finanzas()
                           {
                               CP_CTIPDOC = c.CP_CTIPDOC,
                               CP_CNUMDOC = c.CP_CNUMDOC,
                               CP_DFECDOC = c.CP_DFECDOC,
                               CP_DFECVEN = c.CP_DFECVEN,
                               CP_CCODMON = c.CP_CCODMON,
                               CP_NTIPCAM = Convert.ToDecimal(c.CP_NTIPCAM),
                               IMPORTE = (c.CP_CCODMON == "MN" ? (c.CP_CDEBHAB == "D" ? (-1) * c.CP_NIMPOMN : c.CP_NIMPOMN) : (c.CP_CDEBHAB == "D" ? (-1) * c.CP_NIMPOUS : c.CP_NIMPOUS)),
                               SALDO = (c.CP_CCODMON == "MN" ? (c.CP_CDEBHAB == "D" ? (-1) * Convert.ToDecimal(c.CP_NSALDMN) : Convert.ToDecimal(c.CP_NSALDMN)) : (c.CP_CDEBHAB == "D" ? (-1) * Convert.ToDecimal(c.CP_NSALDUS) : Convert.ToDecimal(c.CP_NSALDUS))),
                               CP_CRETE = c.CP_CRETE,
                               CP_NPORRE = c.CP_NPORRE,
                               CP_CCUENTA = c.CP_CCUENTA,
                               PORDET = (c.CP_CTASDET.Trim() != "" ? CT0003TAGE.listage_unico("28", c.CP_CTASDET).First().TDESCRI.ToString() : ""),
                               CP_CSUBDIA = c.CP_CSUBDIA,
                               CP_CCOMPRO = c.CP_CCOMPRO
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return lista;
        }

        /// <summary>
        /// aCTUALIZAR EL MONTO DEL SALDO AL MONTO ANTERI0R AL ANULAR EL CHEQUE.
        /// </summary>
        /// <param name="COM"></param>
        public static void ActualizarSaldo(CP0003CART COM)
        {
            var orden = new CP0003CART
            {
                CP_CVANEXO = COM.CP_CVANEXO,
                CP_CCODIGO = COM.CP_CCODIGO,
                CP_CTIPDOC = COM.CP_CTIPDOC,
                CP_CNUMDOC = COM.CP_CNUMDOC
            };

            using (var ctx = new RSCONCAR())
            {
                ctx.CP0003CART.Attach(orden);
                orden.CP_NSALDMN = Convert.ToDecimal(ctx.CP0003CART.Where(x => x.CP_CVANEXO == COM.CP_CVANEXO &&
                 x.CP_CCODIGO == COM.CP_CCODIGO &&
                 x.CP_CTIPDOC.Trim() == COM.CP_CTIPDOC.Trim() &&
                 x.CP_CNUMDOC == COM.CP_CNUMDOC).Select(x => x.CP_NIMPOMN).FirstOrDefault())
                -
              Convert.ToDecimal(ctx.CP0003CART.Where(x => x.CP_CVANEXO == COM.CP_CVANEXO &&
                x.CP_CCODIGO == COM.CP_CCODIGO &&
                x.CP_CTIPDOC == COM.CP_CTIPDOC &&
                x.CP_CNUMDOC.Trim() == COM.CP_CNUMDOC.Trim() + "-D").Select(x => x.CP_NIMPOMN).FirstOrDefault());

                orden.CP_NSALDUS = Convert.ToDecimal(ctx.CP0003CART.Where(x => x.CP_CVANEXO == COM.CP_CVANEXO &&
                x.CP_CCODIGO == COM.CP_CCODIGO &&
                x.CP_CTIPDOC.Trim() == COM.CP_CTIPDOC.Trim() &&
                x.CP_CNUMDOC == COM.CP_CNUMDOC).Select(x => x.CP_NIMPOUS).FirstOrDefault())
                -
                Convert.ToDecimal(ctx.CP0003CART.Where(x => x.CP_CVANEXO == COM.CP_CVANEXO &&
                x.CP_CCODIGO == COM.CP_CCODIGO &&
                x.CP_CTIPDOC == COM.CP_CTIPDOC &&
                x.CP_CNUMDOC.Trim() == COM.CP_CNUMDOC.Trim() + "-D").Select(x => x.CP_NIMPOUS).FirstOrDefault());
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }
    }
}
