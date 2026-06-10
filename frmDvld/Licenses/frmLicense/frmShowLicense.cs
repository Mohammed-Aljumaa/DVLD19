using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmShowLicense : Form
    {

        private int _LicenseID;



        public frmShowLicense(int licenseID)
        {
            InitializeComponent();
            _LicenseID = licenseID;
        }

        private void frmShowLicense_Load(object sender, EventArgs e)
        {
            ctrlDriverLicenseInfo1.LoadLicenseInfo(_LicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
