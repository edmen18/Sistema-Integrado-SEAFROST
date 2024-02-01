namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class FT0003TCAJ
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string TC_CCOD { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(8)]
        public string TC_CCLAVE { get; set; }

        [Required]
        [StringLength(40)]
        public string TC_CDESCRI { get; set; }

        [Required]
        [StringLength(5)]
        public string TC_CUSUCRE { get; set; }

        public DateTime? TC_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string TC_CUSUMOD { get; set; }

        public DateTime? TC_DFECMOD { get; set; }

        public static List<FT0003TCAJ> ListarTablaID(FT0003TCAJ FDATA)
        {
            var alumnos = new List<FT0003TCAJ>();

            try
            {
                using (var ctx = new RSFACAR())
                {
                    alumnos = ctx.FT0003TCAJ.Where(x => x.TC_CCOD == FDATA.TC_CCOD && x.TC_CCLAVE == FDATA.TC_CCLAVE).OrderBy(x => x.TC_CDESCRI).ToList();
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
