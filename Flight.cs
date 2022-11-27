using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Flight
    {
        private int flightNumber;
        private int capacity;
        private Customer[] customers;

        public Flight(int flightNumber, int capacity)
        {
            this.flightNumber = flightNumber;
            this.capacity = capacity;
            customers = new Customer[capacity];
        }

        public int getFlightNumber()
        {
            return flightNumber;
        }

        public void setFlightNumber(int flightNumber)
        {
            this.flightNumber = flightNumber;
        }

        public int getCapacity()
        {
            return capacity;
        }

        public void setCapacity(int capacity)
        {
            this.capacity = capacity;
        }

        public bool addCustomer(Customer customer)
        {
            if (getCapacity() <= customers.Length)
            { return false; }

            if (customers.Length == 0)
            {
                customers[customers.Length] = customer;
                return true;
            }

            foreach (Customer _customer in customers)
            {
                if (_customer.getCustomerID() == customer.getCustomerID())
                { return false; }
            }
            customers[customers.Length] = customer;
            return true;
        }

        public override string ToString()
        {
            return $"Flight number: {flightNumber}\n";
        }
    }
}