namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class AL0003LOGC
    {
        [Key]
        [Column(Order = 0, TypeName = "numeric")]
        public decimal LC_NREGACT { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string LC_CPERIODO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(1)]
        public string LC_CTIPCIE { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(5)]
        public string LC_CUSER { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(1)]
        public string LC_CTIPCOS { get; set; }

        public DateTime? LC_DFECREG { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(6)]
        public string LC_CHORREG { get; set; }


        public static AL0003LOGC ObtenerRegistro()
        {
            var datos = new AL0003LOGC();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = ctx.AL0003LOGC.OrderByDescending(x=> x.LC_DFECREG).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

            
    }
}
