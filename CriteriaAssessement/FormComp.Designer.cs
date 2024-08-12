namespace CriteriaAssessement
{
    partial class FormComp
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
            this.lblName = new System.Windows.Forms.Label();
            this.tbNameComp = new System.Windows.Forms.TextBox();
            this.cbComp = new System.Windows.Forms.ComboBox();
            this.lblComp = new System.Windows.Forms.Label();
            this.lblStart = new System.Windows.Forms.Label();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblEnd = new System.Windows.Forms.Label();
            this.cbSkill = new System.Windows.Forms.ComboBox();
            this.lblSkill = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pComp = new System.Windows.Forms.Panel();
            this.pName = new System.Windows.Forms.Panel();
            this.pStart = new System.Windows.Forms.Panel();
            this.pEnd = new System.Windows.Forms.Panel();
            this.pSkill = new System.Windows.Forms.Panel();
            this.pButtons = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpForm.SuspendLayout();
            this.pComp.SuspendLayout();
            this.pName.SuspendLayout();
            this.pStart.SuspendLayout();
            this.pEnd.SuspendLayout();
            this.pSkill.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblName.Location = new System.Drawing.Point(15, 15);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(89, 20);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Название*";
            // 
            // tbNameComp
            // 
            this.tbNameComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNameComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tbNameComp.Location = new System.Drawing.Point(19, 38);
            this.tbNameComp.Name = "tbNameComp";
            this.tbNameComp.Size = new System.Drawing.Size(751, 26);
            this.tbNameComp.TabIndex = 6;
            // 
            // cbComp
            // 
            this.cbComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComp.BackColor = System.Drawing.Color.White;
            this.cbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbComp.FormattingEnabled = true;
            this.cbComp.Location = new System.Drawing.Point(19, 38);
            this.cbComp.Name = "cbComp";
            this.cbComp.Size = new System.Drawing.Size(751, 28);
            this.cbComp.TabIndex = 5;
            this.cbComp.SelectedIndexChanged += new System.EventHandler(this.cbComp_SelectedIndexChanged);
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblComp.Location = new System.Drawing.Point(15, 15);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(316, 20);
            this.lblComp.TabIndex = 4;
            this.lblComp.Text = "Выберите соревнование для изменения";
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblStart.Location = new System.Drawing.Point(15, 15);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(113, 20);
            this.lblStart.TabIndex = 8;
            this.lblStart.Text = "Дата начала*";
            // 
            // dtpStart
            // 
            this.dtpStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpStart.Location = new System.Drawing.Point(19, 38);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(189, 26);
            this.dtpStart.TabIndex = 9;
            this.dtpStart.ValueChanged += new System.EventHandler(this.dtpStart_ValueChanged);
            // 
            // dtpEnd
            // 
            this.dtpEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dtpEnd.Location = new System.Drawing.Point(15, 38);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(193, 26);
            this.dtpEnd.TabIndex = 11;
            this.dtpEnd.ValueChanged += new System.EventHandler(this.dtpEnd_ValueChanged);
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblEnd.Location = new System.Drawing.Point(15, 15);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(138, 20);
            this.lblEnd.TabIndex = 10;
            this.lblEnd.Text = "Дата окончания*";
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
            this.cbSkill.TabIndex = 13;
            // 
            // lblSkill
            // 
            this.lblSkill.AutoSize = true;
            this.lblSkill.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSkill.Location = new System.Drawing.Point(15, 15);
            this.lblSkill.Name = "lblSkill";
            this.lblSkill.Size = new System.Drawing.Size(111, 20);
            this.lblSkill.TabIndex = 12;
            this.lblSkill.Text = "Компетенция";
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
            this.btnDelete.Size = new System.Drawing.Size(166, 29);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Удалить";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
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
            this.btnSave.Size = new System.Drawing.Size(166, 29);
            this.btnSave.TabIndex = 15;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            this.btnCreate.Size = new System.Drawing.Size(166, 29);
            this.btnCreate.TabIndex = 14;
            this.btnCreate.Text = "Создать";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.pComp, 0, 0);
            this.tlpForm.Controls.Add(this.pName, 0, 1);
            this.tlpForm.Controls.Add(this.pStart, 0, 2);
            this.tlpForm.Controls.Add(this.pEnd, 0, 3);
            this.tlpForm.Controls.Add(this.pSkill, 0, 4);
            this.tlpForm.Controls.Add(this.pButtons, 0, 5);
            this.tlpForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 7;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60.74767F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 39.25233F));
            this.tlpForm.Size = new System.Drawing.Size(793, 607);
            this.tlpForm.TabIndex = 17;
            // 
            // pComp
            // 
            this.pComp.Controls.Add(this.lblComp);
            this.pComp.Controls.Add(this.cbComp);
            this.pComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pComp.Location = new System.Drawing.Point(3, 3);
            this.pComp.Name = "pComp";
            this.pComp.Size = new System.Drawing.Size(787, 94);
            this.pComp.TabIndex = 0;
            // 
            // pName
            // 
            this.pName.Controls.Add(this.lblName);
            this.pName.Controls.Add(this.tbNameComp);
            this.pName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pName.Location = new System.Drawing.Point(3, 103);
            this.pName.Name = "pName";
            this.pName.Size = new System.Drawing.Size(787, 94);
            this.pName.TabIndex = 1;
            // 
            // pStart
            // 
            this.pStart.Controls.Add(this.dtpStart);
            this.pStart.Controls.Add(this.lblStart);
            this.pStart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pStart.Location = new System.Drawing.Point(3, 203);
            this.pStart.Name = "pStart";
            this.pStart.Size = new System.Drawing.Size(787, 94);
            this.pStart.TabIndex = 2;
            // 
            // pEnd
            // 
            this.pEnd.Controls.Add(this.lblEnd);
            this.pEnd.Controls.Add(this.dtpEnd);
            this.pEnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pEnd.Location = new System.Drawing.Point(3, 303);
            this.pEnd.Name = "pEnd";
            this.pEnd.Size = new System.Drawing.Size(787, 94);
            this.pEnd.TabIndex = 3;
            // 
            // pSkill
            // 
            this.pSkill.Controls.Add(this.cbSkill);
            this.pSkill.Controls.Add(this.lblSkill);
            this.pSkill.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSkill.Location = new System.Drawing.Point(3, 403);
            this.pSkill.Name = "pSkill";
            this.pSkill.Size = new System.Drawing.Size(787, 94);
            this.pSkill.TabIndex = 4;
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.tlpButtons);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pButtons.Location = new System.Drawing.Point(3, 503);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(787, 59);
            this.pButtons.TabIndex = 5;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.Controls.Add(this.btnCreate, 0, 0);
            this.tlpButtons.Controls.Add(this.btnDelete, 2, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(787, 59);
            this.tlpButtons.TabIndex = 0;
            // 
            // FormComp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(793, 605);
            this.Controls.Add(this.tlpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormComp";
            this.Text = "FormComp";
            this.Load += new System.EventHandler(this.FormComp_Load);
            this.tlpForm.ResumeLayout(false);
            this.pComp.ResumeLayout(false);
            this.pComp.PerformLayout();
            this.pName.ResumeLayout(false);
            this.pName.PerformLayout();
            this.pStart.ResumeLayout(false);
            this.pStart.PerformLayout();
            this.pEnd.ResumeLayout(false);
            this.pEnd.PerformLayout();
            this.pSkill.ResumeLayout(false);
            this.pSkill.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox tbNameComp;
        private System.Windows.Forms.ComboBox cbComp;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblStart;
        private System.Windows.Forms.DateTimePicker dtpStart;
        private System.Windows.Forms.DateTimePicker dtpEnd;
        private System.Windows.Forms.Label lblEnd;
        private System.Windows.Forms.ComboBox cbSkill;
        private System.Windows.Forms.Label lblSkill;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pComp;
        private System.Windows.Forms.Panel pName;
        private System.Windows.Forms.Panel pStart;
        private System.Windows.Forms.Panel pEnd;
        private System.Windows.Forms.Panel pSkill;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
    }
}