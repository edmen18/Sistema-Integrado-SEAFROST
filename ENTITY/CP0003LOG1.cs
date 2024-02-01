namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    using System.Data.Entity;
    using System.Data.Entity.Validation;
    using System.Diagnostics;
    using System.Data;

    public partial class CP0003LOG1
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string CSUBDIA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(6)]
        public string CCOMPRO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(6)]
        public string CFECCOM { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(1)]
        public string CSITUA { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(2)]
        public string CCODMON { get; set; }

        [Key]
        [Column(Order = 5, TypeName = "numeric")]
        public decimal CTIPCAM { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(40)]
        public string CGLOSA { get; set; }

        [Key]
        [Column(Order = 7, TypeName = "numeric")]
        public decimal CTOTAL { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(1)]
        public string CTIPO { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(1)]
        public string CFLAG { get; set; }

        public DateTime? CDATE { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(6)]
        public string CHORA { get; set; }

        [Key]
        [Column(Order = 11)]
        [StringLength(6)]
        public string CFECCAM { get; set; }

        [Key]
        [Column(Order = 12)]
        [StringLength(5)]
        public string CUSER { get; set; }

        [Key]
        [Column(Order = 13)]
        [StringLength(2)]
        public string CORIG { get; set; }

        [Key]
        [Column(Order = 14)]
        [StringLength(1)]
        public string CFORM { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(2)]
        public string CTIPCOM { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(2)]
        public string CDPTO { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(1)]
        public string CEXTOR { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(2)]
        public string CTIPTRA { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(30)]
        public string CCOMEN { get; set; }

        [Key]
        [Column(Order = 20)]
        [StringLength(30)]
        public string CCOMEN2 { get; set; }

        [Key]
        [Column(Order = 21)]
        public DateTime CDATE2 { get; set; }

        [Key]
        [Column(Order = 22)]
        [StringLength(6)]
        public string CHORA2 { get; set; }

        [Key]
        [Column(Order = 23)]
        [StringLength(5)]
        public string CUSER2 { get; set; }

        public DateTime? CFECCOM2 { get; set; }

        public DateTime? CFECCAM2 { get; set; }

        public static Boolean insertaCabecera(CP0003LOG1 datos)
        {
            Boolean band = true;
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    ctx.Entry(datos).State = EntityState.Added;
                    ctx.SaveChanges();
                }
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
                band = false;
            }
            return band;
        }
    }
}
