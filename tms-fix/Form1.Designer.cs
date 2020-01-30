namespace TmsFix
{
    partial class frmTmsFix
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTmsFix));
            this.txtEndtNo = new System.Windows.Forms.TextBox();
            this.lblEndtNo = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.grdTmsHeader = new System.Windows.Forms.DataGridView();
            this.grdTmsContribution = new System.Windows.Forms.DataGridView();
            this.txtOrderNo = new System.Windows.Forms.TextBox();
            this.lblOrderNo = new System.Windows.Forms.Label();
            this.lblAmount = new System.Windows.Forms.Label();
            this.txtAmount = new System.Windows.Forms.TextBox();
            this.lblPreviousAmount = new System.Windows.Forms.Label();
            this.txtPrevAmount = new System.Windows.Forms.TextBox();
            this.btnIUpdate = new System.Windows.Forms.Button();
            this.lblGrdIndex = new System.Windows.Forms.Label();
            this.lblPostingStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsHeader)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsContribution)).BeginInit();
            this.SuspendLayout();
            // 
            // txtEndtNo
            // 
            this.txtEndtNo.Location = new System.Drawing.Point(95, 9);
            this.txtEndtNo.Name = "txtEndtNo";
            this.txtEndtNo.Size = new System.Drawing.Size(235, 23);
            this.txtEndtNo.TabIndex = 0;
            // 
            // lblEndtNo
            // 
            this.lblEndtNo.AutoSize = true;
            this.lblEndtNo.Location = new System.Drawing.Point(13, 9);
            this.lblEndtNo.Name = "lblEndtNo";
            this.lblEndtNo.Size = new System.Drawing.Size(76, 15);
            this.lblEndtNo.TabIndex = 1;
            this.lblEndtNo.Text = "Document #:";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(337, 9);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // grdTmsHeader
            // 
            this.grdTmsHeader.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTmsHeader.Location = new System.Drawing.Point(12, 38);
            this.grdTmsHeader.Name = "grdTmsHeader";
            this.grdTmsHeader.Size = new System.Drawing.Size(1054, 93);
            this.grdTmsHeader.TabIndex = 3;
            this.grdTmsHeader.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTmsHeader_CellClick);
            this.grdTmsHeader.SelectionChanged += new System.EventHandler(this.grdTmsHeader_SelectionChanged);
            // 
            // grdTmsContribution
            // 
            this.grdTmsContribution.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTmsContribution.Location = new System.Drawing.Point(12, 137);
            this.grdTmsContribution.Name = "grdTmsContribution";
            this.grdTmsContribution.Size = new System.Drawing.Size(816, 329);
            this.grdTmsContribution.TabIndex = 4;
            this.grdTmsContribution.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.grdTmsContribution_CellClick);
            // 
            // txtOrderNo
            // 
            this.txtOrderNo.Location = new System.Drawing.Point(923, 161);
            this.txtOrderNo.Name = "txtOrderNo";
            this.txtOrderNo.Size = new System.Drawing.Size(143, 23);
            this.txtOrderNo.TabIndex = 5;
            // 
            // lblOrderNo
            // 
            this.lblOrderNo.AutoSize = true;
            this.lblOrderNo.Location = new System.Drawing.Point(834, 164);
            this.lblOrderNo.Name = "lblOrderNo";
            this.lblOrderNo.Size = new System.Drawing.Size(56, 15);
            this.lblOrderNo.TabIndex = 6;
            this.lblOrderNo.Text = "OrderNo:";
            // 
            // lblAmount
            // 
            this.lblAmount.AutoSize = true;
            this.lblAmount.Location = new System.Drawing.Point(834, 193);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Size = new System.Drawing.Size(54, 15);
            this.lblAmount.TabIndex = 8;
            this.lblAmount.Text = "Amount:";
            // 
            // txtAmount
            // 
            this.txtAmount.Location = new System.Drawing.Point(923, 190);
            this.txtAmount.Name = "txtAmount";
            this.txtAmount.Size = new System.Drawing.Size(143, 23);
            this.txtAmount.TabIndex = 7;
            // 
            // lblPreviousAmount
            // 
            this.lblPreviousAmount.AutoSize = true;
            this.lblPreviousAmount.Location = new System.Drawing.Point(834, 222);
            this.lblPreviousAmount.Name = "lblPreviousAmount";
            this.lblPreviousAmount.Size = new System.Drawing.Size(83, 15);
            this.lblPreviousAmount.TabIndex = 10;
            this.lblPreviousAmount.Text = "Prev. Amount:";
            // 
            // txtPrevAmount
            // 
            this.txtPrevAmount.Location = new System.Drawing.Point(923, 219);
            this.txtPrevAmount.Name = "txtPrevAmount";
            this.txtPrevAmount.Size = new System.Drawing.Size(143, 23);
            this.txtPrevAmount.TabIndex = 9;
            // 
            // btnIUpdate
            // 
            this.btnIUpdate.Location = new System.Drawing.Point(991, 248);
            this.btnIUpdate.Name = "btnIUpdate";
            this.btnIUpdate.Size = new System.Drawing.Size(75, 25);
            this.btnIUpdate.TabIndex = 11;
            this.btnIUpdate.Text = "Update";
            this.btnIUpdate.UseVisualStyleBackColor = true;
            this.btnIUpdate.Click += new System.EventHandler(this.btnIUpdate_Click);
            // 
            // lblGrdIndex
            // 
            this.lblGrdIndex.AutoSize = true;
            this.lblGrdIndex.Location = new System.Drawing.Point(920, 136);
            this.lblGrdIndex.Name = "lblGrdIndex";
            this.lblGrdIndex.Size = new System.Drawing.Size(56, 15);
            this.lblGrdIndex.TabIndex = 12;
            this.lblGrdIndex.Text = "OrderNo:";
            this.lblGrdIndex.Visible = false;
            // 
            // lblPostingStatus
            // 
            this.lblPostingStatus.AutoSize = true;
            this.lblPostingStatus.Location = new System.Drawing.Point(834, 136);
            this.lblPostingStatus.Name = "lblPostingStatus";
            this.lblPostingStatus.Size = new System.Drawing.Size(82, 15);
            this.lblPostingStatus.TabIndex = 13;
            this.lblPostingStatus.Text = "PostingStatus:";
            // 
            // frmTmsFix
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1078, 478);
            this.Controls.Add(this.lblPostingStatus);
            this.Controls.Add(this.lblGrdIndex);
            this.Controls.Add(this.btnIUpdate);
            this.Controls.Add(this.lblPreviousAmount);
            this.Controls.Add(this.txtPrevAmount);
            this.Controls.Add(this.lblAmount);
            this.Controls.Add(this.txtAmount);
            this.Controls.Add(this.lblOrderNo);
            this.Controls.Add(this.txtOrderNo);
            this.Controls.Add(this.grdTmsContribution);
            this.Controls.Add(this.grdTmsHeader);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEndtNo);
            this.Controls.Add(this.txtEndtNo);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmTmsFix";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = ":: TMS Fix ::";
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsHeader)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTmsContribution)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtEndtNo;
        private System.Windows.Forms.Label lblEndtNo;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridView grdTmsHeader;
        private System.Windows.Forms.DataGridView grdTmsContribution;
        private System.Windows.Forms.TextBox txtOrderNo;
        private System.Windows.Forms.Label lblOrderNo;
        private System.Windows.Forms.Label lblAmount;
        private System.Windows.Forms.TextBox txtAmount;
        private System.Windows.Forms.Label lblPreviousAmount;
        private System.Windows.Forms.TextBox txtPrevAmount;
        private System.Windows.Forms.Button btnIUpdate;
        private System.Windows.Forms.Label lblGrdIndex;
        private System.Windows.Forms.Label lblPostingStatus;
    }
}

