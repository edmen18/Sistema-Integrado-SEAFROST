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

    public partial class CP0003EJEC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string GC_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string GC_CNUMOPE { get; set; }

        public DateTime? GC_DFECPRO { get; set; }

        [Required]
        [StringLength(8)]
        public string GC_CCODCON { get; set; }

        [Required]
        [StringLength(1)]
        public string GC_CTIPPAG { get; set; }

        [Required]
        [StringLength(18)]
        public string GC_CCODBAN { get; set; }

        [Required]
        [StringLength(2)]
        public string GC_CCODMON { get; set; }

        [Required]
        [StringLength(2)]
        public string GC_CCODDEP { get; set; }

        [Required]
        [StringLength(6)]
        public string GC_CNUMLOT { get; set; }

        [Required]
        [StringLength(8)]
        public string GC_CTASDET { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GC_NTIPCAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal GC_NMONPRO { get; set; }

        [Required]
        [StringLength(1)]
        public string GC_CESTADO { get; set; }

        [Required]
        [StringLength(5)]
        public string GC_CUSUCRE { get; set; }

        public DateTime? GC_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string GC_CUSUMOD { get; set; }

        public DateTime? GC_DFECMOD { get; set; }

        [Required]
        [StringLength(5)]
        public string GC_CUSUAPR { get; set; }

        public DateTime? GC_DFECAPR { get; set; }

        [Required]
        [StringLength(25)]
        public string GC_CCHQCOR { get; set; }

        [Required]
        [StringLength(20)]
        public string GC_CVOUCOR { get; set; }

        public DateTime? GC_DFECEJE { get; set; }

        [Required]
        [StringLength(5)]
        public string GC_CUSUEJE { get; set; }

        [Required]
        [StringLength(20)]
        public string GC_CNOPEDE { get; set; }

        public DateTime? GC_DFEDEPD { get; set; }

        public static Boolean insertar(CP0003EJEC DATA)
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
        public static string GenerarNumLote()
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    codigo = ctx.CP0003EJEC.Where(x => x.GC_DFECPRO.Value.Year == DateTime.Today.Year && x.GC_CNUMLOT.Trim()!="").Count() + 1;
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        public static List<CP0003EJEC> LISTAREJECUTADAS(CP0003EJEC CODATA)
        {
            DateTime fecha = Convert.ToDateTime("01/01/0001");
            var alumnos = new List<CP0003EJEC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJEC.Where(x => (
                                 ((CODATA.GC_CCODAGE.Trim() != "-1") ? x.GC_CCODAGE.Trim() == CODATA.GC_CCODAGE.Trim() : x.GC_CCODAGE.Trim() != CODATA.GC_CCODAGE.Trim())
                              && ((CODATA.GC_CCODBAN.Trim() != "-1") ? x.GC_CCODBAN.Trim() == CODATA.GC_CCODBAN.Trim() : x.GC_CCODBAN.Trim() != CODATA.GC_CCODBAN.Trim())
                              && ((CODATA.GC_CCODDEP.Trim() != "-1") ? x.GC_CCODDEP.Trim() == CODATA.GC_CCODDEP.Trim() : x.GC_CCODDEP.Trim() != CODATA.GC_CCODDEP.Trim())
                              && ((CODATA.GC_CTIPPAG.Trim() != "-1") ? x.GC_CTIPPAG.Trim() == CODATA.GC_CTIPPAG.Trim() : x.GC_CTIPPAG.Trim() != CODATA.GC_CTIPPAG.Trim())
                              && ((CODATA.GC_CCODCON.Trim() != "-1") ? x.GC_CCODCON.Trim() == CODATA.GC_CCODCON.Trim() : x.GC_CCODCON.Trim() != CODATA.GC_CCODCON.Trim())
                              && (x.GC_CESTADO.Trim() == CODATA.GC_CESTADO.Trim())
                              && (CODATA.GC_DFECPRO != null ? x.GC_DFECPRO == CODATA.GC_DFECPRO : x.GC_DFECPRO.Value.Year == CODATA.GC_NMONPRO && x.GC_DFECPRO.Value.Month == CODATA.GC_NTIPCAM)
                              )
                               )
                               select new
                               {
                                   AGENCIA = a.GC_CCODAGE,
                                   numope = a.GC_CNUMOPE,
                                   fecah = a.GC_DFECPRO,
                                   moneda = a.GC_CCODMON,
                                   IMPORTE = a.GC_NMONPRO,
                                   ESTADO = a.GC_CESTADO,


                                   tipopago = ((from b in ctx.CP0003TABL
                                                where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE == "60"
                                                select new { b.TG_DESCRI }).FirstOrDefault().TG_DESCRI),


                                   CONCEPTO = ((from b in ctx.CP0003COPR
                                                where b.CG_CCODCON.Trim() == a.GC_CCODCON
                                                select new { b.CG_CCONCEP }).FirstOrDefault().CG_CCONCEP),

                                   CODBANCO = ((from b in ctx.CP0003CUBA
                                                where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                                select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),


                               }).ToList()
                           .Select(c => new CP0003EJEC()
                           {
                               GC_CCODAGE = c.AGENCIA,
                               GC_CNUMOPE = c.numope,
                               GC_CUSUCRE = Convert.ToDateTime(c.fecah).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               GC_CCODCON = c.tipopago,
                               GC_CTIPPAG = c.CONCEPTO,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO = c.IMPORTE,
                               GC_CESTADO = (c.ESTADO == "E" ? "EJECUTADA" : ""),

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<CP0003EJEC> numlote(string CODATA)
        {
            var alumnos = new List<CP0003EJEC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJEC.Where (x => ( x.GC_CNUMOPE.Trim()==CODATA.Trim() ) )

                               select new
                               { numlote=a.GC_CNUMLOT,
                               total=a.GC_NMONPRO,
                               }).ToList()
                           .Select(c => new CP0003EJEC()
                           {
                               GC_CNUMLOT = c.numlote,
                               GC_NMONPRO = c.total,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }


        public static List<vista_detalle_programacion> LISTARUNO(string CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_detalle_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJEC
                               where a.GC_CNUMOPE.Trim() == CODATA.Trim()
                               select new
                               {
                                   AGENCIA = a.GC_CCODAGE,
                                   AGENCIA2 = ((from b in ctx.CT0003AGEN
                                                where b.AG_CCODAGE.Trim() == a.GC_CCODAGE
                                                select new { b.AG_CNOMAGE }).FirstOrDefault().AG_CNOMAGE),
                                   numope = a.GC_CNUMOPE,
                                   CONCEPTO = ((from b in ctx.CP0003COPR
                                                where b.CG_CCODCON.Trim() == a.GC_CCODCON
                                                select new { concepto1 = b.CG_CCODCON + "-" + b.CG_CCONCEP }).FirstOrDefault().concepto1),
                                   tipopago = ((from b in ctx.CP0003TABL
                                                where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE == "60"
                                                select new { tipopago1 = b.TG_CODIGO + "-" + b.TG_DESCRI }).FirstOrDefault().tipopago1),
                                   moneda = a.GC_CCODMON,
                                   TIPOCAMBIO = a.GC_NTIPCAM,
                                   IMPORTE = a.GC_NMONPRO,
                                   fecah = a.GC_DFECPRO,
                                   TIPODETRACCION = ((from x in ctx.CT0003TAGE.Where(x => x.TCOD == "28" &&
                                                      (x.TCLAVE.Trim() == a.GC_CTASDET.Trim()) &&
                                                         x.TCLAVE != "00000")
                                                      select new
                                                      { x.TDESCRI }).FirstOrDefault().TDESCRI),

                                   TASADETRACCION = a.GC_CTASDET,
                                   coddepartamento = a.GC_CCODDEP,
                                   DEPARTAMENTO = ((from c in ctx.CP0003TABL.Where(x => x.TG_INDICE.Trim() == "90" && x.TG_CODIGO.Trim() == a.GC_CCODDEP.Trim())
                                                    select new
                                                    { depart = c.TG_CODIGO + "-" + c.TG_DESCRI }).FirstOrDefault().depart),

                                   CODBANCO = a.GC_CCODBAN,
                                   BANCO = ((from b in ctx.CP0003CUBA
                                             where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                             select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),
                                   ESTADO = a.GC_CESTADO,

                                   USUCRE = a.GC_CUSUCRE,
                                   USUAPRO= a.GC_CUSUAPR,
                                   USUMOD=a.GC_CUSUMOD,
                                   FECRE=a.GC_DFECCRE,
                                   FEAPRO=a.GC_DFECAPR,
                                   FEMOD=a.GC_DFECMOD,
                                   operacion=a.GC_CNOPEDE,
                                   foperacion=a.GC_DFEDEPD,
                                    LOTE=a.GC_CNUMLOT,

                               }).ToList()
                           .Select(c => new vista_detalle_programacion()
                           {
                               AGENCIA = c.AGENCIA,
                               AGENCIA2 = c.AGENCIA2,
                               numope = c.numope,
                               CONCEPTO = c.CONCEPTO,
                               tipopago = c.tipopago,
                               moneda = c.moneda,
                               TIPOCAMBIO = c.TIPOCAMBIO,
                               IMPORTE = c.IMPORTE,
                               fecah = c.fecah,
                               TIPODETRACCION = (c.TASADETRACCION.Trim()=="99999"? "TODOS": c.TIPODETRACCION),
                               TASADETRACCION = c.TASADETRACCION,
                               coddepartamento = c.coddepartamento,
                               DEPARTAMENTO = c.DEPARTAMENTO,
                               CODBANCO = c.CODBANCO,
                               BANCO = c.BANCO,
                               ESTADO = (c.ESTADO == "E" ? "EJECUTADA" : ""),
                               USUCRE=c.USUCRE,
                               USUAPRO=c.USUAPRO,
                               USUMOD=c.USUMOD,
                               FECRE=c.FECRE,
                               FEAPRO=c.FEAPRO,
                               FEMOD=c.FEMOD,
                               operacion=c.operacion,
                               foperacion=c.foperacion,
                               BANCOCUENTA=c.LOTE,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }
        // constancia de sunat
        public static List<vista_detalle_programacion> LISTARUNOCONST(string CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_detalle_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003EJEC
                               where a.GC_CNUMOPE.Trim() == CODATA.Trim() && (a.GC_CNOPEDE.Trim() =="-" || a.GC_CNOPEDE.Trim() == "")
                               select new
                               {
                                   AGENCIA = a.GC_CCODAGE,
                                   AGENCIA2 = ((from b in ctx.CT0003AGEN
                                                where b.AG_CCODAGE.Trim() == a.GC_CCODAGE
                                                select new { b.AG_CNOMAGE }).FirstOrDefault().AG_CNOMAGE),
                                   numope = a.GC_CNUMOPE,
                                   CONCEPTO = ((from b in ctx.CP0003COPR
                                                where b.CG_CCODCON.Trim() == a.GC_CCODCON
                                                select new { concepto1 = b.CG_CCODCON + "-" + b.CG_CCONCEP }).FirstOrDefault().concepto1),
                                   tipopago = ((from b in ctx.CP0003TABL
                                                where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE == "60"
                                                select new { tipopago1 = b.TG_CODIGO + "-" + b.TG_DESCRI }).FirstOrDefault().tipopago1),
                                   moneda = a.GC_CCODMON,
                                   TIPOCAMBIO = a.GC_NTIPCAM,
                                   IMPORTE = a.GC_NMONPRO,
                                   fecah = a.GC_DFECPRO,
                                   TIPODETRACCION = ((from x in ctx.CT0003TAGE.Where(x => x.TCOD == "28" &&
                                                      (x.TCLAVE.Trim() == a.GC_CTASDET.Trim()) &&
                                                         x.TCLAVE != "00000")
                                                      select new
                                                      { x.TDESCRI }).FirstOrDefault().TDESCRI),

                                   TASADETRACCION = a.GC_CTASDET,
                                   coddepartamento = a.GC_CCODDEP,
                                   DEPARTAMENTO = ((from c in ctx.CP0003TABL.Where(x => x.TG_INDICE.Trim() == "90" && x.TG_CODIGO.Trim() == a.GC_CCODDEP.Trim())
                                                    select new
                                                    { depart = c.TG_CODIGO + "-" + c.TG_DESCRI }).FirstOrDefault().depart),

                                   CODBANCO = a.GC_CCODBAN,
                                   BANCO = ((from b in ctx.CP0003CUBA
                                             where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                             select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),
                                   ESTADO = a.GC_CESTADO,


                               }).ToList()
                           .Select(c => new vista_detalle_programacion()
                           {
                               AGENCIA = c.AGENCIA,
                               AGENCIA2 = c.AGENCIA2,
                               numope = c.numope,
                               CONCEPTO = c.CONCEPTO,
                               tipopago = c.tipopago,
                               moneda = c.moneda,
                               TIPOCAMBIO = c.TIPOCAMBIO,
                               IMPORTE = c.IMPORTE,
                               fecah = c.fecah,
                               TIPODETRACCION = c.TIPODETRACCION,
                               TASADETRACCION = c.TASADETRACCION,
                               coddepartamento = c.coddepartamento,
                               DEPARTAMENTO = c.DEPARTAMENTO,
                               CODBANCO = c.CODBANCO,
                               BANCO = c.BANCO,
                               ESTADO = (c.ESTADO == "E" ? "EJECUTADA" : ""),

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        // PARA ACTUALIZAR LA CONSTANCIA EMITIDA POR LA SUNAT
        public static void ActualizaConstancia(CP0003EJEC COM)
        {
            var orden = new CP0003EJEC { GC_CCODAGE = COM.GC_CCODAGE, GC_CNUMOPE = COM.GC_CNUMOPE };

            using (var ctx = new RSCONCAR())
            {
                ctx.CP0003EJEC.Attach(orden);
                orden.GC_CNOPEDE = COM.GC_CNOPEDE;
                orden.GC_DFEDEPD = COM.GC_DFEDEPD;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

            }
        }

        public static string autocomplete()
        {
           var valor = "";
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    valor = ctx.CP0003EJEC.OrderByDescending(x=>x.GC_CNUMOPE).Select(x => x.GC_CNUMOPE).FirstOrDefault();
                   
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }

        //public static string autocomplete()
        //{
        //    var alumnos = "";
        //    try
        //    {
        //        using (var ctx = new RSCONCAR())
        //        {
        //            alumnos = (from a in ctx.CP0003EJEC
        //                       orderby a.GC_CNUMOPE

        //                       select new
        //                       {
        //                           numope = a.GC_CNUMOPE,
        //                       }).FirstOrDefault()
        //                   .Select(c => new CP0003EJEC()
        //                   {
        //                       GC_CNUMOPE = c.numope,                             

        //                   }).Take(1).FirstOrDefault();
        //        }
        //    }
        //    catch (Exception)
        //    { throw; }

        //    return alumnos;
        //}
    }
}
