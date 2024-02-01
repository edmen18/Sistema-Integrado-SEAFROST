namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;
    using System.Data.Entity.Spatial;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Linq;
    public partial class tabla_servicios
    {
        
        [StringLength(25)]
        public string AR_CCODIGO { get; set; }

        [StringLength(60)]
        public string AR_CDESCRI { get; set; }

        [StringLength(60)]
        public string AR_CDESCR2 { get; set; }

        [StringLength(25)]
        public string AR_CCODIG2 { get; set; }

        [StringLength(3)]
        public string AR_CUNIDAD { get; set; }

        [StringLength(12)]
        public string AR_CCUENTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI3 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI4 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI5 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECI6 { get; set; }

        [StringLength(2)]
        public string AR_CMONVTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NIGVPOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NISCPOR { get; set; }

        [StringLength(1)]
        public string AR_CTIPO { get; set; }

        [StringLength(1)]
        public string AR_CCONTRO { get; set; }

        [StringLength(3)]
        public string AR_CTIPDES { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NDESCTO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NDESCT2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPDIS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPCOM { get; set; }

        [StringLength(8)]
        public string AR_CGRUPO { get; set; }

        
        [StringLength(8)]
        public string AR_CFAMILI { get; set; }

        [StringLength(8)]
        public string AR_CMODELO { get; set; }

        [Key]
        [StringLength(4)]
        public string AR_CLINEA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPESO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NVOLUME { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NAREA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NFACTOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NANCHO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NLARGO { get; set; }

        [StringLength(2)]
        public string AR_CMONCOS { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECOS { get; set; }

        public DateTime? AR_DFECCOS { get; set; }

        [StringLength(2)]
        public string AR_CMONCOM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPRECOM { get; set; }

        public DateTime? AR_DFECCOM { get; set; }

        [StringLength(18)]
        public string AR_CCODPRO { get; set; }

        [StringLength(2)]
        public string AR_CMONFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPREFOB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARGE2 { get; set; }

        [StringLength(3)]
        public string AR_CCLAART { get; set; }

        [StringLength(15)]
        public string AR_CPARARA { get; set; }

        [StringLength(50)]
        public string AR_CINFTEC { get; set; }

        [StringLength(50)]
        public string AR_CCATALO { get; set; }

        [StringLength(2)]
        public string AR_CCATEGO { get; set; }

        [StringLength(2)]
        public string AR_CTIPOI { get; set; }

        [StringLength(800)]
        public string AR_TOBSERV { get; set; }

        [StringLength(3)]
        public string AR_CUNIREF { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NFACREF { get; set; }

        [StringLength(1)]
        public string AR_CFUNIRE { get; set; }

        [StringLength(1)]
        public string AR_CFSTOCK { get; set; }

        [StringLength(1)]
        public string AR_CFDECI { get; set; }

        [StringLength(1)]
        public string AR_CFPRELI { get; set; }

        [StringLength(1)]
        public string AR_CFRESTA { get; set; }

        [StringLength(1)]
        public string AR_CFSERIE { get; set; }

        [StringLength(1)]
        public string AR_CFLOTE { get; set; }

        [StringLength(1)]
        public string AR_CFROTAB { get; set; }

        [StringLength(5)]
        public string AR_CUSUCRE { get; set; }

        [StringLength(5)]
        public string AR_CUSUMOD { get; set; }

        [StringLength(1)]
        public string AR_CESTADO { get; set; }

        public DateTime? AR_DFECCRE { get; set; }

        public DateTime? AR_DFECMOD { get; set; }

        [StringLength(25)]
        public string AR_CCODANT { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NDETRA { get; set; }

        [StringLength(6)]
        public string AR_CMEDIDA { get; set; }

        [StringLength(9)]
        public string AR_CANNO { get; set; }

        [StringLength(15)]
        public string AR_CGROSOR { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NIMAGEN { get; set; }

        [StringLength(6)]
        public string AR_CFECABC { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NLONSER { get; set; }

        [StringLength(1)]
        public string AR_CFCELU { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NLONCEL { get; set; }

        [StringLength(12)]
        public string AR_CMEDNEU { get; set; }

        [StringLength(12)]
        public string AR_CINDCAR { get; set; }

        [StringLength(12)]
        public string AR_CDISENO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPERC1 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NPERC2 { get; set; }

        [StringLength(8)]
        public string AR_CMARCA { get; set; }

        [StringLength(4)]
        public string AR_CANOFAB { get; set; }

        [StringLength(8)]
        public string AR_CLUGORI { get; set; }

        [StringLength(1)]
        public string AR_CFVEHI { get; set; }

        [StringLength(1)]
        public string AR_CAYUVEN { get; set; }

        [StringLength(20)]
        public string AR_CCOLOR { get; set; }

        [StringLength(20)]
        public string AR_CTALLA { get; set; }

        [StringLength(4)]
        public string AR_CTIPEXI { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NMARVTA { get; set; }

        [StringLength(10)]
        public string AR_CHORSER { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NIGVCPR { get; set; }

        [StringLength(12)]
        public string AR_CCUENTR { get; set; }

        [StringLength(1)]
        public string AR_CFLGRCN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? AR_NTASRCN { get; set; }

        [StringLength(18)]
        public string AR_CFORSER { get; set; }

        [StringLength(8)]
        public string AR_CCODAG1 { get; set; }

        [StringLength(8)]
        public string AR_CCODAG2 { get; set; }

        [StringLength(8)]
        public string AR_CCODAG3 { get; set; }

        [StringLength(8)]
        public string AR_CCODAG4 { get; set; }

        [StringLength(8)]
        public string AR_CCODAG5 { get; set; }

        [StringLength(10)]
        public string AR_PERTOPE { get; set; }

        public static void ActualizatmpAL(tabla_servicios AINF)
        {
            using (ANEXO_RSFACAR ctx = new ANEXO_RSFACAR())
            {
                var ACDAt = (from c in ctx.tabla_servicios  select c).FirstOrDefault();
                //where c.AR_CCODIGO.Trim() == "R051530002008"
                ctx.Entry(ACDAt).State = EntityState.Modified;

                //ctx.tabla_servicios.Attach(ACDAt); 
                ACDAt.AR_CCODIGO = AINF.AR_CCODIGO; 
                ACDAt.AR_CDESCRI = AINF.AR_CDESCRI; 
                ACDAt.AR_NPRECOM = AINF.AR_NPRECOM; 
                ACDAt.AR_CMONCOM = AINF.AR_CMONCOM; 
                ACDAt.AR_CUSUCRE = AINF.AR_CUSUCRE; 
                ACDAt.AR_DFECCRE = AINF.AR_DFECCRE; 
                ACDAt.AR_CCUENTA = AINF.AR_CCUENTA; 
                ACDAt.AR_CPARARA = AINF.AR_CPARARA; 
                ACDAt.AR_CTIPDES = AINF.AR_CTIPDES; 
                ACDAt.AR_CCONTRO = AINF.AR_CCONTRO;
                ACDAt.AR_CCODPRO = AINF.AR_CCODPRO;
                //ctx.Configuration.ValidateOnSaveEnabled = false;
                try
                {
                    ctx.SaveChanges();
                }
                catch (DbEntityValidationException dbEx)
                {
                    foreach (var validationErrors in dbEx.EntityValidationErrors)
                    {
                        foreach (var validationError in validationErrors.ValidationErrors)
                        {
                            Trace.TraceInformation("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                        }
                    }
                  
                }

            }
        }


        public static tabla_servicios ListarTarificaO(string idprod)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                return ctx.tabla_servicios.Where(rr => rr.AR_CCODIGO.Trim() == idprod.Trim()).FirstOrDefault();
            }
        }



    }
}
