namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Data.SqlClient;
    using System.Diagnostics;
    using System.Linq;

    public partial class AL0003ALMA
    {
        [Key]
        [StringLength(4)]
        public string A1_CALMA { get; set; }

        [Required]
        [StringLength(4)]
        public string A1_CLOCALI { get; set; }

        [Required]
        [StringLength(60)]
        public string A1_CDESCRI { get; set; }

        [Required]
        [StringLength(60)]
        public string A1_CDIRECC { get; set; }

        [Required]
        [StringLength(15)]
        public string A1_CDISTRI { get; set; }

        [Required]
        [StringLength(10)]
        public string A1_CTEL { get; set; }

        [Required]
        [StringLength(1)]
        public string A1_CCTLNUM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal A1_NNUMENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal A1_NNUMSAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal A1_NNUMSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal A1_NNUMGUI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal A1_NNUMFIN { get; set; }

        [Required]
        [StringLength(5)]
        public string A1_CUSUCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string A1_CUSUMOD { get; set; }

        public DateTime? A1_DFECCRE { get; set; }

        public DateTime? A1_DFECMOD { get; set; }

        [Required]
        [StringLength(1)]
        public string A1_CTIPO { get; set; }

        [Required]
        [StringLength(40)]
        public string A1_CPROV { get; set; }

        [Required]
        [StringLength(40)]
        public string A1_CDEPT { get; set; }

        [Required]
        [StringLength(18)]
        public string A1_CCODCLI { get; set; }

        [Required]
        [StringLength(60)]
        public string A1_CDESCR2 { get; set; }

        [Required]
        [StringLength(60)]
        public string A1_CDIREC2 { get; set; }

        [Required]
        [StringLength(1)]
        public string A1_CCOSTO { get; set; }


        public static List<AL0003ALMA> ListarAlmacen()
        {
            List<AL0003ALMA> listaA = new List<AL0003ALMA>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    
                    listaA = (from c in ctx.AL0003ALMA orderby c.A1_CDESCRI select c).ToList();
                    
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }
        /// <summary>
        /// Lista almacen solo para pt-congelado/conservas
        /// Actualización: 12/04/2016
        /// </summary>
        /// <returns></returns>
        public static List<AL0003ALMA> ListarAlmacenIDS()
        {
            //((new string[] { "1", "2", "4", "5", "6", "7" }).Contains(x.OC_CSITORD))
            List<AL0003ALMA> listaA = new List<AL0003ALMA>();
            try
            {
                using (var ctx = new RSFACAR())
                {

                    listaA = (from a in ctx.AL0003ALMA.Where(x => ((new string[] { "A002", "A004", "0004", "0008" }).Contains(x.A1_CALMA)))
                              select new
                              {
                                  A1_CALMA = a.A1_CALMA,
                                  A1_CLOCALI = a.A1_CLOCALI,
                                  A1_CDESCRI = a.A1_CDESCRI,
                                  A1_CDIRECC = a.A1_CDIRECC,
                                  A1_CDEPT = a.A1_CDEPT,
                                  A1_CDISTRI = a.A1_CDISTRI,
                                  A1_CPROV = a.A1_CPROV

                              }).ToList().Select(a => new AL0003ALMA()
                              {
                                  A1_CALMA = a.A1_CALMA,
                                  A1_CLOCALI = a.A1_CLOCALI,
                                  A1_CDESCRI = a.A1_CDESCRI,
                                  A1_CDIRECC = a.A1_CDIRECC,
                                  A1_CDEPT = a.A1_CDEPT,
                                  A1_CDISTRI = a.A1_CDISTRI,
                                  A1_CPROV = a.A1_CPROV

                              }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }

        public static AL0003ALMA ListadirAlmacen(AL0003ALMA CALMA)
        {
            AL0003ALMA listaA = new AL0003ALMA();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listaA = (from c in ctx.AL0003ALMA where c.A1_CALMA==CALMA.A1_CALMA orderby c.A1_CDESCRI select c).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return listaA;
        }
        //NUEVO WILLIAM
        public static Boolean actualizaNumeracion(AL0003ALMA datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new AL0003ALMA { A1_CALMA = datos.A1_CALMA };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003ALMA.Attach(data);
                    data.A1_NNUMENT = datos.A1_NNUMENT;
                    data.A1_NNUMSAL = datos.A1_NNUMSAL;
                    data.A1_CUSUMOD = datos.A1_CUSUMOD;
                    data.A1_DFECMOD = fechaA;
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
        //CODIGO EDGAR
        public static List<AL0003ALMA> ListarAlmacenParaStockValorizado(string cod1, string cod2)
        {
            var alumnos = new List<AL0003ALMA>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.Database.SqlQuery<AL0003ALMA>("select * from  AL0003ALMA  where A1_CALMA between @cod1 and @cod2 order by rtrim(ltrim(A1_CALMA))",
                           new SqlParameter("cod1", cod1), new SqlParameter("cod2", cod2)).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<AL0003ALMA> ListarALMACENES(AL0003ALMA TABL)
        {
            var alumnos = new List<AL0003ALMA>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = (from c in ctx.AL0003ALMA
                               select new
                               {
                                   A1_CALMA = c.A1_CALMA,
                                   A1_CDESCRI = c.A1_CDESCRI,
                               }

                        ).ToList().Select(c => new AL0003ALMA()
                        {
                            A1_CALMA = c.A1_CALMA.Trim(),
                            A1_CDESCRI = c.A1_CDESCRI.Trim(),


                        }).ToList(); ;
                }
            }
            catch (Exception)
            {

                throw;
            }
            return alumnos;
        }

        public static List<vista_esvarticulo> RptESVARTALM(vista_esvarticulo COM)

        {
            var Listarep = new List<vista_esvarticulo>();

            using (var ctx = new RSFACAR())
            {
                string[] arreglo = COM.CADENA.Split(',');
                string[] movimiento = COM.MOVIMIENTO.Split(',');
                string[] articulo = COM.AR_CCODIGO.Split(',');
                string[] almacen = COM.A1_CALMA.Split(',');


                Listarep = (from ARTI in ctx.AL0003ARTI
                            join GEN in ctx.AL0003TABL on new { AR_CFAMILI = ARTI.AR_CFAMILI } equals new { AR_CFAMILI = GEN.TG_CCLAVE }
                            join MOVG in ctx.AL0003MOVG on new { C6_CCODIGO = ARTI.AR_CCODIGO } equals new { C6_CCODIGO = MOVG.C6_CCODIGO }
                            join ALMACEN in ctx.AL0003ALMA on new { A1_CALMA = MOVG.C6_CALMA } equals new { A1_CALMA = ALMACEN.A1_CALMA }
                            where
                             (MOVG.C6_DFECDOC >= COM.C6_DFECDOC && MOVG.C6_DFECDOC <= COM.C6_FECHA2 &&
                             (arreglo).Contains(MOVG.C6_CCODMOV) && (movimiento).Contains(MOVG.C6_CTIPMOV)
                             && (almacen).Contains(ALMACEN.A1_CALMA) && (articulo).Contains(ARTI.AR_CCODIGO)
                             )
                            select new
                            {
                                data1 = ARTI.AR_CCODIGO,
                                data13 = ARTI.AR_CDESCRI,
                                data2 = ARTI.AR_CUNIDAD,
                                data3 = GEN.TG_CDESCRI,
                                data4 = ALMACEN.A1_CALMA,
                                data5 = MOVG.C6_CNUMDOC,
                                data6 = MOVG.C6_DFECDOC,
                                data7 = MOVG.C6_NCANTID,
                                data8 = MOVG.C6_NMNPRUN,
                                data9 = MOVG.C6_NUSPRUN,
                                data10 = MOVG.C6_NMNIMPO,
                                data11 = MOVG.C6_NUSIMPO,
                                data12 = COM.C6_CCODMON,
                                data14 = MOVG.C6_CTIPMOV,
                                data15 = MOVG.C6_CCUENTR,
                                data16 = MOVG.C6_CCENCOS,
                                data17 = MOVG.C6_CORDEN,
                                data18 = MOVG.C6_CSOLI,

                                //centro de costo   
                                DATA19 = ((from b in ctx.AL0003TABL
                                           where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == MOVG.C6_CCENCOS
                                           select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                //solicitante
                                DATA20 = ((from b in ctx.AL0003TABL
                                           where b.TG_CCOD.Trim() == "12" && b.TG_CCLAVE.Trim() == MOVG.C6_CSOLI
                                           select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                                data21 = MOVG.C6_CRFTDOC,
                                data22 = MOVG.C6_CRFNDOC,
                                DATA23 = MOVG.C6_CCODPRO,
                                data24 = MOVG.C6_CCODMOV,


                            }).Distinct().ToList().
                 Select(c => new vista_esvarticulo()

                 {
                     AR_CCODIGO = c.data1,
                     AR_CDESCRI = c.data13,
                     AR_CUNIDAD = c.data2,
                     TG_CDESCRI = c.data3,
                     A1_CALMA = c.data4,
                     C6_CNUMDOC = c.data5,
                     fecdoc = Convert.ToString(c.data6).Substring(0, 10),
                     C6_NCANTID = c.data7,
                     C6_NMNPRUN = c.data8,
                     C6_NUSPRUN = c.data9,
                     C6_NMNIMPO = c.data10,
                     C6_NUSIMPO = c.data11,
                     C6_CCODMON = c.data12,
                     C6_CTIPMOV = c.data14,
                     C6_CCUENTA = c.data15,
                     C6_CCENCOS = c.data16,
                     C6_CORDEN = c.data17,
                     C6_CSOLI = c.data18,
                     CCOSTO = c.DATA19,
                     solicitante = c.DATA20,
                     C6_CRFTDOC = c.data21,
                     C6_CRFNDOC = c.data22,
                     ADESANE = (CT0003ANEX.obtenProveedorED(c.DATA23).ADESANE) == "" ? "proveedor no existe" : CT0003ANEX.obtenProveedorED(c.DATA23).ADESANE,
                     C6_CCODMOV = c.data24,

                 }).ToList();

            }
            return Listarep;
        }

        public static List<vista_esvarticulo> RptESVPROALM(vista_esvarticulo COM)
        {
            var Listarep = new List<vista_esvarticulo>();
            string[] arreglo = COM.CADENA.Split(',');
            string[] movimiento = COM.MOVIMIENTO.Split(',');
            string[] proveedor = COM.ACODANE.Split(',');
            string[] almacen = COM.A1_CALMA.Split(',');

            using (var ctx = new RSFACAR())
            // using (var cty =new RSCONCAR())
            {
                Listarep = (from MOVG in ctx.AL0003MOVG
                            join ALMACEN in ctx.AL0003ALMA on new { A1_CALMA = MOVG.C6_CALMA } equals new { A1_CALMA = ALMACEN.A1_CALMA }
                            join ARTI in ctx.AL0003ARTI on new { C6_CCODIGO = MOVG.C6_CCODIGO } equals new { C6_CCODIGO = ARTI.AR_CCODIGO }
                            where
                              (MOVG.C6_DFECDOC >= COM.C6_DFECDOC && MOVG.C6_DFECDOC <= COM.C6_FECHA2 &&
                              (arreglo).Contains(MOVG.C6_CCODMOV) && (movimiento).Contains(MOVG.C6_CTIPMOV) &&
                              (proveedor).Contains(MOVG.C6_CCODPRO) && (almacen).Contains(ALMACEN.A1_CALMA)
                              )
                            select new
                            {
                                data1 = MOVG.C6_CCODPRO,
                                data2 = "",
                                data3 = "",
                                data4 = ALMACEN.A1_CALMA,
                                data5 = MOVG.C6_CNUMDOC,
                                data6 = MOVG.C6_CTIPMOV,
                                data7 = MOVG.C6_CCODMOV,
                                data8 = MOVG.C6_CRFTDOC,
                                data9 = MOVG.C6_CRFNDOC,
                                data10 = ARTI.AR_CCODIGO,
                                data11 = ARTI.AR_CDESCRI,
                                data12 = ARTI.AR_CUNIDAD,
                                data13 = MOVG.C6_NCANTID,
                                data14 = MOVG.C6_NMNPRUN,
                                data15 = MOVG.C6_NUSPRUN,
                                data16 = MOVG.C6_NMNIMPO,
                                data17 = MOVG.C6_NUSIMPO,
                                data18 = COM.C6_CCODMON,
                                data19 = MOVG.C6_DFECDOC,
                                data21 = MOVG.C6_CORDEN,
                                data22 = MOVG.C6_CSOLI,

                                //centro de costo   
                                DATA23 = ((from b in ctx.AL0003TABL
                                           where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == MOVG.C6_CCENCOS
                                           select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                //solicitante
                                DATA20 = ((from b in ctx.AL0003TABL
                                           where b.TG_CCOD.Trim() == "12" && b.TG_CCLAVE.Trim() == MOVG.C6_CSOLI
                                           select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                            }).ToList().
      Select(c => new vista_esvarticulo()

      {
          C6_CCODPRO = c.data1,
          ADESANE = (CT0003ANEX.obtenProveedorED(c.data1).ADESANE),
          ARUC = CT0003ANEX.obtenProveedorED(c.data1).ARUC,
          A1_CALMA = c.data4,
          C6_CNUMDOC = c.data5,
          C6_CTIPMOV = c.data6,
          C6_CCODMOV = c.data7,
          C6_CRFTDOC = c.data8,
          C6_CRFNDOC = c.data9,
          AR_CCODIGO = c.data10,
          AR_CDESCRI = c.data11,
          AR_CUNIDAD = c.data12,
          C6_NCANTID = c.data13,
          C6_NMNPRUN = c.data14,
          C6_NUSPRUN = c.data15,
          C6_NMNIMPO = c.data16,
          C6_NUSIMPO = c.data17,
          C6_CCODMON = c.data18,
          fecdoc = Convert.ToString(c.data19).Substring(0, 10),
          C6_CORDEN = c.data21,
          C6_CSOLI = c.data22,
          CCOSTO = c.DATA23,
          solicitante = c.DATA20,

      }).ToList();

            }
            return Listarep;
        }

        public static List<vista_stockvalorizado> RptSVRESUMIDO(vista_stockvalorizado COM, string ind)
        {
            var Listarep = new List<vista_stockvalorizado>();
            string[] clave = COM.TG_CCLAVE.Split(',');
            string[] clavegrupo = new string[clave.Length];
            string[] clavefamilia = new string[clave.Length];
            string[] clavearticulo = new string[clave.Length];
            string[] clavecuenta = new string[clave.Length];
            string[] clavemodelo = new string[clave.Length];
            string[] clavemarca = new string[clave.Length];

            if (ind == "06")
            {
                clavegrupo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "38")
            {
                clavefamilia = COM.TG_CCLAVE.Split(',');
            }

            if (ind == "A")
            {
                clavearticulo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "07")
            {
                clavecuenta = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "39")
            {
                clavemodelo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "V7")
            {
                clavemarca = COM.TG_CCLAVE.Split(',');
            }
            using (var ctx = new RSFACAR())

            {
                Listarep = (from articulo in ctx.AL0003ARTI
                            join det in ctx.AL0003RESU on new { AR_CCODIGO = articulo.AR_CCODIGO } equals new { AR_CCODIGO = det.VL_CCODIGO }
                            where
                              ((det.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim() && det.VL_NANTCAN != 0
                              )
                              &&
                               ((clavearticulo).Contains(articulo.AR_CCODIGO) || (clavefamilia).Contains(articulo.AR_CFAMILI) ||
                              (clavegrupo).Contains(articulo.AR_CGRUPO) || (clavecuenta).Contains(articulo.AR_CCUENTA) || (clavemodelo).Contains(articulo.AR_CMODELO) ||
                              (clavemarca).Contains(articulo.AR_CMARCA)) //|| //(clave).Contains(articulo.AR_CLINEA))
                               )
                            orderby
                              articulo.AR_CDESCRI
                            select new
                            {
                                data1 = articulo.AR_CGRUPO,
                                data2 = articulo.AR_CFAMILI,
                                data3 = articulo.AR_CLINEA,
                                data4 = articulo.AR_CMARCA,
                                data5 = articulo.AR_CMODELO,
                                data6 = articulo.AR_CCUENTA,
                                data7 = det.VL_CMESPRO,
                                data9 = articulo.AR_CCODIGO,
                                data10 = articulo.AR_CDESCRI,
                                data11 = articulo.AR_CUNIDAD,
                                data12 = det.VL_NANTCAN,
                                data13 = (from R in (from R in ctx.AL0003RESU
                                                     where
                           R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NMNPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NMNPRUN)
                                          }).FirstOrDefault().Column1,

                                data14 = (from R in (from R in ctx.AL0003RESU
                                                     where R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NUSPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NUSPRUN)
                                          }
                                          ).FirstOrDefault().Column1,

                                data15 = COM.AR_CMONVTA,

                            }).Distinct().ToList().
                         Select(c => new vista_stockvalorizado()

                         {
                             AR_CGRUPO = c.data1,
                             PRECIOSOLES = c.data13,
                             PRECIODOLARES = c.data14,
                             familia = AL0003ALMA.obtenDATOSVARIOS(c.data2, "38").TG_CDESCRI,
                             grupo = AL0003ALMA.obtenDATOSVARIOS(c.data1, "06").TG_CDESCRI,
                             cuenta = AL0003ALMA.obtenDATOSVARIOS(c.data6, "07").TG_CDESCRI,
                             modelo = AL0003ALMA.obtenDATOSVARIOS(c.data5, "39").TG_CDESCRI,
                             marca = AL0003ALMA.obtenDATOSVARIOS(c.data4, "V7").TG_CDESCRI,
                             linea = AL0003ALMA.obtenDATOSLINEA(c.data3).LI_CCODLIN,
                             AR_CFAMILI = c.data2,
                             AR_CLINEA = c.data3,
                             AR_CMARCA = c.data4,
                             AR_CMODELO = c.data5,
                             AR_CCUENTA = c.data6,
                             SA_CMESPRO = c.data7,
                             AR_CCODIGO = c.data9,
                             AR_CDESCRI = c.data10,
                             AR_CUNIDAD = c.data11,
                             SA_NCANACT = c.data12,
                             AR_CMONVTA = c.data15,


                         }).ToList();

            }
            return Listarep;
        }


        public static AL0003TABL obtenDATOSVARIOS(string texto, string INDICADOR)
        {
            var alumnos = new AL0003TABL();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.AL0003TABL.Where(x => x.TG_CCLAVE.Trim() == texto.Trim() && x.TG_CCOD.Trim() == INDICADOR.Trim()).FirstOrDefault();

                    if (alumnos == null)
                    {

                        AL0003TABL alumnos1 = new AL0003TABL()
                        {
                            TG_CDESCRI = "no registrado",
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
       
        public static FT0003LINE obtenDATOSLINEA(string texto)
        {
            var alumnos = new FT0003LINE();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.FT0003LINE.Where(x => x.LI_CCODLIN.Trim() == texto.Trim()).FirstOrDefault();

                    if (alumnos == null)
                    {
                        FT0003LINE alumnos1 = new FT0003LINE()
                        {
                            LI_CDESLIN = "no registrado",
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
        public static List<vista_stockvalorizado> RptSVPORALMACENPORCADAUNO(vista_stockvalorizado COM, string ind)
        {
            var Listarep = new List<vista_stockvalorizado>();
            string[] clave = COM.TG_CCLAVE.Split(',');
            string[] clavegrupo = new string[clave.Length];
            string[] clavefamilia = new string[clave.Length];
            string[] clavearticulo = new string[clave.Length];
            string[] clavecuenta = new string[clave.Length];
            string[] clavemodelo = new string[clave.Length];
            string[] clavemarca = new string[clave.Length];

            if (ind == "06")
            {
                clavegrupo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "38")
            {
                clavefamilia = COM.TG_CCLAVE.Split(',');
            }

            if (ind == "A")
            {
                clavearticulo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "07")
            {
                clavecuenta = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "39")
            {
                clavemodelo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "V7")
            {
                clavemarca = COM.TG_CCLAVE.Split(',');
            }
            using (var ctx = new RSFACAR())
            {
                Listarep = (from articulo in ctx.AL0003ARTI
                            join det in ctx.AL0003SKNU on new { AR_CCODIGO = articulo.AR_CCODIGO } equals new { AR_CCODIGO = det.SA_CCODIGO }
                            where
                              ((det.SA_CMESPRO.Trim() == COM.SA_CMESPRO.Trim() && det.SA_CALMA == COM.SA_CALMA
                                 && det.SA_NCANACT != 0
                              )
                               &&
                             ((clavearticulo).Contains(articulo.AR_CCODIGO) || (clavefamilia).Contains(articulo.AR_CFAMILI) ||
                              (clavegrupo).Contains(articulo.AR_CGRUPO) || (clavecuenta).Contains(articulo.AR_CCUENTA) || (clavemodelo).Contains(articulo.AR_CMODELO) ||
                              (clavemarca).Contains(articulo.AR_CMARCA)) //|| //(clave).Contains(articulo.AR_CLINEA))
                             )
                            orderby
                              articulo.AR_CDESCRI
                            select new
                            {
                                data1 = articulo.AR_CGRUPO,
                                data2 = articulo.AR_CFAMILI,
                                data3 = articulo.AR_CLINEA,
                                data4 = articulo.AR_CMARCA,
                                data5 = articulo.AR_CMODELO,
                                data6 = articulo.AR_CCUENTA,
                                data7 = det.SA_CMESPRO,
                                data8 = det.SA_CALMA,
                                data9 = articulo.AR_CCODIGO,
                                data10 = articulo.AR_CDESCRI,
                                data11 = articulo.AR_CUNIDAD,
                                data12 = det.SA_NCANACT,
                                data13 = (from R in (from R in ctx.AL0003RESU
                                                     where
                           R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NMNPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NMNPRUN)
                                          }).FirstOrDefault().Column1,

                                data14 = (from R in (from R in ctx.AL0003RESU
                                                     where R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NUSPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NUSPRUN)
                                          }
                                          ).FirstOrDefault().Column1,

                                data15 = COM.AR_CMONVTA,
                                data16 = ((from b in ctx.AL0003ALMA
                                           where b.A1_CALMA.Trim() == COM.SA_CALMA
                                           select new { b.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),

                            }).Distinct().ToList().
                         Select(c => new vista_stockvalorizado()

                         {
                             AR_CGRUPO = c.data1,
                             PRECIOSOLES = c.data13,
                             PRECIODOLARES = c.data14,
                             familia = AL0003ALMA.obtenDATOSVARIOS(c.data2, "38").TG_CDESCRI,
                             grupo = AL0003ALMA.obtenDATOSVARIOS(c.data1, "06").TG_CDESCRI,
                             cuenta = AL0003ALMA.obtenDATOSVARIOS(c.data6, "07").TG_CDESCRI,
                             modelo = AL0003ALMA.obtenDATOSVARIOS(c.data5, "39").TG_CDESCRI,
                             marca = AL0003ALMA.obtenDATOSVARIOS(c.data4, "V7").TG_CDESCRI,
                             linea = AL0003ALMA.obtenDATOSLINEA(c.data3).LI_CCODLIN,
                             AR_CFAMILI = c.data2,
                             AR_CLINEA = c.data3,
                             AR_CMARCA = c.data4,
                             AR_CMODELO = c.data5,
                             AR_CCUENTA = c.data6,
                             SA_CMESPRO = c.data7,
                             SA_CALMA = c.data8,
                             AR_CCODIGO = c.data9,
                             AR_CDESCRI = c.data10,
                             AR_CUNIDAD = c.data11,
                             SA_NCANACT = Convert.ToDecimal(c.data12),
                             AR_CMONVTA = c.data15,
                             almacen = c.data16


                         }).ToList();

            }
            return Listarep;
        }

        public static List<vista_stockvalorizado> RptSVDETALLADO1X1(vista_stockvalorizado COM, string ind)
        {
            var Listarep = new List<vista_stockvalorizado>();
            string[] clave = COM.TG_CCLAVE.Split(',');
            string[] clavegrupo = new string[clave.Length];
            string[] clavefamilia = new string[clave.Length];
            string[] clavearticulo = new string[clave.Length];
            string[] clavecuenta = new string[clave.Length];
            string[] clavemodelo = new string[clave.Length];
            string[] clavemarca = new string[clave.Length];

            if (ind == "06")
            {
                clavegrupo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "38")
            {
                clavefamilia = COM.TG_CCLAVE.Split(',');
            }

            if (ind == "A")
            {
                clavearticulo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "07")
            {
                clavecuenta = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "39")
            {
                clavemodelo = COM.TG_CCLAVE.Split(',');
            }
            if (ind == "V7")
            {
                clavemarca = COM.TG_CCLAVE.Split(',');
            }

            using (var ctx = new RSFACAR())

            {
                Listarep = (from articulo in ctx.AL0003ARTI
                            join det in ctx.AL0003SKNU on new { AR_CCODIGO = articulo.AR_CCODIGO } equals new { AR_CCODIGO = det.SA_CCODIGO }
                            where
                              ((det.SA_CMESPRO.Trim() == COM.SA_CMESPRO.Trim() && det.SA_NCANACT != 0
                              )
                              &&
                               ((clavearticulo).Contains(articulo.AR_CCODIGO) || (clavefamilia).Contains(articulo.AR_CFAMILI) ||
                              (clavegrupo).Contains(articulo.AR_CGRUPO) || (clavecuenta).Contains(articulo.AR_CCUENTA) || (clavemodelo).Contains(articulo.AR_CMODELO) ||
                              (clavemarca).Contains(articulo.AR_CMARCA)) //|| //(clave).Contains(articulo.AR_CLINEA))
                             )
                            orderby
                              articulo.AR_CDESCRI
                            select new
                            {
                                data1 = articulo.AR_CGRUPO,
                                data2 = articulo.AR_CFAMILI,
                                data3 = articulo.AR_CLINEA,
                                data4 = articulo.AR_CMARCA,
                                data5 = articulo.AR_CMODELO,
                                data6 = articulo.AR_CCUENTA,
                                data7 = det.SA_CMESPRO,
                                data8 = det.SA_CALMA,
                                data9 = articulo.AR_CCODIGO,
                                data10 = articulo.AR_CDESCRI,
                                data11 = articulo.AR_CUNIDAD,
                                data12 = det.SA_NCANACT,
                                data13 = (from R in (from R in ctx.AL0003RESU
                                                     where
                           R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NMNPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NMNPRUN)
                                          }).FirstOrDefault().Column1,

                                data14 = (from R in (from R in ctx.AL0003RESU
                                                     where R.VL_CCODIGO == articulo.AR_CCODIGO && R.VL_CMESPRO.Trim() == COM.SA_CMESPRO.Trim()
                                                     select new { R.VL_NUSPRUN, Dummy = "x" })
                                          group R by new { R.Dummy } into g
                                          select new
                                          {
                                              Column1 = (decimal)g.Average(p => p.VL_NUSPRUN)
                                          }
                                          ).FirstOrDefault().Column1,

                                data15 = COM.AR_CMONVTA,
                                data16 = ((from b in ctx.AL0003ALMA
                                           where b.A1_CALMA.Trim() == det.SA_CALMA
                                           select new { b.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),

                            }).Distinct().ToList().
                         Select(c => new vista_stockvalorizado()

                         {
                             AR_CGRUPO = c.data1,
                             PRECIOSOLES = c.data13,
                             PRECIODOLARES = c.data14,
                             familia = AL0003ALMA.obtenDATOSVARIOS(c.data2, "38").TG_CDESCRI,
                             grupo = AL0003ALMA.obtenDATOSVARIOS(c.data1, "06").TG_CDESCRI,
                             cuenta = AL0003ALMA.obtenDATOSVARIOS(c.data6, "07").TG_CDESCRI,
                             modelo = AL0003ALMA.obtenDATOSVARIOS(c.data5, "39").TG_CDESCRI,
                             marca = AL0003ALMA.obtenDATOSVARIOS(c.data4, "V7").TG_CDESCRI,
                             linea = AL0003ALMA.obtenDATOSLINEA(c.data3).LI_CCODLIN,
                             AR_CFAMILI = c.data2,
                             AR_CLINEA = c.data3,
                             AR_CMARCA = c.data4,
                             AR_CMODELO = c.data5,
                             AR_CCUENTA = c.data6,
                             SA_CMESPRO = c.data7,
                             SA_CALMA = c.data8,
                             AR_CCODIGO = c.data9,
                             AR_CDESCRI = c.data10,
                             AR_CUNIDAD = c.data11,
                             SA_NCANACT = Convert.ToDecimal(c.data12),
                             AR_CMONVTA = c.data15,
                             almacen = c.data16


                         }).ToList();

            }
            return Listarep;
        }






    }
}
