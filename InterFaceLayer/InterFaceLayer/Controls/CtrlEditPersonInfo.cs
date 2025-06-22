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

namespace InterFaceLayer.Controls
{
    public partial class CtrlEditPersonInfo : UserControl
    {
        public string FirstName
        {
            get { return FirstNametxt.Text.Trim(); }
        }
        public string SecondName
        {
            get { return SecondNametxt.Text.Trim(); }
        }
        public string ThirdName
        {
            get { return ThirdNametxt.Text.Trim(); }
        }
        public string FourthName
        {
            get { return FourthNametxt.Text.Trim(); }
        }
        public char Gender
        {
            get
            {
                if (FemaleRdio.Checked)
                {
                    return 'F';
                }
                else
                {
                    return 'M';
                }

            }
        }
        public string NationalNo
        {
            get { return NationalNotxt.Text.Trim(); }
        }
        public string Phone
        {
            get { return Phonetxt.Text.Trim(); }
        }
        public string Country
        {
            get { return CountriesCb.Text.Trim(); }
        }
        public string Address
        {
            get { return CountriesCb.Text.Trim(); }
        }
        public string Email
        {
            get { return Emailtxt.Text.Trim(); }
        }
        public  DateTime DateOfBirth
        {
            get
            {
              return  DateOfBirthPicker.Value.Date;
            }
        } 
        public CtrlEditPersonInfo()
        {
            InitializeComponent();
            LoadCountries();
        }

      private void LoadCountries()
        {
            DataTable dt = clsCountry.ListAllCountries();
            foreach(DataRow row in dt.Rows) {
                CountriesCb.Items.Add(row["CountryName"].ToString());
               
            }
            

        }
    }
}
