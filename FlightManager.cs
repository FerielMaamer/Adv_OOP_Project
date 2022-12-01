using System;
using System.Collections.Generic;
using System.IO;
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
            loadUpDataFromFlightsFile();
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
                    updateFlightsFile();
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
                updateFlightsFile();
                return "Successfully deleted!";
            }
            return "The flight could not be deleted as it does not exist or has customers on it.";
        }
        
        private void updateFlightsFile()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter("./dataFiles/flights.txt"))
                {

                    foreach (Flight f in flightList)
                    {
                        if (f != null)
                        {
                            writer.WriteLine("{0},{1},{2},{3}", f.getFlightNumber().ToString(), f.getCapacity().ToString(), f.getOrigin() , f.getDestination());
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
        
        private void loadUpDataFromFlightsFile()
        {
      
            //loop over each line of the file 
            //turn the line into an array 
            //use addFlights() to add up the data
            
            // Read file using StreamReader. Reads file line by line    
            using(StreamReader file = new StreamReader("./dataFiles/flights.txt")) {  
             
                string ln;
                while (( ln = file.ReadLine()) != null) {  
                    // Console.WriteLine(ln);
                    string[] columns = ln.Split(",");
                    addFlight(int.Parse(columns[0]), int.Parse(columns[1]), columns[2], columns[3]);
                }  
                file.Close();  
           
            }  
        }

        
    }
}
