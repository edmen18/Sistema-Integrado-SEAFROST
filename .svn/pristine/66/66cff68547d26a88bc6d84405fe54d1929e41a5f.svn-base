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
    public partial class tabla_solicitud
    {
       
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SM_ID { get; set; }

        [StringLength(10)]
        public string SM_IDSOLI { get; set; }

        public DateTime? SM_FECHA { get; set; }

        [StringLength(500)]
        public string SM_GLOSA { get; set; }

        [StringLength(10)]
        public string SM_AREA { get; set; }

        public DateTime? SM_FECHAACT { get; set; }

        [StringLength(6)]
        public string SM_USUA { get; set; }

        [StringLength(2)]
        public string SM_ESTADO { get; set; }

        [StringLength(1)]
        public string SM_ATENC { get; set; }

        [StringLength(20)]
        public string SM_ORDTRA { get; set; }

        [StringLength(20)]
        public string SM_MONEDA { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SM_TCAMB { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SM_TOTALMN { get; set; }

        [Column(TypeName = "numeric")]
        public decimal? SM_TOTALUS { get; set; }

        [StringLength(5)]
        public string SM_CCOSTO { get; set; }

        [StringLength(20)]
        public string SM_ALMA { get; set; }
       
        [StringLength(5)]
        public string SM_SALA { get; set; }

        [StringLength(5)]
        public string SM_CTD { get; set; }

        [StringLength(20)]
        public string SM_NPS { get; set; }

        [StringLength(20)]
        public string SM_NPE { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(2)]
        public string SM_TIPOS { get; set; }
        

        public static void InsertaSolicitudC(tabla_solicitud ADDMC)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                try { 
                ctx.Entry(ADDMC).State = EntityState.Added;
                ctx.SaveChanges();
                }
                catch
                {
                    ctx.Entry(ADDMC).State = EntityState.Modified;
                    ctx.SaveChanges();
                }
            }
        }

        public static string ultimocodigoSolic(string TDOC)
        {

            int rvalor = 0, codgen = 0;
            string codstring = ""; 
            try
            {
                using (var ctx = new ANEXO_RSFACAR())
                {
                    rvalor = ctx.tabla_solicitud.Where(s=>s.SM_TIPOS==TDOC).OrderByDescending(ob => ob.SM_ID).FirstOrDefault().SM_ID;
                }
            }
            catch (Exception)
            {

                rvalor = 0;
            }

            codgen = rvalor + 1 ;
            codstring = codgen.ToString();
            return codstring;
        }


        public static List<vista_solicitudCAB> ListarSolicitudes(tabla_solicitud codarea)
        {
            var Listaf = new List<vista_solicitudCAB>();
            using (var ctx=new ANEXO_RSFACAR())
            {

                var narea = tabla_d_areausua.Listarsubareasxusua(codarea.SM_USUA, 1);
                int contt = 0;
                string[] filtroxareausua = new string[narea.Count()];
                foreach (var c in narea)
                {
                    filtroxareausua[contt] = c.SA_ID.ToString();
                    contt++;
                }

                Listaf = (from c in ctx.tabla_solicitud
                          where
                          (codarea.SM_ID == 0 ? c.SM_ID!=0 :c.SM_ID== codarea.SM_ID)
                          && (codarea.SM_AREA =="" ? c.SM_AREA != "" : c.SM_AREA == codarea.SM_AREA) 
                          && (codarea.SM_ESTADO == "" ?  c.SM_ESTADO !="" : c.SM_ESTADO== codarea.SM_ESTADO)
                          && c.SM_TIPOS == codarea.SM_TIPOS 
                          select new
                          {
                              SM_ID = c.SM_ID,
                              SM_IDSOLI = c.SM_IDSOLI,
                              SM_FECHA = c.SM_FECHA,
                              SM_GLOSA = c.SM_GLOSA,
                              SM_AREA = c.SM_AREA,
                              SM_ESTADO = c.SM_ESTADO,
                              SM_USUA = c.SM_USUA,
                              SM_IDAREA = c.SM_AREA,
                              SM_ALMA = c.SM_ALMA,
                              SM_SALA =c.SM_SALA,
                              SM_CTD=c.SM_CTD,
                              SM_NPS = c.SM_NPS,
                              SM_NPE = c.SM_NPE,
                              SM_TIPOS=c.SM_TIPOS

                          }).ToList().Select(b => new vista_solicitudCAB() 
                          {
                              SM_ID = b.SM_ID,
                              SM_IDSOLI = AL0003TABL.Registrouno(b.SM_IDSOLI,"12"),
                              //SM_FECHA = b.SM_FECHA,
                              SM_GLOSA = string.Format("{0:dd/MM/yyyy}", b.SM_FECHA),
                              SM_AREA = tabla_subareas.Nvalidaareas(b.SM_AREA).SA_DESC,
                              SM_ESTADO =AL0003TABL.Registrouno( b.SM_ESTADO,"75"),
                              SM_USUA = UT0030.Mostrarunusuario( b.SM_USUA),
                              SM_IDAREA =b.SM_IDAREA, 
                              SM_IDESTAD = b.SM_ESTADO, 
                              SM_ALMA = b.SM_ALMA, 
                              SM_SALA = b.SM_SALA, 
                              SM_CTD = b.SM_CTD ,
                              SM_NPS = b.SM_NPS,
                              SM_NPE = b.SM_NPE,
                              SM_TIPOS = b.SM_TIPOS
                          }).ToList(); 
            } 
            return Listaf;
        }

        public static List<vista_solicitudCAB> ListarSolicitudesPRM(tabla_solicitud codarea)
        {
            var Listaf = new List<vista_solicitudCAB>();
            using (var ctx = new ANEXO_RSFACAR())
            {

                var narea = tabla_d_areausua.Listarsubareasxusua(codarea.SM_USUA, 1);
                int contt = 0;
                string[] filtroxareausua = new string[narea.Count()];
                foreach (var c in narea)
                {
                    filtroxareausua[contt] = c.SA_ID.ToString();
                    contt++;
                }

                var nniv= tabla_d_nivelusua.Listarnivelxusua(codarea.SM_USUA);
                int contt2 = 0;
                string[] filtroxnivausua = new string[nniv.Count()];
                foreach (var c in nniv)
                {
                    filtroxnivausua[contt2] = c.NA_CODREF.ToString();
                    contt2++;
                }
                

                Listaf = (from c in ctx.tabla_solicitud
                          where
                          //(codarea.SM_ID == 0 ? c.SM_ID != 0 : c.SM_ID == codarea.SM_ID)
                          //&& (codarea.SM_AREA == "" ? c.SM_AREA != "" : c.SM_AREA == codarea.SM_AREA)
                          filtroxareausua.Contains(c.SM_AREA) 
                          //&& (codarea.SM_ESTADO == "" ? c.SM_ESTADO != "" : c.SM_ESTADO == codarea.SM_ESTADO)
                          && filtroxnivausua.Contains(c.SM_ESTADO)
                          && c.SM_TIPOS == "SO" 
                          select new
                          {
                              SM_ID = c.SM_ID,
                              SM_IDSOLI = c.SM_IDSOLI,
                              SM_FECHA = c.SM_FECHA,
                              SM_GLOSA = c.SM_GLOSA,
                              SM_AREA = c.SM_AREA,
                              SM_ESTADO = c.SM_ESTADO,
                              SM_USUA = c.SM_USUA,
                              SM_IDAREA = c.SM_AREA,
                              SM_ALMA = c.SM_ALMA,
                              SM_SALA = c.SM_SALA,
                              SM_CTD = c.SM_CTD,
                              SM_NPS = c.SM_NPS,
                              SM_NPE = c.SM_NPE,
                              SM_TIPOS = c.SM_TIPOS

                          }).ToList().Select(b => new vista_solicitudCAB()
                          {
                              SM_ID = b.SM_ID,
                              SM_IDSOLI = AL0003TABL.Registrouno(b.SM_IDSOLI, "12"),
                              //SM_FECHA = b.SM_FECHA,
                              SM_GLOSA = string.Format("{0:dd/MM/yyyy}", b.SM_FECHA),
                              SM_AREA = tabla_subareas.Nvalidaareas(b.SM_AREA).SA_DESC,
                              SM_ESTADO = AL0003TABL.Registrouno(b.SM_ESTADO, "75"),
                              SM_USUA = UT0030.Mostrarunusuario(b.SM_USUA),
                              SM_IDAREA = b.SM_IDAREA,
                              SM_IDESTAD = b.SM_ESTADO,
                              SM_ALMA = b.SM_ALMA,
                              SM_SALA = b.SM_SALA,
                              SM_CTD = b.SM_CTD,
                              SM_NPS = b.SM_NPS,
                              SM_NPE = b.SM_NPE,
                              SM_TIPOS = b.SM_TIPOS
                          }).ToList();
            }
            return Listaf;
        }


        public static void ActualizaARestado(tabla_solicitud AINF)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
                var ACDAt = (from c in ctx.tabla_solicitud where c.SM_ID == AINF.SM_ID && c.SM_TIPOS==AINF.SM_TIPOS select c).FirstOrDefault();
                ctx.Entry(ACDAt).State = EntityState.Modified;
                ACDAt.SM_ESTADO = AINF.SM_ESTADO;
                ACDAt.SM_ATENC = AINF.SM_ATENC;
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

        public static void ActualizaDatoVale(tabla_solicitud AINF)
        {
            using (var ctx = new ANEXO_RSFACAR())
            {
//&& c.SM_TIPOS== AINF.SM_TIPOS
                var ACDAt = (from c in ctx.tabla_solicitud where c.SM_ID == AINF.SM_ID  select c).FirstOrDefault();
                ctx.Entry(ACDAt).State = EntityState.Modified;
                ACDAt.SM_ATENC = AINF.SM_ATENC; 
                ACDAt.SM_NPS = AINF.SM_NPS;
                ACDAt.SM_NPE = AINF.SM_NPE; 
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
        

        public static tabla_solicitud ObtenerinfounaSol(int idarticulo,string tiposo)
        {
            var resp = new tabla_solicitud();

              using (var ctx = new ANEXO_RSFACAR())
                {
                try
                {
                    resp = ctx.tabla_solicitud.Where(x => x.SM_ID == idarticulo && x.SM_TIPOS==tiposo).FirstOrDefault();

                }
                catch
                {
                    resp = null;
                }
                }
            return resp;
        }

        public static List<tabla_solicitud> ListarSolicitud(int idsolicitud,string TDOCX)
        {
            var ACDAt = new List<tabla_solicitud>();
            using (var ctx=new ANEXO_RSFACAR())
            {
                try { 
                ACDAt = (from c in ctx.tabla_solicitud where c.SM_ID == idsolicitud && c.SM_TIPOS == TDOCX select c).ToList();
                }
                catch
                {
                   throw;
                }
            }
            return ACDAt;
        }


        public static List<vista_solicitudalmacen> ListarSolicit(tabla_solicitud nsolic)
        {
            var Lsol = new List<vista_solicitudalmacen>(); 
            using (var ctx= new ANEXO_RSFACAR())
            {
                Lsol = (from c in ctx.tabla_solicitud join s in ctx.tabla_d_solicitud on c.SM_ID equals s.DS_IDSOLIC where c.SM_ID==nsolic.SM_ID
                        && c.SM_TIPOS == nsolic.SM_TIPOS 
                        group s by new
                        {
                            c.SM_ID,
                            c.SM_FECHA,
                            c.SM_IDSOLI,
                            c.SM_GLOSA,
                            c.SM_AREA,
                            c.SM_USUA,
                            s.DS_CCODIGO,
                            c.SM_ESTADO,
                            c.SM_CCOSTO,
                            c.SM_SALA,
                            c.SM_TIPOS

                        } into g
                        select new {
                            
                            data1 = g.Key.SM_FECHA,
                            data2 = g.Key.SM_IDSOLI,
                            data3 = g.Key.SM_GLOSA,
                            data4 = g.Key.SM_AREA,
                            data5 = g.Key.SM_USUA,
                            data6 = g.Key.DS_CCODIGO,
                            data7 = (decimal?)g.Sum(p => p.DS_CANTID),
                            data8 = g.Key.SM_ID,
                            data9 = g.Key.SM_ESTADO,
                            data10= g.Key.SM_CCOSTO,
                            data11= g.Key.SM_SALA,
                            data12 = g.Key.SM_TIPOS

                        }).ToList().Select(t=> new vista_solicitudalmacen()
                        {
                            SO_IDSOLITD = Convert.ToString(t.data8),
                            SO_FECHA = string.Format("{0:dd/MM/yyyy}", t.data1),
                            SO_SOLICITANTE = AL0003TABL.Registrouno( t.data2,"12"),
                            SO_GLOSA = t.data3,
                            SO_AREA = tabla_subareas.Nvalidaareas( t.data4).SA_DESC,
                            SO_USUARIO = UT0030.Mostrarunusuario(t.data5),
                            SO_ESTADO = AL0003TABL.Registrouno( t.data9,"75"),
                            SO_PRODUCTO = AL0003ARTI.obtenerArticuloPorID(t.data6).AR_CDESCRI,
                            SO_CANTIDAD = Convert.ToDecimal(t.data7),
                            SO_UNIDAD = AL0003ARTI.obtenerArticuloPorID(t.data6).AR_CUNIDAD,
                            SO_CCOSTO=AL0003TABL.Registroxcodigo(t.data10,"10").TG_CDESCRI,
                            SM_SALA=( t.data11==""? "": tabla_parametros.ListarParametroDescr2( "SL",t.data11)),
                            SM_TIPOS=t.data12  

                        }).ToList();
            }
            return Lsol;
        }



        public static vista_solicitudalmacen MostrarCabsoli(tabla_solicitud nsolic)
        {
            var Lsol = new vista_solicitudalmacen();
            using (var ctx = new ANEXO_RSFACAR())
            {
                Lsol = (from c in ctx.tabla_solicitud
                        where c.SM_ID == nsolic.SM_ID && c.SM_TIPOS == nsolic.SM_TIPOS
                        select new
                        {
                            data1 = c.SM_FECHA,
                            data2 = c.SM_IDSOLI,
                            data3 = c.SM_GLOSA,
                            data4 = c.SM_AREA,
                            data5 = c.SM_USUA,
                            data6=c.SM_ID
                        }).ToList().Select(t => new vista_solicitudalmacen()
                        {
                            SO_IDSOLITD = Convert.ToString(t.data6),
                            SO_FECHA = string.Format("{0:dd/MM/yyyy}", t.data1),
                            SO_SOLICITANTE = AL0003TABL.Registrouno(t.data2, "12"),
                            SO_GLOSA = t.data3,
                            SO_AREA = tabla_subareas.Nvalidaareas(t.data4).SA_DESC,
                            SO_USUARIO = UT0030.Mostrarunusuario(t.data5),
                        }).First();
            }
            return Lsol;
        }

        public static List<VISTA_DETALLE_TRABAJOCURSO> DETALLE2(tabla_trabajo CODATA)
        {
            var detalle = new List<VISTA_DETALLE_TRABAJOCURSO>();
            try
            {

                var cty = new ANEXO_RSFACAR();
                var solicitudes = (from a in cty.tabla_solicitud
                                   where a.SM_ORDTRA.Trim() == CODATA.TR_CODIGO.Trim() && a.SM_ESTADO == "7"
                                   select new
                                   {
                                       data1 = a.SM_TOTALMN,
                                       data2 = a.SM_TOTALUS,
                                       data3 = a.SM_ORDTRA,
                                       data4 = a.SM_ID,
                                       data5 = "",
                                   data6 = "SOLICITUD",
                                   data7=a.SM_FECHA
                               }
                                     ).ToArray();


                var ctx = new RSFACAR();

                var ordenes = (from b in ctx.CO0003MOVC
                               where b.OC_CRESPER3.Trim() == CODATA.TR_CODIGO.Trim() && b.OC_CSITORD == "2"
                               select new
                               {
                                   data1 = b.OC_NIMPUS,
                                   data2 = b.OC_NIMPMN,
                                   data3 = b.OC_CRESPER3,
                                   data4 = 0,
                                   data5= b.OC_CNUMORD,
                                   data6 = "ORDEN SERVICIO",
                                   data7=b.OC_DFECDOC
                                   }).ToArray();

                detalle = ((from s in solicitudes
                            select new
                            { soles = s.data2,
                                dolares = s.data1,
                                trabajo = s.data3,
                                documentonro = s.data4,
                                nrodocumento = s.data5,
                                doc = s.data6,
                                fecha= s.data7
                            }).Union(from o in ordenes
                                     select new
                                     {
                                         soles = (decimal?)o.data2,
                                         dolares = (decimal?)o.data1,
                                         trabajo = o.data3,
                                         documentonro = o.data4,
                                         nrodocumento = o.data5,
                                         doc = o.data6,
                                         fecha = o.data7
                                     } )
                                        )
                    
                    .ToList() .Select(c => new VISTA_DETALLE_TRABAJOCURSO()
                    {
                        CODIGO =(c.documentonro==0? c.nrodocumento: c.nrodocumento == ""? Convert.ToString(c.documentonro): c.nrodocumento),
                        DOCUMENTO = c.doc,
                        FECHA = Convert.ToDateTime(c.fecha),
                        //MONEDA = c.data3,
                       // MONTO = (c.data3.Trim() == "MN" ? c.data5 : c.data4),
                        MONTOMN =(CODATA.COD_MON=="MN"? Convert.ToDecimal(c.soles): Convert.ToDecimal(c.dolares)),
                       }).ToList();
            }
            catch (Exception)
            {

                throw;
            }

            return detalle;
        }

    }
}
