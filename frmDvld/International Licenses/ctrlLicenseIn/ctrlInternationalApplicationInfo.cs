using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using System;
using System.Windows.Forms;

namespace frmDvld.International_Licenses.ctrlLicenseIn
{
    public partial class ctrlInternationalApplicationInfo : UserControl
    {
        public ctrlInternationalApplicationInfo()
        {
            InitializeComponent();
        }

        // ================================
        // 1) تحميل البيانات الأولية
        // ================================
        public void LoadInitialInfo(int localLicenseID)
        {
            lblI_L_ApplictionID.Text = "###";
            lblILLicenseID.Text = "###";

            lblApplictionDate.Text = DateTime.Now.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblExpirationDate.Text = DateTime.Now.AddYears(1).ToShortDateString();

            lblFees.Text = "51";
            lblLocalLicenseID.Text = localLicenseID.ToString();

            lblCreateBy.Text = clsGlobal.CurrentUser.UserName;
        }

        // ================================
        // 2) تحميل البيانات بعد إصدار الرخصة الدولية
        // ================================
        public void LoadFinalInfo(int internationalLicenseID)
        {
            var intl = clsInternationalLicense.GetInternationalLicenseByID(internationalLicenseID);
            if (intl == null)
                return;

            lblI_L_ApplictionID.Text = intl.InternationalLicenseApplicationID.ToString();
            lblILLicenseID.Text = intl.InternationalLicenseID.ToString();

            lblApplictionDate.Text = intl.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = intl.IssueDate.ToShortDateString();
            lblExpirationDate.Text = intl.ExpirationDate.ToShortDateString();

            llskw.Text = intl.Fees.ToString();
            lblLocalLicenseID.Text = intl.LocalLicenseID.ToString();

            lblCreateBy.Text = clsGlobal.CurrentUser.UserName;
        }

        // ================================
        // 3) تفريغ الكونترول بالكامل
        // ================================
        public void Clear()
        {
            lblI_L_ApplictionID.Text = "###";
            lblILLicenseID.Text = "###";
            lblApplictionDate.Text = "###";
            lblIssueDate.Text = "###";
            lblExpirationDate.Text = "###";
            llskw.Text = "###";
            lblLocalLicenseID.Text = "###";
            lblCreateBy.Text = "###";
        }
    }
}
