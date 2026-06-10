using DvldBusinessLayer.BLLClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmMangeTest : Form
    {
        public frmMangeTest()
        {
            InitializeComponent();
           
        }

        private void _LoadApplictionTest()
        {
            DataTable dt = clsAppliction.GetAllTestTypeTypes();

            dgvTestType.DataSource = dt;

            

            dgvTestType.Columns["TestTypeID"].HeaderText = "ID";
            dgvTestType.Columns["TestTypeTitle"].HeaderText = "Title";
            dgvTestType.Columns["TestTypeDescription"].HeaderText = "Description";
            dgvTestType.Columns["TestTypeFees"].HeaderText = "Fees";


            dgvTestType.Columns["TestTypeID"].Width = 80;
            dgvTestType.Columns["TestTypeTitle"].Width = 200;
            dgvTestType.Columns["TestTypeDescription"].Width = 350;
            dgvTestType.Columns["TestTypeFees"].Width = 100;

            lblRecordCount.Text = dt.Rows.Count.ToString();




        }

        private void frmMangeTest_Load(object sender, EventArgs e)
        {
            _LoadApplictionTest();

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvTestType.CurrentRow == null)
                return;
            int id = (int)dgvTestType.CurrentRow.Cells["TestTypeID"].Value;
            string title = dgvTestType.CurrentRow.Cells["TestTypeTitle"].Value.ToString();
            string Description = dgvTestType.CurrentRow.Cells["TestTypeDescription"].Value.ToString();
            decimal fees = Convert.ToDecimal(dgvTestType.CurrentRow.Cells["TestTypeFees"].Value);


            frmUpdateTestType frm = new frmUpdateTestType(id,title,Description,fees);
            frm.ShowDialog();
            _LoadApplictionTest();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
