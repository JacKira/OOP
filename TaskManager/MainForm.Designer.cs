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
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.StatusMenu = new System.Windows.Forms.GroupBox();
            this.StatusButton3 = new System.Windows.Forms.RadioButton();
            this.StatusButton2 = new System.Windows.Forms.RadioButton();
            this.StatusButton1 = new System.Windows.Forms.RadioButton();
            this.EmployersLabel = new System.Windows.Forms.Label();
            this.EmployersBox = new System.Windows.Forms.ComboBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.ReloadTableButton = new System.Windows.Forms.Button();
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
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
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
            this.toolStripButton1.Size = new System.Drawing.Size(24, 47);
            this.toolStripButton1.Text = "toolStripButton1";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(24, 47);
            this.toolStripButton2.Text = "toolStripButton2";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(24, 47);
            this.toolStripButton3.Text = "toolStripButton3";
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(24, 47);
            this.toolStripButton4.Text = "toolStripButton4";
            // 
            // FilterMenu
            // 
            this.FilterMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterMenu.BackgroundImage = global::TaskManager.Properties.Resources.kaban2;
            this.FilterMenu.Controls.Add(this.ReloadTableButton);
            this.FilterMenu.Controls.Add(this.ClearFilterButton);
            this.FilterMenu.Controls.Add(this.button5);
            this.FilterMenu.Controls.Add(this.button4);
            this.FilterMenu.Controls.Add(this.button3);
            this.FilterMenu.Controls.Add(this.button2);
            this.FilterMenu.Controls.Add(this.button1);
            this.FilterMenu.Controls.Add(this.textBox2);
            this.FilterMenu.Controls.Add(this.listBox1);
            this.FilterMenu.Controls.Add(this.SearchLabel);
            this.FilterMenu.Controls.Add(this.SearchTextBox);
            this.FilterMenu.Controls.Add(this.StatusMenu);
            this.FilterMenu.Controls.Add(this.EmployersLabel);
            this.FilterMenu.Controls.Add(this.EmployersBox);
            this.FilterMenu.Location = new System.Drawing.Point(12, 63);
            this.FilterMenu.Name = "FilterMenu";
            this.FilterMenu.Size = new System.Drawing.Size(271, 748);
            this.FilterMenu.TabIndex = 0;
            this.FilterMenu.TabStop = false;
            this.FilterMenu.Text = "Фильтры";
            this.FilterMenu.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(80, 485);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(116, 41);
            this.button5.TabIndex = 13;
            this.button5.Text = "Удалить данные";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(150, 439);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(106, 41);
            this.button4.TabIndex = 12;
            this.button4.Text = "Обновить данные";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(4, 439);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(135, 41);
            this.button3.TabIndex = 11;
            this.button3.Text = "добавить в бд";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(144, 360);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(112, 48);
            this.button2.TabIndex = 10;
            this.button2.Text = "Вывести в listbox";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(9, 360);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(124, 48);
            this.button1.TabIndex = 9;
            this.button1.Text = "Вывести в textbox";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(23, 536);
            this.textBox2.Margin = new System.Windows.Forms.Padding(2);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(225, 20);
            this.textBox2.TabIndex = 8;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(23, 567);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(225, 173);
            this.listBox1.TabIndex = 0;
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
            this.SearchTextBox.Size = new System.Drawing.Size(233, 20);
            this.SearchTextBox.TabIndex = 6;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // StatusMenu
            // 
            this.StatusMenu.Controls.Add(this.StatusButton3);
            this.StatusMenu.Controls.Add(this.StatusButton2);
            this.StatusMenu.Controls.Add(this.StatusButton1);
            this.StatusMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.StatusMenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StatusMenu.Location = new System.Drawing.Point(3, 158);
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
            this.StatusButton3.CheckedChanged += new System.EventHandler(this.StatusButton3_CheckedChanged);
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
            this.StatusButton2.CheckedChanged += new System.EventHandler(this.StatusButton2_CheckedChanged);
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
            this.StatusButton1.CheckedChanged += new System.EventHandler(this.StatusButton1_CheckedChanged);
            // 
            // EmployersLabel
            // 
            this.EmployersLabel.AutoSize = true;
            this.EmployersLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.EmployersLabel.Location = new System.Drawing.Point(3, 99);
            this.EmployersLabel.Name = "EmployersLabel";
            this.EmployersLabel.Size = new System.Drawing.Size(82, 17);
            this.EmployersLabel.TabIndex = 4;
            this.EmployersLabel.Text = "Сотрудник:";
            // 
            // EmployersBox
            // 
            this.EmployersBox.FormattingEnabled = true;
            this.EmployersBox.Location = new System.Drawing.Point(3, 119);
            this.EmployersBox.Name = "EmployersBox";
            this.EmployersBox.Size = new System.Drawing.Size(259, 21);
            this.EmployersBox.TabIndex = 3;
            this.EmployersBox.SelectedIndexChanged += new System.EventHandler(this.EmployersBox_SelectedIndexChanged);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(121, 0);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(146, 40);
            this.button6.TabIndex = 3;
            this.button6.Text = "Получить список работников в listbox";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(272, 0);
            this.button7.Margin = new System.Windows.Forms.Padding(2);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(146, 40);
            this.button7.TabIndex = 4;
            this.button7.Text = "Получить ID задач в listbox";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(422, 0);
            this.button8.Margin = new System.Windows.Forms.Padding(2);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(146, 40);
            this.button8.TabIndex = 5;
            this.button8.Text = "Получить ID задач по статусу \"Doing\"";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(573, 0);
            this.button9.Margin = new System.Windows.Forms.Padding(2);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(146, 40);
            this.button9.TabIndex = 6;
            this.button9.Text = "Получить ID задач по работнику \"Андреев\"";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Location = new System.Drawing.Point(20, 264);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(225, 23);
            this.ClearFilterButton.TabIndex = 14;
            this.ClearFilterButton.Text = "Очистить фильтр";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
            // 
            // ReloadTableButton
            // 
            this.ReloadTableButton.Location = new System.Drawing.Point(20, 311);
            this.ReloadTableButton.Name = "ReloadTableButton";
            this.ReloadTableButton.Size = new System.Drawing.Size(225, 23);
            this.ReloadTableButton.TabIndex = 7;
            this.ReloadTableButton.Text = "Обновить доску";
            this.ReloadTableButton.UseVisualStyleBackColor = true;
            this.ReloadTableButton.Click += new System.EventHandler(this.ReloadTableButton_Click);
            // 
            // TaskTableForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(1357, 856);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
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
        private System.Windows.Forms.ComboBox EmployersBox;
        private System.Windows.Forms.RadioButton StatusButton3;
        private System.Windows.Forms.RadioButton StatusButton2;
        private System.Windows.Forms.RadioButton StatusButton1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Button button9;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.Button ReloadTableButton;
    }
}

