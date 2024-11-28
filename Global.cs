using Cosmolapy.scenes.main;
using Cosmolapy.scenes.researches;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy
{
    internal static class Global
    {
        public const string gameUUID = "77ff18fe-8fd9-493c-b0b4-1e65d5ca0a8b"; // TODO зашифровать

        public static MainModel mainModel;
        public static CellsModel cellsModel;
        static Global()
        {
            mainModel = new MainModel();
            cellsModel = new CellsModel();
        }
    }
}
