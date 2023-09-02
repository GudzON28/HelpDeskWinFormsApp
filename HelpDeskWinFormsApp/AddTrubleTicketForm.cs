using HelpDesk.Common;
using HelpDesk.Common.Models;
using System;
using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    public partial class AddTrubleTicketForm : Form
    {
        User user;

        public AddTrubleTicketForm(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void AddTrubleTicketForm_Shown(object sender, EventArgs e)
        {
            userNameTextBox.Text = $"{user.Name} \\ {user.Login}";
        }

        private void AddTrubleTicketForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                var trubelTicket = new TrubleTicket();

                trubelTicket.CreateUser = user.Id;
                trubelTicket.Text = trubleRichTextBox.Text;
                trubelTicket.Status = "Зарегистрирована";
                trubelTicket.Created = DateTime.Now;
                trubelTicket.Deadline = DateTime.Now.AddDays(4);

                DbProvider.AddTrubleTicket(trubelTicket);
            }
        }

        private void TrubleRichTextBox_TextChanged(object sender, EventArgs e)
        {
            if (trubleRichTextBox.Text.Length < 5)
            {
                createTrubleTicketButton.Enabled = false;
            }
            else
            {
                createTrubleTicketButton.Enabled = true;
            }
        }
    }
}
