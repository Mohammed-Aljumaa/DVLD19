using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace frmDvld.International_Licenses.ctrlLicenseIn
{
    public partial class ctrlLicenseFilter : UserControl
    {

        public event Action<int> OnSearch;



        public ctrlLicenseFilter()
        {
            InitializeComponent();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int id;

            if (!int.TryParse(txtLicenseID.Text, out id))
            {
                MessageBox.Show("Please enter a valid License ID.");
                return;
            }

            OnSearch?.Invoke(id);
        }
    }
}
