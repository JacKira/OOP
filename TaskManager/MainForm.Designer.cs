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
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.LoadBasetoolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.AuthtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.AddUsertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openDBDialog = new System.Windows.Forms.OpenFileDialog();
            this.SaveDBtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.FilterMenu = new System.Windows.Forms.GroupBox();
            this.ReloadTableButton = new System.Windows.Forms.Button();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.StatusMenu = new System.Windows.Forms.GroupBox();
            this.StatusButton3 = new System.Windows.Forms.RadioButton();
            this.StatusButton2 = new System.Windows.Forms.RadioButton();
            this.StatusButton1 = new System.Windows.Forms.RadioButton();
            this.EmployersLabel = new System.Windows.Forms.Label();
            this.EmployersBox = new System.Windows.Forms.ComboBox();
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
            this.addNoteToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(124, 26);
            // 
            // addNoteToolStripMenuItem
            // 
            this.addNoteToolStripMenuItem.Name = "addNoteToolStripMenuItem";
            this.addNoteToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.addNoteToolStripMenuItem.Text = "Add note";
            this.addNoteToolStripMenuItem.Click += new System.EventHandler(this.addNoteToolStripMenuItem_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SaveDBtoolStripButton,
            this.LoadBasetoolStripButton2,
            this.AuthtoolStripButton,
            this.AddUsertoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1357, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // LoadBasetoolStripButton2
            // 
            this.LoadBasetoolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadBasetoolStripButton2.Image = global::TaskManager.Properties.Resources.load;
            this.LoadBasetoolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadBasetoolStripButton2.Name = "LoadBasetoolStripButton2";
            this.LoadBasetoolStripButton2.Size = new System.Drawing.Size(24, 47);
            this.LoadBasetoolStripButton2.Text = "Загрузить базу данных";
            this.LoadBasetoolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // AuthtoolStripButton
            // 
            this.AuthtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AuthtoolStripButton.Image = global::TaskManager.Properties.Resources.authorization_LOGIN;
            this.AuthtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AuthtoolStripButton.Name = "AuthtoolStripButton";
            this.AuthtoolStripButton.Size = new System.Drawing.Size(24, 47);
            this.AuthtoolStripButton.Text = "Авторизоваться";
            // 
            // AddUsertoolStripButton
            // 
            this.AddUsertoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddUsertoolStripButton.Image = global::TaskManager.Properties.Resources.authorization;
            this.AddUsertoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddUsertoolStripButton.Name = "AddUsertoolStripButton";
            this.AddUsertoolStripButton.Size = new System.Drawing.Size(24, 47);
            this.AddUsertoolStripButton.Text = "Добавить работника";
            // 
            // SaveDBtoolStripButton
            // 
            this.SaveDBtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveDBtoolStripButton.Image = global::TaskManager.Properties.Resources.save_save1;
            this.SaveDBtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveDBtoolStripButton.Name = "SaveDBtoolStripButton";
            this.SaveDBtoolStripButton.Size = new System.Drawing.Size(24, 47);
            this.SaveDBtoolStripButton.Text = "Сохранить  или создать базу данных";
            // 
            // FilterMenu
            // 
            this.FilterMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FilterMenu.BackgroundImage")));
            this.FilterMenu.Controls.Add(this.ReloadTableButton);
            this.FilterMenu.Controls.Add(this.ClearFilterButton);
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
            // ReloadTableButton
            // 
            this.ReloadTableButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ReloadTableButton.Location = new System.Drawing.Point(14, 664);
            this.ReloadTableButton.Name = "ReloadTableButton";
            this.ReloadTableButton.Size = new System.Drawing.Size(248, 59);
            this.ReloadTableButton.TabIndex = 7;
            this.ReloadTableButton.Text = "Обновить доску";
            this.ReloadTableButton.UseVisualStyleBackColor = true;
            this.ReloadTableButton.Click += new System.EventHandler(this.ReloadTableButton_Click);
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearFilterButton.Location = new System.Drawing.Point(14, 588);
            this.ClearFilterButton.Name = "ClearFilterButton";
            this.ClearFilterButton.Size = new System.Drawing.Size(248, 56);
            this.ClearFilterButton.TabIndex = 14;
            this.ClearFilterButton.Text = "Очистить фильтр";
            this.ClearFilterButton.UseVisualStyleBackColor = true;
            this.ClearFilterButton.Click += new System.EventHandler(this.ClearFilterButton_Click);
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskTableForm_FormClosing);
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
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton SaveDBtoolStripButton;
        private System.Windows.Forms.ToolStripButton LoadBasetoolStripButton2;
        private System.Windows.Forms.ToolStripButton AuthtoolStripButton;
        private System.Windows.Forms.ToolStripButton AddUsertoolStripButton;
        private System.Windows.Forms.GroupBox StatusMenu;
        private System.Windows.Forms.Label EmployersLabel;
        private System.Windows.Forms.ComboBox EmployersBox;
        private System.Windows.Forms.RadioButton StatusButton3;
        private System.Windows.Forms.RadioButton StatusButton2;
        private System.Windows.Forms.RadioButton StatusButton1;
        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.Button ClearFilterButton;
        private System.Windows.Forms.Button ReloadTableButton;
        private System.Windows.Forms.OpenFileDialog openDBDialog;
    }
}

