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

namespace frmDvld.Appliction.ctrlAppliction
{
    public partial class ctrlApplictionBasicInfo : UserControl
    {

        int _PersonID;
        public ctrlApplictionBasicInfo()
        {

            InitializeComponent();
        }

        public void LoadInfo(int applicationID)
        {
            var app = clsAppliction.Find(applicationID);

            if (app == null)
            {
                MessageBox.Show("لم يتم العثور على الطلب");
                return;
            }
            _PersonID = app.ApplicantPersonID;
            lblID.Text = app.ApplicationID.ToString();
            lblStatus.Text = app.ApplicationStatus.ToString();
            lblFees.Text = app.PaidFees.ToString();
            lblType.Text = app.ApplicationTypeTitle;
            lblApplicant.Text = app.ApplicantFullName;
            lblDate.Text = app.ApplicationDate.ToShortDateString();
            lblStatuseDate.Text = app.LastStatusDate.ToShortDateString();
            lblCreatedBy.Text = app.CreatedByUserName;
        }

        private void lnkViewPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmPersonDetails frm = new frmPersonDetails(_PersonID);
            frm.ShowDialog();
                
        }
    }
}
