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
    public partial class CP0003PRGC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string GC_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(10)]
        public string GC_CNUMOPE { get; set; }

        public DateTime GC_DFECPRO { get; set; }

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

       // public string fecha { get; set; }
        public static List<CP0003PRGC> LISTARTTODOS() //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC where a.GC_CESTADO.Trim()=="P"
                              select new
                               {
                                  AGENCIA= a.GC_CCODAGE,
                                  numope=a.GC_CNUMOPE,
                                  fecah=a.GC_DFECPRO,
                                  moneda=a.GC_CCODMON,
                                  IMPORTE=a.GC_NMONPRO,
                                  ESTADO=a.GC_CESTADO,
                                

                                   tipopago = ((from b in ctx.CP0003TABL
                                                      where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE=="60"
                                                select new { b.TG_DESCRI }).FirstOrDefault().TG_DESCRI),


                                   CONCEPTO = ((from b in ctx.CP0003COPR
                                                where b.CG_CCODCON.Trim() == a.GC_CCODCON
                                                      select new { b.CG_CCONCEP }).FirstOrDefault().CG_CCONCEP),

                                   CODBANCO = ((from b in ctx.CP0003CUBA
                                                      where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                                select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),
                                  

                               }).ToList()
                           .Select(c => new CP0003PRGC()
                           {
                               GC_CCODAGE= c.AGENCIA,
                               GC_CNUMOPE= c.numope,
                              GC_CUSUCRE = Convert.ToDateTime(c.fecah).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               GC_CCODCON = c.tipopago,
                               GC_CTIPPAG = c.CONCEPTO,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO= c.IMPORTE,
                               GC_CESTADO= (c.ESTADO=="P"? "PENDIENTE":"APROBADA"),
                                                               
                           }).ToList();
                }
             }
            catch (Exception)
            {    throw;     }

            return alumnos;
        }

        public static List<CP0003PRGC> LISTARTTODOSP(CP0003PRGC codata) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC
                               where a.GC_CESTADO.Trim() == codata.GC_CESTADO.Trim()
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
                           .Select(c => new CP0003PRGC()
                           {
                               GC_CCODAGE = c.AGENCIA,
                               GC_CNUMOPE = c.numope,
                               GC_CUSUCRE = Convert.ToDateTime(c.fecah).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               GC_CCODCON = c.CONCEPTO,
                               GC_CTIPPAG = c.tipopago,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO = c.IMPORTE,
                               GC_CESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),

                           }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return alumnos;
        }

        public static List<CP0003PRGC> LISTARTTODOSA() //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC
                               where a.GC_CESTADO.Trim() == "A"
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
                           .Select(c => new CP0003PRGC()
                           {
                               GC_CCODAGE = c.AGENCIA,
                               GC_CNUMOPE = c.numope,
                               GC_DFECPRO = c.fecah,
                               GC_CCODCON = c.tipopago,
                               GC_CTIPPAG = c.CONCEPTO,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO = c.IMPORTE,
                               GC_CESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),

                           }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return alumnos;
        }
        public static List<CP0003PRGC> LISTARTTODOSFILTRO(CP0003PRGC CODATA ) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC.Where (x=>(
                                  ((CODATA.GC_CCODAGE.Trim() != "-1")? x.GC_CCODAGE.Trim() == CODATA.GC_CCODAGE.Trim() : x.GC_CCODAGE.Trim() != CODATA.GC_CCODAGE.Trim())
                               && ((CODATA.GC_CCODBAN.Trim() != "-1")? x.GC_CCODBAN.Trim() == CODATA.GC_CCODBAN.Trim() : x.GC_CCODBAN.Trim() != CODATA.GC_CCODBAN.Trim())
                               && ((CODATA.GC_CCODDEP.Trim() != "-1")? x.GC_CCODDEP.Trim() == CODATA.GC_CCODDEP.Trim() : x.GC_CCODDEP.Trim() != CODATA.GC_CCODDEP.Trim())
                               && ((CODATA.GC_CTIPPAG.Trim() != "-1")? x.GC_CTIPPAG.Trim() == CODATA.GC_CTIPPAG.Trim() : x.GC_CTIPPAG.Trim() != CODATA.GC_CTIPPAG.Trim())
                               && ((CODATA.GC_CCODCON.Trim() != "-1")? x.GC_CCODCON.Trim() == CODATA.GC_CCODCON.Trim() : x.GC_CCODCON.Trim() != CODATA.GC_CCODCON.Trim()))
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
                           .Select(c => new CP0003PRGC()
                           {
                               GC_CCODAGE = c.AGENCIA,
                               GC_CNUMOPE = c.numope,
                               GC_DFECPRO = c.fecah,
                               GC_CCODCON = c.tipopago,
                               GC_CTIPPAG = c.CONCEPTO,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO = c.IMPORTE,
                               GC_CESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<CP0003PRGC> LISTARTTODOSFILTROP(CP0003PRGC CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha =Convert.ToDateTime("01/01/0001");
            var alumnos = new List<CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC.Where(x => (
                                 ((CODATA.GC_CCODAGE.Trim() != "-1") ? x.GC_CCODAGE.Trim() == CODATA.GC_CCODAGE.Trim() : x.GC_CCODAGE.Trim() != CODATA.GC_CCODAGE.Trim())
                              && ((CODATA.GC_CCODBAN.Trim() != "-1") ? x.GC_CCODBAN.Trim() == CODATA.GC_CCODBAN.Trim() : x.GC_CCODBAN.Trim() != CODATA.GC_CCODBAN.Trim())
                              && ((CODATA.GC_CCODDEP.Trim() != "-1") ? x.GC_CCODDEP.Trim() == CODATA.GC_CCODDEP.Trim() : x.GC_CCODDEP.Trim() != CODATA.GC_CCODDEP.Trim())
                              && ((CODATA.GC_CTIPPAG.Trim() != "-1") ? x.GC_CTIPPAG.Trim() == CODATA.GC_CTIPPAG.Trim() : x.GC_CTIPPAG.Trim() != CODATA.GC_CTIPPAG.Trim())
                              && ((CODATA.GC_CCODCON.Trim() != "-1") ? x.GC_CCODCON.Trim() == CODATA.GC_CCODCON.Trim() : x.GC_CCODCON.Trim() != CODATA.GC_CCODCON.Trim())
                              && (x.GC_CESTADO.Trim()==CODATA.GC_CESTADO.Trim())
                              && (CODATA.GC_DFECPRO!=fecha? x.GC_DFECPRO==CODATA.GC_DFECPRO: x.GC_DFECPRO.Year==CODATA.GC_NMONPRO && x.GC_DFECPRO.Month == CODATA.GC_NTIPCAM)
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
                           .Select(c => new CP0003PRGC()
                           {
                               GC_CCODAGE = c.AGENCIA,
                               GC_CNUMOPE = c.numope,
                               GC_CUSUCRE = Convert.ToDateTime(c.fecah).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               GC_CCODCON = c.tipopago,
                               GC_CTIPPAG = c.CONCEPTO,
                               GC_CCODBAN = c.CODBANCO,
                               GC_CCODMON = c.moneda,
                               GC_NMONPRO = c.IMPORTE,
                               GC_CESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }


        public static Boolean insertar(CP0003PRGC DATA)
        {
            Boolean band = true;
           // var fechaA = DateTime.Now;
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
        public static List<vista_detalle_programacion> LISTARUNO(string CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_detalle_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC where a.GC_CNUMOPE.Trim() == CODATA.Trim()
                               select new
                               {
                                   AGENCIA = a.GC_CCODAGE,
                                   AGENCIA2 = ((from b in ctx.CT0003AGEN
                                                where b.AG_CCODAGE.Trim() == a.GC_CCODAGE
                                                select new { b.AG_CNOMAGE }).FirstOrDefault().AG_CNOMAGE),
                                   numope = a.GC_CNUMOPE,
                                   CONCEPTO = ((from b in ctx.CP0003COPR
                                                where b.CG_CCODCON.Trim() == a.GC_CCODCON
                                                select new { concepto1= b.CG_CCODCON +"-"+ b.CG_CCONCEP }).FirstOrDefault().concepto1),
                                   tipopago = ((from b in ctx.CP0003TABL
                                                where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE == "60"
                                                select new {tipopago1=b.TG_CODIGO+"-"+ b.TG_DESCRI }).FirstOrDefault().tipopago1),
                                   moneda = a.GC_CCODMON,
                                   TIPOCAMBIO = a.GC_NTIPCAM,
                                   IMPORTE = a.GC_NMONPRO,
                                   fecah = a.GC_DFECPRO,
                                   TIPODETRACCION =((from x in ctx.CT0003TAGE.Where(x => x.TCOD == "28" &&
                                                     (x.TCLAVE.Trim() == a.GC_CTASDET.Trim() ) &&
                                                        x.TCLAVE != "00000")
                                                     select new
                                                     {x.TDESCRI }).FirstOrDefault().TDESCRI),

                                   TASADETRACCION = a.GC_CTASDET,
                                   coddepartamento=a.GC_CCODDEP,
                                   DEPARTAMENTO = ((from c in ctx.CP0003TABL.Where(x => x.TG_INDICE.Trim() == "90" && x.TG_CODIGO.Trim()==a.GC_CCODDEP.Trim())
                                                   select new
                                                   { depart = c.TG_CODIGO + "-" + c.TG_DESCRI  }).FirstOrDefault().depart),

                                   CODBANCO = a.GC_CCODBAN,
                                   BANCO = ((from b in ctx.CP0003CUBA
                                             where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                             select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),
                                   BANCOCTA = ((from b in ctx.CP0003CUBA
                                             where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                             select new { b.CT_CCUENTA }).FirstOrDefault().CT_CCUENTA),
                                   ESTADO = a.GC_CESTADO,
                                   USUCRE= a.GC_CUSUCRE,
                                   USUAPRO= a.GC_CUSUAPR,
                                   USUMOD= a.GC_CUSUMOD,

                                   FUSUCRE = a.GC_DFECCRE,
                                   FUSUAPRO = a.GC_DFECAPR,
                                   FUSUMOD = a.GC_DFECMOD,


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
                               IMPORTE =c.IMPORTE,
                               fecah = c.fecah,
                               TIPODETRACCION = c.TIPODETRACCION,
                               TASADETRACCION = c.TASADETRACCION,
                               coddepartamento = c.coddepartamento,
                               DEPARTAMENTO = c.DEPARTAMENTO,
                               CODBANCO = c.CODBANCO,
                               BANCO = c.BANCO,
                               ESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),
                               BANCOCUENTA=c.BANCOCTA,
                               USUCRE=c.USUCRE,
                               USUAPRO=c.USUAPRO,
                               USUMOD=c.USUMOD,
                               FECRE= c.FUSUCRE,
                               FEAPRO= c.FUSUAPRO,
                               FEMOD= c.FUSUMOD,
                                                              
                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        //actualiza estado aprobacion
        public static Boolean actualizaEstado(CP0003PRGC alumno)
        {
            Boolean band = true;
            var orden = new CP0003PRGC { GC_CNUMOPE = alumno.GC_CNUMOPE, GC_CCODAGE=alumno.GC_CCODAGE  };
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.CP0003PRGC.Attach(orden);

                    orden.GC_CESTADO = "A";
                    orden.GC_CUSUAPR = alumno.GC_CUSUAPR;
                    orden.GC_DFECAPR = DateTime.Today;
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
        // eliminar programacion
        public static void EliminaItems(CP0003PRGC CCAB)
        {

            using (var ctx = new RSCONCAR())
            {
                ctx.Entry(new CP0003PRGC { GC_CCODAGE = CCAB.GC_CCODAGE, GC_CNUMOPE=CCAB.GC_CNUMOPE }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }

        public static List<VISTA_CP0003PRGC> EXTRAERPARAINSERTAR(string dato) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<VISTA_CP0003PRGC>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC
                               where a.GC_CNUMOPE.Trim() == dato.Trim()
                               select new
                               {
                                GC_CCODAGE =a.GC_CCODAGE,
                                GC_CNUMOPE = a.GC_CNUMOPE,
                                GC_DFECPRO = a.GC_DFECPRO,
                                GC_CCODCON = a.GC_CCODCON,
                                GC_CTIPPAG = a.GC_CTIPPAG,
                                GC_CCODBAN = a.GC_CCODBAN,
                                GC_CCODMON = a.GC_CCODMON,
                                GC_CCODDEP = a.GC_CCODDEP,
                                GC_CNUMLOT = a.GC_CNUMLOT,
                                GC_CTASDET = a.GC_CTASDET,
                                GC_NTIPCAM =a.GC_NTIPCAM,
                                GC_NMONPRO = a.GC_NMONPRO,
                                GC_CESTADO = a.GC_CESTADO,
                                GC_CUSUCRE = a.GC_CUSUCRE,
                                GC_DFECCRE = a.GC_DFECCRE,
                                GC_CUSUMOD = a.GC_CUSUMOD,
                                GC_DFECMOD = a.GC_DFECMOD,
                                GC_CUSUAPR = a.GC_CUSUAPR,
                                GC_DFECAPR = a.GC_DFECAPR,

                               }).ToList()
                           .Select(c => new VISTA_CP0003PRGC()
                           {
                               GC_CCODAGE = c.GC_CCODAGE,
                               GC_CNUMOPE = c.GC_CNUMOPE,
                               GC_DFECPRO = String.Format("{0:dd/MM/yyyy}", c.GC_DFECPRO),
                               GC_CCODCON = c.GC_CCODCON,
                               GC_CTIPPAG = c.GC_CTIPPAG,
                               GC_CCODBAN = c.GC_CCODBAN,
                               GC_CCODMON = c.GC_CCODMON,
                               GC_CCODDEP = c.GC_CCODDEP,
                               GC_CNUMLOT = c.GC_CNUMLOT,
                               GC_CTASDET = c.GC_CTASDET,
                               GC_NTIPCAM = c.GC_NTIPCAM,
                               GC_NMONPRO = c.GC_NMONPRO,
                               GC_CESTADO = c.GC_CESTADO,
                               GC_CUSUCRE = c.GC_CUSUCRE,
                               GC_DFECCRE = String.Format("{0:dd/MM/yyyy}", c.GC_DFECCRE),
                               GC_CUSUMOD = c.GC_CUSUMOD,
                               GC_DFECMOD = String.Format("{0:dd/MM/yyyy}", c.GC_DFECMOD),
                               GC_CUSUAPR = c.GC_CUSUAPR,
                               GC_DFECAPR = String.Format("{0:dd/MM/yyyy}", c.GC_DFECAPR),

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<vista_detalle_programacion> LISTARUNO1(string CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_detalle_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC
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
                                   USUAPRO = a.GC_CUSUAPR,
                                   USUMOD = a.GC_CUSUMOD,
                                   FECRE = a.GC_DFECCRE,
                                   FEAPRO = a.GC_DFECAPR,
                                   FEMOD = a.GC_DFECMOD,
                                   operacion = "", //a.GC_CNOPEDE,
                                   foperacion = "",
                                   LOTE = a.GC_CNUMLOT,

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
                               TIPODETRACCION = (c.TASADETRACCION.Trim() == "99999" ? "TODOS" : c.TIPODETRACCION),
                               TASADETRACCION = c.TASADETRACCION,
                               coddepartamento = c.coddepartamento,
                               DEPARTAMENTO = c.DEPARTAMENTO,
                               CODBANCO = c.CODBANCO,
                               BANCO = c.BANCO,
                               ESTADO = (c.ESTADO == "P" ? "PENDIENTE" : "APROBADA"),
                               USUCRE = c.USUCRE,
                               USUAPRO = c.USUAPRO,
                               USUMOD = c.USUMOD,
                               FECRE = c.FECRE,
                               FEAPRO = c.FEAPRO,
                               FEMOD = c.FEMOD,
                               operacion = c.operacion,
                              // foperacion = (c.foperacion==""? null:c.foperacion),
                               BANCOCUENTA = c.LOTE,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

        public static List<vista_detalle_programacion> MODIFICARPROG(string CODATA) //CP0003PRGC CODATA)
        {
            DateTime fecha = DateTime.Today;
            var alumnos = new List<vista_detalle_programacion>();
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    alumnos = (from a in ctx.CP0003PRGC
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
                                                select new { concepto1 = b.CG_CCONCEP }).FirstOrDefault().concepto1),
                                   ESTADO= a.GC_CCODCON,

                                   tipopago = ((from b in ctx.CP0003TABL
                                                where b.TG_CODIGO.Trim() == a.GC_CTIPPAG && b.TG_INDICE == "60"
                                                select new { tipopago1 = b.TG_CODIGO.Trim() + "-" + b.TG_DESCRI }).FirstOrDefault().tipopago1),
                                   USUCRE= a.GC_CTIPPAG,
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
                                                    { depart = c.TG_CODIGO.Trim() + "-" + c.TG_DESCRI }).FirstOrDefault().depart),                                     

                                   CODBANCO = a.GC_CCODBAN,
                                   BANCO = ((from b in ctx.CP0003CUBA
                                             where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                             select new { b.CT_CDESCTA }).FirstOrDefault().CT_CDESCTA),
                                   BANCOCTA = ((from b in ctx.CP0003CUBA
                                                where b.CT_CNUMCTA.Trim() == a.GC_CCODBAN
                                                select new { b.CT_CCUENTA }).FirstOrDefault().CT_CCUENTA),
                                  // ESTADO = a.GC_CESTADO,
                                  // USUCRE = a.GC_CUSUCRE,
                                   USUAPRO = a.GC_CUSUAPR,
                                   USUMOD = a.GC_CUSUMOD,

                                   FUSUCRE = a.GC_DFECCRE,
                                   FUSUAPRO = a.GC_DFECAPR,
                                   FUSUMOD = a.GC_DFECMOD,


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
                               ESTADO = (c.ESTADO),
                               BANCOCUENTA = c.BANCOCTA,
                               USUCRE = c.USUCRE,
                               USUAPRO = c.USUAPRO,
                               USUMOD = c.USUMOD,
                               FECRE = c.FUSUCRE,
                               FEAPRO = c.FUSUAPRO,
                               FEMOD = c.FUSUMOD,

                           }).ToList();
                }
            }
            catch (Exception)
            { throw; }

            return alumnos;
        }

    }
}
