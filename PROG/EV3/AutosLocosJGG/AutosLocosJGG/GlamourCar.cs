using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class GlamourCar : Car
    {
        Driver driver = new Human();

        public GlamourCar(string name, double position, double finetunningValue) : base(name, position, finetunningValue)
        {
        }
    }
}
