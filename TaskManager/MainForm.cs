using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.Collections;
using System.Data.OleDb;

namespace TaskManager
{
    public partial class TaskTableForm : Form
    {
        //=========================== Sanya ===============================//
        private Dictionary<int,NoteData> _notes = new Dictionary<int, NoteData>();
        private List<int> _ids = new List<int>();
        private List<int> _forPrint = new List<int>();
        private List<Employer> _employers = new List<Employer>();
        private Dictionary<string, List<int>> _tasksByStatus = new Dictionary<string, List<int>>();


        //=================================================================//
        private TaskDB DB = new TaskDB(@"D:\Repos\OOP\Database3_copy.mdb");
        //=================================================================//


        private int _w;
        private int _h;
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private int[] last_note_cords = { 0, 0 };
        public TaskTableForm()
        {
            InitializeComponent(); //#2 Инициалиизруем меню и доску для записей, но без самих записей.
            //Запоминаем размеры глафно для дальнейшего использования
            _w = this.Width;
            _h = this.Height;
            TaskTable.ContextMenuStrip = contextMenuStrip1; // Добавляем для доски с записями контекстное меню на ПКМ.
            TaskTable.ControlRemoved += new ControlEventHandler(ChangeRowCount);
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Task_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            /* //#3 Заполняем доску тестовыми записями
            /* for (int i = 0; i < 5; i++)
                 AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                 "Me", "Done");
             for (int i = 0; i < 5; i++)
                 AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                 "Me", "To Do");
             for (int i = 0; i < 5; i++)
                 AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                 "Me", "Doing");*/
            /*var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            var note = DB.GetNoteData(4);
            AddNote(note.Title, note.Description, note.Employer, note.Status);
            note.Title = "Заголовок после update";
            note.Description = "Описание после update";
            note.Employer = "Андреев";
            note.Status = "Done";
            DB.UpdateNote(note);
            AddNote(note.Title, note.Description, note.Employer, note.Status);
            note.Title = "База данных";
            note.Description = "Создать базу данных.";
            note.Status = "Doing";
            DB.UpdateNote(note);
            DB.DeleteNoteData(12); */
            // DB.LogIn("Вася", "Vasya", "12345"); логиним Васю
            //DB.AddAdmin(3);

           

            //Получаем все задачи проекта
            _ids = DB.GetTasksId(1);
            foreach(var id in _ids)
            {
                var note = DB.GetNoteData(id);
                _notes.Add(note.ID, note);
            }

            //Получаем id по статусу
            var stat1 = DB.GetTasksIdByStatus("To Do", 1);
            var stat2= DB.GetTasksIdByStatus("Doing", 1);
            var stat3 = DB.GetTasksIdByStatus("Done", 1);
            _tasksByStatus.Add("To Do", stat1);
            _tasksByStatus.Add("Doing", stat2);
            _tasksByStatus.Add("Done", stat3);

            //Получим работников
            _employers = DB.GetEmployers(1);
            foreach(var employer in _employers)
            {
                EmployersBox.Items.Add(employer);
            }

            //Заполняем доску задачами
            _forPrint = _ids;
            UpdateTable();

        }

        //#5 Создаем саму запись как объект, добавляем текстовые поля и события для взаимодействия
        private System.Windows.Forms.TableLayoutPanel InitNote(NoteData note)
        {
            var NewNote = new Note() { Margin = new Padding(10) };
            NewNote.BackColor = System.Drawing.SystemColors.Window;
            NewNote.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            NewNote.ColumnCount = 1;
            NewNote.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            NewNote.Location = new System.Drawing.Point(3, 3);
            NewNote.Name = "tableLayoutPanel" + (last_note_cords.Sum() + 1).ToString();
            NewNote.RowCount = 5;
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 33F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            NewNote.Size = new System.Drawing.Size(330, 320);
            NewNote.TabIndex = 0;
            //#6 Здесь заполняются текстовые поля предоставленными данными и добавляются на Запись
            var textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,
                Multiline = true,
                Text = note.Title,
                Width = 260,
                Size = new System.Drawing.Size(330, 30)
               
            };
            textbox.TextChanged += (sender, args) => ChangeTitle(note.ID, (sender as TextBox).Text);
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,
                Multiline = true,

                Text = note.Description,
                WordWrap = true,
                ScrollBars = ScrollBars.Vertical,
                Size = new System.Drawing.Size(330, 250)
            };
            textbox.TextChanged += (sender, args) => ChangeDescription(note.ID, (sender as TextBox).Text);
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,

                Text = note.Employer.Name,
                Width = 260,
                Size = new System.Drawing.Size(330, 20),
            };
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,
                Text = note.Status,
                Width = 260,
                Size = new System.Drawing.Size(330, 20)
            };
            textbox.TextChanged += (sender, args) => ChangeStatus(note.ID, (sender as TextBox).Text);


            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            System.Drawing.Color color;
            switch (note.Status)
            {
                case "Doing":
                    color = System.Drawing.Color.Orange;
                    break;
                case "To Do":
                    color = System.Drawing.Color.Silver;
                    break;
                case "Done":
                    color = System.Drawing.Color.ForestGreen;
                    break;
                default: color = System.Drawing.Color.Red;
                    break;
            }

            NewNote.Controls.Add(new System.Windows.Forms.TextBox()
            {
                BackColor = color,
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(4, 286),
                Multiline = true,
                ReadOnly = true,
                Size = new System.Drawing.Size(330, 30),
                Text = "---",
                TextAlign = HorizontalAlignment.Center,
                TabIndex = 5,
                Cursor = System.Windows.Forms.Cursors.Hand
            });
            //#7 Здесь добавляем функциональное меню для элемента записи
            NewNote.Controls[4].ContextMenuStrip = new NoteContextMenu(NewNote);
            NewNote.Controls[4].Click += new System.EventHandler(ShowNoteToolStripMenu);

            return NewNote;
        }

        private void AddNote(NoteData note)
        {
            int row = last_note_cords[0];
            int col = last_note_cords[1];
            //#4 Добавляем запись, возвращаемую методом InitNote в число элементов доски
            if ((row == 0) && (col == 0))
            {
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(note));
                return;
            }
            if (col == 2)
            {
                row++;
                col = 0;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(note));
            }
            else
            {
                col++;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(note));
            }
        }

        private static void ChangeRowCount(object sender, EventArgs e)
        {
            System.Windows.Forms.TableLayoutPanel table = (System.Windows.Forms.TableLayoutPanel)sender;
            table.RowCount = (int)table.Controls.Count / 3;
        }


        public static void removeNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var menu = (MenuItem)sender;
            menu.Note.Dispose();
        }

        private static void ShowNoteToolStripMenu(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;
            box.ContextMenuStrip.Show(Control.MousePosition);

        }
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var note = new NoteData();
            //Добавление записки в базу
            AddNote(note);
        }
        /* =========================================== CLASSES ===============================================*/
        private class NoteContextMenu : System.Windows.Forms.ContextMenuStrip
        {
            //#8 Инициализируем унаследованный системный компонент с добавлением в него наших элементов меню
            public NoteContextMenu(System.Windows.Forms.TableLayoutPanel note)
            {

                this.Items.Add(new MenuItem(note));
                this.Items[0].Text = "Remove Note";
                this.Items.Add(new ToolStripMenuItem("NOT Remove Note"));
                this.Size = new System.Drawing.Size(180, 22);
            }
        }

        private class MenuItem : ToolStripMenuItem
        {
            //#9 Инициализируем наш элемент меню, унаследованный системный компонент
            public MenuItem(System.Windows.Forms.TableLayoutPanel note)
            {
                //Добавляем в него событие удаления записи
                this.Click += new System.EventHandler(removeNoteToolStripMenuItem_Click);
                //Сохраняем саму запись для удаления
                Note = note;
            }
            public System.Windows.Forms.TableLayoutPanel Note;
        }

        private class Note : TableLayoutPanel
        {
            public int ID = 0;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            int d_w = this.Width - _w;
            int d_h = this.Height - _h;
            _w = this.Width;
            _h = this.Height;
            TaskTable.Width += d_w;
            TaskTable.ColumnCount = (int)(TaskTable.Width / 350);
            TaskTable.Height += d_h;
            TaskTable.RowCount = (int)(TaskTable.Height / 330);
            TaskTable.AutoScrollMargin = new Size(10, TaskTable.Height);
            //  TaskTable.AutoScroll = true;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTable.Controls.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            // текст запроса
            int ID = 8;
            string query = string.Format("SELECT Описание FROM Записи WHERE Код = {0}", ID);
            var dbconnect = DB.GetDbConnection();
            dbconnect.Open();
            OleDbCommand command = new OleDbCommand(query, dbconnect);
            textBox2.Text = command.ExecuteScalar().ToString();
            dbconnect.Close();
            //DB.CloseDbConnection();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            int ID = 8;
            string query = string.Format("SELECT Заголовок, Статус, Описание FROM Записи WHERE Код = {0}", ID);
            var dbconnect = DB.GetDbConnection();
            dbconnect.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, dbconnect);
            // получаем объект OleDbDataReader для чтения табличного результата запроса SELECT
            OleDbDataReader reader = command.ExecuteReader();
            // очищаем listBox1
            listBox1.Items.Clear();
            // в цикле построчно читаем ответ от БД
            while (reader.Read())
            {
                // выводим данные столбцов текущей строки в listBox1
                listBox1.Items.Add(reader[0].ToString() + " " + reader[1].ToString() + " " + reader[2].ToString() + " ");
            }
            // закрываем OleDbDataReader
            reader.Close();
            dbconnect.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            string query = string.Format("INSERT INTO Записи (Код, Заголовок, Статус, Описание)" +
                                         "VALUES (8, 'Отчеты', 'Done', 'Сделать отчеты')");
            var dbconnect = DB.GetDbConnection();
            dbconnect.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, dbconnect);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            dbconnect.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int ID = 8;
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            string query = string.Format("UPDATE Записи " +
                                         "SET Заголовок = 'AAAAAAAAAAAAAAAAAA'" +
                                         "WHERE Код = {0}", ID);
            var dbconnect = DB.GetDbConnection();
            dbconnect.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, dbconnect);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            dbconnect.Close();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int ID = 8;
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            string query = string.Format("DELETE FROM Записи WHERE Код = {0}", ID);
            var dbconnect = DB.GetDbConnection();
            dbconnect.Open();
            // создаем объект OleDbCommand для выполнения запроса к БД MS Access
            OleDbCommand command = new OleDbCommand(query, dbconnect);
            // выполняем запрос к MS Access
            command.ExecuteNonQuery();
            dbconnect.Close();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            var listEmployers = DB.GetEmployers(1);
            for (int i = 0; i < listEmployers.Count(); i++)
            {
                listBox1.Items.Add(listEmployers[i].Name);
            }
            listBox1.Items.Add(listEmployers.Count());
        }

        private void button7_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            var listId = DB.GetTasksId(1);
            for (int i = 0; i < listId.Count(); i++)
            {
                listBox1.Items.Add(listId[i]);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            var listId = DB.GetTasksIdByStatus("Doing", 1);
            for (int i = 0; i < listId.Count(); i++)
            {
                listBox1.Items.Add(listId[i]);
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            var DB = new TaskDB(@"D:\Repos\OOP\Database3.mdb");
            var listId = DB.GetTasksIdByEmployer("Андреев", 1);
            for (int i = 0; i < listId.Count(); i++)
            {
                listBox1.Items.Add(listId[i]);
            }
        }

        private void StatusButton1_CheckedChanged(object sender, EventArgs e)
        {
            _forPrint = _tasksByStatus["To Do"];
            UpdateTable();
        }

        private void StatusButton2_CheckedChanged(object sender, EventArgs e)
        {
            _forPrint = _tasksByStatus["Doing"];
            UpdateTable();
        }

        private void StatusButton3_CheckedChanged(object sender, EventArgs e)
        {
            _forPrint = _tasksByStatus["Done"];
            UpdateTable();
        }

        private void UpdateTable()
        {
            TaskTable.Controls.Clear();
            foreach(var id in _forPrint)
            {
                AddNote(_notes[id]);
            }
        }

        private void EmployersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            _forPrint = DB.GetTasksIdByEmployer(EmployersBox.SelectedItem.ToString(), 1);
            UpdateTable();
        }

        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            StatusButton1.Checked = false;
            StatusButton2.Checked = false;
            StatusButton3.Checked = false;

            _forPrint = _ids;
            UpdateTable();
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            _forPrint = DB.GetTasksIdByTitle(SearchTextBox.Text, 1);
            UpdateTable();
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            _forPrint = DB.GetTasksIdByTitle(SearchTextBox.Text, 1);
            UpdateTable();
        }

        private void ChangeTitle(int id, string newStr)
        {
            _notes[id].Title = newStr;
            DB.UpdateNote(_notes[id]);
        }
        
        private void ChangeDescription(int id, string newStr)
        {
            _notes[id].Description = newStr;
            DB.UpdateNote(_notes[id]);
        }private void ChangeStatus(int id, string newStr)
        {
            _notes[id].Status = newStr;
            DB.UpdateNote(_notes[id]);
            
            var stat1 = DB.GetTasksIdByStatus("To Do", 1);
            var stat2 = DB.GetTasksIdByStatus("Doing", 1);
            var stat3 = DB.GetTasksIdByStatus("Done", 1);
            _tasksByStatus.Clear();
            _tasksByStatus.Add("To Do", stat1);
            _tasksByStatus.Add("Doing", stat2);
            _tasksByStatus.Add("Done", stat3);
        
        }

        private void ReloadTableButton_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /* =========================================== CLASSES ===============================================*/
    }
}
