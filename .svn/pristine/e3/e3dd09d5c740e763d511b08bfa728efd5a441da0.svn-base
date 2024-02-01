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

    public partial class tabla_log_anticipo
    {
        [Required]
        [StringLength(10)]
        public string ANT_CODIGOL { get; set; }

        [StringLength(20)]
        public string OC_CNUMORDL { get; set; }

        [StringLength(18)]
        public string OC_CCODPROL { get; set; }

        [StringLength(80)]
        public string OC_CRAZOCL { get; set; }

        public DateTime? OC_FECEMIL { get; set; }

        public DateTime? OC_FECPROL { get; set; }

        [StringLength(12)]
        public string OC_CODMONL { get; set; }

        public decimal? OC_MONTO_PEDIDOL { get; set; }

        public decimal? OC_PERCENTAJEL { get; set; }

        public decimal? OC_ANTICIPOL { get; set; }

        public decimal? OC_TOTAL_PAGARL { get; set; }

        [StringLength(500)]
        public string MOTIVOL { get; set; }

        [StringLength(30)]
        public string OC_CTAPROVEEDORL { get; set; }

        [StringLength(18)]
        public string OC_BANCOL { get; set; }

        [StringLength(500)]
        public string BANCOL { get; set; }

        [StringLength(500)]
        public string MONEDAL { get; set; }

        public decimal? DET_PORCENTAJEL { get; set; }

        public decimal? DETRACCIONL { get; set; }

        public decimal? RET_PORCENTAJEL { get; set; }

        public decimal? RETENCIONL { get; set; }

        public int? PLAZO_DIASL { get; set; }

        [StringLength(1)]
        public string ESTADOL { get; set; }

        [StringLength(1)]
        public string APROBADOL { get; set; }

        [StringLength(5)]
        public string USER1L { get; set; }

        [StringLength(5)]
        public string USER2L { get; set; }

        [StringLength(5)]
        public string USER3L { get; set; }

        [StringLength(5)]
        public string USER4L { get; set; }

        [StringLength(12)]
        public string OC_CCODSOLL { get; set; }

        [StringLength(50)]
        public string OC_CSOLICTL { get; set; }

        [StringLength(5)]
        public string USUMODL { get; set; }

        public DateTime? FECHAL { get; set; }

        [StringLength(500)]
        public string OPERACIONL { get; set; }

        [Key]
        public int CODIGO { get; set; }

        public static Boolean insertaSolicitud(tabla_log_anticipo alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Added;
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

        public static List<vista_solicitud> CONSULTAUNO(tabla_anticipo CODATA)
        {
            var alumnos = new List<vista_solicitud>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_anticipo.Where(x => x.ANT_CODIGO.Trim() == CODATA.ANT_CODIGO.Trim()
                              )

                               select new
                               {
                                   codigo = a.ANT_CODIGO,
                                   numoc = a.OC_CNUMORD,
                                   ruc = a.OC_CCODPRO,
                                   razonoc = a.OC_CRAZSOC,
                                   fecemi = a.OC_FECEMI,
                                   fecpro = a.OC_FECPRO,
                                   codmon = a.OC_CODMON,
                                   montopedido = a.OC_MONTO_PEDIDO,
                                   porcentaje = a.OC_PERCENTAJE,
                                   anticipo = a.OC_ANTICIPO,
                                   totalpagar = a.OC_TOTAL_PAGAR,
                                   motivo = a.MOTIVO,
                                   ctaprovedor = a.OC_CTAPROVEEDOR,
                                   ctabanco = a.OC_BANCO,
                                   banco = a.BANCO,
                                   moneda = a.MONEDA,
                                   pdetra = a.DET_PORCENTAJE,
                                   detra = a.DETRACCION,
                                   pret = a.RET_PORCENTAJE,
                                   ret = a.RETENCION,
                                   dias = a.PLAZO_DIAS,
                                   estado = a.ESTADO,
                                   user1 = a.USER1,
                                   user2 = a.USER2,
                                   user3 = a.USER3,
                                   user4 = a.USER4,
                                   apro = a.APROBADO,
                                   codsol = a.OC_CCODSOL,
                                   solicitante = a.OC_CSOLICT,

                               }).ToList()
                          .Select(c => new vista_solicitud()
                          {
                              ANT_CODIGO = c.codigo,
                              OC_CNUMORD = c.numoc,
                              OC_CCODPRO = c.ruc,
                              OC_CRAZSOC = c.razonoc,
                              OC_FECEMI = String.Format("{0:dd/MM/yyyy}", c.fecemi),
                              OC_FECPRO = String.Format("{0:dd/MM/yyyy}", c.fecpro),
                              OC_CODMON = c.codmon,
                              OC_MONTO_PEDIDO = Convert.ToDecimal(c.montopedido),
                              OC_PERCENTAJE = Convert.ToDecimal(c.porcentaje),
                              OC_ANTICIPO = Convert.ToDecimal(c.anticipo),
                              OC_TOTAL_PAGAR = Convert.ToDecimal(c.totalpagar),
                              OC_CTAPROVEEDOR = c.ctaprovedor,
                              MOTIVO = c.motivo,
                              OC_BANCO = c.ctabanco,
                              BANCO = c.banco,
                              MONEDA = c.moneda,
                              DET_PORCENTAJE = Convert.ToDecimal(c.pdetra),
                              DETRACCION = Convert.ToDecimal(c.detra),
                              RET_PORCENTAJE = Convert.ToDecimal(c.pret),
                              RETENCION = Convert.ToDecimal(c.ret),
                              PLAZO_DIAS = Convert.ToInt16(c.dias),
                              ESTADO = c.estado,
                              USER1 = c.user1,
                              USER2 = c.user2,
                              USER3 = c.user3,
                              USER4 = c.user4,
                              APROB = c.apro,
                              OC_CCODSOL = c.codsol,
                              OC_CSOLICT = c.solicitante,
                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
    }
}
