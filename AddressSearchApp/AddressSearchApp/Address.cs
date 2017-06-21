using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSearchApp
{
    class Address
    {
        public string State { get; set; }
        public string StateName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }

        public Address()
        {
            this.State = "";
            this.StateName = "";
            this.City = "";
            this.Street = "";
        }

    }
}
