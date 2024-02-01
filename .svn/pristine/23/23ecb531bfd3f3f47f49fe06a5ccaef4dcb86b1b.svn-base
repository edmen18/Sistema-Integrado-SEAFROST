namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class tabla_tipoPermiso
    {
        [Key]
        [StringLength(3)]
        public string cod { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        public static List<tabla_tipoPermiso> ListaTipoPermiso()
        {
            List<tabla_tipoPermiso> userx = new List<tabla_tipoPermiso>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = (ctx.tabla_tipoPermiso).ToList();
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
