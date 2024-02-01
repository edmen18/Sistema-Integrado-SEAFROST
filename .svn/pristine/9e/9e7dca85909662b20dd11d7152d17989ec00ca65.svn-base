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

    public partial class tabla_modpresupuesto
    {
        [Key]
        public string COD_SOLICITUD { get; set; }
        public string TR_CODIGO { get; set; }
        public DateTime? FECHA_SOL { get; set; }
        public decimal? PMO_ANTERIOR { get; set; }
        public decimal? PM_ANTERIOR { get; set; }
        public decimal? PE_ANTERIOR { get; set; }
        public decimal? PRES_ANTERIOR { get; set; }
        public decimal? TOTAL_ANTERIOR { get; set; }

        public decimal? PMO_NUEVO { get; set; }
        public decimal? PM_NUEVO { get; set; }
        public decimal? PE_NUEVO { get; set; }
        public decimal? PRES_NUEVO { get; set; }
        public decimal? TOTAL_NUEVO { get; set; }
        
        [StringLength(5)]
        public string USU_APRO { get; set; }
        public DateTime? FECHA_APRO { get; set; }
        public string ESTADO { get; set; }

        public static string GenerarCodigo()
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.tabla_modpresupuesto.Count() + 1;
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;

        }

        public static string EMITIDAS(string dato )
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.tabla_modpresupuesto.Where(X=>X.ESTADO=="E" && X.TR_CODIGO==dato).Count();
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;

        }
        public static Boolean inserta(tabla_modpresupuesto datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
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


        public static List<VISTA_SOLICITUD_EXTENSION>ListaTodos()
        {
            var alumnos = new List<VISTA_SOLICITUD_EXTENSION>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo join b in ctx.tabla_modpresupuesto on
                               a.TR_CODIGO equals b.TR_CODIGO where b.ESTADO=="E"
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   solicitud = b.COD_SOLICITUD,
                                   fecha = b.FECHA_SOL,
                                   DESCRIPCION = a.DESCRIPCION,
                                   mo_actual=b.PMO_ANTERIOR,
                                   pm_actual=b.PM_ANTERIOR,
                                   pe_actual=b.PE_ANTERIOR,
                                   pres_actual=b.PRES_ANTERIOR,
                                   total_actual=b.TOTAL_ANTERIOR,

                                   pm_nuevo=b.PM_NUEVO,
                                   pmo_nuevo=b.PMO_NUEVO,
                                   pe_nuevo=b.PE_NUEVO,
                                   pres_nuevo=b.PRES_NUEVO,
                                   total_nuevo=b.TOTAL_NUEVO,
                                   estado=b.ESTADO,
                                   usuario=b.USU_APRO,
                             }).ToList()
                           .Select(c => new VISTA_SOLICITUD_EXTENSION()
                           {
                                TR_CODIGO= c.TAREA,
                                COD_SOLICITUD = c.solicitud,
                                FECHA_SOL = c.fecha,
                               DESCRIPCION = c.DESCRIPCION,
                                PMO_ANTERIOR = c.mo_actual,
                               PM_ANTERIOR = c.pm_actual,
                                PE_ANTERIOR = c.pe_actual,
                                PRES_ANTERIOR = c.pres_actual,
                                TOTAL_ANTERIOR = c.total_actual,
                                PM_NUEVO = c.pm_nuevo,
                                PMO_NUEVO = c.pmo_nuevo,
                                PE_NUEVO = c.pe_nuevo,
                                PRES_NUEVO = c.pres_nuevo,
                                TOTAL_NUEVO = c.total_nuevo,
                                ESTADO = (c.estado == "E" ? "EMITIDA" : c.estado == "A" ? "APROBADA" : "DESAPROBADA"),
                               USU_APRO = c.usuario,

                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_SOLICITUD_EXTENSION> listarparametros(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_SOLICITUD_EXTENSION>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo
                               join b in ctx.tabla_modpresupuesto on
                               a.TR_CODIGO equals b.TR_CODIGO
                               where(
                              ((CODATA.AE_COD == -1) ? (a.AE_COD == -1 || a.AE_COD != 0) : (a.AE_COD == CODATA.AE_COD))
                              && ((CODATA.ESTADO == "T") ? (b.ESTADO == "T" || b.ESTADO != "") : (b.ESTADO == CODATA.ESTADO))
                              && ((CODATA.PL_CODIGO == "-1") ? (a.PL_CODIGO != "-1" || a.PL_CODIGO.Trim() != "") : (a.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (a.EQ_CODIGO != "-1" || a.EQ_CODIGO.Trim() != "") : (a.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (a.COD_CENCOS.Trim() != "" || a.COD_CENCOS.Trim() == "") : (a.COD_CENCOS == CODATA.COD_CENCOS))
                              && (a.FECHA >= CODATA.FECHA && a.FECHA <= CODATA.FECHAFIN))
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   solicitud = b.COD_SOLICITUD,
                                   fecha = b.FECHA_SOL,
                                   DESCRIPCION = a.DESCRIPCION,
                                   mo_actual = b.PMO_ANTERIOR,
                                   pm_actual = b.PM_ANTERIOR,
                                   pe_actual = b.PE_ANTERIOR,
                                   pres_actual = b.PRES_ANTERIOR,
                                   total_actual = b.TOTAL_ANTERIOR,

                                   pm_nuevo = b.PM_NUEVO,
                                   pmo_nuevo = b.PMO_NUEVO,
                                   pe_nuevo = b.PE_NUEVO,
                                   pres_nuevo = b.PRES_NUEVO,
                                   total_nuevo = b.TOTAL_NUEVO,
                                   estado = b.ESTADO,
                                   usuario = b.USU_APRO,
                               }).ToList()
                           .Select(c => new VISTA_SOLICITUD_EXTENSION()
                           {
                               TR_CODIGO = c.TAREA,
                               COD_SOLICITUD = c.solicitud,
                               FECHA_SOL = c.fecha,
                               DESCRIPCION = c.DESCRIPCION,
                               PMO_ANTERIOR = c.mo_actual,
                               PM_ANTERIOR = c.pm_actual,
                               PE_ANTERIOR = c.pe_actual,
                               PRES_ANTERIOR = c.pres_actual,
                               TOTAL_ANTERIOR = c.total_actual,
                               PM_NUEVO = c.pm_nuevo,
                               PMO_NUEVO = c.pmo_nuevo,
                               PE_NUEVO = c.pe_nuevo,
                               PRES_NUEVO = c.pres_nuevo,
                               TOTAL_NUEVO = c.total_nuevo,
                               ESTADO = (c.estado=="E"? "EMITIDA": c.estado=="A"? "APROBADA": "DESAPROBADA"),
                               USU_APRO = c.usuario,

                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_SOLICITUD_EXTENSION> ConsultaUno(tabla_modpresupuesto CODATA)
        {
            var alumnos = new List<VISTA_SOLICITUD_EXTENSION>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from  b in ctx.tabla_modpresupuesto
                               where b.COD_SOLICITUD == CODATA.COD_SOLICITUD
                               select new
                               {
                                  
                                   solicitud = b.COD_SOLICITUD,
                                   fecha = b.FECHA_SOL,
                                   mo_actual = b.PMO_ANTERIOR,
                                   pm_actual = b.PM_ANTERIOR,
                                   pe_actual = b.PE_ANTERIOR,
                                   pres_actual = b.PRES_ANTERIOR,
                                   total_actual = b.TOTAL_ANTERIOR,

                                   pm_nuevo = b.PM_NUEVO,
                                   pmo_nuevo = b.PMO_NUEVO,
                                   pe_nuevo = b.PE_NUEVO,
                                   pres_nuevo = b.PRES_NUEVO,
                                   total_nuevo = b.TOTAL_NUEVO,
                                   estado = b.ESTADO,
                                   usuario = b.USU_APRO,
                               }).ToList()
                           .Select(c => new VISTA_SOLICITUD_EXTENSION()
                           {                              
                               COD_SOLICITUD = c.solicitud,
                               FECHA_SOL = c.fecha,
                               PMO_ANTERIOR = c.mo_actual,
                               PM_ANTERIOR = c.pm_actual,
                               PE_ANTERIOR = c.pe_actual,
                               PRES_ANTERIOR = c.pres_actual,
                               TOTAL_ANTERIOR = c.total_actual,
                               PM_NUEVO = c.pm_nuevo,
                               PMO_NUEVO = c.pmo_nuevo,
                               PE_NUEVO = c.pe_nuevo,
                               PRES_NUEVO = c.pres_nuevo,
                               TOTAL_NUEVO = c.total_nuevo,
                               ESTADO = (c.estado == "E" ? "EMITIDA" : c.estado == "A" ? "APROBADA" : "DESAPROBADA"),
                               USU_APRO = c.usuario,

                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static void Cambiarestado(tabla_modpresupuesto COM)
        {
            var orden = new tabla_modpresupuesto { COD_SOLICITUD = COM.COD_SOLICITUD };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_modpresupuesto.Attach(orden);
               if (COM.ESTADO=="A")
                {
                if (COM.USU_APRO.Trim() != "")
                {   orden.FECHA_APRO = DateTime.Now.Date;
                    orden.USU_APRO = COM.USU_APRO;
                    orden.ESTADO = COM.ESTADO;
                    ctx.Configuration.ValidateOnSaveEnabled = false;
                    ctx.SaveChanges();
                }

                }
                if (COM.ESTADO == "D")
                {
                        String valor = "01/01/2000";
                        orden.FECHA_APRO =Convert.ToDateTime(valor);
                        orden.USU_APRO = "";
                        orden.ESTADO = COM.ESTADO;
                        ctx.Configuration.ValidateOnSaveEnabled = false;
                        ctx.SaveChanges();
                    
                }

            }


        }




    }

}

