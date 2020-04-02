namespace BSAF
{
    partial class SubmitToServerForm
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
            this.pnlSearchResult = new System.Windows.Forms.Panel();
            this.lvBeneficiaries = new System.Windows.Forms.ListView();
            this.BeneficiaryID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MFName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BeneficiaryType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSubmit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lblSubmitting = new System.Windows.Forms.Label();
            this.pnlSearchResult.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSearchResult
            // 
            this.pnlSearchResult.AutoScroll = true;
            this.pnlSearchResult.Controls.Add(this.lvBeneficiaries);
            this.pnlSearchResult.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlSearchResult.Location = new System.Drawing.Point(0, 96);
            this.pnlSearchResult.Name = "pnlSearchResult";
            this.pnlSearchResult.Size = new System.Drawing.Size(1009, 565);
            this.pnlSearchResult.TabIndex = 66;
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
            this.lvBeneficiaries.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.lvBeneficiaries.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvBeneficiaries.FullRowSelect = true;
            this.lvBeneficiaries.GridLines = true;
            this.lvBeneficiaries.Location = new System.Drawing.Point(0, 15);
            this.lvBeneficiaries.Name = "lvBeneficiaries";
            this.lvBeneficiaries.Size = new System.Drawing.Size(1009, 550);
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
            // btnSubmit
            // 
            this.btnSubmit.BackColor = System.Drawing.Color.Blue;
            this.btnSubmit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSubmit.ForeColor = System.Drawing.SystemColors.Window;
            this.btnSubmit.Location = new System.Drawing.Point(809, 57);
            this.btnSubmit.Name = "btnSubmit";
            this.btnSubmit.Size = new System.Drawing.Size(188, 31);
            this.btnSubmit.TabIndex = 67;
            this.btnSubmit.Text = "Submit";
            this.btnSubmit.UseVisualStyleBackColor = false;
            this.btnSubmit.Click += new System.EventHandler(this.btnSubmit_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.RoyalBlue;
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 35);
            this.panel1.TabIndex = 68;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Window;
            this.label1.Location = new System.Drawing.Point(3, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Submit Records";
            // 
            // lblSubmitting
            // 
            this.lblSubmitting.AutoSize = true;
            this.lblSubmitting.Location = new System.Drawing.Point(5, 66);
            this.lblSubmitting.Name = "lblSubmitting";
            this.lblSubmitting.Size = new System.Drawing.Size(0, 13);
            this.lblSubmitting.TabIndex = 69;
            // 
            // SubmitToServerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 661);
            this.Controls.Add(this.lblSubmitting);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnSubmit);
            this.Controls.Add(this.pnlSearchResult);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SubmitToServerForm";
            this.Text = "Submit";
            this.Load += new System.EventHandler(this.SubmitToServerForm_Load);
            this.pnlSearchResult.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnlSearchResult;
        private System.Windows.Forms.ListView lvBeneficiaries;
        private System.Windows.Forms.ColumnHeader BeneficiaryID;
        private System.Windows.Forms.ColumnHeader MName;
        private System.Windows.Forms.ColumnHeader MFName;
        private System.Windows.Forms.ColumnHeader SDate;
        private System.Windows.Forms.ColumnHeader ReturnStatus;
        private System.Windows.Forms.ColumnHeader BeneficiaryType;
        private System.Windows.Forms.Button btnSubmit;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblSubmitting;
    }
}