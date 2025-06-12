using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplication
    {
        public enum enStatus { New=1,Canceled=2,Completed=3}

        protected enum enMode { AddNew=1,Update=2};
        
        public enum enApplicationType { CreateNewLicense=1,RenewLicense=2,ReplacementForLost=3, ReplacementForDamaged=4,
            ReleaseDetainedLicense=5,CreateNewInternationalLicense=6,RetakeTest=7
        }
       protected enMode Mode;


        public int ApplicationId { get; set; } 

        public enApplicationType ApplicationType;

        public clsApplicationType ApplicationTypeInfo;
        public DateTime ApplicationDate { get; set; }
        public int ApplicantId { get; set; }

        public clsPerson ApplicantInfo;

        public enStatus ApplicationStatus;
        public double PaidFees { get; set; }
        public int CreatedByUser { get; set; }
        public clsUser CreatedByUserInfo;


        private clsApplication(int applicationId, enApplicationType ApplicationType,DateTime ApplicationDate,int ApplicantId
            ,enStatus ApplicationStatus,double PaidFee,int CreatedByUser)
        {

            ApplicationId = applicationId;
            this.ApplicationType = ApplicationType;
            this.ApplicationDate = ApplicationDate;
            this.ApplicantId = ApplicantId;
            this.ApplicationStatus =ApplicationStatus;
            this.PaidFees = PaidFee;
            this.CreatedByUser = CreatedByUser; 
            this.CreatedByUserInfo = clsUser.FindUserById(CreatedByUser);
            this.ApplicantInfo = clsPerson.FindPersonById(ApplicantId);
            this.ApplicationTypeInfo = clsApplicationType.FindApplicationType((byte)ApplicationType);
            Mode = enMode.Update;
           

        }
      public  clsApplication()
        {
            this.ApplicationId = -1;
            this.ApplicationType = 0;
            this.ApplicantId= -1;
            this.PaidFees= 0;
            this.CreatedByUser = -1;
            this.ApplicationStatus = enStatus.New;
            this.ApplicationDate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }

        public static clsApplication FindApplicationById(int applicationId)
        {
            int CreatedByUser = -1, ApplicantId = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            byte ApplicationType = 0, ApplicationStatus = 0;
            double PaidFee = 0;
            if (clsApplicationDataAccess.FindApplicationById(applicationId,ref ApplicationType,ref ApplicationDate
                ,ref ApplicantId
                ,ref ApplicationStatus,ref PaidFee,ref CreatedByUser))
            {
                return new clsApplication(applicationId,(enApplicationType)ApplicationType,ApplicationDate,ApplicantId
                    , (enStatus)ApplicationStatus,PaidFee,CreatedByUser);

            }
            else
            {
                return null;
            }

        }

        public static bool DeleteApplication(int applicationId)
        {
           
             return  clsApplicationDataAccess.DeleteApplication(applicationId);
        
        }
        private bool _AddNewApplication() 
        {
            this.ApplicationId= clsApplicationDataAccess.AddNewApplication((byte)this.ApplicationType, this.ApplicationDate, this.ApplicantId
                , (byte)this.ApplicationStatus, this.PaidFees, this.CreatedByUser) ;
            return (this.ApplicationId != -1);
        
        }
        private bool _UpdateApplication()
        {
            return clsApplicationDataAccess.UpdateApplication(ApplicationId,(byte)ApplicationType,ApplicationDate,
                ApplicantId,(byte)ApplicationStatus,PaidFees,CreatedByUser) ;

        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewApplication())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateApplication();
                    
            }

            return false;

        }
        

    }
}
