using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BSAF
{
    public partial class BeneficiaryForm : Form
    {
        public BeneficiaryForm()
        {
            InitializeComponent();
        }

        private void lnkAddFamilyMember_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FamilyMemberForm frm = new FamilyMemberForm();
            frm.ShowDialog();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnProfileNext_Click(object sender, EventArgs e)
        {

        }

        private void chkReturnReasonOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkReturnReasonOther.Checked)
            {
                this.txtReturnReasonOther.Visible = true;
                this.lblReturnReasonOther.Visible = true;
            }
            else
            {
                this.txtReturnReasonOther.Visible = false;
                this.lblReturnReasonOther.Visible = false;
            }
        }

        private void chkBroughtOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkBroughtOther.Checked)
            {
                this.txtItemBroughtOther.Visible = true;
                this.lblItemBroughtIOther.Visible = true;
            }
            else
            {
                this.txtItemBroughtOther.Visible = false;
                this.lblItemBroughtIOther.Visible = false;
            }
        }
    }
}
