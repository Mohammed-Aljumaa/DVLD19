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
    public partial class frmUpdateAppliictionType : Form
    {
        public frmUpdateAppliictionType(int id,string Title,decimal fees)
        {
            InitializeComponent();



            lblID.Text = id.ToString();
            txtTitle.Text = Title;  
            txtFees.Text = fees.ToString();
        }

        private void frmUpdateAppliictionType_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblID.Text);
            decimal fees = decimal.Parse(txtFees.Text);
            string Title = txtTitle.Text;

            bool UpdateTitle = clsAppliction.UpdateNameApplitionType(id, Title);

            bool UpdateFees = clsAppliction.UpdateFeesApplitionType(id, fees);

            if (UpdateTitle && UpdateFees)
            {
                MessageBox.Show("Data Save Successfully");
            }
            else
            {
                MessageBox.Show("Failed");
            }



        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
