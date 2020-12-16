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
    public class TaskTableData
    {
        private string constr;
        private Dictionary<int, NoteData> _notes = new Dictionary<int, NoteData>();
        public List<int> _ids = new List<int>();
        public List<int> _forPrint = new List<int>();
        public List<Employer> _employers = new List<Employer>();
        public List<Employer> _allEmployers = new List<Employer>();
        public Dictionary<string, List<int>> _tasksByStatus = new Dictionary<string, List<int>>();
        public NoteData this[int id]
        {
            get { return _notes[id]; }
            set { _notes[id] = value; }
        }

        public void Add()
        {
            var db = new TaskDB(constr);
            //00000000000000000000000000000000000000000000000000000000000000//
            //  if (note == null)
            // {
            //   note = new NoteData();
            // }
            //_notes.Add(note.ID, note);
            //00000000000000000000000000000000000000000000000000000000000000//
            var note = new NoteData() { Status = "To Do", ID = db.AddEmptyNoteData() };
            _notes.Add(note.ID, note);
            db.UpdateNote(note);
            _ids = db.GetTasksId(1);
            _forPrint = _ids;
            UpdateStatusList();
            UpdateEmployers();
        }

        private void UpdateEmployers()
        {
            var db = new TaskDB(constr);
            _employers = db.GetEmployers(1);
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
            _employers = db.GetEmployers(1);
            UpdateEmployers();
            //Заполняем доску задачами
            _forPrint = _ids;
        }
        private void UpdateStatusList()
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
            _forPrint.Remove(id);
        }
        public List<int> TasksByStatus(string status)
        {
            _forPrint = _tasksByStatus["To Do"];
            return _forPrint;
        }

        public List<int> GetTasksIdByEmployerId(int id, int id_proj)
        {
            var db = new TaskDB(constr);
            _forPrint = db.GetTasksIdByEmployerId(id, id_proj);
            return _forPrint;
        }

        public List<int> GetTasksIdByTitle(string str, int id_proj)
        {
            var db = new TaskDB(constr);
            _forPrint.Clear();
            foreach(var note in _notes) 
            {
                if (note.Value.Title.Contains(str)) 
                {
                    _forPrint.Add(note.Key);
                }
            }
            //_forPrint = db.GetTasksIdByTitle(str, id_proj);
            return _forPrint;
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
    }


}
