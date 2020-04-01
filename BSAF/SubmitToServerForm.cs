using BSAF.Entity;
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
    public partial class SubmitToServerForm : Form
    {
        dbContext db = new dbContext();
        public SubmitToServerForm()
        {
            InitializeComponent();
        }

        private void SubmitToServerForm_Load(object sender, EventArgs e)
        {
            var beneficiares = (from b in db.Beneficiaries
                                join i in db.Individuals
                                on b.BeneficiaryID equals i.BeneficiaryID into individuals
                                where b.IsActive == true && b.IsSubmitted == false
                                select new { b.BeneficiaryID, b.ScreeningDate, b.BeneficiaryType, b.ReturnStatus, FamilyMembers = individuals.ToList() }).ToList();

            var unSubmittedBeneficiary = beneficiares.Select(b => new {
                b.BeneficiaryID,
                b.ScreeningDate,
                b.BeneficiaryType,
                ReturnStatus = (db.LookupValues.Where(l => l.ValueCode == b.ReturnStatus).Select(l => l.EnName).FirstOrDefault()),
                Name = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.Name).FirstOrDefault(),
                FName = b.FamilyMembers.Where(m => m.RelationshipCode == "HH" || m.RelationshipCode == "HSelf").Select(m => m.FName).FirstOrDefault(),
            }).ToList();

            //Clear listview first
            lvBeneficiaries.Items.Clear();
            foreach (var be in unSubmittedBeneficiary)
            {
                ListViewItem lvi = new ListViewItem(be.BeneficiaryID.ToString());
                lvi.SubItems.Add(be.Name);
                lvi.SubItems.Add(be.FName);
                lvi.SubItems.Add(DateTime.Parse(be.ScreeningDate.ToString()).ToString("MMM dd yyyy"));
                lvi.SubItems.Add(be.ReturnStatus);
                lvi.SubItems.Add(be.BeneficiaryType);
                lvBeneficiaries.Items.Add(lvi);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            var beneficiary = db.Beneficiaries.Where(b => b.IsSubmitted == false);
        }
    }
}
