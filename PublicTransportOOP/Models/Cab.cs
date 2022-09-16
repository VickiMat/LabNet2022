using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportOOP.Models
{
    public class Cab : PublicTransport
    {
        public Cab(int passengers) : base(passengers)
        {
            TypeOfTransport = "Cab";

        }

        public override string Move()
        {
            return "mooving forward and looking for passengers";
        }

        public override string Stop()
        {
            return "stopping";
        }
    }
}
