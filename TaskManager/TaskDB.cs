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
       
        /// <summary>
        /// Получить соединение с БД в виде строки
        /// </summary>
        /// <returns></returns>
        public string GetConnectionString()
        {
            return _dbconnstring;
        }

        /// <summary>
        /// Получить соединение с базой данных
        /// </summary>
        /// <returns></returns>
        public OleDbConnection GetDbConnection()
        {
            return new OleDbConnection { ConnectionString = GetConnectionString() };
        }

        /// <summary>
        /// Закрыть соединение с базой данных
        /// </summary>
        public void CloseDbConnection()
        {
            _dbConnection.Close();
        }

        /*================================= Получение данных из БД =================================*/

        /// <summary>
        /// Получить запись по заданному ID записи
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public NoteData GetNoteData(int ID)
        {
            string query = string.Format("SELECT Заголовок, Описание, Статус FROM Записи Where Код = {0}", ID);
            string query2 = string.Format("SELECT Фамилия " +
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

        /// <summary>
        /// Получить список работников по заданному ID проекта
        /// </summary>
        /// <param name="ID_proj"></param>
        /// <returns></returns>
        public List<Employer> GetEmployers(int ID_proj)
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
                if (!IsAdmin(Convert.ToInt32(reader[0].ToString())))
                {
                    Employer employer = new Employer();
                    employer.ID = Convert.ToInt32(reader[0].ToString());
                    employer.Name = reader[1].ToString();
                    list.Add(employer);
                }
            }
            // закрываем OleDbDataReader
            reader.Close();
            _dbConnection.Close();
            return list;
        }

        /// <summary>
        /// // Получить список ID задач по проекту по заданному ID проекта
        /// </summary>
        /// <param name="ID_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksId(int ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN Записи ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}))", ID_proj);
            var list = new List<int>();
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

        /// <summary>
        /// Получить список ID задач по проекту в соответствии с заданным статусом задачи
        /// </summary>
        /// <param name="status"></param>
        /// <param name="ID_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksIdByStatus(string status, int ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}) AND ((Записи.Статус) = \"{1}\"))", ID_proj, status);
            var list = new List<int>();
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
        /// <summary>
        /// Получить список ID задач по проекту в соответствии с заданным заголовком задачи
        /// </summary>
        /// <param name="title"></param>
        /// <param name="ID_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksIdByTitle(string title, int ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Проекты.Код) = {0}) AND ((Записи.Заголовок) = \"{1}\"))", ID_proj, title);
            var list = new List<int>();
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
        /// <summary>
        /// Получить список ID задач работника по проекту
        /// </summary>
        /// <param name="name"></param>
        /// <param name="ID_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksIdByEmployer(string name, int ID_proj)
        {
            string query = string.Format("SELECT Записи.Код " +
                                         "FROM(Проекты INNER JOIN Этапы ON Проекты.Код = Этапы.[ID проекта]) " +
                                         "INNER JOIN(Сотрудники INNER JOIN Записи ON Сотрудники.Код = Записи.[ID работника]) ON Этапы.Код = Записи.[ID этапа] " +
                                         "WHERE(((Сотрудники.Фамилия) = \"{0}\") AND ((Проекты.Код) = {1}))", name, ID_proj);
            var list = new List<int>();
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
            // закрываем соединение с БД
            _dbConnection.Close();
            return list; // возвращаем список ID
        }

        /// <summary>
        /// Получить фамилию работника по его ID
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public string GetNameByEmployerId(int ID)
        {
            string query = string.Format("SELECT Фамилия FROM Сотрудники" +
                                         "WHERE Код = {0}", ID);
            string name;
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                name = reader[0].ToString();
                // закрываем OleDbDataReader
                reader.Close();
                // закрываем соединение с БД
                _dbConnection.Close();
                return name; // возвращаем фамилию работника
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return null; // если работника нет, вернем нулевой указатель 
        }

        /// <summary>
        /// Получить ID работника по его фамилии
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int GetEmployerIdByName(string name)
        {
            string query = string.Format("SELECT Код FROM Сотрудники " +
                                         "WHERE Фамилия = '{0}'", name);
            int ID;
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ID = Convert.ToInt32(reader[0].ToString());
                // закрываем OleDbDataReader
                reader.Close();
                // закрываем соединение с БД
                _dbConnection.Close();
                return ID; // возвращаем фамилию работника
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return -1; // если работника нет, вернем -1 
        }

        /// <summary>
        /// Получить ID работника по его логину
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public int? GetIdByLogin(string login)
        {
            string query = string.Format("SELECT Код FROM Сотрудники" +
                                         "WHERE Логин = {0}", login);
            int? ID;
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                ID = Convert.ToInt32(reader[0].ToString());
                // закрываем OleDbDataReader
                reader.Close();
                // закрываем соединение с БД
                _dbConnection.Close();
                return ID; // возвращаем фамилию работника
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return null; // если работника нет, вернем нулевой указатель 
        }

        /// <summary>
        /// Проверить, является ли сотрудник админом
        /// </summary>
        /// <param name="ID"></param>
        /// <returns>bool</returns>
        public bool IsAdmin(int ID)
        {
            string query = string.Format("SELECT Код FROM Администраторы " +
                                         "WHERE [ID сотрудника] = '{0}'", ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                // закрываем OleDbDataReader
                reader.Close();
                // закрываем соединение с БД
                _dbConnection.Close();
                return true; // возвращаем фамилию работника
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return false; // если работника нет, вернем -1 
        }

        /// <summary>
        /// Верификация пользователя. Если он есть в БД и он админ - вернем true. 
        /// Если он есть в БД, но не админ - вернем false.
        /// Если его нет в БД - вернем null.
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password_"></param>
        /// <returns>bool?</returns>
        public bool? Verification(string login, string password_)
        {
            int? ID = this.GetIdByLogin(login);
            if (ID == null)
            {
                return null;
            }
            string query = string.Format("SELECT Пароль FROM Сотрудники" +
                                         "WHERE Код = {0}", ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            OleDbDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                string password = reader[0].ToString();
                // закрываем OleDbDataReader
                reader.Close();
                // закрываем соединение с БД
                _dbConnection.Close();
                if (password_ == password)
                {
                    if (this.IsAdmin((int)ID))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            // закрываем OleDbDataReader
            reader.Close();
            // закрываем соединение с БД
            _dbConnection.Close();
            return null;
        }

        /*================================= Добавление данных в БД =================================*/

        /// <summary>
        /// Обновить данные записи в БД
        /// </summary>
        /// <param name="note"></param>
        public void UpdateNote(NoteData note)
        {
            int ID = this.GetEmployerIdByName(note.Employer);
            string query = string.Format("UPDATE Записи " +
                                        "SET Заголовок = '{0}', Описание = '{1}', " +
                                        "[ID работника] = {2}, [ID этапа] = {3}, Статус = '{4}' " +
                                        "WHERE Код = {5}", note.Title, note.Description, ID, 1, note.Status, note.ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            command.ExecuteNonQuery(); // вносим изменения в БД
            // закрываем соединение с БД
            _dbConnection.Close();
        }

        /// <summary>
        /// Добавить сотрудника в БД
        /// </summary>
        /// <param name="name"></param>
        /// <param name="login"></param>
        /// <param name="password"></param>
        public void LogIn(string name, string login, string password)
        {
            string query = string.Format("INSERT INTO Сотрудники (Фамилия, Пароль, Логин)" +
                                         "VALUES ('{0}', '{1}', '{2}')", name, password, login);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            // закрываем соединение с БД
            _dbConnection.Close();
        }

        /// <summary>
        /// Добавить администратора из числа работников, если он не админ
        /// </summary>
        /// <param name="ID"></param>
        public void AddAdmin(int ID)
        {
            if (!IsAdmin(ID))
            {
                string query = string.Format("INSERT INTO Администраторы ([ID сотрудника]) " +
                                             "VALUES ({0})", ID);
                // открываем соединение с БД
                _dbConnection.Open();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, _dbConnection);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
                // закрываем соединение с БД
                _dbConnection.Close();
            }
        }

        /// <summary>
        ///  Назначить администратора на проект
        /// </summary>
        /// <param name="ID_admin"></param>
        /// <param name="ID_proj"></param>
        public void SetAdmin(int ID_admin, int ID_proj)
        {
            string query = string.Format("UPDATE Проекты " +
                                         "SET [ID администратора] = {0} " +
                                         "WHERE Код = {1}", ID_admin, ID_proj);
            // открываем соединение с БД
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            // закрываем соединение с БД
            _dbConnection.Close();
        }

        /*================================= Удаление данных из БД =================================*/

        /// <summary>
        /// Удаление записи из БДparam name="ID"></param>
        public void DeleteNoteData(int ID)
        {
            string query = string.Format("DELETE FROM Записи WHERE Код = {0}", ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            _dbConnection.Close();
        }

        /// <summary>
        /// Удалить работника из БД, если он не является админом.
        /// В противном случае - ничего не делать
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteEmployer(int ID)
        {
            if (!this.IsAdmin(ID))
            {
                string query = string.Format("DELETE FROM Сотрудники WHERE Код = {0}", ID);
                _dbConnection.Open();
                // создаем объект OleDbCommand для выполнения запроса к БД MS Access
                OleDbCommand command = new OleDbCommand(query, _dbConnection);
                // выполняем запрос к MS Access
                command.ExecuteNonQuery();
                _dbConnection.Close();
            }
        }

        /// <summary>
        /// Удалить администратора из БД
        /// <param name="ID"></param>
        public void DeleteAdmin(int ID)
        {
            string query = string.Format("DELETE FROM Администраторы WHERE Код = {0}", ID);
            _dbConnection.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, _dbConnection);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            _dbConnection.Close();
        }
    }
}
