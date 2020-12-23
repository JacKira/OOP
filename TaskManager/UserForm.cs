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
    public partial class UserForm : Form
    {
        public string Login { get; set; }
        public string Password { get; set; }
        public bool IsClosed { get; set; } = true;

        private bool _newMember;
        private bool _editMember;

        private TaskTableForm parent;

        private int _w;
        private int _h;

        
    


        public UserForm(TaskTableForm parent, bool _new = false, bool edit = false)
        {
            InitializeComponent();
            _newMember = _new;
            this.parent = parent;
            _editMember = edit;
        }

        private void NewMember()
        {
            GoButton.Text = "Добавить работника";
            this.Text = "Добавление работника";
        }

        private void GoButton_Click(object sender, EventArgs e)
        {
            if((LoginBox.Text == string.Empty) || (PasswordBox.Text == string.Empty))
            {
                MessageBox.Show("Введены не все данные, повторите ввод");
                return;
            }
            if (_newMember)
            {
                if(NameBox.Text == string.Empty)
                {
                    MessageBox.Show("Введены не все данные, повторите ввод");
                    return;
                }
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
                db.LogIn(NameBox.Text, LoginBox.Text, PasswordBox.Text);
                parent.UpdateAllEmployer();
                parent.UpdateTable();
                parent.UpdateEmployers();
            }

            if(_editMember)
            {
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
               //Редактирование пользователя, выбранного в UserBox
            }

            //Обычная авторизация
            if(!_editMember && !_newMember)
            {
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
                bool? res = db.Verification(LoginBox.Text, PasswordBox.Text);
                if(res != null)
                {
                    Properties.Settings.Default.Admin = (bool)res;
                    Properties.Settings.Default.User = true;
                    Properties.Settings.Default.UserID = (int)db.GetIdByLogin(LoginBox.Text);
                    Properties.Settings.Default.UserLogin = LoginBox.Text + ((bool)res ? "(Админ)" : "(Работник)");
                    parent.Updateprivilege();
                }
                parent.UpdateTable();
            }
            IsClosed = false;
            this.Close();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            NameBox.Enabled = _newMember;
            NameLabel.Enabled = _newMember;
            NameLabel.Visible = _newMember;
            NameBox.Visible = _newMember;
            UsersBox.Enabled = _editMember;
            UsersBox.Visible = _editMember;
            GoButton.Enabled = !_editMember;
            GoButton.Visible = !_editMember;
            _w = this.Width;
            _h = this.Height;
            if(_editMember)
            {
                UpdateEmployers();
                this.Text = "Редактирование профиля";
                var btn = new Button { Location = GoButton.Location, Text = "Удалить", Size = GoButton.Size };
                btn.Click += (_sender, args) =>
                {
                    var _db = new TaskDB(Properties.Settings.Default.PathToDB);
                    _db.DeleteEmployer((UsersBox.SelectedItem as Employer).ID);
                    parent.UpdateAllEmployer();
                    parent.UpdateEmployers();
                    parent.UpdateTable();
                    UpdateEmployers();

                };
                this.Controls.Add(btn);
                /*
                 * Добавить редактирование пользователя
                 */
            }
            if (_newMember)
            {
                NewMember();
            }
        }

        private void UpdateEmployers()
        {
            UsersBox.Items.Clear();
            UsersBox.Text = "";
            var db = new TaskDB(Properties.Settings.Default.PathToDB);
            var employers = db.GetEmployers();
            foreach (var employer in employers)
            {
                UsersBox.Items.Add(employer);
            }

        }

        private void UserForm_Resize(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }

        private void UserForm_ResizeBegin(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }

        private void UserForm_ResizeEnd(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }
    }
}
