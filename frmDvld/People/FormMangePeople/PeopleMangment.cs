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
using frmDvld.LoginScreens;

namespace frmDvld
{
    public partial class frmMangePeople : Form
    {

        private static DataTable _dtAllPeople=clsMangepeople.GetAllPeople();

        private DataTable _dtPeople = _dtAllPeople.DefaultView.ToTable(false, "PersonID", "NationalNo", "FirstName","SecondName","ThirdName", "LastName",
            "GendorCaption", "DateOfBirth", "NationalityName", "Phone", "Email");

       


        public frmMangePeople()
        {
            InitializeComponent();
        }
        
            void _RefrechAllPepole()
            {
                // إعادة تحميل البيانات في الجدول الأساسي
                _dtAllPeople = clsMangepeople.GetAllPeople();

                // إنشاء نسخة مفلترة من الأعمدة المطلوبة فقط
                _dtPeople = _dtAllPeople.DefaultView.ToTable(false,
                    "PersonID", "NationalNo", "FirstName", "SecondName", "ThirdName", "LastName",
                    "GendorCaption", "DateOfBirth", "NationalityName", "Phone", "Email");

                // ربط الجدول بالـ DataGridView
                dgvAllPeople.DataSource = _dtPeople;
            }
        
        private void frmMangePeople_Load(object sender, EventArgs e)
        {

            _UbdateRecordsCount();

            dgvAllPeople.DataSource = _dtPeople;
            cbFilterBy.SelectedIndex = 0;

            lblRecords.Text = dgvAllPeople.Rows.Count.ToString();

            if(dgvAllPeople.Rows.Count>0)
            {

                dgvAllPeople.Columns[0].HeaderText = "Person ID";
                dgvAllPeople.Columns[0].Width = 100;
                
                dgvAllPeople.Columns[1].HeaderText = "National No";
                dgvAllPeople.Columns[1].Width = 120;
                
                dgvAllPeople.Columns[2].HeaderText = "First Name";
                dgvAllPeople.Columns[2].Width = 120;
                
                dgvAllPeople.Columns[3].HeaderText = "Second Name";
                dgvAllPeople.Columns[3].Width = 120;
                
                dgvAllPeople.Columns[4].HeaderText = "Third Name";
                dgvAllPeople.Columns[4].Width = 120;
                
                dgvAllPeople.Columns[5].HeaderText = "Last Name";
                dgvAllPeople.Columns[5].Width = 100;
                
                dgvAllPeople.Columns[6].HeaderText = "Gendor";
                dgvAllPeople.Columns[6].Width = 120;
                
                dgvAllPeople.Columns[7].HeaderText = "Date Of Btrth";
                dgvAllPeople.Columns[7].Width = 140;
                
                dgvAllPeople.Columns[8].HeaderText = "Nationalty";
                dgvAllPeople.Columns[8].Width = 120;
                
                dgvAllPeople.Columns[9].HeaderText = "Phone";
                dgvAllPeople.Columns[9].Width = 120;
                
                dgvAllPeople.Columns[10].HeaderText = "Email";
                dgvAllPeople.Columns[10].Width = 170;








            }






            _RefrechAllPepole();
            _UbdateRecordsCount();

            btnAddNewPerson.ImageList = ilAddPerson;
            btnAddNewPerson.ImageIndex = 0;

        }
      

       


        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frmAddPerson1 = new frmAddEditPersonInfo(-1);
            frmAddPerson1.ShowDialog();
            
            _RefrechAllPepole();
            _UbdateRecordsCount();
        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string FilterCoulmn = "";


            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    FilterCoulmn = "PersonID";
                    break;

                case "National No":
                    FilterCoulmn = "NationalNo";
                    break;

                case "First Name":
                    FilterCoulmn = "FirstName";
                    break;

                case "Second Name":
                    FilterCoulmn = "SecondName";
                    break;

                case "Third Name":
                    FilterCoulmn = "ThirdName";
                    break;

                case "Last Name":
                    FilterCoulmn = "LastName";
                    break;

                case "Nationality":
                    FilterCoulmn = "NationalityName";
                    break;

                case "Gender":
                    FilterCoulmn = "GendorCaption";
                    break;

                case "Phone":
                    FilterCoulmn = "Phone";
                    break;

                case "Email":
                    FilterCoulmn = "Email";
                    break;

                default:
                    FilterCoulmn = "Noun";
                    break;

            }
                    //RestFilter :

                    if(txtSearch.Text.Trim()==""||FilterCoulmn=="Noun")
                    {
                        _dtPeople.DefaultView.RowFilter = "";
                        _UbdateRecordsCount();

                        return;
                    }

                    if(cbFilterBy.Text== "Person ID")
                        _dtPeople.DefaultView.RowFilter = string.Format("CONVERT([{0}],'System.String')LIKE '{1}%'", 
                            FilterCoulmn,txtSearch.Text.Trim()); 

                    else
                        _dtPeople.DefaultView.RowFilter = string.Format("[{0}] LIKE '{1}%'",
                            FilterCoulmn, txtSearch.Text.Trim());

                     _UbdateRecordsCount();
            }
        
        private void _UbdateRecordsCount()
        {

            lblRecords.Text = $"{dgvAllPeople.Rows.Count.ToString()}";

        }
        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilterBy.Text!="Noun");

            if(txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        
       
        private void taToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(-1);

            frm.ShowDialog();
            _RefrechAllPepole();
            _UbdateRecordsCount();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dgvAllPeople.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please choose a person.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int PersonID = Convert.ToInt32(dgvAllPeople.CurrentRow.Cells[0].Value);
            frmAddEditPersonInfo frm = new frmAddEditPersonInfo(PersonID);

            frm.ShowDialog();
            _RefrechAllPepole();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (MessageBox.Show("Are you sure Want To Delete Person [ " + (int)dgvAllPeople.CurrentRow.Cells[0].Value + " ]",
          "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                if (clsMangepeople.DeletePerson((int)dgvAllPeople.CurrentRow.Cells[0].Value))
                {
                    MessageBox.Show("Person Delete Successfully.", "Successfully", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    _RefrechAllPepole();
                }
                else
                {
                    MessageBox.Show("Failed to delete the person.", "Deletion Failed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

                _UbdateRecordsCount();
            }
        }

        private void showDeToolStripMenuItem_Click(object sender, EventArgs e)
        {

          
                // تحقق أولًا من وجود صف محدد
                if (dgvAllPeople.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Please choose a person.", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            int PersonID =Convert.ToInt32( dgvAllPeople.CurrentRow.Cells[0].Value);
            frmPersonDetails frm = new frmPersonDetails(PersonID);

            frm.ShowDialog();
            _RefrechAllPepole();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmLoginScreens frm32=new frmLoginScreens();
            frm32.ShowDialog();
        }

        
    }
    }
 
