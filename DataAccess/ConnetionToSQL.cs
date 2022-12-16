using System.Data;
using System.Data.SqlClient;

namespace DataAccess
{
    public abstract class ConnetionToSQL
    {
        private readonly string connectionString;
        public ConnetionToSQL()
        {
            connectionString = "Server=(local)\\MSSQLSERVER01;Database=MyCompany;Integrated Security=true";
        }
        protected  SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}