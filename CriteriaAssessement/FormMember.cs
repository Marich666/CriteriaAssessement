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
    public partial class FormMember : Form
    {
        public FormMember()
        {
            InitializeComponent();
        }

        DataTable dtComp = new DataTable();
        DataTable dtMem = new DataTable();
        DataTable dtRole = new DataTable();

        private void Members_Load(object sender, EventArgs e)
        {
            dtp.MaxDate = DateTime.Now.AddYears(-5);
            Refresh();
        }

        new private void Refresh()
        {
            cbComp.Items.Clear();
            cbRole.Items.Clear();
            cbRole.Items.Add("");
            dtRole = DAL.SelectTable("Роль");
            for (int i = 0; i < dtRole.Rows.Count; i++)
                cbRole.Items.Add(dtRole.Rows[i][1].ToString());
            dtComp = DAL.SelectTable("Соревнование");
            for (int i = 0; i < dtComp.Rows.Count; i++)
                cbComp.Items.Add(dtComp.Rows[i][1].ToString());
            if (cbComp.Items.Count > 0)
                cbComp.SelectedIndex = 0;
        }

            private void cbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbMem.Items.Clear();
            ClearAll();
            cbMem.SelectedIndex = -1;
            dtMem = DAL.SelectTable("Участник", dtComp.Rows[cbComp.SelectedIndex][0].ToString());
            for (int i = 0; i < dtMem.Rows.Count; i++)
                cbMem.Items.Add(dtMem.Rows[i][1].ToString() + " " + dtMem.Rows[i][2].ToString() + " " + dtMem.Rows[i][3].ToString());
            if (cbMem.Items.Count>0)
                cbMem.SelectedIndex = 0;
        }

        private void cbMem_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMem.SelectedIndex!=-1)
            {
                tbSurName.Text = dtMem.Rows[cbMem.SelectedIndex][1].ToString();
                tbName.Text = dtMem.Rows[cbMem.SelectedIndex][2].ToString();
                tbPatr.Text = dtMem.Rows[cbMem.SelectedIndex][3].ToString();
                if (dtMem.Rows[cbMem.SelectedIndex][4].ToString() != "")
                {
                    dtp.Checked = true;
                    dtp.Value = Convert.ToDateTime(dtMem.Rows[cbMem.SelectedIndex][4].ToString());
                }
                else
                {
                    dtp.Value = dtp.MaxDate;
                    dtp.Checked = false;
                }
                if (dtMem.Rows[cbMem.SelectedIndex][5].ToString().ToUpper() == "М")
                    cbSex.SelectedIndex = cbSex.Items.IndexOf("М");
                else if (dtMem.Rows[cbMem.SelectedIndex][5].ToString().ToUpper() == "Ж")
                    cbSex.SelectedIndex = cbSex.Items.IndexOf("Ж");
                else
                    cbSex.SelectedIndex = 0;
                tbInst.Text = dtMem.Rows[cbMem.SelectedIndex][6].ToString();
                tbGroup.Text = dtMem.Rows[cbMem.SelectedIndex][7].ToString();
                if (dtMem.Rows[cbMem.SelectedIndex][8].ToString() != "")
                    cbRole.SelectedIndex = cbRole.Items.IndexOf(dtMem.Rows[cbMem.SelectedIndex][8].ToString());
                else
                    cbRole.SelectedIndex = 0;
            }
            else
                ClearAll();
        }

        private void ClearAll()
        {
            tbSurName.Text = "";
            tbName.Text = "";
            tbPatr.Text = "";
            dtp.Value = dtp.MaxDate;
            dtp.Checked = false;
            cbSex.SelectedIndex = 0;
            tbInst.Text = "";
            tbGroup.Text = "";
            cbRole.SelectedIndex = 0;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            cbMem.SelectedIndex = -1;
            ClearAll();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Trim() != "" && tbSurName.Text.Trim()!="")
            {
                int id = -1;
                string date = "";
                string sex = "";
                int idRole = -1;
                int idMem = -1;
                if (cbMem.SelectedIndex != -1)
                    idMem = Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]);
                if (dtp.Checked)
                    date = dtp.Value.ToString("yyyy-MM-dd");
                if (cbSex.SelectedIndex!=-1)
                     sex = cbSex.SelectedItem.ToString();
                if (cbRole.SelectedIndex-1 != -1)
                    idRole = Convert.ToInt32(dtRole.Rows[cbRole.SelectedIndex-1][0]);
                DAL.UpdateMembers(idMem, tbSurName.Text, tbName.Text, tbPatr.Text, date, sex, tbInst.Text, tbGroup.Text, Convert.ToInt32(dtComp.Rows[cbComp.SelectedIndex][0]), idRole, out id);
                Refresh();
                cbMem.SelectedIndex = dtMem.Rows.IndexOf(dtMem.Select("КодЧеловека = " + id)[0]);
            }
            else
                MessageBox.Show("Заполнены не все обязательные поля");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите удалить выбранного участника?", "Удаление", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                DAL.DeleteMem(Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]));
                Refresh();
                cbMem.SelectedIndex = -1;
                ClearAll();
            }
        }
    }
}
