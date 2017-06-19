using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;


namespace webNew3.Connection
{
    public class ConnectToDb
    {
        /// <summary>
        /// Вевтає Id щойно доданого клієнта 
        /// (викорстовується T-SQl функція SCOPE_IDENTITY())
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        public static int GetLastGeneratedValue(string firstName, string lastName)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["Projects"].ConnectionString;
            int lastId;

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand com = new SqlCommand("SetCustimerGetLastId", con);
                com.CommandType = CommandType.StoredProcedure;

                com.Parameters.AddWithValue("@FirstName", firstName);
                com.Parameters.AddWithValue("@LastName", lastName);
                SqlParameter outputParameter = new SqlParameter("@LastId", SqlDbType.Int)
                { 
                    Direction = ParameterDirection.Output
                };
                com.Parameters.Add(outputParameter);

                con.Open();
                com.ExecuteNonQuery();

                lastId = outputParameter.Value as int? ?? 0; 
            }

            return lastId;
        }
    }
}