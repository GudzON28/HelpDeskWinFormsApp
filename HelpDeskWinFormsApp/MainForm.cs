using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Windows.Forms;
using HelpDesk.Common;
using HelpDesk.Common.Models;

namespace HelpDeskWinFormsApp
{
    public partial class MainForm : Form
    {
        private User user = new();

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CheckInternetConnection();
            CheckDbConfigFile();

            string login = AuthorizationUser();

            if (login != string.Empty)
            {
                TestDbConnetion();

                user = DbProvider.GetUser(login);

                ShowUserTreeNode();
                SetHeaderWindowText();
                ShowExportSubMenu();

                treeView.Width = splitContainer.Panel1.Width;
                treeView.Height = splitContainer.Panel1.Height - 152;

                listTTDataGridView.Size = splitContainer.Panel2.Size;

                userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
                loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
                userNameToolStripMenuItem.Text = $"&{user.Name}";
            }
        }

        private void CheckInternetConnection()
        {
            var ping = new Ping();
            var pingReply = ping.Send("8.8.8.8", 1000);

            if (pingReply.Status == IPStatus.Success)
            {
                return;
            }

            MessageBox.Show("Отсутствует интернет соеденение.\r\nПожалуйста восстановите соеденение и запустите программу повторно.", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            Environment.Exit(2);
        }

        private void CheckDbConfigFile()
        {
            if (FileProvider.Exist("cnf.dat"))
            {
                return;
            }

            var setParamDb = new SetParamDb();

            if (setParamDb.ShowDialog() == DialogResult.Cancel)
            {
                Environment.Exit(0);
            }
        }

        private void ShowExportSubMenu()
        {
            if (user is not Employee)
            {
                exportToolStripMenuItem.Visible =false;
            }
            else
            {
                exportToolStripMenuItem.Visible = true;
            }
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void LogoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listTTDataGridView.Rows.Clear();
            listTTDataGridView.Columns.Clear();

            Hide();

            var login = AuthorizationUser();

            if (login != string.Empty)
            {
                TestDbConnetion();

                user = DbProvider.GetUser(login);

                SetHeaderWindowText();

                userNameToolStripStatusLabel.Text = $"Имя: {user.Name}";
                loginToolStripStatusLabel.Text = $"Логин: {user.Login}";
                userNameToolStripMenuItem.Text = $"&{user.Name}";
                treeView.SelectedNode = treeView.Nodes[0];

                ShowUserTreeNode();
                ShowExportSubMenu();
                Show();
            }
        }

        private void SplitContainer_Panel1_Resize(object sender, EventArgs e)
        {
            treeView.Width = splitContainer.Panel1.Width;
            treeView.Height = splitContainer.Panel1.Height - 152;
            editUserButton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 117);
            openTrubleTicketButton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 88);
            addTrubleTicketbutton.Location = new Point(openTrubleTicketButton.Location.X, splitContainer.Panel1.Height - 59);
            exitButton.Location = new Point(exitButton.Location.X, splitContainer.Panel1.Height - 30);
        }

        private void SplitContainer_Panel2_Resize(object sender, EventArgs e)
        {
            listTTDataGridView.Size = splitContainer.Panel2.Size;
        }

        private void OpenTrubleTicketButton_Click(object sender, EventArgs e)
        {
            if (listTTDataGridView.SelectedRows.Count != 0)
            {
                var isEmployee = user is Employee ? true : false;
                var ticketId = Convert.ToInt32(listTTDataGridView.SelectedCells[0].Value);

                TestDbConnetion();

                var resolvedUser = Convert.ToInt32(DbProvider.GetTrubleTicket(ticketId).ResolveUser != null ? user.Id : -1);

                if (user is Employee && resolvedUser == -1)
                {
                    resolvedUser = user.Id;
                }

                var dialogResult = new TrubleTicketForm(ticketId, isEmployee, resolvedUser).ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    RefreshTrubleTicketsDataGrid();
                }
            }
        }

        private void AddTrubleTicketbutton_Click(object sender, EventArgs e)
        {
            var dialogResult = new AddTrubleTicketForm(user);

            if (dialogResult.ShowDialog() == DialogResult.OK)
            {
                treeView.SelectedNode = treeView.Nodes["trubleTicketlist"].Nodes["openTrubleTicket"];
                RefreshTrubleTicketsDataGrid();
            }
        }

        private void TreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            refreshToolStripMenuItem.PerformClick();
        }

        private void ListTTDataGridView_DoubleClick(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Level != 0)
            {
                if (treeView.SelectedNode.Parent.Name == "trubleTicketlist" || treeView.SelectedNode.Parent.Name == "statusTrubleTicketNode")
                {
                    openTrubleTicketButton.PerformClick();
                }

                if (treeView.SelectedNode.Parent.Name == "usersNode")
                {
                    editUserButton.PerformClick();
                }
            }
        }

        private void exportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var isSupport = false;

            if (user is Employee)
            {
                isSupport = ((Employee)user).Department == "Техническая поддержка";
            }

            new ExportForm(isSupport).ShowDialog();
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            if (listTTDataGridView.SelectedRows.Count != 0)
            {
                var userId = Convert.ToInt32(listTTDataGridView.SelectedCells[0].Value);

                var dialogResult = new EditUserForm(userId).ShowDialog();

                if (dialogResult == DialogResult.OK)
                {
                    RefreshUsersDataGrid();
                }
            }
        }

        private void RefreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (treeView.SelectedNode.Level != 0)
            {
                if (treeView.SelectedNode.Parent.Name == "trubleTicketlist" || treeView.SelectedNode.Parent.Name == "statusTrubleTicketNode")
                {
                    RefreshTrubleTicketsDataGrid();
                    editUserButton.Enabled = false;
                    openTrubleTicketButton.Enabled = true;
                }

                if (treeView.SelectedNode.Parent.Name == "usersNode")
                {
                    RefreshUsersDataGrid();
                    editUserButton.Enabled = true;
                    openTrubleTicketButton.Enabled = false;
                }
            }
            else
            {
                editUserButton.Enabled = false;
                openTrubleTicketButton.Enabled = false;
            }
        }

        private void ShowUserTreeNode()
        {
            if (user is not Employee || ((Employee)user).Department == "Техническая поддержка")
            {
                RemoveUserTreeNode();
                editUserButton.Visible = false;
            }
            else
            {
                if (treeView.Nodes.Count == 1)
                {
                    AddUserTreeNode();
                }

                editUserButton.Visible = true;
            }
        }

        private void SetHeaderWindowText()
        {
            if (user is Employee)
            {
                Text = $"HelpDesk. {((Employee)user).Function}: {user.Name}/{user.Login}";
            }
            else
            {
                Text = $"HelpDesk. Клиент: {user.Name}/{user.Login}";
            }
        }

        private void RemoveUserTreeNode()
        {
            if (treeView.Nodes.Count > 1)
            {
                treeView.Nodes.RemoveAt(1);
            }
        }

        private void AddUserTreeNode()
        {
            TreeNode treeNode1 = new TreeNode("Все пользователи");
            TreeNode treeNode2 = new TreeNode("Клиенты");
            TreeNode treeNode3 = new TreeNode("Сотрудники");
            TreeNode treeNode4 = new TreeNode("Пользователи", new TreeNode[] { treeNode1, treeNode2, treeNode3 });

            treeNode1.Name = "allUsersNode";
            treeNode2.Name = "clientsNode";
            treeNode3.Name = "EmployeeNode";
            treeNode4.Name = "usersNode";

            treeView.Nodes.AddRange(new TreeNode[] { treeNode4 });
        }

        private static string AuthorizationUser()
        {
            var isNeedRegistration = false;
            var login = string.Empty;
            var authorizationFrom = new AuthorizationFrom();

            if (authorizationFrom.ShowDialog() == DialogResult.OK)
            {
                login = authorizationFrom.LoginTextBox.Text;
            }
            else
            {
                isNeedRegistration = authorizationFrom.RegistrationChoice;

                if (!isNeedRegistration)
                {
                    Environment.Exit(0);
                    return string.Empty;
                }
            }

            if (isNeedRegistration)
            {
                var registrationForm = new RegistrationForm();
                var registrationFormDialogResult = registrationForm.ShowDialog();

                if (registrationFormDialogResult == DialogResult.OK)
                {
                    login = registrationForm.loginTextBox.Text;
                }
                else if (registrationFormDialogResult == DialogResult.Cancel)
                {
                    Application.Restart();
                }
                else
                {
                    Environment.Exit(0);
                }
            }

            return login;
        }

        private void RefreshUsersDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            listTTDataGridView.Columns.Clear();

            TestDbConnetion();

            switch (selectedNode)
            {
                case "allUsersNode":
                    FillUsersDataGreedView(DbProvider.GetAllUsers());
                    break;
                case "clientsNode":
                    FillUsersDataGreedView(DbProvider.GetAllUsers().Where(u => u is not Employee).ToList());
                    break;
                case "EmployeeNode":
                    FillUsersDataGreedView(DbProvider.GetAllUsers().Where(u => u is Employee).ToList());
                    break;
                default:
                    break;
            }
        }

        private void RefreshTrubleTicketsDataGrid()
        {
            var selectedNode = treeView.SelectedNode.Name;

            if (selectedNode == "statusTrubleTicketNode")
            {
                return;
            }

            List<TrubleTicket> trubleTickets = new();

            listTTDataGridView.Columns.Clear();

            TestDbConnetion();

            if (user is Employee)
            {
                trubleTickets = DbProvider.GetAllTrubleTickets();
            }
            else
            {
                trubleTickets = DbProvider.GetAllTrubleTickets().Where(t => t.CreateUser == user.Id).ToList();
            }

            switch (selectedNode)
            {
                case "allTrubleTicket":
                    FillTrubleTicketsDataGreedView(trubleTickets);
                    break;
                case "openTrubleTicket":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.IsSolved == false).ToList());
                    break;
                case "closedTrubleTicket":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.IsSolved == true).ToList());
                    break;
                case "overdueTrubleTicketNode":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => (DateTime.Now - s.Deadline).TotalSeconds > 0).ToList());
                    break;
                case "registeredTrubleTicketNode":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.Status == "Зарегистрирована").ToList());
                    break;
                case "workTrubleTicketNode":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.Status == "В работе").ToList());
                    break;
                case "completedTrubleTicketNode":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.Status == "Выполнена").ToList());
                    break;
                case "rejectedTrubleTicketNode":
                    FillTrubleTicketsDataGreedView(trubleTickets.Where(s => s.Status == "Отклонена").ToList());
                    break;
                default:
                    break;
            }
        }

        private static void TestDbConnetion()
        {
            new DbConnectForm().ShowDialog();
        }

        private void FillUsersDataGreedView(List<User> users)
        {
            listTTDataGridView.Columns.Add("id", "ID");
            listTTDataGridView.Columns.Add("name", "Имя");
            listTTDataGridView.Columns.Add("login", "Логин");
            listTTDataGridView.Columns.Add("email", "E-Mail");
            listTTDataGridView.Columns.Add("discriminator", "Тип");
            listTTDataGridView.Columns.Add("function", "Функция");
            listTTDataGridView.Columns.Add("department", "Отдел");

            listTTDataGridView.Rows.Clear();

            var countRows = users.Count;

            for (int i = 0; i < countRows; i++)
            {
                listTTDataGridView.Rows.Add();
                listTTDataGridView.Rows[i].Cells[0].Value = users[i].Id;
                listTTDataGridView.Rows[i].Cells[1].Value = users[i].Name;
                listTTDataGridView.Rows[i].Cells[2].Value = users[i].Login;
                listTTDataGridView.Rows[i].Cells[3].Value = users[i].Email;

                var userType = users[i] is Employee;

                listTTDataGridView.Rows[i].Cells[4].Value = userType ? "Сотрудник" : "Клиент";

                if (userType)
                {
                    var employee = users[i] as Employee;

                    listTTDataGridView.Rows[i].Cells[5].Value = employee.Function;
                    listTTDataGridView.Rows[i].Cells[6].Value = employee.Department;
                }
                else
                {
                    listTTDataGridView.Rows[i].Cells[5].Style.BackColor = Color.Gray;
                    listTTDataGridView.Rows[i].Cells[6].Style.BackColor = Color.Gray;
                }
            }

            listTTDataGridView.ClearSelection();
        }

        private void FillTrubleTicketsDataGreedView(List<TrubleTicket> allTrubleTickets)
        {
            AddColumnsTrubleTicketsDataGreedView();

            listTTDataGridView.Rows.Clear();

            var countRow = allTrubleTickets.Count;
            var allUsers = DbProvider.GetAllUsers();

            for (int i = 0; i < countRow; i++)
            {
                var user = allUsers.Where(u => u.Id == allTrubleTickets[i].CreateUser).FirstOrDefault();
                var resolveUser = allUsers.Where(u => u.Id == allTrubleTickets[i].ResolveUser).FirstOrDefault();

                listTTDataGridView.Rows.Add();

                listTTDataGridView.Rows[i].Cells[0].Value = allTrubleTickets[i].Id;

                if (allTrubleTickets[i].IsSolved)
                {
                    listTTDataGridView.Rows[i].Cells[1].Value = "Да";
                    listTTDataGridView.Rows[i].DefaultCellStyle.BackColor = allTrubleTickets[i].Status == "Выполнена" ? Color.LightGreen : Color.LightGray;
                }
                else
                {
                    listTTDataGridView.Rows[i].Cells[1].Value = "Нет";

                    if ((DateTime.Now - allTrubleTickets[i].Deadline).TotalSeconds > 0)
                    {
                        listTTDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightSalmon;
                    }

                    if (allTrubleTickets[i].Status == "В работе")
                    {
                        listTTDataGridView.Rows[i].DefaultCellStyle.BackColor = Color.LightYellow;
                    }
                }

                listTTDataGridView.Rows[i].Cells[2].Value = allTrubleTickets[i].Status;

                if (allTrubleTickets[i].Text.Length > 50)
                {
                    listTTDataGridView.Rows[i].Cells[3].Value = $"{allTrubleTickets[i].Text.Substring(0, 47)}...";
                }
                else
                {
                    listTTDataGridView.Rows[i].Cells[3].Value = allTrubleTickets[i].Text;
                }

                listTTDataGridView.Rows[i].Cells[4].Value = allTrubleTickets[i].Resolve;
                listTTDataGridView.Rows[i].Cells[5].Value = resolveUser != null ? resolveUser.Name : string.Empty;
                listTTDataGridView.Rows[i].Cells[6].Value = allTrubleTickets[i].Created;
                listTTDataGridView.Rows[i].Cells[7].Value = allTrubleTickets[i].ResolveTime;
                listTTDataGridView.Rows[i].Cells[8].Value = allTrubleTickets[i].Deadline;
                listTTDataGridView.Rows[i].Cells[9].Value = $"{user.Name} \\ {user.Email}";
            }

            listTTDataGridView.ClearSelection();
        }

        private void AddColumnsTrubleTicketsDataGreedView()
        {
            listTTDataGridView.Columns.Add("id", "ID");
            listTTDataGridView.Columns.Add("isSolved", "Решён");
            listTTDataGridView.Columns.Add("status", "Статус");
            listTTDataGridView.Columns.Add("text", "Текст");
            listTTDataGridView.Columns.Add("resolve", "Решение");
            listTTDataGridView.Columns.Add("resolveUser", "Решил");
            listTTDataGridView.Columns.Add("created", "Создано");
            listTTDataGridView.Columns.Add("resolveDate", "Дата решения");
            listTTDataGridView.Columns.Add("deadline", "Крайний срок");
            listTTDataGridView.Columns.Add("userCreate", "Кем создано");
        }

    }
}