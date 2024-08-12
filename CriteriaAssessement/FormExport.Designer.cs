namespace CriteriaAssessement
{
    partial class FormExport
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
            this.cbComp = new System.Windows.Forms.ComboBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.cbWhat = new System.Windows.Forms.ComboBox();
            this.lblComp = new System.Windows.Forms.Label();
            this.lblWhat = new System.Windows.Forms.Label();
            this.cbSubCri = new System.Windows.Forms.ComboBox();
            this.cbMem = new System.Windows.Forms.ComboBox();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.lblSubCri = new System.Windows.Forms.Label();
            this.lblMem = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pWhat = new System.Windows.Forms.Panel();
            this.pComp = new System.Windows.Forms.Panel();
            this.pSubCri = new System.Windows.Forms.Panel();
            this.pMem = new System.Windows.Forms.Panel();
            this.pType = new System.Windows.Forms.Panel();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.tlpForm.SuspendLayout();
            this.pWhat.SuspendLayout();
            this.pComp.SuspendLayout();
            this.pSubCri.SuspendLayout();
            this.pMem.SuspendLayout();
            this.pType.SuspendLayout();
            this.tlpButton.SuspendLayout();
            this.SuspendLayout();
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
            this.cbComp.Size = new System.Drawing.Size(757, 28);
            this.cbComp.TabIndex = 0;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnExport.Location = new System.Drawing.Point(15, 15);
            this.btnExport.Margin = new System.Windows.Forms.Padding(15);
            this.btnExport.MaximumSize = new System.Drawing.Size(360, 79);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(168, 29);
            this.btnExport.TabIndex = 1;
            this.btnExport.Text = "Экспортировать";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // cbWhat
            // 
            this.cbWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbWhat.FormattingEnabled = true;
            this.cbWhat.Items.AddRange(new object[] {
            "Бланк оценивания участника",
            "Результаты проведения соревнования",
            "Критерии оценивания",
            "Участники"});
            this.cbWhat.Location = new System.Drawing.Point(19, 38);
            this.cbWhat.Name = "cbWhat";
            this.cbWhat.Size = new System.Drawing.Size(341, 28);
            this.cbWhat.TabIndex = 3;
            this.cbWhat.SelectedIndexChanged += new System.EventHandler(this.cbInfo_SelectedIndexChanged);
            // 
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblComp.Location = new System.Drawing.Point(15, 15);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(202, 20);
            this.lblComp.TabIndex = 4;
            this.lblComp.Text = "Выберите соревнование*";
            // 
            // lblWhat
            // 
            this.lblWhat.AutoSize = true;
            this.lblWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWhat.Location = new System.Drawing.Point(15, 15);
            this.lblWhat.Name = "lblWhat";
            this.lblWhat.Size = new System.Drawing.Size(250, 20);
            this.lblWhat.TabIndex = 5;
            this.lblWhat.Text = "Выберите что экспортировать*";
            // 
            // cbSubCri
            // 
            this.cbSubCri.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSubCri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSubCri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbSubCri.FormattingEnabled = true;
            this.cbSubCri.Location = new System.Drawing.Point(19, 38);
            this.cbSubCri.Name = "cbSubCri";
            this.cbSubCri.Size = new System.Drawing.Size(185, 28);
            this.cbSubCri.TabIndex = 8;
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
            this.cbMem.Size = new System.Drawing.Size(757, 28);
            this.cbMem.TabIndex = 9;
            // 
            // cbType
            // 
            this.cbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbType.DropDownWidth = 757;
            this.cbType.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbType.FormattingEnabled = true;
            this.cbType.Items.AddRange(new object[] {
            "O",
            "J"});
            this.cbType.Location = new System.Drawing.Point(19, 38);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(185, 28);
            this.cbType.TabIndex = 10;
            // 
            // lblSubCri
            // 
            this.lblSubCri.AutoSize = true;
            this.lblSubCri.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblSubCri.Location = new System.Drawing.Point(15, 15);
            this.lblSubCri.Name = "lblSubCri";
            this.lblSubCri.Size = new System.Drawing.Size(195, 20);
            this.lblSubCri.TabIndex = 11;
            this.lblSubCri.Text = "Выберите подкритерий*";
            // 
            // lblMem
            // 
            this.lblMem.AutoSize = true;
            this.lblMem.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblMem.Location = new System.Drawing.Point(15, 15);
            this.lblMem.Name = "lblMem";
            this.lblMem.Size = new System.Drawing.Size(172, 20);
            this.lblMem.TabIndex = 12;
            this.lblMem.Text = "Выберите участника*";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblType.Location = new System.Drawing.Point(15, 15);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(196, 20);
            this.lblType.TabIndex = 13;
            this.lblType.Text = "Выберите тип аспектов*";
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.pWhat, 0, 0);
            this.tlpForm.Controls.Add(this.pComp, 0, 1);
            this.tlpForm.Controls.Add(this.pSubCri, 0, 2);
            this.tlpForm.Controls.Add(this.pMem, 0, 3);
            this.tlpForm.Controls.Add(this.pType, 0, 4);
            this.tlpForm.Controls.Add(this.tlpButton, 0, 5);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 7;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 23.52941F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 76.47059F));
            this.tlpForm.Size = new System.Drawing.Size(793, 605);
            this.tlpForm.TabIndex = 14;
            // 
            // pWhat
            // 
            this.pWhat.Controls.Add(this.lblWhat);
            this.pWhat.Controls.Add(this.cbWhat);
            this.pWhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pWhat.Location = new System.Drawing.Point(0, 0);
            this.pWhat.Margin = new System.Windows.Forms.Padding(0);
            this.pWhat.Name = "pWhat";
            this.pWhat.Size = new System.Drawing.Size(793, 70);
            this.pWhat.TabIndex = 0;
            // 
            // pComp
            // 
            this.pComp.Controls.Add(this.lblComp);
            this.pComp.Controls.Add(this.cbComp);
            this.pComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pComp.Location = new System.Drawing.Point(0, 70);
            this.pComp.Margin = new System.Windows.Forms.Padding(0);
            this.pComp.Name = "pComp";
            this.pComp.Size = new System.Drawing.Size(793, 70);
            this.pComp.TabIndex = 1;
            // 
            // pSubCri
            // 
            this.pSubCri.Controls.Add(this.cbSubCri);
            this.pSubCri.Controls.Add(this.lblSubCri);
            this.pSubCri.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pSubCri.Location = new System.Drawing.Point(0, 140);
            this.pSubCri.Margin = new System.Windows.Forms.Padding(0);
            this.pSubCri.Name = "pSubCri";
            this.pSubCri.Size = new System.Drawing.Size(793, 70);
            this.pSubCri.TabIndex = 2;
            // 
            // pMem
            // 
            this.pMem.Controls.Add(this.cbMem);
            this.pMem.Controls.Add(this.lblMem);
            this.pMem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMem.Location = new System.Drawing.Point(0, 210);
            this.pMem.Margin = new System.Windows.Forms.Padding(0);
            this.pMem.Name = "pMem";
            this.pMem.Size = new System.Drawing.Size(793, 70);
            this.pMem.TabIndex = 3;
            // 
            // pType
            // 
            this.pType.Controls.Add(this.cbType);
            this.pType.Controls.Add(this.lblType);
            this.pType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pType.Location = new System.Drawing.Point(0, 280);
            this.pType.Margin = new System.Windows.Forms.Padding(0);
            this.pType.Name = "pType";
            this.pType.Size = new System.Drawing.Size(793, 70);
            this.pType.TabIndex = 4;
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 2;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpButton.Controls.Add(this.btnExport, 0, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(0, 350);
            this.tlpButton.Margin = new System.Windows.Forms.Padding(0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(793, 59);
            this.tlpButton.TabIndex = 5;
            // 
            // FormExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(793, 605);
            this.Controls.Add(this.tlpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormExport";
            this.Text = "FormExport";
            this.Load += new System.EventHandler(this.FormExport_Load);
            this.tlpForm.ResumeLayout(false);
            this.pWhat.ResumeLayout(false);
            this.pWhat.PerformLayout();
            this.pComp.ResumeLayout(false);
            this.pComp.PerformLayout();
            this.pSubCri.ResumeLayout(false);
            this.pSubCri.PerformLayout();
            this.pMem.ResumeLayout(false);
            this.pMem.PerformLayout();
            this.pType.ResumeLayout(false);
            this.pType.PerformLayout();
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComp;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.ComboBox cbWhat;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Label lblWhat;
        private System.Windows.Forms.ComboBox cbSubCri;
        private System.Windows.Forms.ComboBox cbMem;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label lblSubCri;
        private System.Windows.Forms.Label lblMem;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pWhat;
        private System.Windows.Forms.Panel pComp;
        private System.Windows.Forms.Panel pSubCri;
        private System.Windows.Forms.Panel pMem;
        private System.Windows.Forms.Panel pType;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
    }
}