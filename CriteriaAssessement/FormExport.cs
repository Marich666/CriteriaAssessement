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
    public partial class FormExport : Form
    {
        public FormExport()
        {
            InitializeComponent();
        }
        
        DataTable dtMem = new DataTable();
        DataTable dtComp = new DataTable();
        DataTable dtSubCri = new DataTable();

        private void FormExport_Load(object sender, EventArgs e)
        {
            dtComp = DAL.SelectTable("Экспорт");
            cbComp.ValueMember = "КодСоревнования";
            cbComp.DisplayMember = "Название";
            cbComp.DataSource = dtComp;

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

            cbComp.SelectedIndex = 0;
            cbWhat.SelectedIndex = 0;
            cbType.SelectedIndex = 0;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            if (cbWhat.SelectedItem.ToString() == "Критерии оценивания")
                DAL.SaveComp(Convert.ToInt32(cbComp.SelectedValue));
            else if (cbWhat.SelectedItem.ToString() == "Участники")
                DAL.SaveMem(Convert.ToInt32(cbComp.SelectedValue));
            else if (cbWhat.SelectedItem.ToString() == "Результаты проведения соревнования")
                DAL.SaveResults(Convert.ToInt32(cbComp.SelectedValue));
            else
            {
                if (cbType.SelectedItem.ToString() == "O")
                {
                    DAL.ExportCriteria('O', Convert.ToInt32(dtSubCri.Rows[cbSubCri.SelectedIndex][0]), Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]));
                }
                else if (cbType.SelectedItem.ToString() == "J")
                {
                    DAL.ExportCriteria('J', Convert.ToInt32(dtSubCri.Rows[cbSubCri.SelectedIndex][0]), Convert.ToInt32(dtMem.Rows[cbMem.SelectedIndex][0]));
                }
            }
        }

        private void cbInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbWhat.SelectedItem.ToString() == "Бланк оценивания участника")
            {
                pSubCri.Visible = true;
                pType.Visible = true;
                pMem.Visible = true;
            }
            else
            {
                pSubCri.Visible = false;
                pType.Visible = false;
                pMem.Visible = false;
            }
        }
    }
}
