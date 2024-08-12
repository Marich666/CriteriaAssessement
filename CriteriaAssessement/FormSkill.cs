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
    public partial class FormSkill : Form
    {
        public FormSkill()
        {
            InitializeComponent();
        }

        DataTable dt;

        private void FormSkill_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            Refresh();
        }

        new private void Refresh()
        {
            cbSkill.Items.Clear();
            dt = DAL.SelectTable("КомпетенцияWS");
            for (int i = 0; i < dt.Rows.Count; i++)
                cbSkill.Items.Add(dt.Rows[i][0].ToString() + " " + dt.Rows[i][1].ToString());
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            cbSkill.SelectedIndex = cbSkill.Items.IndexOf("");
            tbIdSkill.Text = "";
            tbNameSkill.Text = "";
        }

        private void cbSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbSkill.SelectedIndex != -1)
            {
                tbIdSkill.Text = dt.Rows[cbSkill.SelectedIndex][0].ToString();
                tbNameSkill.Text = dt.Rows[cbSkill.SelectedIndex][1].ToString();
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                tbIdSkill.Text = "";
                tbNameSkill.Text = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbIdSkill.Text.Trim() != "" && tbNameSkill.Text.Trim() != "")
            {
                string oldSel = "";
                if (cbSkill.SelectedIndex != -1)
                    oldSel = dt.Rows[cbSkill.SelectedIndex][1].ToString();
                string idSkill = "";
                if (cbSkill.SelectedIndex != -1)
                    idSkill = dt.Rows[cbSkill.SelectedIndex][0].ToString();
                string id = "";
                DAL.UpdateSkill(idSkill, tbIdSkill.Text, tbNameSkill.Text, cbSkill.SelectedIndex, out id);
                Refresh();
                if (cbSkill.Items.IndexOf(id + " " + tbNameSkill.Text)!=-1)
                    cbSkill.SelectedIndex = cbSkill.Items.IndexOf(id +" "+tbNameSkill.Text);
                else
                    cbSkill.SelectedIndex = cbSkill.Items.IndexOf(id + " " + oldSel);
            }
            else
                MessageBox.Show("Заполнены не все поля");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранную компитенцию?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DAL.DeleteSkill(dt.Rows[cbSkill.SelectedIndex][0].ToString());
                Refresh();
                tbIdSkill.Text = "";
                tbNameSkill.Text = "";
            }
        }
    }
}
