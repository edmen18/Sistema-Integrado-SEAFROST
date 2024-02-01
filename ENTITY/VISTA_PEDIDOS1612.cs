namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class VISTA_PEDIDOS1612
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(11)]
        public string F5_CNUMPED { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string F5_CCODAGE { get; set; }

        [StringLength(20)]
        public string F5_DFECDOC { get; set; }

        [StringLength(20)]
        public string F5_DFECFIJ { get; set; }

        [StringLength(20)]
        public string F5_DFECEMB { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(18)]
        public string F5_CCODCLI { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(80)]
        public string F5_CNOMBRE { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string F5_CALMA { get; set; }

        [StringLength(1000)]
        public string FV_CDESCRI { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(2)]
        public string F5_CCODMON { get; set; }

        [Key]
        [Column(Order = 6, TypeName = "numeric")]
        public decimal F5_NIMPORT { get; set; }

        [StringLength(60)]
        public string TG_CDESCRI { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(7)]
        public string F5_CNUMDOC { get; set; }

        [StringLength(50)]
        public string VE_CNOMBRE { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(5)]
        public string F5_CUSUCRE { get; set; }

        [Column(TypeName = "date")]
        public DateTime? F5_DFECDOC2 { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1)]
        public string F5_CESTADO2 { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(5)]
        public string F5_CCVEND2 { get; set; }

        public int? DIASFE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? F6_NCANTID { get; set; }

        public decimal? XEMBARC { get; set; }

        public static  List<VISTA_PEDIDOS1612> F_ListarPedido(string d)
        {
            try
            {
                using (RSFACAR context = new RSFACAR())
                {
                    var LPF = (from c in context.VISTA_PEDIDOS1612 where c.F5_CESTADO2 == d orderby c.F5_CNUMPED select c).ToList<VISTA_PEDIDOS1612>();
                    return LPF;
                }
            }
            catch
            {
                return null;
            }
        }


    }
}
