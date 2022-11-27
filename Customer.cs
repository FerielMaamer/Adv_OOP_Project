using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project
{
    internal class Customer
    {
        private int id = 0;
        private string fname;
        private string lname;
        private string phoneNum;

        public Customer(string fname, string lname, string phoneNum)
        {
            this.id = ++id;
            this.fname = fname;
            this.lname = lname;
            this.phoneNum = phoneNum;
        }

        public int getCustomerID()
        {
            return id;
        }

        public string getFname()
        {
            return fname;
        }

        public void setFname(string fname)
        {
            this.fname = fname;
        }

        public string getLname()
        {
            return lname;
        }

        public void setLname(string lname)
        {
            this.lname = lname;
        }

        public string getName()
        {
            return $"{fname} {lname}";
        }

        public string getPhoneNum()
        {
            return phoneNum;
        }

        public void setPhoneNum(string phoneNum)
        {
            this.phoneNum = phoneNum;
        }

        public override string ToString()
        {
            return $"Customer ID: {id}\nCustomer Name: {fname} {lname}\nCustomer Phone Number: {phoneNum}";
        }
    }
}