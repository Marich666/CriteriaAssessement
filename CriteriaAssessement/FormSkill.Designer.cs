namespace CriteriaAssessement
{
    partial class FormSkill
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
            this.lblSkill = new System.Windows.Forms.Label();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.tbIdSkill = new System.Windows.Forms.TextBox();
            this.lblNumber = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.tbNameSkill = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pSkill = new System.Windows.Forms.Panel();
            this.pNumber = new System.Windows.Forms.Panel();
            this.pName = new System.Windows.Forms.Panel();
            this.pButtons = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpForm.SuspendLayout();
            this.pSkill.SuspendLayout();
            this.pNumber.SuspendLayout();
            this.pName.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSkill
            // 
            this.lblSkill.AutoSize = true;
            this.lblSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSkill.Location = new System.Drawing.Point(15, 15);
            this.lblSkill.Name = "lblSkill";
            this.lblSkill.Size = new System.Drawing.Size(312, 20);
            this.lblSkill.TabIndex = 0;
            this.lblSkill.Text = "Выберите компетенцию для изменения";
            // 
            // cbSkill
            // 
            this.cbSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbSkill.BackColor = System.Drawing.Color.White;
            this.cbSkill.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSkill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSkill.FormattingEnabled = true;
            this.cbSkill.Location = new System.Drawing.Point(19, 38);
            this.cbSkill.Name = "cbSkill";
            this.cbSkill.Size = new System.Drawing.Size(751, 28);
            this.cbSkill.TabIndex = 1;
            this.cbSkill.SelectedIndexChanged += new System.EventHandler(this.cbSkill_SelectedIndexChanged);
            // 
            // tbIdSkill
            // 
            this.tbIdSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbIdSkill.Location = new System.Drawing.Point(19, 38);
            this.tbIdSkill.Name = "tbIdSkill";
            this.tbIdSkill.Size = new System.Drawing.Size(100, 26);
            this.tbIdSkill.TabIndex = 2;
            // 
            // lblNumber
            // 
            this.lblNumber.AutoSize = true;
            this.lblNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblNumber.Location = new System.Drawing.Point(15, 15);
            this.lblNumber.Name = "lblNumber";
            this.lblNumber.Size = new System.Drawing.Size(169, 20);
            this.lblNumber.TabIndex = 3;
            this.lblNumber.Text = "Номер компетенции*";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(15, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(193, 20);
            this.lblName.TabIndex = 4;
            this.lblName.Text = "Название компетенции*";
            // 
            // tbNameSkill
            // 
            this.tbNameSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbNameSkill.Location = new System.Drawing.Point(19, 38);
            this.tbNameSkill.Name = "tbNameSkill";
            this.tbNameSkill.Size = new System.Drawing.Size(751, 26);
            this.tbNameSkill.TabIndex = 5;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.BackColor = System.Drawing.Color.White;
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnCreate.Location = new System.Drawing.Point(15, 15);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(15);
            this.btnCreate.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(166, 31);
            this.btnCreate.TabIndex = 6;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnSave.Location = new System.Drawing.Point(211, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(15);
            this.btnSave.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(166, 31);
            this.btnSave.TabIndex = 7;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.BackColor = System.Drawing.Color.White;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnDelete.Location = new System.Drawing.Point(407, 15);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(15);
            this.btnDelete.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(166, 31);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.pSkill, 0, 0);
            this.tlpForm.Controls.Add(this.pNumber, 0, 1);
            this.tlpForm.Controls.Add(this.pName, 0, 2);
            this.tlpForm.Controls.Add(this.pButtons, 0, 3);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 5;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 22F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 78F));
            this.tlpForm.Size = new System.Drawing.Size(793, 605);
            this.tlpForm.TabIndex = 9;
            // 
            // pSkill
            // 
            this.pSkill.Controls.Add(this.lblSkill);
            this.pSkill.Controls.Add(this.cbSkill);
            this.pSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSkill.Location = new System.Drawing.Point(3, 3);
            this.pSkill.Name = "pSkill";
            this.pSkill.Size = new System.Drawing.Size(787, 94);
            this.pSkill.TabIndex = 0;
            // 
            // pNumber
            // 
            this.pNumber.Controls.Add(this.lblNumber);
            this.pNumber.Controls.Add(this.tbIdSkill);
            this.pNumber.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pNumber.Location = new System.Drawing.Point(3, 103);
            this.pNumber.Name = "pNumber";
            this.pNumber.Size = new System.Drawing.Size(787, 94);
            this.pNumber.TabIndex = 1;
            // 
            // pName
            // 
            this.pName.Controls.Add(this.lblName);
            this.pName.Controls.Add(this.tbNameSkill);
            this.pName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pName.Location = new System.Drawing.Point(3, 203);
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(787, 94);
            this.pName.TabIndex = 2;
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.tlpButtons);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pButtons.Location = new System.Drawing.Point(3, 303);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(787, 61);
            this.pButtons.TabIndex = 3;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.Controls.Add(this.btnSave, 1, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnCreate, 0, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpButtons.Margin = new System.Windows.Forms.Padding(15);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(787, 61);
            this.tlpButtons.TabIndex = 0;
            // 
            // FormSkill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(793, 605);
            this.Controls.Add(this.tlpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormSkill";
            this.Text = "FormSkill";
            this.Load += new System.EventHandler(this.FormSkill_Load);
            this.tlpForm.ResumeLayout(false);
            this.pSkill.ResumeLayout(false);
            this.pSkill.PerformLayout();
            this.pNumber.ResumeLayout(false);
            this.pNumber.PerformLayout();
            this.pName.ResumeLayout(false);
            this.pName.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSkill;
        private System.Windows.Forms.ComboBox cbSkill;
        private System.Windows.Forms.TextBox tbIdSkill;
        private System.Windows.Forms.Label lblNumber;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbNameSkill;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pSkill;
        private System.Windows.Forms.Panel pNumber;
        private System.Windows.Forms.Panel pName;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
    }
}