using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Cards
{
    internal class UpgradeBuildingCard : Card
    {
        Action upgrade;

        public UpgradeBuildingCard(
            string _name, int _honeyPrice, int _woodPrice, int _ironPrice, int _biofuelPrice, Action upgrade)
            : base(_name, _honeyPrice, _woodPrice, _ironPrice, _biofuelPrice)
        {
            this.upgrade = upgrade;
        }

        public override bool Use()
        {
            if (base.Use())
            {
                upgrade();
                return true;
            }
            return false;
        }

        public override object Clone()
        {
            return new UpgradeBuildingCard(Name, HoneyPrice, WoodPrice, IronPrice, BiofuelPrice, upgrade);
        }

    }
}
