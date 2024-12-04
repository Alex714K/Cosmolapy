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
        public List<Card> sampleCards;

        public int quantityCards;

        public ListOfCards(Dictionary<Generators, Generator> generators)
        {
            quantityCards = 2;

            cards = new List<Card>();
            sampleCards = new List<Card>();
            foreach (var generator in generators)
            {
                sampleCards.Add(new UpgradeBuildingCard(
                    "Upgrade\n" + generator.Value.name,
                    0, 100, 100, 100,
                    generator.Value.PlusProgress
                    ));
            }

            sampleCards.Add(new RocketCard(
                "Upgrade\nRocket", 100, 200, 200, 200
                ));

            Update();
        }

        public void Update()
        {
            Random random = new Random();
            cards.Clear();
            for (int i = 0; i < quantityCards; i++)
            {
                cards.Add(sampleCards[random.Next(0, sampleCards.Count)]);
            }
        }

    }
}
