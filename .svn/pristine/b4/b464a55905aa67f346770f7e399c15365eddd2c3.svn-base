namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_gerencias
    {
        [Key]
        [StringLength(3)]
        public string GG_ID { get; set; }

        [StringLength(250)]
        public string GG_DESCRI { get; set; }

        public static List<tabla_gerencias> ListarGerencias()
        {
            using (var ctx= new ANEXO_RSFACAR())
            {
                return (from c in ctx.tabla_gerencias select c).ToList();
            }
        }

        public static tabla_gerencias Listarunagerencia(string idgerencia)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                return (from c in ctx.tabla_gerencias where c.GG_ID== idgerencia select c).First();
            }
        }




    }
}
