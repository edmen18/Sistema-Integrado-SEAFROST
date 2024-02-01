namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class tabla_services
    {
        [Key]
        [StringLength(20)]
        public string codtra { get; set; }

        [StringLength(200)]
        public string descripcion { get; set; }

        public int? condicion { get; set; }

        [StringLength(20)]
        public string dni { get; set; }
        public static List<tabla_services> ListarServis(string texto,string area)
        {
            var info = new List<tabla_services>();
            if (area == "1") { 
            
            try
            {
                using (var ctx = new SEAPLANILLASRRHH())
                {
                    info = ctx.tabla_services.Where(x => x.descripcion.Contains(texto)).ToList();
                }
            }
            catch (Exception)
            {
                throw;
            }
            
            }
            else if (area == "2")
            {
                info = tabla_servicesconserva.ListarServisCS(texto);
            }

            return info;
        }

        public static tabla_services Servicexcodigo(tabla_services tbs,string area)
        {
            var info = new tabla_services();
            if (area == "1") { 
            try
            {
                using (var ctx = new SEAPLANILLASRRHH())
                {
                    info = ctx.tabla_services.Where(x => x.codtra == tbs.codtra).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            }else if (area == "2")
            {
                info = tabla_servicesconserva.ServicexcodigoCS(tbs);
            }

            return info;
        }
    }
}
