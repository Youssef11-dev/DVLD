using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLicenseClass
    {
        enum enMode { AddNew,Update}
        enMode Mode;
        public byte LicenseClassId { get; set; }
        public string ClassName { get; set; }
        public string ClassDescription { get; set; }
        public byte MinimunAllowedAge { get; set; }
        public byte ValidityLength { get; set; }
        public double ClassFee { get; set; }

        private clsLicenseClass()
        {
            this.LicenseClassId = 0;
            this.ValidityLength = 0;
            this.ClassFee = 0;
            this.MinimunAllowedAge = 0;
            this.ClassName = "";
            this.ClassDescription = "";
            Mode = enMode.AddNew;
        }
        private clsLicenseClass(byte LicenseClassId,string ClassName,string ClassDescription,byte MinimumAllowedAge,byte ValidityLength
            ,double ClassFee)
        {
            this.LicenseClassId= LicenseClassId;
            this.ClassName= ClassName;
            this.ClassDescription= ClassDescription;
            this.MinimunAllowedAge= MinimumAllowedAge;
            this.ValidityLength= ValidityLength;
            this.ClassFee= ClassFee;
            Mode = enMode.Update;
        }
        public static clsLicenseClass FindLicenseClassById(byte ClassId)
        {
            string ClassName = "";
            string ClassDescription = "";
            byte MinimunAllowedAge = 0;
            byte ValidityLength = 0;
            double ClassFee = 0;
            if (clsLicenseClassDataAccess.FindLicenseClassById(ClassId, ref ClassName, ref ClassDescription, ref MinimunAllowedAge,
                ref ValidityLength, ref ClassFee))
            {
                return new clsLicenseClass(ClassId, ClassName, ClassDescription, MinimunAllowedAge, ValidityLength, ClassFee);
            }
            else
            {
                return null;
            }
        }
        public static clsLicenseClass FindLicenseClassByName(string ClassName)
        {
            byte ClassId = 0;
            string ClassDescription = "";
            byte MinimunAllowedAge = 0;
            byte ValidityLength = 0;
            double ClassFee = 0;
            if (clsLicenseClassDataAccess.FindLicenseClassByClassName(ref ClassId,  ClassName, ref ClassDescription, ref MinimunAllowedAge,
                ref ValidityLength, ref ClassFee))
            {
                return new clsLicenseClass(ClassId, ClassName, ClassDescription, MinimunAllowedAge, ValidityLength, ClassFee);
            }
            else
            {
                return null;
            }
        }
        private bool _UpdateLicenseClass()
        {
            return clsLicenseClassDataAccess.UpdateLicenseClass(this.LicenseClassId, this.ClassName, this.ClassDescription, this.MinimunAllowedAge
                , this.ValidityLength, this.ClassFee);
        }
        public bool Save()
        {
            switch(Mode)
            {
                case enMode.Update:
                return _UpdateLicenseClass();
            }
            return false;
        }
    }
}
