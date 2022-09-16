using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportOOP.Models
{
    public abstract class PublicTransport
    {
        private int _passengers;

        public PublicTransport(int passengers)
        {
            _passengers = passengers;
        }

        public int Passengers { get { return _passengers; } }

        public string TypeOfTransport { get; set;}

        public abstract string Move();

        public abstract string Stop();
    }
}
