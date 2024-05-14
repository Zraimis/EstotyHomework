using System.Collections.Generic;

public class GridManager
{
    public static GridManager Instance { get; private set; }
    public GridManager()
    {
        if (Instance != null && Instance != this)
        {
            return;
        }
        // TODO "else" is redundant here
        else
        {
            Instance = this;
        }
    }

    private List<Card> _cards = new List<Card>();
    private List<Card> _cardBank = new List<Card>();
    private List<Slot> _slots = new List<Slot>();

    // TODO AddCard would be better name
    public void GetCards(Card card)
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

    
    // TODO AddSlot would be better name
    public void GetSlots(Slot slot)
    {
        _slots.Add(slot);
    }

    public void UpdateGrid(int id)
    {
        foreach (Card card in _cards)
        {
            if (card.id > id)
            {
                card.transform.SetParent(_slots[card.id - 1].transform, false);
                card.id -= 1;
            }          
        }
    }
}