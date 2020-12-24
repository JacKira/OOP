using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.IO;

namespace TaskManager
{
    public partial class TaskTableForm : Form
    {


        private int _w;
        private int _h;
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private int[] last_note_cords = { 0, 0 };
        private string Path = Properties.Settings.Default.PathToDB;
        public TaskTableData tableData = null;
        private List<int> _idsForPrint = new List<int>();

        /// <summary>
        /// Конструктор главной формы
        /// </summary>
        public TaskTableForm()
        {
            InitializeComponent(); //#2 Инициалиизруем меню и доску для записей, но без самих записей.
            //Запоминаем размеры глафно для дальнейшего использования
            _w = this.Width;
            _h = this.Height;
            TaskTable.ContextMenuStrip = contextMenuStrip1; // Добавляем для доски с записями контекстное меню на ПКМ.
            TaskTable.ControlRemoved += new ControlEventHandler(ChangeRowCount);
        }

        /// <summary>
        /// Метод, вызываемый системой при показе главной формы, при вызове метода Show()
        /// Вызываем загрузку свойств системы, свойств привелегий пользователя и загружаем даннык из базы,
        /// если она указана верно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadProperties();
            Updateprivilege();
            if (!File.Exists(Properties.Settings.Default.PathToDB))
            {
                MessageBox.Show("Заданной базы данных не существует");
            }
            else
            {
                InitTable();
            }
        }

        /// <summary>
        /// Загружаем и устанавливаем настройки приложения
        /// </summary>
        private void LoadProperties()
        {
            Properties.Settings.Default.Reload();
            Properties.Settings.Default.Admin = false;
            Properties.Settings.Default.User = false;
            Properties.Settings.Default.UserID = -1;
        }

        /// <summary>
        /// Загрузка задач на доску и вызов обслуживающих методов
        /// </summary>
        private void InitTable()
        {
            tableData = new TaskTableData(Properties.Settings.Default.PathToDB);
            _idsForPrint = tableData.forPrint;
            UpdateEmployers();
            UpdateAllEmployer();
            UpdateTable();
        }

        //#5 Создаем саму запись как объект, добавляем текстовые поля и события для взаимодействия
        /// <summary>
        /// Метод для создания листочка задачи, возвращает созданный листочек 
        /// </summary>
        /// <param name="note"></param>
        /// <returns></returns>
        private System.Windows.Forms.TableLayoutPanel InitNote(NoteData note)
        {
            var NewNote = new Note() { Margin = new Padding(10), ID = note.ID };
            NewNote.BackColor = System.Drawing.SystemColors.Window;
            NewNote.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            NewNote.ColumnCount = 1;
            NewNote.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            NewNote.Location = new System.Drawing.Point(3, 3);
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
                Size = new System.Drawing.Size(330, 30),
                ReadOnly = !Properties.Settings.Default.Admin

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
                Size = new System.Drawing.Size(330, 250),
                ReadOnly = !Properties.Settings.Default.Admin
            };
            textbox.TextChanged += (sender, args) => ChangeDescription(note.ID, (sender as TextBox).Text);
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            var box = new System.Windows.Forms.ComboBox()
            {
                BackColor = Color.White,
                Text = note.Employer.Name,
                Width = 260,
                Size = new System.Drawing.Size(330, 20),
                Enabled = Properties.Settings.Default.Admin
            };
            foreach (var employer in tableData.allEmployers)
            {
                box.Items.Add(employer);
            }
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(box);

            box.TextChanged += (sender, args) => ChangeEmployer(note.ID, (sender as ComboBox).SelectedItem);

            box = new System.Windows.Forms.ComboBox()
            {
                BackColor = Color.White,
                Text = note.Status,
                Width = 260,
                Size = new System.Drawing.Size(330, 20),
                Items = { "To Do", "Doing", "Done" },
                Enabled = (note.Employer.ID == Properties.Settings.Default.UserID) || Properties.Settings.Default.Admin
            };
            box.TextChanged += (sender, args) => ChangeStatus(note.ID, (sender as ComboBox).Text);


            HideCaret(textbox.Handle);
            NewNote.Controls.Add(box);

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
                default:
                    color = System.Drawing.Color.Red;
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
                Text = "* * *",
                TextAlign = HorizontalAlignment.Center,
                TabIndex = 5,
                Cursor = System.Windows.Forms.Cursors.Hand,
                Enabled = Properties.Settings.Default.Admin
            });
            //#7 Здесь добавляем функциональное меню для элемента записи
            NewNote.Controls[4].ContextMenuStrip = new NoteContextMenu(NewNote, tableData, this);
            NewNote.Controls[4].Click += new System.EventHandler(ShowNoteToolStripMenu);
            return NewNote;
        }

        /// <summary>
        /// Метод для добавления листочка на доску
        /// </summary>
        /// <param name="note"></param>
        private void AddNote(NoteData note)
        {
            TaskTable.Controls.Add(InitNote(note));
        }

        /// <summary>
        /// Метод для контроля размером доски с листочками
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ChangeRowCount(object sender, EventArgs e)
        {
            System.Windows.Forms.TableLayoutPanel table = (System.Windows.Forms.TableLayoutPanel)sender;
            table.RowCount = (int)table.Controls.Count / 3;
        }

        /// <summary>
        /// Метод для вызова во время события удаления листочка с доски
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        /// <param name="form"></param>
        private static void removeNoteToolStripMenuItem_Click(object sender, EventArgs args, TaskTableForm form)
        {
            var menu = (MenuItemForDeleteNote)sender;
            form.DeleteNote(menu.Note.ID);
        }

        /// <summary>
        /// Вызов всплывающего меню на доске
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void ShowNoteToolStripMenu(object sender, EventArgs e)
        {
            System.Windows.Forms.TextBox box = (System.Windows.Forms.TextBox)sender;
            box.ContextMenuStrip.Show(Control.MousePosition);

        }

        /// <summary>
        /// Добавление листочка на доску и в базу
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void addNoteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Добавление записки в базу
            tableData.Add();
            _idsForPrint = tableData.forPrint;
            UpdateTable();
            UpdateStatusList();
            UpdateEmployers();


        }
        /* =========================================== CLASSES ===============================================*/
       
        /// <summary>
        /// Меню для взаимодействия с листочком на доске
        /// </summary>
        private class NoteContextMenu : System.Windows.Forms.ContextMenuStrip
        {
            //#8 Инициализируем унаследованный системный компонент с добавлением в него наших элементов меню
            public NoteContextMenu(Note note, TaskTableData tableData, TaskTableForm form)
            {

                this.Items.Add(new MenuItemForDeleteNote(note, tableData, form));
                this.Items[0].Text = "Remove Note";
                this.Size = new System.Drawing.Size(180, 22);
            }
        }

        /// <summary>
        /// Элемент меню для удаления листочка с доски
        /// </summary>
        private class MenuItemForDeleteNote : ToolStripMenuItem
        {
            //#9 Инициализируем наш элемент меню, унаследованный системный компонент
            public MenuItemForDeleteNote(Note note, TaskTableData tableData, TaskTableForm form)
            {
                //Добавляем в него событие удаления записи
                this.Click += (sender, args) =>
                {
                    removeNoteToolStripMenuItem_Click(sender, args, form);
                    form.UpdateTable();
                    tableData.UpdateEmployers();
                    tableData.UpdateStatusList();
                };
                //Сохраняем саму запись для удаления
                Note = note;
            }
            public Note Note;
        }

        /// <summary>
        /// Метод для удаления листочка с доски по ID
        /// </summary>
        /// <param name="id">id листочка</param>
        private void DeleteNote(int id)
        {
            tableData.DeleteNote(id);
            _idsForPrint = tableData.forPrint;
        }
  
        /// <summary>
        /// Модификация стандартного элемента для хранения ID записи
        /// </summary>
        private class Note : TableLayoutPanel
        {
            public int ID = 0;
        }

        /// <summary>
        /// Метод для контроля расположения компонентов на форме при изменении ее размеров
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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


        /// <summary>
        /// Метод события при нажании на вывод задач со статусом "Нужно сделать"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusButton1_CheckedChanged(object sender, EventArgs e)
        {
            EmployersBox.Text = "";
            _idsForPrint = tableData.TasksByStatus("To Do");
            UpdateTable();
        }

        /// <summary>
        /// Метод события при нажании на вывод задач со статусом "В работе"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusButton2_CheckedChanged(object sender, EventArgs e)
        {
            EmployersBox.Text = "";
            SearchTextBox.Text = "";
            _idsForPrint = tableData.TasksByStatus("Doing");
            UpdateTable();
        }

        /// <summary>
        /// Метод события при нажании на вывод задач со статусом "Сделано"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void StatusButton3_CheckedChanged(object sender, EventArgs e)
        {
            EmployersBox.Text = "";
            SearchTextBox.Text = "";
            StatusButton1.Checked = false;
            StatusButton2.Checked = false;
            _idsForPrint = tableData.TasksByStatus("Done");
            UpdateTable();
        }

        /// <summary>
        /// Обновление отображаемых задач на форме
        /// </summary>
        public void UpdateTable()
        {
            TaskTable.Controls.Clear();
            foreach (var id in _idsForPrint)
            {
                AddNote(tableData[id]);
            }
        }

        /// <summary>
        /// Метод, вызываемый при выборе работника, для которого нужно отобразить задачи
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EmployersBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            StatusButton1.Checked = false;
            StatusButton2.Checked = false;
            StatusButton3.Checked = false;
            SearchTextBox.Text = "";
            _idsForPrint = tableData.GetTasksIdByEmployerId((EmployersBox.SelectedItem as Employer).ID, 1);
            UpdateTable();
        }

        /// <summary>
        /// Метод для очистки установок фильтра 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ClearFilterButton_Click(object sender, EventArgs e)
        {
            StatusButton1.Checked = false;
            StatusButton2.Checked = false;
            StatusButton3.Checked = false;
            EmployersBox.Text = "";
            SearchTextBox.Text = "";
            _idsForPrint = tableData.GetAllIds();
            UpdateTable();
        }


        /// <summary>
        /// Метод вызываемый при использовании окна поиска
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            if((SearchTextBox.Text != string.Empty) && (!SearchTextBox.Text.StartsWith(" ")))
            {
                StatusButton1.Checked = false;
                StatusButton2.Checked = false;
                StatusButton3.Checked = false;
                EmployersBox.Text = "";
                _idsForPrint = tableData.GetTasksIdByTitle(SearchTextBox.Text, 1);
                UpdateTable();
            }
         
        }

        /// <summary>
        /// Метод, вызываемый при изменении заголовка задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        private void ChangeTitle(int id, string newStr)
        {
            tableData[id].Title = newStr;
            tableData.UpdateNote(id);
        }

        /// <summary>
        /// Метод, вызываемый при изменении описания задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        private void ChangeDescription(int id, string newStr)
        {
            tableData[id].Description = newStr;
            tableData.UpdateNote(id);
        }

        /// <summary>
        /// Метод, вызываемый при изменении работника, за которым закреплена задача
        /// </summary>
        /// <param name="id"></param>
        /// <param name="new_employer"></param>
        private void ChangeEmployer(int id, object new_employer)
        {
            tableData[id].Employer = new_employer as Employer;
            tableData.UpdateNote(id);
            UpdateEmployers();
            UpdateTable();
        }

        /// <summary>
        /// Метод, вызываемый при изменении статуса задачи
        /// </summary>
        /// <param name="id"></param>
        /// <param name="newStr"></param>
        private void ChangeStatus(int id, string newStr)
        {
            tableData[id].Status = newStr;
            tableData.UpdateNote(id);
            UpdateStatusList();
            UpdateTable();
        }

        /// <summary>
        /// Метод для обновления списка работников для фильтра
        /// </summary>
        public void UpdateEmployers()
        {
            tableData.UpdateEmployers();
            EmployersBox.Items.Clear();
            foreach (var employer in tableData.employers)
            {
                EmployersBox.Items.Add(employer);
            }
        }

        /// <summary>
        /// Обновление списка всех работников
        /// </summary>
        public void UpdateAllEmployer()
        {
            tableData.UpdateAllEmployers();
        }


        /// <summary>
        /// Обновление списков задач по статусу
        /// </summary>
        private void UpdateStatusList()
        {
            tableData.UpdateStatusList();
        }

        /// <summary>
        /// Обновление отображаемых задач на доске
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReloadTableButton_Click(object sender, EventArgs e)
        {
            UpdateTable();
        }

        /// <summary>
        /// Смена действующей базы данных и ее загрузка, если та существует 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            openDbDialog.InitialDirectory = "c:\\";
            openDbDialog.Filter = " access mdb files (*.mdb) | *.mdb";
            openDbDialog.RestoreDirectory = true;

            if (openDbDialog.ShowDialog() == DialogResult.OK)
            {

                //Get the path of specified file
                Properties.Settings.Default.PathToDB = openDbDialog.FileName;
                if (!File.Exists(Properties.Settings.Default.PathToDB))
                {
                    MessageBox.Show("Заданной базы данных не существует");
                    return;
                }
                if(tableData != null)
                {
                    tableData.Dispose();
                    tableData = null;
                }
                tableData = new TaskTableData(Properties.Settings.Default.PathToDB);
                SetDefaultPrivilege();
                Updateprivilege();
                InitTable();
            }
        }

        /// <summary>
        /// Происходит при закрытии формы. Сохраняет настройки приложения и очищает память
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TaskTableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(tableData != null)
            {
                tableData.Dispose();
                tableData = null;
            }
            SetDefaultPrivilege();
            Updateprivilege();
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Вызов окна для авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthtoolStripButton_Click(object sender, EventArgs e)
        {
            var authform = new UserForm(this);
            authform.Show();
        }

        /// <summary>
        /// Вызов окна добавления пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUsertoolStripButton_Click(object sender, EventArgs e)
        {
            var authform = new UserForm(this, true);
            authform.Show();

        }

        /// <summary>
        /// Вызов окна для редактирования профиля пользователя
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUsertoolStripButton_Click(object sender, EventArgs e)
        {
            var authform = new UserForm(this, false, true);
            authform.Show();
        }

        /// <summary>
        /// Обновление действующих привелегий пользователя
        /// </summary>
        public void Updateprivilege()
        {
            AddUsertoolStripButton.Enabled = Properties.Settings.Default.Admin;
            EditUsertoolStripButton.Enabled = Properties.Settings.Default.Admin;
            LogOuttoolStripButton.Enabled = Properties.Settings.Default.Admin || Properties.Settings.Default.User;
            addNoteToolStripMenuItem.Enabled = Properties.Settings.Default.Admin;
            ProfileStatusLabel.Text = "Авторизованный пользователь:\n" + Properties.Settings.Default.UserLogin;
        }

        /// <summary>
        /// Выход из авторизованного профиля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            SetDefaultPrivilege();
            Updateprivilege();
            UpdateTable();
        }

        /// <summary>
        /// Установление возможностей пользователя по умолчанию
        /// </summary>
        private static void SetDefaultPrivilege()
        {
            Properties.Settings.Default.Admin = false;
            Properties.Settings.Default.User = false;
            Properties.Settings.Default.UserID = -1;
            Properties.Settings.Default.UserLogin = "Гость";
        }

        /// <summary>
        /// Вызов диалогового окна для сохранения / копирования действующей базы данных
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveDBtoolStripButton_Click(object sender, EventArgs e)
        {
            saveDbDialog.InitialDirectory = "c:\\";
            saveDbDialog.Filter = " access mdb files (*.mdb) | *.mdb";
            saveDbDialog.RestoreDirectory = true;

            if (saveDbDialog.ShowDialog() == DialogResult.OK)
            {
                File.Copy(Properties.Settings.Default.PathToDB, saveDbDialog.FileName, true);
            }
        }
        /* =========================================== CLASSES ===============================================*/
    }
}
