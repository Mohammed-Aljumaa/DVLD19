using System;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;
using frmDvld; // عدل حسب اسم مشروعك الحقيقي
using frmDvld.LoginScreens.ClaassLoginScreen;

namespace frmDvld.Licenses.ctrlLicense
{
    public partial class ctrlRenewLocalDrivingLicense : UserControl
    {
        private int _OldLicenseID = -1;
        private int _RenewedLicenseID = -1;
        private int _ApplicationID = -1;

        public ctrlRenewLocalDrivingLicense()
        {
            InitializeComponent();
        }
        public string GetNotes()
        {
            return txtNotes.Text;
        }


        // ============================================================
        // 1) تعبئة بيانات الطلب
        // ============================================================
        public void LoadApplicationInfo(int applicationID)
        {
            _ApplicationID = applicationID;

            clsAppliction app = clsAppliction.Find(applicationID);
            if (app == null) return;

            lblR_L_ApplictionID.Text = app.ApplicationID.ToString();
            lblApplictionDate.Text = app.ApplicationDate.ToShortDateString();
            lblIssueDate.Text = DateTime.Now.ToShortDateString();
            lblApplictionFees.Text = app.PaidFees.ToString();
        }

        // ============================================================
        // 2) تعبئة بيانات الرخصة القديمة
        // ============================================================
        public void LoadOldLicenseInfo(int oldLicenseID)
        {
            _OldLicenseID = oldLicenseID;

            clsLicense oldLicense = clsLicense.Find(oldLicenseID);
            if (oldLicense == null) return;

            lblOldLicenseID.Text = oldLicense.LicenseID.ToString();
            lblExpirationDate.Text = oldLicense.ExpirationDate.ToShortDateString();
            lblCreateBy.Text = clsGlobal.CurrentUser.UserName;

            // رسوم الرخصة الجديدة حسب الكلاس
            lblLicensFees.Text = oldLicense.PaidFees.ToString();

            _CalculateTotalFees();
        }

        // ============================================================
        // 3) تعبئة بيانات الرخصة الجديدة بعد الإصدار
        // ============================================================
        public void LoadRenewedLicenseInfo(int renewedLicenseID)
        {
            _RenewedLicenseID = renewedLicenseID;

            lblRenewedLicenseID.Text = renewedLicenseID.ToString();
        }

        // ============================================================
        // 4) حساب الرسوم
        // ============================================================
        private void _CalculateTotalFees()
        {
            decimal appFees = Convert.ToDecimal(lblApplictionFees.Text);
            decimal licenseFees = Convert.ToDecimal(lblLicensFees.Text);

            lblTotalFees.Text = (appFees + licenseFees).ToString();
        }

        // ============================================================
        // 5) إعادة ضبط الكنترول
        // ============================================================
        public void ResetControl()
        {
            _OldLicenseID = -1;
            _RenewedLicenseID = -1;
            _ApplicationID = -1;

            lblR_L_ApplictionID.Text = "###";
            lblApplictionDate.Text = "###";
            lblIssueDate.Text = "###";
            lblApplictionFees.Text = "###";
            lblApplictionFees.Text = "###";
            lblTotalFees.Text = "###";

            lblOldLicenseID.Text = "###";
            lblExpirationDate.Text = "###";
            lblCreateBy.Text = "###";

            lblRenewedLicenseID.Text = "###";

            txtNotes.Text = "";
        }

        // ============================================================
        // 6) إرجاع رقم الطلب
        // ============================================================
        public int GetApplicationID()
        {
            return _ApplicationID;
        }

        // ============================================================
        // 7) إرجاع رقم الرخصة القديمة
        // ============================================================
        public int GetOldLicenseID()
        {
            return _OldLicenseID;
        }

        // ============================================================
        // 8) إرجاع رقم الرخصة الجديدة
        // ============================================================
        public int GetRenewedLicenseID()
        {
            return _RenewedLicenseID;
        }

    }
}
