namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;


    public partial class CO0003MOVD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string OC_CNUMORD { get; set; }


        [StringLength(18)]
        public string OC_CCODPRO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string OC_CITEM { get; set; }


        [StringLength(25)]
        public string OC_CCODIGO { get; set; }


        [StringLength(25)]
        public string OC_CCODREF { get; set; }


        [StringLength(60)]
        public string OC_CDESREF { get; set; }


        [StringLength(3)]
        public string OC_CUNIPRO { get; set; }


        [StringLength(60)]
        public string OC_CDEUNPR { get; set; }


        [StringLength(3)]
        public string OC_CUNIDAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANORD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NPREUNI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NPREUN2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPFI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCFI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NISC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OC_NCANTEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? OC_NCANSAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTMN { get; set; }


        [StringLength(800)]
        public string OC_COMENTA { get; set; }


        [StringLength(1)]
        public string OC_CESTADO { get; set; }


        [StringLength(1)]
        public string OC_FUNICOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANREF { get; set; }


        [StringLength(18)]
        public string OC_CSERIE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NANCHO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCORTE { get; set; }

        public DateTime? OC_DFECDOC { get; set; }


        [StringLength(1)]
        public string OC_CTIPORD { get; set; }


        [StringLength(6)]
        public string OC_CCENCOS { get; set; }


        [StringLength(7)]
        public string OC_CNUMREQ { get; set; }


        [StringLength(3)]
        public string OC_CSOLICI { get; set; }


        [StringLength(4)]
        public string OC_CITEREQ { get; set; }


        [StringLength(25)]
        public string OC_CREFCOD { get; set; }

        [StringLength(20)]
        public string OC_CPEDINT { get; set; }

        [StringLength(4)]
        public string OC_CITEINT { get; set; }


        [StringLength(25)]
        public string OC_CREFCOM { get; set; }


        [StringLength(50)]
        public string OC_CNOMFAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANEMB { get; set; }

        public DateTime? OC_DFECENT { get; set; }


        [StringLength(1)]
        public string OC_CITMPOR { get; set; }


        [StringLength(1)]
        public string OC_CDSCPOR { get; set; }


        [StringLength(1)]
        public string OC_CIGVPOR { get; set; }


        [StringLength(1)]
        public string OC_CISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTMO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NUNXENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NNUMENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANFAC { get; set; }

        //nuevo codigo
        public static void insertdetalleOC(CO0003MOVD datad)
        {
            try
            {

                using (var ctx = new RSFACAR())
                {
                    ctx.Entry(datad).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctxM = new RSFACAR())
                {
                    ctxM.Entry(datad).State = EntityState.Modified;
                    ctxM.SaveChanges();
                }
            }
        }


        public static List<CO0003MOVD> verListaOrden(CO0003MOVD CCAB)
        {
            List<CO0003MOVD> listaA = new List<CO0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listaA = (from c in ctx.CO0003MOVD where c.OC_CNUMORD.Trim() == CCAB.OC_CNUMORD.Trim() select c).ToList();
                }
            }
            catch (Exception)
            {
                listaA = null;
            }
            return listaA;
        }


        public static void EliminaItems(CO0003MOVD CCAB)
        {

            using (var ctx = new RSFACAR())
            {
                ctx.Entry(new CO0003MOVD { OC_CNUMORD = CCAB.OC_CNUMORD, OC_CITEM = CCAB.OC_CITEM }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        //nuevo 12032016
        public static void insertdetalleOCplanilla(CO0003MOVD datad)
        {
            try
            {

                using (var ctx = new RSFACAR())
                {

                    var listaA = (from c in ctx.CO0003MOVD where c.OC_CNUMORD == datad.OC_CNUMORD && c.OC_CITEM == datad.OC_CITEM && c.OC_CCODIGO == datad.OC_CCODIGO select c).Count();
                    if (listaA == 0)
                    {
                        ctx.Entry(datad).State = EntityState.Added;
                        ctx.SaveChanges();
                    }
                    else
                    {
                        ctx.Entry(datad).State = EntityState.Modified;
                        ctx.SaveChanges();
                    }
                }
            }
            catch
            {
                throw;
            }
        }

        //NUEVO WILLIAM
        /// <summary>
        /// Usado Registro de Entrada con Orden compra
        /// </summary>
        /// <param name="DCAB"></param>
        public static void actualizaDetalle(CO0003MOVD DCAB)
        {
            var IDNDOC = new CO0003MOVD { OC_CNUMORD = DCAB.OC_CNUMORD, OC_CCODPRO = DCAB.OC_CCODPRO, OC_CITEM = DCAB.OC_CITEM };
            using (RSFACAR ctx = new RSFACAR())
            {

                ctx.CO0003MOVD.Attach(IDNDOC);
                IDNDOC.OC_CESTADO = DCAB.OC_CESTADO;
                IDNDOC.OC_NCANTEN = DCAB.OC_NCANTEN;
                IDNDOC.OC_NCANSAL = DCAB.OC_NCANSAL;


                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

            }
        }
        public static void actualizaDetalleO(CO0003MOVD DCAB)
        {
            using (RSFACAR ctx = new RSFACAR())
            {
                var miupdate = ctx.CO0003MOVD.Where(u => u.OC_CNUMORD == DCAB.OC_CNUMORD && u.OC_CCODPRO == DCAB.OC_CCODPRO).ToList();

                miupdate.ForEach(IDNDOC =>
                {
                    IDNDOC.OC_CESTADO = DCAB.OC_CESTADO;
                    IDNDOC.OC_NCANTEN = IDNDOC.OC_NCANSAL;
                    IDNDOC.OC_NCANSAL = 0;
                });
                ctx.SaveChanges();

            }
        }

        public static void AprobarDET(CO0003MOVD COM)
        {
            var orden = new CO0003MOVD { OC_CNUMORD = COM.OC_CNUMORD, OC_CITEM = COM.OC_CITEM };

            using (var ctx = new RSFACAR())
            {
                ctx.CO0003MOVD.Attach(orden);
                orden.OC_CESTADO = COM.OC_CESTADO;

                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }

        }

        //nuevo Sergio 16032016 CO0003MOVD
        public static void EliminaItemsDetalleOC(CO0003MOVD DDET)
        {
            try
            {
                using (var ctx = new RSFACAR())
                {
                    List<CO0003MOVD> Listaproda = new List<CO0003MOVD>();
                    Listaproda = ctx.CO0003MOVD.Where(rr => rr.OC_CNUMORD.Trim() == DDET.OC_CNUMORD.Trim() && rr.OC_CNUMREQ.Trim() != "").ToList();

                    string[] listaprod = new string[Listaproda.Count()];
                    string[] listareq = new string[Listaproda.Count()];
                    int ccod = 0;
                    foreach (var sd in Listaproda)
                    {
                        if (sd.OC_CNUMREQ.Trim() != "" || sd.OC_CNUMREQ.Trim() != null)
                        {
                            listaprod[ccod] = sd.OC_CCODIGO;
                            listareq[ccod] = sd.OC_CNUMREQ;
                            ccod++;
                        }
                    }
                    //cambio de estado de requerimiento 
                    var listarrcab = ctx.AL0003REQC.Where(ww => listareq.Distinct().Contains(ww.RC_CNROREQ)
                    ).ToList();
                    listarrcab.ForEach(data =>
                    {
                        data.RC_CESTADO = "7";
                    });
                    ctx.SaveChanges();

                    //cambio de estado detalle de requerimiento 
                    var listarq = ctx.AL0003REQD.Where(ww => listaprod.Contains(ww.RD_CCODIGO) && listareq.Contains(ww.RD_CNROREQ)
                    ).ToList();

                    listarq.ForEach(data =>
                    {
                        data.RD_CSITUA = "7";
                        data.RD_NQATEN = 0;
                    });
                    ctx.SaveChanges();

                    ctx.CO0003MOVD.RemoveRange(ctx.CO0003MOVD.Where(x => x.OC_CNUMORD == DDET.OC_CNUMORD.Trim()));
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }

        //sergio nuevo 27/04/2016
        public static List<CO0003MOVD> ListaHistoricoxTar(CO0003MOVD CCAB)
        {
            List<CO0003MOVD> listaA = new List<CO0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listaA = (from c in ctx.CO0003MOVD where c.OC_CCODIGO == CCAB.OC_CCODIGO && c.OC_CESTADO == "2" select c).ToList();
                }
            }
            catch (Exception)
            {
                listaA = null;
            }
            return listaA;
        }


        public static void updateitemxrq(string nrq, string ccodp)
        {
            using (var ctx = new RSFACAR())
            {
                var tabm = (from c in ctx.AL0003REQD where c.RD_CNROREQ == nrq.Trim() && c.RD_CCODIGO == ccodp select c).FirstOrDefault();
                if (tabm != null)
                {
                    tabm.RD_CSITUA = "7";
                    ctx.SaveChanges();
                }
            }
        }


        public static List<vista_detalle_oc_req> detalleorden(CO0003MOVD DING)
        {

            List<vista_detalle_oc_req> datos = new List<vista_detalle_oc_req>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = (from t in ctx.CO0003MOVD
                             where
                               DING.OC_CNUMORD == t.OC_CNUMORD
                             select new
                             {
                                 ITEM = t.OC_CITEM,
                                 DESCRIPCIOM = t.OC_CDESREF,
                                 UNIDAD = t.OC_CUNIDAD,
                                 CANTIDAD = t.OC_NCANORD,
                                 PRECIOSOLES = t.OC_NPREUNI,
                                 IGV = t.OC_NIGV,
                                 TOTALD = t.OC_NTOTUS,
                                 TOTALS = t.OC_NTOTMN,

                             }
                            ).ToList().Select(g => new vista_detalle_oc_req()
                            {
                                ITEM = g.ITEM,
                                DESCRIPCION = g.DESCRIPCIOM,
                                UNIDAD = g.UNIDAD,
                                CANTIDAD = g.CANTIDAD,
                                PRECIOSOLES = g.PRECIOSOLES,
                                IGV = g.IGV,
                                PRECIODOLARES = g.TOTALD / g.CANTIDAD,
                                TOTALD = g.TOTALD,
                                TOTALS = g.TOTALS,

                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }


        public static decimal PrecioxProv(CO0003MOVD CCAB)
        {
            decimal precm = 0;
            using (var ctx = new RSFACAR())
            {
                var listaA = (from c in ctx.CO0003MOVD where c.OC_CCODIGO.Trim() == CCAB.OC_CCODIGO.Trim() && c.OC_CCODPRO == CCAB.OC_CCODPRO select c).Count();
                if (listaA > 0)
                {
                    precm = (from c in ctx.CO0003MOVD where c.OC_CCODIGO.Trim() == CCAB.OC_CCODIGO.Trim() && c.OC_CCODPRO == CCAB.OC_CCODPRO orderby c.OC_DFECDOC descending select c).FirstOrDefault().OC_NPREUN2;
                }
                else
                {
                    var xproducto = (from c in ctx.CO0003MOVD where c.OC_CCODIGO.Trim() == CCAB.OC_CCODIGO.Trim() select c).Count();
                    if (xproducto >0)
                    {
                        precm = (from c in ctx.CO0003MOVD where c.OC_CCODIGO.Trim() == CCAB.OC_CCODIGO.Trim() orderby c.OC_DFECDOC descending select c).FirstOrDefault().OC_NPREUN2 ;
                    }
                    else
                    {
                        precm = 0;
                    }
                }
            }
            return precm;
        }



    }
}
