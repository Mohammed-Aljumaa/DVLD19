using DvldBusinessLayer;
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

namespace frmDvld
{
    public partial class ctrlPersonDetails : UserControl
    {
        public ctrlPersonDetails()
        {
            InitializeComponent();
            _ResetPersonInfo();
        }

        private clsMangepeople _Person;
        private int _PersonID = -1;

        public int PersonID { get { return _PersonID; } }
        
        public clsMangepeople SelectedPersonInfo
        {
            get { return _Person; }
        }
 private void llEditPersonInfo_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            
            frmAddEditPersonInfo frm2 = new frmAddEditPersonInfo(_PersonID);
           frm2.ShowDialog(); 
            LoadPersonDetails(_PersonID);
            

        }

        private void _ResetPersonInfo()
        {
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblGender.Text = "[????]";
            lblPhone.Text = "[????]";
            LblName.Text = "[????]";
            lblEmail.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblAddress.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblCountry.Text= "[????]";
            pbAddPerson.Image = Properties.Resources.male;


        }
        private void _LoadPersonImage()
        {
            if(_Person.Gendor==0)
                pbAddPerson.Image=Properties.Resources.male;
            else
                pbAddPerson.Image=Properties.Resources.avatar;

            string ImagePath=_Person.ImagePath;

            if (ImagePath != "")
                if (File.Exists(ImagePath))
                    pbAddPerson.ImageLocation = ImagePath;
            else
                    MessageBox.Show("Could not find this Image = "+ImagePath,"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);



        }
        private void _FillPersonInfo()
        {

            // تعبئة الحقول
            _PersonID = _Person.PersonID;
            lblPersonID.Text = _Person.PersonID.ToString();
            LblName.Text = _Person.FirstName + " " + _Person.SecondName + " " + _Person.ThirdName + " " + _Person.LastName;
            lblEmail.Text = _Person.Email;
            lblNationalNo.Text = _Person.NationalNo;
            lblPhone.Text = _Person.Phone;
            lblAddress.Text = _Person.Address;
            lblGender.Text = _Person.Gendor == 0 ? "Male" : "Female";
            lblDateOfBirth.Text = _Person.DateOfBirth.ToShortDateString();
            lblCountry.Text = clsCountry.Find(_Person.NationalityCountryID)?.CountryName ?? "Unknown";
            _LoadPersonImage();
           
        }
     public void LoadPersonDetails(int personID)
        {
           _Person = clsMangepeople.Find(personID);

            if (_Person == null)
            {

                _ResetPersonInfo();
                MessageBox.Show("No Person With PersonID = "+personID.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

           _FillPersonInfo();
            }
     public void LoadPersonDetails(string  NationalNo)
        {
           _Person = clsMangepeople.Find(NationalNo);

            if (_Person == null)
            {

                _ResetPersonInfo();
                MessageBox.Show("No Person With PersonID = "+NationalNo.ToString(),"Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }

           _FillPersonInfo();
            }
        }
    }

