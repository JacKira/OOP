using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TaskManager
{

    public partial class MainForm : Form
    {
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
            TaskTable.Controls.Add(InitNote(), 1, 0);
            TaskTable.Controls.Add(InitNote(), 2, 0);

            TaskTable.Controls.Add(InitNote(), 1, 1);
            TaskTable.Controls.Add(InitNote(), 2, 1);
            TaskTable.Controls.Add(InitNote(), 0, 1);
            

        }

        private System.Windows.Forms.TableLayoutPanel InitNote()
        {
            var NewNote = new System.Windows.Forms.TableLayoutPanel();
            NewNote.BackColor = System.Drawing.SystemColors.Window;
            NewNote.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            NewNote.ColumnCount = 1;
            NewNote.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            NewNote.Location = new System.Drawing.Point(3, 3);
            NewNote.Name = "tableLayoutPanel2";
            NewNote.RowCount = 4;
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            NewNote.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            NewNote.Size = new System.Drawing.Size(330, 260);
            NewNote.TabIndex = 0;
            return NewNote;
        }

        private void AddNote()
        {
                    
        }
    }
}
