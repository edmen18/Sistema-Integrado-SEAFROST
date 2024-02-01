namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    
    public partial class tabla_d_control
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(6)]
        public string USUA_CAU { get; set; }

        public int ACCION_CAU { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TIPO_CAU { get; set; }

        [StringLength(50)]
        public string DESC_CAU { get; set; }

        [StringLength(1)]
        public string CAMPO1_CAU { get; set; }

        [StringLength(1)]
        public string CAMPO2_CAU { get; set; }

        [StringLength(1)]
        public string CAMPO3_CAU { get; set; }

        [StringLength(1)]
        public string CAMPOX_CAU { get; set; }

        public DateTime FECHA_CAU { get; set; }

        public static tabla_d_control VerCabeceraID(tabla_d_control DATA)
        {
            tabla_d_control listaA = new tabla_d_control();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaA = (from c in ctx.tabla_d_control where c.USUA_CAU == DATA.USUA_CAU 
                                    && c.ACCION_CAU==DATA.ACCION_CAU select c).FirstOrDefault();
                }
            }
            catch (Exception)
            {
                listaA = null;
            }
            return listaA;
        }
    }
}
