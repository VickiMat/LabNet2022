using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportOOP.Models
{
    internal class Bus : PublicTransport
    {
        public Bus(int passengers) : base(passengers)
        {
            TypeOfTransport = "Bus";
        }

        public override void Move()
        {
            Console.WriteLine("Bus moving to the next stop");
        }

        public override void Stop()
        {
            Console.WriteLine("Bus stopping at the stop");
        }
    }
}
