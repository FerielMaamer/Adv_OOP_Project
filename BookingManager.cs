using System;
using System.Collections.Generic;
using System.Text;

namespace projectOOP
{
    internal class BookingManager
    {
        private Booking[] bookingsList;
        private int maxBookings;
        private int numBookings;

        public BookingManager(int maxBookings)
        {
            this.maxBookings = maxBookings;
            this.numBookings = 0;
            this.bookingsList = new Booking[maxBookings];
        }
        public bool addBooking()
        {
            if (numBookings < maxBookings)
            {
                FlightManager.viewFlights();
                CustomerManager.viewCustomers();
                Console.WriteLine("Please enter the customer ID for the booking: ");
                string custID = Console.ReadLine();
                Console.WriteLine("Please enter the flight ID for the booking: ");
                string flightID = Console.ReadLine();
                if (CustomerManager.findCustomer(custID) != -1 && FlightManager.findFlight(flightID) != -1)
                    //outputs to user if not found and returns -1 else returns the object
                    
                {
                    if (Flight.addCustomer(custID))
                    //addCustomer() should check if the flight is full or not and if the customer is already part of flight or not
                    //outputs to user if flight is full or cutomer exists
                    {
                        bookingsList[numBookings] = new Booking(flight, customer);
                        numBookings++;
                        return true;
                    }
                    else { return false; }                    
                }
                else { return false; }

            }
        }
    }
}
