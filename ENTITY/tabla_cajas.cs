namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    using System.Data.Entity.SqlServer;

    public partial class tabla_cajas
    {
        [Key]
        public int CODIGO_CAJA { get; set; }

        [StringLength(6)]
        public string USUARIO { get; set; }

        [StringLength(100)]
        public string PROPIETARIO { get; set; }
        public string DESCRIPCION { get; set; }

        public decimal? MONTO_FIJO { get; set; }

        public decimal? PORCENTAJE { get; set; }

        public decimal? MONTO_ACTUAL { get; set; }

        public decimal? SALDO_INICIAL { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public string CUENTA { get; set; }
        public string ANEXO_PROPIETARIO { get; set; }
        public int? TIPO { get; set; }
        public int? FLAG { get; set; }
        //public string DESCRIPCION { get; set; }

        //public static List<tabla_cajas> listarCajas(tabla_cajas PDATA)
        //{
        //    var data = new List<tabla_cajas>();

        //    try
        //    {
        //        using (var ctx = new ANEXO_RSFACAR())
        //        {
        //           data = ctx.tabla_cajas.Where(x => x.TIPO == PDATA.TIPO && x.USUARIO == PDATA.USUARIO).ToList();
        //        }
        //    }
        //    catch (Exception)
        //    {

        //        throw;
        //    }

        //    return data;
        //}
        public static List<tabla_cajas> listarCajas(tabla_cajas PDATA)
        {
            var data = new List<tabla_cajas>();
            var cty = new RSCONCAR();    
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    data = (from x in ctx.tabla_cajas
                            where x.TIPO == PDATA.TIPO && 
                            (PDATA.USUARIO !=""? x.USUARIO == PDATA.USUARIO: x.USUARIO != PDATA.USUARIO)
                            && x.ESTADO == "1"
                            select new
                            {
                                CODIGO_CAJA = x.CODIGO_CAJA,
                                PROPIETARIO = x.PROPIETARIO,
                                DNI = x.ANEXO_PROPIETARIO,
                                MONTO = x.MONTO_FIJO,
                                CUENTA=x.CUENTA,
                            }
                            ).ToList().Select(d => new tabla_cajas()
                            {
                                CODIGO_CAJA = d.CODIGO_CAJA,
                                USUARIO = Convert.ToString(d.CODIGO_CAJA) + "-" + d.PROPIETARIO,
                                PROPIETARIO = cty.CT0003ANEX.Where(X => X.ACODANE.Trim() == d.DNI.Trim() && X.AVANEXO.Trim() == "T").Select(X => X.ADESANE).FirstOrDefault(),
                                ANEXO_PROPIETARIO=d.DNI,
                                MONTO_FIJO=d.MONTO,
                                CUENTA=d.CUENTA,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public static List<tabla_cajas> listarCajas1(tabla_cajas PDATA)
        {
            var data = new List<tabla_cajas>();
            var cty = new RSCONCAR();
            try
            {

                using (var ctx = new ANEXO_RSFACAR())
                {
                    data = (from x in ctx.tabla_cajas
                            where x.CODIGO_CAJA == PDATA.TIPO

                            && x.ESTADO == "1"
                            select new
                            {
                                CODIGO_CAJA = x.CODIGO_CAJA,
                                PROPIETARIO = x.PROPIETARIO,
                                DNI = x.ANEXO_PROPIETARIO,
                                MONTO = x.MONTO_FIJO,
                                CUENTA = x.CUENTA,
                                FLAG = x.FLAG,
                                DESCRIPCION = x.DESCRIPCION,
                            }
                            ).ToList().Select(d => new tabla_cajas()
                            {
                                CODIGO_CAJA = d.CODIGO_CAJA,
                                USUARIO = Convert.ToString(d.CODIGO_CAJA) + "-" + d.PROPIETARIO,
                                PROPIETARIO = cty.CT0003ANEX.Where(X => X.ACODANE.Trim() == d.DNI.Trim() && X.AVANEXO.Trim() == "T").Select(X => X.ADESANE).FirstOrDefault(),
                                ANEXO_PROPIETARIO = d.DNI,
                                MONTO_FIJO = d.MONTO,
                                CUENTA = d.CUENTA,
                                FLAG = d.FLAG,
                                DESCRIPCION=d.DESCRIPCION,
                            }).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return data;
        }

        public static void ActualizarSaldo(tabla_cajas COM)
        {
            var solicitud = new tabla_cajas { CODIGO_CAJA = COM.CODIGO_CAJA };

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.tabla_cajas.Attach(solicitud);
                if (COM.ESTADO=="1")
                {
                    solicitud.MONTO_ACTUAL = solicitud.MONTO_ACTUAL + COM.MONTO_ACTUAL;
                }
                else
                {
                    solicitud.MONTO_ACTUAL = ctx.tabla_cajas.Where(X=>X.CODIGO_CAJA==COM.CODIGO_CAJA).Select(X=>X.MONTO_ACTUAL).FirstOrDefault() - COM.MONTO_ACTUAL;
                }
               
                ctx.Configuration.ValidateOnSaveEnabled = false;
                ctx.SaveChanges();
            }
        }

    }
}
