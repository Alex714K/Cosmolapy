using Cosmolapy.Buildings.Generators;
using Cosmolapy.Cards;
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

        List<Generator> generators;
        public Generator sawmill;
        public Generator mednica;
        public Generator laboratory;
        public Generator mine;

        public Generator viewGenerator;

        public ListOfCards cardModels;

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
            resources = new Resources(100, 100, 100, 100);

            mednica = new Generator("Mednica", 100, 0, 0, 0);
            sawmill = new Generator("Sawmill", 0, 100, 0, -20);
            laboratory = new Generator("Laboratory", 0, -50, 0, 100);
            mine = new Generator("Mine", 0, 0, 100, -20);

            generators = new List<Generator>();
            generators.Add(mednica);
            generators.Add(sawmill);
            generators.Add(laboratory);
            generators.Add(mine);

            movables = new List<NextMovable>();
            movables.Add(sawmill);
            movables.Add(mednica);
            movables.Add(laboratory);
            movables.Add(mine);

            cardModels = new ListOfCards(generators);

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
