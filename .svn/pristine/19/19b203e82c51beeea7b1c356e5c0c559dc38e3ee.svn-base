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
    using System.Data.Entity.SqlServer;

    using System.Data.SqlClient;

    public class vista_Transporte_Cabecera
    {
     
        [StringLength(11)]
        public string numero { get; set; }

        [StringLength(3)]
        public string codprocedencia { get; set; }

        [StringLength(3)]
        public string codplaca { get; set; }

        [StringLength(8)]
        public string codchofer { get; set; }

        [StringLength(3)]
        public string codturno { get; set; }

        [StringLength(8)]
        public string codvigilante { get; set; }

        [StringLength(50)]
        public string usuarioCreacion { get; set; }

        public TimeSpan? horaPartida { get; set; }

        public TimeSpan? horallegada { get; set; }

      
        public string detalle_chofer { get; set; }

      
        public string detalle_vigilante { get; set; }

        public string detalle_pasajero { get; set; }
        public string detalle_ccosto { get; set; }
        public string detalle_labor { get; set; }

        public string codpasajero { get; set; }

        public string placa { get; set; }

        public string procedencia { get; set; }

        public string paradero { get; set; }
        public string fechaCreacion { get; set; }

        public string turno { get; set; }
        

    }
    public partial class tabla_transporte_cabViaje
    {
        [Key]
        [StringLength(11)]
        public string numero { get; set; }

        [StringLength(3)]
        public string codprocedencia { get; set; }

        [StringLength(3)]
        public string codplaca { get; set; }

        [StringLength(8)]
        public string codchofer { get; set; }

        [StringLength(3)]
        public string codturno { get; set; }

        [StringLength(8)]
        public string codvigilante { get; set; }

        [StringLength(50)]
        public string usuarioCreacion { get; set; }

        public DateTime? fechaCreacion { get; set; }

        public TimeSpan? horaPartida { get; set; }

        public TimeSpan? horallegada { get; set; }

        [StringLength(50)]
        public string detalle_chofer { get; set; }

        [StringLength(50)]
        public string detalle_vigilante { get; set; }

        public static List<vista_Transporte_Cabecera> reporteBitacora(DateTime fechaini, DateTime fechafin)
        {
            //  var alumnos = new List<tabla_transporte_cabViaje>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {


                 var   alumnos1 = (from a in ctx.tabla_transporte_cabViaje
                                join b in ctx.tabla_transporte_detViaje on a.numero equals b.numero

                                  where

                               (   a.fechaCreacion >= fechaini && a.fechaCreacion <= fechafin)
                                   //(req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2 > 0
                                   //orderby
                                   // b.OC_CCODIGO,
                                   // a.OC_CRAZSOC
                                   select new
                                {
                                    numero = a.numero,
                                    codchofer = a.codchofer,
                                    detalle_chofer = a.detalle_chofer,
                                    codvigilante = a.codvigilante,
                                    detalle_vigilante = a.detalle_vigilante,
                                //    codplaca = a.codplaca,
                                    fechaCreacion = a.fechaCreacion,
                                    horallegada = a.horallegada,
                                    horaPartida = a.horaPartida,
                                    usuarioCreacion = a.usuarioCreacion,
                                    codpasajero = b.codpasajero,
                                    detalle_pasajero = b.detalle_pasajero,
                                    detalle_ccosto = b.detalle_ccosto,
                                    detalle_labor = b.detalle_labor,

                                    placa = (from x in ctx.tabla_transporte_vehiculo where x.cod == a.codplaca select new { x.placa }).FirstOrDefault().placa,
                                    procedencia = (from x in ctx.tabla_transporte_procedencia where x.cod == a.codprocedencia select new { x.procedencia }).FirstOrDefault().procedencia,
                                    paradero = (from x in ctx.tabla_transporte_paradero where x.cod == b.codparadero select new { x.paradero }).FirstOrDefault().paradero,

                                     turno = (from x in ctx.tabla_transporte_turno where x.cod == a.codturno select new { x.turno }).FirstOrDefault().turno

                                   }
                                          ).ToList()
                                             .Select(c => new vista_Transporte_Cabecera()
                                             {


                                                 //  OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.a),

                                                 numero = c.numero,
                                                 codchofer = c.codchofer,
                                                 detalle_chofer = c.detalle_chofer,
                                                 codvigilante = c.codvigilante,
                                                 detalle_vigilante = c.detalle_vigilante,
                                                 placa = c.placa,
                                                 fechaCreacion = String.Format("{0:dd/MM/yyyy}", c.fechaCreacion),
                                                 horallegada = c.horallegada,
                                                 horaPartida = c.horaPartida,
                                                 usuarioCreacion = c.usuarioCreacion,
                                                 codpasajero = c.codpasajero,
                                                 detalle_pasajero = c.detalle_pasajero,
                                                 detalle_ccosto = c.detalle_ccosto,
                                                 detalle_labor = c.detalle_labor,
                                                 procedencia=c.procedencia,
                                                 paradero=c.paradero,
                                                 turno=c.turno



                                             }).ToList();




                    return alumnos1;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public static List<vista_Transporte_Cabecera> MantenimientoBitacora(DateTime fechaini, DateTime fechafin)
        {
            //  var alumnos = new List<tabla_transporte_cabViaje>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {


                    var alumnos1 = (from a in ctx.tabla_transporte_cabViaje
                                    //join b in ctx.tabla_transporte_detViaje on a.numero equals b.numero

                                    where

                                 (a.fechaCreacion >= fechaini && a.fechaCreacion <= fechafin)
                                    //(req1).Contains(b.OC_CCODIGO) && b.OC_NPREUN2 > 0
                                    //orderby
                                    // b.OC_CCODIGO,
                                    // a.OC_CRAZSOC
                                    select new
                                    {
                                        numero = a.numero,
                                        codchofer = a.codchofer,
                                        detalle_chofer = a.detalle_chofer,
                                        codvigilante = a.codvigilante,
                                        detalle_vigilante = a.detalle_vigilante,
                                        //    codplaca = a.codplaca,
                                        fechaCreacion = a.fechaCreacion,
                                        horallegada = a.horallegada,
                                        horaPartida = a.horaPartida,
                                        usuarioCreacion = a.usuarioCreacion,
                                        //codpasajero = b.codpasajero,
                                        //detalle_pasajero = b.detalle_pasajero,
                                        //detalle_ccosto = b.detalle_ccosto,
                                        //detalle_labor = b.detalle_labor,

                                        placa = (from x in ctx.tabla_transporte_vehiculo where x.cod == a.codplaca select new { x.placa }).FirstOrDefault().placa,
                                        procedencia = (from x in ctx.tabla_transporte_procedencia where x.cod == a.codprocedencia select new { x.procedencia }).FirstOrDefault().procedencia,
                                        //paradero = (from x in ctx.tabla_transporte_paradero where x.cod == b.codparadero select new { x.paradero }).FirstOrDefault().paradero,

                                        turno = (from x in ctx.tabla_transporte_turno where x.cod == a.codturno select new { x.turno }).FirstOrDefault().turno

                                    }
                                             ).ToList()
                                                .Select(c => new vista_Transporte_Cabecera()
                                                {


                                                 //  OC_DFECDOC = String.Format("{0:dd/MM/yyyy}", c.a),

                                                 numero = c.numero,
                                                    codchofer = c.codchofer,
                                                    detalle_chofer = c.detalle_chofer,
                                                    codvigilante = c.codvigilante,
                                                    detalle_vigilante = c.detalle_vigilante,
                                                    placa = c.placa,
                                                    fechaCreacion = String.Format("{0:dd/MM/yyyy}", c.fechaCreacion),
                                                    horallegada = c.horallegada,
                                                    horaPartida = c.horaPartida,
                                                    usuarioCreacion = c.usuarioCreacion,
                                                    //codpasajero = c.codpasajero,
                                                    //detalle_pasajero = c.detalle_pasajero,
                                                    //detalle_ccosto = c.detalle_ccosto,
                                                    //detalle_labor = c.detalle_labor,
                                                    procedencia = c.procedencia,
                                                    //paradero = c.paradero,
                                                    turno = c.turno



                                                }).ToList();




                    return alumnos1;
                }
            }
            catch (Exception)
            {
                throw;
            }

        }


        public static string obtenNumeroBitacora()
        {
          //  var alumnos = new List<tabla_transporte_cabViaje>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    var alumnos = ctx.tabla_transporte_cabViaje.Max(x=>x.numero);
                    return ( Convert.ToInt32(  alumnos)+1).ToString("D11");
                }
            }
            catch (Exception)
            {
                throw;
            }
           
        }

        public static List<vista_Transporte_Cabecera> ListaTransporteCabecera()
        {
            var resultado = new List<vista_Transporte_Cabecera>();

            try
            {
                List<PersonalEmpresa> var_choferes = new List<PersonalEmpresa>();
                List<PersonalEmpresa> var_vigilantes = new List<PersonalEmpresa>();

                var_choferes = PersonalEmpresa.ListaPersonaPorCosto("00045");
                var_vigilantes = PersonalEmpresa.ListaPersonaPorCosto("00047");


                var ctx = new ANEXO_RSFACAR();
                resultado = (from y in ctx.tabla_transporte_cabViaje

                             select new
                             {
                                 codchofer = y.codchofer,// (from b in var_choferes where b.CodPer == y.codchofer select new { b.Detalle }).FirstOrDefault().Detalle,
                                 codvigilante =y.codvigilante,// (from b in var_vigilantes where b.CodPer == y.codchofer select new { b.Detalle }).FirstOrDefault().Detalle,
                            codplaca = (from b in ctx.tabla_transporte_vehiculo where b.cod == y.codplaca select new { b.placa }).FirstOrDefault().placa,
                            codprocedencia = (from b in ctx.tabla_transporte_procedencia where b.cod == y.codprocedencia select new { b.procedencia }).FirstOrDefault().procedencia,
                            codturno = (from b in ctx.tabla_transporte_turno where b.cod == y.codturno select new { b.turno }).FirstOrDefault().turno,
                            fechaCreacion = y.fechaCreacion,
                            horallegada = y.horallegada,
                            horaPartida = y.horaPartida,
                            numero = y.numero,
                            usuarioCreacion = y.usuarioCreacion
                        }

                    ).ToList().Select
                    (
                        c => new vista_Transporte_Cabecera()
                        {

                            codchofer = c.codchofer,//(from b in var_choferes where b.CodPer == c.codchofer select new { b.Detalle }).FirstOrDefault().Detalle,
                            codvigilante =c.codvigilante,//(from b in var_vigilantes where b.CodPer == c.codvigilante select new { b.Detalle }).FirstOrDefault().Detalle,
                            codplaca = c.codplaca,
                            codprocedencia = c.codprocedencia,
                            codturno = c.codturno,
                            //fechaCreacion = c.fechaCreacion,
                            horallegada = c.horallegada,
                            horaPartida = c.horaPartida,
                            numero = c.numero,
                            usuarioCreacion = c.usuarioCreacion

                        }
                    ).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return resultado;
        }
        public static void InsertaBitacoraCab(tabla_transporte_cabViaje ADDMC)
        {
                using (var ctx = new ANEXO_RSFACAR())
                {
                try
                {
                    ctx.Entry(ADDMC).State = EntityState.Added;
                    ctx.SaveChanges();
                }
                catch
                {
                   ctx.Entry(ADDMC).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
    }
                //catch (DbEntityValidationException dbEx)
                //{
                //    foreach (var validationErrors in dbEx.EntityValidationErrors)
                //    {
                //        foreach (var validationError in validationErrors.ValidationErrors)
                //        {
                //            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                //        }
                //    }
                   
                //}
            //}
        }
    
}
