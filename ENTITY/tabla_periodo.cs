namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class tabla_periodo
    {
        [Key]
        [StringLength(3)]
        public string cod { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        public static List<tabla_periodo> ListarPeriodo()
        {
            List<tabla_periodo> userx = new List<tabla_periodo>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    userx = (ctx.tabla_periodo).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }

            return userx;
        }
    }
   
}
