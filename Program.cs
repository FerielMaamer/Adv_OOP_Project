using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    class program
    {
        public static Coordinator coord;

        public static void showMainMenu()
        {
            Console.Clear();
            Console.WriteLine("Select a choice from the menu below:");
            Console.WriteLine("1: Customers");
            Console.WriteLine("2: Flights");
            Console.WriteLine("3: Bookings");
            Console.WriteLine("4: Exit");
        }

        public static void showFlightMenu()
        {
            Console.Clear();
            Console.WriteLine("Flight Menu");
            Console.WriteLine("Select a choice from the menu below:");
            Console.WriteLine("1: Add a flight");
            Console.WriteLine("2: View flights");
            Console.WriteLine("3: View a specific flight");
            Console.WriteLine("4: Delete Flight");
            Console.WriteLine("5: Back to main menu");
        }

        //Flight menu functions:
        

        public static void showCustomerMenu()
        {
            Console.Clear();
            Console.WriteLine("Customer Menu");
            Console.WriteLine("Select a choice from the menu below:");
            Console.WriteLine("1: Add customer");
            Console.WriteLine("2: View customers");
            Console.WriteLine("3: Delete customer");
            Console.WriteLine("4: Back to main menu");
        }

        public static void showBookingMenu()
        {
            Console.Clear();
            Console.WriteLine("Booking Meny");
            Console.WriteLine("Select a choice from the menu below:");
            Console.WriteLine("1: Make a booking");
            Console.WriteLine("2: View bookings");
            Console.WriteLine("3: Back to main menu");
        }

        /* public static int getValidInput()
         {
             int choice;
             showMainMenu();
             while (!int.TryParse(Console.ReadLine(), out choice))
             {
                 showMainMenu();
             }
             return choice;

             static void Main(string[] args)
             {

             }
         }*/

        static void Main(string[] args)
        {
            FlightManager fm = new FlightManager(100);
            CustomerManager cm = new CustomerManager(100);
            coord = new Coordinator(fm, cm, 100);
            coord.addFlight(101010, 30, "Toronto", "London");
            coord.addFlight(202020,40, "London", "Toronto");
            Console.WriteLine(coord.viewAllFlights());
            coord.addCustomer( "Feriel", "maamer", "647555555",1);
            coord.addCustomer( "John", "Doe", "6474444444",0);
            Console.WriteLine(coord.viewAllCustomers());
            Console.WriteLine("input customerID");
            int custID = Int32.Parse(Console.ReadLine());
            coord.deleteCustomer(custID);
            Console.WriteLine(coord.viewFlight(101010));

            Console.WriteLine(coord.viewAllFlights());
            Console.WriteLine(coord.viewAllCustomers());




        }
    }
}