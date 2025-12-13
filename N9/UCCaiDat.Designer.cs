namespace N9
{
    partial class UCCaiDat
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.grpPassword = new System.Windows.Forms.GroupBox();
            this.btnChangePassword = new System.Windows.Forms.Button();
            this.txtConfirmPassword = new System.Windows.Forms.TextBox();
            this.lblConfirmPassword = new System.Windows.Forms.Label();
            this.txtNewPassword = new System.Windows.Forms.TextBox();
            this.lblNewPassword = new System.Windows.Forms.Label();
            this.txtOldPassword = new System.Windows.Forms.TextBox();
            this.lblOldPassword = new System.Windows.Forms.Label();
            this.grpReminder = new System.Windows.Forms.GroupBox();
            this.btnSaveReminder = new System.Windows.Forms.Button();
            this.lblDays = new System.Windows.Forms.Label();
            this.numReminderDays = new System.Windows.Forms.NumericUpDown();
            this.lblReminderDays = new System.Windows.Forms.Label();
            this.grpBackup = new System.Windows.Forms.GroupBox();
            this.lblLastBackup = new System.Windows.Forms.Label();
            this.btnRestore = new System.Windows.Forms.Button();
            this.btnBackup = new System.Windows.Forms.Button();
            this.grpPassword.SuspendLayout();
            this.grpReminder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReminderDays)).BeginInit();
            this.grpBackup.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpPassword
            // 
            this.grpPassword.Controls.Add(this.btnChangePassword);
            this.grpPassword.Controls.Add(this.txtConfirmPassword);
            this.grpPassword.Controls.Add(this.lblConfirmPassword);
            this.grpPassword.Controls.Add(this.txtNewPassword);
            this.grpPassword.Controls.Add(this.lblNewPassword);
            this.grpPassword.Controls.Add(this.txtOldPassword);
            this.grpPassword.Controls.Add(this.lblOldPassword);
            this.grpPassword.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grpPassword.Location = new System.Drawing.Point(30, 20);
            this.grpPassword.Name = "grpPassword";
            this.grpPassword.Size = new System.Drawing.Size(400, 250);
            this.grpPassword.TabIndex = 0;
            this.grpPassword.TabStop = false;
            this.grpPassword.Text = "Đổi mật khẩu";
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnChangePassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangePassword.ForeColor = System.Drawing.Color.White;
            this.btnChangePassword.Location = new System.Drawing.Point(20, 200);
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(150, 35);
            this.btnChangePassword.TabIndex = 6;
            this.btnChangePassword.Text = "Đổi mật khẩu";
            this.btnChangePassword.UseVisualStyleBackColor = false;
            this.btnChangePassword.Click += new System.EventHandler(this.btnChangePassword_Click);
            // 
            // txtConfirmPassword
            // 
            this.txtConfirmPassword.Location = new System.Drawing.Point(20, 160);
            this.txtConfirmPassword.Name = "txtConfirmPassword";
            this.txtConfirmPassword.Size = new System.Drawing.Size(350, 34);
            this.txtConfirmPassword.TabIndex = 5;
            this.txtConfirmPassword.UseSystemPasswordChar = true;
            // 
            // lblConfirmPassword
            // 
            this.lblConfirmPassword.AutoSize = true;
            this.lblConfirmPassword.Location = new System.Drawing.Point(16, 132);
            this.lblConfirmPassword.Name = "lblConfirmPassword";
            this.lblConfirmPassword.Size = new System.Drawing.Size(175, 28);
            this.lblConfirmPassword.TabIndex = 4;
            this.lblConfirmPassword.Text = "Xác nhận mật khẩu";
            // 
            // txtNewPassword
            // 
            this.txtNewPassword.Location = new System.Drawing.Point(20, 100);
            this.txtNewPassword.Name = "txtNewPassword";
            this.txtNewPassword.Size = new System.Drawing.Size(350, 34);
            this.txtNewPassword.TabIndex = 3;
            this.txtNewPassword.UseSystemPasswordChar = true;
            // 
            // lblNewPassword
            // 
            this.lblNewPassword.AutoSize = true;
            this.lblNewPassword.Location = new System.Drawing.Point(16, 72);
            this.lblNewPassword.Name = "lblNewPassword";
            this.lblNewPassword.Size = new System.Drawing.Size(130, 28);
            this.lblNewPassword.TabIndex = 2;
            this.lblNewPassword.Text = "Mật khẩu mới";
            // 
            // txtOldPassword
            // 
            this.txtOldPassword.Location = new System.Drawing.Point(200, 35);
            this.txtOldPassword.Name = "txtOldPassword";
            this.txtOldPassword.Size = new System.Drawing.Size(170, 34);
            this.txtOldPassword.TabIndex = 1;
            this.txtOldPassword.UseSystemPasswordChar = true;
            // 
            // lblOldPassword
            // 
            this.lblOldPassword.AutoSize = true;
            this.lblOldPassword.Location = new System.Drawing.Point(16, 38);
            this.lblOldPassword.Name = "lblOldPassword";
            this.lblOldPassword.Size = new System.Drawing.Size(117, 28);
            this.lblOldPassword.TabIndex = 0;
            this.lblOldPassword.Text = "Mật khẩu cũ";
            // 
            // grpReminder
            // 
            this.grpReminder.Controls.Add(this.btnSaveReminder);
            this.grpReminder.Controls.Add(this.lblDays);
            this.grpReminder.Controls.Add(this.numReminderDays);
            this.grpReminder.Controls.Add(this.lblReminderDays);
            this.grpReminder.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grpReminder.Location = new System.Drawing.Point(30, 290);
            this.grpReminder.Name = "grpReminder";
            this.grpReminder.Size = new System.Drawing.Size(400, 100);
            this.grpReminder.TabIndex = 1;
            this.grpReminder.TabStop = false;
            this.grpReminder.Text = "Cài đặt nhắc nhở";
            // 
            // btnSaveReminder
            // 
            this.btnSaveReminder.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSaveReminder.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSaveReminder.ForeColor = System.Drawing.Color.White;
            this.btnSaveReminder.Location = new System.Drawing.Point(280, 40);
            this.btnSaveReminder.Name = "btnSaveReminder";
            this.btnSaveReminder.Size = new System.Drawing.Size(90, 35);
            this.btnSaveReminder.TabIndex = 3;
            this.btnSaveReminder.Text = "Lưu";
            this.btnSaveReminder.UseVisualStyleBackColor = false;
            this.btnSaveReminder.Click += new System.EventHandler(this.btnSaveReminder_Click);
            // 
            // lblDays
            // 
            this.lblDays.AutoSize = true;
            this.lblDays.Location = new System.Drawing.Point(220, 45);
            this.lblDays.Name = "lblDays";
            this.lblDays.Size = new System.Drawing.Size(52, 28);
            this.lblDays.TabIndex = 2;
            this.lblDays.Text = "ngày";
            // 
            // numReminderDays
            // 
            this.numReminderDays.Location = new System.Drawing.Point(160, 43);
            this.numReminderDays.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numReminderDays.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numReminderDays.Name = "numReminderDays";
            this.numReminderDays.Size = new System.Drawing.Size(55, 34);
            this.numReminderDays.TabIndex = 1;
            this.numReminderDays.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // lblReminderDays
            // 
            this.lblReminderDays.AutoSize = true;
            this.lblReminderDays.Location = new System.Drawing.Point(16, 45);
            this.lblReminderDays.Name = "lblReminderDays";
            this.lblReminderDays.Size = new System.Drawing.Size(138, 28);
            this.lblReminderDays.TabIndex = 0;
            this.lblReminderDays.Text = "Nhắc nhở trước";
            // 
            // grpBackup
            // 
            this.grpBackup.Controls.Add(this.lblLastBackup);
            this.grpBackup.Controls.Add(this.btnRestore);
            this.grpBackup.Controls.Add(this.btnBackup);
            this.grpBackup.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.grpBackup.Location = new System.Drawing.Point(30, 410);
            this.grpBackup.Name = "grpBackup";
            this.grpBackup.Size = new System.Drawing.Size(400, 130);
            this.grpBackup.TabIndex = 2;
            this.grpBackup.TabStop = false;
            this.grpBackup.Text = "Sao lưu && Phục hồi";
            // 
            // lblLastBackup
            // 
            this.lblLastBackup.AutoSize = true;
            this.lblLastBackup.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLastBackup.ForeColor = System.Drawing.Color.Gray;
            this.lblLastBackup.Location = new System.Drawing.Point(16, 90);
            this.lblLastBackup.Name = "lblLastBackup";
            this.lblLastBackup.Size = new System.Drawing.Size(163, 23);
            this.lblLastBackup.TabIndex = 2;
            this.lblLastBackup.Text = "Chưa có bản sao lưu";
            // 
            // btnRestore
            // 
            this.btnRestore.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnRestore.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRestore.ForeColor = System.Drawing.Color.White;
            this.btnRestore.Location = new System.Drawing.Point(180, 40);
            this.btnRestore.Name = "btnRestore";
            this.btnRestore.Size = new System.Drawing.Size(150, 40);
            this.btnRestore.TabIndex = 1;
            this.btnRestore.Text = "Phục hồi";
            this.btnRestore.UseVisualStyleBackColor = false;
            this.btnRestore.Click += new System.EventHandler(this.btnRestore_Click);
            // 
            // btnBackup
            // 
            this.btnBackup.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnBackup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBackup.ForeColor = System.Drawing.Color.White;
            this.btnBackup.Location = new System.Drawing.Point(20, 40);
            this.btnBackup.Name = "btnBackup";
            this.btnBackup.Size = new System.Drawing.Size(150, 40);
            this.btnBackup.TabIndex = 0;
            this.btnBackup.Text = "Sao lưu";
            this.btnBackup.UseVisualStyleBackColor = false;
            this.btnBackup.Click += new System.EventHandler(this.btnBackup_Click);
            // 
            // UCCaiDat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.grpBackup);
            this.Controls.Add(this.grpReminder);
            this.Controls.Add(this.grpPassword);
            this.Name = "UCCaiDat";
            this.Size = new System.Drawing.Size(900, 600);
            this.grpPassword.ResumeLayout(false);
            this.grpPassword.PerformLayout();
            this.grpReminder.ResumeLayout(false);
            this.grpReminder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numReminderDays)).EndInit();
            this.grpBackup.ResumeLayout(false);
            this.grpBackup.PerformLayout();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.GroupBox grpPassword;
        private System.Windows.Forms.Button btnChangePassword;
        private System.Windows.Forms.TextBox txtConfirmPassword;
        private System.Windows.Forms.Label lblConfirmPassword;
        private System.Windows.Forms.TextBox txtNewPassword;
        private System.Windows.Forms.Label lblNewPassword;
        private System.Windows.Forms.TextBox txtOldPassword;
        private System.Windows.Forms.Label lblOldPassword;
        private System.Windows.Forms.GroupBox grpReminder;
        private System.Windows.Forms.Button btnSaveReminder;
        private System.Windows.Forms.Label lblDays;
        private System.Windows.Forms.NumericUpDown numReminderDays;
        private System.Windows.Forms.Label lblReminderDays;
        private System.Windows.Forms.GroupBox grpBackup;
        private System.Windows.Forms.Label lblLastBackup;
        private System.Windows.Forms.Button btnRestore;
        private System.Windows.Forms.Button btnBackup;
    }
}
