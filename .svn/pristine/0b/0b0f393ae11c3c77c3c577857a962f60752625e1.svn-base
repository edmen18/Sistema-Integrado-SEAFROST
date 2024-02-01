namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Linq;

    public partial class OT_CO0003MOVD
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(20)]
        public string OC_CNUMORD { get; set; }

        
        [StringLength(18)]
        public string OC_CCODPRO { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string OC_CITEM { get; set; }

        
        [StringLength(25)]
        public string OC_CCODIGO { get; set; }

        
        [StringLength(25)]
        public string OC_CCODREF { get; set; }

        
        [StringLength(60)]
        public string OC_CDESREF { get; set; }

        
        [StringLength(3)]
        public string OC_CUNIPRO { get; set; }

        
        [StringLength(60)]
        public string OC_CDEUNPR { get; set; }

        
        [StringLength(3)]
        public string OC_CUNIDAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANORD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NPREUNI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NPREUN2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPFI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCFI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCIT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCAD { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDSCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIGV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NISC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANTEN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANSAL { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTUS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTMN { get; set; }

        
        [StringLength(800)]
        public string OC_COMENTA { get; set; }

        
        [StringLength(1)]
        public string OC_CESTADO { get; set; }

        
        [StringLength(1)]
        public string OC_FUNICOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANREF { get; set; }

        
        [StringLength(18)]
        public string OC_CSERIE { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NANCHO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCORTE { get; set; }

        public DateTime? OC_DFECDOC { get; set; }

        
        [StringLength(1)]
        public string OC_CTIPORD { get; set; }

        
        [StringLength(6)]
        public string OC_CCENCOS { get; set; }

        
        [StringLength(7)]
        public string OC_CNUMREQ { get; set; }

        
        [StringLength(3)]
        public string OC_CSOLICI { get; set; }

        
        [StringLength(4)]
        public string OC_CITEREQ { get; set; }

        
        [StringLength(25)]
        public string OC_CREFCOD { get; set; }

        [StringLength(20)]
        public string OC_CPEDINT { get; set; }

        [StringLength(4)]
        public string OC_CITEINT { get; set; }

        
        [StringLength(25)]
        public string OC_CREFCOM { get; set; }

        
        [StringLength(50)]
        public string OC_CNOMFAB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANEMB { get; set; }

        public DateTime? OC_DFECENT { get; set; }

        
        [StringLength(1)]
        public string OC_CITMPOR { get; set; }

        
        [StringLength(1)]
        public string OC_CDSCPOR { get; set; }

        
        [StringLength(1)]
        public string OC_CIGVPOR { get; set; }

        
        [StringLength(1)]
        public string OC_CISCPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NTOTMO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NUNXENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NNUMENV { get; set; }

        [Column(TypeName = "numeric")]
        public decimal OC_NCANFAC { get; set; }

        public static void insertdetalleOT(OT_CO0003MOVD datad)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    ctx.Entry(datad).State = EntityState.Added;
                    ctx.SaveChanges();
                }
            }
            catch
            {
                using (var ctxM = new ANEXO_RSFACAR())
                {
                    ctxM.Entry(datad).State = EntityState.Modified;
                    ctxM.SaveChanges();
                }
            }
        }


        public static List<OT_CO0003MOVD> verListaOrden_OT(OT_CO0003MOVD CCAB)
        {
            List<OT_CO0003MOVD> listaA = new List<OT_CO0003MOVD>();
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    listaA = (from c in ctx.OT_CO0003MOVD where c.OC_CNUMORD == CCAB.OC_CNUMORD select c).ToList();
                }
            }
            catch 
            {
                throw;
            }
            return listaA;
        }

        //nuevo sergio 22032016
        public static void EliminaItemsDetalleOT(OT_CO0003MOVD DDET)
        {
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {

                    ctx.OT_CO0003MOVD.RemoveRange(ctx.OT_CO0003MOVD.Where(x => x.OC_CNUMORD == DDET.OC_CNUMORD.Trim()));
                    ctx.SaveChanges();
                }
            }
            catch
            {
                throw;
            }
        }


    }
}
