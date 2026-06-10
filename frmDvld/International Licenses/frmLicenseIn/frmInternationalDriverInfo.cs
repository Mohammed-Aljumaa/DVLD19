using System;
using System.Windows.Forms;

namespace frmDvld.International_Licenses.frmLicenseIn
{
    public partial class frmInternationalDriverInfo : Form
    {
        private int _internationalLicenseID;

        public frmInternationalDriverInfo(int internationalLicenseID)
        {
            InitializeComponent();
            _internationalLicenseID = internationalLicenseID;
        }

        private void frmInternationalDriverInfo_Load(object sender, EventArgs e)
        {
            // استدعاء الكونترول وتمرير الـ ID
            ctrlDriverLicenseInternationalInfo1.LoadInfo(_internationalLicenseID);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
