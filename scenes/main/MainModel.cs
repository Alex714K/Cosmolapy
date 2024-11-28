using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Cosmolapy.scenes.main
{
    internal class MainModel
    {
        private int move;
        public Resources resources;

        public int Move
        {
            get
            {
                return move;
            }
        }

        public MainModel()
        {
            move = 1;
            resources = new Resources(210, 100);
        }

        public void NextMove()
        {
            move++;
        }
    }
}
