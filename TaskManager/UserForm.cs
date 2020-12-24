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

        
    

        /// <summary>
        /// Задаем начальное состояния формы авторизации
        /// </summary>
        /// <param name="parent"></param>
        /// <param name="_new"></param>
        /// <param name="edit"></param>
        public UserForm(TaskTableForm parent, bool _new = false, bool edit = false)
        {
            InitializeComponent();
            _newMember = _new;
            this.parent = parent;
            _editMember = edit;
        }

        /// <summary>
        /// Изменения интерфейса в случае сценария вызова окна для добавления работника
        /// </summary>
        private void NewMember()
        {
            GoButton.Text = "Добавить работника";
            this.Text = "Добавление работника";
        }

        /// <summary>
        /// Событие нажатия на кнопку формы авторизации
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GoButton_Click(object sender, EventArgs e)
        {
            if((LoginBox.Text == string.Empty) || (PasswordBox.Text == string.Empty)) //Если какие-то поля пропущены, выходим
            {
                MessageBox.Show("Введены не все данные, повторите ввод");
                return;
            }
            if (_newMember) //Если сценарий вызова окна для добавления нового работника
            {
                if(NameBox.Text == string.Empty) //Если поле пропущено, выходим
                {
                    MessageBox.Show("Введены не все данные, повторите ввод");
                    return;
                }
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
                db.LogIn(NameBox.Text, LoginBox.Text, PasswordBox.Text); //Добавляем нового работника в базу
                parent.UpdateAllEmployer();
                parent.UpdateTable();
                parent.UpdateEmployers();
            }

            if(_editMember) //Если сценарий вызова окна для редактирования пользователя
            {
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
               //Редактирование пользователя, выбранного в UserBox                          
            }

            //Обычная авторизация
            if(!_editMember && !_newMember)
            {
                var db = new TaskDB(Properties.Settings.Default.PathToDB);
                bool? res = db.Verification(LoginBox.Text, PasswordBox.Text);
                if(res != null) //Если работник не найден в базе, то res = null
                {
                    Properties.Settings.Default.Admin = (bool)res;  //Если авторизованный пользователь - Администратор, то res = true, если обычный работник, то false
                    Properties.Settings.Default.User = true; //Говорим, что пользователь авторизован
                    Properties.Settings.Default.UserID = (int)db.GetIdByLogin(LoginBox.Text); //Запоминаем id пользователя
                    Properties.Settings.Default.UserLogin = LoginBox.Text + ((bool)res ? "(Админ)" : "(Работник)"); //Строка для статуса пользователя
                    parent.Updateprivilege(); 
                }
                parent.UpdateTable();
            }
            IsClosed = false;
            this.Close();
        }

        /// <summary>
        /// Загрузка формы авторизации в зависимости от сценария использования
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            if(_editMember) //Если сценарий вызова окна для редактирования пользователя
            {
                UpdateEmployers();
                this.Text = "Редактирование профиля";
                //Заменяем кнопку на форме на новый элемент с процедурой для удаления пользователя 
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
            if (_newMember)  // Изменения интерфейса в случае сценария вызова окна для добавления работника
            {
                NewMember();
            }
        }

        /// <summary>
        /// Обновление списка всех пользователей для редактирования
        /// </summary>
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

        /// <summary>
        /// Не даем форме изменять свои размеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_Resize(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }

        /// <summary>
        /// Не даем форме изменять свои размеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_ResizeBegin(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }

        /// <summary>
        /// Не даем форме изменять свои размеры
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserForm_ResizeEnd(object sender, EventArgs e)
        {
            this.Width = _w;
            this.Height = _h;
        }
    }
}
