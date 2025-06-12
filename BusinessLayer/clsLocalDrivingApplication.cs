using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsLocalDrivingApplication:clsApplication
    {

        enum enMode { AddNew=1,Update=2}
        public enum enTestPasses { NoTestPassed = 0,VisionTestPassed=1,WrittedTestPassed=2,StreetTestPassed=3}
        public enum enLicenseClass { SmallMotorcycle=1, HeavyMotorcycleLicense=2, OrdinaryDrivingLicense =3,
            Commercial=4, Agricultural=5, SmallAndMediumBus=6, TruckAndHeavyVehicle=7
        }
        public int LocalDrivingLicenseApplicationId { get; set; }
        public enTestPasses TestPassed;
        public clsLicenseClass LicenseClassInfo;

        public enLicenseClass LicenseClass;
        enMode Mode;

        public clsLocalDrivingApplication()
        {
            this.LocalDrivingLicenseApplicationId = -1;
            this.TestPassed = enTestPasses.NoTestPassed;
            this.LicenseClass = enLicenseClass.TruckAndHeavyVehicle;
            Mode = enMode.AddNew;
        }
        private clsLocalDrivingApplication(int localDrivingLicenseApplicationId, enTestPasses testPassed,  enLicenseClass licenseClass,
            int ApplicationId,enApplicationType ApplicationType,DateTime ApplicationDate,int ApplicantId,enStatus ApplicationStatus,
            double PaidFees,int CreatedByUserId
            )
        {
            LocalDrivingLicenseApplicationId = localDrivingLicenseApplicationId;
            TestPassed = testPassed;
            LicenseClass = licenseClass;
            this.ApplicationId = ApplicationId;
            this.ApplicationType = ApplicationType;
            this.ApplicationDate = ApplicationDate;
            this.ApplicantId = ApplicantId;
            this.ApplicationStatus = ApplicationStatus;
            this.PaidFees = PaidFees;
            this.CreatedByUser= CreatedByUserId;
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationType((byte)ApplicationType);
            this.ApplicantInfo = clsPerson.FindPersonById(ApplicationId);
            this.CreatedByUserInfo = clsUser.FindUserById(CreatedByUserId);
            this.LicenseClassInfo = clsLicenseClass.FindLicenseClassById((byte)LicenseClass);
            Mode = enMode.Update;
        }
        public static clsLocalDrivingApplication FindLocalDrivingApplicationById(int LocalDrivingLicenseApplicationId)
        {
            int ApplicationId = -1;
            byte LicenseClass = 0;
            byte TestPasses = 0;
            if(clsLocalDrivingApplicationLicenseDataAccess.FindApplicationByLocalApplicationId(LocalDrivingLicenseApplicationId,
               ref ApplicationId,ref TestPasses,ref LicenseClass)){
                clsApplication Application = clsApplication.FindApplicationById(ApplicationId);
                if (Application != null) {
                    return new clsLocalDrivingApplication(LocalDrivingLicenseApplicationId, (enTestPasses)TestPasses
                        ,(enLicenseClass) LicenseClass, ApplicationId, Application.ApplicationType, Application.ApplicationDate, Application.ApplicantId,
                        Application.ApplicationStatus, Application.PaidFees, Application.CreatedByUser);
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }

        }

        private bool _AddNewLocalDrivingLicenseApplication()
        {
            this.LocalDrivingLicenseApplicationId = clsLocalDrivingApplicationLicenseDataAccess.AddNewLocalApplication(
                this.ApplicationId,(byte)this.TestPassed,(byte)this.LicenseClass);
            return (this.LocalDrivingLicenseApplicationId != -1);
        }
        private bool _UpdateLocalDrivingLicenseApplication()
        {
            return clsLocalDrivingApplicationLicenseDataAccess.UpdateLocalApplication(this.LocalDrivingLicenseApplicationId
                , this.ApplicationId, (byte)this.TestPassed,(byte) this.LicenseClass);
        }

        public bool Save()
        {
            base.Mode = (clsApplication.enMode)Mode;
            if(!base.Save()) return false;
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewLocalDrivingLicenseApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                    case enMode.Update:
                     return _UpdateLocalDrivingLicenseApplication(); 
                    
                    default:
                    return false;

            }

        }



    }
}
