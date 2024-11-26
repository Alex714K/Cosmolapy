using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.researches
{
    internal class CellsModel
    {
        //public List<Cell> cells;
        public Dictionary<string, Cell> cells;

        public CellsModel()
        {
            cells = new Dictionary<string, Cell>();
            cells["Rocket"] = new Cell("Rocket", 100, true);
            
            cells["Rocket"].children.Add(new Cell("Rocket1", 50, false));
            cells["Rocket"].children[0].children.Add(new Cell("Rocket2", 50, false));
            cells["Rocket"].children.Add(new Cell("Launcher1", 50, false));
            cells["Rocket"].children[1].children.Add(new Cell("Launcher2", 50, false));

            cells["BioFuel"] = new Cell("BioFuel", 100, true);
            cells["BioFuel"].children.Add(new Cell("BioFuel1", 50, false));


            //cells[0].children[1].children.Add(new Cell("Child01", 50));
            //cells[0].children[2].children.Add(new Cell("Child02", 50));

            //cells[1].children.Add(new Cell("Child21", 50));
            //cells[1].children.Add(new Cell("Child22", 50));
            //cells[1].children[0].children.Add(new Cell("Child21", 50));
            //cells[1].children[0].children.Add(new Cell("Child21", 50));
            //cells.Add(new Cell("Aaaa", 50));
        }



    }
}
