using DvldBusinessLayer.BLLClasses;
using frmDvld.Users.frmUsers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.Users
{
    public partial class frmManageUsers : Form
    {


        public frmManageUsers()
        {
            InitializeComponent();
        }



        private static DataTable _dtAllUsers = clsUsers.GetAllUsers();

        private static DataTable _dtUsers = _dtAllUsers.DefaultView.ToTable
            (false, "UserID", "PersonID", "FullName", "UserName", "IsActive");



        void _RefreshAllUsers()
        {
            _dtAllUsers = clsUsers.GetAllUsers();

            _dtUsers = _dtAllUsers.DefaultView.ToTable
            (false, "UserID", "PersonID", "FullName", "UserName", "IsActive");


            dgvAllUsers.DataSource = _dtUsers;

        }
        void _UpdateRecordCount()
        {
            lblRecordCount.Text = $"{dgvAllUsers.Rows.Count.ToString() }";
        }

        private void frmManageUsers_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            dgvAllUsers.DataSource = _dtUsers;

            _UpdateRecordCount();



            if (dgvAllUsers.Rows.Count > 0)
            {
                dgvAllUsers.Columns[0].HeaderText = "User ID";
                dgvAllUsers.Columns[0].Width = 80;

                dgvAllUsers.Columns[1].HeaderText = "Person ID";
                dgvAllUsers.Columns[1].Width = 100;

                dgvAllUsers.Columns[2].HeaderText = "Full Name";
                dgvAllUsers.Columns[2].Width = 200; // الاسم الكامل يحتاج عرض أكبر

                dgvAllUsers.Columns[3].HeaderText = "User Name";
                dgvAllUsers.Columns[3].Width = 130;

                dgvAllUsers.Columns[4].HeaderText = "Is Active";
                dgvAllUsers.Columns[4].Width = 70; // مجرد CheckBox
            }
            dgvAllUsers.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;


            _RefreshAllUsers();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {

            this.Close();

        }


        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (cbFilterBy.Text == "PersonID" || cbFilterBy.Text == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm = new frmAddNewUser();
            frm.ShowDialog();

            _RefreshAllUsers();
            _UpdateRecordCount();
        }



        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterBy.Text == "IsActive")
            {
                txtFilterValue.Visible = false;
                cbIsActiveFilter.Visible = true;
                cbIsActiveFilter.Enabled = true;

            }

            else
            {
                txtFilterValue.Visible = true;
                txtFilterValue.Enabled = true;
                cbIsActiveFilter.Visible = false;
                cbIsActiveFilter.Enabled = false;

                txtFilterValue.Text = "";
            }
        }

        private void txtFilterValue_TextChanged(object sender, EventArgs e)
        {

            string column = cbFilterBy.Text;
            string value = txtFilterValue.Text.Trim();

            if (string.IsNullOrEmpty(value))
            {
                _dtUsers.DefaultView.RowFilter = "";
                return;
            }
            int number; 
            if (column == "UserID" || column == "PersonID")
            {
                if (int.TryParse(value, out number))
                {
                    _dtUsers.DefaultView.RowFilter = $"{column} ={number}";
                }
                else
                {
                    _dtUsers.DefaultView.RowFilter = $"1=0";
                }
            }
            else
            {
                _dtUsers.DefaultView.RowFilter = $"{column} LIKE '%{value}%'";
            }

        }

        private void cbIsActiveFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string choice = cbIsActiveFilter.Text;

            if (choice == "All")
            {
                _dtUsers.DefaultView.RowFilter = "";
            }
            else if (choice == "Yes")
            {
                _dtUsers.DefaultView.RowFilter = "IsActive = true";
            }
            else if (choice == "No")
            {
                _dtUsers.DefaultView.RowFilter = "IsActive = false";
            }


        }

        private void showDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

            // تحقق أولًا من وجود صف محدد
            if (dgvAllUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a person.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

                int userID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);

                frmUserInfo frm = new frmUserInfo(userID);
                frm.ShowDialog();
            

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllUsers.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a person.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int UserID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);
            int PersonID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[1].Value);
            frmAddNewUser frm = new frmAddNewUser(UserID,PersonID);

            frm.ShowDialog();
            _RefreshAllUsers();
            
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure Want To Delete Person [ " + (int)dgvAllUsers.CurrentRow.Cells[0].Value + " ]",
                "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsUsers.DeleteUser((int)dgvAllUsers.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Delete Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefreshAllUsers();
                }
                else
                {
                    MessageBox.Show("Failed to delete the person.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                _UpdateRecordCount();
            }
        }

        private void taToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddNewUser frm =new frmAddNewUser();
            frm.ShowDialog();
            _RefreshAllUsers();
            _UpdateRecordCount();
        }

        private void ChangePasswordtoolStripMenuItem1_Click(object sender, EventArgs e)
        {
            
                // تأكد إنو في صف محدد
                if (dgvAllUsers.CurrentRow == null)
                    return;

                // جلب الـ UserID من أول عمود (حسب تصميمك)
                int userID = Convert.ToInt32(dgvAllUsers.CurrentRow.Cells[0].Value);

                // فتح شاشة تغيير كلمة السر
                frmChangePassword frm = new frmChangePassword(userID);
                frm.ShowDialog();

            

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}

