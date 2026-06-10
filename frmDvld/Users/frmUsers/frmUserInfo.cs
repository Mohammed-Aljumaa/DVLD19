using DvldBusinessLayer;
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

namespace frmDvld.Users.frmUsers
{
    public partial class frmUserInfo : Form
    {
        public frmUserInfo()
        {
            InitializeComponent();
        }
        int _UserID;
        clsUsers _User;

        public int userID
        {
            get { return _UserID; }
        }
        public frmUserInfo(int UserID )
        {
            InitializeComponent();
            _UserID = UserID;
            
        }

        public frmUserInfo(clsUsers user)
        {
            InitializeComponent();
            _User = user;
            _UserID = user.UserID;

        }

        private void _LoadData()
        {
            _User = clsUsers.Find(_UserID);


            if(_User == null)
            {
                MessageBox.Show("User not found!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;

            }

            int PersonID = _User.PersonID;
            ctrlPersonDetails1.LoadPersonDetails(PersonID);
            ctrlLogInfo1.LoadUserLogInfo(_UserID);


        }


        private void frmUserInfo_Load(object sender, EventArgs e)
        {
            _LoadData();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
