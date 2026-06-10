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
    public partial class frmManageApplicationTypes : Form
    {
        public frmManageApplicationTypes()
        {
            InitializeComponent();
        }

        private void frmManageApplicationTypes_Load(object sender, EventArgs e)
        {
            _LoadApllictionType();  
        }


        private void _LoadApllictionType()  
        {

            
                DataTable dt = clsAppliction.GetAllApplictionType();

                dgvApplictionType.DataSource = dt;

            dgvApplictionType.Columns["ApplicationTypeID"].HeaderText = "ID";
            dgvApplictionType.Columns["ApplicationTypeTitle"].HeaderText = "Title";
            dgvApplictionType.Columns["ApplicationFees"].HeaderText = "Fees";

            lblRecordCount.Text = dt.Rows.Count.ToString();
            
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(dgvApplictionType.CurrentRow==null)
            return;


            int id =(int)dgvApplictionType.CurrentRow.Cells["ApplicationTypeID"].Value; 
            string title = dgvApplictionType.CurrentRow.Cells["ApplicationTypeTitle"].Value.ToString();
            decimal fees = Convert.ToDecimal(dgvApplictionType.CurrentRow.Cells["ApplicationFees"].Value);

            frmUpdateAppliictionType frm=new frmUpdateAppliictionType(id,title,fees);

            frm.ShowDialog();
            _LoadApllictionType();
            
        }
    }
}
