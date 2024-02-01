namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    public partial class tabla_turno
    {
        [Key]
        [StringLength(3)]
        public string cod { get; set; }

        [StringLength(50)]
        public string descripcion { get; set; }

        public static List<tabla_turno> ListaTurno(string id)
        {
            List<tabla_turno> userx = new List<tabla_turno>();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    userx = ctx.tabla_turno.Where(x => x.cod == id).Concat(ctx.tabla_turno.Where(x => x.cod != id)).ToList();
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
