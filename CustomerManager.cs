using System;
using System.Collections.Generic;
using System.Text;

namespace projectOOP
{
    internal class CustomerManager
    {
        public int searchCustomerID(int customerID)
        {
            for (int x = 0; x < numCustomers; x++)
            {
                if (customerList[x].getCustomerID() == customerID)
                {
                    customerFind(x);
                    return x;
                }
            }
            return -1;
        }
        public Customer customerFind(int x)
        {
            return customerList[x];
        }
    }
}
