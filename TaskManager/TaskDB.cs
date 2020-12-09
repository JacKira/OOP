using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.OleDb;

namespace TaskManager
{ 
    /// <summary>
    ///  Класс для взаимодействия с базой данных
    /// </summary>
    class TaskDB
    {
        private OleDbConnection _dbConnection;
        private string _dbconnstring;
        private string _dbsource;
        public TaskDB(string path)
        {
            _dbsource = path;
                 _dbconnstring = "Provider = Microsoft.Jet.OLEDB.4.0;  Data Source=" + path;
        }
        public OleDbConnection OpenDbConnection()
        {
            _dbconnstring = GetConnectionString();
            _dbConnection = new OleDbConnection { ConnectionString = _dbconnstring };
            return _dbConnection;
        }

        public string GetConnectionString()
        {
            return _dbconnstring;
        }

        public OleDbConnection GetDbConnection()
        {
            return new OleDbConnection { ConnectionString = GetConnectionString() };
        }
        public void CloseDbConnection()
        {
            _dbConnection.Close();
        }

    }
}
