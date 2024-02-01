namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_servicesconserva
    {
        [Key]
        [StringLength(20)]
        public string codtra { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public int? condicion { get; set; }

        [StringLength(20)]
        public string dni { get; set; }
        public static List<tabla_services> ListarServisCS(string texto)
        {
            var info = new List<tabla_services>();
            try
            {
                using (var ctx = new RRHHCONSERVAS())
                {
                    info = ctx.tabla_services.Where(x => x.descripcion.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

        public static tabla_services ServicexcodigoCS(tabla_services tbs)
        {
            var info = new tabla_services();
            try
            {
                using (var ctx = new RRHHCONSERVAS())
                {
                    info = ctx.tabla_services.Where(x => x.codtra == tbs.codtra).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return info;
        }

    }
}
