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
    public partial class AL0003MOVC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string C5_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string C5_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(11)]
        public string C5_CNUMDOC { get; set; }

        [Required]
        [StringLength(4)]
        public string C5_CLOCALI { get; set; }

        public DateTime? C5_DFECDOC { get; set; }

        public DateTime? C5_DFECVEN { get; set; }

        [Required]
        [StringLength(1)]
        public string C5_CTIPMOV { get; set; }

        [Required]
        [StringLength(2)]
        public string C5_CCODMOV { get; set; }


        [StringLength(1)]
        public string C5_CSITUA { get; set; }


        [StringLength(2)]
        public string C5_CRFTDOC { get; set; }


        [StringLength(24)]
        public string C5_CRFNDOC { get; set; }


        [StringLength(3)]
        public string C5_CSOLI { get; set; }


        [StringLength(6)]
        public string C5_CCENCOS { get; set; }


        [StringLength(4)]
        public string C5_CRFALMA { get; set; }


        [StringLength(30)]
        public string C5_CGLOSA1 { get; set; }


        [StringLength(30)]
        public string C5_CGLOSA2 { get; set; }


        [StringLength(30)]
        public string C5_CGLOSA3 { get; set; }


        [StringLength(1)]
        public string C5_CTIPANE { get; set; }


        [StringLength(18)]
        public string C5_CCODANE { get; set; }

        public DateTime? C5_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string C5_CUSUCRE { get; set; }

        public DateTime? C5_DFECMOD { get; set; }


        [StringLength(5)]
        public string C5_CUSUMOD { get; set; }


        [StringLength(18)]
        public string C5_CCODCLI { get; set; }


        [StringLength(50)]
        public string C5_CNOMCLI { get; set; }


        [StringLength(18)]
        public string C5_CRUC { get; set; }


        [StringLength(4)]
        public string C5_CCODCAD { get; set; }


        [StringLength(10)]
        public string C5_CCODINT { get; set; }


        [StringLength(18)]
        public string C5_CCODTRA { get; set; }


        [StringLength(50)]
        public string C5_CNOMTRA { get; set; }


        [StringLength(18)]
        public string C5_CCODVEH { get; set; }


        [StringLength(2)]
        public string C5_CTIPGUI { get; set; }


        [StringLength(1)]
        public string C5_CSITGUI { get; set; }


        [StringLength(1)]
        public string C5_CGUIFAC { get; set; }


        [StringLength(4)]
        public string C5_CDESTIN { get; set; }


        [StringLength(80)]
        public string C5_CDIRENV { get; set; }


        [StringLength(20)]
        public string C5_CNUMORD { get; set; }


        [StringLength(1)]
        public string C5_CTIPORD { get; set; }


        [StringLength(1)]
        public string C5_CGUIDEV { get; set; }


        [StringLength(18)]
        public string C5_CCODPRO { get; set; }


        [StringLength(50)]
        public string C5_CNOMPRO { get; set; }


        [StringLength(4)]
        public string C5_CCIAS { get; set; }


        [StringLength(3)]
        public string C5_CFORVEN { get; set; }


        [StringLength(2)]
        public string C5_CCODMON { get; set; }


        [StringLength(5)]
        public string C5_CVENDE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NTIPCAM { get; set; }


        [StringLength(4)]
        public string C5_CCODAGE { get; set; }


        [StringLength(11)]
        public string C5_CNUMPED { get; set; }


        [StringLength(80)]
        public string C5_CDIRECC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NIMPORT { get; set; }


        [StringLength(1)]
        public string C5_CTIPO { get; set; }


        [StringLength(4)]
        public string C5_CSUBDIA { get; set; }


        [StringLength(6)]
        public string C5_CCOMPRO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NPORDE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NPORDE2 { get; set; }


        [StringLength(2)]
        public string C5_CTF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NFLETE { get; set; }


        [StringLength(15)]
        public string C5_CCODAUT { get; set; }


        [StringLength(2)]
        public string C5_CRFTDO2 { get; set; }


        [StringLength(24)]
        public string C5_CRFNDO2 { get; set; }


        [StringLength(23)]
        public string C5_CNUMLIQ { get; set; }


        [StringLength(18)]
        public string C5_CORDEN { get; set; }


        [StringLength(1)]
        public string C5_CTIPOGS { get; set; }

        public DateTime? C5_DFECANU { get; set; }


        [StringLength(18)]
        public string C5_CCODFER { get; set; }

        public DateTime? C5_DFECEMB { get; set; }


        [StringLength(50)]
        public string C5_CGLOSA4 { get; set; }


        [StringLength(5)]
        public string C5_CVENDE2 { get; set; }


        [StringLength(1)]
        public string C5_CESTDEV { get; set; }


        [StringLength(1)]
        public string C5_CEXTOR { get; set; }


        [StringLength(80)]
        public string C5_CRENOM { get; set; }


        [StringLength(18)]
        public string C5_CRERUC { get; set; }


        [StringLength(80)]
        public string C5_CREREF { get; set; }


        [StringLength(80)]
        public string C5_CDSNOM { get; set; }


        [StringLength(18)]
        public string C5_CDSRUC { get; set; }


        [StringLength(12)]
        public string C5_CLLECIU { get; set; }


        [StringLength(12)]
        public string C5_CPARCIU { get; set; }


        [StringLength(10)]
        public string C5_CTTRACT { get; set; }


        [StringLength(10)]
        public string C5_CTRASRE { get; set; }


        [StringLength(10)]
        public string C5_CTRAREM { get; set; }


        [StringLength(25)]
        public string C5_CLICCON { get; set; }


        [StringLength(80)]
        public string C5_CSBNOM { get; set; }


        [StringLength(18)]
        public string C5_CSBRUC { get; set; }


        [StringLength(25)]
        public string C5_CSBMTC { get; set; }


        [StringLength(2)]
        public string C5_CMONPER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NIMPPER { get; set; }


        [StringLength(1)]
        public string C5_CFPERCP { get; set; }


        [StringLength(1)]
        public string C5_CESTFIN { get; set; }


        [StringLength(1)]
        public string C5_CFLGPEN { get; set; }


        [StringLength(2)]
        public string C5_CTIPFOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal C5_NPORPER { get; set; }


        [StringLength(1)]
        public string C5_CFLGTRM { get; set; }


        [StringLength(18)]
        public string C5_CAGETRA { get; set; }


        [StringLength(30)]
        public string C5_CCONTAI { get; set; }

        public static Boolean insertaCabeceraEntrada(AL0003MOVC datos)
        {
            Boolean band = true;
            var fechaA = DateTime.Now;
            var NALM = new AL0003ALMA();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //NUEVO
                    NALM.A1_CALMA = datos.C5_CALMA;
                    if (datos.C5_CTIPMOV == "E")
                    {

                        NALM.A1_NNUMENT = Convert.ToDecimal(datos.C5_CNUMDOC);

                    }
                    else if (datos.C5_CTIPMOV == "S")
                    {
                        NALM.A1_NNUMSAL = Convert.ToDecimal(datos.C5_CNUMDOC);
                    }
                    NALM.A1_CUSUMOD = datos.C5_CUSUCRE;
                    NALM.A1_DFECMOD = fechaA;
                    AL0003ALMA.actualizaNumeracion(NALM);

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
        /// Actualiza cabecera
        /// filtros:
        /// Actualizacion: 12/04/2016
        /// Nota: Se agrego metodo para actualizar fecha de detalle
        /// </summary>
        /// <param name="datos"></param>
        /// <returns></returns>
        public static Boolean actualizaCabeceraEntrada(AL0003MOVC datos)
        {
            Boolean band = true;
            int COUNT;
            var fechaA = DateTime.Now;
            var data = new AL0003MOVC { C5_CALMA = datos.C5_CALMA, C5_CTD = datos.C5_CTD, C5_CNUMDOC = datos.C5_CNUMDOC };
            var datad = new AL0003MOVD { C6_CALMA = datos.C5_CALMA, C6_CTD = datos.C5_CTD, C6_CNUMDOC = datos.C5_CNUMDOC };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    COUNT = ctx.AL0003MOVD.Where(x => x.C6_CALMA == datos.C5_CALMA && x.C6_CTD == datos.C5_CTD && x.C6_CNUMDOC == datos.C5_CNUMDOC).Count();
                    //ctx.tabla_menuusuarios.Where(x => x.USUA == codusuario && x.URL.Replace("/SEALOGISTICA", "") == urll).Count();
                    ctx.AL0003MOVC.Attach(data);
                    datad.C6_DFECDOC = datos.C5_DFECDOC;
                    data.C5_DFECDOC = datos.C5_DFECDOC;
                    data.C5_CGLOSA1 = datos.C5_CGLOSA1;
                    data.C5_CGLOSA2 = datos.C5_CGLOSA2;
                    data.C5_CGLOSA3 = datos.C5_CGLOSA3;
                    data.C5_CCODPRO = datos.C5_CCODPRO;
                    data.C5_CNOMPRO = datos.C5_CNOMPRO;
                    data.C5_DFECMOD = fechaA;
                    data.C5_CUSUMOD = datos.C5_CUSUMOD;
                    data.C5_CCENCOS = datos.C5_CCENCOS;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();

                    //NITEM = COUNT.ToString("D4");
                    for (int i = 1; i <= COUNT; i++)
                    {
                        string MITEM;
                        MITEM = i.ToString("D4");
                        AL0003MOVD.actualizaDetalleEntrada(datad, MITEM);
                    }

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

        public static List<AL0003MOVC> listaNRODOCUMENTO(string ND, string ES, string TD, string AL)
        {
            List<AL0003MOVC> listND = new List<AL0003MOVC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = ctx.AL0003MOVC.Where(x => x.C5_CTIPMOV == ES && x.C5_CTD == TD && x.C5_CALMA == AL && x.C5_CNUMDOC.Contains(ND)).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }
        public static AL0003MOVC obtenerCabecera(string ES, string TD, string AL, string ND)
        {
            //NO HA HABIDO NADA OPERACION YA. CON TODOS.
            var datos = new AL0003MOVC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = ctx.AL0003MOVC.Where(x => x.C5_CTIPMOV == ES && x.C5_CTD == TD && x.C5_CALMA == AL && x.C5_CNUMDOC.Contains(ND)).FirstOrDefault();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }
        public static string codMaximo(string ALM, string TDOC)
        {
            int cuenta = 0; string codID;
            try
            {
                using (var ctx = new RSFACAR())
                {

                    cuenta = Convert.ToInt32(ctx.AL0003MOVC.Where(x => x.C5_CALMA == ALM && x.C5_CTD == TDOC && x.C5_CNUMDOC.Length == 11).Max(x => x.C5_CNUMDOC));

                }
            }
            catch (Exception)
            {

                throw;
            }

            cuenta = cuenta + 1;
            codID = cuenta.ToString("D11");
            return codID;
        }
        //ACTUALIZACION: 17/03/2016
        public static List<AL0003MOVC> listaDocumentos(AL0003MOVC DATOS)
        {
            //DateTime f1 = Convert.ToDateTime(FEC1);
            //DateTime f2 = (FEC2!=""?Convert.ToDateTime(FEC2): null);
            List<AL0003MOVC> listND = new List<AL0003MOVC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND = ctx.AL0003MOVC.Where(tb => tb.C5_CALMA == DATOS.C5_CALMA && (DATOS.C5_CNUMDOC != "" ? tb.C5_CNUMDOC == DATOS.C5_CNUMDOC : tb.C5_CNUMDOC != DATOS.C5_CNUMDOC) &&
                                (DATOS.C5_CTD != null ? tb.C5_CTD == DATOS.C5_CTD : tb.C5_CTD != DATOS.C5_CTD) &&
                                (DATOS.C5_CCODCLI != "" ? tb.C5_CCODCLI == DATOS.C5_CCODCLI : tb.C5_CCODCLI == DATOS.C5_CCODCLI) &&
                                (DATOS.C5_DFECDOC != null && DATOS.C5_DFECVEN != null ? tb.C5_DFECDOC >= DATOS.C5_DFECDOC && tb.C5_DFECDOC <= DATOS.C5_DFECVEN : tb.C5_DFECDOC == DATOS.C5_DFECDOC)
                                /*(DATOS.C5_DFECVEN!=null? (tb.C5_DFECDOC.Value.Year == DATOS.C5_DFECVEN.Value.Year && tb.C5_DFECDOC.Value.Month == DATOS.C5_DFECVEN.Value.Day): */
                                ).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }
        public static List<Principal> listaFinal(AL0003MOVC datos)
        {
            //AL0003MOVC datos
            List<Principal> listND = new List<Principal>();
            try
            {
                DateTime f1 = Convert.ToDateTime(datos.C5_DFECDOC);
                using (var ctx = new RSFACAR())
                {
                    listND = (from c in ctx.AL0003MOVC
                              join d in ctx.AL0003MOVD
                                    on new { c.C5_CALMA, c.C5_CTD, c.C5_CNUMDOC }
                                equals new { C5_CALMA = d.C6_CALMA, C5_CTD = d.C6_CTD, C5_CNUMDOC = d.C6_CNUMDOC }
                              where
                                (c.C5_CALMA == datos.C5_CALMA && c.C5_CTD == datos.C5_CTD && c.C5_CNUMDOC == datos.C5_CNUMDOC)
                              //(c.C5_CALMA == datos.C5_CALMA && c.C5_CTD == datos.C5_CTD && (datos.C5_CNUMDOC ==""?c.C5_CNUMDOC!="" :c.C5_CNUMDOC == datos.C5_CNUMDOC) && (datos.C5_DFECDOC == null?c.C5_DFECDOC!=null:(c.C5_DFECDOC>=f1 && c.C5_DFECDOC<=f1)))
                              select new
                              {
                                  var0 = c.C5_CALMA,
                                  var1 = ((from t1 in ctx.AL0003ALMA
                                           where t1.A1_CALMA == c.C5_CALMA
                                           select new { t1.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                                  var2 = c.C5_CTD,
                                  var3 = c.C5_CNUMDOC,
                                  var4 = c.C5_CLOCALI,
                                  var5 = c.C5_DFECDOC,
                                  var6 = c.C5_CTIPMOV,
                                  var7 = c.C5_CCODMOV,
                                  var71 = ((from t2 in ctx.AL0003TABM
                                            where t2.TM_CCODMOV == c.C5_CCODMOV
                                            select new { t2.TM_CDESCRI }).FirstOrDefault().TM_CDESCRI),
                                  var8 = c.C5_CSITUA,
                                  var9 = c.C5_CRFTDOC,
                                  var10 = c.C5_CRFNDOC,
                                  var101 = c.C5_CRFNDO2,  //ORIGEN
                                  var102 = c.C5_CORDEN,    //BAHIA
                                  var103 = c.C5_CSOLI, // SOLICITANTE
                                  var1031 = ((from t in ctx.AL0003TABL
                                              where t.TG_CCOD == "12" && t.TG_CCLAVE == c.C5_CSOLI
                                              select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),//AL0003TABL
                                  var11 = c.C5_CCENCOS,
                                  var111 = ((from t in ctx.AL0003TABL
                                             where t.TG_CCOD == "10" && t.TG_CCLAVE == c.C5_CCENCOS
                                             select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),//AL0003TABL
                                  var12 = c.C5_CRFALMA,
                                  var13 = c.C5_CGLOSA1,
                                  var14 = c.C5_CGLOSA2,
                                  var15 = c.C5_CGLOSA3,
                                  var16 = c.C5_CGLOSA4,
                                  var17 = c.C5_CCODPRO,
                                  var18 = c.C5_CNOMPRO,
                                  var19 = c.C5_DFECCRE,
                                  var20 = c.C5_CUSUCRE,
                                  var201 = c.C5_CNUMORD,
                                  var202 = c.C5_CCODMON,
                                  var203 = c.C5_CDESTIN,
                                  var204 = c.C5_CCODFER,
                                  var21 = d.C6_CITEM,
                                  var22 = d.C6_CCODIGO,
                                  var23 = d.C6_CDESCRI.ToUpper(),
                                  var24 = d.C6_NCANTID,
                                  var241 = ((from t in ctx.AL0003STOC
                                             where t.SK_CALMA == d.C6_CALMA && t.SK_CCODIGO == d.C6_CCODIGO
                                             select new { t.SK_NSKDIS }).FirstOrDefault().SK_NSKDIS),
                                  var25 = ((from t in ctx.AL0003ARTI
                                            where t.AR_CCODIGO == d.C6_CCODIGO
                                            select new { t.AR_CUNIDAD }).FirstOrDefault().AR_CUNIDAD),
                                  var251 = ((from s in ctx.AL0003SERI
                                             where s.SR_CALMA == d.C6_CALMA && s.SR_CCODIGO == d.C6_CCODIGO
                                             select new { s.SR_CSERIE }).FirstOrDefault().SR_CSERIE),
                                  var26 = d.C6_NPREUNI,
                                  var27 = d.C6_NPREUN1,
                                  var28 = d.C6_NMNPRUN,
                                  var29 = d.C6_NUSPRUN

                              }).ToList().Select(c => new Principal()
                              {
                                  C5_CALMA = c.var0,
                                  NOMAL = c.var1,
                                  C5_CTD = c.var2,
                                  C5_CNUMDOC = c.var3,
                                  C5_CLOCALI = c.var4 == null || c.var4 == "" ? "-" : c.var4.Trim(),
                                  C5_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.var5),
                                  C5_CTIPMOV = c.var6,
                                  C5_CCODMOV = c.var7 == null || c.var7.Trim() == "" ? "-" : c.var7.Trim(),
                                  NOMMOV = c.var71,
                                  C5_CRFTDOC = c.var9 == null || c.var9.Trim() == "" ? "-" : c.var9.Trim(),
                                  C5_CSITUA = c.var8,
                                  C5_CRFNDOC = c.var10 == null || c.var10.Trim() == "" ? "-" : c.var10.Trim(),
                                  C5_CRFNDO2 = c.var101 == null || c.var101.Trim() == "" ? "-" : c.var101.Trim(),
                                  C5_CORDEN = c.var102 == null || c.var102.Trim() == "" ? "-" : c.var102.Trim(),
                                  C5_CSOLI = c.var103 == null || c.var103.Trim() == "" ? "-" : c.var103.Trim(),
                                  NOMSOL = c.var1031 == null || c.var1031.Trim() == "" ? "-" : c.var1031.Trim(),
                                  C5_CCENCOS = c.var11 == null || c.var11.Trim() == "" ? "-" : c.var11.Trim(),
                                  NOMCEC = c.var111 == null || c.var111.Trim() == "" ? "-" : c.var111.Trim(),
                                  C5_CRFALMA = c.var12 == null || c.var12.Trim() == "" ? "-" : c.var12.Trim(),
                                  C5_CGLOSA1 = c.var13 == null || c.var13.Trim() == "" ? "-" :
                                                ((c.var0 == "A002" || c.var0 == "A004" || c.var0 == "0004") && c.var13.Trim().Length <= 11 ?
                                                tabla_embarcaciones.ListarEID(c.var13.Trim()) :
                                                c.var13.Trim()),
                                  C5_CGLOSA2 = c.var14 == null || c.var14.Trim() == "" ? "-" : c.var14.Trim(),
                                  C5_CGLOSA3 = c.var15 == null || c.var15.Trim() == "" ? "-" : c.var15.Trim(),
                                  C5_CGLOSA4 = c.var16 == null || c.var18.Trim() == "" ? "-" : c.var16.Trim(),
                                  C5_CCODPRO = c.var17 == null || c.var17.Trim() == "" ? "-" : c.var17.Trim(),
                                  C5_CNOMPRO = c.var18 == null || c.var18.Trim() == "" ? "-" : c.var18.Trim(),
                                  C5_DFECCRE = String.Format("{0:dd/MM/yyyy}", c.var19),
                                  C5_CUSUCRE = c.var20,
                                  C5_CNUMORD = c.var201,
                                  C5_CCODMON = c.var202,
                                  C5_CDESTIN = c.var203 == null || c.var203.Trim() == "" ? "-" : c.var203.Trim(),
                                  C5_CCODFER = c.var204 == null || c.var204.Trim() == "" ? "-" : c.var204.Trim(),
                                  C6_CITEM = c.var21,
                                  C6_CCODIGO = c.var22,
                                  C6_CDESCRI = c.var23,
                                  C6_NCANTID = c.var24,
                                  SK_NSKDIS = c.var241,
                                  AR_CUNIDAD = c.var25,
                                  SR_CSERIE = c.var251,
                                  C6_NPREUNI = c.var26,
                                  C6_NPREUN1 = c.var27,
                                  C6_NMNPRUN = c.var28,
                                  C6_NUSPRUN = c.var29

                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }
        //NUEVO
        public static List<SCabecera> listaCabecera(AL0003MOVC datos)
        {
            //AL0003MOVC datos
            List<SCabecera> listND = new List<SCabecera>();
            try
            {
                int faux1, faux2;
                DateTime f1 = Convert.ToDateTime(datos.C5_DFECDOC);//Convert.ToDateTime(String.Format("{0:MM/dd/yyyy}", datos.C5_DFECDOC));
                faux1 = Convert.ToDateTime(datos.C5_DFECCRE).Year;
                faux2 = Convert.ToDateTime(datos.C5_DFECCRE).Month;

                using (var ctx = new RSFACAR())
                {
                    listND = (from c in ctx.AL0003MOVC
                              where
                              (c.C5_CALMA == datos.C5_CALMA && c.C5_CTD == datos.C5_CTD &&
                                (datos.C5_CNUMDOC == "" ? c.C5_CNUMDOC != "" : c.C5_CNUMDOC == datos.C5_CNUMDOC) &&
                                (datos.C5_DFECCRE != null ? (c.C5_DFECDOC.Value.Year == faux1 && c.C5_DFECDOC.Value.Month == faux2) : (datos.C5_DFECMOD != null ? c.C5_DFECDOC >= datos.C5_DFECDOC && c.C5_DFECMOD <= datos.C5_DFECMOD : c.C5_DFECDOC >= f1 && c.C5_DFECDOC <= f1)) &&
                                (datos.C5_CCODPRO != null ? c.C5_CCODPRO == datos.C5_CCODPRO : c.C5_CCODPRO != datos.C5_CCODPRO)
                              )
                              orderby c.C5_CNUMDOC ascending
                              select new
                              {
                                  var0 = c.C5_CALMA,
                                  var1 = ((from t1 in ctx.AL0003ALMA
                                           where t1.A1_CALMA == c.C5_CALMA
                                           select new { t1.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                                  var2 = c.C5_CTD,
                                  var3 = c.C5_CNUMDOC,
                                  var4 = c.C5_CLOCALI,
                                  var5 = c.C5_DFECDOC,
                                  var6 = c.C5_CTIPMOV,
                                  var7 = c.C5_CCODMOV,
                                  var71 = ((from t2 in ctx.AL0003TABM
                                            where t2.TM_CCODMOV == c.C5_CCODMOV
                                            select new { t2.TM_CDESCRI }).FirstOrDefault().TM_CDESCRI),
                                  var8 = c.C5_CSITUA,
                                  var9 = c.C5_CRFTDOC,
                                  var91 = ((from t3 in ctx.AL0003TABL
                                            where (t3.TG_CCLAVE == c.C5_CRFTDOC && t3.TG_CCOD == "04")
                                            select new { t3.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                  var10 = c.C5_CRFNDOC,
                                  var100 = c.C5_CRFNDO2,
                                  var101 = c.C5_CSOLI,
                                  var1010 = ((from t4 in ctx.AL0003TABL
                                              where (t4.TG_CCLAVE.Trim() == c.C5_CSOLI.Trim() && t4.TG_CCOD == "12")
                                              select new { t4.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                  var11 = c.C5_CCENCOS,
                                  var111 = ((from t5 in ctx.AL0003TABL
                                             where (t5.TG_CCLAVE.Trim() == c.C5_CCENCOS.Trim() && t5.TG_CCOD == "10")
                                             select new { t5.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                  var12 = c.C5_CRFALMA,
                                  var13 = c.C5_CGLOSA1,
                                  var14 = c.C5_CGLOSA2,
                                  var15 = c.C5_CGLOSA3,
                                  var16 = c.C5_CGLOSA4,
                                  var17 = c.C5_CCODPRO,
                                  var18 = c.C5_CNOMPRO,
                                  var19 = c.C5_DFECCRE,
                                  var20 = c.C5_CUSUCRE,
                                  var201 = c.C5_CNUMORD,
                                  var202 = c.C5_CCODMON,
                                  var203 = c.C5_CDESTIN,
                                  var204 = c.C5_CCODFER,
                                  var21 = c.C5_NTIPCAM,
                                  var22 = c.C5_CSUBDIA,
                                  var23 = c.C5_CCOMPRO,

                              }).ToList().Select(c => new SCabecera()
                              {
                                  C5_CALMA = c.var0,
                                  NOMAL = c.var1,
                                  C5_CTD = c.var2,
                                  C5_CNUMDOC = c.var3,
                                  C5_CLOCALI = c.var4 == null || c.var4 == "" ? "-" : c.var4.Trim(),
                                  C5_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.var5),
                                  C5_CTIPMOV = c.var6,
                                  C5_CCODMOV = c.var7 == null || c.var7.Trim() == "" ? "-" : c.var7.Trim(),
                                  NOMMOV = c.var71,
                                  C5_CRFTDOC = c.var9 == null || c.var9.Trim() == "" ? "-" : c.var9.Trim(),
                                  NOMDR = c.var91,
                                  C5_CSITUA = c.var8,
                                  C5_CRFNDOC = c.var10 == null || c.var10.Trim() == "" ? "-" : c.var10.Trim(),
                                  C5_CRFNDO2 = c.var100 == null || c.var100.Trim() == "" ? "-" : c.var100.Trim(),
                                  C5_CSOLI = c.var101 == null || c.var101.Trim() == "" ? "-" : c.var101.Trim(),
                                  NOMSOL = c.var1010 == null || c.var1010.Trim() == "" ? "-" : c.var1010.Trim(),
                                  C5_CCENCOS = c.var11 == null || c.var11.Trim() == "" ? "-" : c.var11.Trim(),
                                  NOMCC = c.var111 == null || c.var111.Trim() == "" ? "-" : c.var111.Trim(),
                                  C5_CRFALMA = c.var12 == null || c.var12.Trim() == "" ? "-" : c.var12.Trim(),
                                  C5_CGLOSA1 = c.var13 == null || c.var13.Trim() == "" ? "-" :
                                                 ((c.var0 == "A002" || c.var0 == "A004" || c.var0 == "0004") && (c.var13.Trim().Length >= 10 && c.var13.Trim().Length <= 11) ?
                                                tabla_embarcaciones.ListarEID(c.var13.Trim()) :
                                                c.var13.Trim()),
                                  C5_CGLOSA2 = c.var14 == null || c.var14.Trim() == "" ? "-" : c.var14.Trim(),
                                  C5_CGLOSA3 = c.var15 == null || c.var15.Trim() == "" ? "-" : c.var15.Trim(),
                                  C5_CGLOSA4 = c.var16 == null || c.var18.Trim() == "" ? "-" : c.var16.Trim(),
                                  C5_CCODPRO = c.var17 == null || c.var17.Trim() == "" ? "-" : c.var17.Trim(),
                                  C5_CNOMPRO = c.var18 == null || c.var18.Trim() == "" ? "-" : c.var18.Trim(),
                                  C5_DFECCRE = String.Format("{0:dd/MM/yyyy}", c.var19),
                                  C5_CUSUCRE = c.var20,
                                  C5_CNUMORD = c.var201 == null || c.var201.Trim() == "" ? "" : c.var201.Trim(),
                                  C5_CCODMON = c.var202 == null || c.var202.Trim() == "" ? "-" : c.var202.Trim(),
                                  C5_CDESTIN = c.var203 == null || c.var203.Trim()==""?"-":c.var203.Trim(),
                                  C5_CCODFER = c.var204 == null || c.var204.Trim()==""?"":c.var204.Trim(),
                                  C5_NTIPCAM = c.var21,
                                  C5_CSUBDIA = c.var22 == null || c.var22.Trim() == "" ? "" : c.var22.Trim(),
                                  C5_CCOMPRO = c.var23 == null || c.var23.Trim() == "" ? "" : c.var23.Trim()
                              }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND;
        }
        public static Boolean valorizaCabecera(AL0003MOVC VDATA)
        {   //VALORIZA PARTES MANUALES - LIQUIDACIONES
            Boolean band = true;
            var fechaA = DateTime.Now;
            var data = new AL0003MOVC { C5_CALMA = VDATA.C5_CALMA, C5_CTD = VDATA.C5_CTD, C5_CNUMDOC = VDATA.C5_CNUMDOC };
            try
            {
                using (var ctx = new RSFACAR())
                {
                    ctx.AL0003MOVC.Attach(data);
                    data.C5_CSITUA = "V";//VALORIZADO
                    data.C5_CRFTDOC = VDATA.C5_CRFTDOC;
                    data.C5_CRFNDOC = VDATA.C5_CRFNDOC;
                    data.C5_CGUIFAC = VDATA.C5_CGUIFAC;//LQ
                    data.C5_CCODPRO = VDATA.C5_CCODPRO;
                    data.C5_CNOMPRO = VDATA.C5_CNOMPRO;
                    data.C5_CCODMON = VDATA.C5_CCODMON;
                    data.C5_NTIPCAM = VDATA.C5_NTIPCAM;
                    data.C5_CTIPO = VDATA.C5_CTIPO;//TIPO DE CAMBIO VENTA/NACIONAL
                    data.C5_CSUBDIA = VDATA.C5_CSUBDIA;
                    data.C5_CCOMPRO = VDATA.C5_CCOMPRO;
                    data.C5_DFECMOD = fechaA;
                    data.C5_CUSUMOD = VDATA.C5_CUSUMOD;
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

        public static List<SCabecera> listaCabeceraI(AL0003MOVC PDATA)
        {
            List<SCabecera> listND1 = new List<SCabecera>();
            try
            {
                using (var ctx = new RSFACAR())
                {

                    listND1 = (from c in ctx.AL0003MOVC
                               join d in ctx.AL0003MOVD
                                    on new { c.C5_CALMA, c.C5_CTD, c.C5_CNUMDOC }
                                equals new { C5_CALMA = d.C6_CALMA, C5_CTD = d.C6_CTD, C5_CNUMDOC = d.C6_CNUMDOC }
                               where
                               (c.C5_CALMA == PDATA.C5_CALMA && c.C5_CTD == PDATA.C5_CTD &&
                                 (PDATA.C5_CNUMDOC != null ? c.C5_CNUMDOC == PDATA.C5_CNUMDOC : c.C5_CNUMDOC != PDATA.C5_CNUMDOC) &&
                                 (PDATA.C5_CCODMOV != null ? c.C5_CCODMOV == PDATA.C5_CCODMOV : c.C5_CCODMOV != PDATA.C5_CCODMOV) &&
                                 (PDATA.C5_CRFTDOC != null ? c.C5_CRFTDOC != PDATA.C5_CRFTDOC : c.C5_CRFTDOC == PDATA.C5_CRFTDOC) &&
                                 (PDATA.C5_CCODPRO != null ? c.C5_CCODPRO == PDATA.C5_CCODPRO : c.C5_CCODPRO != PDATA.C5_CCODPRO) &&
                                 (PDATA.C5_CNUMORD != null ? c.C5_CNUMORD == PDATA.C5_CNUMORD : c.C5_CNUMORD != PDATA.C5_CNUMORD) &&
                                 (c.C5_CSITUA != "V") && //NO ESTEN VALORIZADOS
                                 (c.C5_DFECDOC >= PDATA.C5_DFECDOC && c.C5_DFECDOC <= PDATA.C5_DFECMOD)
                               )
                               orderby c.C5_CNUMDOC ascending
                               select new
                               {
                                   var0 = c.C5_CALMA,
                                   var1 = ((from t1 in ctx.AL0003ALMA
                                            where t1.A1_CALMA == c.C5_CALMA
                                            select new { t1.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                                   var2 = c.C5_CTD,
                                   var3 = c.C5_CNUMDOC,
                                   var4 = c.C5_CLOCALI,
                                   var5 = c.C5_DFECDOC,
                                   var6 = c.C5_CTIPMOV,
                                   var7 = c.C5_CCODMOV,
                                   var71 = ((from t2 in ctx.AL0003TABM
                                             where t2.TM_CCODMOV == c.C5_CCODMOV
                                             select new { t2.TM_CDESCRI }).FirstOrDefault().TM_CDESCRI),
                                   var8 = c.C5_CSITUA,
                                   var9 = c.C5_CRFTDOC,
                                   var10 = c.C5_CRFNDOC,
                                   var11 = c.C5_CCENCOS,
                                   var12 = c.C5_CRFALMA,
                                   var13 = c.C5_CGLOSA1,
                                   var14 = c.C5_CGLOSA2,
                                   var15 = c.C5_CGLOSA3,
                                   var16 = c.C5_CGLOSA4,
                                   var17 = c.C5_CCODPRO,
                                   var18 = c.C5_CNOMPRO,
                                   var19 = c.C5_DFECCRE,
                                   var20 = c.C5_CUSUCRE,
                                   var201 = c.C5_CNUMORD,
                                   var202 = c.C5_CCODMON,
                                   var21 = d.C6_CITEM,
                                   var22 = d.C6_CCODIGO,
                                   var23 = d.C6_CDESCRI,
                                   var24 = d.C6_NCANTID,
                                   var25 = ((from t in ctx.AL0003ARTI
                                             where t.AR_CCODIGO == d.C6_CCODIGO
                                             select new { t.AR_CUNIDAD }).FirstOrDefault().AR_CUNIDAD),
                                   var26 = d.C6_NPREUNI,
                                   var27 = d.C6_NPREUN1,
                                   var28 = d.C6_NMNPRUN,
                                   var29 = d.C6_NUSPRUN

                               }).ToList().Select(c => new SCabecera()
                               {
                                   C5_CALMA = c.var0,
                                   NOMAL = c.var1,
                                   C5_CTD = c.var2,
                                   C5_CNUMDOC = c.var3,
                                   C5_CLOCALI = c.var4 == null || c.var4 == "" ? "-" : c.var4.Trim(),
                                   C5_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.var5),
                                   C5_CTIPMOV = c.var6,
                                   C5_CCODMOV = c.var7 == null || c.var7.Trim() == "" ? "-" : c.var7.Trim(),
                                   NOMMOV = c.var71,
                                   C5_CRFTDOC = c.var9 == null || c.var9.Trim() == "" ? "-" : c.var9.Trim(),
                                   C5_CSITUA = c.var8,
                                   C5_CRFNDOC = c.var10 == null || c.var10.Trim() == "" ? "-" : c.var10.Trim(),
                                   C5_CCENCOS = c.var11 == null || c.var11.Trim() == "" ? "-" : c.var11.Trim(),
                                   C5_CRFALMA = c.var12 == null || c.var12.Trim() == "" ? "-" : c.var12.Trim(),
                                   C5_CGLOSA1 = c.var13 == null || c.var13.Trim() == "" ? "-" :
                                                 ((c.var0 == "A002" || c.var0 == "A004" || c.var0 == "0004") && c.var13.Trim().Length <= 11 ?
                                                tabla_embarcaciones.ListarEID(c.var13)
                                                : c.var13.Trim()),
                                   C5_CGLOSA2 = c.var14 == null || c.var14.Trim() == "" ? "-" : c.var14.Trim(),
                                   C5_CGLOSA3 = c.var15 == null || c.var15.Trim() == "" ? "-" : c.var15.Trim(),
                                   C5_CGLOSA4 = c.var16 == null || c.var18.Trim() == "" ? "-" : c.var16.Trim(),
                                   C5_CCODPRO = c.var17 == null || c.var17.Trim() == "" ? "-" : c.var17.Trim(),
                                   C5_CNOMPRO = c.var18 == null || c.var18.Trim() == "" ? "-" : c.var18.Trim(),
                                   C5_DFECCRE = String.Format("{0:dd/MM/yyyy}", c.var19),
                                   C5_CUSUCRE = c.var20,
                                   C5_CNUMORD = c.var201,
                                   C5_CCODMON = c.var202,
                                   C6_CITEM = c.var21,
                                   C6_CCODIGO = c.var22,
                                   C6_CDESCRI = c.var23,
                                   C6_NCANTID = c.var24,
                                   AR_CUNIDAD = c.var25,
                                   C6_NPREUNI = c.var26,
                                   C6_NPREUN1 = c.var27,
                                   C6_NMNPRUN = c.var28,
                                   C6_NUSPRUN = c.var29

                               }).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND1;
        }
    }
}
