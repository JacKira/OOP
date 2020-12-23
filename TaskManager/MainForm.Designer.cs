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
            this.SaveDBtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.LoadBasetoolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.AuthtoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.AddUsertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.EditUsertoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.LogOuttoolStripButton = new System.Windows.Forms.ToolStripButton();
            this.openDbDialog = new System.Windows.Forms.OpenFileDialog();
            this.FilterMenu = new System.Windows.Forms.GroupBox();
            this.ClearFilterButton = new System.Windows.Forms.Button();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.StatusMenu = new System.Windows.Forms.GroupBox();
            this.StatusButton3 = new System.Windows.Forms.RadioButton();
            this.StatusButton2 = new System.Windows.Forms.RadioButton();
            this.StatusButton1 = new System.Windows.Forms.RadioButton();
            this.EmployersLabel = new System.Windows.Forms.Label();
            this.EmployersBox = new System.Windows.Forms.ComboBox();
            this.saveDbDialog = new System.Windows.Forms.SaveFileDialog();
            this.ProfileStatusLabel = new System.Windows.Forms.Label();
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
            this.toolStripSeparator1,
            this.LoadBasetoolStripButton2,
            this.toolStripSeparator4,
            this.AuthtoolStripButton,
            this.toolStripSeparator2,
            this.AddUsertoolStripButton,
            this.toolStripSeparator3,
            this.EditUsertoolStripButton,
            this.LogOuttoolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.MinimumSize = new System.Drawing.Size(0, 50);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1357, 50);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // SaveDBtoolStripButton
            // 
            this.SaveDBtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.SaveDBtoolStripButton.Image = global::TaskManager.Properties.Resources.save_save;
            this.SaveDBtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.SaveDBtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveDBtoolStripButton.Name = "SaveDBtoolStripButton";
            this.SaveDBtoolStripButton.Size = new System.Drawing.Size(44, 47);
            this.SaveDBtoolStripButton.Text = "Сохранить  или создать базу данных";
            this.SaveDBtoolStripButton.Click += new System.EventHandler(this.SaveDBtoolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 50);
            // 
            // LoadBasetoolStripButton2
            // 
            this.LoadBasetoolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LoadBasetoolStripButton2.Image = global::TaskManager.Properties.Resources.load;
            this.LoadBasetoolStripButton2.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LoadBasetoolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LoadBasetoolStripButton2.Name = "LoadBasetoolStripButton2";
            this.LoadBasetoolStripButton2.Size = new System.Drawing.Size(44, 47);
            this.LoadBasetoolStripButton2.Text = "Загрузить базу данных";
            this.LoadBasetoolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 50);
            // 
            // AuthtoolStripButton
            // 
            this.AuthtoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AuthtoolStripButton.Image = global::TaskManager.Properties.Resources.authorization_LOGIN;
            this.AuthtoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AuthtoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AuthtoolStripButton.Name = "AuthtoolStripButton";
            this.AuthtoolStripButton.Size = new System.Drawing.Size(44, 47);
            this.AuthtoolStripButton.Text = "Авторизоваться";
            this.AuthtoolStripButton.Click += new System.EventHandler(this.AuthtoolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 50);
            // 
            // AddUsertoolStripButton
            // 
            this.AddUsertoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.AddUsertoolStripButton.Enabled = false;
            this.AddUsertoolStripButton.Image = global::TaskManager.Properties.Resources.adduser;
            this.AddUsertoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.AddUsertoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddUsertoolStripButton.Name = "AddUsertoolStripButton";
            this.AddUsertoolStripButton.Size = new System.Drawing.Size(44, 47);
            this.AddUsertoolStripButton.Text = "Добавить работника";
            this.AddUsertoolStripButton.Click += new System.EventHandler(this.AddUsertoolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 50);
            // 
            // EditUsertoolStripButton
            // 
            this.EditUsertoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.EditUsertoolStripButton.Enabled = false;
            this.EditUsertoolStripButton.Image = global::TaskManager.Properties.Resources.EditUser;
            this.EditUsertoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.EditUsertoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditUsertoolStripButton.Name = "EditUsertoolStripButton";
            this.EditUsertoolStripButton.Size = new System.Drawing.Size(44, 47);
            this.EditUsertoolStripButton.Text = "Редактировать пользователя";
            this.EditUsertoolStripButton.Click += new System.EventHandler(this.EditUsertoolStripButton_Click);
            // 
            // LogOuttoolStripButton
            // 
            this.LogOuttoolStripButton.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.LogOuttoolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.LogOuttoolStripButton.Enabled = false;
            this.LogOuttoolStripButton.Image = global::TaskManager.Properties.Resources.logout;
            this.LogOuttoolStripButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.LogOuttoolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.LogOuttoolStripButton.Name = "LogOuttoolStripButton";
            this.LogOuttoolStripButton.Size = new System.Drawing.Size(44, 47);
            this.LogOuttoolStripButton.Text = "Выйти из учетной записи";
            this.LogOuttoolStripButton.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // FilterMenu
            // 
            this.FilterMenu.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FilterMenu.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("FilterMenu.BackgroundImage")));
            this.FilterMenu.Controls.Add(this.ProfileStatusLabel);
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
            // 
            // ClearFilterButton
            // 
            this.ClearFilterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ClearFilterButton.Location = new System.Drawing.Point(14, 670);
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
            // ProfileStatusLabel
            // 
            this.ProfileStatusLabel.AutoSize = true;
            this.ProfileStatusLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ProfileStatusLabel.Location = new System.Drawing.Point(6, 261);
            this.ProfileStatusLabel.MaximumSize = new System.Drawing.Size(250, 0);
            this.ProfileStatusLabel.MinimumSize = new System.Drawing.Size(250, 20);
            this.ProfileStatusLabel.Name = "ProfileStatusLabel";
            this.ProfileStatusLabel.Size = new System.Drawing.Size(250, 34);
            this.ProfileStatusLabel.TabIndex = 15;
            this.ProfileStatusLabel.Text = "Активный пользователь:\r\n Гость";
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
        private System.Windows.Forms.OpenFileDialog openDbDialog;
        private System.Windows.Forms.ToolStripButton EditUsertoolStripButton;
        private System.Windows.Forms.ToolStripButton LogOuttoolStripButton;
        private System.Windows.Forms.SaveFileDialog saveDbDialog;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.Label ProfileStatusLabel;
    }
}

