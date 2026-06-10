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
using System.IO;

namespace frmDvld.Licenses.ctrlLicense
{
    public partial class ctrlDriverLicenseInfo : UserControl
    {
        public ctrlDriverLicenseInfo()
        {
            InitializeComponent();
        }

        public int LicenseID
        {
            get
            {
                if (int.TryParse(lblLicensID.Text, out int id))
                    return id;

                return -1; // أو 0 حسب ما يناسبك
            }
        }
        int _PersonID;
         public int PersonID
        {
            get
            {
                
                    return _PersonID;

                return -1; // أو 0 حسب ما يناسبك
            }
        }


        private void ctrlDriverLicenseInfo_Load(object sender, EventArgs e)
        {

        }

        public void LoadLicenseInfo(int licenseID)
        {
                // 1) نجيب الرخصة
                clsLicense license = clsLicense.Find(licenseID);

                if (license == null)
                {
                    MessageBox.Show("License Not Found!");
                    return;
                }

                lblLicensID.Text = license.LicenseID.ToString();

            // ================================
            // 🔥 جلب الفئة بأبسط طريقة ممكنة
            // ================================

            lblClass.Text = clsLicense.GetClassName(license.LicenseClass);

            // ================================
            // باقي المعلومات كما هي
            // ================================

            lblIssueDate.Text = license.IssueDate.ToShortDateString();
                lblExpirationDate.Text = license.ExpirationDate.ToShortDateString();
                lblNotes.Text = license.Notes;
                lblIsActive.Text = license.IsActive ? "Yes" : "No";

                string reason = "";
                switch (license.IssueReason)
                {
                    case 1: reason = "First Time"; break;
                    case 2: reason = "Renew"; break;
                    case 3: reason = "Replacement for Lost"; break;
                    case 4: reason = "Replacement for Damaged"; break;
                }
                lblIssueReason.Text = reason;

                lblDriverID.Text = license.DriverID.ToString();

                lblIsDetained.Text = clsDetainedLicense.IsLicenseDetained(license.LicenseID)
                         ? "Yes"
                         : "No";

                // 1) نجيب الـ Application المرتبط بالرخصة
                clsAppliction app = clsAppliction.Find(license.ApplicationID);

                if (app == null)
                {
                    MessageBox.Show("Application Not Found!");
                    return;
                }

                // 2) نجيب الشخص عبر PersonID من الـ Application
                clsMangepeople person = clsMangepeople.Find(app.ApplicantPersonID);

                if (person == null)
                {
                    MessageBox.Show("Person Not Found!");
                    return;
                }
            _PersonID = person.PersonID;
                // 3) تعبئة بيانات الشخص
                lblName.Text = person.GetFullName();
                lblNationalNo.Text = person.NationalNo;
                lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
                lblGendor.Text = (person.Gendor == 0) ? "Male" : "Female";

                if (person.Gendor == 0)
                    pbLicensePerson.Image = Properties.Resources.male;
                else
                    pbLicensePerson.Image = Properties.Resources.avatar;

                if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
                {
                    pbLicensePerson.Image = Image.FromFile(person.ImagePath);
                }
                else
                {
                    if (person.Gendor == 0)
                        pbLicensePerson.Image = Properties.Resources.male;
                    else
                        pbLicensePerson.Image = Properties.Resources.avatar;
                }
            }
        }
    }
    
     



