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
    public partial class FormCriteria : Form
    {
        public FormCriteria()
        {
            InitializeComponent();
        }

        Form mainF;

        public FormCriteria(Form main)
        {
            InitializeComponent();
            mainF = main;
            dgv.DataSource = bs;
        }

        DataTable dt = new DataTable();
        DataTable datTab = new DataTable();
        DataTable dtDel = new DataTable();

        private void FormCriteria_Load(object sender, EventArgs e)
        {
            cbComp.Items.Clear();
            dt = DAL.SelectTable("Соревнование");
            for (int i = 0; i < dt.Rows.Count; i++)
                cbComp.Items.Add(dt.Rows[i][1].ToString());
            cbComp.SelectedIndex = 0;
        }

        private void cbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            dgv.Columns.Clear();
            datTab = DAL.SelectTable("Критерий", dt.Rows[cbComp.SelectedIndex][0].ToString());
            bs.DataSource = datTab;
            
                DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
                bc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                bc.Visible = true;
                bc.Text = "Перейти";
                bc.HeaderText = "Подкритерии";
                bc.UseColumnTextForButtonValue = true;
                bc.FlatStyle = FlatStyle.Popup;
                dgv.Columns.Add(bc);
            dgv.Columns[0].Visible = false;
            dtDel.Clear();
            dtDel = datTab.Clone();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            datTab.Rows.Add();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
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
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3 && dgv[0, e.RowIndex].Value.ToString()!="")
            {
                Form f = new FormSubCri(Convert.ToInt32(datTab.Rows[e.RowIndex][0]), datTab.Rows[e.RowIndex][1].ToString());
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                pCri.Controls.Add(f);
                f.BringToFront();
                f.Show();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.UpdateCriteria(Convert.ToInt32(dt.Rows[cbComp.SelectedIndex][0]), datTab, dtDel);
            dtDel.Clear();
            Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
