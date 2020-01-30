using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MotorRenewals
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();
        }

        private void btnGetPolicyData_Click(object sender, EventArgs e)
        {
            MotorRenewal motorRenewal = new MotorRenewal();
            grdPolicyData.DataSource = motorRenewal.GetPolicyData(txtPolicyString.Text);
            grdPolicyData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            grdRenewalData.DataSource = motorRenewal.GetRenewalData(txtPolicyString.Text);
            grdRenewalData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            grdPolicyData.ReadOnly = true;
            grdRenewalData.ReadOnly = true;
        }

        private void btnRenewPolicy_Click(object sender, EventArgs e)
        {
            MotorRenewal motorRenewal;
            string DocumentCode;

            if (grdRenewalData.Rows.Count == 0)
            {
                for (int i = 0; i < grdPolicyData.Rows.Count; i++)
                {
                    DocumentCode = grdPolicyData.Rows[i].Cells[0].Value.ToString().Substring(0, 2);

                    motorRenewal = new MotorRenewal();
                    motorRenewal.GenerateRenewalNotice(grdPolicyData.Rows[i].Cells[0].Value.ToString());

                    grdRenewalData.DataSource = motorRenewal.GetRenewalData(txtPolicyString.Text);
                }

            }

        }

        private void btnRenewCertificate_Click(object sender, EventArgs e)
        {
            MotorRenewal motorRenewal;
            string RnewAssortedCode;
            string CertAssortedCode;
            string DocumentCode;
            string PolicyAssortedCode;

            for (int i = 0; i < grdRenewalData.Rows.Count; i++)
            {
                CertAssortedCode = grdRenewalData.Rows[i].Cells[2].Value.ToString();
                RnewAssortedCode = grdRenewalData.Rows[i].Cells[1].Value.ToString();
                PolicyAssortedCode = grdRenewalData.Rows[i].Cells[5].Value.ToString();
                DocumentCode = grdRenewalData.Rows[i].Cells[0].Value.ToString().Substring(0, 2);

                if (CertAssortedCode == "" && DocumentCode == "07" && PolicyAssortedCode != "")
                {
                    motorRenewal = new MotorRenewal();
                    motorRenewal.RenewCertificate(RnewAssortedCode);

                }
            }

            motorRenewal = new MotorRenewal();
            grdRenewalData.DataSource = motorRenewal.GetRenewalData(txtPolicyString.Text);
            grdRenewalData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

        }

        private void btnAssociatePolicy_Click(object sender, EventArgs e)
        {
            if (grdRenewalData.Rows.Count > 0)
            {
                MotorRenewal motorRenewal = new MotorRenewal();

                motorRenewal.AssociateWithMastherPolicy(txtPolicyString.Text);
                grdRenewalData.DataSource = motorRenewal.GetRenewalData(txtPolicyString.Text);
                grdRenewalData.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            }
        }
        
        private void RadForm1_Load(object sender, EventArgs e)
        {
            grdRenewalData.ReadOnly = true;
            grdPolicyData.ReadOnly = true;
            this.MaximizeBox = false;
            this.StartPosition = FormStartPosition.CenterScreen;
        }
    }
}
