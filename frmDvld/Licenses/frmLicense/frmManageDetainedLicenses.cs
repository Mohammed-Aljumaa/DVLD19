using System;
using System.Data;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;

namespace frmDvld.Licenses.frmLicense
{
    public partial class frmManageDetainedLicenses : Form
    {
        public frmManageDetainedLicenses()
        {
            InitializeComponent();
        }

        // ============================================================
        // تحميل البيانات
        // ============================================================
        private void LoadDetainedLicenses()
        {
            DataTable dt = clsDetainedLicense.GetAllDetainedLicenses();
            dgvDetainedLicenses.DataSource = dt;

            lblRowCount.Text = dt.Rows.Count.ToString();
        }





        private void frmManageDetainedLicenses_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0; // None
            LoadDetainedLicenses();

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (dgvDetainedLicenses.DataSource == null)
                return;

            string filter = txtSearch.Text.Trim();
            DataView dv = ((DataTable)dgvDetainedLicenses.DataSource).DefaultView;

            if (string.IsNullOrEmpty(filter) || cbFilterBy.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lblRecordCount.Text = dv.Count.ToString();
                return;
            }

            switch (cbFilterBy.Text)
            {
                case "Detain ID":
                    dv.RowFilter = $"Convert(DetainID, 'System.String') LIKE '%{filter}%'";
                    break;

                case "License ID":
                    dv.RowFilter = $"Convert(LicenseID, 'System.String') LIKE '%{filter}%'";
                    break;

                case "Is Released":
                    dv.RowFilter = $"Convert(IsReleased, 'System.String') LIKE '%{filter}%'";
                    break;

                case "National No":
                    dv.RowFilter = $"NationalNo LIKE '%{filter}%'";
                    break;

                case "Full Name":
                    dv.RowFilter = $"FullName LIKE '%{filter}%'";
                    break;

                case "Release Application ID":
                    dv.RowFilter = $"Convert(ReleaseApplicationID, 'System.String') LIKE '%{filter}%'";
                    break;
            }

            lblRowCount.Text = dv.Count.ToString();

        }

        private void btnDetain_Click(object sender, EventArgs e)
        {
            frmDetainLicense frm = new frmDetainLicense();
            frm.ShowDialog();

            LoadDetainedLicenses();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (dgvDetainedLicenses.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a detained license first.", "Warning");
                return;
            }

            int detainID = Convert.ToInt32(
                dgvDetainedLicenses.SelectedRows[0].Cells["DetainID"].Value
            );

            frmReleaseDetainedLicense frm = new frmReleaseDetainedLicense();
            frm.ShowDialog();

            LoadDetainedLicenses();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (dgvDetainedLicenses.DataSource == null)
                return;
            txtSearch.Text = "";
                txtSearch.Visible = (cbFilterBy.SelectedIndex != 0); // إظهار/إخفاء حسب الفلتر

                if (cbFilterBy.SelectedIndex == 0)
                {
                    // None
                    DataView dv = ((DataTable)dgvDetainedLicenses.DataSource).DefaultView;
                    dv.RowFilter = "";
                    lblRowCount.Text = dv.Count.ToString();
                }
            

        }
    }
}
