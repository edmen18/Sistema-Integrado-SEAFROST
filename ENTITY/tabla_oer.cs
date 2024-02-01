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
            public partial class tabla_oer
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(10)]
        public string ORDEN_NUMERO { get; set; }

        public DateTime? FECHA { get; set; }

        [StringLength(20)]
        public string COD_SOLICITANTE { get; set; }

        public string SOLICITANTE { get; set; }

        [StringLength(10)]
        public string COD_BANCO { get; set; }

        [StringLength(50)]
        public string BANCO { get; set; }

        [StringLength(20)]
        public string NUMERO_CUENTA { get; set; }

        public decimal? MONTO { get; set; }
        public decimal? MONTO_DECLARADO { get; set; }

        public string MOTIVO { get; set; }

        [StringLength(10)]
        public string APROB1 { get; set; }

        [StringLength(10)]
        public string APROB2 { get; set; }

        [StringLength(10)]
        public string APROB3 { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public DateTime? FECHA_CREACION { get; set; }

        [StringLength(2)]
        public string MONEDA { get; set; }

        [StringLength(10)]
        public string USUMOD { get; set; }


        [StringLength(2)]
        public string SUBDIARIO { get; set; }

        [StringLength(6)]
        public string COMPROBANTE { get; set; }

        public DateTime? FECCOMP { get; set; }
        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO_CAJA { get; set; }
        public static Boolean insertaCabecera(tabla_oer datos)
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
        public static Boolean actualizaSolicitud(tabla_oer alumno)
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
        public static string GeneraNroSolicitud(int tipo)
        {
            var codigot = "";
            var valor = 0;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    codigot = ctx.tabla_oer.Where(x => x.CODIGO_CAJA == tipo).OrderByDescending(X => X.ORDEN_NUMERO).Select(X => X.ORDEN_NUMERO).FirstOrDefault();
                    if (codigot == null)
                    { valor = 0; }
                    else
                    {
                        valor = Convert.ToInt32(codigot);
                    }
                    codigot = Convert.ToString(valor);
                }
            }
            catch (Exception)
            {
                throw;
            }
            return codigot;
        }

        public static List<vista_oer_> ListarOER(tabla_oer CODATA)
        {
            var alumnos = new List<vista_oer_>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_oer.Where(x =>

                               (CODATA.COD_BANCO != "" ? x.COD_BANCO == CODATA.COD_BANCO : x.COD_BANCO != string.Empty)
                               &&
                               (CODATA.ESTADO != " " ? x.ESTADO == CODATA.ESTADO : x.ESTADO != CODATA.ESTADO)
                               &&
                               (CODATA.ORDEN_NUMERO != "" ? x.ORDEN_NUMERO == CODATA.ORDEN_NUMERO : x.ORDEN_NUMERO != CODATA.ORDEN_NUMERO)
                               &&
                                 (CODATA.CODIGO_CAJA == 2 ? x.CODIGO_CAJA == 2 : x.CODIGO_CAJA != 2)
                               &&
                               (CODATA.COD_SOLICITANTE != "" ? x.COD_SOLICITANTE == CODATA.COD_SOLICITANTE : x.COD_SOLICITANTE != string.Empty)

                                && ((x.FECHA >= CODATA.FECHA) && (x.FECHA <= CODATA.FECHA_CREACION))
                              ).OrderByDescending(x => new { x.FECHA })

                               select new
                               {
                                   ORDEN_NUMERO = a.ORDEN_NUMERO,
                                   CODIGO_CAJA = a.CODIGO_CAJA,
                                   FECHA = a.FECHA,
                                   COD_SOLICITANTE = a.COD_SOLICITANTE,
                                   SOLICITANTE = a.SOLICITANTE,
                                   COD_BANCO = a.COD_BANCO,
                                   BANCO = a.BANCO,
                                   NUMERO_CUENTA = a.NUMERO_CUENTA,
                                   MONTO = a.MONTO,
                                   MOTIVO = a.MOTIVO,
                                   APROB1 = a.APROB1,
                                   APROB2 = a.APROB2,
                                   APROB3 = a.APROB3,
                                   ESTADO = a.ESTADO,
                                   //CCOMPRO = a.CCOMPRO,
                                  // CCUENTA = a.CCUENTA,
                                   FECHA_CREACION = a.FECHA_CREACION,
                                   MONEDA = a.MONEDA,
                                   USUMOD = a.USUMOD,

                               }).ToList()
                          .Select(a => new vista_oer_()
                          {
                              ORDEN_NUMERO = a.ORDEN_NUMERO,
                              CODIGO_CAJA =Convert.ToString(a.CODIGO_CAJA),
                              FECHA = Convert.ToString(a.FECHA).Substring(0, 9),
                              COD_SOLICITANTE = Convert.ToString(a.COD_SOLICITANTE),
                              SOLICITANTE = a.SOLICITANTE,
                              COD_BANCO = a.COD_BANCO,
                              BANCO = a.BANCO,
                              NUMERO_CUENTA = a.NUMERO_CUENTA,
                              MONTO = Convert.ToString(a.MONTO),
                              MOTIVO = a.MOTIVO,
                              APROB1 = a.APROB1,
                              APROB2 = a.APROB2,
                              APROB3 = a.APROB3,
                              ESTADO = a.ESTADO,
                              //CCOMPRO = a.CCOMPRO,
                              //CCUENTA = a.CCUENTA,
                              FECHA_CREACION = Convert.ToString(a.FECHA_CREACION),
                              MONEDA = a.MONEDA,
                              USUMOD = a.USUMOD,
                              TIPO = ((from b in ctx.tabla_cajas
                                       join c in ctx.tabla_tipo_entrega on b.TIPO equals c.CODIGO_TIPO
                                       where b.CODIGO_CAJA == a.CODIGO_CAJA
                                       select new { c.DESCRIPCION }).FirstOrDefault().DESCRIPCION),
                              

                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<vista_oer_> ListarOERInicio(tabla_oer com)
        {
            var alumnos = new List<vista_oer_>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_oer.Where(x =>
                               (x.FECHA >= com.FECHA && x.FECHA <= com.FECHA_CREACION && x.CODIGO_CAJA==com.CODIGO_CAJA)

                              ).OrderByDescending(x => new { x.FECHA })

                               select new
                               {
                                   ORDEN_NUMERO = a.ORDEN_NUMERO,
                                   CODIGO_CAJA = a.CODIGO_CAJA,
                                   FECHA = a.FECHA,
                                   COD_SOLICITANTE = a.COD_SOLICITANTE,
                                   SOLICITANTE = a.SOLICITANTE,
                                   COD_BANCO = a.COD_BANCO,
                                   BANCO = a.BANCO,
                                   NUMERO_CUENTA = a.NUMERO_CUENTA,
                                   MONTO = a.MONTO,
                                   MOTIVO = a.MOTIVO,
                                   APROB1 = a.APROB1,
                                   APROB2 = a.APROB2,
                                   APROB3 = a.APROB3,
                                   ESTADO = a.ESTADO,
                                  // CCOMPRO = a.CCOMPRO,
                                  // CCUENTA = a.CCUENTA,
                                   FECHA_CREACION = a.FECHA_CREACION,
                                   MONEDA = a.MONEDA,
                                   USUMOD = a.USUMOD,

                               }).ToList()
                          .Select(a => new vista_oer_()
                          {
                              ORDEN_NUMERO = a.ORDEN_NUMERO,
                              CODIGO_CAJA =Convert.ToString(a.CODIGO_CAJA),
                              FECHA = Convert.ToString(a.FECHA),
                              COD_SOLICITANTE = a.COD_SOLICITANTE,
                              SOLICITANTE = a.SOLICITANTE,
                              COD_BANCO = a.COD_BANCO,
                              BANCO = a.BANCO,
                              NUMERO_CUENTA = a.NUMERO_CUENTA,
                              MONTO = Convert.ToString(a.MONTO),
                              MOTIVO = a.MOTIVO,
                              APROB1 = a.APROB1,
                              APROB2 = a.APROB2,
                              APROB3 = a.APROB3,
                              ESTADO = a.ESTADO,
                             // CCOMPRO = a.CCOMPRO,
                              //CCUENTA = a.CCUENTA,
                              FECHA_CREACION = Convert.ToString(a.FECHA_CREACION),
                              MONEDA = a.MONEDA,
                              USUMOD = a.USUMOD,
                              TIPO = ((from b in ctx.tabla_cajas
                                       join c in ctx.tabla_tipo_entrega on b.TIPO equals c.CODIGO_TIPO
                                       where b.CODIGO_CAJA == a.CODIGO_CAJA
                                       select new { c.DESCRIPCION }).FirstOrDefault().DESCRIPCION),

                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<vista_oer_> ListarUnDato(tabla_oer com)
        {
            var alumnos = new List<vista_oer_>();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_oer.Where(x =>
                               (x.ORDEN_NUMERO == com.ORDEN_NUMERO && x.CODIGO_CAJA==com.CODIGO_CAJA)

                              ).OrderByDescending(x => new { x.FECHA })

                               select new
                               {
                                   ORDEN_NUMERO = a.ORDEN_NUMERO,
                                   CODIGO_CAJA = a.CODIGO_CAJA,
                                   FECHA = a.FECHA,
                                   COD_SOLICITANTE = a.COD_SOLICITANTE,
                                   SOLICITANTE = a.SOLICITANTE,
                                   COD_BANCO = a.COD_BANCO,
                                   BANCO = a.BANCO,
                                   NUMERO_CUENTA = a.NUMERO_CUENTA,
                                   MONTO = a.MONTO,
                                   MOTIVO = a.MOTIVO,
                                   APROB1 = a.APROB1,
                                   APROB2 = a.APROB2,
                                   APROB3 = a.APROB3,
                                   ESTADO = a.ESTADO,
                                   //CCOMPRO = a.CCOMPRO,
                                  // CCUENTA = a.CCUENTA,
                                   FECHA_CREACION = a.FECHA_CREACION,
                                   MONEDA = a.MONEDA,
                                   USUMOD = a.USUMOD,

                               }).ToList()
                          .Select(a => new vista_oer_()
                          {
                              ORDEN_NUMERO = a.ORDEN_NUMERO,
                              CODIGO_CAJA = Convert.ToString(a.CODIGO_CAJA),
                              FECHA = Convert.ToString(a.FECHA),
                              COD_SOLICITANTE = a.COD_SOLICITANTE,
                              SOLICITANTE = a.SOLICITANTE,
                              COD_BANCO = a.COD_BANCO,
                              BANCO = a.BANCO,
                              NUMERO_CUENTA = a.NUMERO_CUENTA,
                              MONTO = Convert.ToString(a.MONTO),
                              MOTIVO = a.MOTIVO,
                              APROB1 = a.APROB1,
                              APROB2 = a.APROB2,
                              APROB3 = a.APROB3,
                              ESTADO = a.ESTADO,
                              //CCOMPRO = a.CCOMPRO,
                              //CCUENTA = a.CCUENTA,
                              FECHA_CREACION = Convert.ToString(a.FECHA_CREACION),
                              MONEDA = a.MONEDA,
                              USUMOD = a.USUMOD,

                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }
        public static List<vista_oer_> Imprimir(tabla_oer com)
        {
            var alumnos = new List<vista_oer_>();
            var cty = new RSFACAR();

            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_oer.Where(x =>
                               (x.ORDEN_NUMERO == com.ORDEN_NUMERO && x.CODIGO_CAJA == com.CODIGO_CAJA)

                              ).OrderByDescending(x => new { x.FECHA })

                               select new
                               {
                                   ORDEN_NUMERO = a.ORDEN_NUMERO,
                                   FECHA = a.FECHA,
                                   COD_SOLICITANTE = a.COD_SOLICITANTE,
                                   SOLICITANTE = a.SOLICITANTE,
                                   COD_BANCO = a.COD_BANCO,
                                   BANCO = a.BANCO,
                                   NUMERO_CUENTA = a.NUMERO_CUENTA,
                                   MONTO = a.MONTO,
                                   MOTIVO = a.MOTIVO,
                                   APROB1 = a.APROB1,
                                   APROB2 = a.APROB2,
                                   APROB3 = a.APROB3,
                                   ESTADO = a.ESTADO,
                                  // CCOMPRO = a.CCOMPRO,
                                  // CCUENTA = a.CCUENTA,
                                   FECHA_CREACION = a.FECHA_CREACION,
                                   MONEDA = a.MONEDA,
                                   USUMOD = a.USUMOD,
                                   CODIGO_TIPO = a.CODIGO_CAJA,
                                   CCOMPRO=a.COMPROBANTE,
                                   CCUENTA=a.SUBDIARIO,
                                   

                               }).ToList()
                          .Select(a => new vista_oer_()
                          {
                              ORDEN_NUMERO = a.ORDEN_NUMERO,
                              TIPO = a.CODIGO_TIPO + " " + ctx.tabla_cajas.Where(x => x.CODIGO_CAJA == a.CODIGO_TIPO).Select(f => f.DESCRIPCION).FirstOrDefault(),
                              FECHA = Convert.ToString(a.FECHA).Substring(0, 10),
                              COD_SOLICITANTE = a.COD_SOLICITANTE,
                              SOLICITANTE = a.SOLICITANTE,
                              COD_BANCO = a.COD_BANCO,
                              BANCO = a.BANCO,
                              NUMERO_CUENTA = a.NUMERO_CUENTA,
                              MONTO = Convert.ToString(a.MONTO),
                              MOTIVO = a.MOTIVO,
                              APROB1 = tabla_usuarios.ObtenUsuario(a.APROB1).TU_NOMUSU.ToUpper(),
                              APROB2 = tabla_usuarios.ObtenUsuario(a.APROB2).TU_NOMUSU.ToUpper(),
                              APROB3 = tabla_usuarios.ObtenUsuario(a.APROB3).TU_NOMUSU.ToUpper(),
                              ESTADO = a.ESTADO,
                              CCOMPRO = a.CCOMPRO ,
                              CCUENTA = a.CCUENTA,
                              FECHA_CREACION = Convert.ToString(a.FECHA_CREACION),
                              MONEDA = a.MONEDA,
                              USUMOD = a.USUMOD,
                              
                             
                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static List<vista_detalle_oer> Imprimir2(tabla_oer com)
        {
            var alumnos = new List<vista_detalle_oer>();
            var cty = new RSFACAR();

            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_oer join b in ctx.tabla_detalle_oer
                               on a.ORDEN_NUMERO + " " + a.CODIGO_CAJA equals b.ORDEN_NUMERO + " " + b.CODIGO_CAJA
                               where (a.ORDEN_NUMERO == com.ORDEN_NUMERO && a.CODIGO_CAJA == com.CODIGO_CAJA)
                               orderby (a.FECHA)

                               select new
                               {
                                   ORDEN_NUMERO = a.ORDEN_NUMERO,
                                   FECHA = a.FECHA,
                                   COD_SOLICITANTE = a.COD_SOLICITANTE,
                                   SOLICITANTE = a.SOLICITANTE,
                                   COD_BANCO = a.COD_BANCO,
                                   BANCO = a.BANCO,
                                   NUMERO_CUENTA = a.NUMERO_CUENTA,
                                   MONTO = a.MONTO,
                                   MOTIVO = a.MOTIVO,
                                   APROB1 = a.APROB1,
                                   APROB2 = a.APROB2,
                                   APROB3 = a.APROB3,
                                   ESTADO = a.ESTADO,
                                   FECHA_CREACION = a.FECHA_CREACION,
                                   MONEDA = a.MONEDA,
                                   USUMOD = a.USUMOD,
                                   CODIGO_TIPO = a.CODIGO_CAJA,
                                   // DETALLE
                                   PROVEEDOR = b.PROVEEDOR,
                                   RUC = b.RUC,
                                   TIPO_DOCUMENTO = b.TIPO_DOCUMENTO,
                                   NUM_DOCUMENTO = b.NUM_DOCUMENTO,
                                   FECHA_EMISION = b.FECHA_EMISION,
                                   IGV = b.IGV,
                                   MONTO_IGV = b.MONTO_IGV,
                                   PARCIAL = b.PARCIAL,
                                   TOTAL = b.TOTAL,
                                   //CCOMPRO = b.CCOMPRO,
                                   GLOSA_COMPROBANTE = b.GLOSA_COMPROBANTE,
                                   GLOSA_MOVIMIENTO = b.GLOSA_MOVIMIENTO,
                                   MONTO_DECLARADO = a.MONTO_DECLARADO,
                                   CCOMPRO = a.COMPROBANTE,
                                   CCUENTA = a.SUBDIARIO,
                               }).ToList()
                          .Select(a => new vista_detalle_oer()
                          {
                              ORDEN_NUMERO = a.ORDEN_NUMERO,
                              TIPO =a.CODIGO_TIPO + " " + ctx.tabla_cajas.Where(x => x.CODIGO_CAJA == a.CODIGO_TIPO).Select(f => f.DESCRIPCION).FirstOrDefault(),
                              FECHA = Convert.ToString(a.FECHA).Substring(0, 10),
                              COD_SOLICITANTE = a.COD_SOLICITANTE,
                              SOLICITANTE = a.SOLICITANTE,
                              COD_BANCO = a.COD_BANCO,
                              BANCO = a.BANCO,
                              NUMERO_CUENTA = a.NUMERO_CUENTA,
                              MONTO = Convert.ToString(a.MONTO),
                              MOTIVO = a.MOTIVO,
                              APROB1 = tabla_usuarios.ObtenUsuario(a.APROB1).TU_NOMUSU.ToUpper(),
                              APROB2 = tabla_usuarios.ObtenUsuario(a.APROB2).TU_NOMUSU.ToUpper(),
                              APROB3 = tabla_usuarios.ObtenUsuario(a.APROB3).TU_NOMUSU.ToUpper(),
                              ESTADO = a.ESTADO,
                              FECHA_CREACION = Convert.ToString(a.FECHA_CREACION),
                              MONEDA = a.MONEDA,
                              USUMOD = a.USUMOD,
                              MONTO_DECLARADO = Convert.ToString(a.MONTO_DECLARADO),


                              // DETALLE

                              PROVEEDOR = a.PROVEEDOR,
                              RUC = a.RUC,
                              TIPO_DOCUMENTO = a.TIPO_DOCUMENTO,
                              NUM_DOCUMENTO = a.NUM_DOCUMENTO,
                              FECHA_EMISION = Convert.ToString(a.FECHA_EMISION).Substring(0, 10),
                              IGV = Convert.ToString(a.IGV),
                              MONTO_IGV = Convert.ToString(a.MONTO_IGV),
                              PARCIAL = Convert.ToString(a.PARCIAL),
                              TOTAL = Convert.ToString(a.TOTAL),
                              //CCOMPRO = a.CCOMPRO,
                              GLOSA_COMPROBANTE = a.GLOSA_COMPROBANTE,
                              GLOSA_MOVIMIENTO = a.GLOSA_MOVIMIENTO,
                              CCOMPRO = a.CCOMPRO,
                              CCUENTA = a.CCUENTA,

                          }).ToList();

                }

            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

        public static void ActualizarEstado(tabla_oer COM)
        {
            var solicitud = new tabla_oer { ORDEN_NUMERO = COM.ORDEN_NUMERO, CODIGO_CAJA=COM.CODIGO_CAJA };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_oer.Attach(solicitud);
                solicitud.ESTADO = COM.ESTADO;
                solicitud.MONTO_DECLARADO = COM.MONTO_DECLARADO;
                solicitud.SUBDIARIO = COM.SUBDIARIO;
                solicitud.COMPROBANTE = COM.COMPROBANTE;
                solicitud.FECCOMP = COM.FECCOMP;
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }



    }
}
