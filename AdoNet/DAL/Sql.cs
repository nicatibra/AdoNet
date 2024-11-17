using System.Data;
using System.Data.SqlClient;

namespace AdoNet.DAL
{
    internal class Sql
    {
        private const string connectionString = @"server=NICATSROG\SQLEXPRESS;database=AdoNet;trusted_connection=true;integrated security=true;";
        private static SqlConnection conn = new SqlConnection(connectionString);

        public int ExecuteCommand(string command)
        {
            int result = 0;
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(command, conn);
                result = cmd.ExecuteNonQuery();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return result;
        }

        public DataTable ExecuteQuery(string query)
        {
            DataTable table = new DataTable();

            try
            {
                conn.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.Fill(table);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                conn.Close();
            }

            return table;
        }
    }
}
