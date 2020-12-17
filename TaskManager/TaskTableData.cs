using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskManager;
//=========================== Sanya ===============================//
namespace TaskManager
{
    /// <summary>
    /// Класс для хранения объектов задач и взаимодействия с ними,
    /// а также для передачи данных интерфейсу для отображения
    /// </summary>
    public class TaskTableData : IDisposable
    {
        private string constr;
        private Dictionary<int, NoteData> _notes = new Dictionary<int, NoteData>();
        private List<int> _ids = new List<int>();
        private Dictionary<string, List<int>> _tasksByStatus = new Dictionary<string, List<int>>();
        public List<int> forPrint = new List<int>();
        public List<Employer> employers = new List<Employer>();
        public List<Employer> allEmployers = new List<Employer>();
        public NoteData this[int id]
        {
            get { return _notes[id]; }
            set { _notes[id] = value; }
        }

        public List<int> GetAllIds()
        {
            forPrint = _ids;
            return forPrint;
        }

        public void Dispose()
        {
            _notes.Clear();
            _ids.Clear();
            forPrint.Clear();
            employers.Clear();
            allEmployers.Clear();
            _tasksByStatus.Clear();
            constr = string.Empty;
        }

        public void Add()
        {
            var db = new TaskDB(constr);
            var note = new NoteData() { Status = "To Do", ID = db.AddEmptyNoteData() };
            _notes.Add(note.ID, note);
            db.UpdateNote(note);
            _ids = db.GetTasksId(1);
            forPrint = _ids;
            UpdateStatusList();
            UpdateEmployers();
        }

        public void UpdateEmployers()
        {
            var db = new TaskDB(constr);
            employers = db.GetEmployers(1);
        }

        public void UpdateAllEmployers()
        {
            var db = new TaskDB(constr);
            allEmployers = db.GetEmployers();
        }

        public TaskTableData(string path = "")
        {
            constr = path;
            var db = new TaskDB(path);

            //Получаем все задачи проекта
            _ids = db.GetTasksId(1);
            foreach (var id in _ids)
            {
                var note = db.GetNoteData(id);
                _notes.Add(note.ID, note);
            }

            //Получаем id по статусу
            UpdateStatusList();
            //Получим работников
            UpdateAllEmployers();
            UpdateEmployers();
            //Заполняем доску задачами
            forPrint = _ids;
        }
        public void UpdateStatusList()
        {
            var db = new TaskDB(constr);
            var stat1 = db.GetTasksIdByStatus("To Do", 1);
            var stat2 = db.GetTasksIdByStatus("Doing", 1);
            var stat3 = db.GetTasksIdByStatus("Done", 1);
            _tasksByStatus.Clear();
            _tasksByStatus.Add("To Do", stat1);
            _tasksByStatus.Add("Doing", stat2);
            _tasksByStatus.Add("Done", stat3);
        }

        public void DeleteNote(int id)
        {
            var db = new TaskDB(constr);
            db.DeleteNoteData(id);
            _ids = db.GetTasksId(1);
            _notes.Remove(id);
            forPrint.Remove(id);
        }
        public List<int> TasksByStatus(string status)
        {
            forPrint = _tasksByStatus[status];
            return forPrint;
        }

        public List<int> GetTasksIdByEmployerId(int id, int id_proj)
        {
            var db = new TaskDB(constr);
            forPrint = db.GetTasksIdByEmployerId(id, id_proj);
            return forPrint;
        }

        public List<int> GetTasksIdByTitle(string str, int id_proj)
        {
            var db = new TaskDB(constr);
            forPrint.Clear();
            foreach(var note in _notes) 
            {
                if (note.Value.Title.ToUpper().Contains(str.ToUpper())) 
                {
                    forPrint.Add(note.Key);
                }
            }
            //_forPrint = db.GetTasksIdByTitle(str, id_proj);
            return forPrint;
        }

        public void ChangeTitle(int id, string newStr)
        {
            var db = new TaskDB(constr);
            _notes[id].Title = newStr;
            db.UpdateNote(_notes[id]);
        }

        public void ChangeDescription(int id, string newStr)
        {
            var db = new TaskDB(constr);
            _notes[id].Description = newStr;
            db.UpdateNote(_notes[id]);
        }
        public void ChangeEmployer(int id, object new_employer)
        {
            var db = new TaskDB(constr);
            _notes[id].Employer = new_employer as Employer;
            db.UpdateNote(_notes[id]);
            UpdateEmployers();
        }

        public void ChangeStatus(int id, string newStr)
        {
            var db = new TaskDB(constr);
            _notes[id].Status = newStr;
            db.UpdateNote(_notes[id]);
            UpdateStatusList();
        }

        public void UpdateNote(int id)
        {
            var db = new TaskDB(constr);
            db.UpdateNote(_notes[id]);
        }
    }

    public class NoteData
    {
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public Employer Employer = new Employer();
        public string Status { get; set; } = "";
        public int ID { get; set; } = 0;
    }

    public class Employer
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "";

        override public string ToString() 
        {
            return Name;
        }

        // Перегружаем логический оператор ==
        public static bool operator ==(Employer employer1, Employer employer2)
        {
            return employer1.ID == employer2.ID;
        }

        public static bool operator !=(Employer employer1, Employer employer2)
        {
            return employer1.ID != employer2.ID;
        }


    }


}
