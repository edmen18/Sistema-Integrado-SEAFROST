using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Configuration;
using CapaEntidades;

namespace CapaDatos
{
   public class Cls_ProcesosCD
    {
         private SqlConnection conectar;

        public Cls_ProcesosCD(string cadena)
        {
            this.conectar = Cls_ConexionCD.conectar(cadena);
        }

        public Boolean sp_inyprod_insertaDetalleNotaDeIngreso(string numdoc2, int fila, int toper, string codpro, double cantidad, string unidad)
        {
            Boolean band = true;

            string sql = string.Empty;
            try
            {

                sql = "sp_inyprod_insertaDetalleNotaDeIngreso";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conectar;
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
                sqlCmd.Parameters.AddWithValue("@fila",fila);
                sqlCmd.Parameters.AddWithValue("@toper", toper);
                sqlCmd.Parameters.AddWithValue("@Codpro", codpro);
                sqlCmd.Parameters.AddWithValue("@cantidad", cantidad);
                sqlCmd.Parameters.AddWithValue("@Unidad", unidad);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                sqlCmd.ExecuteNonQuery();
                conectar.Close();

                
            }
            catch (Exception)
            {
                band = false;
            }

            return band;
        }

        public Boolean sp_inyprod_InsertaNotaIngreso(string numdoc2, Cls_Doc_cab doccab, int toper, int idempresa, Cls_AnexoDocCAb anexodoccab, Cls_Doc_cab docabguia)
        {


            Boolean band = true;

            string sql = string.Empty;
            try
            {
                sql = "sp_inyprod_InsertaNotaIngreso";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conectar;
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddWithValue("@numFact", numdoc2);
                sqlCmd.Parameters.AddWithValue("@DFECHA", doccab.DFECHA);
                sqlCmd.Parameters.AddWithValue("@codproveedor", doccab.CODTER);
                sqlCmd.Parameters.AddWithValue("@usuario", doccab.CODUSU);
                sqlCmd.Parameters.AddWithValue("@NLote", doccab.nloteni);
                sqlCmd.Parameters.AddWithValue("@Codbod", docabguia.CODBOD);
                sqlCmd.Parameters.AddWithValue("@Codcco", docabguia.CODCCO);
                sqlCmd.Parameters.AddWithValue("@FECHAMOD", doccab.Fechamod);
                sqlCmd.Parameters.AddWithValue("@toper", toper);
                sqlCmd.Parameters.AddWithValue("@idCodcco2", doccab.idCodcco2);
                sqlCmd.Parameters.AddWithValue("@idempresa", idempresa);
                sqlCmd.Parameters.AddWithValue("@OBSERV2", doccab.OBSERV2);
                sqlCmd.Parameters.AddWithValue("@ProcedenciaPesca", doccab.ProcedenciaPesca);
                sqlCmd.Parameters.AddWithValue("@EMBARQUE", doccab.EMBARQUE);
                sqlCmd.Parameters.AddWithValue("@PLACAVEH", doccab.PLACAVEH);
                sqlCmd.Parameters.AddWithValue("@matriculaEmbarcacion", doccab.matriculaEmbarcacion);
                sqlCmd.Parameters.AddWithValue("@poza", doccab.poza);
                sqlCmd.Parameters.AddWithValue("@guiaRemision", doccab.guiaRemision);
                sqlCmd.Parameters.AddWithValue("@idcodemb", doccab.idcodemb);
                sqlCmd.Parameters.AddWithValue("@numDERMB", doccab.numDERMB);
                sqlCmd.Parameters.AddWithValue("@numMallas", doccab.numMallas);
                sqlCmd.Parameters.AddWithValue("@numManojos", doccab.numManojos);
                sqlCmd.Parameters.AddWithValue("@frecepcion", doccab.frecepcion);
                sqlCmd.Parameters.AddWithValue("@plantaproceso", doccab.plantaproceso);

                sqlCmd.Parameters.AddWithValue("@color", anexodoccab.color);
                sqlCmd.Parameters.AddWithValue("@codlang", anexodoccab.codlang);
                sqlCmd.Parameters.AddWithValue("@poza2", anexodoccab.poza);
                sqlCmd.Parameters.AddWithValue("@factor", anexodoccab.factor);

                sqlCmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                sqlCmd.ExecuteNonQuery();
                conectar.Close();
            }
            catch (Exception)
            {
                band = false;
            }

            return band;
        }

      
        public string  sp_generarNumNotadeIngresoxccosto(int toper ,string codcco )
        {
            string numdoc2 = string.Empty;
            SqlParameter numFact;
            string sql = string.Empty;
            try
            {

                sql = "sp_generarNumNotadeIngresoxccosto";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conectar;
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddWithValue("@toper", toper);
                sqlCmd.Parameters.AddWithValue("@codcco", codcco );
                numFact = sqlCmd.Parameters.Add("@numFact", SqlDbType.VarChar, 20);
                numFact.Direction = ParameterDirection.Output;
                sqlCmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                sqlCmd.ExecuteNonQuery();
                numdoc2 = numFact.Value.ToString();
                conectar.Close();
            }
            catch (Exception)
            {
                numdoc2 = string.Empty;
            }

            return numdoc2;
        }


        public Boolean sp_inyplanilla_actualiza_etiqueta_desvinculada(string numdoc2)
        {
            Boolean band = true;

            string sql = string.Empty;
            try
            {

                sql = "sp_inyplanilla_actualiza_etiqueta_desvinculada";
                SqlCommand sqlCmd = new SqlCommand();
                sqlCmd.Connection = conectar;
                sqlCmd.CommandText = sql;
                sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
                sqlCmd.CommandType = CommandType.StoredProcedure;
                conectar.Open();
                sqlCmd.ExecuteNonQuery();
                conectar.Close();
            }
            catch (Exception)
            {
                band = false;
            }

            return band;
        }


       public Boolean sp_inyprod_costeoPP(string numdoc2)
        {
            Boolean band = true;

            string sql = string.Empty;
            try
            {

            sql = "sp_inyprod_costeoPP";
            SqlCommand sqlCmd = new SqlCommand();
            sqlCmd.Connection = conectar;
            sqlCmd.CommandText = sql;
            sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
            sqlCmd.CommandType = CommandType.StoredProcedure;
            conectar.Open();
            sqlCmd.ExecuteNonQuery();
            conectar.Close();
            }
            catch (Exception)
            {
                band = false;
            }
                      
            return band;
        }

       public Boolean sp_exporta_insumos_entre_empresas(string numdoc2, int empresa)
       {
           Boolean band = true;

           string sql = string.Empty;
           try
           {

               sql = "sp_exporta_insumos_entre_empresas";
               SqlCommand sqlCmd = new SqlCommand();
               sqlCmd.Connection = conectar;
               sqlCmd.CommandText = sql;
               sqlCmd.Parameters.AddWithValue("@numdoc2", numdoc2);
               sqlCmd.Parameters.AddWithValue("@empresa", empresa);
               sqlCmd.CommandType = CommandType.StoredProcedure;
               conectar.Open();
               sqlCmd.ExecuteNonQuery();
               conectar.Close();
           }
           catch (Exception)
           {
               band = false;
           }

           return band;
       }



       public Boolean sp_inyplanilla_actualizaconsumos(string numdoc2)
       {
           Boolean band = true;

           string sql = string.Empty;
           try
           {

               sql = "sp_inyplanilla_actualizaconsumos";
               SqlCommand sqlCmd = new SqlCommand();
               sqlCmd.Connection = conectar;
               sqlCmd.CommandText = sql;
               sqlCmd.Parameters.AddWithValue("@numpp", numdoc2);
               sqlCmd.CommandType = CommandType.StoredProcedure;
               conectar.Open();
               sqlCmd.ExecuteNonQuery();
               conectar.Close();
           }
           catch (Exception)
           {
               band = false;
           }

           return band;
       }

      
        
    }
}
