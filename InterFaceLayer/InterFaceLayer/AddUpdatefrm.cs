using BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InterFaceLayer
{
    public partial class AddUpdatefrm : Form
    {
        int _personId;
        clsPerson _person;
        enum enMode { AddNew,Update}
        enMode Mode;
        public AddUpdatefrm()
        {
            InitializeComponent();
        }
        public AddUpdatefrm(int PersonId)
        {
            InitializeComponent();
            UpdatePerson(PersonId);
        }
        private void UpdateDataObject()
        {
            _person.FirstName = ctrlEditPersonInfo1.FirstName;
            _person.SecondName = ctrlEditPersonInfo1.SecondName;
            _person.ThirdName = ctrlEditPersonInfo1.ThirdName;
            _person.FourthName = ctrlEditPersonInfo1.FourthName;
            _person.NationalNumber = ctrlEditPersonInfo1.NationalNo;
            _person.DateOfBirth = ctrlEditPersonInfo1.DateOfBirth;
            _person.Gender = ctrlEditPersonInfo1.Gender;
            _person.Phone = ctrlEditPersonInfo1.Phone;
            _person.Email = ctrlEditPersonInfo1.Email;
            _person.Address = ctrlEditPersonInfo1.Address;
            _person.CountryId = clsCountry.FindCountry(ctrlEditPersonInfo1.Country).CountryId;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (Mode == enMode.AddNew) {
                _person = new clsPerson();
            }
            UpdateDataObject();        
            {
                if (_person.Save())
                {
                    MessageBox.Show("Data Saved Succesfully");
                    UpdatePerson(_person.PersonId);
                }
                else
                {
                    MessageBox.Show("Data didn't Saved ,Change National Number");
                }
            }
        }
        private void UpdatePerson(int PersonId)
        {
            _personId = PersonId;
            _person = clsPerson.FindPersonById(_personId);
            PersonIdlbl.Text = _personId.ToString();
            if (_person == null)
            {
                MessageBox.Show("Person Not Found Add New Menu Will Open ...");
                Mode = enMode.AddNew;

            }
            else
            {
                AddUpdatePerson.Text = "Update Person";
                Mode = enMode.Update;
            }
        }
    }
}
