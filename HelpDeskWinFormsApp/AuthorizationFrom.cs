using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class AuthorizationFrom : Form
    {
        public bool RegistrationChoice = false;
        private bool editParamDb = false;

        public AuthorizationFrom()
        {
            InitializeComponent();
        }

        private void AuthorizationFrom_Shown(object sender, EventArgs e)
        {
            connectionDbTimer.Start();
            CheckDbConnectAsync();
        }

        private void AuthorizationFrom_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.Cancel || editParamDb)
            {
                return;
            }

            if (CheckUserInput(e) && DbProvider.IsCorrectLoginPassword(LoginTextBox.Text, PasswordTextBox.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Неверный логин или пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            RegistrationChoice = true;
            cancelButton.PerformClick();
        }

        private void ConnectionDbTimer_Tick(object sender, EventArgs e)
        {
            timerLabel.Text = (Convert.ToInt32(timerLabel.Text) + 1).ToString();
        }

        private void TimerLabel_Click(object sender, EventArgs e)
        {
            timerLabel.Click -= TimerLabel_Click;
            dataBaseConnectionLabel.BackColor = BackColor;
            dataBaseConnectionLabel.Text = "Повторная попытка подключения к базе данных";
            timerLabel.Text = "0";
            connectionDbTimer.Start();

            CheckDbConnectAsync();
        }

        private bool CheckUserInput(FormClosingEventArgs e)
        {
            if (LoginTextBox.Text == string.Empty)
            {
                e.Cancel = true;
                LoginTextBox.Focus();
                MessageBox.Show("Пожалуйста введите логин", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (PasswordTextBox.Text == string.Empty)
            {
                e.Cancel = true;
                PasswordTextBox.Focus();
                MessageBox.Show("Пожалуйста введите пароль", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        async void CheckDbConnectAsync()
        {
            if (await Task.Run(() => new ApplicationDbContext().Database.CanConnectAsync()))
            {
                if (DbProvider.GetAllUsers().Count == 0)
                {
                    AddFirstEmployee();
                }

                UnlockTextBox();
                return;
            }
            else
            {
                try
                {
                    if (await Task.Run(() => new ApplicationDbContext().Database.EnsureCreatedAsync()))
                    {
                        if (DbProvider.GetAllUsers().Count == 0)
                        {
                            AddFirstEmployee();
                        }

                        UnlockTextBox();
                        return;
                    }
                }
                catch { }

                if (connectionDbTimer.Enabled)
                {
                    connectionDbTimer.Stop();
                    MessageBox.Show("Ошибка подключения к базе данных, пожалуйста повторите попытку позже.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    dataBaseConnectionLabel.Text = "Ошибка подключения к базе данных";
                    dataBaseConnectionLabel.BackColor = Color.Red;
                    timerLabel.Text = "Нажмите здесь для повторной попытки";
                    timerLabel.Click += new EventHandler(TimerLabel_Click);
                }
            }
        }

        private void UnlockTextBox()
        {
            LoginTextBox.Enabled = true;
            PasswordTextBox.Enabled = true;
            loginButton.Enabled = true;
            registrationButton.Enabled = true;
            dataBaseConnectionLabel.Text = "База данных успешно подключена";
            dataBaseConnectionLabel.BackColor = Color.Green;
            connectionDbTimer.Stop();
            timerLabel.Hide();
        }

        private static void AddFirstEmployee()
        {
            var employee = new Employee();

            employee.Name = "startAdmin";
            employee.Login = "admin";
            employee.Password = Methods.GetHashMD5("admin");
            employee.Email = "admin@admin.admin";
            employee.Department = "Разработка";
            employee.Function = "Разработчик";

            DbProvider.AddEmployee(employee);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private void configDbToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var setParamDb = new SetParamDb();
            var paramBdDialogResult = setParamDb.ShowDialog();

            if (paramBdDialogResult == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }

            if (paramBdDialogResult == DialogResult.OK)
            {
                editParamDb = true;
                Application.Restart();
            }
        }

        private void settingsDbButton_Click(object sender, EventArgs e)
        {
            connectionDbTimer.Stop();
            Hide();

            new SetParamDb().ShowDialog();

            DialogResult = DialogResult.Cancel;
            Application.Restart();
        }
    }
}
