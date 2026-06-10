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
    public partial class frmUpdateTestType : Form
    {
        public frmUpdateTestType(int id, string Title,string Description, decimal fees)
        {
            InitializeComponent();


            lblID.Text = id.ToString();
            txtTitle.Text = Title;
            txtDescription.Text = Description;  
            txtFees.Text = fees.ToString();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int id = int.Parse(lblID.Text);
            decimal fees = decimal.Parse(txtFees.Text);
            string Description=txtDescription.Text;
            string Title = txtTitle.Text;

            bool UpdateTitle = clsAppliction.UpdateNameTestType(id, Title);

            bool UpdateFees = clsAppliction.UpdateFeesTestType(id, fees);

            bool UpdateDescription = clsAppliction.UpdateDescriptionTestType(id, Description);

            if(UpdateTitle&&UpdateDescription&&UpdateFees)
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

