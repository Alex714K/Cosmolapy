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
        private int honey;
        Action<int> setHoney;

        public int Honey
        {
            set
            {
                this.honey = value;
                setHoney(honey);
            }
            get
            {
                return honey;
            }
        }

        public MainModel(Action<int> _setHoney)
        {
            setHoney = _setHoney;
            Honey = 10;
            
        }



    }
}
