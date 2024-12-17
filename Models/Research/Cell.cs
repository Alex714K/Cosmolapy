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

        ActionSetDone actionSetDone;
        ActionSetDoneXY actionSetDoneXY;


        public delegate void ActionSetDone();
        public delegate void ActionSetDoneXY(int x, int y);

        public Cell(CellData _data, bool _parentDone, ActionSetDone _actionSetDone)
        {
            actionSetDone = _actionSetDone;
            children = new List<Cell>();
            data = _data;
            parentDone = _parentDone;
        }

        public Cell(CellData _data, bool _parentDone, ActionSetDoneXY _actionSetDoneXY)
        {
            actionSetDoneXY = _actionSetDoneXY;
            children = new List<Cell>();
            data = _data;
            parentDone = _parentDone;
        }

        public Cell(string _name, int _priceHoney, bool _parentDone, ActionSetDone _actionSetDone)
            : this(new CellData(_name, _priceHoney), _parentDone, _actionSetDone) { }

        public Cell(string _name, int _priceHoney, bool _parentDone, ActionSetDoneXY _actionSetDoneXY)
            : this(new CellData(_name, _priceHoney), _parentDone, _actionSetDoneXY) { }


        List<Cell> GetChildren()
        {
            if (children.Count != 0)
                return children;
            return null;
        }

        public void setDone()
        {
            actionSetDone();
            data.isDone = true;
            for (int i = 0; i < children.Count; i++)
            {
                children[i].parentDone = true;
            }
        }

    }
}
