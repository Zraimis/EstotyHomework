using System.Collections.Generic;
using System.Diagnostics;

public class GridManager 
{
    public static GridManager Instance { get; private set; }
    public GridManager()
    {
        Awake();
    }

    private List<Card> _cards = new List<Card>(); 
    private List<Card> _cardBank = new List<Card>();
    private List<Slot> _slots = new List<Slot>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            return;
        }
        else
        {
            Instance = this;
        }        
    }

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

    public void GetSlots(Slot slot) 
    {
        _slots.Add(slot);
    }
    public void UpdateGrid(int id)
    { 
        _slots.RemoveAll(s => s == null);
        foreach (Card card in _cards)
        {
            if(card != null) 
            { 
            if (card.id > id)
            {
                card.transform.SetParent(_slots[card.id-1].transform,false);
                card.id -= 1;
            }
            }
        }
    }
}