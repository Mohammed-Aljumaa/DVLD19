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

namespace frmDvld
{
    public partial class frmAddEditPersonInfo : Form
    {

        public enum enMode { AddNew=0,UpDate=1};
        private enMode _Mode;
        int _PersonID;
        clsMangepeople _Person;
        clsCountry _Country = new clsCountry();



        public frmAddEditPersonInfo(int PersonID)
        {
            InitializeComponent();

            _PersonID = PersonID;
            if(_PersonID!=-1)
            {
                _Mode=enMode.UpDate;
            }
            else
            {
                _Mode =enMode.AddNew;
            }
         
        }
        public event EventHandler<int> DataBack;

        private void _LoadData()
        {



            this.AcceptButton = ctrlAddNewPerson2.AcceptButton;
            this.CancelButton = ctrlAddNewPerson2.CancelButton;

            if (_Mode == enMode.AddNew)
            {
                lblAddEditNewPerson.Text = "Add New Person";
                _Person = new clsMangepeople();
              
                return;
            }
            _Person = clsMangepeople.Find(_PersonID);
            if (_Person == null)
            {
                MessageBox.Show("This form Willbe closed becauseno Person with ID " + _PersonID);
                this.Close();
                return;
            }

            
            lblAddEditNewPerson.Text = "Update Person";
           ctrlAddNewPerson2.FirstName = _Person.FirstName;
           ctrlAddNewPerson2.SecondName= _Person.SecondName;
           ctrlAddNewPerson2.ThirdName= _Person.ThirdName;
           ctrlAddNewPerson2.LastName= _Person.LastName;
           ctrlAddNewPerson2.NationalNo= _Person.NationalNo;
           ctrlAddNewPerson2.Email= _Person.Email;
           ctrlAddNewPerson2.Address= _Person.Address;
           ctrlAddNewPerson2.Gendor= _Person.Gendor;
            ctrlAddNewPerson2.DateOfBirth= _Person.DateOfBirth;
            ctrlAddNewPerson2.Phone= _Person.Phone;
            ctrlAddNewPerson2.ImagePath=_Person.ImagePath;
            lblPersonID.Text=_PersonID.ToString();
            pbLableADDandEdit.Image = Properties.Resources.edit;

            // تحقق إن الصورة ليست افتراضية
            if (_Person.ImagePath.Contains("PeopleImages_Dvld"))
            {
                ctrlAddNewPerson2.RemoveImage = true;
            }
            else
            {
                ctrlAddNewPerson2.RemoveImage = false;
            }






            ctrlAddNewPerson2.CurrentPersonID = _Person.PersonID;
            ctrlAddNewPerson2.CountryOfPerson = (clsCountry.Find(_Person.NationalityCountryID).CountryName);
            ctrlAddNewPerson2.CountryIDInComboBox = _Person.NationalityCountryID;
           }
      
        private void frmAddEditPersonInfo_Load(object sender, EventArgs e)
        {

            _LoadData();



        }

        private void ctrlAddNewPerson2_OnSaveClicked()
        {

            // نقل البيانات من UserControl إلى الكائن _Person
            string _LoadedImagePath = _Person.ImagePath;

            if(!ctrlAddNewPerson2.HandlePersonImage(_LoadedImagePath))
            {
                return;
            }

                _Person.FirstName = ctrlAddNewPerson2.FirstName.Trim();
                _Person.SecondName = ctrlAddNewPerson2.SecondName.Trim();
                _Person.ThirdName = ctrlAddNewPerson2.ThirdName.Trim();
                _Person.LastName = ctrlAddNewPerson2.LastName.Trim();
                _Person.NationalNo = ctrlAddNewPerson2.NationalNo.Trim();
                _Person.Email = ctrlAddNewPerson2.Email.Trim();
                _Person.Phone = ctrlAddNewPerson2.Phone.Trim();
                _Person.Address = ctrlAddNewPerson2.Address.Trim();
                _Person.DateOfBirth = ctrlAddNewPerson2.DateOfBirth;
                _Person.NationalityCountryID = ctrlAddNewPerson2.NationalityCountryID();
                _Person.Gendor = ctrlAddNewPerson2.Gendor;
            
                if (!string.IsNullOrEmpty(ctrlAddNewPerson2.ImagePath))
                    _Person.ImagePath = ctrlAddNewPerson2.ImagePath;
                else
                    _Person.ImagePath = "";

                // تنفيذ الحفظ
                if (_Person.Save())
                {
                    MessageBox.Show(" Data Saved Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // تحديث رقم الشخص بعد الحفظ (في حال كان جديد)
                    _PersonID = _Person.PersonID;

                    // تحويل النموذج إلى وضع تعديل
                    _Mode = enMode.UpDate;

                    // تحديث الواجهة
                    pbLableADDandEdit.Image = Properties.Resources.edit;
                    lblAddEditNewPerson.Text = "Update Person";
                    lblPersonID.Text = _Person.PersonID.ToString();

                    // تحديث بيانات UserControl
                    ctrlAddNewPerson2.CurrentPersonID = _Person.PersonID;
                    ctrlAddNewPerson2.CountryIDInComboBox = _Person.NationalityCountryID;
             
    }
                else
                {
                    MessageBox.Show(" Error: Data was not saved successfully", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            if (DataBack != null)
                DataBack(this,_PersonID);
            }


        }
       

        }


