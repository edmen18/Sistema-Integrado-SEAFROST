using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class SaveFile
{
    public string FileName { set; get; }
    public string FileExtension { set; get; }
    public byte[] FileContent { set; get; }

    public string codusu { set; get; }
    public string codarea { set; get; }
    public DateTime fechamod { set; get; }

    public Result SaveFileInDB()
    {
        Result Result = new Result();
       // string strConnection = "data source=mssql1.perucloud.net;initial catalog=seafrost;user id=seafrost;password=ZXFhW9mF";
        //"Data Source=Imdadhusen\\SQLEXPRESS;Initial Catalog=SaveFileExampleDB;Integrated Security=True;Pooling=False"
        using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["inysoft2013"].ToString()))
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SaveFilesInDB";
            cmd.Connection = conn;

            //cmd.Parameters.AddWithValue("@FileContent", FileContent);
            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@FileExtension", FileExtension);

            cmd.Parameters.AddWithValue("@codusu", codusu);
            cmd.Parameters.AddWithValue("@codarea", codarea);
            cmd.Parameters.AddWithValue("@fechamod", fechamod);


            try
            {
                conn.Open();
                cmd.ExecuteNonQuery();
                Result.IsError = false;
            }
            catch (Exception ex)
            {
                Result.IsError = true;
                Result.ErrorMessage = ex.Message;
                Result.InnerException = ex.InnerException.ToString();
                Result.StackTrace = ex.StackTrace.ToString();
            }
            finally
            {
                conn.Close();
                cmd.Dispose();
                conn.Dispose();
            }
        }
        return Result;
    }
}