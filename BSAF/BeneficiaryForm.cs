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
        public BeneficiaryVM beneficiary;
        //public BeneficiaryVM beneficiary { get; set; }
        public BeneficiaryForm()
        {
            InitializeComponent();
            beneficiary = new BeneficiaryVM();

            //selected tab
            this.tabBeneficiary.SelectedTab = this.tabProfile;
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
            var originDistrict = this.cmbOriginDistrict.SelectedValue != null ? int.Parse(this.cmbOriginDistrict.SelectedValue.ToString()) : 0;
            var originVillage = this.txtOriginVillage.Text;
            var returnProvince = this.cmbReturnProvince.SelectedValue != null ? this.cmbReturnProvince.SelectedValue.ToString() : "0";
            var returnDistrict = this.cmbReturnDistrict.SelectedValue != null ? (int)this.cmbReturnDistrict.SelectedValue : 0;
            var returnVillage = this.txtReturnVillage.Text;

            if (provinceBCP != "0" && !string.IsNullOrEmpty(beneficiaryType) && !string.IsNullOrEmpty(returnStatus)
                 && !string.IsNullOrEmpty(this.txtTotalIndividual.Text) 
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

            this.tabBeneficiary.SelectedIndex = 1;
        }

        private void chkReturnReasonOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.RROther.Checked)
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
            }
            else
            {
                this.txtITEMSOther.Visible = false;
            }
        }

        private void chkWhatCanHelpProvisionOfTools_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkProvisionOfTools.Checked)
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
            if (this.ToolsOther.Checked)
            {
                this.txtToolsOther.Visible = true;
            }
            else
            {
                this.txtToolsOther.Visible = false;
            }
        }

        private void btnProtection1Next_Click(object sender, EventArgs e)
        {
            //Clear list first
            this.beneficiary.PSNs.Clear();
            this.beneficiary.ReturnReasons.Clear();
            var psns = this.gbPSN.Controls.OfType<CheckBox>().Where(c=>c.Checked);
            if(psns.Count() > 0)
            {
                foreach (CheckBox cbx in psns)
                {
                    var psn = new PSN
                    {
                        PSNCode = cbx.Name
                    };
                    if (cbx.Name == "PSNOther" && !string.IsNullOrWhiteSpace(this.txtPSNOther.Text))
                    {
                        psn.PSNOther = this.txtPSNOther.Text;
                    }
                    else if (cbx.Name == "PSNOther" && string.IsNullOrWhiteSpace(this.txtPSNOther.Text))
                    {
                        MessageBox.Show("Please speciry other type PSN.");
                    }
                    this.beneficiary.PSNs.Add(psn);
                }
            }
            else
            {
                MessageBox.Show("Please select at lest one option in PSN.");
                return;
            }
            var firstLReason = this.cmb1ReasonForLeaving.SelectedValue != null ? this.cmb1ReasonForLeaving.SelectedValue.ToString() : "0";
            if(firstLReason != "0"){
                this.beneficiary.LeavingReason1 = firstLReason;
                if (firstLReason == "LROther" && !string.IsNullOrEmpty(this.txt1LeavingReasonOther.Text))
                {
                    this.beneficiary.LeavingReason1Other = this.txt1LeavingReasonOther.Text;
                }
                else if(firstLReason == "LROther" && string.IsNullOrEmpty(this.txt1LeavingReasonOther.Text)) {
                    MessageBox.Show("Please provide first other reason."); return; }
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
                }else if(secondLReason == "LROther" && string.IsNullOrEmpty(this.txt2LeavingReasonOther.Text)) {
                    MessageBox.Show("Please provide second other reason."); return; }
            }
            var thirdLReason = this.cmb3ReasonForLeaving.SelectedValue != null ? this.cmb3ReasonForLeaving.SelectedValue.ToString() : "0";
            if (thirdLReason != "0")
            {
                this.beneficiary.LeavingReason3 = thirdLReason;
                if (thirdLReason == "LROther" && !string.IsNullOrEmpty(this.txt3LeavingReasonOther.Text))
                {
                    this.beneficiary.LeavingReason3Other = this.txt3LeavingReasonOther.Text;
                }
                else if(thirdLReason == "LROther" && string.IsNullOrEmpty(this.txt3LeavingReasonOther.Text)) {
                    MessageBox.Show("Please provide third other reason."); return; }
            }
            var returningReasons = this.gbReturnReason.Controls.OfType<CheckBox>().Where(c => c.Checked);
            if (returningReasons.Count() > 0)
            {
                foreach (CheckBox cbx in returningReasons)
                {
                    var reason = new ReturnReason
                    {
                        ReasonCode = cbx.Name
                    };
                    if (cbx.Name == "RROther" && !string.IsNullOrWhiteSpace(this.txtReturnReasonOther.Text))
                    {
                        reason.Other = this.txtReturnReasonOther.Text;
                    }
                    else if (cbx.Name == "RROther" && !string.IsNullOrWhiteSpace(this.txtReturnReasonOther.Text))
                    {
                        MessageBox.Show("Please specify other retuning reaons.");
                    }
                    this.beneficiary.ReturnReasons.Add(reason);
                }
            }
            else
            {
                MessageBox.Show("Please select returning reason.");
                return;
            }
            this.tabBeneficiary.SelectedIndex = 2;
        }

        private void btnProtection1Previous_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 0;
        }

        private void btnProtection2Next_Click(object sender, EventArgs e)
        {
            //Clear list
            this.beneficiary.Determinations.Clear();
            this.beneficiary.MoneySources.Clear();

            var rankImportantsGB = gbRankImportant.Controls.OfType<GroupBox>();
            foreach (var gb in rankImportantsGB)
            {
                var ranksAnswer = gb.Controls.OfType<RadioButton>().Where(c => c != null && c.Checked).FirstOrDefault();
                if (ranksAnswer != null)
                {
                    var rank = new Determination
                    {
                        DeterminationCode = gb.Name,
                        AnswerCode = ranksAnswer.Name.Split('_')[1]
                    };
                    if (gb.Name == "RankImpOther" && !string.IsNullOrWhiteSpace(this.txtRankImpOther.Text))
                    {
                        rank.Other = this.txtRankImpOther.Text;
                    }
                    else if (gb.Name == "RankImpOther" && string.IsNullOrWhiteSpace(this.txtRankImpOther.Text))
                    {
                        MessageBox.Show("Please provide other option to determine your destination in Aghanistan.");
                        return;
                    }
                    this.beneficiary.Determinations.Add(rank);
                }
            }
            if(this.beneficiary.Determinations.Count() == 0)
            {
                MessageBox.Show("Please select at least one option to determine your destination in Afghanistan.");
                return;
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
                    if(cbx.Name == "MFRPOther" && !string.IsNullOrWhiteSpace(this.txtMFRPOther.Text))
                    {
                        source.MoneySourceOther = this.txtMFRPOther.Text;
                    }
                    else if(cbx.Name == "MFRPOther" && string.IsNullOrWhiteSpace(this.txtMFRPOther.Text)) {
                        MessageBox.Show("Please specify other source."); return; }
                    this.beneficiary.MoneySources.Add(source);
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
            this.tabBeneficiary.SelectedIndex = 3;
        }

        private void btnProtection2Previous_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 1;
        }

        private void btnHostCountryNext_Click(object sender, EventArgs e)
        {
            // Clear list
            this.beneficiary.BroughtItems.Clear();

            if (this.Iran.Checked)
            {
                this.beneficiary.CountryOfExile = "Iran";
            }else if (this.Pakistan.Checked) {
                this.beneficiary.CountryOfExile = this.Pakistan.Name;
            }else if (this.COther.Checked && !string.IsNullOrWhiteSpace(this.txtCOther.Text))
            {
               this.beneficiary.CountryOfExile =  this.COther.Name;
                this.beneficiary.CountryOfExilOther = this.txtCOther.Text;
            }
            else {
                MessageBox.Show("Please specify country of exile.");
                return;
            }
            if(this.Iran.Checked || this.Pakistan.Checked)
            {
                var hostProvince = this.cmbBeforReturnProvince.SelectedValue != null ? int.Parse(this.cmbBeforReturnProvince.SelectedValue.ToString()) : 0;
                if(hostProvince != 0)
                {
                    this.beneficiary.BeforReturnProvince = hostProvince;
                }
                else
                {
                    MessageBox.Show("Please select host country province.");
                    return;
                }
                var hostDistrict = this.cmbBeforReturnDistrict.SelectedValue != null ? int.Parse(this.cmbBeforReturnDistrict.SelectedValue.ToString()) : 0;
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
                else {
                    MessageBox.Show("Please specify the number of family member stayed behind.");
                    return;
                }
            }else if (this.rdoFMemberStayedBehindNo.Checked)
            {
                this.beneficiary.FamilyMemStayedBehind = false;
            }
            else {
                MessageBox.Show("Please specify 'do you have family member stayed behind'");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtYearsStay.Text))
            {
                this.beneficiary.LengthOfStayYears = int.Parse(this.txtYearsStay.Text);
            }
            else {
                MessageBox.Show("Please specify length of year stay in host country or put 0.");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtMonthsStay.Text))
            {
                this.beneficiary.LengthOfStayMonths = int.Parse(this.txtMonthsStay.Text);
            }
            else
            {
                MessageBox.Show("Please specify length of month stay in host country or put 0.");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtDaysStay.Text))
            {
                this.beneficiary.LengthOfStayDays = int.Parse(this.txtDaysStay.Text);
            }
            else
            {
                MessageBox.Show("Please specify length of day stay in host country or put 0.");
                return;
            }

            var itemsBrought = pnlItemBrought.Controls.OfType<CheckBox>().Where(c => c.Checked);
            foreach(var chb in itemsBrought)
            {
                var item = new BroughtItem
                {
                    ItemCode = chb.Name
                };
                if(chb.Name == "ITEMSOther" && !string.IsNullOrWhiteSpace(this.txtITEMSOther.Text))
                {
                    item.ItemOther = chb.Name;
                }else if(chb.Name == "ITEMSOther" && string.IsNullOrWhiteSpace(this.txtITEMSOther.Text))
                {
                  MessageBox.Show("Please specify other item brought from host country.");
                    return;
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
                MessageBox.Show("Please specify would you return to Pakistan/Iran.");
                return;
            }
            this.tabBeneficiary.SelectedIndex = 4;
        }

        private void btnHostCountryPrevious_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 2;
        }

        private void btnAssistanceNeedsNext1_Click(object sender, EventArgs e)
        {
            //Clear list
            this.beneficiary.PostArrivalNeeds.Clear();
            // Transportation
            if (this.chkTBRCP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkTBRCP.Parent.Name
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
            if (this.chkFLTP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkFLTP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateFLTD.Value
                };
                if (!string.IsNullOrWhiteSpace(this.txtFLTC.Text)){
                    need.Comment = this.txtFLTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Cash for transportation
            if (this.chkCFTP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkCFTP.Parent.Name,
                    Provided = true,
                ProvidedDate = this.dateCFTD.Value
                };
                if (!string.IsNullOrWhiteSpace(this.txtCFTC.Text)){
                    need.Comment = this.txtCFTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            } 
            // Family tracing
            if (this.chkFTP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkFTP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateFTD.Value
                };
                if (!string.IsNullOrWhiteSpace(this.txtFTC.Text)){
                    need.Comment = this.txtFTC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Special transportation
            if (this.chkSTAP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkSTAP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateSTAD.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtSTAC.Text)){
                    need.Comment = this.txtSTAC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Accommodation in transit center
            if (this.chkAITCP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkAITCP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateAITCD.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtAITCC.Text)){
                    need.Comment = this.txtAITCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // External media care
            if (this.chkEMCP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkEMCP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateEMCD.Value,
                 };
                if (!string.IsNullOrWhiteSpace(this.txtEMCC.Text)){
                    need.Comment = this.txtEMCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Escort
            if (this.chkEP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkEP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateED.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtEC.Text)){
                    need.Comment = this.txtEC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Drug demand reduction
            if (this.chkDDRP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkDDRP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateDDRD.Value
                };
                if (!string.IsNullOrWhiteSpace(this.txtDDRC.Text)){
                    need.Comment = this.txtDDRC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // WFP food package
            if (this.chkWFPP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkWFPP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateWFPD.Value
                };
                if (!string.IsNullOrWhiteSpace(this.txtWFPC.Text)){
                    need.Comment = this.txtWFPC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Psychosocial counseling
            if (this.chkPCP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkPCP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.datePCD.Value
                };
                if (this.chkPCP.Checked)
                {
                }
                if (!string.IsNullOrWhiteSpace(this.txtPCC.Text)){
                    need.Comment = this.txtPCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Non-Food items
            if (this.chkNFIP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkNFIP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateNFID.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtNFIC.Text)){
                    need.Comment = this.txtNFIC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Seasonal clothes
            if (this.chkSCP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkSCP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.dateSCD.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtSCC.Text)){
                    need.Comment = this.txtSCC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            // Protection referral
            if (this.chkPRP.Checked)
            {
                var need = new PostArrivalNeed
                {
                    NeedCode = this.chkPRP.Parent.Name,
                    Provided = true,
                    ProvidedDate = this.datePRD.Value

                };
                if (!string.IsNullOrWhiteSpace(this.txtPCC.Text)){
                    need.Comment = this.txtPRC.Text;
                }
                this.beneficiary.PostArrivalNeeds.Add(need);
            }
            var bneed = this.beneficiary.PostArrivalNeeds;
            this.tabBeneficiary.SelectedIndex = 5;
        }

        private void btnAssistanceNeedsPrevious1_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 3;
        }

        private void btnAssistanceNeedsNext2_Click(object sender, EventArgs e)
        {
            //Clear list
            this.beneficiary.Transports.Clear();

            if (this.rdoBenefitedYes.Checked)
            {
                var assis1Province = this.cmbAssistedInProvince1.SelectedValue != null ? this.cmbAssistedInProvince1.SelectedValue.ToString() : "0";
                var assis1District = this.cmbAssistedInDistrict1.SelectedValue != null ? int.Parse(this.cmbAssistedInDistrict1.SelectedValue.ToString()) : 0;
                var assis1Org = this.cmbAssistedOrg1.SelectedValue != null ? this.cmbAssistedOrg1.SelectedValue.ToString() : "0";
                if(assis1Province != "0" && assis1District != 0 && assis1Org != "0" && !string.IsNullOrWhiteSpace(this.txtAssistance1.Text))
                {
                    var assistanceInfo = new BenefitedFromOrg
                    {
                        Date = this.AssistedDate1.Value,
                        ProvinceCode = assis1Province,
                        DistrictID = assis1District,
                        AssistanceProvided = this.txtAssistance1.Text,
                        OrgCode = assis1Org,
                    };
                    if (!string.IsNullOrWhiteSpace(this.txtAssistedVillage1.Text)) { assistanceInfo.Village = this.txtAssistedVillage1.Text; }
                }
                else {
                    MessageBox.Show("Please provide organization and assistance informaiton.");
                    return;
                }
                var assis2Province = this.cmbAssistedInProvince2.SelectedValue != null ? this.cmbAssistedInProvince2.SelectedValue.ToString() : "0";
                var assis2District = this.cmbAssistedInDistrict2.SelectedValue != null ? int.Parse(this.cmbAssistedInDistrict2.SelectedValue.ToString()) : 0;
                var assis2Org = this.cmbAssistedOrg2.SelectedValue != null ? this.cmbAssistedOrg2.SelectedValue.ToString() : "0";
                if (assis2Province != "0" && assis2District != 0 && assis2Org != "0" && !string.IsNullOrWhiteSpace(this.txtAssistance2.Text))
                {
                    var assistanceInfo = new BenefitedFromOrg
                    {
                        Date = this.AssistedDate2.Value,
                        ProvinceCode = assis2Province,
                        DistrictID = assis2District,
                        AssistanceProvided = this.txtAssistance2.Text,
                        OrgCode = assis2Org,
                    };
                    if (!string.IsNullOrWhiteSpace(this.txtAssistedVillage2.Text)) { assistanceInfo.Village = this.txtAssistedVillage2.Text; }
                }
            }
            if(!this.rdoBenefitedYes.Checked && !this.rdoBenefitedNo.Checked)
            {
                MessageBox.Show("Please answer: How you benefited from UNHCR or IOM.");
                return;
            }
            this.beneficiary.TransportationDate = this.dateTransportationDate.Value;
            var transportOptions = gbTransportation.Controls.OfType<CheckBox>().Where(c => c.Checked);
            foreach(var chb in transportOptions)
            {
                var transOption = new Transportation() {
                    TypedCode = chb.Name,
                };
                if(chb.Name == "TransportOther" && !string.IsNullOrWhiteSpace(this.txtTransportOther.Text))
                {
                    transOption.Other = this.txtTransportOther.Text;
                }
                else if(chb.Name == "TransportOther" && string.IsNullOrWhiteSpace(this.txtTransportOther.Text)) {
                    MessageBox.Show("Please specify transportation other case");
                    return;
                }
                this.beneficiary.Transports.Add(transOption);
            }
            if (!string.IsNullOrWhiteSpace(this.txtTransAdditionalInfo.Text))
            {
                this.beneficiary.TransportationInfo = this.txtTransAdditionalInfo.Text;
            }
            if (!string.IsNullOrWhiteSpace(this.txtTransAccompaniedBy.Text))
            {
                this.beneficiary.TransportAccompaniedBy = this.txtTransAccompaniedBy.Text;
            }
            if (!string.IsNullOrWhiteSpace(this.txtTransMobile.Text))
            {
                this.beneficiary.TransportAccomByNo = this.txtTransMobile.Text;
            }
            this.tabBeneficiary.SelectedIndex = 6;
        }

        private void btnAssistanceNeedsPrevious2_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 4;
        }

        private void btnReintegNeed1NeedNext_Click(object sender, EventArgs e)
        {
            //Clear list
            this.beneficiary.LivelihoodEmpNeeds.Clear();
            this.beneficiary.NeedTools.Clear();
            this.beneficiary.MainConcerns.Clear();

            var reing1Need = this.cmbReintegrationNeeds1.SelectedValue != null ? this.cmbReintegrationNeeds1.SelectedValue.ToString() : "0";
            if(reing1Need != "0")
            {
                this.beneficiary.TopNeed1 = reing1Need;
                if(reing1Need == "TNOther" && !string.IsNullOrWhiteSpace(this.txtReintegrationNeeds1Other.Text))
                {
                    this.beneficiary.TopNeed1Other = this.tabReintegrationNeeds1.Text;
                }
                else if(reing1Need == "TNOther" && string.IsNullOrWhiteSpace(this.txtReintegrationNeeds1Other.Text))
                {
                    MessageBox.Show("Please specify other first need.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please specify first need.");
                return;
            }
            var reing2Need = this.cmbReintegrationNeeds2.SelectedValue != null ? this.cmbReintegrationNeeds2.SelectedValue.ToString() : "0";
            if(reing2Need != "0")
            {
                this.beneficiary.TopNeed2 = reing2Need;
                if(reing2Need == "TNOther" && !string.IsNullOrWhiteSpace(this.txtReintegrationNeeds2Other.Text))
                {
                    this.beneficiary.TopNeed2Other = this.txtReintegrationNeeds2Other.Text;
                }
                else if(reing2Need == "TNOther" && string.IsNullOrWhiteSpace(this.txtReintegrationNeeds2Other.Text))
                {
                    MessageBox.Show("Please specify other second need.");
                    return;
                }
            }
            var reing3Need = this.cmbReintegrationNeeds3.SelectedValue != null ? this.cmbReintegrationNeeds3.SelectedValue.ToString() : "0";
            if(reing3Need != "0")
            {
                this.beneficiary.TopNeed3 = reing3Need;
                if(reing3Need == "TNOther" && !string.IsNullOrWhiteSpace(this.txtReintegrationNeeds3Other.Text))
                {
                    this.beneficiary.TopNeed3Other = this.txtReintegrationNeeds3Other.Text;
                }
                else if(reing3Need == "TNOther" && string.IsNullOrWhiteSpace(this.txtReintegrationNeeds3Other.Text))
                {
                    MessageBox.Show("Please specify other third need.");
                    return;
                }
            }
            var intendToDo = this.cmbIntendToDo.SelectedValue != null ? this.cmbIntendToDo.SelectedValue.ToString() : "0";
            if(intendToDo != "0")
            {
                this.beneficiary.IntendToDo = intendToDo;
                if(intendToDo == "RTH" && !string.IsNullOrWhiteSpace(this.txtReturnToHostReason.Text))
                {
                    this.beneficiary.IntendToDoOther = this.txtReturnToHostReason.Text;
                }
                else if (intendToDo == "RTH" && string.IsNullOrWhiteSpace(this.txtReturnToHostReason.Text))
                {
                    MessageBox.Show("Please state the reason for returning back to host country.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please specify what are you intend to do.");
                return;
            }
            var profession = this.cmbProfession.SelectedValue != null ? this.cmbProfession.SelectedValue.ToString() : "0";
            if(profession != "0")
            {
                this.beneficiary.ProfessionInHostCountry = profession;
                if(profession == "ProfOther" && !string.IsNullOrWhiteSpace(this.txtProfessionOther.Text))
                {
                    this.beneficiary.ProfessionInHostCountryOther = this.txtProfessionOther.Text;
                }
                else if(profession == "ProfOther" && string.IsNullOrWhiteSpace(this.txtProfessionOther.Text)) {
                    MessageBox.Show("Please specify other profession.");
                    return;
                }
            }
            else
            {
                MessageBox.Show("Please specify your profession in host country.");
            }
            if (this.chkVocationalTraining.Checked)
            {
                var whatCanHelp = new LivelihoodEmpNeed {
                    NeedCode = "VTFH"
                };
                this.beneficiary.LivelihoodEmpNeeds.Add(whatCanHelp);
            }
            if (this.chkProvisionOfTools.Checked)
            {
                var whatCanHelp = new LivelihoodEmpNeed {
                    NeedCode = "POT"
                };
                this.beneficiary.LivelihoodEmpNeeds.Add(whatCanHelp);
                var tools = gbToolsNeeded.Controls.OfType<CheckBox>().Where(c => c.Checked);
                foreach(var tool in tools)
                {
                    var needTool = new NeedTool
                    {
                        ToolCode = tool.Name
                    };
                    if(tool.Name == "ToolsOther" && !string.IsNullOrWhiteSpace(this.txtToolsOther.Text))
                    {
                        needTool.Other = this.txtToolsOther.Text;
                    }
                    else if(tool.Name == "ToolsOther" && string.IsNullOrWhiteSpace(this.txtToolsOther.Text))
                    {
                        MessageBox.Show("Plase speciry other tool.");
                        return;
                    }
                    this.beneficiary.NeedTools.Add(needTool);
                }
            }
            if (this.rdoCanYouReadWriteYes.Checked)
            {
                this.beneficiary.HoHCanReadWrite = true;
                var HoHEducationLevel = this.cmbHoHEducationLevel.SelectedValue != null ? this.cmbHoHEducationLevel.SelectedValue.ToString() : "0";
                if(HoHEducationLevel != "0")
                {
                    this.beneficiary.HoHEducationLevel = HoHEducationLevel;
                    if(HoHEducationLevel == "EDUOther" && !string.IsNullOrWhiteSpace(this.txtHoHEducationOther.Text))
                    {
                        this.beneficiary.HoHEducationLevelOther = this.txtHoHEducationOther.Text;
                    }
                    else if(HoHEducationLevel == "EDUOther" && string.IsNullOrWhiteSpace(this.txtHoHEducationOther.Text))
                    {
                        MessageBox.Show("Please specify: HoH education level other");
                        return;
                    }
                }
                else { MessageBox.Show("Please HoH highest education level.");return; }
            }
            else if (this.rdoCanYouReadWriteNo.Checked)
            {
                this.beneficiary.HoHCanReadWrite = false;
            }
            else
            {
                MessageBox.Show("Please specify: Can HoH read and write.");
                return;
            }
            var mainConcerns = this.gbMainConcerns.Controls.OfType<CheckBox>().Where(c => c.Checked);
            if(mainConcerns.Count() != 0) {
                foreach (var concern in mainConcerns)
                {
                    var mcon = new MainConcern
                    {
                        ConcernCode = concern.Name
                    };
                    if (concern.Name == "WAY3MCOther" && !string.IsNullOrWhiteSpace(this.txtWAY3MCOther.Text))
                    {
                        mcon.Other = this.txtWAY3MCOther.Text;
                    }
                    else if (concern.Name == "WAY3MCOther" && string.IsNullOrWhiteSpace(this.txtWAY3MCOther.Text))
                    {
                        MessageBox.Show("Plase speciry other conern.");
                        return;
                    }
                    this.beneficiary.MainConcerns.Add(mcon);
                }
            }
            else
            {
                MessageBox.Show("Please specify your 3 main concern in Afghanistan.");
                return;
            }
            this.tabBeneficiary.SelectedIndex = 7;
        }

        private void btnReintegNeed1Previous_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 5;
        }

        private void btnReintegNeeds2Next_Click(object sender, EventArgs e)
        {
            //Clear list
            this.beneficiary.HostCountrySchools.Clear();
            if (!string.IsNullOrWhiteSpace(this.txtNumHaveTaskira.Text))
            {
                this.beneficiary.NumHHHaveTaskira = int.Parse(this.txtNumHaveTaskira.Text);
            }
            if (!string.IsNullOrWhiteSpace(this.txtNumHavePassport.Text))
            {
                this.beneficiary.NumHHHavePassport = int.Parse(this.txtNumHavePassport.Text);
            }
            if (!string.IsNullOrWhiteSpace(this.txtchkNumHaveOtherDoc.Text))
            {
                this.beneficiary.NumHHHaveDocOther = int.Parse(this.txtchkNumHaveOtherDoc.Text);
            }
            if (this.rdoHaveLivelihoodOrSavingYes.Checked)
            {
                this.beneficiary.DoHaveSecureLivelihood = true;
            }
            else if(this.rdoHaveLivelihoodOrSavingNo.Checked){
                this.beneficiary.DoHaveSecureLivelihood = false;
            }
            else
            {
                MessageBox.Show("Please specify: Do you have secure means of livelihood or savings to subsist from? ");
                return;
            }
            if (this.rdoDidChildrenGoToSchoolYes.Checked)
            {
                this.beneficiary.DidChildrenGoToSchoole = true;
                var schoolsType = this.pnlSchoolTypeInHostCountry.Controls.OfType<CheckBox>().Where(c => c.Checked);
                if(schoolsType.Count()  > 0)
                {
                    foreach(var chb in schoolsType)
                    {
                        var schoolType = new HostCountrySchool {
                            SchoolTypeCode = chb.Name
                        };
                        this.beneficiary.HostCountrySchools.Add(schoolType);
                    }
                }
                else { MessageBox.Show("Please speciry shcool type in host country");return; }
            }else if (this.rdoDidChildrenGoToSchoolNo.Checked)
            {
                this.beneficiary.DidChildrenGoToSchoole = false;
            }
            else
            {
                MessageBox.Show("Please specify did your children go school in host country.");
                return;
            }
            if (!string.IsNullOrEmpty(this.txtNumChildrenAttendSchool.Text))
            {
                this.beneficiary.NumChildrenAttendedSchoole = int.Parse(this.txtNumChildrenAttendSchool.Text);
            }
            this.tabBeneficiary.SelectedIndex = 8;
        }

        private void btnReintegNeeds2Previous_Click(object sender, EventArgs e)
        {
            this.tabBeneficiary.SelectedIndex = 6;
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


        private void HostCountry_CheckedChanged(object sender, EventArgs e)
        {
            if (this.Pakistan.Checked || this.Iran.Checked)
            {
                var countryCode = this.Pakistan.Checked ? "PAK" : "IRN";
                var hostProvinceList = db.HostCountryProvinces.Where(p => p.CountryCode == countryCode).Select(p => new { p.ProvinceId, ProvinceName = p.EnName }).ToList();
                hostProvinceList.Insert(0, new { ProvinceId = 0, ProvinceName = "-- Please Select --" });
                this.cmbBeforReturnProvince.DataSource = hostProvinceList;
                this.cmbBeforReturnProvince.DisplayMember = "ProvinceName";
                this.cmbBeforReturnProvince.ValueMember = "ProvinceId";
                this.cmbBeforReturnProvince.SelectedIndex = 0;

                this.txtCOther.Visible = false;
            }
            else if (this.COther.Checked)
            {
                this.cmbBeforReturnProvince.DataSource = null;
                this.cmbBeforReturnDistrict.DataSource = null;
                this.txtCOther.Visible = true;
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
                var filter = firstReason != "LROther" ? firstReason : "";
                var secondReasonForLeavingList = DbHelper.GetcmbLookups("LREASON").Where(l=>l.ValueCode != filter).ToList();
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
                var filter1 = firstReason != "LROther" ? firstReason : "";
                var filter2 = seconReason != "LROther" ? seconReason : "";
                var secondReasonForLeavingList = DbHelper.GetcmbLookups("LREASON").Where(l=> l.ValueCode != filter1 && l.ValueCode != filter2).ToList();
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
                var filter = firstNeed != "TNOther" ? firstNeed : "";
                var need2List = DbHelper.GetcmbLookups("TOPNEED").Where(l=>l.ValueCode != filter).ToList();
                this.cmbReintegrationNeeds2.DataSource = need2List;
                this.cmbReintegrationNeeds2.DisplayMember = "LookupName";
                this.cmbReintegrationNeeds2.ValueMember = "ValueCode";
                this.cmbReintegrationNeeds2.SelectedIndex = 0;
            }
            if (firstNeed == "TNOther")
            {
                this.pnlFirstNeed.Visible = true;
            }
            else
            {
                this.pnlFirstNeed.Visible = false;
            }
        }

        private void cmbReintegrationNeeds2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var firstNeed = this.cmbReintegrationNeeds1.SelectedValue.ToString();
            var seconNeed = this.cmbReintegrationNeeds2.SelectedValue.ToString();
            if (firstNeed != "0" && seconNeed != "0")
            {
                var filter1 = firstNeed != "TNOther" ? firstNeed : "";
                var filter2 = seconNeed != "TNOther" ? seconNeed : "";
                var needsList = DbHelper.GetcmbLookups("TOPNEED").Where(l=>l.ValueCode != filter1 && l.ValueCode != filter2).ToList();
                this.cmbReintegrationNeeds3.DataSource = needsList;
                this.cmbReintegrationNeeds3.DisplayMember = "LookupName";
                this.cmbReintegrationNeeds3.ValueMember = "ValueCode";
                this.cmbReintegrationNeeds3.SelectedIndex = 0;
            }
            if (seconNeed == "TNOther")
            {
                this.pnlSecondNeed.Visible = true;
            }
            else
            {
                this.pnlSecondNeed.Visible = false;
            }
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
            if (relation == "0")
            {
                MessageBox.Show("Relationship is required.");
                return;

            }
            if ((relation == "HH" || relation == "HSelf") && string.IsNullOrWhiteSpace(this.txtDrFName.Text) && string.IsNullOrWhiteSpace(this.txtDrFName.Text))
            {
                MessageBox.Show("نام و نام پدر لازمی است");
                return;
            }
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(fName)
                && gender != "0" && mStatus != "0" && !string.IsNullOrWhiteSpace(age))
            {
                string[] row = {
                    name,
                    this.txtDrName.Text,
                    fName,
                    this.txtDrFName.Text,
                    this.cmbGender.Text.ToString(),
                    this.cmbMaritalStatus.Text.ToString(),
                    age.ToString(),
                    idType  == "0" ? "" : this.cmbIDType.Text.ToString(),
                    idNumber,
                    relation == "0" ? "" : this.cmbRelationship.Text.ToString(),
                    contactNo
                };
                var indObj = new IndividualVM
                {
                    Name = name,
                    DrName = this.txtDrName.Text,
                    FName = fName,
                    DrFName = this.txtDrFName.Text,
                    GenderCode = this.cmbGender.SelectedValue.ToString(),
                    MaritalStatusCode = this.cmbMaritalStatus.SelectedValue.ToString(),
                    Age = int.Parse(age),
                    IDTypeCode = this.cmbIDType.Text.ToString(),
                    IDNo = idNumber,
                    RelationshipCode = this.cmbRelationship.Text.ToString(),
                    ContactNumber = contactNo
                };
                if(idType != "0")
                {
                    indObj.IDTypeCode = idType;
                }
                if(relation != "0")
                {
                    indObj.RelationshipCode = relation;
                }
                this.beneficiary.Individuals.Add(indObj);
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
                this.txtDrName.Text = string.Empty;
                this.txtDrFName.Text = string.Empty;
            }
            else
            {   
                MessageBox.Show("Please provide family member information.");
                return;
            }
            

        }

        private void btnSaveBeneficiary_Click(object sender, EventArgs e)
        {
           var respons =  BeneficiaryController.Add(this.beneficiary);
            if (respons)
            {
                if(MessageBox.Show("Beneficiary successfully saved.","Success",MessageBoxButtons.OK,MessageBoxIcon.Asterisk) == DialogResult.OK)
                {
                    this.Dispose();
                }
                
            }
            else
            {
                MessageBox.Show("Can not save beneficiary, Please check the required field and try again","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
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

        private void rdoBenefitedYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoBenefitedYes.Checked)
            {
                this.gbBenefited.Visible = true;
            }
            else
            {
                this.gbBenefited.Visible = false;
            }
        }

        private void cmbReintegrationNeeds3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var thirdNeed = this.cmbReintegrationNeeds3.SelectedValue.ToString();
            if (thirdNeed == "TNOther")
            {
                this.pnlThirdNeed.Visible = true;
            }
            else
            {
                this.pnlThirdNeed.Visible = false;
            }
        }

        private void rdoDidChildrenGoToSchoolYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoDidChildrenGoToSchoolYes.Checked)
            {
                this.pnlSchoolTypeInHostCountry.Visible = true;
            }
            else
            {
                this.pnlSchoolTypeInHostCountry.Visible = false;
            }
        }

        private void PSNOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.PSNOther.Checked)
            {
                this.txtPSNOther.Visible = true;
            }
            else
            {
                this.txtPSNOther.Visible = false;
            }
        }

        private void MFRPOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.MFRPOther.Checked)
            {
                this.txtMFRPOther.Visible = true;
            }
            else
            {
                this.txtMFRPOther.Visible = false;
            }
        }

        private void rdoFMemberStayedBehindYes_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoFMemberStayedBehindYes.Checked)
            {
                this.pnlFamilyMemStayYesHowMany.Visible = true;
            }
            else
            {
                this.pnlFamilyMemStayYesHowMany.Visible = false;
            }
        }

        private void TransportOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.TransportOther.Checked)
            {
                this.txtTransportOther.Visible = true;
            }
            else
            {
                this.txtTransportOther.Visible = false;
            }
        }

        private void cmbProfession_SelectedIndexChanged(object sender, EventArgs e)
        {
            var profession = this.cmbProfession.SelectedValue != null ? this.cmbProfession.SelectedValue.ToString() : "0";
            if (profession == "ProfOther")
            {
                this.lblProOther.Visible = true;
                this.txtProfessionOther.Visible = true;
            }
            else
            {
                this.lblProOther.Visible = false;
                this.txtProfessionOther.Visible = false;
            }
        }

        private void cmbIDType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            var idType = this.cmbIDType.SelectedValue != null ? this.cmbIDType.SelectedValue.ToString() : "0";
            if (idType != "0")
            {
                this.txtIDNo.Enabled = true;
            }
            else
            {
                this.txtIDNo.Enabled = false;
            }
        }

        private void cmbWhereWillYouLive_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if(this.cmbWhereWillYouLive.SelectedValue.ToString() == "RH")
            {
                this.pnlRentHouseInfo.Enabled = true;
            }
            else
            {
                this.pnlRentHouseInfo.Enabled = false;
            }
        }

        private void chkTBRCR_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void WAY3MCOther_CheckedChanged(object sender, EventArgs e)
        {
            if (this.WAY3MCOther.Checked)
            {
                this.txtWAY3MCOther.Visible = true;
            }
            else
            {
                this.txtWAY3MCOther.Visible = false;
            }
        }

        private void tsmDeleteMemeber_Click(object sender, EventArgs e)
        {
            if(lvFamilyMember.SelectedItems.Count > 0)
            {
                if (MessageBox.Show("Do you want to remove this member", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    var itemIndex = lvFamilyMember.SelectedIndices[0];
                    this.lvFamilyMember.Items.Remove(lvFamilyMember.SelectedItems[0]);
                    this.beneficiary.Individuals.RemoveAt(itemIndex);
                }
            }
        }

        private void rdoBeneficiaryType_CheckedChanged(object sender, EventArgs e)
        {
            if (this.rdoBeneficiaryTypeFamily.Checked)
            {
                this.cmbRelationship.SelectedValue = "HH";
            }else if(this.rdoBeneficiaryTypeIndividual.Checked)
            {
                this.cmbRelationship.SelectedValue = "HSelf";
            }
            else
            {
                this.cmbRelationship.SelectedValue = "0";
            }
        }

       
    }
}
