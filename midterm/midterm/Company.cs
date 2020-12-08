using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MidTerm2019
{
    [Serializable]
    public class Company
    {
        public Guid CompanyID { get; set; }
        public string CompanyName { get; set; }
        public string HouseNumber { get; set; }
        public string Street { get; set; }
        public string City { get; set; }

        public Company()
        {
        }

        public Company(string companyName, string houseNumber, string street, string city)
        {
            CompanyID = Guid.NewGuid();
            CompanyName = companyName;
            HouseNumber = houseNumber;
            Street = street;
            City = city;
        }

        public override string ToString()
        {
            return CompanyName;
        }
    }
}
