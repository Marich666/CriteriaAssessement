using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CriteriaAssessement
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        Form f;

        private void OpenForm(Form f1)
        {
            pForm.BackgroundImage = null;
            f1.TopLevel = false;
            pForm.Controls.Add(f1);
            f1.Dock = DockStyle.Fill;
            f1.Show();
        }

        private void btnSkill_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormSkill();
            OpenForm(f);
        }

        private void btnComp_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormComp();
            OpenForm(f);
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormExport();
            OpenForm(f);
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormImport();
            OpenForm(f);
        }

        private void btnSections_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormSection();
            OpenForm(f);
        }

        private void btnCri_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormCriteria(this);
            OpenForm(f);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormSubCri();
            OpenForm(f);
        }

        private void btnMem_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormMember();
            OpenForm(f);
        }

        private void btnAssessment_Click(object sender, EventArgs e)
        {
            pForm.Controls.Remove(f);
            f = new FormAssessment();
            OpenForm(f);
        }
    }
}
