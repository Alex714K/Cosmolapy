using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.main
{
    internal class MainViewModel
    {
        private MainModel model;
        private Action<int> setHoneyLabel;
        private Action<int> setWoodLabel;

        public MainViewModel(Action<int> _setHoneyLabel, Action<int> _setWoodLabel)
        {
            setHoneyLabel = _setHoneyLabel;
            setWoodLabel = _setWoodLabel;
            model = new MainModel(SetHoney, SetWoodLabel);
        }

        void SetHoney(int newHoney)
        {
            setHoneyLabel(newHoney);
        }
        void SetWoodLabel(int newHoney)
        {
            setWoodLabel(newHoney);
        }


    }
}
