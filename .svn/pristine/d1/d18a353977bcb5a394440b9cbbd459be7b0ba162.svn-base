namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
        public partial class TB_TIPO_DOC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int COD_TIPO { get; set; }

        [StringLength(100)]
        public string TD_DESCRIPCION { get; set; }

        public static List<TB_TIPO_DOC> ListarTipoDoc()
        {
            var retorno = new List<TB_TIPO_DOC>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.TB_TIPO_DOC.ToList();
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

