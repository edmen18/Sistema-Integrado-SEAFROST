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
    public partial class T_TRABAJO
    {
        [Key]
        [StringLength(10)]
        public string TR_CODIGO { get; set; }

        public int? AE_COD { get; set; }

        [StringLength(10)]
        public string EQ_CODIGO { get; set; }

        [StringLength(10)]
        public string PL_CODIGO { get; set; }

        [StringLength(100)]
        public string CONTRATISTA { get; set; }

        [StringLength(50)]
        public string COD_CENCOS { get; set; }

        [StringLength(100)]
        public string CENTRO_COSTO { get; set; }

        public string DESCRIPCION { get; set; }

        [StringLength(50)]
        public string CONTROL_ACTIVOS { get; set; }

        public string OBSERVACIONES { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? FECHA { get; set; }

        public decimal? PRESUPUESTO { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        [StringLength(2)]
        public string COD_MON { get; set; }

        [StringLength(100)]
        public string MONEDA { get; set; }

        [StringLength(5)]
        public string USU1 { get; set; }

        [StringLength(5)]
        public string USU2 { get; set; }

        [StringLength(5)]
        public string USU3 { get; set; }

        public static Boolean inserta(T_TRABAJO alumno)
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

        public static Boolean actualiza(T_TRABAJO alumno)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(alumno).State = EntityState.Modified;
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


        public static string GenerarCodigo()
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.T_TRABAJO.Count() + 1;
                    valor = Convert.ToString(codigo);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;

        }

        public static List<VISTA_TRABAJO> ListarTrabajos(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_TRABAJO.Where(x =>
                                ((CODATA.AE_COD == -1) ? (x.AE_COD == -1 || x.AE_COD != 0) : (x.AE_COD == CODATA.AE_COD))
                              && ((CODATA.PL_CODIGO == "-1") ? (x.PL_CODIGO != "-1" || x.PL_CODIGO.Trim() != "") : (x.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (x.EQ_CODIGO != "-1" || x.EQ_CODIGO.Trim() != "") : (x.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (x.COD_CENCOS.Trim() != "" || x.COD_CENCOS.Trim() == "") : (x.COD_CENCOS == CODATA.COD_CENCOS))
                              && (x.FECHA>=CODATA.FECHA && x.FECHA<=CODATA.FECHAFIN)
                              )
                           select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_area
                                            where b.AE_COD == a.AE_COD
                                            select new { b.AE_DESC }).FirstOrDefault().AE_DESC),
                                   PLANTA = ((from b in ctx.T_PLANTA
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.T_EQUIPO
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),

                               }).ToList()
                           .Select(c => new VISTA_TRABAJO()
                           {
                               TR_CODIGO = c.TAREA,
                               CONTRATISTA = c.CONTRATISTA,
                               CENTRO_COSTO = c.CENTROCOSTO,
                               DESCRIPCION = c.DESCRIPCION,
                               CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                               AE_DESC = c.AREA,
                               PL_DESCRIPCION = c.PLANTA,
                               EQ_DESCRIPCION = c.EQUIPOS,
                               FECHA = Convert.ToDateTime(c.FECHA),
                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> ConsultaUno(T_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_TRABAJO.Where(x => (x.TR_CODIGO == CODATA.TR_CODIGO))
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_area
                                            where b.AE_COD == a.AE_COD
                                            select new { b.AE_DESC }).FirstOrDefault().AE_DESC),
                                   cod_area = a.AE_COD,

                                   PLANTA = ((from b in ctx.T_PLANTA
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,

                                   EQUIPOS = ((from b in ctx.T_EQUIPO
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                   //agregados
                                   cod_centro=a.COD_CENCOS,
                                   obs=a.OBSERVACIONES,
                                   presupuesto=a.PRESUPUESTO,
                                   estado=a.ESTADO,
                                   codmon=a.COD_MON,
                                   moneda=a.MONEDA,

                               }).ToList()
                           .Select(c => new VISTA_TRABAJO()
                           {
                               TR_CODIGO = c.TAREA,
                               CONTRATISTA = c.CONTRATISTA,
                               CENTRO_COSTO = c.CENTROCOSTO,
                               DESCRIPCION = c.DESCRIPCION,
                               CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                               AE_DESC = c.AREA,
                               AE_COD = c.cod_area,
                               PL_DESCRIPCION = c.PLANTA,
                               PL_CODIGO=c.cod_planta,
                               EQ_DESCRIPCION = c.EQUIPOS,
                               EQ_CODIGO=c.eq_equipo,
                               FECHA = Convert.ToDateTime(c.FECHA),
                               COD_CENCOS=c.cod_centro,
                               OBSERVACIONES=c.obs,
                               PRESUPUESTO=c.presupuesto,
                               ESTADO=c.estado,
                               COD_MON=c.codmon,
                               MONEDA=c.moneda,
                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> Impresion(T_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_TRABAJO join b in ctx.T_DETALLE on a.TR_CODIGO equals b.TR_CODIGO
                               where  (a.TR_CODIGO == CODATA.TR_CODIGO)                               
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_area
                                            where b.AE_COD == a.AE_COD
                                            select new { b.AE_DESC }).FirstOrDefault().AE_DESC),
                                   cod_area = a.AE_COD,

                                   PLANTA = ((from b in ctx.T_PLANTA
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,

                                   EQUIPOS = ((from b in ctx.T_EQUIPO
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                  
                                   cod_centro = a.COD_CENCOS,
                                   obs = a.OBSERVACIONES,
                                   presupuesto = a.PRESUPUESTO,
                                   estado = a.ESTADO,
                                   codmon = a.COD_MON,
                                   moneda = a.MONEDA,

                                   // detalle
                                  documento=b.NUM_DOC,
                                   tipodoc = ((from c in ctx.TB_TIPO_DOC
                                               where c.COD_TIPO == b.COD_TIPO
                                               select new { c.TD_DESCRIPCION }).FirstOrDefault().TD_DESCRIPCION),
                                               USU1=a.USU1,
                                               USU2=a.USU2,
                                               USU3=a.USU3,

                               }).ToList()
                           .Select(c => new VISTA_TRABAJO()
                           {
                               TR_CODIGO = c.TAREA,
                               CONTRATISTA = c.CONTRATISTA,
                               CENTRO_COSTO = c.CENTROCOSTO,
                               DESCRIPCION = c.DESCRIPCION,
                               CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                               AE_DESC = c.AREA,
                               AE_COD = c.cod_area,
                               PL_DESCRIPCION = c.PLANTA,
                               PL_CODIGO = c.cod_planta,
                               EQ_DESCRIPCION = c.EQUIPOS,
                               EQ_CODIGO = c.eq_equipo,
                               FECHA = Convert.ToDateTime(c.FECHA),
                               COD_CENCOS = c.cod_centro,
                               OBSERVACIONES = c.obs,
                               PRESUPUESTO = c.presupuesto,
                               ESTADO = c.estado,
                               COD_MON = c.codmon,
                               MONEDA = c.moneda,
                               tipodoc=c.tipodoc,
                               documento=c.documento,
                               USU1 = tabla_usuarios.ObtenUsuario(c.USU1).TU_NOMUSU.ToUpper(),
                               USU2 = tabla_usuarios.ObtenUsuario(c.USU2).TU_NOMUSU.ToUpper(),
                               USU3 = tabla_usuarios.ObtenUsuario(c.USU3).TU_NOMUSU.ToUpper(),
                               
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
