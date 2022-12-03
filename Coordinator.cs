using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Coordinator
    {
        private FlightManager fm;
        private CustomerManager cm;
        private BookingManager bm;

        public Coordinator(FlightManager flightManager, CustomerManager customerManager, BookingManager bookingManager)
        {
            this.fm = flightManager;
            this.cm = customerManager;
            this.bm = bookingManager;
        }

        //Flight class functions

        public bool addFlight(int flightNumber, int capacity, string origin, string destination)
        {
            return fm.addFlight(flightNumber, capacity, origin, destination);
        }

        public string viewAllFlights()
        {
            return fm.viewAllFlights();
        }

        public string viewFlight(int flightNumber)
        {
            return fm.viewFlight(flightNumber);
        }
        public string deleteFlight(int flightNumber)
        {
            return fm.deleteFlight(flightNumber);
        }

        // Customer class functions

        public bool addCustomer(string fname, string lname, string phone)
        {
            return cm.addCustomer(fname, lname, phone);
        }
        public string viewAllCustomers()
        {
            return cm.viewAllCustomers();
        }
        public string deleteCustomer(int customerNumber)
        {
            return cm.deleteCustomer(customerNumber);
        }

        // Booking class functions


        public bool addBooking(int customerID, int flightID)
        {
            int flightIndex = fm.search(flightID);
            int customerIndex = cm.search(customerID);
            Flight flight = fm.findFlight(flightIndex);
            Customer customer = cm.findCustomer(customerIndex);
            if (flightIndex!=-1 && customerIndex!=-1 && fm.findFlight(flightIndex).flightHasSpace())
            {
                return bm.addBooking(flight, customer);
            }
            return false;
        }
    }


}

