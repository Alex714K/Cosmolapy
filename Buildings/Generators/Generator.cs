using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings.Generators
{
    internal abstract class Generator : Building
    {
        protected int changeHoney;
        protected int changeWood;
        protected int level;

        override public void NextMove()
        {
            Global.mainModel.resources.Honey += changeHoney;
            Global.mainModel.resources.Wood += changeWood;
        }

        public virtual void NextLevel()
        {
            changeHoney = (int)(changeHoney * 1.2f);
            changeWood = (int)(changeWood * 1.2f);
            level++;
        }

    }
}
