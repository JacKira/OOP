namespace TaskManager
{
    partial class TaskTableForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskTableForm));
            this.TaskTable = new System.Windows.Forms.TableLayoutPanel();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addNoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.FilterMenu = new System.Windows.Forms.GroupBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.StatusMenu = new System.Windows.Forms.GroupBox();
            this.StatusButton3 = new System.Windows.Forms.RadioButton();
            this.StatusButton2 = new System.Windows.Forms.RadioButton();
            this.StatusButton1 = new System.Windows.Forms.RadioButton();
            this.EmployersLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.FilterMenu.SuspendLayout();
            this.StatusMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskTable
            // 
            this.TaskTable.AutoScroll = true;
            this.TaskTable.AutoScrollMargin = new System.Drawing.Size(10, 300);
            this.TaskTable.AutoScrollMinSize = new System.Drawing.Size(10, 300);
            this.TaskTable.BackColor = System.Drawing.SystemColors.Control;
            this.TaskTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TaskTable.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.TaskTable.ColumnCount = 3;
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.TaskTable.Location = new System.Drawing.Point(289, 63);
            this.TaskTable.Name = "TaskTable";
            this.TaskTable.RowCount = 1;
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.TaskTable.Size = new System.Drawing.Size(1058, 748);
            this.TaskTable.TabIndex = 1;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addNoteToolStripMenuItem,
            this.testToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 48);
            // 
            // addNoteToolStripMenuItem
            // 
            this.addNoteToolStripMenuItem.Name = "addNoteToolStripMenuItem";
            this.addNoteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addNoteToolStripMenuItem.Text = "Add note";
            this.addNoteToolStripMenuItem.Click += new System.EventHandler(this.addNoteToolStripMenuItem_Click);
            // 
            // testToolStripMenuItem
            // 
            this.testToolStripMenuItem.Name = "testToolStripMenuItem";
            this.testToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.testToolStripMenuItem.Text = "Test";
            this.testToolStripMenuItem.Click += new System.EventHandler(this.testToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3,
            this.toolStripButton4});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1357, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 47);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 47);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 47);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 47);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // FilterMenu
            // 
            this.FilterMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterMenu.BackgroundImage = global::TaskManager.Properties.Resources.kaban2;
            this.FilterMenu.Controls.Add(this.SearchLabel);
            this.FilterMenu.Controls.Add(this.SearchTextBox);
            this.FilterMenu.Controls.Add(this.StatusMenu);
            this.FilterMenu.Controls.Add(this.EmployersLabel);
            this.FilterMenu.Controls.Add(this.comboBox1);
            this.FilterMenu.Location = new System.Drawing.Point(12, 63);
            this.FilterMenu.Name = "FilterMenu";
            this.FilterMenu.Size = new System.Drawing.Size(271, 748);
            this.FilterMenu.TabIndex = 0;
            this.FilterMenu.TabStop = false;
            this.FilterMenu.Text = "Фильтры";
            this.FilterMenu.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // SearchLabel
            // 
            this.SearchLabel.AutoSize = true;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SearchLabel.Location = new System.Drawing.Point(6, 36);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(141, 17);
            this.SearchLabel.TabIndex = 7;
            this.SearchLabel.Text = "Поиск по заголовку:";
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Location = new System.Drawing.Point(3, 56);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(262, 20);
            this.SearchTextBox.TabIndex = 6;
            // 
            // StatusMenu
            // 
            this.StatusMenu.Controls.Add(this.StatusButton3);
            this.StatusMenu.Controls.Add(this.StatusButton2);
            this.StatusMenu.Controls.Add(this.StatusButton1);
            this.StatusMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusMenu.Location = new System.Drawing.Point(6, 165);
            this.StatusMenu.Name = "StatusMenu";
            this.StatusMenu.Size = new System.Drawing.Size(259, 100);
            this.StatusMenu.TabIndex = 5;
            this.StatusMenu.TabStop = false;
            this.StatusMenu.Text = "Статус задачи";
            // 
            // StatusButton3
            // 
            this.StatusButton3.AutoSize = true;
            this.StatusButton3.Location = new System.Drawing.Point(11, 73);
            this.StatusButton3.Name = "StatusButton3";
            this.StatusButton3.Size = new System.Drawing.Size(101, 21);
            this.StatusButton3.TabIndex = 2;
            this.StatusButton3.TabStop = true;
            this.StatusButton3.Text = "Выполнено";
            this.StatusButton3.UseVisualStyleBackColor = true;
            // 
            // StatusButton2
            // 
            this.StatusButton2.AutoSize = true;
            this.StatusButton2.Location = new System.Drawing.Point(11, 46);
            this.StatusButton2.Name = "StatusButton2";
            this.StatusButton2.Size = new System.Drawing.Size(86, 21);
            this.StatusButton2.TabIndex = 1;
            this.StatusButton2.TabStop = true;
            this.StatusButton2.Text = "В работе";
            this.StatusButton2.UseVisualStyleBackColor = true;
            // 
            // StatusButton1
            // 
            this.StatusButton1.AutoSize = true;
            this.StatusButton1.Location = new System.Drawing.Point(11, 19);
            this.StatusButton1.Name = "StatusButton1";
            this.StatusButton1.Size = new System.Drawing.Size(125, 21);
            this.StatusButton1.TabIndex = 0;
            this.StatusButton1.TabStop = true;
            this.StatusButton1.Text = "Нужно сделать";
            this.StatusButton1.UseVisualStyleBackColor = true;
            // 
            // EmployersLabel
            // 
            this.EmployersLabel.AutoSize = true;
            this.EmployersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployersLabel.Location = new System.Drawing.Point(6, 94);
            this.EmployersLabel.Name = "EmployersLabel";
            this.EmployersLabel.Size = new System.Drawing.Size(82, 17);
            this.EmployersLabel.TabIndex = 4;
            this.EmployersLabel.Text = "Сотрудник:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 114);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 21);
            this.comboBox1.TabIndex = 3;
            // 
            // TaskTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1357, 856);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.TaskTable);
            this.Controls.Add(this.FilterMenu);
            this.Name = "TaskTableForm";
            this.Text = "Task Table";
            this.TransparencyKey = System.Drawing.SystemColors.Highlight;
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.FilterMenu.ResumeLayout(false);
            this.FilterMenu.PerformLayout();
            this.StatusMenu.ResumeLayout(false);
            this.StatusMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox FilterMenu;
        private System.Windows.Forms.TableLayoutPanel TaskTable;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem addNoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.GroupBox StatusMenu;
        private System.Windows.Forms.Label EmployersLabel;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.RadioButton StatusButton3;
        private System.Windows.Forms.RadioButton StatusButton2;
        private System.Windows.Forms.RadioButton StatusButton1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLabel;
    }
}

