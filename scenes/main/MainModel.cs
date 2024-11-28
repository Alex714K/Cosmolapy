using Cosmolapy.Buildings.Generators;
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
        List<NextMovable> movables;
        public Sawmill sawmill;
        public Mednica mednica;

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

            mednica = new Mednica();
            sawmill = new Sawmill();

            movables = new List<NextMovable>();
            movables.Add(sawmill);
            movables.Add(mednica);

        }
        public void NextMove()
        {
            foreach (NextMovable movable in movables)
            {
                movable.NextMove();
            }

            move++;
        }
    }
}
