namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class tabla_dist_costeo
    {
        [Key]
        [StringLength(10)]
        public string CT_ID { get; set; }

        [Required]
        [StringLength(10)]
        public string CT_CCOST { get; set; }

        [StringLength(10)]
        public string CT_CBENF { get; set; }

        [Required]
        [StringLength(50)]
        public string CT_CTACO { get; set; }

        [StringLength(50)]
        public string CT_GLOSA { get; set; }

        [Required]
        [StringLength(10)]
        public string CT_USUCRE { get; set; }

        public DateTime CT_FECHAR { get; set; }

        [StringLength(10)]
        public string CT_USUMOD { get; set; }

        public DateTime? CT_FECHAM { get; set; }

        [Required]
        [StringLength(2)]
        public string CT_ESTADO { get; set; }

        public static string costeocta(tabla_dist_costeo DATA)
        {
            var lista = "";
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    lista = ctx.tabla_dist_costeo.Where(x => x.CT_CCOST.Trim() == DATA.CT_CCOST.Trim()).Select(aw => aw.CT_CTACO).First().ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }

        public static tabla_dist_costeo costeocta_x_cc(string CC) {
            tabla_dist_costeo lista = new tabla_dist_costeo();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    lista = ctx.tabla_dist_costeo.Where(x => x.CT_CCOST.Trim() == CC.Trim()).First();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return lista;
        }
    }
}
