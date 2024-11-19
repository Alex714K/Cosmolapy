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

        public MainViewModel(Action<int> _setHoneyLabel)
        {
            setHoneyLabel = _setHoneyLabel;
            model = new MainModel(SetHoney);
            
            GD.Print(setHoneyLabel.ToString());
        }

        void SetHoney(int newHoney)
        {
            
            if (setHoneyLabel != null)
            {
            GD.Print("loool");
                setHoneyLabel(newHoney);
            }
            
        }


    }
}
