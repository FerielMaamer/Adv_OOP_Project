using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class BookingManager
    {
        private Booking[] bookingList;
        private int maxBookings;
        private int numBookings;

        public BookingManager(int maxBookings)
        {
            this.maxBookings = maxBookings;
            numBookings = 0;
            bookingList = new Booking[maxBookings];
        }

        public int search(int bookingNumber)
        {
            for (int i = 0; i < bookingList.Length; i++)
            {
                if (bookingList[i].getBookingNumber() == bookingNumber)
                {
                    return i;
                }
            }
            return -1;
        }

        public bool addBooking(int bookingNumber, Customer customer, Flight flight)
        {
            if (numBookings < maxBookings)
            {
                int index = search(bookingNumber);
                if (index == -1)
                {
                    bookingList[numBookings] = new Booking(customer, flight);
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
