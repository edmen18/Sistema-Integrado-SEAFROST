namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    public partial class FACTURA_CABECERA
    {
        [Key]
        [StringLength(50)]
        public string IDFACTURA { get; set; }

        [StringLength(4)]
        public string SERIE { get; set; }

        [StringLength(2)]
        public string TIPODOC { get; set; }

        [StringLength(80)]
        public string VAPOR { get; set; }

        [StringLength(80)]
        public string BL { get; set; }

        [StringLength(80)]
        public string REGIS { get; set; }

        [StringLength(180)]
        public string CANTIDADES { get; set; }

        [StringLength(180)]
        public string CANTIDADUS { get; set; }

        [StringLength(100)]
        public string PEMB { get; set; }

        [StringLength(100)]
        public string PDEST { get; set; }

        [StringLength(100)]
        public string CFR { get; set; }

        [StringLength(100)]
        public string PTOCFR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SEGUROCANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? FLETECANT { get; set; }

        [StringLength(50)]
        public string TIMCOTERM { get; set; }

        [StringLength(250)]
        public string DIROPCION { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? PESOBRUTO { get; set; }

        [StringLength(200)]
        public string CONSIGNATARIO { get; set; }

        [StringLength(300)]
        public string DIRCONSIG { get; set; }

        [StringLength(2)]
        public string UNIDAD { get; set; }

        [StringLength(2)]
        public string UNIDADPB { get; set; }

        [StringLength(300)]
        public string CLIENTEOPC { get; set; }

        [StringLength(12)]
        public string IDPDEST { get; set; }

        [StringLength(12)]
        public string IDPTOCFR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? IMPMIGV { get; set; }

        [StringLength(50)]
        public string DOCREF { get; set; }


        public static int validangfactura(string serie,string ndoc)
        {
            int nregv = 0;
            using (var ctx = new DB_EXPOR())
            {
                //Convert.ToString(Convert.ToDecimal(FACTURA_CABECERA.IDFACTURA))
                nregv = (from c in ctx.FACTURA_CABECERA where c.IDFACTURA.EndsWith(ndoc) && c.SERIE == serie select c).Count() ;
            }
            return nregv;
        } 



    }
}
