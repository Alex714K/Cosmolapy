using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes
{
    internal class Resources
    {
        private int honey;
        private int wood;

        public int Honey
        {
            set
            {
                honey = value;
            }
            get
            {
                return honey;
            }
        }

        public int Wood
        {
            set {

                wood = value;
            }
            get
            {
                return wood;
            }
        }

        public Resources()
        {
            Honey = 210;
            Wood = 20;
        }

    }
}
