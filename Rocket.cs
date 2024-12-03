using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy
{
    internal class Rocket
    {
        int progress;
        int needProgress;

        public Rocket()
        {
            progress = 0;
            needProgress = 2;
        }

        public int Progress
        {
            get { return progress; }
        }
        public int NeedProgress
        {
            get { return  needProgress; }
        }

        public void PlusProgress()
        {
            progress += 1;
        }

    }
}
