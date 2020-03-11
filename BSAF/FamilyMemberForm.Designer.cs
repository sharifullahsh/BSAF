namespace BSAF
{
    partial class FamilyMemberForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblGender = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.lblMFatherName = new System.Windows.Forms.Label();
            this.txtMName = new System.Windows.Forms.TextBox();
            this.lblMName = new System.Windows.Forms.Label();
            this.lblMaritalStatus = new System.Windows.Forms.Label();
            this.ddlMaritalStatus = new System.Windows.Forms.ComboBox();
            this.ddlIDType = new System.Windows.Forms.ComboBox();
            this.lblIDType = new System.Windows.Forms.Label();
            this.txtIDNo = new System.Windows.Forms.TextBox();
            this.lblIDNo = new System.Windows.Forms.Label();
            this.ddlGender = new System.Windows.Forms.ComboBox();
            this.txtContactNumber = new System.Windows.Forms.TextBox();
            this.lblContactNumber = new System.Windows.Forms.Label();
            this.ddlRelationship = new System.Windows.Forms.ComboBox();
            this.lblRelationship = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancelMember = new System.Windows.Forms.Button();
            this.btnAddMember = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddMember);
            this.groupBox1.Controls.Add(this.btnCancelMember);
            this.groupBox1.Controls.Add(this.txtContactNumber);
            this.groupBox1.Controls.Add(this.lblContactNumber);
            this.groupBox1.Controls.Add(this.ddlRelationship);
            this.groupBox1.Controls.Add(this.lblRelationship);
            this.groupBox1.Controls.Add(this.ddlGender);
            this.groupBox1.Controls.Add(this.txtIDNo);
            this.groupBox1.Controls.Add(this.lblIDNo);
            this.groupBox1.Controls.Add(this.ddlIDType);
            this.groupBox1.Controls.Add(this.lblIDType);
            this.groupBox1.Controls.Add(this.ddlMaritalStatus);
            this.groupBox1.Controls.Add(this.lblMaritalStatus);
            this.groupBox1.Controls.Add(this.lblGender);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.lblMFatherName);
            this.groupBox1.Controls.Add(this.txtMName);
            this.groupBox1.Controls.Add(this.lblMName);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, -74);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(676, 405);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lblGender
            // 
            this.lblGender.AutoSize = true;
            this.lblGender.Location = new System.Drawing.Point(42, 190);
            this.lblGender.Name = "lblGender";
            this.lblGender.Size = new System.Drawing.Size(42, 13);
            this.lblGender.TabIndex = 4;
            this.lblGender.Text = "Gender";
            this.lblGender.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(435, 140);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(200, 20);
            this.textBox1.TabIndex = 3;
            // 
            // lblMFatherName
            // 
            this.lblMFatherName.AutoSize = true;
            this.lblMFatherName.Location = new System.Drawing.Point(340, 143);
            this.lblMFatherName.Name = "lblMFatherName";
            this.lblMFatherName.Size = new System.Drawing.Size(75, 13);
            this.lblMFatherName.TabIndex = 2;
            this.lblMFatherName.Text = "Father\'s Name";
            this.lblMFatherName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtMName
            // 
            this.txtMName.Location = new System.Drawing.Point(94, 140);
            this.txtMName.Name = "txtMName";
            this.txtMName.Size = new System.Drawing.Size(200, 20);
            this.txtMName.TabIndex = 1;
            // 
            // lblMName
            // 
            this.lblMName.AutoSize = true;
            this.lblMName.Location = new System.Drawing.Point(49, 140);
            this.lblMName.Name = "lblMName";
            this.lblMName.Size = new System.Drawing.Size(35, 13);
            this.lblMName.TabIndex = 0;
            this.lblMName.Text = "Name";
            this.lblMName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblMaritalStatus
            // 
            this.lblMaritalStatus.AutoSize = true;
            this.lblMaritalStatus.Location = new System.Drawing.Point(340, 197);
            this.lblMaritalStatus.Name = "lblMaritalStatus";
            this.lblMaritalStatus.Size = new System.Drawing.Size(71, 13);
            this.lblMaritalStatus.TabIndex = 6;
            this.lblMaritalStatus.Text = "Marital Status";
            this.lblMaritalStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ddlMaritalStatus
            // 
            this.ddlMaritalStatus.FormattingEnabled = true;
            this.ddlMaritalStatus.Location = new System.Drawing.Point(435, 197);
            this.ddlMaritalStatus.Name = "ddlMaritalStatus";
            this.ddlMaritalStatus.Size = new System.Drawing.Size(200, 21);
            this.ddlMaritalStatus.TabIndex = 7;
            // 
            // ddlIDType
            // 
            this.ddlIDType.FormattingEnabled = true;
            this.ddlIDType.Location = new System.Drawing.Point(94, 244);
            this.ddlIDType.Name = "ddlIDType";
            this.ddlIDType.Size = new System.Drawing.Size(200, 21);
            this.ddlIDType.TabIndex = 9;
            // 
            // lblIDType
            // 
            this.lblIDType.AutoSize = true;
            this.lblIDType.Location = new System.Drawing.Point(39, 247);
            this.lblIDType.Name = "lblIDType";
            this.lblIDType.Size = new System.Drawing.Size(45, 13);
            this.lblIDType.TabIndex = 8;
            this.lblIDType.Text = "ID Type";
            this.lblIDType.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIDNo
            // 
            this.txtIDNo.Location = new System.Drawing.Point(435, 245);
            this.txtIDNo.Name = "txtIDNo";
            this.txtIDNo.Size = new System.Drawing.Size(200, 20);
            this.txtIDNo.TabIndex = 11;
            // 
            // lblIDNo
            // 
            this.lblIDNo.AutoSize = true;
            this.lblIDNo.Location = new System.Drawing.Point(369, 244);
            this.lblIDNo.Name = "lblIDNo";
            this.lblIDNo.Size = new System.Drawing.Size(35, 13);
            this.lblIDNo.TabIndex = 10;
            this.lblIDNo.Text = "ID No";
            this.lblIDNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlGender
            // 
            this.ddlGender.FormattingEnabled = true;
            this.ddlGender.Location = new System.Drawing.Point(94, 187);
            this.ddlGender.Name = "ddlGender";
            this.ddlGender.Size = new System.Drawing.Size(200, 21);
            this.ddlGender.TabIndex = 12;
            // 
            // txtContactNumber
            // 
            this.txtContactNumber.Location = new System.Drawing.Point(435, 296);
            this.txtContactNumber.Name = "txtContactNumber";
            this.txtContactNumber.Size = new System.Drawing.Size(200, 20);
            this.txtContactNumber.TabIndex = 16;
            // 
            // lblContactNumber
            // 
            this.lblContactNumber.AutoSize = true;
            this.lblContactNumber.Location = new System.Drawing.Point(333, 303);
            this.lblContactNumber.Name = "lblContactNumber";
            this.lblContactNumber.Size = new System.Drawing.Size(82, 13);
            this.lblContactNumber.TabIndex = 15;
            this.lblContactNumber.Text = "Contact number";
            this.lblContactNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ddlRelationship
            // 
            this.ddlRelationship.FormattingEnabled = true;
            this.ddlRelationship.Location = new System.Drawing.Point(94, 300);
            this.ddlRelationship.Name = "ddlRelationship";
            this.ddlRelationship.Size = new System.Drawing.Size(200, 21);
            this.ddlRelationship.TabIndex = 14;
            // 
            // lblRelationship
            // 
            this.lblRelationship.AutoSize = true;
            this.lblRelationship.Location = new System.Drawing.Point(19, 306);
            this.lblRelationship.Name = "lblRelationship";
            this.lblRelationship.Size = new System.Drawing.Size(65, 13);
            this.lblRelationship.TabIndex = 13;
            this.lblRelationship.Text = "Relationship";
            this.lblRelationship.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Desktop;
            this.label5.Location = new System.Drawing.Point(9, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 24);
            this.label5.TabIndex = 7;
            this.label5.Text = "Family member Information";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(0, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(684, 38);
            this.panel1.TabIndex = 17;
            // 
            // btnCancelMember
            // 
            this.btnCancelMember.Location = new System.Drawing.Point(443, 349);
            this.btnCancelMember.Name = "btnCancelMember";
            this.btnCancelMember.Size = new System.Drawing.Size(75, 23);
            this.btnCancelMember.TabIndex = 17;
            this.btnCancelMember.Text = "Cancel";
            this.btnCancelMember.UseVisualStyleBackColor = true;
            this.btnCancelMember.Click += new System.EventHandler(this.btnCancelMember_Click);
            // 
            // btnAddMember
            // 
            this.btnAddMember.Location = new System.Drawing.Point(560, 348);
            this.btnAddMember.Name = "btnAddMember";
            this.btnAddMember.Size = new System.Drawing.Size(75, 23);
            this.btnAddMember.TabIndex = 18;
            this.btnAddMember.Text = "Add";
            this.btnAddMember.UseVisualStyleBackColor = true;
            this.btnAddMember.Click += new System.EventHandler(this.btnAddMember_Click);
            // 
            // FamilyMemberForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(676, 331);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Name = "FamilyMemberForm";
            this.Text = "Family Member";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblGender;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label lblMFatherName;
        private System.Windows.Forms.TextBox txtMName;
        private System.Windows.Forms.Label lblMName;
        private System.Windows.Forms.Label lblMaritalStatus;
        private System.Windows.Forms.ComboBox ddlMaritalStatus;
        private System.Windows.Forms.ComboBox ddlGender;
        private System.Windows.Forms.TextBox txtIDNo;
        private System.Windows.Forms.Label lblIDNo;
        private System.Windows.Forms.ComboBox ddlIDType;
        private System.Windows.Forms.Label lblIDType;
        private System.Windows.Forms.TextBox txtContactNumber;
        private System.Windows.Forms.Label lblContactNumber;
        private System.Windows.Forms.ComboBox ddlRelationship;
        private System.Windows.Forms.Label lblRelationship;
        private System.Windows.Forms.Button btnAddMember;
        private System.Windows.Forms.Button btnCancelMember;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel1;
    }
}