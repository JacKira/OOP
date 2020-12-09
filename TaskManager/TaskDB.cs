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
        private string _dbconnstring;
        private string _dbsource;
        public TaskDB(string path)
        {
            _dbsource = path;
            _dbconnstring = "Provider = Microsoft.Jet.OLEDB.4.0;  Data Source=" + path;
            _dbConnection = new OleDbConnection { ConnectionString = _dbconnstring };
        }
        /*public OleDbConnection OpenDbConnection()
        {
            _dbconnstring = GetConnectionString();
            _dbConnection = new OleDbConnection { ConnectionString = _dbconnstring };
            return _dbConnection;
        }*/

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

        public NoteData GetNoteData(long ID)
        {
            string query = string.Format("SELECT Заголовок, Описание, Статус FROM Записи Where Код = {0}", ID);
            string query2 = string.Format("SELECT Сотрудники.Фамилия, Записи.Код " +
                                          "FROM Сотрудники " +
                                          "INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника] " +
                                          "WHERE(((Записи.Код) = {0}))", ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            var note = new NoteData() { ID = ID };
            // в цикле построчно читаем ответ от БД
            if (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                //listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " ");
                note.Title = reader[0].ToString();
                note.Description = reader[1].ToString();
                note.Status = reader[2].ToString().Replace(" ", "");
            }
            // закрываем OleDbDataReader
            reader.Close();

            command = new OleDbCommand(query2, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            if (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                //listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " ");
                note.Employer = reader[0].ToString();
                reader.Close();
                _dbConnection.Close();
                return note;
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return null;
        }

        public List<Employer> GetEmployers(long ID_proj)
        {
            var list = new List<Employer>();
            return list;
        }

        public List<long> GetTasksId(long ID_proj)
        {
            var list = new List<long>();
            return list;
        }
    }
}
