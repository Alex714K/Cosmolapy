using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Cosmolapy.scenes.researches
{
    public struct CellData
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
    }
    public class Cell
    {
        public CellData data;
        public List<Cell> children;
        public bool parentDone;

        public Cell(string _name, int _priceHoney, bool _parentDone)
        {
            data = new CellData(_name, _priceHoney);
            children = new List<Cell>();
            parentDone = _parentDone;
        }

        public Cell(CellData _data)
        {
            data = _data;
        }

        List<Cell> GetChildren()
        {
            if (children.Count != 0)
                return children;
            return null;
        }

        public void setDone()
        {
            data.isDone = true;
            for (int i = 0; i < children.Count; i++)
            {
                children[i].parentDone = true;
            }
        }

    }
}
