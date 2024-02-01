namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class FT0003ACUD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string F6_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string F6_CTD { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string F6_CNUMSER { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(7)]
        public string F6_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(4)]
        public string F6_CITEM { get; set; }

        [Required]
        [StringLength(25)]
        public string F6_CCODIGO { get; set; }

        [Required]
        [StringLength(60)]
        public string F6_CDESCRI { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_CTR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NCANTID { get; set; }

        [Required]
        [StringLength(3)]
        public string F6_CUNIDAD { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_CSERIE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NCANREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NUNXENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NNUMENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NSALDAR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPRECIO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPRECI1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPREIMP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPREIM1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPRSIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NDESDOC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NVALDIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMPUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMPMN { get; set; }

        [Required]
        [StringLength(3)]
        public string F6_CTIPITM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMP01 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDE2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMP02 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDE3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMP03 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDE4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMP04 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDE5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMP05 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORDES { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_CESTADO { get; set; }

        [Required]
        [StringLength(5)]
        public string F6_CVENDE { get; set; }

        [Required]
        [StringLength(4)]
        public string F6_CALMA { get; set; }

        [Required]
        [StringLength(5)]
        public string F6_CNROCAJ { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_CSTOCK { get; set; }

        public DateTime? F6_DFECDOC { get; set; }

        [Required]
        [StringLength(4)]
        public string F6_CCODLIN { get; set; }

        [Required]
        [StringLength(6)]
        public string F6_CNROTAB { get; set; }

        [Required]
        [StringLength(4)]
        public string F6_CNUMPAQ { get; set; }

        [Required]
        [StringLength(8)]
        public string F6_CNDSCF { get; set; }

        [Required]
        [StringLength(8)]
        public string F6_CNDSCL { get; set; }

        [Required]
        [StringLength(8)]
        public string F6_CNDSCA { get; set; }

        [Required]
        [StringLength(8)]
        public string F6_CNDSCB { get; set; }

        [Required]
        [StringLength(8)]
        public string F6_CNFLAT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMPCOM { get; set; }

        [Required]
        [StringLength(5)]
        public string F6_CUSUCRE { get; set; }

        public DateTime? F6_DFECCRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPRESIS { get; set; }

        [Required]
        [StringLength(5)]
        public string F6_CVENDE2 { get; set; }

        [Required]
        [StringLength(4)]
        public string F6_CITEMP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NTEMPER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NISC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NCANDEV { get; set; }

        [Required]
        [StringLength(6)]
        public string F6_CCENCOS { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_CANEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_CANEREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NCANDEC { get; set; }

        [Required]
        [StringLength(2)]
        public string F6_CTIPPLA { get; set; }

        [Required]
        [StringLength(4)]
        public string F6_CCODPLA { get; set; }

        [Required]
        [StringLength(2)]
        public string F6_CTIPCAT { get; set; }

        [Required]
        [StringLength(20)]
        public string F6_CNROPLA { get; set; }

        [Required]
        [StringLength(5)]
        public string F6_CCOSUPV { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_AVANEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_ACODANE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NRETGAR { get; set; }

        [Required]
        [StringLength(2)]
        public string F6_CTIPDOC { get; set; }

        [Required]
        [StringLength(11)]
        public string F6_CNRODOC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NTASRCN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NIMPRCN { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_CVANEXO { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_CCODANE { get; set; }

        [Required]
        [StringLength(18)]
        public string F6_CCODAN2 { get; set; }

        [Required]
        [StringLength(1)]
        public string F6_CVANEX2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORCM1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F6_NPORCM2 { get; set; }

        [Required]
        [StringLength(3)]
        public string F6_CCODEMPQ { get; set; }

        public static List<FT0003ACUD> ListarDetalFactura(FT0003ACUD DATAM)
        {
            using (var ctx = new RSFACAR())
            {
                return (from c in ctx.FT0003ACUD
                        where c.F6_CNUMSER.Trim() == DATAM.F6_CNUMSER.Trim() 
                        && c.F6_CTD == DATAM.F6_CTD 
                        && c.F6_CNUMDOC.Trim()== DATAM.F6_CNUMDOC.Trim() 
                        select c).ToList();
            }
        }


    }
}
