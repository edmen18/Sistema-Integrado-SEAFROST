namespace ENTITY
{

    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class PersonalLabores
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string Tipo_Tabla { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string Dep_Pos { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string Cod_Pos { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(2)]
        public string Cod_Dep { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(3)]
        public string Codigo { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string Detalle { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        public DateTime? FechaMod { get; set; }

        [StringLength(50)]
        public string sie { get; set; }

        public static string ListarLabores(string labor)
        {
            var alumnos = string.Empty;
            try
            {
                using (var ctx = new PERSONALCONTEXTO())
                {
                    alumnos = ctx.PersonalLabores.Where(x => x.Codigo == labor).Select(x => x.Detalle).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }
    }
}
