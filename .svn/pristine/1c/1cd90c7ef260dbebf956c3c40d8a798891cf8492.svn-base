namespace ENTITY
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Data.Entity.Spatial;

    [Table("DetPlanilla")]
    public partial class DetPlanillaCG
    {
        [Key]
        public int coddetpla { get; set; }

        [StringLength(20)]
        public string codtra { get; set; }

        [Column(TypeName = "money")]
        public decimal? kilos { get; set; }

        public int? numplanilla { get; set; }

        [StringLength(30)]
        public string codp { get; set; }

        [StringLength(30)]
        public string codpr { get; set; }

        [StringLength(30)]
        public string codt { get; set; }

        public int? numplanilla1 { get; set; }

        [StringLength(30)]
        public string ip { get; set; }

        [StringLength(200)]
        public string detalleTrabajador { get; set; }

        public int? condicion { get; set; }

        [StringLength(20)]
        public string dni { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? horas { get; set; }

        [StringLength(20)]
        public string codtra1 { get; set; }


        public static List<vista_planilla> lista_planilla(T_Planilla COM,string area)
        {
            var Listarep = new List<vista_planilla>();
            if (area == "1") { 

            using (var ctx = new SEAPLANILLASRRHH())
            {
                  using (var cct = new ANEXO_RSFACAR()) {
                    
                    var listanpla = (from dg in cct.tabla_plan_ord select dg.BK_PLANI).ToList();
                    var listancod = (from dg in cct.tabla_plan_ord select dg.BK_CODPLAN).ToList();
                    var listancant = (from dg in cct.tabla_plan_ord select dg.BK_CANT).ToList();

                    Listarep = (from a in ctx.T_Planilla
                            join b in ctx.DetPlanilla on a.NumPlanilla equals b.numplanilla
                            where b.codtra == COM.responsable && (a.FecProduc >= COM.fecha && a.FecProduc <= COM.FecProduc)
                            &&
                            (!(listanpla).Contains(b.numplanilla.ToString())  || !(listancod).Contains(b.codt.ToString()))

                            select new
                            {
                                data1 = a.FecProduc,
                                data2 = b.codtra,
                                data3 = b.detalleTrabajador,
                                data4 = a.NumPlanilla,
                                data5 = ((from t in ctx.T_Producto
                                          where t.codp.Trim() == b.codp
                                          select new { t.desp }).FirstOrDefault().desp),//a.codp,
                                data6 = ((from t in ctx.T_Presentacion
                                          where t.codpr.Trim() == b.codpr
                                          select new { t.despr }).FirstOrDefault().despr),
                                data7 = ((from t in ctx.T_Tarea
                                          where t.codt.Trim() == b.codt
                                          select new { t.dest }).FirstOrDefault().dest),
                                data8 = b.kilos,
                                data9 = ((from t in ctx.T_TarGral
                                          where t.codt.Trim() == b.codt
                                          select new { t.tar }).FirstOrDefault().tar) / 1000,//tarifa
                                data10 = (((from t in ctx.T_TarGral
                                            where t.codt.Trim() == b.codt
                                            select new { t.tar }).FirstOrDefault().tar) * b.kilos) / 1000,
                                data11 = (a.codturno == "001" ? "Dia" : "Noche"),
                                data12 = ((from t in ctx.T_TarGral
                                           where t.codt.Trim() == b.codt
                                           select new { t.codsofcom }).FirstOrDefault().codsofcom),//codigo sofcom
                                data13 = b.codt,//codigo planilla
                                data14 = b.coddetpla,
                                data15 =a.guia

                            }).ToList().Select(c => new vista_planilla()
                            {
                                PL_fecha = String.Format("{0:dd/MM/yyyy}", c.data1),
                                PL_codigo = c.data2,
                                PL_servis = c.data3,
                                PL_planilla = c.data4.ToString(),
                                PL_especie = c.data5,
                                PL_presentacion = c.data6,
                                PL_tarea = c.data7,
                                PL_cantidad = Convert.ToDecimal(c.data8),
                                PL_tarifa = Convert.ToDecimal(c.data9),
                                PL_total = Convert.ToDecimal(c.data10),
                                PL_turno = c.data11,
                                PL_codsofcom = c.data12,
                                PL_codplanilla = c.data13,
                                PL_coddetpla =  c.data14.ToString().Substring((c.data14.ToString().Length - 4),4), 
                                PL_guia=c.data15
                            }).ToList();

            }
        }

            }
            else
            {
                Listarep = DetPlanilla.lista_planillaCS(COM);
            }
            return Listarep;
        }
    }
}
