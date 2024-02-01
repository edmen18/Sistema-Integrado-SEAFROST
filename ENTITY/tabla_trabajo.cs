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
    using System.Globalization;

    public partial class tabla_trabajo
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

        public decimal? PORC_ADICIONAL { get; set; }

        public DateTime? FECHA_A1 { get; set; }

        public DateTime? FECHA_A2 { get; set; }

        public DateTime? FECHA_A3 { get; set; }

        [StringLength(50)]
        public string COD_CONTRATISTA { get; set; }

        public decimal? PRES_MANOBRA { get; set; }
        public decimal? PRES_MATERIAL { get; set; }
        public decimal? PRES_EQUIPOS { get; set; }
        public decimal? TIPO_CAMBIO { get; set; }

        public decimal? PI_MANOBRA { get; set; }
        public decimal? PI_MATERIALES { get; set; }
        public decimal? PI_EQUIPOS { get; set; }
        public decimal? PI_INICIAL { get; set; }
        public decimal? PORC_INICIAL { get; set; }



        public DateTime? FECHA_INICIO { get; set; }
        public DateTime? FECHA_FIN { get; set; }
        public string VALIDACION { get; set; }
        public string FINALIZADO { get; set; }
        public string COD_TIPO { get; set; }
      
        public static Boolean inserta(tabla_trabajo alumno)
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


        public static Boolean ActValidacion(tabla_trabajo alumno)
        {
            Boolean band = true;
            var orden = new tabla_trabajo { TR_CODIGO = alumno.TR_CODIGO };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_trabajo.Attach(orden);

                    orden.VALIDACION = alumno.VALIDACION;
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

        public static Boolean actualiza(tabla_trabajo alumno)
        {
            Boolean band = true;
            var orden = new tabla_trabajo { TR_CODIGO = alumno.TR_CODIGO };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_trabajo.Attach(orden);

                    orden.AE_COD = alumno.AE_COD;
                    orden.EQ_CODIGO = alumno.EQ_CODIGO;
                    orden.PL_CODIGO = alumno.PL_CODIGO;
                    orden.FECHA = alumno.FECHA;
                    orden.FECHA_INICIO = alumno.FECHA_INICIO;
                    orden.FECHA_FIN = alumno.FECHA_FIN;
                    orden.CONTRATISTA = alumno.CONTRATISTA;
                    orden.COD_CONTRATISTA = alumno.COD_CONTRATISTA;
                    orden.COD_CENCOS = alumno.COD_CENCOS;
                    orden.CENTRO_COSTO = alumno.CENTRO_COSTO;
                    orden.DESCRIPCION = alumno.DESCRIPCION;
                    orden.CONTROL_ACTIVOS = alumno.CONTROL_ACTIVOS;
                    orden.COD_MON = alumno.COD_MON;
                    orden.MONEDA = alumno.MONEDA;
                    orden.OBSERVACIONES = alumno.OBSERVACIONES;
                    orden.PRESUPUESTO = alumno.PRESUPUESTO;
                    orden.PRES_EQUIPOS = alumno.PRES_EQUIPOS;
                    orden.PRES_MATERIAL = alumno.PRES_MATERIAL;
                    orden.PRES_MANOBRA = alumno.PRES_MANOBRA;
                    orden.ESTADO = alumno.ESTADO;
                    orden.USU1 = alumno.USU1;
                    orden.USU2 = alumno.USU2;
                    orden.USU3 = alumno.USU3;
                    // orden.TR_CODIGO = alumno.TR_CODIGO;
                    orden.PORC_ADICIONAL = alumno.PORC_ADICIONAL;
                    orden.TIPO_CAMBIO = alumno.TIPO_CAMBIO;
                    orden.COD_TIPO = alumno.COD_TIPO;

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

        public static Boolean actualizaFinalizado(tabla_trabajo alumno)
        {
            Boolean band = true;
            var orden = new tabla_trabajo { TR_CODIGO = alumno.TR_CODIGO };
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.tabla_trabajo.Attach(orden);

                    orden.FINALIZADO = "S";

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

        public static void ActPresupuesto(tabla_trabajo COM)
        {
            var orden = new tabla_trabajo { TR_CODIGO = COM.TR_CODIGO };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_trabajo.Attach(orden);
                orden.PRESUPUESTO = COM.PRESUPUESTO;
                orden.PRES_EQUIPOS = COM.PRES_EQUIPOS;
                orden.PRES_MANOBRA = COM.PRES_MANOBRA;
                orden.PRES_MATERIAL = COM.PRES_MATERIAL;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();

            }
        }
        public static List<tabla_trabajo> ListarTrabajosAprobados()
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    var alumnos = (ctx.tabla_trabajo.Where(x => x.FINALIZADO == "N")).ToList();
                    return alumnos;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }
        public static string GenerarCodigo()
        {
            var codigo = 0;
            var valor = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.tabla_trabajo.Count() + 1;
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
                    alumnos = (from a in ctx.tabla_trabajo.Where(x =>
                                ((CODATA.AE_COD == -1) ? (x.AE_COD == -1 || x.AE_COD != 0) : (x.AE_COD == CODATA.AE_COD))
                              && ((CODATA.ESTADO == "T") ? (x.ESTADO == "T" || x.ESTADO != "") : (x.ESTADO == CODATA.ESTADO))
                              && ((CODATA.PL_CODIGO == "-1") ? (x.PL_CODIGO != "-1" || x.PL_CODIGO.Trim() != "") : (x.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (x.EQ_CODIGO != "-1" || x.EQ_CODIGO.Trim() != "") : (x.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (x.COD_CENCOS.Trim() != "" || x.COD_CENCOS.Trim() == "") : (x.COD_CENCOS == CODATA.COD_CENCOS))
                              && (x.FECHA >= CODATA.FECHA && x.FECHA <= CODATA.FECHAFIN)
                              )
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   estado = a.ESTADO,
                                   fecha = a.FECHA,
                                   TIPO = ((from b in ctx.tabla_trabajo_tipo
                                            where b.COD == a.COD_TIPO
                                            select new { b.TIPO }).FirstOrDefault().TIPO),

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
                               FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                               FECHA = c.fecha,
                               TIPO = c.TIPO,
                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> ListarTrabajosPendientesApro(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo.Where(x =>
                                ((CODATA.AE_COD == -1) ? (x.AE_COD == -1 || x.AE_COD != 0) : (x.AE_COD == CODATA.AE_COD))
                              && ((CODATA.PL_CODIGO == "-1") ? (x.PL_CODIGO != "-1" || x.PL_CODIGO.Trim() != "") : (x.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (x.EQ_CODIGO != "-1" || x.EQ_CODIGO.Trim() != "") : (x.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (x.COD_CENCOS.Trim() != "" || x.COD_CENCOS.Trim() == "") : (x.COD_CENCOS == CODATA.COD_CENCOS))
                              && (x.ESTADO == "E")
                              )
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   estado = a.ESTADO,
                                   TIPO = ((from b in ctx.tabla_trabajo_tipo
                                            where b.COD == a.COD_TIPO
                                            select new { b.TIPO }).FirstOrDefault().TIPO),

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
                               FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                               TIPO=c.TIPO
                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<VISTA_TRABAJO> ConsultaUno(tabla_trabajo CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo.Where(x => (x.TR_CODIGO == CODATA.TR_CODIGO))
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   cod_area = a.AE_COD,

                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,

                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                   //agregados
                                   cod_centro = a.COD_CENCOS,
                                   obs = a.OBSERVACIONES,
                                   presupuesto = a.PRESUPUESTO,
                                   estado = a.ESTADO,
                                   codmon = a.COD_MON,
                                   moneda = a.MONEDA,
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   ADICIONAL = a.PORC_ADICIONAL,
                                   COD_CONTRATISTA = a.COD_CONTRATISTA,
                                   manobra = a.PRES_MANOBRA,
                                   material = a.PRES_MATERIAL,
                                   equipo = a.PRES_EQUIPOS,
                                   TC = a.TIPO_CAMBIO,
                                   fini = a.FECHA_INICIO,
                                   ffin = a.FECHA_FIN,
                                   validacion = a.VALIDACION,
                                   PRESINI = a.PI_INICIAL,
                                   PORINI = a.PORC_INICIAL,
                                   PI_MANOBRA = a.PI_MANOBRA,
                                   PI_MATERIALES = a.PI_MATERIALES,
                                   PI_EQUIPOS = a.PI_EQUIPOS,
                                   cod_tipo= a.COD_TIPO,
                                   TIPO = ((from b in ctx.tabla_trabajo_tipo
                                            where b.COD == a.COD_TIPO
                                            select new { b.TIPO }).FirstOrDefault().TIPO),


                               }).ToList()
                           .Select(c => new VISTA_TRABAJO()
                           {
                               TR_CODIGO = c.TAREA,
                               CONTRATISTA = c.CONTRATISTA,
                               COD_CONTRATISTA = c.COD_CONTRATISTA,
                               CENTRO_COSTO = c.CENTROCOSTO,
                               DESCRIPCION = c.DESCRIPCION,
                               CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                               AE_DESC = c.AREA,
                               AE_COD = Convert.ToInt32(c.cod_area),
                               PL_DESCRIPCION = c.PLANTA,
                               PL_CODIGO = c.cod_planta,
                               EQ_DESCRIPCION = c.EQUIPOS,
                               EQ_CODIGO = c.eq_equipo,
                               FECHA = Convert.ToDateTime(c.FECHA),
                               COD_CENCOS = c.cod_centro,
                               OBSERVACIONES = c.obs,
                               PRESUPUESTO = Convert.ToDecimal(c.presupuesto),
                               ESTADO = c.estado,
                               COD_MON = c.codmon,
                               MONEDA = c.moneda,
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               PORC_ADICIONAL = Convert.ToDecimal(c.ADICIONAL),
                               PRES_EQUIPOS = Convert.ToDecimal(c.equipo),
                               PRES_MATERIAL = Convert.ToDecimal(c.material),
                               PRES_MANOBRA = Convert.ToDecimal(c.manobra),
                               TIPO_CAMBIO = Convert.ToDecimal(c.TC),
                               FECHA_INI = Convert.ToDateTime(c.fini),
                               FECHA_FIN = Convert.ToDateTime(c.ffin),
                               VALIDACION = c.validacion,
                               PI_INICIAL = Convert.ToDecimal(c.PRESINI),
                               PORC_INICIAL = Convert.ToDecimal(c.PORINI),
                               PI_MANOBRA = Convert.ToDecimal(c.PI_MANOBRA),
                               PI_MATERIALES = Convert.ToDecimal(c.PI_MATERIALES),
                               PI_EQUIPOS = Convert.ToDecimal(c.PI_EQUIPOS),
                               TIPO=c.TIPO,
                               COD=c.cod_tipo,
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTAIMP_TRABAJOS_DETALLE> Impresion(tabla_trabajo CODATA)
        {
            var resultado = new List<VISTAIMP_TRABAJOS_DETALLE>();

            try
            {
                var cty = new RSFACAR();

                var detalle = ((from a in cty.AL0003REQC
                                where a.RC_CNUMOT == CODATA.TR_CODIGO
                                && a.RC_CESTADO == "7"
                                select new
                                {
                                    data1 = a.RC_CNROREQ,
                                    data2 = a.RC_DFECREQ,
                                    data3 = a.RC_CCODMON,
                                    data4 = a.RC_NIMPUS,
                                    data5 = a.RC_NIMPMN,
                                    data6 = "REQUERIMIENTO",
                                    data7 = a.RC_CNUMOT
                                })
                                .Union(from b in cty.CO0003MOVC
                                       where b.OC_CRESPER3 == CODATA.TR_CODIGO
                                       && b.OC_CSITORD == "2"
                                       select new
                                       {
                                           data1 = b.OC_CNUMORD,
                                           data2 = b.OC_DFECDOC,
                                           data3 = b.OC_CCODMON,
                                           data4 = (decimal?)b.OC_NIMPUS,
                                           data5 = (decimal?)b.OC_NIMPMN,
                                           data6 = "ORDEN SERVICIO",
                                           data7 = b.OC_CRESPER3,
                                       })
                               ).ToArray();

                var ctx = new ANEXO_RSFACAR();

                var alumnos = (from a in ctx.tabla_trabajo

                               where (a.TR_CODIGO == CODATA.TR_CODIGO)

                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   cod_area = a.AE_COD,
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                   cod_centro = a.COD_CENCOS,
                                   obs = a.OBSERVACIONES,
                                   presupuesto = a.PRESUPUESTO,
                                   estado = a.ESTADO,
                                   codmon = a.COD_MON,
                                   moneda = a.MONEDA,
                                   USU1 = a.USU1,
                                   USU2 = a.USU2,
                                   USU3 = a.USU3,
                                   ADICIONAL = a.PORC_ADICIONAL,

                               }).ToArray();

                resultado = (from al in alumnos
                             join det in detalle on al.TAREA.Trim() equals det.data7.Trim()
                             select new
                             {
                                 TAREA = al.TAREA,
                                 CONTRATISTA = al.CONTRATISTA,
                                 CENTROCOSTO = al.CENTROCOSTO,
                                 DESCRIPCION = al.DESCRIPCION,
                                 CONTROLACTIVOS = al.CONTROLACTIVOS,
                                 FECHA = al.FECHA,
                                 AREA = al.AREA,
                                 cod_area = al.cod_area,
                                 PLANTA = al.PLANTA,
                                 cod_planta = al.cod_planta,
                                 EQUIPOS = al.EQUIPOS,
                                 eq_equipo = al.eq_equipo,
                                 cod_centro = al.cod_centro,
                                 obs = al.obs,
                                 presupuesto = al.presupuesto,
                                 estado = al.estado,
                                 codmon = al.codmon,
                                 moneda = al.moneda,
                                 USU1 = al.USU1,
                                 USU2 = al.USU2,
                                 USU3 = al.USU3,
                                 ADICIONAL = al.ADICIONAL,
                                 // detalle
                                 documento = det.data1,
                                 tipodoc = det.data6,
                                 MONTO = (det.data3.Trim() == "MN" ? det.data5 : det.data4),

                             }).ToList()

                          .Select(c => new VISTAIMP_TRABAJOS_DETALLE()
                          {
                              TR_CODIGO = c.TAREA,
                              CONTRATISTA = c.CONTRATISTA,
                              CENTRO_COSTO = c.CENTROCOSTO,
                              DESCRIPCION = c.DESCRIPCION,
                              CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                              AE_DESC = c.AREA,
                              AE_COD = Convert.ToInt32(c.cod_area),
                              PL_DESCRIPCION = c.PLANTA,
                              PL_CODIGO = c.cod_planta,
                              EQ_DESCRIPCION = c.EQUIPOS,
                              EQ_CODIGO = c.eq_equipo,
                              FECHA = Convert.ToDateTime(c.FECHA),
                              COD_CENCOS = c.cod_centro,
                              OBSERVACIONES = c.obs,
                              PRESUPUESTO = Convert.ToDecimal(c.presupuesto),
                              ESTADO = c.estado,
                              COD_MON = c.codmon,
                              MONEDA = c.moneda,
                              tipodoc = c.tipodoc,
                              documento = c.documento,
                              USU1 = tabla_usuarios.ObtenUsuario(c.USU1).TU_NOMUSU.ToUpper(),
                              USU2 = tabla_usuarios.ObtenUsuario(c.USU2).TU_NOMUSU.ToUpper(),
                              USU3 = tabla_usuarios.ObtenUsuario(c.USU3).TU_NOMUSU.ToUpper(),
                              FECHAFIN = Convert.ToDateTime(c.FECHA),
                              PORC_ADICIONAL = Convert.ToDecimal(c.ADICIONAL),
                              MONTO = Convert.ToDecimal(c.MONTO),

                          }).ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }

        public static List<VISTA_TRABAJO_AVANCES> Impresion2(tabla_trabajo CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO_AVANCES>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo
                               join b in ctx.tabla_avances on a.TR_CODIGO equals b.TR_CODIGO
                               where (a.TR_CODIGO == CODATA.TR_CODIGO)
                               orderby b.ACUMULADO
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   cod_area = a.AE_COD,

                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,

                                   EQUIPOS = ((from b in ctx.tabla_equipo
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
                                   acumulado = b.ACUMULADO,
                                   nivel = b.NIVEL_AVANCE,
                                   USU1 = a.USU1,
                                   USU2 = a.USU2,
                                   USU3 = a.USU3,
                                   ADICIONAL = a.PORC_ADICIONAL,
                                   fecha_ava = b.FECHA,

                               }).ToList()
                           .Select(c => new VISTA_TRABAJO_AVANCES()
                           {
                               TR_CODIGO = c.TAREA,
                               CONTRATISTA = c.CONTRATISTA,
                               CENTRO_COSTO = c.CENTROCOSTO,
                               DESCRIPCION = c.DESCRIPCION,
                               CONTROL_ACTIVOS = c.CONTROLACTIVOS,
                               AE_DESC = c.AREA,
                               AE_COD = Convert.ToInt32(c.cod_area),
                               PL_DESCRIPCION = c.PLANTA,
                               PL_CODIGO = c.cod_planta,
                               EQ_DESCRIPCION = c.EQUIPOS,
                               EQ_CODIGO = c.eq_equipo,
                               FECHA = Convert.ToDateTime(c.FECHA),
                               COD_CENCOS = c.cod_centro,
                               OBSERVACIONES = c.obs,
                               PRESUPUESTO = Convert.ToDecimal(c.presupuesto),
                               ESTADO = c.estado,
                               COD_MON = c.codmon,
                               MONEDA = c.moneda,
                               NIVEL_AVANCE = Convert.ToDecimal(c.nivel),
                               ACUMULADO = Convert.ToDecimal(c.acumulado),
                               USU1 = tabla_usuarios.ObtenUsuario(c.USU1).TU_NOMUSU.ToUpper(),
                               USU2 = tabla_usuarios.ObtenUsuario(c.USU2).TU_NOMUSU.ToUpper(),
                               USU3 = tabla_usuarios.ObtenUsuario(c.USU3).TU_NOMUSU.ToUpper(),
                               FECHAFIN = Convert.ToDateTime(c.FECHA),
                               PORC_ADICIONAL = Convert.ToDecimal(c.ADICIONAL),
                               FECHA_AVA = Convert.ToDateTime(c.fecha_ava),

                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static void AprobarSol(tabla_trabajo COM)
        {

            var SOLICITUD = new tabla_trabajo { TR_CODIGO = COM.TR_CODIGO };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_trabajo.Attach(SOLICITUD);
                SOLICITUD.USU1 = COM.USU1;
                SOLICITUD.USU2 = COM.USU2;
                SOLICITUD.USU3 = COM.USU3;
                SOLICITUD.FECHA_A1 = ctx.tabla_trabajo.Where(X => X.TR_CODIGO == COM.TR_CODIGO).Select(X => X.FECHA_A1).FirstOrDefault();
                SOLICITUD.FECHA_A2 = ctx.tabla_trabajo.Where(X => X.TR_CODIGO == COM.TR_CODIGO).Select(X => X.FECHA_A2).FirstOrDefault();
                SOLICITUD.FECHA_A3 = ctx.tabla_trabajo.Where(X => X.TR_CODIGO == COM.TR_CODIGO).Select(X => X.FECHA_A3).FirstOrDefault();

                //PARA EVALUAR LAS FECHAS
                if (SOLICITUD.USU1.Trim() != "" && (SOLICITUD.FECHA_A1 == null || SOLICITUD.FECHA_A1 == Convert.ToDateTime("01/01/2000")))
                {
                    SOLICITUD.FECHA_A1 = DateTime.Now.Date;
                }
                if (SOLICITUD.USU2.Trim() != "" && (SOLICITUD.FECHA_A2 == null || SOLICITUD.FECHA_A2 == Convert.ToDateTime("01/01/2000")))
                {
                    SOLICITUD.FECHA_A2 = DateTime.Now.Date;
                }
                if (SOLICITUD.USU3.Trim() != "" && (SOLICITUD.FECHA_A3 == null || SOLICITUD.FECHA_A3 == Convert.ToDateTime("01/01/2000")))
                {
                    SOLICITUD.FECHA_A3 = DateTime.Now.Date;
                }
                //FIN EVALUAR FECHAS

                if (COM.USU1.Trim() != "" && COM.USU2.Trim() != "" && COM.USU3.Trim() != "" && COM.ESTADO.Trim() == "A")
                {
                    SOLICITUD.ESTADO = COM.ESTADO;

                }

                if (COM.USU1.Trim() != "" && COM.USU2.Trim() != "" && COM.USU3.Trim() != "" && COM.ESTADO.Trim() == "E")
                {
                    SOLICITUD.ESTADO = COM.ESTADO;
                    SOLICITUD.USU1 = "";
                    SOLICITUD.USU2 = "";
                    SOLICITUD.USU3 = "";
                    SOLICITUD.FECHA_A1 = Convert.ToDateTime("01/01/2000");
                    SOLICITUD.FECHA_A2 = Convert.ToDateTime("01/01/2000");
                    SOLICITUD.FECHA_A3 = Convert.ToDateTime("01/01/2000");


                }

                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

        public static List<VISTA_TRABAJO> ListarTrabajosAvances(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo

                               where (
                                ((CODATA.AE_COD == -1) ? (a.AE_COD == -1 || a.AE_COD != 0) : (a.AE_COD == CODATA.AE_COD))
                              && ((CODATA.PL_CODIGO == "-1") ? (a.PL_CODIGO != "-1" || a.PL_CODIGO.Trim() != "") : (a.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (a.EQ_CODIGO != "-1" || a.EQ_CODIGO.Trim() != "") : (a.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (a.COD_CENCOS.Trim() != "" || a.COD_CENCOS.Trim() == "") : (a.COD_CENCOS == CODATA.COD_CENCOS))
                              && (a.ESTADO == "A")
                              )
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   estado = a.ESTADO,
                                   data14 = (from R in (from R in ctx.tabla_avances
                                                        where R.TR_CODIGO == a.TR_CODIGO
                                                        orderby R.FECHA descending
                                                        select new { R.ACUMULADO, Dummy = "x" })
                                             group R by new { R.Dummy } into g
                                             select new
                                             {
                                                 Column1 = ((decimal?)g.Max(p => p.ACUMULADO))
                                             }
                                          ).FirstOrDefault().Column1,
                                   presupuesto = a.PRESUPUESTO,
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
                               FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                               acumulado = Convert.ToDecimal(c.data14),
                               PRESUPUESTO = Convert.ToDecimal(c.presupuesto),

                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> ListarTrabajosAvances1(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo

                               where (
                                ((CODATA.AE_COD == -1) ? (a.AE_COD == -1 || a.AE_COD != 0) : (a.AE_COD == CODATA.AE_COD))
                              && ((CODATA.PL_CODIGO == "-1") ? (a.PL_CODIGO != "-1" || a.PL_CODIGO.Trim() != "") : (a.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (a.EQ_CODIGO != "-1" || a.EQ_CODIGO.Trim() != "") : (a.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (a.COD_CENCOS.Trim() != "" || a.COD_CENCOS.Trim() == "") : (a.COD_CENCOS == CODATA.COD_CENCOS))
                             )
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   estado = a.ESTADO,
                                   data14 = (from R in (from R in ctx.tabla_avances
                                                        where R.TR_CODIGO == a.TR_CODIGO
                                                        orderby R.FECHA descending
                                                        select new { R.ACUMULADO, Dummy = "x" })
                                             group R by new { R.Dummy } into g
                                             select new
                                             {
                                                 Column1 = ((decimal?)g.Max(p => p.ACUMULADO))
                                             }
                                          ).FirstOrDefault().Column1,
                                   presupuesto = a.PRESUPUESTO,
                                   ADICIONAL = a.PORC_ADICIONAL,
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
                               FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                               acumulado = Convert.ToDecimal(c.data14),
                               PRESUPUESTO = Convert.ToDecimal(c.presupuesto),
                               PORC_ADICIONAL = Convert.ToDecimal(c.ADICIONAL),

                           }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> ReporteAvances(VISTA_TRABAJO CODATA)
        {
            var alumnos = new List<VISTA_TRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_trabajo

                               where (
                                ((CODATA.AE_COD == -1) ? (a.AE_COD == -1 || a.AE_COD != 0) : (a.AE_COD == CODATA.AE_COD))
                              && ((CODATA.PL_CODIGO == "-1") ? (a.PL_CODIGO != "-1" || a.PL_CODIGO.Trim() != "") : (a.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (a.EQ_CODIGO != "-1" || a.EQ_CODIGO.Trim() != "") : (a.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (a.COD_CENCOS.Trim() != "" || a.COD_CENCOS.Trim() == "") : (a.COD_CENCOS == CODATA.COD_CENCOS))
                              && (a.ESTADO == "A")
                              )
                               select new
                               {
                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,

                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   usu1 = a.USU1,
                                   usu2 = a.USU2,
                                   usu3 = a.USU3,
                                   estado = a.ESTADO,
                                   data14 = (from R in (from R in ctx.tabla_avances
                                                        where R.TR_CODIGO == a.TR_CODIGO
                                                        orderby R.FECHA descending
                                                        select new { R.ACUMULADO, Dummy = "x" })
                                             group R by new { R.Dummy } into g
                                             select new
                                             {
                                                 Column1 = ((decimal?)g.Max(p => p.ACUMULADO))
                                             }
                                          ).FirstOrDefault().Column1,
                                   obs = a.OBSERVACIONES,
                                   fecha = a.FECHA,
                                   //lista = ((from b in ctx.tabla_detalle
                                   //            where b.TR_CODIGO == a.TR_CODIGO
                                   //            select new { b.NUM_DOC }).ToArray()),

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
                               FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                               USU1 = c.usu1,
                               USU2 = c.usu2,
                               USU3 = c.usu3,
                               ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                               acumulado = Convert.ToDecimal(c.data14),
                               OBSERVACIONES = c.obs,
                               FECHA = c.fecha,
                               //documento=String.Join(",",c.lista),
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static tabla_trabajo ListarunTrabajos(string nrotra)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    var alumnos = (ctx.tabla_trabajo.Where(x => x.ESTADO == "A" && x.TR_CODIGO == nrotra)).FirstOrDefault();
                    return alumnos;
                }
            }
            catch (Exception)
            {

                throw;
            }


        }


        public static List<VISTA_DETALLE_TRABAJOCURSO> SUMDETALLE(tabla_trabajo CODATA)
        {
            var alumnos = new List<VISTA_DETALLE_TRABAJOCURSO>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ((from a in ctx.AL0003REQC
                                where a.RC_CNUMOT == CODATA.TR_CODIGO
                                select new
                                {
                                    data1 = (from R in (from R in ctx.AL0003REQC
                                                        where R.RC_CNUMOT == CODATA.TR_CODIGO
                                                        select new { R.RC_NIMPMN, Dummy = "x" })
                                             group R by new { R.Dummy } into g
                                             select new
                                             {
                                                 Column1 = ((decimal?)g.Sum(p => p.RC_NIMPMN))
                                             }
                                          ).FirstOrDefault().Column1,
                                    data2 = (from R in (from R in ctx.AL0003REQC
                                                        where R.RC_CNUMOT == CODATA.TR_CODIGO
                                                        select new { R.RC_NIMPUS, Dummy = "x" })
                                             group R by new { R.Dummy } into g
                                             select new
                                             {
                                                 Column1 = ((decimal?)g.Sum(p => p.RC_NIMPUS))
                                             }
                                          ).FirstOrDefault().Column1,

                                    data3 = a.RC_CCODMON,


                                }
                                     ).Union(from b in ctx.CO0003MOVC
                                             where b.OC_CRESPER3 == CODATA.TR_CODIGO
                                             select new
                                             {
                                                 data1 = (from R in (from R in ctx.CO0003MOVC
                                                                     where R.OC_CRESPER3 == CODATA.TR_CODIGO
                                                                     select new { R.OC_NIMPMN, Dummy = "x" })
                                                          group R by new { R.Dummy } into g
                                                          select new
                                                          {
                                                              Column1 = ((decimal?)g.Sum(p => p.OC_NIMPMN))
                                                          }
                                          ).FirstOrDefault().Column1,
                                                 data2 = (from R in (from R in ctx.CO0003MOVC
                                                                     where R.OC_CRESPER3 == CODATA.TR_CODIGO
                                                                     select new { R.OC_NIMPUS, Dummy = "x" })
                                                          group R by new { R.Dummy } into g
                                                          select new
                                                          {
                                                              Column1 = ((decimal?)g.Sum(p => p.OC_NIMPUS))
                                                          }
                                          ).FirstOrDefault().Column1,

                                                 data3 = b.OC_CCODMON,
                                             })
                               ).ToList()
                          .Select(c => new VISTA_DETALLE_TRABAJOCURSO()
                          {
                              MONTO = (c.data3.Trim() == "MN" ? Convert.ToDecimal(c.data1) : Convert.ToDecimal(c.data2)),
                          }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_TRABAJO> ListaInicio(VISTA_TRABAJO CODATA)
        {
            var resultado = new List<VISTA_TRABAJO>();

            try
            {
                var ctx = new ANEXO_RSFACAR();

                var alumnos = (from a in ctx.tabla_trabajo.Where(x =>
                                ((CODATA.AE_COD == -1) ? (x.AE_COD == -1 || x.AE_COD != 0) : (x.AE_COD == CODATA.AE_COD))
                              && ((CODATA.ESTADO == "T") ? (x.ESTADO == "T" || x.ESTADO != "") : (x.ESTADO == CODATA.ESTADO))
                              && ((CODATA.PL_CODIGO == "-1") ? (x.PL_CODIGO != "-1" || x.PL_CODIGO.Trim() != "") : (x.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (x.EQ_CODIGO != "-1" || x.EQ_CODIGO.Trim() != "") : (x.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (x.COD_CENCOS.Trim() != "" || x.COD_CENCOS.Trim() == "") : (x.COD_CENCOS == CODATA.COD_CENCOS))
                              && (x.FECHA >= CODATA.FECHA && x.FECHA <= CODATA.FECHAFIN)
                              && (x.FINALIZADO == "N")
                              )


                               select new
                               {
                                   TIPO = ((from b in ctx.tabla_trabajo_tipo
                                            where b.COD == a.COD_TIPO
                                            select new { b.TIPO }).FirstOrDefault().TIPO),

                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   cod_area = a.AE_COD,
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                   cod_centro = a.COD_CENCOS,
                                   obs = a.OBSERVACIONES,
                                   presupuesto = a.PRESUPUESTO,
                                   estado = a.ESTADO,
                                   codmon = a.COD_MON,
                                   moneda = a.MONEDA,
                                   USU1 = a.USU1,
                                   USU2 = a.USU2,
                                   USU3 = a.USU3,
                                   ADICIONAL = a.PORC_ADICIONAL,
                                   PRESINI = a.PI_INICIAL,
                                   PORINI = a.PORC_INICIAL,
                                   PI_MANOBRA = a.PI_MANOBRA,
                                   PI_MATERIALES = a.PI_MATERIALES,
                                   PI_EQUIPOS = a.PI_EQUIPOS

                               }).ToArray();

                resultado = (from al in alumnos
                                 // join det in detalle on al.TAREA.Trim() equals det.data7.Trim()
                             select new
                             {
                                 TIPO = al.TIPO,
                                 TAREA = al.TAREA,
                                 CONTRATISTA = al.CONTRATISTA,
                                 CENTROCOSTO = al.CENTROCOSTO,
                                 DESCRIPCION = al.DESCRIPCION,
                                 CONTROLACTIVOS = al.CONTROLACTIVOS,
                                 FECHA = al.FECHA,

                                 AREA = ((from b in ctx.tabla_subareas
                                          where b.SA_ID == al.cod_area
                                          select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                 PLANTA = ((from b in ctx.tabla_planta
                                            where b.PL_CODIGO == al.cod_planta
                                            select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                 EQUIPOS = ((from b in ctx.tabla_equipo
                                             where b.EQ_CODIGO == al.eq_equipo
                                             select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                 usu1 = al.USU1,
                                 usu2 = al.USU2,
                                 usu3 = al.USU3,
                                 estado = al.estado,
                                 fecha = al.FECHA,
                                 moneda = al.moneda,
                                 sumas = tabla_trabajo.obtenproyectado(al.TAREA, al.codmon),
                                 PRESUPUESTO = (al.PRESINI * (al.PORINI / 100)) + al.PRESINI,
                                 sumaacum = tabla_trabajo.obtenacumulado(al.TAREA, al.codmon),

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
                              FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                              USU1 = c.usu1,
                              USU2 = c.usu2,
                              USU3 = c.usu3,
                              ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                              FECHA = c.fecha,
                              acumulado = c.sumas,
                              PRESUPUESTO = Convert.ToDecimal(c.PRESUPUESTO),
                              PRES_MANOBRA = (c.sumas / Convert.ToDecimal(c.PRESUPUESTO)) * 100,
                              PRES_MATERIAL = c.sumaacum,
                              PRES_EQUIPOS = ((c.sumaacum / Convert.ToDecimal(c.PRESUPUESTO)) * 100),
                              TIPO = c.TIPO

                          }).ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }



        public static List<VISTA_TRABAJO> LISTADODETRABAJOS(VISTA_TRABAJO CODATA)
        {
            var resultado = new List<VISTA_TRABAJO>();

            try
            {
                var ctx = new ANEXO_RSFACAR();

                var alumnos = (from a in ctx.tabla_trabajo.Where(x =>
                                ((CODATA.AE_COD == -1) ? (x.AE_COD == -1 || x.AE_COD != 0) : (x.AE_COD == CODATA.AE_COD))
                              && ((CODATA.ESTADO == "T") ? (x.ESTADO == "T" || x.ESTADO != "") : (x.ESTADO == CODATA.ESTADO))
                              && ((CODATA.PL_CODIGO == "-1") ? (x.PL_CODIGO != "-1" || x.PL_CODIGO.Trim() != "") : (x.PL_CODIGO.Trim() == CODATA.PL_CODIGO.Trim()))
                              && ((CODATA.EQ_CODIGO == "-1") ? (x.EQ_CODIGO != "-1" || x.EQ_CODIGO.Trim() != "") : (x.EQ_CODIGO == CODATA.EQ_CODIGO))
                              && ((CODATA.COD_CENCOS == "-1") ? (x.COD_CENCOS.Trim() != "" || x.COD_CENCOS.Trim() == "") : (x.COD_CENCOS == CODATA.COD_CENCOS))
                              && (x.FECHA >= CODATA.FECHA && x.FECHA <= CODATA.FECHAFIN)
                              )


                               select new
                               {
                                   TIPO = ((from b in ctx.tabla_trabajo_tipo
                                            where b.COD == a.COD_TIPO
                                            select new { b.TIPO }).FirstOrDefault().TIPO),

                                   TAREA = a.TR_CODIGO,
                                   CONTRATISTA = a.CONTRATISTA,
                                   CENTROCOSTO = a.CENTRO_COSTO,
                                   DESCRIPCION = a.DESCRIPCION,
                                   CONTROLACTIVOS = a.CONTROL_ACTIVOS,
                                   FECHA = a.FECHA,
                                   AREA = ((from b in ctx.tabla_subareas
                                            where b.SA_ID == a.AE_COD
                                            select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                   cod_area = a.AE_COD,
                                   PLANTA = ((from b in ctx.tabla_planta
                                              where b.PL_CODIGO == a.PL_CODIGO
                                              select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                   cod_planta = a.PL_CODIGO,
                                   EQUIPOS = ((from b in ctx.tabla_equipo
                                               where b.EQ_CODIGO == a.EQ_CODIGO
                                               select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                   eq_equipo = a.EQ_CODIGO,
                                   cod_centro = a.COD_CENCOS,
                                   obs = a.OBSERVACIONES,
                                   presupuesto = a.PRESUPUESTO,
                                   estado = a.ESTADO,
                                   codmon = a.COD_MON,
                                   moneda = a.MONEDA,
                                   USU1 = a.USU1,
                                   USU2 = a.USU2,
                                   USU3 = a.USU3,
                                   ADICIONAL = a.PORC_ADICIONAL,
                                   PRESINI = a.PI_INICIAL,
                                   PORINI = a.PORC_INICIAL,
                                   PI_MANOBRA = a.PI_MANOBRA,
                                   PI_MATERIALES = a.PI_MATERIALES,
                                   PI_EQUIPOS = a.PI_EQUIPOS

                               }).ToArray();

                resultado = (from al in alumnos
                                 // join det in detalle on al.TAREA.Trim() equals det.data7.Trim()
                             select new
                             {
                                 TIPO = al.TIPO,
                                 TAREA = al.TAREA,
                                 CONTRATISTA = al.CONTRATISTA,
                                 CENTROCOSTO = al.CENTROCOSTO,
                                 DESCRIPCION = al.DESCRIPCION,
                                 CONTROLACTIVOS = al.CONTROLACTIVOS,
                                 FECHA = al.FECHA,

                                 AREA = ((from b in ctx.tabla_subareas
                                          where b.SA_ID == al.cod_area
                                          select new { b.SA_DESC }).FirstOrDefault().SA_DESC),
                                 PLANTA = ((from b in ctx.tabla_planta
                                            where b.PL_CODIGO == al.cod_planta
                                            select new { b.PL_DESCRIPCION }).FirstOrDefault().PL_DESCRIPCION),
                                 EQUIPOS = ((from b in ctx.tabla_equipo
                                             where b.EQ_CODIGO == al.eq_equipo
                                             select new { b.EQ_DESCRIPCION }).FirstOrDefault().EQ_DESCRIPCION),
                                 usu1 = al.USU1,
                                 usu2 = al.USU2,
                                 usu3 = al.USU3,
                                 estado = al.estado,
                                 fecha = al.FECHA,
                                 moneda = al.moneda,
                                 sumas = tabla_trabajo.obtenproyectado(al.TAREA, al.codmon),
                                 PRESUPUESTO = (al.PRESINI * (al.PORINI / 100)) + al.PRESINI,
                                 sumaacum = tabla_trabajo.obtenacumulado(al.TAREA, al.codmon),

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
                              FECH = Convert.ToDateTime(c.FECHA).ToString("dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture),
                              USU1 = c.usu1,
                              USU2 = c.usu2,
                              USU3 = c.usu3,
                              ESTADO = (c.estado == "A" ? "APROBADO" : "EMITIDO"),
                              FECHA = c.fecha,
                              acumulado = c.sumas,
                              PRESUPUESTO = Convert.ToDecimal(c.PRESUPUESTO),
                              PRES_MANOBRA = (c.sumas / Convert.ToDecimal(c.PRESUPUESTO)) * 100,
                              PRES_MATERIAL = c.sumaacum,
                              PRES_EQUIPOS = ((c.sumaacum / Convert.ToDecimal(c.PRESUPUESTO)) * 100),
                              TIPO = c.TIPO

                          }).ToList();

            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public static decimal? obtenproyectado(string TRABAJO, string MONEDA)
        {
            var TRAB = new tabla_trabajo();
            TRAB.TR_CODIGO = TRABAJO;
            TRAB.COD_MON = MONEDA;
            var tc3 = tabla_detalle.DETALLE(TRAB);
            var acumulado = (decimal?)(0);
            foreach (var t in tc3)
            {
                acumulado = acumulado + (MONEDA.Trim() == "MN" ? t.MONTOMN : t.MONTOUS);
            }
            return acumulado;
        }
        public static decimal? obtenacumulado(string TRABAJO, string MONEDA)
        {
            var TRAB = new tabla_trabajo();
            TRAB.TR_CODIGO = TRABAJO;
            TRAB.COD_MON = MONEDA;
            var tc3 = tabla_solicitud.DETALLE2(TRAB);
            var acumulado = (decimal?)(0);
            foreach (var t in tc3)
            {
                acumulado = acumulado + (MONEDA.Trim() == "MN" ? t.MONTOMN : t.MONTOUS);
            }
            return acumulado;
        }

    }
}
