using BSAF.Controller;
using BSAF.Entity;
using BSAF.Helper;
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
            this.FillBeneficiaryListView();
        }
        private void FillBeneficiaryListView()
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
            this.lblSubmitting.Text = "";
            var beneficiariesList = db.Beneficiaries.Where(b => b.IsActive == true && b.IsSubmitted == false).Select(b=>b.BeneficiaryID).ToList();
            //if (!ConnectionController.IsConnectedToInternet()) {
            //    MessageBox.Show("You are not connected to internet please check your connection and try again.");
            //    return;
            //}
            if (string.IsNullOrWhiteSpace(UserInfo.token))
            {
                MessageBox.Show("Your are not loged in, please close the application and login to submit.");
            }
            foreach (var benefID in beneficiariesList)
            {
                
               var benefRecord =  BeneficiaryController.GetBeneficiary(benefID);                
                benefRecord.InsertedBy = UserInfo.ID;
                this.lblSubmitting.Text = "Sending beneficiary with Guid ID : " + benefRecord.GUID;
                var response = APIController.SubmitBeneficiary(benefRecord);
                if(response == false)
                {
                    if (MessageBox.Show("Error sending record with ID" + benefID + "/br Do you want to continue ?", "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
                    {
                        continue;
                    }
                    else { return; }
                }
                var beneficiaryInDB = db.Beneficiaries.Where(i => i.BeneficiaryID == benefID).First();
                beneficiaryInDB.IsSubmitted = true;
                db.SaveChanges();
                this.lblSubmitting.Text = "";
                this.FillBeneficiaryListView();
            }
        }

        private void lvBeneficiaries_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e)
        {
            e.Graphics.DrawString(e.Header.Text, new Font("tahoma", 12), new SolidBrush(Color.Red), e.Bounds);
            e.DrawText();
        }
    }
}
