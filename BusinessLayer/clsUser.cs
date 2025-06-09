using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsUser
    {
        enum enMode { AddNew, Update};
        private enMode Mode;
        public int UserId { get; set; }
        public int PersonId { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        private clsUser(int userId,int personId,string userName,string password,bool isActive)
        {
            this.UserId = userId;
            this.PersonId = personId;
            this.UserName = userName;
            this.Password = password;
            this.IsActive = isActive;
            Mode = enMode.Update;
        }
        public clsUser()
        {
            Mode = enMode.AddNew;
            UserId = -1;
            PersonId = -1;
            UserName = string.Empty;
            Password = string.Empty;
            IsActive = false;
        }


       public static clsUser FindUserById(int userId) 
        {
            int UserId = userId;
            string UserName = "", Password = "";
            int PersonId = -1;
            bool IsActive = false;
            if (clsUserDataAccess.FindUserById(userId,ref PersonId, ref UserName, ref Password, ref IsActive))
            {
                return new clsUser(UserId,PersonId,UserName,Password,IsActive);
            }
            else
            {
                return null;
            }
        
        }
        private bool _AddNewUser()
        {
            this.UserId = clsUserDataAccess.AddNewUser(PersonId,UserName,Password,IsActive);
            return (UserId != -1);
        }
        private bool _UpdateUser()
        {
            return (clsUserDataAccess.UpdateUser(UserId,PersonId,UserName,Password,IsActive));
        }

        public bool Save()
        {
            switch (Mode) 
            {
                case enMode.AddNew:
                    if (_AddNewUser()) 
                    { 
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                case enMode.Update:
                    if (_UpdateUser()) {
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
