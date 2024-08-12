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
    public partial class FormSubCri : Form
    {
        public FormSubCri()
        {
            InitializeComponent();
        }

        public FormSubCri(int id, string letter)
        {
            InitializeComponent();
            idCri = id;
            dgv.DataSource = bs;
            let = letter;
        }

        int idCri;
        string let;
        DataTable dt = new DataTable();
        DataTable dtDel = new DataTable();

        private void FormSubCri_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            dgv.Columns.Clear();
            dt = DAL.SelectTable("Подкритерий", idCri.ToString());
            bs.DataSource = dt;
            
            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bc.Visible = true;
            bc.Text = "Перейти";
            bc.HeaderText = "Аспекты";
            bc.UseColumnTextForButtonValue = true;
            bc.FlatStyle = FlatStyle.Popup;
            dgv.Columns.Add(bc);
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].ReadOnly = true;
            dtDel.Clear();
            dtDel = dt.Clone();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt.Rows.Add();
            if (dgv.Rows.Count != 1)
            {
                    dt.Rows[dt.Rows.Count - 1][1] = let + (Convert.ToInt32(dgv[1, dgv.Rows.Count - 2].Value.ToString().Substring(1)) + 1).ToString();
            }
            else
                dt.Rows[dt.Rows.Count - 1][1] = let + "1";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            while (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                for (int i = 0; i <= dgv.SelectedRows[0].Index; i++)
                    if (dt.Rows[i].RowState == DataRowState.Deleted)
                        index++;
                dtDel.ImportRow(dt.Rows[index]);
                dt.Rows[index].Delete();
                for (int i = index + 1; i < dt.Rows.Count; i++)
                    if (dt.Rows[i].RowState != DataRowState.Deleted)
                        dt.Rows[i][1] = let + (Convert.ToInt32(dt.Rows[i][1].ToString().Substring(1)) - 1).ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.UpdateSubCri(idCri, dt, dtDel);
            dtDel.Clear();
            Refresh();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 4 && dgv[0, e.RowIndex].Value.ToString() != "")
            {
                Form f = new FormAspect(Convert.ToInt32(dt.Rows[e.RowIndex][0]));
                f.TopLevel = false;
                f.Dock = DockStyle.Fill;
                pForm.Controls.Add(f);
                f.BringToFront();
                f.Show();
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
