using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TaskManager;

namespace TaskManager
{
    /// <summary>
    /// Класс для хранения объектов задач и взаимодействия с ними,
    /// а также для передачи данных интерфейсу для отображения
    /// </summary>
    public class TaskTableData
    {
        private Dictionary<int, NoteData> _tableData = new Dictionary<int, NoteData>();
        public int maxid = 0;
        public NoteData this[int id]
        {
            get { return _tableData[id]; }
            set { _tableData[id] = value; }
        }

        public void Add(NoteData note = null)
        {
            if (note == null)
            {
                note = new NoteData();
            }
            if(note.ID > maxid)
            {
                maxid = note.ID;
            }
            _tableData.Add(note.ID, note);
        }
    }

    public class NoteData
    {
        public string Title { get; set; } = "\0";
        public string Description { get; set; } = "\0";
        public Employer Employer = new Employer();
        public string Status { get; set; } = "\0";
        public int ID { get; set; } = 0;
    }

    public class Employer
    {
        public int ID { get; set; } = 0;
        public string Name { get; set; } = "\0";

        override public string ToString() 
        {
            return Name;
        }
    }


}
