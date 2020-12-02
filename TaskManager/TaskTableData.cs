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
            if(note == null)
            {
                note = new NoteData();
            }
            maxid += 1;
            note.ID = maxid;
            _tableData.Add(note.ID, note);
        }
    }

    /*
    public class NoteData
    {
        private string _title;
        private string _description;
        private string _status;
        private string _employer;
        private long _id;
        public NoteData(string title, string description, string status, string employer, long id)
        {
            _title = title;
            _description = description;
            _status = status;
            _employer = employer;
            _id = id;
        }


        /*
        public NoteData()
        {
            _title = "\0";
            _description = "\0";
            _status = "\0";
            _employer = "\0";
            _id = 0;
        }

        /*public string GetTtile()
        {
            return _title;
        }

        public void SetTitile(string title)
        {
            _title = title;
        }
        
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
      //   NoteData.Title = "Task";
      // string title = NoteData.Title;


    }*/




















    public class NoteData
    {
        public string Title { get; set; } = "\0";
        public string Description { get; set; } = "\0";
        public string Employer { get; set; } = "\0";
        public string Status { get; set; } = "\0";
        public long ID { get; set; } = 0;
    }
    
}
