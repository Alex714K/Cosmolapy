using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Buildings.Generators
{
    internal class Generator : Building
    {
        public float changeHoney;
        public float changeWood;
        public float changeIron;
        public float changeBiofuel;
        public int level;

        int progressOfLevel;
        int needProgressOfLevel;

        public Generator(string _name, int _changeHoney, int _changeWood, int _changeIron, int _changeBiofuel)
        {
            changeHoney = _changeHoney;
            changeWood = _changeWood;
            changeIron = _changeIron;
            changeBiofuel = _changeBiofuel;

            needProgressOfLevel = 0;
            progressOfLevel = 0;
            level = 1;
        }

        public override void NextMove()
        {
            Global.mainModel.resources.Honey += (int)changeHoney;
            Global.mainModel.resources.Wood += (int)changeWood;
            Global.mainModel.resources.Iron += (int)changeIron;
            Global.mainModel.resources.BioFuel += (int)changeBiofuel;
        }

        public void PlusProgress()
        {
            progressOfLevel++;
            if (progressOfLevel == needProgressOfLevel)
            {
                NextLevel();
            }
        }

        public virtual void NextLevel()
        {
            changeHoney *= 1.2f;
            changeWood *= 1.2f;
            changeIron *= 1.2f;
            changeBiofuel *= 1.2f;
            level++;
        }

    }
}
