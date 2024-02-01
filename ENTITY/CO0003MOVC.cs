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

    //jimmy 11-03-2016
    //historila de precios
    public class vista_historialPrecios

    {
        public string OC_CCODPRO { get; set; }
        public string OC_CRAZSOC { get; set; }
        public string OC_DFECDOC { get; set; }
        public string OC_CCODMON { get; set; }
        public decimal OC_NPREUN2 { get; set; }
        public string OC_CNUMORD { get; set; }
        public string OC_CFORPA1 { get; set; }

    }
    public partial class CO0003MOVC
    {
        [Key]
        [StringLength(20)]
        public string OC_CNUMORD { get; set; }

        [StringLength(18)]
        public string OC_CCODPRO { get; set; }

        [StringLength(80)]
        public string OC_CRAZSOC { get; set; }

        [StringLength(80)]
        public string OC_CDIRPRO { get; set; }


        [StringLength(30)]
        public string OC_CCOTIZA { get; set; }


        [StringLength(2)]
        public string OC_CCODMON { get; set; }


        [StringLength(30)]
        public string OC_CFORPA1 { get; set; }


        [StringLength(30)]
        public string OC_CFORPA2 { get; set; }


        [StringLength(30)]
        public string OC_CFORPA3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTIPCAM { get; set; }

        public DateTime? OC_DFECENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NPORDES { get; set; }


        [StringLength(80)]
        public string OC_CCARDES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPMN { get; set; }


        [StringLength(50)]
        public string OC_CSOLICT { get; set; }


        [StringLength(80)]
        public string OC_CTIPENV { get; set; }


        [StringLength(80)]
        public string OC_CLUGENT { get; set; }


        [StringLength(80)]
        public string OC_CLUGFAC { get; set; }


        [StringLength(80)]
        public string OC_CDETENT { get; set; }


        [StringLength(1)]
        public string OC_CSITORD { get; set; }

        public DateTime? OC_DFECACT { get; set; }


        [StringLength(8)]
        public string OC_CHORA { get; set; }


        [StringLength(5)]
        public string OC_CUSUARI { get; set; }

        public DateTime? OC_DFECDOC { get; set; }


        [StringLength(1)]
        public string OC_CTIPORD { get; set; }


        [StringLength(30)]
        public string OC_CRESPER1 { get; set; }


        [StringLength(30)]
        public string OC_CRESPER2 { get; set; }


        [StringLength(30)]
        public string OC_CRESPER3 { get; set; }


        [StringLength(30)]
        public string OC_CRESCARG1 { get; set; }


        [StringLength(30)]
        public string OC_CRESCARG2 { get; set; }


        [StringLength(30)]
        public string OC_CRESCARG3 { get; set; }


        [StringLength(4)]
        public string OC_CCOPAIS { get; set; }


        [StringLength(5)]
        public string OC_CUSEA01 { get; set; }


        [StringLength(5)]
        public string OC_CUSEA02 { get; set; }


        [StringLength(5)]
        public string OC_CUSEA03 { get; set; }

        public DateTime? OC_DFECR01 { get; set; }

        public DateTime? OC_DFECR02 { get; set; }

        public DateTime? OC_DFECR03 { get; set; }


        [StringLength(40)]
        public string OC_CREMITE { get; set; }


        [StringLength(40)]
        public string OC_CPERATE { get; set; }


        [StringLength(25)]
        public string OC_CCONTA1 { get; set; }


        [StringLength(25)]
        public string OC_CCONTA2 { get; set; }


        [StringLength(25)]
        public string OC_CCONTA3 { get; set; }


        [StringLength(20)]
        public string OC_CNUMFAC { get; set; }

        public DateTime? OC_DFECEMB { get; set; }


        [StringLength(1)]
        public string OC_CUNIORD { get; set; }


        [StringLength(4)]
        public string OC_CCONVTA { get; set; }


        [StringLength(4)]
        public string OC_CCONEMB { get; set; }


        [StringLength(2)]
        public string OC_CCONDIC { get; set; }


        [StringLength(2)]
        public string OC_CTIPENT { get; set; }


        [StringLength(4)]
        public string OC_CDIAENT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NFLEINT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDOCCHA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NFLETE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NSEGURO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPFAC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPCF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPCIF { get; set; }


        [StringLength(20)]
        public string OC_CNUMREF { get; set; }


        [StringLength(3)]
        public string OC_CTIPDSP { get; set; }


        [StringLength(2)]
        public string OC_CTIPDOC { get; set; }


        [StringLength(4)]
        public string OC_CALMDES { get; set; }


        [StringLength(15)]
        public string OC_CDISTOC { get; set; }


        [StringLength(40)]
        public string OC_CPROVOC { get; set; }


        [StringLength(6)]
        public string OC_CCOSTOC { get; set; }


        [StringLength(20)]
        public string OC_CDOCPAG { get; set; }

        public DateTime? OC_DFECPAG { get; set; }

        public DateTime? OC_DFECVEN { get; set; }


        [StringLength(1)]
        public string OC_CESTPAG { get; set; }


        [StringLength(2)]
        public string OC_CMONPAG { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIMPPAG { get; set; }


        [StringLength(50)]
        public string OC_CGLOPAG { get; set; }


        [StringLength(12)]
        public string OC_CCODSOL { get; set; }


        [StringLength(4)]
        public string OC_CCODAGE { get; set; }


        [StringLength(4)]
        public string OC_CCODTAL { get; set; }


        [StringLength(11)]
        public string OC_CORDTRA { get; set; }


        public static string RetornaProveedores(string codigo)
        {
            // codigo = "M080030076000";
            var contenedor = string.Empty;
            try
            {
                using (var db = new RSFACAR())
                {
                    var alumnos = (

                            (from x in db.CO0003MOVC
                             join y in db.CO0003MOVD on x.OC_CNUMORD equals y.OC_CNUMORD
                             where
                               y.OC_CCODIGO.Trim() == codigo.Trim()
                             select new
                             {
                                 x.OC_CRAZSOC
                             }).Distinct().Take(5).ToList());


                    foreach (var x in alumnos)
                    {
                        contenedor = contenedor + x.OC_CRAZSOC + "/";
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }

            return contenedor;
        }


        public static int nregiaprob(string idorden)
        {
            using (var ctx = new RSFACAR())
            {
                return (from c in ctx.CO0003MOVC where c.OC_CNUMORD.Trim() == idorden.Trim() && (c.OC_CUSEA01.Trim() != "" || c.OC_CUSEA01.Trim() != "" || c.OC_CUSEA01.Trim() != "") select c).Count();
            }
        }

        //nuevo codigo 
        public static List<vista_cocabcera> Listarcabeceraoc(CO0003MOVC CODATA)
        {
            var alumnos = new List<vista_cocabcera>();
            try
            {
                using (var ctx = new RSFACAR())
                {



                    alumnos = (from a in ctx.CO0003MOVC.Where(x =>
                     ((CODATA.OC_CCODPRO == "" || CODATA.OC_CCODPRO == null) ? x.OC_CCODPRO.Trim() != CODATA.OC_CCODPRO.Trim() : x.OC_CCODPRO.Trim() == CODATA.OC_CCODPRO.Trim())//x.OC_CCODPRO == CODATA.OC_CCODPRO
                              && ((CODATA.OC_CNUMORD == "") ? x.OC_CNUMORD != CODATA.OC_CNUMORD : (x.OC_CNUMORD.Trim().EndsWith( CODATA.OC_CNUMORD.Trim())))
                              && (CODATA.OC_CNUMORD != "" ? x.OC_CNUMORD.Trim().EndsWith( CODATA.OC_CNUMORD.Trim()) : 
                              (
                              ((CODATA.OC_CTIPORD == "-1") ? (x.OC_CTIPORD != "-1" || x.OC_CTIPORD.Trim() != "") : (x.OC_CTIPORD.Trim() == CODATA.OC_CTIPORD.Trim()))
                              && ((CODATA.OC_CSITORD == "-1") ? (x.OC_CSITORD != "-1" || x.OC_CSITORD.Trim() != "") : (x.OC_CSITORD.Trim() == CODATA.OC_CSITORD.Trim()))
                              && ((CODATA.OC_CCONDIC == "-1") ? (x.OC_CCONDIC != "-1" || x.OC_CCONDIC.Trim() != "") : (x.OC_CCONDIC == CODATA.OC_CCONDIC))
                              && ((CODATA.OC_CCODSOL == "") ? (x.OC_CCODSOL.Trim() != "" || x.OC_CCODSOL.Trim() == "") : (x.OC_CCODSOL == CODATA.OC_CCODSOL))
                              && ((CODATA.OC_DFECDOC == null && CODATA.OC_DFECENT == null) ? (x.OC_DFECDOC != CODATA.OC_DFECDOC && x.OC_DFECDOC != CODATA.OC_DFECENT) : (x.OC_DFECDOC >= CODATA.OC_DFECDOC && x.OC_DFECDOC <= CODATA.OC_DFECENT))
                              )
                              )
                              )
                               orderby a.OC_DFECDOC descending
                               //alumnos = (from a in ctx.CO0003MOVC.Where(x => x.OC_CCODPRO == CODATA.OC_CCODPRO && x.OC_CTIPORD == CODATA.OC_CTIPORD && x.OC_CSITORD == CODATA.OC_CSITORD && (x.OC_DFECDOC >= CODATA.OC_DFECDOC && x.OC_DFECDOC <= CODATA.OC_DFECENT))
                               select new
                               {
                                   numoc = a.OC_CNUMORD,
                                   codprov = a.OC_CCODPRO,
                                   fechoc = a.OC_DFECDOC,
                                   razonoc = a.OC_CRAZSOC,
                                   monoc = a.OC_CCODMON,
                                   importoc = a.OC_NIMPMN,
                                   importocUS = a.OC_NIMPUS,
                                   sitoc = a.OC_CSITORD,
                                   tipooc = a.OC_CTIPORD,
                                   cotizoc = a.OC_CCOTIZA,
                                   situnum = a.OC_CSITORD,
                                   CABECERAOC = ((from b in ctx.AL0003TABL
                                                  where b.TG_CCOD.Trim() == "31" && b.TG_CCLAVE.Trim() == a.OC_CSITORD
                                                  select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                   OC_CCONDIC = a.OC_CCONDIC
                               }).ToList()
                           .Select(c => new vista_cocabcera()
                           {
                               OC_CNUMORD = c.numoc,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               OC_CRAZSOC = c.razonoc,
                               OC_CCODMON = c.monoc,
                               OC_NIMPMN = c.importoc,
                               OC_CSITORD = c.tipooc,
                               OC_CCOTIZA = c.cotizoc,
                               OC_CTIPORD = c.CABECERAOC,
                               situanum = c.situnum,
                               OC_CODPRO = c.codprov,
                               OC_NIMPUS = c.importocUS,
                               OC_CCONDIC = c.OC_CCONDIC,
                               OC_NAPROB = nregiaprob(c.numoc)
                           }).ToList();

                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        /// <summary>
        /// Obtener O/C
        /// Filtros:
        /// (1)Fecha|Actualizacion|autor:18.03.16|-|sergio
        /// (2)Fecha|Actualizacion|autor:24.05.16|Situacion Ordenes:rec. parcial y total|william
        /// </summary>
        /// <param name="CCAB"></param>
        /// <returns></returns>
        public static CO0003MOVC VerCabeceraID(CO0003MOVC CCAB)
        {
            CO0003MOVC listaA = new CO0003MOVC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listaA = (from c in ctx.CO0003MOVC
                              where
                                c.OC_CNUMORD == CCAB.OC_CNUMORD
                                    && (CCAB.OC_CSITORD != null ? (new string[] { "2", "4", "5" }).Contains(c.OC_CSITORD) : c.OC_CSITORD != CCAB.OC_CSITORD)
                              //&& (CCAB.OC_CTIPORD!=null? (new string[] { "2" }).Contains(c.OC_CSITORD) :c.OC_CTIPORD!=CCAB.OC_CTIPORD)
                              select c).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                listaA = null;
            }

            return listaA;
        }
        /// <summary>
        /// Actualiza Estado de OC
        /// Nota: Se actualiza nombre metodo de AnulaOC a EstadoOC
        /// Actualizacion: 20.04.2016
        /// </summary>
        /// <param name="CONCO"></param>
        public static void EstadoOC(CO0003MOVC CONCO)
        {
            var IDNDOC = new CO0003MOVC { OC_CNUMORD = CONCO.OC_CNUMORD };
            using (RSFACAR ctx = new RSFACAR())
            {

                ctx.CO0003MOVC.Attach(IDNDOC);
                IDNDOC.OC_CSITORD = CONCO.OC_CSITORD;


                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

            }
        }


        public static void AnulaOC(CO0003MOVC CONCO)
        {
            var IDNDOC = new CO0003MOVC { OC_CNUMORD = CONCO.OC_CNUMORD };
            using (RSFACAR ctx = new RSFACAR())
            {
                ctx.CO0003MOVC.Attach(IDNDOC);
                IDNDOC.OC_CSITORD = CONCO.OC_CSITORD;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static string CuentaDetalleMov()
        {
            string idcab = "", idserie = "", nformato = "", idnumer = "";
            int numdev = 0;
            try
            {
                using (var ctx = new RSFACAR())
                {
                    var iddfa = (from c in ctx.CO0003MOVC select c).Max(c => c.OC_CNUMORD);
                    idcab = Convert.ToString(iddfa);
                    idnumer = idcab.Substring(4, 7);
                    idserie = idcab.Substring(0, 4);
                    numdev = Convert.ToInt32(idnumer);
                    numdev = numdev + 1;
                    nformato = numdev.ToString("D7");

                }
            }
            catch (Exception)
            {

                throw;
            }

            return idserie + "" + nformato;
        }

        public static void InsertarCabecera(CO0003MOVC ADDMC)
        {
            try
            {
                using (RSFACAR ctx = new RSFACAR())
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctxM = new RSFACAR())
                {
                    ctxM.Entry(ADDMC).State = EntityState.Modified;
                    ctxM.SaveChanges();
                }
                //foreach (var validationErrors in dbEx.EntityValidationErrors)
                //{
                //    foreach (var validationError in validationErrors.ValidationErrors)
                //    {
                //        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                //    }
                //}
            }
        }


        public static void ModificaMonto(CO0003MOVC COM)
        {
            //var cliente = new CO0003MOVC { OC_CNUMORD = COM.OC_CNUMORD.Trim() };

            using (var ctx = new RSFACAR())
            {
                var cliente = (from c in ctx.CO0003MOVC where c.OC_CNUMORD == COM.OC_CNUMORD.Trim() select c).First();

                ctx.CO0003MOVC.Attach(cliente);
                cliente.OC_NIMPMN = COM.OC_NIMPMN;
                cliente.OC_NIMPUS = COM.OC_NIMPUS;
                cliente.OC_CCONVTA = COM.OC_CCONVTA;
                cliente.OC_NDOCCHA = COM.OC_NDOCCHA;
                ctx.Entry(cliente).State = EntityState.Modified;
                //ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static List<reporte_ordencrys> OCreporte(CO0003MOVC COM)
        {
            var Listarep = new List<reporte_ordencrys>();
            var subrimport = new CO0003MOVI();
            var A_TELE = ""; var A_CONTAC = "";
            using (var ctxconcar = new RSCONCAR())
            {
                try
                {
                    A_TELE = ((from n in ctxconcar.CT0003ANEX
                               where n.ACODANE.Trim() == COM.OC_CCODPRO.Trim() && n.AVANEXO == "P"
                               select new { n.ATELEFO }).FirstOrDefault().ATELEFO);
                }
                catch { A_TELE = ""; }

                try
                {
                    A_CONTAC = ((from r in new RSCONCAR().CP0003MAEC
                                 where r.CP_CCODIGO.Trim() == COM.OC_CCODPRO.Trim()
                                 select new { r.CP_CNOMBRE }).FirstOrDefault().CP_CNOMBRE);
                }
                catch { A_CONTAC = ""; }
            }


            using (var ctx = new RSFACAR())
            {
                subrimport = (from n in ctx.CO0003MOVI where n.OC_CNUMORD == COM.OC_CNUMORD select n).FirstOrDefault();


                Listarep = (from a in ctx.CO0003MOVC
                            join b in ctx.CO0003MOVD on a.OC_CNUMORD equals b.OC_CNUMORD
                            where a.OC_CNUMORD == COM.OC_CNUMORD

                            group b by new
                            {
                                //a.OC_CCODIGO,
                                a.OC_CNUMORD,
                                a.OC_CCODPRO,
                                a.OC_CRAZSOC,
                                a.OC_CDIRPRO,
                                a.OC_CCOTIZA,
                                a.OC_CCODMON,
                                a.OC_CFORPA1,
                                a.OC_DFECACT,
                                a.OC_DFECDOC,
                                a.OC_DFECENT,
                                a.OC_CLUGENT,
                                a.OC_CDETENT,
                                a.OC_CTIPDOC,
                                a.OC_NIMPUS,
                                a.OC_NIMPMN,
                                a.OC_CUSUARI,
                                a.OC_CCOSTOC,
                                a.OC_CTIPORD,
                                a.OC_CSITORD,
                                b.OC_CCODIGO,
                                b.OC_CNUMREQ,
                                b.OC_CCENCOS,
                                b.OC_CSOLICI,
                                b.OC_CUNIDAD,
                                b.OC_NPREUN2,
                                a.OC_CUSEA01,
                                a.OC_CUSEA02,
                                a.OC_CUSEA03,
                                b.OC_COMENTA,
                                b.OC_CPEDINT,
                                b.OC_NISC,
                                a.OC_CRESPER3,
                                a.OC_NDOCCHA
                            } into g
                            select new
                            {
                                data1 = g.Key.OC_CNUMORD,
                                data2 = g.Key.OC_CCODPRO,
                                data3 = g.Key.OC_CRAZSOC,
                                data4 = g.Key.OC_CDIRPRO,
                                data5 = g.Key.OC_CCOTIZA,
                                data6 = g.Key.OC_CCODMON,
                                data7 = g.Key.OC_CFORPA1.ToUpper(),
                                data8 = g.Key.OC_DFECACT,
                                data9 = ((from t in ctx.UT0030
                                          where t.TU_ALIAS.Trim() == g.Key.OC_CUSUARI.Trim()
                                          select new { t.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),//ususario
                                data10 = g.Key.OC_DFECDOC,
                                data11 = g.Key.OC_DFECENT,
                                data12 = ((from t in ctx.AL0003TABL
                                           where t.TG_CCOD.Trim() == "10" && t.TG_CCLAVE.Trim() == g.Key.OC_CCOSTOC.Trim()
                                           select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),//centro costro
                                data13 = g.Key.OC_CLUGENT,
                                data14 = g.Key.OC_CDETENT,
                                data15 = g.Key.OC_CTIPDOC,
                                data16 = ((from t in ctx.AL0003TABL
                                           where t.TG_CCOD.Trim() == "63" && t.TG_CCLAVE.Trim() == g.Key.OC_CTIPORD.Trim()
                                           select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),//forma tiposervicio
                                data17 = ((from r in ctx.AL0003TABL
                                           where r.TG_CCOD.Trim() == "31" && r.TG_CCLAVE.Trim() == g.Key.OC_CSITORD
                                           select new { r.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI), // estado orden
                                data18 = g.Key.OC_NIMPUS,
                                data19 = g.Key.OC_NIMPMN,
                                data20 = g.Key.OC_CCODIGO,
                                data21 = ((from r in ctx.AL0003ARTI
                                           where r.AR_CCODIGO.Trim() == g.Key.OC_CCODIGO.Trim()
                                           select new { r.AR_CDESCRI }).FirstOrDefault().AR_CDESCRI), //descripcion articuloo, 
                                data22 = g.Key.OC_CNUMREQ,
                                data23 = ((from t in ctx.AL0003TABL
                                           where t.TG_CCOD.Trim() == "10" && t.TG_CCLAVE.Trim() == g.Key.OC_CCENCOS.Trim()
                                           select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),//centro costo d
                                data24 = ((from t in ctx.AL0003TABL
                                           where t.TG_CCOD.Trim() == "12" && t.TG_CCLAVE.Trim() == g.Key.OC_CSOLICI
                                           select new { t.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                data25 = g.Key.OC_CUNIDAD,
                                data26 = (decimal?)g.Sum(p => p.OC_NCANORD),
                                data27 = g.Key.OC_NPREUN2,
                                data28 = (decimal?)g.Sum(p => p.OC_NIGV),
                                data29 = (decimal?)g.Sum(p => p.OC_NTOTUS),
                                data30 = (decimal?)g.Sum(p => p.OC_NTOTMN),
                                data31 = ((from r in ctx.ALCIAS
                                           where r.AC_CCIA.Trim() == COM.OC_CCODTAL
                                           select new { r.AC_CNOMCIA }).FirstOrDefault().AC_CNOMCIA), //empresa
                                data32 = ((from r in ctx.ALCIAS
                                           where r.AC_CCIA.Trim() == COM.OC_CCODTAL
                                           select new { r.AC_CRUC }).FirstOrDefault().AC_CRUC), //RUC
                                data33 = ((from r in ctx.ALCIAS
                                           where r.AC_CCIA.Trim() == COM.OC_CCODTAL
                                           select new { r.AC_CDIRCIA }).FirstOrDefault().AC_CDIRCIA), //DIRECCION
                                data34 = A_CONTAC, //contacto 
                                data35 = A_TELE, //telefno
                                data36 = g.Key.OC_CTIPORD,
                                data37 = (decimal?)g.Sum(p => p.OC_NDESCTO),
                                data38 = (decimal?)g.Sum(p => p.OC_NDESCAD),//verificar 
                                data39 = ((from r in ctx.UT0030
                                           where r.TU_ALIAS.Trim() == g.Key.OC_CUSEA01.Trim()
                                           select new { r.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),//a.OC_CUSEA01,
                                data40 = ((from r in ctx.UT0030
                                           where r.TU_ALIAS.Trim() == g.Key.OC_CUSEA02.Trim()
                                           select new { r.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),//a.OC_CUSEA02,
                                data41 = ((from r in ctx.UT0030
                                           where r.TU_ALIAS.Trim() == g.Key.OC_CUSEA03.Trim()
                                           select new { r.TU_NOMUSU }).FirstOrDefault().TU_NOMUSU),//a.OC_CUSEA03
                                data42 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTNOMC }).FirstOrDefault().OC_CSTNOMC),
                                data43 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTPAIS }).FirstOrDefault().OC_CSTPAIS),//OC_CSTPAIS),
                                data44 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTDIRC }).FirstOrDefault().OC_CSTDIRC),//.OC_CSTDIRC),
                                data45 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTTELC }).FirstOrDefault().OC_CSTTELC),//OC_CSTTELC),
                                data46 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTFAXC }).FirstOrDefault().OC_CSTFAXC),//OC_CSTFAXC),
                                data47 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CSTPERA }).FirstOrDefault().OC_CSTPERA),//OC_CSTPERA),
                                data48 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTNOMC }).FirstOrDefault().OC_CCTNOMC),//OC_CCTNOMC),
                                data49 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTPAIS }).FirstOrDefault().OC_CCTPAIS),//OC_CCTPAIS),
                                data50 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTDIRC }).FirstOrDefault().OC_CCTDIRC),//OC_CCTDIRC),
                                data51 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTTELC }).FirstOrDefault().OC_CCTTELC),//OC_CCTTELC),
                                data52 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTFAXC }).FirstOrDefault().OC_CCTFAXC),//OC_CCTFAXC),
                                data53 = ((from r in ctx.CO0003MOVI
                                           where r.OC_CNUMORD == COM.OC_CNUMORD
                                           select new { r.OC_CCTPERA }).FirstOrDefault().OC_CCTPERA),//OC_CCTPERA),
                                data54 = ((from r in ctx.AL0003ARTI
                                           where r.AR_CCODIGO.Trim() == g.Key.OC_CCODIGO.Trim()
                                           select new { r.AR_CLINEA }).FirstOrDefault().AR_CLINEA), //grupo articulo
                                data55 = (g.Key.OC_COMENTA), //OBSERVACION
                                data56 = g.Key.OC_CCENCOS,//centro costo codigo
                                data57 = g.Key.OC_CPEDINT,
                                data58 = g.Key.OC_NISC,
                                data59 = g.Key.OC_CRESPER3,
                                data60 = g.Key.OC_NDOCCHA

                            }).ToList().Select(c => new reporte_ordencrys()
                            {
                                OC_CNUMORD = c.data1,
                                OC_CCODPRO = c.data2,
                                OC_CRAZSOC = c.data3,
                                OC_CDIRPRO = c.data4,
                                OC_CCOTIZA = c.data5,
                                OC_CCODMON = c.data6,
                                OC_CFORPA1 = c.data7,
                                OC_DFECACT = String.Format("{0:dd/MM/yyyy}", c.data8),
                                SC_CUSUARI = c.data9,
                                OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.data10),
                                OC_DFECENT = String.Format("{0:dd/MM/yyyy}", c.data11),
                                SC_CCOSTOC = c.data12,
                                OC_CLUGENT = c.data13,
                                OC_CDETENT = c.data14,
                                SC_CTIPDOC = c.data15,
                                SC_CTIPORD = c.data16,
                                SC_CSITORD = c.data17,
                                OC_NIMPUS = c.data18,
                                OC_NIMPMN = c.data19,
                                OC_CCODIGO = c.data20,
                                OC_CDESREF = c.data21,
                                OC_CNUMREQ = c.data22,
                                SC_CCENCOS = c.data23,
                                SC_CSOLICI = c.data24,
                                OC_CUNIDAD = c.data25,
                                OC_NCANORD = Convert.ToDecimal(c.data26),
                                OC_NPREUN2 = c.data27,
                                OC_NIGV = Convert.ToDecimal(c.data28),
                                OC_NTOTUS = Convert.ToDecimal(c.data29),
                                OC_NTOTMN = Convert.ToDecimal(c.data30),
                                SC_EMPRESA = c.data31,
                                SC_RUC = c.data32,
                                SC_DIREC = c.data33,
                                SC_TELE = c.data34,
                                SC_CONTAC = c.data35,
                                OC_CTIPORD = c.data36,
                                OC_NDESCTO = Convert.ToDecimal(c.data37),
                                OC_NDESCAD = Convert.ToDecimal(c.data38),
                                OC_CUSEA01 = c.data39,
                                OC_CUSEA02 = c.data40,
                                OC_CUSEA03 = c.data41,
                                OC_CSTNOMC = c.data42,
                                OC_CSTPAIS = c.data43,
                                OC_CSTDIRC = c.data44,
                                OC_CSTTELC = c.data45,
                                OC_CSTFAXC = c.data46,
                                OC_CSTPERA = c.data47,
                                OC_CCTNOMC = c.data48,
                                OC_CCTPAIS = c.data49,
                                OC_CCTDIRC = c.data50,
                                OC_CCTTELC = c.data51,
                                OC_CCTFAXC = c.data52,
                                OC_CCTPERA = c.data53,
                                OC_GRUPO = c.data54,
                                OC_COMENTA = c.data55,
                                OC_CCENCOS = c.data56,
                                OC_CPEDINT = c.data57,
                                OC_NISC = c.data58,
                                OC_CRESPER3 = c.data59,
                                OC_INFOT = tabla_trabajo.ListarunTrabajos(c.data59) == null ? "" : tabla_trabajo.ListarunTrabajos(c.data59).CONTRATISTA
                                ,
                                CA_DESCERTIF = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_DESCERTIF,
                                CA_DESDEST = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_DESDEST,
                                CA_DESPROD = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_DESPROD,
                                CA_DESSOLI = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_DESSOLI,
                                CA_PRODMUE = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_PRODMUE,
                                CA_AADIC = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : tabla_ccalidad.ListarCcalidad(c.data1).CA_AADIC,
                                CA_FECHAD = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : String.Format("{0:dd/MM/yyyy}", tabla_ccalidad.ListarCcalidad(c.data1.Trim()).CA_FECHAD),
                                CA_FECHAA = tabla_ccalidad.ListarCcalidad(c.data1) == null ? "" : String.Format("{0:dd/MM/yyyy}", tabla_ccalidad.ListarCcalidad(c.data1).CA_FECHAA),
                                SR_NORD = COM.OC_CDIAENT,
                                OC_NDOCCHA = c.data60
                            }).ToList();

            }
            return Listarep;
        }

        //public static void AprobarOC(CO0003MOVC COM)
        //{
        //    var orden = new CO0003MOVC { OC_CNUMORD = COM.OC_CNUMORD };

        //    using (var ctx = new RSFACAR())
        //    {
        //        ctx.CO0003MOVC.Attach(orden);
        //        // orden.OC_CSITORD = COM.OC_CSITORD;
        //        orden.OC_CUSEA01 = COM.OC_CUSEA01;
        //        orden.OC_CUSEA02 = COM.OC_CUSEA02;
        //        orden.OC_CUSEA03 = COM.OC_CUSEA03;
        //        if (COM.OC_CUSEA01 != "     " && COM.OC_CUSEA02 == "     " && COM.OC_CUSEA03 == "     ")
        //        {
        //            orden.OC_DFECR01 = DateTime.Now.Date;
        //        }
        //        if (COM.OC_CUSEA01 != "     " && COM.OC_CUSEA02 != "     " && COM.OC_CUSEA03 == "     ")
        //        {
        //            orden.OC_DFECR02 = DateTime.Now.Date;
        //        }

        //        if (COM.OC_CUSEA01 != "     " && COM.OC_CUSEA02 != "     " && COM.OC_CUSEA03 != "     " && COM.OC_CSITORD == "2")
        //        {
        //            orden.OC_CSITORD = COM.OC_CSITORD;
        //            orden.OC_DFECR03 = DateTime.Now.Date;

        //        }

        //        if (COM.OC_CUSEA01 != "     " && COM.OC_CUSEA02 != "     " && COM.OC_CUSEA03 != "     " && COM.OC_CSITORD == "1")
        //        {
        //            orden.OC_CSITORD = COM.OC_CSITORD;
        //            String valor = "01/01/2000";
        //            orden.OC_DFECR03 = Convert.ToDateTime(valor);
        //            orden.OC_DFECR02 = Convert.ToDateTime(valor);
        //            orden.OC_DFECR01 = Convert.ToDateTime(valor);
        //            orden.OC_CUSEA01 = "     ";
        //            orden.OC_CUSEA02 = "     ";
        //            orden.OC_CUSEA03 = "     ";

        //        }

        //        ctx.Configuration.ValidateOnSaveEnabled = false;
        //        ctx.SaveChanges();
        //    }


        //}


        public static void AprobarOC(CO0003MOVC COM)
        {
            var orden = new CO0003MOVC { OC_CNUMORD = COM.OC_CNUMORD };

            using (var ctx = new RSFACAR())
            {
                ctx.CO0003MOVC.Attach(orden);
                orden.OC_CUSEA01 = COM.OC_CUSEA01;
                orden.OC_CUSEA02 = COM.OC_CUSEA02;
                orden.OC_CUSEA03 = COM.OC_CUSEA03;
                orden.OC_CSITORD = COM.OC_CSITORD;
                orden.OC_CSITORD = COM.OC_CSITORD;

                if (COM.OC_CUSEA01 != "     ")
                {
                    orden.OC_DFECR01 = DateTime.Now.Date;
                }
                if (COM.OC_CUSEA02 != "     ")
                {
                    orden.OC_DFECR02 = DateTime.Now.Date;
                }

                if (COM.OC_CUSEA03 != "     ")
                {
                    orden.OC_DFECR03 = DateTime.Now.Date;

                }

                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

                // CODIGO EDGAR

                orden.OC_CRESCARG1 = ctx.CO0003MOVC.Where(X => X.OC_CNUMORD == COM.OC_CNUMORD).Select(X => X.OC_CRESCARG1).FirstOrDefault();
                if (orden.OC_CRESCARG1.Trim() != "")
                {
                    using (var cty = new ANEXO_RSFACAR())
                    {
                        var anticipo = new tabla_anticipo
                        { // OC_CNUMORD = COM.OC_CNUMORD.Trim(),
                            ANT_CODIGO = orden.OC_CRESCARG1.Trim()
                        };
                        cty.tabla_anticipo.Attach(anticipo);
                        anticipo.USER1 = COM.OC_CUSEA01;
                        anticipo.USER2 = COM.OC_CUSEA02;
                        anticipo.USER4 = COM.OC_CUSEA03;
                        anticipo.USER3 = cty.tabla_anticipo.Where(X => X.ANT_CODIGO == orden.OC_CRESCARG1).Select(X => X.USER3).FirstOrDefault();
                        if (anticipo.USER3.Trim() != "")
                        {
                            anticipo.APROBADO = "A";
                        }
                        cty.Configuration.ValidateOnSaveEnabled = false;
                        cty.SaveChanges();
                    }

                }
                // FIN CODIGO EDGAR            
            }
        }

        public static void desAprobarOC(CO0003MOVC COM)
        {
            var orden = new CO0003MOVC { OC_CNUMORD = COM.OC_CNUMORD };

            using (var ctx = new RSFACAR())
            {
                ctx.CO0003MOVC.Attach(orden);
                var INDICADOR = COM.OC_CTIPORD;
                orden.OC_CUSEA01 = COM.OC_CUSEA01;
                orden.OC_CUSEA02 = COM.OC_CUSEA02;
                orden.OC_CUSEA03 = COM.OC_CUSEA03;
                if ((COM.OC_CUSEA01.Trim() != "" && COM.OC_CUSEA01 != null) && (COM.OC_CUSEA02.Trim() != "" && COM.OC_CUSEA02 != null) && (COM.OC_CUSEA03.Trim() != "" && COM.OC_CUSEA03 != null))
                {
                    orden.OC_CSITORD = "1";
                    orden.OC_CUSEA01 = "";
                    orden.OC_CUSEA02 = "";
                    orden.OC_CUSEA03 = "";
                    String valor = "01/01/2000";
                    orden.OC_DFECR01 = Convert.ToDateTime(valor);
                    orden.OC_DFECR02 = Convert.ToDateTime(valor);
                    orden.OC_DFECR03 = Convert.ToDateTime(valor);
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();
                }

            }
        }

        public static void ActAnticipo(CO0003MOVC COM) // edgar
        {
            var orden = new CO0003MOVC { OC_CNUMORD = COM.OC_CNUMORD };

            using (var ctx = new RSFACAR())
            {
                ctx.CO0003MOVC.Attach(orden);
                orden.OC_CRESCARG1 = COM.OC_CRESCARG1;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static List<vista_cocabcerapopup> Listarcabeceraocpopup(CO0003MOVC CODATA)
        {
            var alumnos = new List<vista_cocabcerapopup>();
            var narea = tabla_subtipoOC.Listarsubtipoxusua(CODATA.OC_CREMITE, 2);
            int contt = 0;
            string[] filtroxareausua = new string[narea.Count()];
            foreach (var c in narea)
            {
                filtroxareausua[contt] = c.IDTipo.ToString();
                contt++;
            }
            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos =
                        (from a in ctx.CO0003MOVC.Where
                              (x =>
                               (filtroxareausua.Contains(x.OC_CCONDIC)) &&
                               (CODATA.OC_CNUMORD != null ?
                                   x.OC_CNUMORD.EndsWith( CODATA.OC_CNUMORD ):
                                   (
                                        (CODATA.OC_CCODPRO != "" ? x.OC_CCODPRO == CODATA.OC_CCODPRO : x.OC_CCODPRO != "") &&
                                        (CODATA.OC_CTIPORD != "-1" ? x.OC_CTIPORD == CODATA.OC_CTIPORD : x.OC_CTIPORD != CODATA.OC_CTIPORD) &&
                                        (CODATA.OC_CSITORD != "-1" ? x.OC_CSITORD == CODATA.OC_CSITORD : x.OC_CSITORD != CODATA.OC_CSITORD) &&
                                        ((CODATA.OC_CCODSOL == "") ? (x.OC_CCODSOL == "" || x.OC_CCODSOL.Trim() != "") : (x.OC_CCODSOL == CODATA.OC_CCODSOL))
                                   ) &&
                                   ((x.OC_DFECDOC >= CODATA.OC_DFECDOC && x.OC_DFECDOC <= CODATA.OC_DFECENT))
                               )
                               ).OrderByDescending(x => new { x.OC_CNUMORD })
                         select new

                         {

                             numoc = a.OC_CNUMORD,
                             fechoc = a.OC_DFECDOC,
                             razonoc = a.OC_CRAZSOC,
                             monoc = a.OC_CCODMON,
                             importoc = a.OC_NIMPMN,
                             IMPORTEDOLARES = a.OC_NIMPUS,
                             sitoc = a.OC_CSITORD,
                             tipooc = a.OC_CTIPORD,
                             cotizoc = a.OC_CCOTIZA,
                             situnum = a.OC_CSITORD,
                             ruc = a.OC_CCODPRO,
                             dir = a.OC_CDIRPRO,
                             pais = a.OC_CCOPAIS,
                             fpago = a.OC_CFORPA1,
                             tipoenvio = a.OC_CTIPENV,
                             entregalugar = a.OC_CLUGENT,
                             facturalugar = a.OC_CLUGFAC,
                             distrito = a.OC_CDISTOC,
                             provincia = a.OC_CPROVOC,
                             tipocambio = a.OC_NTIPCAM,
                             codsol = a.OC_CCODSOL,
                             solicitante = a.OC_CSOLICT,
                             remite = a.OC_CREMITE,
                             persona = a.OC_CPERATE,
                             user1 = a.OC_CUSEA01,
                             user2 = a.OC_CUSEA02,
                             user3 = a.OC_CUSEA03,
                             Observaciones = a.OC_CDETENT,
                             CABECERAOC = ((from b in ctx.AL0003TABL
                                            where b.TG_CCOD.Trim() == "31" && b.TG_CCLAVE.Trim() == a.OC_CSITORD
                                            select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                             MONEDA = ((from b in ctx.AL0003TABL
                                        where b.TG_CCOD.Trim() == "03" && b.TG_CCLAVE.Trim() == a.OC_CCODMON
                                        select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                             CENTROCOSTO = ((from b in ctx.AL0003TABL
                                             where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == a.OC_CCOSTOC
                                             select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                             ALMACEN = ((from b in ctx.AL0003ALMA
                                         where b.A1_CALMA.Trim() == a.OC_CALMDES
                                         select new { b.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                             REFERENCIA = ((from b in ctx.AL0003TABL
                                            where b.TG_CCOD.Trim() == "04" && b.TG_CCLAVE.Trim() == a.OC_CTIPDOC
                                            select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                             OC_CRESPER2 = a.OC_CRESPER2,
                             OC_CCONDIC = a.OC_CCONDIC
                         }).ToList()
                           .Select(c => new vista_cocabcerapopup()
                           {
                               OC_CNUMORD = c.numoc,
                               MONEDA = c.MONEDA,
                               ALMACEN = c.ALMACEN,
                               REFERENCIA = c.REFERENCIA,
                               CENTROCOSTO = c.CENTROCOSTO,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               OC_CRAZSOC = c.razonoc,
                               OC_CCODMON = c.monoc,
                               OC_NIMPMN = c.importoc,
                               OC_CSITORD = c.tipooc,
                               OC_DSITORD = c.sitoc,//NUEVO 11.07.16
                               OC_CCOTIZA = c.cotizoc,
                               OC_CODPRO = c.ruc,
                               OC_CDIRPRO = c.dir,
                               OC_CTIPORD = c.CABECERAOC,
                               OC_DTIPORD = c.tipooc,
                               OC_CCOPAIS = c.pais,
                               OC_CFORPA1 = c.fpago,
                               OC_CTIPENV = c.tipoenvio,
                               OC_CLUGENT = c.entregalugar,
                               OC_CLUGFAC = c.facturalugar,
                               OC_CDISTOC = c.distrito,
                               OC_CPROVOC = c.provincia,
                               OC_NTIPCAM = c.tipocambio,
                               OC_CODSOL = c.codsol,
                               OC_CSOLICIT = c.solicitante,
                               OC_CREMITE = c.remite,
                               OC_CPERATE = c.persona,
                               OC_CUSEA01 = c.user1,
                               OC_CUSEA02 = c.user2,
                               OC_CUSEA03 = c.user3,
                               situanum = c.situnum,
                               OC_CDETENT = c.Observaciones,
                               OC_NIMPUS = c.IMPORTEDOLARES,
                               OC_CRESPER2 = c.OC_CRESPER2,
                               OC_CCONDIC = c.OC_CCONDIC
                               /*OC_CUENTAB1 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAMNT,
                               OC_CUENTAB2 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAUST,
                               OC_CUENTAB3 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAMN7,
                               OC_CUENTAB4 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAUS7,
                               OC_CUENTAB5 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAMNK,
                               OC_CUENTAB6 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTAUSK
                               OC_CUENTAB7 = CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault() == null ? "" : CP0003MAES.obtiene_banco_cuenta("P", c.ruc).FirstOrDefault().AC_CCTADET*/
                           }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<vista_cocabcerapopup> ListarcabeceraocpopupCondosusuarios(CO0003MOVC CODATA)
        {
            var alumnos = new List<vista_cocabcerapopup>();
            var narea = tabla_subtipoOC.Listarsubtipoxusua(CODATA.OC_CREMITE, 2);
            int contt = 0;
            string[] filtroxareausua = new string[narea.Count()];
            foreach (var c in narea)
            {
                filtroxareausua[contt] = c.IDTipo.ToString();
                contt++;
            }
            try
            {
                using (var ctx = new RSFACAR())
                {

                    alumnos =
                        (from a in ctx.CO0003MOVC.Where
                              (x =>
                                (filtroxareausua.Contains(x.OC_CCONDIC)) &&
                              (
                              (CODATA.OC_CCODPRO != "" ? x.OC_CCODPRO == CODATA.OC_CCODPRO : x.OC_CCODPRO != "")
                             &&
                             (CODATA.OC_CTIPORD != "-1" ? x.OC_CTIPORD == CODATA.OC_CTIPORD : x.OC_CTIPORD != CODATA.OC_CTIPORD)
                             &&
                              (CODATA.OC_CSITORD != "-1" ? x.OC_CSITORD == CODATA.OC_CSITORD : x.OC_CSITORD != CODATA.OC_CSITORD)

                              && ((CODATA.OC_CCODSOL == "") ? (x.OC_CCODSOL == "" || x.OC_CCODSOL.Trim() != "") : (x.OC_CCODSOL == CODATA.OC_CCODSOL))
                             )
                             &&
                              ((x.OC_DFECDOC >= CODATA.OC_DFECDOC && x.OC_DFECDOC <= CODATA.OC_DFECENT) && (x.OC_CUSEA01 != "     " && x.OC_CUSEA02 != "     " && x.OC_CUSEA03 == "     "))
                              ).OrderByDescending(x => new { x.OC_CNUMORD })
                         select new
                         {

                             numoc = a.OC_CNUMORD,
                             fechoc = a.OC_DFECDOC,
                             razonoc = a.OC_CRAZSOC,
                             monoc = a.OC_CCODMON,
                             importoc = a.OC_NIMPMN,
                             IMPORTEDOLARES = a.OC_NIMPUS,
                             sitoc = a.OC_CSITORD,
                             tipooc = a.OC_CTIPORD,
                             cotizoc = a.OC_CCOTIZA,
                             situnum = a.OC_CSITORD,
                             ruc = a.OC_CCODPRO,
                             dir = a.OC_CDIRPRO,
                             pais = a.OC_CCOPAIS,
                             fpago = a.OC_CFORPA1,
                             tipoenvio = a.OC_CTIPENV,
                             entregalugar = a.OC_CLUGENT,
                             facturalugar = a.OC_CLUGFAC,
                             distrito = a.OC_CDISTOC,
                             provincia = a.OC_CPROVOC,
                             tipocambio = a.OC_NTIPCAM,
                             codsol = a.OC_CCODSOL,
                             solicitante = a.OC_CSOLICT,
                             remite = a.OC_CREMITE,
                             persona = a.OC_CPERATE,
                             user1 = a.OC_CUSEA01,
                             user2 = a.OC_CUSEA02,
                             user3 = a.OC_CUSEA03,
                             Observaciones = a.OC_CDETENT,
                             CABECERAOC = ((from b in ctx.AL0003TABL
                                            where b.TG_CCOD.Trim() == "31" && b.TG_CCLAVE.Trim() == a.OC_CSITORD
                                            select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                             MONEDA = ((from b in ctx.AL0003TABL
                                        where b.TG_CCOD.Trim() == "03" && b.TG_CCLAVE.Trim() == a.OC_CCODMON
                                        select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                             CENTROCOSTO = ((from b in ctx.AL0003TABL
                                             where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == a.OC_CCOSTOC
                                             select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                             ALMACEN = ((from b in ctx.AL0003ALMA
                                         where b.A1_CALMA.Trim() == a.OC_CALMDES
                                         select new { b.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                             REFERENCIA = ((from b in ctx.AL0003TABL
                                            where b.TG_CCOD.Trim() == "04" && b.TG_CCLAVE.Trim() == a.OC_CTIPDOC
                                            select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                         }).ToList()
                           .Select(c => new vista_cocabcerapopup()
                           {
                               OC_CNUMORD = c.numoc,
                               MONEDA = c.MONEDA,
                               ALMACEN = c.ALMACEN,
                               REFERENCIA = c.REFERENCIA,
                               CENTROCOSTO = c.CENTROCOSTO,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               OC_CRAZSOC = c.razonoc,
                               OC_CCODMON = c.monoc,
                               OC_NIMPMN = c.importoc,
                               OC_CSITORD = c.tipooc,
                               OC_CCOTIZA = c.cotizoc,
                               OC_CODPRO = c.ruc,
                               OC_CDIRPRO = c.dir,
                               OC_CTIPORD = c.CABECERAOC,
                               OC_CCOPAIS = c.pais,
                               OC_CFORPA1 = c.fpago,
                               OC_CTIPENV = c.tipoenvio,
                               OC_CLUGENT = c.entregalugar,
                               OC_CLUGFAC = c.facturalugar,
                               OC_CDISTOC = c.distrito,
                               OC_CPROVOC = c.provincia,
                               OC_NTIPCAM = c.tipocambio,
                               OC_CODSOL = c.codsol,
                               OC_CSOLICIT = c.solicitante,
                               OC_CREMITE = c.remite,
                               OC_CPERATE = c.persona,
                               OC_CUSEA01 = c.user1,
                               OC_CUSEA02 = c.user2,
                               OC_CUSEA03 = c.user3,
                               situanum = c.situnum,
                               OC_CDETENT = c.Observaciones,
                               OC_NIMPUS = c.IMPORTEDOLARES,
                           }).ToList();




                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        public static List<vista_historialPrecios> ListarHistorialPreciosPorProducto2(AL0003REQD REQ)
        {
            var alumnos = new List<vista_historialPrecios>();
            try
            {
                using (var db = new RSFACAR())
                {
                    alumnos = (

                        from C in db.CO0003MOVC
                        join D in db.CO0003MOVD on C.OC_CNUMORD equals D.OC_CNUMORD
                        where
                          D.OC_CCODIGO.Trim() == REQ.RD_CCODIGO.Trim() && C.OC_CSITORD != "7"
                        //    !(new string[] { "1", "7" }).Contains(C.OC_CSITORD)
                        orderby
                          C.OC_DFECDOC descending
                        select new
                        {
                            a = C.OC_CCODPRO,
                            b = C.OC_CRAZSOC,
                            c = C.OC_DFECDOC,
                            d = C.OC_CCODMON,
                            e = D.OC_NPREUN2,
                            f = C.OC_CNUMORD,
                            g = C.OC_CFORPA1
                        }).ToList()
                           .Select(c => new vista_historialPrecios()
                           {
                               OC_CCODPRO = c.a,
                               OC_CRAZSOC = c.b,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.c),
                               OC_CCODMON = c.d,
                               OC_NPREUN2 = c.e,
                               OC_CNUMORD = c.f,
                               OC_CFORPA1 = c.g
                           }).ToList();

                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        //jimmy 10-03-16
        public static List<vista_historialPrecios> ListarHistorialPreciosPorProducto(AL0003REQD REQ)
        {
            var alumnos = new List<vista_historialPrecios>();
            try
            {
                using (var db = new RSFACAR())
                {
                    alumnos = (

                        from C in db.CO0003MOVC
                        join D in db.CO0003MOVD on C.OC_CNUMORD equals D.OC_CNUMORD
                        where
                          D.OC_CCODIGO.Trim() == REQ.RD_CCODIGO.Trim() &&
                          !(new string[] { "1", "7" }).Contains(C.OC_CSITORD)
                        orderby
                          C.OC_DFECDOC descending
                        select new
                        {
                            a = C.OC_CCODPRO,
                            b = C.OC_CRAZSOC,
                            c = C.OC_DFECDOC,
                            d = C.OC_CCODMON,
                            e = D.OC_NPREUN2,
                            f = C.OC_CNUMORD,
                            g = C.OC_CFORPA1
                        }).ToList()
                           .Select(c => new vista_historialPrecios()
                           {
                               OC_CCODPRO = c.a,
                               OC_CRAZSOC = c.b,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.c),
                               OC_CCODMON = c.d,
                               OC_NPREUN2 = c.e,
                               OC_CNUMORD = c.f,
                               OC_CFORPA1 = c.g
                           }).ToList();

                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static CO0003MOVC UltimolPrecioPorProducto(AL0003REQD REQ)
        {
            // var alumnos = new vista_historialPrecios();

            try
            {
                using (var db = new RSFACAR())
                {
                    var alumnos = db.CO0003MOVC.Join(db.CO0003MOVD, c => c.OC_CNUMORD, cm => cm.OC_CNUMORD, (c, cm) => new { CO0003MOVC = c, CO0003MOVD = cm }).Where(cm => cm.CO0003MOVD.OC_CCODIGO == REQ.RD_CCODIGO.Trim()).OrderByDescending(c => c.CO0003MOVC.OC_DFECDOC).Take(1).FirstOrDefault();
                    var lista = new CO0003MOVC();
                    var precio = Convert.ToDecimal(0);
                    var moneda = string.Empty;
                    var tcambio = Convert.ToDecimal(0);

                    if (alumnos != null)
                    {
                        precio = alumnos.CO0003MOVD.OC_NPREUN2;
                        moneda = alumnos.CO0003MOVC.OC_CCODMON;
                        tcambio = alumnos.CO0003MOVC.OC_NTIPCAM;

                        lista = new CO0003MOVC()
                        {
                            OC_CCODMON = moneda,
                            OC_NTIPCAM = tcambio,
                            OC_NIMPMN = precio
                        };
                    }
                    else
                    {
                        lista = new CO0003MOVC()
                        {
                            OC_CCODMON = moneda,
                            OC_NTIPCAM = tcambio,
                            OC_NIMPMN = precio
                        };
                    }

                    return lista;
                }



            }
            catch (Exception)
            {

                throw;
            }


        }

        //nuevo william

        public static List<vista_cocabcera> ListarOCAP(CO0003MOVC CODATA)
        {
            var alumnos = new List<vista_cocabcera>();
            try
            {
                using (var ctx = new RSFACAR())
                {   //ACTUALIZO 16/03/2016:FUNCION CONTAINS
                    //1:EMITIDA 4:PARCIAL 5:RECEPCION TOTAL	  
                    //alumnos = (from a in ctx.CO0003MOVC.Where(x => (((new string[] { "1", "2", "4", "5", "6", "7" }).Contains(x.OC_CSITORD)) &&
                    alumnos = (from a in ctx.CO0003MOVC.Where(x => (((new string[] { "2", "4" }).Contains(x.OC_CSITORD)) &&
                               (CODATA.OC_CTIPORD != null ? x.OC_CTIPORD == CODATA.OC_CTIPORD : x.OC_CTIPORD != CODATA.OC_CTIPORD) &&
                               (x.OC_CUSEA01 != "" && x.OC_CUSEA02 != "" && x.OC_CUSEA03 != "") &&
                               (CODATA.OC_CNUMORD == "" ? x.OC_CNUMORD == "" : SqlFunctions.PatIndex(CODATA.OC_CNUMORD, x.OC_CNUMORD) > 0)))
                                   //(CODATA.OC_CNUMORD == "" ? x.OC_CNUMORD == "" : x.OC_CNUMORD.Contains(CODATA.OC_CNUMORD))))
                                   //alumnos = (from a in ctx.CO0003MOVC.Where(x => (x.OC_CSITORD=="2" && x.OC_CSITORD=="4") && (CODATA.OC_CNUMORD == "" ? x.OC_CNUMORD == "" : x.OC_CNUMORD.Contains(CODATA.OC_CNUMORD)))
                               select new
                               {
                                   numoc = a.OC_CNUMORD,
                                   codprov = a.OC_CCODPRO,
                                   fechoc = a.OC_DFECDOC,
                                   razonoc = a.OC_CRAZSOC,
                                   monoc = a.OC_CCODMON,
                                   importoc = a.OC_NIMPMN,
                                   importocUS = a.OC_NIMPUS,
                                   sitoc = a.OC_CSITORD,
                                   tipooc = a.OC_CTIPORD,
                                   cotizoc = a.OC_CCOTIZA,
                                   situnum = a.OC_CSITORD,
                                   CABECERAOC = ((from b in ctx.AL0003TABL
                                                  where b.TG_CCOD.Trim() == "31" && b.TG_CCLAVE.Trim() == a.OC_CSITORD
                                                  select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI)
                               }).ToList()
                           .Select(c => new vista_cocabcera()
                           {
                               OC_CNUMORD = c.numoc,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               OC_CRAZSOC = c.razonoc,
                               OC_CCODMON = c.monoc,
                               OC_NIMPMN = c.importoc,
                               OC_CSITORD = c.sitoc,
                               OC_CCOTIZA = c.cotizoc,
                               OC_CTIPORD = c.CABECERAOC,
                               situanum = c.situnum,
                               OC_CODPRO = c.codprov,
                               OC_NIMPUS = c.importocUS
                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        //nuevo edgar
        public static List<CO0003MOVC> Listarordenautocomplete(string texto)
        {
            var codID = new List<CO0003MOVC>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    codID = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD.Contains(texto) && x.OC_CSITORD == "2").ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }

            return codID;
        }
        //public static List<CO0003MOVC> Listarordenautocompletetc(string texto)
        //{
        //    var codID = new List<CO0003MOVC>();
        //    try
        //    {
        //        using (var ctx = new RSFACAR())
        //        {
        //            codID = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD.Contains(texto) && x.OC_CSITORD == "2" && x.OC_CTIPORD.Trim()=="S").ToList();

        //        }
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }

        //    return codID;
        //}

        public static List<CO0003MOVC> Listarordenautocompletetc(CO0003MOVC datos)
        {
            var codID = new List<CO0003MOVC>();

            using (var ctx = new RSFACAR())
            {
                codID = (from REQUE in ctx.CO0003MOVC ///join orden in ctx.CO0003MOVC on REQUE.RC_CNUMORD equals orden.OC_CNUMORD
                         where (REQUE.OC_CSITORD == "2") && (REQUE.OC_CNUMORD.Contains(datos.OC_CNUMORD)) && (REQUE.OC_CCODMON.Trim() == datos.OC_CCODMON)
                         select new
                         {
                             a = REQUE.OC_CNUMORD,
                             b = REQUE.OC_CCODMON,
                             j = REQUE.OC_NIMPMN,
                             k = REQUE.OC_NIMPUS,

                         }).ToList().
                   Select(c => new CO0003MOVC()
                   {
                       OC_CNUMORD = c.a,
                       OC_NIMPMN = (c.b.Trim() == "MN" ? c.j : c.k),
                   }).ToList();
            }
            return codID;
        }


        public static List<vista_cocabcerapopup> ListarcabeceraocpopupFechas(CO0003MOVC CODATA)
        {
            var alumnos = new List<vista_cocabcerapopup>();
            try
            {

                using (var ctx = new RSFACAR())
                {

                    alumnos = (from a in ctx.CO0003MOVC.Where
                              (x => ((x.OC_DFECDOC >= CODATA.OC_DFECDOC && x.OC_DFECDOC <= CODATA.OC_DFECENT))
                              ).OrderBy(x => x.OC_DFECDOC)
                               select new
                               {

                                   numoc = a.OC_CNUMORD,
                                   fechoc = a.OC_DFECDOC,
                                   razonoc = a.OC_CRAZSOC,
                                   monoc = a.OC_CCODMON,
                                   importoc = a.OC_NIMPMN,
                                   IMPORTEDOLARES = a.OC_NIMPUS,
                                   sitoc = a.OC_CSITORD,
                                   tipooc = a.OC_CTIPORD,
                                   cotizoc = a.OC_CCOTIZA,
                                   situnum = a.OC_CSITORD,
                                   ruc = a.OC_CCODPRO,
                                   dir = a.OC_CDIRPRO,
                                   pais = a.OC_CCOPAIS,
                                   fpago = a.OC_CFORPA1,
                                   tipoenvio = a.OC_CTIPENV,
                                   entregalugar = a.OC_CLUGENT,
                                   facturalugar = a.OC_CLUGFAC,
                                   distrito = a.OC_CDISTOC,
                                   provincia = a.OC_CPROVOC,
                                   tipocambio = a.OC_NTIPCAM,
                                   codsol = a.OC_CCODSOL,
                                   solicitante = a.OC_CSOLICT,
                                   remite = a.OC_CREMITE,
                                   persona = a.OC_CPERATE,
                                   user1 = a.OC_CUSEA01,
                                   user2 = a.OC_CUSEA02,
                                   user3 = a.OC_CUSEA03,
                                   Observaciones = a.OC_CDETENT,
                                   CABECERAOC = ((from b in ctx.AL0003TABL
                                                  where b.TG_CCOD.Trim() == "31" && b.TG_CCLAVE.Trim() == a.OC_CSITORD
                                                  select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                   MONEDA = ((from b in ctx.AL0003TABL
                                              where b.TG_CCOD.Trim() == "03" && b.TG_CCLAVE.Trim() == a.OC_CCODMON
                                              select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                   CENTROCOSTO = ((from b in ctx.AL0003TABL
                                                   where b.TG_CCOD.Trim() == "10" && b.TG_CCLAVE.Trim() == a.OC_CCOSTOC
                                                   select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),

                                   ALMACEN = ((from b in ctx.AL0003ALMA
                                               where b.A1_CALMA.Trim() == a.OC_CALMDES
                                               select new { b.A1_CDESCRI }).FirstOrDefault().A1_CDESCRI),
                                   REFERENCIA = ((from b in ctx.AL0003TABL
                                                  where b.TG_CCOD.Trim() == "04" && b.TG_CCLAVE.Trim() == a.OC_CTIPDOC
                                                  select new { b.TG_CDESCRI }).FirstOrDefault().TG_CDESCRI),
                                   FEC1 = a.OC_DFECR01,
                                   FEC2 = a.OC_DFECR02,
                                   FEC3 = a.OC_DFECR03,


                               }).ToList()
                           .Select(c => new vista_cocabcerapopup()
                           {
                               OC_CNUMORD = c.numoc,
                               MONEDA = c.MONEDA,
                               ALMACEN = c.ALMACEN,
                               REFERENCIA = c.REFERENCIA,
                               CENTROCOSTO = c.CENTROCOSTO,
                               OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               OC_CRAZSOC = c.razonoc,
                               OC_CCODMON = c.monoc,
                               OC_NIMPMN = c.importoc,
                               OC_CSITORD = c.tipooc,
                               OC_CCOTIZA = c.cotizoc,
                               OC_CODPRO = c.ruc,
                               OC_CDIRPRO = c.dir,
                               OC_CTIPORD = c.CABECERAOC,
                               OC_CCOPAIS = c.pais,
                               OC_CFORPA1 = c.fpago,
                               OC_CTIPENV = c.tipoenvio,
                               OC_CLUGENT = c.entregalugar,
                               OC_CLUGFAC = c.facturalugar,
                               OC_CDISTOC = c.distrito,
                               OC_CPROVOC = c.provincia,
                               OC_NTIPCAM = c.tipocambio,
                               OC_CODSOL = c.codsol,
                               OC_CSOLICIT = c.solicitante,
                               OC_CREMITE = c.remite,
                               OC_CPERATE = c.persona,
                               OC_CUSEA01 = c.user1,
                               OC_CUSEA02 = c.user2,
                               OC_CUSEA03 = c.user3,
                               situanum = c.situnum,
                               OC_CDETENT = c.Observaciones,
                               OC_NIMPUS = c.IMPORTEDOLARES,
                               OC_DFECR01 = Convert.ToString(c.FEC1),
                               OC_DFECR02 = Convert.ToString(c.FEC2),
                               OC_DFECR03 = Convert.ToString(c.FEC3),

                           }).ToList();




                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static CO0003MOVC ListarDatosOrdenID(string oc)

        {
            var userx = new CO0003MOVC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //    userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc).First();
                    // userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc && x.OC_CSITORD.Trim() == "2").First();
                    userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc && (x.OC_CSITORD.Trim() != "7" && x.OC_CSITORD.Trim() != "1")).First();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return userx;
        }

        public static CO0003MOVC ListarDatosOrdenID1(string oc)

        {
            var userx = new CO0003MOVC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //    userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc).First();
                    // userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc && x.OC_CSITORD.Trim() == "2").First();
                    userx = ctx.CO0003MOVC.Where(x => x.OC_CNUMORD == oc).First();
                }
            }
            catch (Exception)
            {
                // throw;
            }
            return userx;
        }


        public static int ValidaporDocProv(string nref, string nprov)
        {
            int cantr = 0;
            using (var ctx = new RSFACAR())
            {
                cantr = (from c in ctx.CO0003MOVC where c.OC_CCODPRO.Trim() == nprov.Trim() && c.OC_CCOTIZA.Trim() == nref.Trim() select c).Count();
            }
            return cantr;
        }

        public static int Naprobacionesorden(string nodern)
        {
            using (var ctx = new RSFACAR())
            {
                var cr = (from c in ctx.CO0003MOVC where c.OC_CNUMORD == nodern && (c.OC_CUSEA01.Trim() != "" || c.OC_CUSEA02.Trim() != "" || c.OC_CUSEA03.Trim() != "") select c).Count();
                return cr;
            }
        }

        /// <summary>
        /// Agrupacion por cc x capex
        /// </summary>
        /// <param name="DATA"></param>
        /// <param name="IC"></param>
        /// <returns></returns>
        public static List<SCabecera> listaCAPEXA(CO0003MOVC DATA, string[] IC)
        {
            List<SCabecera> listND2 = new List<SCabecera>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND2 = (from c in ctx.CO0003MOVC
                               join d in ctx.CO0003MOVD
                                   on new { c.OC_CNUMORD }
                               equals new { OC_CNUMORD = d.OC_CNUMORD }
                               join a in ctx.AL0003ARTI
                                   on new { d.OC_CCODIGO }
                               equals new { OC_CCODIGO = a.AR_CCODIGO.Trim() }
                               where
                                 (c.OC_CNUMORD == DATA.OC_CNUMORD && d.OC_CESTADO!="8" &&
                                 (new string[] { "2", "4", "5" }).Contains(c.OC_CSITORD) &&
                                 (c.OC_NFLEINT > 0 ? ((IC).Contains(d.OC_CCODIGO)) : d.OC_CCODIGO != null)
                               )
                               orderby d.OC_CCENCOS ascending
                               group new { c, d } by new
                               {
                                   //a.AR_CCUENTA,
                                   d.OC_CCENCOS,
                                   c.OC_CCODPRO

                               } into g
                               select new
                               {
                                   //var0 = g.Key.AR_CCUENTA,
                                   var1 = g.Key.OC_CCENCOS,
                                   var2 = g.Key.OC_CCODPRO,
                                   var3 = (decimal)g.Sum(p => p.d.OC_NCANORD * p.d.OC_NPREUN2)
                               }).ToList().Select(c => new SCabecera()
                               {
                                   TC_CCOMPRA = tabla_dist_costeo.costeocta_x_cc(c.var1).CT_CTACO,
                                   C5_CGLOSA1 = CT0003PLEM.RegistrounCta(tabla_dist_costeo.costeocta_x_cc(c.var1).CT_CTACO),
                                   C5_CCENCOS = c.var1,
                                   C5_CCODPRO = c.var2 == null || c.var2.Trim() == "" ? "-" : c.var2.Trim(),
                                   C6_NCANTID = c.var3
                               }).Distinct().ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return listND2;
        }

        /// <summary>
        /// Obtener Cuenta Servicio x O/S x Cuenta x Centro Costos x Proveedor
        /// </summary>
        /// <param name="PDATA"></param>
        /// <param name="ND"></param>
        /// <returns></returns>
        public static List<SCabecera> listaCSE(CO0003MOVC PDATA, string[] IC)
        {
            List<SCabecera> listND1 = new List<SCabecera>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    listND1 = (from c in ctx.CO0003MOVC
                               join d in ctx.CO0003MOVD
                                   on new { c.OC_CNUMORD }
                               equals new { OC_CNUMORD = d.OC_CNUMORD }
                               join a in ctx.AL0003ARTI
                                   on new { d.OC_CCODIGO }
                               equals new { OC_CCODIGO = a.AR_CCODIGO.Trim() }
                               where
                                 (c.OC_CNUMORD == PDATA.OC_CNUMORD &&
                                 (new string[] { "2", "4", "5" }).Contains(c.OC_CSITORD) &&
                                 (c.OC_NFLEINT > 0 ? ((IC).Contains(d.OC_CCODIGO)) : d.OC_CCODIGO != null)
                               )
                               orderby a.AR_CCUENTA ascending
                               group new { a, c, d } by new
                               {
                                   a.AR_CCUENTA,
                                   c.OC_CCODPRO,
                                   d.OC_CCENCOS
                               } into g
                               select new
                               {
                                   var0 = g.Key.AR_CCUENTA,
                                   var1 = g.Key.OC_CCENCOS,
                                   var2 = g.Key.OC_CCODPRO,
                                   var3 = (decimal)g.Sum(p => p.d.OC_NCANORD * p.d.OC_NPREUN2)
                               }).ToList().Select(c => new SCabecera()
                               {
                                   TC_CCOMPRA = c.var0.Trim(),
                                   C5_CGLOSA1 = CT0003PLEM.RegistrounCta(c.var0.Trim()),
                                   C5_CCENCOS = c.var1,
                                   C5_CCODPRO = c.var2 == null || c.var2.Trim() == "" ? "-" : c.var2.Trim(),
                                   C6_NCANTID = c.var3
                               }).Distinct().ToList();

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