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
        private Booking[] bookingList;
        private int maxBookings;
        private int numBookings;

        public Coordinator(FlightManager flightManager, CustomerManager customerManager, int maxBookings)
        {
            this.fm = flightManager;
            this.cm = customerManager;
            //this.bm = bookingManager;
            this.maxBookings = maxBookings;
            numBookings = 0;
            bookingList = new Booking[maxBookings];
        }

        //Flight class functions

        public bool addFlight(int flightNumber)
        {
            return fm.addFlight(flightNumber);
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

        public bool addCustomer(int customerID, string fname, string lname, string phone)
        {
            return cm.addCustomer(customerID, fname, lname, phone);
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

        public int search(int bookingNumber)
        {
            /*cm.viewAllCustomers();
            fm.viewAllFlights();*/

            for (int i = 0; i < bookingList.Length; i++)
            {
                if (bookingList[i].getBookingNumber() == bookingNumber)
                {
                    return i;
                }
            }
            return -1;
        }


        public bool addBooking(int bookingNumber, int customerID, int flightID)
        {
            if (numBookings < maxBookings)
            {
                int flightIndex = fm.search(flightID);
                int customerIndex = cm.search(customerID);
                int index = search(bookingNumber);
                if (index == -1 && flightIndex!=-1 && customerIndex!=-1)
                {
                    bookingList[numBookings] = new Booking(cm.findCustomer(customerIndex), fm.findFlight(flightIndex));
                    numBookings++;
                    return true;
                }
            }
            return false;
        }

        public string viewBooking(int bookingNumber)
        {
            int index = search(bookingNumber);
            if (index == -1)
            {
                return $"There is no booking with the booking number: {bookingNumber}";
            }
            return bookingList[index].ToString();
        }

        public string viewAllBookings()
        {
            string s = "-------- Bookings --------\n";
            for (int i = 0; i < numBookings; i++)
            {
                s += bookingList[i].ToString() + "\n";
            }
            return s;
        }
    }


}
}
