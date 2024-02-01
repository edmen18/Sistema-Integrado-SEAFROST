namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;

    public partial class tabla_permisos
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechaincicio { get; set; }

        [Column(TypeName = "date")]
        public DateTime? fechafin { get; set; }

        [StringLength(30)]
        public string codper { get; set; }

        [StringLength(100)]
        public string motivo { get; set; }

        [StringLength(20)]
        public string codtipopermiso { get; set; }

        public int? horasInicio { get; set; }
        public int? minutosInicio { get; set; }

        public int? horasFin { get; set; }
        public int? minutosFin { get; set; }

        [StringLength(30)]
        public string codperAutoriza { get; set; }

        public bool? estado { get; set; }

        public PersonalEmpresa ObtenResponsableCosto(string codper)
        {
            PersonalEmpresa userx = new PersonalEmpresa();
            try
            {
                using (var ctx = new PERSONALCONTEXT())
                {
                    var query1 = (ctx.PersonalEmpresa.Where(x => x.CodPer == codper).FirstOrDefault());
                    var query2 = (ctx.Ccosto.Where(x => x.Codcco == query1.Costo).FirstOrDefault());
                    userx = (ctx.PersonalEmpresa.Where(x => x.CodPer == query2.codPer).FirstOrDefault());
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
