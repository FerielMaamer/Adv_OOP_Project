using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Booking
    {
        private int bookingNumber = 0;
        private Customer customer;
        private Flight flight;
        private string date;

        public Booking(Customer customer, Flight flight)
        {
            this.bookingNumber = ++bookingNumber;
            this.customer = customer;
            this.flight = flight;
            this.date = DateTime.Now.ToString(@"MM\/dd\/yyyy  h\:mm tt");
        }

        public int getBookingNumber()
        {
            return bookingNumber;
        }

        /*public void setBookingNumber(int bookingNumber)
        {
            this.bookingNumber = bookingNumber;
        }*/

        public Customer getCustomer()
        {
            return customer;
        }

        /*public void setCustomer(Customer customer)
        {
            this.customer = customer;
        }*/

        public Flight getFlight()
        {
            return flight;
        }
        /*
        public void setFlight(Flight flight)
        {
            this.flight = flight;
        }*/

        public override string ToString()
        {
            return $"Booking Number: {bookingNumber}\nFlight Number: {flight}\nCustomer ID: {customer}";
        }
    }
}
