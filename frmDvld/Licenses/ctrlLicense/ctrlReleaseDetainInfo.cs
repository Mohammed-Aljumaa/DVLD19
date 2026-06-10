using DvldBusinessLayer.BLLClasses;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.ctrlLicense
{
    public partial class ctrlReleaseDetainInfo : UserControl
    {
        public ctrlReleaseDetainInfo()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            lblDetainID.Text = "---";
            lblLicenseID.Text = "---";
            lblFineFees.Text = "---";
            lblApplictionID.Text = "---";
            lblDetainDate.Text = "---";
            lblCreateBy.Text = "---";
            lblTotalFees.Text = "---";
        }

        public void LoadReleaseInfo(int detainID, decimal applicationFees)
        {
            clsDetainedLicense detain = clsDetainedLicense.Find(detainID);

            if (detain == null)
            {
                Clear();
                return;
            }

            lblDetainID.Text = detain.DetainID.ToString();
            lblLicenseID.Text = detain.LicenseID.ToString();
            lblFineFees.Text = detain.FineFees.ToString();
            lblDetainDate.Text = detain.DetainDate.ToShortDateString();

            clsUsers user = clsUsers.Find(detain.CreatedByUserID);
            lblCreateBy.Text = user != null ? user.UserName : "Unknown";

            // هون ما عاد نجيب من clsApplicationTypes
            lblApplictionID.Text = applicationFees.ToString();

            decimal total = applicationFees + detain.FineFees;
            lblTotalFees.Text = total.ToString();
        }

        public decimal GetTotalFees()
        {
            if (decimal.TryParse(lblTotalFees.Text, out decimal total))
                return total;

            return 0;
        }

        public decimal GetApplicationFees()
        {
            if (decimal.TryParse(lblApplictionID.Text, out decimal fees))
                return fees;

            return 0;
        }

        public decimal GetFineFees()
        {
            if (decimal.TryParse(lblFineFees.Text, out decimal fees))
                return fees;

            return 0;
        }
    }
}
