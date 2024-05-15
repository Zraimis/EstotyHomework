using EstotyHomework.Items;
using System.Collections.Generic;
using System.Linq;

namespace EstotyHomework.Managers
{
    public class GridManager
    {
        public static GridManager Instance { get; private set; }
        public GridManager()
        {
            if (Instance != null && Instance != this)
            {
                return;
            }
            Instance = this;
        }

        private List<Card> _cards = new List<Card>();
        private List<Card> _cardBank = new List<Card>();
        private List<Slot> _slots = new List<Slot>();
        public void AddCard(Card card)
        {
            _cards.Add(card);
            _cardBank.Add(card);
        }

        public void ResetGridManager()
        {
            _cards = _cardBank;
        }

        public void ClearGridCards()
        {
            _cards = new List<Card>();
            _cardBank = new List<Card>();
            _slots = new List<Slot>();
        }

        public void AddSlot(Slot slot)
        {
            _slots.Add(slot);
        }

        public void UpdateGrid(int id)
        {
            foreach (Card card in _cards.Where(card => card.id > id))
            {
                card.transform.SetParent(_slots[card.id - 1].transform, false);
                card.id -= 1;
            }
        }
    }
}