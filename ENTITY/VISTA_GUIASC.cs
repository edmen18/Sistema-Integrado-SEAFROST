namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class VISTA_GUIASC
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public long pk { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(30)]
        public string C5_CGLOSA1 { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(30)]
        public string C5_CGLOSA2 { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(50)]
        public string C5_CNOMCLI { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(18)]
        public string C5_CRUC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(18)]
        public string C5_CCODTRA { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(50)]
        public string C5_CNOMTRA { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(80)]
        public string C5_CDIRENV { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(20)]
        public string C5_CNUMORD { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(11)]
        public string C5_CNUMPED { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(30)]
        public string C5_CCONTAI { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(11)]
        public string C5_CNUMDOC { get; set; }

        [StringLength(20)]
        public string C5_DFECDOC { get; set; }

        public DateTime? C5_DFECDOC2 { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(80)]
        public string DIRCLIE { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(1)]
        public string DISTC { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(1)]
        public string PROVC { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(1)]
        public string DEPAC { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(4)]
        public string C5_CALMA { get; set; }

        [StringLength(50)]
        public string MARCAG { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(5)]
        public string C5_CUSUCRE { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(1)]
        public string C5_CSITGUI { get; set; }

        [StringLength(50)]
        public string PLACAG { get; set; }

        [StringLength(50)]
        public string LICENCIAG { get; set; }

        [StringLength(50)]
        public string TRACTORG { get; set; }

        [StringLength(50)]
        public string CONSTANCIAG { get; set; }

        [StringLength(250)]
        public string DIRENTREGAG { get; set; }

        [StringLength(100)]
        public string NOMDESTG { get; set; }

        [StringLength(15)]
        public string RUCDESG { get; set; }

        [StringLength(400)]
        public string GLOSAG { get; set; }

        [StringLength(400)]
        public string CONTENEDORG { get; set; }

        [StringLength(18)]
        public string GTRANSPORG { get; set; }

        [StringLength(108)]
        public string PRECINTO1G { get; set; }

        [StringLength(108)]
        public string PRECINTO2G { get; set; }


        public static  List<VISTA_GUIASC> LGuiasxEstado(string a, string b, string estado)
        {
            var f1 = Convert.ToDateTime(a);
            var f2 = Convert.ToDateTime(b);
            using (RSFACAR context = new RSFACAR())
            {
                return (from c in context.VISTA_GUIASC where c.C5_CSITGUI == estado && c.C5_DFECDOC2 >= f1 && c.C5_DFECDOC2 <= f2 orderby c.C5_CNUMDOC select c).ToList();
            }
        }

        public static int LGuiasfacturada(string a, string b,string situa)
        {
            var f1 = Convert.ToDateTime(a);
            var f2 = Convert.ToDateTime(b);

            using (RSFACAR context = new RSFACAR())
            {
                return (from c in context.VISTA_GUIASC where c.C5_CSITGUI == situa && c.C5_DFECDOC2 >= f1 && c.C5_DFECDOC2 <= f2 orderby c.C5_CNUMDOC select c).Count();
            }
        }
    }
}
