namespace CriteriaAssessement
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.tlpForm = new System.Windows.Forms.TableLayoutPanel();
            this.pMenu = new System.Windows.Forms.Panel();
            this.tlpMenu = new System.Windows.Forms.TableLayoutPanel();
            this.btnAssessment = new System.Windows.Forms.Button();
            this.btnMem = new System.Windows.Forms.Button();
            this.btnSkill = new System.Windows.Forms.Button();
            this.btnSections = new System.Windows.Forms.Button();
            this.btnCri = new System.Windows.Forms.Button();
            this.btnComp = new System.Windows.Forms.Button();
            this.btnInfo = new System.Windows.Forms.Button();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.pForm = new System.Windows.Forms.Panel();
            this.tlpForm.SuspendLayout();
            this.pMenu.SuspendLayout();
            this.tlpMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpForm
            // 
            this.tlpForm.ColumnCount = 2;
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.tlpForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.tlpForm.Controls.Add(this.pMenu, 0, 0);
            this.tlpForm.Controls.Add(this.pForm, 1, 0);
            this.tlpForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpForm.Location = new System.Drawing.Point(0, 0);
            this.tlpForm.Name = "tlpForm";
            this.tlpForm.RowCount = 1;
            this.tlpForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpForm.Size = new System.Drawing.Size(974, 611);
            this.tlpForm.TabIndex = 0;
            // 
            // pMenu
            // 
            this.pMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(255)))));
            this.pMenu.Controls.Add(this.tlpMenu);
            this.pMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pMenu.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.pMenu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.pMenu.Location = new System.Drawing.Point(3, 3);
            this.pMenu.Name = "pMenu";
            this.pMenu.Size = new System.Drawing.Size(169, 605);
            this.pMenu.TabIndex = 0;
            // 
            // tlpMenu
            // 
            this.tlpMenu.BackColor = System.Drawing.Color.Transparent;
            this.tlpMenu.ColumnCount = 1;
            this.tlpMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMenu.Controls.Add(this.btnAssessment, 0, 5);
            this.tlpMenu.Controls.Add(this.btnMem, 0, 4);
            this.tlpMenu.Controls.Add(this.btnSkill, 0, 0);
            this.tlpMenu.Controls.Add(this.btnSections, 0, 1);
            this.tlpMenu.Controls.Add(this.btnCri, 0, 3);
            this.tlpMenu.Controls.Add(this.btnComp, 0, 2);
            this.tlpMenu.Controls.Add(this.btnInfo, 0, 8);
            this.tlpMenu.Controls.Add(this.btnExport, 0, 7);
            this.tlpMenu.Controls.Add(this.btnImport, 0, 6);
            this.tlpMenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMenu.Location = new System.Drawing.Point(0, 0);
            this.tlpMenu.Name = "tlpMenu";
            this.tlpMenu.RowCount = 9;
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.11F));
            this.tlpMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 11.12F));
            this.tlpMenu.Size = new System.Drawing.Size(169, 605);
            this.tlpMenu.TabIndex = 0;
            // 
            // btnAssessment
            // 
            this.btnAssessment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAssessment.BackColor = System.Drawing.Color.White;
            this.btnAssessment.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Assessment;
            this.btnAssessment.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAssessment.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAssessment.ForeColor = System.Drawing.Color.Black;
            this.btnAssessment.Location = new System.Drawing.Point(15, 350);
            this.btnAssessment.Margin = new System.Windows.Forms.Padding(15);
            this.btnAssessment.Name = "btnAssessment";
            this.btnAssessment.Size = new System.Drawing.Size(139, 37);
            this.btnAssessment.TabIndex = 8;
            this.btnAssessment.UseVisualStyleBackColor = false;
            this.btnAssessment.Click += new System.EventHandler(this.btnAssessment_Click);
            // 
            // btnMem
            // 
            this.btnMem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMem.BackColor = System.Drawing.Color.White;
            this.btnMem.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Mem;
            this.btnMem.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnMem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMem.ForeColor = System.Drawing.Color.Black;
            this.btnMem.Location = new System.Drawing.Point(15, 283);
            this.btnMem.Margin = new System.Windows.Forms.Padding(15);
            this.btnMem.Name = "btnMem";
            this.btnMem.Size = new System.Drawing.Size(139, 37);
            this.btnMem.TabIndex = 7;
            this.btnMem.UseVisualStyleBackColor = false;
            this.btnMem.Click += new System.EventHandler(this.btnMem_Click);
            // 
            // btnSkill
            // 
            this.btnSkill.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSkill.BackColor = System.Drawing.Color.White;
            this.btnSkill.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Skills;
            this.btnSkill.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSkill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSkill.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSkill.ForeColor = System.Drawing.Color.Black;
            this.btnSkill.Location = new System.Drawing.Point(15, 15);
            this.btnSkill.Margin = new System.Windows.Forms.Padding(15);
            this.btnSkill.Name = "btnSkill";
            this.btnSkill.Size = new System.Drawing.Size(139, 37);
            this.btnSkill.TabIndex = 0;
            this.btnSkill.UseVisualStyleBackColor = false;
            this.btnSkill.Click += new System.EventHandler(this.btnSkill_Click);
            // 
            // btnSections
            // 
            this.btnSections.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSections.BackColor = System.Drawing.Color.White;
            this.btnSections.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Sections;
            this.btnSections.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnSections.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSections.ForeColor = System.Drawing.Color.Black;
            this.btnSections.Location = new System.Drawing.Point(15, 82);
            this.btnSections.Margin = new System.Windows.Forms.Padding(15);
            this.btnSections.Name = "btnSections";
            this.btnSections.Size = new System.Drawing.Size(139, 37);
            this.btnSections.TabIndex = 4;
            this.btnSections.UseVisualStyleBackColor = false;
            this.btnSections.Click += new System.EventHandler(this.btnSections_Click);
            // 
            // btnCri
            // 
            this.btnCri.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCri.BackColor = System.Drawing.Color.White;
            this.btnCri.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Criteria;
            this.btnCri.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnCri.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCri.ForeColor = System.Drawing.Color.Black;
            this.btnCri.Location = new System.Drawing.Point(15, 216);
            this.btnCri.Margin = new System.Windows.Forms.Padding(15);
            this.btnCri.Name = "btnCri";
            this.btnCri.Size = new System.Drawing.Size(139, 37);
            this.btnCri.TabIndex = 5;
            this.btnCri.UseVisualStyleBackColor = false;
            this.btnCri.Click += new System.EventHandler(this.btnCri_Click);
            // 
            // btnComp
            // 
            this.btnComp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnComp.BackColor = System.Drawing.Color.White;
            this.btnComp.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Comp;
            this.btnComp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnComp.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnComp.ForeColor = System.Drawing.Color.Black;
            this.btnComp.Location = new System.Drawing.Point(15, 149);
            this.btnComp.Margin = new System.Windows.Forms.Padding(15);
            this.btnComp.Name = "btnComp";
            this.btnComp.Size = new System.Drawing.Size(139, 37);
            this.btnComp.TabIndex = 2;
            this.btnComp.UseVisualStyleBackColor = false;
            this.btnComp.Click += new System.EventHandler(this.btnComp_Click);
            // 
            // btnInfo
            // 
            this.btnInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInfo.BackColor = System.Drawing.Color.White;
            this.btnInfo.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Info;
            this.btnInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnInfo.ForeColor = System.Drawing.Color.Black;
            this.btnInfo.Location = new System.Drawing.Point(15, 554);
            this.btnInfo.Margin = new System.Windows.Forms.Padding(15, 18, 15, 18);
            this.btnInfo.Name = "btnInfo";
            this.btnInfo.Size = new System.Drawing.Size(139, 33);
            this.btnInfo.TabIndex = 6;
            this.btnInfo.UseVisualStyleBackColor = false;
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.White;
            this.btnExport.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Export;
            this.btnExport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnExport.ForeColor = System.Drawing.Color.Black;
            this.btnExport.Location = new System.Drawing.Point(15, 484);
            this.btnExport.Margin = new System.Windows.Forms.Padding(15);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(139, 37);
            this.btnExport.TabIndex = 1;
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnImport
            // 
            this.btnImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnImport.BackColor = System.Drawing.Color.White;
            this.btnImport.BackgroundImage = global::CriteriaAssessement.Properties.Resources.Import;
            this.btnImport.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.ForeColor = System.Drawing.Color.Black;
            this.btnImport.Location = new System.Drawing.Point(15, 417);
            this.btnImport.Margin = new System.Windows.Forms.Padding(15);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(139, 37);
            this.btnImport.TabIndex = 3;
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // pForm
            // 
            this.pForm.BackColor = System.Drawing.Color.White;
            this.pForm.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pForm.BackgroundImage")));
            this.pForm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pForm.Location = new System.Drawing.Point(178, 3);
            this.pForm.Name = "pForm";
            this.pForm.Size = new System.Drawing.Size(793, 605);
            this.pForm.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 611);
            this.Controls.Add(this.tlpForm);
            this.Name = "FormMain";
            this.ShowIcon = false;
            this.Text = "Оценивание работ по критериям";
            this.tlpForm.ResumeLayout(false);
            this.pMenu.ResumeLayout(false);
            this.tlpMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpForm;
        private System.Windows.Forms.Panel pMenu;
        private System.Windows.Forms.Panel pForm;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Button btnSkill;
        private System.Windows.Forms.Button btnComp;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Button btnSections;
        private System.Windows.Forms.Button btnCri;
        private System.Windows.Forms.Button btnInfo;
        private System.Windows.Forms.TableLayoutPanel tlpMenu;
        private System.Windows.Forms.Button btnAssessment;
        private System.Windows.Forms.Button btnMem;
    }
}