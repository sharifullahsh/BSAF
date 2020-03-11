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
    public partial class BSAFMainMDIForm : Form
    {
        public BSAFMainMDIForm()
        {
            InitializeComponent();
        }

        private void BSAFMainMDIForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.Owner != null)
            {
                this.Owner.Dispose();
            }
        }
        
        private void AddBeneficiaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BeneficiaryForm bForm = new BeneficiaryForm
            {
                MdiParent = this
            };
            bForm.Show();
        }

        private void SearchBenefaciaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SearchBeneficiary bForm = new SearchBeneficiary();
            bForm.MdiParent = this;
            bForm.Show();
        }
    }
}
