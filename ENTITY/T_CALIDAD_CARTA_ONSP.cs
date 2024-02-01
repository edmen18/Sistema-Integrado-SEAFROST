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
    public partial class T_CALIDAD_CARTA_ONSP
    {
        [Key]
        [StringLength(4)]
        public string NUM_CARTA2 { get; set; }

        public DateTime? FECHA { get; set; }

        [StringLength(50)]
        public string COD_PROV { get; set; }

        [StringLength(500)]
        public string RAZONSOCIAL { get; set; }

        [StringLength(500)]
        public string ATENCION { get; set; }

        [StringLength(200)]
        public string REFERENCIA { get; set; }

        [StringLength(100)]
        public string SOLICITANTE { get; set; }

        [StringLength(100)]
        public string DIRECCION { get; set; }

        [StringLength(4)]
        public string PRODUCTO { get; set; }

        [StringLength(50)]
        public string HABILITACION { get; set; }

        [StringLength(100)]
        public string DIRECCIONPLANTA { get; set; }

        public decimal? CANTIDAD { get; set; }

        [StringLength(50)]
        public string EMBALAGE { get; set; }

        public decimal? PESOBRUTO { get; set; }

        [StringLength(4)]
        public string DESTINO { get; set; }

        [StringLength(50)]
        public string PUERTO_EMBARQUE { get; set; }

        [StringLength(50)]
        public string PUERTO_DESTINO { get; set; }

        [StringLength(50)]
        public string MEDIO_TRANSPORTE { get; set; }

        [StringLength(50)]
        public string DESTINATARIO { get; set; }

        public DateTime? FECHA_EMBARQUE { get; set; }

        [StringLength(200)]
        public string REFERENCIA_EMBARQUE { get; set; }

        [StringLength(500)]
        public string DATOS_ADICIONALES { get; set; }

        public static List<VISTA_CARTASIS> LISTARTTODOS(T_CALIDAD_CARTA_IS CODATA)
        {
            var alumnos = new List<VISTA_CARTASIS>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_CARTA_IS.Where(x => x.FECHA >= CODATA.FECHA && x.FECHA <= CODATA.FECHA_INSPECCION)
                               select new
                               {
                                   NUMCARTA = a.NUM_CARTA,
                                   PARA = a.PARA,
                                   DE = a.DE,
                                   FECHA = a.FECHA,
                                   ORDENTRABAJO = a.ORDEN_TRABAJO,
                                   TIPO_ANALISIS = a.TIPO_ANALISIS,
                                   tIPO_CERTIFICADO = a.TIPO_CERTIFICADO,
                                   PRODUCTOR = a.PRODUCTOR,
                                   HABILITACION = a.HABILITACION,
                                   PRODUCTO = a.PRODUCTO,
                                   ENVASE = a.ENVASE,
                                   LOTES = a.LOTES,
                                   ESPECIFICACION_INTERNA = a.ESPECIFICACION_INTERNA,
                                   DESTINO = a.DESTINO,
                                   LUGAR = a.LUGAR,
                                   FECHA_INSP = a.FECHA_INSPECCION,
                                   CC = a.CC,
                                   RAZONSOCIAL = a.RAZONSOCIAL,
                                   //OBTENEMOS LAS DESCRIPCIONES DE LOS CODIGOS QUE SE MENCUENTRAN EN LA TABLA PRINCIPAL

                                   TA_DESCRIPCION = ((from b in ctx.T_CALIDAD_TIPO_ANALISIS
                                                      where b.TA_CODIGO.Trim() == a.TIPO_ANALISIS
                                                      select new { b.TA_DESCRIPCION }).FirstOrDefault().TA_DESCRIPCION),
                                   TC_DESCRIPCION = ((from b in ctx.T_CALIDAD_TIPO_CERTIFICADO
                                                      where b.TC_CODIGO.Trim() == a.TIPO_CERTIFICADO
                                                      select new { b.TC_DESCRIPCION }).FirstOrDefault().TC_DESCRIPCION),
                                   PR_DESCRIPCION = ((from b in ctx.T_CALIDAD_PRODUCTO
                                                      where b.PR_CODIGO.Trim() == a.PRODUCTO
                                                      select new { b.PR_DESCRIPCION }).FirstOrDefault().PR_DESCRIPCION),
                                   ENV_DESCRIPCION = ((from b in ctx.T_CALIDAD_ENVASE
                                                       where b.ENV_CODIGO.Trim() == a.ENVASE
                                                       select new { b.ENV_DESCRIPCION }).FirstOrDefault().ENV_DESCRIPCION),
                                   DST_DESCRIPCION = ((from b in ctx.T_CALIDAD_DESTINO
                                                       where b.DST_CODIGO.Trim() == a.DESTINO
                                                       select new { b.DST_DESCRIPCION }).FirstOrDefault().DST_DESCRIPCION),


                               }).ToList()
                           .Select(c => new VISTA_CARTASIS()
                           {
                               //OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.fechoc),
                               NUM_CARTA = c.NUMCARTA + "-" + String.Format("{0:dd/MM/yyyy}", c.FECHA).Substring(6, 4),
                               PARA = c.PARA,
                               DE = c.DE,
                               FECHA_E = String.Format("{0:dd/MM/yyyy}", c.FECHA),
                               ORDEN_TRABAJO = c.ORDENTRABAJO,
                               TIPO_ANALISIS = c.TIPO_ANALISIS,
                               TIPO_CERTIFICADO = c.tIPO_CERTIFICADO,
                               PRODUCTOR = c.PRODUCTOR,
                               HABILITACION = c.HABILITACION,
                               PRODUCTO = c.PRODUCTO,
                               ENVASE = c.ENVASE,
                               LOTES = c.LOTES,
                               ESPECIFICACION_INTERNA = c.ESPECIFICACION_INTERNA,
                               DESTINO = c.DESTINO,
                               LUGAR = c.LUGAR,
                               FECHA_I = String.Format("{0:dd/MM/yyyy}", c.FECHA_INSP),
                               CC = c.CC,
                               RAZONSOCIAL = c.RAZONSOCIAL,
                               //OBTENEMOS LAS DESCRIPCIONES DE LOS CODIGOS QUE SE MENCUENTRAN EN LA TABLA PRINCIPAL
                               TA_DESCRIPCION = c.TA_DESCRIPCION,
                               TC_DESCRIPCION = c.TC_DESCRIPCION,
                               PR_DESCRIPCION = c.PR_DESCRIPCION,
                               ENV_DESCRIPCION = c.ENV_DESCRIPCION,
                               DST_DESCRIPCION = c.DST_DESCRIPCION,
                           }).ToList();

                }



            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<VISTA_CARTASIS> getdatos(VISTA_CARTASIS CODATA)
        {
            var alumnos = new List<VISTA_CARTASIS>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.T_CALIDAD_CARTA_IS.Where(x => x.NUM_CARTA == CODATA.NUM_CARTA
                               && x.FECHA.Value.Year == CODATA.FECHA.Value.Year
                               )
                               select new
                               {
                                   NUMCARTA = a.NUM_CARTA,
                                   PARA = a.PARA,
                                   DE = a.DE,
                                   FECHA = a.FECHA,
                                   ORDENTRABAJO = a.ORDEN_TRABAJO,
                                   TIPO_ANALISIS = a.TIPO_ANALISIS,
                                   tIPO_CERTIFICADO = a.TIPO_CERTIFICADO,
                                   PRODUCTOR = a.PRODUCTOR,
                                   HABILITACION = a.HABILITACION,
                                   PRODUCTO = a.PRODUCTO,
                                   ENVASE = a.ENVASE,
                                   LOTES = a.LOTES,
                                   ESPECIFICACION_INTERNA = a.ESPECIFICACION_INTERNA,
                                   DESTINO = a.DESTINO,
                                   LUGAR = a.LUGAR,
                                   FECHA_INSP = a.FECHA_INSPECCION,
                                   CC = a.CC,
                                   RAZONSOCIAL = a.RAZONSOCIAL,

                                   TA_DESCRIPCION = ((from b in ctx.T_CALIDAD_TIPO_ANALISIS
                                                      where b.TA_CODIGO.Trim() == a.TIPO_ANALISIS
                                                      select new { b.TA_DESCRIPCION }).FirstOrDefault().TA_DESCRIPCION),
                                   TC_DESCRIPCION = ((from b in ctx.T_CALIDAD_TIPO_CERTIFICADO
                                                      where b.TC_CODIGO.Trim() == a.TIPO_CERTIFICADO
                                                      select new { b.TC_DESCRIPCION }).FirstOrDefault().TC_DESCRIPCION),
                                   PR_DESCRIPCION = ((from b in ctx.T_CALIDAD_PRODUCTO
                                                      where b.PR_CODIGO.Trim() == a.PRODUCTO
                                                      select new { b.PR_DESCRIPCION }).FirstOrDefault().PR_DESCRIPCION),
                                   ENV_DESCRIPCION = ((from b in ctx.T_CALIDAD_ENVASE
                                                       where b.ENV_CODIGO.Trim() == a.ENVASE
                                                       select new { b.ENV_DESCRIPCION }).FirstOrDefault().ENV_DESCRIPCION),
                                   DST_DESCRIPCION = ((from b in ctx.T_CALIDAD_DESTINO
                                                       where b.DST_CODIGO.Trim() == a.DESTINO
                                                       select new { b.DST_DESCRIPCION }).FirstOrDefault().DST_DESCRIPCION),


                               }).ToList()
                           .Select(c => new VISTA_CARTASIS()
                           {
                               NUM_CARTA = c.NUMCARTA,
                               complemento = "-" + String.Format("{0:dd/MM/yyyy}", c.FECHA).Substring(6, 4),
                               PARA = c.PARA,
                               DE = c.DE,
                               FECHA_E = String.Format("{0:dd/MM/yyyy}", c.FECHA),
                               ORDEN_TRABAJO = c.ORDENTRABAJO,
                               TIPO_ANALISIS = c.TIPO_ANALISIS,
                               TIPO_CERTIFICADO = c.tIPO_CERTIFICADO,
                               PRODUCTOR = c.PRODUCTOR,
                               HABILITACION = c.HABILITACION,
                               PRODUCTO = c.PRODUCTO,
                               ENVASE = c.ENVASE,
                               LOTES = c.LOTES,
                               ESPECIFICACION_INTERNA = c.ESPECIFICACION_INTERNA,
                               DESTINO = c.DESTINO,
                               LUGAR = c.LUGAR,
                               FECHA_I = String.Format("{0:dd/MM/yyyy}", c.FECHA_INSP),
                               CC = c.CC,
                               RAZONSOCIAL = c.RAZONSOCIAL,
                               //OBTENEMOS LAS DESCRIPCIONES DE LOS CODIGOS QUE SE MENCUENTRAN EN LA TABLA PRINCIPAL
                               TA_DESCRIPCION = c.TA_DESCRIPCION,
                               TC_DESCRIPCION = c.TC_DESCRIPCION,
                               PR_DESCRIPCION = c.PR_DESCRIPCION,
                               ENV_DESCRIPCION = c.ENV_DESCRIPCION,
                               DST_DESCRIPCION = c.DST_DESCRIPCION,
                           }).ToList();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }


        public static Boolean insertaSolicitud(T_CALIDAD_CARTA_IS alumno)
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

        public static Boolean actualizaSolicitud(T_CALIDAD_CARTA_IS alumno)
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
        public static string GeneraNroSolicitud(string solicitud)

        {
            var codigo = new T_CALIDAD_CARTA_IS();
            var valor = "";
            int valor1 = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigo = ctx.T_CALIDAD_CARTA_IS.Where(x => x.NUM_CARTA != solicitud).OrderByDescending(x => new { x.FECHA, x.NUM_CARTA }).First();
                    valor = codigo.NUM_CARTA;
                    valor1 = Convert.ToInt32(valor) + 1;
                    valor = Convert.ToString(valor1);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return valor;
        }












    }

}
