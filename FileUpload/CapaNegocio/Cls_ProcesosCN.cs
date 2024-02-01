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

namespace CapaNegocio
{
    public class Cls_ProcesosCN
    {
       
         private string cadena;
         public Cls_ProcesosCN(string cadena)
        {
            this.cadena = cadena ;
        }


         public string sp_generarNumNotadeIngresoxccosto(int toper, string codcco)
         {
             Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
             string numdoc2 = varprocesos.sp_generarNumNotadeIngresoxccosto(toper, codcco);
             return numdoc2;
         }


         public Boolean sp_inyprod_insertaDetalleNotaDeIngreso(string numdoc2, int fila, int toper, string codpro, double cantidad, string unidad)
         {
             Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
             Boolean band = varprocesos.sp_inyprod_insertaDetalleNotaDeIngreso(numdoc2, fila, toper, codpro, cantidad, unidad);
             return band;
         }




         public Boolean sp_exporta_insumos_entre_empresas(string numdoc2, int empresa)
         {
             Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
             Boolean band = varprocesos.sp_exporta_insumos_entre_empresas(numdoc2, empresa);
             return band;
         }



         public Boolean sp_inyprod_InsertaNotaIngreso(string numdoc2, Cls_Doc_cab doccab, int toper, int idempresa, Cls_AnexoDocCAb anexodoccab, Cls_Doc_cab docabguia)
         {

             Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
             Boolean band = varprocesos.sp_inyprod_InsertaNotaIngreso(numdoc2, doccab, toper, idempresa, anexodoccab, docabguia);
             return band;
         }





         public Boolean sp_inyplanilla_actualiza_etiqueta_desvinculada(string numdoc2)
         {
             Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
             Boolean band = varprocesos.sp_inyplanilla_actualiza_etiqueta_desvinculada(numdoc2);
             return band;

         }


        public Boolean sp_inyprod_costeoPP(string numdoc2)
        {
           Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
            Boolean band = varprocesos.sp_inyprod_costeoPP(numdoc2);
            return band;
           
        }


        public Boolean sp_inyplanilla_actualizaconsumos(string numdoc2)
        {
            Cls_ProcesosCD varprocesos = new Cls_ProcesosCD(cadena);
            Boolean band = varprocesos.sp_inyplanilla_actualizaconsumos(numdoc2);
            return band;

        }

       

      

    }
}
