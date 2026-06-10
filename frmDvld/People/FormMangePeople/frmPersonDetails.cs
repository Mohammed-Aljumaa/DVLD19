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
    public partial class frmPersonDetails : Form
    {
        public frmPersonDetails(int personID)
        {
            InitializeComponent();


            ctrlPersonDetails1.LoadPersonDetails(personID);

        }

        public frmPersonDetails(string NationalNo)
        {
            InitializeComponent();

            ctrlPersonDetails1.LoadPersonDetails(NationalNo);
        }







        //public void _LoadDetailsPersonInfo(DataGridViewRow SelectRow)
        //{


        //    ctrlPersonDetails1.SelectedPersonInfo.NationalNo=SelectRow.Cells["NationalNo"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.PersonID = Convert.ToInt32(SelectRow.Cells["PersonID"].Value);
        //    ctrlPersonDetails1.SelectedPersonInfo.FirstName = SelectRow.Cells["FirstName"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.SecondName =SelectRow.Cells["SecondName"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.ThirdName= SelectRow.Cells["ThirdName"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.LastName= SelectRow.Cells["LastName"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.DateOfBirth = Convert.ToDateTime(SelectRow.Cells["DateOfBirth"].Value);
        //    ctrlPersonDetails1.SelectedPersonInfo.Phone = SelectRow.Cells["Phone"].Value.ToString();
        //  //  ctrlPersonDetails1.SelectedPersonInfo.NationalityCountryID =SelectRow.Cells["NationalityName"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.Email = SelectRow.Cells["Email"].Value.ToString();
        //    ctrlPersonDetails1.SelectedPersonInfo.Address = SelectRow.Cells["Address"].Value.ToString();
        //    if (File.Exists(SelectRow.Cells["ImagePath"].Value.ToString()))
        //        ctrlPersonDetails1.SelectedPersonInfo.ImagePath = SelectRow.Cells["ImagePath"].Value.ToString();
        //    string GendorValue  = SelectRow.Cells["GendorCaption"].Value.ToString();
        //    if(GendorValue== "Female")
        //    {
        //        ctrlPersonDetails1.SelectedPersonInfo.Gendor = 0;
        //    }else if(GendorValue== "Male")
        //    {
        //        ctrlPersonDetails1.SelectedPersonInfo.Gendor = 1;

        //    }


        //}

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
