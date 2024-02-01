namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class PD0003PENC
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string F5_CCODAGE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(11)]
        public string F5_CNUMPED { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CTD { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CNUMSER { get; set; }

        [Required]
        [StringLength(7)]
        public string F5_CNUMDOC { get; set; }

        public DateTime? F5_DFECDOC { get; set; }

        public DateTime? F5_DFECVEN { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CDH { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CVENDE { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CNROCAJ { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CCODCLI { get; set; }

        [Required]
        [StringLength(80)]
        public string F5_CNOMBRE { get; set; }

        [Required]
        [StringLength(80)]
        public string F5_CDIRECC { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CRUC { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CCODCAD { get; set; }

        [Required]
        [StringLength(10)]
        public string F5_CCODINT { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CALMA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NIMPORT { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CFORVEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NDIACRE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NSALDO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NIMPIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NTIPCAM { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CRFTD { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CCODMON { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CRFNSER { get; set; }

        [Required]
        [StringLength(20)]
        public string F5_CRFNDOC { get; set; }

        public DateTime? F5_DFECDRF { get; set; }

        [Required]
        [StringLength(40)]
        public string F5_CEMBALA { get; set; }

        [Required]
        [StringLength(50)]
        public string F5_CGLOSA { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CSTKCOM { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CESTADO { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CCODDIR { get; set; }

        [Required]
        [StringLength(8)]
        public string F5_CPOSVEN { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CCODMAQ { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CCODTRA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NPORDE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NPORDE2 { get; set; }

        public DateTime? F5_DFECEMB { get; set; }

        [Required]
        [StringLength(15)]
        public string F5_CORDEN { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CUSUAP { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CTE { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CUSUCRE { get; set; }

        public DateTime? F5_DFECCRE { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CUSUMOD { get; set; }

        public DateTime? F5_DFECMOD { get; set; }

        public DateTime? F5_DFECAPR { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CUSUREC { get; set; }

        public DateTime? F5_DFECREC { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CUSUSEC { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CFORDSC { get; set; }

        [Required]
        [StringLength(15)]
        public string F5_CCODAUT { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CSITUA2 { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CTD2 { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CNUMSER2 { get; set; }

        [Required]
        [StringLength(7)]
        public string F5_CNUMDOC2 { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CSITUA3 { get; set; }

        [Required]
        [StringLength(5)]
        public string F5_CVENDE2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NPORVEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NPORVE2 { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CTIPPED { get; set; }

        public DateTime? F5_DFECANU { get; set; }

        [StringLength(1)]
        public string F5_CTIPDNC { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CCODVEH { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CCODFER { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CTDVA { get; set; }

        [Required]
        [StringLength(4)]
        public string F5_CCAJA { get; set; }

        [Required]
        [StringLength(20)]
        public string F5_CNROPLA { get; set; }

        [Required]
        [StringLength(10)]
        public string F5_CHRADOC { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CTIPPE2 { get; set; }

        public DateTime? F5_DFECREP { get; set; }

        [Required]
        [StringLength(1)]
        public string F5_CFLGPLA { get; set; }

        [Required]
        [StringLength(2)]
        public string F5_CMONPER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NIMPPER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NPORPER { get; set; }

        [Required]
        [StringLength(6)]
        public string F5_CCENCOS { get; set; }

        [Required]
        [StringLength(18)]
        public string F5_CAGETRA { get; set; }

        [Required]
        [StringLength(20)]
        public string F5_CNUMORD { get; set; }

        [Required]
        [StringLength(20)]
        public string F5_CNUMCON { get; set; }

        [Required]
        [StringLength(80)]
        public string F5_CAPPBAS { get; set; }

        public DateTime? F5_DFECCON { get; set; }

        public DateTime? F5_DFECFIJ { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CPRVEXP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal F5_NCANBOL { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CTIPCAL { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CCONEMB { get; set; }

        [Required]
        [StringLength(30)]
        public string F5_CCONTAI { get; set; }

        [Required]
        [StringLength(30)]
        public string F5_CNUMBL { get; set; }

        [Required]
        [StringLength(30)]
        public string F5_CVAPOR { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CPUEEMB { get; set; }

        [Required]
        [StringLength(3)]
        public string F5_CPUEDES { get; set; }


        public static PD0003PENC Mostrarunpedido(PD0003PENC PDDATA)
        {
            try
            {
                using (var ctx = new RSFACAR())
                {
                    return (from c in ctx.PD0003PENC where c.F5_CNUMPED.Trim() == PDDATA.F5_CNUMPED.Trim() select c).First();
                }
            }
            catch
            {
                return null;
            }
        }

    }
}
