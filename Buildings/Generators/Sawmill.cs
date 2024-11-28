using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings.Generators
{
    internal class Sawmill : Generator
    {
        public Sawmill()
        {
            name = "Sawmill";
            changeWood = 10;
            changeHoney = -2;
        }
    }
}
