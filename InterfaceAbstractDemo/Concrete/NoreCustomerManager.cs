using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Adapters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo.Concrete
{
    public class NoreCustomerManager:BaseCustomerManager
    {
       private MernisServiceAdapter _mernisServiceAdapter;

        public NoreCustomerManager(MernisServiceAdapter mernisServiceAdapter)
        {
            _mernisServiceAdapter = mernisServiceAdapter;
        }

        public override void Save(Customer customer)
        {
            if (_mernisServiceAdapter.CheckIfRealPerson(customer))
            {
                base.Save(customer);
            }
            
        }

        
    }
}
