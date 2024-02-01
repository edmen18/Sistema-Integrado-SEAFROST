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
    }
}
