using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class Ride
    {
        public double distance;
        public int time;
        public Ride(double distance, int time) // this constructor is used to set the value of distance and time
        {
            this.distance = distance;
            this.time = time;
        }
    }

}
