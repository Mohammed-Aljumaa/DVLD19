using System;
using System.Data;
using System.Windows.Forms;
using DvldBusinessLayer.BLLClasses;

namespace frmDvld.Driver
{
    public partial class frmManageDriver : Form
    {
        public frmManageDriver()
        {
            InitializeComponent();
        }

        // ============================================================
        // تحميل البيانات
        // ============================================================
        private void LoadDrivers()
        {
            DataTable dt = clsDriver.GetAllDrivers();
            dgvDrivers.DataSource = dt;

            lblRowCount.Text = dt.Rows.Count.ToString();
        }


        private void frmManageDriver_Load(object sender, EventArgs e)
        {

            // إضافة خيارات الفلترة
            cbFilterBy.Items.Clear();
            cbFilterBy.Items.Add("None");
            cbFilterBy.Items.Add("Driver ID");
            cbFilterBy.Items.Add("Person ID");
            cbFilterBy.Items.Add("National No");
            cbFilterBy.Items.Add("Full Name");

            cbFilterBy.SelectedIndex = 0;

            LoadDrivers();

        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dgvDrivers.DataSource == null)
                return;

            txtSearch.Text = "";
            txtSearch.Visible = (cbFilterBy.SelectedIndex != 0);

            if (cbFilterBy.SelectedIndex == 0)
            {
                DataView dv = ((DataTable)dgvDrivers.DataSource).DefaultView;
                dv.RowFilter = "";
                lblRowCount.Text = dv.Count.ToString();
            }

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            if (dgvDrivers.DataSource == null)
                return;

            string filter = txtSearch.Text.Trim();
            DataView dv = ((DataTable)dgvDrivers.DataSource).DefaultView;

            if (string.IsNullOrEmpty(filter) || cbFilterBy.SelectedIndex == 0)
            {
                dv.RowFilter = "";
                lblRowCount.Text = dv.Count.ToString();
                return;
            }

            switch (cbFilterBy.Text)
            {
                case "Driver ID":
                    dv.RowFilter = $"Convert(DriverID, 'System.String') LIKE '%{filter}%'";
                    break;

                case "Person ID":
                    dv.RowFilter = $"Convert(PersonID, 'System.String') LIKE '%{filter}%'";
                    break;

                case "National No":
                    dv.RowFilter = $"NationalNo LIKE '%{filter}%'";
                    break;

                case "Full Name":
                    dv.RowFilter = $"FullName LIKE '%{filter}%'";
                    break;

                 }

            lblRowCount.Text = dv.Count.ToString();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close(); 
        }
    }
}
