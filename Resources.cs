using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy
{
    internal class Resources
    {
        private int honey;
        private int wood;
        private int iron;
        private int bioFuel;

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
            set
            {
                wood = value;
            }
            get
            {
                return wood;
            }
        }
        public int Iron
        {
            set
            {
                iron = value;
            }
            get
            {
                return iron;
            }
        }
        public int BioFuel
        {
            set
            {
                bioFuel = value;
            }
            get
            {
                return bioFuel;
            }
        }

        public Resources(int _honey, int _wood, int _iron, int _bioFuel)
        {
            Honey = _honey;
            Wood = _wood;
            Iron = _iron;
            BioFuel = _bioFuel;
        }

    }
}
