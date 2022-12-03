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
        private int bookingSeed;

        public BookingManager(int maxBookings)
        {
            this.maxBookings = maxBookings;
            numBookings = 0;
            bookingList = new Booking[maxBookings];
            bookingSeed = 2000;
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


        public bool addBooking(Flight flight, Customer customer)
        {
            if (numBookings < maxBookings)
            {
                int index = search(bookingSeed);
                if (index == -1)
                {
                    bookingList[numBookings] = new Booking(flight, customer);
                    customer.setNumBookings(1);
                    numBookings++;
                    bookingSeed++;
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
