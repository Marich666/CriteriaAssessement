namespace CriteriaAssessement
{
    partial class FormAssessment
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgv = new System.Windows.Forms.DataGridView();
            this.cbComp = new System.Windows.Forms.ComboBox();
            this.cbMem = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.btnLoad = new System.Windows.Forms.Button();
            this.bs = new System.Windows.Forms.BindingSource(this.components);
            this.cbSubCri = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pComp = new System.Windows.Forms.Panel();
            this.lblComp = new System.Windows.Forms.Label();
            this.pSubCri = new System.Windows.Forms.Panel();
            this.lblSubCri = new System.Windows.Forms.Label();
            this.pMem = new System.Windows.Forms.Panel();
            this.lblMem = new System.Windows.Forms.Label();
            this.pType = new System.Windows.Forms.Panel();
            this.lblType = new System.Windows.Forms.Label();
            this.pButtons = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).BeginInit();
            this.tlpForm.SuspendLayout();
            this.pComp.SuspendLayout();
            this.pSubCri.SuspendLayout();
            this.pMem.SuspendLayout();
            this.pType.SuspendLayout();
            this.pButtons.SuspendLayout();
            this.tlpButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.AllowUserToAddRows = false;
            this.dgv.AllowUserToDeleteRows = false;
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            this.dgv.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv.Location = new System.Drawing.Point(15, 342);
            this.dgv.Margin = new System.Windows.Forms.Padding(15, 3, 15, 3);
            this.dgv.Name = "dgv";
            this.dgv.Size = new System.Drawing.Size(763, 260);
            this.dgv.TabIndex = 0;
            // 
            // cbComp
            // 
            this.cbComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbComp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbComp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbComp.FormattingEnabled = true;
            this.cbComp.Location = new System.Drawing.Point(19, 38);
            this.cbComp.Name = "cbComp";
            this.cbComp.Size = new System.Drawing.Size(759, 28);
            this.cbComp.TabIndex = 1;
            this.cbComp.SelectedIndexChanged += new System.EventHandler(this.cbComp_SelectedIndexChanged);
            // 
            // cbMem
            // 
            this.cbMem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbMem.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbMem.FormattingEnabled = true;
            this.cbMem.Location = new System.Drawing.Point(19, 38);
            this.cbMem.Name = "cbMem";
            this.cbMem.Size = new System.Drawing.Size(759, 28);
            this.cbMem.TabIndex = 2;
            this.cbMem.SelectedIndexChanged += new System.EventHandler(this.cbMem_SelectedIndexChanged);
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "O",
            "J"});
            this.cbType.Location = new System.Drawing.Point(19, 38);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(185, 28);
            this.cbType.TabIndex = 3;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoad.BackColor = System.Drawing.Color.White;
            this.btnLoad.FlatAppearance.BorderSize = 0;
            this.btnLoad.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnLoad.Location = new System.Drawing.Point(15, 15);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(15);
            this.btnLoad.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(168, 29);
            this.btnLoad.TabIndex = 4;
            this.btnLoad.Text = "Вывести";
            this.btnLoad.UseVisualStyleBackColor = false;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // cbSubCri
            // 
            this.cbSubCri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSubCri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSubCri.FormattingEnabled = true;
            this.cbSubCri.Items.AddRange(new object[] {
            "O",
            "J"});
            this.cbSubCri.Location = new System.Drawing.Point(19, 38);
            this.cbSubCri.Name = "cbSubCri";
            this.cbSubCri.Size = new System.Drawing.Size(185, 28);
            this.cbSubCri.TabIndex = 5;
            this.cbSubCri.SelectedIndexChanged += new System.EventHandler(this.cbSubCri_SelectedIndexChanged);
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
            this.btnSave.Location = new System.Drawing.Point(213, 15);
            this.btnSave.Margin = new System.Windows.Forms.Padding(15);
            this.btnSave.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(168, 29);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Сохранить";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.pComp, 0, 0);
            this.tlpForm.Controls.Add(this.dgv, 0, 5);
            this.tlpForm.Controls.Add(this.pSubCri, 0, 1);
            this.tlpForm.Controls.Add(this.pMem, 0, 2);
            this.tlpForm.Controls.Add(this.pType, 0, 3);
            this.tlpForm.Controls.Add(this.pButtons, 0, 4);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 6;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.15385F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 81.84615F));
            this.tlpForm.Size = new System.Drawing.Size(793, 605);
            this.tlpForm.TabIndex = 7;
            // 
            // pComp
            // 
            this.pComp.Controls.Add(this.lblComp);
            this.pComp.Controls.Add(this.cbComp);
            this.pComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pComp.Location = new System.Drawing.Point(0, 0);
            this.pComp.Margin = new System.Windows.Forms.Padding(0);
            this.pComp.Name = "pComp";
            this.pComp.Size = new System.Drawing.Size(793, 70);
            this.pComp.TabIndex = 0;
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblComp.Location = new System.Drawing.Point(15, 15);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(202, 20);
            this.lblComp.TabIndex = 2;
            this.lblComp.Text = "Выберите соревнование*";
            // 
            // pSubCri
            // 
            this.pSubCri.Controls.Add(this.lblSubCri);
            this.pSubCri.Controls.Add(this.cbSubCri);
            this.pSubCri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSubCri.Location = new System.Drawing.Point(0, 70);
            this.pSubCri.Margin = new System.Windows.Forms.Padding(0);
            this.pSubCri.Name = "pSubCri";
            this.pSubCri.Size = new System.Drawing.Size(793, 70);
            this.pSubCri.TabIndex = 1;
            // 
            // lblSubCri
            // 
            this.lblSubCri.AutoSize = true;
            this.lblSubCri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubCri.Location = new System.Drawing.Point(15, 15);
            this.lblSubCri.Name = "lblSubCri";
            this.lblSubCri.Size = new System.Drawing.Size(195, 20);
            this.lblSubCri.TabIndex = 6;
            this.lblSubCri.Text = "Выберите подкритерий*";
            // 
            // pMem
            // 
            this.pMem.Controls.Add(this.lblMem);
            this.pMem.Controls.Add(this.cbMem);
            this.pMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMem.Location = new System.Drawing.Point(0, 140);
            this.pMem.Margin = new System.Windows.Forms.Padding(0);
            this.pMem.Name = "pMem";
            this.pMem.Size = new System.Drawing.Size(793, 70);
            this.pMem.TabIndex = 2;
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMem.Location = new System.Drawing.Point(15, 15);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(172, 20);
            this.lblMem.TabIndex = 3;
            this.lblMem.Text = "Выберите участника*";
            // 
            // pType
            // 
            this.pType.Controls.Add(this.lblType);
            this.pType.Controls.Add(this.cbType);
            this.pType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pType.Location = new System.Drawing.Point(0, 210);
            this.pType.Margin = new System.Windows.Forms.Padding(0);
            this.pType.Name = "pType";
            this.pType.Size = new System.Drawing.Size(793, 70);
            this.pType.TabIndex = 3;
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblType.Location = new System.Drawing.Point(15, 15);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(196, 20);
            this.lblType.TabIndex = 4;
            this.lblType.Text = "Выберите тип аспектов*";
            // 
            // pButtons
            // 
            this.pButtons.Controls.Add(this.tlpButtons);
            this.pButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pButtons.Location = new System.Drawing.Point(0, 280);
            this.pButtons.Margin = new System.Windows.Forms.Padding(0);
            this.pButtons.Name = "pButtons";
            this.pButtons.Size = new System.Drawing.Size(793, 59);
            this.pButtons.TabIndex = 4;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 4;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButtons.Controls.Add(this.btnLoad, 0, 0);
            this.tlpButtons.Controls.Add(this.btnSave, 1, 0);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(0, 0);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 1;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Size = new System.Drawing.Size(793, 59);
            this.tlpButtons.TabIndex = 7;
            // 
            // FormAssessment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(793, 605);
            this.Controls.Add(this.tlpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormAssessment";
            this.Text = "FormAssessment";
            this.Load += new System.EventHandler(this.FormAssessment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bs)).EndInit();
            this.tlpForm.ResumeLayout(false);
            this.pComp.ResumeLayout(false);
            this.pComp.PerformLayout();
            this.pSubCri.ResumeLayout(false);
            this.pSubCri.PerformLayout();
            this.pMem.ResumeLayout(false);
            this.pMem.PerformLayout();
            this.pType.ResumeLayout(false);
            this.pType.PerformLayout();
            this.pButtons.ResumeLayout(false);
            this.tlpButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.ComboBox cbComp;
        private System.Windows.Forms.ComboBox cbMem;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.BindingSource bs;
        private System.Windows.Forms.ComboBox cbSubCri;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pComp;
        private System.Windows.Forms.Panel pSubCri;
        private System.Windows.Forms.Panel pMem;
        private System.Windows.Forms.Panel pType;
        private System.Windows.Forms.Panel pButtons;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblSubCri;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.Label lblType;
    }
}