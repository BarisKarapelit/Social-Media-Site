using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.MermisServiceReference;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Adapters
{
    public class MernisServiceAdapter : ICustomerCheckService
    {
        public bool CheckIfRealPerson(Customer customer)
        {
            KPSPublicSoapClient client = new KPSPublicSoapClient();

            //KPSPublicSoapClient gereksimleri 
            long TC = Convert.ToInt64(customer.NationalityId);
            string name = customer.FirstName.ToUpper();
            string surname = customer.LastName.ToUpper();
            int birthYear =(int)Convert.ToInt32(customer.DateOfBirth.Year);

            bool status=client.TCKimlikNoDogrula(TC,name,surname,birthYear);

            return status;
                
        }
    }
}
