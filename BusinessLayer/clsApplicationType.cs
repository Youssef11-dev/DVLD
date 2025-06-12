using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class clsApplicationType
    {
        public byte ApplicationTypeId { get;  }
        public string ApplicationTypeName { get; }
        public double ApplicationTypeFee { get;  }

        private clsApplicationType(byte applicationTypeId,string applicationTypeName,double applicationTypeFee) 
        {
            this.ApplicationTypeId = applicationTypeId;
            this.ApplicationTypeName = applicationTypeName;
            this.ApplicationTypeFee = applicationTypeFee;
        }
        public static clsApplicationType FindApplicationType(byte applicationTypeId)
        {
            string applicationTypeName = "";
            double applicationTypeFee = -1.0;
            if (clsApplicationTypeDataAccess.FindApplicationType(applicationTypeId, ref applicationTypeName, ref applicationTypeFee))
            {
                return new clsApplicationType(applicationTypeId, applicationTypeName, applicationTypeFee);
            }
            else
            {
                return null;
            }

        }
      


    }
}
