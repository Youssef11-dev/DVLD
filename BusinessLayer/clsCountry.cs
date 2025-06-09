using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
     public class clsCountry
    {

        public int CountryId { get; set; }
        public string CountryName { get; set; }
        private clsCountry(int CountryId,string CountryName)
        { 
            this.CountryId = CountryId;
            this.CountryName = CountryName;

        }
        public clsCountry()
        {
            this.CountryId = -1;
            this.CountryName = "";
        }
        public static clsCountry FindCountry(int CountryId) 
        {
            string countryName = "";
           if( clsCountryDataAccess.FindCountry(CountryId,ref countryName))
            {
                return new clsCountry(CountryId,countryName);
            }
            else
            {
                return null;
            }
            
        
        }
        public static clsCountry FindCountry(string CountryName)
        {
            int CountryId = -1;
            
            if (clsCountryDataAccess.FindCountry(ref CountryId, CountryName))
            {
                return new clsCountry(CountryId, CountryName);
            }
            else
            {
                return null;
            }


        }


    }
}
