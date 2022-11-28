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
        private string origin;
        private string destination;
        private int capacity;
        private Customer[] customers;
        

        public Flight(int flightNumber, int capacity, string origin, string destination)
        {
            this.flightNumber = flightNumber;
            this.capacity = capacity;
            customers = new Customer[capacity];
            this.origin = origin;
            this.destination = destination;
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

        public string getOrigin()
        {
            return origin;
        }

        public void setOrigin(string origin)
        {
            this.origin = origin;
        }
        public string getDestination()
        {
            return destination;
        }

        public void setDestination(string Destination)
        {
            this.destination = destination;
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
            string s = $"Flight number: {flightNumber}\n";
            s+= $"Flight Origin: {origin}"
            s+= $"Flight destination: {destination}"
            return s;
        }
    }
}