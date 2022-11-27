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

        public bool addFlight(int flightNumber)
        {
            return fm.addFlight(flightNumber);
        }

        public bool addCustomer(int customerID, string fname, string lname, string phone)
        {
            return cm.addCustomer(customerID, fname, lname, phone);
        }

        public bool addBooking(int bookingNumber, int customerID, int flightID)
        {
            return bm.addBooking(bookingNumber, customerID, flightID);
        }


    }
}
