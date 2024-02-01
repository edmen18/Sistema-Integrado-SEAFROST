namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("Ccosto")]
    public partial class Ccosto
    {
        [Key]
        public int idCodcco { get; set; }

        [Required]
        [StringLength(5)]
        public string Codcco { get; set; }

        [StringLength(70)]
        public string Descrip { get; set; }

        [StringLength(4)]
        public string CodBod { get; set; }

        [StringLength(2)]
        public string Prioridad { get; set; }

        [StringLength(3)]
        public string Cc { get; set; }

        [StringLength(2)]
        public string Tipocco { get; set; }

        public float? Has { get; set; }

        [StringLength(5)]
        public string TipoPoza { get; set; }

        public bool? Activada { get; set; }

        [StringLength(5)]
        public string Detalle { get; set; }

        [StringLength(1)]
        public string CDI { get; set; }

        [StringLength(10)]
        public string Codusu { get; set; }

        public DateTime? Fechamod { get; set; }

        [StringLength(8)]
        public string codPer { get; set; }

        public bool? Activo { get; set; }

        [StringLength(10)]
        public string concar { get; set; }

        public static string ListarCostos(string costo)
        {
            var alumnos = string.Empty;
            try
            {
                using (var ctx = new GLOBALCONTEXT())
                {
                    alumnos = ctx.Ccosto.Where(x => x.Codcco ==  costo).Select(x=>x.Descrip).FirstOrDefault();
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
