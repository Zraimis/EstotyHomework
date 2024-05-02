using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpawnCards : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private Card spawnCard;
    [SerializeField] private ButtonSpawn buttonSpawn;
    [SerializeField] private TMP_Text activityPoointsPanelText;
    [SerializeField] private GameObject chestClickArea;
    [SerializeField] private Image chestImage;
    [SerializeField] private Bank bank;
    [SerializeReference] private CardConfig[] cardConfigContainer;

    private int amountOfCardsOnScene;
    private int randomNumber;
    private int amountOfCardsToSpawn;
    private List<int> usedNumbers = new List<int>();
    private CardConfig randomCard;
    
    public void Start()
    {                
        amountOfCardsToSpawn = 2;   
        SpawnCardsOnSlots();
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
            Card card = Instantiate(spawnCard);
            card.transform.SetParent(transform.GetChild(currentSlot), false);
            card.progressBar = progressBar;
            card.activityPointsPanelText = activityPoointsPanelText;
           
            card.logo.sprite = randomCard.logoSprite;
            card.activityPoints = randomCard.activityPoints;
            card.currentAmount = randomCard.currentAmount;
            card.maxAmount = randomCard.maxAmount;
            card.cardTitle.text = randomCard.cardTitle;
            card.isClaimable = randomCard.isClaimable;
            card.id = currentSlot;
            

            GridManager.Instance.GetCards(card);
            
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
            Destroy(target);          
        }
        amountOfCardsToSpawn = 2;
        SpawnCardsOnSlots();
    }
}