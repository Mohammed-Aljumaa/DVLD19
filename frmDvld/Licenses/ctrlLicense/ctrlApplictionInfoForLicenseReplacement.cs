using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.ctrlLicense
{
    public partial class ctrlApplictionInfoForLicenseReplacement : UserControl
    {
        public ctrlApplictionInfoForLicenseReplacement()
        {
            InitializeComponent();
        }

        public void LoadApplicationInfo(
            int applicationID,
            DateTime applicationDate,
            decimal fees,
            int oldLicenseID,
            int newLicenseID,
            string createdBy)
        {
            try
            {
                lblRLApplictionID.Text = applicationID.ToString();
                lblApplictionDate.Text = applicationDate.ToShortDateString();
                lblApplictionFees.Text = fees.ToString();
                lblOldLicenseID.Text = oldLicenseID.ToString();
                lblReplacedLicensID.Text = newLicenseID.ToString();
                lblCreateBy.Text = createdBy;
            }
            catch
            {
                // إذا صار أي خطأ، ما بدنا نخرب البرنامج
            }
        }

        public void Clear()
        {
            try
            {
                lblRLApplictionID.Text = "???";
                lblApplictionDate.Text = "???";
                lblApplictionFees.Text = "???";
                lblOldLicenseID.Text = "???";
                lblReplacedLicensID.Text = "???";
                lblCreateBy.Text = "???";
            }
            catch
            {
            }
        }
    }
}
