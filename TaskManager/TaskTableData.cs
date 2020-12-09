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
        private Dictionary<long, NoteData> _tableData = new Dictionary<long, NoteData>();
        public long maxid = 0;
        public NoteData this[long id]
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
            maxid += 1;
            note.ID = maxid;
            _tableData.Add(note.ID, note);
        }
    }

    public class NoteData
    {
        public string Title { get; set; } = "\0";
        public string Description { get; set; } = "\0";
        public string Employer { get; set; } = "\0";
        public string Status { get; set; } = "\0";
        public long ID { get; set; } = 0;
    }

    class Employer
    {
        public long ID { get; set; } = 0;
        public string Name { get; set; } = "\0";
        
    }


}
