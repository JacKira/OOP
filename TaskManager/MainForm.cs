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

namespace TaskManager
{
    public partial class TaskTableForm : Form
    {
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
            //#3 Заполняем доску тестовыми записями
            for (int i = 0; i < 5; i++)
                AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                "Me", "Done");
            for (int i = 0; i < 5; i++)
                AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                "Me", "To Do");
            for (int i = 0; i < 5; i++)
                AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrкrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                "Me", "Doing");


        }

        //#5 Создаем саму запись как объект, добавляем текстовые поля и события для взаимодействия
        private System.Windows.Forms.TableLayoutPanel InitNote(string title = "\0", string description = "\0",
                                                               string employer = "\0", string status = "To Do", long ID = 0)
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

                Text = title,
                Width = 260,
                Size = new System.Drawing.Size(330, 30)
            };
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,
                Multiline = true,

                Text = description,
                WordWrap = true,
                ScrollBars = ScrollBars.Vertical,
                Size = new System.Drawing.Size(330, 250)
            };
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,

                Text = employer,
                Width = 260,
                Size = new System.Drawing.Size(330, 20),
            };
            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            textbox = new System.Windows.Forms.TextBox()
            {
                BackColor = Color.White,
                Text = status,
                Width = 260,
                Size = new System.Drawing.Size(330, 20)
            };

          

            HideCaret(textbox.Handle);
            NewNote.Controls.Add(textbox);

            System.Drawing.Color color;
            switch (status)
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

        private void AddNote(string title = "\0", string description = "\0",
                             string employer = "\0", string status = "To Do")
        {
            int row = last_note_cords[0];
            int col = last_note_cords[1];
            //#4 Добавляем запись, возвращаемую методом InitNote в число элементов доски
            if ((row == 0) && (col == 0))
            {
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(title, description, employer, status));
                return;
            }
            if (col == 2)
            {
                row++;
                col = 0;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(title, description, employer, status));
            }
            else
            {
                col++;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                //TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                TaskTable.Controls.Add(InitNote(title, description, employer, status));
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
            AddNote();
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
            public long ID = 0;
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
            //TaskTable.RowCount = (int)(TaskTable.Height / 330);
            TaskTable.AutoScrollMargin = new Size(10, TaskTable.Height);
            //  TaskTable.AutoScroll = true;
        }

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TaskTable.Controls.Clear();
        }
        /* =========================================== CLASSES ===============================================*/
    }
}
