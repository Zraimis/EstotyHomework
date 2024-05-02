
using System.Collections.Generic;
using UnityEngine;

public class GridManager 
{
    private List<Card> _cards = new List<Card>();
    private List<Slot> _slots = new List<Slot>();
    public GridManager()
    {
        Awake();
    }
    public static GridManager Instance { get; private set; }

    private void Awake()
    {
        

        if (Instance != null && Instance != this)
        {
            //Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    public void GetCards(Card card)
    {
        _cards.Add(card);
    }

    public void GetSlots(Slot slot) 
    {
        _slots.Add(slot);
    }
    public void UpdateGrid(int id)
    {
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
