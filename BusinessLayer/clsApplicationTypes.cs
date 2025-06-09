using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationTypes
    {
        public int ApplicationTypeId { get;  }
        public string ApplicationTypeName { get; }
        public double ApplicationTypeFee { get;  }

        private clsApplicationTypes(int applicationTypeId,string applicationTypeName,double applicationTypeFee) 
        {
            this.ApplicationTypeId = applicationTypeId;
            this.ApplicationTypeName = applicationTypeName;
            this.ApplicationTypeFee = applicationTypeFee;
        }
        public static clsApplicationTypes FindApplicationType(int applicationTypeId)
        {
            string applicationTypeName = "";
            double applicationTypeFee = -1.0;
            if (clsApplicationTypesDataAccess.FindApplicationType(applicationTypeId, ref applicationTypeName, ref applicationTypeFee))
            {
                return new clsApplicationTypes(applicationTypeId, applicationTypeName, applicationTypeFee);
            }
            else
            {
                return null;
            }

        }


    }
}
