using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cosmolapy.Cards
{
    internal class RocketCard : Card
    {
        public RocketCard(string _name, int _honeyPrice, int _woodPrice, int _ironPrice, int _biofuelPrice)
            : base(_name, _honeyPrice, _woodPrice, _ironPrice, _biofuelPrice)
        {
        }

        public override object Clone()
        {
            return new RocketCard(Name, HoneyPrice, WoodPrice, IronPrice, BiofuelPrice);
        }

        public override bool Use()
        {
            if (base.Use())
            {
                Global.mainModel.rocket.PlusProgress();
                return true;
            }
            return false;
        }

    }
}
