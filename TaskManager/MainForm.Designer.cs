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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.TaskTable.SuspendLayout();
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
            this.TaskTable.AutoSize = true;
            this.TaskTable.BackColor = System.Drawing.SystemColors.Control;
            this.TaskTable.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.TaskTable.ColumnCount = 3;
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 337F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.TaskTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 328F));
            this.TaskTable.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.TaskTable.Location = new System.Drawing.Point(309, 12);
            this.TaskTable.Name = "TaskTable";
            this.TaskTable.RowCount = 3;
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 49.69072F));
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 258F));
            this.TaskTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 247F));
            this.TaskTable.Size = new System.Drawing.Size(995, 785);
            this.TaskTable.TabIndex = 1;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.Window;
            this.tableLayoutPanel2.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.81818F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(330, 260);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 801);
            this.Controls.Add(this.TaskTable);
            this.Controls.Add(this.NavigationMenu);
            this.Name = "MainForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.TaskTable.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox NavigationMenu;
        private System.Windows.Forms.TableLayoutPanel TaskTable;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}

