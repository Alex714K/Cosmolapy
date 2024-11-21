using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

struct CellData
{
    public readonly string name;
    public bool isDone = false;
    public int priceHoney;
    public CellData(string _name, int _priceHoney)
    {
        name = _name;
        isDone = false;
        priceHoney = _priceHoney;
    }
    public CellData(string _name) 
    {
        name = _name;
        isDone = false;
        priceHoney = 10;
    }
}

namespace Cosmolapy.scenes.researches
{
    internal class Cell
    {
        CellData data;
        private List<Cell> children;

        public Cell(string _name, int _priceHoney)
        {
            data = new CellData(_name, _priceHoney);
        }

        List<Cell> GetChildren()
        {
            if (children.Count != 0)
                return children;
            return null;
        }



    }
}
