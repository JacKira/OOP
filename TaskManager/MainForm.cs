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

namespace TaskManager
{


    public partial class MainForm : Form
    {
        [DllImport("user32.dll")]
        static extern bool HideCaret(IntPtr hWnd);
        private int[] last_note_cords = { 0, 0 };
        public MainForm()
        {
            InitializeComponent();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Task_Paint(object sender, PaintEventArgs e)
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.Controls[0].Text = "Test task";
            for (int i = 0; i < 10; i++)
                AddNote("Test task", "Need execute some task forrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr",
                "Me", "Active");

        }

        private System.Windows.Forms.TableLayoutPanel InitNote(string title = "\0", string description = "\0",
                                                               string employer = "\0", string status = "\0")
        {


            var NewNote = new System.Windows.Forms.TableLayoutPanel() { Margin = new Padding(5) };
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

            NewNote.Controls.Add(new System.Windows.Forms.TextBox()
            {
                BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
                Dock = System.Windows.Forms.DockStyle.Fill,
                Location = new System.Drawing.Point(4, 286),
                Multiline = true,
                ReadOnly = true,
                Size = new System.Drawing.Size(322, 30),
                Text = "CLICK ME",
                TextAlign = HorizontalAlignment.Center,
                TabIndex = 5
            });
            NewNote.Controls[4].ContextMenuStrip = new NoteContextMenu();
            return NewNote;
        }

        private void AddNote(string title = "\0", string description = "\0",
                             string employer = "\0", string status = "\0")
        {
            int row = last_note_cords[0];
            int col = last_note_cords[1];
            /*    if ((row == 0) && (col == 0))
                {
                    TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
                    return;
                } */
            if (col == 2)
            {
                row++;
                col = 0;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
            }
            else
            {
                col++;
                last_note_cords[0] = row;
                last_note_cords[1] = col;
                TaskTable.Controls.Add(InitNote(title, description, employer, status), col, row);
            }

        }

        private class NoteContextMenu : System.Windows.Forms.ContextMenuStrip
        {
            public NoteContextMenu()
            {
                this.Items.Add(new ToolStripMenuItem("Удалить"));
            }
        }

        private void RemoveNote(System.Windows.Forms.TableLayoutPanel note)
        {
            note.Dispose();
        }

      
    }
}
