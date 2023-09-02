using System.Windows.Forms;

namespace HelpDeskWinFormsApp
{
    partial class AuthorizationFrom
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            LoginTextBox = new TextBox();
            PasswordTextBox = new TextBox();
            label1 = new Label();
            label2 = new Label();
            loginButton = new Button();
            cancelButton = new Button();
            registrationButton = new Button();
            dataBaseConnectionLabel = new Label();
            connectionDbTimer = new Timer(components);
            timerLabel = new Label();
            menuStrip1 = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            configDbToolStripMenuItem = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            settingsDbButton = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // LoginTextBox
            // 
            LoginTextBox.Enabled = false;
            LoginTextBox.Location = new System.Drawing.Point(12, 91);
            LoginTextBox.Name = "LoginTextBox";
            LoginTextBox.Size = new System.Drawing.Size(279, 23);
            LoginTextBox.TabIndex = 0;
            // 
            // PasswordTextBox
            // 
            PasswordTextBox.Enabled = false;
            PasswordTextBox.Location = new System.Drawing.Point(12, 155);
            PasswordTextBox.Name = "PasswordTextBox";
            PasswordTextBox.Size = new System.Drawing.Size(279, 23);
            PasswordTextBox.TabIndex = 1;
            PasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 58);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(279, 30);
            label1.TabIndex = 2;
            label1.Text = "&Логин";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 117);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(279, 35);
            label2.TabIndex = 3;
            label2.Text = "&Пароль";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loginButton
            // 
            loginButton.DialogResult = DialogResult.OK;
            loginButton.Enabled = false;
            loginButton.Location = new System.Drawing.Point(12, 202);
            loginButton.Name = "loginButton";
            loginButton.Size = new System.Drawing.Size(279, 33);
            loginButton.TabIndex = 4;
            loginButton.Text = "&Вход";
            loginButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            cancelButton.DialogResult = DialogResult.Cancel;
            cancelButton.Location = new System.Drawing.Point(12, 319);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(279, 33);
            cancelButton.TabIndex = 5;
            cancelButton.Text = "В&ыход";
            cancelButton.UseVisualStyleBackColor = true;
            // 
            // registrationButton
            // 
            registrationButton.Enabled = false;
            registrationButton.Location = new System.Drawing.Point(12, 241);
            registrationButton.Name = "registrationButton";
            registrationButton.Size = new System.Drawing.Size(279, 33);
            registrationButton.TabIndex = 6;
            registrationButton.Text = "&Регистрация";
            registrationButton.UseVisualStyleBackColor = true;
            registrationButton.Click += RegistrationButton_Click;
            // 
            // dataBaseConnectionLabel
            // 
            dataBaseConnectionLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataBaseConnectionLabel.Location = new System.Drawing.Point(0, 20);
            dataBaseConnectionLabel.Name = "dataBaseConnectionLabel";
            dataBaseConnectionLabel.Size = new System.Drawing.Size(303, 23);
            dataBaseConnectionLabel.TabIndex = 7;
            dataBaseConnectionLabel.Text = "Идёт проверка подключения к базе данных";
            dataBaseConnectionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // connectionDbTimer
            // 
            connectionDbTimer.Interval = 1000;
            connectionDbTimer.Tick += ConnectionDbTimer_Tick;
            // 
            // timerLabel
            // 
            timerLabel.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            timerLabel.Location = new System.Drawing.Point(12, 39);
            timerLabel.Name = "timerLabel";
            timerLabel.Size = new System.Drawing.Size(279, 18);
            timerLabel.TabIndex = 8;
            timerLabel.Text = "0";
            timerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem });
            menuStrip1.Location = new System.Drawing.Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new System.Drawing.Size(303, 24);
            menuStrip1.TabIndex = 9;
            menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { configDbToolStripMenuItem, exitToolStripMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            файлToolStripMenuItem.Text = "&Файл";
            // 
            // configDbToolStripMenuItem
            // 
            configDbToolStripMenuItem.Name = "configDbToolStripMenuItem";
            configDbToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            configDbToolStripMenuItem.Text = "&Настройки БД";
            configDbToolStripMenuItem.Click += configDbToolStripMenuItem_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            exitToolStripMenuItem.Text = "&Выход";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // settingsDbButton
            // 
            settingsDbButton.Location = new System.Drawing.Point(12, 280);
            settingsDbButton.Name = "settingsDbButton";
            settingsDbButton.Size = new System.Drawing.Size(279, 33);
            settingsDbButton.TabIndex = 10;
            settingsDbButton.Text = "&Настройки БД";
            settingsDbButton.UseVisualStyleBackColor = true;
            settingsDbButton.Click += settingsDbButton_Click;
            // 
            // AuthorizationFrom
            // 
            AcceptButton = loginButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelButton;
            ClientSize = new System.Drawing.Size(303, 382);
            ControlBox = false;
            Controls.Add(settingsDbButton);
            Controls.Add(dataBaseConnectionLabel);
            Controls.Add(registrationButton);
            Controls.Add(cancelButton);
            Controls.Add(loginButton);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(PasswordTextBox);
            Controls.Add(LoginTextBox);
            Controls.Add(timerLabel);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MainMenuStrip = menuStrip1;
            Name = "AuthorizationFrom";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "HelpDesk Авторизация";
            FormClosing += AuthorizationFrom_FormClosing;
            Shown += AuthorizationFrom_Shown;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label2;
        private Button loginButton;
        private Button cancelButton;
        public TextBox LoginTextBox;
        public TextBox PasswordTextBox;
        private Button registrationButton;
        private Label dataBaseConnectionLabel;
        private Timer connectionDbTimer;
        private Label timerLabel;
        private ContextMenuStrip contextMenuStrip;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem configDbToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private Button settingsDbButton;
    }
}