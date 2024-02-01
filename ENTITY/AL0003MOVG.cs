namespace ENTITY
{
    using CapaNegocio;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;
     
    public partial class AL0003MOVG
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string C6_CALMA { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string C6_CCODAGE { get; set; }

        [Key]
        [Column(Order = 2)]
        [StringLength(2)]
        public string C6_CTD { get; set; }

        [Key]
        [Column(Order = 3)]
        [StringLength(4)]
        public string C6_CNUMSER { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(11)]
        public string C6_CNUMDOC { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(4)]
        public string C6_CITEM { get; set; }

        [Key]
        [Column(Order = 6)]
        [StringLength(25)]
        public string C6_CCODIGO { get; set; }

        [Key]
        [Column(Order = 7)]
        [StringLength(12)]
        public string C6_CGRUPO { get; set; }

        [Key]
        [Column(Order = 8)]
        [StringLength(12)]
        public string C6_CFAMILI { get; set; }

        [Key]
        [Column(Order = 9)]
        [StringLength(12)]
        public string C6_CMODELO { get; set; }

        [Key]
        [Column(Order = 10)]
        [StringLength(12)]
        public string C6_CLINEA { get; set; }

        [Key]
        [Column(Order = 11, TypeName = "numeric")]
        public decimal C6_NCANTID { get; set; }

        [Key]
        [Column(Order = 12, TypeName = "numeric")]
        public decimal C6_NPREUNI { get; set; }

        [Key]
        [Column(Order = 13, TypeName = "numeric")]
        public decimal C6_NMNPRUN { get; set; }

        [Key]
        [Column(Order = 14, TypeName = "numeric")]
        public decimal C6_NUSPRUN { get; set; }

        [Key]
        [Column(Order = 15)]
        [StringLength(18)]
        public string C6_CSERIE { get; set; }

        public DateTime? C6_DFECDOC { get; set; }

        [Key]
        [Column(Order = 16)]
        [StringLength(12)]
        public string C6_CCENCOS { get; set; }

        [Key]
        [Column(Order = 17)]
        [StringLength(1)]
        public string C6_CTIPMOV { get; set; }

        [Key]
        [Column(Order = 18)]
        [StringLength(2)]
        public string C6_CCODMOV { get; set; }

        [Key]
        [Column(Order = 19)]
        [StringLength(18)]
        public string C6_CORDEN { get; set; }

        [Key]
        [Column(Order = 20, TypeName = "numeric")]
        public decimal C6_NVAVTMN { get; set; }

        [Key]
        [Column(Order = 21, TypeName = "numeric")]
        public decimal C6_NVAVTUS { get; set; }

        [Key]
        [Column(Order = 22, TypeName = "numeric")]
        public decimal C6_NVALTOT { get; set; }

        [Key]
        [Column(Order = 23, TypeName = "numeric")]
        public decimal C6_NMNIMPO { get; set; }

        [Key]
        [Column(Order = 24, TypeName = "numeric")]
        public decimal C6_NUSIMPO { get; set; }

        [Key]
        [Column(Order = 25)]
        [StringLength(4)]
        public string C6_CSUBDIA { get; set; }

        [Key]
        [Column(Order = 26)]
        [StringLength(6)]
        public string C6_CCOMPRO { get; set; }

        [Key]
        [Column(Order = 27)]
        [StringLength(2)]
        public string C6_CCODMON { get; set; }

        [Key]
        [Column(Order = 28)]
        [StringLength(1)]
        public string C6_CFSTOCK { get; set; }

        [Key]
        [Column(Order = 29)]
        [StringLength(1)]
        public string C6_CSTOCK { get; set; }

        [Key]
        [Column(Order = 30)]
        [StringLength(1)]
        public string C6_CGUIFAC { get; set; }

        [Key]
        [Column(Order = 31)]
        [StringLength(1)]
        public string C6_CPRIVAL { get; set; }

        [Key]
        [Column(Order = 32)]
        [StringLength(1)]
        public string C6_CTIPO { get; set; }

        [Key]
        [Column(Order = 33, TypeName = "numeric")]
        public decimal C6_NTIPCAM { get; set; }

        [Key]
        [Column(Order = 34)]
        [StringLength(2)]
        public string C6_CRFTDOC { get; set; }

        [Key]
        [Column(Order = 35)]
        [StringLength(24)]
        public string C6_CRFNDOC { get; set; }

        [Key]
        [Column(Order = 36)]
        [StringLength(4)]
        public string C6_CRFALMA { get; set; }

        [Key]
        [Column(Order = 37)]
        [StringLength(18)]
        public string C6_CCODPRO { get; set; }

        [Key]
        [Column(Order = 38)]
        [StringLength(18)]
        public string C6_CCODCLI { get; set; }

        [Key]
        [Column(Order = 39)]
        [StringLength(5)]
        public string C6_CVENDE { get; set; }

        [Key]
        [Column(Order = 40)]
        [StringLength(12)]
        public string C6_CCUENTA { get; set; }

        [Key]
        [Column(Order = 41)]
        [StringLength(1)]
        public string C6_CTIPORD { get; set; }

        [Key]
        [Column(Order = 42)]
        [StringLength(20)]
        public string C6_CNUMORD { get; set; }

        [Key]
        [Column(Order = 43)]
        [StringLength(12)]
        public string C6_CSOLI { get; set; }

        [Key]
        [Column(Order = 44)]
        [StringLength(50)]
        public string C6_CGLOSA { get; set; }

        [Key]
        [Column(Order = 45)]
        [StringLength(1)]
        public string C6_CTIPCOS { get; set; }

        [Key]
        [Column(Order = 46)]
        [StringLength(1)]
        public string C6_CTIPANE { get; set; }

        [StringLength(18)]
        public string C6_CCODANE { get; set; }

        [Key]
        [Column(Order = 47)]
        [StringLength(12)]
        public string C6_CCTACMO { get; set; }

        [Key]
        [Column(Order = 48)]
        [StringLength(12)]
        public string C6_CMARCA { get; set; }

        [Key]
        [Column(Order = 49)]
        [StringLength(12)]
        public string C6_CLUGORI { get; set; }

        [Key]
        [Column(Order = 50)]
        [StringLength(12)]
        public string C6_CANOFAB { get; set; }

        [Key]
        [Column(Order = 51)]
        [StringLength(12)]
        public string C6_CCUENTR { get; set; }


        public static List<VISTA_KARDEVAL> DetalleMovg(string fdoc, string fdoc2, string codigo)
        {
            string finicio = "", ffina = "", diax = "";
            finicio = "01/" + fdoc.Substring(5, 2) + "/" + fdoc.Substring(0, 4);
            diax = DateTime.DaysInMonth(Convert.ToInt32(fdoc2.Substring(0, 4)), Convert.ToInt32(fdoc2.Substring(5, 2))).ToString("D2");
            ffina = diax + "/" + fdoc2.Substring(5, 2) + "/" + fdoc2.Substring(0, 4);


            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(ffina);



            List<VISTA_KARDEVAL> datos = new List<VISTA_KARDEVAL>();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    //datos = (from AL0003MOVG in ctx.AL0003MOVG
                    //         where
                    //           (AL0003MOVG.C6_DFECDOC >= fin)
                    //           && AL0003MOVG.C6_DFECDOC <= ffn
                    //           && AL0003MOVG.C6_CCODIGO == codigo
                    //         orderby
                    //          AL0003MOVG.C6_DFECDOC,
                    //          AL0003MOVG.C6_CCODMOV descending,
                    //          (AL0003MOVG.C6_CCODMOV == "TD" ? (AL0003MOVG.C6_CTD)  : "" ) descending ,  
                    //          (AL0003MOVG.C6_CCODMOV == "PR" ? (AL0003MOVG.C6_CTD) : (AL0003MOVG.C6_CTD)) ascending, 
                    //          AL0003MOVG.C6_CNUMDOC
                    //         select new
                    //         {
                    //             AL0003MOVG.C6_CCODIGO,
                    //             AL0003MOVG.C6_DFECDOC,
                    //             AL0003MOVG.C6_CTD,
                    //             AL0003MOVG.C6_CCODMOV,
                    //             AL0003MOVG.C6_CALMA,
                    //             AL0003MOVG.C6_CNUMDOC,
                    //             AL0003MOVG.C6_CRFNDOC,
                    //             AL0003MOVG.C6_CCODPRO,
                    //             AL0003MOVG.C6_NMNPRUN,
                    //             AL0003MOVG.C6_NUSPRUN,
                    //             AL0003MOVG.C6_NCANTID,
                    //             AL0003MOVG.C6_NMNIMPO,
                    //             AL0003MOVG.C6_NUSIMPO,
                    //             AL0003MOVG.C6_CGLOSA
                    //         }
                    //        ).ToList().Select(g => new AL0003MOVG()
                    //        {
                    //            C6_CCODIGO = g.C6_CCODIGO,
                    //            C6_DFECDOC = g.C6_DFECDOC,
                    //            C6_CTD = g.C6_CTD,
                    //            C6_CCODMOV = g.C6_CCODMOV,
                    //            C6_CALMA = g.C6_CALMA,
                    //            C6_CNUMDOC = g.C6_CNUMDOC,
                    //            C6_CRFNDOC = g.C6_CRFNDOC,
                    //            C6_CCODPRO = CT0003ANEX.obtenProveedor(g.C6_CCODPRO).ADESANE,
                    //            C6_NMNPRUN = g.C6_NMNPRUN,
                    //            C6_NUSPRUN = g.C6_NUSPRUN,
                    //            C6_NCANTID = g.C6_NCANTID,
                    //            C6_NMNIMPO = g.C6_NMNIMPO,
                    //            C6_NUSIMPO = g.C6_NUSIMPO,
                    //            C6_CGLOSA = g.C6_CGLOSA
                    //        }).ToList();
                    //var consul = "select C6_DFECDOC, C6_CTD, C6_CNUMDOC, C6_CCODMOV, C6_CCODIGO, C6_CALMA, C6_CRFNDOC, C6_CCODPRO, C6_NMNPRUN, C6_NUSPRUN, C6_NCANTID, C6_NMNIMPO, C6_NUSIMPO, C6_CGLOSA";
                    //consul = consul + "from AL0003MOVG" ;
                    //consul = consul + "where C6_DFECDOC >= '"+ finicio + "' and C6_DFECDOC <= '"+ffina+"'";
                    //consul = consul + "and C6_CCODIGO ='"+ codigo + "' ";
                    //consul = consul + "order by C6_DFECDOC, C6_CCODMOV desc";
                    //consul = consul + ", (case when C6_CCODMOV = 'TD' then  C6_CTD end) desc";
                    //consul = consul + ",(case when C6_CCODMOV != 'TD' then C6_CTD end ) asc";
                    //consul = consul + ",C6_CNUMDOC";
                    //datos = ctx.VISTA_KARDEVAL.SqlQuery(consul).ToList();

                    var consul = "exec PR_KARDEX_PERIODO @fin ='"+ finicio + "',@ffn='" + ffina + "',@codigo='"+ codigo + "' ";
                    datos = ctx.VISTA_KARDEVAL.SqlQuery(consul).ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }


        //nuevo 14/04/2016 sergio
        public static List<VISTA_MOVG> DetalleMovgdistinc(string fdoc, string fdoc2, string codigo, string codigo2, string almacen, string foragrupa)
        {
            string finicio = "", ffina = "", diax = "";
            finicio = "01/" + fdoc.Substring(5, 2) + "/" + fdoc.Substring(0, 4);
            diax = DateTime.DaysInMonth(Convert.ToInt32(fdoc2.Substring(0, 4)), Convert.ToInt32(fdoc2.Substring(5, 2))).ToString("D2");
            ffina = diax + "/" + fdoc2.Substring(5, 2) + "/" + fdoc2.Substring(0, 4);

            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(ffina);

            List<VISTA_MOVG> datos = new List<VISTA_MOVG>();
            //Int64 ccod = 0;
            List<AL0003ARTI> aff = new List<AL0003ARTI>();
            List<AL0003TABL> aff2 = new List<AL0003TABL>();
            string[] listaprod=new string[0] ;
            //if (foragrupa == "4")
            //{
            //    aff = AL0003ARTI.ListarArticulosParaKardex(codigo, codigo2);
            //    listaprod = new string[aff.Count()];
            //    foreach (var sd in aff)
            //    {
            //        listaprod[ccod] = sd.AR_CCODIGO;
            //        ccod++;
            //    }
            //}
            //else if (foragrupa == "5")
            //{
            //    aff2 = AL0003TABL.ListarCCostoParaKardex(codigo, codigo2);
            //listaprod = new string[aff2.Count()];
            //    foreach (var sd in aff2)
            //    {
            //        listaprod[ccod] = sd.TG_CCLAVE.Trim();
            //        ccod++;
            //    }
            //}

            //Cls_ConsultasCN consulta = new Cls_ConsultasCN("RSFACAR");
           //var da = consulta.funConsumoCCost(foragrupa, almacen, fin.ToString(), ffn.ToString(), codigo, codigo2);

            try
            {
                using (var ctx = new RSFACAR())
                {


                    datos = ctx.VISTA_MOVG.SqlQuery("exec PR_CONSUMO_CC @foragrupa='" + foragrupa + "',@almacen='" + almacen + "',@fin='" + finicio + "',@ffn='" + ffina + "',@codigo='" + codigo + "',@codigo2='" + codigo2 + "' ").ToList();


                    //datos  =// consulta.funConsumoCCost(foragrupa, almacen, fin, ffn, codigo, codigo2);
                    //datos = (from ff in ctx.AL0003MOVG
                    //         where
                    //           (ff.C6_DFECDOC >= fin)
                    //           && ff.C6_DFECDOC <= ffn
                    //           && (almacen == "-1" ? ff.C6_CALMA != almacen : ff.C6_CALMA == almacen)
                    //           && ff.C6_CCODMOV == "PR"
                    //          // && (listaprod.Distinct().Contains(ff.C6_CCENCOS))
                    //         && ( foragrupa=="4" ? (listaprod.Distinct()).Contains(ff.C6_CCODIGO) : (listaprod.Distinct().Contains(ff.C6_CCENCOS)) )  

                    //         select new
                    //         {
                    //             C6_CCODIGO = ff.C6_CCODIGO,
                    //             C6_CCENCOS = ff.C6_CCENCOS //AL0003MOVG.C6_CCENCOS,
                    //             //AL0003MOVG.C6_CFAMILI
                    //         }
                    //        ).ToList().Distinct().Select(g => new AL0003MOVG()
                    //        {
                    //            C6_CCODIGO = g.C6_CCODIGO,
                    //            C6_CCENCOS = g.C6_CCENCOS
                    //            //C6_CGLOSA = AL0003ARTI.obtenerArticuloPorID(g.C6_CCODIGO).AR_CDESCRI,
                    //            //C6_CFAMILI =  AL0003ARTI.obtenerArticuloPorID(g.C6_CCODIGO).AR_CUNIDAD

                    //        }).Distinct().ToList();

                }
            }
            catch (Exception)
            {
                throw;
            }
            return datos;
        }

        public static AL0003MOVG DetalleMovgSuma(string fdoc, string fdoc2, string codigo, string insa, string almacen,string ccosto)
        {
            string finicio = "", ffina = "", diax = "";
            finicio = "01/" + fdoc.Substring(5, 2) + "/" + fdoc.Substring(0, 4);
            diax = DateTime.DaysInMonth(Convert.ToInt32(fdoc2.Substring(0, 4)), Convert.ToInt32(fdoc2.Substring(5, 2))).ToString("D2");
            ffina = diax + "/" + fdoc2.Substring(5, 2) + "/" + fdoc2.Substring(0, 4);

            DateTime fin = Convert.ToDateTime(finicio);
            DateTime ffn = Convert.ToDateTime(ffina);

            AL0003MOVG datos = new AL0003MOVG();
            try
            {
                using (var ctx = new RSFACAR())
                {
                    datos = (from AL0003MOVG in ctx.AL0003MOVG
                             where
                               (AL0003MOVG.C6_DFECDOC >= fin)
                               && AL0003MOVG.C6_DFECDOC <= ffn
                               && AL0003MOVG.C6_CCODIGO == codigo
                               && (almacen == "-1" ? AL0003MOVG.C6_CALMA != almacen : AL0003MOVG.C6_CALMA == almacen)
                               && AL0003MOVG.C6_CTD == insa 
                               && AL0003MOVG.C6_CCENCOS == ccosto
                               && (from AL0003TABM in ctx.AL0003TABM
                                   where AL0003TABM.TM_CFLGCSM == "S" && AL0003TABM.TM_CTIPMOV == insa.Substring(1, 1)
                                   select new { AL0003TABM.TM_CCODMOV }).Contains(new { TM_CCODMOV = AL0003MOVG.C6_CCODMOV })

                             group AL0003MOVG by new
                             {
                                 AL0003MOVG.C6_CCODIGO
                             } into g
                             select new
                             {
                                 C6_NUSIMPO = (decimal?)g.Sum(r => r.C6_NUSIMPO),
                                 C6_NMNIMPO = (decimal?)g.Sum(r => r.C6_NMNIMPO),
                                 C6_NCANTID = (decimal?)g.Sum(r => r.C6_NCANTID)

                             }
                            ).ToList().Select(h => new AL0003MOVG()
                            {
                                C6_NUSIMPO = Convert.ToDecimal(h.C6_NUSIMPO),
                                C6_NMNIMPO = Convert.ToDecimal(h.C6_NMNIMPO),
                                C6_NCANTID = Convert.ToDecimal(h.C6_NCANTID),
                            }).FirstOrDefault();

                }
            }
            catch (Exception)
            {
                datos = null;
            }
            return datos;
        }

        public static string Mesletras(int numero)
        {
            string[] mesl = new string[12];
            mesl[0] = "ENERO";
            mesl[1] = "FEBRERO";
            mesl[2] = "MARZO";
            mesl[3] = "ABRIL";
            mesl[4] = "MAYO";
            mesl[5] = "JUNIO";
            mesl[6] = "JULIO";
            mesl[7] = "AGOSTO";
            mesl[8] = "SETIEMBRE";
            mesl[9] = "OCTUBRE";
            mesl[10] = "NOVIEMBRE";
            mesl[11] = "DICIEMBRE";

            return mesl[numero - 1];
        }


    }
}
