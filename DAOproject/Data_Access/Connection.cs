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

        //User ID=user; Password=pwd
        public Connection()
        {
            _connection = new SqlConnection(
                "Data Source=DESKTOP-MG0PNAP; Initial Catalog=testDB; Integrated security=SSPI");
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

        //Buscar a ligação
        public SqlConnection Fetch()
        {
            return this.Open();
        }

        public SqlConnection Open()
        {
           if(_connection.State == ConnectionState.Open )
            {
                _connection.Open();
            }
            return _connection;
        }
    }
}
