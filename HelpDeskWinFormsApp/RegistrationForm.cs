using HelpDesk.Common;
using HelpDesk.Common.Models;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void RegistrationForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || DialogResult == DialogResult.Abort)
            {
                return;
            }

            foreach (var tb in Controls.OfType<TextBox>())
            {
                switch (tb.Name)
                {
                    case "nameTextBox":
                        if (tb.Text == string.Empty)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Пожалуйста введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "loginTextBox":
                        if (tb.Text == string.Empty)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Пожалуйста введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (DbProvider.GetUser(tb.Text) != null)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Логин уже занят, пожалуста выберите другой", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "passwordTextBox":
                        if (tb.Text.Length < 5)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Пароль должен содержать не менее 5 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "replyPasswordTextBox":
                        if (tb.Text == string.Empty)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Пожалуйста введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (tb.Text != passwordTextBox.Text)
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Пароли не совпадают, пожалуйста проверьте корректность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                    case "emailTextBox":
                        if (!Methods.isValidEmail(tb.Text))
                        {
                            tb.Focus();
                            e.Cancel = true;
                            MessageBox.Show("Неверный формат email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        break;
                }
            }

            var user = new User
            {
                Name = nameTextBox.Text,
                Login = loginTextBox.Text,
                Password = Methods.GetHashMD5(passwordTextBox.Text),
                Email = emailTextBox.Text
            };

            DbProvider.AddUser(user);
        }
    }
}
