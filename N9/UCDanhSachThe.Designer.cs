namespace N9
{
    partial class UCDanhSachThe
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.dgvCards = new System.Windows.Forms.DataGridView();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.numDueDayOffset = new System.Windows.Forms.NumericUpDown();
            this.lblDueDayOffset = new System.Windows.Forms.Label();
            this.numStatementDay = new System.Windows.Forms.NumericUpDown();
            this.lblStatementDay = new System.Windows.Forms.Label();
            this.txtCreditLimit = new System.Windows.Forms.TextBox();
            this.lblCreditLimit = new System.Windows.Forms.Label();
            this.txtLast4Digits = new System.Windows.Forms.TextBox();
            this.lblLast4Digits = new System.Windows.Forms.Label();
            this.cboCardType = new System.Windows.Forms.ComboBox();
            this.lblCardType = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.lblBankName = new System.Windows.Forms.Label();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.txtCardId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDueDayOffset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStatementDay)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvCards
            // 
            this.dgvCards.AllowUserToAddRows = false;
            this.dgvCards.AllowUserToDeleteRows = false;
            this.dgvCards.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCards.BackgroundColor = System.Drawing.Color.White;
            this.dgvCards.Location = new System.Drawing.Point(20, 60);
            this.dgvCards.MultiSelect = false;
            this.dgvCards.Name = "dgvCards";
            this.dgvCards.ReadOnly = true;
            this.dgvCards.RowHeadersWidth = 51;
            this.dgvCards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCards.Size = new System.Drawing.Size(550, 500);
            this.dgvCards.TabIndex = 0;
            // 
            // pnlButtons
            // 
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Location = new System.Drawing.Point(20, 10);
            this.pnlButtons.Name = "pnlButtons";
            this.pnlButtons.Size = new System.Drawing.Size(550, 45);
            this.pnlButtons.TabIndex = 1;
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(244)))), ((int)(((byte)(67)))), ((int)(((byte)(54)))));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(220, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(100, 35);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(152)))), ((int)(((byte)(0)))));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(110, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(100, 35);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "Sửa";
            this.btnEdit.UseVisualStyleBackColor = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(175)))), ((int)(((byte)(80)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(0, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(100, 35);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "Thêm mới";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // pnlForm
            // 
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(245)))));
            this.pnlForm.Controls.Add(this.btnCancel);
            this.pnlForm.Controls.Add(this.btnSave);
            this.pnlForm.Controls.Add(this.chkActive);
            this.pnlForm.Controls.Add(this.numDueDayOffset);
            this.pnlForm.Controls.Add(this.lblDueDayOffset);
            this.pnlForm.Controls.Add(this.numStatementDay);
            this.pnlForm.Controls.Add(this.lblStatementDay);
            this.pnlForm.Controls.Add(this.txtCreditLimit);
            this.pnlForm.Controls.Add(this.lblCreditLimit);
            this.pnlForm.Controls.Add(this.txtLast4Digits);
            this.pnlForm.Controls.Add(this.lblLast4Digits);
            this.pnlForm.Controls.Add(this.cboCardType);
            this.pnlForm.Controls.Add(this.lblCardType);
            this.pnlForm.Controls.Add(this.txtBankName);
            this.pnlForm.Controls.Add(this.lblBankName);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Controls.Add(this.txtCardId);
            this.pnlForm.Location = new System.Drawing.Point(590, 10);
            this.pnlForm.Name = "pnlForm";
            this.pnlForm.Size = new System.Drawing.Size(300, 550);
            this.pnlForm.TabIndex = 2;
            this.pnlForm.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(160, 490);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 35);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "Hủy";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(40, 490);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 35);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Lưu";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chkActive.Location = new System.Drawing.Point(40, 440);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(127, 27);
            this.chkActive.TabIndex = 14;
            this.chkActive.Text = "Đang hoạt động";
            // 
            // numDueDayOffset
            // 
            this.numDueDayOffset.Location = new System.Drawing.Point(40, 400);
            this.numDueDayOffset.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            this.numDueDayOffset.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numDueDayOffset.Name = "numDueDayOffset";
            this.numDueDayOffset.Size = new System.Drawing.Size(220, 22);
            this.numDueDayOffset.TabIndex = 13;
            this.numDueDayOffset.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblDueDayOffset
            // 
            this.lblDueDayOffset.AutoSize = true;
            this.lblDueDayOffset.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblDueDayOffset.Location = new System.Drawing.Point(36, 374);
            this.lblDueDayOffset.Name = "lblDueDayOffset";
            this.lblDueDayOffset.Size = new System.Drawing.Size(195, 23);
            this.lblDueDayOffset.TabIndex = 12;
            this.lblDueDayOffset.Text = "Số ngày sau sao kê (hạn)";
            // 
            // numStatementDay
            // 
            this.numStatementDay.Location = new System.Drawing.Point(40, 340);
            this.numStatementDay.Maximum = new decimal(new int[] { 28, 0, 0, 0 });
            this.numStatementDay.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            this.numStatementDay.Name = "numStatementDay";
            this.numStatementDay.Size = new System.Drawing.Size(220, 22);
            this.numStatementDay.TabIndex = 11;
            this.numStatementDay.Value = new decimal(new int[] { 15, 0, 0, 0 });
            // 
            // lblStatementDay
            // 
            this.lblStatementDay.AutoSize = true;
            this.lblStatementDay.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblStatementDay.Location = new System.Drawing.Point(36, 314);
            this.lblStatementDay.Name = "lblStatementDay";
            this.lblStatementDay.Size = new System.Drawing.Size(127, 23);
            this.lblStatementDay.TabIndex = 10;
            this.lblStatementDay.Text = "Ngày chốt sao kê";
            // 
            // txtCreditLimit
            // 
            this.txtCreditLimit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtCreditLimit.Location = new System.Drawing.Point(40, 280);
            this.txtCreditLimit.Name = "txtCreditLimit";
            this.txtCreditLimit.Size = new System.Drawing.Size(220, 30);
            this.txtCreditLimit.TabIndex = 9;
            // 
            // lblCreditLimit
            // 
            this.lblCreditLimit.AutoSize = true;
            this.lblCreditLimit.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCreditLimit.Location = new System.Drawing.Point(36, 254);
            this.lblCreditLimit.Name = "lblCreditLimit";
            this.lblCreditLimit.Size = new System.Drawing.Size(76, 23);
            this.lblCreditLimit.TabIndex = 8;
            this.lblCreditLimit.Text = "Hạn mức";
            // 
            // txtLast4Digits
            // 
            this.txtLast4Digits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtLast4Digits.Location = new System.Drawing.Point(40, 220);
            this.txtLast4Digits.MaxLength = 4;
            this.txtLast4Digits.Name = "txtLast4Digits";
            this.txtLast4Digits.Size = new System.Drawing.Size(220, 30);
            this.txtLast4Digits.TabIndex = 7;
            // 
            // lblLast4Digits
            // 
            this.lblLast4Digits.AutoSize = true;
            this.lblLast4Digits.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblLast4Digits.Location = new System.Drawing.Point(36, 194);
            this.lblLast4Digits.Name = "lblLast4Digits";
            this.lblLast4Digits.Size = new System.Drawing.Size(79, 23);
            this.lblLast4Digits.TabIndex = 6;
            this.lblLast4Digits.Text = "4 số cuối";
            // 
            // cboCardType
            // 
            this.cboCardType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCardType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboCardType.Items.AddRange(new object[] { "Visa", "MasterCard", "JCB", "Amex" });
            this.cboCardType.Location = new System.Drawing.Point(40, 160);
            this.cboCardType.Name = "cboCardType";
            this.cboCardType.Size = new System.Drawing.Size(220, 31);
            this.cboCardType.TabIndex = 5;
            // 
            // lblCardType
            // 
            this.lblCardType.AutoSize = true;
            this.lblCardType.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblCardType.Location = new System.Drawing.Point(36, 134);
            this.lblCardType.Name = "lblCardType";
            this.lblCardType.Size = new System.Drawing.Size(68, 23);
            this.lblCardType.TabIndex = 4;
            this.lblCardType.Text = "Loại thẻ";
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBankName.Location = new System.Drawing.Point(40, 100);
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(220, 30);
            this.txtBankName.TabIndex = 3;
            // 
            // lblBankName
            // 
            this.lblBankName.AutoSize = true;
            this.lblBankName.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblBankName.Location = new System.Drawing.Point(36, 74);
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Size = new System.Drawing.Size(103, 23);
            this.lblBankName.TabIndex = 2;
            this.lblBankName.Text = "Tên ngân hàng";
            // 
            // lblFormTitle
            // 
            this.lblFormTitle.AutoSize = true;
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.Location = new System.Drawing.Point(35, 20);
            this.lblFormTitle.Name = "lblFormTitle";
            this.lblFormTitle.Size = new System.Drawing.Size(161, 32);
            this.lblFormTitle.TabIndex = 1;
            this.lblFormTitle.Text = "Thêm thẻ mới";
            // 
            // txtCardId
            // 
            this.txtCardId.Location = new System.Drawing.Point(40, 55);
            this.txtCardId.Name = "txtCardId";
            this.txtCardId.Size = new System.Drawing.Size(10, 22);
            this.txtCardId.TabIndex = 0;
            this.txtCardId.Visible = false;
            // 
            // UCDanhSachThe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlButtons);
            this.Controls.Add(this.dgvCards);
            this.Name = "UCDanhSachThe";
            this.Size = new System.Drawing.Size(900, 600);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCards)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDueDayOffset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numStatementDay)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataGridView dgvCards;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.TextBox txtCardId;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label lblBankName;
        private System.Windows.Forms.ComboBox cboCardType;
        private System.Windows.Forms.Label lblCardType;
        private System.Windows.Forms.TextBox txtLast4Digits;
        private System.Windows.Forms.Label lblLast4Digits;
        private System.Windows.Forms.TextBox txtCreditLimit;
        private System.Windows.Forms.Label lblCreditLimit;
        private System.Windows.Forms.NumericUpDown numStatementDay;
        private System.Windows.Forms.Label lblStatementDay;
        private System.Windows.Forms.NumericUpDown numDueDayOffset;
        private System.Windows.Forms.Label lblDueDayOffset;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}
