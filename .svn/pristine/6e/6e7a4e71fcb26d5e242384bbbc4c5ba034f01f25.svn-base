namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    public partial class tabla_d_areagerencia
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GA_IDAREA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(3)]
        public string GA_IDGEREN { get; set; }

        public  static List<tabla_d_areagerencia> ListarAreagerencia(string lg )
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                return (from c in ctx.tabla_d_areagerencia where c.GA_IDGEREN == lg select c
                       ).ToList();
            }
        }

        public static List<tabla_d_areagerencia> Listadetallga()
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                return (from c in ctx.tabla_d_areagerencia  select c
                       ).ToList();
            }
        }


        public static List<vista_lisusuageren> Listarxgerencia(string[] codarea)
        {
            var dato = new List<vista_lisusuageren>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    dato = (from c in ctx.tabla_d_areagerencia
                            where codarea.Contains(c.GA_IDAREA.ToString())
                            select new
                            {
                                SA_ID = c.GA_IDAREA,
                                SA_DESC = "",
                                SA_NAPROB = 0,
                                SA_GEREN = c.GA_IDGEREN
                            }).ToList().Select(d => new vista_lisusuageren()
                            {
                                SA_ID = d.SA_ID,
                                SA_DESC = tabla_subareas.Nvalidaareas(d.SA_ID.ToString()).SA_DESC,
                                SA_NAPROB = tabla_subareas.Nvalidaareas(d.SA_ID.ToString()).SA_NAPROB,
                                SA_GEREN = tabla_gerencias.Listarunagerencia(d.SA_GEREN).GG_DESCRI
                            }).ToList();
                }
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
                //catch
                //{
                //    dato = null;
                //}
                return dato;
        }

    }
}
