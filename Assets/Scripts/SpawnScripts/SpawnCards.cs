using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private Card spawnCard;
    [SerializeField] private CardConfig[] cardConfigContainer;

    private int amountOfCardsOnScene;
    private int randomNumber;
    private int amountOfCardsToSpawn;
    private List<int> usedNumbers = new List<int>();
    private CardConfig randomCard;
    
    public void Start()
    {     
        amountOfCardsToSpawn = 2;   
    }

    private void RandomNumber()
    {
        randomNumber = Random.Range(0, cardConfigContainer.Length);
    }
    public void SpawnCardsOnSlots()
    {    
        for (int currentSlot = 0; currentSlot <= amountOfCardsToSpawn; currentSlot++)
        {
            RandomNumber();
            while (usedNumbers.Contains(randomNumber))
            {
                RandomNumber();
            }
            usedNumbers.Add(randomNumber);
            
            randomCard = cardConfigContainer[randomNumber];
            Card card = ObjectPool.Instance.GetPooledObject();
            if(card != null) 
            { 
            card.transform.SetParent(transform.GetChild(currentSlot), false);           
            card.logo.sprite = randomCard.logoSprite;
            card.activityPoints = randomCard.activityPoints;
            card.currentAmount = randomCard.currentAmount;
            card.maxAmount = randomCard.maxAmount;
            card.cardTitle.text = randomCard.cardTitle;
            card.isClaimable = randomCard.isClaimable;
            card.id = currentSlot;     
            card.gameObject.SetActive(true);
            }
            
            if(usedNumbers.Count >= 3)
            {
                usedNumbers.Clear();
            }
        }
        amountOfCardsOnScene += amountOfCardsToSpawn+1;
        amountOfCardsToSpawn = 3 - amountOfCardsOnScene;       
    }

    public void ResetCards()
    {
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Respawn");
        foreach (GameObject target in gameObjects)
        {
            target.SetActive(false); ;          
        }
        amountOfCardsToSpawn = 2;
        GridManager.Instance.ResetGridManager();
        SpawnCardsOnSlots();
    }
}