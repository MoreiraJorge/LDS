using DAOproject.Interfces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace DAOproject.Data_Access
{
    public class Connection : IConnection, IDisposable
    {
        private SqlConnection _connection;

        public Connection()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "housem8sql.database.windows.net";
            builder.UserID = "Marcelo";
            builder.Password = "HOUSEM8_SQL";
            builder.InitialCatalog = "testDB";
            builder.Encrypt = true;
            

            _connection = new SqlConnection(builder.ConnectionString);

            /*
             * "Data Source=housem8sql.database.windows.net;" +
                " User ID=Jorge Password=Moreira_SQL; " +
                " Initial Catalog=testDB; " +
                " Integrated security=False");
             */

            //Server = tcp:myserver.database.windows.net,1433; Database = myDataBase; User ID = mylogin@myserver; Password = myPassword; Trusted_Connection = False; Encrypt = True;
        }

        public void Close()
        {
            if(_connection.State == ConnectionState.Open)
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            this.Close();
            GC.SuppressFinalize(this);
        }

        public SqlConnection Fetch()
        {
            return this.Open();
        }

        public SqlConnection Open()
        {
           if(_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
