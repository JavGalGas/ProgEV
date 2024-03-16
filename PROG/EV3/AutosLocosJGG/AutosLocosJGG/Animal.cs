using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutosLocosJGG
{
    public class Animal : Driver
    {
        public override double GetVelocityExtra()
        {
            return Utils.GetRandomBetween(-1.0, 3.0);
        }
    }
}
