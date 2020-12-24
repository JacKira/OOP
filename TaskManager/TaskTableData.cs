using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskManager;
//=========================== Baranov ===============================//
namespace TaskManager
{
    /// <summary>
    /// Класс для хранения объектов задач и взаимодействия с ними,
    /// а также для передачи данных интерфейсу для отображения
    /// </summary>
    public class TaskTableData : IDisposable
    {
        private string constr; // содержит путь к базе данных
        private Dictionary<int, NoteData> _notes = new Dictionary<int, NoteData>(); // словарь для хранения списка задач
        private List<int> _ids = new List<int>(); // список id всех задач
        private Dictionary<string, List<int>> _tasksByStatus = new Dictionary<string, List<int>>();// словарь для хранения списков задач по id
        public List<int> forPrint = new List<int>(); // список id задач для отображения на доске
        public List<Employer> employers = new List<Employer>(); // список работников за которыми закреплены задачи
        public List<Employer> allEmployers = new List<Employer>(); // список всех работников


        /// <summary>
        /// Конструктор осуществляющий подключение и загрузку данных из базы данных из файла по заданому пути
        /// </summary>
        /// <param name="path"></param>
        public TaskTableData(string path = "") // конструктор принимает путь к базе данных
        {
            constr = path;
            var db = new TaskDB(path); // создание объекта для взаимодействия с БД по переданному пути

            //Получаем все задачи проекта
            _ids = db.GetTasksId(1); // список id задач 1 проекта
            foreach (var id in _ids) // цик перебора всех элементов списка
            {
                var note = db.GetNoteData(id); // создаем объект листочка и получаем данные из БД по id данной итерации
                _notes.Add(note.ID, note); // добавляем листочек в сорварь по id данной итерации
            }

            // наполняем словарь статусов списками id задач 
            UpdateStatusList();
            // наполняем список всех работников
            UpdateAllEmployers();
            // наполняем список работников у которых есть задачи
            UpdateEmployers();
            // сохраняем id для печати
            forPrint = _ids;
        }

        /// <summary>
        /// Перегрузка оператора индексации
        /// возвращает задачу с заданым id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public NoteData this[int id]
        {
            get { return _notes[id]; }
            set { _notes[id] = value; }
        }

        /// <summary>
        /// Получаем id всех задач
        /// </summary>
        /// <returns></returns>
        public List<int> GetAllIds()
        {
            forPrint = _ids;
            return forPrint;
        }

        /// <summary>
        /// Очищение выделеной памяти
        /// </summary>
        public void Dispose()
        {
            _notes.Clear();
            _ids.Clear();
            forPrint.Clear();
            employers.Clear();
            allEmployers.Clear();
            _tasksByStatus.Clear();
            constr = string.Empty; // очищение переменной для пути БД
        }

        /// <summary>
        /// Добавление пустой задачи в базу
        /// </summary>
        public void Add()
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            var note = new NoteData() { Status = "To Do", ID = db.AddEmptyNoteData() }; // создание объекта листочка со статусом "To Do" и новым id
            _notes.Add(note.ID, note); // добавление листочка в словарь
            db.UpdateNote(note); // обновление данных листочка в БД
            _ids = db.GetTasksId(1); // получаем список id всех задач 1 проекта 
            forPrint = _ids; // сохраняем id для печати
            UpdateStatusList(); // наполняем словарь статусов по id задач
            UpdateEmployers(); // наполняем список работников с задачами
        }

        /// <summary>
        /// Обновление списка работников на проект
        /// </summary>
        public void UpdateEmployers()
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            employers = db.GetEmployers(1); // заполнение списка работников с задачами
        }

        /// <summary>
        /// Обновление списка всех работников
        /// </summary>
        public void UpdateAllEmployers()
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            allEmployers = db.GetEmployers(); // заполнение списка всех работников
        }

        /// <summary>
        /// Обновление списка задач по статусам
        /// </summary>
        public void UpdateStatusList()
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            var stat1 = db.GetTasksIdByStatus("To Do", 1); //
            var stat2 = db.GetTasksIdByStatus("Doing", 1); // получаем списки задач по данным статусам проекта 1
            var stat3 = db.GetTasksIdByStatus("Done", 1);  //
            _tasksByStatus.Clear(); // очищаем словарь статусов
            _tasksByStatus.Add("To Do", stat1); //
            _tasksByStatus.Add("Doing", stat2); // заполняем словарь статусов соответствующими списками задач
            _tasksByStatus.Add("Done", stat3);  //
        }


        /// <summary>
        /// Удаление записи по id
        /// </summary>
        /// <param name="id"></param>
        public void DeleteNote(int id)
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            db.DeleteNoteData(id); // удаление листочка по заданому id
            _ids = db.GetTasksId(1); // получаем список id всех задач 1 проекта 
            _notes.Remove(id); // удаляем объект из словаря по id
            forPrint.Remove(id); // удаляем объект из списка для печати
        }

        /// <summary>
        /// получение списка задач по статусу
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<int> TasksByStatus(string status)
        {
            forPrint = _tasksByStatus[status]; // получаем список id по заданному статусу
            return forPrint;
        }

        /// <summary>
        /// Получение списка задач по id работника
        /// </summary>
        /// <param name="id"></param>
        /// <param name="id_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksIdByEmployerId(int id, int id_proj)
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            forPrint = db.GetTasksIdByEmployerId(id, id_proj); // получаем список id задач по id работника
            return forPrint;
        }

        /// <summary>
        /// Получение списка задач по заголовку
        /// </summary>
        /// <param name="str"></param>
        /// <param name="id_proj"></param>
        /// <returns></returns>
        public List<int> GetTasksIdByTitle(string str, int id_proj) // получаем заголовок
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            forPrint.Clear();
            foreach (var note in _notes) // перебор словаря с задачами
            {
                if (note.Value.Title.ToUpper().Contains(str.ToUpper())) // проверка поискового условия
                {
                    forPrint.Add(note.Key); // запоминаем id данной задачи в список для печати
                }
            }
            return forPrint;
        }


        /// <summary>
        /// Изменение заголовка по id задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        public void ChangeTitle(int id, string newStr) // получаем id и новый заголовок изменяемой задачи
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            _notes[id].Title = newStr; // замена заголовка задачи по id на полученное значение 
            db.UpdateNote(_notes[id]); // обновляем данные о задаче в БД
        }

        /// <summary>
        /// Изменение описания по id задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        public void ChangeDescription(int id, string newStr) // получаем id и новое описание изменяемой задачи
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            _notes[id].Description = newStr; // замена описания задачи по id на полученное значение 
            db.UpdateNote(_notes[id]); // обновляем данные о задаче в БД
        }

        /// <summary>
        /// Изменение работника по id задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="new_employer"></param>
        public void ChangeEmployer(int id, object new_employer) // получаем id и работника изменяемой задачи
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            _notes[id].Employer = new_employer as Employer; // замена работника задачи по id на полученное значение 
            db.UpdateNote(_notes[id]); // обновляем данные о задаче в БД
            UpdateEmployers(); // обновление списка работников с задачами
        }

        /// <summary>
        /// Изменение статуса по id задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        public void ChangeStatus(int id, string newStr) // получаем id и статус изменяемой задачи
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            _notes[id].Status = newStr; // замена статуса задачи по id на полученное значение 
            db.UpdateNote(_notes[id]); // обновляем данные о задаче в БД
            UpdateStatusList(); // обновление словаря статусов
        }

        /// <summary>
        /// обновление данных задачи по id в базе данных
        /// </summary>
        /// <param name="id"></param>
        public void UpdateNote(int id) // получение id 
        {
            var db = new TaskDB(constr); // создание объекта для взаимодействия с БД по переданному пути
            db.UpdateNote(_notes[id]);
        }
    }
    /// <summary>
    /// объект для храния данных о задаче
    /// </summary>
    public class NoteData
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public Employer Employer = new Employer();
        public string Status { get; set; } = "";
        public int ID { get; set; } = 0;
    }

    /// <summary>
    /// объект для хранения данных о работнике
    /// </summary>
    public class Employer
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "";

        override public string ToString() // перегрузка метода преобразования объекта в строку
        {
            return Name;
        }

        // Перегружаем логический оператор ==
        public static bool operator ==(Employer employer1, Employer employer2)
        {
            return employer1.ID == employer2.ID;
        }
        // Перегружаем логический оператор =!
        public static bool operator !=(Employer employer1, Employer employer2)
        {
            return employer1.ID != employer2.ID;
        }
    }
}

