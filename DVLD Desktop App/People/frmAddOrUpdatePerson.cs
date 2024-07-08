using DVLD_Business_Layer;
using DVLD_Desktop_App.Properties;
using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Net.NetworkInformation;
using DVLD_Desktop_App.Global_Classes;
namespace DVLD_Desktop_App
{

    public partial class frmAddOrUpdatePerson : Form
    {
        public enum enMode { AddNew, Update };
        private enMode _Mode;
        public enum enGender { Male = 0, Female = 1 };

        private int _PersonID = -1;
        clsPeople _Person;

        // Declare a delegate
        public delegate void Databackenventhandler(object sender, clsPeople Person);
        // Declare an event using the delegate
        public event Databackenventhandler SendPerson;

        public frmAddOrUpdatePerson()
        {
            InitializeComponent();

            _Mode = enMode.AddNew;
        }

        public frmAddOrUpdatePerson(int PersonID)
        {
            InitializeComponent();

            _Mode = enMode.Update;
            _PersonID = PersonID;
        }

        private void _FillComboBoxWithCountriesNames()
        {
            DataTable dt = clsCountries.GetAllCountries();
            foreach (DataRow Row in dt.Rows)
            {
                cbCountryName.Items.Add(Row["CountryName"]);
            }

            //this will set default country to Egypt.
            cbCountryName.SelectedIndex = cbCountryName.FindString("Egypt");
        }

        private void _ResetDefualtValues()
        {
            _FillComboBoxWithCountriesNames();

            if (_Mode == enMode.AddNew)
            {
                this.Text = "Add New PersonID";
                lblMode.Text = this.Text;
                _Person = new clsPeople();
            }
            else
            {
                this.Text = "Update PersonID";
                lblMode.Text = this.Text;
            }

            //we set the max date to 18 years from today, and set the default value the same.
            dtpDateOfBirth.MaxDate = DateTime.Now.AddYears(-18);
            dtpDateOfBirth.Value = dtpDateOfBirth.MaxDate;

            //should not allow adding age more than 100 years
            dtpDateOfBirth.MinDate = DateTime.Now.AddYears(-100);

            //set default image for the person.
            if (rbtnMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            //hide/show the remove linke incase there is no image for the person.
            lblRemoveImage.Visible = (pbPersonImage.ImageLocation != null);

            txtFirstName.Text = "";
            txtSecondName.Text = "";
            txtThirdName.Text = "";
            txtLastName.Text = "";
            txtNationalNo.Text = "";
            rbtnMale.Checked = true;
            txtPhone.Text = "";
            txtEmail.Text = "";
            txtAddress.Text = "";

        }

        private void _LoadDate()
        {
            _Person = clsPeople.Find(_PersonID);

            if (_Person == null)
            {
                MessageBox.Show("This form will be closed because No PersonID with ID = " + _PersonID.ToString());
                this.Close();
                return;
            }

            //the following code will not be executed if the person was found
            lblPersonID.Text = _PersonID.ToString();
            txtFirstName.Text = _Person.FirstName;
            txtSecondName.Text = _Person.SecondName;
            txtThirdName.Text = _Person.ThirdName;
            txtLastName.Text = _Person.LastName;
            txtNationalNo.Text = _Person.NationalNo;
            txtEmail.Text = _Person.Email;
            txtPhone.Text = _Person.Phone;
            txtAddress.Text = _Person.Address;
            dtpDateOfBirth.Value = _Person.DateOfBirth;
            cbCountryName.SelectedIndex = cbCountryName.FindString(_Person.CountryInfo.Name);

            if (_Person.Gender == 0)
                rbtnMale.Checked = true;
            else
                rbtnFemale.Checked = true;

            if (_Person.ImagePath != "")
            {
                pbPersonImage.ImageLocation = _Person.ImagePath;
                lblRemoveImage.Visible = true;
            }
        }

        private void frmAddOrUpdatePerson_Load(object sender, EventArgs e)
        {
            _ResetDefualtValues();

            if (_Mode == enMode.Update)
                _LoadDate();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.InitialDirectory = "C:\\Users\\zayed\\OneDrive\\Pictures\\Saved Pictures";
            openFileDialog1.Title = "Choose Picture";
            openFileDialog1.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog1.FilterIndex = 0;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pbPersonImage.Load(openFileDialog1.FileName);
                lblRemoveImage.Visible = true;

            }
        }

        private void lblRemoveImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pbPersonImage.ImageLocation = null;

            if (rbtnMale.Checked)
                pbPersonImage.Image = Resources.Male_512;
            else
                pbPersonImage.Image = Resources.Female_512;

            lblRemoveImage.Visible = false;
        }

        private void ValidateEmptyTextBox(object sender, CancelEventArgs e)
        {
            //set AutoValidate property of your Form to Enable Allow Focus Change in the designer
            if (string.IsNullOrWhiteSpace(((TextBox)sender).Text))
            {
                e.Cancel = true;
                epValidation.SetError(((TextBox)sender), "This field is required");
            }
            else
            {
                epValidation.SetError(((TextBox)sender), "");
            }
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNationalNo.Text))
            {
                e.Cancel = true;
                epValidation.SetError(txtNationalNo, "This field is required");
                return;
            }
            else
            {
                epValidation.SetError(txtNationalNo, "");
            }

            //Make sure the national number is not used by another person
            if (txtNationalNo.Text.ToUpper() != _Person.NationalNo && clsPeople.IsExist(txtNationalNo.Text.ToUpper()))
            {
                e.Cancel = true;
                epValidation.SetError(txtNationalNo, "National Number is used for anthor person!");
            }
            else
            {
                epValidation.SetError(txtNationalNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            //no need to validate the email incase it's empty
            if (txtEmail.Text.Trim() == "")
                return;

            if (!clsValidation.ValidateEmail(txtEmail.Text.Trim()))
            {
                e.Cancel = true;
                epValidation.SetError(txtEmail, "Invalid Email Address Format!");
            }
            else
            {
                epValidation.SetError(txtEmail, "");
            }
        }

        private void txtPhone_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                e.Cancel = true;
                epValidation.SetError(txtPhone, "This field is required");
                return;
            }
            else
            {
                epValidation.SetError(txtPhone, "");
            }

            //Make sure the Phone number  contains only number.
            if (!clsValidation.ValidateInteger(txtPhone.Text))
            {
                e.Cancel = true;
                epValidation.SetError(txtPhone, "This field Must be Numbers");
            }
            else
            {
                epValidation.SetError(txtPhone, "");
            }
        }

        private bool _HandlePersonImage()
        {
            //this procedure will handle the person image,
            //it will take care of deleting the old image from the folder
            //in case the image changed. and it will rename the new image with guid and 
            // place it in the images folder.


            //_Person.ImagePath contains the old Image, we check if it changed then we copy the new image
            if (_Person.ImagePath != pbPersonImage.ImageLocation)
            {
                if (_Person.ImagePath != "")
                {
                    //first we delete the old image from the folder in case there is any.
                    try
                    {
                        File.Delete(_Person.ImagePath);
                    }
                    catch (IOException e)
                    {
                        // We could not delete the file.
                        //log it later   
                    }
                }

                //then we copy the new image to the image folder after we rename it
                if (pbPersonImage.ImageLocation != null)
                {
                    string sourcefile = pbPersonImage.ImageLocation;
                    if (clsUtilites.CopyImageToProjectImagesFolder(ref sourcefile))
                    {
                        pbPersonImage.ImageLocation = sourcefile;
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("Error Copying Image File", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }

            return true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                //Here we dont continue becuase the form is not valid
                MessageBox.Show("Some fileds are not valide!, put the mouse over the red icon(s) to see the erro", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!_HandlePersonImage())
                return;

            _Person.FirstName = txtFirstName.Text.Trim();
            _Person.SecondName = txtSecondName.Text.Trim();
            _Person.ThirdName = txtThirdName.Text.Trim();
            _Person.LastName = txtLastName.Text.Trim();
            _Person.NationalNo = txtNationalNo.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Phone = txtPhone.Text.Trim();
            _Person.Email = txtEmail.Text.Trim();
            _Person.Address = txtAddress.Text.Trim();

            if (rbtnMale.Checked)
                _Person.Gender = (byte)enGender.Male;
            else
                _Person.Gender = (byte)enGender.Female;

            _Person.DateOfBirth = dtpDateOfBirth.Value.Date;
            _Person.CountryInfo = clsCountries.Find(cbCountryName.Text);
            _Person.NationalityCountryID = _Person.CountryInfo.ID;

            if (pbPersonImage.ImageLocation != null)
                _Person.ImagePath = pbPersonImage.ImageLocation;
            else
                _Person.ImagePath = "";

            if (_Person.Save())
            {
                _Mode = enMode.Update;
                lblMode.Text = "Update PersonID";
                lblPersonID.Text = _Person.ID.ToString();

                MessageBox.Show("Data Saved Successfully.");

                // Trigger the event to send data back to the caller form.
                SendPerson?.Invoke(this, _Person);
            }
            else
                MessageBox.Show("Error: Data Is not Saved Successfully.");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rbtnMale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to male incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Male_512;
        }

        private void rbtnFemale_CheckedChanged(object sender, EventArgs e)
        {
            //change the defualt image to female incase there is no image set.
            if (pbPersonImage.ImageLocation == null)
                pbPersonImage.Image = Resources.Female_512;
        }
    }
}
 
