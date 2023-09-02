namespace HelpDeskWinFormsApp
{
    partial class SetParamDb
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
            label1 = new System.Windows.Forms.Label();
            ServerFirstOctetIpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ServerSecondOctetIpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ServerThirdOctetIpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ServerFourthOctetIpNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label2 = new System.Windows.Forms.Label();
            ServerPortNumericUpDown = new System.Windows.Forms.NumericUpDown();
            label3 = new System.Windows.Forms.Label();
            ServerUserNameTextBox = new System.Windows.Forms.TextBox();
            ServerUserPasswordTextBox = new System.Windows.Forms.TextBox();
            label4 = new System.Windows.Forms.Label();
            serverDbNameTextBox = new System.Windows.Forms.TextBox();
            label5 = new System.Windows.Forms.Label();
            label6 = new System.Windows.Forms.Label();
            ServerVersionThirdNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ServerVersionSecondNumericUpDown = new System.Windows.Forms.NumericUpDown();
            ServerVersionFirstNumericUpDown = new System.Windows.Forms.NumericUpDown();
            OkButton = new System.Windows.Forms.Button();
            CancelButton = new System.Windows.Forms.Button();
            isDemoModeCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)ServerFirstOctetIpNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerSecondOctetIpNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerThirdOctetIpNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerFourthOctetIpNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerPortNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionThirdNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionSecondNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionFirstNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.Location = new System.Drawing.Point(12, 9);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(31, 30);
            label1.TabIndex = 0;
            label1.Text = "IP";
            // 
            // ServerFirstOctetIpNumericUpDown
            // 
            ServerFirstOctetIpNumericUpDown.Location = new System.Drawing.Point(12, 42);
            ServerFirstOctetIpNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerFirstOctetIpNumericUpDown.Name = "ServerFirstOctetIpNumericUpDown";
            ServerFirstOctetIpNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerFirstOctetIpNumericUpDown.TabIndex = 1;
            ServerFirstOctetIpNumericUpDown.ValueChanged += ServerFirstOctetIpNumericUpDown_ValueChanged;
            // 
            // ServerSecondOctetIpNumericUpDown
            // 
            ServerSecondOctetIpNumericUpDown.Location = new System.Drawing.Point(57, 42);
            ServerSecondOctetIpNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerSecondOctetIpNumericUpDown.Name = "ServerSecondOctetIpNumericUpDown";
            ServerSecondOctetIpNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerSecondOctetIpNumericUpDown.TabIndex = 2;
            ServerSecondOctetIpNumericUpDown.ValueChanged += ServerSecondOctetIpNumericUpDown_ValueChanged;
            // 
            // ServerThirdOctetIpNumericUpDown
            // 
            ServerThirdOctetIpNumericUpDown.Location = new System.Drawing.Point(102, 42);
            ServerThirdOctetIpNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerThirdOctetIpNumericUpDown.Name = "ServerThirdOctetIpNumericUpDown";
            ServerThirdOctetIpNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerThirdOctetIpNumericUpDown.TabIndex = 3;
            ServerThirdOctetIpNumericUpDown.ValueChanged += ServerThirdOctetIpNumericUpDown_ValueChanged;
            // 
            // ServerFourthOctetIpNumericUpDown
            // 
            ServerFourthOctetIpNumericUpDown.Location = new System.Drawing.Point(147, 42);
            ServerFourthOctetIpNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerFourthOctetIpNumericUpDown.Name = "ServerFourthOctetIpNumericUpDown";
            ServerFourthOctetIpNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerFourthOctetIpNumericUpDown.TabIndex = 4;
            ServerFourthOctetIpNumericUpDown.ValueChanged += ServerFourthOctetIpNumericUpDown_ValueChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.Location = new System.Drawing.Point(12, 68);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(61, 30);
            label2.TabIndex = 5;
            label2.Text = "Порт";
            // 
            // ServerPortNumericUpDown
            // 
            ServerPortNumericUpDown.Location = new System.Drawing.Point(12, 101);
            ServerPortNumericUpDown.Maximum = new decimal(new int[] { 65535, 0, 0, 0 });
            ServerPortNumericUpDown.Name = "ServerPortNumericUpDown";
            ServerPortNumericUpDown.Size = new System.Drawing.Size(50, 23);
            ServerPortNumericUpDown.TabIndex = 6;
            ServerPortNumericUpDown.Value = new decimal(new int[] { 3306, 0, 0, 0 });
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label3.Location = new System.Drawing.Point(12, 127);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(147, 30);
            label3.TabIndex = 7;
            label3.Text = "Пользователь";
            // 
            // ServerUserNameTextBox
            // 
            ServerUserNameTextBox.Location = new System.Drawing.Point(12, 160);
            ServerUserNameTextBox.Name = "ServerUserNameTextBox";
            ServerUserNameTextBox.Size = new System.Drawing.Size(174, 23);
            ServerUserNameTextBox.TabIndex = 8;
            // 
            // ServerUserPasswordTextBox
            // 
            ServerUserPasswordTextBox.Location = new System.Drawing.Point(12, 219);
            ServerUserPasswordTextBox.Name = "ServerUserPasswordTextBox";
            ServerUserPasswordTextBox.Size = new System.Drawing.Size(174, 23);
            ServerUserPasswordTextBox.TabIndex = 10;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.Location = new System.Drawing.Point(12, 186);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(85, 30);
            label4.TabIndex = 9;
            label4.Text = "Пароль";
            // 
            // serverDbNameTextBox
            // 
            serverDbNameTextBox.Location = new System.Drawing.Point(12, 278);
            serverDbNameTextBox.Name = "serverDbNameTextBox";
            serverDbNameTextBox.Size = new System.Drawing.Size(174, 23);
            serverDbNameTextBox.TabIndex = 12;
            serverDbNameTextBox.Text = "HelpDesk";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.Location = new System.Drawing.Point(12, 245);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(88, 30);
            label5.TabIndex = 11;
            label5.Text = "Имя БД";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label6.Location = new System.Drawing.Point(12, 304);
            label6.Name = "label6";
            label6.Size = new System.Drawing.Size(114, 30);
            label6.TabIndex = 13;
            label6.Text = "Версия БД";
            // 
            // ServerVersionThirdNumericUpDown
            // 
            ServerVersionThirdNumericUpDown.Location = new System.Drawing.Point(102, 337);
            ServerVersionThirdNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerVersionThirdNumericUpDown.Name = "ServerVersionThirdNumericUpDown";
            ServerVersionThirdNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerVersionThirdNumericUpDown.TabIndex = 16;
            // 
            // ServerVersionSecondNumericUpDown
            // 
            ServerVersionSecondNumericUpDown.Location = new System.Drawing.Point(57, 337);
            ServerVersionSecondNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerVersionSecondNumericUpDown.Name = "ServerVersionSecondNumericUpDown";
            ServerVersionSecondNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerVersionSecondNumericUpDown.TabIndex = 15;
            // 
            // ServerVersionFirstNumericUpDown
            // 
            ServerVersionFirstNumericUpDown.Location = new System.Drawing.Point(12, 337);
            ServerVersionFirstNumericUpDown.Maximum = new decimal(new int[] { 255, 0, 0, 0 });
            ServerVersionFirstNumericUpDown.Name = "ServerVersionFirstNumericUpDown";
            ServerVersionFirstNumericUpDown.Size = new System.Drawing.Size(39, 23);
            ServerVersionFirstNumericUpDown.TabIndex = 14;
            // 
            // OkButton
            // 
            OkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            OkButton.Location = new System.Drawing.Point(12, 400);
            OkButton.Name = "OkButton";
            OkButton.Size = new System.Drawing.Size(176, 33);
            OkButton.TabIndex = 17;
            OkButton.Text = "&OK";
            OkButton.UseVisualStyleBackColor = true;
            // 
            // CancelButton
            // 
            CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            CancelButton.Location = new System.Drawing.Point(12, 439);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new System.Drawing.Size(176, 33);
            CancelButton.TabIndex = 18;
            CancelButton.Text = "&Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            // 
            // isDemoModeCheckBox
            // 
            isDemoModeCheckBox.AutoSize = true;
            isDemoModeCheckBox.Location = new System.Drawing.Point(12, 375);
            isDemoModeCheckBox.Name = "isDemoModeCheckBox";
            isDemoModeCheckBox.Size = new System.Drawing.Size(142, 19);
            isDemoModeCheckBox.TabIndex = 19;
            isDemoModeCheckBox.Text = "Демо режим (SQLite)";
            isDemoModeCheckBox.UseVisualStyleBackColor = true;
            isDemoModeCheckBox.CheckedChanged += isDemoModeCheckBox_CheckedChanged;
            // 
            // SetParamDb
            // 
            AcceptButton = OkButton;
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(200, 480);
            ControlBox = false;
            Controls.Add(isDemoModeCheckBox);
            Controls.Add(CancelButton);
            Controls.Add(OkButton);
            Controls.Add(ServerVersionThirdNumericUpDown);
            Controls.Add(ServerVersionSecondNumericUpDown);
            Controls.Add(ServerVersionFirstNumericUpDown);
            Controls.Add(label6);
            Controls.Add(serverDbNameTextBox);
            Controls.Add(label5);
            Controls.Add(ServerUserPasswordTextBox);
            Controls.Add(label4);
            Controls.Add(ServerUserNameTextBox);
            Controls.Add(label3);
            Controls.Add(ServerPortNumericUpDown);
            Controls.Add(label2);
            Controls.Add(ServerFourthOctetIpNumericUpDown);
            Controls.Add(ServerThirdOctetIpNumericUpDown);
            Controls.Add(ServerSecondOctetIpNumericUpDown);
            Controls.Add(ServerFirstOctetIpNumericUpDown);
            Controls.Add(label1);
            Name = "SetParamDb";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "HelpDesk Параметры БД";
            FormClosing += SetParamDb_FormClosing;
            ((System.ComponentModel.ISupportInitialize)ServerFirstOctetIpNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerSecondOctetIpNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerThirdOctetIpNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerFourthOctetIpNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerPortNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionThirdNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionSecondNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)ServerVersionFirstNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown ServerFirstOctetIpNumericUpDown;
        private System.Windows.Forms.NumericUpDown ServerSecondOctetIpNumericUpDown;
        private System.Windows.Forms.NumericUpDown ServerThirdOctetIpNumericUpDown;
        private System.Windows.Forms.NumericUpDown ServerFourthOctetIpNumericUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown ServerPortNumericUpDown;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ServerUserNameTextBox;
        private System.Windows.Forms.TextBox ServerUserPasswordTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox serverDbNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown ServerVersionThirdNumericUpDown;
        private System.Windows.Forms.NumericUpDown ServerVersionSecondNumericUpDown;
        private System.Windows.Forms.NumericUpDown ServerVersionFirstNumericUpDown;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckBox isDemoModeCheckBox;
    }
}