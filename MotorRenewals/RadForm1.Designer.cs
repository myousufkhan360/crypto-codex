namespace MotorRenewals
{
    partial class RadForm1
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtPolicyString = new System.Windows.Forms.TextBox();
            this.btnGetPolicyData = new System.Windows.Forms.Button();
            this.grdPolicyData = new System.Windows.Forms.DataGridView();
            this.btnRenewPolicy = new System.Windows.Forms.Button();
            this.grdRenewalData = new System.Windows.Forms.DataGridView();
            this.btnRenewCertificate = new System.Windows.Forms.Button();
            this.btnAssociatePolicy = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdPolicyData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRenewalData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Policy String";
            // 
            // txtPolicyString
            // 
            this.txtPolicyString.Location = new System.Drawing.Point(90, 13);
            this.txtPolicyString.Name = "txtPolicyString";
            this.txtPolicyString.Size = new System.Drawing.Size(180, 20);
            this.txtPolicyString.TabIndex = 1;
            // 
            // btnGetPolicyData
            // 
            this.btnGetPolicyData.Location = new System.Drawing.Point(287, 9);
            this.btnGetPolicyData.Name = "btnGetPolicyData";
            this.btnGetPolicyData.Size = new System.Drawing.Size(97, 23);
            this.btnGetPolicyData.TabIndex = 2;
            this.btnGetPolicyData.Text = "Get Policy Data";
            this.btnGetPolicyData.UseVisualStyleBackColor = true;
            this.btnGetPolicyData.Click += new System.EventHandler(this.btnGetPolicyData_Click);
            // 
            // grdPolicyData
            // 
            this.grdPolicyData.AllowUserToAddRows = false;
            this.grdPolicyData.AllowUserToDeleteRows = false;
            this.grdPolicyData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPolicyData.Location = new System.Drawing.Point(16, 39);
            this.grdPolicyData.Name = "grdPolicyData";
            this.grdPolicyData.ReadOnly = true;
            this.grdPolicyData.Size = new System.Drawing.Size(650, 186);
            this.grdPolicyData.TabIndex = 3;
            // 
            // btnRenewPolicy
            // 
            this.btnRenewPolicy.Location = new System.Drawing.Point(390, 9);
            this.btnRenewPolicy.Name = "btnRenewPolicy";
            this.btnRenewPolicy.Size = new System.Drawing.Size(97, 23);
            this.btnRenewPolicy.TabIndex = 4;
            this.btnRenewPolicy.Text = "Renewal Notice";
            this.btnRenewPolicy.UseVisualStyleBackColor = true;
            this.btnRenewPolicy.Click += new System.EventHandler(this.btnRenewPolicy_Click);
            // 
            // grdRenewalData
            // 
            this.grdRenewalData.AllowUserToAddRows = false;
            this.grdRenewalData.AllowUserToDeleteRows = false;
            this.grdRenewalData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdRenewalData.Location = new System.Drawing.Point(16, 240);
            this.grdRenewalData.Name = "grdRenewalData";
            this.grdRenewalData.ReadOnly = true;
            this.grdRenewalData.Size = new System.Drawing.Size(650, 186);
            this.grdRenewalData.TabIndex = 5;
            // 
            // btnRenewCertificate
            // 
            this.btnRenewCertificate.Location = new System.Drawing.Point(16, 432);
            this.btnRenewCertificate.Name = "btnRenewCertificate";
            this.btnRenewCertificate.Size = new System.Drawing.Size(97, 23);
            this.btnRenewCertificate.TabIndex = 6;
            this.btnRenewCertificate.Text = "Renew Certificates";
            this.btnRenewCertificate.UseVisualStyleBackColor = true;
            this.btnRenewCertificate.Click += new System.EventHandler(this.btnRenewCertificate_Click);
            // 
            // btnAssociatePolicy
            // 
            this.btnAssociatePolicy.Location = new System.Drawing.Point(493, 9);
            this.btnAssociatePolicy.Name = "btnAssociatePolicy";
            this.btnAssociatePolicy.Size = new System.Drawing.Size(97, 23);
            this.btnAssociatePolicy.TabIndex = 7;
            this.btnAssociatePolicy.Text = "Associate Policy";
            this.btnAssociatePolicy.UseVisualStyleBackColor = true;
            this.btnAssociatePolicy.Click += new System.EventHandler(this.btnAssociatePolicy_Click);
            // 
            // RadForm1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(678, 465);
            this.Controls.Add(this.btnAssociatePolicy);
            this.Controls.Add(this.btnRenewCertificate);
            this.Controls.Add(this.grdRenewalData);
            this.Controls.Add(this.btnRenewPolicy);
            this.Controls.Add(this.grdPolicyData);
            this.Controls.Add(this.btnGetPolicyData);
            this.Controls.Add(this.txtPolicyString);
            this.Controls.Add(this.label1);
            this.Name = "RadForm1";
            // 
            // 
            // 
            this.RootElement.ApplyShapeToControl = true;
            this.Text = ":: Motor Policy Renewal Utility ::";
            this.Load += new System.EventHandler(this.RadForm1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPolicyData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdRenewalData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtPolicyString;
        private System.Windows.Forms.Button btnGetPolicyData;
        private System.Windows.Forms.DataGridView grdPolicyData;
        private System.Windows.Forms.Button btnRenewPolicy;
        private System.Windows.Forms.DataGridView grdRenewalData;
        private System.Windows.Forms.Button btnRenewCertificate;
        private System.Windows.Forms.Button btnAssociatePolicy;
    }
}