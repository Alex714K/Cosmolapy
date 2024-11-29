﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings.Generators
{
    internal class Mednica : Generator
    {
        public Mednica() : base()
        {
            name = "Mednica";
            changeHoney = 10;
            changeWood = -2;
        }
    }
}