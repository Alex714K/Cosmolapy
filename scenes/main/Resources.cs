using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.main
{
    internal class Resources
    {
        private int honey;
        Action<int> setHoney;
        private int wood;
        Action<int> setWood;

        public int Honey
        {
            set
            {
                this.honey = value;
                setHoney(honey);
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
                this.wood = value;
                setWood(wood);
            }
            get
            {
                return wood;
            }
        }

        public Resources(Action<int> _setHoney, Action<int> _setWood)
        {
            setHoney = _setHoney;
            setWood = _setWood;
            Honey = 10;
            Wood = 20;

        }

    }
}
