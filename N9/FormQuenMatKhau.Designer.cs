namespace N9
{
    partial class FormQuenMatKhau
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormQuenMatKhau));
            this.pnlForgotPass = new System.Windows.Forms.Panel();
            this.btnSendEmail = new System.Windows.Forms.Button();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblForgotPass = new System.Windows.Forms.Label();
            this.picForgotPass = new System.Windows.Forms.PictureBox();
            this.pnlAfter = new System.Windows.Forms.Panel();
            this.elipseControl1 = new N9.ElipseControl();
            this.elipseControl2 = new N9.ElipseControl();
            this.elipseControl3 = new N9.ElipseControl();
            this.elipseControl4 = new N9.ElipseControl();
            this.pnlForgotPass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picForgotPass)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlForgotPass
            // 
            this.pnlForgotPass.BackColor = System.Drawing.SystemColors.Control;
            this.pnlForgotPass.Controls.Add(this.btnSendEmail);
            this.pnlForgotPass.Controls.Add(this.txtEmail);
            this.pnlForgotPass.Controls.Add(this.lblEmail);
            this.pnlForgotPass.Controls.Add(this.lblForgotPass);
            this.pnlForgotPass.Controls.Add(this.picForgotPass);
            this.pnlForgotPass.Location = new System.Drawing.Point(400, 37);
            this.pnlForgotPass.Name = "pnlForgotPass";
            this.pnlForgotPass.Size = new System.Drawing.Size(440, 638);
            this.pnlForgotPass.TabIndex = 0;
            // 
            // btnSendEmail
            // 
            this.btnSendEmail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(58)))), ((int)(((byte)(58)))));
            this.btnSendEmail.FlatAppearance.BorderSize = 0;
            this.btnSendEmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSendEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.btnSendEmail.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.btnSendEmail.Location = new System.Drawing.Point(90, 357);
            this.btnSendEmail.Name = "btnSendEmail";
            this.btnSendEmail.Size = new System.Drawing.Size(279, 46);
            this.btnSendEmail.TabIndex = 4;
            this.btnSendEmail.Text = "Gửi yêu cầu";
            this.btnSendEmail.UseVisualStyleBackColor = false;
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Segoe UI", 13.8F);
            this.txtEmail.Location = new System.Drawing.Point(52, 267);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(369, 38);
            this.txtEmail.TabIndex = 3;
            // 
            // lblEmail
            // 
            this.lblEmail.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.lblEmail.Location = new System.Drawing.Point(47, 222);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(374, 25);
            this.lblEmail.TabIndex = 2;
            this.lblEmail.Text = "Email";
            // 
            // lblForgotPass
            // 
            this.lblForgotPass.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Bold);
            this.lblForgotPass.Location = new System.Drawing.Point(109, 116);
            this.lblForgotPass.Name = "lblForgotPass";
            this.lblForgotPass.Size = new System.Drawing.Size(296, 45);
            this.lblForgotPass.TabIndex = 1;
            this.lblForgotPass.Text = "Quên mật khẩu";
            // 
            // picForgotPass
            // 
            this.picForgotPass.Image = ((System.Drawing.Image)(resources.GetObject("picForgotPass.Image")));
            this.picForgotPass.Location = new System.Drawing.Point(21, 111);
            this.picForgotPass.Name = "picForgotPass";
            this.picForgotPass.Size = new System.Drawing.Size(100, 50);
            this.picForgotPass.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picForgotPass.TabIndex = 0;
            this.picForgotPass.TabStop = false;
            // 
            // pnlAfter
            // 
            this.pnlAfter.BackColor = System.Drawing.Color.LightGray;
            this.pnlAfter.Location = new System.Drawing.Point(386, 29);
            this.pnlAfter.Name = "pnlAfter";
            this.pnlAfter.Size = new System.Drawing.Size(469, 662);
            this.pnlAfter.TabIndex = 1;
            // 
            // elipseControl1
            // 
            this.elipseControl1.CornerRadius = 30;
            this.elipseControl1.TargetControl = this.pnlForgotPass;
            // 
            // elipseControl2
            // 
            this.elipseControl2.CornerRadius = 30;
            this.elipseControl2.TargetControl = this.pnlAfter;
            // 
            // elipseControl3
            // 
            this.elipseControl3.CornerRadius = 20;
            this.elipseControl3.TargetControl = this.txtEmail;
            // 
            // elipseControl4
            // 
            this.elipseControl4.CornerRadius = 30;
            this.elipseControl4.TargetControl = this.btnSendEmail;
            // 
            // FormQuenMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1182, 703);
            this.Controls.Add(this.pnlForgotPass);
            this.Controls.Add(this.pnlAfter);
            this.MaximumSize = new System.Drawing.Size(1200, 750);
            this.MinimumSize = new System.Drawing.Size(1200, 750);
            this.Name = "FormQuenMatKhau";
            this.Text = "Quên mật khẩu";
            this.pnlForgotPass.ResumeLayout(false);
            this.pnlForgotPass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picForgotPass)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlForgotPass;
        private System.Windows.Forms.Panel pnlAfter;
        private System.Windows.Forms.PictureBox picForgotPass;
        private System.Windows.Forms.Label lblForgotPass;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Button btnSendEmail;
        private ElipseControl elipseControl1;
        private ElipseControl elipseControl2;
        private ElipseControl elipseControl3;
        private ElipseControl elipseControl4;
    }
}