using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Practica.EF.Entities.WizardWorld
{
    public class Root
    {
        public string id { get; set; }
        public string name { get; set; }
        public string houseColours { get; set; }
        public string founder { get; set; }
        public string animal { get; set; }
        public string element { get; set; }
        public string ghost { get; set; }
        public string commonRoom { get; set; }
        public List<Head> heads { get; set; }
        public List<Trait> traits { get; set; }

    }
}
