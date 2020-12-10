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
        private OleDbConnection _dbConnection;
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
        // Получить соединение с базой данных
        public OleDbConnection GetDbConnection()
        {
            return new OleDbConnection { ConnectionString = GetConnectionString() };
        }
        // Закрыть соединение с базой данных
        public void CloseDbConnection()
        {
            _dbConnection.Close();
        }
        // Получить записку по заданному ID записи
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
                note.Employer = reader[0].ToString();
                reader.Close();
                _dbConnection.Close();
                return note;
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return null; // если записи нет, вернем нулевой указатель
        }

        // Получить список работников по заданному ID проекта
        public List<Employer> GetEmployers(long ID_proj)
        {
            string query = string.Format("SELECT DISTINCT Сотрудники.Код, Сотрудники.Фамилия " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) " +
                                         "ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}))", ID_proj);
            var list = new List<Employer>();
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                Employer employer = new Employer();
                employer.ID = Convert.ToInt32(reader[0].ToString());
                employer.Name = reader[1].ToString();
                list.Add(employer);
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return list;
        }
        // Получить список ID задач по проекту по заданному ID проекта
        public List<long> GetTasksId(long ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN Записи ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}))", ID_proj);
            var list = new List<long>();
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                list.Add(Convert.ToInt32(reader[0].ToString()));
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return list; // возвращаем список ID
        }
        // Получить список ID задач по проекту в соответствии с заданным статусом задачи
        public List<long> GetTasksIdByStatus(string status, long ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}) AND((Записи.Статус) = \"{1}\"))", ID_proj, status);
            var list = new List<long>();
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                list.Add(Convert.ToInt32(reader[0].ToString()));
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return list; // возвращаем список ID
        }
        // Получить список ID задач работника по проекту
        public List<long> GetTasksIdByEmployer(string name, long ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Сотрудники.Фамилия) = \"{0}\") AND ((Проекты.Код) = {1}))", name, ID_proj);
            var list = new List<long>();
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                list.Add(Convert.ToInt32(reader[0].ToString()));
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return list; // возвращаем список ID
        }
    }
}
