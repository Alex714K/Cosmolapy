﻿using Cosmolapy.Buildings.Generators;
using Cosmolapy.Cards;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

enum Generators
{
    sawmill,
    mednica,
    laboratory,
    mine
}

namespace Cosmolapy.scenes.main
{
    internal class MainModel
    {
        public Rocket rocket;
        private int move;
        public Resources resources;
        List<NextMovable> movables;

        public bool alreadyShowPopup;

        public void ShowWinPopup(Popup winPopup)
        {
            if (rocket.Progress >= rocket.NeedProgress && !alreadyShowPopup)
            {
                alreadyShowPopup = true;
                winPopup.Popup();
            }
        }

        public Dictionary<Generators, Generator> generators;

        public Generator viewGenerator;

        public ListOfCards cardModels;

        public int Move
        {
            get
            {
                return move;
            }
        }

        public MainModel()
        {
            rocket = new Rocket();
            move = 1;
            resources = new Resources(100, 100, 100, 100);

            generators = new Dictionary<Generators, Generator>();
            generators[Generators.mednica] = new Generator("Mednica", 100, 0, 0, 0);
            generators[Generators.sawmill] = new Generator("Sawmill", 0, 100, 0, -20);
            generators[Generators.laboratory] = new Generator("Laboratory", 0, -50, 0, 100);
            generators[Generators.mine] = new Generator("Mine", 0, 0, 100, -20);

            movables = new List<NextMovable>();
            movables.Add(generators[Generators.mednica]);
            movables.Add(generators[Generators.sawmill]);
            movables.Add(generators[Generators.laboratory]);
            movables.Add(generators[Generators.mine]);

            cardModels = new ListOfCards(generators);

            alreadyShowPopup = false;

        }
        public void NextMove()
        {
            foreach (NextMovable movable in movables)
            {
                movable.NextMove();
            }

            move++;
        }
    }
}
