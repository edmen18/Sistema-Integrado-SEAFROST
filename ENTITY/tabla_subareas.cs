namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_subareas
    {
        [Key]
        public int SA_ID { get; set; }

        [StringLength(300)]
        public string SA_DESC { get; set; }

        public int? SA_NAPROB { get; set; }

        public static List<tabla_subareas> Listarsubareas()
        {
            var dato = new List<tabla_subareas>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = ctx.tabla_subareas.OrderBy(f => f.SA_ID).ToList();
                }
            }
            catch
            {
                throw;
            }
            return dato;
        }


        public static tabla_subareas Nvalidaareas(string codsubarea)
        {
            var dato = new tabla_subareas();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = ctx.tabla_subareas.Where(tt => tt.SA_ID.ToString() == codsubarea).FirstOrDefault();
                }
            }
            catch
            {
                dato = null;
            }
            return dato;
        }




        // codigo edgar
        public static List<tabla_subareas> ListarsubareasED()
        {
            var dato = new List<tabla_subareas>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = ctx.tabla_subareas.OrderBy(f => f.SA_DESC).ToList();
                }
            }
            catch
            {
                throw;
            }
            return dato;
        }


    }
}
