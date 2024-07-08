using DVLD_Business_Layer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Desktop_App
{
    public partial class frmUserDetails : Form
    {
        public frmUserDetails(int userID)
        {
            InitializeComponent();
            ctrlUserInfromation1.LoadUserInfo(userID);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
