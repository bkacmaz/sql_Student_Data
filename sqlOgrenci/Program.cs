using System;
using System.Data.SqlClient;
using System.Data;

namespace sqlOgrenci
{
    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=;Initial Catalog=;User ID=;Password=";
            SqlConnection cnn;
            cnn = new SqlConnection(connectionString);
            cnn.Open();
            SqlCommand command;
            // command = new SqlCommand("SELECT * FROM OGR ORDER BY ADI, OKUL_NO DESC", cnn);
            command = new SqlCommand("SELECT* FROM[dbo].[OGR]  LEFT JOIN DERS ON OKUL_NO = D_OKUL_NO", cnn);
            
            SqlDataReader reader;
            reader = command.ExecuteReader();
            // DataTable dt= reader.GetSchemaTable();
            DataTable dt = new DataTable();
            dt.Load(reader);

            for(int i=0; i<dt.Rows.Count; i++)
            {
                Console.WriteLine(dt.Rows[i]["OKUL_NO"].ToString() + " " + dt.Rows[i]["ADI"].ToString() + " "+ dt.Rows[i]["DERS_ADI"].ToString());               
            }
            
        }
    }
}
