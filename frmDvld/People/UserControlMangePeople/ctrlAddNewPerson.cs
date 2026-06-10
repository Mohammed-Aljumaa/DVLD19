using DvldBusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.IO;

namespace frmDvld
{
    public partial class ctrlAddNewPerson : UserControl
    {


        public event Action OnSaveClicked;

        protected virtual void RaiseSavePerson()
        {
            Action Handler = OnSaveClicked;
            if (Handler != null)
            {

                Handler();
            }

        }


        public ctrlAddNewPerson()
        {
            InitializeComponent();
        }

        public Button AcceptButton
        {
            get { return btnSave; }
        }
        public Button CancelButton
        {
            get { return btnClose; }
        }

        public string NationalNo
        {
            get => Convert.ToString(txtNationalNo.Text);
            set => txtNationalNo.Text = value.ToString();
        }

        public string FirstName
        {
            get => txtFirstName.Text.Trim();
            set => txtFirstName.Text = value;
        }

        public string SecondName
        {
            get => txtSecondName.Text.Trim();
            set => txtSecondName.Text = value;
        }

        public string ThirdName
        {
            get => txtThirdName.Text.Trim();
            set => txtThirdName.Text = value;
        }

        public string LastName
        {
            get => txtLastName.Text.Trim();
            set => txtLastName.Text = value;
        }

        public string Address
        {
            get => txtAddress.Text.Trim();
            set => txtAddress.Text = value;
        }

        public string Phone
        {
            get => txtPhone.Text.Trim();
            set => txtPhone.Text = value;
        }

        public string Email
        {
            get => txtEmail.Text.Trim();
            set => txtEmail.Text = value;
        }


        public DateTime DateOfBirth
        {
            get => dtpDateOfBirth.Value;
            set => dtpDateOfBirth.Value = value;
        }

        public int NationalityCountryID()
        {
            int CountryID = Convert.ToInt32(cbCountry.SelectedValue);
            return CountryID;
        }
        public int CurrentPersonID { get; set; }
        public byte Gendor
        {
            get => rbMale.Checked ? (byte)0 : (byte)1;
            set
            {
                rbMale.Checked = value == 0;
                rbFemale.Checked = value == 1;
            }
        }
      
        public string ImagePath
        {
            get => pbAddPerson.ImageLocation;
            set => pbAddPerson.ImageLocation = value;

        }


        public string CountryOfPerson { get; set; }

        public int CountryIDInComboBox
        {
            get
            {
                if (cbCountry.SelectedValue != null)
                    return Convert.ToInt32(cbCountry.SelectedValue);
                return -1; // أو أي قيمة افتراضية
            }
            set
            {
                cbCountry.SelectedValue = value;
            }
        }
        public bool RemoveImage
        {
            get => llRemove.Visible;
            set => llRemove.Visible = value;
        }
        void _FillAllCountriesInComboBox()
        {

            DataTable dtCountry = clsCountry.GetAllCountries();
            cbCountry.DataSource = dtCountry;
            cbCountry.DisplayMember = "CountryName";
            cbCountry.ValueMember = "CountryID";



        }
        void _LoadDataUserControl()
        {
            _FillAllCountriesInComboBox();
            _DateTimePiker();
            rbMale.Checked = true;



            cbCountry.SelectedIndex = 0;
            if (pbAddPerson.ImageLocation != null)
            {
                pbAddPerson.ImageLocation=ImagePath;
            }

            if (RemoveImage == true)
            {
                llRemove.Visible = true;
            }
            else
            {
                llRemove.Visible = false;
            }
            cbCountry.SelectedIndex = cbCountry.FindString("Jordan");

        }

        private void ctrlAddNewPerson_Load(object sender, EventArgs e)
        {


            _LoadDataUserControl();

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("some Fileds are not valide!.", "put the mouse over the red icon ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

       
            if (OnSaveClicked != null)
            {
                RaiseSavePerson();
            }

        }






        public bool HandlePersonImage(string originalImagePath)
        {
            string newImagePath = pbAddPerson.ImageLocation;

            if (originalImagePath != newImagePath)
            {
                if (!string.IsNullOrEmpty(originalImagePath) && File.Exists(originalImagePath))
                {
                    try
                    {
                        File.Delete(originalImagePath);
                    }
                    catch (IOException)
                    {
                        // تجاهل الخطأ أو عرض رسالة
                    }
                }

                if (!string.IsNullOrEmpty(newImagePath))
                {
                    string sourceImageFile = newImagePath;
                    if (clsUtil.CopyImageToProjectImageFolder(ref sourceImageFile))
                    {
                        pbAddPerson.ImageLocation = sourceImageFile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }







        private void _DateTimePiker()
        {


            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.MinDate = DateTime.Today.AddYears(-100);
            dtpDateOfBirth.Value=dtpDateOfBirth.MaxDate;

            CultureInfo culture = new CultureInfo("en-US");

            culture.DateTimeFormat.Calendar = new GregorianCalendar();

            dtpDateOfBirth.Format = DateTimePickerFormat.Custom;
            dtpDateOfBirth.CustomFormat = culture.DateTimeFormat.ShortDatePattern;

        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbAddPerson.ImageLocation == null)
            {
                pbAddPerson.Image = Properties.Resources.male;
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (pbAddPerson.ImageLocation == null)
            {
                pbAddPerson.Image = Properties.Resources.avatar;
            }
        }

       



   
        private void llSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        
          openFileDialog1.Filter = "image (*.jpg;*.jpeg;*.png;*.bmp)|*.jpg;*.jpeg;*.png;*.bmp";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.RestoreDirectory= true;
            if(openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                string SelectFilePath = openFileDialog1.FileName;
                pbAddPerson.ImageLocation=SelectFilePath;
                llRemove.Visible = true;
            }
            
        }

        private void llRemove_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            pbAddPerson.ImageLocation = null;

            if (rbMale.Checked)
            {
                pbAddPerson.Image = Properties.Resources.male;
            }
            else
            {
                pbAddPerson.Image = Properties.Resources.avatar;
            }

            llRemove.Visible = false;




            }



        private void _ClearValidationErrors()
        {
            errorProvider1.SetError(txtNationalNo, "");
            errorProvider1.SetError(txtPhone, "");
            errorProvider1.SetError(txtEmail, "");
            errorProvider1.SetError(txtAddress, "");
            errorProvider1.SetError(txtFirstName, "");
            errorProvider1.SetError(txtLastName, "");
        
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
           
                DialogResult result = MessageBox.Show("Are you sure you want to close?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                
                Form parentForm=this.FindForm();

                if(parentForm != null)
                {
                    parentForm.Close();
                }
               

                }
            _ClearValidationErrors();
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            
                string input = txtNationalNo.Text.Trim();

                if (string.IsNullOrEmpty(input))
                {
                    e.Cancel = true;
                    errorProvider1.SetError(txtNationalNo, "Please enter the national number.");
                    return;
                }

                
                // تحقق من وجود الرقم الوطني
                // تحقق هل الرقم الوطني يعود لنفس الشخص الحالي
                if (clsMangepeople.IsNationalNoUsedByOther(input,CurrentPersonID))
                    {
                        e.Cancel = true;
                        errorProvider1.SetError(txtNationalNo, "The national number already exists.");
                        return;
                    }
                

                errorProvider1.SetError(txtNationalNo, "");
            }
        

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
         
                string PhoneNumber = txtPhone.Text.Trim();

                if (string.IsNullOrEmpty(PhoneNumber))
                {
                    errorProvider1.SetError(txtPhone, "Please enter the phone number.");
                    e.Cancel = true;
                    return;
                }

                // تحقق من أن الرقم يحتوي فقط على أرقام
                if (!PhoneNumber.All(char.IsDigit))
                {
                    errorProvider1.SetError(txtPhone, "Phone number must contain digits only.");
                    e.Cancel = true;
                    return;
                }

            // إذا كل شيء تمام، امسح رسالة الخطأ
            if (!e.Cancel)
            {
                errorProvider1.SetError(txtPhone, "");
            }
           

        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            string Email = txtEmail.Text.Trim();

            if(string.IsNullOrEmpty(Email))
            {

                errorProvider1.SetError(txtEmail, "");
                return;
            }
            try
            {
                var EmailChecked = new MailAddress(Email);
                errorProvider1.SetError(txtEmail, "");
                

            }
            catch (Exception ex)
            {
                errorProvider1.SetError(txtEmail, "Invalid email Format.");
                e.Cancel= true;
               

            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            string Address1 = txtAddress.Text.Trim();

            if (string.IsNullOrEmpty(Address1))
            {
                e.Cancel = true;
                errorProvider1.SetError(txtAddress, "Please enter the Address.");
                return ;
            }
            if (!e.Cancel)
            {
                errorProvider1.SetError(txtAddress, "");
            }
                    }
    }
    }


 