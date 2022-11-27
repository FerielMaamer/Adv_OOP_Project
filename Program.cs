﻿namespace project
{
    class program
    {
        public static Coordinator coordintor;

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

        public static int getValidInput()
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
        }
    }
}