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

    public partial class tabla_equipo
    {
        [Key]
        [StringLength(10)]
        public string EQ_CODIGO { get; set; }

        public string EQ_DESCRIPCION { get; set; }

        [StringLength(1)]
        public string EQ_ESTADO { get; set; }

        public static List<tabla_equipo> ListarEquipos()
        {
            var retorno = new List<tabla_equipo>();

            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    retorno = ctx.tabla_equipo.OrderBy(X=>X.EQ_DESCRIPCION).ToList();
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
