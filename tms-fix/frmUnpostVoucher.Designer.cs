namespace TmsFix
{
    partial class frmUnpostVoucher
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
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblEndtNo = new System.Windows.Forms.Label();
            this.txtEndtNo = new System.Windows.Forms.TextBox();
            this.grdTmsHeader = new System.Windows.Forms.DataGridView();
            this.ddlVoucherType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUnPost = new System.Windows.Forms.Button();
            this.lblSelectedVoucher = new System.Windows.Forms.Label();
            this.txtSelectedVoucher = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsHeader)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(506, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // lblEndtNo
            // 
            this.lblEndtNo.AutoSize = true;
            this.lblEndtNo.Location = new System.Drawing.Point(12, 9);
            this.lblEndtNo.Name = "lblEndtNo";
            this.lblEndtNo.Size = new System.Drawing.Size(54, 13);
            this.lblEndtNo.TabIndex = 4;
            this.lblEndtNo.Text = "Voucher#";
            // 
            // txtEndtNo
            // 
            this.txtEndtNo.Location = new System.Drawing.Point(94, 9);
            this.txtEndtNo.Name = "txtEndtNo";
            this.txtEndtNo.Size = new System.Drawing.Size(179, 20);
            this.txtEndtNo.TabIndex = 0;
            // 
            // grdTmsHeader
            // 
            this.grdTmsHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTmsHeader.Location = new System.Drawing.Point(12, 38);
            this.grdTmsHeader.Name = "grdTmsHeader";
            this.grdTmsHeader.Size = new System.Drawing.Size(674, 114);
            this.grdTmsHeader.TabIndex = 3;
            this.grdTmsHeader.DoubleClick += new System.EventHandler(this.GrdTmsHeader_DoubleClick);
            // 
            // ddlVoucherType
            // 
            this.ddlVoucherType.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.ddlVoucherType.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.ddlVoucherType.FormattingEnabled = true;
            this.ddlVoucherType.Location = new System.Drawing.Point(367, 11);
            this.ddlVoucherType.Name = "ddlVoucherType";
            this.ddlVoucherType.Size = new System.Drawing.Size(121, 21);
            this.ddlVoucherType.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Voucher Type:";
            // 
            // btnUnPost
            // 
            this.btnUnPost.Location = new System.Drawing.Point(536, 158);
            this.btnUnPost.Name = "btnUnPost";
            this.btnUnPost.Size = new System.Drawing.Size(96, 23);
            this.btnUnPost.TabIndex = 5;
            this.btnUnPost.Text = "UnPost Voucher";
            this.btnUnPost.UseVisualStyleBackColor = true;
            this.btnUnPost.Click += new System.EventHandler(this.BtnUnPost_Click);
            // 
            // lblSelectedVoucher
            // 
            this.lblSelectedVoucher.AutoSize = true;
            this.lblSelectedVoucher.Location = new System.Drawing.Point(12, 161);
            this.lblSelectedVoucher.Name = "lblSelectedVoucher";
            this.lblSelectedVoucher.Size = new System.Drawing.Size(92, 13);
            this.lblSelectedVoucher.TabIndex = 11;
            this.lblSelectedVoucher.Text = "Selected Voucher";
            // 
            // txtSelectedVoucher
            // 
            this.txtSelectedVoucher.Location = new System.Drawing.Point(110, 161);
            this.txtSelectedVoucher.Name = "txtSelectedVoucher";
            this.txtSelectedVoucher.ReadOnly = true;
            this.txtSelectedVoucher.Size = new System.Drawing.Size(420, 20);
            this.txtSelectedVoucher.TabIndex = 4;
            // 
            // frmUnpostVoucher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 201);
            this.Controls.Add(this.lblSelectedVoucher);
            this.Controls.Add(this.txtSelectedVoucher);
            this.Controls.Add(this.btnUnPost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ddlVoucherType);
            this.Controls.Add(this.grdTmsHeader);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEndtNo);
            this.Controls.Add(this.txtEndtNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MinimizeBox = false;
            this.Name = "frmUnpostVoucher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: Unpost Accounts Voucher::";
            this.Load += new System.EventHandler(this.FrmUnpostVoucher_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsHeader)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblEndtNo;
        private System.Windows.Forms.TextBox txtEndtNo;
        private System.Windows.Forms.DataGridView grdTmsHeader;
        private System.Windows.Forms.ComboBox ddlVoucherType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUnPost;
        private System.Windows.Forms.Label lblSelectedVoucher;
        private System.Windows.Forms.TextBox txtSelectedVoucher;
    }
}