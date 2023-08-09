namespace DataBaseCourseWork.UserControls
{
    partial class ChangePassUserControl
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
            this.currentPassTextBox = new System.Windows.Forms.TextBox();
            this.newPassTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.repeatPassTextBox = new System.Windows.Forms.TextBox();
            this.changePassButton = new System.Windows.Forms.Button();
            this.currentPassErrorLable = new System.Windows.Forms.Label();
            this.newPassErrorLable = new System.Windows.Forms.Label();
            this.repeatPassErrorLable = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // currentPassTextBox
            // 
            this.currentPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPassTextBox.Location = new System.Drawing.Point(5, 30);
            this.currentPassTextBox.Name = "currentPassTextBox";
            this.currentPassTextBox.Size = new System.Drawing.Size(391, 20);
            this.currentPassTextBox.TabIndex = 0;
            // 
            // newPassTextBox
            // 
            this.newPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.newPassTextBox.Location = new System.Drawing.Point(5, 100);
            this.newPassTextBox.Name = "newPassTextBox";
            this.newPassTextBox.Size = new System.Drawing.Size(390, 20);
            this.newPassTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Текущий пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(5, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Новый пароль";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 155);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(135, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Повторите новый пароль";
            // 
            // repeatPassTextBox
            // 
            this.repeatPassTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatPassTextBox.Location = new System.Drawing.Point(5, 170);
            this.repeatPassTextBox.Name = "repeatPassTextBox";
            this.repeatPassTextBox.Size = new System.Drawing.Size(391, 20);
            this.repeatPassTextBox.TabIndex = 5;
            // 
            // changePassButton
            // 
            this.changePassButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.changePassButton.Location = new System.Drawing.Point(120, 228);
            this.changePassButton.Name = "changePassButton";
            this.changePassButton.Size = new System.Drawing.Size(160, 30);
            this.changePassButton.TabIndex = 7;
            this.changePassButton.Text = "Сменить пароль";
            this.changePassButton.UseVisualStyleBackColor = true;
            // 
            // currentPassErrorLable
            // 
            this.currentPassErrorLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.currentPassErrorLable.AutoSize = true;
            this.currentPassErrorLable.ForeColor = System.Drawing.Color.Red;
            this.currentPassErrorLable.Location = new System.Drawing.Point(150, 15);
            this.currentPassErrorLable.Name = "currentPassErrorLable";
            this.currentPassErrorLable.Size = new System.Drawing.Size(175, 13);
            this.currentPassErrorLable.TabIndex = 8;
            this.currentPassErrorLable.Text = "Неверно введен текущий пароль";
            this.currentPassErrorLable.Visible = false;
            // 
            // newPassErrorLable
            // 
            this.newPassErrorLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.newPassErrorLable.AutoSize = true;
            this.newPassErrorLable.ForeColor = System.Drawing.Color.Red;
            this.newPassErrorLable.Location = new System.Drawing.Point(150, 85);
            this.newPassErrorLable.Name = "newPassErrorLable";
            this.newPassErrorLable.Size = new System.Drawing.Size(165, 13);
            this.newPassErrorLable.TabIndex = 9;
            this.newPassErrorLable.Text = "Пароль не может быть пустым";
            this.newPassErrorLable.Visible = false;
            // 
            // repeatPassErrorLable
            // 
            this.repeatPassErrorLable.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.repeatPassErrorLable.AutoSize = true;
            this.repeatPassErrorLable.ForeColor = System.Drawing.Color.Red;
            this.repeatPassErrorLable.Location = new System.Drawing.Point(150, 155);
            this.repeatPassErrorLable.Name = "repeatPassErrorLable";
            this.repeatPassErrorLable.Size = new System.Drawing.Size(118, 13);
            this.repeatPassErrorLable.TabIndex = 10;
            this.repeatPassErrorLable.Text = "Пароли не совпадают";
            this.repeatPassErrorLable.Visible = false;
            // 
            // ChangePassUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.repeatPassErrorLable);
            this.Controls.Add(this.newPassErrorLable);
            this.Controls.Add(this.currentPassErrorLable);
            this.Controls.Add(this.changePassButton);
            this.Controls.Add(this.repeatPassTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newPassTextBox);
            this.Controls.Add(this.currentPassTextBox);
            this.Name = "ChangePassUserControl";
            this.Size = new System.Drawing.Size(400, 300);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox currentPassTextBox;
        private System.Windows.Forms.TextBox newPassTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox repeatPassTextBox;
        private System.Windows.Forms.Button changePassButton;
        private System.Windows.Forms.Label currentPassErrorLable;
        private System.Windows.Forms.Label newPassErrorLable;
        private System.Windows.Forms.Label repeatPassErrorLable;
    }
}
