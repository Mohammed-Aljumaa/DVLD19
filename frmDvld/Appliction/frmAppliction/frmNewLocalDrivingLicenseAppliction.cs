using DvldBusinessLayer;
using DvldBusinessLayer.BLLClasses;
using frmDvld.LoginScreens.ClaassLoginScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Appliction.frmAppliction
{
    public partial class frmNewLocalDrivingLicenseAppliction : Form
    {

        int _PersonID;


        public frmNewLocalDrivingLicenseAppliction()
        {
            InitializeComponent();
        }

        private void btnNextTap_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(ctrlPersonCardWithFilter1.SearchText))//SearchText==txtserach
            {

                ctrlPersonCardWithFilter1.ClearSearch();
            }
            if (ctrlPersonCardWithFilter1.PersonID == -1)
            {
                MessageBox.Show("Please Select a person first! ", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);


                return;
            }

            int PersonID = ctrlPersonCardWithFilter1.PersonID;


            clsMangepeople selectedPerson = clsMangepeople.Find(ctrlPersonCardWithFilter1.PersonID);
            if (selectedPerson == null)
            {
                MessageBox.Show("The selected person does not exist in the system!", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Error);


                return;
            }


            





            tabControl1.SelectedIndex = 1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {


              int personID = ctrlPersonCardWithFilter1.PersonID;
                int licenseClassID = (int)cmbLicenseClass.SelectedValue;

                // 🔥 أول خطوة: تحقق إذا عنده طلب سابق لنفس الفئة (New أو Completed)
                if (clsAppliction.HasActiveOrCompletedApplication(personID, licenseClassID))
                {
                    MessageBox.Show("This person already has an active or completed application for this license class.");
                    return; // ❌ وقف العملية وما تكمل
                }

                // ✔ إذا وصل لهون يعني مسموح يعمل طلب جديد
                decimal fees = decimal.Parse(lblApplictionFees.Text);
                int createdByUserID = clsGlobal.CurrentUser.UserID;

                int applicationID = clsAppliction.Create(
                    personID,
                    licenseClassID,
                    fees,
                    createdByUserID
                );

                if (applicationID > 0)
                {
                    lblApplicationID.Text = applicationID.ToString();
                    MessageBox.Show("Application Created Successfully!");
                }
                else
                {
                    MessageBox.Show("Failed to create application.");
                }
            
        }



        private void frmNewLocalDrivingLicenseAppliction_Load(object sender, EventArgs e)
        {
            cmbLicenseClass.DataSource = clsAppliction.GetAllClasses();
            cmbLicenseClass.DisplayMember = "ClassName";
            cmbLicenseClass.ValueMember = "LicenseClassID";


         


            lblApplictionDate.Text = DateTime.Now.ToShortDateString();
            lblCreatedBy.Text = clsGlobal.CurrentUser.UserName;
            lblApplictionFees.Text = "15";
        }
        private void UpdateFees()
        {
            if (cmbLicenseClass.SelectedValue == null || cmbLicenseClass.SelectedValue is DataRowView)
                return;

            int classID = Convert.ToInt32(cmbLicenseClass.SelectedValue);
            lblApplictionFees.Text = clsAppliction.GetFees(classID).ToString();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    }

