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
    public partial class CtrlShowPersonInfo : UserControl
    {
        private clsPerson _Person;
        public CtrlShowPersonInfo()
        {
            InitializeComponent();   
            
        }
        public bool CtrlLoad(clsPerson Person)
        {
            _Person = Person;
            return FillData();
        }
        private bool FillData()
        {
            if (_Person != null)
            {


                PersonIdlbl.Text = _Person.PersonId.ToString();
                Namelbl.Text = _Person.FullName.ToString();
                Genderlbl.Text = _Person.Gender.ToString();
                Emaillbl.Text = _Person.Email.ToString();
                Addresslbl.Text = _Person.Address.ToString();
                DateOfBirthlbl.Text = _Person.DateOfBirth.ToString("MM/dd/yyyy");
                Phonelbl.Text = _Person.Phone.ToString();
                Countrylbl.Text = _Person.CountryInfo.CountryName.ToString();
                NationalNolbl.Text = _Person.NationalNumber.ToString();
                return true;
            }
            else
            {
                MessageBox.Show("Person Not Found");
                return false;
                
            }

        }
       
        
    }
}
