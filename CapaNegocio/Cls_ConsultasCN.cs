using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using CapaDatos;
using CapaEntidades;
using System.Data.OleDb;

namespace CapaNegocio
{
    public class Cls_ConsultasCN
    {
        private string cadena;
        public Cls_ConsultasCN(string cadena)
        {
            this.cadena = cadena ;
        }

        public DataTable PR_REPORTESEMAFOROREQUERIMIENTO(int band,DateTime fecha1, DateTime fecha2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.PR_REPORTESEMAFOROREQUERIMIENTO(band,fecha1, fecha2);
            return dt;
        }
        
        public DataTable funObtenerGruposTrabajo()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerGruposTrabajo();
            return dt;
       }
        public DataTable pr_reporteasistencia_general(string fecha)
        {
          
                DataTable dt = new DataTable();
                Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
                dt = varConsulta.pr_reporteasistencia_general(fecha);
                return dt;
            }
        public DataTable reporte_condicionConsolidado(Cls_Detalle detalle)
        {

            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.reporte_condicionConsolidado(detalle);
            return dt;
        }

        public DataTable listaPeriodoPlanillaIndividual()
        {

            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.listaPeriodoPlanillaIndividual();
            return dt;
        }



        public List<Cls_anexo_doc_cabGuias> funObtenerCls_anexo_doc_cabGuias(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_anexo_doc_cabGuias> varRespuesta;
            varRespuesta = varConsulta.funObtenerCls_anexo_doc_cabGuias(parNumdoc2);
            return varRespuesta;
        }


        public List<Cls_Doc_det> funObtenerDoc_detFlitro(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_Doc_det> varRespuesta;
            varRespuesta = varConsulta.funObtenerDoc_detFlitro(parNumdoc2);
            return varRespuesta;
        }

        public List<Cls_Doc_det> funObtenerDoc_detFlitroCodigoNS(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_Doc_det> varRespuesta;
            varRespuesta = varConsulta.funObtenerDoc_detFlitroCodigoNS(parNumdoc2);
            return varRespuesta;
        }

        public List<Cls_details_reprocesos> funObtenerdetails_reprocesos(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_details_reprocesos> varRespuesta;
            varRespuesta = varConsulta.funObtenerdetails_reprocesos(parNumdoc2);
            return varRespuesta;
        }




        public List<Cls_especies_materiaprima> funObtenerespecies_materiaprimaFlitro(int parIdempresa, Boolean  parConcurrencia, string parEjercicio)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_especies_materiaprima> varRespuesta;
            varRespuesta = varConsulta.funObtenerespecies_materiaprimaFlitro(parIdempresa, parConcurrencia, parEjercicio);
            return varRespuesta;
        }

        public List<Cls_CentroCostosPPPCE> funObtenerCentroCostosPPP(string parSerie, string parcodcco2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_CentroCostosPPPCE> varRespuesta;
            varRespuesta = varConsulta.funObtenerCentroCostosPPP(parSerie, parcodcco2);
            return varRespuesta;
        }


        public Cls_estuctura_producto funObtenerEstructuraProductosFiltro(string parCodpro)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_estuctura_producto varRespuesta = null;
            varRespuesta = varConsulta.funObtenerEstructuraProductosFiltro(parCodpro);
            return varRespuesta;
        }

        public Cls_Productos funObtenerProductosFiltro(string parCodpro)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_Productos varRespuesta = null;
            varRespuesta = varConsulta.funObtenerProductosFiltro(parCodpro);
            return varRespuesta;
        }


        public Cls_InicalLote funObtenerInicalLoteFiltro(string parDescripVulgar)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_InicalLote varRespuesta = null;
            varRespuesta = varConsulta.funObtenerInicalLoteFiltro(parDescripVulgar);
            return varRespuesta;
        }


        public Cls_DocumRelacionExterno funObtenerDocumRelacionExterno(string parSerieDocOrigen)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_DocumRelacionExterno varRespuesta = null;
            varRespuesta = varConsulta.funObtenerDocumRelacionExterno(parSerieDocOrigen);
            return varRespuesta;
        }


        public Cls_AccesosModuloInyweb funObtenerCls_AccesosModuloInyweb(string parCodusu, string parModulo, string parOpcion)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_AccesosModuloInyweb varRespuesta = null;
            varRespuesta = varConsulta.funObtenerCls_AccesosModuloInyweb(parCodusu, parModulo, parOpcion);
            return varRespuesta;
        }

        //public Cls_Usuarios funObtenerUsuarios(string parCodusu)
        //{
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    Cls_Usuarios varRespuesta = null;
        //    varRespuesta = varConsulta.funObtenerUsuarios(parCodusu);
        //    return varRespuesta;
        //}


        public Cls_Usuarios funObtenerUsuarios(string parCodusu)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_Usuarios varRespuesta = null;
            varRespuesta = varConsulta.funObtenerUsuarios(parCodusu);
            return varRespuesta;
        }
        public Cls_Usuarios funObtenerUsuarios(string parCodusu,string parClave)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_Usuarios varRespuesta = null;
            varRespuesta = varConsulta.funObtenerUsuarios(parCodusu, parClave);
            return varRespuesta;
        }
        //public Cls_Usuarios funObtenerUsuariosAccess(string parCodusu, string parClave)
        //{
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    Cls_Usuarios varRespuesta = null;
        //    varRespuesta = varConsulta.funObtenerUsuariosAccess(parCodusu, parClave);
        //    return varRespuesta;
        //}


      



        public Cls_Series funObtenerseries(string parserie, string parop)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_Series varRespuesta = null;
            varRespuesta = varConsulta.funObtenerseries(parserie, parop);
            return varRespuesta;
        }

        public Cls_SeriesValva funObtenerseriesValva(string parop, string parreferencia, string parCodcco, string parEspecie)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_SeriesValva varRespuesta = null;
            varRespuesta = varConsulta.funObtenerseriesValva(parop, parreferencia, parCodcco, parEspecie);
            return varRespuesta;
        }

        public Cls_ComparativoCab funObtenerComparativoCab(string numdoc2)
         {
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             Cls_ComparativoCab varRespuesta = null;
             varRespuesta = varConsulta.funObtenerComparativoCab(numdoc2);
             return varRespuesta;
         }

        public Cls_planillaCab funObtenerplanillaCab(string numdoc2)
         {
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             Cls_planillaCab varRespuesta = null;
             varRespuesta = varConsulta.funObtenerplanillaCab(numdoc2);
             return varRespuesta;
         }
        
        public Cls_Doc_cab funObtenerdoc_Cab(string numdoc2)
         {
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             Cls_Doc_cab varRespuesta = null;
             varRespuesta = varConsulta.funObtenerdoc_Cab(numdoc2);
             return varRespuesta;
         }

        public Cls_Empresas funObtenerEmpresasFiltro(int parId)
         {
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             Cls_Empresas varRespuesta = null;
             varRespuesta = varConsulta.funObtenerEmpresasFiltro(parId);
             return varRespuesta;
         }



        public Cls_AnexoDocCAb funObtenerAnexoDocCAb(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_AnexoDocCAb varRespuesta = null;
            varRespuesta = varConsulta.funObtenerAnexoDocCAb(parNumdoc2);
            return varRespuesta;
        }


        public Cls_Master_Reprocesos funObtenerMaster_Reprocesos(string parNumdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_Master_Reprocesos varRespuesta = null;
            varRespuesta = varConsulta.funObtenerMaster_Reprocesos(parNumdoc2);
            return varRespuesta;
        }



        public Cls_planillaCab sp_planilla_obtenLangostineraPozaReprocesosTerceros(string numdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_planillaCab varRespuesta = null;
            varRespuesta = varConsulta.sp_planilla_obtenLangostineraPozaReprocesosTerceros(numdoc2);
            return varRespuesta;
        }


        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerNumeroSiguiente(string serie)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            varRespuesta = varConsulta.funSolicitudCorrectivaPreventivaObtenerNumeroSiguiente(serie);
            return varRespuesta;
        }


        public Cls_planillaCab sp_inyprod_setLangostineraPozaTeceroReetiquetado(string numdoc2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_planillaCab varRespuesta = null;
            varRespuesta = varConsulta.sp_inyprod_setLangostineraPozaTeceroReetiquetado(numdoc2);
            return varRespuesta;
        }


        public DataTable sp_inyprod_devuelveInsumosFacturables(string numdoc2, string codper, int tipo)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_devuelveInsumosFacturables(numdoc2, codper,tipo);
            return dt;
        }


        public DataTable funObtenerOrigenNoConformidad()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerOrigenNoConformidad();
            return dt;
        }



        public DataTable funObtenerAreas(string parCodarea)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerAreas(parCodarea);
            return dt;
        }


        public DataTable funObtenerArchivos()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerArchivos();
            return dt;
        }

        public DataTable funObtenerArchivos(string codarea )
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerArchivos(codarea);
            return dt;
        }


     

        public DataTable sp_inyprod_partes_reprocesos_pendientes(string codcco, Boolean acopio, Boolean campos, Boolean tercero)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.sp_inyprod_partes_reprocesos_pendientes(codcco, acopio, campos, tercero);
             return dt;
         }
              
        public DataTable sp_inyprod_listaPartesReetiquetadosPendientes(string parOp, string parCodcco, string parReferencia)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.sp_inyprod_listaPartesReetiquetadosPendientes(parOp, parCodcco, parReferencia);
             return dt;
         }
        
        public DataTable funObtenerProductosActivos(string codigo, int tipo, string planta, string cod)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.funObtenerProductosActivos(codigo, tipo, planta, cod);
             return dt;
         }

        public DataTable sp_inyplanilla_datosdetreporetpp(string numdoc2, int tipo)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_datosdetreporetpp(numdoc2, tipo);
            return dt;
        }
     

        public DataTable sp_inyprod_listaPartesReetiquetadosPendientes(string op, string codcco, int referencia)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.sp_inyprod_listaPartesReetiquetadosPendientes(op, codcco, referencia);
             return dt;
         }
                 
        public DataTable sp_inyprod_notasSalidaPendientesCruce(string codcco, string op, int referencia)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.sp_inyprod_notasSalidaPendientesCruce(codcco, op, referencia);
             return dt;
         }
        
        public DataTable funObtenerProductosActivosFiltro(string codigo, int tipo, string planta)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.funObtenerProductosActivosFiltro(codigo, tipo, planta);
             return dt;
         }

        public DataTable funObtenerDetallePlanilla(string numdoc2)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.funObtenerDetallePlanilla(numdoc2);
             return dt;
         }
        
        public DataTable funObtenerDetalleConsumo(string codcco, string numdoc2, int toper, string numpp)
         {
             DataTable dt = new DataTable();
             Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
             dt = varConsulta.funObtenerDetalleConsumo(codcco, numdoc2,  toper,  numpp);
             return dt;
         }


        public DataTable sp_inyplanilla_Tabla_Maestro_terceros_abc(string parCodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_Tabla_Maestro_terceros_abc(parCodcco);
            return dt;
        }

        public DataTable funObtenerEmpresas(int idempresa)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerEmpresas(idempresa);
            return dt;
        }

        public DataTable funObtenerEjerciciosActivos(int anio)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerEjerciciosActivos(anio);
            return dt;
        }

        public DataTable sp_inyplanilla_Tabla_Maestroxreproceso(string parCodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_Tabla_Maestroxreproceso(parCodcco);
            return dt;
        }
        
        public DataTable funObtenerDTISValva_DT(string parcodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerDTISValva_DT(parcodcco);
            return dt;
        }

        public DataTable sp_inyplanilla_muestrasincruce_ns(string parCodcco,int partipo)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_muestrasincruce_ns(parCodcco,partipo);
            return dt;
        }
        
        public DataTable funObtenerdatosComparativoReetiquetado(string parnumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerdatosComparativoReetiquetado(parnumdoc2);
            return dt;
        }

        public DataTable funObtenerdatosComparativo(string parnumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerdatosComparativo(parnumdoc2);
            return dt;
        }
        
        public DataTable sp_inyprod_consolidadosCuCosteo(string parnumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_consolidadosCuCosteo(parnumdoc2);
            return dt;
        }
       
        public DataTable sp_inyplanilla_Tabla_Maestrox2(string parCodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_Tabla_Maestrox2(parCodcco);
            return dt;
        }
        
        public DataTable sp_inyplanilla_Tabla_MaestroxCamposx2(string parCodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_Tabla_MaestroxCamposx2(parCodcco);
            return dt;
        }
        
        public DataTable sp_inyplanilla_Tabla_Maestro_terceros(string parCodcco)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_Tabla_Maestro_terceros(parCodcco);
            return dt;
        }

        public DataTable funObtenerDetalleDTIValva(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerDetalleDTIValva(parNumdoc2);
            return dt;
        }
        
        public DataTable funObtenerAnexoGuiasFiltro(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerAnexoGuiasFiltro(parNumdoc2);
            return dt;
        }
        
        public DataTable funObtenerCentroCostosPPP_DT(string parcodcco2, string parSerie)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerCentroCostosPPP_DT(parcodcco2, parSerie);
            return dt;
        }

        public DataTable funObtenerRecortesppp(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerRecortesppp(parNumdoc2);
            return dt;
        }
        
        public DataTable sp_inyprod_reporte_dt(string parCodcco, string parPeriodo, string parNumdoc2, string parFecha)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_reporte_dt(parCodcco, parPeriodo, parNumdoc2,  parFecha);
            return dt;
        }

        public DataTable sp_inyprod_reporte_ppp(string parCodcco, string parPeriodo, string parNumdoc2, string parFecha)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_reporte_ppp(parCodcco, parPeriodo, parNumdoc2, parFecha);
            return dt;
        }
        
        public DataTable sp_inyprod_concatenapresentaciones(string parCodcco, int parTipo)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_concatenapresentaciones(parCodcco, parTipo);
            return dt;
        }

        public DataTable sp_inyprod_potappp(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_potappp(parNumdoc2);
            return dt;
        }

        public DataTable funObtenerPlanillaProducciondet(string parNumdoc2)
        {

            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerPlanillaProducciondet( parNumdoc2);
            return dt;

        }

        public DataTable funObtenerDetalleNS(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerDetalleNS(parNumdoc2);
            return dt;
        }


        public DataTable sp_inyplanilla_CAxPE(int parTipo, string parPlanta, string parCod, string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_CAxPE(parTipo, parPlanta, parCod, parNumdoc2);
            return dt;
        }


        public DataTable sp_inyplanilla_CAxPExfiltro(int parTipo, string parPlanta, string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyplanilla_CAxPExfiltro(parTipo, parPlanta, parNumdoc2);
            return dt;
        }

        public DataTable sp_inyprod_retornaDetalleNotaSalidaReetiquetado(string parNumdoc2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.sp_inyprod_retornaDetalleNotaSalidaReetiquetado(parNumdoc2);
            return dt;
        }

        public DataTable funObtenersolicitud_correctivaPreventiva( string serie )
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenersolicitud_correctivaPreventiva(serie);
            return dt;
        }
        public DataTable funObtenersolicitud_correctivaPreventiva(string serie,string codusu)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenersolicitud_correctivaPreventiva(serie,codusu);
            return dt;
        }


        //public DataTable funObtenersolicitud_correctivaPreventiva(string serie)
        //{
        //    DataTable dt = new DataTable();
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    dt = varConsulta.funObtenersolicitud_correctivaPreventiva(serie);
        //    return dt;
        //}


        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerTodos(string numero,string serie)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            varRespuesta = varConsulta.funSolicitudCorrectivaPreventivaObtenerTodos(numero,serie );
            return varRespuesta;
        }

        public Cls_SolicitudCorrectivaPreventiva funSolicitudCorrectivaPreventivaObtenerTodos(string serie, string seriecruce2, string doccruce2)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_SolicitudCorrectivaPreventiva varRespuesta = null;
            varRespuesta = varConsulta.funSolicitudCorrectivaPreventivaObtenerTodos(serie, seriecruce2, doccruce2);
            return varRespuesta;
        }

        public DataTable funObtenersolicitud_correctivaPreventivaEstado(string serie)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenersolicitud_correctivaPreventivaEstado(serie);
            return dt;
        }
        public Cls_OrdenTrabajo funcion_tabla_ordendetrabajo_numerosiguiente(Cls_OrdenTrabajo orden)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_OrdenTrabajo varRespuesta = null;
            varRespuesta = varConsulta.funcion_tabla_ordendetrabajo_numerosiguiente(orden);
            return varRespuesta;

        }

        public Cls_OrdenTrabajo funObtenerOrdenesTrabajo(Cls_OrdenTrabajo orden)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            Cls_OrdenTrabajo varRespuesta = null;
            varRespuesta = varConsulta.funObtenerOrdenesTrabajo(orden);
            return varRespuesta;

        }


       


        public DataTable funObtenerAreas()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerAreas();
            return dt;
        }
        public DataTable funObtenerUnidadesMedida()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerUnidadesMedida();
            return dt;
        }

        public DataTable funObtenerTipoPresupuesto()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerTipoPresupuesto();
            return dt;
        }

        public DataTable funObtenerTipodeOrden()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerTipodeOrden();
            return dt;
        }

        public DataTable funObtenertipoMantenimiento()
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenertipoMantenimiento();
            return dt;
        }

        public DataTable funObtenerOrdenesTrabajo(int band)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerOrdenesTrabajo(band);
            return dt;
        }

        public DataTable funObtenerDetalleOrdenesTrabajo(Cls_DetalleOrdenTrabajo detalle)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerDetalleOrdenesTrabajo(detalle);
            return dt;
        }

        public DataTable funObtenerOrdenesTrabajoFiltroAreaMantenimiento(Cls_OrdenTrabajo orden)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerOrdenesTrabajoFiltroAreaMantenimiento(orden);
            return dt;
        }

        public DataTable funObtenerListaArchivos(Cls_FilesContent files)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerListaArchivos(files);
            return dt;
        }

        public DataTable funObtenerListaSolicitudesxArea(Cls_SolicitudCorrectivaPreventiva sol)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerListaSolicitudesxArea(sol);
            return dt;
        }

        //public DataTable funObtenerLista_productoterminado_congelados()
        //{

        //    DataTable dt = new DataTable();
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    dt = varConsulta.funObtenerLista_productoterminado_congelados();
        //    return dt;

        //}

        public DataTable funObtenerLista_productoterminado_congelados(string numero)
        {


            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_productoterminado_congelados(numero);
            return dt;
        }

        public DataTable funObtenerLista_productoterminado_congelados(string f_prod1, string f_prod2,int tipo)
        {


            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_productoterminado_congelados(f_prod1,f_prod2,tipo);
            return dt;
        }

      

        public DataTable funObtenerLista_especie_pp()
        {


            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_especie_pp();
            return dt;
        }


        public DataTable funObtenerLista_materiaprima_congelados()
        {

            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_materiaprima_congelados();
            return dt;

        }

        public DataTable funObtenerLista_materiaprima_congelados(string f_prod1, string f_prod2, int tipo)
        {


            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_materiaprima_congelados(f_prod1,f_prod2,tipo);
            return dt;
        }

        public DataTable funObtenerLista_materiaprima_congelados(string numero)
        {


            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.funObtenerLista_materiaprima_congelados(numero);
            return dt;
        }


   public DataTable funObtenerLista_insumos_congelados(string numero)
   {


       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerLista_insumos_congelados(numero);
       return dt;
   }


   public DataTable funObtenerLista_insumos_congelados(string f_prod1, string f_prod2, int tipo)
   {


       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerLista_insumos_congelados(f_prod1, f_prod2,tipo);
       return dt;
   }


   public DataTable funObtenerLista_insumos_congelados()
   {


       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerLista_insumos_congelados();
       return dt;
   }

  ////////////////////////////////////////////// SEAFROST
   public DataTable funObtenerSalas()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerSalas();
       return dt;
   }

   public DataTable funObtenerAlmacenes()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerAlmacenes();
       return dt;
   }

   public string funObtenerNumeroGuia(string sala, string tipo)
   {

       string numguia=string.Empty ;
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       numguia = varConsulta.funObtenerNumeroGuia(sala, tipo);
       return numguia;
   }

   public List<string> funObtenerProductos(string producto)
   {
       List<string> varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerProductos(producto);

       return varRespuesta;
   }
   public Cls_Salida funObtenerProductosCls_Salida(string producto, string codigo, int tipo)
   {
       Cls_Salida varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerProductosCls_Salida(producto,codigo,tipo);

       return varRespuesta;
   }


   //public List<string> funObtenerTrabajador(Cls_Personal Personal)
   //{
   //    List<string> varRespuesta;

   //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
   //    varRespuesta = varConsulta.funObtenerTrabajador(Personal);

   //    return varRespuesta;
   //}
   public Cls_Tarea funObtenerTareaByDescripcion(Cls_Tarea tarea)
   {
       Cls_Tarea varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerTareaByDescripcion(tarea);

       return varRespuesta;
   }

   public Cls_Bloqueo funObtenerBloqueo()
   {
       Cls_Bloqueo varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerBloqueo();

       return varRespuesta;
   }


   public double funObtenerStockIdxAlmacen(string codigo, string almacen)
   {
       double varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerStockIdxAlmacen(codigo, almacen);

       return varRespuesta;

   }
   public double funObtenerStockId(string codigo)
   {
      double varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerStockId(codigo);

       return varRespuesta;

   }

   public DataTable funObtenerProcesos(string codtipocontrol)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerProcesos(codtipocontrol);
       return dt;
   }

   public DataTable funObtenerArea()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerArea();
       return dt;
   }

   public DataTable funObtenerTurno()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTurno();
       return dt;
   }

   public DataTable funObtenervista_muestraGuia(string nguia, string codtipocontrol,string codsala)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenervista_muestraGuia(nguia, codtipocontrol,codsala);
       return dt;
   }
   public   DataTable funObtenerVistaMovimientosProducto(string idproducto,int tipo, string fecha1,string fecha2)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerVistaMovimientosProducto(idproducto,tipo, fecha1,fecha2);
       return dt;
   }

   public DataTable funObtenerVistaMovimientos(string fecha1, string fecha2, int tipo, string idproducto)

        
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerVistaMovimientos(fecha1, fecha2, tipo, idproducto);
       return dt;
   }

   public DataTable funObtenerListaEspecies()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerListaEspecies();
       return dt;
   }

   public DataTable funObtenerVistaMovimientosEspecie(string idespecie, int tipo, string fecha1, string fecha2)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);



       dt = varConsulta.funObtenerVistaMovimientosEspecie( idespecie,tipo,fecha1,fecha2);
       return dt;
   }

  public DataTable pr_reporte_stock(DateTime fecha, string codigo,string almacen,int tipo,string codespecie )
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);



       dt = varConsulta.pr_reporte_stock(fecha, codigo, almacen, tipo, codespecie);
       return dt;
   }

   public DataTable pr_lista_guias(string nguia,string tipo)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.pr_lista_guias(nguia, tipo);
       return dt;
   }

   public DataTable funMuestraDetalleGuia(int codcontrol)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funMuestraDetalleGuia(codcontrol);
       return dt;
   }

   public int funObtenerAcceso(string acceso,string codusu)
   {
       int varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerAcceso(acceso,codusu);

       return varRespuesta;
   }

   public DataTable funObtenerTipoControl()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTipoControl();
       return dt;
   }

   public DataTable funObtenerProcesosID(string codproceso)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerProcesosID(codproceso);
       return dt;
   }

   public DataTable funObtenerAlmacenesID(string id)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerAlmacenesID(id);
       return dt;
   }


   public DataTable funObtenerSalidasID(string id)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerSalidasID(id);
       return dt;
   }

   public DataTable funObtenerProductosSalida(string producto)
   {



       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerProductosSalida(producto);
       return dt;


   }

   public Cls_Control funObtenerControl(Cls_Control control)
   {
       Cls_Control varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerControl(control);

       return varRespuesta;
   }

   public DataTable funObtenerEspecieAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerEspecieAll();
       return dt;


   }
   public DataTable funObtenerProcesosAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerProcesosAll();
       return dt;


   }

   public Cls_Planilla funObtenerPlanillaNumero()
   {
       Cls_Planilla dt = new Cls_Planilla();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPlanillaNumero();
       return dt;
   }

   public DataTable funObtenerProductoAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerProductoAll();
       return dt;


   }

   public DataTable funObtenerTipoPersonalAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTipoPersonalAll();
       return dt;


   }

   public DataTable funObtenerTipoPersonalById(Cls_DetPlanilla tipo)
   {
               DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTipoPersonalById(tipo);
       return dt;


   }

   public DataTable funObtenerPresentacionAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPresentacionAll();
       return dt;


   }

   public DataTable funObtenerTareaAll()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTareaAll();
       return dt;


   }
   public List<Cls_Salida> funObtenerProductosBYFiltro(Cls_Salida producto)
   {
       List<Cls_Salida> varRespuesta;

       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       varRespuesta = varConsulta.funObtenerProductosBYFiltro(producto);

       return varRespuesta;
   }

           public Cls_Personal funObtenerPersonalIdLocal(Cls_Personal Personal)
   {
       Cls_Personal dt = new Cls_Personal();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPersonalIdLocal(Personal);
       return dt;
   }

           public Cls_Personal funVerificaBiometrico(Cls_Personal Personal)
           {
               Cls_Personal dt = new Cls_Personal();
               Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
               dt = varConsulta.funVerificaBiometrico(Personal);
               return dt;
           }

   //public Cls_Personal funObtenerPersonalId(Cls_Personal Personal)
   //{
   //    Cls_Personal dt = new Cls_Personal();
   //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
   //    dt = varConsulta.funObtenerPersonalId(Personal);
   //    return dt;
   //}

   public Cls_Personal funObtenerPersonalId1(Cls_Personal Personal)
   {
       Cls_Personal dt = new Cls_Personal();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPersonalId1(Personal);
       return dt;
   }

   public Cls_Planilla funObtenerlistaCabeceraPlanillaOK(Cls_Planilla cab)
   {
       Cls_Planilla dt = new Cls_Planilla();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaCabeceraPlanillaOK(cab);
       return dt;
   }

   public Cls_DetPlanilla funObtenerDetallePlanillaByID(Cls_DetPlanilla det)
   {
       Cls_DetPlanilla dt = new Cls_DetPlanilla();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerDetallePlanillaByID(det);
       return dt;
   }


   public Cls_Personal funObtenerPersonalIdServices(Cls_Personal Personal)
   {
       Cls_Personal dt = new Cls_Personal();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPersonalIdServices(Personal);
       return dt;
   }


   public DataTable funObtenerPresentacionByID(int id)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerPresentacionByID(id);
       return dt;
   }

   public DataTable funObtenerTareaByID(int id,int idprod)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTareaByID(id, idprod);
       return dt;
   }

   public DataTable funObtenerlistaDetallePlanilla(Cls_DetPlanilla det)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaDetallePlanilla(det);
       return dt;
   }

   public DataTable funObtenerlistaReportePersonal()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaReportePersonal();
       return dt;
   }

   public DataTable funObtenerlistaDetallePlanillaOK(Cls_DetPlanilla det)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaDetallePlanillaOK(det);
       return dt;
   }


   public DataTable funObtenerlistaCabeceraPlanilla(Cls_Planilla det)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaCabeceraPlanilla(det);
       return dt;
   }


   public DataTable funObtenerSalasById(Cls_Planilla det)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerSalasById(det);
       return dt;
   }

   public DataTable funObtenerCondicion()
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerCondicion();
       return dt;
   }

   public DataTable funObtenerlistaUnidad()
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerlistaUnidad();
       return dt;


   }

   public DataTable funObtenerTurnoById(Cls_Planilla det)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenerTurnoById(det);
       return dt;
   }

   //public DataTable funObtenerMovimientosInsumos(Cls_Detalle detalle)
   //{

   //    DataTable dt = new DataTable();
   //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
   //    dt = varConsulta.funObtenerMovimientosInsumos(detalle);
   //    return dt;
   //}


   public List<Cls_DetPlanilla> funObtenerlistaDetalleByFechaByPresentacion(Cls_Planilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByFechaByPresentacion(det);
       return varRespuesta;
   }

   public List<Cls_DetPlanilla> funObtenerlistaDetalleByFecha(Cls_Planilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByFecha(det);
       return varRespuesta;
   }

   public List<Cls_DetPlanilla> funObtenerlistaDetalleByFechaByCodturno(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByFechaByCodturno(det);
       return varRespuesta;
   }

   public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajador(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajador(det);
       return varRespuesta;
   }

   public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaByTurno(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByFechaByTurno(det);
       return varRespuesta;

       
   }


  


   public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFecha(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByFecha(det);
       return varRespuesta;
   }
          public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaLike(Cls_DetPlanilla det)
        {
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            List<Cls_DetPlanilla> varRespuesta;
            varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByFechaLike(det);
            return varRespuesta;
        }
   public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByCondicion(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByCondicion(det);
       return varRespuesta;
   }

   public List<Cls_Planilla> funObtenerPlanilaForSie(Cls_Planilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_Planilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerPlanilaForSie( det);
       return varRespuesta;
   }

   public List<Cls_DetPlanilla> funObtenerDetallePlanilaForSie(Cls_Planilla planilla)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerDetallePlanilaForSie(    planilla);
       return varRespuesta;
   }
   public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByTurno(Cls_DetPlanilla det)
   {
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       List<Cls_DetPlanilla> varRespuesta;
       varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByTurno( det);
       return varRespuesta;
   }

   public DataTable funObtenervista_listaSemanasPorPeriodo(string semana)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenervista_listaSemanasPorPeriodo(semana);
       return dt;
   }

   public DataTable funObtenervista_listaSemanasPorPeriodoById(string semana,string periodo)
   {

       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenervista_listaSemanasPorPeriodoById(semana,periodo);
       return dt;
   }

   public DataTable funObtenervista_listaPlanillasSemana(Cls_Planilla pla)
   {
       DataTable dt = new DataTable();
       Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
       dt = varConsulta.funObtenervista_listaPlanillasSemana(pla);
       return dt;
   }
        public void pr_copiaresumen(string periodoant, string periodoactual, string fdoc)
        {

            //DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            varConsulta.pr_copiaresumen(periodoant, periodoactual, fdoc);

        }

        public void pr_limpiarstockvalz(string periodoactual)
        {
            //DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            varConsulta.pr_limpiarstockval( periodoactual);

        }
        
        public List<Cls_articulos> funObtenerArticulos(string producto,string COalm,string MIstoc)
        {
            List<Cls_articulos> varRespuesta;

            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            varRespuesta = varConsulta.funObtenerArticulos(producto, COalm, MIstoc);

            return varRespuesta;
        }

        public List<PRAL0003MOVG> funConsumoCCost(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2)
        {
            List<PRAL0003MOVG> varRespuesta;
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            varRespuesta = varConsulta.PR_ConsumoCcosto(foragrupa, almacen, fin, ffn, codigo, codigo2);
            return varRespuesta;
        }

         public DataTable funEntradasSalida(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2,string codmov,string tm)
        {
            DataTable dt = new DataTable(); 
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.PrEntradasSalidas(foragrupa, almacen, fin, ffn, codigo, codigo2, codmov, tm);
            return dt;
        }

        public DataTable funStockVal(string almacen, string fin, string codigo, string codigo2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.PrStockVal( almacen, fin,codigo, codigo2);
            return dt;
        }

        public DataTable funConsumoVal(string foragrupa,string almacen, string fin, string ffn, string codigo, string codigo2,string localIP,string almacen2)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.PrConsumoVal(foragrupa,almacen, fin,ffn, codigo, codigo2, localIP, almacen2);
            return dt;
        }

        public DataTable funKardexVal( string fin, string ffn, string codigo,string codigo2,string moneda)
        {
            DataTable dt = new DataTable();
            Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
            dt = varConsulta.PrKardexVal(fin, ffn, codigo,codigo2, moneda);
            return dt;
        }
        

        //public DataTable funConsumoCCost(string foragrupa, string almacen, string fin, string ffn, string codigo, string codigo2)
        //{
        //    DataTable dt = new DataTable();
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    dt = varConsulta.PR_ConsumoCcosto(foragrupa, almacen, fin, ffn, codigo, codigo2);
        //    return dt;
        //}

        //public List<Cls_DetPlanilla> funObtenerlistaDetalleByTrabajadorByFechaByTurno(Cls_DetPlanilla det)
        //{
        //    Cls_ConsultasCD varConsulta = new Cls_ConsultasCD(cadena);
        //    List<Cls_DetPlanilla> varRespuesta;
        //    varRespuesta = varConsulta.funObtenerlistaDetalleByTrabajadorByFechaByTurno(det);
        //    return varRespuesta;
        //}


    }
}
