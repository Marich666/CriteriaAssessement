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
    public partial class FormAspect : Form
    {
        public FormAspect()
        {
            InitializeComponent();
        }

        public FormAspect(int id)
        {
            InitializeComponent();
            idSubCri = id;
            dgv.DataSource = bs;
            ToolTip t = new ToolTip();
            t.SetToolTip(btnCancel, "Откат до момента посленего сохранения");
        }

        DataTable dt = new DataTable();
        DataTable dtDel = new DataTable();
        int idSubCri;
        int maxNum;

        private void FormAspect_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            dgv.Columns.Clear();
            dt = DAL.SelectTable("Аспект", idSubCri.ToString());
            bs.DataSource = dt;

            DataGridViewButtonColumn bc = new DataGridViewButtonColumn();
            bc.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            bc.Visible = true;
            bc.Text = "Перейти";
            bc.HeaderText = "Пояснения";
            bc.UseColumnTextForButtonValue = true;
            bc.FlatStyle = FlatStyle.Popup;
            dgv.Columns.Add(bc);
            dgv.Columns[0].Visible = false;
            dgv.Columns[1].Visible = false;
            dtDel.Clear();
            dtDel = dt.Clone();
            if (dt.Rows.Count > 0)
                maxNum = Convert.ToInt32(dt.Rows[dt.Rows.Count - 1][1]);
            else
                maxNum = 1;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dt.Rows.Add();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                while (dgv.SelectedRows.Count > 0)
                {
                    int index = dgv.SelectedRows[0].Index;
                    for (int i = 0; i <= dgv.SelectedRows[0].Index; i++)
                        if (dt.Rows[i].RowState == DataRowState.Deleted)
                            index++;
                    dtDel.ImportRow(dt.Rows[index]);
                    dt.Rows[index].Delete();
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            DAL.UpdateAsp(idSubCri, dt, dtDel, maxNum);
            dtDel.Clear();
            Refresh();
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 6 && dgv[0, e.RowIndex].Value.ToString() != "")
            {
                Form f = new FormAnnotation(Convert.ToInt32(dt.Rows[e.RowIndex][0]));
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
