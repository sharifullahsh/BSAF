using BSAF.Entity;
using BSAF.Helper;
using BSAF.Models.Tables;
using BSAF.Models.ViewModels;
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
        dbContext db = new dbContext();
        BeneficiaryVM beneficiary;
        public BeneficiaryForm()
        {
            InitializeComponent();
            beneficiary = new BeneficiaryVM();
        }

        private void btnProfileNext_Click(object sender, EventArgs e)
        {
            var provinceBCP = this.cmbProvinceBCP.SelectedValue != null ? this.cmbProvinceBCP.SelectedValue.ToString():"0";
            var borderPoint = this.cmbProvinceBCP.SelectedValue != null ? this.cmbProvinceBCP.SelectedValue.ToString() : "0";
            var beneficiaryType = "";
            if (this.rdoBeneficiaryTypeFamily.Checked)
            {
                beneficiaryType = this.rdoBeneficiaryTypeFamily.Text;
            }
            if (this.rdoBeneficiaryTypeIndividual.Checked)
            {
                beneficiaryType = this.rdoBeneficiaryTypeIndividual.Text;
            }
            var returnStatus = "";
            if (this.rdoReturnStatusDeported.Checked)
            {
                returnStatus = "DEP";
            }
            if (this.rdoReturnStatusDocClaimant.Checked)
            {
                returnStatus = "DC";
            }
            if (this.rdoReturnStatusSpontaneous.Checked)
            {
                returnStatus = "SR";
            }
            
            var originProvince = this.cmbOriginProvince.SelectedValue != null ? this.cmbOriginProvince.SelectedValue.ToString() : "0";
            var originDistrict = this.cmbOriginProvince.SelectedValue != null ? int.Parse(this.cmbOriginProvince.SelectedValue.ToString()) : 0;
            var originVillage = this.txtOriginVillage.Text;
            var returnProvince = this.cmbReturnProvince.SelectedValue != null ? this.cmbReturnProvince.SelectedValue.ToString() : "0";
            var returnDistrict = this.cmbReturnDistrict.SelectedValue != null ? (int)this.cmbReturnDistrict.SelectedValue : 0;
            var returnVillage = this.txtReturnVillage.Text;

            if (provinceBCP != "0" && !string.IsNullOrEmpty(beneficiaryType) && string.IsNullOrEmpty(returnStatus)
                 && !string.IsNullOrWhiteSpace(this.txtTotalIndividual.Text) 
                 && originProvince != "0" && originProvince != "0" && originDistrict != 0 && !string.IsNullOrWhiteSpace(originVillage) 
                 && returnProvince != "0" && returnDistrict != 0 && !string.IsNullOrWhiteSpace(returnVillage))
            {
                this.beneficiary.ScreeningDate = this.screeningDate.Value;
                this.beneficiary.ProvinceBCP = this.cmbProvinceBCP.SelectedValue.ToString();
                this.beneficiary.BorderPoint = borderPoint;
                this.beneficiary.BeneficiaryType = beneficiaryType;
                this.beneficiary.ReturnStatus = returnStatus;
                this.beneficiary.OriginProvince = originProvince;
                this.beneficiary.OriginDistrict = originDistrict;
                this.beneficiary.OriginVillage = originVillage;
                this.beneficiary.ReturnProvince = returnProvince;
                this.beneficiary.ReturnDistrict = returnDistrict;
                this.beneficiary.ReturnVillage = returnVillage;
                this.beneficiary.GUID = Guid.NewGuid();
            }
            else
            {
                MessageBox.Show("Please provide required information.");
                return;
            }
            if (this.beneficiary.Individuals.Count <= 0)
            {
                MessageBox.Show("Please enter family memeber.");
                return;
            }
            else if (this.beneficiary.Individuals.Count != int.Parse(this.txtTotalIndividual.Text))
            {
                MessageBox.Show("Intered family member not mach the number specified.");
                return;
            }

            this.tabeBeneficiary.SelectedIndex = 1;
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
            if (this.ITEMSOther.Checked)
            {
                this.txtITEMSOther.Visible = true;
                this.lblItemBroughtIOther.Visible = true;
            }
            else
            {
                this.txtITEMSOther.Visible = false;
                this.lblItemBroughtIOther.Visible = false;
            }
        }

        private void chkWhatCanHelpProvisionOfTools_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkWhatCanHelpProvisionOfTools.Checked)
            {
                this.gbToolsNeeded.Visible = true;
            }
            else
            {
                this.gbToolsNeeded.Visible = false;
            }
        }

        private void chkToolsNeedOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkToolsNeedOther.Checked)
            {
                this.txtToolsNeedsOther.Visible = true;
            }
            else
            {
                this.txtToolsNeedsOther.Visible = false;
            }
        }

        private void btnProtection1Next_Click(object sender, EventArgs e)
        {
            var psns = this.gbPSN.Controls.OfType<CheckBox>().Where(c=>c.Checked);
            foreach(CheckBox cbx in psns)
            {
                var psn = new PSN
                {
                    PSNCode = cbx.Name
                };
                if(cbx.Name == "PSNOther")
                {
                    psn.PSNOther = this.txtPSNOther.Text;
                }
               this.beneficiary.PSNs.Add(psn);
            }
            var firstLReason = this.cmb1ReasonForLeaving.SelectedValue != null ? this.cmb1ReasonForLeaving.SelectedValue.ToString() : "0";
            if(firstLReason != "0"){
                this.beneficiary.LeavingReason1 = firstLReason;
                if (firstLReason == "LROther" && !string.IsNullOrEmpty(this.txt1LeavingReasonOther.Text))
                {
                    this.beneficiary.LeavingReason1Other = this.txt1LeavingReasonOther.Text;
                }
                else { MessageBox.Show("Please provide first other reason."); return; }
            }
            else
            {
                MessageBox.Show("Please select first leaving reason.");
                return;
            }
            var secondLReason = this.cmb2ReasonForLeaving.SelectedValue != null ? this.cmb2ReasonForLeaving.SelectedValue.ToString() : "0";
            if(secondLReason != "0")
            {
                this.beneficiary.LeavingReason2 = secondLReason;
                if (secondLReason == "LROther" && !string.IsNullOrEmpty(this.txt2LeavingReasonOther.Text))
                {
                    this.beneficiary.LeavingReason2Other = this.txt2LeavingReasonOther.Text;
                }
                else { MessageBox.Show("Please provide second other reason."); return; }
            }
            var thirdLReason = this.cmb3ReasonForLeaving.SelectedValue != null ? this.cmb3ReasonForLeaving.SelectedValue.ToString() : "0";
            if (thirdLReason != "0")
            {
                this.beneficiary.LeavingReason3 = thirdLReason;
                if (thirdLReason == "LROther" && !string.IsNullOrEmpty(this.txt3LeavingReasonOther.Text))
                {
                    this.beneficiary.LeavingReason3Other = this.txt3LeavingReasonOther.Text;
                }
                else { MessageBox.Show("Please provide third other reason."); return; }
            }
            var returningReasons = this.gbReturnReason.Controls.OfType<CheckBox>().Where(c => c.Checked);
            if (returningReasons.Count() <= 0)
            {
                MessageBox.Show("Please select returning reason.");
                return;
            }
            if (!string.IsNullOrWhiteSpace(this.txtReturnReasonOther.Text))
            {
                MessageBox.Show("Please other retuning reaons.");
            }
            foreach (CheckBox cbx in psns)
            {
                var reason = new ReturnReason
                {
                    ReasonCode = cbx.Name
                };
                if (cbx.Name == "RROther")
                {
                    reason.Other = this.txtReturnReasonOther.Text;
                }
                this.beneficiary.ReturnReasons.Add(reason);
            }
            this.tabeBeneficiary.SelectedIndex = 2;
        }

        private void btnProtection1Previous_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 0;
        }

        private void btnProtection2Next_Click(object sender, EventArgs e)
        {
            var rankImportantsGB = gbRankImportant.Controls.OfType<GroupBox>();
            foreach(var gb in rankImportantsGB)
            {
                var ranksAnswer = gb.Controls.OfType<RadioButton>().Where(c => c != null && c.Checked).FirstOrDefault();
                if(ranksAnswer != null)
                {
                    var rank = new Determination {
                        DeterminationCode = gb.Name,
                        AnswerCode = ranksAnswer.Name
                    };
                    if(gb.Name == "RankImpOther" && !string.IsNullOrWhiteSpace(this.txtRankImpOther.Text))
                    {
                        rank.Other = this.txtRankImpOther.Text;
                    }
                    else
                    {
                        MessageBox.Show("Please provide other option to determine your destination in Aghanistan.");
                        return;
                    }
                    this.beneficiary.Determinations.Add(rank);
                }
            }
            if (this.rdoOwnHouseYes.Checked)
            {
                this.beneficiary.OwnHouse = true;
            }else if (this.rdoOwnHouseNo.Checked)
            {
                this.beneficiary.OwnHouse = false;
            }
            else { MessageBox.Show("Please select do you own house or not."); return; }
            var whereWillLive = this.cmbWhereWillYouLive.SelectedValue != null ? this.cmbWhereWillYouLive.SelectedValue.ToString() : "0";
            if (whereWillLive != "0")
            {
                this.beneficiary.WhereWillLive = whereWillLive;
            }
            else { MessageBox.Show("Please select where will live."); return; }
            if (!string.IsNullOrEmpty(this.txtRentPayForAccom.Text))
            {
                this.beneficiary.RentPayForAccom = int.Parse(this.txtRentPayForAccom.Text);
                if (this.rdoUSD.Checked)
                {
                    this.beneficiary.RentPayCurrency = this.rdoUSD.Text;
                }
                else if(this.rdoAFG.Checked){
                    this.beneficiary.RentPayCurrency = this.rdoUSD.Text;
                }
                else { MessageBox.Show("Select currency for payment accomodation."); }
            }
            var monySources = gbFindMonyForRentHouse.Controls.OfType<CheckBox>().Where(c => c.Checked);
            if(monySources != null && monySources.Count() > 0)
            {
                foreach(var cbx in monySources)
                {
                    var source = new MoneySource
                    {
                        MoneySourceCode = cbx.Name
                    };
                    if(cbx.Name == "MFRPOther")
                    {
                        source.MoneySourceOther = this.txtMFRPOther.Text;
                    }
                    else { MessageBox.Show("Please specify other source."); return; }
                }
            }
            if (this.rdoAllowFamilyForJobYes.Checked)
            {
                this.beneficiary.AllowForJob = true;
            }else if (this.rdoAllowFamilyForJobNo.Checked)
            {
                this.beneficiary.AllowForJob = false;
            }
            else { MessageBox.Show("Please answer do you allow family member for job."); return; }
            this.tabeBeneficiary.SelectedIndex = 3;
        }

        private void btnProtection2Previous_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 1;
        }

        private void btnHostCountryNext_Click(object sender, EventArgs e)
        {
            if (this.rdoIRN.Checked)
            {
                this.beneficiary.CountryOfExile = this.rdoIRN.Name;
            }if (this.rdoPAK.Checked) {
                this.beneficiary.CountryOfExile = this.rdoPAK.Name;
            }else if (this.COther.Checked && !string.IsNullOrWhiteSpace(this.txtCOther.Text))
            {
               this.beneficiary.CountryOfExile =  this.COther.Name;
                this.beneficiary.CountryOfExilOther = this.txtCOther.Text;
            }
            else { MessageBox.Show("Please specify country of exile."); }
            if(this.rdoIRN.Checked || this.rdoPAK.Checked)
            {
                var hostProvince = this.cmbBeforReturnProvince.SelectedValue != null ? this.cmbBeforReturnProvince.SelectedValue.ToString() : "0";
                if(hostProvince != "0")
                {
                    this.beneficiary.BeforReturnProvince = hostProvince;
                }
                var hostDistrict = this.cmbBeforReturnProvince.SelectedValue != null ? int.Parse(this.cmbBeforReturnProvince.SelectedValue.ToString()) : 0;
                if (hostDistrict != 0)
                {
                    this.beneficiary.BeforReturnDistrictID = hostDistrict;
                }
                if (!string.IsNullOrWhiteSpace(this.txtBeforReturnRemarks.Text))
                {
                    this.beneficiary.BeforReturnRemarks = this.txtBeforReturnRemarks.Text;
                }
            }
            if (this.rdoFMemberStayedBehindYes.Checked)
            {
                this.beneficiary.FamilyMemStayedBehind = true;
                if (!string.IsNullOrEmpty(this.txtFMemberStyedBehind.Text))
                {
                    this.beneficiary.FamilyMemStayedBehindNo = int.Parse(this.txtFMemberStyedBehind.Text);
                }
                else { MessageBox.Show("Please specify the number of family member stayed behind."); }
            }else if (this.rdoFMemberStayedBehindNo.Checked)
            {
                this.beneficiary.FamilyMemStayedBehind = false;
            }
            else { MessageBox.Show("Please specify 'do you have family member stayed behind'"); }
            if (!string.IsNullOrEmpty(this.txtYearsStay.Text))
            {
                this.beneficiary.LengthOfStayYears = int.Parse(this.txtYearsStay.Text);
            }
            if (!string.IsNullOrEmpty(this.txtMonthsStay.Text))
            {
                this.beneficiary.LengthOfStayMonths = int.Parse(this.txtMonthsStay.Text);
            }
            if (!string.IsNullOrEmpty(this.txtDaysStay.Text))
            {
                this.beneficiary.LengthOfStayDays = int.Parse(this.txtDaysStay.Text);
            }
            var itemsBrought = pnlItemBrought.Controls.OfType<CheckBox>().Where(c => c.Checked);
            foreach(var chb in itemsBrought)
            {
                var item = new BroughtItem
                {
                    ItemCode = chb.Name
                };
                if(chb.Name == "ITEMSOther")
                {
                    item.ItemOther = chb.Name;
                }
                this.beneficiary.BroughtItems.Add(item);
            }
            if (this.rdoWantReturnYes.Checked)
            {
                this.beneficiary.WouldYouReturn = true;
            }else if (this.rdoWantReturnNo.Checked)
            {
                this.beneficiary.WouldYouReturn = false;
            }
            else
            {
                MessageBox.Show("Please specify whould your return to Pakistan/Iran.");
            }
            this.tabeBeneficiary.SelectedIndex = 4;
        }

        private void btnHostCountryPrevious_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 2;
        }

        private void btnAssistanceNeedsNext1_Click(object sender, EventArgs e)
        {
            // Transportation
            if (this.chkTBRCR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkTBRCR.Parent.Name
                };
                if (this.chkTBRCP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateTBRCD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtTBRCC.Text)){
                    need.Comment = this.txtTBRCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // 1st Leg transportation
            if (this.chkFLTR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkFLTR.Parent.Name
                };
                if (this.chkFLTP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateFLTD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtFLTC.Text)){
                    need.Comment = this.txtFLTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Cash for transportation
            if (this.chkCFTR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkCFTR.Parent.Name
                };
                if (this.chkCFTP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateCFTD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtCFTC.Text)){
                    need.Comment = this.txtCFTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            } 
            // Family tracing
            if (this.chkFTR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkFTR.Parent.Name
                };
                if (this.chkFTP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateFTD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtFTC.Text)){
                    need.Comment = this.txtFTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Special transportation
            if (this.chkSTAR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkSTAR.Parent.Name
                };
                if (this.chkSTAP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateSTAD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtSTAC.Text)){
                    need.Comment = this.txtSTAC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Accommodation in transit center
            if (this.chkAITCR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkAITCR.Parent.Name
                };
                if (this.chkAITCP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateAITCD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtAITCC.Text)){
                    need.Comment = this.txtAITCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // External media care
            if (this.chkEMCR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkEMCR.Parent.Name
                };
                if (this.chkEMCP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateEMCD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtEMCC.Text)){
                    need.Comment = this.txtEMCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Escort
            if (this.chkER.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkER.Parent.Name
                };
                if (this.chkEP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateED.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtEC.Text)){
                    need.Comment = this.txtEC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Drug demand reduction
            if (this.chkDDRR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkDDRR.Parent.Name
                };
                if (this.chkDDRP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateDDRD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtDDRC.Text)){
                    need.Comment = this.txtDDRC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // WFP food package
            if (this.chkWFPR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkWFPR.Parent.Name
                };
                if (this.chkWFPP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateWFPD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtWFPC.Text)){
                    need.Comment = this.txtWFPC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Psychosocial counseling
            if (this.chkPCR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkPCR.Parent.Name
                };
                if (this.chkPCP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.datePCD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtPCC.Text)){
                    need.Comment = this.txtPCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Non-Food items
            if (this.chkNFIR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkNFIR.Parent.Name
                };
                if (this.chkNFIP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateNFID.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtNFIC.Text)){
                    need.Comment = this.txtNFIC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Seasonal clothes
            if (this.chkSCR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkSCR.Parent.Name
                };
                if (this.chkSCP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.dateSCD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtSCC.Text)){
                    need.Comment = this.txtSCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Protection referral
            if (this.chkPRR.Checked)
            {
                var need = new PostArrivalNeed
                {
                    Requested = true,
                    NeedCode = this.chkPRR.Parent.Name
                };
                if (this.chkPRP.Checked)
                {
                    need.Provided = true;
                    need.ProvidedDate = this.datePRD.Value;
                }
                if (!string.IsNullOrWhiteSpace(this.txtPCC.Text)){
                    need.Comment = this.txtPRC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            var bneed = this.beneficiary.PostArrivalNeeds;
            this.tabeBeneficiary.SelectedIndex = 5;
        }

        private void btnAssistanceNeedsPrevious1_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 3;
        }

        private void btnAssistanceNeedsNext2_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 6;
        }

        private void btnAssistanceNeedsPrevious2_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 4;
        }

        private void btnReintegNeed1NeedNext_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 7;
        }

        private void btnReintegNeed1Previous_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 5;
        }

        private void btnReintegNeeds2Next_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 8;
        }

        private void btnReintegNeeds2Previous_Click(object sender, EventArgs e)
        {
            this.tabeBeneficiary.SelectedIndex = 6;
        }

        private void BeneficiaryForm_Load(object sender, EventArgs e)
        {
            this.lblReturnToHostReason.Visible = false;
            this.txtReturnToHostReason.Visible = false;
            
            this.lblHoHEducationOther.Visible = false;
            this.txtHoHEducationOther.Visible = false;

            this.lbl1LeavingResonOther.Visible = false;
            this.txt1LeavingReasonOther.Visible = false;

            this.lbl2LeavingResonOther.Visible = false;
            this.txt2LeavingReasonOther.Visible = false;

            this.lbl3LeavingResonOther.Visible = false;
            this.txt3LeavingReasonOther.Visible = false;

            this.gbIranPakAddress.Visible = false;

            var provinceList = db.Provinces.Where(p=>p.IsActive == true).Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            provinceList.Insert(0, new { ProvinceCode = "0", ProvinceName = "-- Please Select --" });
            this.cmbProvinceBCP.DataSource = provinceList;
            this.cmbProvinceBCP.DisplayMember = "ProvinceName";
            this.cmbProvinceBCP.ValueMember = "ProvinceCode";
            this.cmbProvinceBCP.SelectedIndex = 0;

            var genderTypeList = DbHelper.GetcmbLookups("GENDER");
            this.cmbGender.DataSource = genderTypeList;
            this.cmbGender.DisplayMember = "LookupName";
            this.cmbGender.ValueMember = "ValueCode";
            this.cmbGender.SelectedIndex = 0;

            var maritalStatusList = DbHelper.GetcmbLookups("MARSTAT");
            this.cmbMaritalStatus.DataSource = maritalStatusList;
            this.cmbMaritalStatus.DisplayMember = "LookupName";
            this.cmbMaritalStatus.ValueMember = "ValueCode";
            this.cmbMaritalStatus.SelectedIndex = 0;

            var IDTypeList = DbHelper.GetcmbLookups("IDTYPE");
            this.cmbIDType.DataSource = IDTypeList;
            this.cmbIDType.DisplayMember = "LookupName";
            this.cmbIDType.ValueMember = "ValueCode";
            this.cmbIDType.SelectedIndex = 0;

            var relationshipList = DbHelper.GetcmbLookups("RELATION");
            this.cmbRelationship.DataSource = relationshipList;
            this.cmbRelationship.DisplayMember = "LookupName";
            this.cmbRelationship.ValueMember = "ValueCode";
            this.cmbRelationship.SelectedIndex = 0;

            var borderPointList = db.BorderCrossingPoints.Where(b=>b.IsActive == true).Select(b=>new { b.BCPCode, BorderPointName = b.EnName}).ToList();
            borderPointList.Insert(0, new { BCPCode = "0", BorderPointName = "-Please Select-" });
            this.cmbBorderPoint.DataSource = borderPointList;
            this.cmbBorderPoint.DisplayMember = "BorderPointName";
            this.cmbBorderPoint.ValueMember = "BCPCode";
            this.cmbBorderPoint.SelectedIndex = 0;

            var orgProvinceList = db.Provinces.Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            orgProvinceList.Insert(0, new { ProvinceCode = "0", ProvinceName ="-- Please Select --"});
            this.cmbOriginProvince.DataSource = orgProvinceList;
            this.cmbOriginProvince.DisplayMember = "ProvinceName";
            this.cmbOriginProvince.ValueMember = "ProvinceCode";
            this.cmbOriginProvince.SelectedIndex = 0;

            var returnProvinceList = db.Provinces.Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            returnProvinceList.Insert(0, new { ProvinceCode = "0", ProvinceName = "-- Please Select --" });
            this.cmbReturnProvince.DataSource = returnProvinceList;
            this.cmbReturnProvince.DisplayMember = "ProvinceName";
            this.cmbReturnProvince.ValueMember = "ProvinceCode";
            this.cmbReturnProvince.SelectedIndex = 0;

            var firstReasonForLeavingList = DbHelper.GetcmbLookups("LREASON");
            this.cmb1ReasonForLeaving.DataSource = firstReasonForLeavingList;
            this.cmb1ReasonForLeaving.DisplayMember = "LookupName";
            this.cmb1ReasonForLeaving.ValueMember = "ValueCode";
            this.cmb1ReasonForLeaving.SelectedIndex = 0;

            var leavingPlaceList = DbHelper.GetcmbLookups("WWYL").ToList();
            this.cmbWhereWillYouLive.DataSource = leavingPlaceList;
            this.cmbWhereWillYouLive.DisplayMember = "LookupName";
            this.cmbWhereWillYouLive.ValueMember = "ValueCode";
            this.cmbWhereWillYouLive.SelectedIndex = 0;

            var assisInProvince1List = db.Provinces.Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            assisInProvince1List.Insert(0, new { ProvinceCode = "0", ProvinceName = "-- Please Select --" });
            this.cmbAssistedInProvince1.DataSource = assisInProvince1List;
            this.cmbAssistedInProvince1.DisplayMember = "ProvinceName";
            this.cmbAssistedInProvince1.ValueMember = "ProvinceCode";
            this.cmbAssistedInProvince1.SelectedIndex = 0;

            var assisInProvince2List = db.Provinces.Select(p => new { p.ProvinceCode, ProvinceName = p.EnName }).ToList();
            assisInProvince2List.Insert(0, new { ProvinceCode = "0", ProvinceName = "-- Please Select --" });
            this.cmbAssistedInProvince2.DataSource = assisInProvince2List;
            this.cmbAssistedInProvince2.DisplayMember = "ProvinceName";
            this.cmbAssistedInProvince2.ValueMember = "ProvinceCode";
            this.cmbAssistedInProvince2.SelectedIndex = 0;

            var needsList = DbHelper.GetcmbLookups("TOPNEED");
            this.cmbReintegrationNeeds1.DataSource = needsList;
            this.cmbReintegrationNeeds1.DisplayMember = "LookupName";
            this.cmbReintegrationNeeds1.ValueMember = "ValueCode";
            this.cmbReintegrationNeeds1.SelectedIndex = 0;

            var toDoList = DbHelper.GetcmbLookups("WDYITD");
            this.cmbIntendToDo.DataSource = toDoList;
            this.cmbIntendToDo.DisplayMember = "LookupName";
            this.cmbIntendToDo.ValueMember = "ValueCode";
            this.cmbIntendToDo.SelectedIndex = 0;

            var professionList = DbHelper.GetcmbLookups("PROFESSION");
            this.cmbProfession.DataSource = professionList;
            this.cmbProfession.DisplayMember = "LookupName";
            this.cmbProfession.ValueMember = "ValueCode";
            this.cmbProfession.SelectedIndex = 0;

            var educationList = DbHelper.GetcmbLookups("EDUCATION");
            this.cmbHoHEducationLevel.DataSource = educationList;
            this.cmbHoHEducationLevel.DisplayMember = "LookupName";
            this.cmbHoHEducationLevel.ValueMember = "ValueCode";
            this.cmbHoHEducationLevel.SelectedIndex = 0;

            var orgList = DbHelper.GetcmbLookups("ORGTYP");
            this.cmbAssistedOrg1.DataSource = orgList;
            this.cmbAssistedOrg1.DisplayMember = "LookupName";
            this.cmbAssistedOrg1.ValueMember = "ValueCode";
            this.cmbAssistedOrg1.SelectedIndex = 0;
        }

        private void cmbOriginProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var selectedPro = this.cmbOriginProvince.SelectedValue.ToString();
            if (selectedPro != null && selectedPro != "0")
            {
                var districtList = db.Districts.Where(d => d.ProvinceCode == this.cmbOriginProvince.SelectedValue.ToString())
                .Select(d => new { d.DistrictCode, DistrictName = d.EnName }).ToList();
                districtList.Insert(0, new { DistrictCode = 0, DistrictName = "-- Please Select --" });
                this.cmbOriginDistrict.DataSource = districtList;
                this.cmbOriginDistrict.DisplayMember = "DistrictName";
                this.cmbOriginDistrict.ValueMember = "DistrictCode";
                this.cmbOriginDistrict.SelectedIndex = 0;
                this.chkSameProvince.Enabled = true;
            }
        }

        private void chkSameProvince_CheckedChanged(object sender, EventArgs e)
        {
            var provinceCode = this.cmbOriginProvince.SelectedValue.ToString();
            if (this.chkSameProvince.Checked && provinceCode != null && provinceCode != "0")
            {
                this.cmbReturnProvince.SelectedValue = this.cmbOriginProvince.SelectedValue;
                this.cmbReturnProvince_SelectionChangeCommitted(null,null);
            }
        }

        private void chkSameDistrict_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSameDistrict.Checked && this.cmbOriginDistrict.SelectedValue != null)
            {
                this.cmbReturnDistrict.SelectedValue = this.cmbOriginDistrict.SelectedValue;
            }
        }

        private void cmbOriginDistrict_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.chkSameDistrict.Enabled = true;
        }

        private void chkSameVillage_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkSameVillage.Checked)
            {
                this.txtReturnVillage.Text = this.txtOriginVillage.Text;
            }
        }
        private void cmbReturnProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbReturnProvince.SelectedValue.ToString() != null)
            {
                var districtList = db.Districts.Where(d => d.ProvinceCode == this.cmbReturnProvince.SelectedValue.ToString())
                .Select(d => new { d.DistrictCode, DistrictName = d.EnName }).ToList();
                districtList.Insert(0, new { DistrictCode = 0, DistrictName = "-- Please Select --" });
                this.cmbReturnDistrict.DataSource = districtList;
                this.cmbReturnDistrict.DisplayMember = "DistrictName";
                this.cmbReturnDistrict.ValueMember = "DistrictCode";
                this.cmbReturnDistrict.SelectedIndex = 0;
            }
        }

        private void rdoIRN_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoIRN.Checked)
            {
                var hostProvinceList = db.HostCountryProvinces.Where(p => p.CountryCode == "IRN").Select(p => new { p.ProvinceId, ProvinceName = p.EnName }).ToList();
                hostProvinceList.Insert(0, new { ProvinceId = 0, ProvinceName = "-- Please Select --" });
                this.cmbBeforReturnProvince.DataSource = hostProvinceList;
                this.cmbBeforReturnProvince.DisplayMember = "ProvinceName";
                this.cmbBeforReturnProvince.ValueMember = "ProvinceId";
                this.cmbBeforReturnProvince.SelectedIndex = 0;

                this.gbIranPakAddress.Visible = true;
            }
            else { this.gbIranPakAddress.Visible = false; }
        }

        private void rdoPAK_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoPAK.Checked)
            {
                var hostProvinceList = db.HostCountryProvinces.Where(p => p.CountryCode == "PAK").Select(p => new { p.ProvinceId, ProvinceName = p.EnName }).ToList();
                hostProvinceList.Insert(0, new { ProvinceId = 0, ProvinceName = "-- Please Select --" });
                this.cmbBeforReturnProvince.DataSource = hostProvinceList;
                this.cmbBeforReturnProvince.DisplayMember = "ProvinceName";
                this.cmbBeforReturnProvince.ValueMember = "ProvinceId";
                this.cmbBeforReturnProvince.SelectedIndex = 0;

                this.gbIranPakAddress.Visible = true;
            }
            else { this.gbIranPakAddress.Visible = false; }
        }

        private void rdoHostCountryOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.COther.Checked)
            {
                this.cmbBeforReturnProvince.DataSource = null;
                this.cmbBeforReturnDistrict.DataSource = null;
                this.gbIranPakAddress.Visible = false;
            }
        }

        private void cmbBeforReturnProvince_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (this.cmbBeforReturnProvince.SelectedValue.ToString() != null)
            {
                var hostDistrictList = db.HostCountryDistricts.Where(d => d.ProvinceId == (int)this.cmbBeforReturnProvince.SelectedValue)
                .Select(d => new { d.DistrictId, DistrictName = d.EnName }).ToList();
                hostDistrictList.Insert(0, new { DistrictId = 0, DistrictName = "-- Please Select --" });
                this.cmbBeforReturnDistrict.DataSource = hostDistrictList;
                this.cmbBeforReturnDistrict.DisplayMember = "DistrictName";
                this.cmbBeforReturnDistrict.ValueMember = "DistrictId";
                this.cmbBeforReturnDistrict.SelectedIndex = 0;
            }
        }


        private void cmbAssistedInProvince1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provincCode = this.cmbAssistedInProvince1.SelectedValue.ToString();
            if (provincCode != null && provincCode != "0")
            {
                var districtList = db.Districts.Where(d => d.ProvinceCode == provincCode)
                .Select(d => new { d.DistrictCode, DistrictName = d.EnName }).ToList();
                districtList.Insert(0, new { DistrictCode = 0, DistrictName = "-- Please Select --" });
                this.cmbAssistedInDistrict1.DataSource = districtList;
                this.cmbAssistedInDistrict1.DisplayMember = "DistrictName";
                this.cmbAssistedInDistrict1.ValueMember = "DistrictCode";
                this.cmbAssistedInDistrict1.SelectedIndex = 0;
            }
        }

        private void cmbAssistedInProvince2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var provincCode = this.cmbAssistedInProvince2.SelectedValue.ToString();
            if (provincCode != null && provincCode != "0")
            {
                var districtList = db.Districts.Where(d => d.ProvinceCode == provincCode)
                .Select(d => new { d.DistrictCode, DistrictName = d.EnName }).ToList();
                districtList.Insert(0, new { DistrictCode = 0, DistrictName = "-- Please Select --" });
                this.cmbAssistedInDistrict2.DataSource = districtList;
                this.cmbAssistedInDistrict2.DisplayMember = "DistrictName";
                this.cmbAssistedInDistrict2.ValueMember = "DistrictCode";
                this.cmbAssistedInDistrict2.SelectedIndex = 0;
            }
        }

        private void cmb1ReasonForLeaving_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstReason = this.cmb1ReasonForLeaving.SelectedValue.ToString();
            if (firstReason != "0")
            {
                var secondReasonForLeavingList = DbHelper.GetcmbLookups("LREASON").Where(l=>l.ValueCode != firstReason).ToList();
                this.cmb2ReasonForLeaving.DataSource = secondReasonForLeavingList;
                this.cmb2ReasonForLeaving.DisplayMember = "LookupName";
                this.cmb2ReasonForLeaving.ValueMember = "ValueCode";
                this.cmb2ReasonForLeaving.SelectedIndex = 0;
            }
            if(firstReason == "LROther")
            {
                this.lbl1LeavingResonOther.Visible = true;
                this.txt1LeavingReasonOther.Visible = true;
            }
            else {
                this.lbl1LeavingResonOther.Visible = false;
                this.txt1LeavingReasonOther.Visible = false;
            }
        }

        private void cmb2ReasonForLeaving_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstReason = this.cmb1ReasonForLeaving.SelectedValue.ToString();
            var seconReason = this.cmb2ReasonForLeaving.SelectedValue.ToString();
            if (firstReason != "0" && seconReason != "0")
            {
                var secondReasonForLeavingList = DbHelper.GetcmbLookups("LREASON").Where(l=> l.ValueCode != firstReason && l.ValueCode != seconReason).ToList();
                this.cmb3ReasonForLeaving.DataSource = secondReasonForLeavingList;
                this.cmb3ReasonForLeaving.DisplayMember = "LookupName";
                this.cmb3ReasonForLeaving.ValueMember = "ValueCode";
                this.cmb3ReasonForLeaving.SelectedIndex = 0;
            }
            if(seconReason == "LROther")
            {
                this.lbl2LeavingResonOther.Visible = true;
                this.txt2LeavingReasonOther.Visible = true;
            }
            else {
                this.lbl2LeavingResonOther.Visible = false;
                this.txt2LeavingReasonOther.Visible = false;
            }
        }

        private void cmbReintegrationNeeds1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstNeed = this.cmbReintegrationNeeds1.SelectedValue.ToString();
            if (firstNeed != "0")
            {
                var need2List = DbHelper.GetcmbLookups("TOPNEED").Where(l=>l.ValueCode != firstNeed).ToList();
                this.cmbReintegrationNeeds2.DataSource = need2List;
                this.cmbReintegrationNeeds2.DisplayMember = "LookupName";
                this.cmbReintegrationNeeds2.ValueMember = "ValueCode";
                this.cmbReintegrationNeeds2.SelectedIndex = 0;
            }
        }

        private void cmbReintegrationNeeds2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstNeed = this.cmbReintegrationNeeds1.SelectedValue.ToString();
            var seconNeed = this.cmbReintegrationNeeds2.SelectedValue.ToString();
            if (firstNeed != "0" && seconNeed != "0")
            {
                var needsList = DbHelper.GetcmbLookups("TOPNEED").Where(l=>l.ValueCode != firstNeed && l.ValueCode != seconNeed).ToList();
                this.cmbReintegrationNeeds3.DataSource = needsList;
                this.cmbReintegrationNeeds3.DisplayMember = "LookupName";
                this.cmbReintegrationNeeds3.ValueMember = "ValueCode";
                this.cmbReintegrationNeeds3.SelectedIndex = 0;
            }
        }

        private void lnkAddFamilyMember_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FamilyMemberForm frm = new FamilyMemberForm();
            frm.ShowDialog();
        }

        private void cmbAssistedOrg1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstOrg = this.cmbAssistedOrg1.SelectedValue.ToString();
            if (firstOrg != "0")
            {
                var orgList = DbHelper.GetcmbLookups("ORGTYP").Where(l=>l.ValueCode != firstOrg).ToList();
                this.cmbAssistedOrg2.DataSource = orgList;
                this.cmbAssistedOrg2.DisplayMember = "LookupName";
                this.cmbAssistedOrg2.ValueMember = "ValueCode";
                this.cmbAssistedOrg2.SelectedIndex = 0;
            }
        }

        private void cmbIntendToDo_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var intendTodo = this.cmbIntendToDo.SelectedValue.ToString();
            if(intendTodo != "0" && intendTodo == "RTH")
            {
                this.lblReturnToHostReason.Visible = true;
                this.txtReturnToHostReason.Visible = true;
            }
            else
            {
                this.lblReturnToHostReason.Visible = false;
                this.txtReturnToHostReason.Visible = false;
            }
        }

        private void cmbHoHEducationLevel_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var educationList = this.cmbHoHEducationLevel.SelectedValue.ToString();
            if (educationList != "0" && educationList == "EDUOther")
            {
                this.lblHoHEducationOther.Visible = true;
                this.txtHoHEducationOther.Visible = true;
            }
            else
            {
                this.lblHoHEducationOther.Visible = false;
                this.txtHoHEducationOther.Visible = false;
            }
        }

        private void btnAddMemeber_Click(object sender, EventArgs e)
        {
            var name = this.txtMName.Text;
            var fName = this.txtMFName.Text;
            var gender = this.cmbGender.SelectedValue != null ? this.cmbGender.SelectedValue.ToString():"0";
            var mStatus = this.cmbMaritalStatus.SelectedValue != null ? this.cmbMaritalStatus.SelectedValue.ToString() : "0";
            var age = this.txtAge.Text.ToString();
            var idType = this.cmbIDType.SelectedValue != null ? this.cmbIDType.SelectedValue.ToString() : "0";
            var idNumber = this.txtIDNo.Text;
            var relation = this.cmbRelationship.SelectedValue != null ?this.cmbRelationship.SelectedValue.ToString() : "0";
            var contactNo = this.txtContactNumber.Text;
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(fName)
                && gender != "0" && mStatus != "0" && !string.IsNullOrWhiteSpace(age)
                && idType != "0" && !string.IsNullOrWhiteSpace(idNumber) && relation != "0"
                && !string.IsNullOrWhiteSpace(contactNo))
            {
                string[] row = {
                    name,
                    fName,
                    this.cmbGender.Text.ToString(),
                    this.cmbMaritalStatus.Text.ToString(),
                    age.ToString(),
                    this.cmbIDType.Text.ToString(),
                    idNumber,
                    this.cmbRelationship.Text.ToString(),
                    contactNo
                };
                this.beneficiary.Individuals.Add(
                    new IndividualVM
                    {
                        Name = name,FName = fName,
                        GenderCode = this.cmbGender.SelectedValue.ToString(),
                        MaritalStatusCode = this.cmbMaritalStatus.SelectedValue.ToString(),
                        Age = int.Parse(age),
                        IDTypeCode = this.cmbIDType.Text.ToString(),
                        IDNo = idNumber,
                        RelationshipCode = this.cmbRelationship.Text.ToString(),
                        ContactNumber = contactNo
                    }
                    );
                ListViewItem member = new ListViewItem(row);
                this.lvFamilyMember.Items.Add(member);
                //Empty the form
                this.txtMName.Text = string.Empty;
                this.txtMFName.Text = string.Empty;
                this.cmbGender.SelectedValue = "0";
                this.cmbMaritalStatus.SelectedValue = "0";
                this.txtAge.Text = string.Empty ;
                this.cmbIDType.SelectedValue = "0";
                this.txtIDNo.Text = string.Empty;
                this.cmbRelationship.SelectedValue = "0";
                this.txtContactNumber.Text = string.Empty;
            }
            else
            {   
                MessageBox.Show("Please provide family member information.");
            }
           
        }

        private void btnSaveBeneficiary_Click(object sender, EventArgs e)
        {
            
        }

        private void Number_Field_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Validation.AllowNumbers(e);
        }

        private void cmb3ReasonForLeaving_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var thirdReason = this.cmb3ReasonForLeaving.SelectedValue.ToString();
          
            if (thirdReason == "LROther")
            {
                this.lbl3LeavingResonOther.Visible = true;
                this.txt3LeavingReasonOther.Visible = true;
            }
            else
            {
                this.lbl3LeavingResonOther.Visible = false;
                this.txt3LeavingReasonOther.Visible = false;
            }
        }
    }
}
