namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;


    [Table("Personal")]
    public partial class Personal
    {
        [Key]
        public int idCodPer { get; set; }

        [StringLength(15)]
        public string CodPer { get; set; }

        [StringLength(2)]
        public string TipoCodPer { get; set; }

        [StringLength(80)]
        public string Detalle { get; set; }

        [StringLength(2)]
        public string Produccion { get; set; }

        [StringLength(11)]
        public string RucEmpresa { get; set; }

        [StringLength(1)]
        public string IngresoSalida { get; set; }

        public int? idGrupoTrabajo { get; set; }

        [StringLength(3)]
        public string GrupoTrabajo { get; set; }

        [Column(TypeName = "money")]
        public decimal? Basico { get; set; }

        [StringLength(30)]
        public string CodigoLaboral { get; set; }

        public int? idUbicacion { get; set; }

        [StringLength(3)]
        public string Ubicacion { get; set; }

        public int? idCategoria { get; set; }

        [StringLength(2)]
        public string Categoria { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaIngreso { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FechaBaja { get; set; }

        public bool? Eventual { get; set; }

        public bool? Activo { get; set; }

        [StringLength(10)]
        public string CodUsu { get; set; }

        public DateTime? FechaMod { get; set; }

        [StringLength(15)]
        public string codigo { get; set; }

        [StringLength(5)]
        public string DepositoBancoCuenta { get; set; }

        public static Personal obtenTrabajador(string codigo )
        {
            var alumnos = new Personal();
            try
            {
                using (var ctx = new PERSONALCONTEXTO())
                {
                    alumnos = ctx.Personal.Where(x => x.codigo == codigo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static PersonalEmpresa obtenTrabajadorDetalle(string codigo)
        {
            var alumnos = new PersonalEmpresa();
            try
            {
                using (var ctx = new PERSONALCONTEXTO())
                {
                    alumnos = ctx.PersonalEmpresa.Where(x => x.CodPer == codigo).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return alumnos;
        }

        public static List<Personal> listaCodigos()
        {
            var alumnos = new List<Personal>();
            try
            {
                using (var ctx = new PERSONALCONTEXTO())
                {
                    alumnos = ctx.Personal.Where(x => x.codigo.Substring(0,1) != "2" && x.codigo !=null && x.codigo!=string.Empty).ToList();
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
