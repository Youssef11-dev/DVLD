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
        enum enStatus { New=1,Canceled=2,Completed=3}

        enum enMode { AddNew,Update};
        
        enum enApplicationType { CreateNewLicense=1,RenewLicense=2,ReplacementForLost=3, ReplacementForDamaged=4,
            ReleaseDetainedLicense=5,CreateNewInternationalLicense=6,RetakeTest=7
        }
        enMode Mode;
        public int ApplicationId { get; set; }
        
        public byte ApplicationType { get; set; }

        public DateTime ApplicationDate { get; set; }
        public int ApplicantId { get; set; }

        enStatus ApplicationStatus;
        public double PaidFee { get; set; }
        public int CreatedByUser { get; set; }


        private clsApplication(int applicationId, byte ApplicationType,DateTime ApplicationDate,int ApplicantId
            ,enStatus ApplicationStatus,double PaidFee,int CreatedByUser)
        {

            ApplicationId = applicationId;
            this.ApplicationType = ApplicationType;
            this.ApplicationDate = ApplicationDate;
            this.ApplicantId = ApplicantId;
            this.ApplicationStatus =ApplicationStatus;
            this.PaidFee = PaidFee;
            this.CreatedByUser = CreatedByUser; 
            Mode = enMode.Update;
           

        }
      public  clsApplication()
        {
            this.ApplicationId = -1;
            this.ApplicationType = 0;
            this.ApplicantId= -1;
            this.PaidFee= 0;
            this.CreatedByUser = -1;
            this.ApplicationStatus = enStatus.New;
            this.ApplicationDate = DateTime.MinValue;
            Mode = enMode.AddNew;
        }

        public static clsApplication FindApplicationById(int applicationId)
        {
            int ApplicationId = -1, CreatedByUser = -1, ApplicantId = -1;
            DateTime ApplicationDate = DateTime.MinValue;
            byte ApplicationType = 0, ApplicationStatus = 0;
            double PaidFee = 0;
            if (clsApplicationDataAccess.FindApplicationById(applicationId,ref ApplicationType,ref ApplicationDate
                ,ref ApplicantId
                ,ref ApplicationStatus,ref PaidFee,ref CreatedByUser))
            {
                return new clsApplication(ApplicationId,ApplicationType,ApplicationDate,ApplicantId
                    , (enStatus)ApplicationStatus,PaidFee,CreatedByUser);

            }
            else
            {
                return null;
            }

        }

        public static bool DeleteApplication(int applicationId)
        {
            if ((int)(clsApplication.FindApplicationById(applicationId).ApplicationStatus) == 1)
            {
             return  clsApplicationDataAccess.DeleteApplication(applicationId);
            }
            else
            {
                return false;
            }
        }
        private bool _AddNewApplication() 
        {
            this.ApplicationId= clsApplicationDataAccess.AddNewApplication((byte)this.ApplicationType, this.ApplicationDate, this.ApplicantId
                , (byte)this.ApplicationStatus, this.PaidFee, this.CreatedByUser) ;
            return (this.ApplicationId != -1);
        
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
                    
            }
            return false;

        }
        

    }
}
