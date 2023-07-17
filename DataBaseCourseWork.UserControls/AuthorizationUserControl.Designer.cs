namespace DataBaseCourseWork.UserControls
{
    partial class AuthorizationUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.loginNameTextBox = new System.Windows.Forms.TextBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageLogin = new System.Windows.Forms.TabPage();
            this.loginErrorLabel = new System.Windows.Forms.Label();
            this.loginPasswordErrorLabel = new System.Windows.Forms.Label();
            this.loginNameErrorLabel = new System.Windows.Forms.Label();
            this.loginButton = new System.Windows.Forms.Button();
            this.loginPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabPageRegistration = new System.Windows.Forms.TabPage();
            this.registrationErrorLabel = new System.Windows.Forms.Label();
            this.registrationRepeatPasswordErrorLabel = new System.Windows.Forms.Label();
            this.registrationPasswordErrorLabel = new System.Windows.Forms.Label();
            this.registrationNameErrorLabel = new System.Windows.Forms.Label();
            this.registrationButton = new System.Windows.Forms.Button();
            this.registrationNameTextBox = new System.Windows.Forms.TextBox();
            this.registrationRepeatPasswordTextBox = new System.Windows.Forms.TextBox();
            this.registrationPasswordTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.tabControl.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageRegistration.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginNameTextBox
            // 
            this.loginNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginNameTextBox.Location = new System.Drawing.Point(5, 25);
            this.loginNameTextBox.Name = "loginNameTextBox";
            this.loginNameTextBox.Size = new System.Drawing.Size(427, 20);
            this.loginNameTextBox.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageLogin);
            this.tabControl.Controls.Add(this.tabPageRegistration);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(450, 400);
            this.tabControl.TabIndex = 1;
            // 
            // tabPageLogin
            // 
            this.tabPageLogin.BackColor = System.Drawing.Color.Gainsboro;
            this.tabPageLogin.Controls.Add(this.loginErrorLabel);
            this.tabPageLogin.Controls.Add(this.loginPasswordErrorLabel);
            this.tabPageLogin.Controls.Add(this.loginNameErrorLabel);
            this.tabPageLogin.Controls.Add(this.loginButton);
            this.tabPageLogin.Controls.Add(this.loginPasswordTextBox);
            this.tabPageLogin.Controls.Add(this.label2);
            this.tabPageLogin.Controls.Add(this.label1);
            this.tabPageLogin.Controls.Add(this.loginNameTextBox);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(442, 374);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Вход";
            // 
            // loginErrorLabel
            // 
            this.loginErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginErrorLabel.AutoSize = true;
            this.loginErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginErrorLabel.Location = new System.Drawing.Point(145, 274);
            this.loginErrorLabel.Name = "loginErrorLabel";
            this.loginErrorLabel.Size = new System.Drawing.Size(151, 13);
            this.loginErrorLabel.TabIndex = 12;
            this.loginErrorLabel.Text = "Неверный логин или пароль";
            this.loginErrorLabel.Visible = false;
            // 
            // loginPasswordErrorLabel
            // 
            this.loginPasswordErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPasswordErrorLabel.AutoSize = true;
            this.loginPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginPasswordErrorLabel.Location = new System.Drawing.Point(125, 65);
            this.loginPasswordErrorLabel.Name = "loginPasswordErrorLabel";
            this.loginPasswordErrorLabel.Size = new System.Drawing.Size(165, 13);
            this.loginPasswordErrorLabel.TabIndex = 11;
            this.loginPasswordErrorLabel.Text = "Пароль не может быть пустым";
            this.loginPasswordErrorLabel.Visible = false;
            // 
            // loginNameErrorLabel
            // 
            this.loginNameErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.loginNameErrorLabel.AutoSize = true;
            this.loginNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginNameErrorLabel.Location = new System.Drawing.Point(125, 10);
            this.loginNameErrorLabel.Name = "loginNameErrorLabel";
            this.loginNameErrorLabel.Size = new System.Drawing.Size(149, 13);
            this.loginNameErrorLabel.TabIndex = 10;
            this.loginNameErrorLabel.Text = "Имя не может быть пустым";
            this.loginNameErrorLabel.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.loginButton.Location = new System.Drawing.Point(147, 290);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(147, 35);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // loginPasswordTextBox
            // 
            this.loginPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginPasswordTextBox.Location = new System.Drawing.Point(5, 80);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.loginPasswordTextBox.Size = new System.Drawing.Size(427, 20);
            this.loginPasswordTextBox.TabIndex = 3;
            this.loginPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Имя";
            // 
            // tabPageRegistration
            // 
            this.tabPageRegistration.BackColor = System.Drawing.Color.LightGray;
            this.tabPageRegistration.Controls.Add(this.registrationErrorLabel);
            this.tabPageRegistration.Controls.Add(this.registrationRepeatPasswordErrorLabel);
            this.tabPageRegistration.Controls.Add(this.registrationPasswordErrorLabel);
            this.tabPageRegistration.Controls.Add(this.registrationNameErrorLabel);
            this.tabPageRegistration.Controls.Add(this.registrationButton);
            this.tabPageRegistration.Controls.Add(this.registrationNameTextBox);
            this.tabPageRegistration.Controls.Add(this.registrationRepeatPasswordTextBox);
            this.tabPageRegistration.Controls.Add(this.registrationPasswordTextBox);
            this.tabPageRegistration.Controls.Add(this.label5);
            this.tabPageRegistration.Controls.Add(this.label4);
            this.tabPageRegistration.Controls.Add(this.label3);
            this.tabPageRegistration.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegistration.Name = "tabPageRegistration";
            this.tabPageRegistration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegistration.Size = new System.Drawing.Size(442, 374);
            this.tabPageRegistration.TabIndex = 1;
            this.tabPageRegistration.Text = "Регистрация";
            // 
            // registrationErrorLabel
            // 
            this.registrationErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationErrorLabel.AutoSize = true;
            this.registrationErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationErrorLabel.Location = new System.Drawing.Point(102, 274);
            this.registrationErrorLabel.Name = "registrationErrorLabel";
            this.registrationErrorLabel.Size = new System.Drawing.Size(250, 13);
            this.registrationErrorLabel.TabIndex = 12;
            this.registrationErrorLabel.Text = "Пользователь с таким именем уже существует";
            this.registrationErrorLabel.Visible = false;
            // 
            // registrationRepeatPasswordErrorLabel
            // 
            this.registrationRepeatPasswordErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationRepeatPasswordErrorLabel.AutoSize = true;
            this.registrationRepeatPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationRepeatPasswordErrorLabel.Location = new System.Drawing.Point(125, 119);
            this.registrationRepeatPasswordErrorLabel.Name = "registrationRepeatPasswordErrorLabel";
            this.registrationRepeatPasswordErrorLabel.Size = new System.Drawing.Size(118, 13);
            this.registrationRepeatPasswordErrorLabel.TabIndex = 11;
            this.registrationRepeatPasswordErrorLabel.Text = "Пароли не совпадают";
            this.registrationRepeatPasswordErrorLabel.Visible = false;
            // 
            // registrationPasswordErrorLabel
            // 
            this.registrationPasswordErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationPasswordErrorLabel.AutoSize = true;
            this.registrationPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationPasswordErrorLabel.Location = new System.Drawing.Point(125, 64);
            this.registrationPasswordErrorLabel.Name = "registrationPasswordErrorLabel";
            this.registrationPasswordErrorLabel.Size = new System.Drawing.Size(165, 13);
            this.registrationPasswordErrorLabel.TabIndex = 10;
            this.registrationPasswordErrorLabel.Text = "Пароль не может быть пустым";
            this.registrationPasswordErrorLabel.Visible = false;
            // 
            // registrationNameErrorLabel
            // 
            this.registrationNameErrorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationNameErrorLabel.AutoSize = true;
            this.registrationNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationNameErrorLabel.Location = new System.Drawing.Point(125, 10);
            this.registrationNameErrorLabel.Name = "registrationNameErrorLabel";
            this.registrationNameErrorLabel.Size = new System.Drawing.Size(149, 13);
            this.registrationNameErrorLabel.TabIndex = 9;
            this.registrationNameErrorLabel.Text = "Имя не может быть пустым";
            this.registrationNameErrorLabel.Visible = false;
            // 
            // registrationButton
            // 
            this.registrationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.registrationButton.Location = new System.Drawing.Point(147, 290);
            this.registrationButton.Name = "registrationButton";
            this.registrationButton.Size = new System.Drawing.Size(147, 35);
            this.registrationButton.TabIndex = 8;
            this.registrationButton.Text = "Зарегистрироваться";
            this.registrationButton.UseVisualStyleBackColor = false;
            // 
            // registrationNameTextBox
            // 
            this.registrationNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationNameTextBox.Location = new System.Drawing.Point(5, 25);
            this.registrationNameTextBox.Name = "registrationNameTextBox";
            this.registrationNameTextBox.Size = new System.Drawing.Size(427, 20);
            this.registrationNameTextBox.TabIndex = 7;
            // 
            // registrationRepeatPasswordTextBox
            // 
            this.registrationRepeatPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationRepeatPasswordTextBox.Location = new System.Drawing.Point(5, 135);
            this.registrationRepeatPasswordTextBox.Name = "registrationRepeatPasswordTextBox";
            this.registrationRepeatPasswordTextBox.Size = new System.Drawing.Size(427, 20);
            this.registrationRepeatPasswordTextBox.TabIndex = 6;
            this.registrationRepeatPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // registrationPasswordTextBox
            // 
            this.registrationPasswordTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.registrationPasswordTextBox.Location = new System.Drawing.Point(5, 80);
            this.registrationPasswordTextBox.Name = "registrationPasswordTextBox";
            this.registrationPasswordTextBox.Size = new System.Drawing.Size(427, 20);
            this.registrationPasswordTextBox.TabIndex = 5;
            this.registrationPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(5, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(5, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Повторите пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя";
            // 
            // AuthorizationUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Name = "AuthorizationUserControl";
            this.Size = new System.Drawing.Size(450, 400);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.AuthorizationUserControl_KeyDown);
            this.tabControl.ResumeLayout(false);
            this.tabPageLogin.ResumeLayout(false);
            this.tabPageLogin.PerformLayout();
            this.tabPageRegistration.ResumeLayout(false);
            this.tabPageRegistration.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox loginNameTextBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageLogin;
        private System.Windows.Forms.TabPage tabPageRegistration;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox loginPasswordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button registrationButton;
        private System.Windows.Forms.TextBox registrationNameTextBox;
        private System.Windows.Forms.TextBox registrationRepeatPasswordTextBox;
        private System.Windows.Forms.TextBox registrationPasswordTextBox;
        private System.Windows.Forms.Label loginPasswordErrorLabel;
        private System.Windows.Forms.Label loginNameErrorLabel;
        private System.Windows.Forms.Label registrationRepeatPasswordErrorLabel;
        private System.Windows.Forms.Label registrationPasswordErrorLabel;
        private System.Windows.Forms.Label registrationNameErrorLabel;
        private System.Windows.Forms.Label loginErrorLabel;
        private System.Windows.Forms.Label registrationErrorLabel;
    }
}
