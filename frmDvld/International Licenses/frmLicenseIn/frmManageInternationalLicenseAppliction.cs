using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;
using frmDvld.Licenses.frmLicense;

namespace frmDvld.International_Licenses.frmLicenseIn
{
    public partial class frmManageInternationalLicenseAppliction : Form
    {
        public frmManageInternationalLicenseAppliction()
        {
            InitializeComponent();
        }

        // ============================================================
        // 1) جلب InternationalLicenseID من الصف المحدد
        // ============================================================
        private int GetSelectedInternationalID()
        {
            if (dgvInternationalLicenses.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dgvInternationalLicenses.CurrentRow.Cells["InternationalLicenseID"].Value
            );
        }

        // ============================================================
        // 2) جلب DriverID من الصف المحدد
        // ============================================================
        private int GetSelectedDriverID()
        {
            if (dgvInternationalLicenses.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dgvInternationalLicenses.CurrentRow.Cells["DriverID"].Value
            );
        }

        // ============================================================
        // 3) جلب ApplicationID من الصف المحدد
        // ============================================================
        private int GetSelectedApplicationID()
        {
            if (dgvInternationalLicenses.CurrentRow == null)
                return -1;

            return Convert.ToInt32(
                dgvInternationalLicenses.CurrentRow.Cells["ApplicationID"].Value
            );
        }

        // ============================================================
        // 4) تحميل كل الرخص الدولية
        // ============================================================
        private void _LoadInternationalLicenses()
        {
            DataTable dt = clsInternationalLicense.GetAll(); // لازم يكون موجود عندك
            dgvInternationalLicenses.DataSource = dt;

            lblRecordCount.Text = dt.Rows.Count.ToString();
            cbFilterBy.SelectedIndex = 0;

        }

        private void showPersonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int driverID = GetSelectedDriverID();
            if (driverID <= 0)
            {
                MessageBox.Show("Select a valid record.");
                return;
            }

            clsDriver driver = clsDriver.Find(driverID);
            if (driver == null)
            {
                MessageBox.Show("Driver not found.");
                return;
            }

            frmPersonLicenseHistory frm = new frmPersonLicenseHistory(driver.PersonID);
            frm.ShowDialog();

        }

        private void cmsInternationalMange_Opening(object sender, CancelEventArgs e)
        {
            if (dgvInternationalLicenses.CurrentRow == null)
            {
                e.Cancel = true;
                return;
            }

            showPersonToolStripMenuItem.Enabled = true;
            showLicenseDetailsToolStripMenuItem.Enabled = true;
            showPersonToolStripMenuItem.Enabled = true;

        }

        private void frmManageInternationalLicenseAppliction_Load_1(object sender, EventArgs e)
        {
            _LoadInternationalLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbFilterBy.Text == "None")
            {
                txtSearch.Visible = false;
                txtSearch.Text = "";
                (dgvInternationalLicenses.DataSource as DataTable).DefaultView.RowFilter = "";
            }
            else
            {
                txtSearch.Visible = true;
                txtSearch.Focus();
            }

        }

        private void txtSearch_TextChanged_1(object sender, EventArgs e)
        {
            if (dgvInternationalLicenses.DataSource == null)
                return;

            if (cbFilterBy.Text == "None")
            {
                (dgvInternationalLicenses.DataSource as DataTable).DefaultView.RowFilter = "";
                return;
            }

            string columnName = "";
            bool isNumeric = false;

            switch (cbFilterBy.Text)
            {
                case "Int.License ID":
                    columnName = "InternationalLicenseID";
                    isNumeric = true;
                    break;

                case "Application ID":
                    columnName = "ApplicationID";
                    isNumeric = true;
                    break;

                case "Driver ID":
                    columnName = "DriverID";
                    isNumeric = true;
                    break;

                case "Local License ID":
                    columnName = "LocalLicenseID";
                    isNumeric = true;
                    break;

                case "Is Active":
                    columnName = "IsActive";
                    break;
            }

            if (isNumeric)
            {
                (dgvInternationalLicenses.DataSource as DataTable).DefaultView.RowFilter =
                    $"Convert([{columnName}], 'System.String') LIKE '{txtSearch.Text}%'";
            }
            else
            {
                (dgvInternationalLicenses.DataSource as DataTable).DefaultView.RowFilter =
                    $"[{columnName}] LIKE '{txtSearch.Text}%'";
            }

        }

        private void showToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int driverID = GetSelectedDriverID();
            if (driverID <= 0)
            {
                MessageBox.Show("Select a valid record.");
                return;
            }

            clsDriver driver = clsDriver.Find(driverID);
            if (driver == null)
            {
                MessageBox.Show("Driver not found.");
                return;
            }

            frmPersonDetails frm = new frmPersonDetails(driver.PersonID);
            frm.ShowDialog();


        }

        private void showLicenseDetailsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            int id = GetSelectedInternationalID();

            if (id <= 0)
            {
                MessageBox.Show("Select a valid international license.");
                return;
            }

            frmInternationalDriverInfo frm = new frmInternationalDriverInfo(id);
            frm.ShowDialog();

        }

        private void btnAddNewLicense_Click(object sender, EventArgs e)
        {
            frmNewInternationalLicenseAppliction frm = new frmNewInternationalLicenseAppliction();
            frm.ShowDialog();

            _LoadInternationalLicenses(); // إعادة تحميل البيانات بعد الإضافة


        }
    }
}
