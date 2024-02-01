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

    public partial class tabla_tipo_entrega
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int CODIGO_TIPO { get; set; }

        [StringLength(50)]
        public string DESCRIPCION { get; set; }

        [StringLength(1)]
        public string ESTADO { get; set; }

        public static List<tabla_tipo_entrega> listar()
        {
            var retorno = new List<tabla_tipo_entrega>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_tipo_entrega.Where(z=>z.CODIGO_TIPO==2).OrderBy(Z => Z.DESCRIPCION).ToList();
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
