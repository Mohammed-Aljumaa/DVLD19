using DvldBusinessLayer;
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
    public partial class frmShowApplication : Form
    {

        private int _LocalAppID;

        public frmShowApplication(int localAppID)
        {
            InitializeComponent();

            _LocalAppID = localAppID;
        }

        private void frmShowApplication_Load(object sender, EventArgs e)
        {

            var app = clsLocalDrivingLicenseApplication.Find(_LocalAppID);
            if (app == null) return;

            var application = clsAppliction.Find(app.ApplicationID);
            var person = clsMangepeople.Find(application.ApplicantPersonID);

            ctrlPersonDetails1.LoadPersonDetails(person.PersonID);
            ctrlDrivingLicenseApplictiponInfo1.LoadInfo(_LocalAppID);

        }

    }
}
