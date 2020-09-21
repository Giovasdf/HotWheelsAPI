using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotwheelsAPI.Models
{
    public class Car
    {
        public int IdCar { get; set; }
        public int Year { get; set; }
        public string Serie { get; set; }
        public string Name { get; set; }
        public string Model { get; set; }
        public string Colour { get; set; }
    }
}
