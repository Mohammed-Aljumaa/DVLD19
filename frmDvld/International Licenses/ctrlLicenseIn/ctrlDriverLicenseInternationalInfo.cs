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

namespace frmDvld.International_Licenses.ctrlLicenseIn
{
    public partial class ctrlDriverLicenseInternationalInfo : UserControl
    {


        int _internationalLicenseID=-1;
        public ctrlDriverLicenseInternationalInfo()
        {
            InitializeComponent();
           
        }



        public void LoadInfo(int internationalLicenseID)
        {
            clsInternationalLicense L =
                clsInternationalLicense.GetInternationalLicenseByID(internationalLicenseID);

            if (L == null)
            {
                MessageBox.Show("International license not found.");
                return;
            }

            // 1) نجيب الـ Application
            clsAppliction app = clsAppliction.Find(L.InternationalLicenseApplicationID);

            // 2) نجيب الشخص
            clsMangepeople person = clsMangepeople.Find(app.ApplicantPersonID);

            // 3) تعبئة اللابلز
            lblName.Text = person.GetFullName();
            lblIntLicenseID.Text = L.InternationalLicenseID.ToString();
            lblApplictionID.Text = L.InternationalLicenseApplicationID.ToString();
            lblLicensID.Text = L.LocalLicenseID.ToString();
            lblIsActive.Text = L.IsActive ? "Yes" : "No";

            lblNationalNo.Text = person.NationalNo;
            lblDateOfBirth.Text = person.DateOfBirth.ToShortDateString();
            lblGendor.Text = (person.Gendor == 0) ? "Male" : "Female";


            lblDriverID.Text = L.DriverID.ToString();
            lblIssueDate.Text = L.IssueDate.ToShortDateString();
            lblExpirationDate.Text = L.ExpirationDate.ToShortDateString();



            // تحميل صورة الشخص
            
                if (!string.IsNullOrEmpty(person.ImagePath) && File.Exists(person.ImagePath))
                    pbintLicensePerson.Image = Image.FromFile(person.ImagePath);
            else
            {
                // تحميل صورة الشخص حسب الجنس
                if (person.Gendor == 0) // Male
                {
                    pictureBox1.Image = Properties.Resources.male;
                }
                else // Female
                {
                    pictureBox1.Image = Properties.Resources.avatar;
                }

            }


        }

        
    }
}
