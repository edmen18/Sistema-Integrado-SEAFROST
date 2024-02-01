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

    public partial class tabla_detalle
    {
        [StringLength(10)]
        public string TR_CODIGO { get; set; }

        [StringLength(50)]
        public string NUM_DOC { get; set; }

        public int? COD_TIPO { get; set; }

        [Key]
        public int CODIGO { get; set; }

        public decimal? MONTO { get; set; }
        public static void EliminaItems(tabla_detalle CCAB)
        {

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.Entry(new tabla_detalle { CODIGO = CCAB.CODIGO }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
        public static Boolean insertaItem(tabla_detalle tabla)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(tabla).State = EntityState.Added;
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

        public static List<VISTA_DETTRABAJO> ListarDL(VISTA_DETTRABAJO CODATA)
        {
            var alumnos = new List<VISTA_DETTRABAJO>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    alumnos = (from a in ctx.tabla_detalle
                               join b in ctx.tabla_tipo_doc
                               on a.COD_TIPO equals b.COD_TIPO
                               where a.TR_CODIGO == CODATA.TR_CODIGO
                               select new
                               {
                                   trabajo = a.TR_CODIGO,
                                   documento = a.NUM_DOC,
                                   tipo = a.COD_TIPO,
                                   tipodoc = b.TD_DESCRIPCION,
                                   codigo = a.CODIGO,
                                   monto=a.MONTO,
                               }
                              ).ToList()
                          .Select(c => new VISTA_DETTRABAJO()
                          {
                              TR_CODIGO = c.trabajo,
                              COD_TIPO = c.tipo,
                              NUM_DOC = c.documento,
                              DOCUMENTOTIPO = c.tipodoc,
                              CODIGO = c.codigo,
                              MONTO= c.monto,
                              
                          }).ToList();

                }
            }
            catch (Exception)
            {

                throw;
            }

            return alumnos;
        }

      


        public static List<VISTA_DETALLE_TRABAJOCURSO> DETALLE(tabla_trabajo CODATA)
        {
            var alumnos = new List<VISTA_DETALLE_TRABAJOCURSO>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ((from a in ctx.AL0003REQC
                                where a.RC_CNUMOT.Trim() == CODATA.TR_CODIGO.Trim() //&& a.RC_CESTADO=="7"
                                select new { data1 = a.RC_CNROREQ, data2 = a.RC_DFECREQ, data3 = a.RC_CCODMON,
                                    data4 = a.RC_NIMPUS,
                                    data5 = a.RC_NIMPMN,
                                    data6="REQUERIMIENTO"}
                                     ).Union(from b in ctx.CO0003MOVC
                                             where b.OC_CRESPER3.Trim() == CODATA.TR_CODIGO.Trim()
                                         //    && b.OC_CSITORD=="2"
                                             select new { data1 = b.OC_CNUMORD, data2 = b.OC_DFECDOC,
                                                 data3 = b.OC_CCODMON,
                                                 data4 = (decimal?)(b.OC_NIMPUS),
                                                 data5 = (decimal?)(b.OC_NIMPMN),
                                             data6="ORDEN SERVICIO"})
                               ).ToList()
                          .Select(c => new VISTA_DETALLE_TRABAJOCURSO()
                          {
                              CODIGO = c.data1,
                              DOCUMENTO=c.data6,
                              FECHA = Convert.ToDateTime(c.data2),
                              MONEDA = c.data3,
                              MONTO = (c.data3.Trim() == "MN" ? c.data5 : c.data4),        
                              MONTOMN= c.data5,
                              MONTOUS= c.data4
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
