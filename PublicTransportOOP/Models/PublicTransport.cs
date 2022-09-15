using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportOOP.Models
{
    public abstract class PublicTransport
    {
        public PublicTransport(int passengers)
        {
            _passengers = passengers;
        }

        private int _passengers { get ; }

        public int Passengers { get { return _passengers; } }

        public string TypeOfTransport;

        public abstract void Move();

        public abstract void Stop();
    }
}
