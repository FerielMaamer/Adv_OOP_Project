using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class FlightManager
    {
        private Flight[] flightList;
        private int maxFlights;
        private int numFlights;
        

        public FlightManager(int maxFlights)
        {
            this.maxFlights = maxFlights;
            numFlights = 0;
            flightList = new Flight[maxFlights];
        }

        public int search(int flightNumber)
        {
            for (int i = 0; i < flightList.Length; i++)
            {
                if (flightList[i] == null) { return -1; }
                else if (flightList[i].getFlightNumber() == flightNumber)
                {
                    return i;
                }
            }
            return -1;
        }

        public Flight findFlight(int index)
        {
            return flightList[index];
        }

        public bool addFlight(int flightNumber, int capacity, string origin, string destination)
        {
            if (numFlights < maxFlights)
            {
                if (search(flightNumber) == -1)
                {
                    flightList[numFlights] = new Flight(flightNumber, capacity, origin, destination);
                    numFlights++;
                    return true;
                }
            }
            return false;
        }

        public string viewAllFlights()
        {
            string s = "-------- Flights --------\n";
            for (int i = 0; i < numFlights; i++)
            {
                if (flightList[i] != null)
                {
                    s += flightList[i].ToString() + "\n";
                }
                
            }
            return s;
        }

        public string viewFlight(int flightNumber)
        {
            int index = search(flightNumber);
            if (index == -1)
            {
                return $"There is no flight with the flight number: {flightNumber}";
            }
            return flightList[index].ToString();
        }

        public string deleteFlight(int flightNumber)
        {
            int index = search(flightNumber);
            if (index != -1 && flightList[index].getNumCustomers()==0)
            {
                for (int i = index; i < flightList.Length-1; i++)
                {
                    flightList[i] = flightList[i + 1];
                }
                return "Successfully deleted!";
            }
            return "The flight could not be deleted as it does not exist or has customers on it.";
        }

        
    }
}
