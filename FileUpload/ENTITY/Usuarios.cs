namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Usuarios
    {
        [Key]
        public int idCodUsu { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        [StringLength(50)]
        public string Descrip { get; set; }

        [StringLength(10)]
        public string Clave { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [StringLength(3)]
        public string Ubicacion { get; set; }

        [StringLength(10)]
        public string UID { get; set; }

        [StringLength(50)]
        public string PWR { get; set; }

        [StringLength(8)]
        public string Codper { get; set; }

        [StringLength(1)]
        public string nivel { get; set; }

        public int? nivel2 { get; set; }

        public bool? firma { get; set; }

        [StringLength(10)]
        public string userAutorizaP { get; set; }

        public DateTime? Vencimiento { get; set; }

        public int? Vigencia { get; set; }

        [StringLength(10)]
        public string codusu2 { get; set; }

        public int? ap_exp { get; set; }
    }
}
