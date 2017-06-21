using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressSearchApp
{
    class Core
    {
        public static async Task<dynamic> GetAddressSearchResult(string address)
        {
            string pzNumber = address.Substring(0,3);
            string taNumber = address.Substring(3);

            string queryString = "http://api.thni.net/jzip/X0401/JSON/" + pzNumber + "/" + taNumber + ".js";
            dynamic results = await HttpService.getDataFromService(queryString).ConfigureAwait(false);

            if ((results != null) && (!string.IsNullOrEmpty((string)results["state"])))
            {
                Address Ad = new Address();
                Ad.State = (string)results["state"];
                Ad.StateName = (string)results["stateName"];
                Ad.City = (string)results["city"];
                Ad.Street = (string)results["street"];
                return Ad;
            }
            else
            {
                return null;
            }

        }
    }
}
