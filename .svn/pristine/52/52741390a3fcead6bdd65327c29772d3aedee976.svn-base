namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class tabla_subtipoOC
    {
        [Key]
        public int IDTipo { get; set; }

        [StringLength(150)]
        public string Descripcion { get; set; }
        public int ST_NAPROB { get; set; }

        public static List<tabla_subtipoOC> ListarSTipoOC()
        {
            var retorno = new List<tabla_subtipoOC>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_subtipoOC.ToList() ;
                }
            }
            catch (Exception)
            {
                throw;
            }
            return retorno;
        }

        public static List<tabla_subtipoOC> Listarsubtipoxusua(string usuario, int tipousua)
        {
            var dato = new List<tabla_subtipoOC>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from a in ctx.tabla_d_areausua
                            join b in ctx.tabla_subtipoOC on a.UA_SUBAREA equals b.IDTipo
                            where a.UA_USUA == usuario && a.UA_TIPOPROCESO == tipousua
                            orderby b.Descripcion
                            select new
                            {
                                IDTipo = b.IDTipo,
                                Descripcion = b.Descripcion,
                            }).ToList().Select(c => new tabla_subtipoOC()
                            {
                                IDTipo = c.IDTipo,
                                Descripcion = c.Descripcion
                            }
                        ).ToList();
                }
            }
            catch
            {
                throw;
            }
            return dato;
        }


    }
}
