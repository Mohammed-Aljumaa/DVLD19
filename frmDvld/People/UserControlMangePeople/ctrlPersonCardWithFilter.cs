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

namespace frmDvld
{
    public partial class ctrlPersonCardWithFilter : UserControl
    {
        public ctrlPersonCardWithFilter()
        {
            InitializeComponent();
        }


        public event Action<int> OnPersonSelected;

        protected virtual void PersonSelected(int PersonID)
        {
            Action<int> Handler = OnPersonSelected;

            if (Handler != null)
            {
                Handler(PersonID);
            }



        }


        private bool _ShowAddPerson = true;

        public bool ShowAddPerson
        {

            get
            {

                return _ShowAddPerson;

            }
            set
            {
                _ShowAddPerson = value;
                btnAddPerson.Visible = _ShowAddPerson;
            }


        }

        private bool _FilterEnable = true;

        public bool FilterEnable
        {

            get
            {

                return _FilterEnable;

            }
            set
            {
                _FilterEnable = value;
                gbFilter.Visible = _FilterEnable;
            }


        }



        private int _PersonID = -1;

        public string SearchText
        {
            get { return txtSearch.Text; }
            set { txtSearch.Text = value; }
        }
        public int PersonID
        {
            set { _PersonID = value; }
            get { return ctrlPersonDetails1.PersonID; }
        }

        public clsMangepeople SelectedPersonInfo
        {
            get { return ctrlPersonDetails1.SelectedPersonInfo; }
        }


        public void LoadPersonInfo(int PersonID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtSearch.Text = PersonID.ToString();

            FindNow();

        }

        public void FindNow()
        {


            switch (cbFilterBy.Text)
            {
                case "Person ID":
                    ctrlPersonDetails1.LoadPersonDetails(int.Parse(txtSearch.Text));
                    break;

                case "National No":
                    ctrlPersonDetails1.LoadPersonDetails(txtSearch.Text);
                    break;

                default: break;


            }

            if (OnPersonSelected != null && FilterEnable)
                OnPersonSelected(ctrlPersonDetails1.PersonID);

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            if (!this.ValidateChildren())
            {
                MessageBox.Show("Some filde are not valide!,put the mouse over the red icon", "Required", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            FindNow();
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {
            cbFilterBy.SelectedIndex = 0;
            txtSearch.Focus();
            
         

           
        }

        private void txtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
            {

                errorProvider1.SetError(txtSearch, "This field is required!");
            }
            else
            {
                errorProvider1.SetError(txtSearch, null);
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {


            frmAddEditPersonInfo frm3 = new frmAddEditPersonInfo(-1);
            frm3.DataBack += DataBackEvent;
            frm3.ShowDialog();

        }


        private void DataBackEvent(object Sender, int personID)
        {
            cbFilterBy.SelectedIndex = 1;
            txtSearch.Text = personID.ToString();
            ctrlPersonDetails1.LoadPersonDetails(personID);

        }


        public void FilterFoucs()
        {
            txtSearch.Focus();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {


            if (e.KeyChar == (char)13)
            {
                btnSearch.PerformClick();
            }



            if (cbFilterBy.Text == "Person ID")
                e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cbFilterBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSearch.Visible = (cbFilterBy.Text != "Noun");

            if (txtSearch.Visible)
            {
                txtSearch.Text = "";
                txtSearch.Focus();
            }

        }
        public void ClearSearch()
        {
            txtSearch.Text = "";
            PersonID = -1;
        }







      }
}
