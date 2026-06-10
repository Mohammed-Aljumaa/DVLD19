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

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmPersonLicenseHistory : Form
    {


        private int _PersonID;
        public frmPersonLicenseHistory(int personID)
        {
            InitializeComponent();
            _PersonID = personID;
        }

        private void frmPersonLicenseHistory_Load(object sender, EventArgs e)
        {

            // تحميل معلومات الشخص
            ctrlPersonCardWithFilter1.LoadPersonInfo(_PersonID);

            // تحميل الرخص المحلية
            var dtLocal = clsLicense.GetLocalLicensesByPersonID(_PersonID);
            dgvLocalLicenses.DataSource = dtLocal;

            // تحميل الرخص الدولية
            var dtInternational = clsInternationalLicense.GetInternationalLicensesByPersonID(_PersonID);
            dgvInternationalLicenses.DataSource = dtInternational;

            // أول تبويب هو Local
            lblRecord.Text = $" {dtLocal.Rows.Count}";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (taball.SelectedTab == tabLocal)
            {
                lblRecord.Text = $" {dgvLocalLicenses.Rows.Count}";
            }
            else if (taball.SelectedTab == tapInternational)
            {
                lblRecord.Text = $" {dgvInternationalLicenses.Rows.Count}";
            }
        }
    }
    }

