namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
    [Table("TABLCONSUCTA")]
    public partial class TABLCONSUCTA
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(12)]
        public string C6_CCENCOS { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(12)]
        public string C6_CCUENTA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? C6_NCANTID { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? C6_NUSIMPO { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? C6_NMNIMPO { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(12)]
        public string RUB { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(100)]
        public string CTAV { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(100)]
        public string C6_ANIO { get; set; }


        [StringLength(100)]
        public string CTADEST { get; set; }

        [StringLength(100)]
        public string CTACONS { get; set; }

        [StringLength(200)]
        public string DESALMA { get; set; }

        //DESCRIPCION DE LA CUENTA 
        [StringLength(200)]
        public string PDESCRI { get; set; }

        [StringLength(210)]
        public string DESCRUB { get; set; }

        [StringLength(10)]
        public string AR_CUNIDAD { get; set; }

        [StringLength(30)]
        public string IP_PC { get; set; }


        public static List<TABLCONSUCTA> LstAsientoConsu(string ip, string almacen)
        {
            int vlalma = (almacen == "0016" || almacen == "0017") ? 1 : 0;
            List<TABLCONSUCTA> lst = new List<TABLCONSUCTA>();
            List<TABLCONSUCTA> lst2 = new List<TABLCONSUCTA>();
            List<TABLCONSUCTA> lst3 = new List<TABLCONSUCTA>();
            List<TABLCONSUCTA> lst4 = new List<TABLCONSUCTA>();
            using (var ctx = new RSFACAR())
            {
                lst = (from c in ctx.TABLCONSUCTA
                       where c.IP_PC == ip.Trim()
                       orderby c.DESCRUB, c.PDESCRI, c.CTACONS
                       group c by new
                       {
                           c.RUB,
                           c.C6_CCUENTA,
                           c.CTACONS
                       } into a
                       select new
                       {
                           d01 = a.Key.RUB,
                           d02 = a.Key.C6_CCUENTA,
                           d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                           d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                           d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO),
                           d06 = a.Key.CTACONS
                       }
                       ).ToList().Select(q => new TABLCONSUCTA()
                       {
                           RUB = tabla_parametros.ListarParametroID("PA", q.d01),
                           C6_CCUENTA = q.d06, //== null ?"":(vlalma==1? (q.d06.Split('-').Length== 1 ? "": q.d06.Split('-')[1]) : q.d06.Split('-')[0] == "" ? q.d06 : q.d06.Split('-')[0]) ,
                           CTAV = CT0003PLEM.RegistrounCta(q.d02),//CT0003PLEM.RegistrounCta(q.d02),
                           C6_CCODIGO = tabla_parametros.ListarParametroDescr1("32", q.d06 == null ? "" : q.d06.Substring(0, 2)),//tabla_parametros.ListarParametroDescr1(q.d01, q.d02),//CUENTA DESTINO
                           C6_NMNIMPO = q.d04,
                           C6_NUSIMPO = q.d05,
                           IP_PC = "" 
                       }).ToList();

                lst2 = (from c in ctx.TABLCONSUCTA
                        where c.IP_PC == ip.Trim()
                        group c by new
                        {
                            //c.RUB,
                            c.CTADEST,
                        } into a
                        select new
                        {
                            d01 = "",//a.Key.RUB,
                            d02 = a.Key.CTADEST,
                            d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                            d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                            d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO)
                        }).ToList().Select(q => new TABLCONSUCTA()
                        {
                            RUB = tabla_parametros.ListarParametroID("PA", q.d01),
                            C6_CCUENTA = q.d02, ///== null ? "" : (vlalma == 1 ? (q.d02.Split('-').Length == 1 ? "" : q.d02.Split('-')[1]) : q.d02.Split('-')[0] == "" ? q.d02 : q.d02.Split('-')[0]), //q.d02,
                            CTAV = "VARIOS",
                            C6_CCODIGO = tabla_parametros.ListarParametroDescr1("32", q.d02 == null ? "" : q.d02.Substring(0, 2)),//CUENTA DESTINO
                            C6_NMNIMPO = q.d04,
                            C6_NUSIMPO = q.d05,
                            IP_PC=""
                        }).ToList();


                lst3 = (from c in ctx.TABLCONSUCTA
                       where c.IP_PC == ip.Trim()
                       orderby c.DESCRUB, c.PDESCRI, c.CTACONS
                       group c by new
                       {
                           c.RUB,
                           c.C6_CCUENTA,
                           c.CTACONS
                       } into a
                       select new
                       {
                           d01 = a.Key.RUB,
                           d02 = a.Key.C6_CCUENTA,
                           d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                           d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                           d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO),
                           d06 = a.Key.CTACONS
                       }).ToList().Select(q => new TABLCONSUCTA()
                       {
                           RUB = tabla_parametros.ListarParametroID("PA", q.d01),
                           C6_CCUENTA = CT0003PLEM.InfCtaOBJ(q.d06) ==null?"": CT0003PLEM.InfCtaOBJ(q.d06).PCTACAR, //== null ?"":(vlalma==1? (q.d06.Split('-').Length== 1 ? "": q.d06.Split('-')[1]) : q.d06.Split('-')[0] == "" ? q.d06 : q.d06.Split('-')[0]) ,
                           CTAV = CT0003PLEM.RegistrounCta(q.d02),//CT0003PLEM.RegistrounCta(q.d02),
                           C6_CCODIGO = "D",//tabla_parametros.ListarParametroDescr1("32", q.d06 == null ? "" : q.d06.Substring(0, 2)),//tabla_parametros.ListarParametroDescr1(q.d01, q.d02),//CUENTA DESTINO
                           C6_NMNIMPO = q.d04,
                           C6_NUSIMPO = q.d05,
                           IP_PC = q.d06
                       }).ToList();

                lst4 = (from c in ctx.TABLCONSUCTA
                        where c.IP_PC == ip.Trim()
                        orderby c.DESCRUB, c.PDESCRI, c.CTACONS
                        group c by new
                        {
                            c.RUB,
                            c.C6_CCUENTA,
                            c.CTACONS
                        } into a
                        select new
                        {
                            d01 = a.Key.RUB,
                            d02 = a.Key.C6_CCUENTA,
                            d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                            d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                            d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO),
                            d06 = a.Key.CTACONS
                        }).ToList().Select(q => new TABLCONSUCTA()
                        {
                            RUB = tabla_parametros.ListarParametroID("PA", q.d01),
                            C6_CCUENTA = CT0003PLEM.InfCtaOBJ(q.d06) == null ? "" : CT0003PLEM.InfCtaOBJ(q.d06).PCTAABO, //== null ?"":(vlalma==1? (q.d06.Split('-').Length== 1 ? "": q.d06.Split('-')[1]) : q.d06.Split('-')[0] == "" ? q.d06 : q.d06.Split('-')[0]) ,
                            CTAV = CT0003PLEM.RegistrounCta(q.d02),//CT0003PLEM.RegistrounCta(q.d02),
                            C6_CCODIGO = "H",//tabla_parametros.ListarParametroDescr1("32", q.d06 == null ? "" : q.d06.Substring(0, 2)),//tabla_parametros.ListarParametroDescr1(q.d01, q.d02),//CUENTA DESTINO
                            C6_NMNIMPO = q.d04,
                            C6_NUSIMPO = q.d05,
                            IP_PC = q.d06
                        }).ToList();

            }
            return lst.Union(lst2).Union(lst3).Union(lst4).ToList();

        }


        public static List<TABLCONSUCTA> LstAsientoConsuCond(TABLCONSUCTA PRM, List<RConsumo> tcona)
        {
            List<TABLCONSUCTA> lst = new List<TABLCONSUCTA>();
            try
            {

                //using (var ctx = new RSFACAR())
                //{
                lst = (from c in tcona
                       where
                       (c.C6_CALMA == PRM.C6_CALMA && c.C6_CCODIGO.Trim() == PRM.C6_CCODIGO.Trim() && c.C6_CCENCOS == PRM.C6_CCENCOS
                       && c.C6_ANIO == PRM.C6_ANIO && c.C6_CCUENTA.Trim() == PRM.C6_CCUENTA.Trim())
                       group c by new
                       {
                           c.RUB,
                           c.C6_CCUENTA,

                       } into a
                       select new
                       {
                           d01 = a.Key.RUB,
                           d02 = a.Key.C6_CCUENTA,
                           d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                           d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                           d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO)
                       }

                       ).ToList().Select(q => new TABLCONSUCTA()
                       {
                           RUB = tabla_parametros.ListarParametroID("PA", q.d01),
                           C6_CCUENTA = q.d02,
                           CTAV = CT0003PLEM.RegistrounCta(q.d02),
                           C6_CCODIGO = tabla_parametros.ListarParametroDescr1(q.d01, q.d02),//CUENTA DESTINO
                           C6_NMNIMPO = q.d04,
                           C6_NUSIMPO = q.d05,
                           C6_NCANTID = q.d03
                       }
                    ).ToList();
                //}
            }
            catch
            {
                lst = null;
            }
            return lst;
        }



        public static List<TABLCONSUCTA> LstAsientoGroup()
        {
            List<TABLCONSUCTA> lst = new List<TABLCONSUCTA>();
            using (var ctx = new RSFACAR())
            {
                lst = (from c in ctx.TABLCONSUCTA
                       group c by new
                       {
                           c.C6_CCENCOS,
                           c.C6_CCUENTA,
                           c.C6_CCODIGO,
                           c.C6_CALMA
                       } into a
                       select new
                       {
                           d01 = a.Key.C6_CCENCOS,
                           d02 = a.Key.C6_CCUENTA,
                           d03 = (decimal?)a.Sum(y => y.C6_NCANTID),
                           d04 = (decimal?)a.Sum(y => y.C6_NMNIMPO),
                           d05 = (decimal?)a.Sum(y => y.C6_NUSIMPO),
                           d06 = a.Key.C6_CCODIGO,
                           d07 = a.Key.C6_CALMA,
                       }

                       ).ToList().Select(q => new TABLCONSUCTA()
                       {
                           C6_CCENCOS = q.d01,
                           C6_CCUENTA = q.d02,
                           C6_CCODIGO = q.d06,
                           C6_CALMA = q.d07,
                           C6_NMNIMPO = q.d04,
                           C6_NUSIMPO = q.d05,
                           C6_NCANTID = q.d03

                       }
                    ).ToList();
            }
            return lst;
        }





    }
}
