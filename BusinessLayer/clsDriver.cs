using System;
using DataAccessLayer;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsDriver
    {
        enum enMode { AddNew,Update }
        public int DriverId { get; set; }
        enMode Mode;
        public int PersonId { get; set; }
        public int CreatedByUserId { get; set; }
        public DateTime CreatedDate { get; set; }

        //Composition
        public clsPerson PersonInfo;
        public clsUser UserInfo;


        public clsDriver()
        {
            this.DriverId = -1;
            this.PersonId = -1;
            this.CreatedByUserId = -1;
            Mode = enMode.AddNew;
            this.CreatedDate = DateTime.Now;
        }
        private clsDriver(int driverId,int personId,int createdByUserId,DateTime createdDate)
        {
            this.DriverId=driverId;
            this.PersonId=personId;
            this.CreatedByUserId=createdByUserId;
            this.CreatedDate=createdDate;
            UserInfo = clsUser.FindUserById(this.CreatedByUserId);
            PersonInfo = clsPerson.FindPersonById(this.PersonId);
            Mode = enMode.Update;   
                }
        public static clsDriver FindDriverById(int driverId)
        {
            int PersonId = -1, CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriverDataAccess.FindDriverById(driverId,ref PersonId,ref CreatedByUserId,ref CreatedDate)) {
                return new clsDriver(driverId,PersonId,CreatedByUserId,CreatedDate);
            }
            else
            {
                return null;
            }
        }
        public static clsDriver FindDriverByPersonId(int PersonId)
        {
            int DriverId = -1, CreatedByUserId = -1;
            DateTime CreatedDate = DateTime.Now;
            if (clsDriverDataAccess.FindDriverByPersonId(ref DriverId,PersonId,ref CreatedByUserId,ref CreatedDate))
            {
                return new clsDriver(DriverId, PersonId, CreatedByUserId, CreatedDate);
            }
            else
            {
                return null;
            }
        }
        public static bool DeleteDriverById(int DriverId) {
            return clsDriverDataAccess.DeleteDriver(DriverId);
        }
        private bool _UpdateDriver()
        {
            return clsDriverDataAccess.UpdatePerson(this.DriverId,this.PersonId,this.CreatedByUserId,this.CreatedDate);
        }
        private bool _AddNewDriver()
        {
            this.DriverId = clsDriverDataAccess.AddNewDriver(PersonId, CreatedByUserId, CreatedDate);
            return (this.DriverId != -1);
        }
        public bool Save()
        {
            switch (Mode)
            {
                case enMode.AddNew:
                    if (_AddNewDriver())
                    {
                        Mode = enMode.Update;
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    return _UpdateDriver();
            }
            return false;
        }

    }
}
