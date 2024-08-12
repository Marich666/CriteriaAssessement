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
    public partial class FormImport : Form
    {
        public FormImport()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        private void FormImport_Load(object sender, EventArgs e)
        {
            cbWhat.SelectedIndex = 0;
            dt = DAL.SelectTable("СоревнованиеИКри");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i][1].ToString() != "")
                    cbComp.Items.Add(dt.Rows[i][1].ToString());
            }
            cbComp.SelectedIndex = 0;
        }

        /// <summary>
        /// Обработчик события нажатия на кнопку btnImport
        /// </summary>
        private void btnImport_Click(object sender, EventArgs e)
        {
            // Условие с проверкой на соответствие выбранного в cbWhat элемента значению "Критерии оценивания"
            if (cbWhat.SelectedItem.ToString() == "Критерии оценивания")
            {
                string nameSkill = dt.Rows[cbComp.SelectedIndex][5].ToString();
                // Вызов метода ImportSkill из класса DAL
                DAL.ImportSkill(Convert.ToInt32(dt.Rows[cbComp.SelectedIndex][0]), nameSkill);
            }
            else
                // Вызов метода ImportMem из класса DAL
                DAL.ImportMem(Convert.ToInt32(dt.Rows[cbComp.SelectedIndex][0]));
        }
    }
}
