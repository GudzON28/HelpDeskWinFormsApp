using HelpDesk.Common;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class DbConnectForm : Form
    {
        public DbConnectForm()
        {
            InitializeComponent();
        }

        private void DbConnectForm_Shown(object sender, System.EventArgs e)
        {
            CheckDbConnectAsync();
        }

        async void CheckDbConnectAsync()
        {
            statusLabel.Text = "Загрузка данных";
            var checkAvailableDb = true;

            if (await Task.Run(() => new ApplicationDbContext().Database.CanConnectAsync()))
            {
                statusLabel.Text = "Загрузка данных успешна";
                Close();
            }
            else
            {
                var aswer = MessageBox.Show("Ошибка подключения к базе данных", "Ошибка", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

                if (aswer == DialogResult.Retry)
                {
                    CheckDbConnectAsync();
                }

                if (aswer == DialogResult.Cancel)
                {
                    Environment.Exit(0);
                }
            }
        }
    }
}
