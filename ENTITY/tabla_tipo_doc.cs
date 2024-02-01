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

    public partial class tabla_tipo_doc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COD_TIPO { get; set; }

        [StringLength(100)]
        public string TD_DESCRIPCION { get; set; }

        public static List<tabla_tipo_doc> ListarTipoDoc()
        {
            var retorno = new List<tabla_tipo_doc>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_tipo_doc.ToList();
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

