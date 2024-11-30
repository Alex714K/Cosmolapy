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

        public ListOfCards(Dictionary<Generators, Generator> generators)
        {
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
