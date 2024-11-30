using Cosmolapy.Buildings.Generators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.Cards
{
    internal class ListOfCards
    {
        public List<Card> cards;
        List<Card> sampleCards;

        public ListOfCards(List<Generator> generators)
        {
            cards = new List<Card>();
            sampleCards = new List<Card>();
            for (int i = 0; i < generators.Count; i++)
            {
                sampleCards.Add(new UpgradeBuildingCard(
                    "Upgrade\n" + generators[i].name,
                    0, 100, 100, 100,
                    generators[i].PlusProgress
                    ));
            }

            //sampleCards.Add(new UpgradeBuildingCard(
            //    "Upgrade\n" + generators[0].name,
            //    0, 100, 100, 100,
            //    generators[0].PlusProgress
            //    ));

            //sampleCards.Add(new UpgradeBuildingCard(
            //    "Upgrade\n" + generators[0].name,
            //    0, 100, 100, 100,
            //    generators[0].PlusProgress
            //    ));
            //sampleCards.Add(new UpgradeBuildingCard(
            //    "Upgrade\n" + generators[0].name,
            //    0, 100, 100, 100,
            //    Global.mainModel.mine.PlusProgress
            //    ));
            Update();
        }

        public void Update()
        {
            Random random = new Random();
            cards.Clear();
            for (int i = 0; i < 3; i++)
            {
                cards.Add(sampleCards[random.Next(0, sampleCards.Count)]);
            }
        }

    }
}
