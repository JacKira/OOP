namespace TaskManager
{
    partial class MainForm
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
            this.NavigationMenu = new System.Windows.Forms.GroupBox();
            this.TaskTable = new System.Windows.Forms.TableLayoutPanel();
        
            this.SuspendLayout();
            // 
            // NavigationMenu
            // 
            this.NavigationMenu.Location = new System.Drawing.Point(12, 12);
            this.NavigationMenu.Name = "NavigationMenu";
            this.NavigationMenu.Size = new System.Drawing.Size(271, 748);
            this.NavigationMenu.TabIndex = 0;
            this.NavigationMenu.TabStop = false;
            this.NavigationMenu.Text = "Menu";
            this.NavigationMenu.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // TaskTable
            // 
            this.TaskTable.AutoScroll = true;
            this.TaskTable.BackColor = System.Drawing.SystemColors.Control;
            this.TaskTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TaskTable.ColumnCount = 3;
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 334F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 329F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 357F));
            this.TaskTable.Location = new System.Drawing.Point(305, 12);
            this.TaskTable.Name = "TaskTable";
            this.TaskTable.RowCount = 1;
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 291F));
            this.TaskTable.Size = new System.Drawing.Size(1020, 291);
            this.TaskTable.TabIndex = 1;
            // 
            
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 856);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.TaskTable);
            this.Controls.Add(this.NavigationMenu);
            this.Name = "MainForm";
            this.Text = "Task Table";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox NavigationMenu;
        private System.Windows.Forms.TableLayoutPanel TaskTable;
        private System.Windows.Forms.TextBox textBox1;
    }
}

