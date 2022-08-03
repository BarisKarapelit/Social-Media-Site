using InterfaceAbstractDemo.Abstract;
using InterfaceAbstractDemo.Adapters;
using InterfaceAbstractDemo.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfaceAbstractDemo
{
    internal class Program
    {
       public static void Main(string[] args)
        {
            BaseCustomerManager customerManager = new NoreCustomerManager(new MernisServiceAdapter());
            customerManager.Save(new Customer { 
                DateOfBirth=new DateTime(1995,8,22),
                FirstName="Barış",
                LastName="Karapelit",
                NationalityId= "59920514432"
            });
            Console.ReadLine();

        }
    }
}
