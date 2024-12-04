using Cosmolapy.Cards;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmolapy.scenes.researches
{
    enum Reseraches
    {
        Cards,
        Cheap
    }

    internal class CellsModel
    {
        public Dictionary<Reseraches, Cell> cells;

        private void CheapCards()
        {
            foreach (Card card in Global.mainModel.cardModels.sampleCards)
            {
                card.Cheap();
            }
        }

        public CellsModel()
        {
            cells = new Dictionary<Reseraches, Cell>();
            cells[Reseraches.Cards] = new Cell("3 Cards", 200, true, () => Global.mainModel.cardModels.quantityCards = 3);
            cells[Reseraches.Cards].children.Add(new Cell("4 Cards", 100, false, () => Global.mainModel.cardModels.quantityCards = 4));
            cells[Reseraches.Cards].children[0].children.Add(new Cell("5 Cards", 100, false, () => Global.mainModel.cardModels.quantityCards = 5));

            cells[Reseraches.Cheap] = new Cell("Cheap cards", 200, true, CheapCards);
            cells[Reseraches.Cheap].children.Add(new Cell("Cheap cards 2", 200, false, CheapCards));
        }
    }
}
