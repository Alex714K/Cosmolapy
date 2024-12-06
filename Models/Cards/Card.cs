using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Cards
{
    internal abstract class Card : ICloneable
    {
        string name;
        int honeyPrice;
        int woodPrice;
        int ironPrice;
        int biofuelPrice;

        public string Name
        {
            get { return name; }
        }
        public int HoneyPrice
        {
            get { return honeyPrice; }
        }
        public int WoodPrice
        {
            get { return woodPrice; }
        }
        public int IronPrice
        {
            get { return ironPrice; }
        }
        public int BiofuelPrice
        {
            get { return biofuelPrice; }
        }

        protected Card(string _name, int _honeyPrice, int _woodPrice, int _ironPrice, int _biofuelPrice)
        {
            name = _name;
            honeyPrice = _honeyPrice;
            woodPrice = _woodPrice;
            ironPrice = _ironPrice;
            biofuelPrice = _biofuelPrice;
        } 

        public void Cheap()
        {
            honeyPrice = (int)(honeyPrice * 0.9);
            woodPrice = (int)(woodPrice * 0.9);
            ironPrice = (int)(ironPrice * 0.9);
            biofuelPrice = (int)(biofuelPrice * 0.9);
        }

        public virtual bool Use()
        {
            if (Global.mainModel.resources.Honey >= honeyPrice &&
                Global.mainModel.resources.Wood >= woodPrice &&
                Global.mainModel.resources.Iron >= ironPrice &&
                Global.mainModel.resources.BioFuel >= biofuelPrice)
            {
                Global.mainModel.resources.Honey -= honeyPrice;
                Global.mainModel.resources.Wood -= woodPrice;
                Global.mainModel.resources.Iron -= ironPrice;
                Global.mainModel.resources.BioFuel -= biofuelPrice;
                return true;
            }
            return false;
        }

        public abstract object Clone();
        
    }
}