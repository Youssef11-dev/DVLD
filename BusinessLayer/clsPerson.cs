using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsPerson
    {
        enum enMode {AddNew,Update};

        enMode Mode;
        

        public int PersonId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string ThirdName { get; set; }
        public string FourthName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + SecondName + " " + ThirdName + " " + FourthName; }

        }
        public string NationalNumber {  get; set; }
        public char Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public int CountryId { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string ImagePath { get; set; }
        public string Address { get; set; }
        public clsPerson()
        {
            PersonId = -1;
            FirstName = string.Empty;
            SecondName = string.Empty;
            ThirdName = string.Empty;
            FourthName = string.Empty;
            NationalNumber = string.Empty;
            Gender = '\0';
            DateOfBirth = DateTime.MinValue;
            CountryId = -1;
            Phone = string.Empty;
            Email = string.Empty;
            ImagePath = string.Empty;
            Address = string.Empty;
            Mode = enMode.AddNew;
        }
        private clsPerson(int  id,string FirstName,string SecondName,string ThirdName,string FourthName,
            string NationalNumber,char Gender,DateTime DateOfBirth,int CountryId,string Phone,
            string Email,string ImagePath,string Address)
        {
            this.PersonId = id;
            this.FirstName = FirstName;
            this.SecondName = SecondName;
            this.ThirdName = ThirdName;
            this.FourthName = FourthName;
            this.NationalNumber = NationalNumber;
            this.Gender = Gender;
            this.DateOfBirth = DateOfBirth;
            this.CountryId = CountryId;
            this.Phone = Phone;
            this.Email = Email;
            this.ImagePath = ImagePath;
            this.Address = Address;
            this.Mode = enMode.Update;
        }
        public static clsPerson FindPersonById(int id) 
        {
            
            string firstname = "", secondname = "", thirdname = "", fourthname = "", nationalnumber = "", phone = "", email = "", imagepath = "", address = "";
            char gender = '\0';
            int countryId = -1; 
            DateTime dateOfBirth = DateTime.MinValue;
            if(clsPersonDataAccess.FindPersonById(id,ref firstname,ref secondname,ref thirdname,ref fourthname,ref nationalnumber,ref gender,
                ref dateOfBirth,ref countryId,ref phone,ref email ,ref imagepath,ref address))
            {
                return new clsPerson(id,firstname,secondname,thirdname, fourthname, nationalnumber,gender, dateOfBirth,countryId,phone,email,imagepath,address);
            }
            else
            {
                return null;
            }
 
        }
        public static clsPerson FindPersonByNationalNumber(string nationalnumber)
        {
            int id = -1;
            string firstname = "", secondname = "", thirdname = "", fourthname = "", phone = "", email = "", imagepath = "", address = "";
            char gender = '\0';
            int countryId = -1;
            DateTime dateOfBirth = DateTime.MinValue;
            if (clsPersonDataAccess.FindPersonByNationalNumber(ref id, ref firstname, ref secondname, ref thirdname, ref fourthname,  nationalnumber, ref gender,
                ref dateOfBirth, ref countryId, ref phone, ref email, ref imagepath, ref address))
            {
                return new clsPerson(id, firstname, secondname, thirdname, fourthname, nationalnumber, gender, dateOfBirth, countryId, phone, email, imagepath, address);
            }
            else
            {
                return null;
            }

        }
        public static bool DeletePersonById(int id)
        {
            return clsPersonDataAccess.DeletePerson(id);
            
        }
        private bool _AddNewPerson()
        {
            this.PersonId = clsPersonDataAccess.AddNewPerson(FirstName, SecondName, ThirdName, FourthName, NationalNumber, Gender
                , DateOfBirth, CountryId, Phone, Email, ImagePath, Address);
            return (PersonId != -1);
        }
        private bool _UpdatePerson()
        {
            return clsPersonDataAccess.UpdatePerson(PersonId,FirstName, SecondName, ThirdName, FourthName, NationalNumber, Gender
                , DateOfBirth, CountryId, Phone, Email, ImagePath, Address);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewPerson())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case enMode.Update:
                    return _UpdatePerson();

                default:
                    return false;

            }
        }
        public static DataTable GetAllPeople()
        {
            return clsPersonDataAccess.ListAllPeople();
        }
        public static bool IsPersonExist(int PersonId)
        {
           return clsPersonDataAccess.isPersonExist(PersonId);
        }
        public static bool IsPersonExist(string NationalNumber)
        {
            return clsPersonDataAccess.isPersonExist(NationalNumber);
        }

    }
}
