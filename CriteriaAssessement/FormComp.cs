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
    public partial class FormComp : Form
    {
        public FormComp()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void FormComp_Load(object sender, EventArgs e)
        {
            btnDelete.Enabled = false;
            Refresh();
            dtpStart.Value = DateTime.Now;
            dtpEnd.Value = DateTime.Now;
        }

        new private void Refresh()
        {
            cbComp.Items.Clear();
            cbSkill.Items.Clear();
            cbSkill.Items.Add("");
            dt = DAL.SelectTable("СоревнованиеИКомп");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() != "")
                    cbComp.Items.Add(dt.Rows[i][1].ToString());
                if (dt.Rows[i][4].ToString() != "" && !cbSkill.Items.Contains(dt.Rows[i][4].ToString() + " " + dt.Rows[i][5].ToString()))
                    cbSkill.Items.Add(dt.Rows[i][4].ToString() + " " + dt.Rows[i][5].ToString());
            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            cbComp.SelectedIndex = cbComp.Items.IndexOf("");
            cbSkill.SelectedIndex = cbSkill.Items.IndexOf("");
            tbNameComp.Text = "";
            dtpEnd.Value = DateTime.Now;
            dtpStart.Value = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 0, 0, 0);

        }

        private void cbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbComp.SelectedIndex != -1)
            {
                tbNameComp.Text = dt.Rows[cbComp.SelectedIndex][1].ToString();
                dtpStart.Value = Convert.ToDateTime(dt.Rows[cbComp.SelectedIndex][2].ToString());
                dtpEnd.Value = Convert.ToDateTime(dt.Rows[cbComp.SelectedIndex][3].ToString());
                if (dt.Rows[cbComp.SelectedIndex][4].ToString() != "")
                    cbSkill.SelectedIndex = cbSkill.Items.IndexOf(dt.Rows[cbComp.SelectedIndex][4].ToString() + " " + dt.Rows[cbComp.SelectedIndex][5].ToString());
                else
                    cbSkill.SelectedIndex = 0;
                btnDelete.Enabled = true;
            }
            else
            {
                btnDelete.Enabled = false;
                tbNameComp.Text = "";
                dtpEnd.Value = DateTime.Now;
                dtpStart.Value = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 0, 0, 0);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbNameComp.Text.Trim() != "")
            {
                if (dtpStart.Value.Date <= dtpEnd.Value.Date)
                {
                    string newSel = tbNameComp.Text.Trim();
                    int id;
                    int idComp = 0;
                    if (cbComp.SelectedIndex != -1)
                        idComp = Convert.ToInt32(dt.Rows[cbComp.SelectedIndex][0]);
                    string idSkill = "";
                    if (cbSkill.SelectedIndex > 0)
                        idSkill = dt.Rows[dt.Rows.IndexOf(dt.Select("КодКомпетенции + ' ' + Название1 = '" + cbSkill.SelectedItem + "'")[0])][4].ToString();
                    DAL.UpdateComp(idComp, tbNameComp.Text.Trim(), dtpStart.Value.ToString("yyyy-MM-dd"), dtpEnd.Value.ToString("yyyy-MM-dd"), idSkill, out id);
                    Refresh();
                    try
                    {
                        cbComp.SelectedIndex = dt.Rows.IndexOf(dt.Select("КодСоревнования = '" + id + "'")[0]);
                    }
                    catch { }
                }
                else
                    MessageBox.Show("Дата окночания не может быть раньше даты начала");
            }
            else
                MessageBox.Show("Заполнены не все поля");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранное соревнование?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DAL.DeleteComp(Convert.ToInt32(dt.Rows[cbComp.SelectedIndex][0]));
                Refresh();
                tbNameComp.Text = "";
                dtpStart.Value = DateTime.Now;
                dtpEnd.Value = DateTime.Now;
            }
        }

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            dtpStart.Value = new DateTime(dtpStart.Value.Year, dtpStart.Value.Month, dtpStart.Value.Day, 0, 0, 0);
            if (dtpEnd.Value.CompareTo(dtpStart.Value) < 0)
                dtpEnd.Value = dtpStart.Value;
            dtpEnd.MinDate = dtpStart.Value;
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            dtpEnd.Value = new DateTime(dtpEnd.Value.Year, dtpEnd.Value.Month, dtpEnd.Value.Day, 0, 0, 0);
            if (dtpEnd.Value.CompareTo(dtpStart.Value) < 0)
                dtpStart.Value = dtpEnd.Value;
            dtpStart.MaxDate = dtpEnd.Value;
        }
    }
}
