﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.researches
{
    internal class CellsModel
    {
        public List<Cell> cells;

        public CellsModel()
        {
            cells = new List<Cell>();
            cells.Add(new Cell("Flight", 100));
        }



    }
}
