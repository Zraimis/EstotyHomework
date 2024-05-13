using System.Collections.Generic;
using UnityEngine;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] 
    private Card spawnCard;
    [SerializeField] 
    private CardConfig[] cardConfigContainer;
    private int _amountOfCardsOnScene = 2;
    private int _randomNumber;
    private int _amountOfCardsToSpawn;
    private List<int> _usedNumbers = new List<int>();
    private CardConfig _randomCard;

    private void RandomNumber()
    {
        _randomNumber = Random.Range(0, cardConfigContainer.Length);
    }
    public void SpawnCardsOnSlots()
    {
        for (int currentSlot = 0; currentSlot <= _amountOfCardsToSpawn; currentSlot++)
        {
            RandomNumber();
            while (_usedNumbers.Contains(_randomNumber))
            {
                RandomNumber();
            }
            _usedNumbers.Add(_randomNumber);
            
            _randomCard = cardConfigContainer[_randomNumber];
            Card card = ObjectPoolingManager.Instance.GetPooledObject();
            if(card != null) 
            { 
            card.transform.SetParent(transform.GetChild(currentSlot), false);           
            card.logo.sprite = _randomCard.logoSprite;
            card.activityPoints = _randomCard.activityPoints;
            card.currentAmount = _randomCard.currentAmount;
            card.maxAmount = _randomCard.maxAmount;
            card.cardTitle.text = _randomCard.cardTitle;
            card.isClaimable = _randomCard.isClaimable;
            card.id = currentSlot;     
            card.gameObject.SetActive(true);
            }
            
            if(_usedNumbers.Count >= 3)
            {
                _usedNumbers.Clear();
            }
        }
        _amountOfCardsOnScene += _amountOfCardsToSpawn+1;
        _amountOfCardsToSpawn = 3 - _amountOfCardsOnScene;       
    }

    public void ResetCards()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject target in gameObjects)
        {
            target.SetActive(false); ;          
        }
        _amountOfCardsToSpawn = 2;
        GridManager.Instance.ResetGridManager();
        SpawnCardsOnSlots();
    }
}