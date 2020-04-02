namespace BSAF
{
    partial class SearchBeneficiaryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SearchBeneficiaryForm));
            this.lvBeneficiaries = new System.Windows.Forms.ListView();
            this.BeneficiaryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MFName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BeneficiaryType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ctmstSearchBeneficiary = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblMName = new System.Windows.Forms.Label();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.lblMFatherName = new System.Windows.Forms.Label();
            this.txtMFName = new System.Windows.Forms.TextBox();
            this.pnlBeneficiaryInfo = new System.Windows.Forms.Panel();
            this.rdoBeneficiaryTypeFamily = new System.Windows.Forms.RadioButton();
            this.rdoBeneficiaryTypeIndividual = new System.Windows.Forms.RadioButton();
            this.lblBeneficiaryType = new System.Windows.Forms.Label();
            this.pnlReturnStatus = new System.Windows.Forms.Panel();
            this.rdoReturnStatusDeported = new System.Windows.Forms.RadioButton();
            this.rdoReturnStatusDocClaimant = new System.Windows.Forms.RadioButton();
            this.rdoReturnStatusSpontaneous = new System.Windows.Forms.RadioButton();
            this.label8 = new System.Windows.Forms.Label();
            this.dateFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dateToDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbSearchCriteria = new System.Windows.Forms.GroupBox();
            this.pnlSearchResult = new System.Windows.Forms.Panel();
            this.ctmstSearchBeneficiary.SuspendLayout();
            this.pnlBeneficiaryInfo.SuspendLayout();
            this.pnlReturnStatus.SuspendLayout();
            this.gbSearchCriteria.SuspendLayout();
            this.pnlSearchResult.SuspendLayout();
            this.SuspendLayout();
            // 
            // lvBeneficiaries
            // 
            this.lvBeneficiaries.BackColor = System.Drawing.SystemColors.Window;
            this.lvBeneficiaries.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.BeneficiaryID,
            this.MName,
            this.MFName,
            this.SDate,
            this.ReturnStatus,
            this.BeneficiaryType});
            this.lvBeneficiaries.ContextMenuStrip = this.ctmstSearchBeneficiary;
            this.lvBeneficiaries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvBeneficiaries.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvBeneficiaries.FullRowSelect = true;
            this.lvBeneficiaries.GridLines = true;
            this.lvBeneficiaries.Location = new System.Drawing.Point(0, 14);
            this.lvBeneficiaries.Name = "lvBeneficiaries";
            this.lvBeneficiaries.Size = new System.Drawing.Size(1009, 511);
            this.lvBeneficiaries.TabIndex = 0;
            this.lvBeneficiaries.UseCompatibleStateImageBehavior = false;
            this.lvBeneficiaries.View = System.Windows.Forms.View.Details;
            // 
            // BeneficiaryID
            // 
            this.BeneficiaryID.Text = "ID";
            this.BeneficiaryID.Width = 128;
            // 
            // MName
            // 
            this.MName.Text = "Name";
            this.MName.Width = 128;
            // 
            // MFName
            // 
            this.MFName.Text = "FatherName";
            this.MFName.Width = 156;
            // 
            // SDate
            // 
            this.SDate.Text = "Screening Date";
            this.SDate.Width = 167;
            // 
            // ReturnStatus
            // 
            this.ReturnStatus.Text = "Return Status";
            this.ReturnStatus.Width = 162;
            // 
            // BeneficiaryType
            // 
            this.BeneficiaryType.Text = "Beneficiary Type";
            this.BeneficiaryType.Width = 257;
            // 
            // ctmstSearchBeneficiary
            // 
            this.ctmstSearchBeneficiary.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.ctmstSearchBeneficiary.Name = "ctmstSearchBeneficiary";
            this.ctmstSearchBeneficiary.Size = new System.Drawing.Size(95, 26);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.editToolStripMenuItem.Text = "Edit";
            this.editToolStripMenuItem.Click += new System.EventHandler(this.editToolStripMenuItem_Click);
            // 
            // lblMName
            // 
            this.lblMName.AutoSize = true;
            this.lblMName.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMName.Location = new System.Drawing.Point(10, 22);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(35, 13);
            this.lblMName.TabIndex = 22;
            this.lblMName.Text = "Name";
            this.lblMName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(51, 19);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(181, 20);
            this.txtMName.TabIndex = 20;
            // 
            // lblMFatherName
            // 
            this.lblMFatherName.AutoSize = true;
            this.lblMFatherName.ForeColor = System.Drawing.SystemColors.Window;
            this.lblMFatherName.Location = new System.Drawing.Point(237, 22);
            this.lblMFatherName.Name = "lblMFatherName";
            this.lblMFatherName.Size = new System.Drawing.Size(75, 13);
            this.lblMFatherName.TabIndex = 23;
            this.lblMFatherName.Text = "Father\'s Name";
            this.lblMFatherName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMFName
            // 
            this.txtMFName.Location = new System.Drawing.Point(318, 19);
            this.txtMFName.Name = "txtMFName";
            this.txtMFName.Size = new System.Drawing.Size(181, 20);
            this.txtMFName.TabIndex = 21;
            // 
            // pnlBeneficiaryInfo
            // 
            this.pnlBeneficiaryInfo.Controls.Add(this.rdoBeneficiaryTypeFamily);
            this.pnlBeneficiaryInfo.Controls.Add(this.rdoBeneficiaryTypeIndividual);
            this.pnlBeneficiaryInfo.Location = new System.Drawing.Point(632, 48);
            this.pnlBeneficiaryInfo.Name = "pnlBeneficiaryInfo";
            this.pnlBeneficiaryInfo.Size = new System.Drawing.Size(363, 35);
            this.pnlBeneficiaryInfo.TabIndex = 54;
            // 
            // rdoBeneficiaryTypeFamily
            // 
            this.rdoBeneficiaryTypeFamily.AutoSize = true;
            this.rdoBeneficiaryTypeFamily.ForeColor = System.Drawing.SystemColors.Window;
            this.rdoBeneficiaryTypeFamily.Location = new System.Drawing.Point(6, 8);
            this.rdoBeneficiaryTypeFamily.Name = "rdoBeneficiaryTypeFamily";
            this.rdoBeneficiaryTypeFamily.Size = new System.Drawing.Size(54, 17);
            this.rdoBeneficiaryTypeFamily.TabIndex = 4;
            this.rdoBeneficiaryTypeFamily.TabStop = true;
            this.rdoBeneficiaryTypeFamily.Text = "Family";
            this.rdoBeneficiaryTypeFamily.UseVisualStyleBackColor = true;
            // 
            // rdoBeneficiaryTypeIndividual
            // 
            this.rdoBeneficiaryTypeIndividual.AutoSize = true;
            this.rdoBeneficiaryTypeIndividual.ForeColor = System.Drawing.SystemColors.Window;
            this.rdoBeneficiaryTypeIndividual.Location = new System.Drawing.Point(82, 8);
            this.rdoBeneficiaryTypeIndividual.Name = "rdoBeneficiaryTypeIndividual";
            this.rdoBeneficiaryTypeIndividual.Size = new System.Drawing.Size(70, 17);
            this.rdoBeneficiaryTypeIndividual.TabIndex = 5;
            this.rdoBeneficiaryTypeIndividual.TabStop = true;
            this.rdoBeneficiaryTypeIndividual.Text = "Individual";
            this.rdoBeneficiaryTypeIndividual.UseVisualStyleBackColor = true;
            // 
            // lblBeneficiaryType
            // 
            this.lblBeneficiaryType.AutoSize = true;
            this.lblBeneficiaryType.BackColor = System.Drawing.Color.RoyalBlue;
            this.lblBeneficiaryType.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBeneficiaryType.ForeColor = System.Drawing.SystemColors.Window;
            this.lblBeneficiaryType.Location = new System.Drawing.Point(506, 56);
            this.lblBeneficiaryType.Name = "lblBeneficiaryType";
            this.lblBeneficiaryType.Size = new System.Drawing.Size(120, 18);
            this.lblBeneficiaryType.TabIndex = 53;
            this.lblBeneficiaryType.Text = "Beneficiary Type:";
            // 
            // pnlReturnStatus
            // 
            this.pnlReturnStatus.Controls.Add(this.rdoReturnStatusDeported);
            this.pnlReturnStatus.Controls.Add(this.rdoReturnStatusDocClaimant);
            this.pnlReturnStatus.Controls.Add(this.rdoReturnStatusSpontaneous);
            this.pnlReturnStatus.Location = new System.Drawing.Point(119, 50);
            this.pnlReturnStatus.Name = "pnlReturnStatus";
            this.pnlReturnStatus.Size = new System.Drawing.Size(375, 34);
            this.pnlReturnStatus.TabIndex = 56;
            // 
            // rdoReturnStatusDeported
            // 
            this.rdoReturnStatusDeported.AutoSize = true;
            this.rdoReturnStatusDeported.ForeColor = System.Drawing.SystemColors.Window;
            this.rdoReturnStatusDeported.Location = new System.Drawing.Point(3, 7);
            this.rdoReturnStatusDeported.Name = "rdoReturnStatusDeported";
            this.rdoReturnStatusDeported.Size = new System.Drawing.Size(69, 17);
            this.rdoReturnStatusDeported.TabIndex = 6;
            this.rdoReturnStatusDeported.TabStop = true;
            this.rdoReturnStatusDeported.Text = "Deported";
            this.rdoReturnStatusDeported.UseVisualStyleBackColor = true;
            // 
            // rdoReturnStatusDocClaimant
            // 
            this.rdoReturnStatusDocClaimant.AutoSize = true;
            this.rdoReturnStatusDocClaimant.ForeColor = System.Drawing.SystemColors.Window;
            this.rdoReturnStatusDocClaimant.Location = new System.Drawing.Point(100, 7);
            this.rdoReturnStatusDocClaimant.Name = "rdoReturnStatusDocClaimant";
            this.rdoReturnStatusDocClaimant.Size = new System.Drawing.Size(116, 17);
            this.rdoReturnStatusDocClaimant.TabIndex = 7;
            this.rdoReturnStatusDocClaimant.TabStop = true;
            this.rdoReturnStatusDocClaimant.Text = "Document claimant";
            this.rdoReturnStatusDocClaimant.UseVisualStyleBackColor = true;
            // 
            // rdoReturnStatusSpontaneous
            // 
            this.rdoReturnStatusSpontaneous.AutoSize = true;
            this.rdoReturnStatusSpontaneous.ForeColor = System.Drawing.SystemColors.Window;
            this.rdoReturnStatusSpontaneous.Location = new System.Drawing.Point(240, 7);
            this.rdoReturnStatusSpontaneous.Name = "rdoReturnStatusSpontaneous";
            this.rdoReturnStatusSpontaneous.Size = new System.Drawing.Size(130, 17);
            this.rdoReturnStatusSpontaneous.TabIndex = 8;
            this.rdoReturnStatusSpontaneous.TabStop = true;
            this.rdoReturnStatusSpontaneous.Text = "Spontaneous returnee";
            this.rdoReturnStatusSpontaneous.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.RoyalBlue;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.Window;
            this.label8.Location = new System.Drawing.Point(13, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(102, 18);
            this.label8.TabIndex = 55;
            this.label8.Text = "Return Status:";
            // 
            // dateFromDate
            // 
            this.dateFromDate.CustomFormat = "MMM dd yyyy";
            this.dateFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateFromDate.Location = new System.Drawing.Point(595, 19);
            this.dateFromDate.MinDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dateFromDate.Name = "dateFromDate";
            this.dateFromDate.Size = new System.Drawing.Size(178, 20);
            this.dateFromDate.TabIndex = 57;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.RoyalBlue;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Window;
            this.label2.Location = new System.Drawing.Point(545, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 18);
            this.label2.TabIndex = 58;
            this.label2.Text = "From";
            // 
            // dateToDate
            // 
            this.dateToDate.CustomFormat = "MMM dd yyyy";
            this.dateToDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateToDate.Location = new System.Drawing.Point(819, 19);
            this.dateToDate.MinDate = new System.DateTime(2002, 1, 1, 0, 0, 0, 0);
            this.dateToDate.Name = "dateToDate";
            this.dateToDate.Size = new System.Drawing.Size(176, 20);
            this.dateToDate.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.RoyalBlue;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(790, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 18);
            this.label1.TabIndex = 60;
            this.label1.Text = "To";
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.Blue;
            this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(920, 89);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 31);
            this.btnSearch.TabIndex = 61;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.SystemColors.WindowText;
            this.btnCancel.Location = new System.Drawing.Point(826, 89);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 31);
            this.btnCancel.TabIndex = 62;
            this.btnCancel.Text = "Reset";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // gbSearchCriteria
            // 
            this.gbSearchCriteria.BackColor = System.Drawing.Color.RoyalBlue;
            this.gbSearchCriteria.Controls.Add(this.txtMFName);
            this.gbSearchCriteria.Controls.Add(this.lblMFatherName);
            this.gbSearchCriteria.Controls.Add(this.txtMName);
            this.gbSearchCriteria.Controls.Add(this.btnCancel);
            this.gbSearchCriteria.Controls.Add(this.lblMName);
            this.gbSearchCriteria.Controls.Add(this.btnSearch);
            this.gbSearchCriteria.Controls.Add(this.lblBeneficiaryType);
            this.gbSearchCriteria.Controls.Add(this.dateToDate);
            this.gbSearchCriteria.Controls.Add(this.pnlBeneficiaryInfo);
            this.gbSearchCriteria.Controls.Add(this.label1);
            this.gbSearchCriteria.Controls.Add(this.label8);
            this.gbSearchCriteria.Controls.Add(this.dateFromDate);
            this.gbSearchCriteria.Controls.Add(this.pnlReturnStatus);
            this.gbSearchCriteria.Controls.Add(this.label2);
            this.gbSearchCriteria.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbSearchCriteria.ForeColor = System.Drawing.SystemColors.Window;
            this.gbSearchCriteria.Location = new System.Drawing.Point(0, 0);
            this.gbSearchCriteria.Name = "gbSearchCriteria";
            this.gbSearchCriteria.Size = new System.Drawing.Size(1009, 130);
            this.gbSearchCriteria.TabIndex = 64;
            this.gbSearchCriteria.TabStop = false;
            this.gbSearchCriteria.Text = "Search Criteria";
            // 
            // pnlSearchResult
            // 
            this.pnlSearchResult.AutoScroll = true;
            this.pnlSearchResult.Controls.Add(this.lvBeneficiaries);
            this.pnlSearchResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSearchResult.Location = new System.Drawing.Point(0, 136);
            this.pnlSearchResult.Name = "pnlSearchResult";
            this.pnlSearchResult.Size = new System.Drawing.Size(1009, 525);
            this.pnlSearchResult.TabIndex = 65;
            // 
            // SearchBeneficiaryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1009, 661);
            this.Controls.Add(this.pnlSearchResult);
            this.Controls.Add(this.gbSearchCriteria);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchBeneficiaryForm";
            this.Text = "Search Beneficiary";
            this.Load += new System.EventHandler(this.SearchBeneficiary_Load);
            this.ctmstSearchBeneficiary.ResumeLayout(false);
            this.pnlBeneficiaryInfo.ResumeLayout(false);
            this.pnlBeneficiaryInfo.PerformLayout();
            this.pnlReturnStatus.ResumeLayout(false);
            this.pnlReturnStatus.PerformLayout();
            this.gbSearchCriteria.ResumeLayout(false);
            this.gbSearchCriteria.PerformLayout();
            this.pnlSearchResult.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView lvBeneficiaries;
        private System.Windows.Forms.Label lblMName;
        public System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.Label lblMFatherName;
        private System.Windows.Forms.TextBox txtMFName;
        private System.Windows.Forms.Panel pnlBeneficiaryInfo;
        private System.Windows.Forms.RadioButton rdoBeneficiaryTypeFamily;
        private System.Windows.Forms.RadioButton rdoBeneficiaryTypeIndividual;
        private System.Windows.Forms.Label lblBeneficiaryType;
        private System.Windows.Forms.Panel pnlReturnStatus;
        private System.Windows.Forms.RadioButton rdoReturnStatusDeported;
        private System.Windows.Forms.RadioButton rdoReturnStatusDocClaimant;
        private System.Windows.Forms.RadioButton rdoReturnStatusSpontaneous;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dateFromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateToDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ColumnHeader BeneficiaryID;
        private System.Windows.Forms.ColumnHeader MName;
        private System.Windows.Forms.ColumnHeader MFName;
        private System.Windows.Forms.ColumnHeader SDate;
        private System.Windows.Forms.ColumnHeader ReturnStatus;
        private System.Windows.Forms.ColumnHeader BeneficiaryType;
        private System.Windows.Forms.ContextMenuStrip ctmstSearchBeneficiary;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.GroupBox gbSearchCriteria;
        private System.Windows.Forms.Panel pnlSearchResult;
    }
}