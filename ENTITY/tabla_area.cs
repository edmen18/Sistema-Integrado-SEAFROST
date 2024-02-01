namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data;
    using System.Linq;
    public partial class tabla_area
    {
        [Key]
        public int AE_COD { get; set; }

        [StringLength(100)]
        public string AE_DESC { get; set; }

        public static List<tabla_area> Listararea()
        {
            var retorno = new List<tabla_area>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_area.ToList();
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
