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
    public partial class FormAssessment : Form
    {
        public FormAssessment()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        DataTable dtComp = new DataTable();
        DataTable dtMem = new DataTable();
        DataTable dtSubCri = new DataTable();

        private void FormAssessment_Load(object sender, EventArgs e)
        {
            dgv.DataSource = bs;
            Refresh();
            cbType.SelectedIndex = 0;
        }

        new private void Refresh()
        {
            bs.DataSource = null;
            dgv.Columns.Clear();
            cbComp.Items.Clear();
            dtComp = DAL.SelectTable("Соревнование");
            for (int i = 0; i < dtComp.Rows.Count; i++)
                cbComp.Items.Add(dtComp.Rows[i][1].ToString());
            if (cbComp.Items.Count > 0)
                cbComp.SelectedIndex = 0;
        }

        private void cbComp_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = null;
            dgv.Columns.Clear();
            cbMem.Items.Clear();
            cbMem.SelectedIndex = -1;
            dtMem = DAL.SelectTable("Участник", dtComp.Rows[cbComp.SelectedIndex][0].ToString());
            for (int i = 0; i < dtMem.Rows.Count; i++)
                cbMem.Items.Add(dtMem.Rows[i][1].ToString() + " " + dtMem.Rows[i][2].ToString() + " " + dtMem.Rows[i][3].ToString());
            if (cbMem.Items.Count > 0)
                cbMem.SelectedIndex = 0;

            cbSubCri.Items.Clear();
            cbSubCri.SelectedIndex = -1;
            dtSubCri = DAL.SelectTable("НомерПодкритерия", dtComp.Rows[cbComp.SelectedIndex][0].ToString());
            for (int i = 0; i < dtSubCri.Rows.Count; i++)
                cbSubCri.Items.Add(dtSubCri.Rows[i][1].ToString());
            if (cbSubCri.Items.Count > 0)
                cbSubCri.SelectedIndex = 0;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgv.Columns.Clear();
            if (cbComp.SelectedIndex < 0 || cbSubCri.SelectedIndex < 0 || cbMem.SelectedIndex < 0 || cbType.SelectedIndex < 0)
                MessageBox.Show("Заполните все поля");
            else
            {
                dt = DAL.FillAssessment(Convert.ToInt32(dtSubCri.Rows[cbSubCri.SelectedIndex][0]), Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]), Convert.ToChar(cbType.SelectedItem));
                if (dt != null && dt.Rows.Count>0)
                {
                    foreach (DataRow dr in dt.Rows)
                        dr[0] = dr[0].ToString() + dr[1].ToString();
                    bs.DataSource = dt;
                    dgv.Columns[1].Visible = false;
                    dgv.Columns[0].ReadOnly = true;
                    dgv.Columns[2].ReadOnly = true;
                    dgv.Columns[3].ReadOnly = true;
                    dgv.Columns[4].Visible = false;
                    dgv.Columns[5].Visible = false;

                    DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn dgvnudc = new DataGridViewNumericUpDownElements.DataGridViewNumericUpDownColumn();
                    dgvnudc.DecimalPlaces = 2;
                    dgvnudc.Minimum = 0;
                    dgvnudc.HeaderText = "Полученный балл";
                    dgv.Columns.Add(dgvnudc);

                    for (int i = 0; i < dgv.Rows.Count; i++)
                        dgv[6, i].Value = dgv[5, i].Value != DBNull.Value ? dgv[5, i].Value : 0;
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int count = 0;
            for (int i = 0; i < dgv.RowCount; i++)
                DAL.SaveAssessment(Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]), Convert.ToInt32(dtComp.Rows[cbComp.SelectedIndex][0]), Convert.ToInt32(dgv[4, i].Value), dgv[6, i].Value != DBNull.Value ? Convert.ToDouble(dgv[6, i].Value) : 0, ref count);            
        }

        private void cbSubCri_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = null;
            dgv.Columns.Clear();
        }

        private void cbMem_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = null;
            dgv.Columns.Clear();
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            bs.DataSource = null;
            dgv.Columns.Clear();
        }
    }
}
