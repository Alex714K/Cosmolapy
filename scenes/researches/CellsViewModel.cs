using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.researches
{
    internal class CellsViewModel
    {
        public CellsViewModel(Action<List<Cell>> fillCells)
        {
            fillCells(Global.cellsModel.cells);
        }

    }
}
