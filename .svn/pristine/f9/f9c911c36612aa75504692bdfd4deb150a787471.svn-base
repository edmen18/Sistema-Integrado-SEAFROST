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

    public partial class T_DETALLE
    {
        [StringLength(10)]
        public string TR_CODIGO { get; set; }

        [StringLength(50)]
        public string NUM_DOC { get; set; }

        public int? COD_TIPO { get; set; }

        [Key]
        public int CODIGO { get; set; }


        public static void EliminaItems(T_DETALLE CCAB)
        {

            using (var ctx = new ANEXO_RSFACAR())
            {
                ctx.Entry(new T_DETALLE { CODIGO = CCAB.CODIGO }).State = EntityState.Deleted;
                ctx.SaveChanges();
            }
        }
        public static Boolean insertaItem(T_DETALLE tabla)
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
                    alumnos = (from a in ctx.T_DETALLE join b in ctx.TB_TIPO_DOC
                               on a.COD_TIPO equals b.COD_TIPO
                                where a.TR_CODIGO == CODATA.TR_CODIGO
                               select new
                               {
                                   trabajo = a.TR_CODIGO,
                                   documento = a.NUM_DOC,
                                   tipo = a.COD_TIPO,
                                   tipodoc=b.TD_DESCRIPCION,
                                   codigo=a.CODIGO,
                                                                  }
                              ).ToList()
                          .Select(c => new VISTA_DETTRABAJO()
                          {
                              TR_CODIGO = c.trabajo,
                              COD_TIPO = c.tipo,
                              NUM_DOC = c.documento,
                              DOCUMENTOTIPO=c.tipodoc,   
                              CODIGO=c.codigo,                         
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
