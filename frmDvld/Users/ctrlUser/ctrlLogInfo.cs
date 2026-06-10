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

namespace frmDvld.Users.ctrlUser
{
    public partial class ctrlLogInfo : UserControl
    {
        public ctrlLogInfo()
        {
            InitializeComponent();
        }
        int _UserID;
        clsUsers _User;


        public void LoadUserLogInfo(int userID)
        {

            _UserID = userID;
            _User = clsUsers.Find(_UserID);
            if (_User == null)
            {
                MessageBox.Show("User not found!", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            lblUserID.Text = _User.UserID.ToString();
            lblUserName.Text = _User.UserName.ToString();
            lblUserActive.Text = _User.IsActives ? "Yes" : "No";
        }
    }
}


