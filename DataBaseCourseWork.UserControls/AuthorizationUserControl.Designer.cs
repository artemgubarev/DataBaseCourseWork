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
            this.tablePanel1 = new DevExpress.Utils.Layout.TablePanel();
            this.tablePanel2 = new DevExpress.Utils.Layout.TablePanel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl.SuspendLayout();
            this.tabPageLogin.SuspendLayout();
            this.tabPageRegistration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).BeginInit();
            this.tablePanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).BeginInit();
            this.tablePanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // loginNameTextBox
            // 
            this.tablePanel1.SetColumn(this.loginNameTextBox, 0);
            this.tablePanel1.SetColumnSpan(this.loginNameTextBox, 3);
            this.loginNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginNameTextBox.Location = new System.Drawing.Point(3, 43);
            this.loginNameTextBox.Name = "loginNameTextBox";
            this.tablePanel1.SetRow(this.loginNameTextBox, 1);
            this.loginNameTextBox.Size = new System.Drawing.Size(430, 21);
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
            this.tabPageLogin.Controls.Add(this.tablePanel1);
            this.tabPageLogin.Location = new System.Drawing.Point(4, 22);
            this.tabPageLogin.Name = "tabPageLogin";
            this.tabPageLogin.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageLogin.Size = new System.Drawing.Size(442, 374);
            this.tabPageLogin.TabIndex = 0;
            this.tabPageLogin.Text = "Вход";
            // 
            // loginErrorLabel
            // 
            this.loginErrorLabel.AutoSize = true;
            this.tablePanel1.SetColumn(this.loginErrorLabel, 1);
            this.loginErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginErrorLabel.Location = new System.Drawing.Point(148, 294);
            this.loginErrorLabel.Name = "loginErrorLabel";
            this.tablePanel1.SetRow(this.loginErrorLabel, 5);
            this.loginErrorLabel.Size = new System.Drawing.Size(139, 26);
            this.loginErrorLabel.TabIndex = 12;
            this.loginErrorLabel.Text = "Неверный логин или пароль";
            this.loginErrorLabel.Visible = false;
            // 
            // loginPasswordErrorLabel
            // 
            this.loginPasswordErrorLabel.AutoSize = true;
            this.tablePanel1.SetColumn(this.loginPasswordErrorLabel, 1);
            this.loginPasswordErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginPasswordErrorLabel.Location = new System.Drawing.Point(148, 94);
            this.loginPasswordErrorLabel.Name = "loginPasswordErrorLabel";
            this.tablePanel1.SetRow(this.loginPasswordErrorLabel, 2);
            this.loginPasswordErrorLabel.Size = new System.Drawing.Size(139, 26);
            this.loginPasswordErrorLabel.TabIndex = 11;
            this.loginPasswordErrorLabel.Text = "Пароль не может быть пустым";
            this.loginPasswordErrorLabel.Visible = false;
            // 
            // loginNameErrorLabel
            // 
            this.loginNameErrorLabel.AutoSize = true;
            this.tablePanel1.SetColumn(this.loginNameErrorLabel, 1);
            this.loginNameErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.loginNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.loginNameErrorLabel.Location = new System.Drawing.Point(148, 14);
            this.loginNameErrorLabel.Name = "loginNameErrorLabel";
            this.tablePanel1.SetRow(this.loginNameErrorLabel, 0);
            this.loginNameErrorLabel.Size = new System.Drawing.Size(139, 26);
            this.loginNameErrorLabel.TabIndex = 10;
            this.loginNameErrorLabel.Text = "Имя не может быть пустым";
            this.loginNameErrorLabel.Visible = false;
            // 
            // loginButton
            // 
            this.loginButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tablePanel1.SetColumn(this.loginButton, 1);
            this.loginButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginButton.Location = new System.Drawing.Point(148, 323);
            this.loginButton.Name = "loginButton";
            this.tablePanel1.SetRow(this.loginButton, 6);
            this.loginButton.Size = new System.Drawing.Size(139, 42);
            this.loginButton.TabIndex = 4;
            this.loginButton.Text = "Войти";
            this.loginButton.UseVisualStyleBackColor = false;
            // 
            // loginPasswordTextBox
            // 
            this.tablePanel1.SetColumn(this.loginPasswordTextBox, 0);
            this.tablePanel1.SetColumnSpan(this.loginPasswordTextBox, 3);
            this.loginPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.loginPasswordTextBox.Location = new System.Drawing.Point(3, 123);
            this.loginPasswordTextBox.Name = "loginPasswordTextBox";
            this.tablePanel1.SetRow(this.loginPasswordTextBox, 3);
            this.loginPasswordTextBox.Size = new System.Drawing.Size(430, 21);
            this.loginPasswordTextBox.TabIndex = 3;
            this.loginPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.tablePanel1.SetColumn(this.label2, 0);
            this.label2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label2.Location = new System.Drawing.Point(3, 107);
            this.label2.Name = "label2";
            this.tablePanel1.SetRow(this.label2, 2);
            this.label2.Size = new System.Drawing.Size(139, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Пароль";
            // 
            // tabPageRegistration
            // 
            this.tabPageRegistration.BackColor = System.Drawing.Color.LightGray;
            this.tabPageRegistration.Controls.Add(this.tablePanel2);
            this.tabPageRegistration.Location = new System.Drawing.Point(4, 22);
            this.tabPageRegistration.Name = "tabPageRegistration";
            this.tabPageRegistration.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRegistration.Size = new System.Drawing.Size(442, 374);
            this.tabPageRegistration.TabIndex = 1;
            this.tabPageRegistration.Text = "Регистрация";
            // 
            // registrationErrorLabel
            // 
            this.registrationErrorLabel.AutoSize = true;
            this.tablePanel2.SetColumn(this.registrationErrorLabel, 1);
            this.registrationErrorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationErrorLabel.Location = new System.Drawing.Point(148, 280);
            this.registrationErrorLabel.Name = "registrationErrorLabel";
            this.tablePanel2.SetRow(this.registrationErrorLabel, 7);
            this.registrationErrorLabel.Size = new System.Drawing.Size(139, 40);
            this.registrationErrorLabel.TabIndex = 12;
            this.registrationErrorLabel.Text = "Пользователь с таким именем уже существует";
            this.registrationErrorLabel.Visible = false;
            // 
            // registrationRepeatPasswordErrorLabel
            // 
            this.registrationRepeatPasswordErrorLabel.AutoSize = true;
            this.tablePanel2.SetColumn(this.registrationRepeatPasswordErrorLabel, 1);
            this.registrationRepeatPasswordErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.registrationRepeatPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationRepeatPasswordErrorLabel.Location = new System.Drawing.Point(148, 187);
            this.registrationRepeatPasswordErrorLabel.Name = "registrationRepeatPasswordErrorLabel";
            this.tablePanel2.SetRow(this.registrationRepeatPasswordErrorLabel, 4);
            this.registrationRepeatPasswordErrorLabel.Size = new System.Drawing.Size(139, 13);
            this.registrationRepeatPasswordErrorLabel.TabIndex = 11;
            this.registrationRepeatPasswordErrorLabel.Text = "Пароли не совпадают";
            this.registrationRepeatPasswordErrorLabel.Visible = false;
            // 
            // registrationPasswordErrorLabel
            // 
            this.registrationPasswordErrorLabel.AutoSize = true;
            this.tablePanel2.SetColumn(this.registrationPasswordErrorLabel, 1);
            this.registrationPasswordErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.registrationPasswordErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationPasswordErrorLabel.Location = new System.Drawing.Point(148, 94);
            this.registrationPasswordErrorLabel.Name = "registrationPasswordErrorLabel";
            this.tablePanel2.SetRow(this.registrationPasswordErrorLabel, 2);
            this.registrationPasswordErrorLabel.Size = new System.Drawing.Size(139, 26);
            this.registrationPasswordErrorLabel.TabIndex = 10;
            this.registrationPasswordErrorLabel.Text = "Пароль не может быть пустым";
            this.registrationPasswordErrorLabel.Visible = false;
            // 
            // registrationNameErrorLabel
            // 
            this.registrationNameErrorLabel.AutoSize = true;
            this.tablePanel2.SetColumn(this.registrationNameErrorLabel, 1);
            this.registrationNameErrorLabel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.registrationNameErrorLabel.ForeColor = System.Drawing.Color.Red;
            this.registrationNameErrorLabel.Location = new System.Drawing.Point(148, 14);
            this.registrationNameErrorLabel.Name = "registrationNameErrorLabel";
            this.tablePanel2.SetRow(this.registrationNameErrorLabel, 0);
            this.registrationNameErrorLabel.Size = new System.Drawing.Size(139, 26);
            this.registrationNameErrorLabel.TabIndex = 9;
            this.registrationNameErrorLabel.Text = "Имя не может быть пустым";
            this.registrationNameErrorLabel.Visible = false;
            // 
            // registrationButton
            // 
            this.registrationButton.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tablePanel2.SetColumn(this.registrationButton, 1);
            this.registrationButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationButton.Location = new System.Drawing.Point(148, 323);
            this.registrationButton.Name = "registrationButton";
            this.tablePanel2.SetRow(this.registrationButton, 8);
            this.registrationButton.Size = new System.Drawing.Size(139, 42);
            this.registrationButton.TabIndex = 8;
            this.registrationButton.Text = "Зарегистрироваться";
            this.registrationButton.UseVisualStyleBackColor = false;
            // 
            // registrationNameTextBox
            // 
            this.tablePanel2.SetColumn(this.registrationNameTextBox, 0);
            this.tablePanel2.SetColumnSpan(this.registrationNameTextBox, 3);
            this.registrationNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationNameTextBox.Location = new System.Drawing.Point(3, 43);
            this.registrationNameTextBox.Name = "registrationNameTextBox";
            this.tablePanel2.SetRow(this.registrationNameTextBox, 1);
            this.registrationNameTextBox.Size = new System.Drawing.Size(430, 21);
            this.registrationNameTextBox.TabIndex = 7;
            // 
            // registrationRepeatPasswordTextBox
            // 
            this.tablePanel2.SetColumn(this.registrationRepeatPasswordTextBox, 0);
            this.tablePanel2.SetColumnSpan(this.registrationRepeatPasswordTextBox, 3);
            this.registrationRepeatPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationRepeatPasswordTextBox.Location = new System.Drawing.Point(3, 203);
            this.registrationRepeatPasswordTextBox.Name = "registrationRepeatPasswordTextBox";
            this.tablePanel2.SetRow(this.registrationRepeatPasswordTextBox, 5);
            this.registrationRepeatPasswordTextBox.Size = new System.Drawing.Size(430, 21);
            this.registrationRepeatPasswordTextBox.TabIndex = 6;
            this.registrationRepeatPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // registrationPasswordTextBox
            // 
            this.tablePanel2.SetColumn(this.registrationPasswordTextBox, 0);
            this.tablePanel2.SetColumnSpan(this.registrationPasswordTextBox, 3);
            this.registrationPasswordTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.registrationPasswordTextBox.Location = new System.Drawing.Point(3, 123);
            this.registrationPasswordTextBox.Name = "registrationPasswordTextBox";
            this.tablePanel2.SetRow(this.registrationPasswordTextBox, 3);
            this.registrationPasswordTextBox.Size = new System.Drawing.Size(430, 21);
            this.registrationPasswordTextBox.TabIndex = 5;
            this.registrationPasswordTextBox.UseSystemPasswordChar = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.tablePanel2.SetColumn(this.label5, 0);
            this.label5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label5.Location = new System.Drawing.Point(3, 107);
            this.label5.Name = "label5";
            this.tablePanel2.SetRow(this.label5, 2);
            this.label5.Size = new System.Drawing.Size(139, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Пароль";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.tablePanel2.SetColumn(this.label4, 0);
            this.label4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label4.Location = new System.Drawing.Point(3, 187);
            this.label4.Name = "label4";
            this.tablePanel2.SetRow(this.label4, 4);
            this.label4.Size = new System.Drawing.Size(139, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Повторите пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.tablePanel2.SetColumn(this.label3, 0);
            this.label3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label3.Location = new System.Drawing.Point(3, 27);
            this.label3.Name = "label3";
            this.tablePanel2.SetRow(this.label3, 0);
            this.label3.Size = new System.Drawing.Size(139, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Имя";
            // 
            // tablePanel1
            // 
            this.tablePanel1.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel1.Controls.Add(this.label1);
            this.tablePanel1.Controls.Add(this.loginButton);
            this.tablePanel1.Controls.Add(this.loginErrorLabel);
            this.tablePanel1.Controls.Add(this.loginNameErrorLabel);
            this.tablePanel1.Controls.Add(this.loginPasswordErrorLabel);
            this.tablePanel1.Controls.Add(this.loginPasswordTextBox);
            this.tablePanel1.Controls.Add(this.loginNameTextBox);
            this.tablePanel1.Controls.Add(this.label2);
            this.tablePanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel1.Location = new System.Drawing.Point(3, 3);
            this.tablePanel1.Name = "tablePanel1";
            this.tablePanel1.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 120F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F)});
            this.tablePanel1.Size = new System.Drawing.Size(436, 368);
            this.tablePanel1.TabIndex = 13;
            // 
            // tablePanel2
            // 
            this.tablePanel2.Columns.AddRange(new DevExpress.Utils.Layout.TablePanelColumn[] {
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F),
            new DevExpress.Utils.Layout.TablePanelColumn(DevExpress.Utils.Layout.TablePanelEntityStyle.Relative, 50F)});
            this.tablePanel2.Controls.Add(this.label3);
            this.tablePanel2.Controls.Add(this.registrationButton);
            this.tablePanel2.Controls.Add(this.registrationErrorLabel);
            this.tablePanel2.Controls.Add(this.registrationNameErrorLabel);
            this.tablePanel2.Controls.Add(this.registrationRepeatPasswordErrorLabel);
            this.tablePanel2.Controls.Add(this.registrationRepeatPasswordTextBox);
            this.tablePanel2.Controls.Add(this.registrationNameTextBox);
            this.tablePanel2.Controls.Add(this.registrationPasswordErrorLabel);
            this.tablePanel2.Controls.Add(this.label5);
            this.tablePanel2.Controls.Add(this.label4);
            this.tablePanel2.Controls.Add(this.registrationPasswordTextBox);
            this.tablePanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tablePanel2.Location = new System.Drawing.Point(3, 3);
            this.tablePanel2.Name = "tablePanel2";
            this.tablePanel2.Rows.AddRange(new DevExpress.Utils.Layout.TablePanelRow[] {
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F),
            new DevExpress.Utils.Layout.TablePanelRow(DevExpress.Utils.Layout.TablePanelEntityStyle.Absolute, 40F)});
            this.tablePanel2.Size = new System.Drawing.Size(436, 368);
            this.tablePanel2.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.tablePanel1.SetColumn(this.label1, 0);
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Location = new System.Drawing.Point(3, 27);
            this.label1.Name = "label1";
            this.tablePanel1.SetRow(this.label1, 0);
            this.label1.Size = new System.Drawing.Size(139, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Имя";
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
            this.tabPageRegistration.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel1)).EndInit();
            this.tablePanel1.ResumeLayout(false);
            this.tablePanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tablePanel2)).EndInit();
            this.tablePanel2.ResumeLayout(false);
            this.tablePanel2.PerformLayout();
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
        private DevExpress.Utils.Layout.TablePanel tablePanel1;
        private DevExpress.Utils.Layout.TablePanel tablePanel2;
        private System.Windows.Forms.Label label1;
    }
}
