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
    using CapaNegocio;
    using System.Data.Entity.SqlServer;
    using System.Data.SqlClient;

    public class vista_kardex_SaldoAnterior
    {
       public decimal? saldo { get; set; }
    }
    public partial class AL0003MOVD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string C6_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string C6_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string C6_CITEM { get; set; }

        [Required]
        [StringLength(4)]
        public string C6_CLOCALI { get; set; }

        [Required]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANTID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANTEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANFAC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPREUN1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPREUNI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NMNPRUN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NUSPRUN { get; set; }


        [StringLength(18)]
        public string C6_CSERIE { get; set; }


        [StringLength(1)]
        public string C6_CSITUA { get; set; }

        public DateTime? C6_DFECDOC { get; set; }

        public DateTime? C6_DFECVEN { get; set; }

        public DateTime? C6_DFECENT { get; set; }


        [StringLength(4)]
        public string C6_CRFALMA { get; set; }


        [StringLength(1)]
        public string C6_CTALLA { get; set; }


        [StringLength(1)]
        public string C6_CESTADO { get; set; }


        [StringLength(2)]
        public string C6_CCODMOV { get; set; }


        [StringLength(18)]
        public string C6_CORDEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NVALTOT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NMNIMPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NUSIMPO { get; set; }


        [StringLength(4)]
        public string C6_CSUBDIA { get; set; }


        [StringLength(6)]
        public string C6_CCOMPRO { get; set; }


        [StringLength(2)]
        public string C6_CCODMON { get; set; }


        [StringLength(1)]
        public string C6_CTIPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NTIPCAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPREVTA { get; set; }

        [StringLength(2)]
        public string C6_CMONVTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NUNXENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NNUMENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NDEVOL { get; set; }


        [StringLength(6)]
        public string C6_CCENCOS { get; set; }


        [StringLength(3)]
        public string C6_CSOLI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPRECIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPRECI1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPUS { get; set; }

        [Required]
        [StringLength(50)]
        public string C6_CDESCRI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPO1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDE2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPO2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDE3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPO3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDE4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPO4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDE5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NIMPO5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPORDES { get; set; }


        [StringLength(3)]
        public string C6_CTIPITM { get; set; }


        [StringLength(4)]
        public string C6_CNUMPAQ { get; set; }


        [StringLength(4)]
        public string C6_CCODLIN { get; set; }


        [StringLength(6)]
        public string C6_CNROTAB { get; set; }


        [StringLength(8)]
        public string C6_CNDSCF { get; set; }


        [StringLength(8)]
        public string C6_CNDSCL { get; set; }


        [StringLength(8)]
        public string C6_CNDSCA { get; set; }


        [StringLength(8)]
        public string C6_CNDSCB { get; set; }


        [StringLength(8)]
        public string C6_CNFLAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPESO { get; set; }


        [StringLength(1)]
        public string C6_CTR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NPRSIGV { get; set; }


        [StringLength(1)]
        public string C6_CTIPANE { get; set; }


        [StringLength(18)]
        public string C6_CCODANE { get; set; }


        [StringLength(1)]
        public string C6_CSTOCK { get; set; }

        [StringLength(4)]
        public string C6_CCODAGE { get; set; }


        [StringLength(25)]
        public string C6_CCODAUX { get; set; }


        [StringLength(4)]
        public string C6_CITEREQ { get; set; }


        [StringLength(7)]
        public string C6_CNROREQ { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NTEMPER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NISC { get; set; }


        [StringLength(4)]
        public string C6_CITEFAC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANRPE { get; set; }


        [StringLength(7)]
        public string C6_CNUMREQ { get; set; }


        [StringLength(4)]
        public string C6_CITERQ { get; set; }


        [StringLength(25)]
        public string C6_CCODRQ { get; set; }

        public DateTime? C6_DFECRQ { get; set; }


        [StringLength(1)]
        public string C6_CTIPPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANREQ { get; set; }


        [StringLength(12)]
        public string C6_CCTACMO { get; set; }


        [StringLength(20)]
        public string C6_CNUMORD { get; set; }


        [StringLength(3)]
        public string C6_CUMREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANDEC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C6_NCANREF { get; set; }


        [StringLength(4)]
        public string C6_CITEMOC { get; set; }


        [StringLength(1)]
        public string C6_CVANEXO { get; set; }


        [StringLength(1)]
        public string C6_CVANEX2 { get; set; }


        [StringLength(18)]
        public string C6_CCODAN2 { get; set; }


        [StringLength(3)]
        public string C6_CCODEMPQ { get; set; }

        public static decimal? devuelveKardexSaldoAnteriorFinal(string codigo,string almacen, DateTime fecha1)
        {
            var entrada= AL0003MOVD.devuelveKardexSaldoAnterior(codigo, almacen, fecha1,"PE");
            var salida = AL0003MOVD.devuelveKardexSaldoAnterior(codigo, almacen, fecha1, "PS");
            var total=    entrada - salida;
            return total;
        }

        public static decimal?  devuelveKardexSaldoAnterior(string codigo, string almacen, DateTime fecha1,  string tipo)
        {
             using (var ctx = new RSFACAR())
            {
                var data =
                        (
                        from AL0003MOVD in
                         (from AL0003MOVD in ctx.AL0003MOVD
                          where
                            AL0003MOVD.C6_CCODIGO == codigo.Trim()
                            &&
                            AL0003MOVD.C6_DFECDOC <fecha1
                            &&
                            AL0003MOVD.C6_CALMA.Trim() == almacen.Trim()
                            &&
                            AL0003MOVD.C6_CTD.Trim() == tipo.Trim()
                          select new
                          {
                              AL0003MOVD.C6_NCANTID,
                              Dummy = "x"
                          })
                        group AL0003MOVD by new { AL0003MOVD.Dummy } into g
                        select new
                        {
                            Column1 = (decimal?)g.Sum(p => p.C6_NCANTID)
                        }
                        ).ToList().Select(c => new vista_kardex_SaldoAnterior()

                        {
                            saldo = c.Column1
                        }).FirstOrDefault();

                if (data == null)
                    return 0;
                else
                   return data.saldo;

            }
        }

        public static Boolean insertaDetalleCabecera(AL0003MOVD datos)
        {
            Boolean band = true;
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
        /// <summary>
        /// Version anterior
        /// </summary>
        /// <param name="AL"></param>
        /// <param name="TD"></param>
        /// <param name="ND"></param>
        /// <returns></returns>
        public static List<AL0003MOVD> detalleCabecera(string AL, string TD, string ND)
        {
            List<AL0003MOVD> datos = new List<AL0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = ctx.AL0003MOVD.Where(x => x.C6_CALMA == AL && x.C6_CTD == TD && x.C6_CNUMDOC == ND).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }
        /// <summary>
        /// Detalle objeto
        /// </summary>
        /// <param name="DATA"></param>
        /// <returns></returns>
        public static List<AL0003MOVD> detalleC(AL0003MOVD DATA)
        {
            List<AL0003MOVD> datos = new List<AL0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = ctx.AL0003MOVD.Where(x => x.C6_CALMA == DATA.C6_CALMA && x.C6_CTD == DATA.C6_CTD && x.C6_CNUMDOC == DATA.C6_CNUMDOC).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        /// <summary>
        /// Valorizacion de Partes Manuales
        /// </summary>
        /// <param name="VDETA"></param>
        /// <returns></returns>
        public static Boolean valorizaDetalle(AL0003MOVD VDETA)
        {   //VALORIZA PARTES MANUALES - LIQUIDACIONES DE COMPRA
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new AL0003MOVD { C6_CALMA = VDETA.C6_CALMA, C6_CTD = VDETA.C6_CTD, C6_CNUMDOC = VDETA.C6_CNUMDOC, C6_CITEM = VDETA.C6_CITEM };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003MOVD.Attach(data);
                    data.C6_NCANTEN = VDETA.C6_NCANTEN;//LQ
                    data.C6_NPREUN1 = VDETA.C6_NPREUN1;//PRECIO ORIGINAL
                    data.C6_NPREUNI = VDETA.C6_NPREUNI;//PRECIO ORIGINAL2
                    data.C6_NMNPRUN = VDETA.C6_NMNPRUN;//PRECIO SOLES
                    data.C6_NUSPRUN = VDETA.C6_NUSPRUN;//PRECIO DOLARES
                    data.C6_NVALTOT = VDETA.C6_NVALTOT;//VALOR TOTAL
                    data.C6_NMNIMPO = VDETA.C6_NMNIMPO;//VALOR TOTAL SOLES
                    data.C6_NUSIMPO = VDETA.C6_NUSIMPO;//VALOR TOTAL DOLARES
                    data.C6_NPRECIO = VDETA.C6_NPRECIO;//PRECIO DESVALVE SOLES
                    data.C6_NPRECI1 = VDETA.C6_NPRECI1;//PRECIO DESVALE DOLARES
                    data.C6_CCODMON = VDETA.C6_CCODMON;
                    data.C6_CSUBDIA = VDETA.C6_CSUBDIA;
                    data.C6_CCOMPRO = VDETA.C6_CCOMPRO;
                    //data.C6_CNUMORD = VDETA.C6_CNUMORD;//ULTIMO CAMPO AGREGADO
                    data.C6_CTIPO = VDETA.C6_CTIPO;
                    data.C6_NTIPCAM = VDETA.C6_NTIPCAM;
                    data.C6_CESTADO = VDETA.C6_CESTADO;//VALORIZADO
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

        public static Boolean valorizaDetalleG(AL0003MOVD VDETA, string[] ND)
        {   //VALORIZA PARTES MANUALES - LIQUIDACIONES DE COMPRA
            Boolean band = true;
            //var fechaA = DateTime.Now;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //ctx.AL0003MOVD.Attach(data);
                    var miupdate = ctx.AL0003MOVD.Where(u => u.C6_CALMA == VDETA.C6_CALMA
                                                        && u.C6_CTD == VDETA.C6_CTD
                                                        && ND.Contains(u.C6_CNUMDOC) //== VDETA.C6_CNUMDOC
                                                        && (VDETA.C6_CCODIGO!=null?u.C6_CCODIGO == VDETA.C6_CCODIGO: u.C6_CCODIGO != VDETA.C6_CCODIGO)).ToList();
                    //ACTUALIZACION 07.06.16
                    miupdate.ForEach(data =>
                    {
                        data.C6_NCANTEN = VDETA.C6_NCANTEN;//LQ
                        //data.C6_NPREUN1 = VDETA.C6_NPREUN1;
                        //data.C6_NPREUNI = VDETA.C6_NPREUNI;
                        //data.C6_NMNPRUN = VDETA.C6_NMNPRUN;
                        //data.C6_NUSPRUN = VDETA.C6_NUSPRUN;
                        //data.C6_NVALTOT = (data.C6_NCANTID * VDETA.C6_NPREUN1);//VDETA.C6_NVALTOT;
                        //data.C6_NMNIMPO = (data.C6_NCANTID * VDETA.C6_NPREUN1);//VDETA.C6_NMNIMPO;
                        //data.C6_NUSIMPO = ((data.C6_NCANTID * VDETA.C6_NPREUN1) / VDETA.C6_NTIPCAM);///VDETA.C6_NUSIMPO;
                        //data.C6_CCODMON = VDETA.C6_CCODMON;
                        data.C6_CSUBDIA = VDETA.C6_CSUBDIA;
                        data.C6_CCOMPRO = VDETA.C6_CCOMPRO;
                        //data.C6_CTIPO = VDETA.C6_CTIPO;
                        //data.C6_NTIPCAM = VDETA.C6_NTIPCAM;
                        //data.C6_CESTADO = VDETA.C6_CESTADO;//VALORIZADO
                    });
                    //ctx.Configuration.ValidateOnSaveEnabled = false;
                    //var miupdate2 = ctx.CO0003MOVD.Where(c=>c.OC_CCO==VDETA.C6_CNUMORD).ToList();


                    ctx.SaveChanges();

                }
            }
            catch (DbEntityValidationException dbEx)
            {
                CapaNegocio.Cls_Utilidades.LogError(dbEx);
                /*foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }*/
                band = false;
            }
            return band;
        }

        /// <summary>
        /// Actualiza detalle cabecera, cambio en cabecera
        /// Actualizacion 12/04/2016 - FITEM
        /// </summary>
        /// <param name="datos"></param>
        /// <param name="FITEM"></param>
        /// <returns></returns>
        public static Boolean actualizaDetalleEntrada(AL0003MOVD datos, string FITEM)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new AL0003MOVD { C6_CALMA = datos.C6_CALMA, C6_CTD = datos.C6_CTD, C6_CNUMDOC = datos.C6_CNUMDOC, C6_CITEM = (FITEM != "" ? FITEM : datos.C6_CITEM) };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003MOVD.Attach(data);
                    data.C6_DFECDOC = datos.C6_DFECDOC;
                    //data.C5_CGLOSA1 = datos.C5_CGLOSA1;
                    //data.C5_CGLOSA2 = datos.C5_CGLOSA2;
                    //data.C5_CGLOSA3 = datos.C5_CGLOSA3;
                    //data.C5_CCODPRO = datos.C5_CCODPRO;
                    //data.C5_CNOMPRO = datos.C5_CNOMPRO;
                    //data.C5_DFECMOD = fechaA;
                    //data.C5_CUSUMOD = datos.C5_CUSUMOD;
                    //data.C5_CCENCOS = datos.C5_CCENCOS;

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

        //sergio nuevo 28032016
        public static List<AL0003MOVD> Detalleagrupaentradasa(string fdoc)
        {
            string finicio = "", periodoproceso = "", mesx = "", periodomesant = "", mesant = "";

            finicio = "01" + fdoc.Substring(2, 8);
            periodoproceso = fdoc.Substring(6, 4) + "" + fdoc.Substring(3, 2);
            mesx = fdoc.Substring(3, 2);
            mesant = (mesx == "01" ? "12" : (Convert.ToDecimal(mesx) - 1).ToString());
            periodomesant = fdoc.Substring(6, 4) + "" + Convert.ToInt32(mesant).ToString("D2");

            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(fdoc);

            
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //var lstinfo = ctx.AL0003SKNU.Where(x => x.SA_CMESPRO == periodoproceso).ToList();
                    //ctx.AL0003SKNU.RemoveRange(lstinfo);
                    //ctx.SaveChanges();
                    //ctx.AL0003SKNU.SqlQuery("delete from AL0003SKNU where SA_CMESPRO =  @periodoproceso ",new[] { new SqlParameter("@periodoproceso", periodoproceso) });
                    //ctx.AL0003SKNU.SqlQuery("exec PR_LIMPIASTOCKV @periodo = '" + periodoproceso + "' ");
                    Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
                    consulta.pr_limpiarstockvalz( periodoproceso);
                }
            }
            catch {

            }


            List<AL0003MOVD> datos = new List<AL0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = (from AL0003MOVD in ctx.AL0003MOVD
                             where
                               AL0003MOVD.C6_CESTADO == "V" && AL0003MOVD.C6_CTD == "PE" && AL0003MOVD.C6_DFECDOC >= fin && AL0003MOVD.C6_DFECDOC <= ffn
                             group AL0003MOVD by new
                             {
                                 AL0003MOVD.C6_CCODIGO,
                                 AL0003MOVD.C6_CALMA,
                                 AL0003MOVD.C6_CTD
                             } into g
                             select new
                             {
                                 SumaxProd = (decimal?)g.Sum(p => p.C6_NCANTID),
                                 valortotal = (decimal?)g.Sum(p => p.C6_NVALTOT),
                                 codigo = g.Key.C6_CCODIGO,
                                 almacen = g.Key.C6_CALMA,
                                 cantanterior = ((from r in ctx.AL0003SKNU
                                                  where r.SA_CCODIGO == g.Key.C6_CCODIGO && r.SA_CMESPRO == periodomesant && r.SA_CALMA == g.Key.C6_CALMA
                                                  select new { r.SA_NCANACT }).FirstOrDefault().SA_NCANACT),
                                 cantsaliente = ((from r in ctx.AL0003MOVD
                                                  where r.C6_CCODIGO == g.Key.C6_CCODIGO && r.C6_DFECDOC >= fin && r.C6_DFECDOC <= ffn && r.C6_CALMA == g.Key.C6_CALMA
                                                  && r.C6_CESTADO == "V" && r.C6_CTD == "PS"
                                                  group r by new
                                                  {
                                                      r.C6_CCODIGO,
                                                      r.C6_CALMA,
                                                      r.C6_CTD
                                                  } into t
                                                  select new { sumasalida = (decimal?)t.Sum(y => y.C6_NCANTID) }).FirstOrDefault().sumasalida),
                                 periodoin = periodoproceso

                             }).ToList().Select(g => new AL0003MOVD()
                             {
                                 C6_NCANTID = Convert.ToDecimal(g.SumaxProd),
                                 C6_NVALTOT = Convert.ToDecimal(g.valortotal),
                                 C6_CCODIGO = g.codigo,
                                 C6_CALMA = g.almacen,
                                 C6_NCANFAC = Convert.ToDecimal(g.cantanterior),
                                 C6_NCANTEN = Convert.ToDecimal(g.cantsaliente),
                                 C6_NNUMENV = (Convert.ToDecimal(g.cantanterior) + Convert.ToDecimal(g.SumaxProd)) - Convert.ToDecimal(g.cantsaliente),
                                 C6_CORDEN = g.periodoin
                             }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        public static List<AL0003MOVD> DetalleNovalorizado(string fdoc)
        {
            string finicio = "", periodoproceso = "", mesx = "", periodomesant = "", mesant = "";
            finicio = "01" + fdoc.Substring(2, 8);
            periodoproceso = fdoc.Substring(6, 4) + "" + fdoc.Substring(3, 2);
            mesx = fdoc.Substring(3, 2);
            mesant = (mesx == "01" ? "12" : (Convert.ToDecimal(mesx) - 1).ToString());
            periodomesant = fdoc.Substring(6, 4) + "" + Convert.ToInt32(mesant).ToString("D2");

            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(fdoc);

            List<AL0003MOVD> datos = new List<AL0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = (from AL0003MOVD in ctx.AL0003MOVD
                             where
                               AL0003MOVD.C6_DFECDOC >= fin &&
                               AL0003MOVD.C6_DFECDOC <= ffn &&
                                 (from AL0003ALMA in ctx.AL0003ALMA
                                  where AL0003ALMA.A1_CCOSTO == "S"
                                  select new { AL0003ALMA.A1_CALMA }).Contains(new { A1_CALMA = AL0003MOVD.C6_CALMA }) &&

                                 (from AL0003ARTI in ctx.AL0003ARTI
                                  where AL0003ARTI.AR_CESTADO == "V"
                                  select new { AL0003ARTI.AR_CCODIGO }).Contains(new { AR_CCODIGO = AL0003MOVD.C6_CCODIGO }) &&
                               !(new string[] { "V", "S" }).Contains(AL0003MOVD.C6_CESTADO)

                             select new
                             {
                                 AL0003MOVD.C6_CALMA,
                                 AL0003MOVD.C6_CTD,
                                 AL0003MOVD.C6_CCODMOV,
                                 AL0003MOVD.C6_CNUMDOC,
                                 AL0003MOVD.C6_CITEM,
                                 AL0003MOVD.C6_CCODIGO,
                                 AL0003MOVD.C6_DFECDOC,
                                 AL0003MOVD.C6_NCANTID,
                                 AL0003MOVD.C6_CSITUA,
                                 AL0003MOVD.C6_CESTADO
                             }
                            ).ToList().Select(g => new AL0003MOVD()
                            {
                                C6_CALMA = (g.C6_CALMA),
                                C6_CTD = (g.C6_CTD),
                                C6_CCODMOV = g.C6_CCODMOV,
                                C6_CNUMDOC = g.C6_CNUMDOC,
                                C6_CITEM = g.C6_CITEM,
                                C6_CCODIGO = g.C6_CCODIGO,
                                C6_DFECDOC = (g.C6_DFECDOC),
                                C6_NCANTID = g.C6_NCANTID,
                                C6_CSITUA = g.C6_CSITUA,
                                C6_CESTADO = g.C6_CESTADO
                            }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        public static void Detalleagruparesumen(string fdoc)
        {
            string finicio = "", periodoproceso = "", mesx = "", periodomesant = "", mesant = "",anioa="",aniox="";



            finicio = "01" + fdoc.Substring(2, 8);
            periodoproceso = fdoc.Substring(6, 4) + "" + fdoc.Substring(3, 2);
            mesx = fdoc.Substring(3, 2);
            aniox = fdoc.Substring(6, 4);
            mesant = (mesx == "01" ? "12" : (Convert.ToDecimal(mesx) - 1).ToString());
            anioa = (mesx == "01" ? (Convert.ToDecimal(aniox) - 1).ToString() : Convert.ToDecimal(aniox).ToString());
            periodomesant = anioa + "" + Convert.ToInt32(mesant).ToString("D2");

            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(fdoc);

            try
            {
                using (var ctx = new RSFACAR())
                {
                    //ctx.AL0003RESU.RemoveRange(ctx.AL0003RESU.Where(x => x.VL_CMESPRO == periodoproceso));
                    //ctx.SaveChanges();
                    Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
                    consulta.pr_copiaresumen(periodomesant, periodoproceso, fdoc);
                }
            }
            catch {
                throw;
            }


        }


        public static List<AL0003MOVD> ListaProdUltimo(AL0003MOVD DING)
        {

            List<AL0003MOVD> datos = new List<AL0003MOVD>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = (from t in ctx.AL0003MOVD
                             where
                               t.C6_CCODIGO.Trim() == DING.C6_CCODIGO.Trim() && t.C6_CTD == "PE" && t.C6_CESTADO=="V"
                             orderby t.C6_DFECDOC descending
                             select new
                             {
                                 t.C6_DFECDOC,
                                 t.C6_CCODMON,
                                 t.C6_CCODIGO,
                                 t.C6_NPREUN1
                             }
                            ).ToList().Take(1).Select(g => new AL0003MOVD()
                            {
                                C6_DFECDOC = g.C6_DFECDOC,
                                C6_CCODMON = g.C6_CCODMON,
                                C6_CCODIGO = g.C6_CCODIGO,
                                C6_NPREUN1 = g.C6_NPREUN1
                            }).ToList();

                    if (datos.Count() == 0)
                    {
                        datos = null;
                    }

                }
            }
            catch (Exception)
            {
                return datos=null;
            }
            return datos;
        }


    }
}
