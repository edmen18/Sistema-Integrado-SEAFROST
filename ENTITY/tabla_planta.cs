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

    public partial class tabla_planta
    {
        [Key]
        [StringLength(10)]
        public string PL_CODIGO { get; set; }

        public string PL_DESCRIPCION { get; set; }

        [StringLength(1)]
        public string PL_ESTADO { get; set; }
        public static List<tabla_planta> ListarPLANTA()
        {
            var retorno = new List<tabla_planta>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_planta.OrderBy(Z=>Z.PL_DESCRIPCION).ToList();
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
