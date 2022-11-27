using System;
using System.Collections.Generic;
using System.Void;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Flight
    {
        private int flightNumber;

        public Flight(int flightNumber)
        {
            this.flightNumber = flightNumber;
        }

        public int getFlightNumber()
        {
            return flightNumber;
        }

        public void setFlightNumber(int flightNumber)
        {
            this.flightNumber = flightNumber;
        }

        public override string ToString()
        {
            return $"Flight number: {flightNumber}\n";
        }
    }
}