namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;


    [Table("CTCAMB")]
    public partial class CTCAMB
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(2)]
        public string XCODMON { get; set; }

        [Required]
        [StringLength(6)]
        public string XFECCAM { get; set; }

        [Column(TypeName = "numeric")]
        public decimal XMEIMP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal XMNIMP { get; set; }

        [Column(TypeName = "numeric")]
        public decimal XMEIMP2 { get; set; }

        [Column(TypeName = "numeric")]
        public decimal XMNIMP2 { get; set; }

        public DateTime? XDATE { get; set; }

        [Key]
        [Column(Order = 1)]
        public DateTime XFECCAM2 { get; set; }

        public static CTCAMB obetenertcambio(CTCAMB CTCAMB)
        {
            var tcam = new CTCAMB();

            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tcam = ctx.CTCAMB.Where(x => x.XFECCAM2 == CTCAMB.XFECCAM2).FirstOrDefault();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tcam;
        }
        //NUEVO WILLIAM
        public static string existeTC(CTCAMB CTCAMB)
        {
            var tcam = "";
            //DateTime f1 = Convert.ToDateTime(CTCAMB.XFECCAM2);
            try
            {
                using (var ctx = new RSCONCAR())
                {
                    tcam = ctx.CTCAMB.Where(x => x.XFECCAM2 >= CTCAMB.XFECCAM2 && x.XFECCAM2 <= CTCAMB.XFECCAM2).Count().ToString();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return tcam;
        }

    }
}
