using DvldBusinessLayer.BLLClasses;
using System;
using System.Windows.Forms;

namespace frmDvld.Licenses.ctrlLicense
{
    public partial class ctrlDetainInfo : UserControl
    {
        public ctrlDetainInfo()
        {
            InitializeComponent();
        }

        public void Clear()
        {
            lblDetainID.Text = "---";
            lblDetainDate.Text = "---";
            txtFees.Text = "";
            lblLicenseID.Text = "---";
            lblCreateBy.Text = "---";
        }

        public void LoadDetainInfo(int detainID)
        {
            clsDetainedLicense detain = clsDetainedLicense.Find(detainID);

            if (detain == null)
            {
                Clear();
                return;
            }

            lblDetainID.Text = detain.DetainID.ToString();
            lblDetainDate.Text = detain.DetainDate.ToShortDateString();
            txtFees.Text = detain.FineFees.ToString(); 
            lblLicenseID.Text = detain.LicenseID.ToString();

            clsUsers user = clsUsers.Find(detain.CreatedByUserID);
            lblCreateBy.Text = user != null ? user.UserName : "Unknown";
        }
        public decimal GetFineFees()
        {
            if (decimal.TryParse(txtFees.Text, out decimal fees))
                return fees;

            return 0;
        }

    }
}
