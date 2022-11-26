using System;
using System.Collections.Generic;
using System.Text;

namespace projectOOP
{
    internal class Booking
    {
        string bookingDate;
        string bookingNum;
        Flight flight;
        Customer customer;

        public Booking(Flight flight, Customer customer)
        {                        
            this.flight = flight;
            this.customer = customer;
            //generating booking date
            this.bookingDate = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");
            //randomly generated booking number
            Random generator = new Random();
            this.bookingNum = generator.Next(0, 1000000).ToString("D6");
        }
        public string getBookingDate() { return bookingDate; }
        public string getBookingNum() { return bookingNum; }

        public string viewBooking()
        {
            string s = "Booking Date: " + bookingDate + "\nBooking Number: " + bookingNum +
                "\nCustomer Name: " + customer.getName() + "\nFlight number: " + flight.getFilghtNumber;
            return s;
        }

    }
}
