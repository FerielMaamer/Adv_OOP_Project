using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class CustomerManager
    {
        private Customer[] customerList;
        private int maxCustomers;
        private int numCustomers;

        public CustomerManager(int maxCustomers)
        {
            this.maxCustomers = maxCustomers;
            numCustomers = 0;
            customerList = new Customer[maxCustomers];
        }

        public int search(int customerNumber)
        {
            for (int i = 0; i < customerList.Length; i++)
            {
                if (customerList[i].getCustomerID() == customerNumber)
                {
                    return i;
                }
            }
            return -1;
        }
        public Customer findCustomer(int index)
        {
            return customerList[index];
        }

        public bool addCustomer(int customerID, string fname, string lname, string phoneNumber)
        {
            if (numCustomers < maxCustomers)
            {
                if (search(customerID) == -1)
                {
                    customerList[numCustomers] = new Customer(fname, lname, phoneNumber);
                    numCustomers++;
                    customerList[numCustomers]
                    return true;
                }
            }
            return false;
        }

        public string viewAllCustomers()
        {
            string s = "-------- Bookings --------\n";
            for (int i = 0; i < numCustomers; i++)
            {
                s += customerList[i].ToString() + "\n";
            }
            return s;
        }

        public string viewCustomer(int customerID)
        {
            if (search(customerID) == -1)
            {
                return $"There is no customer with the ID: {customerID}";
            }
            return customerList[customerID].ToString() + "\n";
        }        

        public string deleteCustomer(int customerNumber)
        {
            int index = search(customerNumber);
            int numBookings = customerList[index].getBookings();
            if (index != -1 && numBookings==0)
            {                
                customerList[index].setBookings(numBookings-1);
                for (int i = index; i<customerList.Length; i++)
                {
                    customerList[i]=customerList[i+1]; 
                }
                return "Successfully deleted!";
            }
            return "The flight could not be deleted as it does not exist.";
        }
    }
}