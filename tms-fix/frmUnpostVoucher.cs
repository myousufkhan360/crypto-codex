using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TmsFix.myCode;

namespace TmsFix
{
    public partial class frmUnpostVoucher : Form
    {
        public frmUnpostVoucher()
        {
            InitializeComponent();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            if(!txtEndtNo.Text.Equals(null))
            {
                TmsAccountVoucher tmsAccountVoucher = new TmsAccountVoucher();
                DataTable tblVoucherType = tmsAccountVoucher.GetVoucherTypeList();
                grdTmsHeader.DataSource = tmsAccountVoucher.GetVoucherDetails(ddlVoucherType.SelectedValue.ToString(), txtEndtNo.Text);
                grdTmsHeader.ReadOnly = true;
            }
        }

        private void FrmUnpostVoucher_Load(object sender, EventArgs e)
        {
            FillDdl();
        }

        private void FillDdl()
        {
            TmsAccountVoucher tmsAccountVoucher = new TmsAccountVoucher();
            DataTable tblVoucherType = tmsAccountVoucher.GetVoucherTypeList();

            ddlVoucherType.DataSource = tblVoucherType;
            ddlVoucherType.DisplayMember = "V_TYPE";
            ddlVoucherType.ValueMember = "V_TYPE";
        }


        private void GrdTmsHeader_DoubleClick(object sender, EventArgs e)
        {
            string selectedVoucher = grdTmsHeader.CurrentRow.Cells[1].Value + " " + grdTmsHeader.CurrentRow.Cells[2].Value;
            txtSelectedVoucher.Text = selectedVoucher;
        }

        private void BtnUnPost_Click(object sender, EventArgs e)
        {
            if (!txtSelectedVoucher.Text.Equals(null))
            {
                TmsAccountVoucher tmsAccountVoucher = new TmsAccountVoucher();
                tmsAccountVoucher.UnpostVoucher(txtSelectedVoucher.Text);
                MessageBox.Show("Voucher has been unposted");
                BtnSearch_Click(sender, e);
            }
        }
    }
}
