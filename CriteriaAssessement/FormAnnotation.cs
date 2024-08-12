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
    public partial class FormAnnotation : Form
    {
        public FormAnnotation()
        {
            InitializeComponent();
        }

        public FormAnnotation(int idAspect)
        {
            InitializeComponent();
            idAsp = idAspect;
            dgv.DataSource = bs;
            ToolTip t = new ToolTip();
            t.SetToolTip(btnCancel, "Откат до момента посленего сохранения");
        }

        DataTable dt = new DataTable();
        DataTable dtDel = new DataTable();
        int idAsp;

        private void FormAnnotation_Load(object sender, EventArgs e)
        {
            Refresh();
        }

        new private void Refresh()
        {
            dgv.Columns.Clear();
            dt = DAL.SelectTable("Пояснение", idAsp.ToString());
            bs.DataSource = dt;
            
            dgv.Columns[0].Visible = false;
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
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgv.SelectedRows.Count > 0)
            {
                int index = dgv.SelectedRows[0].Index;
                while (dgv.SelectedRows.Count > 0)
                {
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
            DAL.UpdateAnnot(idAsp, dt, dtDel);
            dtDel.Clear();
            Refresh();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Refresh();
        }
    }
}
