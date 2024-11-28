using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings.Generators
{
    internal abstract class Generator : Building
    {
        public float changeHoney;
        public float changeWood;
        public int level;

        override public void NextMove()
        {
            Global.mainModel.resources.Honey += (int)changeHoney;
            Global.mainModel.resources.Wood += (int)changeWood;
        }

        public virtual void NextLevel()
        {
            changeHoney *= 1.2f;
            changeWood *= 1.2f;
            level++;
        }

    }
}
