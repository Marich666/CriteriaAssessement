namespace CriteriaAssessement
{
    partial class FormImport
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
            this.lblComp = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.cbWhat = new System.Windows.Forms.ComboBox();
            this.lblWhat = new System.Windows.Forms.Label();
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pWhat = new System.Windows.Forms.Panel();
            this.pComp = new System.Windows.Forms.Panel();
            this.pImport = new System.Windows.Forms.Panel();
            this.tlpButton = new System.Windows.Forms.TableLayoutPanel();
            this.tlpForm.SuspendLayout();
            this.pWhat.SuspendLayout();
            this.pComp.SuspendLayout();
            this.pImport.SuspendLayout();
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
            // lblComp
            // 
            this.lblComp.AutoSize = true;
            this.lblComp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblComp.Location = new System.Drawing.Point(15, 15);
            this.lblComp.Name = "lblComp";
            this.lblComp.Size = new System.Drawing.Size(202, 20);
            this.lblComp.TabIndex = 1;
            this.lblComp.Text = "Выберите соревнование*";
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.White;
            this.btnImport.FlatAppearance.BorderSize = 0;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.btnImport.Location = new System.Drawing.Point(15, 15);
            this.btnImport.Margin = new System.Windows.Forms.Padding(15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(166, 28);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Импортировать";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // cbWhat
            // 
            this.cbWhat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWhat.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.cbWhat.FormattingEnabled = true;
            this.cbWhat.Items.AddRange(new object[] {
            "Участники",
            "Критерии оценивания"});
            this.cbWhat.Location = new System.Drawing.Point(19, 38);
            this.cbWhat.Name = "cbWhat";
            this.cbWhat.Size = new System.Drawing.Size(235, 28);
            this.cbWhat.TabIndex = 4;
            // 
            // lblWhat
            // 
            this.lblWhat.AutoSize = true;
            this.lblWhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblWhat.Location = new System.Drawing.Point(15, 15);
            this.lblWhat.Name = "lblWhat";
            this.lblWhat.Size = new System.Drawing.Size(245, 20);
            this.lblWhat.TabIndex = 6;
            this.lblWhat.Text = "Выберите что импортировать*";
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 1;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Controls.Add(this.pWhat, 0, 0);
            this.tlpForm.Controls.Add(this.pComp, 0, 1);
            this.tlpForm.Controls.Add(this.pImport, 0, 2);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 4;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 13.97849F));
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 86.02151F));
            this.tlpForm.Size = new System.Drawing.Size(793, 605);
            this.tlpForm.TabIndex = 7;
            // 
            // pWhat
            // 
            this.pWhat.Controls.Add(this.cbWhat);
            this.pWhat.Controls.Add(this.lblWhat);
            this.pWhat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pWhat.Location = new System.Drawing.Point(0, 0);
            this.pWhat.Margin = new System.Windows.Forms.Padding(0);
            this.pWhat.Name = "pWhat";
            this.pWhat.Size = new System.Drawing.Size(793, 70);
            this.pWhat.TabIndex = 0;
            // 
            // pComp
            // 
            this.pComp.Controls.Add(this.cbComp);
            this.pComp.Controls.Add(this.lblComp);
            this.pComp.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pComp.Location = new System.Drawing.Point(0, 70);
            this.pComp.Margin = new System.Windows.Forms.Padding(0);
            this.pComp.Name = "pComp";
            this.pComp.Size = new System.Drawing.Size(793, 70);
            this.pComp.TabIndex = 1;
            // 
            // pImport
            // 
            this.pImport.Controls.Add(this.tlpButton);
            this.pImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pImport.Location = new System.Drawing.Point(3, 143);
            this.pImport.Name = "pImport";
            this.pImport.Size = new System.Drawing.Size(787, 58);
            this.pImport.TabIndex = 3;
            // 
            // tlpButton
            // 
            this.tlpButton.ColumnCount = 2;
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpButton.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tlpButton.Controls.Add(this.btnImport, 0, 0);
            this.tlpButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButton.Location = new System.Drawing.Point(0, 0);
            this.tlpButton.Name = "tlpButton";
            this.tlpButton.RowCount = 1;
            this.tlpButton.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButton.Size = new System.Drawing.Size(787, 58);
            this.tlpButton.TabIndex = 0;
            // 
            // FormImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(793, 605);
            this.Controls.Add(this.tlpForm);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormImport";
            this.Text = "FormImport";
            this.Load += new System.EventHandler(this.FormImport_Load);
            this.tlpForm.ResumeLayout(false);
            this.pWhat.ResumeLayout(false);
            this.pWhat.PerformLayout();
            this.pComp.ResumeLayout(false);
            this.pComp.PerformLayout();
            this.pImport.ResumeLayout(false);
            this.tlpButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComp;
        private System.Windows.Forms.Label lblComp;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ComboBox cbWhat;
        private System.Windows.Forms.Label lblWhat;
        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pWhat;
        private System.Windows.Forms.Panel pComp;
        private System.Windows.Forms.Panel pImport;
        private System.Windows.Forms.TableLayoutPanel tlpButton;
    }
}