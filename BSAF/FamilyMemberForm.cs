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
    public partial class FamilyMemberForm : Form
    {
        public FamilyMemberForm()
        {
            InitializeComponent();
        }

        private void btnCancelMember_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
        }

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            this.Close();
            //this.Dispose();
        }
    }
}
