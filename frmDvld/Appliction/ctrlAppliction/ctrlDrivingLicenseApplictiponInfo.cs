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
    public partial class ctrlDrivingLicenseApplictiponInfo : UserControl
    {
        public ctrlDrivingLicenseApplictiponInfo()
        {
            InitializeComponent();
        }


        public void LoadInfo(int localAppID)
        {
            var app =clsLocalDrivingLicenseApplication.Find(localAppID);

            if (app == null)
            {
                MessageBox.Show("لم يتم العثور على الطلب");
                return;
            }

            lblDLAPPID.Text = app.LocalAppID.ToString();
            lblAppliedForLicense.Text = app.ClassName;
            lblPassedTest.Text = $"{app.PassedTests}/3";
        }


    }
}
