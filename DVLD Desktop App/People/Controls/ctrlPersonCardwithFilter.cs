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
    public partial class ctrlPersonCardwithFilter : UserControl
    {

        public ctrlPersonCardwithFilter()
        {
            InitializeComponent();
        }

        public event Action<clsPeople> OnPersonSelected;

        protected virtual void PersonSelected(clsPeople Person)
        {
            Action<clsPeople> handler = OnPersonSelected;
            if (handler != null)
            {
                handler(Person);
            }
        }

        public int PersonID
        {
            get { return ctrlPersonCard1.PersonID; }
        }
        public clsPeople SelectedPersonInfo
        {
            get { return ctrlPersonCard1.SelectedPersonInfo; }
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
                btnAddNewPerson.Visible = _ShowAddPerson;
            }
        }

        private bool _FilterEnabled = true;
        public bool FilterEnabled
        {
            get
            {
                return _FilterEnabled;
            }
            set
            {
                _FilterEnabled = value;
                gbFilters.Enabled = _FilterEnabled;
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            mtxtSearchValue.Text = "";
            switch (cbFilter.SelectedIndex)
            {
                case 0:
                    mtxtSearchValue.Mask = null;
                    break;
                case 1:
                    mtxtSearchValue.Mask = "0000000000";
                    break;
            }
            mtxtSearchValue.Focus();
        }

        private void FindNow()
        {
            switch (cbFilter.SelectedIndex)
            {
                case 0: //search with nationalno.

                    string PersonNationalNo = mtxtSearchValue.Text.ToUpper().Trim();

                    ctrlPersonCard1.LoadPersonInfo(PersonNationalNo);

                    break;
                case 1: //search with person id.

                    int ApplicantPersonID = Convert.ToInt32(mtxtSearchValue.Text.Trim());

                    ctrlPersonCard1.LoadPersonInfo(ApplicantPersonID);

                    break;
            }
        }

        public void LoadPersonInfo(int ApplicantPersonID)
        {
            cbFilter.SelectedIndex = 1; //person id.
            mtxtSearchValue.Text = ApplicantPersonID.ToString();
            FindNow();
        }

        public void LoadPersonInfo(clsPeople person)
        {
            cbFilter.SelectedIndex = 1; //person id.
            mtxtSearchValue.Text = person.ID.ToString();
            ctrlPersonCard1.LoadPersonInfo(person);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            FindNow();
        }

        private void ctrPerson_getNewAddedPerson(object sender, clsPeople Person)
        {
            cbFilter.SelectedIndex = 1;
            mtxtSearchValue.Text = Person.ID.ToString();
            ctrlPersonCard1.LoadPersonInfo(Person);
        }

        private void btnAddNewPerson_Click(object sender, EventArgs e)
        {
            frmAddOrUpdatePerson frm = new frmAddOrUpdatePerson();
            frm.SendPerson += ctrPerson_getNewAddedPerson;
            frm.ShowDialog();
        }

        private void ctrlPersonCardwithFilter_Load(object sender, EventArgs e)
        {
            cbFilter.SelectedIndex = 0;
            mtxtSearchValue.Focus();
        }

        private void mtxtSearch_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(mtxtSearchValue.Text.Trim()))
            {
                e.Cancel = true;
                errorProvider1.SetError(mtxtSearchValue, "This field is required!");
            }
            else
            {
                //e.Cancel = false;
                errorProvider1.SetError(mtxtSearchValue, null);
            }
        }

        public void FilterFocus()
        {
            mtxtSearchValue.Focus();
        }
    }
}
