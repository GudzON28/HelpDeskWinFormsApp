using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Linq;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class EditUserForm : Form
    {
        int userId;
        User user;

        public EditUserForm(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        private void EditUserForm_Shown(object sender, System.EventArgs e)
        {
            user = DbProvider.GetUser(userId);

            if (user is Employee)
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;

                userTypeComboBox.Text = "Сотрудник";
                deparmentComboBox.Text = ((Employee)user).Department;
                functionComboBox.Text = ((Employee)user).Function;
            }
            else
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;

                userTypeComboBox.Text = "Клиент";
            }

            nameTextBox.Text = user.Name;
            loginTextBox.Text = user.Login;
            emailTextBox.Text = user.Email;
        }

        private void UserTypeComboBox_SelectedValueChanged(object sender, System.EventArgs e)
        {
            if (userTypeComboBox.Text == "Сотрудник")
            {
                deparmentComboBox.Enabled = true;
                functionComboBox.Enabled = true;
            }
            else if (userTypeComboBox.Text == "Клиент")
            {
                deparmentComboBox.Enabled = false;
                functionComboBox.Enabled = false;
            }
        }

        private void EditUserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (nameTextBox.Text == string.Empty)
            {
                nameTextBox.Focus();
                e.Cancel = true;
                MessageBox.Show("Пожалуйста введите имя", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.Name = nameTextBox.Text;

            if (loginTextBox.Text == string.Empty)
            {
                loginTextBox.Focus();
                e.Cancel = true;
                MessageBox.Show("Пожалуйста введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.Login = loginTextBox.Text;

            if (changePasswordTextBox.Text != string.Empty)
            {
                if (changePasswordTextBox.Text.Length < 5)
                {
                    changePasswordTextBox.Focus();
                    e.Cancel = true;
                    MessageBox.Show("Пароль должен содержать не менее 5 символов", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (changePasswordTextBox.Text != confurmChangePasswordTextBox.Text)
                {
                    confurmChangePasswordTextBox.Focus();
                    e.Cancel = true;
                    MessageBox.Show("Пароли не совпадают, пожалуйста проверьте корректность", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                user.Password = Methods.GetHashMD5(changePasswordTextBox.Text);
            }

            if (!Methods.isValidEmail(emailTextBox.Text))
            {
                emailTextBox.Focus();
                e.Cancel = true;
                MessageBox.Show("Неверный формат email", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            user.Email = emailTextBox.Text;

            if (user is Employee)
            {
                if (CheckCorrentFilling(e))
                {
                    ((Employee)user).Function = functionComboBox.Text;
                    ((Employee)user).Department = deparmentComboBox.Text;
                }
            }

            if (userTypeComboBox.Text == "Сотрудник" && user is not Employee)
            {
                if (CheckCorrentFilling(e))
                {
                    DbProvider.ChangeUserToEmployee(user, functionComboBox.Text, deparmentComboBox.Text);
                }

            }
            else if (userTypeComboBox.Text == "Клиент" && user is Employee)
            {
                DbProvider.ChangeEmployeeToUser(user);
            }
            else
            {
                DbProvider.UpdateUser(user);
            }
        }

        private bool CheckCorrentFilling(FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (deparmentComboBox.Text == string.Empty)
                {
                    deparmentComboBox.Focus();
                    e.Cancel = true;
                    MessageBox.Show("Пожалуйста выберите отдел", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                if (functionComboBox.Text == string.Empty)
                {
                    functionComboBox.Focus();
                    e.Cancel = true;
                    MessageBox.Show("Пожалуйста выберите функцию сотрудника", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                return true;
            }

            return false;
        }

        private void DeparmentComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            if (deparmentComboBox.Text == "Техническая поддержка")
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add("Оператор");
                functionComboBox.Items.Add("Технический специалист");
                functionComboBox.Text = "Оператор";
            }
            else if (deparmentComboBox.Text == "Разработка")
            {
                functionComboBox.Items.Clear();
                functionComboBox.Items.Add("Тестировщик");
                functionComboBox.Items.Add("Разработчик");
                functionComboBox.Text = "Тестировщик";
            }
        }
    }
}
