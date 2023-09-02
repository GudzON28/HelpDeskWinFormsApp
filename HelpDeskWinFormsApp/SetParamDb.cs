using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class SetParamDb : Form
    {
        public SetParamDb()
        {
            InitializeComponent();
        }

        private void SetParamDb_FormClosing(object sender, FormClosingEventArgs e)
        {
            var paramDb = new ParamDb();

            if (DialogResult == DialogResult.OK)
            {
                if (!isDemoModeCheckBox.Checked)
                {
                    if (ServerFirstOctetIpNumericUpDown.Value == 0 && ServerSecondOctetIpNumericUpDown.Value == 0 &&
                        ServerThirdOctetIpNumericUpDown.Value == 0 && ServerFourthOctetIpNumericUpDown.Value == 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите IP сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.ServerIp = new string[]
                    {
                    ServerFirstOctetIpNumericUpDown.Value.ToString().Trim(),
                    ServerSecondOctetIpNumericUpDown.Value.ToString().Trim(),
                    ServerThirdOctetIpNumericUpDown.Value.ToString().Trim(),
                    ServerFourthOctetIpNumericUpDown.Value.ToString().Trim()
                    };

                    if (ServerPortNumericUpDown.Value == 0)
                    {
                        ServerPortNumericUpDown.Focus();
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите порт сервера", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.ServerPort = ServerPortNumericUpDown.Value.ToString().Trim();

                    if (string.IsNullOrEmpty(ServerUserNameTextBox.Text))
                    {
                        ServerUserNameTextBox.Focus();
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите логин пользователя БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.User = ServerUserNameTextBox.Text;

                    if (string.IsNullOrEmpty(ServerUserPasswordTextBox.Text))
                    {
                        ServerUserPasswordTextBox.Focus();
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите пароль пользователя БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.Password = ServerUserPasswordTextBox.Text;

                    if (string.IsNullOrEmpty(serverDbNameTextBox.Text))
                    {
                        serverDbNameTextBox.Focus();
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите название БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.NameDb = serverDbNameTextBox.Text;

                    if (ServerVersionFirstNumericUpDown.Value == 0 && ServerVersionSecondNumericUpDown.Value == 0 && ServerVersionThirdNumericUpDown.Value == 0)
                    {
                        e.Cancel = true;
                        MessageBox.Show("Пожалуйста введите версию сервера БД", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    paramDb.VersionDb = new int[]
                    {
                        Convert.ToInt32(ServerVersionFirstNumericUpDown.Value),
                        Convert.ToInt32(ServerVersionSecondNumericUpDown.Value),
                        Convert.ToInt32(ServerVersionThirdNumericUpDown.Value)
                    };

                    paramDb.IsDemoMode = false;
                }
                else
                {
                    paramDb.IsDemoMode = true;
                }

                if (FileProvider.Exist("cnf.dat"))
                {
                    FileProvider.Delete("cnf.dat");
                }

                JsonProvider.Save(paramDb);
            }
        }

        private void ServerFirstOctetIpNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (ServerFirstOctetIpNumericUpDown.Value > 255)
            {
                ServerFirstOctetIpNumericUpDown.Value = 255;
            }
        }

        private void ServerSecondOctetIpNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (ServerSecondOctetIpNumericUpDown.Value > 255)
            {
                ServerSecondOctetIpNumericUpDown.Value = 255;
            }
        }

        private void ServerThirdOctetIpNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (ServerThirdOctetIpNumericUpDown.Value > 255)
            {
                ServerSecondOctetIpNumericUpDown.Value = 255;
            }
        }

        private void ServerFourthOctetIpNumericUpDown_ValueChanged(object sender, System.EventArgs e)
        {
            if (ServerFourthOctetIpNumericUpDown.Value > 255)
            {
                ServerFourthOctetIpNumericUpDown.Value = 255;
            }
        }

        private void isDemoModeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (isDemoModeCheckBox.Checked)
            {
                ServerFirstOctetIpNumericUpDown.Enabled = false;
                ServerSecondOctetIpNumericUpDown.Enabled = false;
                ServerThirdOctetIpNumericUpDown.Enabled = false;
                ServerFourthOctetIpNumericUpDown.Enabled = false;
                ServerPortNumericUpDown.Enabled = false;
                ServerUserNameTextBox.Enabled = false;
                ServerUserPasswordTextBox.Enabled = false;
                serverDbNameTextBox.Enabled = false;
                ServerVersionFirstNumericUpDown.Enabled = false;
                ServerVersionSecondNumericUpDown.Enabled = false;
                ServerVersionThirdNumericUpDown.Enabled = false;
            }
            else
            {
                ServerFirstOctetIpNumericUpDown.Enabled = true;
                ServerSecondOctetIpNumericUpDown.Enabled = true;
                ServerThirdOctetIpNumericUpDown.Enabled = true;
                ServerFourthOctetIpNumericUpDown.Enabled = true;
                ServerPortNumericUpDown.Enabled = true;
                ServerUserNameTextBox.Enabled = true;
                ServerUserPasswordTextBox.Enabled = true;
                serverDbNameTextBox.Enabled = true;
                ServerVersionFirstNumericUpDown.Enabled = true;
                ServerVersionSecondNumericUpDown.Enabled = true;
                ServerVersionThirdNumericUpDown.Enabled = true;
            }
        }
    }
}
