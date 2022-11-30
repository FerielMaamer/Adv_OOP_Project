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
        private int maxBookings;
        private int numBookings;

        public Coordinator(FlightManager flightManager, CustomerManager customerManager, BookingManager bookingManager)
        {
            this.fm = flightManager;
            this.cm = customerManager;
            this.bm = bookingManager;
            numBookings = 0;
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

        public bool addCustomer(string fname, string lname, string phone, int numBookings)
        {
            return cm.addCustomer(fname, lname, phone, numBookings);
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

        /*public int search(int bookingNumber)
        {
            cm.viewAllCustomers();
            fm.viewAllFlights();

            for (int i = 0; i < bookingList.Length; i++)
            {
                if (bookingList[i].getBookingNumber() == bookingNumber)
                {
                    return i;
                }
            }
            return -1;
        }*/


        public bool addBooking(int customerID, int flightID)
        {
            if (numBookings < maxBookings)
            {
                int flightIndex = fm.search(flightID);
                int customerIndex = cm.search(customerID);
                //int index = search(bookingNumber);
                if (flightIndex!=-1 && customerIndex!=-1 && fm.findFlight(flightIndex).flightHasSpace())
                {
                    bm.addBooking(fm.findFlight(flightIndex), cm.findCustomer(customerIndex));
                    numBookings++;
                    return true;
                }
            }
            return false;
        }
        /*
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
        }*/
    }


}

