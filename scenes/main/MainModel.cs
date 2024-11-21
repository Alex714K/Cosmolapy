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
        Resources resources;
        public MainModel(Action<int> _setHoney, Action<int> _setWood)
        {
            resources = new Resources(_setHoney, _setWood);
        }
    }
}
