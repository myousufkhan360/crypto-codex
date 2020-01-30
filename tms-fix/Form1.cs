using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;
using TmsFix.myCode;

namespace TmsFix
{
    public partial class frmTmsFix : Form
    {
        public frmTmsFix()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            TmsHeader tmsHeader = new TmsHeader();
            grdTmsHeader.DataSource = tmsHeader.GeTmsHeaderData(txtEndtNo.Text);
            grdTmsHeader.AutoResizeColumns();
            grdTmsHeader.ReadOnly = true;

        }

        private void grdTmsHeader_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GetContributionData();
        }

        private void grdTmsContribution_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            lblGrdIndex.Text = grdTmsContribution.CurrentRow.Index.ToString();
            txtOrderNo.Text = grdTmsContribution.CurrentRow.Cells[1].Value.ToString();
            txtAmount.Text = grdTmsContribution.CurrentRow.Cells[5].Value.ToString();
            txtPrevAmount.Text = grdTmsContribution.CurrentRow.Cells[6].Value.ToString();
            txtPrevAmount.ReadOnly = true;
            txtOrderNo.ReadOnly = true;

            if (lblPostingStatus.Text == "POSTED")
            {
                txtAmount.ReadOnly = true;
            }
            else
            {
                txtAmount.ReadOnly = false;
                txtAmount.Focus();
            }
            
            
        }

        private void btnIUpdate_Click(object sender, EventArgs e)
        {
            if (lblPostingStatus.Text != "POSTED")
            {
                grdTmsContribution.Rows[Convert.ToInt32(lblGrdIndex.Text)].Cells[5].Value = txtAmount.Text;
                grdTmsContribution.Rows[Convert.ToInt32(lblGrdIndex.Text)].Cells[6].Value = txtPrevAmount.Text;
                grdTmsContribution.Rows[Convert.ToInt32(lblGrdIndex.Text)].Cells[7].Value =
                    Convert.ToDecimal(txtAmount.Text) - Convert.ToDecimal(txtPrevAmount.Text);
                RecalculateValues();
                CommitContributionData();
            }
            else
            {
                
                MessageBox.Show("You cannot change in Posted transactions");
            }


        }

        private void grdTmsHeader_SelectionChanged(object sender, EventArgs e)
        {
            GetContributionData();
        }

        private void GetContributionData()
        {
            if (grdTmsHeader.Rows.Count > 0)
            {
                string assortedCode = grdTmsHeader.CurrentRow.Cells[0].Value.ToString();
                TmsContribution tmsContribution = new TmsContribution();
                grdTmsContribution.DataSource = tmsContribution.GeTmsContributionData(assortedCode);
                grdTmsContribution.AutoResizeColumns();
                grdTmsContribution.Columns[0].Visible = false;
                grdTmsContribution.Columns[8].Visible = false;
                grdTmsContribution.ReadOnly = true;
                grdTmsContribution.Columns[4].DefaultCellStyle.Format = "N2";
                grdTmsContribution.Columns[5].DefaultCellStyle.Format = "N2";
                grdTmsContribution.Columns[6].DefaultCellStyle.Format = "N2";
                grdTmsContribution.Columns[7].DefaultCellStyle.Format = "N2";
                grdTmsContribution.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTmsContribution.Columns[5].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTmsContribution.Columns[6].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                grdTmsContribution.Columns[7].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                lblPostingStatus.Text = grdTmsHeader.CurrentRow.Cells[5].Value.ToString();

                if (lblPostingStatus.Text == "POSTED")
                {
                    txtAmount.ReadOnly = true;
                    btnIUpdate.Enabled = false;
                }
                else
                {
                    txtAmount.ReadOnly = false;
                    btnIUpdate.Enabled = true;
                }
            }
        }

        private void RecalculateValues()
        {
            decimal totalAmount = 0;
            decimal previousTotalAmount;
            decimal differTotalAmount;
            int lastCalcRowIndex=0;

            if (grdTmsContribution.Rows.Count == 13)
            {
                lastCalcRowIndex = 10;
            }
            else if (grdTmsContribution.Rows.Count == 14)
            {
                lastCalcRowIndex = 11;
            }


            for (int i = 3; i < lastCalcRowIndex; i++)
            {
                totalAmount += (decimal) grdTmsContribution.Rows[i].Cells[5].Value;
            }

            

            if (grdTmsContribution.Rows.Count == 13)
            {
                previousTotalAmount = (decimal) grdTmsContribution.Rows[10].Cells[6].Value;
                differTotalAmount = (decimal)grdTmsContribution.Rows[10].Cells[7].Value;

                differTotalAmount = totalAmount - previousTotalAmount;

                grdTmsContribution.Rows[10].Cells[5].Value = totalAmount;
                grdTmsContribution.Rows[12].Cells[5].Value = totalAmount;

                grdTmsContribution.Rows[10].Cells[7].Value = differTotalAmount;
                grdTmsContribution.Rows[12].Cells[7].Value = differTotalAmount;

            }
            else if(grdTmsContribution.Rows.Count == 14)
            {
                previousTotalAmount = (decimal)grdTmsContribution.Rows[11].Cells[6].Value;
                differTotalAmount = (decimal)grdTmsContribution.Rows[11].Cells[7].Value;

                differTotalAmount = totalAmount - previousTotalAmount;

                grdTmsContribution.Rows[11].Cells[5].Value = totalAmount;
                grdTmsContribution.Rows[13].Cells[5].Value = totalAmount;

                grdTmsContribution.Rows[11].Cells[7].Value = differTotalAmount;
                grdTmsContribution.Rows[13].Cells[7].Value = differTotalAmount;

            }
        }

        private void CommitContributionData()
        {
            decimal amount;
            string txnSysId;
            TmsContribution tmsContribution = new TmsContribution();
            int gridRows=0;

            if (grdTmsContribution.Rows.Count == 13)
            {
                gridRows = 13;
            }
            else if (grdTmsContribution.Rows.Count == 14)
            {
                gridRows = 14;
            }

            for (int i = 3; i < gridRows; i++)
            {
                txnSysId = grdTmsContribution.Rows[i].Cells[8].Value.ToString();
                amount = (decimal) grdTmsContribution.Rows[i].Cells[5].Value;
                tmsContribution.CommitContributionData(txnSysId, amount);   
            }
        }
    }
}
