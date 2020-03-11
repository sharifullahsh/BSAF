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

       
    }
}
