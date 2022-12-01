using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Coordinator
    {
        private FlightManager fm;
        private CustomerManager cm;
        //private BookingManager bm;
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
            loadUpDataFromBookingsFile();
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


        public bool addBooking(int customerID, int flightID)
        {
            if (numBookings < maxBookings)
            {
                int flightIndex = fm.search(flightID);
                int customerIndex = cm.search(customerID);
                //int index = search(bookingNumber);
                if (flightIndex!=-1 && customerIndex!=-1 && fm.findFlight(flightIndex).flightHasSpace())
                {
                    bookingList[numBookings] = new Booking(cm.findCustomer(customerIndex), fm.findFlight(flightIndex));
                    numBookings++;
                    updateBookingsFile();
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
        private void updateBookingsFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("./dataFiles/bookings.txt"))
                {

                    foreach (Booking b in bookingList)
                    {
                        if (b != null)
                        {
                            writer.WriteLine("{0},{1}", b.getCustomer().getCustomerID(), b.getFlight().getFlightNumber());
                        }
                        else
                        {
                            break;
                        }
                    }
                    writer.Close();
                }  

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
           
        }
        
        private void loadUpDataFromBookingsFile()
        {
      
            //loop over each line of the file 
            //turn the line into an array 
            //use addCustomers() to add up the data
            
            // Read file using StreamReader. Reads file line by line   
            try
            {
                using(StreamReader file = new StreamReader("./dataFiles/bookings.txt")) {  
             
                    string ln;
                    while (( ln = file.ReadLine()) != null) {  
                        Console.WriteLine(ln);
                        string[] columns = ln.Split(",");
                        int cutId = int.Parse(columns[0]);
                        int fId = int.Parse(columns[1]);

                        addBooking(cutId,fId);
                    }  
                    file.Close();  
           
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
        

  
    }

}

