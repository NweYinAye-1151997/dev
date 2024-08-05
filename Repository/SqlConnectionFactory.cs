using System.Data;
using System.Data.SqlClient;

namespace ShoppingCartProject.Repository
{
    public class SqlConnectionFactory
    {
        private static readonly string Server = "Server=";
        private static readonly string DataBase = ";Database=";
        private static readonly string UserId = ";User ID=";
        private static readonly string Password = ";Password=";
        private static readonly string MinPoolSize = "; Min Pool Size=";
        private static readonly string MaxPoolSize = "; Max Pool Size=";
        private static readonly string Pooling = "; Pooling=";
        public SqlConnectionFactory() { }
        public IDbConnection CreateConnection()
        {
            {
                //string test = _connectionString;


                string strUserId = "sa";
                string strPassword = "123";
                string strIP = "localhost";
                string strDb = "ShoppingCart";
                int strMinPoolSize = 0;
                int strMaxPoolSize = 100;
                bool strPool = true;
                string result = Server + strIP + DataBase + strDb + UserId + strUserId + Password + strPassword + MinPoolSize + strMinPoolSize + "" + MaxPoolSize + strMaxPoolSize + "" + Pooling + strPool + "";

                var sqlConnection = new SqlConnection(result);
                sqlConnection.Open();
                return sqlConnection;
            }
        }


    }
}
