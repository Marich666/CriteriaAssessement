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
    public partial class FormSection : Form
    {
        public FormSection()
        {
            InitializeComponent();
            dgv.DataSource = bs;
        }

        DataTable dt = new DataTable();
        DataTable datTab = new DataTable();
        DataTable dtDel = new DataTable();

        private void FormSection_Load(object sender, EventArgs e)
        {
            dt = DAL.SelectTable("КомпетенцияWS");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() != "")
                    cbSkill.Items.Add(dt.Rows[i][1].ToString());
            }
            cbSkill.SelectedIndex = 0;
        }

        private void cbSkill_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            datTab = DAL.SelectTable("Раздел", dt.Rows[cbSkill.SelectedIndex][0].ToString());
            bs.DataSource = datTab;
            dgv.Columns[0].Visible = false;
            dtDel.Clear();
            dtDel = datTab.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            datTab.Rows.Add();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.UpdateSect(Convert.ToInt32(dt.Rows[cbSkill.SelectedIndex][0]), datTab, dtDel);
            dtDel.Clear();
            Refresh();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            while (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                for (int i = 0; i <= dgv.SelectedRows[0].Index; i++)
                    if (datTab.Rows[i].RowState == DataRowState.Deleted)
                        index++;
                dtDel.ImportRow(datTab.Rows[index]);
                datTab.Rows[index].Delete();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            MessageBox.Show(btnAdd.Size.ToString());
            Refresh();
        }
    }
}
